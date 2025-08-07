// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;

namespace Azure.Storage.DataMovement.Tests
{
    public class MockResourceCheckpointDetails : StorageResourceCheckpointDetails
    {
        public byte[] Bytes;

        public override int Length => Bytes.Length;

        public static MockResourceCheckpointDetails DefaultInstance => s_instance.Value;
        private static Lazy<MockResourceCheckpointDetails> s_instance = new(() => new MockResourceCheckpointDetails());

        public MockResourceCheckpointDetails()
        {
            string testString = "Hello World!";
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryWriter writer = new BinaryWriter(stream);

                writer.Write(false);
                writer.Write(42);
                writer.Write(123860);
                writer.Write(Encoding.UTF8.GetBytes(testString));

                Bytes = stream.ToArray();
            }
        }

        protected internal override void Serialize(Stream stream)
        {
            stream.Write(Bytes, 0, Bytes.Length);
        }
    }
}
