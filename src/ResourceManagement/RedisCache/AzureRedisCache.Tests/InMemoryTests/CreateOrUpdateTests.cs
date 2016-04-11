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
            RedisResourceWithAccessKey response = client.Redis.CreateOrUpdate(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateOrUpdateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                RedisVersion = "2.8",
                                                                                Sku = new Sku()
                                                                                {
                                                                                    Name = SkuName.Basic,
                                                                                    Family = SkuFamily.C,
                                                                                    Capacity = 1
                                                                                }
                                                                            });

            Assert.Equal("/subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/HydraTest07152014/providers/Microsoft.Cache/Redis/hydraradiscache", response.Id);
            Assert.Equal("North Europe", response.Location);
            Assert.Equal("hydraradiscache", response.Name);
            Assert.Equal("Microsoft.Cache/Redis", response.Type);

            Assert.Equal("creating", response.ProvisioningState);
            Assert.Equal(SkuName.Basic, response.Sku.Name);
            Assert.Equal(SkuFamily.C, response.Sku.Family);
            Assert.Equal(1, response.Sku.Capacity);
            Assert.Equal("2.8", response.RedisVersion);

            Assert.NotNull(response.AccessKeys);
            Assert.Equal("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa=", response.AccessKeys.PrimaryKey);
            Assert.Equal("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb=", response.AccessKeys.SecondaryKey);

            Assert.Equal("hydraradiscache.cache.icbbvt.windows-int.net", response.HostName);
            Assert.Equal(6379, response.Port);
            Assert.Equal(6380, response.SslPort);
        }

        [Fact]
        public void CreateOrUpdate_EmptyJSONFromCSM()
        {
            string responseString = (@"{}");
            RedisManagementClient client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            RedisResourceWithAccessKey response = client.Redis.CreateOrUpdate(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateOrUpdateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                RedisVersion = "2.8",
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
            Assert.Throws<CloudException>(() => client.Redis.CreateOrUpdate(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateOrUpdateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                RedisVersion = "2.8",
                                                                                Sku = new Sku()
                                                                                {
                                                                                    Name = SkuName.Basic,
                                                                                    Family = SkuFamily.C,
                                                                                    Capacity = 1
                                                                                }
                                                                            }));

        }

        [Fact]
        public void CreateOrUpdate_ParametersChecking()
        {
            RedisManagementClient client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.NotFound);

            Exception e = Assert.Throws<ValidationException>(() => client.Redis.CreateOrUpdate(resourceGroupName: null, name: "cachename",
                                                                            parameters: new RedisCreateOrUpdateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                RedisVersion = "2.8",
                                                                                Sku = new Sku()
                                                                                {
                                                                                    Name = SkuName.Basic,
                                                                                    Family = SkuFamily.C,
                                                                                    Capacity = 1
                                                                                }
                                                                            }));
            Assert.Contains("resourceGroupName", e.Message);
            e = Assert.Throws<ValidationException>(() => client.Redis.CreateOrUpdate(resourceGroupName: "resource-group", name: null,
                                                                            parameters: new RedisCreateOrUpdateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                RedisVersion = "2.8",
                                                                                Sku = new Sku()
                                                                                {
                                                                                    Name = SkuName.Basic,
                                                                                    Family = SkuFamily.C,
                                                                                    Capacity = 1
                                                                                }
                                                                            }));
            Assert.Contains("name", e.Message);
            e = Assert.Throws<ValidationException>(() => client.Redis.CreateOrUpdate(resourceGroupName: "resource-group", name: "cachename", parameters: null));
            Assert.Contains("parameters", e.Message);
            e = Assert.Throws<ValidationException>(() => client.Redis.CreateOrUpdate(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateOrUpdateParameters
                                                                            {
                                                                                Location = null,
                                                                                RedisVersion = "2.8",
                                                                                Sku = new Sku()
                                                                                {
                                                                                    Name = SkuName.Basic,
                                                                                    Family = SkuFamily.C,
                                                                                    Capacity = 1
                                                                                }
                                                                            }));
            Assert.Contains("Location", e.Message);
            e = Assert.Throws<ValidationException>(() => client.Redis.CreateOrUpdate(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateOrUpdateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                RedisVersion = "2.8",
                                                                                Sku = null
                                                                            }));
            Assert.Contains("Sku", e.Message);
            e = Assert.Throws<ValidationException>(() => client.Redis.CreateOrUpdate(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateOrUpdateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                RedisVersion = "2.8",
                                                                                Sku = new Sku()
                                                                                {
                                                                                    Name = null,
                                                                                    Family = SkuFamily.C,
                                                                                    Capacity = 1
                                                                                }
                                                                            }));
            Assert.Contains("Name", e.Message);
            e = Assert.Throws<ValidationException>(() => client.Redis.CreateOrUpdate(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateOrUpdateParameters
                                                                            {
                                                                                Location = "North Europe",
                                                                                RedisVersion = "2.8",
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
            RedisResourceWithAccessKey response = client.Redis.CreateOrUpdate(resourceGroupName: "resource-group", name: "cachename",
                                                                            parameters: new RedisCreateOrUpdateParameters
                                                                            {
                                                                                Location = "North Europe",
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
                                                                            });

            Assert.Equal("/subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/HydraTest07152014/providers/Microsoft.Cache/Redis/hydraradiscache", response.Id);
            Assert.Equal("North Europe", response.Location);
            Assert.Equal("hydraradiscache", response.Name);
            Assert.Equal("Microsoft.Cache/Redis", response.Type);

            Assert.Equal("creating", response.ProvisioningState);
            Assert.Equal(SkuName.Basic, response.Sku.Name);
            Assert.Equal(SkuFamily.C, response.Sku.Family);
            Assert.Equal(1, response.Sku.Capacity);
            Assert.Equal("2.8", response.RedisVersion);
            Assert.Equal("allkeys-lru", response.RedisConfiguration["maxmemory-policy"]);

            Assert.NotNull(response.AccessKeys);
            Assert.Equal("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa=", response.AccessKeys.PrimaryKey);
            Assert.Equal("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb=", response.AccessKeys.SecondaryKey);

            Assert.Equal("hydraradiscache.cache.icbbvt.windows-int.net", response.HostName);
            Assert.Equal(6379, response.Port);
            Assert.Equal(6380, response.SslPort);
        }
    }
}
