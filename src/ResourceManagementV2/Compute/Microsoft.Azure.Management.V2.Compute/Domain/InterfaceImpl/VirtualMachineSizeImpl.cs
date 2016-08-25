/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.Compute.Models;
    public partial class VirtualMachineSizeImpl 
    {
        /// <returns>the maximum number of data disks allowed by a VM size</returns>
        int? Microsoft.Azure.Management.V2.Compute.IVirtualMachineSize.MaxDataDiskCount
        {
            get
            {
                return this.MaxDataDiskCount;
            }
        }
        /// <returns>the Number of cores supported by a VM size</returns>
        int? Microsoft.Azure.Management.V2.Compute.IVirtualMachineSize.NumberOfCores
        {
            get
            {
                return this.NumberOfCores;
            }
        }
        /// <returns>the OS disk size allowed by a VM size</returns>
        int? Microsoft.Azure.Management.V2.Compute.IVirtualMachineSize.OsDiskSizeInMB
        {
            get
            {
                return this.OsDiskSizeInMB;
            }
        }
        /// <returns>resource disk size allowed by a VM size</returns>
        int? Microsoft.Azure.Management.V2.Compute.IVirtualMachineSize.ResourceDiskSizeInMB
        {
            get
            {
                return this.ResourceDiskSizeInMB;
            }
        }
        /// <returns>the VM size name</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineSize.Name
        {
            get
            {
                return this.Name as string;
            }
        }
        /// <returns>the memory size supported by a VM size</returns>
        int? Microsoft.Azure.Management.V2.Compute.IVirtualMachineSize.MemoryInMB
        {
            get
            {
                return this.MemoryInMB;
            }
        }
    }
}