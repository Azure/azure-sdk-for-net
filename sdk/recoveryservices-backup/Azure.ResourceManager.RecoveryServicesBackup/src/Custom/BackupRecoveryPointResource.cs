// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.RecoveryServicesBackup
{
    /// <summary>
    /// BackupRecoveryPointResource.
    /// </summary>
    public partial class BackupRecoveryPointResource
    {
        /// <summary>
        /// Trigger Restore.
        /// </summary>
        /// <param name="waitUntil"></param>
        /// <param name="content"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual ArmOperation TriggerRestore(WaitUntil waitUntil, Models.TriggerRestoreContent content, CancellationToken cancellationToken)
        {
            return TriggerRestore(waitUntil, content,xMsAuthorizationAuxiliary: null, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Trigger Restore Async.
        /// </summary>
        /// <param name="waitUntil"></param>
        /// <param name="content"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<ArmOperation> TriggerRestoreAsync(WaitUntil waitUntil, Models.TriggerRestoreContent content, CancellationToken cancellationToken)
        {
            return TriggerRestoreAsync(waitUntil, content, xMsAuthorizationAuxiliary: null, cancellationToken: cancellationToken);
        }
    }
}
