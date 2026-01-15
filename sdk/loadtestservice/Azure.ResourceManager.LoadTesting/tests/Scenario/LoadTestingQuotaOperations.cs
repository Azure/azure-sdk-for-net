// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
            Response<LoadTestingQuotaResource> quotaResponse = await _quotaResourceCollection.GetAsync("maxConcurrentTestRuns");
            Assert.IsNotNull(quotaResponse);
            Assert.IsNotNull(quotaResponse.Value);
            Assert.IsNotNull(quotaResponse.Value.Data);
            Assert.IsNotNull(quotaResponse.Value.Data.Name);
            Assert.IsNotNull(quotaResponse.Value.Data.Limit);
            Assert.IsNotNull(quotaResponse.Value.Data.Usage);
            Assert.That(quotaResponse.Value.Data.Name, Is.EqualTo("maxConcurrentTestRuns"));

            quotaResponse = await Subscription.GetLoadTestingQuotaAsync(AzureLocation.WestUS2, "maxConcurrentTestRuns");
            Assert.IsNotNull(quotaResponse);
            Assert.IsNotNull(quotaResponse.Value);
            Assert.IsNotNull(quotaResponse.Value.Data);
            Assert.IsNotNull(quotaResponse.Value.Data.Name);
            Assert.IsNotNull(quotaResponse.Value.Data.Limit);
            Assert.IsNotNull(quotaResponse.Value.Data.Usage);
            Assert.That(quotaResponse.Value.Data.Name, Is.EqualTo("maxConcurrentTestRuns"));
        }

        [RecordedTest]
        public async Task ListAllQuotaBuckets()
        {
            //// Quota get limit and usage tests
            List<LoadTestingQuotaResource> quotaBuckets = await _quotaResourceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(quotaBuckets);

            foreach (LoadTestingQuotaResource quotaBucket in quotaBuckets)
            {
                Assert.That(quotaBucket.HasData, Is.True);
                Assert.IsNotNull(quotaBucket.Data);
                Assert.IsNotNull(quotaBucket.Data.Name);
                Assert.IsNotNull(quotaBucket.Data.Id);
                Assert.IsNotNull(quotaBucket.Data.ResourceType);
                Assert.IsNotNull(quotaBucket.Data.Limit);
                Assert.IsNotNull(quotaBucket.Data.Usage);

                Response<LoadTestingQuotaResource> quotaBucketLimits = await quotaBucket.GetAsync();
                Assert.IsNotNull(quotaBucketLimits);
                Assert.That(quotaBucketLimits.HasValue, Is.True);
                Assert.NotNull(quotaBucketLimits.Value);
                Assert.That(quotaBucketLimits.Value.HasData, Is.True);
                Assert.NotNull(quotaBucketLimits.Value.Data);
                Assert.NotNull(quotaBucketLimits.Value.Data.Name);
                Assert.NotNull(quotaBucketLimits.Value.Data.Id);
                Assert.NotNull(quotaBucketLimits.Value.Data.Limit);
                Assert.NotNull(quotaBucketLimits.Value.Data.Usage);
            }
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
            Assert.IsNotNull(quotaResource.Data.Id);
            Assert.IsNotNull(quotaResource.Data.Name);
            Assert.IsNotNull(quotaResource.Data.Limit);
            Assert.IsNotNull(quotaResource.Data.Usage);
            Assert.IsNotNull(quotaResource.Data.ResourceType);
            Assert.That(quotaResource.Data.Name, Is.EqualTo("maxConcurrentTestRuns"));

            LoadTestingQuotaBucketDimensions dimensions = new LoadTestingQuotaBucketDimensions(
                Subscription.Id.SubscriptionId, LoadTestResourceHelper.LOADTESTS_RESOURCE_LOCATION, null);

            LoadTestingQuotaBucketContent quotaAvailabilityPayload = new LoadTestingQuotaBucketContent(
                quotaResponse.Value.Data.Id,
                quotaResource.Data.Name,
                quotaResource.Data.ResourceType,
                null,
                quotaResource.Data.Usage,
                quotaResource.Data.Limit,
                quotaResource.Data.Limit,
                dimensions, null);

            Response<LoadTestingQuotaAvailabilityResult> checkAvailabilityResult = await quotaResponse.Value.CheckLoadTestingQuotaAvailabilityAsync(quotaAvailabilityPayload);
            Assert.IsNotNull(checkAvailabilityResult);
            Assert.IsNotNull(checkAvailabilityResult.Value);
            Assert.That(checkAvailabilityResult.Value.Name, Is.EqualTo("maxConcurrentTestRuns"));
            Assert.That(checkAvailabilityResult.Value.IsAvailable.Value == true || checkAvailabilityResult.Value.IsAvailable.Value == false, Is.True);
        }
    }
}
