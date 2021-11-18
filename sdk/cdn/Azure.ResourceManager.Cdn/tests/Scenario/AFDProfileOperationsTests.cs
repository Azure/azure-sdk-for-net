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
    public class AFDProfileOperationsTests : CdnManagementTestBase
    {
        public AFDProfileOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            await AFDProfile.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await AFDProfile.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            ProfileUpdateParameters updateParameters = new ProfileUpdateParameters();
            updateParameters.Tags.Add("newTag", "newValue");
            var lro = await AFDProfile.UpdateAsync(updateParameters);
            Profile updatedAFDProfile = lro.Value;
            ResourceDataHelper.AssertProfileUpdate(updatedAFDProfile, updateParameters);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckResourceUsage()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            int count = 0;
            await foreach (var tempUsage in AFDProfile.GetResourceUsageAFDProfilesAsync())
            {
                count++;
                Assert.AreEqual(tempUsage.Unit, UsageUnit.Count);
                Assert.AreEqual(tempUsage.CurrentValue, 0);
            }
            Assert.AreEqual(count, 6);
        }

        // CheckHostNameAvailability method is removed
        //[TestCase]
        //[RecordedTest]
        //[Ignore("Not ready")]
        //public async Task CheckHostNameAvailability()
        //{
        //    Subscription subscription = await Client.GetDefaultSubscriptionAsync();
        //    ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
        //    string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
        //    Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
        //    ValidateCustomDomainInput validateCustomDomainInput1 = new ValidateCustomDomainInput("testAFDEndpoint.z01.azurefd.net");
        //    ValidateCustomDomainOutput validateCustomDomainOutput = await AFDProfile.CheckHostNameAvailabilityAsync(validateCustomDomainInput1);
        //    Assert.False(validateCustomDomainOutput.CustomDomainValidated);
        //    ValidateCustomDomainInput validateCustomDomainInput2 = new ValidateCustomDomainInput("testAFDEndpoint-no-use.z01.azurefd.net");
        //    validateCustomDomainOutput = await AFDProfile.CheckHostNameAvailabilityAsync(validateCustomDomainInput2);
        //    Assert.True(validateCustomDomainOutput.CustomDomainValidated);
        //}

        [TestCase]
        [RecordedTest]
        public async Task GetLogAnalyticsLocations()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            ContinentsResponse continentsResponse = await AFDProfile.GetLogAnalyticsLocationsAFDProfileAsync();
            Assert.AreEqual(continentsResponse.Continents.Count, 7);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetLogAnalyticsMetrics()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await subscription.GetResourceGroups().GetAsync("CdnTest");
            Profile AFDProfile = await rg.GetProfiles().GetAsync("testAFDProfile");
            List<LogMetric> metric = new List<LogMetric>() { LogMetric.ClientRequestCount };
            DateTimeOffset dateTimeBegin = new DateTimeOffset(2021, 9, 23, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset dateTimeEnd = new DateTimeOffset(2021, 9, 25, 0, 0, 0, TimeSpan.Zero);
            List<string> customDomain = new List<string>() { "customdomain4afd.azuretest.net" };
            List<string> protocols = new List<string>() { "https" };
            MetricsResponse mtricsResponse = await AFDProfile.GetLogAnalyticsMetricsAFDProfileAsync(metric, dateTimeBegin, dateTimeEnd, LogMetricsGranularity.PT5M, customDomain, protocols);
            Assert.AreEqual(mtricsResponse.Granularity, MetricsResponseGranularity.PT5M);
            Assert.AreEqual(mtricsResponse.Series.Count, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetLogAnalyticsRankings()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await subscription.GetResourceGroups().GetAsync("CdnTest");
            Profile AFDProfile = await rg.GetProfiles().GetAsync("testAFDProfile");
            List<LogRanking> rankings = new List<LogRanking>() { LogRanking.Url };
            List<LogRankingMetric> metric = new List<LogRankingMetric>() { LogRankingMetric.ClientRequestCount };
            int maxRankings = 5;
            DateTimeOffset dateTimeBegin = new DateTimeOffset(2021, 9, 23, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset dateTimeEnd = new DateTimeOffset(2021, 9, 25, 0, 0, 0, TimeSpan.Zero);
            RankingsResponse rankingsResponse = await AFDProfile.GetLogAnalyticsRankingsAFDProfileAsync(rankings, metric, maxRankings, dateTimeBegin, dateTimeEnd);
            Assert.AreEqual(rankingsResponse.Tables.Count, 1);
            Assert.AreEqual(rankingsResponse.Tables[0].Ranking, LogRanking.Url.ToString());
            Assert.AreEqual(rankingsResponse.Tables[0].Data.Count, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetLogAnalyticsResources()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await subscription.GetResourceGroups().GetAsync("CdnTest");
            Profile AFDProfile = await rg.GetProfiles().GetAsync("testAFDProfile");
            ResourcesResponse resourcesResponse = await AFDProfile.GetLogAnalyticsResourcesAFDProfileAsync();
            Assert.AreEqual(resourcesResponse.CustomDomains.Count, 0);
            Assert.AreEqual(resourcesResponse.Endpoints.Count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetWafLogAnalyticsMetrics()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await subscription.GetResourceGroups().GetAsync("CdnTest");
            Profile AFDProfile = await rg.GetProfiles().GetAsync("testAFDPremiumProfile");
            List<WafMetric> metric = new List<WafMetric>() { WafMetric.ClientRequestCount };
            DateTimeOffset dateTimeBegin = new DateTimeOffset(2021, 9, 23, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset dateTimeEnd = new DateTimeOffset(2021, 9, 25, 0, 0, 0, TimeSpan.Zero);
            WafMetricsResponse wafMtricsResponse = await AFDProfile.GetWafLogAnalyticsMetricsAFDProfileAsync(metric, dateTimeBegin, dateTimeEnd, WafGranularity.PT5M);
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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await subscription.GetResourceGroups().GetAsync("CdnTest");
            Profile AFDProfile = await rg.GetProfiles().GetAsync("testAFDPremiumProfile");
            List<WafMetric> metric = new List<WafMetric>() { WafMetric.ClientRequestCount };
            DateTimeOffset dateTimeBegin = new DateTimeOffset(2021, 9, 23, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset dateTimeEnd = new DateTimeOffset(2021, 9, 25, 0, 0, 0, TimeSpan.Zero);
            int maxRankings = 5;
            List<WafRankingType> rankings = new List<WafRankingType>() { WafRankingType.UserAgent };
            WafRankingsResponse wafRankingsResponse = await AFDProfile.GetWafLogAnalyticsRankingsAFDProfileAsync(metric, dateTimeBegin, dateTimeEnd, maxRankings, rankings);
            Assert.AreEqual(wafRankingsResponse.Groups.Count, 1);
            Assert.AreEqual(wafRankingsResponse.Groups[0], WafRankingType.UserAgent.ToString());
            Assert.AreEqual(wafRankingsResponse.Data.Count, 0);
        }
    }
}
