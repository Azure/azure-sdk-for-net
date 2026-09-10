// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.FileShares.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.FileShares.Tests
{
    public class FileShareSubscriptionOperationsTests : FileSharesManagementTestBase
    {
        public FileShareSubscriptionOperationsTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task GetUsageData()
        {
            var result = await DefaultSubscription.GetUsageDataAsync(new AzureLocation(DefaultLocation));

            Assert.IsNotNull(result.Value);
            Assert.GreaterOrEqual(result.Value.LiveSharesFileShareCount, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetLimits()
        {
            var result = await DefaultSubscription.GetLimitsAsync(new AzureLocation(DefaultLocation));

            Assert.IsNotNull(result.Value);
            Assert.IsNotNull(result.Value.Properties);
            Assert.IsNotNull(result.Value.Properties.Limits);
            Assert.IsNotNull(result.Value.Properties.ProvisioningConstants);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetProvisioningRecommendation()
        {
            var content = new FileShareProvisioningRecommendationContent(1024);

            var result = await DefaultSubscription.GetProvisioningRecommendationAsync(
                new AzureLocation(DefaultLocation), content);

            Assert.IsNotNull(result.Value);
            Assert.IsNotNull(result.Value.Properties);
            Assert.Greater(result.Value.Properties.ProvisionedIOPerSec, 0);
            Assert.Greater(result.Value.Properties.ProvisionedThroughputMiBPerSec, 0);
            Assert.IsNotEmpty(result.Value.Properties.AvailableRedundancyOptions);
        }
    }
}
