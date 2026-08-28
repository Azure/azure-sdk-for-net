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
    // The generator's auto-emitted backward-compat factory overloads call the modern
    // factory using positional arguments in MODEL FIELD ORDER rather than the modern
    // factory's parameter order, producing CS1739 compile errors. The hand-rolled
    // back-compat overloads here delegate using named arguments to side-step the bug.
    // Tracked in https://github.com/Azure/azure-sdk-for-net/issues/58688
    //
    // TODO: Once the generator bug is fixed, delete this file and rely on the
    // generator's public factory and back-compat overloads.
    public static partial class ArmRedisModelFactory
    {
        /// <summary> Old-signature overload for backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RedisCreateOrUpdateContent RedisCreateOrUpdateContent(IEnumerable<string> zones, AzureLocation location, IDictionary<string, string> tags, ManagedServiceIdentity identity, RedisCommonConfiguration redisConfiguration, string redisVersion, bool? enableNonSslPort, int? replicasPerMaster, int? replicasPerPrimary, IDictionary<string, string> tenantSettings, int? shardCount, RedisTlsVersion? minimumTlsVersion, RedisPublicNetworkAccess? publicNetworkAccess, UpdateChannel? updateChannel, bool? isAccessKeyAuthenticationDisabled, RedisSku sku, ResourceIdentifier subnetId, IPAddress staticIP)
        {
            return new RedisCreateOrUpdateContent(
                redisConfiguration is null && redisVersion is null && enableNonSslPort is null && replicasPerMaster is null && replicasPerPrimary is null && tenantSettings is null && shardCount is null && minimumTlsVersion is null && publicNetworkAccess is null && updateChannel is null && isAccessKeyAuthenticationDisabled is null && sku is null && subnetId is null && staticIP is null ? default : new RedisCreateProperties(
                    redisConfiguration,
                    redisVersion,
                    enableNonSslPort,
                    replicasPerMaster,
                    replicasPerPrimary,
                    tenantSettings ?? new ChangeTrackingDictionary<string, string>(),
                    shardCount,
                    minimumTlsVersion,
                    publicNetworkAccess,
                    updateChannel,
                    isAccessKeyAuthenticationDisabled,
                    default,
                    default,
                    sku,
                    subnetId,
                    staticIP),
                (zones ?? new ChangeTrackingList<string>()).ToList(),
                location,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                identity,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Old-signature overload for backward compatibility (without isAccessKeyAuthenticationDisabled). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RedisCreateOrUpdateContent RedisCreateOrUpdateContent(IEnumerable<string> zones, AzureLocation location, IDictionary<string, string> tags, ManagedServiceIdentity identity, RedisCommonConfiguration redisConfiguration, string redisVersion, bool? enableNonSslPort, int? replicasPerMaster, int? replicasPerPrimary, IDictionary<string, string> tenantSettings, int? shardCount, RedisTlsVersion? minimumTlsVersion, RedisPublicNetworkAccess? publicNetworkAccess, UpdateChannel? updateChannel, RedisSku sku, ResourceIdentifier subnetId, IPAddress staticIP)
        {
            return RedisCreateOrUpdateContent(
                zones,
                location,
                tags,
                identity,
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
                default,
                sku,
                subnetId,
                staticIP);
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
