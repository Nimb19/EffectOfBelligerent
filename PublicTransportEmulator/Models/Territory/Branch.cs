using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportEmulator.Models
{
    /// <summary> Ветка </summary>
    public class Branch
    {
        /// <summary> Остановки по порядку от первой и до последней </summary>
        public List<StopOver> StopOvers { get; }
        public List<Bus> Buses { get; }
    }
}
