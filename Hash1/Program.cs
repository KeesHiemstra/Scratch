using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash1
{
  class Program
  {
    static void Main(string[] args)
    {
      string password;

      Console.Write("Password: ");
      password = Console.ReadLine();

      Console.WriteLine($"\n{password.GetHashCode():X8}");

      Console.Write("\nPress any key...");
      Console.ReadKey();
    }
  }
}
