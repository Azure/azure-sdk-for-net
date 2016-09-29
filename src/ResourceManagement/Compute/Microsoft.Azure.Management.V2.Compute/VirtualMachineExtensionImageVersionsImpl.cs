// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.V2.Compute
{
    using Management.Compute;
    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    /// <summary>
    /// The implementation for {@link VirtualMachineExtensionImageVersions}.
    /// </summary>
    internal partial class VirtualMachineExtensionImageVersionsImpl  :
        ReadableWrappers<Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImageVersion,Microsoft.Azure.Management.V2.Compute.VirtualMachineExtensionImageVersionImpl,Microsoft.Azure.Management.Compute.Models .VirtualMachineExtensionImageInner>,
        IVirtualMachineExtensionImageVersions
    {
        private IVirtualMachineExtensionImagesOperations client;
        private IVirtualMachineExtensionImageType type;
        internal  VirtualMachineExtensionImageVersionsImpl (IVirtualMachineExtensionImagesOperations client, IVirtualMachineExtensionImageType type)
        {
            this.client = client;
            this.type = type;
        }

        public PagedList<Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImageVersion> List ()
        {
            return WrapList(this.client.ListVersions(this.type.RegionName,
            this.type.Publisher().Name,
            this.type.Name));
        }

        protected override IVirtualMachineExtensionImageVersion WrapModel (VirtualMachineExtensionImageInner inner)
        {
            return new VirtualMachineExtensionImageVersionImpl(this.client, this.type, inner);
        }
    }
}