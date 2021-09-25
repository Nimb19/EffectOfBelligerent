using CommonLib.Models.ServerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Models
{
    public class Validator
    {
        public Guid Uid { get; }

        private PayServiceController _paySerrvice;

        public Validator(Guid uid, PayServiceController paySerrvice)
        {
            Uid = uid;
            _paySerrvice = paySerrvice;
        }
    }
}
