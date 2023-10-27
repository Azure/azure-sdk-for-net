// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    public class ShareSourceCheckpointDataTests
    {
        [Test]
        public void Ctor()
        {
            ShareFileSourceCheckpointData data = new();

            Assert.That(data.Version, Is.EqualTo(DataMovementShareConstants.SourceCheckpointData.SchemaVersion));
        }

        [Test]
        public void Serialize()
        {
            byte[] expected;
            using (MemoryStream stream = new MemoryStream(DataMovementShareConstants.SourceCheckpointData.DataSize))
            {
                BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(DataMovementShareConstants.SourceCheckpointData.SchemaVersion);
                expected = stream.ToArray();
            }

            ShareFileSourceCheckpointData data = new();
            byte[] actual;
            using (MemoryStream stream = new(DataMovementShareConstants.SourceCheckpointData.DataSize))
            {
                data.SerializeInternal(stream);
                actual = stream.ToArray();
            }

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Deserialize()
        {
            ShareFileSourceCheckpointData data = new();
            ShareFileSourceCheckpointData deserialized;

            using (MemoryStream stream = new())
            {
                data.SerializeInternal(stream);
                stream.Position = 0;
                deserialized = ShareFileSourceCheckpointData.Deserialize(stream);
            }

            Assert.That(deserialized.Version, Is.EqualTo(data.Version));
        }
    }
}
