// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update
{

    using System.Collections.Generic;
    using Microsoft.Azure.Management.Fluent.Redis.Models;
    using Microsoft.Azure.Management.Fluent.Redis;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using Microsoft.Azure.Management.Fluent.Resource.Core.Resource.Update;
    /// <summary>
    /// A Redis Cache update allowing non SSL port to be enabled or disabled.
    /// </summary>
    public interface IWithNonSslPort 
    {
        /// <summary>
        /// Enables non-ssl Redis server port (6379).
        /// </summary>
        /// <returns>the next stage of Redis Cache update.</returns>
        IUpdate WithNonSslPort ();

        /// <summary>
        /// Disables non-ssl Redis server port (6379).
        /// </summary>
        /// <returns>the next stage of Redis Cache update.</returns>
        IUpdate WithoutNonSslPort ();

    }
    /// <summary>
    /// A Redis Cache update allowing Redis configuration to be modified.
    /// </summary>
    public interface IWithRedisConfiguration 
    {
        /// <summary>
        /// All Redis Settings. Few possible keys:
        /// rdb-backup-enabled, rdb-storage-connection-string, rdb-backup-frequency, maxmemory-delta, maxmemory-policy,
        /// notify-keyspace-events, maxmemory-samples, slowlog-log-slower-than, slowlog-max-len, list-max-ziplist-entries,
        /// list-max-ziplist-value, hash-max-ziplist-entries, hash-max-ziplist-value, set -max-intset-entries,
        /// zset-max-ziplist-entries, zset-max-ziplist-value etc.
        /// </summary>
        /// <param name="redisConfiguration">redisConfiguration configuration of Redis Cache as a map indexed by configuration name</param>
        /// <returns>the next stage of Redis Cache update.</returns>
        IUpdate WithRedisConfiguration (IDictionary<string,string> redisConfiguration);

        /// <summary>
        /// Specifies Redis Setting.
        /// rdb-backup-enabled, rdb-storage-connection-string, rdb-backup-frequency, maxmemory-delta, maxmemory-policy,
        /// notify-keyspace-events, maxmemory-samples, slowlog-log-slower-than, slowlog-max-len, list-max-ziplist-entries,
        /// list-max-ziplist-value, hash-max-ziplist-entries, hash-max-ziplist-value, set -max-intset-entries,
        /// zset-max-ziplist-entries, zset-max-ziplist-value etc.
        /// </summary>
        /// <param name="key">key   Redis configuration name.</param>
        /// <param name="value">value Redis configuration value.</param>
        /// <returns>the next stage of Redis Cache update.</returns>
        IUpdate WithRedisConfiguration (string key, string value);

        /// <summary>
        /// Cleans all the configuration settings being set on Redis Cache.
        /// </summary>
        /// <returns>the next stage of Redis Cache update.</returns>
        IUpdate WithoutRedisConfiguration ();

        /// <summary>
        /// Removes specified Redis Cache configuration setting.
        /// </summary>
        /// <param name="key">key Redis configuration name.</param>
        /// <returns>the next stage of Redis Cache update.</returns>
        IUpdate WithoutRedisConfiguration (string key);

    }
    /// <summary>
    /// The template for a Redis Cache update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        IAppliable<IRedisCache>,
        IUpdateWithTags<IUpdate>,
        IWithSku,
        IWithNonSslPort,
        IWithRedisConfiguration
    {
        /// <summary>
        /// Assigns the specified subnet to this instance of Redis Cache.
        /// </summary>
        /// <param name="networkResource">networkResource instance of Network object.</param>
        /// <param name="subnetName">subnetName the name of the subnet.</param>
        /// <returns>the next stage of Redis Cache update.</returns>
        IUpdate WithSubnet (IGroupableResource networkResource, string subnetName);

        /// <summary>
        /// Sets Redis Cache static IP. Required when deploying a Redis Cache inside an existing Azure Virtual Network.
        /// </summary>
        /// <param name="staticIP">staticIP the staticIP value to set.</param>
        /// <returns>the next stage of Redis Cache update.</returns>
        IUpdate WithStaticIP (string staticIP);

        /// <summary>
        /// The number of shards to be created on a Premium Cluster Cache.
        /// </summary>
        /// <param name="shardCount">shardCount the shard count value to set.</param>
        /// <returns>the next stage of Redis Cache update.</returns>
        IUpdate WithShardCount (int shardCount);

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="dayOfWeek">dayOfWeek day of week when cache can be patched.</param>
        /// <param name="startHourUtc">startHourUtc start hour after which cache patching can start.</param>
        /// <returns>the next stage of Redis Cache with Premium SKU definition.</returns>
        IUpdate WithPatchSchedule (DayOfWeek dayOfWeek, int startHourUtc);

        /// <summary>
        /// The number of shards to be created on a Premium Cluster Cache.
        /// </summary>
        /// <param name="dayOfWeek">dayOfWeek day of week when cache can be patched.</param>
        /// <param name="startHourUtc">startHourUtc start hour after which cache patching can start.</param>
        /// <param name="maintenanceWindow">maintenanceWindow ISO8601 timespan specifying how much time cache patching can take.</param>
        /// <returns>the next stage of Redis Cache with Premium SKU definition.</returns>
        IUpdate WithPatchSchedule (DayOfWeek dayOfWeek, int startHourUtc, System.TimeSpan? maintenanceWindow);

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="scheduleEntry">scheduleEntry Patch schedule entry for Premium Redis Cache.</param>
        /// <returns>the next stage of Redis Cache with Premium SKU definition.</returns>
        IUpdate WithPatchSchedule (ScheduleEntry scheduleEntry);

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="scheduleEntry">scheduleEntry List of patch schedule entries for Premium Redis Cache.</param>
        /// <returns>the next stage of Redis Cache with Premium SKU definition.</returns>
        IUpdate WithPatchSchedule (IList<ScheduleEntry> scheduleEntry);

    }
    /// <summary>
    /// A Redis Cache update stage allowing to change the parameters.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Updates Redis Cache to Basic sku with new capacity.
        /// </summary>
        /// <param name="capacity">capacity specifies what size of Redis Cache to update to for Basic sku with C family (0, 1, 2, 3, 4, 5, 6).</param>
        /// <returns>the next stage of Redis Cache update.</returns>
        IUpdate WithBasicSku (int capacity);

        /// <summary>
        /// Updates Redis Cache to Standard sku.
        /// </summary>
        /// <returns>the next stage of Redis Cache update.</returns>
        IUpdate WithStandardSku ();

        /// <summary>
        /// Updates Redis Cache to Standard sku with new capacity.
        /// </summary>
        /// <param name="capacity">capacity specifies what size of Redis Cache to update to for Standard sku with C family (0, 1, 2, 3, 4, 5, 6).</param>
        /// <returns>the next stage of Redis Cache update.</returns>
        IUpdate WithStandardSku (int capacity);

        /// <summary>
        /// Updates Redis Cache to Premium sku.
        /// </summary>
        /// <returns>the next stage of Redis Cache update.</returns>
        IUpdate WithPremiumSku ();

        /// <summary>
        /// Updates Redis Cache to Premium sku with new capacity.
        /// </summary>
        /// <param name="capacity">capacity specifies what size of Redis Cache to update to for Premium sku with P family (1, 2, 3, 4).</param>
        /// <returns>the next stage of Redis Cache update.</returns>
        IUpdate WithPremiumSku (int capacity);

    }
}