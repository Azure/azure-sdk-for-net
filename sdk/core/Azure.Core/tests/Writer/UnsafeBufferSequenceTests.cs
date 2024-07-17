// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using NUnit.Framework;

#nullable enable

namespace Azure.Core.Tests
{
    public class UnsafeBufferSequenceTests
    {
        private static readonly FieldInfo _buffersField = typeof(UnsafeBufferSequence).GetField("_buffers", BindingFlags.NonPublic | BindingFlags.Instance)!;

        [Test]
        public void ZeroOutAfterGettingReader()
        {
            using UnsafeBufferSequence writer = UnsafeBufferSequenceHelper.SetUpBufferBuilder();
            UnsafeBufferSegment[] buffers = (UnsafeBufferSegment[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.Greater(buffers.Length, 0);

            using UnsafeBufferSequence.Reader reader = writer.ExtractReader();
            Assert.AreEqual(100000, reader.Length);

            buffers = (UnsafeBufferSegment[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.AreEqual(0, buffers.Length);
        }

        [Test]
        public void CanContinueToWriteAfterZeroOut()
        {
            using UnsafeBufferSequence writer = UnsafeBufferSequenceHelper.SetUpBufferBuilder();
            using UnsafeBufferSequence.Reader reader = writer.ExtractReader();

            UnsafeBufferSequenceHelper.WriteBytes(writer, 0xFF, 110000, 15000);
            UnsafeBufferSegment[] buffers = (UnsafeBufferSegment[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.Greater(buffers.Length, 0);

            using UnsafeBufferSequence.Reader reader2 = writer.ExtractReader();
            Assert.AreEqual(110000, reader2.Length);

            buffers = (UnsafeBufferSegment[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.AreEqual(0, buffers.Length);
        }

        [Test]
        public void DisposeZerosOutBuffers()
        {
            using UnsafeBufferSequence writer = UnsafeBufferSequenceHelper.SetUpBufferBuilder();
            UnsafeBufferSegment[] buffers = (UnsafeBufferSegment[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.Greater(buffers.Length, 0);

            writer.Dispose();
            buffers = (UnsafeBufferSegment[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.AreEqual(0, buffers.Length);
        }

        [Test]
        public void CanContinueToWriteAfterDispose()
        {
            UnsafeBufferSequence writer = UnsafeBufferSequenceHelper.SetUpBufferBuilder();
            writer.Dispose();

            UnsafeBufferSequenceHelper.WriteBytes(writer, 0xFF, 110000, 15000);
            UnsafeBufferSegment[] buffers = (UnsafeBufferSegment[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.Greater(buffers.Length, 0);

            using UnsafeBufferSequence.Reader reader = writer.ExtractReader();
            Assert.AreEqual(110000, reader.Length);

            buffers = (UnsafeBufferSegment[])_buffersField.GetValue(writer)!;
            Assert.IsNotNull(buffers);
            Assert.AreEqual(0, buffers.Length);
        }
    }
}
