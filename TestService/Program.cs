using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHi.Extensions;

namespace CHi
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine(ServiceExtensions.IsStarted("MSSQLServer", true));

      //Console.WriteLine($"The SQL Server is installed: {"SQL Server (MSSQLSERVER)".DoesExist()}");
      //Console.WriteLine($"The SQL Server is installed: {"MSSQLSERVER".DoesExist()}");
      //Console.WriteLine($"The SQL Server is running: {"MSSQLSERVER".IsStarted(true)}");
      
      Console.Write("\nPress any key...");
      Console.ReadKey();
    }
  }
}
