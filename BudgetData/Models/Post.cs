using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Syntra.Data.Models
{
   public class Post
    {
   


        //public int ID { get; set; }

        public HoofdCategorie HoofdCat { get; set; }
        public SubCategorie SubCat { get; set; }

        public double Debet { get; set; }

        public double Credit { get; set; }




        public Post() { }


        public Post(HoofdCategorie hoofdcat, SubCategorie subcat, double debet, double credit)
        {

        
            HoofdCat = hoofdcat;
            SubCat = subcat;
            Debet = debet;
            Credit = credit;

        }

    }
}
