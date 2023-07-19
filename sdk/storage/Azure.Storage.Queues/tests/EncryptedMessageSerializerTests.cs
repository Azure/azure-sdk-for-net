// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Azure.Core;
using Azure.Core.Cryptography;
using Azure.Core.Pipeline;
using Azure.Storage.Cryptography;
using Azure.Storage.Cryptography.Models;
using Azure.Storage.Queues.Specialized.Models;
using Moq;
using NUnit.Framework;
using static Moq.It;

namespace Azure.Storage.Queues.Test
{
#pragma warning disable CS0618 // obsolete
    [TestFixture(ClientSideEncryptionVersion.V1_0)]
    [TestFixture(ClientSideEncryptionVersion.V2_0)]
#pragma warning restore CS0618 // obsolete
    public class EncryptedMessageSerializerTests // doesn't inherit our test base because there are no network tests
    {
        private const string TestMessage = "This can technically be a valid encrypted message.";
        private const string KeyWrapAlgorithm = "my_key_wrap_algorithm";

        private readonly ClientSideEncryptionVersion _version;

        public EncryptedMessageSerializerTests(ClientSideEncryptionVersion version)
        {
            _version = version;
        }

        private Mock<IKeyEncryptionKey> GetIKeyEncryptionKey(byte[] userKeyBytes = default, string keyId = default)
        {
            if (userKeyBytes == default)
            {
                const int keySizeBits = 256;
                var bytes = new byte[keySizeBits >> 3];
#if NET6_0_OR_GREATER
                RandomNumberGenerator.Create().GetBytes(bytes);
#else
                new RNGCryptoServiceProvider().GetBytes(bytes);
#endif
                userKeyBytes = bytes;
            }
            keyId ??= Guid.NewGuid().ToString();

            var keyMock = new Mock<IKeyEncryptionKey>(MockBehavior.Strict);
            keyMock.SetupGet(k => k.KeyId).Returns(keyId);
            keyMock.Setup(k => k.WrapKey(KeyWrapAlgorithm, IsNotNull<ReadOnlyMemory<byte>>(), IsAny<CancellationToken>()))
                .Returns<string, ReadOnlyMemory<byte>, CancellationToken>((algorithm, key, cancellationToken) => Xor(userKeyBytes, key.ToArray()));
            keyMock.Setup(k => k.UnwrapKey(KeyWrapAlgorithm, IsNotNull<ReadOnlyMemory<byte>>(), IsAny<CancellationToken>()))
                .Returns<string, ReadOnlyMemory<byte>, CancellationToken>((algorithm, wrappedKey, cancellationToken) => Xor(userKeyBytes, userKeyBytes.ToArray()));

            return keyMock;
        }
        private static byte[] Xor(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
            {
                throw new ArgumentException("Keys must be the same length for this mock implementation.");
            }

            var aBits = new System.Collections.BitArray(a);
            var bBits = new System.Collections.BitArray(b);

            var result = new byte[a.Length];
            aBits.Xor(bBits).CopyTo(result, 0);

            return result;
        }

        [Test]
        public void SerializeEncryptedMessage()
        {
            var result = new ClientSideEncryptorV1_0(new ClientSideEncryptionOptions(_version)
            {
                KeyEncryptionKey = GetIKeyEncryptionKey().Object,
                KeyWrapAlgorithm = KeyWrapAlgorithm
            }).BufferedEncryptInternal(
                new MemoryStream(Encoding.UTF8.GetBytes(TestMessage)),
                async: false,
                default).EnsureCompleted();
            var encryptedMessage = new EncryptedMessage()
            {
                EncryptedMessageText = Convert.ToBase64String(result.Ciphertext),
                EncryptionData = result.EncryptionData
            };

            var serializedMessage = EncryptedMessageSerializer.Serialize(encryptedMessage);

            // success = don't throw. test values in another test with deserialization (can't control serialization order)
        }

        [Test]
        public void DeserializeEncryptedMessage()
        {
            var result = new ClientSideEncryptorV1_0(new ClientSideEncryptionOptions(_version)
            {
                KeyEncryptionKey = GetIKeyEncryptionKey().Object,
                KeyWrapAlgorithm = KeyWrapAlgorithm
            }).BufferedEncryptInternal(
                new MemoryStream(Encoding.UTF8.GetBytes(TestMessage)),
                async: false,
                default).EnsureCompleted();
            var encryptedMessage = new EncryptedMessage()
            {
                EncryptedMessageText = Convert.ToBase64String(result.Ciphertext),
                EncryptionData = result.EncryptionData
            };
            var serializedMessage = EncryptedMessageSerializer.Serialize(encryptedMessage);

            var parsedEncryptedMessage = EncryptedMessageSerializer.Deserialize(serializedMessage);

            Assert.IsTrue(AreEqual(encryptedMessage, parsedEncryptedMessage));
        }

