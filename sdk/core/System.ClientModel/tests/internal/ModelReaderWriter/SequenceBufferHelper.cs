// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Reflection;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal.ModelReaderWriterTests
{
    internal static class SequenceBufferHelper
    {
        public static readonly FieldInfo IsDisposedField = typeof(SequenceBufferReader).GetField("_isDisposed", BindingFlags.NonPublic | BindingFlags.Instance)!;

        public static SequenceBufferReader SetUpBufferReader(int totalSize = 100000, int segmentSize = 16384, int chunkSize = 15000)
        {
            SequenceBufferWriter writer = SetUpBufferBuilder(totalSize, segmentSize, chunkSize);
            SequenceBufferReader reader = writer.GetSequenceBufferReader();
            Assert.AreEqual(0, IsDisposedField.GetValue(reader));
            Assert.IsTrue(reader.TryComputeLength(out long length));
            Assert.AreEqual(totalSize, length);
            return reader;
        }

        public static SequenceBufferWriter SetUpBufferBuilder(int totalSize = 100000, int segmentSize = 16384, int chunkSize = 15000)
        {
            SequenceBufferWriter writer = new SequenceBufferWriter(segmentSize);
            WriteBytes(writer, 0xFF, totalSize, chunkSize);
            return writer;
        }

        public static void WriteBytes(SequenceBufferWriter writer, byte data, int total, int chunkSize)
        {
            int segments = (total / chunkSize) + 1;
            int remaining = total;
            for (int i = 0; i < segments; i++)
            {
                int size = Math.Min(remaining, chunkSize);
                writer.GetMemory(size).Span.Fill(data);
                writer.Advance(size);
                remaining -= size;
            }
        }
    }
}
