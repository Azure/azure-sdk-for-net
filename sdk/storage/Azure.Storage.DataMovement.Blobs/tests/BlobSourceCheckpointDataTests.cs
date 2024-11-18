// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
extern alias BaseBlobs;

using System.IO;
using BaseBlobs::Azure.Storage.Blobs.Models;
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

            Assert.AreEqual(DataMovementBlobConstants.SourceCheckpointData.SchemaVersion, data.Version);
        }

        [Test]
        public void Serialize()
        {
            BlobSourceCheckpointData data = new();

            byte[] expected;
            using (MemoryStream stream = new MemoryStream(DataMovementBlobConstants.SourceCheckpointData.DataSize))
            {
                BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(DataMovementBlobConstants.SourceCheckpointData.SchemaVersion);
                expected = stream.ToArray();
            }

            byte[] actual;
            using (MemoryStream stream = new MemoryStream(DataMovementBlobConstants.SourceCheckpointData.DataSize))
            {
                data.Serialize(stream);
                actual = stream.ToArray();
            }

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(BlobType.Block)]
        [TestCase(BlobType.Page)]
        [TestCase(BlobType.Append)]
        public void Deserialize(BlobType blobType)
        {
            BlobSourceCheckpointData data = new();

            using (Stream stream = new MemoryStream(DataMovementBlobConstants.SourceCheckpointData.DataSize))
            {
                data.Serialize(stream);
                stream.Position = 0;
                BlobSourceCheckpointData deserialized = BlobSourceCheckpointData.Deserialize(stream);

                Assert.AreEqual(DataMovementBlobConstants.SourceCheckpointData.SchemaVersion, deserialized.Version);
            }
        }
    }
}
