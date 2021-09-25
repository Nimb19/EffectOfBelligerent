using CommonLib.Models.ExternalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Models.ServerModels
{
    public class PayServiceController
    {
        private PaymentCard _card;
        private UserAccount _userAccount;

        public PayServiceController(PaymentCard card, UserAccount userAccount)
        {
            _card = card;
            _userAccount = userAccount;
        }
    }
}
