// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    // Backward-compat: BackupsMigrationContent is custom because the previous SDK exposed both a
    // string ctor and a (deprecated) ResourceIdentifier ctor for `backupVaultId`. The generated
    // model only emits the `string` ctor (matching the spec's `@@alternateType` to string), so
    // we add the EBV-hidden ResourceIdentifier overload for source compatibility.
    public partial class BackupsMigrationContent
    {
        /// <summary> Initializes a new instance of <see cref="BackupsMigrationContent"/>. </summary>
        /// <param name="backupVaultId"> The resource ID of the backup vault as string. </param>
        public BackupsMigrationContent(string backupVaultId)
        {
            Argument.AssertNotNull(backupVaultId, nameof(backupVaultId));
            BackupVaultId = backupVaultId;
        }

        /// <summary> Initializes a new instance of <see cref="BackupsMigrationContent"/>. </summary>
        /// <param name="backupVaultId"> The resource ID of the backup vault. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BackupsMigrationContent(ResourceIdentifier backupVaultId) : this(backupVaultId?.ToString()) { }
    }
}
