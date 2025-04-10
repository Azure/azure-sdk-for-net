// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.RecoveryServicesBackup
{
    /// <summary>
    /// BackupResourceVaultConfigResource
    /// </summary>
    public partial class BackupResourceVaultConfigResource
    {
        /// <summary>
        /// Update async.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<Response<BackupResourceVaultConfigResource>> UpdateAsync(BackupResourceVaultConfigData data, CancellationToken cancellationToken)
        {
            return UpdateAsync(data, xMsAuthorizationAuxiliary: null, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<BackupResourceVaultConfigResource> Update(BackupResourceVaultConfigData data, CancellationToken cancellationToken)
        {
            return Update(data, xMsAuthorizationAuxiliary: null, cancellationToken: cancellationToken);
        }
    }
}
