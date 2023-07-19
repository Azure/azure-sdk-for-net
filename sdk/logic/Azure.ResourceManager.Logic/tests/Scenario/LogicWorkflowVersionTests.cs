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
    internal class LogicWorkflowVersionTests : LogicManagementTestBase
    {
        private ResourceIdentifier _logicWorkflowIdentifier;
        private LogicWorkflowResource _logicWorkflow;

        private LogicWorkflowVersionCollection _versionCollection => _logicWorkflow.GetLogicWorkflowVersions();

        public LogicWorkflowVersionTests(bool isAsync) : base(isAsync)
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

        [RecordedTest]
        public async Task Exist()
        {
            var list = await _versionCollection.GetAllAsync().ToEnumerableAsync();
            string versionName = list.FirstOrDefault().Data.Name;
            bool flag = await _versionCollection.ExistsAsync(versionName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            var list = await _versionCollection.GetAllAsync().ToEnumerableAsync();
            string versionName = list.FirstOrDefault().Data.Name;
            var version = await _versionCollection.GetAsync(versionName);
            Assert.IsNotNull(version);
            Assert.AreEqual(versionName, version.Value.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _versionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(1, list.Count);
        }
    }
}
