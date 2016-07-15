using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Compute
{
    public interface IVirtualMachines :
        ISupportsCreating<VirtualMachine.Definition.IBlank>,
        ISupportsListing<IVirtualMachine>
    {}
}
