// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Reflection;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal.ModelReaderWriterTests
{
    public class BufferSequenceTests
    {
        private static readonly FieldInfo _buffersField = typeof(BufferSequence).GetField("_buffers", BindingFlags.NonPublic | BindingFlags.Instance)!;

        [Test]
        public void ZeroOutAfterGettingReader()
        {
            using BufferSequence writer = BufferSequenceHelper.SetUpBufferBuilder();
            ClientModel.Internal.BufferSegment[] buffers = (ClientModel.Internal.BufferSegment[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.Greater(buffers.Length, 0);

            using BufferSequence.Reader reader = writer.ExtractSequenceBufferReader();
            Assert.IsTrue(reader.TryComputeLength(out long length));
            Assert.AreEqual(100000, length);

            buffers = (ClientModel.Internal.BufferSegment[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.AreEqual(0, buffers.Length);
        }

        [Test]
        public void CanContinueToWriteAfterZeroOut()
        {
            using BufferSequence writer = BufferSequenceHelper.SetUpBufferBuilder();
            using BufferSequence.Reader reader = writer.ExtractSequenceBufferReader();

            BufferSequenceHelper.WriteBytes(writer, 0xFF, 110000, 15000);
            ClientModel.Internal.BufferSegment[] buffers = (ClientModel.Internal.BufferSegment[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.Greater(buffers.Length, 0);

            using BufferSequence.Reader reader2 = writer.ExtractSequenceBufferReader();
            Assert.IsTrue(reader2.TryComputeLength(out long length));
            Assert.AreEqual(110000, length);

            buffers = (ClientModel.Internal.BufferSegment[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.AreEqual(0, buffers.Length);
        }

        [Test]
        public void DisposeZerosOutBuffers()
        {
            using BufferSequence writer = BufferSequenceHelper.SetUpBufferBuilder();
            ClientModel.Internal.BufferSegment[] buffers = (ClientModel.Internal.BufferSegment[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.Greater(buffers.Length, 0);

            writer.Dispose();
            buffers = (ClientModel.Internal.BufferSegment[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.AreEqual(0, buffers.Length);
        }

        [Test]
        public void CanContinueToWriteAfterDispose()
        {
            BufferSequence writer = BufferSequenceHelper.SetUpBufferBuilder();
            writer.Dispose();

            BufferSequenceHelper.WriteBytes(writer, 0xFF, 110000, 15000);
            ClientModel.Internal.BufferSegment[] buffers = (ClientModel.Internal.BufferSegment[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.Greater(buffers.Length, 0);

            using BufferSequence.Reader reader = writer.ExtractSequenceBufferReader();
            Assert.IsTrue(reader.TryComputeLength(out long length));
            Assert.AreEqual(110000, length);

            buffers = (ClientModel.Internal.BufferSegment[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.AreEqual(0, buffers.Length);
        }
    }
}
