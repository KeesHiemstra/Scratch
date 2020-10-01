using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
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

namespace UnderstandDataGrid1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private int LinesCount;
		public ObservableCollection<Record> Records { get; set; } = new ObservableCollection<Record>();

		public MainWindow()
		{
			InitializeComponent();

			AddComboBox.ItemsSource = new List<int>() { 0, 1, 2, 3, 4, 5, 10, 15, 20, 25, 50 };
			UnderstandDataGrid.ItemsSource = Records;
		}


		private void AddButton_Click(object sender, RoutedEventArgs e)
		{
			for (int i = 0; i < (int)AddComboBox.SelectedValue; i++)
			{
				Record record = new Record
				{
					Id = LinesCount,
					Column1 = "".PadLeft(1 + LinesCount, 'i'),
					Column2 = "".PadLeft(1 + LinesCount, 'w'),
				};

				Records.Add(record);
				LinesCount++;
			}
		}

		private void WatchButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void GotoButton_Click(object sender, RoutedEventArgs e)
		{
			UnderstandDataGrid.ScrollIntoView(UnderstandDataGrid.Items[10], UnderstandDataGrid.Columns[0]);
			UnderstandDataGrid.SelectedItem = UnderstandDataGrid.Items[10];
		}
	}
}
