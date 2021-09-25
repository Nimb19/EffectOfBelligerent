using CommonLib.Models.ExternalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Models.BusAndComponents
{
    public interface INFSModuleReader
    {
        Guid Uid { get; }
        bool Pay(PaymentCard paymentCard);
        bool PayAnyway(PaymentCard paymentCard);
        bool Check(PaymentCard paymentCard);
    }
}
