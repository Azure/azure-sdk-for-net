// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
extern alias DMShare;

using System;
using System.IO;
using NUnit.Framework;
using DMShare::Azure.Storage.DataMovement.Files.Shares;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    public class ShareSourceCheckpointDetailsTests
    {
        [Test]
        public void Ctor()
        {
            ShareFileSourceCheckpointDetails data = new();
        }

        [Test]
        public void Serialize()
        {
            byte[] expected = Array.Empty<byte>();

            ShareFileSourceCheckpointDetails data = new();
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
            ShareFileSourceCheckpointDetails deserialized;

            using (MemoryStream stream = new())
            {
                deserialized = ShareFileSourceCheckpointDetails.Deserialize(Stream.Null);
            }
        }
    }
}
