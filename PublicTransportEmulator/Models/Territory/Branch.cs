using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Models
{
    /// <summary> Ветка поездок по городу </summary>
    public class Branch
    {
        /// <summary> Остановки по порядку от первой и до последней (их id) </summary>
        public List<int> BusStations { get; }
        public List<Bus> Buses { get; } = new List<Bus>();

        public int Id { get; }
        public int DefaultBusCount { get; }

        public Branch(int id, int defaultBusCount, List<int> orderedBusStations)
        {
            BusStations = orderedBusStations;
            Id = id;
            DefaultBusCount = defaultBusCount;
        }
    }
}
