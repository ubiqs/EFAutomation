using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAutomation.Services
{
    public class PropertyTS
    {

        private string DataType { get; set; }
        private string Name { get; set; }

        public PropertyTS(string name, string dataType)
        {
            Name = name;
            DataType = dataType;
        }

        public override string ToString()
        {
            return string.Format(" {0}: {1};", Name, DataType);
        }
    }
}
