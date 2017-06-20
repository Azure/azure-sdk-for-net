// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition
{
    using Microsoft.Azure.Management.Redis.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.Redis.Fluent.Models;
    using System;

    /// <summary>
    /// A Redis Cache definition with sufficient inputs to create a new
    /// Redis Cache in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Redis.Fluent.IRedisCache>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithCreate>
    {
        /// <summary>
        /// Enables non-ssl Redis server port (6379).
        /// </summary>
        /// <return>The next stage of Redis Cache definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithCreate WithNonSslPort();

        /// <summary>
        /// Assigns the specified subnet to this instance of Redis Cache.
        /// </summary>
        /// <param name="network">Instance of Network object.</param>
        /// <param name="subnetName">The name of the subnet.</param>
        /// <return>The next stage of Redis Cache definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithCreate WithSubnet(IHasId network, string subnetName);

        /// <summary>
        /// Sets Redis Cache static IP. Required when deploying a Redis Cache inside an existing Azure Virtual Network.
        /// </summary>
        /// <param name="staticIP">The static IP value to set.</param>
        /// <return>The next stage of Redis Cache definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithCreate WithStaticIP(string staticIP);

        /// <summary>
        /// All Redis Settings. Few possible keys:
        /// rdb-backup-enabled, rdb-storage-connection-string, rdb-backup-frequency, maxmemory-delta, maxmemory-policy,
        /// notify-keyspace-events, maxmemory-samples, slowlog-log-slower-than, slowlog-max-len, list-max-ziplist-entries,
        /// list-max-ziplist-value, hash-max-ziplist-entries, hash-max-ziplist-value, set -max-intset-entries,
        /// zset-max-ziplist-entries, zset-max-ziplist-value etc.
        /// </summary>
        /// <param name="redisConfiguration">Configuration of Redis Cache as a map indexed by configuration name.</param>
        /// <return>The next stage of Redis Cache definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithCreate WithRedisConfiguration(IDictionary<string,string> redisConfiguration);

        /// <summary>
        /// Specifies Redis Setting.
        /// rdb-backup-enabled, rdb-storage-connection-string, rdb-backup-frequency, maxmemory-delta, maxmemory-policy,
        /// notify-keyspace-events, maxmemory-samples, slowlog-log-slower-than, slowlog-max-len, list-max-ziplist-entries,
        /// list-max-ziplist-value, hash-max-ziplist-entries, hash-max-ziplist-value, set -max-intset-entries,
        /// zset-max-ziplist-entries, zset-max-ziplist-value etc.
        /// </summary>
        /// <param name="key">Redis configuration name.</param>
        /// <param name="value">Redis configuration value.</param>
        /// <return>The next stage of Redis Cache definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithCreate WithRedisConfiguration(string key, string value);
    }

    /// <summary>
    /// The first stage of the Redis Cache definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// A Redis Cache definition allowing the sku to be set.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the Premium sku of the Redis Cache.
        /// </summary>
        /// <return>The next stage of Redis Cache definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithPremiumSkuCreate WithPremiumSku();

        /// <summary>
        /// Specifies the Premium sku of the Redis Cache.
        /// </summary>
        /// <param name="capacity">Specifies what size of Redis Cache to deploy for Standard sku with P family (1, 2, 3, 4).</param>
        /// <return>The next stage of Redis Cache definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithPremiumSkuCreate WithPremiumSku(int capacity);

        /// <summary>
        /// Specifies the Basic sku of the Redis Cache.
        /// </summary>
        /// <return>The next stage of Redis Cache definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithCreate WithBasicSku();

        /// <summary>
        /// Specifies the Basic sku of the Redis Cache.
        /// </summary>
        /// <param name="capacity">Specifies what size of Redis Cache to deploy for Basic sku with C family (0, 1, 2, 3, 4, 5, 6).</param>
        /// <return>The next stage of Redis Cache definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithCreate WithBasicSku(int capacity);

        /// <summary>
        /// Specifies the Standard Sku of the Redis Cache.
        /// </summary>
        /// <return>The next stage of Redis Cache definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithCreate WithStandardSku();

        /// <summary>
        /// Specifies the Standard sku of the Redis Cache.
        /// </summary>
        /// <param name="capacity">Specifies what size of Redis Cache to deploy for Standard sku with C family (0, 1, 2, 3, 4, 5, 6).</param>
        /// <return>The next stage of Redis Cache definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithCreate WithStandardSku(int capacity);
    }

    /// <summary>
    /// A Redis Cache definition allowing resource group to be set.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithSku>
    {
    }

    /// <summary>
    /// A Redis Cache definition with Premium Sku specific functionality.
    /// </summary>
    public interface IWithPremiumSkuCreate  :
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithCreate
    {
        /// <summary>
        /// The number of shards to be created on a Premium Cluster Cache.
        /// </summary>
        /// <param name="shardCount">The shard count value to set.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithPremiumSkuCreate WithShardCount(int shardCount);

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="dayOfWeek">Day of week when cache can be patched.</param>
        /// <param name="startHourUtc">Start hour after which cache patching can start.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithPremiumSkuCreate WithPatchSchedule(Microsoft.Azure.Management.Redis.Fluent.Models.DayOfWeek dayOfWeek, int startHourUtc);

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="dayOfWeek">Day of week when cache can be patched.</param>
        /// <param name="startHourUtc">Start hour after which cache patching can start.</param>
        /// <param name="maintenanceWindow">ISO8601 timespan specifying how much time cache patching can take.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithPremiumSkuCreate WithPatchSchedule(Microsoft.Azure.Management.Redis.Fluent.Models.DayOfWeek dayOfWeek, int startHourUtc, TimeSpan maintenanceWindow);

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="scheduleEntry">Patch schedule entry for Premium Redis Cache.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithPremiumSkuCreate WithPatchSchedule(ScheduleEntry scheduleEntry);

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="scheduleEntry">List of patch schedule entries for Premium Redis Cache.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithPremiumSkuCreate WithPatchSchedule(IList<Microsoft.Azure.Management.Redis.Fluent.Models.ScheduleEntry> scheduleEntry);
    }

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IBlank,
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithGroup,
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithSku,
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithCreate,
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IWithPremiumSkuCreate
    {
    }
}