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
        [Test]
        public void Ctor()
        {
            ShareFileSourceCheckpointDetails data = new(ShareProtocol.Nfs);

            Assert.That(DataMovementShareConstants.SourceCheckpointDetails.SchemaVersion, Is.EqualTo(data.Version));
            Assert.That(ShareProtocol.Nfs, Is.EqualTo(data.ShareProtocol));
        }

        [Test]
        public void Serialize()
        {
            ShareFileSourceCheckpointDetails data = new(ShareProtocol.Nfs);
            byte[] actual;
            using (MemoryStream stream = new())
            {
                data.SerializeInternal(stream);
                actual = stream.ToArray();
            }

            // Should only be the fixed size header
            Assert.That(actual.Length, Is.EqualTo(DataMovementShareConstants.SourceCheckpointDetails.VariableLengthStartIndex));
        }

        [Test]
        public void Deserialize()
        {
            ShareFileSourceCheckpointDetails original = new(ShareProtocol.Nfs);
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
            Assert.That(deserialized.ShareProtocol, Is.EqualTo(ShareProtocol.Nfs));
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
            ShareFileSourceCheckpointDetails data = new(ShareProtocol.Nfs);
            data.Version = incorrectSchemaVersion;

            using MemoryStream dataStream = new MemoryStream();
            data.SerializeInternal(dataStream);
            dataStream.Position = 0;
            TestHelper.AssertExpectedException(
                () => ShareFileSourceCheckpointDetails.Deserialize(dataStream),
                new ArgumentException($"The checkpoint file schema version {incorrectSchemaVersion} is not supported by this version of the SDK."));
        }

        [Test]
        public void RoundTrip()
        {
            ShareFileSourceCheckpointDetails original = new(ShareProtocol.Nfs);
            using MemoryStream serialized = new();
            original.SerializeInternal(serialized);
            serialized.Position = 0;
            ShareFileSourceCheckpointDetails deserialized = ShareFileSourceCheckpointDetails.Deserialize(serialized);

            Assert.That(original.Version, Is.EqualTo(deserialized.Version));
            Assert.That(original.ShareProtocol, Is.EqualTo(deserialized.ShareProtocol));
        }

        [Test]
        public void Deserialize_Version1()
        {
            // Version 1 has version + protocol
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
        }

        [Test]
        public void Deserialize_EmptyStream_BackwardCompatibility()
        {
            // Act
            ShareFileSourceCheckpointDetails deserialized = ShareFileSourceCheckpointDetails.Deserialize(Stream.Null);

            // Assert - Should handle legacy empty checkpoints gracefully (version 0)
            Assert.AreEqual(ShareProtocol.Smb, deserialized.ShareProtocol);
        }

        [Test]
        public void Deserialize_Version1_BackwardCompatibility()
        {
            // Arrange - Create a version 1 checkpoint
            using MemoryStream stream = new MemoryStream();
            using (BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8, leaveOpen: true))
            {
                writer.Write(DataMovementShareConstants.SourceCheckpointDetails.SchemaVersion_1); // Version 1
                writer.Write((byte)ShareProtocol.Smb); // ShareProtocol
            }

            // Act
            stream.Position = 0;
            ShareFileSourceCheckpointDetails deserialized = ShareFileSourceCheckpointDetails.Deserialize(stream);

            // Assert - Should handle version 1 checkpoint
            Assert.AreEqual(ShareProtocol.Smb, deserialized.ShareProtocol);
        }

        [Test]
        public void Length()
        {
            // Arrange
            ShareFileSourceCheckpointDetails data = new ShareFileSourceCheckpointDetails(ShareProtocol.Nfs);

            // Assert
            Assert.AreEqual(DataMovementShareConstants.SourceCheckpointDetails.VariableLengthStartIndex, data.Length);
        }
    }
}
