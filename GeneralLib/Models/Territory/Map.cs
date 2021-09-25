using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLib.Models
{
    /// <summary> Общая карта маршрутов по городу </summary>
    public class Map
    {
        /// <summary> Все остановки </summary>
        public List<StopOver> StopOvers { get; set; }
        /// <summary> Все ветки </summary>
        public List<Branch> Branches { get; set; }

        public Map(List<StopOver> stopOvers, List<Branch> branches)
        {
            StopOvers = stopOvers;
            Branches = branches;
        }
    }
}
