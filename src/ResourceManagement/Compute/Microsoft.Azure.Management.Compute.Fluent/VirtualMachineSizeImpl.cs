// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Compute.Fluent
{

    using Management.Compute.Fluent.Models;
    /// <summary>
    /// The implementation for VirtualMachineSize.
    /// </summary>
    internal partial class VirtualMachineSizeImpl  :
        IVirtualMachineSize
    {
        private VirtualMachineSize innerModel;

        internal  VirtualMachineSizeImpl (VirtualMachineSize innerModel)
        {
            this.innerModel = innerModel;
        }

        public string Name
        {
            get
            {
                return innerModel.Name;
            }
        }

        public int NumberOfCores
        {
            get
            {
                return innerModel.NumberOfCores.Value;
            }
        }

        public int OsDiskSizeInMB
        {
            get
            {
                return innerModel.OsDiskSizeInMB.Value;
            }
        }

        public int ResourceDiskSizeInMB
        {
            get
            {
                return innerModel.ResourceDiskSizeInMB.Value;
            }
        }

        public int MemoryInMB
        {
            get
            {
                return innerModel.MemoryInMB.Value;
            }
        }

        public int MaxDataDiskCount
        {
            get
            {
                return innerModel.MaxDataDiskCount.Value;
            }
        }
    }
}