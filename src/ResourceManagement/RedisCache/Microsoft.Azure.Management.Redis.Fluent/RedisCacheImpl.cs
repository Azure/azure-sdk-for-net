// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Redis.Fluent
{
    using Models;
    using Resource.Fluent.Core;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Resource.Fluent;
    using System;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Implementation for Redis Cache and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnJlZGlzLmltcGxlbWVudGF0aW9uLlJlZGlzQ2FjaGVJbXBs
    internal partial class RedisCacheImpl :
        GroupableResource<IRedisCache, RedisResourceInner,
            RedisCacheImpl, IRedisManager,
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
        private IDictionary<Models.DayOfWeek, ScheduleEntry> scheduleEntries;

        ///GENMHASH:A46525F44B70758E2EDBD761F1C43440:CDCB954FF16DBA73112F76E0FBD05F88
        public string SubnetId()
        {
            return Inner.SubnetId;
        }

        ///GENMHASH:DA29E6CF75B7755D5158B0C9AAA9D5A0:A3EDD15A99413A6F39B0B8A0338713D9
        public RedisCacheImpl WithNonSslPort()
        {
            if (IsInCreateMode)
            {
                createParameters.EnableNonSslPort = true;
            }
            else
            {
                updateParameters.EnableNonSslPort = true;
            }
            return this;
        }

        ///GENMHASH:A50A011CA652E846C1780DCE98D171DE:1130E1FDC5A612FAE78D6B24DD71D43E
        public string HostName()
        {
            return Inner.HostName;
        }

        ///GENMHASH:3D7C4113A3F55E3E31A8AB77D2A98BC2:342BB306A1B89F9C0E62BB6844E58611
        public void DeletePatchSchedule()
        {
            patchSchedulesInner.Delete(this.ResourceGroupName, this.Name);
        }

        ///GENMHASH:E0A932BCE095834DF49296A5A1B250F3:9AB43882F1D20579E20CB41390D07940
        public RedisCacheImpl WithSubnet(IHasId networkResource, string subnetName)
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

        ///GENMHASH:8939689DC27B99614145E6616DB6A0BF:60428C770DA47B41ED0FE8196801C941
        public string StaticIP()
        {
            return Inner.StaticIP;
        }

        ///GENMHASH:6EE61FA0DE4D0297160B059C5B56D12A:FCE23512A2C31EB7F68F7065799142F4
        public IRedisAccessKeys Keys()
        {
            if (cachedAccessKeys == null)
            {
                cachedAccessKeys = RefreshKeys();
            }
            return cachedAccessKeys;
        }

        ///GENMHASH:8D7485C72B719CA5E190D69B6FF75F54:EF1EAF9D3B229FCBEC276D19464D4B8C
        public RedisCacheImpl WithBasicSku()
        {
            ///GENMHASH:F792F6C8C594AA68FA7A0FCA92F55B55:43E446F640DC3345BDBD9A3378F2018A
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

        ///GENMHASH:3A939C892B9542A7F3B2D43CFB7641C7:3D66186DDF06CB5C03B9666F446517A0
        public RedisCacheImpl WithBasicSku(int capacity)
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

        ///GENMHASH:6BCE517E09457FF033728269C8936E64:735695BBFA17FB30B54763A64BD24DB2
        public override RedisCache.Update.IUpdate Update()
        {
            this.updateParameters = new RedisUpdateParametersInner();
            this.scheduleEntries = new Dictionary<Models.DayOfWeek, ScheduleEntry>();
            return this;
        }

        ///GENMHASH:7EA43FE4B5DC6873C3A15AE9AF9FD9A2:0176FA0695BE5AF7085965288087F3E6
        public void ImportData(IList<string> files)
        {
            var parameters = new ImportRDBParametersInner
            {
                Files = files
            };
            this.client.ImportData(this.ResourceGroupName, this.Name, parameters);
        }

        ///GENMHASH:797BE61D54080982DA71A130D2628D30:245A7A45CB8ACD07ADC910C1F5C669C3
        public void ImportData(IList<string> files, string fileFormat)
        {
            var parameters = new ImportRDBParametersInner
            {
                Files = files,
                Format = fileFormat
            };
            this.client.ImportData(this.ResourceGroupName, this.Name, parameters);
        }

        ///GENMHASH:9456FDB06E5A3C49F9A7BFDDA1938013:A5E2F06B6C6C37916FED3F7329DBBE32
        public RedisCacheImpl WithShardCount(int shardCount)
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

        ///GENMHASH:E3A7804FB0FA9098FEB1BBC27C0AC302:1D1FD1926CD83B5A53D025D908F50F70
        public void ExportData(string containerSASUrl, string prefix)
        {
            var parameters = new ExportRDBParametersInner
            {
                Container = containerSASUrl,
                Prefix = prefix
            };
            this.client.ExportData(this.ResourceGroupName, this.Name, parameters);
        }

        ///GENMHASH:D36720446E1DFBFE86C7D6259BB131A7:96E7F137224736FF0D8B93037CAC1AB4
        public void ExportData(string containerSASUrl, string prefix, string fileFormat)
        {
            var parameters = new ExportRDBParametersInner
            {
                Container = containerSASUrl,
                Prefix = prefix,
                Format = fileFormat
            };
            this.client.ExportData(this.ResourceGroupName, this.Name, parameters);
        }

        ///GENMHASH:CC99BC6F0FDDE008E581A6EB944FE764:0C30EC62BAFB5962817F1799BCD0FA3F
        public IList<Models.ScheduleEntry> ListPatchSchedules()
        {
            var schedule = patchSchedulesInner.Get(this.ResourceGroupName, this.Name);
            return (schedule == null)? null : schedule.ScheduleEntries;
        }

        ///GENMHASH:83D353023D85D6E91BB9A3E8AC689039:DF02D821D2252D83CC2CDE0D9667F24E
        public IReadOnlyDictionary<string,string> RedisConfiguration()
        {
            return new ReadOnlyDictionary<string,string>(Inner.RedisConfiguration);
        }

        ///GENMHASH:6D1D6050A5B64D726B268700D1D5B76A:B617C9AF570BA31ABDF18E43D8A277EA
        public bool NonSslPort()
        {
            return (Inner.EnableNonSslPort.HasValue)?
                Inner.EnableNonSslPort.Value : false;
        }

        ///GENMHASH:A4D7300B7F198955D626D528C3191C0D:7D05859155D538EA8AAA13A7171F55B2
        public IRedisCachePremium AsPremium()
        {
            if (this.IsPremium())
            {
                return (IRedisCachePremium)this;
            }
            return null;
        }

        ///GENMHASH:1F68C56BDE6C18A1D69F2A7E56996F24:92A35BA32839860728FBFB7B8EF51BC5
        public RedisCacheImpl WithStaticIP(string staticIP)
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

        public Sku Sku()
        {
            return Inner.Sku;
        }

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:C4C75685A8644A15C4342387354A58BB
        public async Task<Microsoft.Azure.Management.Redis.Fluent.IRedisCache> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await client.UpdateAsync(this.ResourceGroupName, this.Name, updateParameters, cancellationToken);

            while (!inner.ProvisioningState.Equals("Succeeded", StringComparison.OrdinalIgnoreCase) &&
                !cancellationToken.IsCancellationRequested)
            {
                await SdkContext.DelayProvider.DelayAsync(30 * 1000, cancellationToken);
                inner = await client.GetAsync(this.ResourceGroupName, this.Name, cancellationToken);
            }
            this.SetInner(inner);
            await this.UpdatePatchSchedules(cancellationToken);
            return this;
        }

        ///GENMHASH:861E02F6BBA5773E9337D78B346B0D6B:A13471591206DDE563C137910EBF8D1F
        public IRedisAccessKeys RegenerateKey(RedisKeyType keyType)
        {
            var response = this.client.RegenerateKey(this.ResourceGroupName, this.Name, keyType);
            cachedAccessKeys = new RedisAccessKeysImpl(response);
            return cachedAccessKeys;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:5E5963AD8180E75B1BDD4665CB491F14
        public override async Task<Microsoft.Azure.Management.Redis.Fluent.IRedisCache> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (IsInCreateMode)
            {
                createParameters.Location = this.RegionName;
                createParameters.Tags = Inner.Tags;
                var inner = await this.client.CreateAsync(this.ResourceGroupName, this.Name, createParameters, cancellationToken);
                this.SetInner(inner);
                await this.UpdatePatchSchedules(cancellationToken);
                return this;
            }
            else
            {
                return await this.UpdateResourceAsync(cancellationToken);
            }
        }

        ///GENMHASH:7EDCF977DFDBB33CAD61C0A35BD4E3F0:FDF1D73E8E4D62C39446855B695C604B
        private async Task UpdatePatchSchedules(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.scheduleEntries != null &&
                this.scheduleEntries.Any())
            {
                var parameters = new RedisPatchScheduleInner
                {
                    ScheduleEntries = new List<ScheduleEntry>()
                };
                foreach (ScheduleEntry entry in this.scheduleEntries.Values)
                {
                    parameters.ScheduleEntries.Add(entry);
                }

                var scheduleEntriesUpdated = await this.patchSchedulesInner.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, parameters, cancellationToken);
                this.scheduleEntries.Clear();
                foreach (ScheduleEntry entry in scheduleEntriesUpdated.ScheduleEntries)
                {
                    this.scheduleEntries.Add(entry.DayOfWeek, entry);
                }
            }
        }

        ///GENMHASH:36C3CA891B448CCCA6D3BB4C29A31470:A33045316FD527F5E8BD1321B1F93CB2
        public IRedisAccessKeys RefreshKeys()
        {
            var response = this.client.ListKeys(this.ResourceGroupName, this.Name);
            cachedAccessKeys = new RedisAccessKeysImpl(response);
            return cachedAccessKeys;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:FEAA566B918E8D6129C37B2AD34F3689
        public override IRedisCache Refresh()
        {
            var redisResourceInner = this.client.Get(this.ResourceGroupName, this.Name);
            this.SetInner(redisResourceInner);
            return this;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:220D4662AAC7DF3BEFAF2B253278E85C
        public string ProvisioningState()
        {
            return Inner.ProvisioningState;
        }

        ///GENMHASH:8E06C1A19EE798AB8D863FD70174E162:EB25F0BF011FB476ED48A193129040E2
        public int SslPort()
        {
            return (Inner.SslPort.HasValue)?
                Inner.SslPort.Value : 0;
        }

        ///GENMHASH:4F64337819291292917CAEDDE1BA957C:61DFF56DF837BA3A7526DB4C6FB3A760
        public RedisCacheImpl WithoutRedisConfiguration()
        {
            if (updateParameters.RedisConfiguration != null)
            {
                updateParameters.RedisConfiguration.Clear();
            }

            return this;
        }

        ///GENMHASH:EE0340B2F8356DEF7F1B64D128A2B48C:D28521C5DD147C307414B1CB76E973D0
        public RedisCacheImpl WithoutRedisConfiguration(string key)
        {
            if (updateParameters.RedisConfiguration != null &&
                updateParameters.RedisConfiguration.ContainsKey(key))
            {
                updateParameters.RedisConfiguration.Remove(key);
            }

            return this;
        }

        ///GENMHASH:0DEA6EED7C42496EBE4A5F0A6169F305:DB027AD772BBD41451F9E589A68B87F8
        public string RedisVersion()
        {
            return Inner.RedisVersion;
        }

        ///GENMHASH:09C8C6B57BAA375B863AFE579BB6807D:91AAC365E5F79518CF38951EBEE910D6
        public RedisCacheImpl WithoutNonSslPort()
        {
            if (!IsInCreateMode)
            {
                updateParameters.EnableNonSslPort = false;
            }
            return this;
        }

        ///GENMHASH:BF1200B4E784F046AF04467F35BAC1C4:F0090A6ECB1B91C3BCFD966232A4C1D4
        public int Port()
        {
            return (Inner.Port.HasValue)?
                Inner.Port.Value : 0;
        }

        ///GENMHASH:00B3FC5713723EC459E8D0BBE862C56F:FB69548FAA3E0BDC93FB1EB6A6E158EC
        public void ForceReboot(string rebootType)
        {
            var parameters = new RedisRebootParametersInner
            {
                RebootType = rebootType
            };
            this.client.ForceReboot(this.ResourceGroupName, this.Name, parameters);
        }

        ///GENMHASH:9514189731558B5E71CF90933A631027:98E14B4429597E5D69A9A512FB31AC81
        public void ForceReboot(string rebootType, int shardId)
        {
            var parameters = new RedisRebootParametersInner
            {
                RebootType = rebootType,
                ShardId = shardId
            };
            this.client.ForceReboot(this.ResourceGroupName, this.Name, parameters);
        }

        ///GENMHASH:30CB47385D9AC0E9818336B698BEF529:4EF4FC902E838999361E1A71DDDF1772
        public RedisCacheImpl WithPremiumSku()
        {
            var newSku = new Sku
            {
                Name = SkuName.Premium,
                Family = SkuFamily.P,
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

        ///GENMHASH:5237FB6E7BCD5E52462CBB82E15EE73E:BB67358C305B16CB80D9D59DEDDC11E9
        public RedisCacheImpl WithPremiumSku(int capacity)
        {
            var newSku = new Sku
            {
                Name = SkuName.Premium,
                Family = SkuFamily.P,
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

        ///GENMHASH:1593AB443F94D260A2681DBAC7A504E4:D07F31B79AEB480685C5B24199EEE067
        public bool IsPremium()
        {
            if (this.Sku().Name.Equals(SkuName.Premium, System.StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        ///GENMHASH:246CCD739A2C2D6763D6C1A7A4C3F1B3:FCB76FD3E14B5306E0C0D9C582A496EF
        public int ShardCount()
        {
            return (Inner.ShardCount.HasValue)?
                Inner.ShardCount.Value : 0;
        }

        ///GENMHASH:D24D0D518EC4AAB3671622B0122F4207:2884FF302CBD610FA22D475BDC8EBC01
        public RedisCacheImpl WithStandardSku()
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

        ///GENMHASH:85220C2FDADE8DCD78F313C8C1D645BE:B3B4FEA837D2E04D13A5DAE50007103A
        public RedisCacheImpl WithStandardSku(int capacity)
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

        ///GENMHASH:1CA727C3FD99D6E28A9659CD7F1CF091:4E78F5B0D0A013537A5A89F07D0A88AD
        internal RedisCacheImpl(
            string name,
            RedisResourceInner innerModel,
            IPatchSchedulesOperations patchSchedulesInner,
            IRedisOperations client,
            IRedisManager redisManager)
            : base(name, innerModel, redisManager)
        {
            this.createParameters = new RedisCreateParametersInner();
            this.updateParameters = new RedisUpdateParametersInner();
            this.patchSchedulesInner = patchSchedulesInner;
            this.scheduleEntries = new Dictionary<Models.DayOfWeek, ScheduleEntry>();
            this.client = client;
        }

        ///GENMHASH:F7A196D3735B12867C5D8141F3638249:ACD54F2F69ECDD6A123AB39BF9034EB6
        public RedisCacheImpl WithRedisConfiguration(IDictionary<string, string> redisConfiguration)
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

        ///GENMHASH:BEAAB097144934E76ACF615386D481B3:4375CEA991BF92F46A862A930235B943
        public RedisCacheImpl WithRedisConfiguration(string key, string value)
        {
            if (IsInCreateMode)
            {
                if (createParameters.RedisConfiguration == null)
                {
                    createParameters.RedisConfiguration = new Dictionary<string, string>();
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

        ///GENMHASH:28A59E2D7BB5002CC1F16417C4F25FD1:90FDAC2D7F671EE3AF491F69172F0D7E
        public RedisCacheImpl WithPatchSchedule(Models.DayOfWeek dayOfWeek, int startHourUtc)
        {
            return this.WithPatchSchedule(new ScheduleEntry
            {
                DayOfWeek = dayOfWeek,
                StartHourUtc = startHourUtc
            });
        }

        ///GENMHASH:6201C51B639713985315AA03C532B541:5848DBA8C0AAE4C5977BD3956E8379ED
        public RedisCacheImpl WithPatchSchedule(Models.DayOfWeek dayOfWeek, int startHourUtc, System.TimeSpan? maintenanceWindow)
        {
            return this.WithPatchSchedule(new ScheduleEntry
            {
                DayOfWeek = dayOfWeek,
                StartHourUtc = startHourUtc,
                MaintenanceWindow = maintenanceWindow
            });
        }

        ///GENMHASH:4DC611DFE1B12D88B1FBC380172484A4:5EA2206D23C4D336706EFB8004C25FC1
        public RedisCacheImpl WithPatchSchedule(IList<Models.ScheduleEntry> scheduleEntry)
        {
            this.scheduleEntries.Clear();
            foreach (ScheduleEntry entry in scheduleEntry)
            {
                this.WithPatchSchedule(entry);
            }

            return this;
        }

        ///GENMHASH:C11AE4C223D196AB7A57470F94A0CDC6:3497B4EAD6A09E77BB7E7007D1973D9A
        public RedisCacheImpl WithPatchSchedule(ScheduleEntry scheduleEntry)
        {
            scheduleEntries[scheduleEntry.DayOfWeek] = scheduleEntry;
            return this;
        }
    }
}
