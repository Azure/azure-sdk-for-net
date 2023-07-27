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
    internal class LogicWorkflowTriggerTests : LogicManagementTestBase
    {
        private ResourceIdentifier _logicWorkflowIdentifier;
        private LogicWorkflowResource _logicWorkflow;

        private LogicWorkflowTriggerCollection _triggerCollection => _logicWorkflow.GetLogicWorkflowTriggers();

        public LogicWorkflowTriggerTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.CentralUS));
            var integrationAccount = await CreateIntegrationAccount(rgLro.Value, SessionRecording.GenerateAssetName("integration"));
            var logicWorkflow = await CreateLogicWorkflow(rgLro.Value, integrationAccount.Data.Id, SessionRecording.GenerateAssetName("workflow"));
            _logicWorkflowIdentifier = logicWorkflow.Data.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _logicWorkflow = await Client.GetLogicWorkflowResource(_logicWorkflowIdentifier).GetAsync();
        }

        private void ValidateTrigger(LogicWorkflowTriggerResource actual)
        {
            Assert.AreEqual(DefaultTriggerName, actual.Data.Name);
            Assert.AreEqual("Succeeded", actual.Data.ProvisioningState.ToString());
            Assert.AreEqual("Enabled", actual.Data.State.ToString());
            Assert.NotNull(actual.Data.CreatedOn);
            Assert.NotNull(actual.Data.ChangedOn);
        }

        [RecordedTest]
        public async Task Exist()
        {
            bool flag = await _triggerCollection.ExistsAsync(DefaultTriggerName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            var trigger = await _triggerCollection.GetAsync(DefaultTriggerName);
            Assert.IsNotNull(trigger);
            ValidateTrigger(trigger.Value);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _triggerCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateTrigger(list.FirstOrDefault());
        }
    }
}
