// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Management.Compute;
    using Management.Compute.Fluent.Models;
    using Resource.Fluent.Core;
    /// <summary>
    /// The implementation for VirtualMachineSizes.
    /// </summary>
    internal partial class VirtualMachineSizesImpl :
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
            return ListByRegion(region.Name);
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