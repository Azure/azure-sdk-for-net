using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    /**
     * The minimum valid number of master nodes.
     */
    public enum ContainerServiceMasterProfileCount
    {
        /** Enum value Min. */
        MIN = 1,

        /** Enum value Mid. */
        MID = 3,

        /** Enum value Max. */
        MAX = 5
    }
}
