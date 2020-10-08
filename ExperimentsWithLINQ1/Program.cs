using CHi.Extensions;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentsWithLINQ1
{
	class Program
	{
		public static List<Journal> Journals = new List<Journal>();

		static void Main(string[] args)
		{
			LoadJournal(@"%OneDrive%\Data\Journal.csv".TranslatePath());

			//Use only the fallen rain records
			Journals = Journals
				.Where(x => x.Event == "Regen")
				.ToList();

			//YearTotals();
			MonthTotals();

			Console.Write("\nPress any key...");
			Console.ReadKey();
		}

		private static void YearTotals()
		{
			var year = Journals
				.GroupBy(
					x => x.Time.Year,
					x => decimal.Parse(x.Message),
					(Year, rain) => new
						{
							Key = Year,
							Rain = rain.Sum(x => x)
						}
					);

			Console.WriteLine("Year\tRain");
			Console.WriteLine("----\t----");
			foreach (var item in year)
			{
				Console.WriteLine($"{item.Key}\t{item.Rain}");
			}
		}

		private static void MonthTotals()
		{
			var month = Journals
				.Where(x => x.Time >= new DateTime(2020, 01, 01))
				.GroupBy(
					x => (x.Time.Year, x.Time.Month),
					x => decimal.Parse(x.Message),
					(Date, rain) => new
					{
						Key = Date,
						YearTotals = rain.Sum(x => x),
						MonthTotals = rain.Sum(x => x)
					}
					);
		}

		#region Load the data

		private static void LoadJournal(string path)
		{
			string content;
			using (StreamReader stream = new StreamReader(path))
			{
				content = stream.ReadToEnd();
			};

			ProcessLines(content.Split(new string[] { "\"\r\n\"" },
				StringSplitOptions.RemoveEmptyEntries));
		}

		private static void ProcessLines(string[] lines)
		{
			for (int i = 1; i < lines.Length; i++)
			{
				ProcessLine(lines[i].Split(new string[] { "\";\"" }, StringSplitOptions.None));
			}
		}

		private static void ProcessLine(string[] field)
		{
			Journals.Add(new Journal()
			{
				LogID = int.Parse(field[0]),
				Time = DateTime.Parse(field[1]),
				Event = field[2],
				Message = field[3]
			});
		}

		#endregion

	}

	public class Journal
	{
		public int LogID;
		public DateTime Time;
		public string Event;
		public string Message;
	}

}
