// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    internal class SequenceWriterTests
    {
        [Test]
        public void ValidateEmptyBuffer()
        {
            SequenceWriter writer = new SequenceWriter();
            Assert.IsTrue(writer.TryComputeLength(out var length));
            Assert.AreEqual(0, length);
            Assert.AreEqual(ReadOnlySequence<byte>.Empty, writer.GetReadOnlySequence());
        }

        [Test]
        public void ValidateSingleBuffer()
        {
            SequenceWriter writer = new SequenceWriter(512);
            WriteMemory(writer, 400, 0xFF);

            var sequence = writer.GetReadOnlySequence();

            Assert.AreEqual(400, sequence.Length);
            Assert.AreEqual(0xFF, sequence.First.Span[0]);
            Assert.AreEqual(0xFF, sequence.Slice(399).First.Span[0]);
        }

        [Test]
        public void ValidateMultiBuffer()
        {
            SequenceWriter writer = new SequenceWriter(512);
            WriteMemory(writer, 400, 0xFF);
            WriteMemory(writer, 400, 0xFF);

            var sequence = writer.GetReadOnlySequence();

            Assert.AreEqual(800, sequence.Length);
            Assert.AreEqual(0xFF, sequence.First.Span[0]);
            Assert.AreEqual(0xFF, sequence.Slice(399).First.Span[0]);
            Assert.AreEqual(0xFF, sequence.Slice(400).First.Span[0]);
            Assert.AreEqual(0xFF, sequence.Slice(799).First.Span[0]);
        }

        [Test]
        public void CanWriteMoreThanBufferSize()
        {
            SequenceWriter writer = new SequenceWriter(512);
            WriteMemory(writer, 513, 0xFF);
            WriteMemory(writer, 256, 0xFE);

            Assert.IsTrue(writer.TryComputeLength(out var length));
            Assert.AreEqual(769, length);

            var sequence = writer.GetReadOnlySequence();
            Assert.AreEqual(769, sequence.Length);
            Assert.AreEqual(0xFF, sequence.First.Span[0]);
            Assert.AreEqual(0xFE, sequence.Slice(514).First.Span[0]);
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
            var memory = writer.GetMemory(size);
            memory.Span.Slice(0, size).Fill(data);
            writer.Advance(size);
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
