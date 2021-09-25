using CommonLib.Models.BusAndComponents;
using CommonLib.Models.ServerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Models
{
    public class StandReader : INFSModuleReader
    {
        public Guid Uid { get; set; }

        private PayServiceController _paySerrvice;

        public StandReader(PayServiceController paySerrvice)
        {
            Uid = Guid.NewGuid();
            _paySerrvice = paySerrvice;
        }
    }
}
