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
    public class ListKeysTests
    {
        [Fact]
        public void ListKeys_Basic()
        {
            string responseString = (@"
            {
	            ""primaryKey"": ""sJ+jruGKPHDKsEC8kmoybobH3TZx2njBR3ipEsquZFo="",
	            ""secondaryKey"": ""LwizcpMV3wyVjXJEd/lxMhIlpM3rYx5UlB/aVSl3lUE=""
            }
            ");
            string requestIdHeader = "0d33aff8-8a4e-4565-b893-a10e52260de0";
            RedisManagementClient client = Utility.GetRedisManagementClient(responseString, requestIdHeader, HttpStatusCode.OK);
            RedisListKeysResponse response = client.Redis.ListKeys(resourceGroupName: "resource-group", name: "cachename");

            Assert.Equal(requestIdHeader, response.RequestId);
            Assert.Equal("sJ+jruGKPHDKsEC8kmoybobH3TZx2njBR3ipEsquZFo=", response.PrimaryKey);
            Assert.Equal("LwizcpMV3wyVjXJEd/lxMhIlpM3rYx5UlB/aVSl3lUE=", response.SecondaryKey);
        }

        [Fact]
        public void ListKeys_ParametersChecking()
        {
            RedisManagementClient client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.NotFound);
            Exception e = Assert.Throws<ArgumentNullException>(() => client.Redis.ListKeys(resourceGroupName: null, name: "cachename"));
            Assert.Contains("resourceGroupName", e.Message);
            e = Assert.Throws<ArgumentNullException>(() => client.Redis.ListKeys(resourceGroupName: "resource-group", name: null));
            Assert.Contains("name", e.Message);
        }

        [Fact]
        public void ListKeys_404()
        {
            RedisManagementClient client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.NotFound);
            Assert.Throws<CloudException>(() => client.Redis.ListKeys(resourceGroupName: "resource-group", name: "cachename"));
        }

        [Fact]
        public void ListKeys_InvalidJSONFromCSM()
        {
            string responseString = (@"Exception: Any exception from CSM");
            RedisManagementClient client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            Assert.Throws<Newtonsoft.Json.JsonReaderException>(() => client.Redis.ListKeys(resourceGroupName: "resource-group", name: "cachename"));
        }

        [Fact]
        public void ListKeys_EmptyJSONFromCSM()
        {
            string responseString = (@"{}");
            RedisManagementClient client = Utility.GetRedisManagementClient(responseString, null, HttpStatusCode.OK);
            RedisListKeysResponse response = client.Redis.ListKeys(resourceGroupName: "resource-group", name: "cachename");
            Assert.Null(response.PrimaryKey);
            Assert.Null(response.SecondaryKey);
        }
    }
}
