// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.RecoveryServicesBackup
{
    /// <summary>
    /// The BackupProtectionPolicyCollection.
    /// </summary>
    public partial class BackupProtectionPolicyCollection
    {
        /// <summary>
        /// Create or Update.
        /// </summary>
        /// <param name="waitUntil"></param>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual ArmOperation<BackupProtectionPolicyResource> CreateOrUpdate(WaitUntil waitUntil, string name, BackupProtectionPolicyData data, CancellationToken cancellationToken)
        {
            return CreateOrUpdate(waitUntil, name, data, xMsAuthorizationAuxiliary: null, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Create or Update Async.
        /// </summary>
        /// <param name="waitUntil"></param>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<ArmOperation<BackupProtectionPolicyResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string name, BackupProtectionPolicyData data, CancellationToken cancellationToken)
        {
            return CreateOrUpdateAsync(waitUntil, name, data, xMsAuthorizationAuxiliary: null, cancellationToken: cancellationToken);
        }
    }
}
