// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine extension image.
    /// <p>
    /// Note: Azure virtual machine extension image is also referred as virtual machine extension handler.
    /// </summary>
    public interface IVirtualMachineExtensionImage :
        IWrapper<VirtualMachineExtensionImageInner>
    {
        /// <returns>the resource ID of the extension image</returns>
        string Id();

        /// <returns>the region in which virtual machine extension image is available</returns>
        string RegionName();

        /// <returns>the name of the publisher of the virtual machine extension image</returns>
        string PublisherName();

        /// <returns>the name of the virtual machine extension image type this image belongs to</returns>
        string TypeName();

        /// <returns>the name of the virtual machine extension image version this image represents</returns>
        string VersionName();

        /// <returns>the operating system this virtual machine extension image supports</returns>
        OperatingSystemTypes? OsType();

        /// <returns>the type of role this virtual machine extension image supports</returns>
        ComputeRoles? ComputeRole();

        /// <returns>the schema defined by publisher, where extension consumers should provide settings in a matching schema</returns>
        /// <returns><p></returns>
        /// <returns>Note this field will be null since server provide null for them</returns>
        string HandlerSchema();

        /// <returns>true if the extension can be used on xRP Virtual Machine ScaleSets.</returns>
        /// <returns><p></returns>
        /// <returns>Note by default existing extensions are usable on scale sets, but there might be cases where a publisher wants to</returns>
        /// <returns>explicitly indicate the extension is only enabled for Compute Resource Provider VMs but not Virtual Machine ScaleSets.</returns>
        bool? VmScaleSetEnabled();

        /// <returns>true if the handler can support multiple extensions.</returns>
        bool? SupportsMultipleExtensions();

        /// <returns>the virtual machine extension image version this image belongs to</returns>
        IVirtualMachineExtensionImageVersion Version();

    }
}