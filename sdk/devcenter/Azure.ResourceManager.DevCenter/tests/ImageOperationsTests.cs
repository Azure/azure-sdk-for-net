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
            : base(isAsync)
        {
        }

        [Test]
        [PlaybackOnly("")]
        public async Task ListImagesByDevCenter()
        {
            ResourceIdentifier devCenterId = new ResourceIdentifier(TestEnvironment.DefaultDevCenterId);

            var devCenterResponse = await Client.GetDevCenterResource(devCenterId).GetAsync();
            var devCenterResource = devCenterResponse.Value;

            List<DevCenterImageResource> images = await devCenterResource.GetImagesAsync().ToEnumerableAsync();
            Assert.IsTrue(images.Count > 0);
        }

        [Test]
        [PlaybackOnly("")]
        public async Task ListAndGetImagesByGallery()
        {
            ResourceIdentifier devCenterId = new ResourceIdentifier(TestEnvironment.DefaultDevCenterId);

            var devCenterResponse = await Client.GetDevCenterResource(devCenterId).GetAsync();
            var devCenterResource = devCenterResponse.Value;

            var galleryResource = (await devCenterResource.GetDevCenterGalleryAsync("default")).Value;

            List<DevCenterImageResource> images = await galleryResource.GetDevCenterImages().GetAllAsync().ToEnumerableAsync();

            Assert.IsTrue(images.Count > 0);

            // Get one of the images
            var image = (await galleryResource.GetDevCenterImageAsync(images.First().Data.Name)).Value;
            Assert.IsNotNull(image);
        }
    }
}
