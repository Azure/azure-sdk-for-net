/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{


    /// <summary>
    /// A type representing virtual machine size available for a subscription in a region.
    /// </summary>
    public interface IVirtualMachineSize 
    {
        /// <returns>the VM size name</returns>
        string Name { get; }

        /// <returns>the Number of cores supported by a VM size</returns>
        int? NumberOfCores { get; }

        /// <returns>the OS disk size allowed by a VM size</returns>
        int? OsDiskSizeInMB { get; }

        /// <returns>resource disk size allowed by a VM size</returns>
        int? ResourceDiskSizeInMB { get; }

        /// <returns>the memory size supported by a VM size</returns>
        int? MemoryInMB { get; }

        /// <returns>the maximum number of data disks allowed by a VM size</returns>
        int? MaxDataDiskCount { get; }

    }
}