// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Reflection;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal.ModelReaderWriterTests
{
    public class SequenceBufferWriterTests
    {
        private static readonly FieldInfo _buffersField = typeof(SequenceBufferWriter).GetField("_buffers", BindingFlags.NonPublic | BindingFlags.Instance)!;

        [Test]
        public void ZeroOutAfterGettingReader()
        {
            using SequenceBufferWriter writer = SequenceBufferHelper.SetUpBufferBuilder();
            SequenceBuffer[] buffers = (SequenceBuffer[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.Greater(buffers.Length, 0);

            using SequenceBufferReader reader = writer.GetSequenceBufferReader();
            Assert.IsTrue(reader.TryComputeLength(out long length));
            Assert.AreEqual(100000, length);

            buffers = (SequenceBuffer[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.AreEqual(0, buffers.Length);
        }

        [Test]
        public void CanContinueToWriteAfterZeroOut()
        {
            using SequenceBufferWriter writer = SequenceBufferHelper.SetUpBufferBuilder();
            using SequenceBufferReader reader = writer.GetSequenceBufferReader();

            SequenceBufferHelper.WriteBytes(writer, 0xFF, 110000, 15000);
            SequenceBuffer[] buffers = (SequenceBuffer[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.Greater(buffers.Length, 0);

            using SequenceBufferReader reader2 = writer.GetSequenceBufferReader();
            Assert.IsTrue(reader2.TryComputeLength(out long length));
            Assert.AreEqual(110000, length);

            buffers = (SequenceBuffer[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.AreEqual(0, buffers.Length);
        }

        [Test]
        public void DisposeZerosOutBuffers()
        {
            using SequenceBufferWriter writer = SequenceBufferHelper.SetUpBufferBuilder();
            SequenceBuffer[] buffers = (SequenceBuffer[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.Greater(buffers.Length, 0);

            writer.Dispose();
            buffers = (SequenceBuffer[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.AreEqual(0, buffers.Length);
        }

        [Test]
        public void CanContinueToWriteAfterDispose()
        {
            SequenceBufferWriter writer = SequenceBufferHelper.SetUpBufferBuilder();
            writer.Dispose();

            SequenceBufferHelper.WriteBytes(writer, 0xFF, 110000, 15000);
            SequenceBuffer[] buffers = (SequenceBuffer[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.Greater(buffers.Length, 0);

            using SequenceBufferReader reader = writer.GetSequenceBufferReader();
            Assert.IsTrue(reader.TryComputeLength(out long length));
            Assert.AreEqual(110000, length);

            buffers = (SequenceBuffer[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.AreEqual(0, buffers.Length);
        }
    }
}
