// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Logic.Tests
{
    internal class IntegrationAccountTests : LogicManagementTestBase
    {
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceGroupResource _resourceGroup;

        private IntegrationAccountCollection _integrationAccountCollection => _resourceGroup.GetIntegrationAccounts();

        public IntegrationAccountTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.CentralUS));
            _resourceGroupIdentifier = rgLro.Value.Id;
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
            string integrationAccountName = SessionRecording.GenerateAssetName("intergrationAccount");
            var integrationAccount = await CreateIntegrationAccount(_resourceGroup, integrationAccountName);
            Assert.IsNotNull(integrationAccount);
            Assert.AreEqual(integrationAccountName, integrationAccount.Data.Name);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string integrationAccountName = SessionRecording.GenerateAssetName("intergrationAccount");
            await CreateIntegrationAccount(_resourceGroup, integrationAccountName);
            bool flag = await _integrationAccountCollection.ExistsAsync(integrationAccountName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string integrationAccountName = SessionRecording.GenerateAssetName("intergrationAccount");
            await CreateIntegrationAccount(_resourceGroup, integrationAccountName);
            var integrationAccount = await _integrationAccountCollection.GetAsync(integrationAccountName);
            Assert.IsNotNull(integrationAccount);
            Assert.AreEqual(integrationAccountName, integrationAccount.Value.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string integrationAccountName = SessionRecording.GenerateAssetName("intergrationAccount");
            await CreateIntegrationAccount(_resourceGroup, integrationAccountName);
            var list = await _integrationAccountCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string integrationAccountName = SessionRecording.GenerateAssetName("intergrationAccount");
            var integrationAccount = await CreateIntegrationAccount(_resourceGroup, integrationAccountName);
            bool flag = await _integrationAccountCollection.ExistsAsync(integrationAccountName);
            Assert.IsTrue(flag);

            await integrationAccount.DeleteAsync(WaitUntil.Completed);
            flag = await _integrationAccountCollection.ExistsAsync(integrationAccountName);
            Assert.IsFalse(flag);
        }
    }
}
