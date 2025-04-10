// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.RecoveryServicesBackup
{
    /// <summary>
    /// BackupProtectionPolicyResource.
    /// </summary>
    public partial class BackupProtectionPolicyResource
    {
        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="waitUntil"></param>
        /// <param name="data"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual ArmOperation<BackupProtectionPolicyResource> Update(WaitUntil waitUntil, BackupProtectionPolicyData data, CancellationToken cancellationToken)
        {
            return Update(waitUntil, data,xMsAuthorizationAuxiliary: null, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Update Async.
        /// </summary>
        /// <param name="waitUntil"></param>
        /// <param name="data"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<ArmOperation<BackupProtectionPolicyResource>> UpdateAsync(WaitUntil waitUntil, BackupProtectionPolicyData data, CancellationToken cancellationToken)
        {
            return UpdateAsync(waitUntil, data, xMsAuthorizationAuxiliary: null, cancellationToken: cancellationToken);
        }
    }
}
