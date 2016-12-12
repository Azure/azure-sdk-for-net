// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;

    internal partial class VirtualMachineOfferImpl
    {
        /// <return>The name of the resource.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name() as string;
            }
        }

        /// <return>Virtual machine image SKUs available in this offer.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSkus Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineOffer.Skus
        {
            get
            {
                return this.Skus() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSkus;
            }
        }

        /// <return>The publisher of this virtual machine image offer.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineOffer.Publisher
        {
            get
            {
                return this.Publisher() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher;
            }
        }

        /// <return>The region where this virtual machine image offer is available.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineOffer.Region
        {
            get
            {
                return this.Region() as Microsoft.Azure.Management.Resource.Fluent.Core.Region;
            }
        }
    }
}