        [Test]
        public void TryDeserializeEncryptedMessage()
        {
            var result = new ClientSideEncryptorV1_0(new ClientSideEncryptionOptions(_version)
            {
                KeyEncryptionKey = GetIKeyEncryptionKey().Object,
                KeyWrapAlgorithm = KeyWrapAlgorithm
            }).BufferedEncryptInternal(
                new MemoryStream(Encoding.UTF8.GetBytes(TestMessage)),
                async: false,
                default).EnsureCompleted();
            var encryptedMessage = new EncryptedMessage()
            {
                EncryptedMessageText = Convert.ToBase64String(result.Ciphertext),
                EncryptionData = result.EncryptionData
            };
            var serializedMessage = EncryptedMessageSerializer.Serialize(encryptedMessage);

            bool tryResult = EncryptedMessageSerializer.TryDeserialize(serializedMessage, out var parsedEncryptedMessage);

            Assert.AreEqual(true, tryResult);
            Assert.IsTrue(AreEqual(encryptedMessage, parsedEncryptedMessage));
        }

        [TestCase("")]
        [TestCase("\"aa\"")] // real world example
        [TestCase("{\"key1\":\"value1\",\"key2\":\"value2\"}")] // more typical json object, but not the actual schema we're looking for
        [TestCase("{\"EncryptedMessageContents\":\"value1\",\"key2\":\"value2\"}")] // one required piece but not the other
        [TestCase("{\"EncryptionData\":{},\"key2\":\"value2\"}")] // one required piece but not the other
        [TestCase("this is not even valid json")]
        [TestCase("ᛁᚳ᛫ᛗᚨᚷ᛫ᚷᛚᚨᛋ᛫ᛖᚩᛏᚪᚾ᛫ᚩᚾᛞ᛫ᚻᛁᛏ᛫ᚾᛖ᛫ᚻᛖᚪᚱᛗᛁᚪᚧ᛫ᛗᛖ")]
        public void TryDeserializeGracefulOnBadInput(string input)
        {
            bool tryResult = EncryptedMessageSerializer.TryDeserialize(new BinaryData(input), out var parsedEncryptedMessage);

            Assert.AreEqual(false, tryResult);
            Assert.IsNull(parsedEncryptedMessage?.EncryptedMessageText);
            Assert.IsNull(parsedEncryptedMessage?.EncryptionData);
            Assert.IsNull(parsedEncryptedMessage);
        }

        #region ModelComparison
        private static bool AreEqual(EncryptedMessage left, EncryptedMessage right)
            => left.EncryptedMessageText.Equals(right.EncryptedMessageText, StringComparison.InvariantCulture)
            && AreEqual(left.EncryptionData, right.EncryptionData);

        private static bool AreEqual(EncryptionData left, EncryptionData right)
            => left.EncryptionMode.Equals(right.EncryptionMode, StringComparison.InvariantCulture)
            && AreEqual(left.WrappedContentKey, right.WrappedContentKey)
            && AreEqual(left.EncryptionAgent, right.EncryptionAgent)
            && left.ContentEncryptionIV.SequenceEqual(right.ContentEncryptionIV)
            && AreEqual(left.KeyWrappingMetadata, right.KeyWrappingMetadata);

        private static bool AreEqual(KeyEnvelope left, KeyEnvelope right)
            => left.KeyId.Equals(right.KeyId, StringComparison.InvariantCulture)
            && left.EncryptedKey.SequenceEqual(right.EncryptedKey)
            && left.Algorithm.Equals(right.Algorithm, StringComparison.InvariantCulture);

        private static bool AreEqual(EncryptionAgent left, EncryptionAgent right)
            => left.EncryptionAlgorithm.Equals(right.EncryptionAlgorithm)
            && left.EncryptionVersion.Equals(right.EncryptionVersion);

        private static bool AreEqual(IDictionary<string, string> left, IDictionary<string, string> right)
        {
            if (left.Count != right.Count)
            {
                return false;
            }
            foreach (KeyValuePair<string, string> leftPair in left)
            {
                if (!right.TryGetValue(leftPair.Key, out string rightValue))
                {
                    return false;
                }
                if (!leftPair.Value.Equals(rightValue, StringComparison.InvariantCulture))
                {
                    return false;
                }
            }

            return true;
        }
        #endregion
    }
}
