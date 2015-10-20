using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAutomation.Model
{
    public class DatabaseColumn
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public bool IsNullable {get; set;}
        public bool IsPrimaryKey { get; set; }
    }
}
