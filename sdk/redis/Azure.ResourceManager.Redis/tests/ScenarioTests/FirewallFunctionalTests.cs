// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Redis.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Redis.Tests
{
    public class FirewallFunctionalTests : RedisManagementTestBase
    {
        public FirewallFunctionalTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private RedisCollection Collection { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            Collection = ResourceGroup.GetAllRedis();
        }

        [Test]
        public async Task CreateUpdateDeleteTest()
        {
            await SetCollectionsAsync();

            var redisCacheName = Recording.GenerateAssetName("RedisFirewall");
            var parameter = new RedisCreateOrUpdateContent(DefaultLocation, new RedisSku(RedisSkuName.Premium, RedisSkuFamily.Premium, 1));
            await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisCacheName, parameter);

            // First try to get cache and verify that it is premium cache
            var response = (await Collection.GetAsync(redisCacheName)).Value;
            Assert.That(response.Data.Name, Is.EqualTo(redisCacheName));
            Assert.That(response.Data.Sku.Name, Is.EqualTo(RedisSkuName.Premium));
            Assert.That(response.Data.Sku.Family, Is.EqualTo(RedisSkuFamily.Premium));

            // Set firewall rule for 10.0.0.0 to 10.0.0.32
            var firewallCollection = response.GetRedisFirewallRules();

            var firewallData = new RedisFirewallRuleData(IPAddress.Parse("10.0.0.0"), IPAddress.Parse("10.0.0.32"));
            var ruleOne = (await firewallCollection.CreateOrUpdateAsync(WaitUntil.Completed, "RuleOne", firewallData)).Value;
            Assert.That(ruleOne.Data.StartIP.ToString(), Is.EqualTo("10.0.0.0"));
            Assert.That(ruleOne.Data.EndIP.ToString(), Is.EqualTo("10.0.0.32"));

            // Set firewall rule for 10.0.0.64 to 10.0.0.128
            firewallData = new RedisFirewallRuleData(IPAddress.Parse("10.0.0.64"), IPAddress.Parse("10.0.0.128"));
            var ruleTwo = (await firewallCollection.CreateOrUpdateAsync(WaitUntil.Completed, "RuleTwo", firewallData)).Value;
            Assert.That(ruleTwo.Data.StartIP.ToString(), Is.EqualTo("10.0.0.64"));
            Assert.That(ruleTwo.Data.EndIP.ToString(), Is.EqualTo("10.0.0.128"));

            // Get test
            ruleOne = (await firewallCollection.GetAsync("RuleOne")).Value;
            Assert.That(ruleOne.Data.StartIP.ToString(), Is.EqualTo("10.0.0.0"));
            Assert.That(ruleOne.Data.EndIP.ToString(), Is.EqualTo("10.0.0.32"));

            ruleTwo = (await firewallCollection.GetAsync("RuleTwo")).Value;
            Assert.That(ruleTwo.Data.StartIP.ToString(), Is.EqualTo("10.0.0.64"));
            Assert.That(ruleTwo.Data.EndIP.ToString(), Is.EqualTo("10.0.0.128"));

            // List test
            var rules = await firewallCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(rules.Count, Is.EqualTo(2));

            // Delete
            await ruleTwo.DeleteAsync(WaitUntil.Completed);
            rules = await firewallCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(rules.Count, Is.EqualTo(1));
            var falseResult = (await firewallCollection.ExistsAsync("RuleTwo")).Value;
            Assert.That(falseResult, Is.False);
        }
    }
}
