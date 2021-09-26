using CommonLib.Models.ExternalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Models
{
    public class Human
    {
        public string Name { get; set; }
        public PaymentCard CardUid { get; set; }

        public Human(string name, PaymentCard cardUid)
        {
            Name = name;
            CardUid = cardUid;
        }
    }
}
