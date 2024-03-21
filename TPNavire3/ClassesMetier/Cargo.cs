using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.ClassesMetier
{
    internal class Cargo: Navire
    {
        private string typeFret;

        public Cargo(string imo, string nom, string latitude, string longitude, int tonnageGT, int tonnageDWT, int tonnageActuel,string typeFret)
            : base(imo, nom, latitude, longitude, tonnageGT, tonnageDWT, tonnageActuel)
        {
            this.typeFret = typeFret;
        }
        public override string ToString()
        {
            return base.ToString() + " : Cargo";
        }
    }
}
