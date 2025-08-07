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
    public class QueryCarbonEmissionOverallSummaryReportTests : CarbonOptimizationManagementTestBase
    {
        public QueryCarbonEmissionOverallSummaryReportTests(bool isAsync) : base(isAsync)
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
        public async Task QueryCarbonEmissionOverallSummaryReport()
        {
            // invoke the operation

            CarbonEmissionAvailableDateRange availableDatesRange = await Tenant.QueryCarbonEmissionAvailableDateRangeAsync().ConfigureAwait(false);

            var subscriptionIds = new List<string>();

            await foreach (var subscription in Tenant.GetSubscriptions().GetAllAsync())
            {
                subscriptionIds.Add(subscription.Data.SubscriptionId);

                if (subscriptionIds.Count >= 100)
                    break;
            }

            CarbonEmissionQueryFilter queryParameters = new OverallSummaryReportQueryFilter(
                new CarbonEmissionQueryDateRange(availableDatesRange.StartOn, availableDatesRange.EndOn),
                subscriptionIds.ToArray(),
                new CarbonEmissionScope[] { CarbonEmissionScope.Scope1, CarbonEmissionScope.Scope3 });

            CarbonEmissionListResult result = await Tenant.QueryCarbonEmissionReportsAsync(queryParameters);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);

            var resultItem = (CarbonEmissionOverallSummary)result.Value[0];
            Assert.IsNotNull(resultItem.LatestMonthEmissions);
            Assert.IsTrue(resultItem.DataType == CarbonEmissionDataType.OverallSummaryData);
        }
    }
}
