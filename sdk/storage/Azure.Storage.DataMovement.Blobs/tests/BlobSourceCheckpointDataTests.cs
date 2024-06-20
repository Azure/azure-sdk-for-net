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
            BlobSourceCheckpointData data = new(new(BlobType.Block));

            Assert.AreEqual(DataMovementBlobConstants.SourceCheckpointData.SchemaVersion, data.Version);
            Assert.IsFalse(data.BlobType.Preserve);
            Assert.AreEqual(BlobType.Block, data.BlobType.Value);
        }

        [Test]
        public void Serialize()
        {
            BlobSourceCheckpointData data = new(new(BlobType.Block));

            byte[] expected;
            using (MemoryStream stream = new MemoryStream(DataMovementBlobConstants.SourceCheckpointData.DataSize))
            {
                BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(DataMovementBlobConstants.SourceCheckpointData.SchemaVersion);
                // Set blob type to block (no preserve)
                writer.Write(false);
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
        public void Serialize_Preserve()
        {
            BlobSourceCheckpointData data = new(new(true));

            byte[] expected;
            using (MemoryStream stream = new MemoryStream(DataMovementBlobConstants.SourceCheckpointData.DataSize))
            {
                BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(DataMovementBlobConstants.SourceCheckpointData.SchemaVersion);
                // Set blob type to block (no preserve)
                writer.Write(true);
                writer.Write((byte)0);
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
            BlobSourceCheckpointData data = new(new(blobType));

            using (Stream stream = new MemoryStream(DataMovementBlobConstants.DestinationCheckpointData.VariableLengthStartIndex))
            {
                data.Serialize(stream);
                stream.Position = 0;
                BlobSourceCheckpointData deserialized = BlobSourceCheckpointData.Deserialize(stream);

                Assert.AreEqual(DataMovementBlobConstants.SourceCheckpointData.SchemaVersion, deserialized.Version);
                Assert.IsFalse(deserialized.BlobType.Preserve);
                Assert.AreEqual(blobType, deserialized.BlobType.Value);
            }
        }

        [Test]
        public void Deserialize_NoPreserve()
        {
            BlobSourceCheckpointData data = new(new(true));

            using (Stream stream = new MemoryStream(DataMovementBlobConstants.DestinationCheckpointData.VariableLengthStartIndex))
            {
                data.Serialize(stream);
                stream.Position = 0;
                BlobSourceCheckpointData deserialized = BlobSourceCheckpointData.Deserialize(stream);

                Assert.AreEqual(DataMovementBlobConstants.SourceCheckpointData.SchemaVersion, deserialized.Version);
                Assert.IsTrue(deserialized.PreserveBlobType);
                Assert.IsNull(deserialized.BlobTypeValue);
            }
        }
    }
}
