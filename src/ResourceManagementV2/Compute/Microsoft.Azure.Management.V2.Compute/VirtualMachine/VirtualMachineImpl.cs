using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.V2.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.V2.Resource.Core;

namespace Microsoft.Azure.Management.V2.Compute
{
    internal class VirtualMachineImpl :
        GroupableResource<IVirtualMachine,
            Management.Compute.Models.VirtualMachine,
            Management.Compute.Models.Resource,
            VirtualMachineImpl,
            ComputeManager,
            VirtualMachine.Definition.IWithGroup,
            VirtualMachine.Definition.IWithCreate>,
        IVirtualMachine,
        VirtualMachine.Definition.IDefinition,
        VirtualMachine.Update.IUpdate
    {
        internal VirtualMachineImpl(string name,
        Management.Compute.Models.VirtualMachine innerObject,
        IVirtualMachinesOperations client,
        ComputeManager manager) : base(name, innerObject, manager)
        {
        }

        public override Task<IResource> CreateResourceAsync()
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
