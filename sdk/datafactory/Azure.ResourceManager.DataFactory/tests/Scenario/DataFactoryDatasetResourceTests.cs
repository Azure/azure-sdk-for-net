﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.DataFactory.Tests;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using NUnit.Framework;

namespace Azure.ResourceManager.IotHub.Tests.Scenario
{
    internal class DataFactoryDatasetResourceTests : DataFactoryManagementTestBase
    {
        private string _accessKey;
        private string _linkedServiceName;
        private ResourceGroupResource _resourceGroup;
        private DataFactoryResource _dataFactory;
        public DataFactoryDatasetResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            // Create a resource group
            string dataFactoryName = Recording.GenerateAssetName("DataFactory-");
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            _resourceGroup = await CreateResourceGroup(subscription, "DataFactory-RG-", AzureLocation.WestUS2);
            // Create a DataFactory and a LinkedService
            _dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _accessKey = await GetStorageAccountAccessKey(_resourceGroup);
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(_dataFactory, _linkedServiceName, _accessKey);
        }

        [TearDown]
        public async Task TestTearDown()
        {
            // Delete Storage Account ASAP.
            var list = await _resourceGroup.GetStorageAccounts().GetAllAsync().ToEnumerableAsync();
            foreach (var storageAccount in list)
            {
                await storageAccount.DeleteAsync(WaitUntil.Completed);
            }
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
            bool flag = await _dataFactory.GetDatasetResources().ExistsAsync(datasetName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
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
        public async Task GetAll()
        {
            string datasetName = Recording.GenerateAssetName("dataset");
            await CreateDefaultDataset(datasetName);
            var list = await _dataFactory.GetDatasetResources().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(1,list.Count);
        }

        [Test]
        [RecordedTest]
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
