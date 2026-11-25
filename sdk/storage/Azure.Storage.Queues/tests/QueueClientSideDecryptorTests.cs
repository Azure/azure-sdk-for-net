// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Cryptography;
using Azure.Core.Pipeline;
using Azure.Storage.Cryptography;
using Azure.Storage.Queues.Models;
using Azure.Storage.Queues.Specialized;
using Moq;
using NUnit.Framework;
using static Moq.It;

namespace Azure.Storage.Queues.Test
{
    public class QueueClientSideDecryptorTests // no network tests, doesn't inherit our test base
    {
        private const string KeyWrapAlgorithm = "my_key_wrap_algorithm";

        private static Mock<IKeyEncryptionKey> GetKey(string keyId)
        {
            byte[] keyBytes = new byte[32];
            new Random().NextBytes(keyBytes);

            byte[] Xor(ReadOnlyMemory<byte> data)
            {
                byte[] input = data.ToArray();
                byte[] result = new byte[input.Length];
                for (int i = 0; i < input.Length; i++)
                {
                    result[i] = (byte)(input[i] ^ keyBytes[i % keyBytes.Length]);
                }
                return result;
            }

            var keyMock = new Mock<IKeyEncryptionKey>(MockBehavior.Strict);
            keyMock.SetupGet(k => k.KeyId).Returns(keyId);
            keyMock.Setup(k => k.WrapKey(KeyWrapAlgorithm, IsAny<ReadOnlyMemory<byte>>(), IsAny<CancellationToken>()))
                .Returns<string, ReadOnlyMemory<byte>, CancellationToken>((_, key, _) => Xor(key));
            keyMock.Setup(k => k.UnwrapKey(KeyWrapAlgorithm, IsAny<ReadOnlyMemory<byte>>(), IsAny<CancellationToken>()))
                .Returns<string, ReadOnlyMemory<byte>, CancellationToken>((_, key, _) => Xor(key));
            return keyMock;
        }

        [Test]
        public void DecryptsBatchEncryptedWithDifferentKeys()        {
            // Arrange
            IKeyEncryptionKey[] keys = new[] { GetKey("key1").Object, GetKey("key2").Object, GetKey("key3").Object };
            var resolverMock = new Mock<IKeyEncryptionKeyResolver>(MockBehavior.Strict);
            resolverMock.Setup(r => r.Resolve(IsAny<string>(), IsAny<CancellationToken>()))
                .Returns<string, CancellationToken>((id, _) => keys.First(k => k.KeyId == id));

#pragma warning disable CS0618 // obsolete
            var version = ClientSideEncryptionVersion.V1_0;
#pragma warning restore CS0618 // obsolete

            var messages = new List<QueueMessage>();
            var expected = new List<string>();
            for (int i = 0; i < keys.Length; i++)
            {
                var encryptionOptions = new ClientSideEncryptionOptions(version)
                {
                    KeyEncryptionKey = keys[i],
                    KeyWrapAlgorithm = KeyWrapAlgorithm
                };
                string text = $"message {i}";
                BinaryData encrypted = new QueueClientSideEncryptor(new ClientSideEncryptorV1_0(encryptionOptions))
                    .ClientSideEncryptInternal(BinaryData.FromString(text), async: false, default).EnsureCompleted();
                messages.Add(QueuesModelFactory.QueueMessage($"id{i}", "receipt", encrypted, 1));
                expected.Add(text);
            }

            var decryptor = new QueueClientSideDecryptor(new QueueClientSideEncryptionOptions(version)
            {
                KeyResolver = resolverMock.Object
            });

            // Act
            QueueMessage[] result = decryptor.ClientSideDecryptMessagesInternal(
                messages.ToArray(), async: false, default).EnsureCompleted();

            // Assert
            CollectionAssert.AreEqual(expected, result.Select(m => m.Body.ToString()).ToList());
        }
    }
}
