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
    // Custom additions for NetAppBackupVaultBackupResource:
    // - RestoreFilesBackupsUnderBackupVault* preserve the previous SDK's longer method names.
    // - The IJsonModel<NetAppBackupData>/IPersistableModel<NetAppBackupData> implementations
    //   delegate to Data. The generator declares the interfaces on the resource (because the
    //   data class is renamed asymmetrically via [CodeGenType] from NetAppBackupVaultBackupData
    //   to NetAppBackupData) but does not emit the method bodies, so they are provided here.
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

        void IJsonModel<NetAppBackupData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<NetAppBackupData>)Data).Write(writer, options);

        NetAppBackupData IJsonModel<NetAppBackupData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => DataDeserializationInstance.Create(ref reader, options);

        BinaryData IPersistableModel<NetAppBackupData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<NetAppBackupData>(Data, options, AzureResourceManagerNetAppContext.Default);

        NetAppBackupData IPersistableModel<NetAppBackupData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<NetAppBackupData>(data, options, AzureResourceManagerNetAppContext.Default);

        string IPersistableModel<NetAppBackupData>.GetFormatFromOptions(ModelReaderWriterOptions options) => DataDeserializationInstance.GetFormatFromOptions(options);
    }
}
