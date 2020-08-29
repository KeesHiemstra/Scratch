using CHi.Extensions;
using CHi.Log;

using JoostReports.Models;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JoostReports.ViewModels
{
	public class MainViewModel : INotifyPropertyChanged
	{

		#region [ Fields ]

		private MainWindow View;
		private readonly string DbConnection = @"Database=Joost;Data Source=(Local);Trusted_Connection=True;MultipleActiveResultSets=true";

		#endregion

		#region [ Properties ]

		public ObservableCollection<Journal> Journals { get; set; } = new ObservableCollection<Journal>();

		public int TotalCount { get => Journals.Count; }

		#endregion

		#region [ Construction ]

		public MainViewModel(MainWindow mainWindow)
		{
			View = mainWindow;
			ReadData();
		}

		#endregion

		#region [ Public methods ]

		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged(string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public void RestoreDatabase()
		{
			string backupFile = @"%onedrive%\Environment\SQL Backup\Joost.bak".TranslatePath();
			FileInfo info = new FileInfo(backupFile);

			try
			{
				File.Copy(backupFile,
					@"C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\Backup\Joost.bak",
					true);
				Log.Write("Backup file is copied");
			}
			catch (Exception ex)
			{
				Log.Write($"Error copying backup: '{ex.Message}'");
				MessageBox.Show(ex.Message,
					"Copying backup file",
					MessageBoxButton.OK,
					MessageBoxImage.Exclamation);
				return;
			}
			backupFile = @"C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\Backup\Joost.bak";

			string sql = $"USE [master]\n" +
				$"ALTER DATABASE [Joost] SET SINGLE_USER WITH ROLLBACK IMMEDIATE\n" +
				$"RESTORE DATABASE [Joost] FROM DISK = N'{backupFile}' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 5\n" +
				$"ALTER DATABASE [Joost] SET MULTI_USER";
			try
			{
				using JournalDbContext db = new JournalDbContext(DbConnection);
				db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, sql);

				Log.Write($"Database is restored from {info.LastWriteTime:yyyy:MM:dd HH:mm}");
				MessageBox.Show($"Restore from {info.LastWriteTime:yyyy:MM:dd HH:mm} completed",
					"Restoring database",
					MessageBoxButton.OK,
					MessageBoxImage.Information);
			}
			catch (Exception ex)
			{
				Log.Write($"Error restoring: '{ex.Message}'");
				MessageBox.Show(ex.Message,
					"Error restoring database",
					MessageBoxButton.OK,
					MessageBoxImage.Exclamation);
				return;
			}

			ReadData();
		}

		#endregion

		private async Task ListArticles() 
		{
		}

		private async void ReadData()
		{
			await ReadJournalsAsync();
			NotifyPropertyChanged("");
		}

		private async Task ReadJournalsAsync()
		{
			using JournalDbContext db = new JournalDbContext(DbConnection);
			var journals = await (from a in db.Journals
														orderby a.DTStart descending
														where a.LogID >= 22400
														select a).ToListAsync();
			Journals = new ObservableCollection<Journal>(journals);
			Log.Write($"{Journals.Count} records");
		}

	}
}
