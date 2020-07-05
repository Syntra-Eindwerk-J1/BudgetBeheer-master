using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Syntra.Data.Models
{
   public class Maand
    {
        BudgetPosten _maandBGPosten ;
        TransactiePosten _maandTRPosten ;
        public int ID;
        public int Index;
        public int Jaar;
        public bool Archief;
       // public BudgetPosten _bgPosten;

    public Maand() { }
    public Maand(int id, int index, int jaar, bool archief)
    {
        ID = id;
        Index = index;
        Jaar = jaar;
        Archief = archief;

    }
    public BudgetPosten MaandBGPosten
        {
            get
            {
                _maandBGPosten ??= new BudgetPosten();
                return _maandBGPosten;
            }
            set 
            {
                _maandBGPosten =value;
            }
        }
        public TransactiePosten MaandTRPosten
        {
            get
            {
                _maandTRPosten ??= new TransactiePosten();
                return _maandTRPosten;
            }
            set
            {
                _maandTRPosten = value;
            }
        }
        
        public string getNaam()
        {

            string naam = "";
            // code hier
            return naam;
        }

        public void duplicateBGPosten(Budget bg)
        {
            Maand vorigeMaand = bg.getLaatsteMaand();
            foreach( BudgetPost bgp in MaandBGPosten.Members)
            {
                
                MaandBGPosten.Members.Add(bgp.dupliceerBGPost(this));
            }

        }
        public void archiveer()
        {
            Archief = true;
        }



   }
 }