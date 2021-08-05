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

namespace Azure.ResourceManager.Network.Tests.Tests
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

        //[TearDown]
        //public async Task CleanupResourceGroup()
        //{
        //    await CleanupResourceGroupsAsync();
        //}

        private const string Filter_Commmunity = "12076:51006";

        [Test]
        public async Task RouteFilterApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/routefilters");
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            var filterContainer = resourceGroup.Value.GetRouteFilters();
            // Create route filter
            string filterName = "filter";
            string ruleName = "rule";

            RouteFilter filter = await CreateDefaultRouteFilter(filterContainer,
                filterName, location);
            Assert.AreEqual("Succeeded", filter.Data.ProvisioningState.ToString());
            Assert.AreEqual(filterName, filter.Data.Name);
            Assert.IsEmpty(filter.Data.Rules);

            var filters = await filterContainer.GetAllAsync().ToEnumerableAsync();
            Has.One.Equals(filters);
            Assert.AreEqual(filterName, filters[0].Data.Name);
            Assert.IsEmpty(filters[0].Data.Rules);

            var allFilters = await ArmClient.DefaultSubscription.GetRouteFiltersAsync().ToEnumerableAsync();
            // there could be other filters in the current subscription
            Assert.True(allFilters.Any(f => filterName == f.Data.Name && f.Data.Rules.Count == 0));

            // Crete route filter rule
            RouteFilterRule filterRule = await CreateDefaultRouteFilterRule(filter, ruleName);
            Assert.AreEqual("Succeeded", filterRule.Data.ProvisioningState.ToString());
            Assert.AreEqual(ruleName, filterRule.Data.Name);

            Response<RouteFilter> getFilterResponse = await filterContainer.GetAsync(filterName);
            Assert.AreEqual(filterName, getFilterResponse.Value.Data.Name);

            filter = await filterContainer.GetAsync(filterName);
            Assert.AreEqual(filterName, filter.Data.Name);
            Has.One.Equals(filter.Data.Rules);
            Assert.AreEqual(ruleName, filter.Data.Rules[0].Name);

            filterRule = await filter.GetRouteFilterRules().GetAsync(ruleName);
            Assert.AreEqual(ruleName, filterRule.Data.Name);

            // Update route filter
            filterRule.Data.Access = Access.Deny;
            filterRule = await filter.GetRouteFilterRules().CreateOrUpdateAsync(ruleName, filterRule.Data);
            Assert.AreEqual(ruleName, filterRule.Data.Name);
            Assert.AreEqual(Access.Deny, filterRule.Data.Access);

            // Add filter rule, this will fail due to the limitation of maximum 1 rule per filter
            Assert.ThrowsAsync<RequestFailedException>(async () => await CreateDefaultRouteFilterRule(filter, "rule2"));

            filter = await filterContainer.GetAsync(filterName);
            Has.One.Equals(filter.Data.Rules);
            Assert.AreEqual(ruleName, filter.Data.Rules[0].Name);

            // Delete fileter rule
            await filterRule.DeleteAsync();

            var rules = await filter.GetRouteFilterRules().GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(rules);

            // Delete filter
            await filter.DeleteAsync();
            allFilters = await ArmClient.DefaultSubscription.GetRouteFiltersAsync().ToEnumerableAsync();
            Assert.False(allFilters.Any(f => filter.Id == f.Id));
        }

        private async Task<RouteFilter> CreateDefaultRouteFilter(RouteFilterContainer filterContainer, string filterName, string location,
            bool containsRule = false)
        {
            var filter = new RouteFilterData()
            {
                Location = location,
                Tags = { { "key", "value" } }
            };

            if (containsRule)
            {
                var rule = new RouteFilterRuleData()
                {
                    Name = "test",
                    Access = Access.Allow,
                    Communities = { Filter_Commmunity },
                    Location = location
                };

                filter.Rules.Add(rule);
            }

            // Put route filter
            Operation<RouteFilter> filterOperation = await filterContainer.StartCreateOrUpdateAsync(filterName, filter);
            return await filterOperation.WaitForCompletionAsync();;
        }

        private async Task<RouteFilterRule> CreateDefaultRouteFilterRule(RouteFilter filter,  string ruleName)
        {
            var rule = new RouteFilterRuleData()
            {
                Access = Access.Allow,
                Communities = { Filter_Commmunity },
                Location = filter.Data.Location
            };

            // Put route filter rule
            Operation<RouteFilterRule> ruleOperation = await filter.GetRouteFilterRules().StartCreateOrUpdateAsync(ruleName, rule);
            Response<RouteFilterRule> ruleResponse = await ruleOperation.WaitForCompletionAsync();;
            return ruleResponse;
        }
    }
}
