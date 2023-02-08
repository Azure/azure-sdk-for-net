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
        private MediaServicesAccountResource _mediaService;
        private MediaLiveEventResource _liveEvent;

        private MediaLiveOutputCollection liveOutputCollection => _liveEvent.GetMediaLiveOutputs();

        public LiveOutputTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var mediaServiceName = Recording.GenerateAssetName("dotnetsdkmediatests");
            var liveEventName = Recording.GenerateAssetName("liveEvent");
            _mediaService = await CreateMediaService(ResourceGroup, mediaServiceName);
            _liveEvent = await CreateLiveEvent(_mediaService, liveEventName);
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
