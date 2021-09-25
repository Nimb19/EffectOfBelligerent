using CommonLib.Logger;
using CommonLib.Models.ExternalServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonLib.Models.ServerModels
{
    public class PayServiceController
    {
        /// <summary> Оплата за проезд </summary>
        public const double Fare = 42;

        private readonly ILogger _logger;
        /// <summary> К гуиду автобуса - кол-во уидов людей, которые в нём зарегистрированы </summary>
        private readonly Dictionary<Guid, List<Guid>> _authorizedCards 
            = new Dictionary<Guid, List<Guid>>();

        public PayServiceController(ILogger logger)
        {
            _logger = logger;
            _logger.WriteLine($"Инициализация {nameof(PayServiceController)}");
        }

        public bool CheckCardIsPaid(PaymentCard paymentCard, Guid tsUid)
        {
            if (_authorizedCards.ContainsKey(tsUid))
                return _authorizedCards[tsUid].Any(x => x == paymentCard.Uid);
            else
                return false;
        }

        public bool MakePayment(PaymentCard paymentCard, Guid tsUid, double money)
        {
            _logger.WriteLine($"Оплата от {paymentCard.HolderName} в количестве {money}");

            if (CheckCardIsPaid(paymentCard, tsUid))
                return true;

            return PayAnyway(paymentCard, tsUid, money);
        }

        public bool PayAnyway(PaymentCard paymentCard, Guid tsUid, double money)
        {
            var payment = paymentCard.Pay(money);
            if (payment)
            {
                _logger.WriteLine($"Оплата прошла успешно!");

                if (_authorizedCards.ContainsKey(tsUid))
                    _authorizedCards[tsUid].Add(paymentCard.Uid);
                else
                    _authorizedCards.Add(tsUid, new List<Guid>() { paymentCard.Uid });

                return true;
            }
            else
            {
                _logger.WriteLine($"Оплата не была совершена.");
                return false;
            }
        }
    }
}
