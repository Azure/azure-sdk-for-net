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
    internal class LogicWorkflowRunTests : LogicManagementTestBase
    {
        private ResourceIdentifier _logicWorkflowIdentifier;
        private ResourceIdentifier _triggerIdentifier;
        private LogicWorkflowResource _logicWorkflow;
        private LogicWorkflowTriggerResource _trigger;

        private LogicWorkflowRunCollection _runCollection => _logicWorkflow.GetLogicWorkflowRuns();

        public LogicWorkflowRunTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.CentralUS));
            var integrationAccount = await CreateIntegrationAccount(rgLro.Value, SessionRecording.GenerateAssetName("integration"));
            var logicWorkflow = await CreateLogicWorkflow(rgLro.Value, integrationAccount.Data.Id, SessionRecording.GenerateAssetName("workflow"));
            var trigger = await logicWorkflow.GetLogicWorkflowTriggers().GetAsync(DefaultTriggerName);
            _logicWorkflowIdentifier = logicWorkflow.Data.Id;
            _triggerIdentifier = trigger.Value.Data.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _logicWorkflow = await Client.GetLogicWorkflowResource(_logicWorkflowIdentifier).GetAsync();
            _trigger = await Client.GetLogicWorkflowTriggerResource(_triggerIdentifier).GetAsync();
        }

        private void ValidateRunData(LogicWorkflowRunResource actual)
        {
            Assert.NotNull(actual.Data.Name);
            Assert.NotNull(actual.Data.EndOn);
            Assert.AreEqual("Succeeded", actual.Data.Status.ToString());
        }

        [RecordedTest]
        public async Task Exist()
        {
            await _trigger.RunAsync();
            var list = await _runCollection.GetAllAsync().ToEnumerableAsync();
            string runName = list.FirstOrDefault().Data.Name;

            bool flag = await _runCollection.ExistsAsync(runName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            await _trigger.RunAsync();
            var list = await _runCollection.GetAllAsync().ToEnumerableAsync();
            string runName = list.FirstOrDefault().Data.Name;

            var run = await _runCollection.GetAsync(runName);
            Assert.IsNotNull(run);
            ValidateRunData(run);

            var operation = await run.Value.GetLogicWorkflowRunActions().GetAllAsync().ToEnumerableAsync();
            System.Console.WriteLine("x");
        }

        [RecordedTest]
        public async Task GetAll()
        {
            await _trigger.RunAsync();
            var list = await _runCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateRunData(list.FirstOrDefault());
        }
    }
}
