// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// Represents a virtual machine image publisher.
    /// </summary>
    public interface IVirtualMachinePublisher  :
        IHasName
    {
        /// <summary>
        /// Gets the offers from this publisher.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineOffers Offers { get; }

        /// <summary>
        /// Gets the virtual machine image extensions from this publisher.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageTypes ExtensionTypes { get; }

        /// <summary>
        /// Gets the region where virtual machine images from this publisher are available.
        /// </summary>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region Region { get; }
    }
}