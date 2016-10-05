// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Fluent.Redis
{
    using System.Collections.Generic;
    using System.Threading;
    using Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition;
    using Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using Microsoft.Azure.Management.Fluent.Redis.Models;
    using System.Threading.Tasks;
    internal partial class RedisCacheImpl 
    {
        /// <summary>
        /// Sets Redis Cache static IP. Required when deploying a Redis Cache inside an existing Azure Virtual Network.
        /// </summary>
        /// <param name="staticIP">staticIP the static IP value to set.</param>
        /// <returns>the next stage of Redis Cache definition.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithCreate.WithStaticIP (string staticIP) {
            return this.WithStaticIP( staticIP) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithCreate;
        }

        /// <summary>
        /// All Redis Settings. Few possible keys:
        /// rdb-backup-enabled, rdb-storage-connection-string, rdb-backup-frequency, maxmemory-delta, maxmemory-policy,
        /// notify-keyspace-events, maxmemory-samples, slowlog-log-slower-than, slowlog-max-len, list-max-ziplist-entries,
        /// list-max-ziplist-value, hash-max-ziplist-entries, hash-max-ziplist-value, set -max-intset-entries,
        /// zset-max-ziplist-entries, zset-max-ziplist-value etc.
        /// </summary>
        /// <param name="redisConfiguration">redisConfiguration configuration of Redis Cache as a map indexed by configuration name</param>
        /// <returns>the next stage of Redis Cache definition.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithCreate.WithRedisConfiguration (IDictionary<string,string> redisConfiguration) {
            return this.WithRedisConfiguration( redisConfiguration) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithCreate;
        }

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
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithCreate.WithRedisConfiguration (string key, string value) {
            return this.WithRedisConfiguration( key,  value) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithCreate;
        }

        /// <summary>
        /// Assigns the specified subnet to this instance of Redis Cache.
        /// </summary>
        /// <param name="networkResource">networkResource instance of Network object.</param>
        /// <param name="subnetName">subnetName the name of the subnet.</param>
        /// <returns>the next stage of Redis Cache definition.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithCreate.WithSubnet (IGroupableResource networkResource, string subnetName) {
            return this.WithSubnet( networkResource,  subnetName) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables non-ssl Redis server port (6379).
        /// </summary>
        /// <returns>the next stage of Redis Cache definition.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithCreate.WithNonSslPort () {
            return this.WithNonSslPort() as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithCreate;
        }

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="dayOfWeek">dayOfWeek day of week when cache can be patched.</param>
        /// <param name="startHourUtc">startHourUtc start hour after which cache patching can start.</param>
        /// <returns>the next stage of Redis Cache with Premium SKU definition.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate.WithPatchSchedule (DayOfWeek dayOfWeek, int startHourUtc) {
            return this.WithPatchSchedule( dayOfWeek,  startHourUtc) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// The number of shards to be created on a Premium Cluster Cache.
        /// </summary>
        /// <param name="dayOfWeek">dayOfWeek day of week when cache can be patched.</param>
        /// <param name="startHourUtc">startHourUtc start hour after which cache patching can start.</param>
        /// <param name="maintenanceWindow">maintenanceWindow ISO8601 timespan specifying how much time cache patching can take.</param>
        /// <returns>the next stage of Redis Cache with Premium SKU definition.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate.WithPatchSchedule (DayOfWeek dayOfWeek, int startHourUtc, System.TimeSpan? maintenanceWindow) {
            return this.WithPatchSchedule( dayOfWeek,  startHourUtc,  maintenanceWindow) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="scheduleEntry">scheduleEntry List of patch schedule entries for Premium Redis Cache.</param>
        /// <returns>the next stage of Redis Cache with Premium SKU definition.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate.WithPatchSchedule (IList<ScheduleEntry> scheduleEntry) {
            return this.WithPatchSchedule( scheduleEntry) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="scheduleEntry">scheduleEntry Patch schedule entry for Premium Redis Cache.</param>
        /// <returns>the next stage of Redis Cache with Premium SKU definition.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate.WithPatchSchedule (ScheduleEntry scheduleEntry) {
            return this.WithPatchSchedule( scheduleEntry) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Sets Redis Cache static IP. Required when deploying a Redis Cache inside an existing Azure Virtual Network.
        /// </summary>
        /// <param name="staticIP">staticIP the staticIP value to set.</param>
        /// <returns>the next stage of Redis Cache update.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate.WithStaticIP (string staticIP) {
            return this.WithStaticIP( staticIP) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// The number of shards to be created on a Premium Cluster Cache.
        /// </summary>
        /// <param name="shardCount">shardCount the shard count value to set.</param>
        /// <returns>the next stage of Redis Cache update.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate.WithShardCount (int shardCount) {
            return this.WithShardCount( shardCount) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Assigns the specified subnet to this instance of Redis Cache.
        /// </summary>
        /// <param name="networkResource">networkResource instance of Network object.</param>
        /// <param name="subnetName">subnetName the name of the subnet.</param>
        /// <returns>the next stage of Redis Cache update.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate.WithSubnet (IGroupableResource networkResource, string subnetName) {
            return this.WithSubnet( networkResource,  subnetName) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="dayOfWeek">dayOfWeek day of week when cache can be patched.</param>
        /// <param name="startHourUtc">startHourUtc start hour after which cache patching can start.</param>
        /// <returns>the next stage of Redis Cache with Premium SKU definition.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithPremiumSkuCreate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithPremiumSkuCreate.WithPatchSchedule (DayOfWeek dayOfWeek, int startHourUtc) {
            return this.WithPatchSchedule( dayOfWeek,  startHourUtc) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithPremiumSkuCreate;
        }

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="dayOfWeek">dayOfWeek day of week when cache can be patched.</param>
        /// <param name="startHourUtc">startHourUtc start hour after which cache patching can start.</param>
        /// <param name="maintenanceWindow">maintenanceWindow ISO8601 timespan specifying how much time cache patching can take.</param>
        /// <returns>the next stage of Redis Cache with Premium SKU definition.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithPremiumSkuCreate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithPremiumSkuCreate.WithPatchSchedule (DayOfWeek dayOfWeek, int startHourUtc, System.TimeSpan? maintenanceWindow) {
            return this.WithPatchSchedule( dayOfWeek,  startHourUtc,  maintenanceWindow) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithPremiumSkuCreate;
        }

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="scheduleEntry">scheduleEntry List of patch schedule entries for Premium Redis Cache.</param>
        /// <returns>the next stage of Redis Cache with Premium SKU definition.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithPremiumSkuCreate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithPremiumSkuCreate.WithPatchSchedule (IList<ScheduleEntry> scheduleEntry) {
            return this.WithPatchSchedule( scheduleEntry) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithPremiumSkuCreate;
        }

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="scheduleEntry">scheduleEntry Patch schedule entry for Premium Redis Cache.</param>
        /// <returns>the next stage of Redis Cache with Premium SKU definition.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithPremiumSkuCreate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithPremiumSkuCreate.WithPatchSchedule (ScheduleEntry scheduleEntry) {
            return this.WithPatchSchedule( scheduleEntry) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithPremiumSkuCreate;
        }

        /// <summary>
        /// The number of shards to be created on a Premium Cluster Cache.
        /// </summary>
        /// <param name="shardCount">shardCount the shard count value to set.</param>
        /// <returns>the next stage of Redis Cache with Premium SKU definition.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithPremiumSkuCreate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithPremiumSkuCreate.WithShardCount (int shardCount) {
            return this.WithShardCount( shardCount) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithPremiumSkuCreate;
        }

        /// <returns>the hostName value</returns>
        string Microsoft.Azure.Management.Fluent.Redis.IRedisCache.HostName
        {
            get
            {
                return this.HostName as string;
            }
        }
        /// <returns>the Redis configuration value</returns>
        System.Collections.Generic.IDictionary<string,string> Microsoft.Azure.Management.Fluent.Redis.IRedisCache.RedisConfiguration
        {
            get
            {
                return this.RedisConfiguration as System.Collections.Generic.IDictionary<string,string>;
            }
        }
        /// <summary>
        /// Regenerates the access keys for this Redis Cache.
        /// </summary>
        /// <param name="keyType">keyType key type to regenerate</param>
        /// <returns>the generated access keys for this Redis Cache</returns>
        Microsoft.Azure.Management.Fluent.Redis.IRedisAccessKeys Microsoft.Azure.Management.Fluent.Redis.IRedisCache.RegenerateKey (RedisKeyType keyType) {
            return this.RegenerateKey( keyType) as Microsoft.Azure.Management.Fluent.Redis.IRedisAccessKeys;
        }

        /// <returns>the shardCount value</returns>
        int? Microsoft.Azure.Management.Fluent.Redis.IRedisCache.ShardCount
        {
            get
            {
                return this.ShardCount;
            }
        }
        /// <returns>true if non SSL port is enabled, false otherwise</returns>
        bool? Microsoft.Azure.Management.Fluent.Redis.IRedisCache.NonSslPort
        {
            get
            {
                return this.NonSslPort;
            }
        }
        /// <returns>returns true if current Redis Cache instance has Premium Sku.</returns>
        bool Microsoft.Azure.Management.Fluent.Redis.IRedisCache.IsPremium
        {
            get
            {
                return this.IsPremium;
            }
        }
        /// <returns>the provisioningState value</returns>
        string Microsoft.Azure.Management.Fluent.Redis.IRedisCache.ProvisioningState
        {
            get
            {
                return this.ProvisioningState as string;
            }
        }
        /// <returns>the sku value</returns>
        Microsoft.Azure.Management.Fluent.Redis.Models.Sku Microsoft.Azure.Management.Fluent.Redis.IRedisCache.Sku
        {
            get
            {
                return this.Sku as Microsoft.Azure.Management.Fluent.Redis.Models.Sku;
            }
        }
        /// <returns>a Redis Cache's access keys. This operation requires write permission to the Cache resource.</returns>
        Microsoft.Azure.Management.Fluent.Redis.IRedisAccessKeys Microsoft.Azure.Management.Fluent.Redis.IRedisCache.Keys () {
            return this.Keys() as Microsoft.Azure.Management.Fluent.Redis.IRedisAccessKeys;
        }

        /// <returns>the staticIP value</returns>
        string Microsoft.Azure.Management.Fluent.Redis.IRedisCache.StaticIP
        {
            get
            {
                return this.StaticIP as string;
            }
        }
        /// <returns>the sslPort value</returns>
        int? Microsoft.Azure.Management.Fluent.Redis.IRedisCache.SslPort
        {
            get
            {
                return this.SslPort;
            }
        }
        /// <summary>
        /// Fetch the up-to-date access keys from Azure for this Redis Cache.
        /// </summary>
        /// <returns>the access keys for this Redis Cache</returns>
        Microsoft.Azure.Management.Fluent.Redis.IRedisAccessKeys Microsoft.Azure.Management.Fluent.Redis.IRedisCache.RefreshKeys () {
            return this.RefreshKeys() as Microsoft.Azure.Management.Fluent.Redis.IRedisAccessKeys;
        }

        /// <returns>the port value</returns>
        int? Microsoft.Azure.Management.Fluent.Redis.IRedisCache.Port
        {
            get
            {
                return this.Port;
            }
        }
        /// <returns>the Redis version value</returns>
        string Microsoft.Azure.Management.Fluent.Redis.IRedisCache.RedisVersion
        {
            get
            {
                return this.RedisVersion as string;
            }
        }
        /// <returns>the subnetId value</returns>
        string Microsoft.Azure.Management.Fluent.Redis.IRedisCache.SubnetId
        {
            get
            {
                return this.SubnetId as string;
            }
        }
        /// <returns>exposes features available only to Premium Sku Redis Cache instances.</returns>
        Microsoft.Azure.Management.Fluent.Redis.IRedisCachePremium Microsoft.Azure.Management.Fluent.Redis.IRedisCache.AsPremium () {
            return this.AsPremium() as Microsoft.Azure.Management.Fluent.Redis.IRedisCachePremium;
        }

        /// <summary>
        /// Disables non-ssl Redis server port (6379).
        /// </summary>
        /// <returns>the next stage of Redis Cache update.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IWithNonSslPort.WithoutNonSslPort () {
            return this.WithoutNonSslPort() as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Enables non-ssl Redis server port (6379).
        /// </summary>
        /// <returns>the next stage of Redis Cache update.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IWithNonSslPort.WithNonSslPort () {
            return this.WithNonSslPort() as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Begins an update for a new resource.
        /// <p>
        /// This is the beginning of the builder pattern used to update top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is {@link Appliable#apply()}.
        /// </summary>
        /// <returns>the stage of new resource update</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions.IUpdatable<Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate>.Update () {
            return this.Update() as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Cleans all the configuration settings being set on Redis Cache.
        /// </summary>
        /// <returns>the next stage of Redis Cache update.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IWithRedisConfiguration.WithoutRedisConfiguration () {
            return this.WithoutRedisConfiguration() as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Removes specified Redis Cache configuration setting.
        /// </summary>
        /// <param name="key">key Redis configuration name.</param>
        /// <returns>the next stage of Redis Cache update.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IWithRedisConfiguration.WithoutRedisConfiguration (string key) {
            return this.WithoutRedisConfiguration( key) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// All Redis Settings. Few possible keys:
        /// rdb-backup-enabled, rdb-storage-connection-string, rdb-backup-frequency, maxmemory-delta, maxmemory-policy,
        /// notify-keyspace-events, maxmemory-samples, slowlog-log-slower-than, slowlog-max-len, list-max-ziplist-entries,
        /// list-max-ziplist-value, hash-max-ziplist-entries, hash-max-ziplist-value, set -max-intset-entries,
        /// zset-max-ziplist-entries, zset-max-ziplist-value etc.
        /// </summary>
        /// <param name="redisConfiguration">redisConfiguration configuration of Redis Cache as a map indexed by configuration name</param>
        /// <returns>the next stage of Redis Cache update.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IWithRedisConfiguration.WithRedisConfiguration (IDictionary<string,string> redisConfiguration) {
            return this.WithRedisConfiguration( redisConfiguration) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate;
        }

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
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IWithRedisConfiguration.WithRedisConfiguration (string key, string value) {
            return this.WithRedisConfiguration( key,  value) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Updates Redis Cache to Basic sku with new capacity.
        /// </summary>
        /// <param name="capacity">capacity specifies what size of Redis Cache to update to for Basic sku with C family (0, 1, 2, 3, 4, 5, 6).</param>
        /// <returns>the next stage of Redis Cache update.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IWithSku.WithBasicSku (int capacity) {
            return this.WithBasicSku( capacity) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Updates Redis Cache to Standard sku.
        /// </summary>
        /// <returns>the next stage of Redis Cache update.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IWithSku.WithStandardSku () {
            return this.WithStandardSku() as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Updates Redis Cache to Standard sku with new capacity.
        /// </summary>
        /// <param name="capacity">capacity specifies what size of Redis Cache to update to for Standard sku with C family (0, 1, 2, 3, 4, 5, 6).</param>
        /// <returns>the next stage of Redis Cache update.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IWithSku.WithStandardSku (int capacity) {
            return this.WithStandardSku( capacity) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Updates Redis Cache to Premium sku.
        /// </summary>
        /// <returns>the next stage of Redis Cache update.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IWithSku.WithPremiumSku () {
            return this.WithPremiumSku() as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Updates Redis Cache to Premium sku with new capacity.
        /// </summary>
        /// <param name="capacity">capacity specifies what size of Redis Cache to update to for Premium sku with P family (1, 2, 3, 4).</param>
        /// <returns>the next stage of Redis Cache update.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IWithSku.WithPremiumSku (int capacity) {
            return this.WithPremiumSku( capacity) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the Basic sku of the Redis Cache.
        /// </summary>
        /// <returns>the next stage of Redis Cache definition.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithSku.WithBasicSku () {
            return this.WithBasicSku() as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the Basic sku of the Redis Cache.
        /// </summary>
        /// <param name="capacity">capacity specifies what size of Redis Cache to deploy for Basic sku with C family (0, 1, 2, 3, 4, 5, 6).</param>
        /// <returns>the next stage of Redis Cache definition.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithSku.WithBasicSku (int capacity) {
            return this.WithBasicSku( capacity) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the Standard Sku of the Redis Cache.
        /// </summary>
        /// <returns>the next stage of Redis Cache definition.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithSku.WithStandardSku () {
            return this.WithStandardSku() as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the Standard sku of the Redis Cache.
        /// </summary>
        /// <param name="capacity">capacity specifies what size of Redis Cache to deploy for Standard sku with C family (0, 1, 2, 3, 4, 5, 6).</param>
        /// <returns>the next stage of Redis Cache definition.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithSku.WithStandardSku (int capacity) {
            return this.WithStandardSku( capacity) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the Premium sku of the Redis Cache.
        /// </summary>
        /// <returns>the next stage of Redis Cache definition.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithPremiumSkuCreate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithSku.WithPremiumSku () {
            return this.WithPremiumSku() as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithPremiumSkuCreate;
        }

        /// <summary>
        /// Specifies the Premium sku of the Redis Cache.
        /// </summary>
        /// <param name="capacity">capacity specifies what size of Redis Cache to deploy for Standard sku with P family (1, 2, 3, 4).</param>
        /// <returns>the next stage of Redis Cache definition.</returns>
        Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithPremiumSkuCreate Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithSku.WithPremiumSku (int capacity) {
            return this.WithPremiumSku( capacity) as Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition.IWithPremiumSkuCreate;
        }

        /// <summary>
        /// Export data from Redis Cache.
        /// </summary>
        /// <param name="containerSASUrl">containerSASUrl container name to export to.</param>
        /// <param name="prefix">prefix          prefix to use for exported files.</param>
        void Microsoft.Azure.Management.Fluent.Redis.IRedisCachePremium.ExportData (string containerSASUrl, string prefix) {
            this.ExportData( containerSASUrl,  prefix);
        }

        /// <summary>
        /// Export data from Redis Cache.
        /// </summary>
        /// <param name="containerSASUrl">containerSASUrl container name to export to.</param>
        /// <param name="prefix">prefix          prefix to use for exported files.</param>
        /// <param name="fileFormat">fileFormat      specifies file format.</param>
        void Microsoft.Azure.Management.Fluent.Redis.IRedisCachePremium.ExportData (string containerSASUrl, string prefix, string fileFormat) {
            this.ExportData( containerSASUrl,  prefix,  fileFormat);
        }

        /// <summary>
        /// Import data into Redis Cache.
        /// </summary>
        /// <param name="files">files files to import.</param>
        void Microsoft.Azure.Management.Fluent.Redis.IRedisCachePremium.ImportData (IList<string> files) {
            this.ImportData( files);
        }

        /// <summary>
        /// Import data into Redis Cache.
        /// </summary>
        /// <param name="files">files      files to import.</param>
        /// <param name="fileFormat">fileFormat specifies file format.</param>
        void Microsoft.Azure.Management.Fluent.Redis.IRedisCachePremium.ImportData (IList<string> files, string fileFormat) {
            this.ImportData( files,  fileFormat);
        }

        /// <summary>
        /// Gets the patching schedule for Redis Cache.
        /// </summary>
        /// <returns>List of patch schedules for current Redis Cache.</returns>
        System.Collections.Generic.IList<ScheduleEntry> Microsoft.Azure.Management.Fluent.Redis.IRedisCachePremium.GetPatchSchedules()
        {
            return this.GetPatchSchedules() as System.Collections.Generic.IList<ScheduleEntry>;
        }
        /// <summary>
        /// Deletes the patching schedule for Redis Cache.
        /// </summary>
        void Microsoft.Azure.Management.Fluent.Redis.IRedisCachePremium.DeletePatchSchedule () {
            this.DeletePatchSchedule();
        }

        /// <summary>
        /// Reboot specified Redis node(s). This operation requires write permission to the cache resource. There can be potential data loss.
        /// </summary>
        /// <param name="rebootType">rebootType specifies which Redis node(s) to reboot. Depending on this value data loss is</param>
        /// <param name="possible.">possible. Possible values include: 'PrimaryNode', 'SecondaryNode', 'AllNodes'.</param>
        void Microsoft.Azure.Management.Fluent.Redis.IRedisCachePremium.ForceReboot (string rebootType) {
            this.ForceReboot( rebootType);
        }

        /// <summary>
        /// Reboot specified Redis node(s). This operation requires write permission to the cache resource. There can be potential data loss.
        /// </summary>
        /// <param name="rebootType">rebootType specifies which Redis node(s) to reboot. Depending on this value data loss is</param>
        /// <param name="possible.">possible. Possible values include: 'PrimaryNode', 'SecondaryNode', 'AllNodes'.</param>
        /// <param name="shardId">shardId    In case of cluster cache, this specifies shard id which should be rebooted.</param>
        void Microsoft.Azure.Management.Fluent.Redis.IRedisCachePremium.ForceReboot (string rebootType, int shardId) {
            this.ForceReboot( rebootType,  shardId);
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <returns>the refreshed resource</returns>
        Microsoft.Azure.Management.Fluent.Redis.IRedisCache Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Fluent.Redis.IRedisCache>.Refresh () {
            return this.Refresh() as Microsoft.Azure.Management.Fluent.Redis.IRedisCache;
        }
    }
}