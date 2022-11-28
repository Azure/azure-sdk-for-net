// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.LoadTesting;
using Azure.ResourceManager.LoadTesting.Models;
using Azure.ResourceManager.LoadTesting.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.LoadTesting.Tests.ScenarioTests
{
    public class LoadTestingQuotaOperations : LoadTestingManagementTestBase
    {
        private LoadTestingQuotaCollection _quotaResourceCollection { get; set; }
        private LoadTestingQuotaResource _quotaResource { get; set; }
        private LoadTestingQuotaData _quotaResourceData { get; set; }

        public LoadTestingQuotaOperations(bool isAsync) : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateCommonClient();
            }
            _quotaResourceCollection = Subscription.GetAllLoadTestingQuota(LoadTestResourceHelper.LOADTESTS_RESOURCE_LOCATION);
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
            Response<LoadTestingQuotaResource> quotaResponse = await _quotaResourceCollection.GetAsync("maxConcurrentTestRuns");

            Assert.IsNotNull(quotaResponse);
            Assert.IsNotNull(quotaResponse.Value);
            LoadTestingQuotaResource quotaResource = quotaResponse.Value;
            Assert.IsNotNull(quotaResource.Data);
            Assert.IsNotNull(quotaResource.Data.Name);
            Assert.IsNotNull(quotaResource.Data.Limit);
            Assert.IsNotNull(quotaResource.Data.Usage);
            Assert.AreEqual("maxConcurrentTestRuns", quotaResource.Data.Name);

            LoadTestingQuotaBucketDimensions dimensions = new LoadTestingQuotaBucketDimensions(
                Subscription.Id.SubscriptionId, LoadTestResourceHelper.LOADTESTS_RESOURCE_LOCATION);

            LoadTestingQuotaBucketContent quotaAvailabilityPayload = new LoadTestingQuotaBucketContent(
                quotaResponse.Value.Data.Id,
                quotaResource.Data.Name,
                quotaResource.Data.ResourceType,
                null,
                quotaResource.Data.Usage,
                quotaResource.Data.Limit,
                quotaResource.Data.Limit,
                dimensions);

            Response<LoadTestingQuotaAvailabilityResponse> checkAvailabilityResponse = await quotaResponse.Value.CheckAvailabilityAsync(quotaAvailabilityPayload);
            Assert.IsNotNull(checkAvailabilityResponse);
            Assert.IsNotNull(checkAvailabilityResponse.Value);
            Assert.AreEqual("maxConcurrentTestRuns", checkAvailabilityResponse.Value.Name);
            Assert.True(checkAvailabilityResponse.Value.IsAvailable.Value == true || checkAvailabilityResponse.Value.IsAvailable.Value == false);
        }
    }
}
