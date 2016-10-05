// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{

    using Microsoft.Azure.Management.Compute.Fluent.Models;
    /// <summary>
    /// A type representing a SKU available for virtual machines in a scale set.
    /// </summary>
    public interface IVirtualMachineScaleSetSku 
    {
        /// <returns>the type of resource the SKU applies to</returns>
        string ResourceType { get; }

        /// <returns>the SKU type</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetSkuTypes SkuType { get; }

        /// <returns>available scaling information</returns>
        Microsoft.Azure.Management.Compute.Fluent.Models.VirtualMachineScaleSetSkuCapacity Capacity { get; }

    }
}