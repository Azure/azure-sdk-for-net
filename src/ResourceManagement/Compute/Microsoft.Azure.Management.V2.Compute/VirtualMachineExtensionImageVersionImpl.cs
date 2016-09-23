/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    /// <summary>
    /// The implementation for {@link VirtualMachineExtensionImageVersion}.
    /// </summary>
    public partial class VirtualMachineExtensionImageVersionImpl  :
        WrapperImpl<Microsoft.Azure.Management.V2.Compute.VirtualMachineExtensionImageInner>,
        IVirtualMachineExtensionImageVersion
    {
        private VirtualMachineExtensionImagesInner client;
        private IVirtualMachineExtensionImageType type;
        private  VirtualMachineExtensionImageVersionImpl (VirtualMachineExtensionImagesInner client, IVirtualMachineExtensionImageType extensionImageType, VirtualMachineExtensionImageInner inner)
        {

            //$ VirtualMachineExtensionImageType extensionImageType,
            //$ VirtualMachineExtensionImageInner inner) {
            //$ super(inner);
            //$ this.client = client;
            //$ this.type = extensionImageType;
            //$ }

        }

        public string Id
        {
            get
            {
            //$ return this.inner().id();


                return null;
            }
        }
        public string Name
        {
            get
            {
            //$ return this.inner().name();


                return null;
            }
        }
        public string RegionName
        {
            get
            {
            //$ return this.inner().location();


                return null;
            }
        }
        public IVirtualMachineExtensionImageType Type ()
        {

            //$ return this.type;

            return null;
        }

        public IVirtualMachineExtensionImage Image ()
        {

            //$ VirtualMachineExtensionImageInner inner = this.client.get(this.regionName(),
            //$ this.type().publisher().name(),
            //$ this.type().name(),
            //$ this.name());
            //$ return new VirtualMachineExtensionImageImpl(this, inner);

            return null;
        }

    }
}