// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// A type representing virtual machine size available for a subscription in a region.
    /// </summary>
    public interface IVirtualMachineSize :
        IHasName
    {
        /// <return>The OS disk size allowed by the VM size.</return>
        int OsDiskSizeInMB { get; }

        /// <return>The resource disk size allowed by the VM size.</return>
        int ResourceDiskSizeInMB { get; }

        /// <return>The maximum number of data disks allowed by a VM size.</return>
        int MaxDataDiskCount { get; }

        /// <return>The memory size supported by the VM size.</return>
        int MemoryInMB { get; }

        /// <return>The number of cores supported by the VM size.</return>
        int NumberOfCores { get; }
    }
}