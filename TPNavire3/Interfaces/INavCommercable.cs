using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Interfaces
{
    internal interface INavCommercable
    {
        void Charger(int qte);
        void Decharger(int qte);
    }
}
