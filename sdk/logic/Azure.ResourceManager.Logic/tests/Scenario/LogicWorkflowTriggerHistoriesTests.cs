// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Logic.Tests
{
    internal class LogicWorkflowTriggerHistoriesTests : LogicManagementTestBase
    {
        private ResourceIdentifier _triggerIdentifier;
        private LogicWorkflowTriggerResource _trigger;

        private LogicWorkflowTriggerHistoryCollection _TriggerCollection => _trigger.GetLogicWorkflowTriggerHistories();

        public LogicWorkflowTriggerHistoriesTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.CentralUS));
            var integrationAccount = await CreateIntegrationAccount(rgLro.Value, SessionRecording.GenerateAssetName("integration"));
            var logicWorkflow = await CreateLogicWorkflow(rgLro.Value, integrationAccount.Data.Id, SessionRecording.GenerateAssetName("workflow"));
            var trigger = await logicWorkflow.GetLogicWorkflowTriggers().GetAsync(DefaultTriggerName);
            _triggerIdentifier = trigger.Value.Data.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _trigger = await Client.GetLogicWorkflowTriggerResource(_triggerIdentifier).GetAsync();
        }

        private void ValidateHistory(LogicWorkflowTriggerHistoryResource actual)
        {
            Assert.IsNotEmpty(actual.Data.Correlation.ClientTrackingId);
            Assert.True(actual.Data.IsFired);
            Assert.NotNull(actual.Data.Id);
            Assert.NotNull(actual.Data.Run.Name);
            Assert.NotNull(actual.Data.StartOn);
            Assert.NotNull(actual.Data.EndOn);
        }

        [RecordedTest]
        public async Task Exist()
        {
            _ = await _trigger.RunAsync();
            var list = await _TriggerCollection.GetAllAsync().ToEnumerableAsync();
            string historyName = list.FirstOrDefault().Data.Name;
            bool flag = await _TriggerCollection.ExistsAsync(historyName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            _ = await _trigger.RunAsync();
            var list = await _TriggerCollection.GetAllAsync().ToEnumerableAsync();
            string historyName = list.FirstOrDefault().Data.Name;
            var history = await _TriggerCollection.GetAsync(historyName);
            ValidateHistory(history.Value);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            _ = await _trigger.RunAsync();
            var list = await _TriggerCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateHistory(list.FirstOrDefault());
        }
    }
}
