using Microsoft.Azure;
using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AzureRedisCache.Tests
{
    public class UpdateEnableNonSslPortBug : TestBase
    {
        [Fact]
        public void UpdateEnableNonSslPortBugTest()
        {
            TestUtilities.StartTest();
            
            var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this);

            RedisGetResponse responseGet = _client.Redis.Get(resourceGroupName: "SunnySDK25", name: "sunnysdk25-centralus");
            Assert.True(responseGet.Resource.Properties.EnableNonSslPort.Value);

            Dictionary<string, string> redisConfiguration = new Dictionary<string, string>();
            redisConfiguration.Add("maxmemory-policy","allkeys-lru");

            RedisCreateOrUpdateResponse responseCreate = _client.Redis.CreateOrUpdate(resourceGroupName: "SunnySDK25", name: "sunnysdk25-centralus",
                                    parameters: new RedisCreateOrUpdateParameters
                                    {
                                        Location = "Central US",
                                        Properties = new RedisProperties
                                        {
                                            RedisVersion = "2.8",
                                            Sku = new Sku()
                                            {
                                                Name = SkuName.Standard,
                                                Family = SkuFamily.C,
                                                Capacity = 2
                                            },
                                            RedisConfiguration = redisConfiguration
                                        }
                                    });

            Assert.Equal(6379, responseCreate.Resource.Properties.Port);
            Assert.Equal(6380, responseCreate.Resource.Properties.SslPort);
            Assert.True(responseCreate.Resource.Properties.EnableNonSslPort.Value);
            
            TestUtilities.EndTest();
        }
    }
}
