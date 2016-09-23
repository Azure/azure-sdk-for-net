/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    /// <summary>
    /// The implementation for {@link VirtualMachineExtensionImage}.
    /// </summary>
    public partial class VirtualMachineExtensionImageImpl  :
        WrapperImpl<VirtualMachineExtensionImageInner>,
        IVirtualMachineExtensionImage
    {
        private IVirtualMachineExtensionImageVersion version;
        private  VirtualMachineExtensionImageImpl (IVirtualMachineExtensionImageVersion version, VirtualMachineExtensionImageInner inner)
        {

            //$ super(inner);
            //$ this.version = version;
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
        public string RegionName
        {
            get
            {
            //$ return this.inner().location();


                return null;
            }
        }
        public string PublisherName
        {
            get
            {
            //$ return this.version().type().publisher().name();


                return null;
            }
        }
        public string TypeName
        {
            get
            {
            //$ return this.version().type().name();


                return null;
            }
        }
        public string VersionName
        {
            get
            {
            //$ return this.version().name();


                return null;
            }
        }
        public OperatingSystemTypes? OsType
        {
            get
            {
            //$ return OperatingSystemTypes.fromString(this.inner().operatingSystem());


                return null;
            }
        }
        public ComputeRoles? ComputeRole
        {
            get
            {
            //$ return ComputeRoles.fromString(this.inner().computeRole());


                return null;
            }
        }
        public string HandlerSchema
        {
            get
            {
            //$ return this.inner().handlerSchema();


                return null;
            }
        }
        public bool? VmScaleSetEnabled
        {
            get
            {
            //$ return this.inner().vmScaleSetEnabled();


                return null;
            }
        }
        public bool? SupportsMultipleExtensions
        {
            get
            {
            //$ return this.inner().supportsMultipleExtensions();


                return null;
            }
        }
        public IVirtualMachineExtensionImageVersion Version ()
        {

            //$ return this.version;

            return null;
        }

    }
}