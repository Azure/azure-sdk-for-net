// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.DataFactory.Tests;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.IotHub.Tests.Scenario
{
    internal class DataFactoryDatasetResourceTests : DataFactoryManagementTestBase
    {
        private const string _accessKey = "DefaultEndpointsProtocol=https;AccountName=220722datafactory;EndpointSuffix=core.windows.net;AccountKey=th4S/DG4Cz8uq1vbv8a8ooRZqKk+TLmsgSKb004bgen/4epF+E8wYhzFp0pv3PbRF5dy8SDgwHdI+AStU7Ejbw==;";
        private DataFactoryResource _dataFactory;
        private string _linkedServiceName;
        public DataFactoryDatasetResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            // Create a resource group
            string dataFactoryName = Recording.GenerateAssetName("DataFactory-");
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            var resourceGroup = await CreateResourceGroup(subscription, "DataFactory-RG-", AzureLocation.WestUS2);
            // Create a DataFactory and a LinkedService
            _dataFactory = await CreateDataFactory(resourceGroup, dataFactoryName);
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(_dataFactory, _linkedServiceName, _accessKey);
        }

        private async Task<DatasetResource> CreateDefaultDataset(string datasetName)
        {
            LinkedServiceReference linkedServiceReference = new LinkedServiceReference(LinkedServiceReferenceType.LinkedServiceReference, _linkedServiceName);
            Dataset properties = new Dataset(linkedServiceReference);
            DatasetResourceData data = new DatasetResourceData(properties);
            var dataset = await _dataFactory.GetDatasetResources().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return dataset.Value;
        }

        [Test]
        [RecordedTest]
        [PlaybackOnly("Add ref Storage mgmt package. Temporarily use a known AccessKey instead")]
        public async Task CreateOrUpdate()
        {
            string datasetName = Recording.GenerateAssetName("dataset");
            var dataset = await CreateDefaultDataset(datasetName);
            Assert.IsNotNull(dataset);
            Assert.AreEqual(datasetName, dataset.Data.Name);
        }

        [Test]
        [RecordedTest]
        [PlaybackOnly("Add ref Storage mgmt package. Temporarily use a known AccessKey instead")]
        public async Task Exist()
        {
            string datasetName = Recording.GenerateAssetName("dataset");
            await CreateDefaultDataset(datasetName);
            bool flag = await _dataFactory.GetDatasetResources().ExistsAsync(datasetName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        [PlaybackOnly("Add ref Storage mgmt package. Temporarily use a known AccessKey instead")]
        public async Task Get()
        {
            string datasetName = Recording.GenerateAssetName("dataset");
            await CreateDefaultDataset(datasetName);
            var dataset = await _dataFactory.GetDatasetResources().GetAsync(datasetName);
            Assert.IsNotNull(dataset);
            Assert.AreEqual(datasetName, dataset.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        [PlaybackOnly("Add ref Storage mgmt package. Temporarily use a known AccessKey instead")]
        public async Task GetAll()
        {
            string datasetName = Recording.GenerateAssetName("dataset");
            await CreateDefaultDataset(datasetName);
            var list = await _dataFactory.GetDatasetResources().GetAllAsync().ToEnumerableAsync();
            System.Console.WriteLine(list);
        }

        [Test]
        [RecordedTest]
        [PlaybackOnly("Add ref Storage mgmt package. Temporarily use a known AccessKey instead")]
        public async Task Delete()
        {
            string datasetName = Recording.GenerateAssetName("dataset");
            var dataset = await CreateDefaultDataset(datasetName);
            bool flag = await _dataFactory.GetDatasetResources().ExistsAsync(datasetName);
            Assert.IsTrue(flag);

            await dataset.DeleteAsync(WaitUntil.Completed);
            flag = await _dataFactory.GetDatasetResources().ExistsAsync(datasetName);
            Assert.IsFalse(flag);
        }
    }
}
