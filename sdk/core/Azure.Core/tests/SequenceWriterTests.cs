// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    internal class SequenceWriterTests
    {
        [Test]
        public void ValidateEmptyBuffer()
        {
            using SequenceWriter writer = new SequenceWriter();
            Assert.IsTrue(writer.TryComputeLength(out var length));
            Assert.AreEqual(0, length);
        }

        [Test]
        public void ValidateSingleBuffer()
        {
            using SequenceWriter writer = new SequenceWriter(512);
            WriteMemory(writer, 400, 0xFF);

            Assert.IsTrue(writer.TryComputeLength(out var length));
            Assert.AreEqual(400, length);
        }

        [Test]
        public void ValidateMultiBuffer()
        {
            using SequenceWriter writer = new SequenceWriter(512);
            WriteMemory(writer, 400, 0xFF);
            WriteMemory(writer, 400, 0xFF);

            Assert.IsTrue(writer.TryComputeLength(out var length));
            Assert.AreEqual(800, length);
        }

        [Test]
        public void CanWriteMoreThanBufferSize()
        {
            using SequenceWriter writer = new SequenceWriter(512);
            WriteMemory(writer, 513, 0xFF);
            WriteMemory(writer, 256, 0xFE);

            Assert.IsTrue(writer.TryComputeLength(out var length));
            Assert.AreEqual(769, length);
        }

        [Test]
        public void DisposeAfterGetMemory()
        {
            SequenceWriter writer = new SequenceWriter(512);
            Memory<byte> memory = writer.GetMemory(400);
            writer.Dispose();
            Assert.Throws<Exception>(() => memory.Span.Fill(0xFF));
        }

        [Test]
        public async Task DisposedWhileCopying()
        {
            int segments = 10000;
            int segmentSize = 400;
            SequenceWriter writer = new SequenceWriter(512);
            for (int i = 0; i < segments; i++)
            {
                WriteMemory(writer, segmentSize, 0xFF);
            }

            Assert.IsTrue(writer.TryComputeLength(out var length));
            Assert.AreEqual(segments * segmentSize, length);

            using var memory = new MemoryStream((int)length);
            var result = Task.Run(() => { return writer.CopyToAsync(memory, default); });
            while (memory.Length == 0) { }
            writer.Dispose();
            await result;

            Assert.Greater(memory.Length, 0);
            Assert.Less(memory.Length, length);
        }

        [Test]
        public async Task DisposedWhileWriting()
        {
            int segments = 10000;
            int segmentSize = 400;
            SequenceWriter writer = new SequenceWriter(512);
            var result = Task.Run(() =>
            {
                bool exceptionThrown = false;
                try
                {
                    for (int i = 0; i < segments; i++)
                    {
                        WriteMemory(writer, segmentSize, 0xFF);
                    }
                }
                catch (Exception ex)
                {
                    Assert.IsTrue(ex is ArgumentOutOfRangeException || ex is IndexOutOfRangeException);
                    exceptionThrown = true;
                }
                finally
                {
                    Assert.IsTrue(exceptionThrown);
                }
            });
            long sequenceLength = 0;
            do
            {
                writer.TryComputeLength(out sequenceLength);
            } while (sequenceLength == 0);

            writer.Dispose();
            await result;
        }

        [Test]
        public void GetNewMemoryAfterDispose()
        {
            SequenceWriter writer = new SequenceWriter(512);
            writer.Dispose();

            Assert.IsTrue(writer.TryComputeLength(out var length));
            Assert.AreEqual(0, length);

            WriteMemory(writer, 400, 0xFF);
            Assert.IsTrue(writer.TryComputeLength(out length));
            Assert.AreEqual(400, length);
        }

        private static void WriteMemory(SequenceWriter writer, int size, byte data)
        {
            var memory = writer.GetMemory(size);
            memory.Span.Slice(0, size).Fill(data);
            writer.Advance(size);
        }
    }
}
