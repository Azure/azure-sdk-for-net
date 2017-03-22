// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine extension image type.
    /// </summary>
    public interface IVirtualMachineExtensionImageType  :
        IHasInner<Models.VirtualMachineExtensionImageInner>,
        IHasName
    {
        /// <summary>
        /// Gets Virtual machine image extension versions available in this type.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageVersions Versions { get; }

        /// <summary>
        /// Gets the region in which virtual machine extension image type is available.
        /// </summary>
        string RegionName { get; }

        /// <summary>
        /// Gets the publisher of this virtual machine extension image type.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher Publisher { get; }

        /// <summary>
        /// Gets the resource ID of the virtual machine extension image type.
        /// </summary>
        string Id { get; }
    }
}