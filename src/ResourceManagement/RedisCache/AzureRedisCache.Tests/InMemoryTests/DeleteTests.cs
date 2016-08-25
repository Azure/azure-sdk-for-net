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
using Microsoft.Azure;
using Microsoft.Rest.Azure;
using Microsoft.Rest;

namespace AzureRedisCache.Tests
{
    public class DeleteTests
    {
        [Fact]
        public void Delete_Basic()
        {
            string requestIdHeader = "0d33aff8-8a4e-4565-b893-a10e52260de0";
            RedisManagementClient client = Utility.GetRedisManagementClient(null, requestIdHeader, HttpStatusCode.OK);
            client.Redis.Delete(resourceGroupName: "resource-group", name: "cachename");
        }

        [Fact]
        public void Delete_406()
        {
            RedisManagementClient client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.NotAcceptable);
            Assert.Throws<CloudException>(() => client.Redis.Delete(resourceGroupName: "resource-group", name: "cachename"));
        }

        [Fact]
        public void Delete_ParametersChecking()
        {
            RedisManagementClient client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.NotFound);
            Exception e = Assert.Throws<ValidationException>(() => client.Redis.Delete(resourceGroupName: null, name: "cachename"));
            Assert.Contains("resourceGroupName", e.Message);
            e = Assert.Throws<ValidationException>(() => client.Redis.Delete(resourceGroupName: "resource-group", name: null));
            Assert.Contains("name", e.Message);
        }
    }
}
