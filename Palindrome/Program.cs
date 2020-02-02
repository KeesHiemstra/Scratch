using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
  class Program
  {
    static void Main(string[] args)
    {

      int year = 2019;
      string date;
      do
      {
        date = CreateDate(year);
        year--;
      } while (!DateIsValid(date));
      Console.WriteLine(CreateDate(year));

      Console.WriteLine("\nPress any key...");
      Console.ReadKey();

    }

    private static bool DateIsValid(string date)
    {
      try
      {
        int year = int.Parse(date.Substring(4, 4));
        int month = int.Parse(date.Substring(2, 2));
        int day = int.Parse(date.Substring(0, 2));
        DateTime dateTime = new DateTime(year, month, day);
        return true;
      }
      catch
      {
        return false;
      }
    }

    private static string CreateDate(int year)
    {

      string date = "";
      string _year = year.ToString();
      for (int i = 0; i < 4; i++)
      {
        date += _year[3 - i];
      }
      date += _year;

      return date;
    }
  }
}
