// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// Represents a virtual machine image offer.
    /// </summary>
    public interface IVirtualMachineOffer :
        IHasName
    {
        /// <return>Virtual machine image SKUs available in this offer.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSkus Skus { get; }

        /// <return>The publisher of this virtual machine image offer.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher Publisher { get; }

        /// <return>The region where this virtual machine image offer is available.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region Region { get; }
    }
}