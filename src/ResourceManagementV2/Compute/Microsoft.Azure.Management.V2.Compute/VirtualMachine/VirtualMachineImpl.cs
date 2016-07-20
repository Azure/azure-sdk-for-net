using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.V2.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.V2.Resource.Core;
using System.Threading;

namespace Microsoft.Azure.Management.V2.Compute
{
    internal class VirtualMachineImpl :
        GroupableResource<IVirtualMachine,
            Management.Compute.Models.VirtualMachineInner,
            Rest.Azure.Resource,
            VirtualMachineImpl,
            ComputeManager,
            VirtualMachine.Definition.IWithGroup,
            VirtualMachine.Definition.IWithCreate>,
        IVirtualMachine,
        VirtualMachine.Definition.IDefinition,
        VirtualMachine.Update.IUpdate
    {
        internal VirtualMachineImpl(string name,
        Management.Compute.Models.VirtualMachineInner innerObject,
        IVirtualMachinesOperations client,
        ComputeManager manager) : base(name, innerObject, manager)
        {
        }

        public override Task<IResource> CreateResourceAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<IVirtualMachine> Refresh()
        {
            throw new NotImplementedException();
        }

        public VirtualMachine.Update.IUpdate Update()
        {
            return this;
        }
    }
}
