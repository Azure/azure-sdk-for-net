// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Queues.Models;
using NUnit.Framework;

namespace Azure.Storage.Queues.Tests
{
    public class QueueMessageCodecTests
    {
        #region EncodeMessageBody - None encoding
        [Test]
        public void EncodeMessageBody_None_ReturnsPlainText()
        {
            var body = new BinaryData("hello world");

            var result = QueueMessageCodec.EncodeMessageBody(body, QueueMessageEncoding.None);

            Assert.AreEqual("hello world", result);
        }

        [Test]
        public void EncodeMessageBody_None_NullReturnsNull()
        {
            var result = QueueMessageCodec.EncodeMessageBody(null, QueueMessageEncoding.None);

            Assert.IsNull(result);
        }

        [Test]
        public void EncodeMessageBody_None_EmptyString()
        {
            var body = new BinaryData(string.Empty);

            var result = QueueMessageCodec.EncodeMessageBody(body, QueueMessageEncoding.None);

            Assert.AreEqual(string.Empty, result);
        }
        #endregion

        #region EncodeMessageBody - Base64 encoding
        [Test]
        public void EncodeMessageBody_Base64_ReturnsBase64String()
        {
            var body = new BinaryData("hello world");

            var result = QueueMessageCodec.EncodeMessageBody(body, QueueMessageEncoding.Base64);

            Assert.AreEqual(Convert.ToBase64String(body.ToArray()), result);
        }

        [Test]
        public void EncodeMessageBody_Base64_NullReturnsNull()
        {
            var result = QueueMessageCodec.EncodeMessageBody(null, QueueMessageEncoding.Base64);

            Assert.IsNull(result);
        }

        [Test]
        public void EncodeMessageBody_Base64_EmptyBytes()
        {
            var body = new BinaryData(Array.Empty<byte>());

            var result = QueueMessageCodec.EncodeMessageBody(body, QueueMessageEncoding.Base64);

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void EncodeMessageBody_Base64_BinaryContent()
        {
            var bytes = new byte[] { 0x00, 0x01, 0xFF, 0xFE };
            var body = new BinaryData(bytes);

            var result = QueueMessageCodec.EncodeMessageBody(body, QueueMessageEncoding.Base64);

            Assert.AreEqual(Convert.ToBase64String(bytes), result);
        }
        #endregion

        #region EncodeMessageBody - Invalid encoding
        [Test]
        public void EncodeMessageBody_InvalidEncoding_Throws()
        {
            var body = new BinaryData("hello");

            Assert.Throws<ArgumentException>(() =>
                QueueMessageCodec.EncodeMessageBody(body, (QueueMessageEncoding)999));
        }
        #endregion

        #region DecodeMessageBody - None encoding
        [Test]
        public void DecodeMessageBody_None_ReturnsBinaryData()
        {
            var result = QueueMessageCodec.DecodeMessageBody("hello world", QueueMessageEncoding.None);

            Assert.AreEqual("hello world", result.ToString());
        }

        [Test]
        public void DecodeMessageBody_None_NullReturnsEmpty()
        {
            var result = QueueMessageCodec.DecodeMessageBody(null, QueueMessageEncoding.None);

            Assert.AreEqual(string.Empty, result.ToString());
        }

        [Test]
        public void DecodeMessageBody_None_EmptyString()
        {
            var result = QueueMessageCodec.DecodeMessageBody(string.Empty, QueueMessageEncoding.None);

            Assert.AreEqual(string.Empty, result.ToString());
        }
        #endregion

        #region DecodeMessageBody - Base64 encoding
        [Test]
        public void DecodeMessageBody_Base64_DecodesCorrectly()
        {
            var originalText = "hello world";
            var base64Text = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(originalText));

            var result = QueueMessageCodec.DecodeMessageBody(base64Text, QueueMessageEncoding.Base64);

            Assert.AreEqual(originalText, result.ToString());
        }

        [Test]
        public void DecodeMessageBody_Base64_NullReturnsEmpty()
        {
            var result = QueueMessageCodec.DecodeMessageBody(null, QueueMessageEncoding.Base64);

            Assert.AreEqual(string.Empty, result.ToString());
        }

        [Test]
        public void DecodeMessageBody_Base64_BinaryContent()
        {
            var bytes = new byte[] { 0x00, 0x01, 0xFF, 0xFE };
            var base64Text = Convert.ToBase64String(bytes);

            var result = QueueMessageCodec.DecodeMessageBody(base64Text, QueueMessageEncoding.Base64);

            CollectionAssert.AreEqual(bytes, result.ToArray());
        }
        #endregion

        #region DecodeMessageBody - Invalid encoding
        [Test]
        public void DecodeMessageBody_InvalidEncoding_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
                QueueMessageCodec.DecodeMessageBody("hello", (QueueMessageEncoding)999));
        }
        #endregion

        #region Round-trip tests
        [Test]
        public void RoundTrip_None_PreservesText()
        {
            var original = new BinaryData("hello world");

            var encoded = QueueMessageCodec.EncodeMessageBody(original, QueueMessageEncoding.None);
            var decoded = QueueMessageCodec.DecodeMessageBody(encoded, QueueMessageEncoding.None);

            Assert.AreEqual(original.ToString(), decoded.ToString());
        }

        [Test]
        public void RoundTrip_Base64_PreservesBytes()
        {
            var bytes = new byte[] { 0x00, 0x01, 0x02, 0xFF };
            var original = new BinaryData(bytes);

            var encoded = QueueMessageCodec.EncodeMessageBody(original, QueueMessageEncoding.Base64);
            var decoded = QueueMessageCodec.DecodeMessageBody(encoded, QueueMessageEncoding.Base64);

            CollectionAssert.AreEqual(bytes, decoded.ToArray());
        }

        [Test]
        public void RoundTrip_Base64_PreservesText()
        {
            var original = new BinaryData("hello world");

            var encoded = QueueMessageCodec.EncodeMessageBody(original, QueueMessageEncoding.Base64);
            var decoded = QueueMessageCodec.DecodeMessageBody(encoded, QueueMessageEncoding.Base64);

            Assert.AreEqual(original.ToString(), decoded.ToString());
        }
        #endregion
    }
}
