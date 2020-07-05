using System;
using System.Collections.Generic;
using System.Linq;
using SyntraAB.Tools.Extensions;
using System.IO;
using System.Text.Json;

namespace Syntra.Data.Models
{
     public class BudgetPosten
    {
		public const string DataFile = "BudgetPosten.dat";
		public string LastError { get; protected set; } = "";
		public List<BudgetPost> Members { get; set; } = new List<BudgetPost>();
		public int Count { get => Members?.Count > 0 ? Members.Count : 0; }
		

		public BudgetPosten()
		{

		}
		public bool Import()
		{

			string data = GetType().GetEmbeddedResource("BudgetPosten.dat");

			if (data.NotEmpty())
			{
				try
				{
					var jsonData = JsonSerializer.Deserialize<List<BudgetPost>>(data);
					if (jsonData != null)
					{
						if (Count > 0)
						{
							foreach (var bp in jsonData)
							{
								var item = Members.Where(t => t.SubCat == bp.SubCat).FirstOrDefault();
								if (item != null)
								{
									item.HoofdCat = bp.HoofdCat != null ? bp.HoofdCat : item.HoofdCat;
									//item.SubCat = bp.SubCat != null ? bp.SubCat : item.SubCat;
									item.Mnd=bp.Mnd != null ? bp.Mnd : item.Mnd;
									item.Debet = bp.Debet > 0 ? bp.Debet : item.Debet;
									item.Credit = bp.Credit > 0 ? bp.Credit : item.Credit;
									
								}

								else
								{
									Members.Add(bp);
								}

							}
							Members.Clear();
						}
						Members.AddRange(jsonData);

					}
					return true;
				}
				catch (Exception ex) { LastError = ex.ToString(); }
				return false;
			}
			return false;
		}

	


		public bool addBudgetPost(Maand maand, HoofdCategorie hc, SubCategorie sc, double debet, double credit)
	
		{
			
			BudgetPost bp = new BudgetPost( maand, hc, sc, debet, credit);
			Members.Add(bp);
			return true;
		}


		public bool deleteTransactiePost(BudgetPost bp)
		{

			return (Members.Remove(bp));

		}


		public string Export() => JsonSerializer.Serialize(Members, new JsonSerializerOptions() { WriteIndented = true, IgnoreNullValues = true });


	}
}
