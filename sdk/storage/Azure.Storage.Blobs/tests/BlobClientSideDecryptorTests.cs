// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Cryptography;
using Azure.Storage.Cryptography;
using Azure.Storage.Cryptography.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    [TestFixture]
    public class BlobClientSideDecryptorTests
    {
        #region DecryptInternal

        [Test]
        public async Task DecryptInternal_NoEncryptionMetadata_TrimsStream()
        {
            var decryptor = new BlobClientSideDecryptor(CreateDecryptor());
            using var stream = new MemoryStream(new byte[] { 1, 2, 3, 4, 5 });
            var metadata = new Dictionary<string, string>
            {
                { "otherKey", "otherValue" }
            };

            var result = await decryptor.DecryptInternal(
                stream,
                metadata,
                new HttpRange(2, 3),
                "bytes 0-4/5",
                0,
                async: false,
                CancellationToken.None);

            var actual = await ReadAllBytesAsync(result);
            CollectionAssert.AreEqual(new byte[] { 3, 4, 5 }, actual);
        }

        [Test]
        public async Task DecryptInternal_WithEncryptionMetadata_DecryptsAndTrims()
        {
            var plaintext = new byte[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
            var (ciphertext, metadata) = await CreateEncryptedPayloadAsync(plaintext);
            var decryptor = new BlobClientSideDecryptor(CreateDecryptor());

            var result = await decryptor.DecryptInternal(
                ciphertext,
                metadata,
                new HttpRange(3, 5),
                "bytes 0-9/10",
                0,
                async: false,
                CancellationToken.None);

            var actual = await ReadAllBytesAsync(result);
            CollectionAssert.AreEqual(new byte[] { 13, 14, 15, 16, 17 }, actual);
        }

        [Test]
        public async Task DecryptWholeBlobWriteInternal_NoEncryptionMetadata_ReturnsOriginalStream()
        {
            var decryptor = new BlobClientSideDecryptor(CreateDecryptor());
            var stream = new MemoryStream(new byte[] { 1, 2, 3 });

            var result = await decryptor.DecryptWholeBlobWriteInternal(
                stream,
                new Dictionary<string, string> { { "otherKey", "otherValue" } },
                async: false,
                CancellationToken.None);

            Assert.AreSame(stream, result);
        }

        [Test]
        public async Task DecryptWholeBlobWriteInternal_WithEncryptionMetadata_DecryptsToDestination()
        {
            var plaintext = new byte[] { 20, 21, 22, 23, 24 };
            var (ciphertext, metadata) = await CreateEncryptedPayloadAsync(plaintext);
            var decryptor = new BlobClientSideDecryptor(CreateDecryptor());
            var destination = new MemoryStream();

            using (Stream result = await decryptor.DecryptWholeBlobWriteInternal(
                destination,
                metadata,
                async: false,
                CancellationToken.None))
            {
                Assert.IsNotNull(result);
                ciphertext.Position = 0;
                await result.WriteAsync(await ReadAllBytesAsync(ciphertext), 0, (int)ciphertext.Length);
                result.Flush();
            }

            CollectionAssert.AreEqual(plaintext, destination.ToArray());
        }

        #endregion

        #region Helpers

        private static ClientSideDecryptor CreateDecryptor()
        {
            const string keyId = "keyId";
            const string keyWrapAlgorithm = "some algorithm name";
            var key = new Mock<IKeyEncryptionKey>(MockBehavior.Strict);
            key.SetupGet(k => k.KeyId).Returns(keyId);
            key.Setup(k => k.WrapKey(keyWrapAlgorithm, It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<CancellationToken>()))
                .Returns((string _, ReadOnlyMemory<byte> contents, CancellationToken _) => contents.ToArray());
            key.Setup(k => k.UnwrapKey(keyWrapAlgorithm, It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<CancellationToken>()))
                .Returns((string _, ReadOnlyMemory<byte> contents, CancellationToken _) => contents.ToArray());
            key.Setup(k => k.WrapKeyAsync(keyWrapAlgorithm, It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<CancellationToken>()))
                .Returns((string _, ReadOnlyMemory<byte> contents, CancellationToken _) => Task.FromResult(contents.ToArray()));
            key.Setup(k => k.UnwrapKeyAsync(keyWrapAlgorithm, It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<CancellationToken>()))
                .Returns((string _, ReadOnlyMemory<byte> contents, CancellationToken _) => Task.FromResult(contents.ToArray()));

            var resolver = new Mock<IKeyEncryptionKeyResolver>(MockBehavior.Strict);
            resolver.Setup(r => r.Resolve(keyId, It.IsAny<CancellationToken>())).Returns(key.Object);
            resolver.Setup(r => r.ResolveAsync(keyId, It.IsAny<CancellationToken>())).ReturnsAsync(key.Object);

            var options = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V2_0)
            {
                KeyEncryptionKey = key.Object,
                KeyResolver = resolver.Object,
                KeyWrapAlgorithm = keyWrapAlgorithm,
            };

            return new ClientSideDecryptor(options);
        }

        private static async Task<(MemoryStream Ciphertext, Dictionary<string, string> Metadata)> CreateEncryptedPayloadAsync(byte[] plaintext)
        {
            const string keyId = "keyId";
            const string keyWrapAlgorithm = "some algorithm name";
            var key = new Mock<IKeyEncryptionKey>(MockBehavior.Strict);
            key.SetupGet(k => k.KeyId).Returns(keyId);
            key.Setup(k => k.WrapKey(keyWrapAlgorithm, It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<CancellationToken>()))
                .Returns((string _, ReadOnlyMemory<byte> contents, CancellationToken _) => contents.ToArray());
            key.Setup(k => k.UnwrapKey(keyWrapAlgorithm, It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<CancellationToken>()))
                .Returns((string _, ReadOnlyMemory<byte> contents, CancellationToken _) => contents.ToArray());
            key.Setup(k => k.WrapKeyAsync(keyWrapAlgorithm, It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<CancellationToken>()))
                .Returns((string _, ReadOnlyMemory<byte> contents, CancellationToken _) => Task.FromResult(contents.ToArray()));
            key.Setup(k => k.UnwrapKeyAsync(keyWrapAlgorithm, It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<CancellationToken>()))
                .Returns((string _, ReadOnlyMemory<byte> contents, CancellationToken _) => Task.FromResult(contents.ToArray()));

            var resolver = new Mock<IKeyEncryptionKeyResolver>(MockBehavior.Strict);
            resolver.Setup(r => r.Resolve(keyId, It.IsAny<CancellationToken>())).Returns(key.Object);
            resolver.Setup(r => r.ResolveAsync(keyId, It.IsAny<CancellationToken>())).ReturnsAsync(key.Object);

            var options = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V2_0)
            {
                KeyEncryptionKey = key.Object,
                KeyResolver = resolver.Object,
                KeyWrapAlgorithm = keyWrapAlgorithm,
            };

            var encryptor = new ClientSideEncryptorV2_0(options);
            var (ciphertext, encryptionData) = await encryptor.BufferedEncryptInternal(new MemoryStream(plaintext), async: false, CancellationToken.None);
            var metadata = new Dictionary<string, string>
            {
                { Constants.ClientSideEncryption.EncryptionDataKey, EncryptionDataSerializer.Serialize(encryptionData) }
            };

            return (new MemoryStream(ciphertext), metadata);
        }

        private static async Task<byte[]> ReadAllBytesAsync(Stream stream)
        {
            using var memory = new MemoryStream();
            if (stream.CanSeek)
            {
                stream.Position = 0;
            }

            await stream.CopyToAsync(memory).ConfigureAwait(false);
            return memory.ToArray();
        }

        #endregion
    }
}
