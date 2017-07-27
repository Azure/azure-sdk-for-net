// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation of VirtualMachineEncryption.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVFbmNyeXB0aW9uSW1wbA==
    internal partial class VirtualMachineEncryptionImpl  :
        IVirtualMachineEncryption
    {
        private IVirtualMachine virtualMachine;
        private VirtualMachineEncryptionHelper virtualMachineEncryptionHelper;

        /// <summary>
        /// Creates VirtualMachineEncryptionImpl.
        /// </summary>
        /// <param name="virtualMachine">Virtual machine on which encryption related operations to be performed.</param>
        ///GENMHASH:43EFAF5441E2FA34B2E150376999BDEA:E9FB486FAD9C6ACEB65147D2FB93629F
        internal VirtualMachineEncryptionImpl(IVirtualMachine virtualMachine)
        {
            this.virtualMachine = virtualMachine;
            this.virtualMachineEncryptionHelper = new VirtualMachineEncryptionHelper(virtualMachine);
        }

        ///GENMHASH:60606BD7BB11968C7CA15EA85A54F23D:B21431AE460A6A3EA24A78638D0C7550
        public async Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> DisableAsync(DiskVolumeType volumeType, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await virtualMachineEncryptionHelper.DisableEncryptionAsync(volumeType, cancellationToken);
        }

        ///GENMHASH:F5C4065BE678A5CA018C264CAFF7901A:1C7F0F2F318A44EF8EF32F689B1ABFB4
        public async Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> GetMonitorAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IDiskVolumeEncryptionMonitor monitor = null;
            if (this.virtualMachine.OSType == OperatingSystemTypes.Linux) 
            {
                monitor = new LinuxDiskVolumeEncryptionMonitorImpl(virtualMachine.Id, virtualMachine.Manager);
            } 
            else 
            {
                monitor = new WindowsVolumeEncryptionMonitorImpl(virtualMachine.Id, virtualMachine.Manager);
            }
            return await monitor.RefreshAsync(cancellationToken);
        }

        ///GENMHASH:E41DD646C1F7D0458D57765D5AA21BD2:1A8F2584537929C0B602DAC8BEA90F0A
        public IDiskVolumeEncryptionMonitor Enable(string keyVaultId, string aadClientId, string aadSecret)
        {
            return Extensions.Synchronize(() => EnableAsync(keyVaultId, aadClientId, aadSecret));
        }

        ///GENMHASH:9D6DD1865EFFEE09432AB8D009095748:DC1C703A2CBB98499CF5B5775B6772AA
        public IDiskVolumeEncryptionMonitor Enable(WindowsVMDiskEncryptionConfiguration encryptionSettings)
        {
            return Extensions.Synchronize(() => EnableAsync(encryptionSettings));
        }

        ///GENMHASH:B90504B6DA9457416BB33BED5A9AA699:DC1C703A2CBB98499CF5B5775B6772AA
        public IDiskVolumeEncryptionMonitor Enable(LinuxVMDiskEncryptionConfiguration encryptionSettings)
        {
            return Extensions.Synchronize(() => EnableAsync(encryptionSettings));
        }

        ///GENMHASH:111E7E7282F1AF5C0D13E925EE81F501:FBB9648A0907B504CC31792F37E4880E
        public IDiskVolumeEncryptionMonitor Disable(DiskVolumeType volumeType)
        {
            return Extensions.Synchronize(() => DisableAsync(volumeType));
        }

        ///GENMHASH:63180E26DE0748370CBF1E688F400DA7:5A16D5F74FDBF1874F9D0EA507F123B3
        public async Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> EnableAsync(string keyVaultId, string aadClientId, string aadSecret, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.virtualMachine.OSType == OperatingSystemTypes.Linux) 
            {
                return await EnableAsync(new LinuxVMDiskEncryptionConfiguration(keyVaultId, aadClientId, aadSecret), cancellationToken);
            } 
            else 
            {
                return await EnableAsync(new WindowsVMDiskEncryptionConfiguration(keyVaultId, aadClientId, aadSecret), cancellationToken);
            }
        }

        ///GENMHASH:759A67E565795A68519740FF52F3799B:B98D2D73AF646442EF7A686C89600CAC
        public async Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> EnableAsync(WindowsVMDiskEncryptionConfiguration encryptionSettings, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await virtualMachineEncryptionHelper.EnableEncryptionAsync(encryptionSettings, cancellationToken);
        }

        ///GENMHASH:FF2DAE678B014FE543F645A74C2F3B6E:B98D2D73AF646442EF7A686C89600CAC
        public async Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> EnableAsync(LinuxVMDiskEncryptionConfiguration encryptionSettings, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await virtualMachineEncryptionHelper.EnableEncryptionAsync(encryptionSettings, cancellationToken);
        }

        ///GENMHASH:C6ABD3D452DBDFE8506CA443FC27C3BF:D1A986AAA62E86256065FD08F6B69054
        public IDiskVolumeEncryptionMonitor GetMonitor()
        {
            return Extensions.Synchronize(() => GetMonitorAsync());
        }
    }
}