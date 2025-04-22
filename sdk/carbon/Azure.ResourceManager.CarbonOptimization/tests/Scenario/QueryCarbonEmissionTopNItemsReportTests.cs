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
        public QueryCarbonEmissionTopNItemsReportTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
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
            QueryFilter queryParameters = await BuildQueryParameter(CategoryTypeEnum.Resource).ConfigureAwait(false);

            // invoke the operation
            CarbonEmissionDataListResult result = await Tenant.QueryCarbonEmissionReportsCarbonServicesAsync(queryParameters);

            // assert the result
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);

            var firstItem = (ResourceCarbonEmissionTopItemsSummary)result.Value.First();
            Assert.IsNotNull(firstItem.LatestMonthEmissions);
            Assert.IsTrue(firstItem.DataType == ResponseDataTypeEnum.ResourceTopItemsSummaryData);
            Assert.IsNotNull(firstItem.ItemName);
            Assert.IsTrue(firstItem.CategoryType == CategoryTypeEnum.Resource);
            Assert.IsNotNull(firstItem.ResourceGroup);
            Assert.IsNotNull(firstItem.SubscriptionId);

            var lastItem = (ResourceCarbonEmissionTopItemsSummary)result.Value.Last();
            Assert.IsNotNull(lastItem.LatestMonthEmissions);
            Assert.IsTrue(lastItem.DataType == ResponseDataTypeEnum.ResourceTopItemsSummaryData);
            Assert.IsNotNull(lastItem.ItemName);
            Assert.IsTrue(lastItem.CategoryType == CategoryTypeEnum.Resource);
            Assert.IsNotNull(lastItem.ResourceGroup);
            Assert.IsNotNull(lastItem.SubscriptionId);
        }

        [TestCase]
        [RecordedTest]
        public async Task QueryCarbonEmissionTopNResourceGroupsReport()
        {
            // prepare query parameter
            QueryFilter queryParameters = await BuildQueryParameter(CategoryTypeEnum.ResourceGroup).ConfigureAwait(false);

            // invoke the operation
            CarbonEmissionDataListResult result = await Tenant.QueryCarbonEmissionReportsCarbonServicesAsync(queryParameters);

            // assert the result
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);

            var firstItem = (ResourceGroupCarbonEmissionTopItemsSummary)result.Value.First();
            Assert.IsNotNull(firstItem.LatestMonthEmissions);
            Assert.IsTrue(firstItem.DataType == ResponseDataTypeEnum.ResourceGroupTopItemsSummaryData);
            Assert.IsNotNull(firstItem.ItemName);
            Assert.IsTrue(firstItem.CategoryType == CategoryTypeEnum.ResourceGroup);
            Assert.IsNotNull(firstItem.ResourceGroupUri);

            var lastItem = (ResourceGroupCarbonEmissionTopItemsSummary)result.Value.Last();
            Assert.IsNotNull(lastItem.LatestMonthEmissions);
            Assert.IsTrue(lastItem.DataType == ResponseDataTypeEnum.ResourceGroupTopItemsSummaryData);
            Assert.IsNotNull(lastItem.ItemName);
            Assert.IsTrue(lastItem.CategoryType == CategoryTypeEnum.ResourceGroup);
            Assert.IsNotNull(lastItem.ResourceGroupUri);
        }

        [TestCase]
        [RecordedTest]
        public async Task QueryCarbonEmissionTopNResourceTypesReport()
        {
            // prepare query parameter
            QueryFilter queryParameters = await BuildQueryParameter(CategoryTypeEnum.ResourceType).ConfigureAwait(false);

            // invoke the operation
            CarbonEmissionDataListResult result = await Tenant.QueryCarbonEmissionReportsCarbonServicesAsync(queryParameters);

            // assert the result
            AssertTopItemsSummaryResult(result, CategoryTypeEnum.ResourceType);
        }

        [TestCase]
        [RecordedTest]
        public async Task QueryCarbonEmissionTopNLocationsReport()
        {
            // prepare query parameter
            QueryFilter queryParameters = await BuildQueryParameter(CategoryTypeEnum.Location).ConfigureAwait(false);

            // invoke the operation
            CarbonEmissionDataListResult result = await Tenant.QueryCarbonEmissionReportsCarbonServicesAsync(queryParameters);

            // assert the result
            AssertTopItemsSummaryResult(result, CategoryTypeEnum.Location);
        }

        [TestCase]
        [RecordedTest]
        public async Task QueryCarbonEmissionTopNSubscriptionsReport()
        {
            // prepare query parameter
            QueryFilter queryParameters = await BuildQueryParameter(CategoryTypeEnum.Subscription).ConfigureAwait(false);

            // invoke the operation
            CarbonEmissionDataListResult result = await Tenant.QueryCarbonEmissionReportsCarbonServicesAsync(queryParameters);

            // assert the result
            AssertTopItemsSummaryResult(result, CategoryTypeEnum.Subscription);
        }

        private async Task<QueryFilter> BuildQueryParameter(CategoryTypeEnum categoryType)
        {
            CarbonEmissionDataAvailableDateRange availableDatesRange = await Tenant.QueryCarbonEmissionDataAvailableDateRangeCarbonServiceAsync().ConfigureAwait(false);

            var subscriptionIds = new List<string>();

            await foreach (var subscription in Tenant.GetSubscriptions().GetAllAsync())
            {
                subscriptionIds.Add(subscription.Data.SubscriptionId);

                if (subscriptionIds.Count >= 100)
                    break;
            }

            QueryFilter queryParameters = new TopItemsSummaryReportQueryFilter(
                new DateRange(DateTimeOffset.Parse(availableDatesRange.EndDate), DateTimeOffset.Parse(availableDatesRange.EndDate)),
                subscriptionIds.ToArray(),
                new EmissionScopeEnum[] { EmissionScopeEnum.Scope1, EmissionScopeEnum.Scope3 },
                categoryType, 5);

            return queryParameters;
        }

        private void AssertTopItemsSummaryResult(CarbonEmissionDataListResult result, CategoryTypeEnum categoryType)
        {
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);

            var firstItem = (CarbonEmissionTopItemsSummary) result.Value.First();
            Assert.IsNotNull(firstItem.LatestMonthEmissions);
            Assert.IsTrue(firstItem.DataType == ResponseDataTypeEnum.TopItemsSummaryData);
            Assert.IsNotNull(firstItem.ItemName);
            Assert.IsTrue(firstItem.CategoryType == categoryType);

            var lastItem = (CarbonEmissionTopItemsSummary) result.Value.Last();
            Assert.IsNotNull(lastItem.LatestMonthEmissions);
            Assert.IsTrue(lastItem.DataType == ResponseDataTypeEnum.TopItemsSummaryData);
            Assert.IsNotNull(lastItem.ItemName);
            Assert.IsTrue(lastItem.CategoryType == categoryType);
        }
    }
}
