// <copyright file="Port.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Station.Interfaces;

namespace NavireHeritage.ClassesMetier
{
    /// <summary>
    /// Classe Port de l'espace de nom TPNavire3.ClassesMetier.
    /// </summary>
    public class Port : IStationnable
    {
        private readonly string nom;
        private readonly string latitude;
        private readonly string longitude;
        private readonly Dictionary<string, Navire> navireAttendus = new Dictionary<string, Navire>();
        private readonly Dictionary<string, Navire> navireArrives = new Dictionary<string, Navire>();
        private readonly Dictionary<string, Navire> navirePartis = new Dictionary<string, Navire>();
        private readonly Dictionary<string, Navire> navireEnAttente = new Dictionary<string, Navire>();
        private int nbPortique;
        private int nbQuaisTanker;
        private int nbQuaisSuperTanker;
        private int nbQuaisPassager;

        /// <summary>
        /// Initializes a new instance of the <see cref="Port"/> class.
        /// </summary>
        /// <param name="nom">paramètre nom de type string.</param>
        /// <param name="latitude">paramètre latitude de type string.</param>
        /// <param name="longitude">paramètre longitude de type string.</param>
        /// <param name="nbPortique">paramètre nbPortique de type int.</param>
        /// <param name="nbQuaisTanker">paramètre nbQuaisTanker de type int.</param>
        /// <param name="nbQuaisSuperTanker">paramètre nbQuaisSuperTanker de type int.</param>
        /// <param name="nbQuaisPassager">paramètre nbQuaisPassager de type int.</param>
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

        /// <summary>
        /// Gets attribut nom.
        /// </summary>
        public string Nom { get => this.nom; }

        /// <summary>
        /// Gets attribut latitude.
        /// </summary>
        public string Latitude { get => this.latitude; }

        /// <summary>
        /// Gets attribut longitude.
        /// </summary>
        public string Longitude { get => this.longitude; }

        /// <summary>
        /// Gets or Sets attribut nbPortique.
        /// </summary>
        public int NbPortique { get => this.nbPortique; set => this.nbPortique = value; }

        /// <summary>
        /// Gets or Sets attribut nbQuaisTanker.
        /// </summary>
        public int NbQuaisTanker { get => this.nbQuaisTanker; set => this.nbQuaisTanker = value; }

        /// <summary>
        /// Gets or Sets attribut nbQuaisSuperTanker.
        /// </summary>
        public int NbQuaisSuperTanker { get => this.nbQuaisSuperTanker; set => this.nbQuaisSuperTanker = value; }

        /// <summary>
        /// Gets or Sets attribut nbQuaisPassager.
        /// </summary>
        public int NbQuaisPassager { get => this.nbQuaisPassager; set => this.nbQuaisPassager = value; }

        /// <summary>
        /// Gets attribut navireAttendus.
        /// </summary>
        internal Dictionary<string, Navire> NavireAttendus { get => this.navireAttendus; }

        /// <summary>
        /// Gets attribut navireArrives.
        /// </summary>
        internal Dictionary<string, Navire> NavireArrives { get => this.navireArrives; }

        /// <summary>
        /// Gets attribut navirePartis.
        /// </summary>
        internal Dictionary<string, Navire> NavirePartis { get => this.navirePartis; }

        /// <summary>
        /// Gets attribut navireEnAttente.
        /// </summary>
        internal Dictionary<string, Navire> NavireEnAttente { get => this.navireEnAttente; }

