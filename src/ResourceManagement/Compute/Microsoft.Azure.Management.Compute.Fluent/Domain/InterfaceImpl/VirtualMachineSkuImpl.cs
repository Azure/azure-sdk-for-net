// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class VirtualMachineSkuImpl 
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
        /// Gets virtual machine images in the SKU.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImagesInSku Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSku.Images
        {
            get
            {
                return this.Images() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImagesInSku;
            }
        }

        /// <summary>
        /// Gets the publisher of this virtual machine image offer SKU.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSku.Publisher
        {
            get
            {
                return this.Publisher() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher;
            }
        }

        /// <summary>
        /// Gets the virtual machine offer name that this SKU belongs to.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineOffer Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSku.Offer
        {
            get
            {
                return this.Offer() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineOffer;
            }
        }

        /// <summary>
        /// Gets the region where this virtual machine image offer SKU is available.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSku.Region
        {
            get
            {
                return this.Region() as Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region;
            }
        }
    }
}