// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;

    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine extension image.
    /// <p>
    /// Note: Azure virtual machine extension image is also referred as virtual machine extension handler.
    /// </summary>
    public interface IVirtualMachineExtensionImage :
        IWrapper<Models.VirtualMachineExtensionImageInner>
    {
        /// <return>The name of the publisher of the virtual machine extension image.</return>
        string PublisherName { get; }

        /// <return>The region in which virtual machine extension image is available.</return>
        string RegionName { get; }

        /// <return>True if the extension can be used with virtual machine scale sets, false otherwise.</return>
        bool SupportsVirtualMachineScaleSets { get; }

        /// <return>The name of the virtual machine extension image type this image belongs to.</return>
        string TypeName { get; }

        /// <return>The operating system this virtual machine extension image supports.</return>
        Models.OperatingSystemTypes OsType { get; }

        /// <return>The schema defined by publisher, where extension consumers should provide settings in a matching schema.</return>
        string HandlerSchema { get; }

        /// <return>The resource ID of the extension image.</return>
        string Id { get; }

        /// <return>The name of the virtual machine extension image version this image represents.</return>
        string VersionName { get; }

        /// <return>The type of role this virtual machine extension image supports.</return>
        Microsoft.Azure.Management.Compute.Fluent.ComputeRoles ComputeRole { get; }

        /// <return>True if the handler can support multiple extensions.</return>
        bool SupportsMultipleExtensions { get; }

        /// <return>The virtual machine extension image version this image belongs to.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageVersion Version { get; }
    }
}