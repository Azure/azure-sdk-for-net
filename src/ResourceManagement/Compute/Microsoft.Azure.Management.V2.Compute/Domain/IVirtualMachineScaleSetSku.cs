// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.Compute.Models;
    /// <summary>
    /// A type representing a SKU available for virtual machines in a scale set.
    /// </summary>
    public interface IVirtualMachineScaleSetSku
    {
        /// <returns>the type of resource the SKU applies to</returns>
        string ResourceType { get; }

        /// <returns>the SKU type</returns>
        VirtualMachineScaleSetSkuTypes SkuType();

        /// <returns>available scaling information</returns>
        VirtualMachineScaleSetSkuCapacity Capacity { get; }

    }
}