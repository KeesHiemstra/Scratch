using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeTotalDays1
{
	class Program
	{
		static void Main(string[] args)
		{
			DateTime old = new DateTime(2020, 11, 13, 5, 52, 0);
			DateTime today = new DateTime(2020, 11, 14, 17, 52, 0);

			var days = (today.Date - old).TotalDays;
			Console.WriteLine($"{days} => {Math.Round(days, 0) + 1}");

			Console.Write("\nPress any key...");
			Console.ReadKey();
		}
	}
}
