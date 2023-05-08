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
    public class GalleryOperationsTests : DevCenterManagementTestBase
    {
        public GalleryOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        [PlaybackOnly("")]
        public async Task GalleryResourceFull()
        {
            ResourceIdentifier devCenterId = new ResourceIdentifier(TestEnvironment.DefaultDevCenterId);

            var devCenterResponse = await Client.GetDevCenterResource(devCenterId).GetAsync();
            var devCenterResource = devCenterResponse.Value;

            GalleryCollection resourceCollection = devCenterResource.GetGalleries();

            string resourceName = "sdktestgallery";

            // Create a DevBox Definition resource

            var galleryData = new GalleryData()
            {
                GalleryResourceId = TestEnvironment.DefaultComputeGalleryId,
            };
            GalleryResource createdResource
                = (await resourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, galleryData)).Value;

            Assert.NotNull(createdResource);
            Assert.NotNull(createdResource.Data);

            // List
            List<GalleryResource> resources = await resourceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(resources.Any(r => r.Id == createdResource.Id));

            // Get
            Response<GalleryResource> retrievedResource = await resourceCollection.GetAsync(resourceName);
            Assert.NotNull(retrievedResource.Value);
            Assert.NotNull(retrievedResource.Value.Data);

            // Delete
            ArmOperation deleteOp = await retrievedResource.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}
