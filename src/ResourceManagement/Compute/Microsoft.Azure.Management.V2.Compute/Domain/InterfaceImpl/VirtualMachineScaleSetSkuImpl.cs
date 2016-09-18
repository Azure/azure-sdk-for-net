/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    public partial class VirtualMachineScaleSetSkuImpl 
    {
        /// <returns>the Sku type.</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetSkuTypes Microsoft.Azure.Management.V2.Compute.IVirtualMachineScaleSetSku.SkuType () {
            return this.SkuType() as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetSkuTypes;
        }

        /// <returns>available scaling information.</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetSkuCapacity Microsoft.Azure.Management.V2.Compute.IVirtualMachineScaleSetSku.Capacity
        {
            get
            {
                return this.Capacity as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetSkuCapacity;
            }
        }
        /// <returns>the type of resource the sku applies to.</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineScaleSetSku.ResourceType
        {
            get
            {
                return this.ResourceType as string;
            }
        }
    }
}