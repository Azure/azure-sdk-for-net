using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Compute
{
    public interface IVirtualMachine :
        IGroupableResource,
        IResource,
        IRefreshable<IVirtualMachine>,
        IUpdatable<VirtualMachine.Update.IUpdate>,
        IWrapper<Management.Compute.Models.VirtualMachineInner>
    {}
}
