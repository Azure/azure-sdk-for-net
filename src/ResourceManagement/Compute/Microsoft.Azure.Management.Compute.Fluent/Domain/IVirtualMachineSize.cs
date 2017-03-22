// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// A type representing virtual machine size available for a subscription in a region.
    /// </summary>
    public interface IVirtualMachineSize  :
        IHasName
    {
        /// <summary>
        /// Gets the OS disk size allowed by the VM size.
        /// </summary>
        int OsDiskSizeInMB { get; }

        /// <summary>
        /// Gets the resource disk size allowed by the VM size.
        /// </summary>
        int ResourceDiskSizeInMB { get; }

        /// <summary>
        /// Gets the maximum number of data disks allowed by a VM size.
        /// </summary>
        int MaxDataDiskCount { get; }

        /// <summary>
        /// Gets the memory size supported by the VM size.
        /// </summary>
        int MemoryInMB { get; }

        /// <summary>
        /// Gets the number of cores supported by the VM size.
        /// </summary>
        int NumberOfCores { get; }
    }
}