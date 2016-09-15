/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.Compute.Models;
    public partial class VirtualMachineOfferImpl 
    {
        /// <returns>the name of the virtual machine image offer</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineOffer.Name
        {
            get
            {
                return this.Name as string;
            }
        }
        /// <returns>Virtual machine image SKUs available in this offer.</returns>
        Microsoft.Azure.Management.V2.Compute.IVirtualMachineSkus Microsoft.Azure.Management.V2.Compute.IVirtualMachineOffer.Skus () {
            return this.Skus() as Microsoft.Azure.Management.V2.Compute.IVirtualMachineSkus;
        }

        /// <returns>the publisher of this virtual machine image offer</returns>
        Microsoft.Azure.Management.V2.Compute.IVirtualMachinePublisher Microsoft.Azure.Management.V2.Compute.IVirtualMachineOffer.Publisher () {
            return this.Publisher() as Microsoft.Azure.Management.V2.Compute.IVirtualMachinePublisher;
        }

        /// <returns>the region where this virtual machine image offer is available</returns>
        Microsoft.Azure.Management.V2.Resource.Core.Region? Microsoft.Azure.Management.V2.Compute.IVirtualMachineOffer.Region
        {
            get
            {
                return this.Region;
            }
        }
    }
}