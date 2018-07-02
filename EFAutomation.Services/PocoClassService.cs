using EFAutomation.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAutomation.Services
{
    public class PocoClassService
    {
        private string TEMPLATE_NAME = "PocoClassTemplate.txt";
        private string TEMPLATE_NAME_TS = "TypeScriptInterfaceTemplate.txt";

        public object GetClassCode(string tableName, string templatePath, string nameSpace)
        {
            List<DatabaseColumn> databaseColumns = null;
            string fullTemplatePath = Path.Combine(templatePath, TEMPLATE_NAME);
            string fullTemplatePath_TS = Path.Combine(templatePath, TEMPLATE_NAME_TS);

            databaseColumns = LoadDatabaseColumns(tableName);

            string pocoClassTemplate = LoadTemplate(fullTemplatePath);
            string typeScriptInterfaceTemplate = LoadTemplate(fullTemplatePath_TS);

            string properties = string.Empty;
            string propertiesTypeScript = string.Empty;


            foreach (var column in databaseColumns)
            {
                properties += new PropertyCSharp(column.Name, SQLServerCSharpDataTypeMappingService.GetCSharpType(column.DataType, column.IsNullable), column.IsPrimaryKey).ToString() + Environment.NewLine;
                propertiesTypeScript += new PropertyTS(column.Name, SQLServerTypescriptDataTypeMappingService.GetCSharpType(column.DataType, column.IsNullable)).ToString() + Environment.NewLine;
            }

            pocoClassTemplate = pocoClassTemplate.Replace(TemplateConstants.ClassName, tableName);
            pocoClassTemplate = pocoClassTemplate.Replace(TemplateConstants.Namespace, nameSpace);
            pocoClassTemplate = pocoClassTemplate.Replace(TemplateConstants.Properties, properties);

            typeScriptInterfaceTemplate = typeScriptInterfaceTemplate.Replace(TemplateConstants.ClassName, tableName);
            typeScriptInterfaceTemplate = typeScriptInterfaceTemplate.Replace(TemplateConstants.Properties, propertiesTypeScript);

            return new { ClassTemplate = pocoClassTemplate, TypeScriptInterfaceTemplate = typeScriptInterfaceTemplate };
        }

        private string LoadTemplate(string fullTemplatePath)
        {
            using (FileStream stream = new FileStream(fullTemplatePath, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        private List<DatabaseColumn> LoadDatabaseColumns(string tableName)
        {
            using (EFAutomationDbContext context = new EFAutomationDbContext())
            {
                using (ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext)
                {
                    //objectContext.Connection.Open();
                    string query = string.Format(@"SELECT 
                                                                c.name Name,
                                                                t.Name DataType,
                                                                c.max_length 'Max Length',
                                                                c.precision ,
                                                                c.scale ,
                                                                c.is_nullable IsNullable,
                                                                ISNULL(i.is_primary_key, 0) 'IsPrimaryKey'
                                                            FROM    
                                                                sys.columns c
                                                            INNER JOIN 
                                                                sys.types t ON c.user_type_id = t.user_type_id
                                                            LEFT OUTER JOIN 
                                                                sys.index_columns ic ON ic.object_id = c.object_id AND ic.column_id = c.column_id
                                                            LEFT OUTER JOIN 
                                                                sys.indexes i ON ic.object_id = i.object_id AND ic.index_id = i.index_id
                                                            WHERE
                                                                c.object_id = OBJECT_ID('{0}')
                                                             Order By IsPrimaryKey Desc", tableName);

                    return objectContext
                       .ExecuteStoreQuery<DatabaseColumn>(query).ToList();


                }

            }

        }
    }
}
