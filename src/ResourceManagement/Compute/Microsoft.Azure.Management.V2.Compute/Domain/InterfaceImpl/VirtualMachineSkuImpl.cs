/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    public partial class VirtualMachineSkuImpl 
    {
        /// <returns>virtual machine images in the sku</returns>
        Microsoft.Azure.Management.V2.Compute.IVirtualMachineImagesInSku Microsoft.Azure.Management.V2.Compute.IVirtualMachineSku.Images () {
            return this.Images() as Microsoft.Azure.Management.V2.Compute.IVirtualMachineImagesInSku;
        }

        /// <returns>the commercial name of the virtual machine image (SKU)</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineSku.Name
        {
            get
            {
                return this.Name as string;
            }
        }
        /// <returns>the virtual machine offer name that this SKU belongs to</returns>
        Microsoft.Azure.Management.V2.Compute.IVirtualMachineOffer Microsoft.Azure.Management.V2.Compute.IVirtualMachineSku.Offer () {
            return this.Offer() as Microsoft.Azure.Management.V2.Compute.IVirtualMachineOffer;
        }

        /// <returns>the publisher of this virtual machine image offer SKU</returns>
        Microsoft.Azure.Management.V2.Compute.IVirtualMachinePublisher Microsoft.Azure.Management.V2.Compute.IVirtualMachineSku.Publisher () {
            return this.Publisher() as Microsoft.Azure.Management.V2.Compute.IVirtualMachinePublisher;
        }

        /// <returns>the region where this virtual machine image offer SKU is available</returns>
        Microsoft.Azure.Management.V2.Resource.Core.Region? Microsoft.Azure.Management.V2.Compute.IVirtualMachineSku.Region
        {
            get
            {
                return this.Region;
            }
        }
    }
}