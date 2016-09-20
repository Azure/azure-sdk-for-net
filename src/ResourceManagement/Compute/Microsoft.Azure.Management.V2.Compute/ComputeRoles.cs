using Microsoft.Azure.Management.V2.Resource.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Compute
{
    public enum ComputeRoles
    {
        [EnumName("PaaS")]
        PAAS,

        [EnumName("IaaS")]
        IAAS
    }
}
