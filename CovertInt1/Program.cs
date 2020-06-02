using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovertInt1
{
  class Program
  {
    static void Main(string[] args)
    {
      string line;
      int number;
      do
      {
        line = Console.ReadLine();
        if (!int.TryParse(line, out number))
        {
          number = -1;
        }
      } while (number == -1);

      Console.WriteLine($"Number: {number}");

      Console.Write("\nPress any key...");
      Console.ReadKey();
    }
  }
}
