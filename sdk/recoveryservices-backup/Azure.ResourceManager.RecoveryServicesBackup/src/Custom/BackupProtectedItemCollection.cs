// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.RecoveryServicesBackup
{
    public partial class BackupProtectedItemCollection
    {
        /// <summary>
        /// Enables backup of an item or to modifies the backup policy information of an already backed up item. This is an
        /// asynchronous operation. To know the status of the operation, call the GetItemOperationResult API.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{fabricName}/protectionContainers/{containerName}/protectedItems/{protectedItemName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProtectedItems_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BackupProtectedItemResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="protectedItemName"> Item name to be backed up. </param>
        /// <param name="data"> resource backed up item. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="protectedItemName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="protectedItemName"/> or <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<BackupProtectedItemResource> CreateOrUpdate(WaitUntil waitUntil, string protectedItemName, BackupProtectedItemData data, CancellationToken cancellationToken)
        {
            return CreateOrUpdate(waitUntil, protectedItemName, data, xMsAuthorizationAuxiliary: null, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Enables backup of an item or to modifies the backup policy information of an already backed up item. This is an
        /// asynchronous operation. To know the status of the operation, call the GetItemOperationResult API.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{fabricName}/protectionContainers/{containerName}/protectedItems/{protectedItemName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProtectedItems_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BackupProtectedItemResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="protectedItemName"> Item name to be backed up. </param>
        /// <param name="data"> resource backed up item. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="protectedItemName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="protectedItemName"/> or <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<BackupProtectedItemResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string protectedItemName, BackupProtectedItemData data, CancellationToken cancellationToken)
        {
            return CreateOrUpdateAsync(waitUntil, protectedItemName, data, xMsAuthorizationAuxiliary: null, cancellationToken: cancellationToken);
        }
    }
}
