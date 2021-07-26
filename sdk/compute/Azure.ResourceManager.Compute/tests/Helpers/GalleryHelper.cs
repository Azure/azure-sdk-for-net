// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.Helpers
{
    public static class GalleryHelper
    {
        public static void AssertGallery(GalleryData gallery1, GalleryData gallery2)
        {
            Assert.AreEqual(gallery1.Id, gallery2.Id);
            Assert.AreEqual(gallery1.Name, gallery2.Name);
            Assert.AreEqual(gallery1.Type, gallery2.Type);
            Assert.AreEqual(gallery1.Location, gallery2.Location);
            Assert.AreEqual(gallery1.Tags, gallery2.Tags);
            Assert.AreEqual(gallery1.Description, gallery2.Description);
            Assert.AreEqual(gallery1.Identifier?.UniqueName, gallery2.Identifier?.UniqueName);
        }

        public static GalleryData GetBasicGalleryData(Location location, string description = null, IDictionary<string, string> tags = null)
        {
            var data = new GalleryData(location)
            {
                Description = description
            };
            data.Tags.AddRange(tags);
            return data;
        }
    }
}
