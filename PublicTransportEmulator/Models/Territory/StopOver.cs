using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportEmulator.Models
{
    /// <summary> Остановка </summary>
    public class StopOver
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Road> Roads { get; }

        public StopOver(string name, int id, List<Road> roads)
        {
            Name = name;
            Id = id;
            Roads = roads;
        }
    }
}
