using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.ClassesMetier
{
    internal class Croisiere: Navire
    {
        private char typeNavireCroisiere;
        private int nbPassagersMaxi;

        public Croisiere(string imo, string nom, string latitude, string longitude, int tonnageGT, int tonnageDWT, int tonnageActuel, char typeNavireCroisiere, int nbPassagersMaxi)
            : base(imo, nom, latitude, longitude, tonnageGT, tonnageDWT, tonnageActuel)
        {
            this.typeNavireCroisiere = typeNavireCroisiere;
            this.nbPassagersMaxi = nbPassagersMaxi;
        }
        public override string ToString()
        {
            return base.ToString() + " : Croisière";
        }
    }
}
