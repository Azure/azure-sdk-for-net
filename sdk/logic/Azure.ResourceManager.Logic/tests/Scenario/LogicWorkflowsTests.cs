// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Logic.Tests
{
    internal class LogicWorkflowsTests : LogicManagementTestBase
    {
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceIdentifier _integrationAccountIdentifier;
        private ResourceGroupResource _resourceGroup;

        private LogicWorkflowCollection _logicWorkflowCollection => _resourceGroup.GetLogicWorkflows();

        public LogicWorkflowsTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.CentralUS));
            var integrationAccount = await CreateIntegrationAccount(rgLro.Value, SessionRecording.GenerateAssetName("integration"));
            _resourceGroupIdentifier = rgLro.Value.Id;
            _integrationAccountIdentifier = integrationAccount.Data.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await Client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string logicWorkflowName = Recording.GenerateAssetName("workflow");
            var logicWorkflow = await CreateLogicWorkflow(_resourceGroup, _integrationAccountIdentifier, logicWorkflowName);
            Assert.IsNotNull(logicWorkflow);
            Assert.AreEqual(logicWorkflowName, logicWorkflow.Data.Name);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string logicWorkflowName = Recording.GenerateAssetName("workflow");
            await CreateLogicWorkflow(_resourceGroup, _integrationAccountIdentifier, logicWorkflowName);
            bool flag = await _logicWorkflowCollection.ExistsAsync(logicWorkflowName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string logicWorkflowName = Recording.GenerateAssetName("workflow");
            await CreateLogicWorkflow(_resourceGroup, _integrationAccountIdentifier, logicWorkflowName);
            var logicWorkflow = await _logicWorkflowCollection.GetAsync(logicWorkflowName);
            Assert.IsNotNull(logicWorkflow);
            Assert.AreEqual(logicWorkflowName, logicWorkflow.Value.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string logicWorkflowName = Recording.GenerateAssetName("workflow");
            await CreateLogicWorkflow(_resourceGroup, _integrationAccountIdentifier, logicWorkflowName);
            var list = await _logicWorkflowCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string logicWorkflowName = Recording.GenerateAssetName("workflow");
            var logicWorkflow = await CreateLogicWorkflow(_resourceGroup, _integrationAccountIdentifier, logicWorkflowName);
            bool flag = await _logicWorkflowCollection.ExistsAsync(logicWorkflowName);
            Assert.IsTrue(flag);

            await logicWorkflow.DeleteAsync(WaitUntil.Completed);
            flag = await _logicWorkflowCollection.ExistsAsync(logicWorkflowName);
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        public async Task Update()
        {
            string logicWorkflowName = Recording.GenerateAssetName("workflow");
            var logicWorkflow = await CreateLogicWorkflow(_resourceGroup, _integrationAccountIdentifier, logicWorkflowName);

            var input = ConstructLogicWorkflowData(_resourceGroup.Data.Location, _integrationAccountIdentifier);
            input.Tags.Add("testKey", "testVal");
            var lro = await logicWorkflow.UpdateAsync(WaitUntil.Completed, input);
            var updatedLogicWorkflow = lro.Value;

            Assert.AreEqual(updatedLogicWorkflow.Data.Tags.Count, 1);
        }
    }
}
