using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingOptions
{
  class Program
  {
    static void Main(string[] args)
    {
      Options options = new Options();
      options.BackupPath = "%OneDrive%\\Documents\\Huishouden\\2019";

      var files = Directory.EnumerateFiles(options.BackupPath.TranslatedPath(), "*.*");

      foreach (string item in files)
      {
        Console.WriteLine(item);
      }

      Console.Write("\nPress any key...");
      Console.ReadKey();
    }
  }
}
