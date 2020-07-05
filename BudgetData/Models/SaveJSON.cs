using System;
using System.Collections.Generic;
using System.Linq;
using SyntraAB.Tools.Extensions;
using System.IO;
using System.Text.Json;
using System.Security.Cryptography;

namespace Syntra.Data.Models
{
   public class SaveJSON
    {
        public SaveJSON()
        {

        }
		public const string DataFile=null;
		public string StAppDir
		{
			get
			{
				//aangepast om te testen, het mag terug naar de oorspronkelijke
				string dir = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).TrimEnd('\\')}\Groepswerk";
				if (!Directory.Exists(dir))
				{
					Directory.CreateDirectory(dir);
				}
				string dr = "C:\\Users\\maria\\Downloads\\Documents\\syntra\\Groepswerk\\BudgetData\\Data";
				return dr;
			}
		}
		public bool SaveData(string datapath, string json)
		{
			//string json = Export();
			if (json?.Length > 0)
			{
				try
				{
					File.WriteAllText(datapath, json);
					return true;
				}
				catch { }
			}
			return false;
		}


	}
}
