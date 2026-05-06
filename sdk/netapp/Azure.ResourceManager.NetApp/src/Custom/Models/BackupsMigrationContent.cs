// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    // Backward-compat: the GENERATED `BackupsMigrationContent` (Generated/Models/BackupsMigrationContent.cs)
    // exposes ONLY an `internal` constructor — there is no way for users to construct it.
    // The custom string ctor below is therefore required to expose a public construction
    // path at all. The deprecated ResourceIdentifier overload is then retained on top of
    // that for v1.15 source-compat (GA used a ResourceIdentifier-typed `BackupVaultId`).
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
