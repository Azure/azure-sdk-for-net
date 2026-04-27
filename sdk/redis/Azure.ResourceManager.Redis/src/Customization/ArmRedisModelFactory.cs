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

namespace Azure.ResourceManager.Redis.Models
{
    public static partial class ArmRedisModelFactory
    {
        /// <summary> Backward-compat overload where zones and identity are at the end of the parameter list. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RedisData RedisData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, RedisCommonConfiguration redisConfiguration, string redisVersion, bool? enableNonSslPort, int? replicasPerMaster, int? replicasPerPrimary, IDictionary<string, string> tenantSettings, int? shardCount, RedisTlsVersion? minimumTlsVersion, RedisPublicNetworkAccess? publicNetworkAccess, UpdateChannel? updateChannel, bool? isAccessKeyAuthenticationDisabled, ZonalAllocationPolicy? zonalAllocationPolicy, RedisSku sku, ResourceIdentifier subnetId, IPAddress staticIP, RedisProvisioningState? provisioningState, string hostName, int? port, int? sslPort, RedisAccessKeys accessKeys, IEnumerable<SubResource> linkedServers, IEnumerable<RedisInstanceDetails> instances, IEnumerable<RedisPrivateEndpointConnectionData> privateEndpointConnections, IEnumerable<string> zones, ManagedServiceIdentity identity)
        {
            tenantSettings ??= new ChangeTrackingDictionary<string, string>();
            linkedServers ??= new ChangeTrackingList<SubResource>();
            instances ??= new ChangeTrackingList<RedisInstanceDetails>();
            privateEndpointConnections ??= new ChangeTrackingList<RedisPrivateEndpointConnectionData>();

            // Delegate to the generated public factory method (zones/identity early) for base construction
            var result = RedisData(id, name, resourceType, systemData, tags, location, zones, identity, redisConfiguration, redisVersion, enableNonSslPort, replicasPerMaster, replicasPerPrimary, tenantSettings, shardCount, minimumTlsVersion, publicNetworkAccess, updateChannel, isAccessKeyAuthenticationDisabled, zonalAllocationPolicy, sku, subnetId, staticIP, provisioningState, hostName, port, sslPort, accessKeys, linkedServers, instances, privateEndpointConnections);
            // The generated factory doesn't populate Properties (requires @flattenProperty in TypeSpec).
            // Manually construct it so redis-specific values are preserved for mocking.
            result.Properties = new RedisProperties(
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
                privateEndpointConnections.ToList(),
                targetAmrResourceId: default);
            return result;
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
