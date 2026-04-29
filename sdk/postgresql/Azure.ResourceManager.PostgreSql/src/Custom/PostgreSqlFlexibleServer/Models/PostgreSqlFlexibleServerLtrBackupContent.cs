// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Preserves the previous constructor shape that accepted BackupSettings.
    public partial class PostgreSqlFlexibleServerLtrBackupContent
    {
        /// <summary> Initializes a new instance of <see cref="PostgreSqlFlexibleServerLtrBackupContent"/>. </summary>
        /// <param name="backupSettings"> Backup Settings. </param>
        /// <param name="targetDetails"> Backup store detail for target server. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="backupSettings"/> or <paramref name="targetDetails"/> is null. </exception>
        public PostgreSqlFlexibleServerLtrBackupContent(PostgreSqlFlexibleServerBackupSettings backupSettings, PostgreSqlFlexibleServerBackupStoreDetails targetDetails) : base(backupSettings)
        {
            Argument.AssertNotNull(backupSettings, nameof(backupSettings));
            Argument.AssertNotNull(targetDetails, nameof(targetDetails));

            TargetDetails = targetDetails;
        }
    }
}