        /// <summary>
        /// Méthode polymorphe publique ToString qui doit retourner un string.
        /// </summary>
        /// <returns>retourne le descriptif de la classe en type string.</returns>
        public override string ToString()
        {
            return $"Port de {this.Nom}" +
                $"\n\tCoordonnées GPS : {this.latitude}/{this.longitude}" +
                $"\n\tNb portiques : {this.NbPortique}" +
                $"\n\tNb quais croisière : {this.nbQuaisPassager}" +
                $"\n\tNb quais tankers : {this.nbQuaisTanker}" +
                $"\n\tNb quais super tankers : {this.nbQuaisSuperTanker}" +
                $"\n\tNb Navires à quai : {this.NavireArrives.Count}" +
                $"\n\tNb Navires attendus : {this.NavireAttendus.Count}" +
                $"\n\tNb Navires partis : {this.NavirePartis.Count}" +
                $"\n\tNb Navires en attente : {this.NavireEnAttente.Count}" +
                $"\n\nNombre de cargos dans le port : {this.GetNbCargoArrives()}" +
                $"\nNombre de tankers dans le port : {this.GetNbTankerArrives()}" +
                $"\nNombre de super tankers dans le port : {this.GetNbSuperTankerArrives()}";
        }

        /// <summary>
        /// Méthode public EnregistrerArriveePrevue.
        /// </summary>
        /// <param name="unNavire">paramètre unNavire de type Navire.</param>
        /// <exception cref="Exception">Exception Le navire est déjà enregistré dans les navires attendus.</exception>
        public void EnregistrerArriveePrevue(object unNavire)
        {
            foreach (Navire navire in this.NavireAttendus.Values)
            {
                if (this.NavireAttendus.ContainsKey(((Navire)unNavire).Imo))
                {
                    throw new Exception("Le navire " + ((Navire)navire).Imo + " est déjà enregistré dans les navires attendus");
                }
            }

            this.navireAttendus.Add(((Navire)unNavire).Imo, (Navire)unNavire);
        }

        /// <summary>
        /// Méthode public EnregistrerArrivee.
        /// </summary>
        /// <param name="unImo">paramètre unImo de type string.</param>
        /// <exception cref="Exception">Esception Le navire n'est pas attendu ou est déja arrivée dans le port.</exception>
        public void EnregistrerArrivee(string unImo)
        {
            if (this.EstAttendus(unImo))
            {
                if (this.GetUnAttendu(unImo) is Croisiere)
                {
                    this.AjoutNavireArrivee(this.GetUnAttendu(unImo));
                }
                else if (this.GetUnAttendu(unImo) is Tanker)
                {
                    this.TypeTanker(this.GetUnAttendu(unImo));
                }
                else if (this.GetUnAttendu(unImo) is Cargo)
                {
                    this.EnregistrerArriveeCargo(this.GetUnAttendu(unImo));
                }
            }
            else if (!this.EstAttendus(unImo))
            {
                this.NavireAttendus.Add(unImo, this.GetUnEnAttente(unImo));
                this.EnregistrerArrivee(unImo);
            }
            else
            {
                throw new Exception($"Le navire {unImo} n'est pas attendu ou est déja arrivée dans le port");
            }
        }

        /// <summary>
        /// Méthode publique EnregistrerDepart.
        /// </summary>
        /// <param name="unImo">paramètre unImo de type string.</param>
        /// <exception cref="Exception">Exception Impossible d'enregistrer le départ du navire, il n'est pas dans le port .</exception>
        public void EnregistrerDepart(string unImo)
        {
            if (this.EstPresent(unImo))
            {
                // le navire est présent dans le port
                this.navirePartis.Add(unImo, this.GetUnArrive(unImo));
                this.navireArrives.Remove(unImo);
                bool placePrise = false;
                int i = 0;
                while (!placePrise && i < this.NavireEnAttente.Count)
                {
                    KeyValuePair<string, Navire> unNavireEnAttente = this.navireEnAttente.ElementAt(i);
                    if (unNavireEnAttente.Value.GetType() == this.GetUnParti(unImo).GetType())
                    {
                        placePrise = true;
                        this.navireArrives.Add(unNavireEnAttente.Key, unNavireEnAttente.Value);
                        this.NavireEnAttente.Remove(unNavireEnAttente.Key);
                    }

                    i++;
                }
            }
            else
            {
                // le navire n'est pas dans le port
                throw new Exception("Impossible d'enregistrer le départ du navire " + unImo + ", il n'est pas dans le port ");
            }
        }

