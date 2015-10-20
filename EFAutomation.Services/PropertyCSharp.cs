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

        public PropertyCSharp(string name, string dataType)
        {
            Name = name;
            DataType = dataType;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} get; set; {4}", _AccessModifier, DataType, Name, "{", "}");
        }
    }
}
