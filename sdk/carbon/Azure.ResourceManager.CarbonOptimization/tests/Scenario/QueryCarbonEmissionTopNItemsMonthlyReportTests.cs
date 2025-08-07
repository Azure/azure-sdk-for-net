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
    public class QueryCarbonEmissionTopNItemsMonthlyReportTests : CarbonOptimizationManagementTestBase
    {
        public QueryCarbonEmissionTopNItemsMonthlyReportTests(bool isAsync) : base(isAsync)
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
        public async Task QueryCarbonEmissionTopNResourcesMonthlyReport()
        {
            // prepare query parameter
            CarbonEmissionQueryFilter queryParameters = await BuildQueryParameter(CarbonEmissionCategoryType.Resource).ConfigureAwait(false);

            // invoke the operation
            CarbonEmissionListResult result = await Tenant.QueryCarbonEmissionReportsAsync(queryParameters);

            // assert the result
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);

            var firstItem = (ResourceCarbonEmissionTopItemMonthlySummary)result.Value.First();
            Assert.IsNotNull(firstItem.LatestMonthEmissions);
            Assert.IsTrue(firstItem.DataType == CarbonEmissionDataType.ResourceTopItemsMonthlySummaryData);
            Assert.IsNotNull(firstItem.ItemName);
            Assert.IsTrue(firstItem.CategoryType == CarbonEmissionCategoryType.Resource);
            Assert.IsNotNull(firstItem.ResourceGroup);
            Assert.IsNotNull(firstItem.SubscriptionId);
            Assert.IsNotNull(firstItem.Date);

            var lastItem = (ResourceCarbonEmissionTopItemMonthlySummary)result.Value.Last();
            Assert.IsNotNull(lastItem.LatestMonthEmissions);
            Assert.IsTrue(lastItem.DataType == CarbonEmissionDataType.ResourceTopItemsMonthlySummaryData);
            Assert.IsNotNull(lastItem.ItemName);
            Assert.IsTrue(lastItem.CategoryType == CarbonEmissionCategoryType.Resource);
            Assert.IsNotNull(lastItem.ResourceGroup);
            Assert.IsNotNull(lastItem.SubscriptionId);
            Assert.IsNotNull(lastItem.Date);
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

            var firstItem = (ResourceGroupCarbonEmissionTopItemMonthlySummary)result.Value.First();
            Assert.IsNotNull(firstItem.LatestMonthEmissions);
            Assert.IsTrue(firstItem.DataType == CarbonEmissionDataType.ResourceGroupTopItemsMonthlySummaryData);
            Assert.IsNotNull(firstItem.ItemName);
            Assert.IsTrue(firstItem.CategoryType == CarbonEmissionCategoryType.ResourceGroup);
            Assert.IsNotNull(firstItem.ResourceGroupId);
            Assert.IsNotNull(firstItem.Date);

            var lastItem = (ResourceGroupCarbonEmissionTopItemMonthlySummary)result.Value.Last();
            Assert.IsNotNull(lastItem.LatestMonthEmissions);
            Assert.IsTrue(lastItem.DataType == CarbonEmissionDataType.ResourceGroupTopItemsMonthlySummaryData);
            Assert.IsNotNull(lastItem.ItemName);
            Assert.IsTrue(lastItem.CategoryType == CarbonEmissionCategoryType.ResourceGroup);
            Assert.IsNotNull(lastItem.ResourceGroupId);
            Assert.IsNotNull(lastItem.Date);
        }

        [TestCase]
        [RecordedTest]
        public async Task QueryCarbonEmissionTopNResourceTypesMonthlyReport()
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
        public async Task QueryCarbonEmissionTopNLocationsMonthlyReport()
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
        public async Task QueryCarbonEmissionTopNSubscriptionsMonthlyReport()
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

            CarbonEmissionQueryFilter queryParameters = new TopItemsMonthlySummaryReportQueryFilter(
                new CarbonEmissionQueryDateRange(availableDatesRange.StartOn, availableDatesRange.EndOn),
                subscriptionIds.ToArray(),
                new CarbonEmissionScope[] { CarbonEmissionScope.Scope1, CarbonEmissionScope.Scope3 },
                categoryType, 5);

            return queryParameters;
        }

        private void AssertTopItemsSummaryResult(CarbonEmissionListResult result, CarbonEmissionCategoryType categoryType)
        {
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);

            var firstItem = (CarbonEmissionTopItemMonthlySummary) result.Value.First();
            Assert.IsNotNull(firstItem.LatestMonthEmissions);
            Assert.IsTrue(firstItem.DataType == CarbonEmissionDataType.TopItemsMonthlySummaryData);
            Assert.IsNotNull(firstItem.ItemName);
            Assert.IsTrue(firstItem.CategoryType == categoryType);
            Assert.IsNotNull(firstItem.Date);

            var lastItem = (CarbonEmissionTopItemMonthlySummary) result.Value.Last();
            Assert.IsNotNull(lastItem.LatestMonthEmissions);
            Assert.IsTrue(lastItem.DataType == CarbonEmissionDataType.TopItemsMonthlySummaryData);
            Assert.IsNotNull(lastItem.ItemName);
            Assert.IsTrue(lastItem.CategoryType == categoryType);
            Assert.IsNotNull(lastItem.Date);
        }
    }
}
