// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class AfdProfileOperationsTests : CdnManagementTestBase
    {
        public AfdProfileOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfile = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            await afdProfile.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await afdProfile.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfile = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            ProfilePatch updateOptions = new ProfilePatch();
            updateOptions.Tags.Add("newTag", "newValue");
            var lro = await afdProfile.UpdateAsync(WaitUntil.Completed, updateOptions);
            ProfileResource updatedAfdProfile = lro.Value;
            ResourceDataHelper.AssertProfileUpdate(updatedAfdProfile, updateOptions);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckResourceUsage()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfile = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            int count = 0;
            await foreach (var tempUsage in afdProfile.GetFrontDoorProfileResourceUsagesAsync())
            {
                count++;
                Assert.AreEqual(tempUsage.Unit, FrontDoorUsageUnit.Count);
                Assert.AreEqual(tempUsage.CurrentValue, 0);
            }
            Assert.AreEqual(count, 7);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetLogAnalyticsLocations()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfile = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            ContinentsResponse continentsResponse = await afdProfile.GetLogAnalyticsLocationsAsync();
            Assert.AreEqual(continentsResponse.Continents.Count, 7);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetLogAnalyticsMetrics()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroups().GetAsync("azure_cli_test");
            ProfileResource afdProfile = await rg.GetProfiles().GetAsync("testAFDProfile");
            List<LogMetric> metric = new List<LogMetric>() { LogMetric.ClientRequestCount };
            DateTimeOffset dateTimeBegin = new DateTimeOffset(2021, 9, 23, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset dateTimeEnd = new DateTimeOffset(2021, 9, 25, 0, 0, 0, TimeSpan.Zero);
            List<string> customDomain = new List<string>() { "azuretest.azuretest.net" };
            List<string> protocols = new List<string>() { "https" };
            MetricsResponse mtricsResponse = await afdProfile.GetLogAnalyticsMetricsAsync(metric, dateTimeBegin, dateTimeEnd, LogMetricsGranularity.PT5M, customDomain, protocols);
            Assert.AreEqual(mtricsResponse.Granularity, MetricsResponseGranularity.PT5M);
            Assert.AreEqual(mtricsResponse.Series.Count, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetLogAnalyticsRankings()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroups().GetAsync("azure_cli_test");
            ProfileResource afdProfile = await rg.GetProfiles().GetAsync("testAFDProfile");
            List<LogRanking> rankings = new List<LogRanking>() { LogRanking.Uri };
            List<LogRankingMetric> metric = new List<LogRankingMetric>() { LogRankingMetric.ClientRequestCount };
            int maxRankings = 5;
            DateTimeOffset dateTimeBegin = new DateTimeOffset(2021, 9, 23, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset dateTimeEnd = new DateTimeOffset(2021, 9, 25, 0, 0, 0, TimeSpan.Zero);
            RankingsResponse rankingsResponse = await afdProfile.GetLogAnalyticsRankingsAsync(rankings, metric, maxRankings, dateTimeBegin, dateTimeEnd);
            Assert.AreEqual(rankingsResponse.Tables.Count, 1);
            Assert.AreEqual(rankingsResponse.Tables[0].Ranking, LogRanking.Uri.ToString());
            Assert.AreEqual(rankingsResponse.Tables[0].Data.Count, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetLogAnalyticsResources()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroups().GetAsync("azure_cli_test");
            ProfileResource afdProfile = await rg.GetProfiles().GetAsync("testAFDProfile");
            ResourcesResponse resourcesResponse = await afdProfile.GetLogAnalyticsResourcesAsync();
            Assert.AreEqual(resourcesResponse.CustomDomains.Count, 1);
            Assert.AreEqual(resourcesResponse.Endpoints.Count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetWafLogAnalyticsMetrics()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroups().GetAsync("azure_cli_test");
            ProfileResource afdProfile = await rg.GetProfiles().GetAsync("testAFDPremiumProfile");
            List<WafMetric> metric = new List<WafMetric>() { WafMetric.ClientRequestCount };
            DateTimeOffset dateTimeBegin = new DateTimeOffset(2021, 9, 23, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset dateTimeEnd = new DateTimeOffset(2021, 9, 25, 0, 0, 0, TimeSpan.Zero);
            WafMetricsResponse wafMtricsResponse = await afdProfile.GetWafLogAnalyticsMetricsAsync(metric, dateTimeBegin, dateTimeEnd, WafGranularity.PT5M);
            Assert.AreEqual(wafMtricsResponse.Granularity, WafMetricsResponseGranularity.PT5M);
            Assert.AreEqual(wafMtricsResponse.Series.Count, 1);
            Assert.AreEqual(wafMtricsResponse.Series[0].Metric, WafMetric.ClientRequestCount.ToString());
            Assert.AreEqual(wafMtricsResponse.Series[0].Unit, WafMetricsResponseSeriesItemUnit.Count);
            Assert.AreEqual(wafMtricsResponse.Series[0].Data.Count, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetWafLogAnalyticsRankings()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroups().GetAsync("azure_cli_test");
            ProfileResource afdProfile = await rg.GetProfiles().GetAsync("testAFDPremiumProfile");
            List<WafMetric> metric = new List<WafMetric>() { WafMetric.ClientRequestCount };
            DateTimeOffset dateTimeBegin = new DateTimeOffset(2021, 9, 23, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset dateTimeEnd = new DateTimeOffset(2021, 9, 25, 0, 0, 0, TimeSpan.Zero);
            int maxRankings = 5;
            List<WafRankingType> rankings = new List<WafRankingType>() { WafRankingType.UserAgent };
            WafRankingsResponse wafRankingsResponse = await afdProfile.GetWafLogAnalyticsRankingsAsync(metric, dateTimeBegin, dateTimeEnd, maxRankings, rankings);
            Assert.AreEqual(wafRankingsResponse.Groups.Count, 1);
            Assert.AreEqual(wafRankingsResponse.Groups[0], WafRankingType.UserAgent.ToString());
            Assert.AreEqual(wafRankingsResponse.Data.Count, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckHostNameAvailability()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfile = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            HostNameAvailabilityContent input = new HostNameAvailabilityContent("customdomain4afdtest.azuretest.net");
            CdnNameAvailabilityResult result = await afdProfile.CheckFrontDoorProfileHostNameAvailabilityAsync(input);
            Assert.AreEqual(result.NameAvailable, true);
        }

        [TestCase]
        [RecordedTest]
        public async Task UpdateLogScrubbing()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfile = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            ProfilePatch updateOptions = new ProfilePatch();
            updateOptions.LogScrubbing = new()
            {
                State = ProfileScrubbingState.Enabled,
            };
            var item = new ProfileScrubbingRules() {
                MatchVariable = ScrubbingRuleEntryMatchVariable.RequestIPAddress,
                SelectorMatchOperator = ScrubbingRuleEntryMatchOperator.EqualsAny,
                State = ScrubbingRuleEntryState.Enabled,
            };
            updateOptions.LogScrubbing.ScrubbingRules.Add(item);
            var lro = await afdProfile.UpdateAsync(WaitUntil.Completed, updateOptions);
            ProfileResource updatedAfdProfile = lro.Value;
            ResourceDataHelper.AssertProfileUpdate(updatedAfdProfile, updateOptions);
        }
    }
}
