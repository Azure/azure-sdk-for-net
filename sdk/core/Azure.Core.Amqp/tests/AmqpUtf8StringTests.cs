// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Runtime.Serialization;
using System.Text;
using Azure.Core.Amqp.Shared;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using NUnit.Framework;

namespace Azure.Core.Amqp.Tests
{
    public class AmqpUtf8StringTests
    {
        [Test]
        public void Utf8ApplicationPropertySample()
        {
            #region Snippet:AmqpUtf8ApplicationProperty
            var message = new AmqpAnnotatedMessage(
                AmqpMessageBody.FromData(new[] { ReadOnlyMemory<byte>.Empty }));
            ReadOnlyMemory<byte> utf8Bytes = Encoding.UTF8.GetBytes("order-created");
            message.ApplicationProperties["eventType"] = AmqpUtf8String.FromBytes(utf8Bytes);
            #endregion
            Assert.AreEqual("order-created", AmqpAnnotatedMessage.FromBytes(message.ToBytes()).ApplicationProperties["eventType"]);
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
            var message = CreateMessage(AmqpUtf8String.FromBytes(default));
            Assert.AreEqual("", AmqpAnnotatedMessage.FromBytes(message.ToBytes()).ApplicationProperties["value"]);
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
            var message = CreateMessage(AmqpUtf8String.FromBytes(bytes));
            bytes[0] = 0xFF;
            Assert.Throws<DecoderFallbackException>(() => message.ToBytes());
        }

        [Test]
        public void BorrowsWithoutCopyingAndCanBeReused()
        {
            byte[] bytes = { (byte)'a' };
            var value = AmqpUtf8String.FromBytes(bytes);
            Assert.AreEqual(bytes, value.Bytes.ToArray());
            Assert.True(AmqpAnnotatedMessageConverter.TryCreateAmqpPropertyValueFromNetProperty(value, out object converted));
            Assert.AreSame(value, converted);
            var message = CreateMessage(value);
            Assert.AreEqual("a", AmqpAnnotatedMessage.FromBytes(message.ToBytes()).ApplicationProperties["value"]);
            bytes[0] = (byte)'b';
            Assert.AreEqual("b", AmqpAnnotatedMessage.FromBytes(message.ToBytes()).ApplicationProperties["value"]);
        }

        [Test]
        public void EncodesNonArrayBackedMemory()
        {
            using var memory = new TestMemoryManager(Encoding.UTF8.GetBytes("caf\u00e9-\u6771\u4eac"));
            var message = CreateMessage(AmqpUtf8String.FromBytes(memory.Memory));
            Assert.AreEqual("caf\u00e9-\u6771\u4eac", AmqpAnnotatedMessage.FromBytes(message.ToBytes()).ApplicationProperties["value"]);
        }

        [Test]
        public void ExistingBinaryAndUnsupportedValuesKeepTheirSemantics()
        {
            byte[] bytes = { (byte)'a' };
            foreach (object value in new object[] { bytes, new ArraySegment<byte>(bytes) })
            {
                var message = CreateMessage(value);
                Assert.AreEqual(bytes, AmqpAnnotatedMessage.FromBytes(message.ToBytes()).ApplicationProperties["value"]);
            }
            Assert.Throws<SerializationException>(() => CreateMessage(new ReadOnlyMemory<byte>(bytes)).ToBytes());
            Assert.Throws<SerializationException>(() => CreateMessage(new CustomSerializer()).ToBytes());
        }

        private static void AssertStringEncoding(string text)
        {
            byte[] padded = Encoding.UTF8.GetBytes("[" + text + "]");
            var bytes = padded.AsMemory(1, padded.Length - 2);
            var value = AmqpUtf8String.FromBytes(bytes);
            Assert.AreEqual(bytes, value.Bytes);
            BinaryData actual = CreateMessage(value).ToBytes();
            BinaryData expected = CreateMessage(text).ToBytes();
            Assert.True(actual.ToMemory().Span.SequenceEqual(expected.ToMemory().Span));
            Assert.AreEqual(text, AmqpAnnotatedMessage.FromBytes(actual).ApplicationProperties["value"]);
        }

        private static AmqpAnnotatedMessage CreateMessage(object value)
        {
            var message = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(Array.Empty<ReadOnlyMemory<byte>>()));
            message.ApplicationProperties["value"] = value;
            return message;
        }

        private sealed class CustomSerializer : IAmqpSerializable
        {
            public int EncodeSize => throw new InvalidOperationException("The converter must reject this type.");
            public void Encode(ByteBuffer buffer) => throw new InvalidOperationException("The converter must reject this type.");
            public void Decode(ByteBuffer buffer) => throw new NotSupportedException();
        }

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
