// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information

namespace Microsoft.Azure.Management.V2.Compute
{
    using Management.Compute;
    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    /// <summary>
    /// The implementation for {@link VirtualMachineExtensionImageType}.
    /// </summary>
    public partial class VirtualMachineExtensionImageTypeImpl  :
        Wrapper<Microsoft.Azure.Management.Compute.Models .VirtualMachineExtensionImageInner>,
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

        public IVirtualMachinePublisher Publisher
        {
            get
            {
                return this.publisher;
            }
        }

        public IVirtualMachineExtensionImageVersions Versions
        {
            get
            {
                return new VirtualMachineExtensionImageVersionsImpl(this.client, this);
            }
        }
    }
}