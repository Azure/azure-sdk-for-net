// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class RouteFilterTests : NetworkServiceClientTestBase
    {
        public RouteFilterTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        private const string Filter_Commmunity = "12076:51006";

        private async Task<RouteFilterCollection> GetCollection()
        {
            var resourceGroup = await CreateResourceGroup(Recording.GenerateAssetName("route_filter_test_"));
            return resourceGroup.GetRouteFilters();
        }

        [Test]
        [RecordedTest]
        public async Task RouteFilterApiTest()
        {
            SubscriptionResource subscription = await ArmClient.GetDefaultSubscriptionAsync();
            var filterCollection = await GetCollection();

            // Create route filter
            string filterName = Recording.GenerateAssetName("filter");
            string ruleName = Recording.GenerateAssetName("rule");

            RouteFilterResource filter = await CreateDefaultRouteFilter(filterCollection,
                filterName);
            Assert.That(filter.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
            Assert.That(filter.Data.Name, Is.EqualTo(filterName));
            Assert.IsEmpty(filter.Data.Rules);

            var filters = await filterCollection.GetAllAsync().ToEnumerableAsync();
            Has.One.Equals(filters);
            Assert.That(filters[0].Data.Name, Is.EqualTo(filterName));
            Assert.IsEmpty(filters[0].Data.Rules);

            var allFilters = await subscription.GetRouteFiltersAsync().ToEnumerableAsync();
            // there could be other filters in the current subscription
            Assert.That(allFilters.Any(f => filterName == f.Data.Name && f.Data.Rules.Count == 0), Is.True);

            // Crete route filter rule
            RouteFilterRuleResource filterRule = await CreateDefaultRouteFilterRule(filter, ruleName);
            Assert.That(filterRule.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
            Assert.That(filterRule.Data.Name, Is.EqualTo(ruleName));

            Response<RouteFilterResource> getFilterResponse = await filterCollection.GetAsync(filterName);
            Assert.That(getFilterResponse.Value.Data.Name, Is.EqualTo(filterName));

            filter = await filterCollection.GetAsync(filterName);
            Assert.That(filter.Data.Name, Is.EqualTo(filterName));
            Has.One.Equals(filter.Data.Rules);
            Assert.That(filter.Data.Rules[0].Name, Is.EqualTo(ruleName));

            filterRule = await filter.GetRouteFilterRules().GetAsync(ruleName);
            Assert.That(filterRule.Data.Name, Is.EqualTo(ruleName));

            // Update route filter
            filterRule.Data.Access = NetworkAccess.Deny;
            var operation = InstrumentOperation(await filter.GetRouteFilterRules().CreateOrUpdateAsync(WaitUntil.Completed, ruleName, filterRule.Data));
            await operation.WaitForCompletionAsync();
            Assert.That(filterRule.Data.Name, Is.EqualTo(ruleName));
            Assert.That(filterRule.Data.Access, Is.EqualTo(NetworkAccess.Deny));

            // Add filter rule, this will fail due to the limitation of maximum 1 rule per filter
            Assert.ThrowsAsync<RequestFailedException>(async () => await CreateDefaultRouteFilterRule(filter, Recording.GenerateAssetName("rule2")));

            filter = await filterCollection.GetAsync(filterName);
            Has.One.Equals(filter.Data.Rules);
            Assert.That(filter.Data.Rules[0].Name, Is.EqualTo(ruleName));

            // Delete fileter rule
            await filterRule.DeleteAsync(WaitUntil.Completed);

            var rules = await filter.GetRouteFilterRules().GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(rules);

            // Delete filter
            await filter.DeleteAsync(WaitUntil.Completed);
            allFilters = await subscription.GetRouteFiltersAsync().ToEnumerableAsync();
            Assert.That(allFilters.Any(f => filter.Id == f.Id), Is.False);
        }

        private async Task<RouteFilterResource> CreateDefaultRouteFilter(RouteFilterCollection filterCollection, string filterName,
            bool containsRule = false)
        {
            var filter = new RouteFilterData()
            {
                Location = TestEnvironment.Location,
                Tags = { { "key", "value" } }
            };

            if (containsRule)
            {
                var rule = new RouteFilterRuleData()
                {
                    Name = Recording.GenerateAssetName("test"),
                    Access = NetworkAccess.Allow,
                    Communities = { Filter_Commmunity },
                    Location = TestEnvironment.Location
                };

                filter.Rules.Add(rule);
            }

            // Put route filter
            Operation<RouteFilterResource> filterOperation = InstrumentOperation(await filterCollection.CreateOrUpdateAsync(WaitUntil.Completed, filterName, filter));
            return await filterOperation.WaitForCompletionAsync();
        }

        private async Task<RouteFilterRuleResource> CreateDefaultRouteFilterRule(RouteFilterResource filter,  string ruleName)
        {
            var rule = new RouteFilterRuleData()
            {
                Access = NetworkAccess.Allow,
                Communities = { Filter_Commmunity },
                Location = filter.Data.Location
            };

            // Put route filter rule
            Operation<RouteFilterRuleResource> ruleOperation = await filter.GetRouteFilterRules().CreateOrUpdateAsync(WaitUntil.Completed, ruleName, rule);
            Response<RouteFilterRuleResource> ruleResponse = await ruleOperation.WaitForCompletionAsync();
            return ruleResponse;
        }
    }
}
