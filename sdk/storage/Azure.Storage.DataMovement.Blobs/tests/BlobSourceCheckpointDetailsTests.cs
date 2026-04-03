// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;

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
            // Act
            BlobSourceCheckpointDetails data = new BlobSourceCheckpointDetails();

            // Assert
            Assert.AreEqual(DataMovementBlobConstants.SourceCheckpointDetails.SchemaVersion, data.Version);
        }

        [Test]
        public void Ctor_FromOptions()
        {
            // Arrange
            BlobStorageResourceOptions options = new BlobStorageResourceOptions();

            // Act
            BlobSourceCheckpointDetails data = new BlobSourceCheckpointDetails(options);

            // Assert
            Assert.AreEqual(DataMovementBlobConstants.SourceCheckpointDetails.SchemaVersion, data.Version);
        }

        [Test]
        public void Ctor_FromOptions_Null()
        {
            // Act
            BlobSourceCheckpointDetails data = new BlobSourceCheckpointDetails(options: null);

            // Assert
            Assert.AreEqual(DataMovementBlobConstants.SourceCheckpointDetails.SchemaVersion, data.Version);
        }

        [Test]
        public void Serialize()
        {
            // Arrange
            BlobSourceCheckpointDetails data = new BlobSourceCheckpointDetails();

            // Act
            byte[] actual;
            using (MemoryStream stream = new MemoryStream())
            {
                data.Serialize(stream);
                actual = stream.ToArray();
            }

            // Assert
            Assert.AreEqual(DataMovementBlobConstants.SourceCheckpointDetails.VariableLengthStartIndex, actual.Length);
        }

        [Test]
        public void Deserialize()
        {
            // Arrange
            BlobSourceCheckpointDetails data = new BlobSourceCheckpointDetails();

            // Act
            BlobSourceCheckpointDetails deserialized;
            using (MemoryStream stream = new MemoryStream())
            {
                data.Serialize(stream);
                stream.Position = 0;
                deserialized = BlobSourceCheckpointDetails.Deserialize(stream);
            }

            // Assert
            Assert.AreEqual(data.Version, deserialized.Version);
        }

        [Test]
        public void Deserialize_EmptyStream_BackwardCompatibility()
        {
            // Act
            BlobSourceCheckpointDetails deserialized = BlobSourceCheckpointDetails.Deserialize(Stream.Null);

            // Assert - Should handle legacy empty checkpoints gracefully
            Assert.AreEqual(DataMovementBlobConstants.SourceCheckpointDetails.SchemaVersion, deserialized.Version);
        }

        [Test]
        public void RoundTrip()
        {
            // Arrange
            BlobSourceCheckpointDetails original = new BlobSourceCheckpointDetails();

            // Act
            BlobSourceCheckpointDetails deserialized;
            using (MemoryStream stream = new MemoryStream())
            {
                original.Serialize(stream);
                stream.Position = 0;
                deserialized = BlobSourceCheckpointDetails.Deserialize(stream);
            }

            // Assert
            Assert.AreEqual(original.Version, deserialized.Version);
            Assert.AreEqual(original.Length, deserialized.Length);
        }

        [Test]
        public void Length()
        {
            // Arrange
            BlobSourceCheckpointDetails data = new BlobSourceCheckpointDetails();

            // Assert
            Assert.AreEqual(DataMovementBlobConstants.SourceCheckpointDetails.VariableLengthStartIndex, data.Length);
        }
    }
}
