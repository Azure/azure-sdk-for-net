// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> A request that is made for pre-backup. </summary>
    [CodeGenSuppress("PostgreSqlFlexibleServerLtrPreBackupContent", typeof(PostgreSqlFlexibleServerBackupSettings))]
    public partial class PostgreSqlFlexibleServerLtrPreBackupContent : PostgreSqlBackupContent
    {
        /// <summary> Initializes a new instance of <see cref="PostgreSqlFlexibleServerLtrPreBackupContent"/>. </summary>
        /// <param name="backupSettings"> Backup Settings. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="backupSettings"/> is null. </exception>
        public PostgreSqlFlexibleServerLtrPreBackupContent(PostgreSqlFlexibleServerBackupSettings backupSettings) : base(backupSettings, null)
        {
            Argument.AssertNotNull(backupSettings, nameof(backupSettings));
        }
    }
}
