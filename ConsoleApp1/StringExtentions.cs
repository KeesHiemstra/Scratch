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

			DateReference = RoundTimeMinute(DateReference);
			DateMeasure = RoundTimeMinute(DateMeasure);

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

		private static DateTime RoundTimeMinute(DateTime dateTime)
		{

			//Round the DataReference to minute
			if (dateTime.Second < 30)
			{
				dateTime = dateTime.AddSeconds(-dateTime.Second);
			}
			else
			{
				dateTime = dateTime.AddSeconds(60 - dateTime.Second);
			}

			return dateTime;

		}

		private static DateTime RoundTimeHour(DateTime dateTime)
		{

			//Round the DataReference to minute
			if (dateTime.Minute < 30)
			{
				dateTime = dateTime.AddMinutes(-dateTime.Minute);
			}
			else
			{
				dateTime = dateTime.AddMinutes(60 - dateTime.Minute);
			}

			return dateTime;

		}

		private static (int Week, int Day) CalcWeeks(TimeSpan ts)
		{
			int Weeks = ts.Days / 7;
			int Days = ts.Days - (Weeks * 7);

			return (Weeks, Days);
		}

	}
}
