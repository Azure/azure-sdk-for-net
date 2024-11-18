// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Storage.Blobs;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Tests
{
    public class BlobPathTests
    {
        [Test]
        [TestCase("blobName")]
        [TestCase("blob_Name")]
        [TestCase("blob_Nam/e324324.txt")]
        [TestCase("!*'();[]:@&%=+$,/#äÄöÖüÜß")]
        public void BlobPathTryParseAbsUrl(string blobName)
        {
            string uriStr = "https://account.blob.core.windows.net/container/" + blobName;
            if (BlobPath.TryParseAbsUrl(uriStr, out BlobPath path))
            {
                Assert.AreEqual(blobName, path.BlobName);
            }
            else
            {
                Assert.Fail("Failed to parse blob name");
            }
        }
    }
}
