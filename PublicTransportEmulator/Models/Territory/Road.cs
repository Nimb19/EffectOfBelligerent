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
        public BusStation LeadsIn { get; set; }
        /// <summary> Ведёт от остановки </summary>
        public BusStation LeadsOut { get; set; }

        public int Distance { get; }

        public Road(int distance, BusStation leadsIn, BusStation leadsOut)
        {
            Distance = distance;
            LeadsIn = leadsIn;
            LeadsOut = leadsOut;
        }
    }
}
