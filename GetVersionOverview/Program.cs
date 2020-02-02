using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace GetVersionOverview
{
  class Program
  {
    static void Main(string[] args)
    {
      /*
      Console.WriteLine("OSVersion: {0}", Environment.OSVersion);
      string releaseId = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ReleaseId", "").ToString();
      Console.WriteLine(releaseId);

      string Version = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion", "ProductName", null);
      Console.WriteLine(Version);
      */

      Console.WriteLine(GetOsVer());

      Console.Write("\nPress any key...");
      Console.ReadKey();
    }

    private static ManagementObject GetMngObj(string className)
    {
      var wmi = new ManagementClass(className);

      foreach (var o in wmi.GetInstances())
      {
        var mo = (ManagementObject)o;
        if (mo != null) return mo;
      }

      return null;
    }

    public static string GetOsVer()
    {
      try
      {
        ManagementObject managementObject = GetMngObj("Win32_OperatingSystem");

        if (null == managementObject)
          return string.Empty;

        Console.WriteLine(managementObject["InstallDate"] as string);
        Console.WriteLine(managementObject["QuantumLength"] as string);
        string Build = managementObject["BuildNumber"] as string;

        return $"{Build}";
      }
      catch (Exception e)
      {
        return string.Empty;
      }
    }
  }
}
