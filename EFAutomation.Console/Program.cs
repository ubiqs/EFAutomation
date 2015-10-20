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
            string classCode = pocoClassService.GetClassCode("dimProvider", @"C:\Projects\EFAutomation\EFAutomation.Services\Templates", "DM.ClaimTarget.DataLoader");
           string c2 = classCode;
        }
    }
}
