using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF11207_TP1
{
    internal interface IDistance
    {
       double Calcul_distance(Grain_ble train,Grain_ble test);
    }
}
