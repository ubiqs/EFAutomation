using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAutomation.Services
{
    public static class SQLServerTypescriptDataTypeMappingService
    {
        private static Dictionary<string, string> _DataTypeMapping = new Dictionary<string, string>();
        private static HashSet<string> _NullableCSharpTypes = new HashSet<string>();

        static SQLServerTypescriptDataTypeMappingService()
        {
            //Load Mapping
            _DataTypeMapping.Add("image", "any");
            _DataTypeMapping.Add("text", "String");
            _DataTypeMapping.Add("uniqueidentifier", "any");
            _DataTypeMapping.Add("date", "any");
            _DataTypeMapping.Add("time", "any");
            _DataTypeMapping.Add("datetime2", "any");
            _DataTypeMapping.Add("datetimeoffset", "any");
            _DataTypeMapping.Add("tinyint", "Number");
            _DataTypeMapping.Add("smallint", "Number");
            _DataTypeMapping.Add("int", "Number");
            _DataTypeMapping.Add("smalldatetime", "any");
            _DataTypeMapping.Add("real", "Number");
            _DataTypeMapping.Add("money", "Number");
            _DataTypeMapping.Add("datetime", "any");
            _DataTypeMapping.Add("float", "Number");
            _DataTypeMapping.Add("sql_variant", "any");
            _DataTypeMapping.Add("ntext", "String");
            _DataTypeMapping.Add("bit", "Boolean");
            _DataTypeMapping.Add("decimal", "Number");
            _DataTypeMapping.Add("numeric", "Number");
            _DataTypeMapping.Add("smallmoney", "Number");
            _DataTypeMapping.Add("bigint", "Number");
            //_DataTypeMapping.Add("hierarchyid", "Byte[]");
            //_DataTypeMapping.Add("geometry", "Byte[]");
            //_DataTypeMapping.Add("geography", "Byte[]");
            _DataTypeMapping.Add("varbinary", "any");
            _DataTypeMapping.Add("varchar", "String");
            _DataTypeMapping.Add("binary", "any");
            _DataTypeMapping.Add("char", "String");
            _DataTypeMapping.Add("timestamp", "any");
            _DataTypeMapping.Add("nvarchar", "String");
            _DataTypeMapping.Add("nchar", "String");
            _DataTypeMapping.Add("xml", "any");
            //_DataTypeMapping.Add("sysname", "Byte[]");


        }

        public static string GetCSharpType(string databaseType, bool isNullable)
        {
            string returnValue = string.Empty;

            if (_DataTypeMapping.ContainsKey(databaseType))
            {
                returnValue = _DataTypeMapping[databaseType];

            }
            else
            {
                throw (new Exception("Database Type Not Found."));
            }

            return returnValue;
        }
    }
}
