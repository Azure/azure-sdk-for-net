using AzureRedisCache.Tests.ScenarioTests;
using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace AzureRedisCache.Tests
{
    public class RebootFunctionalTests : TestBase
    {
        [Fact]
        public void RebootBothNodesTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this, context);

                // First try to get cache and verify that it is premium cache
                RedisResource response = _client.Redis.Get(resourceGroupName: "MyResourceGroup", name: "sunnyprimary");
                Assert.Contains("sunnyprimary", response.Id);
                Assert.Equal("sunnyprimary", response.Name);
                Assert.True("succeeded".Equals(response.ProvisioningState, StringComparison.OrdinalIgnoreCase));
                Assert.Equal(SkuName.Premium, response.Sku.Name);
                Assert.Equal(SkuFamily.P, response.Sku.Family);

                RedisRebootParameters rebootParameter = new RedisRebootParameters {
                    RebootType = RebootType.AllNodes
                };
                _client.Redis.ForceReboot(resourceGroupName: "MyResourceGroup", name: "sunnyprimary", parameters: rebootParameter);
            }
        }
    }
}
