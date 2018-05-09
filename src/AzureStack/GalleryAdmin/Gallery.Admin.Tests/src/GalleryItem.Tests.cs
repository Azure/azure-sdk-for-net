// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Gallery.Admin;
using Microsoft.AzureStack.Management.Gallery.Admin.Models;
using System;
using Xunit;
using System.Linq;

namespace Gallery.Tests
{
    public class OperationTests : GalleryTestBase
    {
        

        [Fact]
        public void TestListAllGalleryItems() {
            RunTest((client) => {
                var galleryItems = client.GalleryItems.List();
                Assert.NotNull(galleryItems);
            });
        }

        [Fact]
        public void TestGetGalleryItem()
        {
            RunTest((client) => {
                var galleryItems = client.GalleryItems.List();
                Assert.NotNull(galleryItems);
                foreach (var galleryItem in galleryItems)
                {
                    var retrievedGalleryItem = client.GalleryItems.Get(galleryItem.Name);
                    Assert.Equal(galleryItem.Name, retrievedGalleryItem.Name);
                }
            });
        }

        [Fact]
        public void TestCreateAndDeleteGalleryItem()
        {
            RunTest((client) => {
                var galleryItemUri = "https://github.com/Azure/AzureStack-Tools/raw/master/ComputeAdmin/microsoft.vmss.1.3.6.azpkg";
                var name = "microsoft.vmss.1.3.6";

                // Delete if it already exists
                client.GalleryItems.Delete(name);

                // Create a gallery item
                var galleryItem = client.GalleryItems.Create(galleryItemUri);
                Assert.NotNull(galleryItem);

                // Delete the gallery item
                client.GalleryItems.Delete(name);
            });
        }
    }
}
