// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Redis.Fluent.Models;
    using Microsoft.Azure.Management.Redis.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;

    /// <summary>
    /// A Redis Cache update allowing Redis configuration to be modified.
    /// </summary>
    public interface IWithRedisConfiguration 
    {
        /// <summary>
        /// Cleans all the configuration settings being set on Redis Cache.
        /// </summary>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithoutRedisConfiguration();

        /// <summary>
        /// Removes specified Redis Cache configuration setting.
        /// </summary>
        /// <param name="key">Redis configuration name.</param>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithoutRedisConfiguration(string key);

        /// <summary>
        /// All Redis Settings. Few possible keys:
        /// rdb-backup-enabled, rdb-storage-connection-string, rdb-backup-frequency, maxmemory-delta, maxmemory-policy,
        /// notify-keyspace-events, maxmemory-samples, slowlog-log-slower-than, slowlog-max-len, list-max-ziplist-entries,
        /// list-max-ziplist-value, hash-max-ziplist-entries, hash-max-ziplist-value, set -max-intset-entries,
        /// zset-max-ziplist-entries, zset-max-ziplist-value etc.
        /// </summary>
        /// <param name="redisConfiguration">Configuration of Redis Cache as a map indexed by configuration name.</param>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithRedisConfiguration(IDictionary<string,string> redisConfiguration);

        /// <summary>
        /// Specifies Redis Setting.
        /// rdb-backup-enabled, rdb-storage-connection-string, rdb-backup-frequency, maxmemory-delta, maxmemory-policy,
        /// notify-keyspace-events, maxmemory-samples, slowlog-log-slower-than, slowlog-max-len, list-max-ziplist-entries,
        /// list-max-ziplist-value, hash-max-ziplist-entries, hash-max-ziplist-value, set -max-intset-entries,
        /// zset-max-ziplist-entries, zset-max-ziplist-value etc.
        /// </summary>
        /// <param name="key">Redis configuration name.</param>
        /// <param name="value">Redis configuration value.</param>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithRedisConfiguration(string key, string value);
    }

    /// <summary>
    /// The template for a Redis Cache update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Redis.Fluent.IRedisCache>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate>,
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IWithSku,
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IWithNonSslPort,
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IWithRedisConfiguration
    {
        /// <summary>
        /// Assigns the specified subnet to this instance of Redis Cache.
        /// </summary>
        /// <param name="networkResource">Instance of Network object.</param>
        /// <param name="subnetName">The name of the subnet.</param>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithSubnet(IHasId networkResource, string subnetName);

        /// <summary>
        /// Sets Redis Cache static IP. Required when deploying a Redis Cache inside an existing Azure Virtual Network.
        /// </summary>
        /// <param name="staticIP">The staticIP value to set.</param>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithStaticIP(string staticIP);

        /// <summary>
        /// The number of shards to be created on a Premium Cluster Cache.
        /// </summary>
        /// <param name="shardCount">The shard count value to set.</param>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithShardCount(int shardCount);

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="dayOfWeek">Day of week when cache can be patched.</param>
        /// <param name="startHourUtc">Start hour after which cache patching can start.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithPatchSchedule(Microsoft.Azure.Management.Redis.Fluent.Models.DayOfWeek dayOfWeek, int startHourUtc);

        /// <summary>
        /// The number of shards to be created on a Premium Cluster Cache.
        /// </summary>
        /// <param name="dayOfWeek">Day of week when cache can be patched.</param>
        /// <param name="startHourUtc">Start hour after which cache patching can start.</param>
        /// <param name="maintenanceWindow">ISO8601 timespan specifying how much time cache patching can take.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithPatchSchedule(Microsoft.Azure.Management.Redis.Fluent.Models.DayOfWeek dayOfWeek, int startHourUtc, TimeSpan maintenanceWindow);

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="scheduleEntry">Patch schedule entry for Premium Redis Cache.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithPatchSchedule(ScheduleEntry scheduleEntry);

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="scheduleEntry">List of patch schedule entries for Premium Redis Cache.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithPatchSchedule(IList<Microsoft.Azure.Management.Redis.Fluent.Models.ScheduleEntry> scheduleEntry);
    }

    /// <summary>
    /// A Redis Cache update allowing non SSL port to be enabled or disabled.
    /// </summary>
    public interface IWithNonSslPort 
    {
        /// <summary>
        /// Enables non-ssl Redis server port (6379).
        /// </summary>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithNonSslPort();

        /// <summary>
        /// Disables non-ssl Redis server port (6379).
        /// </summary>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithoutNonSslPort();
    }

    /// <summary>
    /// A Redis Cache update stage allowing to change the parameters.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Updates Redis Cache to Premium sku.
        /// </summary>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithPremiumSku();

        /// <summary>
        /// Updates Redis Cache to Premium sku with new capacity.
        /// </summary>
        /// <param name="capacity">Specifies what size of Redis Cache to update to for Premium sku with P family (1, 2, 3, 4).</param>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithPremiumSku(int capacity);

        /// <summary>
        /// Updates Redis Cache to Basic sku with new capacity.
        /// </summary>
        /// <param name="capacity">Specifies what size of Redis Cache to update to for Basic sku with C family (0, 1, 2, 3, 4, 5, 6).</param>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithBasicSku(int capacity);

        /// <summary>
        /// Updates Redis Cache to Standard sku.
        /// </summary>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithStandardSku();

        /// <summary>
        /// Updates Redis Cache to Standard sku with new capacity.
        /// </summary>
        /// <param name="capacity">Specifies what size of Redis Cache to update to for Standard sku with C family (0, 1, 2, 3, 4, 5, 6).</param>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithStandardSku(int capacity);
    }
}