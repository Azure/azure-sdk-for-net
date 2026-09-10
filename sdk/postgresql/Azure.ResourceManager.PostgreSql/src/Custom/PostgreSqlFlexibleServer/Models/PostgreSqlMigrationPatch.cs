// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // The merged TypeSpec models patch secretParameters with the patch-only MigrationSecretParametersForPatch type.
    // Preserve the previous GA PostgreSqlMigrationSecretParameters property type on PostgreSqlMigrationPatch.
    public partial class PostgreSqlMigrationPatch
    {
        /// <summary> Migration secret parameters. </summary>
        public PostgreSqlMigrationSecretParameters SecretParameters { get; set; }
    }
}
