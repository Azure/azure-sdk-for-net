// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.DataProtectionBackup.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.DataProtectionBackup
{
    /// <summary>
    /// A class representing a collection of <see cref="DataProtectionBackupInstanceResource"/> and their operations.
    /// Each <see cref="DataProtectionBackupInstanceResource"/> in the collection will belong to the same instance of <see cref="DataProtectionBackupVaultResource"/>.
    /// To get a <see cref="DataProtectionBackupInstanceCollection"/> instance call the GetDataProtectionBackupInstances method from an instance of <see cref="DataProtectionBackupVaultResource"/>.
    /// </summary>
    public partial class DataProtectionBackupInstanceCollection
    {
        /// <summary>
        /// Create or update a backup instance in a backup vault
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/backupVaults/{vaultName}/backupInstances/{backupInstanceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BackupInstances_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DataProtectionBackupInstanceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="backupInstanceName"> The name of the backup instance. </param>
        /// <param name="data"> Request body for operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="backupInstanceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="backupInstanceName"/> or <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DataProtectionBackupInstanceResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string backupInstanceName, DataProtectionBackupInstanceData data, CancellationToken cancellationToken)
        {
            return await CreateOrUpdateAsync(waitUntil, backupInstanceName, data, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create or update a backup instance in a backup vault
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/backupVaults/{vaultName}/backupInstances/{backupInstanceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BackupInstances_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DataProtectionBackupInstanceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="backupInstanceName"> The name of the backup instance. </param>
        /// <param name="data"> Request body for operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="backupInstanceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="backupInstanceName"/> or <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DataProtectionBackupInstanceResource> CreateOrUpdate(WaitUntil waitUntil, string backupInstanceName, DataProtectionBackupInstanceData data, CancellationToken cancellationToken)
        {
            return CreateOrUpdate(waitUntil, backupInstanceName, data, null, cancellationToken);
        }
    }
}
