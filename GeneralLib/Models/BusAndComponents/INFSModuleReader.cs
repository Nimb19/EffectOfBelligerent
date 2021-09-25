using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLib.Models.BusAndComponents
{
    public interface INFSModuleReader
    {
        Guid Uid { get; }
        bool Pay();
        bool PayAnyway();
        bool Check();
    }
}
