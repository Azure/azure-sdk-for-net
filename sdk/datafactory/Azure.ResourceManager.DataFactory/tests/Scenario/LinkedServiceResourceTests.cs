// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using NUnit.Framework;

namespace Azure.ResourceManager.DataFactory.Tests.Scenario
{
    internal class LinkedServiceResourceTests : DataFactoryManagementTestBase
    {
        private string _accessKey;
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceGroupResource _resourceGroup;
        private DataFactoryResource _dataFactory;
        public LinkedServiceResourceTests(bool isAsync) : base(isAsync)
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
            string dataFactoryName = Recording.GenerateAssetName("DataFactory-");
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            _dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
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

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");
            var linkedService = await CreateLinkedService(_dataFactory, linkedServiceName, _accessKey);
            Assert.IsNotNull(linkedService);
            Assert.AreEqual(linkedServiceName, linkedService.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(_dataFactory, linkedServiceName, _accessKey);
            bool flag = await _dataFactory.GetFactoryLinkedServices().ExistsAsync(linkedServiceName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(_dataFactory, linkedServiceName, _accessKey);
            var linkedService = await _dataFactory.GetFactoryLinkedServices().GetAsync(linkedServiceName);
            Assert.IsNotNull(linkedService);
            Assert.AreEqual(linkedServiceName, linkedService.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(_dataFactory, linkedServiceName, _accessKey);
            var list = await _dataFactory.GetFactoryLinkedServices().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");
            var linkedService = await CreateLinkedService(_dataFactory, linkedServiceName, _accessKey);
            bool flag = await _dataFactory.GetFactoryLinkedServices().ExistsAsync(linkedServiceName);
            Assert.IsTrue(flag);

            await linkedService.DeleteAsync(WaitUntil.Completed);
            flag = await _dataFactory.GetFactoryLinkedServices().ExistsAsync(linkedServiceName);
            Assert.IsFalse(flag);
        }
    }
}
