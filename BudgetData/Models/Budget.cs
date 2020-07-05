using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Syntra.Data.Models
{
    public class Budget
    {
        public Maand StartMaand;
        public List<Maand> Maanden;

        public Budget() { }
       public bool addMaand()
        {
            Maand currMaand = getLaatsteMaand();
            int ind=currMaand.Index;
            int jaar = currMaand.Jaar;
            int id= currMaand.ID;
            if (ind == 11)//of 12=>1
            {
                ind = 0;
                jaar++;
            }
            Maand NewMaand = new Maand(id, jaar, ind, false);
            NewMaand.duplicateBGPosten(this);
            Maanden.Add(NewMaand);
           // currMaand.archiveer();
           return true;
        }

        public bool deleteMaand(Maand mnd)
        {
            //code hier
            return true;
        }



        public Maand getLaatsteMaand()
        {            
            return Maanden.Find(t=>t.ID == Maanden.Max(t => t.ID));
        }

        
    }
}
