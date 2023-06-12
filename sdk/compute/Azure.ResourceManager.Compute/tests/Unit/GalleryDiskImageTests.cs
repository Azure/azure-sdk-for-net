// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Compute.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.Unit
{
    public class GalleryDiskImageTests
    {
        [TestCase]
        public void ValidateSetOldSourceGetNewGallerySource()
        {
            var galleryDiskImage = new GalleryDiskImage();
            galleryDiskImage.Source = new GalleryArtifactVersionSource();
            var galleryDiskImageSource = galleryDiskImage.GallerySource;

            Assert.IsNull(galleryDiskImageSource);
        }
    }
}
