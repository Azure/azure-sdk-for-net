// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Preserves the previous backupSettings-based constructor. The new emitter flattens `backupSettings.backupName` into a `string backupName` ctor parameter,
    // but the base class (PostgreSqlBackupContent) only has constructors taking
    // PostgreSqlFlexibleServerBackupSettings, causing CS1503. Suppress the flattened ctor and
    // provide the legacy backupSettings-based ctor for backward compatibility.
    [CodeGenSuppress("PostgreSqlFlexibleServerLtrPreBackupContent", typeof(string))]
    public partial class PostgreSqlFlexibleServerLtrPreBackupContent
    {
        /// <summary> Initializes a new instance of <see cref="PostgreSqlFlexibleServerLtrPreBackupContent"/>. </summary>
        /// <param name="backupSettings"> Backup Settings. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="backupSettings"/> is null. </exception>
        public PostgreSqlFlexibleServerLtrPreBackupContent(PostgreSqlFlexibleServerBackupSettings backupSettings) : base(backupSettings)
        {
            Argument.AssertNotNull(backupSettings, nameof(backupSettings));
        }
    }
}
