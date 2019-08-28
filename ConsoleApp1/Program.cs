using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
			public static List<DateTime> TestDT = new List<DateTime>();
			public static DateTime ReferenceDT = new DateTime(2019, 8, 28, 7, 50, 31);

			static void Main(string[] args)
			{
					InitializeTestDT();

				foreach(DateTime dt in TestDT)
				{
					Console.WriteLine(dt.DateDiff(ReferenceDT));
				}
			}

			private static void InitializeTestDT()
			{
				TestDT.Add(new DateTime(2019, 8, 28, 7, 50, 30));
				//TestDT.Add(new DateTime(2019, 8, 28, 6, 30, 0));
				//TestDT.Add(new DateTime(2019, 8, 27, 18, 21, 12));
				//TestDT.Add(new DateTime(2019, 8, 24, 0, 0, 0));
				//TestDT.Add(new DateTime(2019, 4, 11, 6, 12, 53));
				//TestDT.Add(new DateTime(2018, 9, 30, 0, 0, 0));
				//TestDT.Add(new DateTime(2018, 8, 24, 0, 0, 0));
				//TestDT.Add(new DateTime(2018, 8, 23, 0, 0, 0));
			}

    }
}
