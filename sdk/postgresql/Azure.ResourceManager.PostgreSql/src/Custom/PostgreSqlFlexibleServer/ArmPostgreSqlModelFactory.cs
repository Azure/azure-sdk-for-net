// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Suppress generated factory methods that reference internal ForPatch / "Internal" types.
    // These methods use internal types (AuthConfigForPatch, BackupForPatch, HighAvailabilityForPatch,
    // MaintenanceWindowForPatch, SkuForPatch, MigrationSecretParametersForPatch, UserIdentity)
    // in their public signatures, which causes CS0051 errors.
    // The backward-compat factory methods in ArmPostgreSqlFlexibleServersModelFactory provide
    // equivalent functionality using the old public types.
    //
    // Name-only suppression is no longer honored by the latest emitter when overloads exist, so
    // the full typed signatures are listed explicitly below.
    [CodeGenSuppress(
        "PostgreSqlFlexibleServerPatch",
        typeof(SkuForPatch),
        typeof(PostgreSqlFlexibleServerUserAssignedIdentity),
        typeof(string),
        typeof(string),
        typeof(PostgreSqlFlexibleServerVersion?),
        typeof(PostgreSqlFlexibleServerStorage),
        typeof(BackupForPatch),
        typeof(HighAvailabilityForPatch),
        typeof(MaintenanceWindowForPatch),
        typeof(AuthConfigForPatch),
        typeof(PostgreSqlFlexibleServerDataEncryption),
        typeof(string),
        typeof(PostgreSqlFlexibleServerCreateModeForUpdate?),
        typeof(PostgreSqlFlexibleServerReplicationRole?),
        typeof(PostgreSqlFlexibleServersReplica),
        typeof(PostgreSqlFlexibleServerNetwork),
        typeof(PostgreSqlFlexibleServerClusterProperties),
        typeof(IDictionary<string, string>))]
    [CodeGenSuppress(
        "PostgreSqlMigrationPatch",
        typeof(ResourceIdentifier),
        typeof(string),
        typeof(string),
        typeof(MigrationSecretParametersForPatch),
        typeof(IEnumerable<string>),
        typeof(PostgreSqlMigrationLogicalReplicationOnSourceDb?),
        typeof(PostgreSqlMigrationOverwriteDbsInTarget?),
        typeof(DateTimeOffset?),
        typeof(MigrateRolesEnum?),
        typeof(PostgreSqlMigrationStartDataMigration?),
        typeof(PostgreSqlMigrationTriggerCutover?),
        typeof(IEnumerable<string>),
        typeof(PostgreSqlMigrationCancel?),
        typeof(IEnumerable<string>),
        typeof(PostgreSqlMigrationMode?),
        typeof(IDictionary<string, string>))]
    [CodeGenSuppress(
        "PostgreSqlFlexibleServerUserAssignedIdentity",
        typeof(IDictionary<string, UserIdentity>),
        typeof(Guid?),
        typeof(PostgreSqlFlexibleServerIdentityType),
        typeof(Guid?))]
    [CodeGenSuppress(
        "PostgreSqlFlexibleServerNameAvailabilityResult",
        typeof(bool?),
        typeof(PostgreSqlFlexibleServerNameUnavailableReason?),
        typeof(string),
        typeof(string),
        typeof(ResourceType?))]
    [CodeGenSuppress(
        "PostgreSqlFlexibleServerNameAvailabilityResponse",
        typeof(bool?),
        typeof(PostgreSqlFlexibleServerNameUnavailableReason?),
        typeof(string))]
    // The new emitter flattens `backupSettings.backupName` into a `string backupName` parameter,
    // but the public API for this factory historically takes `PostgreSqlFlexibleServerBackupSettings`.
    // Suppress the generated flattened version and provide the original signature below.
    [CodeGenSuppress(
        "PostgreSqlFlexibleServerLtrBackupContent",
        typeof(string),
        typeof(IEnumerable<string>))]
    public static partial class ArmPostgreSqlModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="PostgreSqlFlexibleServerLtrBackupContent"/>. </summary>
        /// <param name="backupSettings"> Backup Settings. </param>
        /// <param name="targetDetailsSasUriList"> List of SAS uri of storage containers where backup data is to be streamed/copied. </param>
        /// <returns> A new <see cref="PostgreSqlFlexibleServerLtrBackupContent"/> instance for mocking. </returns>
        public static PostgreSqlFlexibleServerLtrBackupContent PostgreSqlFlexibleServerLtrBackupContent(PostgreSqlFlexibleServerBackupSettings backupSettings = null, IEnumerable<string> targetDetailsSasUriList = null)
        {
            PostgreSqlFlexibleServerBackupStoreDetails targetDetails = targetDetailsSasUriList is null
                ? null
                : PostgreSqlFlexibleServerBackupStoreDetails(targetDetailsSasUriList);
            return new PostgreSqlFlexibleServerLtrBackupContent(backupSettings, additionalBinaryDataProperties: null, targetDetails);
        }
    }
}
