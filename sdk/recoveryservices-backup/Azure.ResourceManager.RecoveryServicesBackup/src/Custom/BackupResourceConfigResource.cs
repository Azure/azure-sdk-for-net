// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

// NOTE: The following customization is intentionally retained for backward compatibility.
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
        /// <description>BackupResourceStorageConfigsNonCRR_Update</description>
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BackupResourceConfigResource>> UpdateAsync(BackupResourceConfigData data, CancellationToken cancellationToken = default)
        {
            var result = await CreateOrUpdateAsync(WaitUntil.Started, data, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(result.Value, result.GetRawResponse());
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
        /// <description>BackupResourceStorageConfigsNonCRR_Update</description>
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BackupResourceConfigResource> Update(BackupResourceConfigData data, CancellationToken cancellationToken = default)
        {
            var result = CreateOrUpdate(WaitUntil.Started, data, cancellationToken);
            return Response.FromValue(result.Value, result.GetRawResponse());
        }

        /// <summary>
        /// Updates vault storage model type.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupstorageconfig/vaultstorageconfig. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> BackupResourceStorageConfigsNonCRR_Update. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="BackupResourceConfigResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Vault storage config request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<BackupResourceConfigResource>> UpdateAsync(WaitUntil waitUntil, BackupResourceConfigData data, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, data, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Updates vault storage model type.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupstorageconfig/vaultstorageconfig. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> BackupResourceStorageConfigsNonCRR_Update. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-01-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="BackupResourceConfigResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Vault storage config request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<BackupResourceConfigResource> Update(WaitUntil waitUntil, BackupResourceConfigData data, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, data, cancellationToken);
    }
}
