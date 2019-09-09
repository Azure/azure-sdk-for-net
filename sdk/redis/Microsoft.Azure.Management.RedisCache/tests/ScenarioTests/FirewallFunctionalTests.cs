// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AzureRedisCache.Tests.ScenarioTests;
using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace AzureRedisCache.Tests
{
    public class FirewallFunctionalTests : TestBase
    {
        [Fact]
        public void FirewallFunctionalTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var _redisCacheManagementHelper = new RedisCacheManagementHelper(this, context);
                _redisCacheManagementHelper.TryRegisterSubscriptionForResource();

                var resourceGroupName = TestUtilities.GenerateName("RedisFirewall");
                var redisCacheName = TestUtilities.GenerateName("RedisFirewall");
                
                var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this, context);
                _redisCacheManagementHelper.TryCreateResourceGroup(resourceGroupName, RedisCacheManagementHelper.Location);
                _client.Redis.Create(resourceGroupName, redisCacheName,
                                        parameters: new RedisCreateParameters
                                        {
                                            Location = RedisCacheManagementHelper.Location,
                                            Sku = new Sku()
                                            {
                                                Name = SkuName.Premium,
                                                Family = SkuFamily.P,
                                                Capacity = 1
                                            }
                                        });

                // First try to get cache and verify that it is premium cache
                RedisResource response = _client.Redis.Get(resourceGroupName, redisCacheName);
                Assert.Contains(redisCacheName, response.Id);
                Assert.Equal(redisCacheName, response.Name);
                Assert.Equal("succeeded", response.ProvisioningState, ignoreCase: true);
                Assert.Equal(SkuName.Premium, response.Sku.Name);
                Assert.Equal(SkuFamily.P, response.Sku.Family);

                // Set firewall rule for 10.0.0.0 to 10.0.0.32
                RedisFirewallRule ruleOne = _client.FirewallRules.CreateOrUpdate(resourceGroupName, redisCacheName, "RuleOne", new RedisFirewallRuleCreateParameters
                {
                    StartIP = "10.0.0.0",
                    EndIP = "10.0.0.32"
                });
                Assert.Equal("10.0.0.0", ruleOne.StartIP);
                Assert.Equal("10.0.0.32", ruleOne.EndIP);

                // Set firewall rule for 10.0.0.64 to 10.0.0.128
                RedisFirewallRule ruleTwo = _client.FirewallRules.CreateOrUpdate(resourceGroupName, redisCacheName, "RuleTwo", new RedisFirewallRuleCreateParameters
                {
                    StartIP = "10.0.0.64",
                    EndIP = "10.0.0.128"
                });
                Assert.Equal("10.0.0.64", ruleTwo.StartIP);
                Assert.Equal("10.0.0.128", ruleTwo.EndIP);

                // Get test
                ruleOne = _client.FirewallRules.Get(resourceGroupName, redisCacheName, "RuleOne");
                Assert.Equal("10.0.0.0", ruleOne.StartIP);
                Assert.Equal("10.0.0.32", ruleOne.EndIP);

                ruleTwo = _client.FirewallRules.Get(resourceGroupName, redisCacheName, "RuleTwo");
                Assert.Equal("10.0.0.64", ruleTwo.StartIP);
                Assert.Equal("10.0.0.128", ruleTwo.EndIP);

                // List test
                IPage<RedisFirewallRule> rules = _client.FirewallRules.ListByRedisResource(resourceGroupName, redisCacheName);
                Assert.Equal(2, rules.Count());

                // Delete
                _client.FirewallRules.Delete(resourceGroupName, redisCacheName, "RuleTwo");

                rules = _client.FirewallRules.ListByRedisResource(resourceGroupName, redisCacheName);
                Assert.Single(rules);
                Assert.Equal("10.0.0.0", rules.First().StartIP);
                Assert.Equal("10.0.0.32", rules.First().EndIP);

            }
        }
    }
}

