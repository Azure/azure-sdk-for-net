// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CarbonOptimization.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.CarbonOptimization.Tests
{
    public class QueryCarbonEmissionTopNItemsReportTests : CarbonOptimizationManagementTestBase
    {
        public QueryCarbonEmissionTopNItemsReportTests(bool isAsync) : base(isAsync)
        {
        }

        private TenantResource Tenant { get; set; }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                AsyncPageable<TenantResource> tenantResourcesResponse = Client.GetTenants().GetAllAsync();
                List<TenantResource> tenantResources = await tenantResourcesResponse.ToEnumerableAsync();
                Tenant = tenantResources.ToArray()[0];
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task QueryCarbonEmissionTopNResourcesReport()
        {
            // prepare query parameter
            CarbonEmissionQueryFilter queryParameters = await BuildQueryParameter(CarbonEmissionCategoryType.Resource).ConfigureAwait(false);

            // invoke the operation
            CarbonEmissionListResult result = await Tenant.QueryCarbonEmissionReportsAsync(queryParameters);

            // assert the result
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value, Is.Not.Null);

            var firstItem = (ResourceCarbonEmissionTopItemsSummary)result.Value.First();
            Assert.That(firstItem.LatestMonthEmissions, Is.Not.Null);
            Assert.That(firstItem.DataType == CarbonEmissionDataType.ResourceTopItemsSummaryData, Is.True);
            Assert.That(firstItem.ItemName, Is.Not.Null);
            Assert.That(firstItem.CategoryType == CarbonEmissionCategoryType.Resource, Is.True);
            Assert.That(firstItem.ResourceGroup, Is.Not.Null);
            Assert.That(firstItem.SubscriptionId, Is.Not.Null);

            var lastItem = (ResourceCarbonEmissionTopItemsSummary)result.Value.Last();
            Assert.That(lastItem.LatestMonthEmissions, Is.Not.Null);
            Assert.That(lastItem.DataType == CarbonEmissionDataType.ResourceTopItemsSummaryData, Is.True);
            Assert.That(lastItem.ItemName, Is.Not.Null);
            Assert.That(lastItem.CategoryType == CarbonEmissionCategoryType.Resource, Is.True);
            Assert.That(lastItem.ResourceGroup, Is.Not.Null);
            Assert.That(lastItem.SubscriptionId, Is.Not.Null);
        }

        [TestCase]
        [RecordedTest]
        public async Task QueryCarbonEmissionTopNResourceGroupsReport()
        {
            // prepare query parameter
            CarbonEmissionQueryFilter queryParameters = await BuildQueryParameter(CarbonEmissionCategoryType.ResourceGroup).ConfigureAwait(false);

            // invoke the operation
            CarbonEmissionListResult result = await Tenant.QueryCarbonEmissionReportsAsync(queryParameters);

            // assert the result
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value, Is.Not.Null);

            var firstItem = (ResourceGroupCarbonEmissionTopItemsSummary)result.Value.First();
            Assert.That(firstItem.LatestMonthEmissions, Is.Not.Null);
            Assert.That(firstItem.DataType == CarbonEmissionDataType.ResourceGroupTopItemsSummaryData, Is.True);
            Assert.That(firstItem.ItemName, Is.Not.Null);
            Assert.That(firstItem.CategoryType == CarbonEmissionCategoryType.ResourceGroup, Is.True);
            Assert.That(firstItem.ResourceGroupId, Is.Not.Null);

            var lastItem = (ResourceGroupCarbonEmissionTopItemsSummary)result.Value.Last();
            Assert.That(lastItem.LatestMonthEmissions, Is.Not.Null);
            Assert.That(lastItem.DataType == CarbonEmissionDataType.ResourceGroupTopItemsSummaryData, Is.True);
            Assert.That(lastItem.ItemName, Is.Not.Null);
            Assert.That(lastItem.CategoryType == CarbonEmissionCategoryType.ResourceGroup, Is.True);
            Assert.That(lastItem.ResourceGroupId, Is.Not.Null);
        }

        [TestCase]
        [RecordedTest]
        public async Task QueryCarbonEmissionTopNResourceTypesReport()
        {
            // prepare query parameter
            CarbonEmissionQueryFilter queryParameters = await BuildQueryParameter(CarbonEmissionCategoryType.ResourceType).ConfigureAwait(false);

            // invoke the operation
            CarbonEmissionListResult result = await Tenant.QueryCarbonEmissionReportsAsync(queryParameters);

            // assert the result
            AssertTopItemsSummaryResult(result, CarbonEmissionCategoryType.ResourceType);
        }

        [TestCase]
        [RecordedTest]
        public async Task QueryCarbonEmissionTopNLocationsReport()
        {
            // prepare query parameter
            CarbonEmissionQueryFilter queryParameters = await BuildQueryParameter(CarbonEmissionCategoryType.Location).ConfigureAwait(false);

            // invoke the operation
            CarbonEmissionListResult result = await Tenant.QueryCarbonEmissionReportsAsync(queryParameters);

            // assert the result
            AssertTopItemsSummaryResult(result, CarbonEmissionCategoryType.Location);
        }

        [TestCase]
        [RecordedTest]
        public async Task QueryCarbonEmissionTopNSubscriptionsReport()
        {
            // prepare query parameter
            CarbonEmissionQueryFilter queryParameters = await BuildQueryParameter(CarbonEmissionCategoryType.Subscription).ConfigureAwait(false);

            // invoke the operation
            CarbonEmissionListResult result = await Tenant.QueryCarbonEmissionReportsAsync(queryParameters);

            // assert the result
            AssertTopItemsSummaryResult(result, CarbonEmissionCategoryType.Subscription);
        }

        private async Task<CarbonEmissionQueryFilter> BuildQueryParameter(CarbonEmissionCategoryType categoryType)
        {
            CarbonEmissionAvailableDateRange availableDatesRange = await Tenant.QueryCarbonEmissionAvailableDateRangeAsync().ConfigureAwait(false);

            var subscriptionIds = new List<string>();

            await foreach (var subscription in Tenant.GetSubscriptions().GetAllAsync())
            {
                subscriptionIds.Add(subscription.Data.SubscriptionId);

                if (subscriptionIds.Count >= 100)
                    break;
            }

            CarbonEmissionQueryFilter queryParameters = new TopItemsSummaryReportQueryFilter(
                new CarbonEmissionQueryDateRange(availableDatesRange.EndOn, availableDatesRange.EndOn),
                subscriptionIds.ToArray(),
                new CarbonEmissionScope[] { CarbonEmissionScope.Scope1, CarbonEmissionScope.Scope3 },
                categoryType, 5);

            return queryParameters;
        }

        private void AssertTopItemsSummaryResult(CarbonEmissionListResult result, CarbonEmissionCategoryType categoryType)
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value, Is.Not.Null);

            var firstItem = (CarbonEmissionTopItemsSummary) result.Value.First();
            Assert.That(firstItem.LatestMonthEmissions, Is.Not.Null);
            Assert.That(firstItem.DataType == CarbonEmissionDataType.TopItemsSummaryData, Is.True);
            Assert.That(firstItem.ItemName, Is.Not.Null);
            Assert.That(firstItem.CategoryType == categoryType, Is.True);

            var lastItem = (CarbonEmissionTopItemsSummary) result.Value.Last();
            Assert.That(lastItem.LatestMonthEmissions, Is.Not.Null);
            Assert.That(lastItem.DataType == CarbonEmissionDataType.TopItemsSummaryData, Is.True);
            Assert.That(lastItem.ItemName, Is.Not.Null);
            Assert.That(lastItem.CategoryType == categoryType, Is.True);
        }
    }
}
