// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.RecoveryServicesBackup
{
    /// <summary> The BackupProtectedItemCollection. </summary>
    public partial class BackupProtectedItemCollection
    {
        /// <summary>
        /// <summary>Create or Update.</summary>
        /// </summary>
        /// <param name="waitUntil"></param>
        /// <param name="protectedItemName"></param>
        /// <param name="data"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual ArmOperation<BackupProtectedItemResource> CreateOrUpdate(WaitUntil waitUntil, string protectedItemName, BackupProtectedItemData data, CancellationToken cancellationToken)
        {
            return CreateOrUpdate(waitUntil, protectedItemName, data, xMsAuthorizationAuxiliary: null, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <summary>Create or Update Async.</summary>
        /// </summary>
        /// <param name="waitUntil"></param>
        /// <param name="protectedItemName"></param>
        /// <param name="data"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<ArmOperation<BackupProtectedItemResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string protectedItemName, BackupProtectedItemData data, CancellationToken cancellationToken)
        {
            return CreateOrUpdateAsync(waitUntil, protectedItemName, data, xMsAuthorizationAuxiliary: null, cancellationToken: cancellationToken);
        }
    }
}
