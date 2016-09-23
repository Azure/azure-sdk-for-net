// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.Compute.Models;
    public partial class VirtualMachineExtensionImageImpl
    {
        /// <returns>the region in which virtual machine extension image is available</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImage.RegionName
        {
            get
            {
                return this.RegionName as string;
            }
        }
        /// <returns>the schema defined by publisher, where extension consumers should provide settings in a matching schema</returns>
        /// <returns><p></returns>
        /// <returns>Note this field will be null since server provide null for them</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImage.HandlerSchema
        {
            get
            {
                return this.HandlerSchema as string;
            }
        }
        /// <returns>the operating system this virtual machine extension image supports</returns>
        Microsoft.Azure.Management.Compute.Models.OperatingSystemTypes? Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImage.OsType
        {
            get
            {
                return this.OsType;
            }
        }
        /// <returns>the resource ID of the extension image</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImage.Id
        {
            get
            {
                return this.Id as string;
            }
        }
        /// <returns>the name of the virtual machine extension image version this image represents</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImage.VersionName
        {
            get
            {
                return this.VersionName as string;
            }
        }
        /// <returns>true if the handler can support multiple extensions.</returns>
        bool? Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImage.SupportsMultipleExtensions
        {
            get
            {
                return this.SupportsMultipleExtensions;
            }
        }
        /// <returns>the virtual machine extension image version this image belongs to</returns>
        Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImageVersion Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImage.Version
        {
            get
            {
                return this.Version as Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImageVersion;
            }
        }

        /// <returns>the name of the publisher of the virtual machine extension image</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImage.PublisherName
        {
            get
            {
                return this.PublisherName as string;
            }
        }
        /// <returns>the name of the virtual machine extension image type this image belongs to</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImage.TypeName
        {
            get
            {
                return this.TypeName as string;
            }
        }
        /// <returns>the type of role this virtual machine extension image supports</returns>
        Microsoft.Azure.Management.Compute.Models.ComputeRoles? Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImage.ComputeRole
        {
            get
            {
                return this.ComputeRole;
            }
        }
        /// <returns>true if the extension can be used on xRP Virtual Machine ScaleSets.</returns>
        /// <returns><p></returns>
        /// <returns>Note by default existing extensions are usable on scale sets, but there might be cases where a publisher wants to</returns>
        /// <returns>explicitly indicate the extension is only enabled for Compute Resource Provider VMs but not Virtual Machine ScaleSets.</returns>
        bool? Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImage.VmScaleSetEnabled
        {
            get
            {
                return this.VmScaleSetEnabled;
            }
        }
    }
}