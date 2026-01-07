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
        private MediaServicesAccountResource _mediaService;

        private MediaLiveEventCollection liveEventCollection => _mediaService.GetMediaLiveEvents();

        public LiveEventTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var mediaServiceName = Recording.GenerateAssetName(MediaServiceAccountPrefix);
            _mediaService = await CreateMediaService(ResourceGroup, mediaServiceName);
        }

        [Test]
        [RecordedTest]
        public async Task LiveEventBasicTests()
        {
            // Create
            string liveEventName = Recording.GenerateAssetName("liveEventName");
            var liveEvent = await CreateLiveEvent(_mediaService, liveEventName);
            Assert.That(liveEvent, Is.Not.Null);
            Assert.That(liveEvent.Data.Name, Is.EqualTo(liveEventName));
            // Check exists
            bool flag = await liveEventCollection.ExistsAsync(liveEventName);
            Assert.That(flag, Is.True);
            // Get
            var result = await liveEventCollection.GetAsync(liveEventName);
            Assert.That(liveEvent, Is.Not.Null);
            Assert.That(result.Value.Data.Name, Is.EqualTo(liveEventName));
            // List
            var list = await liveEventCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            // Delete
            await liveEvent.DeleteAsync(WaitUntil.Completed);
            flag = await liveEventCollection.ExistsAsync(liveEventName);
            Assert.That(flag, Is.False);
        }
    }
}
