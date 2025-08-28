// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.ResourceManager.Redis.Models
{
    public partial class RedisCreateOrUpdateContent
    {
        /// <summary> All Redis Settings. Few possible keys: rdb-backup-enabled,rdb-storage-connection-string,rdb-backup-frequency,maxmemory-delta, maxmemory-policy,notify-keyspace-events, aof-backup-enabled, aof-storage-connection-string-0, aof-storage-connection-string-1 etc. </summary>
        [WirePath("properties.redisConfiguration")]
        public RedisCommonConfiguration RedisConfiguration { get; set; }
        /// <summary> Redis version. This should be in the form 'major[.minor]' (only 'major' is required) or the value 'latest' which refers to the latest stable Redis version that is available. Supported versions: 4.0, 6.0 (latest). Default value is 'latest'. </summary>
        [WirePath("properties.redisVersion")]
        public string RedisVersion { get; set; }
        /// <summary> Specifies whether the non-ssl Redis server port (6379) is enabled. </summary>
        [WirePath("properties.enableNonSslPort")]
        public bool? EnableNonSslPort { get; set; }
        /// <summary> The number of replicas to be created per primary. </summary>
        [WirePath("properties.replicasPerMaster")]
        public int? ReplicasPerMaster { get; set; }
        /// <summary> The number of replicas to be created per primary. </summary>
        [WirePath("properties.replicasPerPrimary")]
        public int? ReplicasPerPrimary { get; set; }
        /// <summary> A dictionary of tenant settings. </summary>
        [WirePath("properties.tenantSettings")]
        public IDictionary<string, string> TenantSettings { get; }
        /// <summary> The number of shards to be created on a Premium Cluster Cache. </summary>
        [WirePath("properties.shardCount")]
        public int? ShardCount { get; set; }
        /// <summary> Optional: requires clients to use a specified TLS version (or higher) to connect (e,g, '1.0', '1.1', '1.2'). </summary>
        [WirePath("properties.minimumTlsVersion")]
        public RedisTlsVersion? MinimumTlsVersion { get; set; }
        /// <summary> Whether or not public endpoint access is allowed for this cache.  Value is optional but if passed in, must be 'Enabled' or 'Disabled'. If 'Disabled', private endpoints are the exclusive access method. Default value is 'Enabled'. </summary>
        [WirePath("properties.publicNetworkAccess")]
        public RedisPublicNetworkAccess? PublicNetworkAccess { get; set; }
        /// <summary> Optional: Specifies the update channel for the monthly Redis updates your Redis Cache will receive. Caches using 'Preview' update channel get latest Redis updates at least 4 weeks ahead of 'Stable' channel caches. Default value is 'Stable'. </summary>
        [WirePath("properties.updateChannel")]
        public UpdateChannel? UpdateChannel { get; set; }
        /// <summary> Authentication to Redis through access keys is disabled when set as true. Default value is false. </summary>
        [WirePath("properties.disableAccessKeyAuthentication")]
        public bool? IsAccessKeyAuthenticationDisabled { get; set; }
        /// <summary> Optional: Specifies how availability zones are allocated to the Redis cache. 'Automatic' enables zone redundancy and Azure will automatically select zones based on regional availability and capacity. 'UserDefined' will select availability zones passed in by you using the 'zones' parameter. 'NoZones' will produce a non-zonal cache. If 'zonalAllocationPolicy' is not passed, it will be set to 'UserDefined' when zones are passed in, otherwise, it will be set to 'Automatic' in regions where zones are supported and 'NoZones' in regions where zones are not supported. </summary>
        [WirePath("properties.zonalAllocationPolicy")]
        public ZonalAllocationPolicy? ZonalAllocationPolicy { get; set; }
    }
}
