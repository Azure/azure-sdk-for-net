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
    internal class LogicWorkflowRunActionTests : LogicManagementTestBase
    {
        private ResourceIdentifier _runResourceIdentifier;
        private LogicWorkflowRunResource _runResource;

        private LogicWorkflowRunActionCollection _runActionCollection => _runResource.GetLogicWorkflowRunActions();

        public LogicWorkflowRunActionTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.CentralUS));
            var integrationAccount = await CreateIntegrationAccount(rgLro.Value, SessionRecording.GenerateAssetName("integration"));
            var logicWorkflow = await CreateLogicWorkflow(rgLro.Value, integrationAccount.Data.Id, SessionRecording.GenerateAssetName("workflow"));
            var trigger = await logicWorkflow.GetLogicWorkflowTriggers().GetAsync(DefaultTriggerName);
            _ = await trigger.Value.RunAsync();
            var runResource = (await logicWorkflow.GetLogicWorkflowRuns().GetAllAsync().ToEnumerableAsync()).FirstOrDefault();
            _runResourceIdentifier = runResource.Data.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _runResource = await Client.GetLogicWorkflowRunResource(_runResourceIdentifier).GetAsync();
        }

        private void ValidateRunData(LogicWorkflowRunActionResource actual)
        {
            Assert.AreEqual("Response", actual.Data.Name);
            Assert.NotNull(actual.Data.StartOn);
            Assert.NotNull(actual.Data.EndOn);
            Assert.AreEqual("Skipped", actual.Data.Status.ToString());
        }

        [RecordedTest]
        public async Task Exist()
        {
            bool flag = await _runActionCollection.ExistsAsync("Response");
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            var runAction = await _runActionCollection.GetAsync("Response");
            Assert.IsNotNull(runAction);
            ValidateRunData(runAction);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _runActionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateRunData(list.FirstOrDefault());
        }
    }
}
