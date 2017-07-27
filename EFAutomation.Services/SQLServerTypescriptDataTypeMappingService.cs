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
            _DataTypeMapping.Add("text", "string");
            _DataTypeMapping.Add("uniqueidentifier", "any");
            _DataTypeMapping.Add("date", "any");
            _DataTypeMapping.Add("time", "any");
            _DataTypeMapping.Add("datetime2", "any");
            _DataTypeMapping.Add("datetimeoffset", "any");
            _DataTypeMapping.Add("tinyint", "number");
            _DataTypeMapping.Add("smallint", "number");
            _DataTypeMapping.Add("int", "number");
            _DataTypeMapping.Add("smalldatetime", "any");
            _DataTypeMapping.Add("real", "number");
            _DataTypeMapping.Add("money", "number");
            _DataTypeMapping.Add("datetime", "any");
            _DataTypeMapping.Add("float", "number");
            _DataTypeMapping.Add("sql_variant", "any");
            _DataTypeMapping.Add("ntext", "string");
            _DataTypeMapping.Add("bit", "boolean");
            _DataTypeMapping.Add("decimal", "number");
            _DataTypeMapping.Add("numeric", "number");
            _DataTypeMapping.Add("smallmoney", "number");
            _DataTypeMapping.Add("bigint", "number");
            //_DataTypeMapping.Add("hierarchyid", "Byte[]");
            //_DataTypeMapping.Add("geometry", "Byte[]");
            //_DataTypeMapping.Add("geography", "Byte[]");
            _DataTypeMapping.Add("varbinary", "any");
            _DataTypeMapping.Add("varchar", "string");
            _DataTypeMapping.Add("binary", "any");
            _DataTypeMapping.Add("char", "string");
            _DataTypeMapping.Add("timestamp", "any");
            _DataTypeMapping.Add("nvarchar", "string");
            _DataTypeMapping.Add("nchar", "string");
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
