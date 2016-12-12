// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    internal partial class VirtualMachineScaleSetSkuImpl
    {
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetSkuTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetSku.SkuType
        {
            get
            {
                return this.SkuType() as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetSkuTypes;
            }
        }

        Models.VirtualMachineScaleSetSkuCapacity Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetSku.Capacity
        {
            get
            {
                return this.Capacity() as Models.VirtualMachineScaleSetSkuCapacity;
            }
        }

        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetSku.ResourceType
        {
            get
            {
                return this.ResourceType();
            }
        }
    }
}