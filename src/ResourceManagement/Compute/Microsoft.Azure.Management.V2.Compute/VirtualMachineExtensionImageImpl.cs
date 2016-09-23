// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.Compute.Models;
    /// <summary>
    /// The implementation for {@link VirtualMachineExtensionImage}.
    /// </summary>
    public partial class VirtualMachineExtensionImageImpl :
        Wrapper<Microsoft.Azure.Management.Compute.Models.VirtualMachineExtensionImageInner>,
        IVirtualMachineExtensionImage
    {
        private IVirtualMachineExtensionImageVersion version;
        internal VirtualMachineExtensionImageImpl(IVirtualMachineExtensionImageVersion version, VirtualMachineExtensionImageInner inner) : base(inner)
        {
            this.version = version;
        }

        public string Id
        {
            get
            {
                return this.Inner.Id;
            }
        }

        public string RegionName
        {
            get
            {
                return this.Inner.Location;
            }
        }

        public string PublisherName
        {
            get
            {
                return this.Version.Type.Publisher.Name;
            }
        }

        public string TypeName
        {
            get
            {
                return this.Version.Type.Name;
            }
        }

        public string VersionName
        {
            get
            {
                return this.Version.Name;
            }
        }
        public OperatingSystemTypes? OsType
        {
            get
            {
                if (this.Inner.OperatingSystem == null)
                {
                    return null;
                }
                // OperatingSystemTypes is an AutoRest generated type from the swagger
                return EnumHelper.FromEnumMemberSerializationValue<OperatingSystemTypes>(this.Inner.OperatingSystem);
            }
        }

        public ComputeRoles? ComputeRole
        {
            get
            {
                if (this.Inner.ComputeRole == null)
                {
                    return null;
                }
                // ComputeRole is a fluent level convinence enum
                return EnumNameAttribute.FromName<ComputeRoles>(this.Inner.ComputeRole);
            }
        }

        public string HandlerSchema
        {
            get
            {
                return this.Inner.HandlerSchema;
            }
        }

        public bool? VmScaleSetEnabled
        {
            get
            {
                return this.Inner.VmScaleSetEnabled;
            }
        }

        public bool? SupportsMultipleExtensions
        {
            get
            {
                return this.Inner.SupportsMultipleExtensions;
            }
        }

        public IVirtualMachineExtensionImageVersion Version
        {
            get
            {
                return this.version;
            }
        }

    }
}