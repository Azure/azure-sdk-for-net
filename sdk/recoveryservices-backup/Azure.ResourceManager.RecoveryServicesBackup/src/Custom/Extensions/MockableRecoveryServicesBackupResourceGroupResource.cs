// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.RecoveryServicesBackup.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.RecoveryServicesBackup.Mocking
{
    public partial class MockableRecoveryServicesBackupResourceGroupResource : ArmResource
    {
        /// <summary>
        /// Get the security PIN.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupSecurityPIN</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SecurityPINs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vaultName"> The name of the recovery services vault. </param>
        /// <param name="content"> security pin request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<TokenInformation> GetSecurityPin(string vaultName, SecurityPinContent content, CancellationToken cancellationToken)
        {
            return GetSecurityPin(vaultName, content, xMsAuthorizationAuxiliary: null, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get the security PIN.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupSecurityPIN</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SecurityPINs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vaultName"> The name of the recovery services vault. </param>
        /// <param name="content"> security pin request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<TokenInformation>> GetSecurityPinAsync(string vaultName, SecurityPinContent content, CancellationToken cancellationToken)
        {
            return GetSecurityPinAsync(vaultName, content, xMsAuthorizationAuxiliary: null, cancellationToken: cancellationToken);
        }

        /// <summary> Gets a collection of BackupResourceConfigResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of BackupResourceConfigResources and their operations over a BackupResourceConfigResource. </returns>
        [Obsolete("This collection class is retained for backward compatibility. The BackupResourceConfigResource is a singleton resource and should not have a collection class.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual BackupResourceConfigCollection GetBackupResourceConfigs()
        {
            throw new NotSupportedException("This method is not supported because BackupResourceConfigResource is a singleton resource and should not have a collection class.");
        }

        /// <summary>
        /// Fetches resource storage config.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/Subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupstorageconfig/vaultstorageconfig</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BackupResourceStorageConfigsNonCRR_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BackupResourceConfigResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vaultName"> The name of the recovery services vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BackupResourceConfigResource>> GetBackupResourceConfigAsync(string vaultName, CancellationToken cancellationToken = default)
        {
            var backupResourceConfigResource = GetBackupResourceConfig();
            return await backupResourceConfigResource.GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Fetches resource storage config.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/Subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupstorageconfig/vaultstorageconfig</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BackupResourceStorageConfigsNonCRR_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BackupResourceConfigResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vaultName"> The name of the recovery services vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BackupResourceConfigResource> GetBackupResourceConfig(string vaultName, CancellationToken cancellationToken = default)
        {
            var backupResourceConfigResource = GetBackupResourceConfig();
            return backupResourceConfigResource.Get(cancellationToken);
        }

        /// <summary> Gets a collection of BackupResourceEncryptionConfigExtendedResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of BackupResourceEncryptionConfigExtendedResources and their operations over a BackupResourceEncryptionConfigExtendedResource. </returns>
        [Obsolete("This collection class is retained for backward compatibility. The BackupResourceEncryptionConfigExtendedResource is a singleton resource and should not have a collection class.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual BackupResourceEncryptionConfigExtendedCollection GetBackupResourceEncryptionConfigExtendeds()
        {
            throw new NotSupportedException("This method is not supported because BackupResourceEncryptionConfigExtendedResource is a singleton resource and should not have a collection class.");
        }

        /// <summary>
        /// Fetches Vault Encryption config.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupEncryptionConfigs/backupResourceEncryptionConfig</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BackupResourceEncryptionConfigs_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BackupResourceEncryptionConfigExtendedResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vaultName"> The name of the recovery services vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BackupResourceEncryptionConfigExtendedResource>> GetBackupResourceEncryptionConfigExtendedAsync(string vaultName, CancellationToken cancellationToken = default)
        {
            var backupResourceEncryptionConfigExtendedResource = GetBackupResourceEncryptionConfigExtended();
            return await backupResourceEncryptionConfigExtendedResource.GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Fetches Vault Encryption config.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupEncryptionConfigs/backupResourceEncryptionConfig</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BackupResourceEncryptionConfigs_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BackupResourceEncryptionConfigExtendedResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vaultName"> The name of the recovery services vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BackupResourceEncryptionConfigExtendedResource> GetBackupResourceEncryptionConfigExtended(string vaultName, CancellationToken cancellationToken = default)
        {
            var backupResourceEncryptionConfigExtendedResource = GetBackupResourceEncryptionConfigExtended();
            return backupResourceEncryptionConfigExtendedResource.Get(cancellationToken);
        }

        /// <summary> Gets a collection of BackupResourceVaultConfigResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of BackupResourceVaultConfigResources and their operations over a BackupResourceVaultConfigResource. </returns>
        [Obsolete("This collection class is retained for backward compatibility. The BackupResourceVaultConfigResources is a singleton resource and should not have a collection class.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual BackupResourceVaultConfigCollection GetBackupResourceVaultConfigs()
        {
            throw new NotSupportedException("This method is not supported because BackupResourceVaultConfigResource is a singleton resource and should not have a collection class.");
        }

        /// <summary>
        /// Fetches resource vault config.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupconfig/vaultconfig</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BackupResourceVaultConfigs_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BackupResourceVaultConfigResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vaultName"> The name of the recovery services vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BackupResourceVaultConfigResource>> GetBackupResourceVaultConfigAsync(string vaultName, CancellationToken cancellationToken = default)
        {
            var resourceVaultConfigResource = GetBackupResourceVaultConfig();
            return await resourceVaultConfigResource.GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Fetches resource vault config.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupconfig/vaultconfig</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BackupResourceVaultConfigs_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BackupResourceVaultConfigResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vaultName"> The name of the recovery services vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BackupResourceVaultConfigResource> GetBackupResourceVaultConfig(string vaultName, CancellationToken cancellationToken = default)
        {
            var resourceVaultConfigResource = GetBackupResourceVaultConfig();
            return resourceVaultConfigResource.Get(cancellationToken);
        }
    }
}
