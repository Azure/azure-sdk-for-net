// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information

namespace Microsoft.Azure.Management.Fluent.Compute
{
    using Management.Compute;
    using Management.Compute.Models;
    using Resource.Core;
    /// <summary>
    /// The implementation for VirtualMachineExtensionImageType.
    /// </summary>
    internal partial class VirtualMachineExtensionImageTypeImpl  :
        Wrapper<VirtualMachineExtensionImageInner>,
        IVirtualMachineExtensionImageType
    {
        private IVirtualMachineExtensionImagesOperations client;
        private IVirtualMachinePublisher publisher;
        internal  VirtualMachineExtensionImageTypeImpl (IVirtualMachineExtensionImagesOperations client, IVirtualMachinePublisher publisher, VirtualMachineExtensionImageInner inner) : base(inner)
        {
            this.client = client;
            this.publisher = publisher;
        }

        public string Id
        {
            get
            {
                return this.Inner.Id;
            }
        }

        public string Name
        {
            get
            {
                return this.Inner.Name;
            }
        }

        public string RegionName
        {
            get
            {
                return this.Inner.Location;
            }
        }

        public IVirtualMachinePublisher Publisher()
        {
            return this.publisher;
            //get
            //{
            //    return this.publisher;
            //}
        }

        public IVirtualMachineExtensionImageVersions Versions()
        {
            return new VirtualMachineExtensionImageVersionsImpl(this.client, this);
            //get
            //{
            //    return new VirtualMachineExtensionImageVersionsImpl(this.client, this);
            //}
        }
    }
}