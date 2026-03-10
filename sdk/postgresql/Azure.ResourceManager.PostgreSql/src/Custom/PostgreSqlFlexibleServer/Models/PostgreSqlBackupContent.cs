// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    [CodeGenSuppress("PostgreSqlBackupContent")]
    public partial class PostgreSqlBackupContent
    {
        /// <summary> Initializes a new instance of <see cref="PostgreSqlBackupContent"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PostgreSqlBackupContent()
        {
        }

        /// <summary> Initializes a new instance of <see cref="PostgreSqlBackupContent"/>. </summary>
        /// <param name="backupSettings"> Backup Settings. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PostgreSqlBackupContent(PostgreSqlFlexibleServerBackupSettings backupSettings)
        {
            BackupSettings = backupSettings;
        }
    }
}
