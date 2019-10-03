﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankingOptions
{
  public static class PathExtensions
  {
    /// <summary>
    /// Translate the PathName %OneDrive% to the full path.
    /// %OneDrive% is a environment variable.
    /// </summary>
    /// <param name="PathName"></param>
    /// <returns></returns>
    public static string TranslatedPath(this string PathName)
    {
      string result = PathName;

      Regex regex = new Regex("%OneDrive%", RegexOptions.IgnoreCase);

      if (regex.IsMatch(result))
      {
        result = regex.Replace(result, Environment.GetEnvironmentVariable("OneDrive")); 
      }

      return result;
    }
  }
}
