﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Models
{
    /// <summary> Остановка </summary>
    public class BusStation
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Road> Roads { get; }

        public BusStation(string name, int id, List<Road> roads)
        {
            Name = name;
            Id = id;
            Roads = roads;
        }
    }
}
