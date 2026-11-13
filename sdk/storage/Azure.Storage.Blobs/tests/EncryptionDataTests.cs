// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Cryptography;
using Azure.Storage.Cryptography.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    [TestFixture]
    public class EncryptionDataTests
    {
        private const string TestKeyId = "test-key-id";
        private const string TestWrapAlgorithm = "testAlgorithm";
        private static readonly byte[] TestCek = new byte[32];
        private static readonly byte[] TestIv = new byte[16];
        private static readonly byte[] TestWrappedKey = new byte[] { 1, 2, 3, 4 };

        private static Mock<IKeyEncryptionKey> CreateMockKek()
        {
            var mock = new Mock<IKeyEncryptionKey>();
            mock.SetupGet(k => k.KeyId).Returns(TestKeyId);
            mock.Setup(k => k.WrapKey(It.IsAny<string>(), It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<CancellationToken>()))
                .Returns(TestWrappedKey);
            mock.Setup(k => k.WrapKeyAsync(It.IsAny<string>(), It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(TestWrappedKey);
            return mock;
        }

        #region CreateInternalV1_0

        [Test]
        public async Task CreateInternalV1_0_Async_SetsCorrectProperties()
        {
            var mockKek = CreateMockKek();

            EncryptionData result = await EncryptionData.CreateInternalV1_0(
                TestIv, TestWrapAlgorithm, TestCek, mockKek.Object, async: true, CancellationToken.None);

            Assert.AreEqual(Constants.ClientSideEncryption.EncryptionMode, result.EncryptionMode);
            Assert.AreEqual(TestIv, result.ContentEncryptionIV);
#pragma warning disable CS0618
            Assert.AreEqual(ClientSideEncryptionVersionInternal.V1_0, result.EncryptionAgent.EncryptionVersion);
#pragma warning restore CS0618
            Assert.AreEqual(ClientSideEncryptionAlgorithm.AesCbc256, result.EncryptionAgent.EncryptionAlgorithm);
            Assert.AreEqual(TestWrapAlgorithm, result.WrappedContentKey.Algorithm);
            Assert.AreEqual(TestWrappedKey, result.WrappedContentKey.EncryptedKey);
            Assert.AreEqual(TestKeyId, result.WrappedContentKey.KeyId);
            Assert.IsTrue(result.KeyWrappingMetadata.ContainsKey(Constants.ClientSideEncryption.AgentMetadataKey));
        }

        [Test]
        public async Task CreateInternalV1_0_Async_CallsWrapKeyAsync()
        {
            var mockKek = CreateMockKek();

            await EncryptionData.CreateInternalV1_0(
                TestIv, TestWrapAlgorithm, TestCek, mockKek.Object, async: true, CancellationToken.None);

            mockKek.Verify(
                k => k.WrapKeyAsync(TestWrapAlgorithm, It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<CancellationToken>()),
                Times.Once);
            mockKek.Verify(
                k => k.WrapKey(It.IsAny<string>(), It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<CancellationToken>()),
                Times.Never);
        }

        [Test]
        public async Task CreateInternalV1_0_Sync_CallsWrapKey()
        {
            var mockKek = CreateMockKek();

            await EncryptionData.CreateInternalV1_0(
                TestIv, TestWrapAlgorithm, TestCek, mockKek.Object, async: false, CancellationToken.None);

            mockKek.Verify(
                k => k.WrapKey(TestWrapAlgorithm, It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<CancellationToken>()),
                Times.Once);
            mockKek.Verify(
                k => k.WrapKeyAsync(It.IsAny<string>(), It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<CancellationToken>()),
                Times.Never);
        }

        [Test]
        public async Task CreateInternalV1_0_PassesCancellationToken()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var mockKek = CreateMockKek();

            await EncryptionData.CreateInternalV1_0(
                TestIv, TestWrapAlgorithm, TestCek, mockKek.Object, async: true, token);

            mockKek.Verify(
                k => k.WrapKeyAsync(TestWrapAlgorithm, It.IsAny<ReadOnlyMemory<byte>>(), token),
                Times.Once);
        }

        #endregion

        #region CreateInternalV2_0

        [Test]
        public async Task CreateInternalV2_0_Async_SetsCorrectProperties()
        {
            var mockKek = CreateMockKek();

            EncryptionData result = await EncryptionData.CreateInternalV2_0(
                TestWrapAlgorithm, TestCek, mockKek.Object, async: true, CancellationToken.None);

            Assert.AreEqual(Constants.ClientSideEncryption.EncryptionMode, result.EncryptionMode);
            Assert.AreEqual(ClientSideEncryptionVersionInternal.V2_0, result.EncryptionAgent.EncryptionVersion);
            Assert.AreEqual(ClientSideEncryptionAlgorithm.AesGcm256, result.EncryptionAgent.EncryptionAlgorithm);
            Assert.AreEqual(Constants.ClientSideEncryption.V2.EncryptionRegionDataSize, result.EncryptedRegionInfo.DataLength);
            Assert.AreEqual(Constants.ClientSideEncryption.V2.NonceSize, result.EncryptedRegionInfo.NonceLength);
            Assert.AreEqual(TestWrapAlgorithm, result.WrappedContentKey.Algorithm);
            Assert.AreEqual(TestWrappedKey, result.WrappedContentKey.EncryptedKey);
            Assert.AreEqual(TestKeyId, result.WrappedContentKey.KeyId);
            Assert.IsTrue(result.KeyWrappingMetadata.ContainsKey(Constants.ClientSideEncryption.AgentMetadataKey));
            Assert.IsNull(result.ContentEncryptionIV);
        }

        [Test]
        public async Task CreateInternalV2_0_Async_CallsWrapKeyAsync()
        {
            var mockKek = CreateMockKek();

            await EncryptionData.CreateInternalV2_0(
                TestWrapAlgorithm, TestCek, mockKek.Object, async: true, CancellationToken.None);

            mockKek.Verify(
                k => k.WrapKeyAsync(TestWrapAlgorithm, It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<CancellationToken>()),
                Times.Once);
            mockKek.Verify(
                k => k.WrapKey(It.IsAny<string>(), It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<CancellationToken>()),
                Times.Never);
        }

        [Test]
        public async Task CreateInternalV2_0_Sync_CallsWrapKey()
        {
            var mockKek = CreateMockKek();

            await EncryptionData.CreateInternalV2_0(
                TestWrapAlgorithm, TestCek, mockKek.Object, async: false, CancellationToken.None);

            mockKek.Verify(
                k => k.WrapKey(TestWrapAlgorithm, It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<CancellationToken>()),
                Times.Once);
            mockKek.Verify(
                k => k.WrapKeyAsync(It.IsAny<string>(), It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<CancellationToken>()),
                Times.Never);
        }

        [Test]
        public async Task CreateInternalV2_0_WrapsVersionAndKey()
        {
            ReadOnlyMemory<byte> capturedData = default;
            var mockKek = CreateMockKek();
            mockKek.Setup(k => k.WrapKeyAsync(It.IsAny<string>(), It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<CancellationToken>()))
                .Callback<string, ReadOnlyMemory<byte>, CancellationToken>((alg, data, ct) => capturedData = data)
                .ReturnsAsync(TestWrappedKey);

            await EncryptionData.CreateInternalV2_0(
                TestWrapAlgorithm, TestCek, mockKek.Object, async: true, CancellationToken.None);

            // data to wrap should be version string (8 bytes) + CEK
            int expectedLength = Constants.ClientSideEncryption.V2.WrappedDataVersionLength + TestCek.Length;
            Assert.AreEqual(expectedLength, capturedData.Length);
        }

        [Test]
        public async Task CreateInternalV2_0_PassesCancellationToken()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var mockKek = CreateMockKek();

            await EncryptionData.CreateInternalV2_0(
                TestWrapAlgorithm, TestCek, mockKek.Object, async: true, token);

            mockKek.Verify(
                k => k.WrapKeyAsync(TestWrapAlgorithm, It.IsAny<ReadOnlyMemory<byte>>(), token),
                Times.Once);
        }

        #endregion
    }
}
