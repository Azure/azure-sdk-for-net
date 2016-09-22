// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition
{

    using Microsoft.Azure.Management.V2.Resource.Core.Resource.Definition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.Fluent.Redis;
    using Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.Fluent.Redis.Models;
    /// <summary>
    /// A Redis Cache definition with sufficient inputs to create a new
    /// Redis Cache in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<IRedisCache>,
        IDefinitionWithTags<IWithCreate>
    {
        /// <summary>
        /// Enables non-ssl Redis server port (6379).
        /// </summary>
        /// <returns>the next stage of Redis Cache definition.</returns>
        IWithCreate WithNonSslPort ();

        /// <summary>
        /// All Redis Settings. Few possible keys:
        /// rdb-backup-enabled, rdb-storage-connection-string, rdb-backup-frequency, maxmemory-delta, maxmemory-policy,
        /// notify-keyspace-events, maxmemory-samples, slowlog-log-slower-than, slowlog-max-len, list-max-ziplist-entries,
        /// list-max-ziplist-value, hash-max-ziplist-entries, hash-max-ziplist-value, set -max-intset-entries,
        /// zset-max-ziplist-entries, zset-max-ziplist-value etc.
        /// </summary>
        /// <param name="redisConfiguration">redisConfiguration configuration of Redis Cache as a map indexed by configuration name</param>
        /// <returns>the next stage of Redis Cache definition.</returns>
        IWithCreate WithRedisConfiguration (IDictionary<string,string> redisConfiguration);

        /// <summary>
        /// Specifies Redis Setting.
        /// rdb-backup-enabled, rdb-storage-connection-string, rdb-backup-frequency, maxmemory-delta, maxmemory-policy,
        /// notify-keyspace-events, maxmemory-samples, slowlog-log-slower-than, slowlog-max-len, list-max-ziplist-entries,
        /// list-max-ziplist-value, hash-max-ziplist-entries, hash-max-ziplist-value, set -max-intset-entries,
        /// zset-max-ziplist-entries, zset-max-ziplist-value etc.
        /// </summary>
        /// <param name="key">key   Redis configuration name.</param>
        /// <param name="value">value Redis configuration value.</param>
        /// <returns>the next stage of Redis Cache definition.</returns>
        IWithCreate WithRedisConfiguration (string key, string value);

        /// <summary>
        /// Assigns the specified subnet to this instance of Redis Cache.
        /// </summary>
        /// <param name="networkResource">networkResource instance of Network object.</param>
        /// <param name="subnetName">subnetName the name of the subnet.</param>
        /// <returns>the next stage of Redis Cache definition.</returns>
        IWithCreate WithSubnet (IGroupableResource networkResource, string subnetName);

        /// <summary>
        /// Sets Redis Cache static IP. Required when deploying a Redis Cache inside an existing Azure Virtual Network.
        /// </summary>
        /// <param name="staticIP">staticIP the static IP value to set.</param>
        /// <returns>the next stage of Redis Cache definition.</returns>
        IWithCreate WithStaticIP (string staticIP);

    }
    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithGroup,
        IWithSku,
        IWithCreate,
        IWithPremiumSkuCreate
    {
    }
    /// <summary>
    /// A Redis Cache definition allowing resource group to be set.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition.IWithGroup<IWithSku>
    {
    }
    /// <summary>
    /// A Redis Cache definition allowing the sku to be set.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the Basic sku of the Redis Cache.
        /// </summary>
        /// <returns>the next stage of Redis Cache definition.</returns>
        IWithCreate WithBasicSku ();

        /// <summary>
        /// Specifies the Basic sku of the Redis Cache.
        /// </summary>
        /// <param name="capacity">capacity specifies what size of Redis Cache to deploy for Basic sku with C family (0, 1, 2, 3, 4, 5, 6).</param>
        /// <returns>the next stage of Redis Cache definition.</returns>
        IWithCreate WithBasicSku (int capacity);

        /// <summary>
        /// Specifies the Standard Sku of the Redis Cache.
        /// </summary>
        /// <returns>the next stage of Redis Cache definition.</returns>
        IWithCreate WithStandardSku ();

        /// <summary>
        /// Specifies the Standard sku of the Redis Cache.
        /// </summary>
        /// <param name="capacity">capacity specifies what size of Redis Cache to deploy for Standard sku with C family (0, 1, 2, 3, 4, 5, 6).</param>
        /// <returns>the next stage of Redis Cache definition.</returns>
        IWithCreate WithStandardSku (int capacity);

        /// <summary>
        /// Specifies the Premium sku of the Redis Cache.
        /// </summary>
        /// <returns>the next stage of Redis Cache definition.</returns>
        IWithPremiumSkuCreate WithPremiumSku ();

        /// <summary>
        /// Specifies the Premium sku of the Redis Cache.
        /// </summary>
        /// <param name="capacity">capacity specifies what size of Redis Cache to deploy for Standard sku with P family (1, 2, 3, 4).</param>
        /// <returns>the next stage of Redis Cache definition.</returns>
        IWithPremiumSkuCreate WithPremiumSku (int capacity);

    }
    /// <summary>
    /// A Redis Cache definition with Premium Sku specific functionality.
    /// </summary>
    public interface IWithPremiumSkuCreate  :
        IWithCreate
    {
        /// <summary>
        /// The number of shards to be created on a Premium Cluster Cache.
        /// </summary>
        /// <param name="shardCount">shardCount the shard count value to set.</param>
        /// <returns>the next stage of Redis Cache with Premium SKU definition.</returns>
        IWithPremiumSkuCreate WithShardCount (int shardCount);

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="dayOfWeek">dayOfWeek day of week when cache can be patched.</param>
        /// <param name="startHourUtc">startHourUtc start hour after which cache patching can start.</param>
        /// <returns>the next stage of Redis Cache with Premium SKU definition.</returns>
        IWithPremiumSkuCreate WithPatchSchedule (DayOfWeek dayOfWeek, int startHourUtc);

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="dayOfWeek">dayOfWeek day of week when cache can be patched.</param>
        /// <param name="startHourUtc">startHourUtc start hour after which cache patching can start.</param>
        /// <param name="maintenanceWindow">maintenanceWindow ISO8601 timespan specifying how much time cache patching can take.</param>
        /// <returns>the next stage of Redis Cache with Premium SKU definition.</returns>
        IWithPremiumSkuCreate WithPatchSchedule (DayOfWeek dayOfWeek, int startHourUtc, System.TimeSpan? maintenanceWindow);

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="scheduleEntry">scheduleEntry Patch schedule entry for Premium Redis Cache.</param>
        /// <returns>the next stage of Redis Cache with Premium SKU definition.</returns>
        IWithPremiumSkuCreate WithPatchSchedule (ScheduleEntry scheduleEntry);

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="scheduleEntry">scheduleEntry List of patch schedule entries for Premium Redis Cache.</param>
        /// <returns>the next stage of Redis Cache with Premium SKU definition.</returns>
        IWithPremiumSkuCreate WithPatchSchedule (IList<ScheduleEntry> scheduleEntry);

    }
    /// <summary>
    /// The first stage of the Redis Cache definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithGroup>
    {
    }
}