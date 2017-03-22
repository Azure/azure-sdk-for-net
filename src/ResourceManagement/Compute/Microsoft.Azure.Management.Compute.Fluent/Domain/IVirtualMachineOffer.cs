// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Represents a virtual machine image offer.
    /// </summary>
    public interface IVirtualMachineOffer  :
        IHasName
    {
        /// <summary>
        /// Gets virtual machine image SKUs available in this offer.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSkus Skus { get; }

        /// <summary>
        /// Gets the publisher of this virtual machine image offer.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher Publisher { get; }

        /// <summary>
        /// Gets the region where this virtual machine image offer is available.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Region { get; }
    }
}