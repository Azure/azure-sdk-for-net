// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
extern alias DMShare;
using System;
using System.IO;
using System.Text;
using Azure.Storage.Test;
using DMShare::Azure.Storage.DataMovement.Files.Shares;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    public class ShareSourceCheckpointDetailsTests
    {
        private static string defaultSnapshot = "2024-01-15T10:30:00.0000000Z";
        private byte[] CreateSerializedSetValues_LatestVersion()
        {
            using MemoryStream stream = new();
            using BinaryWriter writer = new(stream);

            byte[] snapshotBytes = StringToByteArray(defaultSnapshot);
            int snapshotOffset = DataMovementShareConstants.SourceCheckpointDetails.VariableLengthStartIndex;

            writer.Write(DataMovementShareConstants.SourceCheckpointDetails.SchemaVersion);
            writer.Write((byte)ShareProtocol.Nfs);
            // With snapshot - write offset/length
            writer.Write(snapshotOffset); // offset
            writer.Write(snapshotBytes.Length); // length
            // Write the actual snapshot bytes
            writer.Write(snapshotBytes);

            return stream.ToArray();
        }

        private void AssertEquals(ShareFileSourceCheckpointDetails left, ShareFileSourceCheckpointDetails right)
        {
            Assert.That(left.Version, Is.EqualTo(right.Version));
            Assert.That(left.ShareProtocol, Is.EqualTo(right.ShareProtocol));
            Assert.That(left.Snapshot, Is.EqualTo(right.Snapshot));
        }

        private static byte[] StringToByteArray(string value)
        {
            return string.IsNullOrEmpty(value) ? Array.Empty<byte>() : Encoding.UTF8.GetBytes(value);
        }

        [Test]
        public void Ctor()
        {
            ShareFileSourceCheckpointDetails data = new(ShareProtocol.Nfs, snapshot: null);

            Assert.That(DataMovementShareConstants.SourceCheckpointDetails.SchemaVersion, Is.EqualTo(data.Version));
            Assert.That(ShareProtocol.Nfs, Is.EqualTo(data.ShareProtocol));
            Assert.That(data.Snapshot, Is.Null);
        }

        [Test]
        public void Serialize_LatestVersion()
        {
            byte[] expected = CreateSerializedSetValues_LatestVersion();

            ShareFileSourceCheckpointDetails data = new(ShareProtocol.Nfs, snapshot: defaultSnapshot);
            byte[] actual;
            using (MemoryStream stream = new())
            {
                data.SerializeInternal(stream);
                actual = stream.ToArray();
            }

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Deserialize_LatestVersion()
        {
            byte[] serialized = CreateSerializedSetValues_LatestVersion();
            ShareFileSourceCheckpointDetails deserialized;

            using (MemoryStream stream = new(serialized))
            {
                deserialized = ShareFileSourceCheckpointDetails.Deserialize(stream);
            }

            Assert.That(deserialized.Version, Is.EqualTo(DataMovementShareConstants.SourceCheckpointDetails.SchemaVersion));
            Assert.That(deserialized.ShareProtocol, Is.EqualTo(ShareProtocol.Nfs));
            Assert.That(deserialized.Snapshot, Is.EqualTo(defaultSnapshot));
        }

        [Test]
        public void Deserialize_Version0()
        {
            byte[] serialized = new byte[0]; // Version 0 has no data
            ShareFileSourceCheckpointDetails deserialized;

            using (MemoryStream stream = new(serialized))
            {
                deserialized = ShareFileSourceCheckpointDetails.Deserialize(stream);
            }

            // We are expecting that after deserialization, the version is bumped to latest version
            Assert.That(deserialized.Version, Is.EqualTo(DataMovementShareConstants.SourceCheckpointDetails.SchemaVersion));
            // We are expecting that after deserialization, the ShareProtocol is set to default value (SMB)
            Assert.That(deserialized.ShareProtocol, Is.EqualTo(ShareProtocol.Smb));
        }

        [Test]
        [TestCase(0)]
        [TestCase(3)]
        [TestCase(4)]
        public void Deserialize_IncorrectSchemaVersion(int incorrectSchemaVersion)
        {
            ShareFileSourceCheckpointDetails data = new(ShareProtocol.Nfs, snapshot: null);
            data.Version = incorrectSchemaVersion;

            using MemoryStream dataStream = new MemoryStream();
            data.SerializeInternal(dataStream);
            dataStream.Position = 0;
            TestHelper.AssertExpectedException(
                () => ShareFileSourceCheckpointDetails.Deserialize(dataStream),
                new ArgumentException($"The checkpoint file schema version {incorrectSchemaVersion} is not supported by this version of the SDK."));
        }

        [Test]
        public void RoundTrip_LatestVersion()
        {
            ShareFileSourceCheckpointDetails original = new(ShareProtocol.Nfs, snapshot: defaultSnapshot);
            using MemoryStream serialized = new();
            original.SerializeInternal(serialized);
            serialized.Position = 0;
            ShareFileSourceCheckpointDetails deserialized = ShareFileSourceCheckpointDetails.Deserialize(serialized);

            AssertEquals(original, deserialized);
        }

        [Test]
        public void Serialize_NoSnapshot()
        {
            ShareFileSourceCheckpointDetails data = new(ShareProtocol.Smb, snapshot: null);

            byte[] serialized;
            using (MemoryStream stream = new())
            {
                data.SerializeInternal(stream);
                serialized = stream.ToArray();
            }

            // Should only be the fixed size header (no variable-length data)
            Assert.That(serialized.Length, Is.EqualTo(DataMovementShareConstants.SourceCheckpointDetails.VariableLengthStartIndex));
        }

        [Test]
        public void Serialize_WithSnapshot()
        {
            ShareFileSourceCheckpointDetails data = new(ShareProtocol.Smb, snapshot: defaultSnapshot);

            byte[] serialized;
            using (MemoryStream stream = new())
            {
                data.SerializeInternal(stream);
                serialized = stream.ToArray();
            }

            Assert.That(serialized.Length, Is.GreaterThan(DataMovementShareConstants.SourceCheckpointDetails.VariableLengthStartIndex));
        }

        [Test]
        public void RoundTrip_NoSnapshot()
        {
            ShareFileSourceCheckpointDetails original = new(ShareProtocol.Smb, snapshot: null);

            using MemoryStream serialized = new();
            original.SerializeInternal(serialized);
            serialized.Position = 0;
            ShareFileSourceCheckpointDetails deserialized = ShareFileSourceCheckpointDetails.Deserialize(serialized);

            AssertEquals(original, deserialized);
        }

        [Test]
        public void Deserialize_WithSnapshot()
        {
            string snapshotValue = "2024-01-15T10:30:00.0000000Z";
            ShareFileSourceCheckpointDetails original = new(ShareProtocol.Smb, snapshot: snapshotValue);

            byte[] serialized;
            using (MemoryStream stream = new())
            {
                original.SerializeInternal(stream);
                serialized = stream.ToArray();
            }

            ShareFileSourceCheckpointDetails deserialized;
            using (MemoryStream stream = new(serialized))
            {
                deserialized = ShareFileSourceCheckpointDetails.Deserialize(stream);
            }

            Assert.That(deserialized.Version, Is.EqualTo(DataMovementShareConstants.SourceCheckpointDetails.SchemaVersion));
            Assert.That(deserialized.ShareProtocol, Is.EqualTo(ShareProtocol.Smb));
            Assert.That(deserialized.Snapshot, Is.EqualTo(snapshotValue));
        }

        [Test]
        public void RoundTrip_WithSnapshot()
        {
            string snapshotValue = "2024-01-15T10:30:00.0000000Z";
            ShareFileSourceCheckpointDetails original = new(ShareProtocol.Nfs, snapshot: snapshotValue);

            using MemoryStream serialized = new();
            original.SerializeInternal(serialized);
            serialized.Position = 0;
            ShareFileSourceCheckpointDetails deserialized = ShareFileSourceCheckpointDetails.Deserialize(serialized);

            AssertEquals(original, deserialized);
        }

        [Test]
        public void Deserialize_Version1()
        {
            // Version 1 has version + protocol but no snapshot fields
            using MemoryStream stream = new();
            using BinaryWriter writer = new(stream);

            writer.Write(DataMovementShareConstants.SourceCheckpointDetails.SchemaVersion_1);
            writer.Write((byte)ShareProtocol.Nfs);

            byte[] serialized = stream.ToArray();
            ShareFileSourceCheckpointDetails deserialized;

            using (MemoryStream readStream = new(serialized))
            {
                deserialized = ShareFileSourceCheckpointDetails.Deserialize(readStream);
            }

            // We are expecting that after deserialization, the version is bumped to latest version
            Assert.That(deserialized.Version, Is.EqualTo(DataMovementShareConstants.SourceCheckpointDetails.SchemaVersion));
            Assert.That(deserialized.ShareProtocol, Is.EqualTo(ShareProtocol.Nfs));
            Assert.That(deserialized.Snapshot, Is.Null);
        }

        [Test]
        public void Deserialize_EmptyStream_BackwardCompatibility()
        {
            // Act
            ShareFileSourceCheckpointDetails deserialized = ShareFileSourceCheckpointDetails.Deserialize(Stream.Null);

            // Assert - Should handle legacy empty checkpoints gracefully (version 0)
            Assert.AreEqual(ShareProtocol.Smb, deserialized.ShareProtocol);
            Assert.IsNull(deserialized.Snapshot);
        }

        [Test]
        public void Deserialize_Version1_NoSnapshot_BackwardCompatibility()
        {
            // Arrange - Create a version 1 checkpoint (no snapshot support)
            using MemoryStream stream = new MemoryStream();
            using (BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8, leaveOpen: true))
            {
                writer.Write(DataMovementShareConstants.SourceCheckpointDetails.SchemaVersion_1); // Version 1
                writer.Write((byte)ShareProtocol.Smb); // ShareProtocol
            }

            // Act
            stream.Position = 0;
            ShareFileSourceCheckpointDetails deserialized = ShareFileSourceCheckpointDetails.Deserialize(stream);

            // Assert - Should handle version 1 checkpoint without snapshot field
            Assert.AreEqual(ShareProtocol.Smb, deserialized.ShareProtocol);
            Assert.IsNull(deserialized.Snapshot);
        }

        [Test]
        public void Length_NoSnapshot()
        {
            // Arrange
            ShareFileSourceCheckpointDetails data = new ShareFileSourceCheckpointDetails(ShareProtocol.Nfs);

            // Assert
            Assert.AreEqual(DataMovementShareConstants.SourceCheckpointDetails.VariableLengthStartIndex, data.Length);
        }

        [Test]
        public void Length_WithSnapshot()
        {
            // Arrange
            ShareFileSourceCheckpointDetails data = new ShareFileSourceCheckpointDetails(ShareProtocol.Nfs, defaultSnapshot);
            int expectedLength = DataMovementShareConstants.SourceCheckpointDetails.VariableLengthStartIndex
                + StringToByteArray(defaultSnapshot).Length;

            // Assert
            Assert.AreEqual(expectedLength, data.Length);
        }
    }
}
