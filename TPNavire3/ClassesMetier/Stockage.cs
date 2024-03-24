// <copyright file="Stockage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TPNavire3.ClassesMetier
{
    /// <summary>
    /// Classe Stockage de l'espace de nom TPNavire3.ClassesMetier.
    /// </summary>
    internal class Stockage
    {
        private readonly int numero;
        private int capaciteDispo;
        private int capaciteMaxi;

        /// <summary>
        /// Initializes a new instance of the <see cref="Stockage"/> class.
        /// </summary>
        /// <param name="numero">paramètre numéro de type entier.</param>
        /// <param name="capaciteMaxi">paramètre capaciteMaxi de type entier.</param>
        public Stockage(int numero, int capaciteMaxi)
        {
            this.numero = numero;
            this.capaciteMaxi = capaciteMaxi;
        }

        /// <summary>
        /// Gets attribut numero.
        /// </summary>
        public int Numero { get => this.numero; }

        /// <summary>
        /// Gets or Sets attribut CapaciteDispo.
        /// </summary>
        public int CapaciteDispo { get => this.capaciteDispo; set => this.capaciteDispo = value; }

        /// <summary>
        /// Gets or Sets attribut CapaciteMaxi.
        /// </summary>
        public int CapaciteMaxi { get => this.capaciteMaxi; set => this.capaciteMaxi = value; }
    }
}
