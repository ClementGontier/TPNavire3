using GestionNavire.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NavireHeritage.ClassesMetier
{
    public class Port
    {
        private string nom;
        private string latitude;
        private string longitude;
        private int nbPortique;
        private int nbQuaisTanker;
        private int nbQuaisSuperTanker;
        private int nbQuaisPassager;
        private Dictionary<string, Navire> navireAttendus = new Dictionary<string, Navire>();
        private Dictionary<string, Navire> navireArrives = new Dictionary<string, Navire>();
        private Dictionary<string, Navire> navirePartis = new Dictionary<string, Navire>();
        private Dictionary<string, Navire> navireEnAttente = new Dictionary<string, Navire>();
        public string Nom { get => nom;  }
        public string Latitude { get => latitude;  }
        public string Longitude { get => longitude;  }
        public int NbPortique { get => nbPortique; set => nbPortique = value; }
        public int NbQuaisTanker { get => nbQuaisTanker; set => nbQuaisTanker = value; }
        public int NbQuaisSuperTanker { get => nbQuaisSuperTanker; set => nbQuaisSuperTanker = value; }
        public int NbQuaisPassager { get => nbQuaisPassager; set => nbQuaisPassager = value; }
        internal Dictionary<string, Navire> NavireAttendus { get => navireAttendus;  }
        internal Dictionary<string, Navire> NavireArrives { get => navireArrives; }
        internal Dictionary<string, Navire> NavirePartis { get => navirePartis; }
        internal Dictionary<string, Navire> NavireEnAttente { get => navireEnAttente;  }

        public Port(string nom, string latitude, string longitude, int nbPortique, int nbQuaisTanker, int nbQuaisSuperTanker, int nbQuaisPassager) 
        {
            this.nom = nom;
            this.latitude = latitude;
            this.longitude = longitude;
            this.nbPortique = nbPortique;
            this.nbQuaisTanker = nbQuaisTanker;
            this.nbQuaisSuperTanker = nbQuaisSuperTanker;
            this.nbQuaisPassager = nbQuaisPassager;
            this.navireAttendus = new Dictionary<string, Navire>();
            this.navireArrives = new Dictionary<string, Navire>();
            this.navirePartis = new Dictionary<string, Navire>();
            this.navireEnAttente = new Dictionary<string, Navire>();

        }
        public override string ToString()
        {
            return $"Port de {this.Nom}" +
                $"\n\tCoordonnées GPS : {this.latitude}/{this.longitude}" +
                $"\n\tNb portiques : {this.NbPortique}" +
                $"\n\tNb quais croisière : {this.nbQuaisPassager}" +
                $"\n\tNb quais tankers : {this.nbQuaisTanker}" +
                $"\n\tNb quais super tankers : {this.nbQuaisTanker}" +
                $"\n\tNb quais super tankers : {this.nbQuaisSuperTanker}" +
                $"\n\tNb Navires à quai : {this.NavireArrives.Count}" +
                $"\n\tNb Navires attendus : {this.NavireAttendus.Count}" +
                $"\n\tNb Navires partis : {this.NavirePartis.Count}" +
                $"\n\tNb Navires en attente : {this.NavireEnAttente.Count}" +
                $"\n\nNombre de cargos dans le port : {this.GetNbCargoArrives()}" +
                $"\nNombre de tankers dans le port : {this.GetNbTankerArrives()}" +
                $"\nNombre de super tankers dans le port : {this.GetNbSuperTankerArrives()}";
        }
        public void EnregistrerArriveePrevue(Object unNavire) 
        {
            foreach (Navire navire in this.NavireAttendus.Values)
            {
                if (this.NavireAttendus.ContainsKey(((Navire)unNavire).Imo))
                {
                    throw new GestionPortException("Le navire " + ((Navire)navire).Imo + " est déjà enregistré dans les navires attendus");
                }
            }
            this.navireAttendus.Add(((Navire)unNavire).Imo, (Navire)unNavire);
        } 

        public void EnregistrerArrivee(Object unNavire) 
        {
            if (!this.NavireAttendus.ContainsKey(((Navire)unNavire).Imo))
            {
                throw new GestionPortException("On ne peut enregistrer l'arrivée d'un navire non attendu");
            }
            else if (this.NavireAttendus.ContainsKey("Croisiere")) 
            {
                this.NavireAttendus.Remove(((Navire)unNavire).Imo);
                this.navireArrives.Add(((Navire)unNavire).Imo, (Navire)unNavire);
            }
            else if ()
            {

            }
        }
        public void EnregistrerDepart(Object navire) 
        {
            if (this.EstPresent(((Navire)navire).Imo))
            {
                // le navire est présent dans le port
                this.navirePartis.Add(((Navire)navire).Imo, (Navire)navire);
                this.navireArrives.Remove(((Navire)navire).Imo);
            }
            else
            {
                // le navire n'est pas dans le port
                throw new GestionPortException("impossible d'enregistrer le départ du navire " + ((Navire)navire).Imo + ", il n'est pas dans le port ");
            }
            
        }
        //public bool EstAttendu(string navire) { }
        //public bool EstParti(string navire) { }
        public bool EstPresent(string imo) 
        {
            return this.navireArrives.ContainsKey(imo);
        }
        //public bool EstEnAttente(string navire) { }


        //public void Dechargement(string, int)
        //{

        //}
        //public void Chargement(string, int)
        //{

        //}
        //private void AjoutNavireEnAttente(Navire navire)
        //{

        //}
        //public bool EstEnAttente(string)
        //{

        //}
        //public void GetUnEnAttente(string)
        //{

        //}
        //public void GetUnArrive(string)
        //{

        //}
        //public void GetUnParti(string)
        //{

        //}
        public int GetNbTankerArrives()
        {
            int cpt = 0;
            foreach (Navire navire in this.NavireArrives.Values)
            {
                if (navire is Tanker && navire.TonnageGT <= 130000)
                {
                    cpt++;
                }
            }
            return cpt;
        }
        public int GetNbSuperTankerArrives()
        {
            int cpt = 0;
            foreach (Navire navire in this.NavireArrives.Values)
            {
                if (navire is Tanker && navire.TonnageGT>130000)
                {
                    cpt++;
                }
            }
            return cpt;
        }
        public int GetNbCargoArrives()
        {
            int cpt = 0;
            foreach (Navire navire in this.NavireArrives.Values)
            {
                if (navire is Cargo)
                {
                    cpt++;
                }
            }
            return cpt;
        }

    }
}
