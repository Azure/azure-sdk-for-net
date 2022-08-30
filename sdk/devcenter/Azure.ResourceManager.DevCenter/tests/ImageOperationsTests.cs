// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DevCenter.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DevCenter.Tests
{
    public class ImageOperationsTests : DevCenterManagementTestBase
    {
        public ImageOperationsTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        [Test]
        [PlaybackOnly("TODO")]
        public async Task ListImagesByDevCenter()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            ArmOperation<ResourceGroupResource> rgResponse = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.ResourceGroup, new ResourceGroupData(TestEnvironment.Location)).ConfigureAwait(false);
            ResourceGroupResource rg = rgResponse.Value;

            ResourceIdentifier devCenterId = new ResourceIdentifier(TestEnvironment.DefaultDevCenterId);

            var devCenterResponse = await Client.GetDevCenterResource(devCenterId).GetAsync();
            var devCenterResource = devCenterResponse.Value;

            List<ImageResource> images = await devCenterResource.GetImagesAsync().ToEnumerableAsync();
            Assert.IsTrue(images.Count > 0);
        }

        [Test]
        [PlaybackOnly("TODO")]
        public async Task ListAndGetImagesByGallery()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            ArmOperation<ResourceGroupResource> rgResponse = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.ResourceGroup, new ResourceGroupData(TestEnvironment.Location)).ConfigureAwait(false);
            ResourceGroupResource rg = rgResponse.Value;

            ResourceIdentifier devCenterId = new ResourceIdentifier(TestEnvironment.DefaultDevCenterId);

            var devCenterResponse = await Client.GetDevCenterResource(devCenterId).GetAsync();
            var devCenterResource = devCenterResponse.Value;

            var galleryResource = (await devCenterResource.GetGalleryAsync("default")).Value;

            List<ImageResource> images = await galleryResource.GetImages().GetAllAsync().ToEnumerableAsync();

            Assert.IsTrue(images.Count > 0);

            // Get one of the images
            var image = (await galleryResource.GetImageAsync(images.First().Data.Name)).Value;
            Assert.IsNotNull(image);
        }
    }
}
