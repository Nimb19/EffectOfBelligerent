using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Models
{
    /// <summary> Общая карта маршрутов по городу </summary>
    public class Map
    {
        /// <summary> Все остановки </summary>
        public List<BusStation> BusStations { get; set; }
        /// <summary> Все ветки </summary>
        public List<Branch> Branches { get; set; }

        public Map(List<BusStation> busStations, List<Branch> branches)
        {
            BusStations = busStations;
            Branches = branches;
        }
    }
}
