// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Logic.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Logic.Tests
{
    internal class IntegrationAccountBatchConfigurationTests : LogicManagementTestBase
    {
        private ResourceIdentifier _integrationAccountIdentifier;
        private IntegrationAccountResource _integrationAccount;

        private IntegrationAccountBatchConfigurationCollection _batchConfigurationCollection => _integrationAccount.GetIntegrationAccountBatchConfigurations();

        public IntegrationAccountBatchConfigurationTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.CentralUS));
            var integrationAccount = await CreateIntegrationAccount(rgLro.Value, SessionRecording.GenerateAssetName("intergrationAccount"));
            _integrationAccountIdentifier = integrationAccount.Data.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _integrationAccount = await Client.GetIntegrationAccountResource(_integrationAccountIdentifier).GetAsync();
        }

        private async Task<IntegrationAccountBatchConfigurationResource> CreateBatchConfiguration(string batchConfigurationName)
        {
            string batchGroupName = SessionRecording.GenerateAssetName("batchGroup");
            var properties = new IntegrationAccountBatchConfigurationProperties(batchGroupName, new IntegrationAccountBatchReleaseCriteria() { BatchSize = 10 });
            IntegrationAccountBatchConfigurationData data = new IntegrationAccountBatchConfigurationData(_integrationAccount.Data.Location, properties);
            var batchConfiguration = await _batchConfigurationCollection.CreateOrUpdateAsync(WaitUntil.Completed, batchConfigurationName, data);
            return batchConfiguration.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string batchConfigurationName = SessionRecording.GenerateAssetName("batch");
            var batchConfiguration = await CreateBatchConfiguration(batchConfigurationName);
            Assert.IsNotNull(batchConfiguration);
            Assert.AreEqual(batchConfigurationName, batchConfiguration.Data.Name);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string batchConfigurationName = SessionRecording.GenerateAssetName("batch");
            await CreateBatchConfiguration(batchConfigurationName);
            bool flag = await _batchConfigurationCollection.ExistsAsync(batchConfigurationName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string batchConfigurationName = SessionRecording.GenerateAssetName("batch");
            await CreateBatchConfiguration(batchConfigurationName);
            var batchConfiguration = await _batchConfigurationCollection.GetAsync(batchConfigurationName);
            Assert.IsNotNull(batchConfiguration);
            Assert.AreEqual(batchConfigurationName, batchConfiguration.Value.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string batchConfigurationName = SessionRecording.GenerateAssetName("batch");
            await CreateBatchConfiguration(batchConfigurationName);
            var list = await _batchConfigurationCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string batchConfigurationName = SessionRecording.GenerateAssetName("batch");
            var batchConfiguration = await CreateBatchConfiguration(batchConfigurationName);
            bool flag = await _batchConfigurationCollection.ExistsAsync(batchConfigurationName);
            Assert.IsTrue(flag);

            await batchConfiguration.DeleteAsync(WaitUntil.Completed);
            flag = await _batchConfigurationCollection.ExistsAsync(batchConfigurationName);
            Assert.IsFalse(flag);
        }
    }
}
