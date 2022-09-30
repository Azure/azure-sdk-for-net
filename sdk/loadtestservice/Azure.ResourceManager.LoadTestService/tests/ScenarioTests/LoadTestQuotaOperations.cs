// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            _quotaResourceCollection = Subscription.GetQuotaResources(LoadTestResourceHelper.RESOURCE_LOCATION);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task GetMaxConcurrentTestRuns()
        {
            //// Quota get - maxConcurrentTestRuns
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
        [AsyncOnly]
        public async Task GetMaxConcurrentEngineInstances()
        {
            //// Quota get - maxConcurrentTestRuns
            var quotaResponse = await _quotaResourceCollection.GetAsync("maxConcurrentEngineInstances");
            Assert.IsNotNull(quotaResponse);
            Assert.IsNotNull(quotaResponse.Value);
            Assert.IsNotNull(quotaResponse.Value.Data);
            Assert.IsNotNull(quotaResponse.Value.Data.Name);
            Assert.IsNotNull(quotaResponse.Value.Data.Limit);
            Assert.IsNotNull(quotaResponse.Value.Data.Usage);
            Assert.AreEqual("maxConcurrentEngineInstances", quotaResponse.Value.Data.Name);
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task GetMaxEngineInstancesPerTestRun()
        {
            //// Quota get - maxConcurrentTestRuns
            var quotaResponse = await _quotaResourceCollection.GetAsync("maxEngineInstancesPerTestRun");
            Assert.IsNotNull(quotaResponse);
            Assert.IsNotNull(quotaResponse.Value);
            Assert.IsNotNull(quotaResponse.Value.Data);
            Assert.IsNotNull(quotaResponse.Value.Data.Name);
            Assert.IsNotNull(quotaResponse.Value.Data.Limit);
            Assert.IsNotNull(quotaResponse.Value.Data.Usage);
            Assert.AreEqual("maxEngineInstancesPerTestRun", quotaResponse.Value.Data.Name);
        }

        //[RecordedTest]
        //[AsyncOnly]
        //public async Task CheckQuotaAvailability()
        //{
        //    //// Quota get - maxConcurrentTestRuns
        //    var quotaResponse = await _quotaResourceCollection.GetAsync("maxConcurrentTestRuns");

        //    Assert.IsNotNull(quotaResponse);
        //    Assert.IsNotNull(quotaResponse.Value);
        //    QuotaResource quotaResource = quotaResponse.Value;
        //    Assert.IsNotNull(quotaResource.Data);
        //    Assert.IsNotNull(quotaResource.Data.Name);
        //    Assert.IsNotNull(quotaResource.Data.Limit);
        //    Assert.IsNotNull(quotaResource.Data.Usage);
        //    Assert.AreEqual("maxConcurrentTestRuns", quotaResource.Data.Name);

        //    QuotaBucketRequestPropertiesDimensions dimensions = new QuotaBucketRequestPropertiesDimensions(
        //        Subscription.Id.SubscriptionId, LoadTestResourceHelper.RESOURCE_LOCATION);
        //    QuotaBucketContent qbc = new QuotaBucketContent(quotaResponse.Value.Data.Id,
        //            quotaResource.Data.Name, quotaResource.Data.ResourceType, null,
        //            quotaResource.Data.Usage, quotaResource.Data.Limit, quotaResource.Data.Usage, dimensions);
        //    var a = await quotaResponse.Value.CheckAvailabilityAsync(qbc);
        //    Assert.IsNotNull(a);
        //}
    }
}
