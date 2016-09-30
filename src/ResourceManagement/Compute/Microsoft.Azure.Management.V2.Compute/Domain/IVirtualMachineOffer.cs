// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Compute
{

    using Microsoft.Azure.Management.Fluent.Resource.Core;
    /// <summary>
    /// Represents a virtual machine image offer.
    /// </summary>
    public interface IVirtualMachineOffer
    {
        /// <returns>the region where this virtual machine image offer is available</returns>
        Region? Region { get; }

        /// <returns>the publisher of this virtual machine image offer</returns>
        IVirtualMachinePublisher Publisher();

        /// <returns>the name of the virtual machine image offer</returns>
        string Name { get; }

        /// <returns>virtual machine image SKUs available in this offer</returns>
        IVirtualMachineSkus Skus();

    }
}