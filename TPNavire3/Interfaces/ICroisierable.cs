// <copyright file="ICroisierable.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace Station.Interfaces
{
    /// <summary>
    /// Interface ICroisierable de l'espace de nom Station.Interfaces.
    /// </summary>
    internal interface ICroisierable
    {
        /// <summary>
        /// Méthode public Embarquer.
        /// </summary>
        /// <param name="listpassagers">paramètre listpassagers de la classe list.</param>
        void Embarquer(List<object> listpassagers);

        /// <summary>
        /// Méthode public Debarquer qui doit retourner une liste d'objets.
        /// </summary>
        /// <param name="listpassagers">paramètre listpassagers de la classe list.</param>
        /// <returns>Retourne la liste des objets passés en paramètre et qui n'ont pas été trouvés dans la liste des objets présents dans le navire.</returns>
        List<object> Debarquer(List<object> listpassagers);
    }
}
