// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models;

    /// <summary>
    /// Virtual machine encryption related operations.
    /// </summary>
    public interface IVirtualMachineEncryption 
    {
        /// <summary>
        /// Disable encryption for virtual machine disks.
        /// </summary>
        /// <param name="volumeType">Volume type to disable encryption.</param>
        /// <return>Observable that emits current volume decryption status.</return>
        Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> DisableAsync(DiskVolumeType volumeType, CancellationToken cancellationToken = default(CancellationToken));

        /// <return>Observable that emits current volume decryption status.</return>
        Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> GetMonitorAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enable encryption for virtual machine disks.
        /// </summary>
        /// <param name="keyVaultId">Resource id of the key vault to store the disk encryption key.</param>
        /// <param name="aadClientId">Client id of an AAD application which has permission to the key vault.</param>
        /// <param name="aadSecret">Client secret corresponding to the aadClientId.</param>
        /// <return>Current volume decryption status.</return>
        Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor Enable(string keyVaultId, string aadClientId, string aadSecret);

        /// <summary>
        /// Enable encryption for Windows virtual machine disks.
        /// </summary>
        /// <param name="encryptionSettings">Encryption settings for windows virtual machine.</param>
        /// <return>Current volume encryption status.</return>
        Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor Enable(WindowsVMDiskEncryptionConfiguration encryptionSettings);

        /// <summary>
        /// Enable encryption for Linux virtual machine disks.
        /// </summary>
        /// <param name="encryptionSettings">Encryption settings for windows virtual machine.</param>
        /// <return>Current volume encryption status.</return>
        Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor Enable(LinuxVMDiskEncryptionConfiguration encryptionSettings);

        /// <summary>
        /// Disable encryption for virtual machine disks.
        /// </summary>
        /// <param name="volumeType">Volume type to disable encryption.</param>
        /// <return>Current volume encryption status.</return>
        Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor Disable(DiskVolumeType volumeType);

        /// <summary>
        /// Enable encryption for virtual machine disks.
        /// </summary>
        /// <param name="keyVaultId">Resource id of the key vault to store the disk encryption key.</param>
        /// <param name="aadClientId">Client id of an AAD application which has permission to the key vault.</param>
        /// <param name="aadSecret">Client secret corresponding to the aadClientId.</param>
        /// <return>Observable that emits current volume encryption status.</return>
        Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> EnableAsync(string keyVaultId, string aadClientId, string aadSecret, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enable encryption for Windows virtual machine disks.
        /// </summary>
        /// <param name="encryptionSettings">Encryption settings for windows virtual machine.</param>
        /// <return>Observable that emits current volume encryption status.</return>
        Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> EnableAsync(WindowsVMDiskEncryptionConfiguration encryptionSettings, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enable encryption for Linux virtual machine disks.
        /// </summary>
        /// <param name="encryptionSettings">Encryption settings for windows virtual machine.</param>
        /// <return>Observable that emits current volume encryption status.</return>
        Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> EnableAsync(LinuxVMDiskEncryptionConfiguration encryptionSettings, CancellationToken cancellationToken = default(CancellationToken));

        /// <return>Current volume decryption status.</return>
        Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor GetMonitor();
    }
}