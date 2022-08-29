// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Media.Tests
{
    public class MediaServicesTests : MediaManagementTestBase
    {
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceIdentifier _storageAccountIdentifier;
        private ResourceGroupResource _resourceGroup;

        private MediaServicesAccountCollection mediaServiceCollection => _resourceGroup.GetMediaServicesAccounts();

        public MediaServicesTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.WestUS2));
            var storage = await CreateStorageAccount(rgLro.Value, SessionRecording.GenerateAssetName(StorageAccountNamePrefix));
            _resourceGroupIdentifier = rgLro.Value.Data.Id;
            _storageAccountIdentifier = storage.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await Client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string mediaServiceName = SessionRecording.GenerateAssetName("mediaservice");
            var mediaService = await CreateMediaService(_resourceGroup, mediaServiceName, _storageAccountIdentifier);
            Assert.IsNotNull(mediaService);
            Assert.AreEqual(mediaServiceName, mediaService.Data.Name);
            Assert.AreEqual(_storageAccountIdentifier, mediaService.Data.StorageAccounts.FirstOrDefault().Id);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string mediaServiceName = SessionRecording.GenerateAssetName("mediaservice");
            var mediaService = await CreateMediaService(_resourceGroup, mediaServiceName, _storageAccountIdentifier);
            bool flag = await mediaServiceCollection.ExistsAsync(mediaServiceName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string mediaServiceName = SessionRecording.GenerateAssetName("mediaservice");
            var mediaService = await CreateMediaService(_resourceGroup, mediaServiceName, _storageAccountIdentifier);
            Assert.IsNotNull(mediaService);
            Assert.AreEqual(mediaServiceName, mediaService.Data.Name);
            Assert.AreEqual(_storageAccountIdentifier, mediaService.Data.StorageAccounts.FirstOrDefault().Id);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string mediaServiceName = SessionRecording.GenerateAssetName("mediaservice");
            var mediaService = await CreateMediaService(_resourceGroup, mediaServiceName, _storageAccountIdentifier);
            var list = await mediaServiceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string mediaServiceName = SessionRecording.GenerateAssetName("mediaservice");
            var mediaService = await CreateMediaService(_resourceGroup, mediaServiceName, _storageAccountIdentifier);
            bool flag = await mediaServiceCollection.ExistsAsync(mediaServiceName);
            Assert.IsTrue(flag);

            await mediaService.DeleteAsync(WaitUntil.Completed);
            flag = await mediaServiceCollection.ExistsAsync(mediaServiceName);
            Assert.IsFalse(flag);
        }
    }
}
