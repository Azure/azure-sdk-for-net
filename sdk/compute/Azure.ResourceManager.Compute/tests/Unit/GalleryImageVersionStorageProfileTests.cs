// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Compute.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.Unit
{
    public class GalleryImageVersionStorageProfileTests
    {
        [TestCase]
        public void ValidateSetOldSourceGetNewGallerySource()
        {
            var galleryStorageProfile = new GalleryImageVersionStorageProfile();
            galleryStorageProfile.Source = new GalleryArtifactVersionSource();
            var fullSource = galleryStorageProfile.GallerySource;

            Assert.IsNull(fullSource);
        }
    }
}
