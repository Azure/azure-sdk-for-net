using FakeItEasy;
using Hyak.Common;
using Microsoft.Azure;
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
    public class RegenerateKeyTests
    {
        [Fact]
        public void RegenerateKey_Basic()
        {
            string requestIdHeader = "0d33aff8-8a4e-4565-b893-a10e52260de0";
            RedisManagementClient client = Utility.GetRedisManagementClient(null, requestIdHeader, HttpStatusCode.OK);
            AzureOperationResponse response = client.Redis.RegenerateKey(resourceGroupName: "resource-group", name: "cachename", parameters: new RedisRegenerateKeyParameters() { KeyType = RedisKeyType.Primary });
            Assert.Equal(requestIdHeader, response.RequestId);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void RegenerateKey_404()
        {
            RedisManagementClient client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.NotFound);
            Assert.Throws<CloudException> (() => client.Redis.RegenerateKey(resourceGroupName: "resource-group", name: "cachename", parameters: new RedisRegenerateKeyParameters() { KeyType = RedisKeyType.Primary }));
        }

        [Fact]
        public void RegenerateKey_ParametersChecking()
        {
            RedisManagementClient client = Utility.GetRedisManagementClient(null, null, HttpStatusCode.NotFound);
            Exception e = Assert.Throws<ArgumentNullException>(() => client.Redis.RegenerateKey(resourceGroupName: null, name: "cachename", parameters: new RedisRegenerateKeyParameters() { KeyType = RedisKeyType.Primary }));
            Assert.Contains("resourceGroupName", e.Message);
            e = Assert.Throws<ArgumentNullException>(() => client.Redis.RegenerateKey(resourceGroupName: "resource-group", name: null, parameters: new RedisRegenerateKeyParameters() { KeyType = RedisKeyType.Primary }));
            Assert.Contains("name", e.Message);
            e = Assert.Throws<ArgumentNullException>(() => client.Redis.RegenerateKey(resourceGroupName: "resource-group", name: "cachename", parameters: null));
            Assert.Contains("parameters", e.Message);
        }
    }
}
