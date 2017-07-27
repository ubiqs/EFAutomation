using EFAutomation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAutomation.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            PocoClassService pocoClassService = new PocoClassService();
            object classCode = pocoClassService.GetClassCode("Grid_Errors", @"C:\_Code\_EFAutomation\EFAutomation.Services\Templates", "DM.ConfigAuditor.Model.ViewModel");
            object c2 = classCode;
        }
    }
}
