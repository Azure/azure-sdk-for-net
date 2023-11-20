// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DataFactory.Tests.Scenario
{
    internal class DataFactoryTests : DataFactoryManagementTestBase
    {
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceGroupResource _resourceGroup;
        public DataFactoryTests(bool isAsync) : base(isAsync)
        {
        }

        public async Task TestSetUp()
        {
            string rgName = Recording.GenerateAssetName("DataFactory-RG-");
            var rgLro = await Client.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
            _resourceGroupIdentifier = rgLro.Value.Id;
            _resourceGroup = await Client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            await TestSetUp();
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
            await TestSetUp();
            string dataFactoryName = Recording.GenerateAssetName("dataFactory-");
            var dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            bool flag = await _resourceGroup.GetDataFactories().ExistsAsync(dataFactoryName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            await TestSetUp();
            string dataFactoryName = Recording.GenerateAssetName("dataFactory-");
            await CreateDataFactory(_resourceGroup, dataFactoryName);
            var dataFactory = await _resourceGroup.GetDataFactories().GetAsync(dataFactoryName);
            Assert.IsNotNull(dataFactory);
            Assert.AreEqual(dataFactoryName, dataFactory.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            await TestSetUp();
            string dataFactoryName = Recording.GenerateAssetName("dataFactory-");
            await CreateDataFactory(_resourceGroup, dataFactoryName);
            var list = await _resourceGroup.GetDataFactories().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            await TestSetUp();
            string dataFactoryName = Recording.GenerateAssetName("dataFactory-");
            var dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            bool flag = await _resourceGroup.GetDataFactories().ExistsAsync(dataFactoryName);
            Assert.IsTrue(flag);
            await dataFactory.DeleteAsync(WaitUntil.Completed);
            flag = await _resourceGroup.GetDataFactories().ExistsAsync(dataFactoryName);
            Assert.IsFalse(flag);
        }
    }
}
