using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Syntra.Data.Models
{
   public class TransactiePost:Post
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("tr_datum")]
        public DateTime Datum { get; set; }     
        public string Comment { get; set; }
        public string DatumString { get; set; }

        public TransactiePost() { }
        

        public TransactiePost(int id, DateTime datum, HoofdCategorie hoofdcat, SubCategorie subcat, string comment, double debet, double credit)
            {
            string ds= datum.ToShortDateString();
            
            ID = id;
            Datum = datum;
            HoofdCat = hoofdcat;
            SubCat = subcat;
            Comment = comment;
            Debet = debet;
            Credit = credit;
            DatumString = ds;
        }


    }
}
