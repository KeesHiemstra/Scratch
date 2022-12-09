using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversions
{
	class Program
	{
		static void Main(string[] args)
		{
			WorkWithDates();
			//ConverTimeSpan();
			//CalculateMonths();

			Console.Write("\nPress any key...");
			Console.ReadKey();
		}

		static void WorkWithDates()
		{
			DateTime date = DateTime.Now;
			Console.WriteLine((int)date.DayOfWeek);

			date = date.AddDays(2);
			Console.WriteLine((int)date.DayOfWeek);
		}

		static void CalculateMonths()
		{
			DateTime Start = new DateTime(2020, 09, 14);

			TimeSpan Periode = DateTime.Now - Start;

			Console.WriteLine(Periode);
		}

		static void ConverTimeSpan()
		{
			DateTime dateTime = DateTime.Now;
			Console.WriteLine(dateTime);

			TimeSpan time = dateTime.TimeOfDay;
			Console.WriteLine(time);

			double ftime = (double)time.TotalSeconds;
			Console.WriteLine(ftime);

			TimeSpan ntime = TimeSpan.FromSeconds(ftime);
			Console.WriteLine(ntime);

			ntime = TimeSpan.FromSeconds(Math.Round(ftime));
			Console.WriteLine(ntime);
		}

	}
}
