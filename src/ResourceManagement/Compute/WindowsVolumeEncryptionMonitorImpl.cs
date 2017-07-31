// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using System;
    using System.Collections.Generic;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// The implementation for DiskVolumeEncryptionStatus for Windows virtual machine.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uV2luZG93c1ZvbHVtZUVuY3J5cHRpb25Nb25pdG9ySW1wbA==
    internal partial class WindowsVolumeEncryptionMonitorImpl  :
        IDiskVolumeEncryptionMonitor
    {
        private string rgName;
        private string vmName;
        private IComputeManager computeManager;
        private VirtualMachineExtensionInner encryptionExtension;
        private VirtualMachineInner virtualMachine;
        ///GENMHASH:C82133AFFAADD3FE1A871F505A55CC6A:78CF6DCAD4B00CDC882F843E1E1F4B06
        private bool HasEncryptionDetails()
        {
            return virtualMachine != null && this.encryptionExtension != null;
        }

        ///GENMHASH:1BAF4F1B601F89251ABCFE6CC4867026:5FB785552E5FD74C28F297EA7778027A
        public OperatingSystemTypes OSType()
        {
            return OperatingSystemTypes.Windows;
        }

        ///GENMHASH:D1037603B1F11C451DD830F07021E503:EE1AB39DC25D0E54E8D460F4A5A910E3
        public EncryptionStatus OSDiskStatus()
        {
            if (!HasEncryptionDetails()) {
                return EncryptionStatus.NotEncrypted;
            }
            if (encryptionExtension.ProvisioningState == null) {
                return EncryptionStatus.NotEncrypted;
            }
            if (!encryptionExtension.ProvisioningState.Equals("Succeeded", System.StringComparison.OrdinalIgnoreCase)) {
                return EncryptionStatus.NotEncrypted;
            }
            if (this.virtualMachine.StorageProfile == null
                || virtualMachine.StorageProfile.OsDisk == null
                || virtualMachine.StorageProfile.OsDisk.EncryptionSettings == null) {
                return EncryptionStatus.NotEncrypted;
            }

            DiskEncryptionSettings encryptionSettings = virtualMachine
                .StorageProfile
                .OsDisk
                .EncryptionSettings;
            if (encryptionSettings.DiskEncryptionKey != null
                && encryptionSettings.DiskEncryptionKey.SecretUrl != null
                && encryptionSettings.Enabled.HasValue
                && encryptionSettings.Enabled == true) {
                return EncryptionStatus.Encrypted;
            }
            return EncryptionStatus.NotEncrypted;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:FF7924BFEF46CE7F250D6F5B1A727744
        public IDiskVolumeEncryptionMonitor Refresh()
        {
            return Extensions.Synchronize(() => RefreshAsync());
        }

        ///GENMHASH:5A2D79502EDA81E37A36694062AEDC65:061A846F0F7CA8B3F2DF8CA79A8D8B5A
        public async Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Refreshes the cached Windows virtual machine and installed encryption extension
            //
            var virtualMachine = await RetrieveVirtualMachineAsync(cancellationToken);
            this.virtualMachine = virtualMachine;
            if (virtualMachine.Resources != null)
            {
                foreach (var extension in virtualMachine.Resources)
                {
                    if (extension.Publisher.Equals("Microsoft.Azure.Security", StringComparison.OrdinalIgnoreCase)
                            && extension.VirtualMachineExtensionType.Equals("AzureDiskEncryption", StringComparison.OrdinalIgnoreCase))
                    {
                        this.encryptionExtension = extension;
                        break;
                    }
                }
            }
            return this;
        }

        /// <summary>
        /// Retrieve the virtual machine.
        /// If the virtual machine does not exists then an error observable will be returned.
        /// </summary>
        /// <return>The retrieved virtual machine.</return>
        ///GENMHASH:087C8FD03AB202F8A3AED65D0B562C6E:5BB394FB5CF6CB0BF678900B8778496D
        private async Task<Models.VirtualMachineInner> RetrieveVirtualMachineAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var virtualMachine = await this.computeManager
                .Inner
                .VirtualMachines
                .GetAsync(rgName, vmName, cancellationToken: cancellationToken);
            if (virtualMachine == null)
            {
                throw new Exception($"VM with name '{vmName}' not found (resource group '{rgName}')");
            }
            return virtualMachine;
        }

        ///GENMHASH:CFF730CD005B7D5386D59ADCF7C33D0C:C78106B3B84E85EA41CA6C096637C846
        public EncryptionStatus DataDiskStatus()
        {
            if (!HasEncryptionDetails()) {
                return EncryptionStatus.NotEncrypted;
            }
            if (encryptionExtension.ProvisioningState == null) {
                return EncryptionStatus.NotEncrypted;
            }
            if (!encryptionExtension.ProvisioningState.Equals("Succeeded", StringComparison.OrdinalIgnoreCase)) {
                return EncryptionStatus.NotEncrypted;
            }
            Dictionary<string, object> publicSettings = new Dictionary<string, object>();
            if (encryptionExtension.Settings != null) {
                publicSettings = (Dictionary<string, object>) encryptionExtension.Settings;
            }
            if (!publicSettings.ContainsKey("VolumeType")
                || string.IsNullOrEmpty((string) publicSettings["VolumeType"])
                || ((string) publicSettings["VolumeType"]).Equals("All", StringComparison.OrdinalIgnoreCase)
                || ((string) publicSettings["VolumeType"]).Equals("Data", StringComparison.OrdinalIgnoreCase)) {
                if (publicSettings.ContainsKey("EncryptionOperation")) {
                    string encryptionOperation = (string)publicSettings["EncryptionOperation"];
                    if (encryptionOperation != null && encryptionOperation.Equals("EnableEncryption", StringComparison.OrdinalIgnoreCase)) {
                        return EncryptionStatus.Encrypted;
                    }
                }
                return EncryptionStatus.NotEncrypted;
            }
            return EncryptionStatus.Unknown;
        }

        /// <summary>
        /// Creates WindowsVolumeEncryptionMonitorImpl.
        /// </summary>
        /// <param name="virtualMachineId">Resource id of Windows virtual machine to retrieve encryption status from.</param>
        /// <param name="computeManager">Compute manager.</param>
        ///GENMHASH:F0AB482101B80764DF92472E6DF90604:0C2BFB2332C823A9307222D73EFBAF83
        internal  WindowsVolumeEncryptionMonitorImpl(string virtualMachineId, IComputeManager computeManager)
        {
            this.rgName = ResourceUtils.GroupFromResourceId(virtualMachineId);
            this.vmName = ResourceUtils.NameFromResourceId(virtualMachineId);
            this.computeManager = computeManager;

        }

        ///GENMHASH:6BC2D312A9C6A52A192D8C5304AB76C7:12EE45D4547C7C1908554B9C49CAFAF3
        public string ProgressMessage()
        {
            if (!HasEncryptionDetails()) {
                return null;
            }
            return $"OSDisk: {OSDiskStatus()} DataDisk: {DataDiskStatus()}";
        }
    }
}