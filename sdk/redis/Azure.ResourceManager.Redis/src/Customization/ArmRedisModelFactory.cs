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
