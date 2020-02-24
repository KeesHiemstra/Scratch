using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Develop_snippets
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Use return");
      ExecuteTry(false);

      Console.WriteLine("Use exit");
      ExecuteTry(true);

      Console.Write("\nPress any key...");
      Console.ReadKey();
    }

    private static void ExecuteTry(bool UseExit)
    {
      try
      {
        int devide = 0;
        Console.WriteLine(1 / devide);
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Exception {ex.Message}");
        if (!UseExit)
        {
          return;
        }
        else
        {
          Environment.Exit(1);
        }
      }
      finally
      {
        Console.WriteLine("Finally is executed");
      }

      Console.WriteLine("Never executed");
    }
  }

}
