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
        /// <summary>
        /// Gets the SKU type.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetSkuTypes SkuType { get; }

        /// <summary>
        /// Gets available scaling information.
        /// </summary>
        Models.VirtualMachineScaleSetSkuCapacity Capacity { get; }

        /// <summary>
        /// Gets the type of resource the SKU applies to.
        /// </summary>
        string ResourceType { get; }
    }
}