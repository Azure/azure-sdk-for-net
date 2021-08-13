// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.Helpers
{
    public static class GalleryImageVersionHelper
    {
        public static void AssertGalleryImageVersion(GalleryImageVersionData imageversion1, GalleryImageVersionData imageversion2)
        {
            Assert.AreEqual(imageversion1.Name, imageversion2.Name);
            Assert.AreEqual(imageversion1.Id, imageversion2.Id);
            Assert.AreEqual(imageversion1.Location, imageversion2.Location);
            //Assert.AreEqual(image1.Identifier.Offer, image2.Identifier.Offer);
            //Assert.AreEqual(image1.Identifier.Publisher, image2.Identifier.Publisher);
            //Assert.AreEqual(image1.Identifier.Sku, image2.Identifier.Sku);
            //Assert.AreEqual(image1.OsType, image2.OsType);
            //Assert.AreEqual(image1.OsState, image2.OsState);
            Assert.AreEqual(imageversion1.Tags, imageversion2.Tags);
            //Assert.AreEqual(image1.Description, image2.Description);
        }
    }
}
