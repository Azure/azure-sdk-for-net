// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

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
