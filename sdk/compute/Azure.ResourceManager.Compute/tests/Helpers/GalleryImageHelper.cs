// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.Helpers
{
    public static class GalleryImageHelper
    {
        public static void AssertGalleryImage(GalleryImageData image1, GalleryImageData image2)
        {
            Assert.AreEqual(image1.Name, image2.Name);
            Assert.AreEqual(image1.Id, image2.Id);
            Assert.AreEqual(image1.Location, image2.Location);
            Assert.AreEqual(image1.Identifier.Offer, image2.Identifier.Offer);
            Assert.AreEqual(image1.Identifier.Publisher, image2.Identifier.Publisher);
            Assert.AreEqual(image1.Identifier.Sku, image2.Identifier.Sku);
            Assert.AreEqual(image1.OsType, image2.OsType);
            Assert.AreEqual(image1.OsState, image2.OsState);
            Assert.AreEqual(image1.Tags, image2.Tags);
            Assert.AreEqual(image1.Description, image2.Description);
        }

        public static GalleryImageData GetBasicGalleryImageData(Location location, OperatingSystemTypes osType, GalleryImageIdentifier identifier, IDictionary<string, string> tags = null)
        {
            var data = new GalleryImageData(location)
            {
                OsType = osType,
                Identifier = identifier
            };
            data.Tags.AddRange(tags);
            return data;
        }

        public static GalleryImageIdentifier GetGalleryImageIdentifier(string publisher, string offer, string sku)
        {
            return new GalleryImageIdentifier(publisher, offer, sku);
        }
    }
}
