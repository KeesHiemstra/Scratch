using CHi.Extensions;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Timer2;

namespace WeatherMonitor.Models
{
	public class DayWeathers
	{

		#region [ Fields ]
		private MainWindow View;

		private readonly string DayWeatherJsonPath = "%OneDrive%\\Data\\DailyWeather".TranslatePath();
		private string JsonFile;
		private AutoResetEvent AutoEvent;
		private Timer AutoLoad;

		#endregion

		#region [ Properties ]

		public List<DayWeather> Weathers { get; set; } = new List<DayWeather>();
		public DateTime Date { get; set; }
		public DateTime TimeLastWrite { get; set; }
		public DateTime TimeMin { get; set; }
		public DateTime TimeMax { get; set; }
		public decimal TemperatureMin { get; set; }
		public decimal TemperatureMax { get; set; }

		#endregion

		#region [ Construction ]

		public DayWeathers(MainWindow mainView)
		{
			View = mainView;
			Date = DateTime.Now.Date;
			JsonFile = $"{DayWeatherJsonPath}\\DayWeather.json";
			LoadDayWeather(JsonFile);
			//Start only the timer with current weather
			StartTimer();
		}

		public DayWeathers(DateTime date)
		{
			Date = date.Date;
			LoadDayWeather($"{DayWeatherJsonPath}\\DayWeather_{date:yyyy-MM-dd}.json");
		}

		#endregion

		#region [ Public methods ]


		#endregion

		private void LoadDayWeather(string jsonFile)
		{
			if (File.Exists(jsonFile))
			{
				FileInfo info = new FileInfo(jsonFile);

				using (StreamReader stream = File.OpenText(jsonFile))
				{
					string json = stream.ReadToEnd();
					Weathers = JsonConvert.DeserializeObject<List<DayWeather>>(json)
						.Where(x => x.Time >= Date)
						.ToList();
				}

				TimeLastWrite = info.LastWriteTimeUtc;
			}

			TimeMin = Weathers.Min(x => x.Time);
			TimeMax = Weathers.Max(x => x.Time);
			TemperatureMin = Weathers.Min(x => x.Temperature);
			TemperatureMax = Weathers.Max(x => x.Temperature);
		}

		private void StartTimer()
		{
			TimeSpan start = DateTime.Now.ToUniversalTime() - TimeLastWrite;
			TimeSpan time = new TimeSpan(0, 0, 1);

			AutoEvent = new AutoResetEvent(false);
			AutoLoad = new Timer(CheckFile, AutoEvent, start, time);

			StackPanel stackPanel = new StackPanel()
			{
				Orientation = Orientation.Horizontal,
			};
			string text = $"{DateTime.Now:HH:mm:ss} {start} {time} ";
			TextBlock block = new TextBlock()
			{
				Text = text,
			};
			stackPanel.Children.Add(block);
			View.LogStackPanel.Children.Add(stackPanel);
		}

		private void CheckFile(Object stateInfo)
		{
			FileInfo info = new FileInfo(JsonFile);

			StackPanel stackPanel = new StackPanel()
			{
				Orientation = Orientation.Horizontal,
			};
			string text = $"{DateTime.Now:HH:mm:ss} {info.LastWriteTimeUtc:HH:mm:ss} ";
			TextBlock block = new TextBlock()
			{
				Text = text,
			};
			stackPanel.Children.Add(block);
			View.LogStackPanel.Children.Add(stackPanel);
		}
	}


}
