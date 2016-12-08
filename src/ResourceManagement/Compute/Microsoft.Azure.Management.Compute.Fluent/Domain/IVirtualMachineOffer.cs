// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Core;
    /// <summary>
    /// Represents a virtual machine image offer.
    /// </summary>
    public interface IVirtualMachineOffer : IHasName
    {
        /// <returns>the region where this virtual machine image offer is available</returns>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region Region { get; }

        /// <returns>the publisher of this virtual machine image offer</returns>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher Publisher { get; }

        /// <returns>virtual machine image SKUs available in this offer</returns>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSkus Skus { get; }

    }
}