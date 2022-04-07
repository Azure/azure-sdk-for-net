// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class AzureReachabilityReportTests : NetworkServiceClientTestBase
    {
        public AzureReachabilityReportTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [Test]
        [Ignore("Track2: The NetworkWathcer is involved, so disable the test")]
        public async Task AzureReachabilityReportCountryLevelAggregationTest()
        {
            AzureReachabilityReportContent parameters = new AzureReachabilityReportContent(
                new AzureReachabilityReportLocation("United States"), Recording.UtcNow.AddDays(-10), Recording.UtcNow.AddDays(-5))
            {
                AzureLocations = { "West US" }
            };
            Operation<AzureReachabilityReport> reportOperation = await GetResourceGroup("NetworkWatcherRG").GetNetworkWatchers().Get("NetworkWatcher_westus").Value.GetAzureReachabilityReportAsync(WaitUntil.Completed, parameters);
            Response<AzureReachabilityReport> report = await reportOperation.WaitForCompletionAsync();;

            //Validation
            Assert.AreEqual("Country", report.Value.AggregationLevel);
            Assert.AreEqual("United States", report.Value.ProviderLocation.Country);
            Assert.AreEqual("West US", report.Value.ReachabilityReport[0].AzureLocation);
        }

        [Test]
        [Ignore("Track2: The NetworkWathcer is involved, so disable the test")]
        public async Task AzureReachabilityReportStateLevelAggregationTest()
        {
            AzureReachabilityReportContent parameters = new AzureReachabilityReportContent(
                new AzureReachabilityReportLocation("United States") { State = "washington" }, Recording.UtcNow.AddDays(-10), Recording.UtcNow.AddDays(-5))
            {
                AzureLocations = { "West US" }
            };
            Operation<AzureReachabilityReport> reportOperation = await GetResourceGroup("NetworkWatcherRG").GetNetworkWatchers().Get("NetworkWatcher_westus").Value.GetAzureReachabilityReportAsync(WaitUntil.Completed, parameters);
            Response<AzureReachabilityReport> report = await reportOperation.WaitForCompletionAsync();;

            //Validation
            Assert.AreEqual("State", report.Value.AggregationLevel);
            Assert.AreEqual("United States", report.Value.ProviderLocation.Country);
            Assert.AreEqual("washington", report.Value.ProviderLocation.State);
            Assert.AreEqual("West US", report.Value.ReachabilityReport[0].AzureLocation);
        }

        [Test]
        [Ignore("Track2: The NetworkWathcer is involved, so disable the test")]
        public async Task AzureReachabilityReportCityLevelAggregationTest()
        {
            AzureReachabilityReportContent parameters = new AzureReachabilityReportContent(
                new AzureReachabilityReportLocation("United States") { State = "washington", City = "seattle" }, Recording.UtcNow.AddDays(-10), Recording.UtcNow.AddDays(-5))
            {
                AzureLocations = { "West US" }
            };
            Operation<AzureReachabilityReport> reportOperation = await GetResourceGroup("NetworkWatcherRG").GetNetworkWatchers().Get("NetworkWatcher_westus").Value.GetAzureReachabilityReportAsync(WaitUntil.Completed, parameters);
            Response<AzureReachabilityReport> report = await reportOperation.WaitForCompletionAsync();;

            //Validation
            Assert.AreEqual("City", report.Value.AggregationLevel);
            Assert.AreEqual("United States", report.Value.ProviderLocation.Country);
            Assert.AreEqual("washington", report.Value.ProviderLocation.State);
            Assert.AreEqual("seattle", report.Value.ProviderLocation.City);
            Assert.AreEqual("West US", report.Value.ReachabilityReport[0].AzureLocation);
        }
    }
}
