/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{
    using Management.Compute.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    /// <summary>
    /// The implementation for {@link VirtualMachineExtensionImage}.
    /// </summary>
    public partial class VirtualMachineExtensionImageImpl  :
        Wrapper<VirtualMachineExtensionImageInner>,
        IVirtualMachineExtensionImage
    {
        private IVirtualMachineExtensionImageVersion version;
        private  VirtualMachineExtensionImageImpl (IVirtualMachineExtensionImageVersion version, VirtualMachineExtensionImageInner inner) : base(inner)
        {
            this.version = version;
        }

        public string Id()
        {
            return this.Inner.Id;
            //get
            //{
            //    return this.Inner.Id;
            //}
        }

        public string RegionName()
        {
            return this.Inner.Location;
            //get
            //{
            //    return this.Inner.Location;
            //}
        }

        public string PublisherName()
        {
            return this.Version().Type.Publisher.Name;
            //get
            //{
            //    return this.Version.Type.Publisher.Name;
            //}
        }

        public string TypeName()
        {
            return this.Version().Type.Name;
            //get
            //{
            //    return this.Version.Type.Name;
            //}
        }

        public string VersionName()
        {
            return this.Version().Name;
            //get
            //{
            //    return this.Version.Name;
            //}
        }

        public OperatingSystemTypes? OsType()
        {
            if (this.Inner.OperatingSystem == null)
            {
                return null;
            }
            // OperatingSystemTypes is an AutoRest generated type from the swagger
            return EnumHelper.FromEnumMemberSerializationValue<OperatingSystemTypes>(this.Inner.OperatingSystem);

            //get
            //{
            //    if (this.Inner.OperatingSystem == null)
            //    {
            //        return null;
            //    }
            //    // OperatingSystemTypes is an AutoRest generated type from the swagger
            //    return EnumHelper.FromEnumMemberSerializationValue<OperatingSystemTypes>(this.Inner.OperatingSystem);
            //}
        }

        public ComputeRoles? ComputeRole()
        {
            if (this.Inner.ComputeRole == null)
            {
                return null;
            }
            // ComputeRole is a fluent level convinence enum
            return EnumNameAttribute.FromName<ComputeRoles>(this.Inner.ComputeRole);

            //get {
            //    if (this.Inner.ComputeRole == null)
            //    {
            //        return null;
            //    }
            //    // ComputeRole is a fluent level convinence enum
            //    return EnumNameAttribute.FromName<ComputeRoles>(this.Inner.ComputeRole);
            //}
        }

        public string HandlerSchema()
        {
            return this.Inner.HandlerSchema;
            //get
            //{
            //    return this.Inner.HandlerSchema;
            //}
        }

        public bool? VmScaleSetEnabled()
        {
            return this.Inner.VmScaleSetEnabled;
            //get
            //{
            //    return this.Inner.VmScaleSetEnabled;
            //}
        }

        public bool? SupportsMultipleExtensions()
        {
            return this.Inner.SupportsMultipleExtensions;
            //get
            //{
            //    return this.Inner.SupportsMultipleExtensions;
            //}
        }

        public IVirtualMachineExtensionImageVersion Version()
        {
            return this.version;
            //get
            //{
            //    return this.version;
            //}
        }

    }
}