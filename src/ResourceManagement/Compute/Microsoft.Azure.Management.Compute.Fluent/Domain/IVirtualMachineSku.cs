// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Core;
    /// <summary>
    /// Represents a virtual machine image SKU.
    /// </summary>
    public interface IVirtualMachineSku 
    {
        /// <returns>the region where this virtual machine image offer SKU is available</returns>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region Region { get; }

        /// <returns>the publisher of this virtual machine image offer SKU</returns>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher Publisher { get; }

        /// <returns>the virtual machine offer name that this SKU belongs to</returns>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineOffer Offer { get; }

        /// <returns>the commercial name of the virtual machine image (SKU)</returns>
        string Name { get; }

        /// <returns>virtual machine images in the SKU</returns>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImagesInSku Images { get; }

    }
}