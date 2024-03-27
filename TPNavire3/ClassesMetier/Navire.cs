using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.ClassesMetier
{
    public class Navire
    {
        protected string imo;
        protected string nom;
        protected string latitude;
        protected string longitude;
        protected int tonnageGT;
        protected int tonnageDWT;
        protected int tonnageActuel;

        public Navire(string imo, string nom, string latitude, string longitude, int tonnageGT, int tonnageDWT, int tonnageActuel)
        {
            this.imo = imo;
            this.nom = nom;
            this.latitude = latitude;
            this.longitude = longitude;
            this.tonnageGT = tonnageGT;
            this.tonnageDWT = tonnageDWT;
            this.tonnageActuel = tonnageActuel;
        }
        public override string ToString()
        {
            return $"{this.imo}" +
                $"\t{this.nom}";
        }
        public string Imo { get => this.imo; }
        public string Nom { get => this.nom;  }
        public string Latitude { get => this.latitude; set => this.latitude = value; }
        public string Longitude { get => this.longitude; set => this.longitude = value; }
        public int TonnageGT { get => this.tonnageGT; }
        public int TonnageDWT { get => this.tonnageDWT;  }
        public int TonnageActuel
        {
            get => this.tonnageActuel;
            set
            {
                if (this.tonnageActuel + value <= this.tonnageDWT && this.tonnageActuel + value >= 0)
                {
                    this.tonnageActuel += value;
                }
                else
                {
                    throw new Exception("La charge maximale est dépassé ou est négative.");
                }
            }
        }
    }
}
