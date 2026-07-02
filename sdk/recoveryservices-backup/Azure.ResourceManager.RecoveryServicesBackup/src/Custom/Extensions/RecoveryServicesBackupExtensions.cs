// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.RecoveryServicesBackup.Mocking;
using Azure.ResourceManager.RecoveryServicesBackup.Models;
using Azure.ResourceManager.Resources;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.RecoveryServicesBackup
{
    public static partial class RecoveryServicesBackupExtensions
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableRecoveryServicesBackupResourceGroupResource.GetSecurityPin(string,SecurityPinContent,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vaultName"> The name of the recovery services vault. </param>
        /// <param name="content"> security pin request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="vaultName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<TokenInformation> GetSecurityPin(this ResourceGroupResource resourceGroupResource, string vaultName, SecurityPinContent content, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableRecoveryServicesBackupResourceGroupResource(resourceGroupResource).GetSecurityPin(vaultName, content, cancellationToken: cancellationToken);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableRecoveryServicesBackupResourceGroupResource.GetSecurityPin(string,SecurityPinContent,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vaultName"> The name of the recovery services vault. </param>
        /// <param name="content"> security pin request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="vaultName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<TokenInformation>> GetSecurityPinAsync(this ResourceGroupResource resourceGroupResource, string vaultName, SecurityPinContent content, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableRecoveryServicesBackupResourceGroupResource(resourceGroupResource).GetSecurityPinAsync(vaultName, content, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Gets a collection of BackupResourceConfigResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableRecoveryServicesBackupResourceGroupResource.GetBackupResourceConfigs()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of BackupResourceConfigResources and their operations over a BackupResourceConfigResource. </returns>
        [Obsolete("This collection class is retained for backward compatibility. The BackupResourceConfigResource is a singleton resource and should not have a collection class.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BackupResourceConfigCollection GetBackupResourceConfigs(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableRecoveryServicesBackupResourceGroupResource(resourceGroupResource).GetBackupResourceConfigs();
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableRecoveryServicesBackupResourceGroupResource.GetBackupResourceConfigAsync(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vaultName"> The name of the recovery services vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="vaultName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<BackupResourceConfigResource>> GetBackupResourceConfigAsync(this ResourceGroupResource resourceGroupResource, string vaultName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return await GetMockableRecoveryServicesBackupResourceGroupResource(resourceGroupResource).GetBackupResourceConfigAsync(vaultName, cancellationToken).ConfigureAwait(false);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableRecoveryServicesBackupResourceGroupResource.GetBackupResourceConfig(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vaultName"> The name of the recovery services vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="vaultName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<BackupResourceConfigResource> GetBackupResourceConfig(this ResourceGroupResource resourceGroupResource, string vaultName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableRecoveryServicesBackupResourceGroupResource(resourceGroupResource).GetBackupResourceConfig(vaultName, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of BackupResourceEncryptionConfigExtendedResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableRecoveryServicesBackupResourceGroupResource.GetBackupResourceEncryptionConfigExtendeds()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of BackupResourceEncryptionConfigExtendedResources and their operations over a BackupResourceEncryptionConfigExtendedResource. </returns>
        [Obsolete("This collection class is retained for backward compatibility. The BackupResourceEncryptionConfigExtendedResource is a singleton resource and should not have a collection class.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BackupResourceEncryptionConfigExtendedCollection GetBackupResourceEncryptionConfigExtendeds(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableRecoveryServicesBackupResourceGroupResource(resourceGroupResource).GetBackupResourceEncryptionConfigExtendeds();
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableRecoveryServicesBackupResourceGroupResource.GetBackupResourceEncryptionConfigExtendedAsync(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vaultName"> The name of the recovery services vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="vaultName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<BackupResourceEncryptionConfigExtendedResource>> GetBackupResourceEncryptionConfigExtendedAsync(this ResourceGroupResource resourceGroupResource, string vaultName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return await GetMockableRecoveryServicesBackupResourceGroupResource(resourceGroupResource).GetBackupResourceEncryptionConfigExtendedAsync(vaultName, cancellationToken).ConfigureAwait(false);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableRecoveryServicesBackupResourceGroupResource.GetBackupResourceEncryptionConfigExtended(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vaultName"> The name of the recovery services vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="vaultName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<BackupResourceEncryptionConfigExtendedResource> GetBackupResourceEncryptionConfigExtended(this ResourceGroupResource resourceGroupResource, string vaultName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableRecoveryServicesBackupResourceGroupResource(resourceGroupResource).GetBackupResourceEncryptionConfigExtended(vaultName, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of BackupResourceVaultConfigResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableRecoveryServicesBackupResourceGroupResource.GetBackupResourceVaultConfigs()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of BackupResourceVaultConfigResources and their operations over a BackupResourceVaultConfigResource. </returns>
        [Obsolete("This collection class is retained for backward compatibility. The BackupResourceVaultConfigResource is a singleton resource and should not have a collection class.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BackupResourceVaultConfigCollection GetBackupResourceVaultConfigs(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableRecoveryServicesBackupResourceGroupResource(resourceGroupResource).GetBackupResourceVaultConfigs();
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableRecoveryServicesBackupResourceGroupResource.GetBackupResourceVaultConfigAsync(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vaultName"> The name of the recovery services vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="vaultName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<BackupResourceVaultConfigResource>> GetBackupResourceVaultConfigAsync(this ResourceGroupResource resourceGroupResource, string vaultName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return await GetMockableRecoveryServicesBackupResourceGroupResource(resourceGroupResource).GetBackupResourceVaultConfigAsync(vaultName, cancellationToken).ConfigureAwait(false);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableRecoveryServicesBackupResourceGroupResource.GetBackupResourceVaultConfig(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vaultName"> The name of the recovery services vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="vaultName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<BackupResourceVaultConfigResource> GetBackupResourceVaultConfig(this ResourceGroupResource resourceGroupResource, string vaultName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableRecoveryServicesBackupResourceGroupResource(resourceGroupResource).GetBackupResourceVaultConfig(vaultName, cancellationToken);
        }
    }
}
