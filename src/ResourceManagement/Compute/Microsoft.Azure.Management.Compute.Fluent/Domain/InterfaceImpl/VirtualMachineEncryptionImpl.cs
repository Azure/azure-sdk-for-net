// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models;

    internal partial class VirtualMachineEncryptionImpl 
    {
        /// <summary>
        /// Enable encryption for virtual machine disks.
        /// </summary>
        /// <param name="keyVaultId">Resource id of the key vault to store the disk encryption key.</param>
        /// <param name="aadClientId">Client id of an AAD application which has permission to the key vault.</param>
        /// <param name="aadSecret">Client secret corresponding to the aadClientId.</param>
        /// <return>Observable that emits current volume encryption status.</return>
        async Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineEncryption.EnableAsync(string keyVaultId, string aadClientId, string aadSecret, CancellationToken cancellationToken)
        {
            return await this.EnableAsync(keyVaultId, aadClientId, aadSecret, cancellationToken) as Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor;
        }

        /// <summary>
        /// Enable encryption for Windows virtual machine disks.
        /// </summary>
        /// <param name="encryptionSettings">Encryption settings for windows virtual machine.</param>
        /// <return>Observable that emits current volume encryption status.</return>
        async Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineEncryption.EnableAsync(WindowsVMDiskEncryptionConfiguration encryptionSettings, CancellationToken cancellationToken)
        {
            return await this.EnableAsync(encryptionSettings, cancellationToken) as Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor;
        }

        /// <summary>
        /// Enable encryption for Linux virtual machine disks.
        /// </summary>
        /// <param name="encryptionSettings">Encryption settings for windows virtual machine.</param>
        /// <return>Observable that emits current volume encryption status.</return>
        async Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineEncryption.EnableAsync(LinuxVMDiskEncryptionConfiguration encryptionSettings, CancellationToken cancellationToken)
        {
            return await this.EnableAsync(encryptionSettings, cancellationToken) as Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor;
        }

        /// <summary>
        /// Disable encryption for virtual machine disks.
        /// </summary>
        /// <param name="volumeType">Volume type to disable encryption.</param>
        /// <return>Observable that emits current volume decryption status.</return>
        async Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineEncryption.DisableAsync(DiskVolumeType volumeType, CancellationToken cancellationToken)
        {
            return await this.DisableAsync(volumeType, cancellationToken) as Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor;
        }

        /// <return>Current volume decryption status.</return>
        Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineEncryption.GetMonitor()
        {
            return this.GetMonitor() as Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor;
        }

        /// <summary>
        /// Disable encryption for virtual machine disks.
        /// </summary>
        /// <param name="volumeType">Volume type to disable encryption.</param>
        /// <return>Current volume encryption status.</return>
        Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineEncryption.Disable(DiskVolumeType volumeType)
        {
            return this.Disable(volumeType) as Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor;
        }

        /// <summary>
        /// Enable encryption for virtual machine disks.
        /// </summary>
        /// <param name="keyVaultId">Resource id of the key vault to store the disk encryption key.</param>
        /// <param name="aadClientId">Client id of an AAD application which has permission to the key vault.</param>
        /// <param name="aadSecret">Client secret corresponding to the aadClientId.</param>
        /// <return>Current volume decryption status.</return>
        Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineEncryption.Enable(string keyVaultId, string aadClientId, string aadSecret)
        {
            return this.Enable(keyVaultId, aadClientId, aadSecret) as Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor;
        }

        /// <summary>
        /// Enable encryption for Windows virtual machine disks.
        /// </summary>
        /// <param name="encryptionSettings">Encryption settings for windows virtual machine.</param>
        /// <return>Current volume encryption status.</return>
        Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineEncryption.Enable(WindowsVMDiskEncryptionConfiguration encryptionSettings)
        {
            return this.Enable(encryptionSettings) as Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor;
        }

        /// <summary>
        /// Enable encryption for Linux virtual machine disks.
        /// </summary>
        /// <param name="encryptionSettings">Encryption settings for windows virtual machine.</param>
        /// <return>Current volume encryption status.</return>
        Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineEncryption.Enable(LinuxVMDiskEncryptionConfiguration encryptionSettings)
        {
            return this.Enable(encryptionSettings) as Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor;
        }

        /// <return>Observable that emits current volume decryption status.</return>
        async Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineEncryption.GetMonitorAsync(CancellationToken cancellationToken)
        {
            return await this.GetMonitorAsync(cancellationToken) as Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor;
        }
    }
}