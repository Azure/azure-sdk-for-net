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
            CarbonEmissionAvailableDateRange availableDateRange = await CarbonOptimizationExtensions.QueryCarbonEmissionAvailableDateRangeAsync(DefaultTenant).ConfigureAwait(false);
            Assert.AreNotEqual(availableDateRange, null);
        }

        [TestCase]
        [RecordedTest]
        public async Task DetailItemsReportAsync()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            OverallSummaryReportQueryContent filter = new OverallSummaryReportQueryContent(
                new CarbonEmissionQueryDateRange(),
                new List<string>() { subscription.Id.SubscriptionId },
                new List<CarbonEmissionQueryScope>() { CarbonEmissionQueryScope.Scope1, CarbonEmissionQueryScope.Scope2, CarbonEmissionQueryScope.Scope3 }
            );
            AsyncPageable<CarbonEmission> carbonEmissionDatas = CarbonOptimizationExtensions.GetCarbonEmissionReportsAsync(DefaultTenant, filter);

            await foreach (CarbonEmission data in carbonEmissionDatas)
            {
                Assert.AreNotEqual(data, null);
            }
        }
    }
}
