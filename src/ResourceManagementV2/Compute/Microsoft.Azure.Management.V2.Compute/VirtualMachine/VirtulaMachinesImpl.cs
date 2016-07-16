using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.V2.Resource.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure;
using System.Collections;

namespace Microsoft.Azure.Management.V2.Compute
{
    internal class VirtulaMachinesImpl :
                GroupableResources<
                IVirtualMachine,
                VirtualMachineImpl,
                VirtualMachineInner,
                IVirtualMachinesOperations,
                ComputeManager>,
                IVirtualMachines
    {
        internal VirtulaMachinesImpl(IVirtualMachinesOperations innerCollection, ComputeManager manager) : base(innerCollection, manager)
        { }

        public VirtualMachine.Definition.IBlank Define(string name)
        {
            throw new NotImplementedException();
        }

        public override Task<IVirtualMachine> GetByGroupAsync(string groupName, string name)
        {
            throw new NotImplementedException();
        }

        public PagedList<IVirtualMachine> List()
        {

            IPage<Management.Compute.Models.VirtualMachineInner> firstPage = InnerCollection.ListAll();
            var pagedList = new PagedList<Management.Compute.Models.VirtualMachineInner>(firstPage, (string nextPageLink) =>
            {
                return InnerCollection.ListAllNext(nextPageLink);
            });
            return WrapList(pagedList);
        }

        protected override IVirtualMachine WrapModel(VirtualMachineInner inner)
        {
            return new VirtualMachineImpl(inner.Name,
                inner,
                InnerCollection,
                MyManager);
        }

        protected override VirtualMachineImpl WrapModel(string name)
        {
            throw new NotImplementedException();
        }
    }
}
