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
            Assert.Multiple(() =>
            {
                Assert.That(actual.Data.Correlation.ClientTrackingId, Is.Not.Empty);
                Assert.That(actual.Data.IsFired, Is.True);
                Assert.That(actual.Data.Id, Is.Not.Null);
                Assert.That(actual.Data.Run.Name, Is.Not.Null);
                Assert.That(actual.Data.StartOn, Is.Not.Null);
                Assert.That(actual.Data.EndOn, Is.Not.Null);
            });
        }

        [RecordedTest]
        public async Task Exist()
        {
            _ = await _trigger.RunAsync();
            var list = await _TriggerCollection.GetAllAsync().ToEnumerableAsync();
            string historyName = list.FirstOrDefault().Data.Name;
            bool flag = await _TriggerCollection.ExistsAsync(historyName);
            Assert.That(flag, Is.True);
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
            Assert.That(list, Is.Not.Empty);
            ValidateHistory(list.FirstOrDefault());
        }
    }
}
