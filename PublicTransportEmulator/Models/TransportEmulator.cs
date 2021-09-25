using CommonLib.Logger;
using CommonLib.Models;

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
    }
}
