// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    [TestFixture]
    public class GenerateBlockIdTests
    {
        [Test]
        public void GenerateBlockId_ReturnsValidBase64()
        {
            string blockId = BlobHelpers.GenerateBlockId();
            byte[] decoded = Convert.FromBase64String(blockId);
            Assert.That(decoded, Has.Length.EqualTo(48));
        }

        [Test]
        public void GenerateBlockId_IsUnique()
        {
            string blockId1 = BlobHelpers.GenerateBlockId();
            string blockId2 = BlobHelpers.GenerateBlockId();
            Assert.That(blockId1, Is.Not.EqualTo(blockId2));
        }

        [Test]
        public void GenerateBlockId_LengthIsWithinLimit()
        {
            string blockId = BlobHelpers.GenerateBlockId();
            // Azure Storage requires block ID Base64 string to be <= 64 characters
            Assert.That(blockId.Length, Is.LessThanOrEqualTo(64));
        }
    }
}
