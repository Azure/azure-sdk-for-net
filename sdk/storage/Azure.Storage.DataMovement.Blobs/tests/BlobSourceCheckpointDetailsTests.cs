// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;

using System;
using System.IO;
using System.Text;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    public class BlobSourceCheckpointDetailsTests
    {
        private const string DefaultSnapshot = "2024-01-01T00:00:00.0000000Z";
        private const string DefaultVersionId = "2024-01-02T12:30:45.1234567Z";

        private static byte[] StringToByteArray(string value) => Encoding.UTF8.GetBytes(value);

        private BlobSourceCheckpointDetails CreateNoValues()
            => new BlobSourceCheckpointDetails(
                snapshot: null,
                versionId: null);

        private BlobSourceCheckpointDetails CreateWithSnapshot()
            => new BlobSourceCheckpointDetails(
                snapshot: DefaultSnapshot,
                versionId: null);

        private BlobSourceCheckpointDetails CreateWithVersionId()
            => new BlobSourceCheckpointDetails(
                snapshot: null,
                versionId: DefaultVersionId);

        [Test]
        public void Ctor_NoValues()
        {
            // Act
            BlobSourceCheckpointDetails data = CreateNoValues();

            // Assert
            Assert.AreEqual(DataMovementBlobConstants.SourceCheckpointDetails.SchemaVersion, data.Version);
            Assert.IsNull(data.Snapshot);
            Assert.IsEmpty(data.SnapshotBytes);
            Assert.IsNull(data.VersionId);
            Assert.IsEmpty(data.VersionIdBytes);
        }

        [Test]
        public void Ctor_WithSnapshot()
        {
            // Act
            BlobSourceCheckpointDetails data = CreateWithSnapshot();

            // Assert
            Assert.AreEqual(DataMovementBlobConstants.SourceCheckpointDetails.SchemaVersion, data.Version);
            Assert.AreEqual(DefaultSnapshot, data.Snapshot);
            Assert.AreEqual(StringToByteArray(DefaultSnapshot), data.SnapshotBytes);
            Assert.IsNull(data.VersionId);
            Assert.IsEmpty(data.VersionIdBytes);
        }

        [Test]
        public void Ctor_WithVersionId()
        {
            // Act
            BlobSourceCheckpointDetails data = CreateWithVersionId();

            // Assert
            Assert.AreEqual(DataMovementBlobConstants.SourceCheckpointDetails.SchemaVersion, data.Version);
            Assert.IsNull(data.Snapshot);
            Assert.IsEmpty(data.SnapshotBytes);
            Assert.AreEqual(DefaultVersionId, data.VersionId);
            Assert.AreEqual(StringToByteArray(DefaultVersionId), data.VersionIdBytes);
        }

        [Test]
        public void Ctor_FromOptions_NoValues()
        {
            // Arrange
            BlobStorageResourceOptions options = new BlobStorageResourceOptions();

            // Act
            BlobSourceCheckpointDetails data = new BlobSourceCheckpointDetails(options);

            // Assert
            Assert.IsNull(data.Snapshot);
            Assert.IsNull(data.VersionId);
        }

        [Test]
        public void Ctor_FromOptions_WithSnapshot()
        {
            // Arrange
            BlobStorageResourceOptions options = new BlobStorageResourceOptions
            {
                Snapshot = DefaultSnapshot
            };

            // Act
            BlobSourceCheckpointDetails data = new BlobSourceCheckpointDetails(options);

            // Assert
            Assert.AreEqual(DefaultSnapshot, data.Snapshot);
            Assert.IsNull(data.VersionId);
        }

        [Test]
        public void Ctor_FromOptions_WithVersionId()
        {
            // Arrange
            BlobStorageResourceOptions options = new BlobStorageResourceOptions
            {
                VersionId = DefaultVersionId
            };

            // Act
            BlobSourceCheckpointDetails data = new BlobSourceCheckpointDetails(options);

            // Assert
            Assert.IsNull(data.Snapshot);
            Assert.AreEqual(DefaultVersionId, data.VersionId);
        }

        [Test]
        public void Ctor_FromOptions_Null()
        {
            // Act
            BlobSourceCheckpointDetails data = new BlobSourceCheckpointDetails(options: null);

            // Assert
            Assert.IsNull(data.Snapshot);
            Assert.IsNull(data.VersionId);
        }

        [Test]
        public void Serialize_NoValues()
        {
            // Arrange
            BlobSourceCheckpointDetails data = CreateNoValues();

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
        public void Serialize_WithSnapshot()
        {
            // Arrange
            BlobSourceCheckpointDetails data = CreateWithSnapshot();
            int expectedLength = DataMovementBlobConstants.SourceCheckpointDetails.VariableLengthStartIndex
                + StringToByteArray(DefaultSnapshot).Length;

            // Act
            byte[] actual;
            using (MemoryStream stream = new MemoryStream())
            {
                data.Serialize(stream);
                actual = stream.ToArray();
            }

            // Assert
            Assert.AreEqual(expectedLength, actual.Length);
            Assert.AreEqual(data.Length, actual.Length);
        }

        [Test]
        public void Serialize_WithVersionId()
        {
            // Arrange
            BlobSourceCheckpointDetails data = CreateWithVersionId();
            int expectedLength = DataMovementBlobConstants.SourceCheckpointDetails.VariableLengthStartIndex
                + StringToByteArray(DefaultVersionId).Length;

            // Act
            byte[] actual;
            using (MemoryStream stream = new MemoryStream())
            {
                data.Serialize(stream);
                actual = stream.ToArray();
            }

            // Assert
            Assert.AreEqual(expectedLength, actual.Length);
            Assert.AreEqual(data.Length, actual.Length);
        }

        [Test]
        public void Deserialize_NoValues()
        {
            // Arrange
            BlobSourceCheckpointDetails data = CreateNoValues();

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
            Assert.AreEqual(data.Snapshot, deserialized.Snapshot);
            Assert.AreEqual(data.VersionId, deserialized.VersionId);
        }

        [Test]
        public void Deserialize_WithSnapshot()
        {
            // Arrange
            BlobSourceCheckpointDetails data = CreateWithSnapshot();

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
            Assert.AreEqual(DefaultSnapshot, deserialized.Snapshot);
            Assert.IsNull(deserialized.VersionId);
        }

        [Test]
        public void Deserialize_WithVersionId()
        {
            // Arrange
            BlobSourceCheckpointDetails data = CreateWithVersionId();

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
            Assert.IsNull(deserialized.Snapshot);
            Assert.AreEqual(DefaultVersionId, deserialized.VersionId);
        }

        [Test]
        public void Deserialize_EmptyStream_BackwardCompatibility()
        {
            // Act
            BlobSourceCheckpointDetails deserialized = BlobSourceCheckpointDetails.Deserialize(Stream.Null);

            // Assert - Should handle legacy empty checkpoints gracefully
            Assert.IsNull(deserialized.Snapshot);
            Assert.IsNull(deserialized.VersionId);
        }

        [Test]
        public void RoundTrip_NoValues()
        {
            // Arrange
            BlobSourceCheckpointDetails original = CreateNoValues();

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
            Assert.AreEqual(original.Snapshot, deserialized.Snapshot);
            Assert.AreEqual(original.VersionId, deserialized.VersionId);
            Assert.AreEqual(original.Length, deserialized.Length);
        }

        [Test]
        public void RoundTrip_WithSnapshot()
        {
            // Arrange
            BlobSourceCheckpointDetails original = CreateWithSnapshot();

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
            Assert.AreEqual(original.Snapshot, deserialized.Snapshot);
            Assert.AreEqual(original.VersionId, deserialized.VersionId);
            Assert.AreEqual(original.Length, deserialized.Length);
        }

        [Test]
        public void RoundTrip_WithVersionId()
        {
            // Arrange
            BlobSourceCheckpointDetails original = CreateWithVersionId();

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
            Assert.AreEqual(original.Snapshot, deserialized.Snapshot);
            Assert.AreEqual(original.VersionId, deserialized.VersionId);
            Assert.AreEqual(original.Length, deserialized.Length);
        }

        [Test]
        public void Length_NoValues()
        {
            // Arrange
            BlobSourceCheckpointDetails data = CreateNoValues();

            // Assert
            Assert.AreEqual(DataMovementBlobConstants.SourceCheckpointDetails.VariableLengthStartIndex, data.Length);
        }

        [Test]
        public void Length_WithSnapshot()
        {
            // Arrange
            BlobSourceCheckpointDetails data = CreateWithSnapshot();
            int expectedLength = DataMovementBlobConstants.SourceCheckpointDetails.VariableLengthStartIndex
                + StringToByteArray(DefaultSnapshot).Length;

            // Assert
            Assert.AreEqual(expectedLength, data.Length);
        }

        [Test]
        public void Length_WithVersionId()
        {
            // Arrange
            BlobSourceCheckpointDetails data = CreateWithVersionId();
            int expectedLength = DataMovementBlobConstants.SourceCheckpointDetails.VariableLengthStartIndex
                + StringToByteArray(DefaultVersionId).Length;

            // Assert
            Assert.AreEqual(expectedLength, data.Length);
        }
    }
}
