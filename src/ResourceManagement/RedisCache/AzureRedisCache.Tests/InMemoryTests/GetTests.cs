using Hyak.Common;
using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AzureRedisCache.Tests
{
    public class GetTests
    {
        [Fact]
        public void Get_Basic()
        {
            string responseString = (@"
            {
	            ""id"" : ""/subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/HydraTest07152014/providers/Microsoft.Cache/Redis/hydraradiscache"",
	            ""location"" : ""North Europe"",
	            ""name"" : ""hydraradiscache"",
	            ""type"" : ""Microsoft.Cache/Redis"",
	            ""tags"" : {""update"": ""done""},
	            ""properties"" : {
		            ""provisioningState"" : ""succeeded"",
		            ""sku"": {
                            ""name"": ""Basic"",
                            ""family"": ""C"",
                            ""capacity"": 1
                        },
		            ""redisVersion"" : ""2.8"",
		            ""redisConfiguration"": {""maxmemory-policy"": ""allkeys-lru""},
		            ""accessKeys"" : null,
		            ""hostName"" : ""hydraradiscache.cache.icbbvt.windows-int.net"",
		            ""port"" : 6379,
		            ""sslPort"" : 6380
	            }
            }
            ");
            
            string requestIdHeader = "0d33aff8-8a4e-4565-b893-a10e52260de0";
            RedisManagementClient client = Utility.GetRedisManagementClient(responseString, requestIdHeader, HttpStatusCode.OK);
            RedisGetResponse response = client.Redis.Get(resourceGroupName: "resource-group", name: "cachename");

            Assert.Equal(requestIdHeader, response.RequestId);
            Assert.Equal("/subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/HydraTest07152014/providers/Microsoft.Cache/Redis/hydraradiscache", response.Resource.Id);
            Assert.Equal("North Europe", response.Resource.Location);
            Assert.Equal("hydraradiscache", response.Resource.Name);
            Assert.Equal("Microsoft.Cache/Redis", response.Resource.Type);

            Assert.Equal("succeeded", response.Resource.Properties.ProvisioningState);
            Assert.Equal(SkuName.Basic, response.Resource.Properties.Sku.Name);
            Assert.Equal(SkuFamily.C, response.Resource.Properties.Sku.Family);
            Assert.Equal(1, response.Resource.Properties.Sku.Capacity);
            Assert.Equal("2.8", response.Resource.Properties.RedisVersion);
            Assert.Equal("allkeys-lru", response.Resource.Properties.RedisConfiguration["maxmemory-policy"]);

            Assert.Equal("hydraradiscache.cache.icbbvt.windows-int.net", response.Resource.Properties.HostName);
            Assert.Equal(6379, response.Resource.Properties.Port);
            Assert.Equal(6380, response.Resource.Properties.SslPort);
        }

        [Fact]
        public void Get_ParametersChecking()
        {
            RedisManagementClient client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.NotFound);
            Exception e = Assert.Throws<ArgumentNullException>(() => client.Redis.Get(resourceGroupName: null, name: "cachename"));
            Assert.Contains("resourceGroupName", e.Message);
            e = Assert.Throws<ArgumentNullException>(() => client.Redis.Get(resourceGroupName: "resource-group", name: null));
            Assert.Contains("name", e.Message);
        }

        [Fact]
        public void Get_404()
        {
            RedisManagementClient client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.NotFound);
            Assert.Throws<CloudException>(() => client.Redis.Get(resourceGroupName: "resource-group", name: "cachename"));
        }

        [Fact]
        public void Get_InvalidJSONFromCSM()
        {
            string responseString = (@"Exception: Any exception from CSM");
            RedisManagementClient client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            Assert.Throws<Newtonsoft.Json.JsonReaderException>(() => client.Redis.Get(resourceGroupName: "resource-group", name: "cachename"));
        }

        [Fact]
        public void Get_EmptyJSONFromCSM()
        {
            string responseString = (@"{}");
            RedisManagementClient client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            RedisGetResponse response = client.Redis.Get(resourceGroupName: "resource-group", name: "cachename");
            Assert.Null(response.RequestId);
            Assert.Null(response.Resource.Id);
            Assert.Null(response.Resource.Location);
            Assert.Null(response.Resource.Name);
            Assert.Null(response.Resource.Type);
            Assert.Null(response.Resource.Properties);
        }
    }
}
