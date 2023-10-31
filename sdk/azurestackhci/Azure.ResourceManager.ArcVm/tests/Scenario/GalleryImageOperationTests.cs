// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ArcVm.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ArcVm.Tests
{
    public class GalleryImageOperationTests: ArcVmManagementTestBase
    {
        public GalleryImageOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        // Gallery image download is very expensive and can take time depending on network speed.
        // So before running live / record please make sure the test region have the capacity for create a new one.
        //[PlaybackOnly("Live test for gallery image is not necessary")]
        [RecordedTest]
        public async Task GetDelete()
        {
            var galleryImage = await CreateGalleryImageAsync();

            GalleryImageResource galleryImageFromGet = await galleryImage.GetAsync();
            if (await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(galleryImageFromGet), TimeSpan.FromSeconds(100)))
            {
                Assert.AreEqual(galleryImageFromGet.Data.Name, galleryImage.Data.Name);
                Assert.AreEqual(galleryImageFromGet.Data.OSType, OperatingSystemType.Linux);
            }
            Assert.AreEqual(galleryImageFromGet.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);

            await galleryImageFromGet.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase(null)]
        [TestCase(true)]
        // Gallery image download is very expensive and can take time depending on network speed.
        // So before running live / record please make sure the test region have the capacity for create a new one.
        //[PlaybackOnly("Live test for gallery image is not necessary")]
        [RecordedTest]
        public async Task SetTags(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            var galleryImage = await CreateGalleryImageAsync();

            var tags = new Dictionary<string, string>()
            {
                { "key", "value" }
            };
            GalleryImageResource updatedGalleryImage = await galleryImage.SetTagsAsync(tags);
            if (await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(updatedGalleryImage), TimeSpan.FromSeconds(100)))
            {
                Assert.AreEqual(tags, updatedGalleryImage.Data.Tags);
            }
            Assert.AreEqual(updatedGalleryImage.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);
        }
    }
}
