// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Preserves both the flattened backupName constructor and the previous backupSettings-based constructor.
    public partial class PostgreSqlFlexibleServerLtrPreBackupContent
    {
        /// <summary> Initializes a new instance of <see cref="PostgreSqlFlexibleServerLtrPreBackupContent"/>. </summary>
        /// <param name="backupName"> Backup Name for the current backup. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="backupName"/> is null. </exception>
        public PostgreSqlFlexibleServerLtrPreBackupContent(string backupName) : this(new PostgreSqlFlexibleServerBackupSettings(backupName))
        {
        }

        /// <summary> Initializes a new instance of <see cref="PostgreSqlFlexibleServerLtrPreBackupContent"/>. </summary>
        /// <param name="backupSettings"> Backup Settings. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="backupSettings"/> is null. </exception>
        public PostgreSqlFlexibleServerLtrPreBackupContent(PostgreSqlFlexibleServerBackupSettings backupSettings) : base(backupSettings)
        {
            Argument.AssertNotNull(backupSettings, nameof(backupSettings));
        }
    }
}
