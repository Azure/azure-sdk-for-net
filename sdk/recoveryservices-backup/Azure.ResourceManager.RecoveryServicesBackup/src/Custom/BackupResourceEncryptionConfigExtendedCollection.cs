// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.RecoveryServicesBackup.Models;
using Azure.ResourceManager.Resources;

// NOTE: The following customization is intentionally retained for backward compatibility.
// The BackupResourceEncryptionConfigExtendedResource is a singleton resource, so should not have Collection class. However this Collection class was added in previous release by mistake, and removing it will be a breaking change. So we keep this Collection class, but mark it as obsolete.
namespace Azure.ResourceManager.RecoveryServicesBackup
{
    /// <summary>
    /// A class representing a collection of <see cref="BackupResourceEncryptionConfigExtendedResource"/> and their operations.
    /// Each <see cref="BackupResourceEncryptionConfigExtendedResource"/> in the collection will belong to the same instance of <see cref="ResourceGroupResource"/>.
    /// To get a <see cref="BackupResourceEncryptionConfigExtendedCollection"/> instance call the GetBackupResourceEncryptionConfigExtendeds method from an instance of <see cref="ResourceGroupResource"/>.
    /// </summary>
    [Obsolete("This collection class is retained for backward compatibility. The BackupResourceEncryptionConfigExtendedResource is a singleton resource and should not have a collection class.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class BackupResourceEncryptionConfigExtendedCollection : ArmCollection
    {
        /// <summary> Initializes a new instance of the <see cref="BackupResourceEncryptionConfigExtendedCollection"/> class for mocking. </summary>
        protected BackupResourceEncryptionConfigExtendedCollection()
        {
        }

        /// <summary>
        /// Updates Vault encryption config.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupEncryptionConfigs/backupResourceEncryptionConfig</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BackupResourceEncryptionConfigs_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BackupResourceEncryptionConfigExtendedResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vaultName"> The name of the recovery services vault. </param>
        /// <param name="content"> Vault encryption input config request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation> CreateOrUpdateAsync(WaitUntil waitUntil, string vaultName, BackupResourceEncryptionConfigExtendedCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported because BackupResourceEncryptionConfigExtendedResource is a singleton resource and should not have a collection class.");
        }

        /// <summary>
        /// Updates Vault encryption config.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupEncryptionConfigs/backupResourceEncryptionConfig</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BackupResourceEncryptionConfigs_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BackupResourceEncryptionConfigExtendedResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vaultName"> The name of the recovery services vault. </param>
        /// <param name="content"> Vault encryption input config request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation CreateOrUpdate(WaitUntil waitUntil, string vaultName, BackupResourceEncryptionConfigExtendedCreateOrUpdateContent content, CancellationToken cancellationToken = default)
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
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<BackupResourceEncryptionConfigExtendedResource>> GetAsync(string vaultName, CancellationToken cancellationToken = default)
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
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BackupResourceEncryptionConfigExtendedResource> Get(string vaultName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported because BackupResourceEncryptionConfigExtendedResource is a singleton resource and should not have a collection class.");
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
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
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<bool>> ExistsAsync(string vaultName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported because BackupResourceEncryptionConfigExtendedResource is a singleton resource and should not have a collection class.");
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
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
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string vaultName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported because BackupResourceEncryptionConfigExtendedResource is a singleton resource and should not have a collection class.");
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
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
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<NullableResponse<BackupResourceEncryptionConfigExtendedResource>> GetIfExistsAsync(string vaultName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported because BackupResourceEncryptionConfigExtendedResource is a singleton resource and should not have a collection class.");
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
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
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<BackupResourceEncryptionConfigExtendedResource> GetIfExists(string vaultName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported because BackupResourceEncryptionConfigExtendedResource is a singleton resource and should not have a collection class.");
        }
    }
}
