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
    public class GetAllTests
    {
        private string nextLinkForAllInResourceGroup = "https://api-next.resources.windows-int.net/subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/resourceGroupName/providers/Microsoft.Cache/Redis/?api-version=2014-04-01-preview";
        private string nextLinkForAllInSubscription = "https://api-next.resources.windows-int.net/subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/providers/Microsoft.Cache/Redis/?api-version=2014-04-01-preview";

        [Fact]
        public void List_Basic()
        {
            string responseString = (@"
            {
	            ""value"": [{
		            ""id"": ""/subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/HydraTest07152014/providers/Microsoft.Cache/Redis/hydraradiscache3"",
		            ""location"": ""NorthCentralUS"",
		            ""name"": ""hydraradiscache3"",
		            ""type"": ""Microsoft.Cache/Redis"",
		            ""tags"": {},
		            ""properties"": {
			            ""provisioningState"": ""succeeded"",
			            ""sku"": {
                            ""name"": ""Basic"",
                            ""family"": ""C"",
                            ""capacity"": 1
                        },
		                ""redisVersion"" : ""2.8"",
		                ""accessKeys"": null,
			            ""hostName"": ""hydraradiscache3.cache.icbbvt.windows-int.net"",
			            ""port"": 6379,
			            ""sslPort"": 6380
		            }
	            },
	            {
		            ""id"": ""/subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/HydraTest07152014/providers/Microsoft.Cache/Redis/hydraradiscache"",
		            ""location"": ""NorthEurope"",
		            ""name"": ""hydraradiscache"",
		            ""type"": ""Microsoft.Cache/Redis"",
		            ""tags"": {""update"": ""done""},
		            ""properties"": {
			            ""provisioningState"": ""succeeded"",
			            ""sku"": {
                            ""name"": ""Basic"",
                            ""family"": ""C"",
                            ""capacity"": 1
                        },
		                ""redisVersion"" : ""2.8"",
		                ""maxMemoryPolicy"": ""AllKeysLRU"",
			            ""accessKeys"": null,
			            ""hostName"": ""hydraradiscache.cache.icbbvt.windows-int.net"",
			            ""port"": 6379,
			            ""sslPort"": 6380
		            }
	            }]
            }");

            string requestIdHeader = "0d33aff8-8a4e-4565-b893-a10e52260de0";
            
            RedisListResponse[] list = new RedisListResponse[4];
            RedisManagementClient client = Utility.GetRedisManagementClient(responseString, requestIdHeader, HttpStatusCode.OK);
            list[0] = client.Redis.List(resourceGroupName: "resource-group");
            client = Utility.GetRedisManagementClient(responseString, requestIdHeader, HttpStatusCode.OK);
            list[1] = client.Redis.ListNext(nextLink: nextLinkForAllInResourceGroup);
            client = Utility.GetRedisManagementClient(responseString, requestIdHeader, HttpStatusCode.OK);
            list[2] = client.Redis.List(null);
            client = Utility.GetRedisManagementClient(responseString, requestIdHeader, HttpStatusCode.OK);
            list[3] = client.Redis.ListNext(nextLink: nextLinkForAllInSubscription);

            foreach (RedisListResponse responseList in list)
            {
                Assert.Equal(requestIdHeader, responseList.RequestId);
                Assert.Equal(2, responseList.Value.Count);

                foreach (RedisResource response in responseList.Value)
                {
                    Assert.Contains("/subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/HydraTest07152014/providers/Microsoft.Cache/Redis/hydraradiscache", response.Id);
                    Assert.Contains("North", response.Location);
                    Assert.Contains("hydraradiscache", response.Name);
                    Assert.Equal("Microsoft.Cache/Redis", response.Type);
                    Assert.Equal("succeeded", response.Properties.ProvisioningState);
                    Assert.Equal(SkuName.Basic, response.Properties.Sku.Name);
                    Assert.Equal(SkuFamily.C, response.Properties.Sku.Family);
                    Assert.Equal(1, response.Properties.Sku.Capacity);
                    Assert.Equal("2.8", response.Properties.RedisVersion);
                    Assert.Contains(".cache.icbbvt.windows-int.net", response.Properties.HostName);
                    Assert.Equal(6379, response.Properties.Port);
                    Assert.Equal(6380, response.Properties.SslPort);
                }
            }
        }

        [Fact]
        public void List_ParametersChecking()
        {
            RedisManagementClient client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.NotFound);
            Exception e = Assert.Throws<ArgumentNullException>(() => client.Redis.ListNext(nextLink: null));
            Assert.Contains("nextLink", e.Message);
        }

        [Fact]
        public void List_404()
        {
            RedisManagementClient client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.NotFound);
            Assert.Throws<CloudException>(() => client.Redis.List(resourceGroupName: "resource-group"));
            client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.NotFound);
            Assert.Throws<CloudException>(() => client.Redis.ListNext(nextLink: nextLinkForAllInResourceGroup));
            client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.NotFound);
            Assert.Throws<CloudException>(() => client.Redis.List(null));
            client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.NotFound);
            Assert.Throws<CloudException>(() => client.Redis.ListNext(nextLink: nextLinkForAllInSubscription));
        }

        [Fact]
        public void List_InvalidJSONFromCSM()
        {
            string responseString = (@"Exception: Any exception from CSM");
            RedisManagementClient client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            Assert.Throws<Newtonsoft.Json.JsonReaderException>(() => client.Redis.List(resourceGroupName: "resource-group"));
            client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            Assert.Throws<Newtonsoft.Json.JsonReaderException>(() => client.Redis.ListNext(nextLink: nextLinkForAllInResourceGroup));
            client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            Assert.Throws<Newtonsoft.Json.JsonReaderException>(() => client.Redis.List(null));
            client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            Assert.Throws<Newtonsoft.Json.JsonReaderException>(() => client.Redis.ListNext(nextLink: nextLinkForAllInSubscription));
        }
        
        [Fact]
        public void List_EmptyJSONFromCSM()
        {
            string responseString = (@"{}");
            RedisListResponse[] list = new RedisListResponse[4];
            
            RedisManagementClient client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            list[0] = client.Redis.List(resourceGroupName: "resource-group");
            client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            list[1] = client.Redis.ListNext(nextLink: nextLinkForAllInResourceGroup);
            client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            list[2] = client.Redis.List(null);
            client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            list[3] = client.Redis.ListNext(nextLink: nextLinkForAllInSubscription);

            foreach (RedisListResponse responseList in list)
            {
                Assert.Equal(0, responseList.Value.Count);
                Assert.Null(responseList.NextLink);
            }
        }

        [Fact]
        public void List_InvalidCastFromJSONValueToJSONArray()
        {
            string responseString = (@" {""value"" : ""Invalid Non-Array Value""} ");
            RedisManagementClient client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            Assert.Throws<System.InvalidCastException>(() => client.Redis.List(resourceGroupName: "resource-group"));
            client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            Assert.Throws<System.InvalidCastException>(() => client.Redis.ListNext(nextLink: nextLinkForAllInResourceGroup));
            client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            Assert.Throws<System.InvalidCastException>(() => client.Redis.List(null));
            client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            Assert.Throws<System.InvalidCastException>(() => client.Redis.ListNext(nextLink: nextLinkForAllInSubscription));
        }
        
    }
}
