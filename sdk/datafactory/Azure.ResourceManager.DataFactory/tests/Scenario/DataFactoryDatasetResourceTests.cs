// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Expressions.DataFactory;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using NUnit.Framework;

namespace Azure.ResourceManager.DataFactory.Tests.Scenario
{
    internal class DataFactoryDatasetResourceTests : DataFactoryManagementTestBase
    {
        private string _accessKey;
        private string _linkedServiceName;
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceGroupResource _resourceGroup;
        private DataFactoryResource _dataFactory;
        public DataFactoryDatasetResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgName = SessionRecording.GenerateAssetName("DataFactory-RG-");
            var storageAccountName = SessionRecording.GenerateAssetName("datafactory");
            if (Mode == RecordedTestMode.Playback)
            {
                _resourceGroupIdentifier = ResourceGroupResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), rgName);
                _accessKey = "Sanitized";
            }
            else
            {
                using (SessionRecording.DisableRecording())
                {
                    var subscription = await GlobalClient.GetDefaultSubscriptionAsync();
                    var rgLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
                    _resourceGroupIdentifier = rgLro.Value.Data.Id;
                    _accessKey = await GetStorageAccountAccessKey(rgLro.Value, storageAccountName);
                }
            }
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName("DataFactory-");
            _dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(_dataFactory, _linkedServiceName, _accessKey);
        }

        [OneTimeTearDown]
        public async Task GlobalTearDown()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return;
            }
            try
            {
                using (Recording.DisableRecording())
                {
                    await foreach (var storageAccount in _resourceGroup.GetStorageAccounts().GetAllAsync())
                    {
                        await storageAccount.DeleteAsync(WaitUntil.Completed);
                    }
                }
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultDataset(string datasetName)
        {
            DataFactoryLinkedServiceReference linkedServiceReference = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, _linkedServiceName);
            DataFactoryDatasetProperties properties = new DataFactoryDatasetProperties(linkedServiceReference);
            DataFactoryDatasetData data = new DataFactoryDatasetData(properties);
            var dataset = await _dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return dataset.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string datasetName = Recording.GenerateAssetName("dataset");
            var dataset = await CreateDefaultDataset(datasetName);
            Assert.IsNotNull(dataset);
            Assert.AreEqual(datasetName, dataset.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string datasetName = Recording.GenerateAssetName("dataset");
            await CreateDefaultDataset(datasetName);
            bool flag = await _dataFactory.GetDataFactoryDatasets().ExistsAsync(datasetName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string datasetName = Recording.GenerateAssetName("dataset");
            await CreateDefaultDataset(datasetName);
            var dataset = await _dataFactory.GetDataFactoryDatasets().GetAsync(datasetName);
            Assert.IsNotNull(dataset);
            Assert.AreEqual(datasetName, dataset.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string datasetName = Recording.GenerateAssetName("dataset");
            await CreateDefaultDataset(datasetName);
            var list = await _dataFactory.GetDataFactoryDatasets().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(1,list.Count);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string datasetName = Recording.GenerateAssetName("dataset");
            var dataset = await CreateDefaultDataset(datasetName);
            bool flag = await _dataFactory.GetDataFactoryDatasets().ExistsAsync(datasetName);
            Assert.IsTrue(flag);

            await dataset.DeleteAsync(WaitUntil.Completed);
            flag = await _dataFactory.GetDataFactoryDatasets().ExistsAsync(datasetName);
            Assert.IsFalse(flag);
        }
    }
}
