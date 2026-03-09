// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    public partial class PostgreSqlBackupContent
    {
        /// <summary> Initializes a new instance of <see cref="PostgreSqlBackupContent"/>. </summary>
        /// <param name="backupSettings"> Backup Settings. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="backupSettings"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PostgreSqlBackupContent(PostgreSqlFlexibleServerBackupSettings backupSettings)
            : this(backupSettings, null)
        {
        }
    }
}
