// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// Represents a virtual machine image SKU.
    /// </summary>
    public interface IVirtualMachineSku  :
        IHasName
    {
        /// <summary>
        /// Gets the virtual machine offer name that this SKU belongs to.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineOffer Offer { get; }

        /// <summary>
        /// Gets virtual machine images in the SKU.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImagesInSku Images { get; }

        /// <summary>
        /// Gets the publisher of this virtual machine image offer SKU.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher Publisher { get; }

        /// <summary>
        /// Gets the region where this virtual machine image offer SKU is available.
        /// </summary>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region Region { get; }
    }
}