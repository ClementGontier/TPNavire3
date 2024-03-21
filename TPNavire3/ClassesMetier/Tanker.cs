using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.ClassesMetier
{
    internal class Tanker: Navire
    {
        private string typeFluide;

        public Tanker(string imo, string nom, string latitude, string longitude, int tonnageGT, int tonnageDWT, int tonnageActuel, string typeFluide)
            : base(imo, nom, latitude, longitude, tonnageGT, tonnageDWT, tonnageActuel)
        {
            this.typeFluide = typeFluide;
        }
        public override string ToString()
        {
            return base.ToString() + " : Tanker";
        }
    }
}
