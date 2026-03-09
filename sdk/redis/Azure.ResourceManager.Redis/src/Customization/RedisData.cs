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

namespace Azure.ResourceManager.Redis
{
    [CodeGenSuppress("RedisData", typeof(AzureLocation), typeof(RedisProperties))]
    public partial class RedisData
    {
        /// <summary> Initializes a new instance of <see cref="RedisData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="sku"> The SKU of the Redis cache to deploy. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RedisData(AzureLocation location, RedisSku sku) : base(location)
        {
            Properties = new RedisProperties() { Sku = sku };
            Zones = new ChangeTrackingList<string>();
        }

        /// <summary> List of the linked servers associated with the cache. </summary>
        [WirePath("properties.linkedServers")]
        public IReadOnlyList<SubResource> LinkedServers
        {
            get => Properties?.LinkedServers?.Select(ls => ResourceManagerModelFactory.SubResource(ls.Id != null ? new ResourceIdentifier(ls.Id) : null)).ToList();
        }

        /// <summary> The managed service identities assigned to this resource. </summary>
        [WirePath("identity")]
        public ManagedServiceIdentity Identity { get; set; }

        /// <summary> All Redis Settings. Few possible keys: rdb-backup-enabled,rdb-storage-connection-string,rdb-backup-frequency,maxmemory-delta, maxmemory-policy,notify-keyspace-events, aof-backup-enabled, aof-storage-connection-string-0, aof-storage-connection-string-1 etc. </summary>
        [WirePath("properties.redisConfiguration")]
        public RedisCommonConfiguration RedisConfiguration
        {
            get => Properties.RedisConfiguration;
            set => Properties.RedisConfiguration = value;
        }

        /// <summary> Redis version. This should be in the form 'major[.minor]' (only 'major' is required) or the value 'latest' which refers to the latest stable Redis version that is available. Supported versions: 4.0, 6.0 (latest). Default value is 'latest'. </summary>
        [WirePath("properties.redisVersion")]
        public string RedisVersion
        {
            get => Properties.RedisVersion;
            set => Properties.RedisVersion = value;
        }

        /// <summary> Specifies whether the non-ssl Redis server port (6379) is enabled. </summary>
        [WirePath("properties.enableNonSslPort")]
        public bool? EnableNonSslPort
        {
            get => Properties.EnableNonSslPort;
            set => Properties.EnableNonSslPort = value;
        }

        /// <summary> The number of replicas to be created per primary. </summary>
        [WirePath("properties.replicasPerMaster")]
        public int? ReplicasPerMaster
        {
            get => Properties.ReplicasPerMaster;
            set => Properties.ReplicasPerMaster = value;
        }

        /// <summary> The number of replicas to be created per primary. </summary>
        [WirePath("properties.replicasPerPrimary")]
        public int? ReplicasPerPrimary
        {
            get => Properties.ReplicasPerPrimary;
            set => Properties.ReplicasPerPrimary = value;
        }

        /// <summary> The number of shards to be created on a Premium Cluster Cache. </summary>
        [WirePath("properties.shardCount")]
        public int? ShardCount
        {
            get => Properties.ShardCount;
            set => Properties.ShardCount = value;
        }

        /// <summary> Optional: requires clients to use a specified TLS version (or higher) to connect (e,g, '1.0', '1.1', '1.2'). </summary>
        [WirePath("properties.minimumTlsVersion")]
        public RedisTlsVersion? MinimumTlsVersion
        {
            get => Properties.MinimumTlsVersion;
            set => Properties.MinimumTlsVersion = value;
        }

        /// <summary> Whether or not public endpoint access is allowed for this cache.  Value is optional but if passed in, must be 'Enabled' or 'Disabled'. If 'Disabled', private endpoints are the exclusive access method. </summary>
        [WirePath("properties.publicNetworkAccess")]
        public RedisPublicNetworkAccess? PublicNetworkAccess
        {
            get => Properties.PublicNetworkAccess;
            set => Properties.PublicNetworkAccess = value;
        }

        /// <summary> Optional: Specifies the update channel for the monthly Redis updates your Redis Cache will receive. Caches using 'Preview' update channel get latest Redis updates at least 4 weeks ahead of 'Stable' channel caches. Default value is 'Stable'. </summary>
        [WirePath("properties.updateChannel")]
        public UpdateChannel? UpdateChannel
        {
            get => Properties.UpdateChannel;
            set => Properties.UpdateChannel = value;
        }

        /// <summary> Authentication to Redis through access keys is disabled when set as true. Default value is false. </summary>
        [WirePath("properties.disableAccessKeyAuthentication")]
        public bool? IsAccessKeyAuthenticationDisabled
        {
            get => Properties.IsAccessKeyAuthenticationDisabled;
            set => Properties.IsAccessKeyAuthenticationDisabled = value;
        }

        /// <summary> Optional: Specifies how availability zones are allocated to the Redis cache. 'Automatic' enables zone redundancy and Azure will automatically select zones based on regional availability and capacity. 'UserDefined' will select availability zones passed in by you using the 'zones' parameter. 'NoZones' will produce a non-zonal cache. If 'zonalAllocationPolicy' is not passed, it will be set to 'UserDefined' when zones are passed in, otherwise, it will be set to 'Automatic' in regions where zones are supported and 'NoZones' in regions where zones are not supported. </summary>
        [WirePath("properties.zonalAllocationPolicy")]
        public ZonalAllocationPolicy? ZonalAllocationPolicy
        {
            get => Properties.ZonalAllocationPolicy;
            set => Properties.ZonalAllocationPolicy = value;
        }

        /// <summary> The SKU of the Redis cache to deploy. </summary>
        [WirePath("properties.sku")]
        public RedisSku Sku
        {
            get => Properties.Sku;
            set => Properties.Sku = value;
        }

        /// <summary> The full resource ID of a subnet in a virtual network to deploy the Redis cache in. Example format: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/Microsoft.{Network|ClassicNetwork}/VirtualNetworks/vnet1/subnets/subnet1. </summary>
        [WirePath("properties.subnetId")]
        public ResourceIdentifier SubnetId
        {
            get => Properties.SubnetId;
            set => Properties.SubnetId = value;
        }

        /// <summary> Static IP address. Optionally, may be specified when deploying a Redis cache inside an existing Azure Virtual Network; auto assigned by default. </summary>
        [WirePath("properties.staticIP")]
        public IPAddress StaticIP
        {
            get => Properties.StaticIP;
            set => Properties.StaticIP = value;
        }
    }
}
