// <copyright file="Passager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NavireHeritage.ClassesMetier
{
    /// <summary>
    /// Classe Passager de l'espace de nom NavireHeritage.ClassesMetier.
    /// </summary>
    internal class Passager
    {
        private readonly string numPasseport;
        private readonly string nom;
        private readonly string prenom;
        private readonly string nationalite;

        /// <summary>
        /// Initializes a new instance of the <see cref="Passager"/> class.
        /// </summary>
        /// <param name="numPasseport">paramètre numPasseport de type string.</param>
        /// <param name="nom">paramètre nom de type string.</param>
        /// <param name="prenom">paramètre prenom de type string.</param>
        /// <param name="nationalite">paramètre nationalite de type string.</param>
        public Passager(string numPasseport, string nom, string prenom, string nationalite)
        {
            this.numPasseport = numPasseport;
            this.nom = nom;
            this.prenom = prenom;
            this.nationalite = nationalite;
        }

        /// <summary>
        /// Gets attribut numPasseport.
        /// </summary>
        public string NumPasseport { get => this.numPasseport; }

        /// <summary>
        /// Gets attribut nom.
        /// </summary>
        public string Nom { get => this.nom; }

        /// <summary>
        /// Gets attribut prenom.
        /// </summary>
        public string Prenom { get => this.prenom; }

        /// <summary>
        /// Gets attribut nationalite.
        /// </summary>
        public string Nationalite { get => this.nationalite; }
    }
}
