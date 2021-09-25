using CommonLib.Logger;
using CommonLib.Models;
using CommonLib.Models.ServerModels;
using System.Collections.Generic;

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
            var payService = new PayServiceController(_logger);
            foreach (var branch in _map.Branches)
            {
                for (int i = 0; i < branch.DefaultBusCount; i++)
                {
                    var validators = new List<Validator>() 
                    { 
                        new Validator(payService), 
                        new Validator(payService), 
                        new Validator(payService) 
                    };

                    var standReaders = new List<StandReader>() 
                    { 
                        new StandReader(payService),
                        new StandReader(payService),
                        new StandReader(payService),
                    };
                    branch.Buses.Add(new Bus(validators, standReaders));
                }
            }   
        }
    }
}
