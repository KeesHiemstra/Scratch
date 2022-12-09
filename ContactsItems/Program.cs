using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsItems
{
	class Program
	{
		static void Main(string[] args)
		{
			List<string> Items = new List<string>()
			{
				"Contact",
				"Ontmoeting"
			};

			string json = JsonConvert.SerializeObject(Items, Formatting.Indented);
			using (StreamWriter stream = new StreamWriter("\\\\Rommeldijk\\Data\\JoostEvents.json"))
			{
				stream.Write(json);
			}


			Console.Write("\nPress any key...");
			Console.ReadKey();
		}
	}
}
