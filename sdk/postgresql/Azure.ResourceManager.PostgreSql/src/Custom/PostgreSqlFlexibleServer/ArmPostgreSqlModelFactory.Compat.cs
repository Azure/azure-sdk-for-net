// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Suppress generated factory methods that reference internal ForPatch types.
    // These methods use internal types (AuthConfigForPatch, BackupForPatch, etc.) in their public signatures,
    // which causes CS0051 errors. The backward-compat factory methods in ArmPostgreSqlFlexibleServersModelFactory
    // provide equivalent functionality using the old public types.
    [CodeGenSuppress("PostgreSqlFlexibleServerPatch")]
    [CodeGenSuppress("PostgreSqlMigrationPatch")]
    public static partial class ArmPostgreSqlModelFactory
    {
    }
}
