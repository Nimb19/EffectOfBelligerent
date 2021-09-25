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

        public Validator(PayServiceController paySerrvice)
        {
            Uid = Guid.NewGuid();
            _paySerrvice = paySerrvice;
        }
    }
}
