using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.V2.Resource.Core;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.V2.Compute
{
    public partial class VirtualMachinePublishersImpl
        : ReadableWrappers<IVirtualMachinePublisher, VirtualMachinePublisherImpl, VirtualMachineImageResourceInner>,
          IVirtualMachinePublishers
    {
        private IVirtualMachineImagesOperations innerCollection;

        internal VirtualMachinePublishersImpl(IVirtualMachineImagesOperations innerCollection)
        {
            this.innerCollection = innerCollection;
        }

        public PagedList<IVirtualMachinePublisher> ListByRegion(string regionName)
        {
            IEnumerable<VirtualMachineImageResourceInner> innerPublishers = innerCollection.ListPublishers(regionName);
            var pagedList = new PagedList<VirtualMachineImageResourceInner>(innerPublishers);
            return WrapList(pagedList);
        }

        public PagedList<IVirtualMachinePublisher> ListByRegion(Region region)
        {
            return this.ListByRegion(EnumNameAttribute.GetName(region));
        }

        protected override IVirtualMachinePublisher WrapModel(VirtualMachineImageResourceInner inner)
        {
            return new VirtualMachinePublisherImpl(EnumNameAttribute.FromName<Region>(inner.Location), inner.Name, this.innerCollection);
        }
    }
}
