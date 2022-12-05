// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.LoadTestService.Models;
using Azure.ResourceManager.LoadTestService.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.LoadTestService.Tests.ScenarioTests
{
    public class LoadTestQuotaOperations : LoadTestServiceManagementTestBase
    {
        private QuotaResourceCollection _quotaResourceCollection { get; set; }
        private QuotaResource _quotaResource { get; set; }
        private QuotaResourceData _quotaResourceData { get; set; }

        public LoadTestQuotaOperations(bool isAsync) : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateCommonClient();
            }
            _quotaResourceCollection = Subscription.GetQuotaResources(LoadTestResourceHelper.LOADTESTS_RESOURCE_LOCATION);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [RecordedTest]
        public async Task GetQuotaLimitAndUsage()
        {
            //// Quota get limit and usage tests
            var quotaResponse = await _quotaResourceCollection.GetAsync("maxConcurrentTestRuns");
            Assert.IsNotNull(quotaResponse);
            Assert.IsNotNull(quotaResponse.Value);
            Assert.IsNotNull(quotaResponse.Value.Data);
            Assert.IsNotNull(quotaResponse.Value.Data.Name);
            Assert.IsNotNull(quotaResponse.Value.Data.Limit);
            Assert.IsNotNull(quotaResponse.Value.Data.Usage);
            Assert.AreEqual("maxConcurrentTestRuns", quotaResponse.Value.Data.Name);
        }

        [RecordedTest]
        public async Task CheckQuotaAvailability()
        {
            //// Quota check availability tests
            Response<QuotaResource> quotaResponse = await _quotaResourceCollection.GetAsync("maxConcurrentTestRuns");

            Assert.IsNotNull(quotaResponse);
            Assert.IsNotNull(quotaResponse.Value);
            QuotaResource quotaResource = quotaResponse.Value;
            Assert.IsNotNull(quotaResource.Data);
            Assert.IsNotNull(quotaResource.Data.Name);
            Assert.IsNotNull(quotaResource.Data.Limit);
            Assert.IsNotNull(quotaResource.Data.Usage);
            Assert.AreEqual("maxConcurrentTestRuns", quotaResource.Data.Name);

            QuotaBucketRequestPropertiesDimensions dimensions = new QuotaBucketRequestPropertiesDimensions(
                Subscription.Id.SubscriptionId, LoadTestResourceHelper.LOADTESTS_RESOURCE_LOCATION);

            QuotaBucketContent quotaAvailabilityPayload = new QuotaBucketContent(
                quotaResponse.Value.Data.Id,
                quotaResource.Data.Name,
                quotaResource.Data.ResourceType,
                null,
                quotaResource.Data.Usage,
                quotaResource.Data.Limit,
                quotaResource.Data.Limit,
                dimensions);

            Response<CheckQuotaAvailabilityResponse> checkAvailabilityResponse = await quotaResponse.Value.CheckAvailabilityAsync(quotaAvailabilityPayload);
            Assert.IsNotNull(checkAvailabilityResponse);
            Assert.IsNotNull(checkAvailabilityResponse.Value);
            Assert.AreEqual("maxConcurrentTestRuns", checkAvailabilityResponse.Value.Name);
            Assert.True(checkAvailabilityResponse.Value.IsAvailable.Value == true || checkAvailabilityResponse.Value.IsAvailable.Value == false);
        }
    }
}
