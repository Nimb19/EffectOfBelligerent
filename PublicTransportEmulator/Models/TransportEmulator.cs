using CommonLib.Logger;
using CommonLib.Models;
using CommonLib.Models.ServerModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommonLib
{
    public class TransportEmulator
    {
        private Map _map;
        private readonly ILogger _logger;

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
                Task.Run(() => BusEmulator(bus));
            }
        }

        private void BusEmulator(Bus bus)
        {
            bus.
        }
    }
}
