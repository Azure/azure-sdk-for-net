// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Chaos.Tests.TestDependencies;
using Azure.ResourceManager.Chaos.Tests.TestDependencies.Utilities;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Chaos.Tests
{
    [NonParallelizable]
    public class ExperimentTests : ChaosManagementTestBase
    {
        public ExperimentTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Playback)
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

            if (Mode == RecordedTestMode.Record)
            {
                await Delay(10000);
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
            Assert.True(experimentList.Any());
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

            await Delay(2000, 0);

            var existsResponse = await rg.GetChaosExperiments().ExistsAsync(this.ExperimentName).ConfigureAwait(false);
            Assert.AreEqual(false, existsResponse.Value);
        }

        [TestCase, Order(5)]
        [RecordedTest]
        public async Task StartAndCheckExecutionStatus()
        {
            var experimentName = string.Format(TestConstants.ExperimentForExecutionNameFormat, TestConstants.ExperimentNamePrefix, this.VmssId);
            var experimentResourceResponse = await this.ExperimentCollection.GetAsync(experimentName).ConfigureAwait(false);
            var startResponse = await experimentResourceResponse.Value.StartAsync(WaitUntil.Started).ConfigureAwait(false);
            Assert.AreEqual(202, startResponse.GetRawResponse().Status);

            var executionsList = await experimentResourceResponse.Value.GetChaosExperimentExecutions().ToListAsync().ConfigureAwait(false);
            Assert.True(executionsList.Any());

            var executionId = UrlUtility.GetExecutionsId(executionsList.FirstOrDefault().Id);
            var executionResponse = await experimentResourceResponse.Value.GetChaosExperimentExecutionAsync(executionId).ConfigureAwait(false);
            Assert.AreEqual(200, executionResponse.GetRawResponse().Status);
        }

        [TestCase, Order(6)]
        [RecordedTest]
        public async Task Cancel()
        {
            var experimentName = string.Format(TestConstants.ExperimentForExecutionNameFormat, TestConstants.ExperimentNamePrefix, this.VmssId);
            var experimentResourceResponse = await this.ExperimentCollection.GetAsync(experimentName).ConfigureAwait(false);
            var cancelResponse = await experimentResourceResponse.Value.CancelAsync(WaitUntil.Started).ConfigureAwait(false);
            Assert.AreEqual(202, cancelResponse.GetRawResponse().Status);
        }
    }
}
