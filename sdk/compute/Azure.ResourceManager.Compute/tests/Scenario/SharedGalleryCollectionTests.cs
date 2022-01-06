// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class SharedGalleryCollectionTests : ComputeTestBase
    {
        public SharedGalleryCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private SharedGalleryCollection GetSharedGalleryCollection(string location)
        {
            return DefaultSubscription.GetSharedGalleries(location);
        }

        [TestCase]
        [RecordedTest]
        public void Get()
        {
            var collection = GetSharedGalleryCollection(DefaultLocation);
            var name = Recording.GenerateAssetName("sharedImage_");
            // shared image of this name does not exist
            Assert.ThrowsAsync<RequestFailedException>(async () => await collection.GetAsync(name));
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            var collection = GetSharedGalleryCollection(DefaultLocation);
            var name = Recording.GenerateAssetName("sharedImage_");
            // shared image of this name does not exist
            Assert.IsFalse(await collection.ExistsAsync(name));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var collection = GetSharedGalleryCollection(DefaultLocation);
            int count = 0;

            await foreach (var _ in collection.GetAllAsync())
            {
                count++;
            }

            Assert.GreaterOrEqual(count, 0);
        }
    }
}
