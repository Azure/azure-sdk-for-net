// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Helper type to enable or disable virtual machine disk (OS, Data) encryption.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVFbmNyeXB0aW9uSGVscGVy
    internal partial class VirtualMachineEncryptionHelper  :
        object
    {
        private string encryptionExtensionPublisher = "Microsoft.Azure.Security";
        private OperatingSystemTypes osType;
        private IVirtualMachine virtualMachine;
        private readonly string ERROR_ENCRYPTION_EXTENSION_NOT_FOUND = "Expected encryption extension not found in the VM";
        private readonly string ERROR_NON_SUCCESS_PROVISIONING_STATE = "Extension needed for disk encryption was not provisioned correctly, found ProvisioningState as '%s'";
        private readonly string ERROR_EXPECTED_KEY_VAULT_URL_NOT_FOUND = "Could not found URL pointing to the secret for disk encryption";
        private readonly string ERROR_EXPECTED_ENCRYPTION_EXTENSION_STATUS_NOT_FOUND = "Encryption extension with successful status not found in the VM";
        private readonly string ERROR_ENCRYPTION_EXTENSION_STATUS_IS_EMPTY = "Encryption extension status is empty";
        private readonly string ERROR_ON_LINUX_DECRYPTING_NON_DATA_DISK_IS_NOT_SUPPORTED = "Only data disk is supported to disable encryption on Linux VM";
        private readonly string ERROR_ON_LINUX_DATA_DISK_DECRYPT_NOT_ALLOWED_IF_OS_DISK_IS_ENCRYPTED = "On Linux VM disabling data disk encryption is allowed only if OS disk is not encrypted";
        /// <summary>
        /// Creates VirtualMachineEncryptionHelper.
        /// </summary>
        /// <param name="virtualMachine">The virtual machine to enable or disable encryption.</param>
        ///GENMHASH:FC0CE97F5CDB23A526AC5FBD778B25E4:B371E9156A68585E5C6F1DA9109A9E4F
        internal VirtualMachineEncryptionHelper(IVirtualMachine virtualMachine)
        {
            this.virtualMachine = virtualMachine;
            this.osType = this.virtualMachine.OsType;
        }

        /// <summary>
        /// Retrieves encryption extension installed in the virtual machine, if the extension is
        /// not installed then return an empty observable.
        /// </summary>
        /// <return>An observable that emits the encryption extension installed in the virtual machine.</return>
        ///GENMHASH:9E0CF934F182F50D2FE7A72E02617F94:324B026FB14C16BEDA7B060212E59DE0
        private async Task<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension> GetEncryptionExtensionInstalledInVMAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var extensions = await virtualMachine.GetExtensionsAsync(cancellationToken);
            IVirtualMachineExtension encryptionExtension = extensions
                .FirstOrDefault(e => e.PublisherName.Equals(encryptionExtensionPublisher, StringComparison.OrdinalIgnoreCase)
                                        && e.TypeName.Equals(EncryptionExtensionType(), StringComparison.OrdinalIgnoreCase));
            if (encryptionExtension == null)
            {
                return await Task.FromResult<IVirtualMachineExtension>(null);
            }
            return encryptionExtension;
        }

        /// <summary>
        /// Prepare encryption extension using provided configuration and install it in the virtual machine.
        /// </summary>
        /// <param name="encryptConfig">The volume encryption configuration.</param>
        /// <return>An observable that emits updated virtual machine.</return>
        ///GENMHASH:90F5E95CF3EB9C10D9E436E206241DB8:709FA1AD6AFC4D8E0EEEB4F58D788AFA
        private async Task<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine> InstallEncryptionExtensionAsync(EnableDisableEncryptConfig encryptConfig, CancellationToken cancellationToken = default(CancellationToken))
        {
            string extensionName = EncryptionExtensionType();
            return await virtualMachine.Update()
                .DefineNewExtension(extensionName)
                    .WithPublisher(encryptionExtensionPublisher)
                    .WithType(EncryptionExtensionType())
                    .WithVersion(EncryptionExtensionVersion())
                    .WithPublicSettings(encryptConfig.ExtensionPublicSettings())
                    .WithProtectedSettings(encryptConfig.ExtensionProtectedSettings())
                    .WithMinorVersionAutoUpgrade()
                    .Attach()
                .ApplyAsync(cancellationToken);
        }

        /// <summary>
        /// Gets status object that describes the current status of the volume encryption or decryption process.
        /// </summary>
        /// <param name="virtualMachine">The virtual machine on which encryption or decryption is running.</param>
        /// <return>An observable that emits current encrypt or decrypt status.</return>
        ///GENMHASH:320925F5DE599EF676589095F72B25CB:2FDB3461FF786FBAE2C4F7E37E373582
        private async Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> GetDiskVolumeEncryptDecryptStatusAsync(IVirtualMachine virtualMachine, CancellationToken cancellationToken = default(CancellationToken))
        {
            IDiskVolumeEncryptionMonitor monitor = null;
            if (osType == OperatingSystemTypes.Linux) {
                monitor = new LinuxDiskVolumeEncryptionMonitorImpl(virtualMachine.Id, virtualMachine.Manager);
            } else {
                monitor = new WindowsVolumeEncryptionMonitorImpl(virtualMachine.Id, virtualMachine.Manager);
            }
            return await monitor.RefreshAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves the encryption extension status from the extension instance view.
        /// An error observable will be returned if
        /// 1. extension is not installed
        /// 2. extension is not provisioned successfully
        /// 2. extension status could be retrieved (either not found or empty).
        /// </summary>
        /// <param name="statusEmptyErrorMessage">The error message to emit if unable to locate the status.</param>
        /// <return>An observable that emits status message.</return>
        ///GENMHASH:5D5D4450A8A3676D4AB254F68D0D6E6F:FD676570747D9407B4E5BA65CEA5012A
        private async Task<string> RetrieveEncryptionExtensionStatusStringAsync(string statusEmptyErrorMessage, CancellationToken cancellationToken = default(CancellationToken))
        {
            IVirtualMachineExtension encryptionExtension = await GetEncryptionExtensionInstalledInVMAsync(cancellationToken);
            if (encryptionExtension == null)
            {
                throw new Exception(ERROR_ENCRYPTION_EXTENSION_NOT_FOUND);
            }
            if (!encryptionExtension.ProvisioningState.Equals("Succeeded", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(string.Format(ERROR_NON_SUCCESS_PROVISIONING_STATE, encryptionExtension.ProvisioningState));
            }
            VirtualMachineExtensionInstanceView instanceView = await encryptionExtension.GetInstanceViewAsync(cancellationToken);
            if (instanceView == null
                || instanceView.Statuses == null
                || instanceView.Statuses.Count == 0) {
                throw new Exception(ERROR_EXPECTED_ENCRYPTION_EXTENSION_STATUS_NOT_FOUND);
            }
            string extensionStatus = instanceView.Statuses[0].Message;
            if (string.IsNullOrEmpty(extensionStatus))
            {
                throw new Exception(statusEmptyErrorMessage);
            }
            return extensionStatus;
        }

        /// <summary>
        /// Updates the virtual machine's OS Disk model with the encryption specific details so that platform can
        /// use it while booting the virtual machine.
        /// </summary>
        /// <param name="encryptConfig">The configuration specific to enabling the encryption.</param>
        /// <param name="encryptionSecretKeyVaultUrl">The keyVault URL pointing to secret holding disk encryption key.</param>
        /// <return>An observable that emits updated virtual machine.</return>
        ///GENMHASH:67C0461B156AC4E3B99954E3C1D2CBC6:FD88377F886FF359056146DABA972399
        private async Task<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine> UpdateVMStorageProfileAsync(EnableDisableEncryptConfig encryptConfig, string encryptionSecretKeyVaultUrl, CancellationToken cancellationToken = default(CancellationToken))
        {
            var diskEncryptionSettings = encryptConfig.StorageProfileEncryptionSettings();
            diskEncryptionSettings.DiskEncryptionKey.SecretUrl = encryptionSecretKeyVaultUrl;
            return await virtualMachine.Update()
                .WithOsDiskEncryptionSettings(diskEncryptionSettings)
                .ApplyAsync(cancellationToken);
        }

        /// <summary>
        /// Updates the virtual machine's OS Disk model with the encryption specific details.
        /// </summary>
        /// <param name="encryptConfig">The configuration specific to disabling the encryption.</param>
        /// <return>An observable that emits updated virtual machine.</return>
        ///GENMHASH:9E912268A5CDF429573A7112EC718690:63BF821D222D03E59BCD43264C3339D8
        private async Task<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine> UpdateVMStorageProfileAsync(EnableDisableEncryptConfig encryptConfig, CancellationToken cancellationToken = default(CancellationToken))
        {
            DiskEncryptionSettings diskEncryptionSettings = encryptConfig.StorageProfileEncryptionSettings();
            return await virtualMachine.Update()
                .WithOsDiskEncryptionSettings(diskEncryptionSettings)
                .ApplyAsync(cancellationToken);
        }

        /// <return>OS specific encryption extension version.</return>
        ///GENMHASH:C6B6A6BE7125F3222921978BAAAD158C:DA7BCCD8F3EBB8DF30FE3B09A51993F0
        private string EncryptionExtensionVersion()
        {
            if (this.osType == OperatingSystemTypes.Linux) {
                return "0.1";
            } else {
                return "1.1";
            }
        }

        /// <return>OS specific encryption extension type.</return>
        ///GENMHASH:EB5E4873902883B7A5D561248699E59F:0697EDE3B59F3C8FC56609ECBD880CD3
        private string EncryptionExtensionType()
        {
            if (this.osType == OperatingSystemTypes.Linux) {
                return "AzureDiskEncryptionForLinux";
            } else {
                return "AzureDiskEncryption";
            }
        }

        /// <summary>
        /// Enables encryption.
        /// </summary>
        /// <param name="encryptionSettings">The settings to be used for encryption extension.</param>
        /// <param name="">The Windows or Linux encryption settings.</param>
        /// <return>An observable that emits the encryption status.</return>
        ///GENMHASH:FB7DBA27A41CC76685F21AB0A9729C82:D88D73A86520940C4EA57E9CEEA1516F
        internal async Task<IDiskVolumeEncryptionMonitor> EnableEncryptionAsync<T>(VirtualMachineEncryptionConfiguration<T> encryptionSettings, 
            CancellationToken cancellationToken = default(CancellationToken)) where T : VirtualMachineEncryptionConfiguration<T>
        {
            var encryptConfig = new EnableEncryptConfig<T>(encryptionSettings);
            // Update the encryption extension if already installed
            //
            IVirtualMachine virtualMachine = await UpdateEncryptionExtensionAsync(encryptConfig, cancellationToken);
            if (virtualMachine == null)
            {
                // If encryption extension is not installed then install it
                //
                virtualMachine = await InstallEncryptionExtensionAsync(encryptConfig, cancellationToken);
            }
            // Retrieve the encryption key URL after extension install or update
            //
            string keyVaultSecretUrl = await RetrieveEncryptionExtensionStatusStringAsync(ERROR_EXPECTED_KEY_VAULT_URL_NOT_FOUND, cancellationToken);
            // Update the VM's OS Disk (in storage profile) with the encryption metadata
            //
            virtualMachine = await UpdateVMStorageProfileAsync(encryptConfig, keyVaultSecretUrl, cancellationToken);
            // Gets the encryption status
            //
            return await GetDiskVolumeEncryptDecryptStatusAsync(virtualMachine, cancellationToken);
        }

        /// <summary>
        /// Updates the encryption extension in the virtual machine using provided configuration.
        /// If extension is not installed then this method return null else the updated vm.
        /// </summary>
        /// <param name="encryptConfig">The volume encryption configuration.</param>
        /// <return>Tasks that emits updated virtual machine.</return>
        ///GENMHASH:99CCEB2CE75C64E72E8D4CB8CFDA73B5:B2EAD454D0D489C6F6AC659E4EB949F0
        private async Task<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine> UpdateEncryptionExtensionAsync(EnableDisableEncryptConfig encryptConfig, CancellationToken cancellationToken = default(CancellationToken))
        {
            IVirtualMachineExtension extension = await GetEncryptionExtensionInstalledInVMAsync(cancellationToken);
            if (extension == null)
            {
                return await Task.FromResult<IVirtualMachine>(null);
            }
            return await virtualMachine.Update()
                .UpdateExtension(extension.Name)
                    .WithPublicSettings(encryptConfig.ExtensionPublicSettings())
                    .WithProtectedSettings(encryptConfig.ExtensionProtectedSettings())
                    .Parent()
                .ApplyAsync(cancellationToken);
        }

        /// <summary>
        /// Checks the given volume type in the virtual machine can be decrypted.
        /// </summary>
        /// <param name="volumeType">The volume type to decrypt.</param>
        /// <return>Observable that emit true if no validation error otherwise error observable.</return>
        ///GENMHASH:88D2478D6B927119AD5935A29B7D7C60:D8EC0364E38FD84A3DD1F18E9AF6198A
        private async Task<bool> ValidateBeforeDecryptAsync(DiskVolumeType volumeType, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (osType == OperatingSystemTypes.Linux)
            {
                if (volumeType != DiskVolumeType.Data)
                {
                    throw new Exception(ERROR_ON_LINUX_DECRYPTING_NON_DATA_DISK_IS_NOT_SUPPORTED);
                }
                var monitor = await GetDiskVolumeEncryptDecryptStatusAsync(virtualMachine, cancellationToken);
                if (monitor.OsDiskStatus.Equals(EncryptionStatus.Encrypted))
                {
                    throw new Exception(ERROR_ON_LINUX_DATA_DISK_DECRYPT_NOT_ALLOWED_IF_OS_DISK_IS_ENCRYPTED);
                }
            }
                return true;
        }

        /// <summary>
        /// Disables encryption on the given disk volume.
        /// </summary>
        /// <param name="volumeType">The disk volume.</param>
        /// <return>An observable that emits the decryption status.</return>
        ///GENMHASH:B980B0A762D67885E3B127392FD42890:A65E5C07D8DA37A2AB5EC199276933B9
        internal async Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> DisableEncryptionAsync(DiskVolumeType volumeType, CancellationToken cancellationToken = default(CancellationToken))
        {
            EnableDisableEncryptConfig encryptConfig = new DisableEncryptConfig(volumeType);
            await ValidateBeforeDecryptAsync(volumeType, cancellationToken);
            // Update the encryption extension if already installed
            //
            IVirtualMachine virtualMachine = await UpdateEncryptionExtensionAsync(encryptConfig, cancellationToken);
            if (virtualMachine == null)
            {
                // If encryption extension is not then install it
                //
                virtualMachine = await InstallEncryptionExtensionAsync(encryptConfig, cancellationToken);
            }
            // Validate and retrieve the encryption extension status
            //
            string status = await RetrieveEncryptionExtensionStatusStringAsync(ERROR_ENCRYPTION_EXTENSION_STATUS_IS_EMPTY, cancellationToken);
            // Update the VM's OS profile by marking encryption disabled
            //
            virtualMachine = await UpdateVMStorageProfileAsync(encryptConfig, cancellationToken);
            // Gets the encryption status
            //
            return await GetDiskVolumeEncryptDecryptStatusAsync(virtualMachine, cancellationToken);
        }
    }

    /// <summary>
    /// Base type representing configuration for enabling and disabling disk encryption.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVFbmNyeXB0aW9uSGVscGVyLkVuYWJsZURpc2FibGVFbmNyeXB0Q29uZmln
    internal abstract partial class EnableDisableEncryptConfig
    {
        /// <return>Encryption specific settings to be set on virtual machine storage profile.</return>
        ///GENMHASH:861A97732A551A94F695C3B49DFAB96C:27E486AB74A10242FF421C0798DDC450
        public abstract DiskEncryptionSettings StorageProfileEncryptionSettings();

        /// <return>Encryption extension public settings.</return>
        ///GENMHASH:112DFE7CB9D7594A6C865E2D6CC357DD:27E486AB74A10242FF421C0798DDC450
        public abstract IDictionary<string, object> ExtensionPublicSettings();

        /// <return>Encryption extension protected settings.</return>
        ///GENMHASH:42BADBBDF9B8511E182143831C7F0FF6:27E486AB74A10242FF421C0798DDC450
        public abstract IDictionary<string, object> ExtensionProtectedSettings();
    }

    /// <summary>
    /// Base type representing configuration for enabling disk encryption.
    /// </summary>
    /// <param><T>.</param>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVFbmNyeXB0aW9uSGVscGVyLkVuYWJsZUVuY3J5cHRDb25maWc=
    internal partial class EnableEncryptConfig<T> :
        EnableDisableEncryptConfig
        where T : VirtualMachineEncryptionConfiguration<T>
    {
        private VirtualMachineEncryptionConfiguration<T> settings;

        ///GENMHASH:A4680AAD3C732AD8C23180D4695F0002:2D5ABDE502752AC4098DD0B501F665E5
        public EnableEncryptConfig(VirtualMachineEncryptionConfiguration<T> settings)
        {
            this.settings = settings;
        }

        ///GENMHASH:861A97732A551A94F695C3B49DFAB96C:E348102753EC23A2170268E43AF0844B
        public override DiskEncryptionSettings StorageProfileEncryptionSettings()
        {
            KeyVaultKeyReference keyEncryptionKey = null;
            if (settings.KeyEncryptionKeyURL() != null) {
                keyEncryptionKey = new KeyVaultKeyReference()
                {
                    KeyUrl = settings.KeyEncryptionKeyURL()
                };
                if (settings.KeyEncryptionKeyVaultId() != null) {
                    keyEncryptionKey.SourceVault = new ResourceManager.Fluent.SubResource()
                    {
                        Id = settings.KeyEncryptionKeyVaultId()
                    };
                }
            }
            DiskEncryptionSettings diskEncryptionSettings = new DiskEncryptionSettings()
            {
                Enabled = true,
                KeyEncryptionKey = keyEncryptionKey,
                DiskEncryptionKey = new KeyVaultSecretReference()
                {
                    SourceVault = new ResourceManager.Fluent.SubResource()
                    {
                        Id = settings.KeyVaultId()
                    }
                }
            };
            return diskEncryptionSettings;
        }

        ///GENMHASH:112DFE7CB9D7594A6C865E2D6CC357DD:A73CB70ECA05F57606DC4D8C914F8EB6
        public override IDictionary<string, object> ExtensionPublicSettings()
        {
            var publicSettings = new Dictionary<string, object>();
            publicSettings.Add("EncryptionOperation", "EnableEncryption");
            publicSettings.Add("AADClientID", settings.AadClientId());
            publicSettings.Add("KeyEncryptionAlgorithm", settings.VolumeEncryptionKeyEncryptAlgorithm());
            publicSettings.Add("KeyVaultURL", settings.KeyVaultUrl());
            publicSettings.Add("VolumeType", settings.VolumeType().ToString());
            publicSettings.Add("SequenceVersion", Guid.NewGuid().ToString());
            if (settings.KeyEncryptionKeyURL() != null) {
                publicSettings.Add("KeyEncryptionKeyURL", settings.KeyEncryptionKeyURL());
            }
            return publicSettings;
        }

        ///GENMHASH:42BADBBDF9B8511E182143831C7F0FF6:310634F314DEDED02B268CD45ABDDF80
        public override IDictionary<string, object> ExtensionProtectedSettings()
        {
            var protectedSettings = new Dictionary<string, object>();
            protectedSettings.Add("AADClientSecret", settings.AadSecret());
            if (settings.OsType() == OperatingSystemTypes.Linux
                && settings.LinuxPassPhrase() != null) {
                protectedSettings.Add("Passphrase", settings.LinuxPassPhrase());
            }
            return protectedSettings;
        }
    }

    /// <summary>
    /// Base type representing configuration for disabling disk encryption.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVFbmNyeXB0aW9uSGVscGVyLkRpc2FibGVFbmNyeXB0Q29uZmln
    internal partial class DisableEncryptConfig :
        EnableDisableEncryptConfig
    {
        private DiskVolumeType volumeType;

        ///GENMHASH:ED81FD69658AB4C787751DF16402585E:43501F666AB8B6252C9423192FE5CC88
        internal DisableEncryptConfig(DiskVolumeType volumeType)
        {
            this.volumeType = volumeType;
        }

        ///GENMHASH:861A97732A551A94F695C3B49DFAB96C:8745D610DD6AEA078F21FC3C57C74909
        public override DiskEncryptionSettings StorageProfileEncryptionSettings()
        {
            return new DiskEncryptionSettings()
            {
                Enabled = false
            };
        }

        ///GENMHASH:112DFE7CB9D7594A6C865E2D6CC357DD:9C5C71076B1A45D64B463082FDD67FF0
        public override IDictionary<string, object> ExtensionPublicSettings()
        {
            Dictionary<string, object> publicSettings = new Dictionary<string, object>();
            publicSettings.Add("EncryptionOperation", "DisableEncryption");
            publicSettings.Add("SequenceVersion", Guid.NewGuid().ToString());
            publicSettings.Add("VolumeType", this.volumeType);
            return publicSettings;
        }

        ///GENMHASH:42BADBBDF9B8511E182143831C7F0FF6:91C3605EF0B602A2AC8FE63B07EDB661
        public override IDictionary<string, object> ExtensionProtectedSettings()
        {
            return new Dictionary<string, object>();
        }
    }
}