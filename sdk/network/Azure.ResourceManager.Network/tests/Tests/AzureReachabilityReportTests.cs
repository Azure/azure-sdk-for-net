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
            Assert.That(report.Value.AggregationLevel, Is.EqualTo("Country"));
            Assert.That(report.Value.ProviderLocation.Country, Is.EqualTo("United States"));
            Assert.That(report.Value.ReachabilityReport[0].AzureLocation, Is.EqualTo("West US"));
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
            Assert.That(report.Value.AggregationLevel, Is.EqualTo("State"));
            Assert.That(report.Value.ProviderLocation.Country, Is.EqualTo("United States"));
            Assert.That(report.Value.ProviderLocation.State, Is.EqualTo("washington"));
            Assert.That(report.Value.ReachabilityReport[0].AzureLocation, Is.EqualTo("West US"));
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
            Assert.That(report.Value.AggregationLevel, Is.EqualTo("City"));
            Assert.That(report.Value.ProviderLocation.Country, Is.EqualTo("United States"));
            Assert.That(report.Value.ProviderLocation.State, Is.EqualTo("washington"));
            Assert.That(report.Value.ProviderLocation.City, Is.EqualTo("seattle"));
            Assert.That(report.Value.ReachabilityReport[0].AzureLocation, Is.EqualTo("West US"));
        }
    }
}
