// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Restores the public BackupSettings constructor shape from the previous SDK.
    public partial class PostgreSqlBackupContent
    {
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
