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
            : base(isAsync)//, RecordedTestMode.Record)
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

            var existsResponse = await rg.GetExperiments().ExistsAsync(this.ExperimentName).ConfigureAwait(false);
            Assert.AreEqual(false, existsResponse.Value);
        }

        [TestCase, Order(5)]
        [RecordedTest]
        public async Task StartAndCheckStatus()
        {
            var experimentName = string.Format(TestConstants.ExperimentForExecutionNameFormat, TestConstants.ExperimentNamePrefix, this.VmssId);
            var experimentResourceResponse = await this.ExperimentCollection.GetAsync(experimentName).ConfigureAwait(false);
            var startResponse = await experimentResourceResponse.Value.StartAsync().ConfigureAwait(false);
            Assert.AreEqual(experimentName, startResponse.Value.Name);
            Assert.AreEqual(202, startResponse.GetRawResponse().Status);

            var statusId = UrlUtility.GetStatusId(startResponse.Value.StatusUri);
            var statusResponse = await experimentResourceResponse.Value.GetExperimentStatusAsync(statusId).ConfigureAwait(false);
            Assert.AreEqual(200, statusResponse.GetRawResponse().Status);
        }

        [TestCase, Order(6)]
        [RecordedTest]
        public async Task Cancel()
        {
            var experimentName = string.Format(TestConstants.ExperimentForExecutionNameFormat, TestConstants.ExperimentNamePrefix, this.VmssId);
            var experimentResourceResponse = await this.ExperimentCollection.GetAsync(experimentName).ConfigureAwait(false);
            var cancelResponse = await experimentResourceResponse.Value.CancelAsync().ConfigureAwait(false);
            Assert.AreEqual(experimentName, cancelResponse.Value.Name);
            Assert.AreEqual(202, cancelResponse.GetRawResponse().Status);
        }

        [TestCase, Order(7)]
        [RecordedTest]
        public async Task ListAndGetDetails()
        {
            var experimentName = string.Format(TestConstants.ExperimentForExecutionNameFormat, TestConstants.ExperimentNamePrefix, this.VmssId);
            var experimentResourceResponse = await this.ExperimentCollection.GetAsync(experimentName).ConfigureAwait(false);
            var detailsList = await experimentResourceResponse.Value.GetExperimentExecutionDetails().ToListAsync().ConfigureAwait(false);
            Assert.True(detailsList.Any());

            var detailId = UrlUtility.GetDetailsId(detailsList.FirstOrDefault().Id);
            var experimentDetailResponse = await experimentResourceResponse.Value.GetExperimentExecutionDetailAsync(detailId).ConfigureAwait(false);
            Assert.AreEqual(detailsList.FirstOrDefault().Id, experimentDetailResponse.Value.Id);
            Assert.AreEqual(200, experimentDetailResponse.GetRawResponse().Status);
        }
    }
}
