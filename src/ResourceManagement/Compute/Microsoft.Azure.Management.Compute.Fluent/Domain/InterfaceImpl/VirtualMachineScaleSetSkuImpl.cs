// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class VirtualMachineScaleSetSkuImpl 
    {
        /// <summary>
        /// Gets the SKU type.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetSkuTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetSku.SkuType
        {
            get
            {
                return this.SkuType() as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetSkuTypes;
            }
        }

        /// <summary>
        /// Gets available scaling information.
        /// </summary>
        Models.VirtualMachineScaleSetSkuCapacity Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetSku.Capacity
        {
            get
            {
                return this.Capacity() as Models.VirtualMachineScaleSetSkuCapacity;
            }
        }

        /// <summary>
        /// Gets the type of resource the SKU applies to.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetSku.ResourceType
        {
            get
            {
                return this.ResourceType();
            }
        }
    }
}