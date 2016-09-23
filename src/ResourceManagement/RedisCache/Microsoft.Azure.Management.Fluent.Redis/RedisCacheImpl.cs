// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Redis
{
    using Microsoft.Azure.Management.Fluent.Redis.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using RedisCache.Update;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using V2.Resource;

    /// <summary>
    /// Implementation for Redis Cache and its parent interfaces.
    /// </summary>
    internal partial class RedisCacheImpl  :
        GroupableResource<IRedisCache, RedisResourceInner, Rest.Azure.Resource, RedisCacheImpl, IRedisManager,
            RedisCache.Definition.IWithGroup,
            RedisCache.Definition.IWithSku,
            RedisCache.Definition.IWithCreate,
            RedisCache.Update.IUpdate>,
        IRedisCache,
        IRedisCachePremium,
        RedisCache.Definition.IDefinition,
        RedisCache.Update.IUpdate
    {
        private IPatchSchedulesOperations patchSchedulesInner;
        private IRedisOperations client;
        private IRedisAccessKeys cachedAccessKeys;
        private RedisCreateParametersInner createParameters;
        private RedisUpdateParametersInner updateParameters;
        private IDictionary<DayOfWeek,ScheduleEntry> scheduleEntries;

        internal RedisCacheImpl (
            string name, 
            RedisResourceInner innerModel, 
            IPatchSchedulesOperations patchSchedulesInner, 
            IRedisOperations client, 
            RedisManager redisManager)
            : base(name, innerModel, redisManager)
        {
            this.createParameters = new RedisCreateParametersInner();
            this.updateParameters = new RedisUpdateParametersInner();
            this.patchSchedulesInner = patchSchedulesInner;
            this.scheduleEntries = new Dictionary<DayOfWeek, ScheduleEntry>();
            this.client = client;
        }

        public string ProvisioningState
        {
            get
            {
                return this.Inner.ProvisioningState;
            }
        }
        public string HostName
        {
            get
            {
                return this.Inner.HostName;
            }
        }
        public int? Port
        {
            get
            {
                return this.Inner.Port;
            }
        }
        public int? SslPort
        {
            get
            {
                return this.Inner.SslPort;
            }
        }
        public string RedisVersion
        {
            get
            {
                return this.Inner.RedisVersion;
            }
        }
        public Sku Sku
        {
            get
            {
                return this.Inner.Sku;
            }
        }
        public bool? NonSslPort
        {
            get
            {
                return this.Inner.EnableNonSslPort;
            }
        }
        public int? ShardCount
        {
            get
            {
                return this.Inner.ShardCount;
            }
        }
        public string SubnetId
        {
            get
            {
                return this.Inner.SubnetId;
            }
        }
        public string StaticIP
        {
            get
            {
                return this.Inner.StaticIP;
            }
        }
        public IDictionary<string,string> RedisConfiguration
        {
            get
            {
                return this.Inner.RedisConfiguration;
            }
        }
        public IRedisCachePremium AsPremium ()
        {
            if (this.IsPremium)
            {
                return (IRedisCachePremium) this;
            }
            return null;
        }

        public bool IsPremium
        {
            get
            {
                if (this.Sku.Name.Equals(SkuName.Premium, System.StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                return false;
            }
        }
        public IRedisAccessKeys Keys ()
        {
            if (cachedAccessKeys == null)
            {
                cachedAccessKeys = RefreshKeys();
            }
            return cachedAccessKeys;
        }

        public IRedisAccessKeys RefreshKeys ()
        {
            var response = this.client.ListKeys(this.ResourceGroupName, this.Name);
            cachedAccessKeys = new RedisAccessKeysImpl(response);
            return cachedAccessKeys;
        }

        public IRedisAccessKeys RegenerateKey (RedisKeyType keyType)
        {
            var response = this.client.RegenerateKey(this.ResourceGroupName, this.Name, keyType);
            cachedAccessKeys = new RedisAccessKeysImpl(response);
            return cachedAccessKeys;
        }

        public void ForceReboot (string rebootType)
        {
            var parameters = new RedisRebootParametersInner
                                {
                                    RebootType = rebootType
                                };
            this.client.ForceReboot(this.ResourceGroupName, this.Name, parameters);
        }

        public void ForceReboot (string rebootType, int shardId)
        {
            var parameters = new RedisRebootParametersInner
                                {
                                    RebootType = rebootType,
                                    ShardId = shardId
                                };
            this.client.ForceReboot(this.ResourceGroupName, this.Name, parameters);
        }

        public void ImportData (IList<string> files)
        {
            var parameters = new ImportRDBParametersInner
                                {
                                    Files = files
                                };
            this.client.ImportData(this.ResourceGroupName, this.Name, parameters);
        }

        public void ImportData (IList<string> files, string fileFormat)
        {
            var parameters = new ImportRDBParametersInner
                                {
                                    Files = files,
                                    Format = fileFormat
                                };
            this.client.ImportData(this.ResourceGroupName, this.Name, parameters);
        }

        public void ExportData (string containerSASUrl, string prefix)
        {
            var parameters = new ExportRDBParametersInner
                                {
                                    Container = containerSASUrl,
                                    Prefix = prefix
                                };
            this.client.ExportData(this.ResourceGroupName, this.Name, parameters);
        }

        public void ExportData (string containerSASUrl, string prefix, string fileFormat)
        {
            var parameters = new ExportRDBParametersInner
                                {
                                    Container = containerSASUrl,
                                    Prefix = prefix,
                                    Format = fileFormat
            };
            this.client.ExportData(this.ResourceGroupName, this.Name, parameters);
        }

        public override async Task<IRedisCache> Refresh ()
        {
            var redisResourceInner = await this.client.GetAsync(this.ResourceGroupName, this.Name);
            this.SetInner(redisResourceInner);
            return this;
        }

        public RedisCacheImpl WithNonSslPort ()
        {
            if (IsInCreateMode)
            {
                createParameters.EnableNonSslPort = true;
            } else
            {
                updateParameters.EnableNonSslPort = true;
            }
            return this;
        }

        public RedisCacheImpl WithoutNonSslPort ()
        {
            if (!IsInCreateMode) 
            {
                updateParameters.EnableNonSslPort = false;
            }
            return this;
        }

        public RedisCacheImpl WithRedisConfiguration (IDictionary<string,string> redisConfiguration)
        {
            if (IsInCreateMode)
            {
                createParameters.RedisConfiguration = redisConfiguration;
            }
            else
            {
                updateParameters.RedisConfiguration = redisConfiguration;
            }
            return this;
        }

        public RedisCacheImpl WithRedisConfiguration (string key, string value)
        {
            if (IsInCreateMode) 
            {
                if (createParameters.RedisConfiguration == null)
                {
                    createParameters.RedisConfiguration = new Dictionary<string,string>();
                }
                createParameters.RedisConfiguration[key] = value;
            }
            else
            {
                if (updateParameters.RedisConfiguration == null)
                {
                    updateParameters.RedisConfiguration = new Dictionary<string, string>();
                }
                updateParameters.RedisConfiguration[key] = value;
            }
            return this;
        }

        public RedisCacheImpl WithoutRedisConfiguration ()
        {
            if (updateParameters.RedisConfiguration != null)
            {
                updateParameters.RedisConfiguration.Clear();
            }

            return this;
        }

        public RedisCacheImpl WithoutRedisConfiguration (string key)
        {
            if (updateParameters.RedisConfiguration != null && 
                updateParameters.RedisConfiguration.ContainsKey(key))
            {
                updateParameters.RedisConfiguration.Remove(key);
            }

            return this;
        }

        public RedisCacheImpl WithSubnet (IGroupableResource networkResource, string subnetName)
        {
            if (networkResource != null)
            {
                var subnetId = networkResource.Id + "/subnets/" + subnetName;
                if (IsInCreateMode)
                {
                    createParameters.SubnetId = subnetId;
                }
                else
                {
                    updateParameters.SubnetId = subnetId;
                }
            }

            return this;
        }

        public RedisCacheImpl WithStaticIP (string staticIP)
        {
            if (IsInCreateMode)
            {
                createParameters.StaticIP = staticIP;
            }
            else
            {
                updateParameters.StaticIP = staticIP;
            }

            return this;
        }

        public RedisCacheImpl WithBasicSku ()
        {
            var newSku = new Sku
            {
                Name = SkuName.Basic,
                Family = SkuFamily.C
            };

            if (IsInCreateMode)
            {
                createParameters.Sku = newSku;
            }
            else
            {
                updateParameters.Sku = newSku;
            }

            return this;
        }

        public RedisCacheImpl WithBasicSku (int capacity)
        {
            var newSku = new Sku
            {
                Name = SkuName.Basic,
                Family = SkuFamily.C,
                Capacity = capacity

            };

            if (IsInCreateMode)
            {
                createParameters.Sku = newSku;
            }
            else
            {
                updateParameters.Sku = newSku;
            }

            return this;
        }

        public RedisCacheImpl WithStandardSku ()
        {
            var newSku = new Sku
            {
                Name = SkuName.Standard,
                Family = SkuFamily.C
            };

            if (IsInCreateMode)
            {
                createParameters.Sku = newSku;
            }
            else
            {
                updateParameters.Sku = newSku;
            }

            return this;
        }

        public RedisCacheImpl WithStandardSku (int capacity)
        {
            var newSku = new Sku
            {
                Name = SkuName.Standard,
                Family = SkuFamily.C,
                Capacity = capacity

            };

            if (IsInCreateMode)
            {
                createParameters.Sku = newSku;
            }
            else
            {
                updateParameters.Sku = newSku;
            }

            return this;
        }

        public RedisCacheImpl WithPremiumSku ()
        {
            var newSku = new Sku
            {
                Name = SkuName.Premium,
                Family = SkuFamily.C,
                Capacity = 1
            };

            if (IsInCreateMode)
            {
                createParameters.Sku = newSku;
            }
            else
            {
                updateParameters.Sku = newSku;
            }

            return this;
        }

        public RedisCacheImpl WithPremiumSku (int capacity)
        {
            var newSku = new Sku
            {
                Name = SkuName.Premium,
                Family = SkuFamily.C,
                Capacity = capacity
            };

            if (IsInCreateMode)
            {
                createParameters.Sku = newSku;
            }
            else
            {
                updateParameters.Sku = newSku;
            }

            return this;
        }

        public RedisCacheImpl WithShardCount (int shardCount)
        {
            if (IsInCreateMode)
            {
                createParameters.ShardCount = shardCount;
            }
            else
            {
                updateParameters.ShardCount = shardCount;
            }

            return this;
        }

        public RedisCacheImpl WithPatchSchedule(DayOfWeek dayOfWeek, int startHourUtc)
        {
            return this.WithPatchSchedule(new ScheduleEntry
            {
                DayOfWeek = dayOfWeek,
                StartHourUtc = startHourUtc
            });
        }

        public RedisCacheImpl WithPatchSchedule (DayOfWeek dayOfWeek, int startHourUtc, System.TimeSpan? maintenanceWindow)
        {
            return this.WithPatchSchedule(new ScheduleEntry
            {
                DayOfWeek = dayOfWeek,
                StartHourUtc = startHourUtc,
                MaintenanceWindow = maintenanceWindow
            });
        }

        public RedisCacheImpl WithPatchSchedule (IList<ScheduleEntry> scheduleEntry)
        {
            this.scheduleEntries.Clear();
            foreach (ScheduleEntry entry in scheduleEntry)
            {
                this.WithPatchSchedule(entry);
            }

            return this;
        }

        public RedisCacheImpl WithPatchSchedule (ScheduleEntry scheduleEntry)
        {
            scheduleEntries[scheduleEntry.DayOfWeek] = scheduleEntry;
            return this;
        }

        public IList<ScheduleEntry> GetPatchSchedules()
        {
            return patchSchedulesInner
                .Get(this.ResourceGroupName, this.Name)
                .ScheduleEntries;
        }

        public void DeletePatchSchedule ()
        {
            patchSchedulesInner.Delete(this.ResourceGroupName, this.Name);
        }

        private async Task UpdatePatchSchedules ()
        {
            if (this.scheduleEntries != null &&
                this.scheduleEntries.Any())
            {
                var parameters = new RedisPatchScheduleInner
                                    {
                                        ScheduleEntries = new List<ScheduleEntry>()
                                    };
                foreach(ScheduleEntry entry in this.scheduleEntries.Values)
                {
                    parameters.ScheduleEntries.Add(entry);
                }

                var scheduleEntriesUpdated = await this.patchSchedulesInner.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, parameters);
                this.scheduleEntries.Clear();
                foreach (ScheduleEntry entry in scheduleEntriesUpdated.ScheduleEntries)
                {
                    this.scheduleEntries.Add(entry.DayOfWeek, entry);
                }
            }
        }

        public override IUpdate Update ()
        {
            this.updateParameters = new RedisUpdateParametersInner();
            this.scheduleEntries = new Dictionary<DayOfWeek,ScheduleEntry>();
            return this;
        }

        public async Task<IRedisCache> ApplyUpdateAsync (CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await client.UpdateAsync(this.ResourceGroupName, this.Name, updateParameters);
            this.SetInner(inner);
            await this.UpdatePatchSchedules();
            return this;
        }

        public override async Task<IRedisCache> CreateResourceAsync (CancellationToken cancellationToken = default(CancellationToken))
        {
            createParameters.Location = this.RegionName;
            createParameters.Tags = this.Inner.Tags;
            var inner = await this.client.CreateAsync(this.ResourceGroupName, this.Name, createParameters);
            this.SetInner(inner);
            await this.UpdatePatchSchedules();
            return this;
        }
    }
}