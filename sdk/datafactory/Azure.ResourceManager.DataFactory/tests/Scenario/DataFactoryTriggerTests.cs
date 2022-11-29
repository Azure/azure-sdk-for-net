// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DataFactory.Tests.Scenario
{
    internal class DataFactoryTriggerTests : DataFactoryManagementTestBase
    {
        private ResourceIdentifier _dataFactoryIdentifier;
        private DataFactoryResource _dataFactory;
        public DataFactoryTriggerTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            string rgName = SessionRecording.GenerateAssetName("DataFactory-RG-");
            string dataFactoryName = SessionRecording.GenerateAssetName("DataFactory-");
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
            var dataFactoryLro = await CreateDataFactory(rgLro.Value, dataFactoryName);
            _dataFactoryIdentifier = dataFactoryLro.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _dataFactory = await Client.GetDataFactoryResource(_dataFactoryIdentifier).GetAsync();
        }

        private async Task<FactoryTriggerResource> CreateDefaultTrigger(DataFactoryResource dataFactory, string triggerName)
        {
            FactoryTriggerDefinition dataFactoryTriggerProperties = new FactoryTriggerDefinition()
            {
                TriggerType = "ScheduleTrigger",
            };
            FactoryTriggerData data = new FactoryTriggerData(dataFactoryTriggerProperties);
            var trigger = await dataFactory.GetFactoryTriggers().CreateOrUpdateAsync(WaitUntil.Completed, triggerName, data);
            return trigger.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string triggerName = Recording.GenerateAssetName("trigger-");
            var trigger = await CreateDefaultTrigger(_dataFactory, triggerName);
            Assert.IsNotNull(trigger);
            Assert.AreEqual(triggerName, trigger.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string triggerName = Recording.GenerateAssetName("trigger-");
            await CreateDefaultTrigger(_dataFactory, triggerName);
            bool flag = await _dataFactory.GetFactoryTriggers().ExistsAsync(triggerName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string triggerName = Recording.GenerateAssetName("trigger-");
            await CreateDefaultTrigger(_dataFactory, triggerName);
            var trigger = await _dataFactory.GetFactoryTriggers().GetAsync(triggerName);
            Assert.IsNotNull(trigger);
            Assert.AreEqual(triggerName, trigger.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string triggerName = Recording.GenerateAssetName("trigger-");
            await CreateDefaultTrigger(_dataFactory, triggerName);
            var list = await _dataFactory.GetFactoryTriggers().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string triggerName = Recording.GenerateAssetName("trigger-");
            var trigger = await CreateDefaultTrigger(_dataFactory, triggerName);
            bool flag = await _dataFactory.GetFactoryTriggers().ExistsAsync(triggerName);
            Assert.IsTrue(flag);

            await trigger.DeleteAsync(WaitUntil.Completed);
            flag = await _dataFactory.GetFactoryTriggers().ExistsAsync(triggerName);
            Assert.IsFalse(flag);
        }
    }
}
