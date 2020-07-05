using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Syntra.Data.Models
{
    public class BudgetPost:Post
    {
        public Maand Mnd { get; set; }
        public BudgetPost() { }


        public BudgetPost( Maand maand, HoofdCategorie hoofdcat, SubCategorie subcat, double debet, double credit)
        {

       
            Mnd =maand;
            HoofdCat = hoofdcat;
            SubCat = subcat;
            Debet = debet;
            Credit = credit;
        }
        public BudgetPost dupliceerBGPost(Maand maand)
        {
           return new BudgetPost(maand, HoofdCat, SubCat, Debet, Credit);
        }
    }
}
