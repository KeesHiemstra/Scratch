using System;

namespace ConsoleApp1
{
    public static class StringExtentions
    {
      public static string DateDiff(this DateTime DateMeasure)
      {
        return DateDiff(DateMeasure, DateTime.Now);
      }

      public static string DateDiff(this DateTime DateMeasure, DateTime DateReference)
      {
        string result = string.Empty;
        if (DateReference == null)
        {
          DateReference = DateTime.Now;
        }

        //Round the DataReference to minute
        if (DateReference.Second < 30)
        {
          DateReference = DateReference.AddSeconds(-DateReference.Second);
        }
        else
        {
          DateReference = DateReference.AddSeconds(60 - DateReference.Second);
        }

        System.Console.WriteLine(DateReference);

        TimeSpan timeDiff = DateReference.Subtract(DateMeasure);

        if (timeDiff.Days < 1)
        {
          return $"{timeDiff.Hours} u {timeDiff.Minutes} m";
        }

        if (timeDiff.Days < 7)
        {
          return $"{timeDiff.Days} d {timeDiff.Hours} h";
        }

        (int Week, int Day) Weeks = CalcWeeks(timeDiff);

        if (Weeks.Week > 0)
        {
          result = $"{Weeks.Week} w {Weeks.Day}";
        }

        Console.WriteLine(timeDiff.ToString());

        return result;
      }

      private static (int Week, int Day) CalcWeeks(TimeSpan ts)
      {
        int Weeks = ts.Days / 7;
        int Days = ts.Days - (Weeks * 7);

        return (Weeks, Days);
      }

    }
}
