// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// Represents a virtual machine image SKU.
    /// </summary>
    public interface IVirtualMachineSku :
        IHasName
    {
        /// <return>The virtual machine offer name that this SKU belongs to.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineOffer Offer { get; }

        /// <return>Virtual machine images in the SKU.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImagesInSku Images { get; }

        /// <return>The publisher of this virtual machine image offer SKU.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher Publisher { get; }

        /// <return>The region where this virtual machine image offer SKU is available.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region Region { get; }
    }
}