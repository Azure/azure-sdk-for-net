// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    internal partial class VirtualMachineExtensionImageImpl 
    {
        /// <summary>
        /// Gets the region in which virtual machine extension image is available.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage.RegionName
        {
            get
            {
                return this.RegionName();
            }
        }

        /// <summary>
        /// Gets the schema defined by publisher, where extension consumers should provide settings in a matching schema.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage.HandlerSchema
        {
            get
            {
                return this.HandlerSchema();
            }
        }

        /// <summary>
        /// Gets the operating system this virtual machine extension image supports.
        /// </summary>
        Models.OperatingSystemTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage.OsType
        {
            get
            {
                return this.OsType();
            }
        }

        /// <summary>
        /// Gets the resource ID of the extension image.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the name of the virtual machine extension image version this image represents.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage.VersionName
        {
            get
            {
                return this.VersionName();
            }
        }

        /// <summary>
        /// Gets true if the handler can support multiple extensions.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage.SupportsMultipleExtensions
        {
            get
            {
                return this.SupportsMultipleExtensions();
            }
        }

        /// <summary>
        /// Gets the virtual machine extension image version this image belongs to.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageVersion Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage.Version
        {
            get
            {
                return this.Version() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageVersion;
            }
        }

        /// <summary>
        /// Gets the name of the publisher of the virtual machine extension image.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage.PublisherName
        {
            get
            {
                return this.PublisherName();
            }
        }

        /// <summary>
        /// Gets true if the extension can be used with virtual machine scale sets, false otherwise.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage.SupportsVirtualMachineScaleSets
        {
            get
            {
                return this.SupportsVirtualMachineScaleSets();
            }
        }

        /// <summary>
        /// Gets the name of the virtual machine extension image type this image belongs to.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage.TypeName
        {
            get
            {
                return this.TypeName();
            }
        }

        /// <summary>
        /// Gets the type of role this virtual machine extension image supports.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.ComputeRoles Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage.ComputeRole
        {
            get
            {
                return this.ComputeRole();
            }
        }
    }
}