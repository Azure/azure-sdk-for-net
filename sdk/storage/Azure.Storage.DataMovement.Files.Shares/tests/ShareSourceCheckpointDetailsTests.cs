// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
extern alias DMShare;
using System;
using System.IO;
using Azure.Storage.Test;
using DMShare::Azure.Storage.DataMovement.Files.Shares;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    public class ShareSourceCheckpointDetailsTests
    {
        private byte[] CreateSerializedSetValues_LatestVersion()
        {
            using MemoryStream stream = new();
            using BinaryWriter writer = new(stream);

            writer.Write(DataMovementShareConstants.SourceCheckpointDetails.SchemaVersion);
            writer.Write((byte)ShareProtocol.Nfs);

            return stream.ToArray();
        }

        private void AssertEquals(ShareFileSourceCheckpointDetails left, ShareFileSourceCheckpointDetails right)
        {
            Assert.That(left.Version, Is.EqualTo(right.Version));
            Assert.That(left.ShareProtocol, Is.EqualTo(right.ShareProtocol));
        }

        [Test]
        public void Ctor()
        {
            ShareFileSourceCheckpointDetails data = new(ShareProtocol.Nfs);

            Assert.That(DataMovementShareConstants.SourceCheckpointDetails.SchemaVersion, Is.EqualTo(data.Version));
            Assert.That(ShareProtocol.Nfs, Is.EqualTo(data.ShareProtocol));
        }

        [Test]
        public void Serialize_LatestVersion()
        {
            byte[] expected = CreateSerializedSetValues_LatestVersion();

            ShareFileSourceCheckpointDetails data = new(ShareProtocol.Nfs);
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

            ShareFileSourceCheckpointDetails expected = new(ShareProtocol.Nfs);

            AssertEquals(deserialized, expected);
        }

        [Test]
        [TestCase(0)]
        [TestCase(2)]
        [TestCase(3)]
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
        public void RoundTrip_LatestVersion()
        {
            ShareFileSourceCheckpointDetails original = new(ShareProtocol.Nfs);
            using MemoryStream serialized = new();
            original.SerializeInternal(serialized);
            serialized.Position = 0;
            ShareFileSourceCheckpointDetails deserialized = ShareFileSourceCheckpointDetails.Deserialize(serialized);

            AssertEquals(original, deserialized);
        }
    }
}
