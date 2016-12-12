// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    internal partial class VirtualMachineExtensionImageImpl
    {
        /// <return>The region in which virtual machine extension image is available.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage.RegionName
        {
            get
            {
                return this.RegionName() as string;
            }
        }

        /// <return>The schema defined by publisher, where extension consumers should provide settings in a matching schema.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage.HandlerSchema
        {
            get
            {
                return this.HandlerSchema() as string;
            }
        }

        /// <return>The operating system this virtual machine extension image supports.</return>
        Models.OperatingSystemTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage.OsType
        {
            get
            {
                return this.OsType();
            }
        }

        /// <return>The resource ID of the extension image.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage.Id
        {
            get
            {
                return this.Id() as string;
            }
        }

        /// <return>The name of the virtual machine extension image version this image represents.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage.VersionName
        {
            get
            {
                return this.VersionName() as string;
            }
        }

        /// <return>True if the handler can support multiple extensions.</return>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage.SupportsMultipleExtensions
        {
            get
            {
                return this.SupportsMultipleExtensions();
            }
        }

        /// <return>The virtual machine extension image version this image belongs to.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageVersion Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage.Version
        {
            get
            {
                return this.Version() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageVersion;
            }
        }

        /// <return>The name of the publisher of the virtual machine extension image.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage.PublisherName
        {
            get
            {
                return this.PublisherName() as string;
            }
        }

        /// <return>True if the extension can be used with virtual machine scale sets, false otherwise.</return>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage.SupportsVirtualMachineScaleSets
        {
            get
            {
                return this.SupportsVirtualMachineScaleSets();
            }
        }

        /// <return>The name of the virtual machine extension image type this image belongs to.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage.TypeName
        {
            get
            {
                return this.TypeName() as string;
            }
        }

        /// <return>The type of role this virtual machine extension image supports.</return>
        Microsoft.Azure.Management.Compute.Fluent.ComputeRoles Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage.ComputeRole
        {
            get
            {
                return this.ComputeRole();
            }
        }
    }
}