// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Redis.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Redis.Models
{
    public static partial class ArmRedisModelFactory
    {
        // Custom factory method for RedisData is needed because the generated RedisData constructor takes a
        // flattened RedisProperties parameter (due to property customizations in RedisData.cs that delegate to
        // Properties.*), while the generated backward-compat overloads in ArmRedisModelFactory pass individual
        // property values with zones and identity at the end. This method bridges the gap by accepting the
        // individual parameters in the order the backward-compat overloads expect and constructing the
        // RedisProperties object internally.
        /// <summary> Initializes a new instance of <see cref="Redis.RedisData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RedisData RedisData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, RedisCommonConfiguration redisConfiguration, string redisVersion, bool? enableNonSslPort, int? replicasPerMaster, int? replicasPerPrimary, IDictionary<string, string> tenantSettings, int? shardCount, RedisTlsVersion? minimumTlsVersion, RedisPublicNetworkAccess? publicNetworkAccess, UpdateChannel? updateChannel, bool? isAccessKeyAuthenticationDisabled, ZonalAllocationPolicy? zonalAllocationPolicy, RedisSku sku, ResourceIdentifier subnetId, IPAddress staticIP, RedisProvisioningState? provisioningState, string hostName, int? port, int? sslPort, RedisAccessKeys accessKeys, IEnumerable<SubResource> linkedServers, IEnumerable<RedisInstanceDetails> instances, IEnumerable<RedisPrivateEndpointConnectionData> privateEndpointConnections, IEnumerable<string> zones, ManagedServiceIdentity identity)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();
            zones ??= new ChangeTrackingList<string>();
            tenantSettings ??= new ChangeTrackingDictionary<string, string>();
            linkedServers ??= new ChangeTrackingList<SubResource>();
            instances ??= new ChangeTrackingList<RedisInstanceDetails>();
            privateEndpointConnections ??= new ChangeTrackingList<RedisPrivateEndpointConnectionData>();

            return new RedisData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                location,
                new RedisProperties(
                    redisConfiguration,
                    redisVersion,
                    enableNonSslPort,
                    replicasPerMaster,
                    replicasPerPrimary,
                    tenantSettings,
                    shardCount,
                    minimumTlsVersion,
                    publicNetworkAccess,
                    updateChannel,
                    isAccessKeyAuthenticationDisabled,
                    zonalAllocationPolicy,
                    additionalBinaryDataProperties: null,
                    sku,
                    subnetId,
                    staticIP,
                    provisioningState,
                    hostName,
                    port,
                    sslPort,
                    accessKeys,
                    linkedServers.ToList(),
                    instances.ToList(),
                    privateEndpointConnections.ToList()),
                zones.ToList(),
                identity);
        }

        /// <summary> Old-signature overload for backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RedisCreateOrUpdateContent RedisCreateOrUpdateContent(IEnumerable<string> zones, AzureLocation location, IDictionary<string, string> tags, ManagedServiceIdentity identity, RedisCommonConfiguration redisConfiguration, string redisVersion, bool? enableNonSslPort, int? replicasPerMaster, int? replicasPerPrimary, IDictionary<string, string> tenantSettings, int? shardCount, RedisTlsVersion? minimumTlsVersion, RedisPublicNetworkAccess? publicNetworkAccess, UpdateChannel? updateChannel, bool? isAccessKeyAuthenticationDisabled, RedisSku sku, ResourceIdentifier subnetId, IPAddress staticIP)
        {
            return RedisCreateOrUpdateContent(zones: zones, location: location, tags: tags, identity: identity, redisConfiguration: redisConfiguration, redisVersion: redisVersion, enableNonSslPort: enableNonSslPort, replicasPerMaster: replicasPerMaster, replicasPerPrimary: replicasPerPrimary, tenantSettings: tenantSettings, shardCount: shardCount, minimumTlsVersion: minimumTlsVersion, publicNetworkAccess: publicNetworkAccess, updateChannel: updateChannel, isAccessKeyAuthenticationDisabled: isAccessKeyAuthenticationDisabled, zonalAllocationPolicy: default, sku: sku, subnetId: subnetId, staticIP: staticIP);
        }

        /// <summary> Old-signature overload for backward compatibility (without isAccessKeyAuthenticationDisabled). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RedisCreateOrUpdateContent RedisCreateOrUpdateContent(IEnumerable<string> zones, AzureLocation location, IDictionary<string, string> tags, ManagedServiceIdentity identity, RedisCommonConfiguration redisConfiguration, string redisVersion, bool? enableNonSslPort, int? replicasPerMaster, int? replicasPerPrimary, IDictionary<string, string> tenantSettings, int? shardCount, RedisTlsVersion? minimumTlsVersion, RedisPublicNetworkAccess? publicNetworkAccess, UpdateChannel? updateChannel, RedisSku sku, ResourceIdentifier subnetId, IPAddress staticIP)
        {
            return RedisCreateOrUpdateContent(zones: zones, location: location, tags: tags, identity: identity, redisConfiguration: redisConfiguration, redisVersion: redisVersion, enableNonSslPort: enableNonSslPort, replicasPerMaster: replicasPerMaster, replicasPerPrimary: replicasPerPrimary, tenantSettings: tenantSettings, shardCount: shardCount, minimumTlsVersion: minimumTlsVersion, publicNetworkAccess: publicNetworkAccess, updateChannel: updateChannel, isAccessKeyAuthenticationDisabled: default, zonalAllocationPolicy: default, sku: sku, subnetId: subnetId, staticIP: staticIP);
        }

        /// <summary> Old-signature overload for backward compatibility (non-nullable AzureLocation and RedisLinkedServerRole). </summary>
        public static RedisLinkedServerWithPropertyCreateOrUpdateContent RedisLinkedServerWithPropertyCreateOrUpdateContent(ResourceIdentifier linkedRedisCacheId = default, AzureLocation? linkedRedisCacheLocation = default, RedisLinkedServerRole? serverRole = default, string geoReplicatedPrimaryHostName = default, string primaryHostName = default)
        {
            return new RedisLinkedServerWithPropertyCreateOrUpdateContent(
                new RedisLinkedServerCreateProperties(
                    linkedRedisCacheId,
                    linkedRedisCacheLocation.GetValueOrDefault(),
                    serverRole.GetValueOrDefault(),
                    geoReplicatedPrimaryHostName,
                    primaryHostName,
                    null),
                additionalBinaryDataProperties: null);
        }

        /// <summary> Old-signature overload for backward compatibility (non-nullable AzureLocation and RedisLinkedServerRole). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RedisLinkedServerWithPropertyCreateOrUpdateContent RedisLinkedServerWithPropertyCreateOrUpdateContent(ResourceIdentifier linkedRedisCacheId, AzureLocation linkedRedisCacheLocation, RedisLinkedServerRole serverRole, string geoReplicatedPrimaryHostName, string primaryHostName)
        {
            return RedisLinkedServerWithPropertyCreateOrUpdateContent(linkedRedisCacheId, (AzureLocation?)linkedRedisCacheLocation, (RedisLinkedServerRole?)serverRole, geoReplicatedPrimaryHostName, primaryHostName);
        }
    }
}
