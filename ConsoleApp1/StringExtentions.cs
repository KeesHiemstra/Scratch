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

			DateReference = RoundTimeMinute(DateReference);
			DateMeasure = RoundTimeMinute(DateMeasure);

			TimeSpan timeDiff = DateReference.Subtract(DateMeasure);

			if (timeDiff.Days < 1)
			{
				return $"{timeDiff.Hours} u {timeDiff.Minutes} m";
			}

			if (timeDiff.Days < 7)
			{
        DateTime dateDiff = new DateTime(1, 1, 1);
        dateDiff = dateDiff.Add(timeDiff);
        dateDiff = RoundTimeHour(dateDiff);
				return $"{timeDiff.Days} d {dateDiff.Hour} h";
			}

			(int Week, int Day) weeks = CalcWeeks(timeDiff);

			if (weeks.Week < 14)
			{
				return $"{weeks.Week} w {weeks.Day} d";
			}

			int days = Math.Abs(DateReference.Day - DateMeasure.Day);
			int months = (DateReference.Month - DateMeasure.Month);
			if (DateReference.Day < DateMeasure.Day)
			{
				months--;

				DateTime dateReference = new DateTime(DateReference.Year, DateReference.Month - 1, DateMeasure.Day);
				days = (DateReference - dateReference).Days;
			}

			int years = DateReference.Year - DateMeasure.Year;
			if (DateReference.DayOfYear < DateMeasure.DayOfYear)
			{
				years--;
				months += 12;
			}

			int count = 0;
			if (years > 0)
			{
				result = $"{years} y";
				count++;
			}

			if (months > 0)
			{
				if (count == 1 && days > 15)
				{
					months++;
				}
				result = $"{result} {months} m".Trim();
				count++;
			}

			if (count < 2 && days > 0)
			{
				result = $"{result} {days} d".Trim();
			}

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
