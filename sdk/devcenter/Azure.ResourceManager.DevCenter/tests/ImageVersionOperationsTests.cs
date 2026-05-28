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
    public class ImageVersionOperationsTests : DevCenterManagementTestBase
    {
        public ImageVersionOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        [PlaybackOnly("")]
        public async Task ListAndGetImagesVersions()
        {
            ResourceIdentifier devCenterId = new ResourceIdentifier(TestEnvironment.DefaultDevCenterId);

            var devCenterResponse = await Client.GetDevCenterResource(devCenterId).GetAsync();
            var devCenterResource = devCenterResponse.Value;

            List<DevCenterImageResource> images = await devCenterResource.GetImagesAsync().ToEnumerableAsync();
            Assert.IsTrue(images.Count > 0);

            // List image versions for one image
            List<ImageVersionResource> imageVersions = await images.First().GetImageVersions().GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(imageVersions.Count > 0);

            // Get one of the image versions
            ImageVersionResource imageVersion = await images.First().GetImageVersionAsync(imageVersions.First().Data.Name);
            Assert.IsNotNull(imageVersion);
        }
    }
}
