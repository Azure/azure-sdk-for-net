// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.NetApp
{
    /// <summary> Backward-compat shims for NetAppBackupVaultBackupCollection. </summary>
    public partial class NetAppBackupVaultBackupCollection : ArmCollection
    {
        // TODO: NetAppBackupVaultBackupData was renamed to BackupData and the CreateOrUpdate methods
        // on this standalone class can't delegate to the Generated BackupCollection methods.
        // These backward compat shims need to be reworked if still needed.
        //
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // public virtual async Task<ArmOperation<NetAppBackupVaultBackupResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string backupName, NetAppBackupData data, CancellationToken cancellationToken = default)
        // { ... }
        //
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // public virtual ArmOperation<NetAppBackupVaultBackupResource> CreateOrUpdate(WaitUntil waitUntil, string backupName, NetAppBackupData data, CancellationToken cancellationToken = default)
        // { ... }
    }
}