        /// <summary>
        /// Méthode publique Dechargement.
        /// </summary>
        /// <param name="unImo">paramètre unImo de type string.</param>
        /// <param name="qte">paramètre qte de type int.</param>
        public void Dechargement(string unImo, int qte)
        {
            foreach (Navire unNavire in this.navireArrives.Values)
            {
                if (unNavire.Imo == unImo)
                {
                    this.navireArrives[unImo].TonnageActuel -= qte;
                }
            }
        }

        /// <summary>
        /// Méthode publique Chargement.
        /// </summary>
        /// <param name="unImo">paramètre unImo de type string.</param>
        /// <param name="qte">paramètre qte de type int.</param>
        public void Chargement(string unImo, int qte)
        {
            foreach (Navire unNavire in this.navireArrives.Values)
            {
                if (unNavire.Imo == unImo)
                {
                    this.navireArrives[unImo].TonnageActuel += qte;
                }
            }
        }

        /// <summary>
        /// Méthode publique EstEnAttente qui renvoie un bool.
        /// </summary>
        /// <param name="unImo">paramètre unImo de type string.</param>
        /// <returns> retourne un booléan.</returns>
        public bool EstEnAttente(string unImo)
        {
            return this.navireEnAttente.ContainsKey(unImo);
        }

        /// <summary>
        /// Méthode publique EstAttendus qui renvoie un bool.
        /// </summary>
        /// <param name="unImo">paramètre unImo de type string.</param>
        /// <returns> retourne un booléan.</returns>
        public bool EstAttendus(string unImo)
        {
            return this.navireAttendus.ContainsKey(unImo);
        }

        /// <summary>
        /// Méthode publique EstParti qui renvoie un bool.
        /// </summary>
        /// <param name="unImo">paramètre unImo de type string.</param>
        /// <returns>retourne un booléan.</returns>
        public bool EstParti(string unImo)
        {
            return this.navirePartis.ContainsKey(unImo);
        }

        /// <summary>
        /// Méthode publique EstPresent qui renvoie un bool.
        /// </summary>
        /// <param name="unImo">paramètre unImo de type string.</param>
        /// <returns>retourne un booléan.</returns>
        public bool EstPresent(string unImo)
        {
            return this.NavireArrives.ContainsKey(unImo);
        }

        /// <summary>
        /// Méthode public GetUnAttendu.
        /// </summary>
        /// <param name="unImo">paramètre unImo de type string.</param>
        /// <returns>retourne un objet de la classe navire.</returns>
        /// <exception cref="Exception">Exception Le navire n'est pas attendu.</exception>
        public Navire GetUnAttendu(string unImo)
        {
            if (!this.EstAttendus(unImo))
            {
                throw new Exception($"Le navire {unImo} n'est pas attendu");
            }
            else
            {
                return this.navireAttendus[unImo];
            }
        }

        /// <summary>
        /// Méthode public GetUnArrive.
        /// </summary>
        /// <param name="unImo">paramètre unImo de type string.</param>
        /// <returns>retourne un objet de la classe navire.</returns>
        /// <exception cref="Exception">Exception Le navire n'est pas arrivée.</exception>
        public Navire GetUnArrive(string unImo)
        {
            if (!this.EstPresent(unImo))
            {
                throw new Exception($"Le navire {unImo} n'est pas arrivé");
            }
            else
            {
                return this.navireArrives[unImo];
            }
        }

        /// <summary>
        /// Méthode public GetUnParti.
        /// </summary>
        /// <param name="unImo">paramètre unImo de type string.</param>
        /// <returns>retourne un objet de la classe navire.</returns>
        /// <exception cref="Exception">Exception Le navire n'est pas parti.</exception>
        public Navire GetUnParti(string unImo)
        {
            if (!this.EstParti(unImo))
            {
                throw new Exception($"Le navire {unImo} n'est pas parti");
            }
            else
            {
                return this.navirePartis[unImo];
            }
        }

        /// <summary>
        /// Méthode public GetUnEnAttente.
        /// </summary>
        /// <param name="unImo">paramètre unImo de type string.</param>
        /// <returns>retourne un objet de la classe navire.</returns>
        /// <exception cref="Exception">Exception Le navire n'est pas en attente.</exception>
        public Navire GetUnEnAttente(string unImo)
        {
            if (!this.EstEnAttente(unImo))
            {
                throw new Exception($"Le navire {unImo} n'est pas en attente");
            }
            else
            {
                return this.navireEnAttente[unImo];
            }
        }

