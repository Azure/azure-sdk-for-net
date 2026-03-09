// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.PostgreSql.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    [CodeGenSuppress("PostgreSqlFlexibleServerUserAssignedIdentity", typeof(IDictionary<string, UserIdentity>), typeof(Guid?), typeof(PostgreSqlFlexibleServerIdentityType), typeof(Guid?))]
    [CodeGenSuppress("PostgreSqlFlexibleServerPatch", typeof(SkuForPatch), typeof(PostgreSqlFlexibleServerUserAssignedIdentity), typeof(string), typeof(PostgreSqlFlexibleServerVersion?), typeof(PostgreSqlFlexibleServerStorage), typeof(BackupForPatch), typeof(HighAvailabilityForPatch), typeof(MaintenanceWindowForPatch), typeof(AuthConfigForPatch), typeof(PostgreSqlFlexibleServerDataEncryption), typeof(string), typeof(PostgreSqlFlexibleServerCreateModeForUpdate?), typeof(PostgreSqlFlexibleServerReplicationRole?), typeof(PostgreSqlFlexibleServersReplica), typeof(PostgreSqlFlexibleServerNetwork), typeof(PostgreSqlFlexibleServerClusterProperties), typeof(string), typeof(IDictionary<string, string>))]
    public static partial class ArmPostgreSqlModelFactory
    {
    }
}

namespace Azure.ResourceManager.PostgreSql.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmPostgreSqlModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="PostgreSql.PostgreSqlPrivateEndpointConnectionData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlPrivateEndpointConnectionData PostgreSqlPrivateEndpointConnectionData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, ResourceIdentifier privateEndpointId = null, PostgreSqlPrivateLinkServiceConnectionStateProperty connectionState = null, string provisioningState = null)
        {
            return new PostgreSqlPrivateEndpointConnectionData(
                id,
                name,
                resourceType,
                systemData,
                privateEndpointId == null ? null : new WritableSubResource { Id = privateEndpointId },
                connectionState,
                provisioningState,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="PostgreSql.PostgreSqlPrivateLinkResourceData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlPrivateLinkResourceData PostgreSqlPrivateLinkResourceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, PostgreSqlPrivateLinkResourceProperties properties = null)
        {
            return new PostgreSqlPrivateLinkResourceData(
                id,
                name,
                resourceType,
                systemData,
                properties,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlPrivateLinkResourceProperties"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlPrivateLinkResourceProperties PostgreSqlPrivateLinkResourceProperties(string groupId = null, IEnumerable<string> requiredMembers = null)
        {
            return new PostgreSqlPrivateLinkResourceProperties(
                groupId,
                (requiredMembers ?? new List<string>()).ToList(),
                new List<string>(),
                additionalBinaryDataProperties: null);
        }
    }
}
