/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/

namespace Microsoft.Azure.Management.V2.Compute
{
    using Management.Compute;
    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    /// <summary>
    /// The implementation for {@link VirtualMachineSizes}.
    /// </summary>
    public partial class VirtualMachineSizesImpl :
        ReadableWrappers<IVirtualMachineSize, VirtualMachineSizeImpl, VirtualMachineSize>,
        IVirtualMachineSizes
    {
        private IVirtualMachineSizesOperations innerCollection;

        internal VirtualMachineSizesImpl(IVirtualMachineSizesOperations innerCollection)
        {
            this.innerCollection = innerCollection;
        }

        public PagedList<IVirtualMachineSize> ListByRegion(Region region)
        {
            return ListByRegion(region.ToString());
        }

        protected override IVirtualMachineSize WrapModel(VirtualMachineSize inner)
        {
             return new VirtualMachineSizeImpl(inner);
        }

        public PagedList<IVirtualMachineSize> ListByRegion(string regionName)
        {
            var data = innerCollection.List(regionName);
            return WrapList(new PagedList<VirtualMachineSize>(data));

        }

    }
}