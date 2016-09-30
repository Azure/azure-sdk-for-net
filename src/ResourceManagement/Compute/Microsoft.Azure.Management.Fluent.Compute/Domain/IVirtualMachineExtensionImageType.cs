// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Compute
{

    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine extension image type.
    /// </summary>
    public interface IVirtualMachineExtensionImageType  :
        IWrapper<Microsoft.Azure.Management.Compute.Models.VirtualMachineExtensionImageInner>
    {
        /// <returns>the resource ID of the virtual machine extension image type</returns>
        string Id { get; }

        /// <returns>the name of the virtual machine extension image type</returns>
        string Name { get; }

        /// <returns>the region in which virtual machine extension image type is available</returns>
        string RegionName { get; }

        /// <returns>the publisher of this virtual machine extension image type</returns>
        Microsoft.Azure.Management.Fluent.Compute.IVirtualMachinePublisher Publisher { get; }

        /// <returns>Virtual machine image extension versions available in this type</returns>
        Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineExtensionImageVersions Versions { get; }

    }
}