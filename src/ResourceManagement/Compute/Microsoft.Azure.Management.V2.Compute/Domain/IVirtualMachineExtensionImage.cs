// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Compute
{
    /// <summary>
    ///  An immutable client-side representation of an Azure virtual machine extension image.
    /// Note: Azure virtual machine extension image is also referred as virtual machine extension handler.
    /// </summary>
    public interface IVirtualMachineExtensionImage : IWrapper<VirtualMachineExtensionImageInner>
    {
         /// <returns>The resource ID of the extension image</returns>
        string Id { get; }

        /// <returns>the region in which virtual machine extension image is available</returns>
        string RegionName { get; }

        /// <returns>the name of the publisher of the virtual machine extension image</returns>
        string PublisherName { get; }

        /// <returns>the name of the virtual machine extension image type this image belongs to</returns>
        string TypeName { get; }

        /// <returns> the name of the virtual machine extension image version this image represents</returns>
        string VersionName { get; }

        /**
         * @return the operating system this virtual machine extension image supports
         */
        /// <returns>the region in which virtual machine extension image is available</returns>
        OperatingSystemTypes OsType();

        /// <returns>the type of role this virtual machine extension image supports</returns>
        ComputeRoles ComputeRole { get; }

        ///<summary>
        ///Note this field will be null since server provide null for them
        ///</summary>
        /// <returns>the schema defined by publisher, where extension consumers should provide settings in a matching schema</returns>
        string HandlerSchema { get; }

        ///<summary>
        /// Note by default existing extensions are usable on scale sets, but there might be cases where a publisher wants to
        /// explicitly indicate the extension is only enabled for Compute Resource Provider VMs but not Virtual Machine ScaleSets.
        ///</summary>
        /// <returns>true if the extension can be used on xRP Virtual Machine ScaleSets.</returns>
        bool VmScaleSetEnabled { get; }

        /// <returns>true if the handler can support multiple extensions.</returns>
        bool SupportsMultipleExtensions { get; }

        /// <returns>the virtual machine extension image version this image belongs to</returns>
        IVirtualMachineExtensionImageVersion Version { get; }
    }
}
