using Station.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.ClassesMetier
{
    internal class Cargo: Navire, INavCommercable
    {
        private string typeFret;

        public string TypeFret { get => this.typeFret; }

        public Cargo(string imo, string nom, string latitude, string longitude, int tonnageGT, int tonnageDWT, int tonnageActuel,string typeFret)
            : base(imo, nom, latitude, longitude, tonnageGT, tonnageDWT, tonnageActuel)
        {
            this.typeFret = typeFret;
        }
        public override string ToString()
        {
            return base.ToString() + " : Cargo";
        }
        public void Charger(int qte)
        {
            this.tonnageActuel += qte;
        }
        public void Decharger(int qte)
        {
            this.tonnageActuel -= qte;
        }
    }
}
