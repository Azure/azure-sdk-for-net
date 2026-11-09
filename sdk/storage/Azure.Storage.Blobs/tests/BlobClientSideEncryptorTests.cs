// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Cryptography;
using Azure.Storage.Cryptography.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    [TestFixture]
    public class BlobClientSideEncryptorTests
    {
        private static EncryptionData CreateTestEncryptionData()
        {
            return new EncryptionData
            {
                EncryptionMode = Constants.ClientSideEncryption.EncryptionMode,
                EncryptionAgent = new EncryptionAgent
                {
                    EncryptionVersion = ClientSideEncryptionVersionInternal.V2_0,
                    EncryptionAlgorithm = ClientSideEncryptionAlgorithm.AesGcm256,
                },
                WrappedContentKey = new KeyEnvelope
                {
                    KeyId = "keyId",
                    EncryptedKey = new byte[] { 1, 2, 3 },
                    Algorithm = "algo"
                },
                EncryptedRegionInfo = new EncryptedRegionInfo
                {
                    DataLength = Constants.ClientSideEncryption.V2.EncryptionRegionDataSize,
                    NonceLength = Constants.ClientSideEncryption.V2.NonceSize
                },
                KeyWrappingMetadata = new Dictionary<string, string>
                {
                    { Constants.ClientSideEncryption.AgentMetadataKey, "2.0" }
                }
            };
        }

        #region ClientSideEncryptInternal

        [Test]
        public async Task ClientSideEncryptInternal_ReturnsEncryptedStreamAndMetadata()
        {
            // Arrange
            var expectedCiphertext = new MemoryStream(new byte[] { 10, 20, 30 });
            var expectedEncryptionData = CreateTestEncryptionData();

            var mockEncryptor = new Mock<IClientSideEncryptor>();
            mockEncryptor
                .Setup(e => e.EncryptInternal(It.IsAny<Stream>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((expectedCiphertext, expectedEncryptionData));

            var encryptor = new BlobClientSideEncryptor(mockEncryptor.Object);
            var plaintext = new MemoryStream(new byte[] { 1, 2, 3 });

            // Act
            var (ciphertext, metadata) = await encryptor.ClientSideEncryptInternal(
                plaintext,
                null,
                async: true,
                CancellationToken.None);

            // Assert
            Assert.AreSame(expectedCiphertext, ciphertext);
            Assert.IsNotNull(metadata);
            Assert.IsTrue(metadata.ContainsKey(Constants.ClientSideEncryption.EncryptionDataKey));
        }

        [Test]
        public async Task ClientSideEncryptInternal_NullMetadata_CreatesNewMetadata()
        {
            // Arrange
            var expectedEncryptionData = CreateTestEncryptionData();
            var mockEncryptor = new Mock<IClientSideEncryptor>();
            mockEncryptor
                .Setup(e => e.EncryptInternal(It.IsAny<Stream>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((new MemoryStream(), expectedEncryptionData));

            var encryptor = new BlobClientSideEncryptor(mockEncryptor.Object);

            // Act
            var (_, metadata) = await encryptor.ClientSideEncryptInternal(
                new MemoryStream(),
                null,
                async: true,
                CancellationToken.None);

            // Assert
            Assert.IsNotNull(metadata);
            Assert.AreEqual(1, metadata.Count);
            Assert.IsTrue(metadata.ContainsKey(Constants.ClientSideEncryption.EncryptionDataKey));
        }

        [Test]
        public async Task ClientSideEncryptInternal_ExistingMetadata_PreservesAndAddsEncryptionData()
        {
            // Arrange
            var expectedEncryptionData = CreateTestEncryptionData();
            var mockEncryptor = new Mock<IClientSideEncryptor>();
            mockEncryptor
                .Setup(e => e.EncryptInternal(It.IsAny<Stream>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((new MemoryStream(), expectedEncryptionData));

            var encryptor = new BlobClientSideEncryptor(mockEncryptor.Object);
            var existingMetadata = new Dictionary<string, string>
            {
                { "existingKey", "existingValue" }
            };

            // Act
            var (_, metadata) = await encryptor.ClientSideEncryptInternal(
                new MemoryStream(),
                existingMetadata,
                async: true,
                CancellationToken.None);

            // Assert
            Assert.AreEqual(2, metadata.Count);
            Assert.AreEqual("existingValue", metadata["existingKey"]);
            Assert.IsTrue(metadata.ContainsKey(Constants.ClientSideEncryption.EncryptionDataKey));
        }

        [Test]
        public async Task ClientSideEncryptInternal_ExistingEncryptionMetadata_OverwritesPrevious()
        {
            // Arrange
            var expectedEncryptionData = CreateTestEncryptionData();
            var mockEncryptor = new Mock<IClientSideEncryptor>();
            mockEncryptor
                .Setup(e => e.EncryptInternal(It.IsAny<Stream>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((new MemoryStream(), expectedEncryptionData));

            var encryptor = new BlobClientSideEncryptor(mockEncryptor.Object);
            var existingMetadata = new Dictionary<string, string>
            {
                { Constants.ClientSideEncryption.EncryptionDataKey, "oldValue" }
            };

            // Act
            var (_, metadata) = await encryptor.ClientSideEncryptInternal(
                new MemoryStream(),
                existingMetadata,
                async: true,
                CancellationToken.None);

            // Assert
            Assert.AreEqual(1, metadata.Count);
            Assert.AreNotEqual("oldValue", metadata[Constants.ClientSideEncryption.EncryptionDataKey]);
        }

        [Test]
        public async Task ClientSideEncryptInternal_DoesNotMutateOriginalMetadata()
        {
            // Arrange
            var expectedEncryptionData = CreateTestEncryptionData();
            var mockEncryptor = new Mock<IClientSideEncryptor>();
            mockEncryptor
                .Setup(e => e.EncryptInternal(It.IsAny<Stream>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((new MemoryStream(), expectedEncryptionData));

            var encryptor = new BlobClientSideEncryptor(mockEncryptor.Object);
            var originalMetadata = new Dictionary<string, string>
            {
                { "key1", "value1" }
            };

            // Act
            await encryptor.ClientSideEncryptInternal(
                new MemoryStream(),
                originalMetadata,
                async: true,
                CancellationToken.None);

            // Assert - original metadata should not be modified
            Assert.AreEqual(1, originalMetadata.Count);
            Assert.IsFalse(originalMetadata.ContainsKey(Constants.ClientSideEncryption.EncryptionDataKey));
        }

        [Test]
        public async Task ClientSideEncryptInternal_Sync_CallsEncryptorCorrectly()
        {
            // Arrange
            var expectedEncryptionData = CreateTestEncryptionData();
            var mockEncryptor = new Mock<IClientSideEncryptor>();
            mockEncryptor
                .Setup(e => e.EncryptInternal(It.IsAny<Stream>(), false, It.IsAny<CancellationToken>()))
                .ReturnsAsync((new MemoryStream(), expectedEncryptionData));

            var encryptor = new BlobClientSideEncryptor(mockEncryptor.Object);

            // Act
            await encryptor.ClientSideEncryptInternal(
                new MemoryStream(),
                null,
                async: false,
                CancellationToken.None);

            // Assert
            mockEncryptor.Verify(
                e => e.EncryptInternal(It.IsAny<Stream>(), false, It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Test]
        public async Task ClientSideEncryptInternal_PassesCancellationToken()
        {
            // Arrange
            var expectedEncryptionData = CreateTestEncryptionData();
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var mockEncryptor = new Mock<IClientSideEncryptor>();
            mockEncryptor
                .Setup(e => e.EncryptInternal(It.IsAny<Stream>(), It.IsAny<bool>(), token))
                .ReturnsAsync((new MemoryStream(), expectedEncryptionData));

            var encryptor = new BlobClientSideEncryptor(mockEncryptor.Object);

            // Act
            await encryptor.ClientSideEncryptInternal(
                new MemoryStream(),
                null,
                async: true,
                token);

            // Assert
            mockEncryptor.Verify(
                e => e.EncryptInternal(It.IsAny<Stream>(), true, token),
                Times.Once);
        }

        [Test]
        public async Task ClientSideEncryptInternal_MetadataKeysAreCaseInsensitive()
        {
            // Arrange
            var expectedEncryptionData = CreateTestEncryptionData();
            var mockEncryptor = new Mock<IClientSideEncryptor>();
            mockEncryptor
                .Setup(e => e.EncryptInternal(It.IsAny<Stream>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((new MemoryStream(), expectedEncryptionData));

            var encryptor = new BlobClientSideEncryptor(mockEncryptor.Object);

            // Act
            var (_, metadata) = await encryptor.ClientSideEncryptInternal(
                new MemoryStream(),
                null,
                async: true,
                CancellationToken.None);

            // Assert - metadata should be case insensitive
            string key = Constants.ClientSideEncryption.EncryptionDataKey;
            Assert.IsTrue(metadata.ContainsKey(key.ToUpperInvariant()));
        }

        #endregion
    }
}
