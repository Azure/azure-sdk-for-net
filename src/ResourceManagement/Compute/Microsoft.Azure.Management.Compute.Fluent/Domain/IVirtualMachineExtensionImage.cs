// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Compute
{

    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using Microsoft.Azure.Management.Compute.Models;
    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine extension image.
    /// <p>
    /// Note: Azure virtual machine extension image is also referred as virtual machine extension handler.
    /// </summary>
    public interface IVirtualMachineExtensionImage  :
        IWrapper<Microsoft.Azure.Management.Compute.Models.VirtualMachineExtensionImageInner>
    {
        /// <returns>the resource ID of the extension image</returns>
        string Id { get; }

        /// <returns>the region in which virtual machine extension image is available</returns>
        string RegionName { get; }

        /// <returns>the name of the publisher of the virtual machine extension image</returns>
        string PublisherName { get; }

        /// <returns>the name of the virtual machine extension image type this image belongs to</returns>
        string TypeName { get; }

        /// <returns>the name of the virtual machine extension image version this image represents</returns>
        string VersionName { get; }

        /// <returns>the operating system this virtual machine extension image supports</returns>
        Microsoft.Azure.Management.Compute.Models.OperatingSystemTypes OsType { get; }

        /// <returns>the type of role this virtual machine extension image supports</returns>
        Microsoft.Azure.Management.Fluent.Compute.ComputeRoles ComputeRole { get; }

        /// <returns>the schema defined by publisher, where extension consumers should provide settings in a matching schema</returns>
        string HandlerSchema { get; }

        /// <returns>true if the extension can be used with virtual machine scale sets, false otherwise</returns>
        bool SupportsVirtualMachineScaleSets { get; }

        /// <returns>true if the handler can support multiple extensions</returns>
        bool SupportsMultipleExtensions { get; }

        /// <returns>the virtual machine extension image version this image belongs to</returns>
        Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineExtensionImageVersion Version { get; }

    }
}