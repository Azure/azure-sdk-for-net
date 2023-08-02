// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
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

            // need to find a way to make this fail
            memory.Span.Fill(0xFF);
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

            using MemoryStream memory = new MemoryStream((int)length);
            Task result = Task.Run(() => { return writer.CopyToAsync(memory, default); });
            while (memory.Length == 0)
            { }
            writer.Dispose();
            await result;

            // because the writer was disposed in the middle of copying to a stream
            // the length will be less than expected
            // only a portion of the writer was copied to the stream before the dispose
            // no exception is thrown here because the writer is not thread safe
            Assert.Greater(memory.Length, 0);
            Assert.Less(memory.Length, length);
        }

        [Test]
        public async Task DisposedWhileWriting()
        {
            int segments = 10000;
            int segmentSize = 400;
            SequenceWriter writer = new SequenceWriter(512);
            bool exceptionThrown = false;
            Task result = Task.Run(() =>
            {
                try
                {
                    for (int i = 0; i < segments; i++)
                    {
                        WriteMemory(writer, segmentSize, 0xFF);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    // due to not fully locking and making the writer thread safe
                    // it is possible to get an index out of range exception
                    // if you dispose the writer right after a resize
                    exceptionThrown = true;
                }
            });
            long sequenceLength = 0;
            do
            {
                Assert.IsTrue(writer.TryComputeLength(out sequenceLength));
            } while (sequenceLength == 0);

            writer.Dispose();

            // The original task will continue to write to the sequence writer
            // but the writer was disposed in the middle so whatever was written before
            // the dispose will be freed back to the shared pool so the length will be less than expected
            await result;

            Assert.IsTrue(writer.TryComputeLength(out sequenceLength));
            if (!exceptionThrown)
            {
                Assert.Greater(sequenceLength, 0);
                Assert.Less(sequenceLength, segments * segmentSize);
            }
        }

        [Test]
        public void GetNewMemoryAfterDispose()
        {
            SequenceWriter writer = new SequenceWriter(512);
            writer.Dispose();

            Assert.IsTrue(writer.TryComputeLength(out var length));
            Assert.AreEqual(0, length);

            // should this fail with ObjectDisposedException?
            WriteMemory(writer, 400, 0xFF);
            Assert.IsTrue(writer.TryComputeLength(out length));
            Assert.AreEqual(400, length);
        }

        private static void WriteMemory(SequenceWriter writer, int size, byte data)
        {
            Memory<byte> memory = writer.GetMemory(size);
            memory.Span.Slice(0, size).Fill(data);
            writer.Advance(size);
        }

        [Test]
        public void GetMultipleMemoryWithoutAdvance()
        {
            using SequenceWriter writer = new SequenceWriter(512);
            Memory<byte> memory1 = writer.GetMemory(400);

            // should we throw here on the second GetMemory without calling Advance?
            // It seems that you should not be able to get more memory without advancing
            // If we did this perhaps we could eliminate the use-after-free and worst case leak
            // one segment that doesn't get disposed
            Memory<byte> memory2 = writer.GetMemory(400);
            memory2.Span.Fill(0xFF);
            writer.Advance(400);

            MemoryStream stream = new MemoryStream(400);
            writer.CopyTo(stream, default);
            Assert.AreEqual(400, stream.Length);
            byte[] buffer = stream.GetBuffer();

            // even though we write to the second memory buffer the first segment had 0 written bytes
            Assert.AreEqual(0xFF, buffer[0]);
            Assert.AreEqual(0xFF, buffer[399]);

            Array rawSegments = writer.GetType().GetField("_buffers", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(writer) as Array;
            // we should have 1 segment since the two memory objects should be pointed at the same place
            Assert.AreEqual(1, rawSegments.Length);

            memory1.Span.Fill(0xFE);

            stream = new MemoryStream(400);
            writer.CopyTo(stream, default);
            Assert.AreEqual(400, stream.Length);
            buffer = stream.GetBuffer();

            // without advancing since the first and second Memory pointed to the same place
            // we have replaced what was there
            Assert.AreEqual(0xFE, buffer[0]);
            Assert.AreEqual(0xFE, buffer[399]);

            Assert.Throws<ArgumentOutOfRangeException>(() => writer.Advance(400));
        }

        [Test]
        public void GetMultipleMemoryMultipleSegmentWithoutAdvance()
        {
            using SequenceWriter writer = new SequenceWriter(512);
            Memory<byte> memory1 = writer.GetMemory(400);

            // should we throw here on the second GetMemory without calling Advance?
            // It seems that you should not be able to get more memory without advancing
            // If we did this perhaps we could eliminate the use-after-free and worst case leak
            // one segment that doesn't get disposed
            Memory<byte> memory2 = writer.GetMemory(800);
            memory2.Span.Fill(0xFF);
            writer.Advance(800);

            MemoryStream stream = new MemoryStream(800);
            writer.CopyTo(stream, default);
            Assert.AreEqual(800, stream.Length);
            byte[] buffer = stream.GetBuffer();

            // even though we write to the second memory buffer the first segment had 0 written bytes
            Assert.AreEqual(0xFF, buffer[0]);
            Assert.AreEqual(0xFF, buffer[799]);

            Array rawSegments = writer.GetType().GetField("_buffers", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(writer) as Array;
            // we should have 2 segment since the second memory was larger than the segment size
            Assert.AreEqual(2, rawSegments.Length);
            object buffer1 = rawSegments.GetValue(0);
            int buffer1BytesWritten = (int)buffer1.GetType().GetField("Written", BindingFlags.Public | BindingFlags.Instance).GetValue(buffer1);
            Assert.AreEqual(0, buffer1BytesWritten);

            byte[] buffer1Array = (byte[])buffer1.GetType().GetField("Array", BindingFlags.Public | BindingFlags.Instance).GetValue(buffer1);
            Assert.AreEqual(0, buffer1Array[0]);
            Assert.AreEqual(0, buffer1Array[399]);

            object buffer2 = rawSegments.GetValue(1);
            int buffer2BytesWritten = (int)buffer2.GetType().GetField("Written", BindingFlags.Public | BindingFlags.Instance).GetValue(buffer2);
            Assert.AreEqual(800, buffer2BytesWritten);

            memory1.Span.Fill(0xFE);

            // Since we didn't advance the public view is still the same
            // but internally we should have stuff written to the first segment
            stream = new MemoryStream(800);
            writer.CopyTo(stream, default);
            Assert.AreEqual(800, stream.Length);
            buffer = stream.GetBuffer();
            Assert.AreEqual(0xFF, buffer[0]);
            Assert.AreEqual(0xFF, buffer[799]);

            buffer1Array = (byte[])buffer1.GetType().GetField("Array", BindingFlags.Public | BindingFlags.Instance).GetValue(buffer1);
            Assert.AreEqual(0xFE, buffer1Array[0]);
            Assert.AreEqual(0xFE, buffer1Array[399]);

            Assert.Throws<ArgumentOutOfRangeException>(() => writer.Advance(400));
        }
    }
}
