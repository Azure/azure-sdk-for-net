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
        public async Task ClientSideEncryptInternal_NullMetadata_CreatesNewMetadata()
        {
            var expectedCiphertext = new MemoryStream(new byte[] { 10, 20, 30 });
            var expectedEncryptionData = CreateTestEncryptionData();
            var mockEncryptor = new Mock<IClientSideEncryptor>();
            mockEncryptor
                .Setup(e => e.EncryptInternal(It.IsAny<Stream>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((expectedCiphertext, expectedEncryptionData));

            var encryptor = new BlobClientSideEncryptor(mockEncryptor.Object);
            var (ciphertext, metadata) = await encryptor.ClientSideEncryptInternal(
                new MemoryStream(new byte[] { 1, 2, 3 }),
                null,
                async: true,
                CancellationToken.None);

            Assert.AreSame(expectedCiphertext, ciphertext);
            Assert.AreEqual(1, metadata.Count);
            Assert.IsTrue(metadata.ContainsKey(Constants.ClientSideEncryption.EncryptionDataKey));
        }

        [Test]
        public async Task ClientSideEncryptInternal_ExistingMetadata_CopiesAndOverwritesEncryptionData()
        {
            var expectedEncryptionData = CreateTestEncryptionData();
            var mockEncryptor = new Mock<IClientSideEncryptor>();
            mockEncryptor
                .Setup(e => e.EncryptInternal(It.IsAny<Stream>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((new MemoryStream(), expectedEncryptionData));

            var encryptor = new BlobClientSideEncryptor(mockEncryptor.Object);
            var existingMetadata = new Dictionary<string, string>
            {
                { "existingKey", "existingValue" },
                { Constants.ClientSideEncryption.EncryptionDataKey, "oldValue" }
            };

            var (_, metadata) = await encryptor.ClientSideEncryptInternal(
                new MemoryStream(),
                existingMetadata,
                async: true,
                CancellationToken.None);

            Assert.AreEqual(2, metadata.Count);
            Assert.AreEqual("existingValue", metadata["existingKey"]);
            Assert.AreNotEqual("oldValue", metadata[Constants.ClientSideEncryption.EncryptionDataKey]);
            Assert.AreEqual("oldValue", existingMetadata[Constants.ClientSideEncryption.EncryptionDataKey]);
        }

        #endregion
    }
}
