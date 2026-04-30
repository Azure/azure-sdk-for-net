// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Suppress the generated factory overload that would expose the internal patch-only secret type.
    [CodeGenSuppress("PostgreSqlMigrationPatch", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(MigrationSecretParametersForPatch), typeof(IEnumerable<string>), typeof(PostgreSqlMigrationLogicalReplicationOnSourceDb?), typeof(PostgreSqlMigrationOverwriteDbsInTarget?), typeof(DateTimeOffset?), typeof(MigrateRolesEnum?), typeof(PostgreSqlMigrationStartDataMigration?), typeof(PostgreSqlMigrationTriggerCutover?), typeof(IEnumerable<string>), typeof(PostgreSqlMigrationCancel?), typeof(IEnumerable<string>), typeof(PostgreSqlMigrationMode?), typeof(IDictionary<string, string>))]
    public static partial class ArmPostgreSqlModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlMigrationPatch"/>. </summary>
        public static PostgreSqlMigrationPatch PostgreSqlMigrationPatch(ResourceIdentifier sourceDbServerResourceId = null, string sourceDbServerFullyQualifiedDomainName = null, string targetDbServerFullyQualifiedDomainName = null, PostgreSqlMigrationSecretParameters secretParameters = null, IEnumerable<string> dbsToMigrate = null, PostgreSqlMigrationLogicalReplicationOnSourceDb? setupLogicalReplicationOnSourceDbIfNeeded = null, PostgreSqlMigrationOverwriteDbsInTarget? overwriteDbsInTarget = null, DateTimeOffset? migrationWindowStartTimeInUtc = null, MigrateRolesEnum? migrateRoles = null, PostgreSqlMigrationStartDataMigration? startDataMigration = null, PostgreSqlMigrationTriggerCutover? triggerCutover = null, IEnumerable<string> dbsToTriggerCutoverOn = null, PostgreSqlMigrationCancel? cancel = null, IEnumerable<string> dbsToCancelMigrationOn = null, PostgreSqlMigrationMode? migrationMode = null, IDictionary<string, string> tags = null)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new PostgreSqlMigrationPatch(sourceDbServerResourceId is null && sourceDbServerFullyQualifiedDomainName is null && targetDbServerFullyQualifiedDomainName is null && secretParameters is null && dbsToMigrate is null && setupLogicalReplicationOnSourceDbIfNeeded is null && overwriteDbsInTarget is null && migrationWindowStartTimeInUtc is null && migrateRoles is null && startDataMigration is null && triggerCutover is null && dbsToTriggerCutoverOn is null && cancel is null && dbsToCancelMigrationOn is null && migrationMode is null ? default : new MigrationPropertiesForPatch(
                sourceDbServerResourceId,
                sourceDbServerFullyQualifiedDomainName,
                targetDbServerFullyQualifiedDomainName,
                ConvertSecretParameters(secretParameters),
                dbsToMigrate?.ToList(),
                setupLogicalReplicationOnSourceDbIfNeeded,
                overwriteDbsInTarget,
                migrationWindowStartTimeInUtc,
                migrateRoles,
                startDataMigration,
                triggerCutover,
                dbsToTriggerCutoverOn?.ToList(),
                cancel,
                dbsToCancelMigrationOn?.ToList(),
                migrationMode,
                null),
                tags,
                additionalBinaryDataProperties: null);
        }

        private static MigrationSecretParametersForPatch ConvertSecretParameters(PostgreSqlMigrationSecretParameters secretParameters)
        {
            if (secretParameters is null)
            {
                return null;
            }

            return new MigrationSecretParametersForPatch
            {
                AdminCredentials = secretParameters.AdminCredentials is null ? null : new AdminCredentialsForPatch
                {
                    SourceServerPassword = secretParameters.AdminCredentials.SourceServerPassword,
                    TargetServerPassword = secretParameters.AdminCredentials.TargetServerPassword
                },
                SourceServerUsername = secretParameters.SourceServerUsername,
                TargetServerUsername = secretParameters.TargetServerUsername
            };
        }
    }
}
