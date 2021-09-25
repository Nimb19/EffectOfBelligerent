using CommonLib.Models.BusAndComponents;
using CommonLib.Models.ExternalServices;
using CommonLib.Models.ServerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Models
{
    public class Validator : INFSModuleReader
    {
        public Guid Uid { get; }
        public Guid TSUid { get; set; }

        private PayServiceController _paySerrvice;

        public Validator(PayServiceController paySerrvice, Guid tsUid)
        {
            Uid = Guid.NewGuid();
            TSUid = tsUid;
            _paySerrvice = paySerrvice;
        }

        public bool Pay(PaymentCard card)
        {
            return _paySerrvice.MakePayment(card, TSUid, PayServiceController.Fare);
        }

        public bool PayAnyway(PaymentCard card)
        {
            return _paySerrvice.PayAnyway(card, TSUid, PayServiceController.Fare);
        }

        public bool Check(PaymentCard paymentCard)
        {
            return _paySerrvice.CheckCardIsPaid(paymentCard, TSUid);
        }
    }
}
