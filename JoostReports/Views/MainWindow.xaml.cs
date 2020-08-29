using JoostReports.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JoostReports
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainViewModel VM { get; set; }
		public MainWindow()
		{
			InitializeComponent();

			VM = new MainViewModel(this);
			DataContext = VM;
		}

		private void RestoreDatabase_Click(object sender, RoutedEventArgs e)
		{
			VM.RestoreDatabase();
		}

		private void MainWarpPanel_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
		{

		}
	}
}
