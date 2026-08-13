// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Preserves the previous backupSettings-based constructor shape for backup content models.
    public partial class PostgreSqlBackupContent
    {
        // TODO: Remove this shim after https://github.com/Azure/azure-sdk-for-net/pull/58867 is merged and consumed.
        // Required by generated derived backup-content deserialization constructors.
        private protected PostgreSqlBackupContent()
        {
        }

        /// <summary> Initializes a new instance of <see cref="PostgreSqlBackupContent"/>. </summary>
        /// <param name="backupSettings"> Backup Settings. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="backupSettings"/> is null. </exception>
        public PostgreSqlBackupContent(PostgreSqlFlexibleServerBackupSettings backupSettings)
        {
            Argument.AssertNotNull(backupSettings, nameof(backupSettings));

            BackupSettings = backupSettings;
        }
    }
}
