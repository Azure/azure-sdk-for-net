using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
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

            IPage<RedisResource>[] list = new IPage<RedisResource>[4];
            RedisManagementClient client = Utility.GetRedisManagementClient(responseString, requestIdHeader, HttpStatusCode.OK);
            list[0] = client.Redis.ListByResourceGroup(resourceGroupName: "resource-group");
            client = Utility.GetRedisManagementClient(responseString, requestIdHeader, HttpStatusCode.OK);
            list[1] = client.Redis.ListByResourceGroupNext(nextPageLink: nextLinkForAllInResourceGroup);
            client = Utility.GetRedisManagementClient(responseString, requestIdHeader, HttpStatusCode.OK);
            list[2] = client.Redis.List();
            client = Utility.GetRedisManagementClient(responseString, requestIdHeader, HttpStatusCode.OK);
            list[3] = client.Redis.ListNext(nextPageLink: nextLinkForAllInSubscription);

            foreach (IPage<RedisResource> responseList in list)
            {
                Assert.Equal(2, responseList.Count());

                foreach (RedisResource response in responseList)
                {
                    Assert.Contains("/subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/HydraTest07152014/providers/Microsoft.Cache/Redis/hydraradiscache", response.Id);
                    Assert.Contains("North", response.Location);
                    Assert.Contains("hydraradiscache", response.Name);
                    Assert.Equal("Microsoft.Cache/Redis", response.Type);
                    Assert.Equal("succeeded", response.ProvisioningState);
                    Assert.Equal(SkuName.Basic, response.Sku.Name);
                    Assert.Equal(SkuFamily.C, response.Sku.Family);
                    Assert.Equal(1, response.Sku.Capacity);
                    Assert.Equal("2.8", response.RedisVersion);
                    Assert.Contains(".cache.icbbvt.windows-int.net", response.HostName);
                    Assert.Equal(6379, response.Port);
                    Assert.Equal(6380, response.SslPort);
                }
            }
        }

        [Fact]
        public void List_ParametersChecking()
        {
            RedisManagementClient client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.NotFound);
            Exception e = Assert.Throws<ValidationException>(() => client.Redis.ListNext(nextPageLink: null));
            Assert.Contains("nextPageLink", e.Message);
        }

        [Fact]
        public void List_404()
        {
            RedisManagementClient client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.NotFound);
            Assert.Throws<CloudException>(() => client.Redis.ListByResourceGroup(resourceGroupName: "resource-group"));
            client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.NotFound);
            Assert.Throws<CloudException>(() => client.Redis.ListByResourceGroupNext(nextPageLink: nextLinkForAllInResourceGroup));
            client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.NotFound);
            Assert.Throws<CloudException>(() => client.Redis.List());
            client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.NotFound);
            Assert.Throws<CloudException>(() => client.Redis.ListNext(nextPageLink: nextLinkForAllInSubscription));
        }

        [Fact]
        public void List_InvalidJSONFromCSM()
        {
            string responseString = (@"Exception: Any exception from CSM");
            RedisManagementClient client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            Assert.Throws<SerializationException>(() => client.Redis.ListByResourceGroup(resourceGroupName: "resource-group"));
            client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            Assert.Throws<SerializationException>(() => client.Redis.ListByResourceGroupNext(nextPageLink: nextLinkForAllInResourceGroup));
            client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            Assert.Throws<SerializationException>(() => client.Redis.List());
            client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            Assert.Throws<SerializationException>(() => client.Redis.ListNext(nextPageLink: nextLinkForAllInSubscription));
        }
        
        [Fact]
        public void List_EmptyJSONFromCSM()
        {
            string responseString = (@"{}");
            IPage<RedisResource>[] list = new IPage<RedisResource>[4];
            
            RedisManagementClient client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            list[0] = client.Redis.ListByResourceGroup(resourceGroupName: "resource-group");
            client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            list[1] = client.Redis.ListByResourceGroupNext(nextPageLink: nextLinkForAllInResourceGroup);
            client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            list[2] = client.Redis.List();
            client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            list[3] = client.Redis.ListNext(nextPageLink: nextLinkForAllInSubscription);

            foreach (IPage<RedisResource> responseList in list)
            {
                Assert.Equal(0, responseList.Count());
                Assert.Null(responseList.NextPageLink);
            }
        }

        [Fact]
        public void List_InvalidCastFromJSONValueToJSONArray()
        {
            string responseString = (@" {""value"" : ""Invalid Non-Array Value""} ");
            RedisManagementClient client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            Assert.Throws<SerializationException>(() => client.Redis.ListByResourceGroup(resourceGroupName: "resource-group"));
            client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            Assert.Throws<SerializationException>(() => client.Redis.ListByResourceGroupNext(nextPageLink: nextLinkForAllInResourceGroup));
            client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            Assert.Throws<SerializationException>(() => client.Redis.List());
            client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            Assert.Throws<SerializationException>(() => client.Redis.ListNext(nextPageLink: nextLinkForAllInSubscription));
        }
        
    }
}
