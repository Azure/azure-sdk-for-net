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
            Assert.That(quotaResponse, Is.Not.Null);
            Assert.That(quotaResponse.Value, Is.Not.Null);
            Assert.That(quotaResponse.Value.Data, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(quotaResponse.Value.Data.Name, Is.Not.Null);
                Assert.That(quotaResponse.Value.Data.Limit, Is.Not.Null);
                Assert.That(quotaResponse.Value.Data.Usage, Is.Not.Null);
            });
            Assert.That(quotaResponse.Value.Data.Name, Is.EqualTo("maxConcurrentTestRuns"));

            quotaResponse = await Subscription.GetLoadTestingQuotaAsync(AzureLocation.WestUS2, "maxConcurrentTestRuns");
            Assert.That(quotaResponse, Is.Not.Null);
            Assert.That(quotaResponse.Value, Is.Not.Null);
            Assert.That(quotaResponse.Value.Data, Is.Not.Null);
            Assert.That(quotaResponse.Value.Data.Name, Is.Not.Null);
            Assert.That(quotaResponse.Value.Data.Limit, Is.Not.Null);
            Assert.That(quotaResponse.Value.Data.Usage, Is.Not.Null);
            Assert.That(quotaResponse.Value.Data.Name, Is.EqualTo("maxConcurrentTestRuns"));
        }

        [RecordedTest]
        public async Task ListAllQuotaBuckets()
        {
            //// Quota get limit and usage tests
            List<LoadTestingQuotaResource> quotaBuckets = await _quotaResourceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(quotaBuckets, Is.Not.Null);

            foreach (LoadTestingQuotaResource quotaBucket in quotaBuckets)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(quotaBucket.HasData, Is.True);
                    Assert.That(quotaBucket.Data, Is.Not.Null);
                });
                Assert.Multiple(() =>
                {
                    Assert.That(quotaBucket.Data.Name, Is.Not.Null);
                    Assert.That(quotaBucket.Data.Id, Is.Not.Null);
                    Assert.That(quotaBucket.Data.ResourceType, Is.Not.Null);
                    Assert.That(quotaBucket.Data.Limit, Is.Not.Null);
                    Assert.That(quotaBucket.Data.Usage, Is.Not.Null);
                });

                Response<LoadTestingQuotaResource> quotaBucketLimits = await quotaBucket.GetAsync();
                Assert.That(quotaBucketLimits, Is.Not.Null);
                Assert.Multiple(() =>
                {
                    Assert.That(quotaBucketLimits.HasValue, Is.True);
                    Assert.That(quotaBucketLimits.Value, Is.Not.Null);
                });
                Assert.Multiple(() =>
                {
                    Assert.That(quotaBucketLimits.Value.HasData, Is.True);
                    Assert.That(quotaBucketLimits.Value.Data, Is.Not.Null);
                });
                Assert.Multiple(() =>
                {
                    Assert.That(quotaBucketLimits.Value.Data.Name, Is.Not.Null);
                    Assert.That(quotaBucketLimits.Value.Data.Id, Is.Not.Null);
                    Assert.That(quotaBucketLimits.Value.Data.Limit, Is.Not.Null);
                    Assert.That(quotaBucketLimits.Value.Data.Usage, Is.Not.Null);
                });
            }
        }

        [RecordedTest]
        public async Task CheckQuotaAvailability()
        {
            //// Quota check availability tests
            Response<LoadTestingQuotaResource> quotaResponse = await _quotaResourceCollection.GetAsync("maxConcurrentTestRuns");

            Assert.That(quotaResponse, Is.Not.Null);
            Assert.That(quotaResponse.Value, Is.Not.Null);
            LoadTestingQuotaResource quotaResource = quotaResponse.Value;
            Assert.That(quotaResource.Data, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(quotaResource.Data.Id, Is.Not.Null);
                Assert.That(quotaResource.Data.Name, Is.Not.Null);
                Assert.That(quotaResource.Data.Limit, Is.Not.Null);
                Assert.That(quotaResource.Data.Usage, Is.Not.Null);
                Assert.That(quotaResource.Data.ResourceType, Is.Not.Null);
            });
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
            Assert.That(checkAvailabilityResult, Is.Not.Null);
            Assert.That(checkAvailabilityResult.Value, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(checkAvailabilityResult.Value.Name, Is.EqualTo("maxConcurrentTestRuns"));
                Assert.That(checkAvailabilityResult.Value.IsAvailable.Value == true || checkAvailabilityResult.Value.IsAvailable.Value == false, Is.True);
            });
        }
    }
}
