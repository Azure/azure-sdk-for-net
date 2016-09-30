﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Compute
{

    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine extension image version.
    /// </summary>
    public interface IVirtualMachineExtensionImageVersion :
        IWrapper<Microsoft.Azure.Management.Compute.Models.VirtualMachineExtensionImageInner>
    {
        /// <returns>the resource ID of the extension image version</returns>
        string Id { get; }

        /// <returns>the name of the virtual machine extension image version</returns>
        string Name { get; }

        /// <returns>the region in which virtual machine extension image version is available</returns>
        string RegionName { get; }

        /// <returns>the virtual machine extension image type this version belongs to</returns>
        IVirtualMachineExtensionImageType Type();

        /// <returns>virtual machine extension image this version represents</returns>
        IVirtualMachineExtensionImage Image();

    }
}