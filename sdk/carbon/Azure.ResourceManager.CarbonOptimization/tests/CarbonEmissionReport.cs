// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CarbonOptimization.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.CarbonOptimization.Tests
{
    [TestFixture]
    public class CarbonEmissionReport : CarbonOptimizationManagementTestBase
    {
        public CarbonEmissionReport(): base(true) { }

        protected CarbonEmissionReport(bool isAsync) : base(isAsync)
        {
        }

        protected CarbonEmissionReport(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task QueryCarbonEmissionDataAvailableDateRangeCarbonServiceAsync()
        {
            CarbonEmissionDataAvailableDateRange availableDateRange = await CarbonOptimizationExtensions.QueryCarbonEmissionDataAvailableDateRangeCarbonServiceAsync(DefaultTenant).ConfigureAwait(false);
            Assert.AreNotEqual(availableDateRange, null);
        }

        [TestCase]
        [RecordedTest]
        public async Task DetailItemsReportAsync()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            OverallSummaryReportQueryFilter filter = new OverallSummaryReportQueryFilter(
                new DateRange(),
                new List<string>() { subscription.Id.SubscriptionId },
                new List<EmissionScopeEnum>() { EmissionScopeEnum.Scope1, EmissionScopeEnum.Scope2, EmissionScopeEnum.Scope3 }
            );
            AsyncPageable<CarbonEmissionData> carbonEmissionDatas = CarbonOptimizationExtensions.GetCarbonEmissionReportsCarbonServicesAsync(DefaultTenant, filter);

            await foreach (CarbonEmissionData data in carbonEmissionDatas)
            {
                Assert.AreNotEqual(data, null);
            }
        }
    }
}
