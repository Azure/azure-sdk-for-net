// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Redis.Fluent
{
    using System.Collections.Generic;
    using System.Threading;
    using Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition;
    using Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Redis.Fluent.Models;
    using System.Threading.Tasks;
    internal partial class RedisCacheImpl 
    {
        /// <summary>
        /// Sets Redis Cache static IP. Required when deploying a Redis Cache inside an existing Azure Virtual Network.
        /// </summary>
        /// <param name="staticIP">The static IP value to set.</param>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithCreate.WithStaticIP(string staticIP)
        {
            return this.WithStaticIP(staticIP) as RedisCache.Definition.IWithCreate;
        }

        /// <summary>
        /// All Redis Settings. Few possible keys:
        /// rdb-backup-enabled, rdb-storage-connection-string, rdb-backup-frequency, maxmemory-delta, maxmemory-policy,
        /// notify-keyspace-events, maxmemory-samples, slowlog-log-slower-than, slowlog-max-len, list-max-ziplist-entries,
        /// list-max-ziplist-value, hash-max-ziplist-entries, hash-max-ziplist-value, set -max-intset-entries,
        /// zset-max-ziplist-entries, zset-max-ziplist-value etc.
        /// </summary>
        /// <param name="redisConfiguration">Configuration of Redis Cache as a map indexed by configuration name.</param>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithCreate.WithRedisConfiguration(IDictionary<string,string> redisConfiguration)
        {
            return this.WithRedisConfiguration(redisConfiguration) as RedisCache.Definition.IWithCreate;
        }

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
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithCreate.WithRedisConfiguration(string key, string value)
        {
            return this.WithRedisConfiguration(key, value) as RedisCache.Definition.IWithCreate;
        }

        /// <summary>
        /// Assigns the specified subnet to this instance of Redis Cache.
        /// </summary>
        /// <param name="networkResource">Instance of Network object.</param>
        /// <param name="subnetName">The name of the subnet.</param>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithCreate.WithSubnet(IHasId networkResource, string subnetName)
        {
            return this.WithSubnet(networkResource, subnetName) as RedisCache.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables non-ssl Redis server port (6379).
        /// </summary>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithCreate.WithNonSslPort()
        {
            return this.WithNonSslPort() as RedisCache.Definition.IWithCreate;
        }

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="dayOfWeek">Day of week when cache can be patched.</param>
        /// <param name="startHourUtc">Start hour after which cache patching can start.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IUpdate.WithPatchSchedule(DayOfWeek dayOfWeek, int startHourUtc)
        {
            return this.WithPatchSchedule(dayOfWeek, startHourUtc) as RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// The number of shards to be created on a Premium Cluster Cache.
        /// </summary>
        /// <param name="dayOfWeek">Day of week when cache can be patched.</param>
        /// <param name="startHourUtc">Start hour after which cache patching can start.</param>
        /// <param name="maintenanceWindow">ISO8601 timespan specifying how much time cache patching can take.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IUpdate.WithPatchSchedule(DayOfWeek dayOfWeek, int startHourUtc, System.TimeSpan? maintenanceWindow)
        {
            return this.WithPatchSchedule(dayOfWeek, startHourUtc, maintenanceWindow) as RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="scheduleEntry">List of patch schedule entries for Premium Redis Cache.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IUpdate.WithPatchSchedule(IList<Models.ScheduleEntry> scheduleEntry)
        {
            return this.WithPatchSchedule(scheduleEntry) as RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="scheduleEntry">Patch schedule entry for Premium Redis Cache.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IUpdate.WithPatchSchedule(ScheduleEntry scheduleEntry)
        {
            return this.WithPatchSchedule(scheduleEntry) as RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Sets Redis Cache static IP. Required when deploying a Redis Cache inside an existing Azure Virtual Network.
        /// </summary>
        /// <param name="staticIP">The staticIP value to set.</param>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IUpdate.WithStaticIP(string staticIP)
        {
            return this.WithStaticIP(staticIP) as RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// The number of shards to be created on a Premium Cluster Cache.
        /// </summary>
        /// <param name="shardCount">The shard count value to set.</param>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IUpdate.WithShardCount(int shardCount)
        {
            return this.WithShardCount(shardCount) as RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Assigns the specified subnet to this instance of Redis Cache.
        /// </summary>
        /// <param name="networkResource">Instance of Network object.</param>
        /// <param name="subnetName">The name of the subnet.</param>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IUpdate.WithSubnet(IHasId networkResource, string subnetName)
        {
            return this.WithSubnet(networkResource, subnetName) as RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="dayOfWeek">Day of week when cache can be patched.</param>
        /// <param name="startHourUtc">Start hour after which cache patching can start.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        RedisCache.Definition.IWithPremiumSkuCreate RedisCache.Definition.IWithPremiumSkuCreate.WithPatchSchedule(DayOfWeek dayOfWeek, int startHourUtc)
        {
            return this.WithPatchSchedule(dayOfWeek, startHourUtc) as RedisCache.Definition.IWithPremiumSkuCreate;
        }

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="dayOfWeek">Day of week when cache can be patched.</param>
        /// <param name="startHourUtc">Start hour after which cache patching can start.</param>
        /// <param name="maintenanceWindow">ISO8601 timespan specifying how much time cache patching can take.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        RedisCache.Definition.IWithPremiumSkuCreate RedisCache.Definition.IWithPremiumSkuCreate.WithPatchSchedule(DayOfWeek dayOfWeek, int startHourUtc, System.TimeSpan? maintenanceWindow)
        {
            return this.WithPatchSchedule(dayOfWeek, startHourUtc, maintenanceWindow) as RedisCache.Definition.IWithPremiumSkuCreate;
        }

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="scheduleEntry">List of patch schedule entries for Premium Redis Cache.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        RedisCache.Definition.IWithPremiumSkuCreate RedisCache.Definition.IWithPremiumSkuCreate.WithPatchSchedule(IList<Models.ScheduleEntry> scheduleEntry)
        {
            return this.WithPatchSchedule(scheduleEntry) as RedisCache.Definition.IWithPremiumSkuCreate;
        }

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="scheduleEntry">Patch schedule entry for Premium Redis Cache.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        RedisCache.Definition.IWithPremiumSkuCreate RedisCache.Definition.IWithPremiumSkuCreate.WithPatchSchedule(ScheduleEntry scheduleEntry)
        {
            return this.WithPatchSchedule(scheduleEntry) as RedisCache.Definition.IWithPremiumSkuCreate;
        }

        /// <summary>
        /// The number of shards to be created on a Premium Cluster Cache.
        /// </summary>
        /// <param name="shardCount">The shard count value to set.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        RedisCache.Definition.IWithPremiumSkuCreate RedisCache.Definition.IWithPremiumSkuCreate.WithShardCount(int shardCount)
        {
            return this.WithShardCount(shardCount) as RedisCache.Definition.IWithPremiumSkuCreate;
        }

        /// <summary>
        /// Gets the hostName value.
        /// </summary>
        string Microsoft.Azure.Management.Redis.Fluent.IRedisCache.HostName
        {
            get
            {
                return this.HostName();
            }
        }

        /// <summary>
        /// Gets the Redis configuration value.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,string> Microsoft.Azure.Management.Redis.Fluent.IRedisCache.RedisConfiguration
        {
            get
            {
                return this.RedisConfiguration() as System.Collections.Generic.IReadOnlyDictionary<string,string>;
            }
        }

        /// <summary>
        /// Regenerates the access keys for this Redis Cache.
        /// </summary>
        /// <param name="keyType">Key type to regenerate.</param>
        /// <return>The generated access keys for this Redis Cache.</return>
        Microsoft.Azure.Management.Redis.Fluent.IRedisAccessKeys Microsoft.Azure.Management.Redis.Fluent.IRedisCache.RegenerateKey(RedisKeyType keyType)
        {
            return this.RegenerateKey(keyType) as Microsoft.Azure.Management.Redis.Fluent.IRedisAccessKeys;
        }

        /// <summary>
        /// Gets the shardCount value.
        /// </summary>
        int Microsoft.Azure.Management.Redis.Fluent.IRedisCache.ShardCount
        {
            get
            {
                return this.ShardCount();
            }
        }

        /// <summary>
        /// Gets true if non SSL port is enabled, false otherwise.
        /// </summary>
        bool Microsoft.Azure.Management.Redis.Fluent.IRedisCache.NonSslPort
        {
            get
            {
                return this.NonSslPort();
            }
        }

        /// <summary>
        /// Gets returns true if current Redis Cache instance has Premium Sku.
        /// </summary>
        bool Microsoft.Azure.Management.Redis.Fluent.IRedisCache.IsPremium
        {
            get
            {
                return this.IsPremium();
            }
        }

        /// <summary>
        /// Gets the provisioningState value.
        /// </summary>
        string Microsoft.Azure.Management.Redis.Fluent.IRedisCache.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets a Redis Cache's access keys. This operation requires write permission to the Cache resource.
        /// </summary>
        Microsoft.Azure.Management.Redis.Fluent.IRedisAccessKeys Microsoft.Azure.Management.Redis.Fluent.IRedisCache.Keys
        {
            get
            {
                return this.Keys() as Microsoft.Azure.Management.Redis.Fluent.IRedisAccessKeys;
            }
        }

        /// <summary>
        /// Gets the sku value.
        /// </summary>
        Models.Sku Microsoft.Azure.Management.Redis.Fluent.IRedisCache.Sku
        {
            get
            {
                return this.Sku() as Models.Sku;
            }
        }

        /// <summary>
        /// Gets the staticIP value.
        /// </summary>
        string Microsoft.Azure.Management.Redis.Fluent.IRedisCache.StaticIP
        {
            get
            {
                return this.StaticIP();
            }
        }

        /// <summary>
        /// Gets the sslPort value.
        /// </summary>
        int Microsoft.Azure.Management.Redis.Fluent.IRedisCache.SslPort
        {
            get
            {
                return this.SslPort();
            }
        }

        /// <summary>
        /// Fetch the up-to-date access keys from Azure for this Redis Cache.
        /// </summary>
        /// <return>The access keys for this Redis Cache.</return>
        Microsoft.Azure.Management.Redis.Fluent.IRedisAccessKeys Microsoft.Azure.Management.Redis.Fluent.IRedisCache.RefreshKeys()
        {
            return this.RefreshKeys() as Microsoft.Azure.Management.Redis.Fluent.IRedisAccessKeys;
        }

        /// <summary>
        /// Gets the port value.
        /// </summary>
        int Microsoft.Azure.Management.Redis.Fluent.IRedisCache.Port
        {
            get
            {
                return this.Port();
            }
        }

        /// <summary>
        /// Gets the Redis version value.
        /// </summary>
        string Microsoft.Azure.Management.Redis.Fluent.IRedisCache.RedisVersion
        {
            get
            {
                return this.RedisVersion();
            }
        }

        /// <summary>
        /// Gets the subnetId value.
        /// </summary>
        string Microsoft.Azure.Management.Redis.Fluent.IRedisCache.SubnetId
        {
            get
            {
                return this.SubnetId();
            }
        }
        
        /// <summary>
        /// Disables non-ssl Redis server port (6379).
        /// </summary>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IWithNonSslPort.WithoutNonSslPort()
        {
            return this.WithoutNonSslPort() as RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Enables non-ssl Redis server port (6379).
        /// </summary>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IWithNonSslPort.WithNonSslPort()
        {
            return this.WithNonSslPort() as RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Begins an update for a new resource.
        /// This is the beginning of the builder pattern used to update top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is Appliable.apply().
        /// </summary>
        /// <return>The stage of new resource update.</return>
        RedisCache.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<RedisCache.Update.IUpdate>.Update()
        {
            return this.Update() as RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Cleans all the configuration settings being set on Redis Cache.
        /// </summary>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IWithRedisConfiguration.WithoutRedisConfiguration()
        {
            return this.WithoutRedisConfiguration() as RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Removes specified Redis Cache configuration setting.
        /// </summary>
        /// <param name="key">Redis configuration name.</param>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IWithRedisConfiguration.WithoutRedisConfiguration(string key)
        {
            return this.WithoutRedisConfiguration(key) as RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// All Redis Settings. Few possible keys:
        /// rdb-backup-enabled, rdb-storage-connection-string, rdb-backup-frequency, maxmemory-delta, maxmemory-policy,
        /// notify-keyspace-events, maxmemory-samples, slowlog-log-slower-than, slowlog-max-len, list-max-ziplist-entries,
        /// list-max-ziplist-value, hash-max-ziplist-entries, hash-max-ziplist-value, set -max-intset-entries,
        /// zset-max-ziplist-entries, zset-max-ziplist-value etc.
        /// </summary>
        /// <param name="redisConfiguration">Configuration of Redis Cache as a map indexed by configuration name.</param>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IWithRedisConfiguration.WithRedisConfiguration(IDictionary<string,string> redisConfiguration)
        {
            return this.WithRedisConfiguration(redisConfiguration) as RedisCache.Update.IUpdate;
        }

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
        RedisCache.Update.IUpdate RedisCache.Update.IWithRedisConfiguration.WithRedisConfiguration(string key, string value)
        {
            return this.WithRedisConfiguration(key, value) as RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Updates Redis Cache to Basic sku with new capacity.
        /// </summary>
        /// <param name="capacity">Specifies what size of Redis Cache to update to for Basic sku with C family (0, 1, 2, 3, 4, 5, 6).</param>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IWithSku.WithBasicSku(int capacity)
        {
            return this.WithBasicSku(capacity) as RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Updates Redis Cache to Standard sku.
        /// </summary>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IWithSku.WithStandardSku()
        {
            return this.WithStandardSku() as RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Updates Redis Cache to Standard sku with new capacity.
        /// </summary>
        /// <param name="capacity">Specifies what size of Redis Cache to update to for Standard sku with C family (0, 1, 2, 3, 4, 5, 6).</param>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IWithSku.WithStandardSku(int capacity)
        {
            return this.WithStandardSku(capacity) as RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Updates Redis Cache to Premium sku.
        /// </summary>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IWithSku.WithPremiumSku()
        {
            return this.WithPremiumSku() as RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Updates Redis Cache to Premium sku with new capacity.
        /// </summary>
        /// <param name="capacity">Specifies what size of Redis Cache to update to for Premium sku with P family (1, 2, 3, 4).</param>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IWithSku.WithPremiumSku(int capacity)
        {
            return this.WithPremiumSku(capacity) as RedisCache.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the Basic sku of the Redis Cache.
        /// </summary>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithSku.WithBasicSku()
        {
            return this.WithBasicSku() as RedisCache.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the Basic sku of the Redis Cache.
        /// </summary>
        /// <param name="capacity">Specifies what size of Redis Cache to deploy for Basic sku with C family (0, 1, 2, 3, 4, 5, 6).</param>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithSku.WithBasicSku(int capacity)
        {
            return this.WithBasicSku(capacity) as RedisCache.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the Standard Sku of the Redis Cache.
        /// </summary>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithSku.WithStandardSku()
        {
            return this.WithStandardSku() as RedisCache.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the Standard sku of the Redis Cache.
        /// </summary>
        /// <param name="capacity">Specifies what size of Redis Cache to deploy for Standard sku with C family (0, 1, 2, 3, 4, 5, 6).</param>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithSku.WithStandardSku(int capacity)
        {
            return this.WithStandardSku(capacity) as RedisCache.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the Premium sku of the Redis Cache.
        /// </summary>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithPremiumSkuCreate RedisCache.Definition.IWithSku.WithPremiumSku()
        {
            return this.WithPremiumSku() as RedisCache.Definition.IWithPremiumSkuCreate;
        }

        /// <summary>
        /// Specifies the Premium sku of the Redis Cache.
        /// </summary>
        /// <param name="capacity">Specifies what size of Redis Cache to deploy for Standard sku with P family (1, 2, 3, 4).</param>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithPremiumSkuCreate RedisCache.Definition.IWithSku.WithPremiumSku(int capacity)
        {
            return this.WithPremiumSku(capacity) as RedisCache.Definition.IWithPremiumSkuCreate;
        }

        /// <summary>
        /// Export data from Redis Cache.
        /// </summary>
        /// <param name="containerSASUrl">Container name to export to.</param>
        /// <param name="prefix">Prefix to use for exported files.</param>
        void Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremium.ExportData(string containerSASUrl, string prefix)
        {
 
            this.ExportData(containerSASUrl, prefix);
        }

        /// <summary>
        /// Export data from Redis Cache.
        /// </summary>
        /// <param name="containerSASUrl">Container name to export to.</param>
        /// <param name="prefix">Prefix to use for exported files.</param>
        /// <param name="fileFormat">Specifies file format.</param>
        void Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremium.ExportData(string containerSASUrl, string prefix, string fileFormat)
        {
 
            this.ExportData(containerSASUrl, prefix, fileFormat);
        }

        /// <summary>
        /// Import data into Redis Cache.
        /// </summary>
        /// <param name="files">Files to import.</param>
        void Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremium.ImportData(IList<string> files)
        {
 
            this.ImportData(files);
        }

        /// <summary>
        /// Import data into Redis Cache.
        /// </summary>
        /// <param name="files">Files to import.</param>
        /// <param name="fileFormat">Specifies file format.</param>
        void Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremium.ImportData(IList<string> files, string fileFormat)
        {
 
            this.ImportData(files, fileFormat);
        }

        /// <summary>
        /// Deletes the patching schedule for Redis Cache.
        /// </summary>
        void Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremium.DeletePatchSchedule()
        {
 
            this.DeletePatchSchedule();
        }

        /// <summary>
        /// Gets the patching schedule for Redis Cache.
        /// </summary>
        /// <return>List of patch schedules for current Redis Cache.</return>
        System.Collections.Generic.IList<Models.ScheduleEntry> Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremium.ListPatchSchedules()
        {
            return this.ListPatchSchedules() as System.Collections.Generic.IList<Models.ScheduleEntry>;
        }

        /// <summary>
        /// Reboot specified Redis node(s). This operation requires write permission to the cache resource. There can be potential data loss.
        /// </summary>
        /// <param name="rebootType">
        /// Specifies which Redis node(s) to reboot. Depending on this value data loss is
        /// possible. Possible values include: 'PrimaryNode', 'SecondaryNode', 'AllNodes'.
        /// </param>
        void Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremium.ForceReboot(string rebootType)
        {
 
            this.ForceReboot(rebootType);
        }

        /// <summary>
        /// Reboot specified Redis node(s). This operation requires write permission to the cache resource. There can be potential data loss.
        /// </summary>
        /// <param name="rebootType">
        /// Specifies which Redis node(s) to reboot. Depending on this value data loss is
        /// possible. Possible values include: 'PrimaryNode', 'SecondaryNode', 'AllNodes'.
        /// </param>
        /// <param name="shardId">In case of cluster cache, this specifies shard id which should be rebooted.</param>
        void Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremium.ForceReboot(string rebootType, int shardId)
        {
 
            this.ForceReboot(rebootType, shardId);
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Redis.Fluent.IRedisCache Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Redis.Fluent.IRedisCache>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Redis.Fluent.IRedisCache;
        }
    }
}