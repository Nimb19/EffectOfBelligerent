using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Models.ExternalServices
{
    public class PaymentCard
    {
        public Guid Uid { get; }
        /// <summary> Имя человека, за кем карта </summary>
        public string HolderName { get; }
        public double Money { get; private set; }

        public PaymentCard(Guid uid, string humanName, double money)
        {
            Uid = uid;
            HolderName = humanName;
            Money = money;
        }

        public bool Pay(double money)
        {
            if (Money < money)
                return false;
            else
            {
                Money -= money;
                return true;
            }
        }

        public void AddMoney(double money)
        {
            Money += money;
        }
    }
}
