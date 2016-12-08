// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;

    internal partial class VirtualMachineSizeImpl
    {
        /// <return>The name of the resource.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name() as string;
            }
        }

        /// <return>The number of cores supported by the VM size.</return>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize.NumberOfCores
        {
            get
            {
                return this.NumberOfCores();
            }
        }

        /// <return>The maximum number of data disks allowed by a VM size.</return>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize.MaxDataDiskCount
        {
            get
            {
                return this.MaxDataDiskCount();
            }
        }

        /// <return>The OS disk size allowed by the VM size.</return>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize.OsDiskSizeInMB
        {
            get
            {
                return this.OsDiskSizeInMB();
            }
        }

        /// <return>The resource disk size allowed by the VM size.</return>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize.ResourceDiskSizeInMB
        {
            get
            {
                return this.ResourceDiskSizeInMB();
            }
        }

        /// <return>The memory size supported by the VM size.</return>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize.MemoryInMB
        {
            get
            {
                return this.MemoryInMB();
            }
        }
    }
}