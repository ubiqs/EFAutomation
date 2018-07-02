using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAutomation.Services
{
    public class PropertyCSharp
    {
        private string _AccessModifier = "public";
        private string DataType { get; set; }
        private string Name { get; set; }
        private bool IsPrimaryKey { get; set; }

        public PropertyCSharp(string name, string dataType, bool isPrimaryKey)
        {
            Name = name;
            DataType = dataType;
            IsPrimaryKey = isPrimaryKey;
        }

        public override string ToString()
        {
            string keyString = string.Empty;
            if(IsPrimaryKey)
            {
                keyString = "[Key]" + Environment.NewLine;
            }

            return string.Format("{5}{0} {1} {2} {3} get; set; {4}", _AccessModifier, DataType, Name, "{", "}", keyString);
        }
    }
}
