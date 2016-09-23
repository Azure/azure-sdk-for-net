// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Management.Compute;

    /// <summary>
    /// The implementation for {@link VirtualMachineExtensionImageTypes}.
    /// </summary>
    public partial class VirtualMachineExtensionImageTypesImpl  :
        ReadableWrappers<Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImageType,Microsoft.Azure.Management.V2.Compute.VirtualMachineExtensionImageTypeImpl,Microsoft.Azure.Management.Compute.Models .VirtualMachineExtensionImageInner>,
        IVirtualMachineExtensionImageTypes
    {
        private IVirtualMachineExtensionImagesOperations client;
        private IVirtualMachinePublisher publisher;
        internal  VirtualMachineExtensionImageTypesImpl (IVirtualMachineExtensionImagesOperations client, IVirtualMachinePublisher publisher)
        {
            this.client = client;
            this.publisher = publisher;
        }

        public PagedList<Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImageType> List ()
        {
            return WrapList(this.client.ListTypes(EnumNameAttribute.GetName(this.publisher.Region), this.publisher.Name));
        }

        protected override IVirtualMachineExtensionImageType WrapModel (VirtualMachineExtensionImageInner inner)
        {
            return new VirtualMachineExtensionImageTypeImpl(this.client, this.publisher, inner);
        }
    }
}