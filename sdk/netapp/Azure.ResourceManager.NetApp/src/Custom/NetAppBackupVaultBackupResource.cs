// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    /// <summary> Backward-compat shims for NetAppBackupVaultBackupResource. </summary>
    public partial class NetAppBackupVaultBackupResource : ArmResource, IJsonModel<NetAppBackupData>, IPersistableModel<NetAppBackupData>
    {
        /// <summary> Restore files from a backup. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> RestoreFilesBackupsUnderBackupVaultAsync(WaitUntil waitUntil, NetAppVolumeBackupBackupRestoreFilesContent body, CancellationToken cancellationToken = default)
        {
            return await RestoreFilesAsync(waitUntil, body, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Restore files from a backup. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation RestoreFilesBackupsUnderBackupVault(WaitUntil waitUntil, NetAppVolumeBackupBackupRestoreFilesContent body, CancellationToken cancellationToken = default)
        {
            return RestoreFiles(waitUntil, body, cancellationToken);
        }

        NetAppBackupData IJsonModel<NetAppBackupData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("Use NetAppBackupVaultBackupData instead.");
        void IJsonModel<NetAppBackupData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("Use NetAppBackupVaultBackupData instead.");
        NetAppBackupData IPersistableModel<NetAppBackupData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("Use NetAppBackupVaultBackupData instead.");
        string IPersistableModel<NetAppBackupData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<NetAppBackupData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("Use NetAppBackupVaultBackupData instead.");
    }
}
