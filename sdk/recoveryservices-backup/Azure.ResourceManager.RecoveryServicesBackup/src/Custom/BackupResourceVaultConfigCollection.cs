// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.RecoveryServicesBackup
{
    /// <summary>
    /// BackupResourceVaultConfigCollection
    /// </summary>
    public partial class BackupResourceVaultConfigCollection
    {
        /// <summary>
        /// Create or Update.
        /// </summary>
        /// <param name="waitUntil"></param>
        /// <param name="vaultName"></param>
        /// <param name="backupResourceVaultConfigData"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual ArmOperation<BackupResourceVaultConfigResource>  CreateOrUpdate(WaitUntil waitUntil, string vaultName, BackupResourceVaultConfigData backupResourceVaultConfigData, CancellationToken cancellationToken)
        {
            return CreateOrUpdate(waitUntil, vaultName, backupResourceVaultConfigData, xMsAuthorizationAuxiliary: null, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Create or Update async.
        /// </summary>
        /// <param name="waitUntil"></param>
        /// <param name="vaultName"></param>
        /// <param name="backupResourceVaultConfigData"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<ArmOperation<BackupResourceVaultConfigResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string vaultName, BackupResourceVaultConfigData backupResourceVaultConfigData, CancellationToken cancellationToken)
        {
            return CreateOrUpdateAsync(waitUntil, vaultName, backupResourceVaultConfigData, xMsAuthorizationAuxiliary: null, cancellationToken: cancellationToken);
        }
    }
}
