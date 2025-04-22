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

            CarbonEmissionDataAvailableDateRange availableDatesRange = await Tenant.QueryCarbonEmissionDataAvailableDateRangeCarbonServiceAsync().ConfigureAwait(false);

            var subscriptionIds = new List<string>();

            await foreach (var subscription in Tenant.GetSubscriptions().GetAllAsync())
            {
                subscriptionIds.Add(subscription.Data.SubscriptionId);

                if (subscriptionIds.Count >= 100)
                    break;
            }

            QueryFilter queryParameters = new OverallSummaryReportQueryFilter(
                new DateRange(DateTimeOffset.Parse(availableDatesRange.StartDate), DateTimeOffset.Parse(availableDatesRange.EndDate)),
                subscriptionIds.ToArray(),
                new EmissionScopeEnum[] { EmissionScopeEnum.Scope1, EmissionScopeEnum.Scope3 });

            CarbonEmissionDataListResult result = await Tenant.QueryCarbonEmissionReportsCarbonServicesAsync(queryParameters);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);

            var resultItem = (CarbonEmissionOverallSummary)result.Value[0];
            Assert.IsNotNull(resultItem.LatestMonthEmissions);
            Assert.IsTrue(resultItem.DataType == ResponseDataTypeEnum.OverallSummaryData);
        }
    }
}
