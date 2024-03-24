using NavireHeritage.ClassesMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Interfaces
{
    internal interface IStationnable
    {
        void EnregistrerArriveePrevue(Object unNavire);
        void EnregistrerArrivee(string unImo);
        void EnregistrerDepart(string unImo);
        bool EstAttendus(string unImo);
        bool EstParti(string unImo);
        bool EstPresent(string unImo);
        Navire GetUnAttendu(string unImo);
        Navire GetUnArrive(string unImo);
        Navire GetUnParti(string unImo);

    }
}
