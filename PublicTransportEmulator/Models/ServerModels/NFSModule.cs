using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportEmulator.Models.ServerModels
{
    public class NFSModule
    {
        public Guid Uid { get; }
        public string UserName { get; }

        public NFSModule(Guid uid, string userName)
        {
            Uid = uid;
            UserName = userName;
        }
    }
}
