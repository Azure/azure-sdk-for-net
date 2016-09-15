/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.Compute.Models;
    public partial class VirtualMachinePublisherImpl 
    {
        /// <returns>the name of the publisher</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachinePublisher.Name
        {
            get
            {
                return this.Name as string;
            }
        }
        /// <returns>the offers from this publisher</returns>
        Microsoft.Azure.Management.V2.Compute.IVirtualMachineOffers Microsoft.Azure.Management.V2.Compute.IVirtualMachinePublisher.Offers () {
            return this.Offers() as Microsoft.Azure.Management.V2.Compute.IVirtualMachineOffers;
        }

        /// <returns>the region where virtual machine images from this publisher is available</returns>
        Microsoft.Azure.Management.V2.Resource.Core.Region? Microsoft.Azure.Management.V2.Compute.IVirtualMachinePublisher.Region
        {
            get
            {
                return this.Region;
            }
        }
    }
}