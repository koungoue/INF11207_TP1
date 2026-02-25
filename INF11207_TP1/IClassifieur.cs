using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF11207_TP1
{
    internal interface IClassifieur
    {
        Variety Predire(Grain_ble grain);
    }
}
