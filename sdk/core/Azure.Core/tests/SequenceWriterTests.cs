// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    /// <summary>
    /// Uses unique bytes in the memory in each test to better debug any issues with tests not
    /// being fully cleaned up and affecting other tests.
    /// </summary>
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
            WriteMemory(writer, 400, 0xFE);
            WriteMemory(writer, 400, 0xFE);

            Assert.IsTrue(writer.TryComputeLength(out var length));
            Assert.AreEqual(800, length);
        }

        [Test]
        public void CanWriteMoreThanBufferSize()
        {
            using SequenceWriter writer = new SequenceWriter(512);
            WriteMemory(writer, 513, 0xFD);
            WriteMemory(writer, 256, 0xFD);

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
            memory.Span.Fill(0xAA);
        }

        [Test]
        public async Task DisposedWhileCopying()
        {
            int segments = 10000;
            int segmentSize = 400;
            SequenceWriter writer = new SequenceWriter(512);
            for (int i = 0; i < segments; i++)
            {
                WriteMemory(writer, segmentSize, 0xFC);
            }

            Assert.IsTrue(writer.TryComputeLength(out var length));
            Assert.AreEqual(segments * segmentSize, length);

            using MemoryStream memory = new MemoryStream((int)length);
            Task result = Task.Run(() => { return writer.CopyToAsync(memory, default); });

            // wait for the writing to start
            while (memory.Length == 0)
            { }

            writer.Dispose();

            //Assert.IsTrue(writer.TryComputeLength(out length));
            //Assert.AreEqual(0, length);

            SequenceWriter writer2 = new SequenceWriter(512);
            Task result2 = Task.Run(() =>
            {
                for (int i = 0; i < segments; i++)
                {
                    WriteMemory(writer2, segmentSize, 0xFB);
                }
            });

            await result;
            await result2;

            // because the writer was disposed in the middle of copying to a stream
            // the length will be less than expected
            // only a portion of the writer was copied to the stream before the dispose
            // no exception is thrown here because the writer is not thread safe
            Assert.Greater(memory.Length, 0);
            Assert.LessOrEqual(memory.Length, length); // in rare cases it can be equal
            byte[] memoryStreamBuffer = memory.GetBuffer();
            for (int i = 0; i < memory.Length; i++)
            {
                // sometimes fails due to rerent, dispose doesn't wait for copies to finish
                // failed on 102nd try
                Assert.AreEqual(0xFC, memoryStreamBuffer[i]);
            }
            writer2.Dispose();
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
                        WriteMemory(writer, segmentSize, 0xFA);
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
            WriteMemory(writer, 400, 0xF9);
            Assert.IsTrue(writer.TryComputeLength(out length));
            Assert.AreEqual(400, length);

            writer.Dispose();
        }

        [Test]
        public void GetExceptionWhenDisposedMulti()
        {
            SequenceWriter writer = new SequenceWriter(512);
            WriteMemory(writer, 400, 0xFF);
            WriteMemory(writer, 400, 0xFE);
            var sequence = writer.GetReadOnlySequence();
            var s = writer.GetReadOnlySequence();

            writer.Dispose();

            var x = sequence.Length;
            Assert.DoesNotThrow(() => { var x = sequence.Length; });
            Assert.Throws<IndexOutOfRangeException>(() => { var x = sequence.First.Span[0]; });
            Assert.Throws<ArgumentOutOfRangeException>(() => { var x = sequence.Slice(513).First.Span[0]; });
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
            memory2.Span.Fill(0xF8);
            writer.Advance(400);

            MemoryStream stream = new MemoryStream(400);
            writer.CopyTo(stream, default);
            Assert.AreEqual(400, stream.Length);
            byte[] buffer = stream.GetBuffer();

            // even though we write to the second memory buffer the first segment had 0 written bytes
            Assert.AreEqual(0xF8, buffer[0]);
            Assert.AreEqual(0xF8, buffer[399]);

            Array rawSegments = writer.GetType().GetField("_buffers", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(writer) as Array;
            // we should have 1 segment since the two memory objects should be pointed at the same place
            Assert.AreEqual(1, rawSegments.Length);

            memory1.Span.Fill(0xF7);

            stream = new MemoryStream(400);
            writer.CopyTo(stream, default);
            Assert.AreEqual(400, stream.Length);
            buffer = stream.GetBuffer();

            // without advancing since the first and second Memory pointed to the same place
            // we have replaced what was there
            Assert.AreEqual(0xF7, buffer[0]);
            Assert.AreEqual(0xF7, buffer[399]);

            Assert.Throws<ArgumentOutOfRangeException>(() => writer.Advance(400));
        }

        [Test]
        public void GetMultipleMemoryMultipleSegmentWithoutAdvance()
        {
            using SequenceWriter writer = new SequenceWriter(512);
            Memory<byte> memory1 = writer.GetMemory(400);
            memory1.Span.Fill(0); //zero it out for validation later

            // should we throw here on the second GetMemory without calling Advance?
            // It seems that you should not be able to get more memory without advancing
            // If we did this perhaps we could eliminate the use-after-free and worst case leak
            // one segment that doesn't get disposed
            Memory<byte> memory2 = writer.GetMemory(800);
            memory2.Span.Fill(0xF6);
            writer.Advance(800);

            MemoryStream stream = new MemoryStream(800);
            writer.CopyTo(stream, default);
            Assert.AreEqual(800, stream.Length);
            byte[] buffer = stream.GetBuffer();

            // even though we write to the second memory buffer the first segment had 0 written bytes
            Assert.AreEqual(0xF6, buffer[0]);
            Assert.AreEqual(0xF6, buffer[799]);

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

            byte[] buffer2Array = (byte[])buffer2.GetType().GetField("Array", BindingFlags.Public | BindingFlags.Instance).GetValue(buffer2);

            memory1.Span.Fill(0xF5);

            // Since we didn't advance the public view is still the same
            // but internally we should have stuff written to the first segment
            stream = new MemoryStream(800);
            writer.CopyTo(stream, default);
            Assert.AreEqual(800, stream.Length);
            buffer = stream.GetBuffer();
            Assert.AreEqual(0xF6, buffer[0]);
            Assert.AreEqual(0xF6, buffer[799]);

            buffer1Array = (byte[])buffer1.GetType().GetField("Array", BindingFlags.Public | BindingFlags.Instance).GetValue(buffer1);
            Assert.AreEqual(0xF5, buffer1Array[0]);
            Assert.AreEqual(0xF5, buffer1Array[399]);

            if (buffer2Array.Length < 1200) //sometimes the buffer will be big enough
                Assert.Throws<ArgumentOutOfRangeException>(() => writer.Advance(400));
        }

        [Test]
        public void GetExceptionWhenDisposedSingle()
        {
            SequenceWriter writer = new SequenceWriter(512);
            WriteMemory(writer, 400, 0xFF);
            var sequence = writer.GetReadOnlySequence();

            writer.Dispose();

            Assert.DoesNotThrow(() => { var x = sequence.Length; });
            Assert.Throws<ArgumentOutOfRangeException>(() => { var x = sequence.First.Span[0]; });
            Assert.Throws<ArgumentOutOfRangeException>(() => { var x = sequence.Slice(350).First.Span[0]; });
        }

        [Test]
        public void ValidateUseOnMemoryRef()
        {
            SequenceWriter writer = new SequenceWriter(512);
            WriteMemory(writer, 400, 0xFF);
            var sequence = writer.GetReadOnlySequence();
            var memory = sequence.First;

            writer.Dispose();

            Assert.DoesNotThrow(() => { var x = sequence.Length; });

            //access through the sequence will fail since the segments are disposed
            Assert.Throws<ArgumentOutOfRangeException>(() => { var x = sequence.First.Span[0]; });
            Assert.Throws<ArgumentOutOfRangeException>(() => { var x = sequence.Slice(350).First.Span[0]; });

            //can still read memory if the reference is kept
            Assert.AreEqual(0xFF, memory.Span[0]);
            Assert.AreEqual(0xFF, memory.Span[399]);
        }

        [Test]
        public void GetExceptionWhenDisposedMultiSequence()
        {
            SequenceWriter writer = new SequenceWriter(512);
            WriteMemory(writer, 400, 0xFF);
            WriteMemory(writer, 400, 0xFF);
            var sequence1 = writer.GetReadOnlySequence();
            WriteMemory(writer, 400, 0xFF);
            var sequence2 = writer.GetReadOnlySequence();

            writer.Dispose();

            Assert.DoesNotThrow(() => { var x = sequence1.Length; });
            Assert.Throws<IndexOutOfRangeException>(() => { var x = sequence1.First.Span[0]; });
            Assert.Throws<ArgumentOutOfRangeException>(() => { var x = sequence1.Slice(513).First.Span[0]; });

            Assert.DoesNotThrow(() => { var x = sequence2.Length; });
            Assert.Throws<IndexOutOfRangeException>(() => { var x = sequence2.First.Span[0]; });
            Assert.Throws<ArgumentOutOfRangeException>(() => { var x = sequence2.Slice(513).First.Span[0]; });
        }
    }
}
