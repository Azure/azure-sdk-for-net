// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.V2.Compute
{
    using Management.Compute;
    using Management.Compute.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    /// <summary>
    /// The implementation for {@link VirtualMachineExtensionImageVersion}.
    /// </summary>
    internal partial class VirtualMachineExtensionImageVersionImpl  :
        Wrapper<Microsoft.Azure.Management.Compute.Models.VirtualMachineExtensionImageInner>,
        IVirtualMachineExtensionImageVersion
    {
        private IVirtualMachineExtensionImagesOperations client;
        private IVirtualMachineExtensionImageType type;
        internal  VirtualMachineExtensionImageVersionImpl (IVirtualMachineExtensionImagesOperations client, IVirtualMachineExtensionImageType extensionImageType, VirtualMachineExtensionImageInner inner) : base(inner)
        {
            this.client = client;
            this.type = extensionImageType;
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

        public IVirtualMachineExtensionImageType Type()
        {
            return this.type;
            //get 
            //{
            //    return this.type;
            //}
        }

        public IVirtualMachineExtensionImage Image ()
        {
            VirtualMachineExtensionImageInner inner = this.client.Get(this.RegionName,
                this.Type().Publisher().Name,
                this.Type().Name,
                this.Name);
            return new VirtualMachineExtensionImageImpl(this, inner);
        }
    }
}