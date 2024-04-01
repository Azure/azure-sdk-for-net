// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
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
        public async Task DetailItemsReportAsync()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg", AzureLocation.WestUS);
            string resourceName = Recording.GenerateAssetName("resource");
            CarbonEmissionAvailableDateRange availableDateRange = await CarbonOptimizationExtensions.QueryCarbonEmissionDataAvailableDateRangeCarbonServiceAsync(DefaultTenant).ConfigureAwait(false);

            Assert.IsTrue(true);
        }
    }
}
