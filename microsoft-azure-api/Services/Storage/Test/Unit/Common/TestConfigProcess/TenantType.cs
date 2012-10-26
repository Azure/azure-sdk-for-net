using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.WindowsAzure.Storage
{
    [Flags]
    public enum TenantType
    {
        None = 0x0,
        DevStore = 0x1,
        DevFabric = 0x2,
        Cloud = 0x4,
        All = 0x7
    }
}
