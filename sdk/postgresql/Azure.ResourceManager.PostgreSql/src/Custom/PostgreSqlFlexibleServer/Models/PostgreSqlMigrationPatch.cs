// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Preserve the previous GA type for migration patch secret parameters.
    public partial class PostgreSqlMigrationPatch
    {
        /// <summary> Migration secret parameters. </summary>
        [CodeGenMember("SecretParameters")]
        public PostgreSqlMigrationSecretParameters SecretParameters { get; set; }
    }
}
