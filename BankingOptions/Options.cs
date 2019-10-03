using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingOptions
{
  public class Options : INotifyPropertyChanged
  {
    private string backupPath = @"C:\";

    public string BackupPath
    {
      get => backupPath;
      set
      {
        if (value != backupPath)
        {
          backupPath = value;
          NotifyPropertyChanged();
        }
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(string propertyName = "")
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }

  }
}