        /// <summary>
        /// Méthode public GetNbTankerArrives.
        /// </summary>
        /// <returns>retourne un entier qui compte le nombre de tanker arrivée.</returns>
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

        /// <summary>
        /// Méthode public GetNbSuperTankerArrives.
        /// </summary>
        /// <returns>retourne un entier qui compte le nombre de super tanker arrivée.</returns>
        public int GetNbSuperTankerArrives()
        {
            int cpt = 0;
            foreach (Navire navire in this.NavireArrives.Values)
            {
                if (navire is Tanker && navire.TonnageGT > 130000)
                {
                    cpt++;
                }
            }

            return cpt;
        }

        /// <summary>
        /// Méthode public GetNbCargoArrives.
        /// </summary>
        /// <returns>retourne un entier qui compte le nombre de cargo arrivée.</returns>
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

        /// <summary>
        /// Méthode pivée TypeTanker.
        /// </summary>
        /// <param name="unNavire">paramètre unNavire de type Navire.</param>
        private void TypeTanker(object unNavire)
        {
            if (((Navire)unNavire).TonnageGT > 130000)
            {
                this.EnregistrerArriveeSuperTanker((Navire)unNavire);
            }
            else
            {
                this.EnregistrerArriveeTanker((Navire)unNavire);
            }
        }

        /// <summary>
        /// Méthode pivée EnregistrerArriveeTanker.
        /// </summary>
        /// <param name="unNavire">paramètre unNavire de type Navire.</param>
        private void EnregistrerArriveeTanker(object unNavire)
        {
            if (this.nbQuaisTanker > this.GetNbTankerArrives())
            {
                this.AjoutNavireArrivee(this.GetUnAttendu(((Navire)unNavire).Imo));
            }
            else
            {
                this.AjoutNavireEnAttente(this.GetUnAttendu(((Navire)unNavire).Imo));
            }
        }

        /// <summary>
        /// Méthode pivée EnregistrerArriveeSuperTanker.
        /// </summary>
        /// <param name="unNavire">paramètre unNavire de type Navire.</param>
        private void EnregistrerArriveeSuperTanker(object unNavire)
        {
            if (this.nbQuaisSuperTanker > this.GetNbSuperTankerArrives())
            {
                this.AjoutNavireArrivee(this.GetUnAttendu(((Navire)unNavire).Imo));
            }
            else
            {
                this.AjoutNavireEnAttente(this.GetUnAttendu(((Navire)unNavire).Imo));
            }
        }

        /// <summary>
        /// Méthode pivée EnregistrerArriveeCargo.
        /// </summary>
        /// <param name="unNavire">paramètre unNavire de type Navire.</param>
        private void EnregistrerArriveeCargo(object unNavire)
        {
            if (this.nbPortique > this.GetNbCargoArrives())
            {
                this.AjoutNavireArrivee(this.GetUnAttendu(((Navire)unNavire).Imo));
            }
            else
            {
                this.AjoutNavireEnAttente(this.GetUnAttendu(((Navire)unNavire).Imo));
            }
        }

        /// <summary>
        /// Méthode privée AjoutNavireEnAttente.
        /// </summary>
        /// <param name="unNavire">paramètre unNavire de type Navire.</param>
        private void AjoutNavireEnAttente(Navire unNavire)
        {
            this.navireEnAttente.Add(unNavire.Imo, unNavire);
            this.navireAttendus.Remove(unNavire.Imo);
        }

        /// <summary>
        /// Méthode privée AjoutNavireArrivee.
        /// </summary>
        /// <param name="unNavire">paramètre unNavire de type Navire.</param>
        private void AjoutNavireArrivee(Navire unNavire)
        {
            this.navireArrives.Add(unNavire.Imo, unNavire);
            this.navireAttendus.Remove(unNavire.Imo);
        }
    }
}
