/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    /// <summary>
    /// Represents a virtual machine image SKU.
    /// </summary>
    public interface IVirtualMachineSku 
    {
        /// <returns>the region where this virtual machine image offer SKU is available</returns>
        Region? Region { get; }

        /// <returns>the publisher of this virtual machine image offer SKU</returns>
        IVirtualMachinePublisher Publisher ();

        /// <returns>the virtual machine offer name that this SKU belongs to</returns>
        IVirtualMachineOffer Offer ();

        /// <returns>the commercial name of the virtual machine image (SKU)</returns>
        string Name { get; }

        /// <returns>virtual machine images in the sku</returns>
        IVirtualMachineImagesInSku Images ();

    }
}