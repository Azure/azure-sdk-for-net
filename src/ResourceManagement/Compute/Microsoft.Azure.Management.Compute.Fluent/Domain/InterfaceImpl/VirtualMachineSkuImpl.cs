// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;

    internal partial class VirtualMachineSkuImpl
    {
        /// <return>The name of the resource.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name() as string;
            }
        }

        /// <return>Virtual machine images in the SKU.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImagesInSku Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSku.Images
        {
            get
            {
                return this.Images() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImagesInSku;
            }
        }

        /// <return>The publisher of this virtual machine image offer SKU.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSku.Publisher
        {
            get
            {
                return this.Publisher() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher;
            }
        }

        /// <return>The virtual machine offer name that this SKU belongs to.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineOffer Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSku.Offer
        {
            get
            {
                return this.Offer() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineOffer;
            }
        }

        /// <return>The region where this virtual machine image offer SKU is available.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSku.Region
        {
            get
            {
                return this.Region() as Microsoft.Azure.Management.Resource.Fluent.Core.Region;
            }
        }
    }
}