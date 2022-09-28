// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DataFactory.Tests
{
    internal class DataFactoryTests : DataFactoryManagementTestBase
    {
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceGroupResource _resourceGroup;
        public DataFactoryTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            string rgName = SessionRecording.GenerateAssetName("DataFactory-RG-");
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
            _resourceGroupIdentifier = rgLro.Value.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await Client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string dataFactoryName = Recording.GenerateAssetName("dataFactory-");
            DataFactoryData data = new DataFactoryData(_resourceGroup.Data.Location);
            var dataFactory = await _resourceGroup.GetDataFactories().CreateOrUpdateAsync(WaitUntil.Completed, dataFactoryName, data);
            Assert.IsNotNull(dataFactory);
            Assert.AreEqual(dataFactoryName, dataFactory.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            var dataFactory = await CreateDataFactory(_resourceGroup);
            bool flag = await _resourceGroup.GetDataFactories().ExistsAsync(dataFactory.Id.Name);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup);
            var dataFactoryName = dataFactory.Id.Name;
            dataFactory = await _resourceGroup.GetDataFactories().GetAsync(dataFactoryName);
            Assert.IsNotNull(dataFactory);
            Assert.AreEqual(dataFactoryName, dataFactory.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            await CreateDataFactory(_resourceGroup);
            var list = await _resourceGroup.GetDataFactories().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            var dataFactory = await CreateDataFactory(_resourceGroup);
            bool flag = await _resourceGroup.GetDataFactories().ExistsAsync(dataFactory.Id.Name);
            Assert.IsTrue(flag);
            await dataFactory.DeleteAsync(WaitUntil.Completed);
            flag = await _resourceGroup.GetDataFactories().ExistsAsync(dataFactory.Id.Name);
            Assert.IsFalse(flag);
        }
    }
}
