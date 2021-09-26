using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Models
{
    /// <summary> Остановка </summary>
    public class BusStation
    {
        public string Name { get; }
        public int Id { get; }
        public List<Road> Roads { get; } = new List<Road>();
        public List<Bus> Buses { get; set; } = new List<Bus>();

        public BusStation(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}
