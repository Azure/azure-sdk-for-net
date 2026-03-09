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
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Redis.Models
{
    [CodeGenSuppress("RedisData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(RedisCommonConfiguration), typeof(string), typeof(bool?), typeof(int?), typeof(int?), typeof(IDictionary<string, string>), typeof(int?), typeof(RedisTlsVersion?), typeof(RedisPublicNetworkAccess?), typeof(UpdateChannel?), typeof(bool?), typeof(ZonalAllocationPolicy?), typeof(RedisSku), typeof(ResourceIdentifier), typeof(IPAddress), typeof(RedisProvisioningState?), typeof(string), typeof(int?), typeof(int?), typeof(RedisAccessKeys), typeof(IEnumerable<RedisLinkedServer>), typeof(IEnumerable<RedisInstanceDetails>), typeof(IEnumerable<RedisPrivateEndpointConnectionData>), typeof(IEnumerable<string>), typeof(ManagedServiceIdentity))]
    public static partial class ArmRedisModelFactory
    {
        /// <summary> Private implementation to avoid overload resolution ambiguity among public RedisData overloads. </summary>
        private static RedisData RedisDataCore(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, RedisCommonConfiguration redisConfiguration, string redisVersion, bool? enableNonSslPort, int? replicasPerMaster, int? replicasPerPrimary, IDictionary<string, string> tenantSettings, int? shardCount, RedisTlsVersion? minimumTlsVersion, RedisPublicNetworkAccess? publicNetworkAccess, UpdateChannel? updateChannel, bool? isAccessKeyAuthenticationDisabled, ZonalAllocationPolicy? zonalAllocationPolicy, RedisSku sku, ResourceIdentifier subnetId, IPAddress staticIP, RedisProvisioningState? provisioningState, string hostName, int? port, int? sslPort, RedisAccessKeys accessKeys, IEnumerable<SubResource> linkedServers, IEnumerable<RedisInstanceDetails> instances, IEnumerable<RedisPrivateEndpointConnectionData> privateEndpointConnections, IEnumerable<string> zones, ManagedServiceIdentity identity)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();
            zones ??= new ChangeTrackingList<string>();
            var linkedServersList = linkedServers?.Select(s => new RedisLinkedServer(s.Id?.ToString(), null)).ToList();

            return new RedisData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                location,
                redisConfiguration is null && redisVersion is null && enableNonSslPort is null && replicasPerMaster is null && replicasPerPrimary is null && tenantSettings is null && shardCount is null && minimumTlsVersion is null && publicNetworkAccess is null && updateChannel is null && isAccessKeyAuthenticationDisabled is null && zonalAllocationPolicy is null && sku is null && subnetId is null && staticIP is null && provisioningState is null && hostName is null && port is null && sslPort is null && accessKeys is null && linkedServers is null && instances is null && privateEndpointConnections is null ? default : new RedisProperties(
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
                    null,
                    sku,
                    subnetId,
                    staticIP,
                    provisioningState,
                    hostName,
                    port,
                    sslPort,
                    accessKeys,
                    linkedServersList ?? new List<RedisLinkedServer>(),
                    (instances ?? new ChangeTrackingList<RedisInstanceDetails>()).ToList(),
                    (privateEndpointConnections ?? new ChangeTrackingList<RedisPrivateEndpointConnectionData>()).ToList()),
                zones.ToList(),
                identity);
        }

        /// <summary> Initializes a new instance of <see cref="Redis.RedisData"/>. </summary>
        /// <returns> A new <see cref="Redis.RedisData"/> instance for mocking. </returns>
        public static RedisData RedisData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default, RedisCommonConfiguration redisConfiguration = default, string redisVersion = default, bool? enableNonSslPort = default, int? replicasPerMaster = default, int? replicasPerPrimary = default, IDictionary<string, string> tenantSettings = default, int? shardCount = default, RedisTlsVersion? minimumTlsVersion = default, RedisPublicNetworkAccess? publicNetworkAccess = default, UpdateChannel? updateChannel = default, bool? isAccessKeyAuthenticationDisabled = default, ZonalAllocationPolicy? zonalAllocationPolicy = default, RedisSku sku = default, ResourceIdentifier subnetId = default, IPAddress staticIP = default, RedisProvisioningState? provisioningState = default, string hostName = default, int? port = default, int? sslPort = default, RedisAccessKeys accessKeys = default, IEnumerable<SubResource> linkedServers = default, IEnumerable<RedisInstanceDetails> instances = default, IEnumerable<RedisPrivateEndpointConnectionData> privateEndpointConnections = default, IEnumerable<string> zones = default, ManagedServiceIdentity identity = default)
        {
            return RedisDataCore(id, name, resourceType, systemData, tags, location, redisConfiguration, redisVersion, enableNonSslPort, replicasPerMaster, replicasPerPrimary, tenantSettings, shardCount, minimumTlsVersion, publicNetworkAccess, updateChannel, isAccessKeyAuthenticationDisabled, zonalAllocationPolicy, sku, subnetId, staticIP, provisioningState, hostName, port, sslPort, accessKeys, linkedServers, instances, privateEndpointConnections, zones, identity);
        }

        /// <summary> Old-signature overload for backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RedisData RedisData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, IEnumerable<string> zones, ManagedServiceIdentity identity, RedisCommonConfiguration redisConfiguration, string redisVersion, bool? enableNonSslPort, int? replicasPerMaster, int? replicasPerPrimary, IDictionary<string, string> tenantSettings, int? shardCount, RedisTlsVersion? minimumTlsVersion, RedisPublicNetworkAccess? publicNetworkAccess, UpdateChannel? updateChannel, bool? isAccessKeyAuthenticationDisabled, ZonalAllocationPolicy? zonalAllocationPolicy, RedisSku sku, ResourceIdentifier subnetId, IPAddress staticIP, RedisProvisioningState? provisioningState, string hostName, int? port, int? sslPort, RedisAccessKeys accessKeys, IEnumerable<SubResource> linkedServers, IEnumerable<RedisInstanceDetails> instances, IEnumerable<RedisPrivateEndpointConnectionData> privateEndpointConnections)
        {
            return RedisDataCore(id, name, resourceType, systemData, tags, location, redisConfiguration, redisVersion, enableNonSslPort, replicasPerMaster, replicasPerPrimary, tenantSettings, shardCount, minimumTlsVersion, publicNetworkAccess, updateChannel, isAccessKeyAuthenticationDisabled, zonalAllocationPolicy, sku, subnetId, staticIP, provisioningState, hostName, port, sslPort, accessKeys, linkedServers, instances, privateEndpointConnections, zones, identity);
        }

        /// <summary> Old-signature overload for backward compatibility (without zonalAllocationPolicy). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RedisData RedisData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, IEnumerable<string> zones, ManagedServiceIdentity identity, RedisCommonConfiguration redisConfiguration, string redisVersion, bool? enableNonSslPort, int? replicasPerMaster, int? replicasPerPrimary, IDictionary<string, string> tenantSettings, int? shardCount, RedisTlsVersion? minimumTlsVersion, RedisPublicNetworkAccess? publicNetworkAccess, UpdateChannel? updateChannel, bool? isAccessKeyAuthenticationDisabled, RedisSku sku, ResourceIdentifier subnetId, IPAddress staticIP, RedisProvisioningState? provisioningState, string hostName, int? port, int? sslPort, RedisAccessKeys accessKeys, IEnumerable<SubResource> linkedServers, IEnumerable<RedisInstanceDetails> instances, IEnumerable<RedisPrivateEndpointConnectionData> privateEndpointConnections)
        {
            return RedisDataCore(id, name, resourceType, systemData, tags, location, redisConfiguration, redisVersion, enableNonSslPort, replicasPerMaster, replicasPerPrimary, tenantSettings, shardCount, minimumTlsVersion, publicNetworkAccess, updateChannel, isAccessKeyAuthenticationDisabled, default, sku, subnetId, staticIP, provisioningState, hostName, port, sslPort, accessKeys, linkedServers, instances, privateEndpointConnections, zones, identity);
        }

        /// <summary> Old-signature overload for backward compatibility (without isAccessKeyAuthenticationDisabled, zonalAllocationPolicy). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RedisData RedisData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, IEnumerable<string> zones, ManagedServiceIdentity identity, RedisCommonConfiguration redisConfiguration, string redisVersion, bool? enableNonSslPort, int? replicasPerMaster, int? replicasPerPrimary, IDictionary<string, string> tenantSettings, int? shardCount, RedisTlsVersion? minimumTlsVersion, RedisPublicNetworkAccess? publicNetworkAccess, UpdateChannel? updateChannel, RedisSku sku, ResourceIdentifier subnetId, IPAddress staticIP, RedisProvisioningState? provisioningState, string hostName, int? port, int? sslPort, RedisAccessKeys accessKeys, IEnumerable<SubResource> linkedServers, IEnumerable<RedisInstanceDetails> instances, IEnumerable<RedisPrivateEndpointConnectionData> privateEndpointConnections)
        {
            return RedisDataCore(id, name, resourceType, systemData, tags, location, redisConfiguration, redisVersion, enableNonSslPort, replicasPerMaster, replicasPerPrimary, tenantSettings, shardCount, minimumTlsVersion, publicNetworkAccess, updateChannel, default, default, sku, subnetId, staticIP, provisioningState, hostName, port, sslPort, accessKeys, linkedServers, instances, privateEndpointConnections, zones, identity);
        }

        /// <summary> Old-signature overload for backward compatibility (without updateChannel, isAccessKeyAuthenticationDisabled, zonalAllocationPolicy). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RedisData RedisData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, IEnumerable<string> zones, ManagedServiceIdentity identity, RedisCommonConfiguration redisConfiguration, string redisVersion, bool? enableNonSslPort, int? replicasPerMaster, int? replicasPerPrimary, IDictionary<string, string> tenantSettings, int? shardCount, RedisTlsVersion? minimumTlsVersion, RedisPublicNetworkAccess? publicNetworkAccess, RedisSku sku, ResourceIdentifier subnetId, IPAddress staticIP, RedisProvisioningState? provisioningState, string hostName, int? port, int? sslPort, RedisAccessKeys accessKeys, IEnumerable<SubResource> linkedServers, IEnumerable<RedisInstanceDetails> instances, IEnumerable<RedisPrivateEndpointConnectionData> privateEndpointConnections)
        {
            return RedisDataCore(id, name, resourceType, systemData, tags, location, redisConfiguration, redisVersion, enableNonSslPort, replicasPerMaster, replicasPerPrimary, tenantSettings, shardCount, minimumTlsVersion, publicNetworkAccess, default, default, default, sku, subnetId, staticIP, provisioningState, hostName, port, sslPort, accessKeys, linkedServers, instances, privateEndpointConnections, zones, identity);
        }

        /// <param name="zones"></param>
        /// <param name="location"></param>
        /// <param name="tags"></param>
        /// <param name="identity"></param>
        /// <param name="redisConfiguration"></param>
        /// <param name="redisVersion"></param>
        /// <param name="enableNonSslPort"></param>
        /// <param name="replicasPerMaster"></param>
        /// <param name="replicasPerPrimary"></param>
        /// <param name="tenantSettings"></param>
        /// <param name="shardCount"></param>
        /// <param name="minimumTlsVersion"></param>
        /// <param name="publicNetworkAccess"></param>
        /// <param name="updateChannel"></param>
        /// <param name="isAccessKeyAuthenticationDisabled"></param>
        /// <param name="sku"></param>
        /// <param name="subnetId"></param>
        /// <param name="staticIP"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RedisCreateOrUpdateContent RedisCreateOrUpdateContent(IEnumerable<string> zones, AzureLocation location, IDictionary<string, string> tags, ManagedServiceIdentity identity, RedisCommonConfiguration redisConfiguration, string redisVersion, bool? enableNonSslPort, int? replicasPerMaster, int? replicasPerPrimary, IDictionary<string, string> tenantSettings, int? shardCount, RedisTlsVersion? minimumTlsVersion, RedisPublicNetworkAccess? publicNetworkAccess, UpdateChannel? updateChannel, bool? isAccessKeyAuthenticationDisabled, RedisSku sku, ResourceIdentifier subnetId, IPAddress staticIP)
        {
            return RedisCreateOrUpdateContent(zones: zones, location: location, tags: tags, identity: identity, redisConfiguration: redisConfiguration, redisVersion: redisVersion, enableNonSslPort: enableNonSslPort, replicasPerMaster: replicasPerMaster, replicasPerPrimary: replicasPerPrimary, tenantSettings: tenantSettings, shardCount: shardCount, minimumTlsVersion: minimumTlsVersion, publicNetworkAccess: publicNetworkAccess, updateChannel: updateChannel, isAccessKeyAuthenticationDisabled: isAccessKeyAuthenticationDisabled, zonalAllocationPolicy: default, sku: sku, subnetId: subnetId, staticIP: staticIP);
        }

        /// <param name="zones"></param>
        /// <param name="location"></param>
        /// <param name="tags"></param>
        /// <param name="identity"></param>
        /// <param name="redisConfiguration"></param>
        /// <param name="redisVersion"></param>
        /// <param name="enableNonSslPort"></param>
        /// <param name="replicasPerMaster"></param>
        /// <param name="replicasPerPrimary"></param>
        /// <param name="tenantSettings"></param>
        /// <param name="shardCount"></param>
        /// <param name="minimumTlsVersion"></param>
        /// <param name="publicNetworkAccess"></param>
        /// <param name="updateChannel"></param>
        /// <param name="sku"></param>
        /// <param name="subnetId"></param>
        /// <param name="staticIP"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RedisCreateOrUpdateContent RedisCreateOrUpdateContent(IEnumerable<string> zones, AzureLocation location, IDictionary<string, string> tags, ManagedServiceIdentity identity, RedisCommonConfiguration redisConfiguration, string redisVersion, bool? enableNonSslPort, int? replicasPerMaster, int? replicasPerPrimary, IDictionary<string, string> tenantSettings, int? shardCount, RedisTlsVersion? minimumTlsVersion, RedisPublicNetworkAccess? publicNetworkAccess, UpdateChannel? updateChannel, RedisSku sku, ResourceIdentifier subnetId, IPAddress staticIP)
        {
            return RedisCreateOrUpdateContent(zones: zones, location: location, tags: tags, identity: identity, redisConfiguration: redisConfiguration, redisVersion: redisVersion, enableNonSslPort: enableNonSslPort, replicasPerMaster: replicasPerMaster, replicasPerPrimary: replicasPerPrimary, tenantSettings: tenantSettings, shardCount: shardCount, minimumTlsVersion: minimumTlsVersion, publicNetworkAccess: publicNetworkAccess, updateChannel: updateChannel, isAccessKeyAuthenticationDisabled: default, zonalAllocationPolicy: default, sku: sku, subnetId: subnetId, staticIP: staticIP);
        }
        /// <param name="linkedRedisCacheId"> Fully qualified resourceId of the linked redis cache. </param>
        /// <param name="linkedRedisCacheLocation"> Location of the linked redis cache. </param>
        /// <param name="serverRole"> Role of the linked server. </param>
        /// <param name="geoReplicatedPrimaryHostName"> The unchanging DNS name which will always point to current geo-primary cache. </param>
        /// <param name="primaryHostName"> The changing DNS name that resolves to the current geo-primary cache. </param>
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

        /// <param name="linkedRedisCacheId"> Fully qualified resourceId of the linked redis cache. </param>
        /// <param name="linkedRedisCacheLocation"> Location of the linked redis cache. </param>
        /// <param name="serverRole"> Role of the linked server. </param>
        /// <param name="geoReplicatedPrimaryHostName"> The unchanging DNS name which will always point to current geo-primary cache. </param>
        /// <param name="primaryHostName"> The changing DNS name that resolves to the current geo-primary cache. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RedisLinkedServerWithPropertyCreateOrUpdateContent RedisLinkedServerWithPropertyCreateOrUpdateContent(ResourceIdentifier linkedRedisCacheId, AzureLocation linkedRedisCacheLocation, RedisLinkedServerRole serverRole, string geoReplicatedPrimaryHostName, string primaryHostName)
        {
            return RedisLinkedServerWithPropertyCreateOrUpdateContent(linkedRedisCacheId, (AzureLocation?)linkedRedisCacheLocation, (RedisLinkedServerRole?)serverRole, geoReplicatedPrimaryHostName, primaryHostName);
        }
    }
}
