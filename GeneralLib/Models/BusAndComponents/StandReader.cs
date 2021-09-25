﻿using GeneralLib.Models.BusAndComponents;
using GeneralLib.Models.ServerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLib.Models
{
    public class StandReader : INFSModuleReader
    {
        public Guid Uid { get; set; }

        private PayServiceController _paySerrvice;

        public StandReader(Guid uid, PayServiceController paySerrvice)
        {
            Uid = uid;
            _paySerrvice = paySerrvice;
        }
    }
}
