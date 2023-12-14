// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;

using System.IO;
using Azure.Storage.Blobs.Models;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    public class BlobSourceCheckpointDataTests
    {
        [Test]
        public void Ctor()
        {
            BlobSourceCheckpointData data = new(BlobType.Block);

            Assert.AreEqual(DataMovementBlobConstants.SourceCheckpointData.SchemaVersion, data.Version);
            Assert.AreEqual(BlobType.Block, data.BlobType);
        }

        [Test]
        public void Serialize()
        {
            BlobSourceCheckpointData data = new(BlobType.Block);

            byte[] expected;
            using (MemoryStream stream = new MemoryStream(DataMovementBlobConstants.SourceCheckpointData.DataSize))
            {
                BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(DataMovementBlobConstants.SourceCheckpointData.SchemaVersion);
                writer.Write((byte)BlobType.Block);
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
            BlobSourceCheckpointData data = new(blobType);

            using (Stream stream = new MemoryStream(DataMovementBlobConstants.DestinationCheckpointData.VariableLengthStartIndex))
            {
                data.Serialize(stream);
                stream.Position = 0;
                BlobSourceCheckpointData deserialized = BlobSourceCheckpointData.Deserialize(stream);

                Assert.AreEqual(DataMovementBlobConstants.SourceCheckpointData.SchemaVersion, deserialized.Version);
                Assert.AreEqual(blobType, deserialized.BlobType);
            }
        }
    }
}
