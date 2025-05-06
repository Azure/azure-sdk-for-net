// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.RecoveryServicesBackup
{
    public partial class BackupProtectionPolicyResource
    {
        /// <summary>
        /// Creates or modifies a backup policy. This is an asynchronous operation. Status of the operation can be fetched
        /// using GetPolicyOperationResult API.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupPolicies/{policyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProtectionPolicies_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BackupProtectionPolicyResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> resource backup policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<BackupProtectionPolicyResource> Update(WaitUntil waitUntil, BackupProtectionPolicyData data, CancellationToken cancellationToken)
        {
            return Update(waitUntil, data,xMsAuthorizationAuxiliary: null, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Creates or modifies a backup policy. This is an asynchronous operation. Status of the operation can be fetched
        /// using GetPolicyOperationResult API.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupPolicies/{policyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProtectionPolicies_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BackupProtectionPolicyResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> resource backup policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<BackupProtectionPolicyResource>> UpdateAsync(WaitUntil waitUntil, BackupProtectionPolicyData data, CancellationToken cancellationToken)
        {
            return UpdateAsync(waitUntil, data, xMsAuthorizationAuxiliary: null, cancellationToken: cancellationToken);
        }
    }
}
