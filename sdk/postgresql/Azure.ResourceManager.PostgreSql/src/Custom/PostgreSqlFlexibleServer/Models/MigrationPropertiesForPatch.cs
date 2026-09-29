// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // TODO: Remove these workarounds after https://github.com/microsoft/typespec/issues/11696 is fixed.
    internal partial class MigrationPropertiesForPatch
    {
        [CodeGenMember("SourceDBServerResourceId")]
        public ResourceIdentifier SourceDbServerResourceId { get; set; }

        [CodeGenMember("SourceDBServerFullyQualifiedDomainName")]
        public string SourceDbServerFullyQualifiedDomainName { get; set; }

        [CodeGenMember("TargetDBServerFullyQualifiedDomainName")]
        public string TargetDbServerFullyQualifiedDomainName { get; set; }

        [CodeGenMember("SetupLogicalReplicationOnSourceDBIfNeeded")]
        public PostgreSqlMigrationLogicalReplicationOnSourceDb? SetupLogicalReplicationOnSourceDbIfNeeded { get; set; }
    }
}
