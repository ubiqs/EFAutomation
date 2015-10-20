using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAutomation.Services
{
    public static class SQLServerCSharpDataTypeMappingService
    {
        private static Dictionary<string, string> _DataTypeMapping = new Dictionary<string, string>();
        private static HashSet<string> _NullableCSharpTypes = new HashSet<string>();
        
        static SQLServerCSharpDataTypeMappingService()
        {
            //Load Mapping
            _DataTypeMapping.Add("image", "Byte[]");
            _DataTypeMapping.Add("text", "String");
            _DataTypeMapping.Add("uniqueidentifier", "Guid");
            _DataTypeMapping.Add("date", "DateTime");
            _DataTypeMapping.Add("time", "TimeSpan");
            _DataTypeMapping.Add("datetime2", "DateTime");
            _DataTypeMapping.Add("datetimeoffset", "DateTimeOffset");
            _DataTypeMapping.Add("tinyint", "Byte");
            _DataTypeMapping.Add("smallint", "Int16");
            _DataTypeMapping.Add("int", "int");
            _DataTypeMapping.Add("smalldatetime", "DateTime");
            _DataTypeMapping.Add("real", "Single");
            _DataTypeMapping.Add("money", "Decimal");
            _DataTypeMapping.Add("datetime", "DateTime");
            _DataTypeMapping.Add("float", "Double");
            _DataTypeMapping.Add("sql_variant", "Object");
            _DataTypeMapping.Add("ntext", "String");
            _DataTypeMapping.Add("bit", "bool");
            _DataTypeMapping.Add("decimal", "Decimal");
            _DataTypeMapping.Add("numeric", "Decimal");
            _DataTypeMapping.Add("smallmoney", "Decimal");
            _DataTypeMapping.Add("bigint", "Int64");
            //_DataTypeMapping.Add("hierarchyid", "Byte[]");
            //_DataTypeMapping.Add("geometry", "Byte[]");
            //_DataTypeMapping.Add("geography", "Byte[]");
            _DataTypeMapping.Add("varbinary", "Byte[]");
            _DataTypeMapping.Add("varchar", "string");
            _DataTypeMapping.Add("binary", "Byte[]");
            _DataTypeMapping.Add("char", "String");
            _DataTypeMapping.Add("timestamp", "Byte[]");
            _DataTypeMapping.Add("nvarchar", "String");
            _DataTypeMapping.Add("nchar", "String");
            _DataTypeMapping.Add("xml", "Xml");
            //_DataTypeMapping.Add("sysname", "Byte[]");

            //add nullable types
            _NullableCSharpTypes.Add("int");
            _NullableCSharpTypes.Add("bool");
            _NullableCSharpTypes.Add("Boolean");
            _NullableCSharpTypes.Add("Byte");
            _NullableCSharpTypes.Add("Decimal");
            _NullableCSharpTypes.Add("Double");
            _NullableCSharpTypes.Add("float");
            _NullableCSharpTypes.Add("Int64");
            _NullableCSharpTypes.Add("Int32");
            _NullableCSharpTypes.Add("Int16");
            _NullableCSharpTypes.Add("DateTime");
            
            

        }

        public static string GetCSharpType(string databaseType, bool isNullable)
        {
            string returnValue = string.Empty;

            if(_DataTypeMapping.ContainsKey(databaseType))
            {
                returnValue = _DataTypeMapping[databaseType];
                if(isNullable && _NullableCSharpTypes.Contains(returnValue))
                {
                    returnValue += "?";
                }
            }
            else
            {
                throw(new Exception("Database Type Not Found."));
            }

            return returnValue;
        }

    }
}
