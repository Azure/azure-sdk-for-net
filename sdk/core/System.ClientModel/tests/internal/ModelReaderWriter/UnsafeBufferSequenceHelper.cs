// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Reflection;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal.ModelReaderWriterTests
{
    internal static class UnsafeBufferSequenceHelper
    {
        public static readonly FieldInfo IsDisposedField = typeof(UnsafeBufferSequence.Reader).GetField("_isDisposed", BindingFlags.NonPublic | BindingFlags.Instance)!;

        public static UnsafeBufferSequence.Reader SetUpBufferReader(int totalSize = 100000, int segmentSize = 16384, int chunkSize = 15000)
        {
            UnsafeBufferSequence writer = SetUpBufferBuilder(totalSize, segmentSize, chunkSize);
            UnsafeBufferSequence.Reader reader = writer.ExtractReader();
            Assert.IsFalse((bool)IsDisposedField.GetValue(reader)!);
            Assert.AreEqual(totalSize, reader.Length);
            return reader;
        }

        public static UnsafeBufferSequence SetUpBufferBuilder(int totalSize = 100000, int segmentSize = 16384, int chunkSize = 15000)
        {
            UnsafeBufferSequence writer = new UnsafeBufferSequence(segmentSize);
            WriteBytes(writer, 0xFF, totalSize, chunkSize);
            return writer;
        }

        public static void WriteBytes(UnsafeBufferSequence writer, byte data, int total, int chunkSize)
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
