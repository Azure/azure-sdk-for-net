// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
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
        private ResourceIdentifier _mediaServiceIdentifier;
        private MediaServicesAccountResource _mediaService;

        private MediaLiveEventCollection liveEventCollection => _mediaService.GetMediaLiveEvents();

        public LiveEventTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgName = SessionRecording.GenerateAssetName(ResourceGroupNamePrefix);
            var storageAccountName = SessionRecording.GenerateAssetName(StorageAccountNamePrefix);
            var mediaServiceName = SessionRecording.GenerateAssetName("dotnetsdkmediatest");
            if (Mode == RecordedTestMode.Playback)
            {
                _mediaServiceIdentifier = MediaServicesAccountResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), rgName, mediaServiceName);
            }
            else
            {
                using (SessionRecording.DisableRecording())
                {
                    var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, rgName, new ResourceGroupData(AzureLocation.WestUS2));
                    var storage = await CreateStorageAccount(rgLro.Value, storageAccountName);
                    var mediaService = await CreateMediaService(rgLro.Value, mediaServiceName, storage.Id);
                    _mediaServiceIdentifier = mediaService.Id;
                }
            }
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _mediaService = await Client.GetMediaServicesAccountResource(_mediaServiceIdentifier).GetAsync();
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
