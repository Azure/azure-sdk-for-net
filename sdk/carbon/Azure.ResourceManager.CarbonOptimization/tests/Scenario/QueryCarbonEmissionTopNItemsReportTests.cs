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
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);

            var firstItem = (ResourceCarbonEmissionTopItemsSummary)result.Value.First();
            Assert.IsNotNull(firstItem.LatestMonthEmissions);
            Assert.IsTrue(firstItem.DataType == CarbonEmissionDataType.ResourceTopItemsSummaryData);
            Assert.IsNotNull(firstItem.ItemName);
            Assert.IsTrue(firstItem.CategoryType == CarbonEmissionCategoryType.Resource);
            Assert.IsNotNull(firstItem.ResourceGroup);
            Assert.IsNotNull(firstItem.SubscriptionId);

            var lastItem = (ResourceCarbonEmissionTopItemsSummary)result.Value.Last();
            Assert.IsNotNull(lastItem.LatestMonthEmissions);
            Assert.IsTrue(lastItem.DataType == CarbonEmissionDataType.ResourceTopItemsSummaryData);
            Assert.IsNotNull(lastItem.ItemName);
            Assert.IsTrue(lastItem.CategoryType == CarbonEmissionCategoryType.Resource);
            Assert.IsNotNull(lastItem.ResourceGroup);
            Assert.IsNotNull(lastItem.SubscriptionId);
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
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);

            var firstItem = (ResourceGroupCarbonEmissionTopItemsSummary)result.Value.First();
            Assert.IsNotNull(firstItem.LatestMonthEmissions);
            Assert.IsTrue(firstItem.DataType == CarbonEmissionDataType.ResourceGroupTopItemsSummaryData);
            Assert.IsNotNull(firstItem.ItemName);
            Assert.IsTrue(firstItem.CategoryType == CarbonEmissionCategoryType.ResourceGroup);
            Assert.IsNotNull(firstItem.ResourceGroupId);

            var lastItem = (ResourceGroupCarbonEmissionTopItemsSummary)result.Value.Last();
            Assert.IsNotNull(lastItem.LatestMonthEmissions);
            Assert.IsTrue(lastItem.DataType == CarbonEmissionDataType.ResourceGroupTopItemsSummaryData);
            Assert.IsNotNull(lastItem.ItemName);
            Assert.IsTrue(lastItem.CategoryType == CarbonEmissionCategoryType.ResourceGroup);
            Assert.IsNotNull(lastItem.ResourceGroupId);
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
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);

            var firstItem = (CarbonEmissionTopItemsSummary) result.Value.First();
            Assert.IsNotNull(firstItem.LatestMonthEmissions);
            Assert.IsTrue(firstItem.DataType == CarbonEmissionDataType.TopItemsSummaryData);
            Assert.IsNotNull(firstItem.ItemName);
            Assert.IsTrue(firstItem.CategoryType == categoryType);

            var lastItem = (CarbonEmissionTopItemsSummary) result.Value.Last();
            Assert.IsNotNull(lastItem.LatestMonthEmissions);
            Assert.IsTrue(lastItem.DataType == CarbonEmissionDataType.TopItemsSummaryData);
            Assert.IsNotNull(lastItem.ItemName);
            Assert.IsTrue(lastItem.CategoryType == categoryType);
        }
    }
}
