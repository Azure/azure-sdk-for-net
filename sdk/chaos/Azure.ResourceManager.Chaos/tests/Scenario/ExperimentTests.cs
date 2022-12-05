// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Chaos.Tests.TestDependencies.Utilities;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Chaos.Tests
{
    [NonParallelizable]
    public class ExperimentTests : ChaosManagementTestBase
    {
        public ExperimentTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        // Typical constructor setup requires an init method instead to not break Record functionality
        [SetUp]
        public async Task ClearChallengeCacheForRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await Initialize().ConfigureAwait(false);
            }
        }

        [TestCase, Order(1)]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var resourceResponse = await this.ExperimentCollection.CreateOrUpdateAsync(WaitUntil.Completed, this.ExperimentName, this.MockExperimentEntities.GetVmssShutdownV2v0Experiment());
            Assert.AreEqual(this.ExperimentName, resourceResponse.Value.Data.Name);
        }

        [TestCase, Order(2)]
        [RecordedTest]
        public async Task Get()
        {
            await this.ExperimentCollection.CreateOrUpdateAsync(WaitUntil.Completed, this.ExperimentName, this.MockExperimentEntities.GetVmssShutdownV2v0Experiment());
            var getResourceResponse = await this.ExperimentCollection.GetAsync(this.ExperimentName).ConfigureAwait(false);
            Assert.AreEqual(this.ExperimentName, getResourceResponse.Value.Data.Name);
        }

        [TestCase, Order(3)]
        [RecordedTest]
        public async Task List()
        {
            var experimentList = await this.ExperimentCollection.GetAllAsync().ToListAsync().ConfigureAwait(false);
            Assert.True(experimentList.Count > 0);
        }

        [TestCase, Order(4)]
        [RecordedTest]
        public async Task Delete()
        {
            await this.ExperimentCollection.CreateOrUpdateAsync(WaitUntil.Completed, this.ExperimentName, this.MockExperimentEntities.GetVmssShutdownV2v0Experiment());
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroupAsync(TestEnvironment.ResourceGroup).ConfigureAwait(false);
            var experimentResourceResponse = await this.ExperimentCollection.GetAsync(this.ExperimentName).ConfigureAwait(false);
            var deleteResponse = await experimentResourceResponse.Value.DeleteAsync(WaitUntil.Completed).ConfigureAwait(false);
            Assert.AreEqual(200, deleteResponse.GetRawResponse().Status);

            var existsResponse = await rg.GetExperiments().ExistsAsync(this.ExperimentName).ConfigureAwait(false);
            Assert.AreEqual(false, existsResponse.Value);
        }

        [TestCase, Order(5)]
        [RecordedTest]
        public async Task StartAndCheckStatus()
        {
            var experimentName = $"{ExperimentNamePrefix}execution-{this.VmssId}";
            await this.ExperimentCollection.CreateOrUpdateAsync(WaitUntil.Completed, experimentName, this.MockExperimentEntities.GetVmssShutdownV2v0Experiment());
            var experimentResourceResponse = await this.ExperimentCollection.GetAsync(experimentName).ConfigureAwait(false);
            var startResponse = await experimentResourceResponse.Value.StartAsync().ConfigureAwait(false);
            Assert.AreEqual(experimentName, startResponse.Value.Name);
            Assert.AreEqual(202, startResponse.GetRawResponse().Status);

            var statusId = UrlUtility.GetStatusId(startResponse.Value.StatusUri);
            var statusResponse = await experimentResourceResponse.Value.GetExperimentStatusAsync(statusId).ConfigureAwait(false);
            Assert.AreEqual(statusId, statusResponse.Value.Id);
            Assert.AreEqual(200, statusResponse.GetRawResponse().Status);
        }
    }
}
