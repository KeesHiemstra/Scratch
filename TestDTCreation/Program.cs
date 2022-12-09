using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDTCreation
{
	class Program
	{
		private static readonly string ContactsPath = "\\\\Rommeldijk\\Data\\Contacts.json";
		public static ObservableCollection<Journal> Contacts { get; set; } =
			new ObservableCollection<Journal>();

		static void Main(string[] args)
		{
			LoadContacts();

			Console.WriteLine("Database");
			Console.WriteLine("2021-05-23 08:15:27.500");
			Console.WriteLine("2021-05-23 08:16:01.053");
			Console.WriteLine("--- Json ---");

			foreach (Journal item in Contacts)
			{
				DateTime test = new DateTime(2021,5,23,08,16,01,053);
				Console.WriteLine($"{((DateTime)item.DTCreation).TimeOfDay}");
				if (item.DTCreation >= test.AddMilliseconds(-2) && 
					item.DTCreation <= test.AddMilliseconds(2) )
				{
					Console.WriteLine("Millisecond difference if enough");
				}
			}

			Console.Write("\nPress any key...");
			Console.ReadKey();
		}

		private static void LoadContacts()
		{
			if (!File.Exists(ContactsPath)) return;

			using (StreamReader stream = File.OpenText(ContactsPath))
			{
				string json = stream.ReadToEnd();
				Contacts = JsonConvert.DeserializeObject<ObservableCollection<Journal>>(json);
			}
		}
	}
}
