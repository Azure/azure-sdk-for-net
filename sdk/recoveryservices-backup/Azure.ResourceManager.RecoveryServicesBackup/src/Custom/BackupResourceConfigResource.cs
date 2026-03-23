// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;

// TODO: need further investigation to determine why the behavior of this operation is different but spec is same.
namespace Azure.ResourceManager.RecoveryServicesBackup
{
    public partial class BackupResourceConfigResource : ArmResource
    {
        /// <summary>
        /// Updates vault storage model type.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupstorageconfig/vaultstorageconfig</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BackupResourceStorageConfigsNonCRR_Patch</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BackupResourceConfigResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="data"> Vault storage config request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<Response<BackupResourceConfigResource>> UpdateAsync(BackupResourceConfigData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _backupResourceConfigBackupResourceStorageConfigsNonCRRClientDiagnostics.CreateScope("BackupResourceConfigResource.Update");
            scope.Start();
            try
            {
                var response = await _backupResourceConfigBackupResourceStorageConfigsNonCRRRestClient.PatchAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, data, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new BackupResourceConfigResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates vault storage model type.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupstorageconfig/vaultstorageconfig</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BackupResourceStorageConfigsNonCRR_Patch</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BackupResourceConfigResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="data"> Vault storage config request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual Response<BackupResourceConfigResource> Update(BackupResourceConfigData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _backupResourceConfigBackupResourceStorageConfigsNonCRRClientDiagnostics.CreateScope("BackupResourceConfigResource.Update");
            scope.Start();
            try
            {
                var response = _backupResourceConfigBackupResourceStorageConfigsNonCRRRestClient.Patch(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, data, cancellationToken);
                return Response.FromValue(new BackupResourceConfigResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
