// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class VirtualMachineSizeImpl 
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the maximum number of data disks allowed by a VM size.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize.MaxDataDiskCount
        {
            get
            {
                return this.MaxDataDiskCount();
            }
        }

        /// <summary>
        /// Gets the number of cores supported by the VM size.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize.NumberOfCores
        {
            get
            {
                return this.NumberOfCores();
            }
        }

        /// <summary>
        /// Gets the OS disk size allowed by the VM size.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize.OSDiskSizeInMB
        {
            get
            {
                return this.OSDiskSizeInMB();
            }
        }

        /// <summary>
        /// Gets the resource disk size allowed by the VM size.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize.ResourceDiskSizeInMB
        {
            get
            {
                return this.ResourceDiskSizeInMB();
            }
        }

        /// <summary>
        /// Gets the memory size supported by the VM size.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize.MemoryInMB
        {
            get
            {
                return this.MemoryInMB();
            }
        }
    }
}