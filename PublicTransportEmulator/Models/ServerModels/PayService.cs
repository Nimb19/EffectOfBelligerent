using CommonLib.Logger;
using CommonLib.Models.ExternalServices;

namespace CommonLib.Models.ServerModels
{
    public class PayServiceController
    {
        ILogger _logger;

        public PayServiceController(ILogger logger)
        {
            _logger = logger;
            _logger.WriteLine("Инициализация PayServiceController");
        }

        public bool MakePayment(PaymentCard paymentCard, double money)
        {
            _logger.WriteLine($"Оплата от {paymentCard.HolderName} в количестве {money}");

            var payment = paymentCard.Pay(money);
            if (payment)
            {
                _logger.WriteLine($"Оплата прошла успешно!");
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
