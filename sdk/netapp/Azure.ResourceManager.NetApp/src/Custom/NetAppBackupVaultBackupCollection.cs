// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.NetApp
{
    /// <summary> Backward-compat shims for NetAppBackupVaultBackupCollection. </summary>
    public partial class NetAppBackupVaultBackupCollection : ArmCollection
    {
        /// <summary> Create a backup under the backup vault. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NetAppBackupVaultBackupResource> CreateOrUpdate(WaitUntil waitUntil, string backupName, NetAppBackupData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is not supported. Use CreateOrUpdate(WaitUntil, string, NetAppBackupVaultBackupData, CancellationToken) instead.");
        }

        /// <summary> Create a backup under the backup vault. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NetAppBackupVaultBackupResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string backupName, NetAppBackupData data, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This overload is not supported. Use CreateOrUpdateAsync(WaitUntil, string, NetAppBackupVaultBackupData, CancellationToken) instead.");
        }
    }
}
