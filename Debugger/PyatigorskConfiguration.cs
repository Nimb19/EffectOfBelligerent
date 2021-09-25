using CommonLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debugger
{
    public class PyatigorskConfiguration
    {
        public Map CreatePyatigorskConfiguration()
        {
            var busStations = GenerateRoadsAndBusStations();
            var busBranches = CreateBranches();
            
            return new Map(busStations, busBranches);
        }

        private static List<Branch> CreateBranches()
        {
            return new List<Branch>()
            {
                new Branch(2, 5, new List<int>() { 2, 1, 5, 6, 7, 8, 9, 12 }),
                new Branch(5, 3, new List<int>() { 2, 3, 4, 1, 5, 6, 13, 14, 15, 16 }),
                new Branch(7, 3, new List<int>() { 2, 1, 5, 6, 7, 8, 9, 10, 11 }),
                new Branch(8, 5, new List<int>() { 18, 17, 14, 13, 7, 8, 9, 10, 11 }),
            };
        }

        private List<BusStation> GenerateRoadsAndBusStations()
        {
            var busStations = new List<BusStation>()
            {
                new BusStation("ул. Тольяти №24"    , 1),
                new BusStation("ул. Шаповалова №13" , 2),
                new BusStation("ул. Скачки №16"     , 3),
                new BusStation("ул. Линеева №13"    , 4),
                new BusStation("ул. Кочубея №1"     , 5),
                new BusStation("ул. Кирова №55"     , 6),
                new BusStation("ул. 40 л. окт. №4"  , 7),
                new BusStation("ул. 40 л. окт. №32" , 8),
                new BusStation("ул. 40 л. окт. №55" , 9),
                new BusStation("ул. Первая №11"     , 10),
                new BusStation("ул. Тихова №19"     , 11),
                new BusStation("ул. Ордженикидзе №1", 12),
                new BusStation("ул. Кирова №61"     , 13),
                new BusStation("ул. Кирова №97"     , 14),
                new BusStation("ул. Рубина №5"      , 15),
                new BusStation("ул. Собранная №2"   , 16),
                new BusStation("ул. Теплосерная №12", 17),
                new BusStation("ул. Теплосерная №55", 18),
            };

            CreateRoad(2, busStations, 1, 2);
            CreateRoad(1, busStations, 1, 4);
            CreateRoad(1, busStations, 1, 5);
            
            CreateRoad(2, busStations, 2, 1);
            CreateRoad(2, busStations, 2, 3);
            
            CreateRoad(2, busStations, 3, 2);
            CreateRoad(1, busStations, 3, 4);
            
            CreateRoad(1, busStations, 4, 1);
            CreateRoad(1, busStations, 4, 3);
            
            CreateRoad(1, busStations, 5, 1);
            CreateRoad(1, busStations, 5, 6);
            
            CreateRoad(1, busStations, 6, 5);
            CreateRoad(1, busStations, 6, 7);
            CreateRoad(1, busStations, 6, 13);
            
            CreateRoad(1, busStations, 7, 6);
            CreateRoad(1, busStations, 7, 8);
            CreateRoad(1, busStations, 7, 13);
            
            CreateRoad(1, busStations, 8, 7);
            CreateRoad(1, busStations, 8, 9);
            
            CreateRoad(1, busStations, 9, 8);
            CreateRoad(1, busStations, 9, 10);
            CreateRoad(3, busStations, 9, 12);
            
            CreateRoad(1, busStations, 10, 9);
            CreateRoad(2, busStations, 10, 11);
            
            CreateRoad(2, busStations, 11, 10);
            
            CreateRoad(3, busStations, 12, 9);
            
            CreateRoad(1, busStations, 13, 6);
            CreateRoad(1, busStations, 13, 7);
            CreateRoad(2, busStations, 13, 14);

            CreateRoad(2, busStations, 14, 13);
            CreateRoad(1, busStations, 14, 15);
            CreateRoad(1, busStations, 14, 17);

            CreateRoad(1, busStations, 15, 14);
            CreateRoad(1, busStations, 15, 16);

            CreateRoad(1, busStations, 16, 15);

            CreateRoad(1, busStations, 17, 14);
            CreateRoad(2, busStations, 17, 18);

            CreateRoad(2, busStations, 18, 17);

            return busStations;
        }

        private void CreateRoad(int distance, List<BusStation> busStations, int inStationId, int outStationId)
        {
            new Road(distance, busStations[inStationId - 1], busStations[outStationId - 1]);
        }
    }
}
