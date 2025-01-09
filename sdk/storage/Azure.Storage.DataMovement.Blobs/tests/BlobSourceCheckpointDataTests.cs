// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;

using System;
using System.IO;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    public class BlobSourceCheckpointDataTests
    {
        [Test]
        public void Ctor()
        {
            BlobSourceCheckpointData data = new();
        }

        [Test]
        public void Serialize()
        {
            byte[] expected = Array.Empty<byte>();

            BlobSourceCheckpointData data = new();

            byte[] actual;
            using (MemoryStream stream = new())
            {
                data.Serialize(stream);
                actual = stream.ToArray();
            }

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Deserialize()
        {
            BlobSourceCheckpointData deserialized;

            using (MemoryStream stream = new())
            {
                deserialized = BlobSourceCheckpointData.Deserialize(Stream.Null);
            }
        }
    }
}
