// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.V2.Compute
{
    using Management.Compute;
    using Management.Compute.Models;
    using Resource.Core;
    /// <summary>
    /// The implementation for VirtualMachineExtensionImageVersions.
    /// </summary>
    internal partial class VirtualMachineExtensionImageVersionsImpl  :
        ReadableWrappers<IVirtualMachineExtensionImageVersion, VirtualMachineExtensionImageVersionImpl, VirtualMachineExtensionImageInner>,
        IVirtualMachineExtensionImageVersions
    {
        private IVirtualMachineExtensionImagesOperations client;
        private IVirtualMachineExtensionImageType type;
        internal  VirtualMachineExtensionImageVersionsImpl (IVirtualMachineExtensionImagesOperations client, IVirtualMachineExtensionImageType type)
        {
            this.client = client;
            this.type = type;
        }

        public PagedList<IVirtualMachineExtensionImageVersion> List ()
        {
            return WrapList(this.client.ListVersions(
                type.RegionName,
                type.Publisher().Name,
                type.Name));
        }

        protected override IVirtualMachineExtensionImageVersion WrapModel (VirtualMachineExtensionImageInner inner)
        {
            return new VirtualMachineExtensionImageVersionImpl(client, type, inner);
        }
    }
}