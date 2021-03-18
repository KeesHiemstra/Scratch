using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLanguage1
{
	class Program
	{
		static void Main(string[] args)
		{
			List<string> lijstje = new();
			lijstje.Add("One");
			lijstje.Add("Two");
			lijstje.Add("Three");
			lijstje.Add("Four");
			lijstje.Add("Five");

			foreach (var item in lijstje)
			{
				Console.WriteLine(item);
			}

			Console	.Write("\nPress any key...");
			Console.ReadKey();
		}
	}
}
