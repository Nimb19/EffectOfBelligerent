using CommonLib.Logger;
using CommonLib.Models;
using CommonLib.Models.ServerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonLib
{
    public class TransportEmulator
    {
        private Map _map;
        private readonly ILogger _logger;
        private Random rng = new Random();

        public TransportEmulator(Map map, ILogger logger)
        {
            _map = map;
            _logger = logger;
        }

        public void StartEmulator()
        {
            var tasks = new List<Task>();
            var payService = new PayServiceController(_logger);
            foreach (var branch in _map.Branches)
            {
                for (int i = 0; i < branch.DefaultBusCount; i++)
                {
                    var busUid = Guid.NewGuid();
                    var validators = new List<Validator>() 
                    { 
                        new Validator(payService, busUid), 
                        new Validator(payService, busUid), 
                        new Validator(payService, busUid), 
                    };

                    var standReaders = new List<StandReader>() 
                    { 
                        new StandReader(payService, busUid),
                        new StandReader(payService, busUid),
                        new StandReader(payService, busUid),
                    };
                    branch.Buses.Add(new Bus(busUid, validators, standReaders));
                }
            }

            foreach (var branch in _map.Branches)
            {
                BranchEmulator(branch);
            }
        }

        private void BranchEmulator(Branch branch)
        {
            foreach (var bus in branch.Buses)
            {
                var busStationsOnTheBranch = branch.BusStations
                    .Select(x => _map.BusStations.First(y => y.Id == x)).ToArray();
                Task.Run(() => BusEmulator(bus, branch, busStationsOnTheBranch));
            }
        }

        private void BusEmulator(Bus bus, Branch branch, BusStation[] busStationsOnTheBranch)
        {
            var stationId = SetBusOnRandomStation(bus, branch, busStationsOnTheBranch);

            var nextStations = GetNextCicle(stationId, busStationsOnTheBranch);
            while (true)
            {
                for (int i = 1; i < nextStations.Count; i++)
                {
                    var station = nextStations[i];
                    _logger.Debug($"Автобус {bus.Uid} с ветки №{branch.Id} прибыл " +
                        $"на остановку {station.Name}");

                    EmulateHumans(bus, station, branch);
                    Task.Delay(2000).Wait();

                    Road roadToNextStation;
                    if (i + 1 != nextStations.Count) 
                        roadToNextStation = station.Roads
                            .First(x => x.LeadsIn.Id == nextStations[i + 1].Id);
                    else
                        roadToNextStation = station.Roads
                            .First(x => x.LeadsIn.Id == nextStations[0].Id);

                    var ms = 4000 * roadToNextStation.Distance;
                    _logger.Debug($"Через {ms / 1000} секунд автобус {bus.Uid} доедет " +
                        $"до следующей остановки {roadToNextStation.LeadsIn.Name}");
                    Task.Delay(ms).Wait();
                }
            }
        }

        /// <summary> Эмулирует загрузку и выгрузку пассажиров </summary>
        private void EmulateHumans(Bus bus, BusStation station, Branch branch)
        {
            var rngPeopleCount = rng.Next(0, 10);

            bus.People.Add(new Human(Guid.NewGuid().ToString()), null);

            foreach (var human in bus.People)
            {
                var isBellinger = rng.Next(0, 30);

            }
        }

        private List<BusStation> GetNextCicle(int stationId, BusStation[] busStationsOnTheBranch)
        {
            var elIndex = GetElementIndex(stationId, busStationsOnTheBranch);
            var resultList = new List<BusStation>();

            for (int i = 1; i <= 10; i++)
            {
                if (busStationsOnTheBranch.Length == elIndex + i)
                {
                    for (int j = (elIndex + i) - 2; j >= elIndex; j++)
                    {
                        resultList.Add(busStationsOnTheBranch[j]);
                    }
                    return resultList;
                }
                else
                {
                    resultList.Add(busStationsOnTheBranch[elIndex + i]);
                }
            }

            // Код недоступен
            throw new Exception();
        }

        private int GetElementIndex(int stationId, BusStation[] busStationsOnTheBranch)
        {
            for (int i = 0; i < busStationsOnTheBranch.Length; i++)
            {
                if (busStationsOnTheBranch[i].Id == stationId)
                    return i;
            }
            throw new Exception($"В массиве busStationsOnTheBranch не было элемента с Id={stationId}");
        }

        private BusStation GetNextStation(int stationId, IEnumerable<BusStation> busStationsOnTheBranch
            , out IEnumerable<int> nextIdStations)
        {
            throw new NotImplementedException();
        }

        private int SetBusOnRandomStation(Bus bus, Branch branch, IEnumerable<BusStation> busStationsOnTheBranch)
        {
            var stantion = busStationsOnTheBranch.ToList()
                .Shuffle(rng)
                .GetRandom(rng);

            stantion.Buses.Add(bus);
            bus.CurrentStation = stantion;

            return stantion.Id;
        }
    }
}
