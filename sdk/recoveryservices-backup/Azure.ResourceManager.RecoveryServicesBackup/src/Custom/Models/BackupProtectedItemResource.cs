// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.RecoveryServicesBackup
{
    /// <summary> The BackupProtectedItemResource. </summary>
    public partial class BackupProtectedItemResource
    {
        /// <summary>
        /// Update async.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="backupProtectedItemData"> resource backed up item. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<BackupProtectedItemResource>> UpdateAsync(WaitUntil waitUntil, BackupProtectedItemData backupProtectedItemData, CancellationToken cancellationToken)
        {
            return UpdateAsync(waitUntil, backupProtectedItemData, xMsAuthorizationAuxiliary: null, cancellationToken: cancellationToken);
        }
    }
}
