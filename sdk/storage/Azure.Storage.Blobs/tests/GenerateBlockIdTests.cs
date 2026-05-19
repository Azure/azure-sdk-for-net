// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using Azure.Storage.Blobs;

namespace Azure.Storage.Blobs.Tests
{
    [TestFixture]
    public class GenerateBlockIdTests
    {
        [Test]
        public void GenerateBlockId_ReturnsValidBase64()
        {
            string blockId = BlobExtensions.GenerateBlockId();
            byte[] decoded = Convert.FromBase64String(blockId);
            Assert.That(decoded, Has.Length.EqualTo(48));
        }

        [Test]
        public void GenerateBlockId_IsUnique()
        {
            string blockId1 = BlobExtensions.GenerateBlockId();
            string blockId2 = BlobExtensions.GenerateBlockId();
            Assert.That(blockId1, Is.Not.EqualTo(blockId2));
        }

        [Test]
        public void GenerateBlockId_UrlEncodedSizeIsWithinLimit()
        {
            string blockId = BlobExtensions.GenerateBlockId();
            string urlEncoded = Uri.EscapeDataString(blockId);
            Assert.That(
                System.Text.Encoding.UTF8.GetByteCount(urlEncoded),
                Is.LessThanOrEqualTo(64));
        }
    }
}
