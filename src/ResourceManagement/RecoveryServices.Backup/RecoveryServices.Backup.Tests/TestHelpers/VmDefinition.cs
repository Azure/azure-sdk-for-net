// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.Management.RecoveryServices.Backup.Tests
{
    public enum VmType
    {
        Classic,
        Compute,
    }

    public class VmDefinition
    {
        private readonly string vmName;
        private readonly string vmRg;
        private readonly VmType vmType;
        private readonly StorageAccountDefinition saDefinition;

        public VmDefinition(StorageAccountDefinition saDefinition)
        {
            this.vmName = TestSettings.Instance.VirtualMachineName;
            this.vmRg = TestSettings.Instance.VirtualMachineResourceGroupName;
            this.vmType = (VmType)Enum.Parse(typeof(VmType), TestSettings.Instance.VirtualMachineType);
            this.saDefinition = saDefinition;
        }

        public string VaultName
        {
            get { return vmName; }
        }

        public string VmRg
        {
            get { return vmRg; }
        }

        public string ContainerType
        {
            get { return vmType == VmType.Classic ? "iaasvmcontainer" : "iaasvmcontainerv2"; }
        }

        public string ContainerUniqueName
        {
            get { return string.Join(";", ContainerType, vmRg, vmName).ToLower(); }
        }

        public string ContainerName
        {
            get { return string.Join(";", "IaasVMContainer", ContainerUniqueName); }
        }

        public string ItemName
        {
            get { return string.Join(";", "VM", ContainerUniqueName); }
        }

        public StorageAccountDefinition RestoreStorageAccount
        {
            get { return saDefinition; }
        }
    }
}
