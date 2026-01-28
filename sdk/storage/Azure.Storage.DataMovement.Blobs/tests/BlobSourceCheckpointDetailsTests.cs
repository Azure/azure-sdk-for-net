// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;

using System;
using System.IO;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    public class BlobSourceCheckpointDetailsTests
    {
        [Test]
        public void Ctor()
        {
            BlobSourceCheckpointDetails data = new();
        }

        [Test]
        public void Serialize()
        {
            byte[] expected = Array.Empty<byte>();

            BlobSourceCheckpointDetails data = new();

            byte[] actual;
            using (MemoryStream stream = new())
            {
                data.Serialize(stream);
                actual = stream.ToArray();
            }

            Assert.That(actual, Is.EqualTo(expected).AsCollection);
        }

        [Test]
        public void Deserialize()
        {
            BlobSourceCheckpointDetails deserialized;

            using (MemoryStream stream = new())
            {
                deserialized = BlobSourceCheckpointDetails.Deserialize(Stream.Null);
            }
        }
    }
}
