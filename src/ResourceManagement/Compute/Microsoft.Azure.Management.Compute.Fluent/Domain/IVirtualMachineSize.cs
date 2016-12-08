// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.Resource.Fluent.Core;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    /// <summary>
    /// A type representing virtual machine size available for a subscription in a region.
    /// </summary>
    public interface IVirtualMachineSize : IHasName
    {
        /// <returns>the number of cores supported by the VM size</returns>
        int NumberOfCores { get; }

        /// <returns>the OS disk size allowed by the VM size</returns>
        int OsDiskSizeInMB { get; }

        /// <returns>the resource disk size allowed by the VM size</returns>
        int ResourceDiskSizeInMB { get; }

        /// <returns>the memory size supported by the VM size</returns>
        int MemoryInMB { get; }

        /// <returns>the maximum number of data disks allowed by a VM size</returns>
        int MaxDataDiskCount { get; }
    }
}