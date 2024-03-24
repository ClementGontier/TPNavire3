using Station.Interfaces;
using System;
using System.Collections.Generic;

namespace NavireHeritage.ClassesMetier
{
    internal class Croisiere: Navire, ICroisierable
    {
        private char typeNavireCroisiere;
        private int nbPassagersMaxi;
        private Dictionary<string, Passager> passagers;

        public char TypeNavireCroisiere { get => this.typeNavireCroisiere; }
        public int NbPassagersMaxi { get => this.nbPassagersMaxi; }
        internal Dictionary<string, Passager> Passagers { get => this.passagers; }

        public Croisiere(string imo, string nom, string latitude, string longitude, int tonnageGT, int tonnageDWT, int tonnageActuel, char typeNavireCroisiere, int nbPassagersMaxi)
            : base(imo, nom, latitude, longitude, tonnageGT, tonnageDWT, tonnageActuel)
        {
            this.typeNavireCroisiere = typeNavireCroisiere;
            this.nbPassagersMaxi = nbPassagersMaxi;
        }
        public Croisiere(string imo, string nom, string latitude, string longitude, int tonnageGT, int tonnageDWT, int tonnageActuel, char typeNavireCroisiere, int nbPassagersMaxi, Dictionary<string, Passager> passagers)
            : this(imo, nom, latitude, longitude, tonnageGT, tonnageDWT, tonnageActuel, typeNavireCroisiere, nbPassagersMaxi)
        {
            this.passagers = passagers;
        }
        public override string ToString()
        {
            return base.ToString() + " : Croisière";
        }
        public void Embarquer(List<Object> unPassager)
        {
            foreach (Passager passager in unPassager)
            {
                if (this.passagers.Count < this.nbPassagersMaxi)
                {
                    this.passagers.Add(passager.NumPasseport, passager);
                }
                else
                {
                    throw new Exception("Il n'y a plus de places dans le navire");
                }
            }
        }
        public List<Object> Debarquer(List<Object> unPassager)
        {
            List<Object> listPassager = new List<Object>();
            foreach (Passager passager in this.passagers.Values)
            {
                if (unPassager.Contains(passager))
                {
                    this.passagers.Remove(passager.NumPasseport);
                }
                else
                {
                    listPassager.Add(passager);
                }
            }
            return listPassager;
        }
    }
}
