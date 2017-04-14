// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine extension image.
    /// Note: Azure virtual machine extension image is also referred as virtual machine extension handler.
    /// </summary>
    public interface IVirtualMachineExtensionImage  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.VirtualMachineExtensionImageInner>
    {
        /// <summary>
        /// Gets the name of the virtual machine extension image type this image belongs to.
        /// </summary>
        string TypeName { get; }

        /// <summary>
        /// Gets the resource ID of the extension image.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets true if the handler can support multiple extensions.
        /// </summary>
        bool SupportsMultipleExtensions { get; }

        /// <summary>
        /// Gets the name of the publisher of the virtual machine extension image.
        /// </summary>
        string PublisherName { get; }

        /// <summary>
        /// Gets the type of role this virtual machine extension image supports.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.ComputeRoles ComputeRole { get; }

        /// <summary>
        /// Gets the region in which virtual machine extension image is available.
        /// </summary>
        string RegionName { get; }

        /// <summary>
        /// Gets the schema defined by publisher, where extension consumers should provide settings in a matching schema.
        /// </summary>
        string HandlerSchema { get; }

        /// <summary>
        /// Gets the operating system this virtual machine extension image supports.
        /// </summary>
        Models.OperatingSystemTypes OSType { get; }

        /// <summary>
        /// Gets the name of the virtual machine extension image version this image represents.
        /// </summary>
        string VersionName { get; }

        /// <summary>
        /// Gets true if the extension can be used with virtual machine scale sets, false otherwise.
        /// </summary>
        bool SupportsVirtualMachineScaleSets { get; }

        /// <summary>
        /// Gets the virtual machine extension image version this image belongs to.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageVersion Version { get; }
    }
}