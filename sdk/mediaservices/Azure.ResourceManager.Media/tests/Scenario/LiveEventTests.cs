// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Media.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Media.Tests
{
    public class LiveEventTests : MediaManagementTestBase
    {
        private MediaServicesAccountResource _mediaService;

        private LiveEventCollection liveEventCollection => _mediaService.GetLiveEvents();

        public LiveEventTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var resourceGroup = await CreateResourceGroup(AzureLocation.WestUS2);
            var storage = await CreateStorageAccount(resourceGroup, Recording.GenerateAssetName(StorageAccountNamePrefix));
            _mediaService = await CreateMediaService(resourceGroup, Recording.GenerateAssetName("mediaforle"), storage.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LiveEventBasicTests()
        {
            // Create
            string liveEventName = Recording.GenerateAssetName("liveEventName");
            var liveEvent = await CreateLiveEvent(_mediaService, liveEventName);
            Assert.IsNotNull(liveEvent);
            Assert.AreEqual(liveEventName, liveEvent.Data.Name);
            // Check exists
            bool flag = await liveEventCollection.ExistsAsync(liveEventName);
            Assert.IsTrue(flag);
            // Get
            var result = await liveEventCollection.GetAsync(liveEventName);
            Assert.IsNotNull(liveEvent);
            Assert.AreEqual(liveEventName, result.Value.Data.Name);
            // List
            var list = await liveEventCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            // Delete
            await liveEvent.DeleteAsync(WaitUntil.Completed);
            flag = await liveEventCollection.ExistsAsync(liveEventName);
            Assert.IsFalse(flag);
        }
    }
}
