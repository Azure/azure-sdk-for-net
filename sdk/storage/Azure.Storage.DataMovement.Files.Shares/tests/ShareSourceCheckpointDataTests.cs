// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        }

        [Test]
        public void Serialize()
        {
            byte[] expected = Array.Empty<byte>();

            ShareFileSourceCheckpointData data = new();
            byte[] actual;
            using (MemoryStream stream = new())
            {
                data.SerializeInternal(stream);
                actual = stream.ToArray();
            }

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Deserialize()
        {
            ShareFileSourceCheckpointData deserialized;

            using (MemoryStream stream = new())
            {
                deserialized = ShareFileSourceCheckpointData.Deserialize(Stream.Null);
            }
        }
    }
}
