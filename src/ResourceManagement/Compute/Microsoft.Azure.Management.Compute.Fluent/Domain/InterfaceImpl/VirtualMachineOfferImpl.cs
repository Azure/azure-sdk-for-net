// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class VirtualMachineOfferImpl 
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets virtual machine image SKUs available in this offer.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSkus Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineOffer.Skus
        {
            get
            {
                return this.Skus() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSkus;
            }
        }

        /// <summary>
        /// Gets the publisher of this virtual machine image offer.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineOffer.Publisher
        {
            get
            {
                return this.Publisher() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher;
            }
        }

        /// <summary>
        /// Gets the region where this virtual machine image offer is available.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineOffer.Region
        {
            get
            {
                return this.Region() as Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region;
            }
        }
    }
}