// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information

namespace Microsoft.Azure.Management.Compute.Fluent
{

    using Management.Compute.Fluent.Models;
    using Resource.Fluent.Core;
    using Management.Compute;

    /// <summary>
    /// The implementation for VirtualMachineExtensionImageTypes.
    /// </summary>
    internal partial class VirtualMachineExtensionImageTypesImpl  :
        ReadableWrappers<IVirtualMachineExtensionImageType, VirtualMachineExtensionImageTypeImpl, VirtualMachineExtensionImageInner>,
        IVirtualMachineExtensionImageTypes
    {
        private IVirtualMachineExtensionImagesOperations client;
        private IVirtualMachinePublisher publisher;
        internal  VirtualMachineExtensionImageTypesImpl (IVirtualMachineExtensionImagesOperations client, IVirtualMachinePublisher publisher)
        {
            this.client = client;
            this.publisher = publisher;
        }

        public PagedList<IVirtualMachineExtensionImageType> List ()
        {
            return WrapList(this.client.ListTypes(this.publisher.Region.Name, this.publisher.Name));
        }

        protected override IVirtualMachineExtensionImageType WrapModel (VirtualMachineExtensionImageInner inner)
        {
            return new VirtualMachineExtensionImageTypeImpl(this.client, this.publisher, inner);
        }
    }
}