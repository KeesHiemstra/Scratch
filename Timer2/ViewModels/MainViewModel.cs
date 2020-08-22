using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitor.Models;

namespace Timer2.ViewModels
{
	public class MainViewModel
	{
    MainWindow MainView;

    public DayWeathers CurrentWeathers { get; set; } = new DayWeathers();

    public MainViewModel(MainWindow mainView)
    {
      MainView = mainView;
    }
  }
}
