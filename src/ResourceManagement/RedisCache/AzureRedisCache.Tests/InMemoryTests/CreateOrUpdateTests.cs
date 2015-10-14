using FakeItEasy;
using Hyak.Common;
using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
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

namespace AzureRedisCache.Tests
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
		            ""provisioningState"" : ""creating"",
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
		            ""sslPort"" : 6380
	            }
            }
            ");
            string requestIdHeader = "0d33aff8-8a4e-4565-b893-a10e52260de0";
            RedisManagementClient client = Utility.GetRedisManagementClient(responseString, requestIdHeader, HttpStatusCode.Created);
            RedisCreateOrUpdateResponse response = client.Redis.CreateOrUpdate(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateOrUpdateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                Properties = new RedisProperties
                                                                                {
                                                                                    RedisVersion = "2.8",
                                                                                    Sku = new Sku(){
                                                                                        Name = SkuName.Basic,
                                                                                        Family = SkuFamily.C,
                                                                                        Capacity = 1
                                                                                    }
                                                                                }
                                                                            });

            Assert.Equal(requestIdHeader, response.RequestId);
            Assert.Equal("/subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/HydraTest07152014/providers/Microsoft.Cache/Redis/hydraradiscache", response.Resource.Id);
            Assert.Equal("North Europe", response.Resource.Location);
            Assert.Equal("hydraradiscache", response.Resource.Name);
            Assert.Equal("Microsoft.Cache/Redis", response.Resource.Type);

            Assert.Equal("creating", response.Resource.Properties.ProvisioningState);
            Assert.Equal(SkuName.Basic, response.Resource.Properties.Sku.Name);
            Assert.Equal(SkuFamily.C, response.Resource.Properties.Sku.Family);
            Assert.Equal(1, response.Resource.Properties.Sku.Capacity);
            Assert.Equal("2.8", response.Resource.Properties.RedisVersion);

            Assert.NotNull(response.Resource.Properties.AccessKeys);
            Assert.Equal("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa=", response.Resource.Properties.AccessKeys.PrimaryKey);
            Assert.Equal("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb=", response.Resource.Properties.AccessKeys.SecondaryKey);

            Assert.Equal("hydraradiscache.cache.icbbvt.windows-int.net", response.Resource.Properties.HostName);
            Assert.Equal(6379, response.Resource.Properties.Port);
            Assert.Equal(6380, response.Resource.Properties.SslPort);
        }

        [Fact]
        public void CreateOrUpdate_EmptyJSONFromCSM()
        {
            string responseString = (@"{}");
            RedisManagementClient client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            RedisCreateOrUpdateResponse response = client.Redis.CreateOrUpdate(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateOrUpdateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                Properties = new RedisProperties
                                                                                {
                                                                                    RedisVersion = "2.8",
                                                                                    Sku = new Sku()
                                                                                    {
                                                                                        Name = SkuName.Basic,
                                                                                        Family = SkuFamily.C,
                                                                                        Capacity = 1
                                                                                    }
                                                                                }
                                                                            });
            Assert.Null(response.RequestId);
            Assert.Null(response.Resource.Id);
            Assert.Null(response.Resource.Location);
            Assert.Null(response.Resource.Name);
            Assert.Null(response.Resource.Type);
            Assert.Null(response.Resource.Properties); 
        }

        [Fact]
        public void CreateOrUpdate_404()
        {
            RedisManagementClient client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.NotFound);
            Assert.Throws<CloudException>(() => client.Redis.CreateOrUpdate(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateOrUpdateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                Properties = new RedisProperties
                                                                                {
                                                                                    RedisVersion = "2.8",
                                                                                    Sku = new Sku()
                                                                                    {
                                                                                        Name = SkuName.Basic,
                                                                                        Family = SkuFamily.C,
                                                                                        Capacity = 1
                                                                                    }
                                                                                }
                                                                            }));

        }

        [Fact]
        public void CreateOrUpdate_ParametersChecking()
        {
            RedisManagementClient client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.NotFound);

            Exception e = Assert.Throws<ArgumentNullException>(() => client.Redis.CreateOrUpdate(resourceGroupName: null, name: "cachename",
                                                                            parameters: new RedisCreateOrUpdateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                Properties = new RedisProperties
                                                                                {
                                                                                    RedisVersion = "2.8",
                                                                                    Sku = new Sku()
                                                                                    {
                                                                                        Name = SkuName.Basic,
                                                                                        Family = SkuFamily.C,
                                                                                        Capacity = 1
                                                                                    }
                                                                                }
                                                                            }));
            Assert.Contains("resourceGroupName", e.Message);
            e = Assert.Throws<ArgumentNullException>(() => client.Redis.CreateOrUpdate(resourceGroupName: "resource-group", name: null,
                                                                            parameters: new RedisCreateOrUpdateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                Properties = new RedisProperties
                                                                                {
                                                                                    RedisVersion = "2.8",
                                                                                    Sku = new Sku()
                                                                                    {
                                                                                        Name = SkuName.Basic,
                                                                                        Family = SkuFamily.C,
                                                                                        Capacity = 1
                                                                                    }
                                                                                }
                                                                            }));
            Assert.Contains("name", e.Message);
            e = Assert.Throws<ArgumentNullException>(() => client.Redis.CreateOrUpdate(resourceGroupName: "resource-group", name: "cachename", parameters: null));
            Assert.Contains("parameters", e.Message);
            e = Assert.Throws<ArgumentNullException>(() => client.Redis.CreateOrUpdate(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateOrUpdateParameters
                                                                            {
                                                                                Location = null,
                                                                                Properties = new RedisProperties
                                                                                {
                                                                                    RedisVersion = "2.8",
                                                                                    Sku = new Sku()
                                                                                    {
                                                                                        Name = SkuName.Basic,
                                                                                        Family = SkuFamily.C,
                                                                                        Capacity = 1
                                                                                    }
                                                                                }
                                                                            }));
            Assert.Contains("parameters.Location", e.Message);
            e = Assert.Throws<ArgumentNullException>(() => client.Redis.CreateOrUpdate(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateOrUpdateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                Properties = null
                                                                            }));
            Assert.Contains("parameters.Properties", e.Message);
            e = Assert.Throws<ArgumentNullException>(() => client.Redis.CreateOrUpdate(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateOrUpdateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                Properties = new RedisProperties
                                                                                {
                                                                                    RedisVersion = "2.8",
                                                                                    Sku = null
                                                                                }
                                                                            }));
            Assert.Contains("parameters.Properties.Sku", e.Message);
            e = Assert.Throws<ArgumentNullException>(() => client.Redis.CreateOrUpdate(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateOrUpdateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                Properties = new RedisProperties
                                                                                {
                                                                                    RedisVersion = "2.8",
                                                                                    Sku = new Sku()
                                                                                    {
                                                                                        Name = null,
                                                                                        Family = SkuFamily.C,
                                                                                        Capacity = 1
                                                                                    }
                                                                                }
                                                                            }));
            Assert.Contains("parameters.Properties.Sku.Name", e.Message);
            e = Assert.Throws<ArgumentNullException>(() => client.Redis.CreateOrUpdate(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateOrUpdateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                Properties = new RedisProperties
                                                                                {
                                                                                    RedisVersion = "2.8",
                                                                                    Sku = new Sku()
                                                                                    {
                                                                                        Name = SkuName.Basic,
                                                                                        Family = null,
                                                                                        Capacity = 1
                                                                                    }
                                                                                }
                                                                            }));
            Assert.Contains("parameters.Properties.Sku.Family", e.Message);
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
		            ""provisioningState"" : ""creating"",
		            ""sku"": {
                            ""name"": ""Basic"",
                            ""family"": ""C"",
                            ""capacity"": 1
                        },
		            ""redisVersion"" : ""2.8"",
                    ""redisConfiguration"": {""maxmemory-policy"": ""allkeys-lru""},
		            ""accessKeys"" : {
			            ""primaryKey"" : ""aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa="",
			            ""secondaryKey"" : ""bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb=""
		            },
		            ""hostName"" : ""hydraradiscache.cache.icbbvt.windows-int.net"",
		            ""port"" : 6379,
		            ""sslPort"" : 6380
	            }
            }
            ");

            string requestIdHeader = "0d33aff8-8a4e-4565-b893-a10e52260de0";

            RedisManagementClient client = Utility.GetRedisManagementClient(responseString, requestIdHeader, HttpStatusCode.Created);
            RedisCreateOrUpdateResponse response = client.Redis.CreateOrUpdate(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateOrUpdateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                Properties = new RedisProperties
                                                                                {
                                                                                    RedisVersion = "2.8",
                                                                                    Sku = new Sku()
                                                                                    {
                                                                                        Name = SkuName.Basic,
                                                                                        Family = SkuFamily.C,
                                                                                        Capacity = 1
                                                                                    },
                                                                                    RedisConfiguration = new Dictionary<string, string>() { 
                                                                                        {"maxmemory-policy","allkeys-lru"}
                                                                                    }
                                                                                }
                                                                            });

            Assert.Equal(requestIdHeader, response.RequestId);
            Assert.Equal("/subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/HydraTest07152014/providers/Microsoft.Cache/Redis/hydraradiscache", response.Resource.Id);
            Assert.Equal("North Europe", response.Resource.Location);
            Assert.Equal("hydraradiscache", response.Resource.Name);
            Assert.Equal("Microsoft.Cache/Redis", response.Resource.Type);

            Assert.Equal("creating", response.Resource.Properties.ProvisioningState);
            Assert.Equal(SkuName.Basic, response.Resource.Properties.Sku.Name);
            Assert.Equal(SkuFamily.C, response.Resource.Properties.Sku.Family);
            Assert.Equal(1, response.Resource.Properties.Sku.Capacity);
            Assert.Equal("2.8", response.Resource.Properties.RedisVersion);
            Assert.Equal("allkeys-lru", response.Resource.Properties.RedisConfiguration["maxmemory-policy"]);

            Assert.NotNull(response.Resource.Properties.AccessKeys);
            Assert.Equal("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa=", response.Resource.Properties.AccessKeys.PrimaryKey);
            Assert.Equal("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb=", response.Resource.Properties.AccessKeys.SecondaryKey);

            Assert.Equal("hydraradiscache.cache.icbbvt.windows-int.net", response.Resource.Properties.HostName);
            Assert.Equal(6379, response.Resource.Properties.Port);
            Assert.Equal(6380, response.Resource.Properties.SslPort);
        }
    }
}
