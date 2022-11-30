// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Media.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Media.Tests
{
    public class LiveOutputTests : MediaManagementTestBase
    {
        private ResourceIdentifier _mediaServiceIdentifier;
        private MediaServicesAccountResource _mediaService;
        private ResourceIdentifier _liveEventIdentifier;
        private MediaLiveEventResource _liveEvent;

        private MediaLiveOutputCollection liveOutputCollection => _liveEvent.GetMediaLiveOutputs();

        public LiveOutputTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgName = SessionRecording.GenerateAssetName(ResourceGroupNamePrefix);
            var storageAccountName = SessionRecording.GenerateAssetName(StorageAccountNamePrefix);
            var mediaServiceName = SessionRecording.GenerateAssetName("dotnetsdkmediatest");
            var liveEventName = SessionRecording.GenerateAssetName("liveEvent");
            if (Mode == RecordedTestMode.Playback)
            {
                _mediaServiceIdentifier = MediaServicesAccountResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), rgName, mediaServiceName);
                _liveEventIdentifier = MediaLiveEventResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), rgName, mediaServiceName, liveEventName);
            }
            else
            {
                using (SessionRecording.DisableRecording())
                {
                    var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, rgName, new ResourceGroupData(AzureLocation.WestUS2));
                    var storage = await CreateStorageAccount(rgLro.Value, storageAccountName);
                    var mediaService = await CreateMediaService(rgLro.Value, mediaServiceName, storage.Id);
                    var liveEvent = await CreateLiveEvent(mediaService, liveEventName);
                    _mediaServiceIdentifier = mediaService.Id;
                    _liveEventIdentifier = liveEvent.Id;
                }
            }
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _mediaService = await Client.GetMediaServicesAccountResource(_mediaServiceIdentifier).GetAsync();
            _liveEvent = await Client.GetMediaLiveEventResource(_liveEventIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            var list = await liveOutputCollection.GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        private async Task<MediaLiveOutputResource> CreateLiveOutPut(string liveOutPutName)
        {
            var asset = await _mediaService.GetMediaAssets().CreateOrUpdateAsync(WaitUntil.Completed, "empty-asset-input", new MediaAssetData());
            MediaLiveOutputData data = new MediaLiveOutputData()
            {
                AssetName = asset.Value.Data.Name,
                ArchiveWindowLength = new TimeSpan(0, 5, 0),
                Hls = new Hls()
                {
                    FragmentsPerTsSegment = 5
                },
            };
            var liveOutPut = await liveOutputCollection.CreateOrUpdateAsync(WaitUntil.Completed, liveOutPutName, data);
            return liveOutPut.Value;
        }

        [Test]
        [RecordedTest]
        public async Task LiveOutputBasicTests()
        {
            // Create
            string liveOutPutName = Recording.GenerateAssetName("liveoutput");
            var liveoutput = await CreateLiveOutPut(liveOutPutName);
            Assert.IsNotNull(liveoutput);
            Assert.AreEqual(liveOutPutName, liveoutput.Data.Name);
            // Check exists
            bool flag = await liveOutputCollection.ExistsAsync(liveOutPutName);
            Assert.IsTrue(flag);
            // Get
            var result = await liveOutputCollection.GetAsync(liveOutPutName);
            Assert.IsNotNull(result);
            Assert.AreEqual(liveOutPutName, result.Value.Data.Name);
            // Get all
            var list = await liveOutputCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            // Delete
            await liveoutput.DeleteAsync(WaitUntil.Completed);
            flag = await liveOutputCollection.ExistsAsync(liveOutPutName);
            Assert.IsFalse(flag);
        }
    }
}
