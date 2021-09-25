using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Models
{
    /// <summary> Дорога от одной остановки к другой </summary>
    public class Road
    {
        /// <summary> Ведёт к остановке </summary>
        public BusStation LeadsIn { get; internal set; }
        /// <summary> Ведёт от остановки </summary>
        public BusStation LeadsOut { get; internal set; }

        public int Distance { get; }

        public Road(int distance, BusStation leadsInStation, BusStation leadsOutStation)
        {
            Distance = distance;
            LeadsIn = leadsInStation;
            LeadsOut = leadsOutStation;
            leadsInStation.Roads.Add(this);
        }
    }
}
