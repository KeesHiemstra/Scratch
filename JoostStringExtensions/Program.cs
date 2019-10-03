using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoostStringExtensions
{
  class Program
  {
    static void Main(string[] args)
    {
      DateTime dateTime = new DateTime(2020, 1, 1);
      for (int i = 0; i < 24; i++)
      {
        dateTime = dateTime.AddMonths(-1);
        Console.WriteLine(dateTime.DateDiff(new DateTime(2020, 2, 2)));
      }

      Console.Write("\nPress any key...");
      Console.ReadKey();
    }
  }
}
