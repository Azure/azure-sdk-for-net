// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Text;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;
using NUnit.Framework;

namespace Azure.Core.Amqp.Tests
{
    public class AmqpUtf8StringEncodingTests
    {
        [Test]
        public void Utf8DescriptorSample()
        {
            #region Snippet:AmqpUtf8StringDescriptor
            ReadOnlyMemory<byte> utf8Bytes = Encoding.UTF8.GetBytes("order-created");
            AmqpUtf8String value = AmqpUtf8String.FromBytes(utf8Bytes);
            #endregion
            Assert.AreEqual(utf8Bytes, value.Bytes);
        }

        [TestCase("")]
        [TestCase("ascii")]
        [TestCase("caf\u00e9-\u6771\u4eac")]
        [TestCase("\0\U0001F680")]
        public void RoundTripsAsString(string text)
        {
            AssertStringEncoding(text);
        }

        [TestCase(254)]
        [TestCase(255)]
        [TestCase(256)]
        [TestCase(257)]
        [TestCase(1024)]
        public void PreservesStringEncodingBoundaries(int length)
        {
            AssertStringEncoding(new string('a', length));
            AssertStringEncoding(new string('\u00e9', length / 2) + (length % 2 == 0 ? "" : "a"));
        }

        [Test]
        public void DefaultMemoryRepresentsEmptyString()
        {
            Assert.AreEqual("", ReadValue(Serialize(AmqpUtf8String.FromBytes(default))));
        }

        [TestCase(new byte[] { 0xC3, 0x28 })]
        [TestCase(new byte[] { 0xC0, 0xAF })]
        [TestCase(new byte[] { 0xED, 0xA0, 0x80 })]
        [TestCase(new byte[] { 0xF4, 0x90, 0x80, 0x80 })]
        [TestCase(new byte[] { 0xE2, 0x82 })]
        public void RejectsInvalidUtf8(byte[] bytes)
        {
            var exception = Assert.Throws<ArgumentException>(() => AmqpUtf8String.FromBytes(bytes));
            Assert.AreEqual("bytes", exception.ParamName);
            Assert.IsInstanceOf<DecoderFallbackException>(exception.InnerException);
        }

        [Test]
        public void RevalidatesBorrowedBytesAtEncoding()
        {
            byte[] bytes = { (byte)'a', (byte)'b' };
            var value = AmqpUtf8String.FromBytes(bytes);
            bytes[0] = 0xFF;
            Assert.Throws<DecoderFallbackException>(() => Serialize(value));
        }

        [Test]
        public void BorrowsWithoutCopyingAndCanBeReused()
        {
            byte[] bytes = { (byte)'a' };
            var value = AmqpUtf8String.FromBytes(bytes);
            Assert.AreEqual(bytes, value.Bytes.ToArray());
            Assert.AreEqual("a", ReadValue(Serialize(value)));
            bytes[0] = (byte)'b';
            Assert.AreEqual("b", ReadValue(Serialize(value)));
        }

        [Test]
        public void EncodesNonArrayBackedMemory()
        {
            using var memory = new TestMemoryManager(Encoding.UTF8.GetBytes("caf\u00e9-\u6771\u4eac"));
            var value = AmqpUtf8String.FromBytes(memory.Memory);
            Assert.AreEqual("caf\u00e9-\u6771\u4eac", ReadValue(Serialize(value)));
        }

        private static void AssertStringEncoding(string text)
        {
            byte[] padded = Encoding.UTF8.GetBytes("[" + text + "]");
            var bytes = padded.AsMemory(1, padded.Length - 2);
            var value = AmqpUtf8String.FromBytes(bytes);
            Assert.AreEqual(bytes, value.Bytes);
            BinaryData actual = Serialize(value);
            BinaryData expected = Serialize(text);
            Assert.True(actual.ToMemory().Span.SequenceEqual(expected.ToMemory().Span));
            Assert.AreEqual(text, ReadValue(actual));
        }

        private static BinaryData Serialize(object value)
        {
            using var message = AmqpMessage.Create(
                new Data { Value = new ArraySegment<byte>(Array.Empty<byte>()) });
            message.ApplicationProperties.Map["value"] = value;
            using var stream = message.ToStream();
            return BinaryData.FromStream(stream);
        }

        private static object ReadValue(BinaryData bytes) =>
            AmqpAnnotatedMessage.FromBytes(bytes).ApplicationProperties["value"];

        private sealed class TestMemoryManager : MemoryManager<byte>
        {
            private readonly byte[] _bytes;
            public TestMemoryManager(byte[] bytes) => _bytes = bytes;
            public override Span<byte> GetSpan() => _bytes;
            public override MemoryHandle Pin(int elementIndex = 0) => throw new NotSupportedException();
            public override void Unpin() { }
            protected override void Dispose(bool disposing) { }
        }
    }
}
