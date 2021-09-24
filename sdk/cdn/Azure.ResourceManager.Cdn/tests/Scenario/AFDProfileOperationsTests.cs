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
            ResourceGroup rg = await CreateResourceGroup("testRg-");
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
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            ProfileUpdateParameters updateParameters = new ProfileUpdateParameters();
            updateParameters.Tags.Add("newTag", "newValue");
            var lro = await AFDProfile.UpdateAsync(updateParameters);
            Profile updatedProfile = lro.Value;
            ResourceDataHelper.AssertProfileUpdate(updatedProfile, updateParameters);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckResourceUsage()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            int count = 0;
            await foreach (var tempUsage in AFDProfile.CheckResourceUsageAsync())
            {
                count++;
                Assert.AreEqual(tempUsage.Unit, UsageUnit.Count);
                Assert.AreEqual(tempUsage.CurrentValue, 0);
            }
            Assert.AreEqual(count, 6);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Not ready, service returns nameAvailable instead of customDomainValidated")]
        public async Task CheckHostNameAvailability()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            ValidateCustomDomainInput validateCustomDomainInput1 = new ValidateCustomDomainInput("testAFDEndpoint.z01.azurefd.net");
            ValidateCustomDomainOutput validateCustomDomainOutput = await AFDProfile.CheckHostNameAvailabilityAsync(validateCustomDomainInput1);
            Assert.False(validateCustomDomainOutput.CustomDomainValidated);
            ValidateCustomDomainInput validateCustomDomainInput2 = new ValidateCustomDomainInput("testAFDEndpoint-no-use.z01.azurefd.net");
            validateCustomDomainOutput = await AFDProfile.CheckHostNameAvailabilityAsync(validateCustomDomainInput2);
            Assert.True(validateCustomDomainOutput.CustomDomainValidated);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("The id of ContinentsResponseCountryOrRegionsItem inherits from subResource")]
        public async Task GetLogAnalyticsLocations()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            ContinentsResponse continentsResponse = await AFDProfile.GetLogAnalyticsLocationsAsync();
            Assert.AreEqual(continentsResponse.Continents.Count, 7);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetLogAnalyticsMetrics()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            List<LogMetric> metric = new List<LogMetric>() { LogMetric.ClientRequestCount };
            DateTimeOffset dateTimeBegin = new DateTimeOffset(2021, 9, 23, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset dateTimeEnd = new DateTimeOffset(2021, 9, 25, 0, 0, 0, TimeSpan.Zero);
            MetricsResponse mtricsResponse = await AFDProfile.GetLogAnalyticsMetricsAsync(metric, dateTimeBegin, dateTimeEnd, LogMetricsGranularity.PT5M, new List<string>(), new List<string>());
        }
    }
}
