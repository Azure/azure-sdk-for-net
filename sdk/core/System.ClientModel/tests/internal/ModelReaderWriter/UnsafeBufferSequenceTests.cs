// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Reflection;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal.ModelReaderWriterTests
{
    public class UnsafeBufferSequenceTests
    {
        private static readonly FieldInfo _buffersField = typeof(UnsafeBufferSequence).GetField("_buffers", BindingFlags.NonPublic | BindingFlags.Instance)!;

        [Test]
        public void ZeroOutAfterGettingReader()
        {
            using UnsafeBufferSequence writer = UnsafeBufferSequenceHelper.SetUpBufferBuilder();
            ClientModel.Internal.UnsafeBufferSegment[] buffers = (ClientModel.Internal.UnsafeBufferSegment[])_buffersField.GetValue(writer)!;
            Assert.That(buffers, Is.Not.Null);
            Assert.That(buffers.Length, Is.GreaterThan(0));

            using UnsafeBufferSequence.Reader reader = writer.ExtractReader();
            Assert.That(reader.Length, Is.EqualTo(100000));

            buffers = (ClientModel.Internal.UnsafeBufferSegment[])_buffersField.GetValue(writer)!;
            Assert.That(buffers, Is.Not.Null);
            Assert.That(buffers.Length, Is.EqualTo(0));
        }

        [Test]
        public void CanContinueToWriteAfterZeroOut()
        {
            using UnsafeBufferSequence writer = UnsafeBufferSequenceHelper.SetUpBufferBuilder();
            using UnsafeBufferSequence.Reader reader = writer.ExtractReader();

            UnsafeBufferSequenceHelper.WriteBytes(writer, 0xFF, 110000, 15000);
            ClientModel.Internal.UnsafeBufferSegment[] buffers = (ClientModel.Internal.UnsafeBufferSegment[])_buffersField.GetValue(writer)!;
            Assert.That(buffers, Is.Not.Null);
            Assert.That(buffers.Length, Is.GreaterThan(0));

            using UnsafeBufferSequence.Reader reader2 = writer.ExtractReader();
            Assert.That(reader2.Length, Is.EqualTo(110000));

            buffers = (ClientModel.Internal.UnsafeBufferSegment[])_buffersField.GetValue(writer)!;
            Assert.That(buffers, Is.Not.Null);
            Assert.That(buffers.Length, Is.EqualTo(0));
        }

        [Test]
        public void DisposeZerosOutBuffers()
        {
            using UnsafeBufferSequence writer = UnsafeBufferSequenceHelper.SetUpBufferBuilder();
            ClientModel.Internal.UnsafeBufferSegment[] buffers = (ClientModel.Internal.UnsafeBufferSegment[])_buffersField.GetValue(writer)!;
            Assert.That(buffers, Is.Not.Null);
            Assert.That(buffers.Length, Is.GreaterThan(0));

            writer.Dispose();
            buffers = (ClientModel.Internal.UnsafeBufferSegment[])_buffersField.GetValue(writer)!;
            Assert.That(buffers, Is.Not.Null);
            Assert.That(buffers.Length, Is.EqualTo(0));
        }

        [Test]
        public void CanContinueToWriteAfterDispose()
        {
            UnsafeBufferSequence writer = UnsafeBufferSequenceHelper.SetUpBufferBuilder();
            writer.Dispose();

            UnsafeBufferSequenceHelper.WriteBytes(writer, 0xFF, 110000, 15000);
            ClientModel.Internal.UnsafeBufferSegment[] buffers = (ClientModel.Internal.UnsafeBufferSegment[])_buffersField.GetValue(writer)!;
            Assert.That(buffers, Is.Not.Null);
            Assert.That(buffers.Length, Is.GreaterThan(0));

            using UnsafeBufferSequence.Reader reader = writer.ExtractReader();
            Assert.That(reader.Length, Is.EqualTo(110000));

            buffers = (ClientModel.Internal.UnsafeBufferSegment[])_buffersField.GetValue(writer)!;
            Assert.That(buffers, Is.Not.Null);
            Assert.That(buffers.Length, Is.EqualTo(0));
        }
    }
}
