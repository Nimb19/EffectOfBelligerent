using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportEmulator.Models
{
    /// <summary> Дорога от одной остановки к другой </summary>
    public class Road
    {
        /// <summary> Ведёт к остановке </summary>
        public StopOver LeadsIn { get; set; }
        /// <summary> Ведёт от остановки </summary>
        public StopOver LeadsOut { get; set; }

        public int Distance { get; }

        public Road(int distance, StopOver leadsIn, StopOver leadsOut)
        {
            Distance = distance;
            LeadsIn = leadsIn;
            LeadsOut = leadsOut;
        }
    }
}
