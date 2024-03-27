using Station.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.ClassesMetier
{
    internal class Tanker: Navire, INavCommercable
    {
        private string typeFluide;

        public Tanker(string imo, string nom, string latitude, string longitude, int tonnageGT, int tonnageDWT, int tonnageActuel, string typeFluide)
            : base(imo, nom, latitude, longitude, tonnageGT, tonnageDWT, tonnageActuel)
        {
            this.typeFluide = typeFluide;
        }

        public string TypeFluide { get => this.typeFluide; }

        public override string ToString()
        {
            return base.ToString() + " : Tanker";
        }
        public void Charger(int qte)
        {
            this.TonnageActuel += qte;
        }
        public void Decharger(int qte)
        {
            this.TonnageActuel -= qte;
        }
    }
}
