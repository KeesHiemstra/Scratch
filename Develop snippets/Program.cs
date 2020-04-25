using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
      Test();

      Console.Write("\nPress any key...");
      Console.ReadKey();
    }

    private static void Test()
    {
      SystemEvents.PowerModeChanged += OnPowerChange;
    }

    private static void OnPowerChange(object sender, PowerModeChangedEventArgs e)
    {
      switch (e.Mode)
      {
        case PowerModes.Resume:
          Console.WriteLine("Resume");
          break;
        case PowerModes.StatusChange:
          Console.WriteLine("StatusChange");
          break;
        case PowerModes.Suspend:
          Console.WriteLine("Suspend");
          break;
        default:
          Console.WriteLine("Default");
          break;
      }
    }
  }
}
