// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AzureRedisCache.Tests.InMemoryTests
{
    public class CreateOrUpdateTests
    {
        [Fact]
        public void CreateOrUpdate_Basic()
        {
            string responseString = (@"
            {
	            ""id"" : ""/subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/HydraTest07152014/providers/Microsoft.Cache/Redis/hydraradiscache"",
	            ""location"" : ""North Europe"",
	            ""name"" : ""hydraradiscache"",
	            ""type"" : ""Microsoft.Cache/Redis"",
	            ""tags"" : {},
	            ""properties"" : {
		            ""provisioningState"" : ""Succeeded"",
		            ""sku"": {
                            ""name"": ""Basic"",
                            ""family"": ""C"",
                            ""capacity"": 1
                        },
		            ""redisVersion"" : ""2.8"",
		            ""accessKeys"" : {
			            ""primaryKey"" : ""aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa="",
			            ""secondaryKey"" : ""bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb=""
		            },
		            ""hostName"" : ""hydraradiscache.cache.icbbvt.windows-int.net"",
		            ""port"" : 6379,
		            ""sslPort"" : 6380,
                    ""minimumTlsVersion"": ""1.2""
	            }
            }
            ");
            string requestIdHeader = "0d33aff8-8a4e-4565-b893-a10e52260de0";
            RedisManagementClient client = Utility.GetRedisManagementClient(responseString, requestIdHeader, HttpStatusCode.Created);
            var response = client.Redis.Create(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                Sku = new Sku()
                                                                                {
                                                                                    Name = SkuName.Basic,
                                                                                    Family = SkuFamily.C,
                                                                                    Capacity = 1
                                                                                },
                                                                                MinimumTlsVersion = TlsVersion.OneFullStopTwo
                                                                            });

            Assert.Equal("/subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/HydraTest07152014/providers/Microsoft.Cache/Redis/hydraradiscache", response.Id);
            Assert.Equal("North Europe", response.Location);
            Assert.Equal("hydraradiscache", response.Name);
            Assert.Equal("Microsoft.Cache/Redis", response.Type);

            Assert.Equal(ProvisioningState.Succeeded, response.ProvisioningState);
            Assert.Equal(SkuName.Basic, response.Sku.Name);
            Assert.Equal(SkuFamily.C, response.Sku.Family);
            Assert.Equal(1, response.Sku.Capacity);
            Assert.Equal("2.8", response.RedisVersion);

            Assert.Equal("hydraradiscache.cache.icbbvt.windows-int.net", response.HostName);
            Assert.Equal(6379, response.Port);
            Assert.Equal(6380, response.SslPort);
            Assert.Equal(TlsVersion.OneFullStopTwo, response.MinimumTlsVersion);
        }

        [Fact]
        public void CheckNameAvailability_200()
        {
            RedisManagementClient client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.OK);
            client.Redis.CheckNameAvailability(parameters: new CheckNameAvailabilityParameters
            {
                Name = "cachename",
                Type = "Microsoft.Cache/Redis"
            });
        }

        [Fact]
        public void CreateOrUpdate_EmptyJSONFromCSM()
        {
            string responseString = (@"{}");
            RedisManagementClient client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            var response = client.Redis.Create(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                Sku = new Sku()
                                                                                {
                                                                                    Name = SkuName.Basic,
                                                                                    Family = SkuFamily.C,
                                                                                    Capacity = 1
                                                                                }
                                                                            });
            Assert.Null(response.Id);
            Assert.Null(response.Location);
            Assert.Null(response.Name);
            Assert.Null(response.Type);
        }

        [Fact]
        public void CreateOrUpdate_404()
        {
            RedisManagementClient client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.NotFound);
            Assert.Throws<ErrorResponseException>(() => client.Redis.Create(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                Sku = new Sku()
                                                                                {
                                                                                    Name = SkuName.Basic,
                                                                                    Family = SkuFamily.C,
                                                                                    Capacity = 1
                                                                                }
                                                                            }));

        }

        [Fact]
        public void CheckNameAvailability_409()
        {
            RedisManagementClient client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.Conflict);
            Assert.Throws<ErrorResponseException>(() => client.Redis.CheckNameAvailability(parameters: new CheckNameAvailabilityParameters
            {
                Name = "cachename",
                Type = "Microsoft.Cache/Redis"
            }));
        }

        [Fact]
        public void CreateOrUpdate_ParametersChecking()
        {
            RedisManagementClient client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.NotFound);

            Exception e = Assert.Throws<ValidationException>(() => client.Redis.Create(resourceGroupName: null, name: "cachename",
                                                                            parameters: new RedisCreateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                Sku = new Sku()
                                                                                {
                                                                                    Name = SkuName.Basic,
                                                                                    Family = SkuFamily.C,
                                                                                    Capacity = 1
                                                                                }
                                                                            }));
            Assert.Contains("resourceGroupName", e.Message);
            e = Assert.Throws<ValidationException>(() => client.Redis.Create(resourceGroupName: "resource-group", name: null,
                                                                            parameters: new RedisCreateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                Sku = new Sku()
                                                                                {
                                                                                    Name = SkuName.Basic,
                                                                                    Family = SkuFamily.C,
                                                                                    Capacity = 1
                                                                                }
                                                                            }));
            Assert.Contains("name", e.Message);
            e = Assert.Throws<ValidationException>(() => client.Redis.Create(resourceGroupName: "resource-group", name: "cachename", parameters: null));
            Assert.Contains("parameters", e.Message);
            e = Assert.Throws<ValidationException>(() => client.Redis.Create(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateParameters
                                                                            {
                                                                                Location = null,
                                                                                Sku = new Sku()
                                                                                {
                                                                                    Name = SkuName.Basic,
                                                                                    Family = SkuFamily.C,
                                                                                    Capacity = 1
                                                                                }
                                                                            }));
            Assert.Contains("Location", e.Message);
            e = Assert.Throws<ValidationException>(() => client.Redis.Create(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                Sku = null
                                                                            }));
            Assert.Contains("Sku", e.Message);
            e = Assert.Throws<ValidationException>(() => client.Redis.Create(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                Sku = new Sku()
                                                                                {
                                                                                    Name = null,
                                                                                    Family = SkuFamily.C,
                                                                                    Capacity = 1
                                                                                }
                                                                            }));
            Assert.Contains("Name", e.Message);
            e = Assert.Throws<ValidationException>(() => client.Redis.Create(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                Sku = new Sku()
                                                                                {
                                                                                    Name = SkuName.Basic,
                                                                                    Family = null,
                                                                                    Capacity = 1
                                                                                }
                                                                            }));
            Assert.Contains("Family", e.Message);
        }

        [Fact]
        public void CreateOrUpdate_BasicWithTagsAndConfig()
        {
            string responseString = (@"
            {
	            ""id"" : ""/subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/HydraTest07152014/providers/Microsoft.Cache/Redis/hydraradiscache"",
	            ""location"" : ""North Europe"",
	            ""name"" : ""hydraradiscache"",
	            ""type"" : ""Microsoft.Cache/Redis"",
	            ""tags"" : {""update"": ""done""},
	            ""properties"" : {
		            ""provisioningState"" : ""Succeeded"",
		            ""sku"": {
                            ""name"": ""Basic"",
                            ""family"": ""C"",
                            ""capacity"": 1
                        },
		            ""redisVersion"" : ""2.8"",
                    ""redisConfiguration"": {""maxmemory-policy"": ""allkeys-lru"",""preferred-data-persistence-auth-method"": ""ManagedIdentity"",""aof-backup-enabled"":""Enabled"",""zonal-configuration"":""zonalconfig"",""authnotrequired"":""Enabled""},
		            ""accessKeys"" : {
			            ""primaryKey"" : ""aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa="",
			            ""secondaryKey"" : ""bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb=""
		            },
		            ""hostName"" : ""hydraradiscache.cache.icbbvt.windows-int.net"",
		            ""port"" : 6379,
		            ""sslPort"" : 6380,
                    ""minimumTlsVersion"": ""1.2"",
                    ""replicasPerMaster"": ""2"",
                    ""instances"": [
                    {
                        ""sslPort"": 15000,
                        ""nonSslPort"": 13000
                    },
                    {
                        ""sslPort"": 15001,
                        ""nonSslPort"": 13001
                    },
                    {
                        ""sslPort"": 15002,
                        ""nonSslPort"": 13002
                    },
                    ]
	            }
            }
            ");

            string requestIdHeader = "0d33aff8-8a4e-4565-b893-a10e52260de0";

            RedisManagementClient client = Utility.GetRedisManagementClient(responseString, requestIdHeader, HttpStatusCode.Created);
            var response = client.Redis.Create(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                Sku = new Sku()
                                                                                {
                                                                                    Name = SkuName.Basic,
                                                                                    Family = SkuFamily.C,
                                                                                    Capacity = 1
                                                                                },
                                                                                RedisConfiguration = new RedisCommonPropertiesRedisConfiguration()
                                                                                {
                                                                                    MaxmemoryPolicy = "allkeys-lru",
                                                                                    AofBackupEnabled = "True",
                                                                                    PreferredDataPersistenceAuthMethod = "ManagedIdentity",
                                                                                    Authnotrequired = "Enabled"
                                                                                },
                                                                                MinimumTlsVersion = TlsVersion.OneFullStopTwo,
                                                                                ReplicasPerMaster = 2
                                                                            }); ;

            Assert.Equal("/subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/HydraTest07152014/providers/Microsoft.Cache/Redis/hydraradiscache", response.Id);
            Assert.Equal("North Europe", response.Location);
            Assert.Equal("hydraradiscache", response.Name);
            Assert.Equal("Microsoft.Cache/Redis", response.Type);

            Assert.Equal(ProvisioningState.Succeeded, response.ProvisioningState);
            Assert.Equal(SkuName.Basic, response.Sku.Name);
            Assert.Equal(SkuFamily.C, response.Sku.Family);
            Assert.Equal(1, response.Sku.Capacity);
            Assert.Equal("2.8", response.RedisVersion);
            Assert.Equal("allkeys-lru", response.RedisConfiguration.MaxmemoryPolicy);
            Assert.Equal("ManagedIdentity", response.RedisConfiguration.PreferredDataPersistenceAuthMethod);
            Assert.Equal("Enabled", response.RedisConfiguration.AofBackupEnabled);
            Assert.Equal("zonalconfig", response.RedisConfiguration.ZonalConfiguration);
            Assert.Equal("Enabled", response.RedisConfiguration.Authnotrequired);

            Assert.Equal("hydraradiscache.cache.icbbvt.windows-int.net", response.HostName);
            Assert.Equal(6379, response.Port);
            Assert.Equal(6380, response.SslPort);
            Assert.Equal(TlsVersion.OneFullStopTwo, response.MinimumTlsVersion);
            Assert.Equal(2, response.ReplicasPerMaster);

            Assert.Equal(3, response.Instances.Count);
            for (int i = 0; i < response.Instances.Count; i++)
            {
                Assert.Equal(15000 + i, response.Instances[i].SslPort);
                Assert.Equal(13000 + i, response.Instances[i].NonSslPort);
                Assert.Null(response.Instances[i].ShardId);
                Assert.Null(response.Instances[i].Zone);
            }
        }
    }
}
