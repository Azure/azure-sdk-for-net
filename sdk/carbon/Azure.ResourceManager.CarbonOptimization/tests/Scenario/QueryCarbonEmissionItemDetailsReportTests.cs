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
    public class QueryCarbonEmissionItemDetailsReportTests : CarbonOptimizationManagementTestBase
    {
        public QueryCarbonEmissionItemDetailsReportTests(bool isAsync) : base(isAsync)
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
        public async Task QueryCarbonEmissionItemDetailsResourcesReport()
        {
            // prepare query parameter
            QueryFilter queryParameters = await BuildQueryParameter(CategoryTypeEnum.Resource).ConfigureAwait(false);

            // invoke the operation
            CarbonEmissionDataListResult result = await Tenant.QueryCarbonEmissionReportsCarbonServicesAsync(queryParameters);

            // assert the result
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);

            var firstItem = (ResourceCarbonEmissionItemDetail)result.Value.First();
            Assert.IsNotNull(firstItem.LatestMonthEmissions);
            Assert.IsTrue(firstItem.DataType == ResponseDataTypeEnum.ResourceItemDetailsData);
            Assert.IsNotNull(firstItem.ItemName);
            Assert.IsTrue(firstItem.CategoryType == CategoryTypeEnum.Resource);
            Assert.IsNotNull(firstItem.ResourceGroup);
            Assert.IsNotNull(firstItem.SubscriptionId);
            Assert.IsNotNull(firstItem.ResourceId);

            var lastItem = (ResourceCarbonEmissionItemDetail)result.Value.Last();
            Assert.IsNotNull(lastItem.LatestMonthEmissions);
            Assert.IsTrue(lastItem.DataType == ResponseDataTypeEnum.ResourceItemDetailsData);
            Assert.IsNotNull(lastItem.ItemName);
            Assert.IsTrue(lastItem.CategoryType == CategoryTypeEnum.Resource);
            Assert.IsNotNull(lastItem.ResourceGroup);
            Assert.IsNotNull(lastItem.SubscriptionId);
            Assert.IsNotNull(lastItem.ResourceId);
        }

        [TestCase]
        [RecordedTest]
        public async Task QueryCarbonEmissionItemDetailsResourceGroupsReport()
        {
            // prepare query parameter
            QueryFilter queryParameters = await BuildQueryParameter(CategoryTypeEnum.ResourceGroup).ConfigureAwait(false);

            // invoke the operation
            CarbonEmissionDataListResult result = await Tenant.QueryCarbonEmissionReportsCarbonServicesAsync(queryParameters);

            // assert the result
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);

            var firstItem = (ResourceGroupCarbonEmissionItemDetail)result.Value.First();
            Assert.IsNotNull(firstItem.LatestMonthEmissions);
            Assert.IsTrue(firstItem.DataType == ResponseDataTypeEnum.ResourceGroupItemDetailsData);
            Assert.IsNotNull(firstItem.ItemName);
            Assert.IsTrue(firstItem.CategoryType == CategoryTypeEnum.ResourceGroup);
            Assert.IsNotNull(firstItem.ResourceGroupUri);
            Assert.IsNotNull(firstItem.SubscriptionId);

            var lastItem = (ResourceGroupCarbonEmissionItemDetail)result.Value.Last();
            Assert.IsNotNull(lastItem.LatestMonthEmissions);
            Assert.IsTrue(lastItem.DataType == ResponseDataTypeEnum.ResourceGroupItemDetailsData);
            Assert.IsNotNull(lastItem.ItemName);
            Assert.IsTrue(lastItem.CategoryType == CategoryTypeEnum.ResourceGroup);
            Assert.IsNotNull(lastItem.ResourceGroupUri);
            Assert.IsNotNull(lastItem.SubscriptionId);
        }

        [TestCase]
        [RecordedTest]
        public async Task QueryCarbonEmissionItemDetailsResourceTypesReport()
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
        public async Task QueryCarbonEmissionItemDetailsLocationsReport()
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
        public async Task QueryCarbonEmissionItemDetailsSubscriptionsReport()
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

            QueryFilter queryParameters = new ItemDetailsQueryFilter(
                new DateRange(DateTimeOffset.Parse(availableDatesRange.EndDate), DateTimeOffset.Parse(availableDatesRange.EndDate)),
                subscriptionIds.ToArray(),
                new EmissionScopeEnum[] { EmissionScopeEnum.Scope1, EmissionScopeEnum.Scope3 },
                categoryType,
                OrderByColumnEnum.LatestMonthEmissions,
                SortDirectionEnum.Desc,
                1000);

            return queryParameters;
        }

        private void AssertTopItemsSummaryResult(CarbonEmissionDataListResult result, CategoryTypeEnum categoryType)
        {
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);

            var firstItem = (CarbonEmissionItemDetail) result.Value.First();
            Assert.IsNotNull(firstItem.LatestMonthEmissions);
            Assert.IsTrue(firstItem.DataType == ResponseDataTypeEnum.ItemDetailsData);
            Assert.IsNotNull(firstItem.ItemName);
            Assert.IsTrue(firstItem.CategoryType == categoryType);

            var lastItem = (CarbonEmissionItemDetail) result.Value.Last();
            Assert.IsNotNull(lastItem.LatestMonthEmissions);
            Assert.IsTrue(lastItem.DataType == ResponseDataTypeEnum.ItemDetailsData);
            Assert.IsNotNull(lastItem.ItemName);
            Assert.IsTrue(lastItem.CategoryType == categoryType);
        }
    }
}
