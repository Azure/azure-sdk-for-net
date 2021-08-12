// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests.Tests.Helpers
{
    public class BlobHelper
    {
        public static void AssertBlob(BlobContainer blobContainer1,BlobContainer blobContainer2)
        {
            Assert.AreEqual(blobContainer1.Id.Name, blobContainer2.Id.Name);
            Assert.AreEqual(blobContainer1.Id.Location, blobContainer2.Id.Location);
        }
    }
}
