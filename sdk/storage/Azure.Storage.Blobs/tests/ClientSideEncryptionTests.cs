// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Cryptography;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Keys.Cryptography;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.Cryptography;
using Azure.Storage.Cryptography.Models;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using static Azure.Storage.Constants.ClientSideEncryption;
using static Azure.Storage.Test.Shared.ClientSideEncryptionTestExtensions;
using static Moq.It;

namespace Azure.Storage.Blobs.Test
{
    public class ClientSideEncryptionTests : BlobTestBase
    {
        private static string s_algorithmName => ClientSideEncryptionTestExtensions.s_algorithmName;
        private static readonly CancellationToken s_cancellationToken = new CancellationTokenSource().Token;

        public ClientSideEncryptionTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
            // TODO: enable after new KeyValue is released (after Dec 2023)
            TestDiagnostics = false;
        }

        private static IEnumerable<ClientSideEncryptionVersion> GetEncryptionVersions()
            => Enum.GetValues(typeof(ClientSideEncryptionVersion)).Cast<ClientSideEncryptionVersion>();

        /// <summary>
        /// Provides encryption v1 functionality clone of client logic, letting us validate the client got it right end-to-end.
        /// </summary>
        private byte[] EncryptDataV1_0(byte[] data, byte[] key, byte[] iv)
        {
            using var aesProvider = Aes.Create();
            aesProvider.Key = key;
            aesProvider.IV = iv;
            using var encryptor = aesProvider.CreateEncryptor();
            using var memStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(data, 0, data.Length);
            cryptoStream.FlushFinalBlock();
            return memStream.ToArray();
        }

        /// <summary>
        /// Provides encryption v2 functionality clone of client logic, letting us validate the client got it right end-to-end
        /// and was not altered.
        /// </summary>
        private ReadOnlySpan<byte> EncryptDataV2_0(ReadOnlySpan<byte> data, ReadOnlySpan<byte> key)
        {
            int numEncryptionRegions = data.Length % V2.EncryptionRegionDataSize == 0
                ? data.Length / V2.EncryptionRegionDataSize
                : (data.Length + (V2.EncryptionRegionDataSize - (data.Length % V2.EncryptionRegionDataSize))) / V2.EncryptionRegionDataSize;
            int encryptedDataLength = data.Length + (numEncryptionRegions * (V2.NonceSize + V2.TagSize));
            var result = new Span<byte>(new byte[encryptedDataLength]);

            long nonceCounter = 1;
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
            using var gcm = new AesGcm(key);
#else
            using var gcm = new Azure.Storage.Shared.AesGcm.AesGcmWindows(key);
#endif
            for (int i = 0; i < numEncryptionRegions; i++)
            {
                int dataRegionLength = Math.Min(V2.EncryptionRegionDataSize, data.Length - (i * V2.EncryptionRegionDataSize));
                var dataRegionSlice = data.Slice(i * V2.EncryptionRegionDataSize, dataRegionLength);
                var resultRegionSlice = result.Slice(i * V2.EncryptionRegionTotalSize, dataRegionLength + V2.NonceSize + V2.TagSize);

                // get nonce for this block
                var nonce = resultRegionSlice.Slice(0, V2.NonceSize);
                const int bytesInLong = 8;
                int remainingNonceBytes = V2.NonceSize - bytesInLong;
                Enumerable.Repeat((byte)0, remainingNonceBytes).ToArray().CopyTo(nonce.Slice(0, remainingNonceBytes));
                BitConverter.GetBytes(nonceCounter++).CopyTo(nonce.Slice(remainingNonceBytes, bytesInLong));

                gcm.Encrypt(
                    nonce,
                    dataRegionSlice, //data.Slice(i * V2.EncryptionRegionDataSize, Math.Min(V2.EncryptionRegionDataSize, data.Length - (i * V2.EncryptionRegionDataSize))),
                    resultRegionSlice.Slice(V2.NonceSize, dataRegionLength), //result.Slice(i * V2.EncryptionRegionTotalSize, Math.Min(V2.EncryptionRegionTotalSize, result.Length - (i * V2.EncryptionRegionTotalSize))),
                    resultRegionSlice.Slice(V2.NonceSize + dataRegionLength, V2.TagSize));
            }

            return result;
        }

        private async Task<IKeyEncryptionKey> GetKeyvaultIKeyEncryptionKey()
        {
            var keyClient = GetKeyClient_TargetKeyClient();
            Security.KeyVault.Keys.KeyVaultKey key = await keyClient.CreateRsaKeyAsync(
                new Security.KeyVault.Keys.CreateRsaKeyOptions($"CloudRsaKey-{Guid.NewGuid()}", false));
            return new CryptographyClient(key.Id, GetTokenCredential_TargetKeyClient());
        }

        private async Task<DisposingContainer> GetTestContainerEncryptionAsync(
            ClientSideEncryptionOptions encryptionOptions,
            string containerName = default,
            IDictionary<string, string> metadata = default)
        {
            // normally set through property on subclass; this is easier to hook up in current test infra with internals access
            var options = GetOptions();
            options._clientSideEncryptionOptions = encryptionOptions;

            containerName ??= GetNewContainerName();
            var service = BlobsClientBuilder.GetServiceClient_SharedKey(options);

            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(containerName));
            await container.CreateAsync(metadata: metadata);
            return new DisposingContainer(container);
        }

        private void VerifyUnwrappedKeyWasCached(Mock<IKeyEncryptionKey> keyMock)
        {
            if (IsAsync)
            {
                keyMock.Verify(k => k.UnwrapKeyAsync(s_algorithmName, IsNotNull<ReadOnlyMemory<byte>>(), s_cancellationToken), Times.Once);
            }
            else
            {
                keyMock.Verify(k => k.UnwrapKey(s_algorithmName, IsNotNull<ReadOnlyMemory<byte>>(), It.IsAny<CancellationToken>()), Times.Once);
            }
        }

        /// <summary>
        /// Get Content Encryption Key and IV from uploaded/encrypted blob to determine expected ciphertext.
        /// </summary>
        /// <param name="plaintext">
        /// Data to encrypt.
        /// </param>
        /// <param name="properties">
        /// BlobProperties containing the wrapped CEK and IV to use for replicating encryption steps.
        /// </param>
        /// <param name="keyEncryptionKey">
        /// KEK used to unwrap the CEK in <paramref name="properties"/>.
        /// </param>
        /// <returns>Expected encrypted data with the given CEK and IV.</returns>
        private async Task<byte[]> ReplicateEncryption(byte[] plaintext, BlobProperties properties, IKeyEncryptionKey keyEncryptionKey)
        {
            // encrypt original data manually for comparison
            if (!properties.Metadata.TryGetValue(Constants.ClientSideEncryption.EncryptionDataKey, out string serialEncryptionData))
            {
                Assert.Fail("No encryption metadata present.");
            }

            EncryptionData encryptionMetadata = EncryptionDataSerializer.Deserialize(serialEncryptionData);
            switch (encryptionMetadata.EncryptionAgent.EncryptionVersion)
            {
#pragma warning disable CS0618 // obsolete
                case ClientSideEncryptionVersion.V1_0:
                    return await ReplicateEncryptionV1_0(plaintext, encryptionMetadata, keyEncryptionKey);
#pragma warning restore CS0618 // obsolete
                case ClientSideEncryptionVersion.V2_0:
                    return await ReplicateEncryptionV2_0(plaintext, encryptionMetadata, keyEncryptionKey);
                default:
                    throw new ArgumentException("Bad version in EncryptionData");
            }

            throw new NotImplementedException();
        }

#pragma warning disable CS0618 // obsolete
        private async Task<byte[]> ReplicateEncryptionV1_0(byte[] plaintext, EncryptionData encryptionMetadata, IKeyEncryptionKey keyEncryptionKey)
        {
            Assert.NotNull(encryptionMetadata, "Never encrypted data.");
            Assert.AreEqual(ClientSideEncryptionVersion.V1_0, encryptionMetadata.EncryptionAgent.EncryptionVersion);

            var explicitlyUnwrappedKey = IsAsync // can't instrument this
                ? await keyEncryptionKey.UnwrapKeyAsync(s_algorithmName, encryptionMetadata.WrappedContentKey.EncryptedKey, s_cancellationToken).ConfigureAwait(false)
                : keyEncryptionKey.UnwrapKey(s_algorithmName, encryptionMetadata.WrappedContentKey.EncryptedKey, s_cancellationToken);

            return EncryptDataV1_0(
                plaintext,
                explicitlyUnwrappedKey,
                encryptionMetadata.ContentEncryptionIV);
        }
#pragma warning restore CS0618 // obsolete

        private async Task<byte[]> ReplicateEncryptionV2_0(byte[] plaintext, EncryptionData encryptionMetadata, IKeyEncryptionKey keyEncryptionKey)
        {
            Assert.NotNull(encryptionMetadata, "Never encrypted data.");
            Assert.AreEqual(ClientSideEncryptionVersion.V2_0, encryptionMetadata.EncryptionAgent.EncryptionVersion);

            var explicitlyUnwrappedContent = IsAsync // can't instrument this
                ? await keyEncryptionKey.UnwrapKeyAsync(s_algorithmName, encryptionMetadata.WrappedContentKey.EncryptedKey, s_cancellationToken).ConfigureAwait(false)
                : keyEncryptionKey.UnwrapKey(s_algorithmName, encryptionMetadata.WrappedContentKey.EncryptedKey, s_cancellationToken);

            var explicitlyUnwrappedVersion = new ReadOnlySpan<byte>(explicitlyUnwrappedContent).Slice(0, V2.WrappedDataVersionLength).ToArray();
            var explicitlyUnwrappedKey = new ReadOnlySpan<byte>(explicitlyUnwrappedContent).Slice(V2.WrappedDataVersionLength).ToArray();

            Assert.AreEqual("2.0", Encoding.UTF8.GetString(explicitlyUnwrappedVersion).Trim('\0'));

            return EncryptDataV2_0(
                plaintext,
                explicitlyUnwrappedKey).ToArray();
        }

        /// <summary>
        /// Download a blob without decrypting it.
        /// </summary>
        /// <param name="blob">Encrypted blob to download.</param>
        /// <returns>Ciphertext.</returns>
        private async Task<byte[]> DownloadBypassDecryption(BlobClient blob)
        {
            var encryptedDataStream = new MemoryStream();
            await InstrumentClient(new BlobClient(blob.Uri, Tenants.GetNewSharedKeyCredentials())).DownloadToAsync(encryptedDataStream, cancellationToken: s_cancellationToken);
            return encryptedDataStream.ToArray();
        }

        private async Task<EncryptionData> GetMockEncryptionDataAsync(byte[] cek, IKeyEncryptionKey kek)
        {
            byte[] encryptedKey = IsAsync
                ? await kek.WrapKeyAsync(s_algorithmName, cek, s_cancellationToken)
                : kek.WrapKey(s_algorithmName, cek, s_cancellationToken);

            return new EncryptionData
            {
                WrappedContentKey = new KeyEnvelope
                {
                    EncryptedKey = encryptedKey,
                    Algorithm = s_algorithmName,
                    KeyId = kek.KeyId
                },
                EncryptedRegionInfo = new EncryptedRegionInfo
                {
                    DataLength = 4 * Constants.MB,
                    NonceLength = 12
                },
                EncryptionAgent = new EncryptionAgent()
                {
                    EncryptionAlgorithm = "foo",
                    EncryptionVersion = ClientSideEncryptionVersion.V2_0
                },
                EncryptionMode = "bar",
                KeyWrappingMetadata = new Dictionary<string, string> { { "fizz", "buzz" } }
            };
        }

#pragma warning disable CS0618 // obsolete
        [TestCase(ClientSideEncryptionVersion.V1_0)]
        [TestCase(ClientSideEncryptionVersion.V2_0)]
        [LiveOnly]
#pragma warning restore CS0618 // obsolete
        public void CanSwapKey(ClientSideEncryptionVersion version)
        {
            var options1 = new ClientSideEncryptionOptions(version)
            {
                KeyEncryptionKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object,
                KeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, default).Object,
                KeyWrapAlgorithm = "foo"
            };
            var options2 = new ClientSideEncryptionOptions(version)
            {
                KeyEncryptionKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object,
                KeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, default).Object,
                KeyWrapAlgorithm = "bar"
            };

            var client = new BlobClient(new Uri("http://someuri.com"), new SpecializedBlobClientOptions()
            {
                ClientSideEncryption = options1,
            });

            Assert.AreEqual(options1.KeyEncryptionKey, client.ClientSideEncryption.KeyEncryptionKey);
            Assert.AreEqual(options1.KeyResolver, client.ClientSideEncryption.KeyResolver);
            Assert.AreEqual(options1.KeyWrapAlgorithm, client.ClientSideEncryption.KeyWrapAlgorithm);

            client = client.WithClientSideEncryptionOptions(options2);

            Assert.AreEqual(options2.KeyEncryptionKey, client.ClientSideEncryption.KeyEncryptionKey);
            Assert.AreEqual(options2.KeyResolver, client.ClientSideEncryption.KeyResolver);
            Assert.AreEqual(options2.KeyWrapAlgorithm, client.ClientSideEncryption.KeyWrapAlgorithm);
        }

#pragma warning disable CS0618 // obsolete
        [TestCase(ClientSideEncryptionVersion.V1_0, 16)] // a single cipher block
        [TestCase(ClientSideEncryptionVersion.V1_0, 14)] // a single unalligned cipher block
        [TestCase(ClientSideEncryptionVersion.V1_0, Constants.KB)] // multiple blocks
        [TestCase(ClientSideEncryptionVersion.V1_0, Constants.KB - 4)] // multiple unalligned blocks
        [TestCase(ClientSideEncryptionVersion.V1_0, Constants.MB)] // larger test, increasing likelihood to trigger async extension usage bugs
        // TODO don't move to recorded tests without making the encryption region size configurable
        [TestCase(ClientSideEncryptionVersion.V2_0, V2.EncryptionRegionDataSize)] // a single cipher block
        [TestCase(ClientSideEncryptionVersion.V2_0, V2.EncryptionRegionDataSize - 1000000)] // a single unalligned cipher block
        [TestCase(ClientSideEncryptionVersion.V2_0, 2 * V2.EncryptionRegionDataSize)] // multiple blocks
        [TestCase(ClientSideEncryptionVersion.V2_0, 2 * V2.EncryptionRegionDataSize - 1000000)] // multiple unalligned blocks
        [LiveOnly] // cannot seed content encryption key
#pragma warning restore CS0618 // obsolete
        public async Task UploadAsync(ClientSideEncryptionVersion version, long dataSize)
        {
            var plaintext = GetRandomBuffer(dataSize);
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(version)
                {
                    KeyEncryptionKey = mockKey,
                    KeyWrapAlgorithm = s_algorithmName
                }))
            {
                var blobName = GetNewBlobName();
                var blob = InstrumentClient(disposable.Container.GetBlobClient(blobName));

                // upload with encryption
                await blob.UploadAsync(new MemoryStream(plaintext), cancellationToken: s_cancellationToken);

                var encryptedData = await DownloadBypassDecryption(blob);
                byte[] expectedEncryptedData = await ReplicateEncryption(plaintext, await blob.GetPropertiesAsync(), mockKey);

                // compare data
                Assert.AreEqual(expectedEncryptedData, encryptedData);
            }
        }

#pragma warning disable CS0618 // obsolete
        [TestCase(ClientSideEncryptionVersion.V1_0, 16, 16)]
        [TestCase(ClientSideEncryptionVersion.V1_0, Constants.KB, 1000)] // unaligned write buffer
        [TestCase(ClientSideEncryptionVersion.V1_0, Constants.KB - 4, 1000)] // unalligned wite buffer and data
        [TestCase(ClientSideEncryptionVersion.V1_0, Constants.MB, 256 * Constants.KB)] // larger test, increasing likelihood to trigger async extension usage bugs
        // TODO don't move to recorded tests without making the encryption region size configurable
        [TestCase(ClientSideEncryptionVersion.V2_0, V2.EncryptionRegionDataSize, V2.EncryptionRegionDataSize)]
        [TestCase(ClientSideEncryptionVersion.V2_0, V2.EncryptionRegionDataSize - 1000000, Constants.MB)]
        [TestCase(ClientSideEncryptionVersion.V2_0, 2 * V2.EncryptionRegionDataSize, 1000000)] // multiple blocks w/ unallignment
        [LiveOnly] // cannot seed content encryption key
#pragma warning restore CS0618 // obsolete
        public async Task OpenWriteAsync(ClientSideEncryptionVersion version, long dataSize, int bufferSize)
        {
            var plaintext = GetRandomBuffer(dataSize);
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(version)
                {
                    KeyEncryptionKey = mockKey,
                    KeyWrapAlgorithm = s_algorithmName
                }))
            {
                var blobName = GetNewBlobName();
                var blob = InstrumentClient(disposable.Container.GetBlobClient(blobName));

                // upload with encryption
                using (Stream writeStream = await blob.OpenWriteAsync(true, new BlobOpenWriteOptions
                {
                    BufferSize = bufferSize,
                }, s_cancellationToken))
                {
                    Stream plaintextStream = new MemoryStream(plaintext);
                    if (IsAsync)
                    {
                        await plaintextStream.CopyToAsync(writeStream);
                    }
                    else
                    {
                        plaintextStream.CopyTo(writeStream);
                    }
                }

                var encryptedData = await DownloadBypassDecryption(blob);
                byte[] expectedEncryptedData = await ReplicateEncryption(plaintext, await blob.GetPropertiesAsync(), mockKey);

                // compare data
                Assert.AreEqual(expectedEncryptedData, encryptedData);
            }
        }

#pragma warning disable CS0618 // obsolete
        [TestCase(ClientSideEncryptionVersion.V1_0)]
        [TestCase(ClientSideEncryptionVersion.V2_0)]
        [LiveOnly] // cannot seed content encryption key
#pragma warning restore CS0618 // obsolete
        public async Task OpenWriteAsyncNoOpenWriteOptions(ClientSideEncryptionVersion version)
        {
            var plaintext = GetRandomBuffer(Constants.KB);
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(version)
                {
                    KeyEncryptionKey = mockKey,
                    KeyWrapAlgorithm = s_algorithmName
                }))
            {
                var blobName = GetNewBlobName();
                var blob = InstrumentClient(disposable.Container.GetBlobClient(blobName));

                // upload with encryption
                using (Stream writeStream = await blob.OpenWriteAsync(true, options: default, s_cancellationToken))
                {
                    Stream plaintextStream = new MemoryStream(plaintext);
                    if (IsAsync)
                    {
                        await plaintextStream.CopyToAsync(writeStream);
                    }
                    else
                    {
                        plaintextStream.CopyTo(writeStream);
                    }
                }

                var encryptedData = await DownloadBypassDecryption(blob);
                byte[] expectedEncryptedData = await ReplicateEncryption(plaintext, await blob.GetPropertiesAsync(), mockKey);

                // compare data
                Assert.AreEqual(expectedEncryptedData, encryptedData);
            }
        }

#pragma warning disable CS0618 // obsolete
        [TestCase(ClientSideEncryptionVersion.V1_0)]
        [TestCase(ClientSideEncryptionVersion.V2_0)]
        [LiveOnly] // cannot seed content encryption key
#pragma warning restore CS0618 // obsolete
        public async Task UploadAsync_OverwritesDeliberately_BinaryData(ClientSideEncryptionVersion version)
        {
            var plaintext = GetRandomBuffer(Constants.KB);
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(version)
                {
                    KeyEncryptionKey = mockKey,
                    KeyWrapAlgorithm = s_algorithmName
                }))
            {
                var blobName = GetNewBlobName();
                var blob = InstrumentClient(disposable.Container.GetBlobClient(blobName));

                // upload with encryption
                await blob.UploadAsync(BinaryData.FromBytes(plaintext), cancellationToken: s_cancellationToken);

                // overwrite with encryption
                plaintext = GetRandomBuffer(Constants.KB);
                await blob.UploadAsync(BinaryData.FromBytes(plaintext), cancellationToken: s_cancellationToken, overwrite: true);

                var encryptedData = await DownloadBypassDecryption(blob);
                byte[] expectedEncryptedData = await ReplicateEncryption(plaintext, await blob.GetPropertiesAsync(), mockKey);

                // compare data
                Assert.AreEqual(expectedEncryptedData, encryptedData);
            }
        }

        [Test]
        [Combinatorial]
        [LiveOnly] // cannot seed content encryption key
        public async Task UploadAsyncSplit(
            [Values(1, 2, 4, 8)] int concurrency,
            [ValueSource("GetEncryptionVersions")] ClientSideEncryptionVersion version)
        {
            int blockSize = Constants.KB;
            int dataSize = 16 * Constants.KB;
            var plaintext = GetRandomBuffer(dataSize);
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(version)
                {
                    KeyEncryptionKey = mockKey,
                    KeyWrapAlgorithm = s_algorithmName
                }))
            {
                var blobName = GetNewBlobName();
                var blob = InstrumentClient(disposable.Container.GetBlobClient(blobName));

                // upload with encryption
                await blob.UploadAsync(
                    new MemoryStream(plaintext),
                    new BlobUploadOptions
                    {
                        TransferOptions = new StorageTransferOptions
                        {
                            InitialTransferSize = blockSize,
                            MaximumTransferSize = blockSize,
                            MaximumConcurrency = concurrency
                        }
                    },
                    cancellationToken: s_cancellationToken);

                var encryptedData = await DownloadBypassDecryption(blob);
                byte[] expectedEncryptedData = await ReplicateEncryption(plaintext, await blob.GetPropertiesAsync(), mockKey);

                // compare data
                Assert.AreEqual(expectedEncryptedData, encryptedData);
            }
        }

#pragma warning disable CS0618 // obsolete
        [TestCase(ClientSideEncryptionVersion.V1_0, 16, null)] // a single cipher block
        [TestCase(ClientSideEncryptionVersion.V1_0, 14, null)] // a single unalligned cipher block
        [TestCase(ClientSideEncryptionVersion.V1_0, Constants.KB, null)] // multiple blocks
        [TestCase(ClientSideEncryptionVersion.V1_0, Constants.KB - 4, null)] // multiple unalligned blocks
        [TestCase(ClientSideEncryptionVersion.V1_0, Constants.MB, 64 * Constants.KB)] // make sure we cache unwrapped key for large downloads
        // TODO don't move to recorded tests without making the encryption region size configurable
        [TestCase(ClientSideEncryptionVersion.V2_0, V2.EncryptionRegionDataSize, null)] // a single cipher block
        [TestCase(ClientSideEncryptionVersion.V2_0, V2.EncryptionRegionDataSize - 1000000, null)] // a single unalligned cipher block
        [TestCase(ClientSideEncryptionVersion.V2_0, 2 * V2.EncryptionRegionDataSize, null)] // multiple blocks
        [TestCase(ClientSideEncryptionVersion.V2_0, 2 * V2.EncryptionRegionDataSize - 1000000, null)] // multiple unalligned blocks
        [LiveOnly] // cannot seed content encryption key
#pragma warning restore CS0618 // obsolete
        public async Task RoundtripAsync(ClientSideEncryptionVersion version, long dataSize, long? initialDownloadRequestSize)
        {
            var data = GetRandomBuffer(dataSize);
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken);
            var mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, mockKey.Object).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(version)
                {
                    KeyEncryptionKey = mockKey.Object,
                    KeyResolver = mockKeyResolver,
                    KeyWrapAlgorithm = s_algorithmName
                }))
            {
                var blob = InstrumentClient(disposable.Container.GetBlobClient(GetNewBlobName()));

                // upload with encryption
                await blob.UploadAsync(new MemoryStream(data), cancellationToken: s_cancellationToken);

                // download with decryption
                byte[] downloadData;
                using (var stream = new MemoryStream())
                {
                    await blob.DownloadToAsync(stream,
                        transferOptions: new StorageTransferOptions() { InitialTransferSize = initialDownloadRequestSize },
                        cancellationToken: s_cancellationToken);
                    downloadData = stream.ToArray();
                }

                // compare data
                Assert.AreEqual(data, downloadData);
                VerifyUnwrappedKeyWasCached(mockKey);
            }
        }

        [Test]
        [Combinatorial]
        [LiveOnly] // cannot seed content encryption key
        public async Task RoundtripSplitAsync(
            [Values(1, 2, 4, 8)] int concurrency,
            [ValueSource("GetEncryptionVersions")] ClientSideEncryptionVersion version)
        {
            int blockSize = Constants.KB;
            int dataSize = 16 * Constants.KB;

            var data = GetRandomBuffer(dataSize);
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken);
            var mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, mockKey.Object).Object;
            var transferOptions = new StorageTransferOptions
            {
                InitialTransferSize = blockSize,
                MaximumTransferSize = blockSize,
                MaximumConcurrency = concurrency
            };
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(version)
                {
                    KeyEncryptionKey = mockKey.Object,
                    KeyResolver = mockKeyResolver,
                    KeyWrapAlgorithm = s_algorithmName
                }))
            {
                var blob = InstrumentClient(disposable.Container.GetBlobClient(GetNewBlobName()));

                // upload with encryption
                await blob.UploadAsync(new MemoryStream(data), transferOptions: transferOptions, cancellationToken: s_cancellationToken);

                // download with decryption
                byte[] downloadData;
                using (var stream = new MemoryStream())
                {
                    await blob.DownloadToAsync(stream,
                        transferOptions: transferOptions,
                        cancellationToken: s_cancellationToken);
                    downloadData = stream.ToArray();
                }

                // compare data
                Assert.AreEqual(data, downloadData);
                VerifyUnwrappedKeyWasCached(mockKey);
            }
        }

#pragma warning disable CS0618 // obsolete
        [TestCase(ClientSideEncryptionVersion.V1_0, Constants.MB, 64 * Constants.KB)]
        [TestCase(ClientSideEncryptionVersion.V1_0, Constants.MB, Constants.MB)]
        [TestCase(ClientSideEncryptionVersion.V1_0, Constants.MB, 4 * Constants.MB)]
        [TestCase(ClientSideEncryptionVersion.V2_0, Constants.MB, 128 * Constants.KB)]
        [TestCase(ClientSideEncryptionVersion.V2_0, 2 * V2.EncryptionRegionDataSize, Constants.MB)]
        [TestCase(ClientSideEncryptionVersion.V2_0, 2 * V2.EncryptionRegionDataSize + 1000, Constants.MB + 15)]
        [LiveOnly] // cannot seed content encryption key
#pragma warning restore CS0618 // obsolete
        public async Task RoundtripAsyncWithOpenRead(ClientSideEncryptionVersion version, long dataSize, int bufferSize)
        {
            var data = GetRandomBuffer(dataSize);
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken);
            var mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, mockKey.Object).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(version)
                {
                    KeyEncryptionKey = mockKey.Object,
                    KeyResolver = mockKeyResolver,
                    KeyWrapAlgorithm = s_algorithmName
                }))
            {
                var blob = InstrumentClient(disposable.Container.GetBlobClient(GetNewBlobName()));

                // upload with encryption
                await blob.UploadAsync(new MemoryStream(data), cancellationToken: s_cancellationToken);

                // download with decryption
                byte[] downloadData;
                using (var stream = new MemoryStream())
                {
                    using var blobStream = await blob.OpenReadAsync(new BlobOpenReadOptions(false) { BufferSize = bufferSize }, cancellationToken: s_cancellationToken);
                    if (IsAsync)
                    {
                        await blobStream.CopyToAsync(stream, bufferSize, s_cancellationToken);
                    } else
                    {
                        blobStream.CopyTo(stream, bufferSize);
                    }
                    downloadData = stream.ToArray();
                }

                // compare data
                Assert.AreEqual(data, downloadData);
                VerifyUnwrappedKeyWasCached(mockKey);
            }
        }

        [Test]
        [LiveOnly] // cannot seed content encryption key
        public async Task RoundtripWithMetadata([ValueSource("GetEncryptionVersions")] ClientSideEncryptionVersion version)
        {
            // Arrange

            var data = GetRandomBuffer(Constants.KB);
            var metadata = new Dictionary<string, string>
            {
                { "foo", "bar" },
                { "fizz", "buzz" }
            };
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken);
            var mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, mockKey.Object).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(version)
                {
                    KeyEncryptionKey = mockKey.Object,
                    KeyResolver = mockKeyResolver,
                    KeyWrapAlgorithm = s_algorithmName
                }))
            {
                var blob = InstrumentClient(disposable.Container.GetBlobClient(GetNewBlobName()));

                // Act

                await blob.UploadAsync(new MemoryStream(data), metadata: metadata, cancellationToken: s_cancellationToken);

                // Assert

                // caller-provided metadata unchanged after upload
                Assert.AreEqual(2, metadata.Count);
                Assert.AreEqual("bar", metadata["foo"]);
                Assert.AreEqual("buzz", metadata["fizz"]);

                // downloaded content and metadata as expected
                var result = await blob.DownloadContentAsync(cancellationToken: s_cancellationToken);
                Assert.AreEqual(data, result.Value.Content.ToArray());
                IDictionary<string, string> downloadedMetadata = result.Value.Details.Metadata;
                Assert.AreEqual(metadata.Count + 1, downloadedMetadata.Count);
                foreach (var kvp in metadata)
                {
                    Assert.IsTrue(downloadedMetadata.ContainsKey(kvp.Key));
                    Assert.AreEqual(metadata[kvp.Key], downloadedMetadata[kvp.Key]);
                }
                Assert.IsTrue(downloadedMetadata.ContainsKey(EncryptionDataKey));
                Assert.AreEqual(version, EncryptionDataSerializer.Deserialize(downloadedMetadata[EncryptionDataKey]).EncryptionAgent.EncryptionVersion);
            }
        }

        [Test] // multiple unalligned blocks
        [LiveOnly] // cannot seed content encryption key
        public async Task KeyResolverKicksIn([ValueSource("GetEncryptionVersions")] ClientSideEncryptionVersion version)
        {
            var data = GetRandomBuffer(Constants.KB);
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object;
            var mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, mockKey).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(version)
                {
                    KeyEncryptionKey = mockKey,
                    KeyWrapAlgorithm = s_algorithmName
                }))
            {
                string blobName = GetNewBlobName();
                // upload with encryption
                await InstrumentClient(disposable.Container.GetBlobClient(blobName)).UploadAsync(new MemoryStream(data), cancellationToken: s_cancellationToken);

                // download with decryption and no cached key
                byte[] downloadData;
                using (var stream = new MemoryStream())
                {
                    var options = GetOptions();
                    options._clientSideEncryptionOptions = new ClientSideEncryptionOptions(version)
                    {
                        KeyResolver = mockKeyResolver
                    };
                    await InstrumentClient(new BlobContainerClient(disposable.Container.Uri, Tenants.GetNewSharedKeyCredentials(), options).GetBlobClient(blobName)).DownloadToAsync(stream, cancellationToken: s_cancellationToken);
                    downloadData = stream.ToArray();
                }

                // compare data
                Assert.AreEqual(data, downloadData);
            }
        }

#pragma warning disable CS0618 // obsolete
        [TestCase(ClientSideEncryptionVersion.V1_0, 0, 16)]  // first block
        [TestCase(ClientSideEncryptionVersion.V1_0, 16, 16)] // not first block
        [TestCase(ClientSideEncryptionVersion.V1_0, 32, 32)] // multiple blocks; IV not at blob start
        [TestCase(ClientSideEncryptionVersion.V1_0, 16, 17)] // overlap end of block
        [TestCase(ClientSideEncryptionVersion.V1_0, 32, 17)] // overlap end of block; IV not at blob start
        [TestCase(ClientSideEncryptionVersion.V1_0, 15, 17)] // overlap beginning of block
        [TestCase(ClientSideEncryptionVersion.V1_0, 31, 17)] // overlap beginning of block; IV not at blob start
        [TestCase(ClientSideEncryptionVersion.V1_0, 15, 18)] // overlap both sides
        [TestCase(ClientSideEncryptionVersion.V1_0, 31, 18)] // overlap both sides; IV not at blob start
        [TestCase(ClientSideEncryptionVersion.V1_0, 16, null)]
        // TODO don't move to recorded tests until we can get off 4MB blocks for tests
        [TestCase(ClientSideEncryptionVersion.V2_0, 0, V2.EncryptionRegionDataSize)]  // first region
        [TestCase(ClientSideEncryptionVersion.V2_0, V2.EncryptionRegionDataSize, V2.EncryptionRegionDataSize)] // not first region
        [TestCase(ClientSideEncryptionVersion.V2_0, 0, 2 * V2.EncryptionRegionDataSize)] // multiple regions
        [TestCase(ClientSideEncryptionVersion.V2_0, V2.EncryptionRegionDataSize, V2.EncryptionRegionDataSize + 1)] // overlap end of region
        [TestCase(ClientSideEncryptionVersion.V2_0, V2.EncryptionRegionDataSize - 1, V2.EncryptionRegionDataSize + 1)] // overlap beginning of region
        [TestCase(ClientSideEncryptionVersion.V2_0, V2.EncryptionRegionDataSize - 1, V2.EncryptionRegionDataSize + 2)] // overlap both sides
        [TestCase(ClientSideEncryptionVersion.V2_0, 1024, 30)] // small range inside region
        [TestCase(ClientSideEncryptionVersion.V2_0, V2.EncryptionRegionDataSize + 1024, 30)] // small range inside non-first region
        [TestCase(ClientSideEncryptionVersion.V2_0, V2.EncryptionRegionDataSize, null)] // second region to end
        [LiveOnly] // cannot seed content encryption key
#pragma warning restore CS0618 // obsolete
        public async Task PartialDownloadAsync(ClientSideEncryptionVersion version, int offset, int? count)
        {
            int countDefault = version switch
            {
#pragma warning disable CS0618 // obsolete
                ClientSideEncryptionVersion.V1_0 => 16,
#pragma warning restore CS0618 // obsolete
                ClientSideEncryptionVersion.V2_0 => V2.EncryptionRegionDataSize,
                _ => throw new ArgumentException()
            };
            var data = GetRandomBuffer(offset + (count ?? countDefault) + 32); // ensure we have enough room in original data
            var mockKey = this.GetIKeyEncryptionKey(expectedCancellationToken: s_cancellationToken).Object;
            var mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, mockKey).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(version)
                {
                    KeyEncryptionKey = mockKey,
                    KeyResolver = mockKeyResolver,
                    KeyWrapAlgorithm = s_algorithmName
                }))
            {
                var blob = InstrumentClient(disposable.Container.GetBlobClient(GetNewBlobName()));

                // upload with encryption
                await blob.UploadAsync(new MemoryStream(data), cancellationToken: s_cancellationToken);

                // download range with decryption
                byte[] downloadData; // no overload that takes Stream and HttpRange; we must buffer read
                Stream downloadStream = (await blob.DownloadAsync(new HttpRange(offset, count), cancellationToken: s_cancellationToken)).Value.Content;
                byte[] buffer = new byte[Constants.KB];
                using (MemoryStream stream = new MemoryStream())
                {
                    int read;
                    while ((read = downloadStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        stream.Write(buffer, 0, read);
                    }
                    downloadData = stream.ToArray();
                }

                // compare range of original data to downloaded data
                var slice = data.Skip(offset);
                slice = count.HasValue
                    ? slice.Take(count.Value)
                    : slice;
                var sliceArray = slice.ToArray();
                Assert.AreEqual(sliceArray, downloadData);
            }
        }

        [Test]
        [LiveOnly] // cannot seed content encryption key
        public async Task Track2DownloadTrack1Blob()
        {
            var data = GetRandomBuffer(Constants.KB);

            var keyEncryptionKeyBytes = this.GenerateKeyBytes();
            var keyId = this.GenerateKeyId();

            var mockKey = this.GetTrackOneIKey(keyEncryptionKeyBytes, keyId).Object;
            var mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, this.GetIKeyEncryptionKey(s_cancellationToken, keyEncryptionKeyBytes, keyId).Object).Object;
#pragma warning disable CS0618 // obsolete
            await using (var disposable = await GetTestContainerEncryptionAsync(new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
            {
                KeyResolver = mockKeyResolver,
                KeyWrapAlgorithm = s_algorithmName
            }))
#pragma warning restore CS0618 // obsolete
            {
                var track2Blob = InstrumentClient(disposable.Container.GetBlobClient(GetNewBlobName()));

                // upload with track 1
                var creds = Tenants.GetNewSharedKeyCredentials();
                var track1Blob = new Microsoft.Azure.Storage.Blob.CloudBlockBlob(
                    track2Blob.Uri,
                    new Microsoft.Azure.Storage.Auth.StorageCredentials(creds.AccountName, creds.GetAccountKey()));
                var track1RequestOptions = new Microsoft.Azure.Storage.Blob.BlobRequestOptions()
                {
                    EncryptionPolicy = new Microsoft.Azure.Storage.Blob.BlobEncryptionPolicy(mockKey, default)
                };
                if (IsAsync) // can't instrument track 1
                {
                    await track1Blob.UploadFromByteArrayAsync(data, 0, data.Length, default, track1RequestOptions, default, s_cancellationToken);
                }
                else
                {
                    track1Blob.UploadFromByteArray(data, 0, data.Length, default, track1RequestOptions, default);
                }

                // download with track 2
                var downloadStream = new MemoryStream();
                await track2Blob.DownloadToAsync(downloadStream, cancellationToken: s_cancellationToken);

                // compare original data to downloaded data
                Assert.AreEqual(data, downloadStream.ToArray());
            }
        }

        [Test]
        [LiveOnly] // cannot seed content encryption key
        public async Task Track1DownloadTrack2Blob()
        {
            var data = GetRandomBuffer(Constants.KB); // ensure we have enough room in original data

            var keyEncryptionKeyBytes = this.GenerateKeyBytes();
            var keyId = this.GenerateKeyId();

            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken, keyEncryptionKeyBytes, keyId).Object;
            var mockKeyResolver = this.GetTrackOneIKeyResolver(this.GetTrackOneIKey(keyEncryptionKeyBytes, keyId).Object).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(
#pragma warning disable CS0618 // obsolete
                new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
                {
                    KeyEncryptionKey = mockKey,
                    KeyWrapAlgorithm = s_algorithmName
                }))
#pragma warning restore CS0618 // obsolete
            {
                var track2Blob = InstrumentClient(disposable.Container.GetBlobClient(GetNewBlobName()));

                // upload with track 2
                await track2Blob.UploadAsync(new MemoryStream(data), cancellationToken: s_cancellationToken);

                // download with track 1
                var creds = Tenants.GetNewSharedKeyCredentials();
                var track1Blob = new Microsoft.Azure.Storage.Blob.CloudBlockBlob(
                    track2Blob.Uri,
                    new Microsoft.Azure.Storage.Auth.StorageCredentials(creds.AccountName, creds.GetAccountKey()));
                var downloadData = new byte[data.Length];
                var track1RequestOptions = new Microsoft.Azure.Storage.Blob.BlobRequestOptions()
                {
                    EncryptionPolicy = new Microsoft.Azure.Storage.Blob.BlobEncryptionPolicy(default, mockKeyResolver)
                };
                if (IsAsync) // can't instrument track 1
                {
                    await track1Blob.DownloadToByteArrayAsync(downloadData, 0, default, track1RequestOptions, default, s_cancellationToken);
                }
                else
                {
                    track1Blob.DownloadToByteArray(downloadData, 0, default, track1RequestOptions, default);
                }

                // compare original data to downloaded data
                Assert.AreEqual(data, downloadData);
            }
        }

        /// <summary>
        /// Track 1 had a bug where it used default casing settings for serializing properties,
        /// which the application writer could change. So there exists encryption metadata in
        /// Storage we do not know the casing of. We need to be able to deserialize those objects.
        /// </summary>
        [Test]
        [LiveOnly]
        public async Task DownloadBadCasing()
        {
            var data = new BinaryData(GetRandomBuffer(Constants.KB)); // ensure we have enough room in original data

            var keyEncryptionKeyBytes = this.GenerateKeyBytes();
            var keyId = this.GenerateKeyId();

            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken, keyEncryptionKeyBytes, keyId).Object;
            await using var disposable = await GetTestContainerEncryptionAsync(
#pragma warning disable CS0618 // obsolete
                new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
                {
                    KeyEncryptionKey = mockKey,
                    KeyWrapAlgorithm = s_algorithmName
                });

            var blob = InstrumentClient(disposable.Container.GetBlobClient(GetNewBlobName()));
            await blob.UploadAsync(data.ToStream(), cancellationToken: s_cancellationToken);

            // tamper metadata json key casing
            Assert.IsTrue((await blob.GetPropertiesAsync()).Value.Metadata.TryGetValue(EncryptionDataKey, out string rawEncryptionData));
            // pattern to match restated without string literal escapes: /"(\w+)"\s*:/
            // matches json property key and captures the text inside the quotations
            // (regex not perfect but will capture in our scenario)
            // replaces captured key with ToUpper of said key, ensuring casing is unexpected but we can parse it anyway on download
            rawEncryptionData = Regex.Replace(rawEncryptionData, "\"(\\w+)\"\\s*:", match => match.Value.ToUpper());
            await blob.SetMetadataAsync(new Dictionary<string, string>
            {
                { EncryptionDataKey, rawEncryptionData }
            });

            Assert.DoesNotThrowAsync(async () => await blob.DownloadContentAsync(cancellationToken: s_cancellationToken));
        }

        [Test]
        [LiveOnly] // need access to keyvault service && cannot seed content encryption key
        public async Task RoundtripWithKeyvaultProvider([ValueSource("GetEncryptionVersions")] ClientSideEncryptionVersion version)
        {
            var data = GetRandomBuffer(Constants.KB);
            IKeyEncryptionKey key = await GetKeyvaultIKeyEncryptionKey();
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(version)
                {
                    KeyEncryptionKey = key,
                    KeyWrapAlgorithm = "RSA-OAEP-256"
                }))
            {
                var blob = disposable.Container.GetBlobClient(GetNewBlobName());

                await blob.UploadAsync(new MemoryStream(data), cancellationToken: s_cancellationToken);

                var downloadStream = new MemoryStream();
                await blob.DownloadToAsync(downloadStream, cancellationToken: s_cancellationToken);

                Assert.AreEqual(data, downloadStream.ToArray());
            }
        }

#pragma warning disable CS0618 // obsolete
        [TestCase(ClientSideEncryptionVersion.V1_0, Constants.MB, 64*Constants.KB)]
        [TestCase(ClientSideEncryptionVersion.V2_0,  Constants.MB, 64 * Constants.KB)]
        [LiveOnly] // need access to keyvault service && cannot seed content encryption key
#pragma warning restore CS0618 // obsolete
        public async Task RoundtripWithKeyvaultProviderOpenRead(ClientSideEncryptionVersion version, long dataSize, int bufferSize)
        {
            var data = GetRandomBuffer(dataSize);
            IKeyEncryptionKey key = await GetKeyvaultIKeyEncryptionKey();
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(version)
                {
                    KeyEncryptionKey = key,
                    KeyWrapAlgorithm = "RSA-OAEP-256"
                }))
            {
                var blob = disposable.Container.GetBlobClient(GetNewBlobName());

                await blob.UploadAsync(new MemoryStream(data), cancellationToken: s_cancellationToken);

                var downloadStream = new MemoryStream();
                using var blobStream = await blob.OpenReadAsync(new BlobOpenReadOptions(false) { BufferSize = bufferSize});
                await blobStream.CopyToAsync(downloadStream);

                Assert.AreEqual(data, downloadStream.ToArray());
            }
        }

        [Test]
        [Combinatorial]
        [LiveOnly]
        public async Task CannotFindKeyAsync(
            [Values(true, false)] bool resolverThrows,
            [ValueSource("GetEncryptionVersions")] ClientSideEncryptionVersion version)
        {
            var data = GetRandomBuffer(Constants.KB);
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(version)
                {
                    KeyEncryptionKey = mockKey,
                    KeyWrapAlgorithm = s_algorithmName
                }))
            {
                var blob = InstrumentClient(disposable.Container.GetBlobClient(GetNewBlobName()));
                await blob.UploadAsync(new MemoryStream(data), cancellationToken: s_cancellationToken);

                bool threw = false;
                var resolver = this.GetAlwaysFailsKeyResolver(s_cancellationToken, resolverThrows);
                try
                {
                    // download but can't find key
                    var options = GetOptions();
                    options._clientSideEncryptionOptions = new ClientSideEncryptionOptions(version)
                    {
                        KeyResolver = resolver.Object,
                        KeyWrapAlgorithm = "test"
                    };
                    var encryptedDataStream = new MemoryStream();
                    await InstrumentClient(new BlobClient(blob.Uri, Tenants.GetNewSharedKeyCredentials(), options)).DownloadToAsync(encryptedDataStream, cancellationToken: s_cancellationToken);
                }
                catch (MockException e)
                {
                    Assert.Fail(e.Message);
                }
                catch (Exception)
                {
                    threw = true;
                }
                finally
                {
                    Assert.IsTrue(threw);
                    // we already asserted the correct method was called in `catch (MockException e)`
                    Assert.AreEqual(1, resolver.Invocations.Count);
                }
            }
        }

        // using 5 to setup offsets to avoid any off-by-one confusion in debugging
        [TestCase(0, null)]
        [TestCase(0, 2 * EncryptionBlockSize)]
        [TestCase(0, 2 * EncryptionBlockSize + 5)]
        [TestCase(EncryptionBlockSize, EncryptionBlockSize)]
        [TestCase(EncryptionBlockSize, EncryptionBlockSize + 5)]
        [TestCase(EncryptionBlockSize + 5, 2 * EncryptionBlockSize)]
        [LiveOnly]
        public async Task AppropriateRangeDownloadOnPlaintext(int rangeOffset, int? rangeLength)
        {
            var data = GetRandomBuffer(rangeOffset + (rangeLength ?? Constants.KB) + EncryptionBlockSize);
            var mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, this.GetIKeyEncryptionKey(s_cancellationToken).Object).Object;
            await using (var disposable = await GetTestContainerAsync())
            {
                // upload plaintext
                var blob = disposable.Container.GetBlobClient(GetNewBlobName());
                await blob.UploadAsync(new MemoryStream(data));

                // download plaintext range with encrypted client
                var cryptoClient = InstrumentClient(new BlobClient(blob.Uri, Tenants.GetNewSharedKeyCredentials(), new SpecializedBlobClientOptions()
                {
                    ClientSideEncryption = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V2_0)
                    {
                        KeyResolver = mockKeyResolver
                    }
                }));
                var desiredRange = new HttpRange(rangeOffset, rangeLength);
                var response = await cryptoClient.DownloadAsync(desiredRange);

                // assert we recieved the data we requested
                int expectedLength = rangeLength ?? data.Length - rangeOffset;
                var memoryStream = new MemoryStream();
                await response.Value.Content.CopyToAsync(memoryStream);
                var recievedData = memoryStream.ToArray();
                Assert.AreEqual(expectedLength, recievedData.Length);
                for (int i = 0; i < recievedData.Length; i++)
                {
                    Assert.AreEqual(data[i + rangeOffset], recievedData[i]);
                }
            }
        }

        [Test]
        [LiveOnly] // cannot seed content encryption key
        [Ignore("stress test")]
        public async Task StressManyBlobsAsync([ValueSource("GetEncryptionVersions")] ClientSideEncryptionVersion version)
        {
            static async Task<byte[]> RoundTripData(BlobClient client, byte[] data)
            {
                using (var dataStream = new MemoryStream(data))
                {
                    await client.UploadAsync(dataStream, cancellationToken: s_cancellationToken);
                }

                using (var downloadStream = new MemoryStream())
                {
                    await client.DownloadToAsync(downloadStream, cancellationToken: s_cancellationToken);
                    return downloadStream.ToArray();
                }
            }

            var data = GetRandomBuffer(10 * Constants.MB);
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object;
            var mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, mockKey).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(version)
                {
                    KeyEncryptionKey = mockKey,
                    KeyResolver = mockKeyResolver,
                    KeyWrapAlgorithm = s_algorithmName
                }))
            {
                var downloadTasks = new List<Task<byte[]>>();
                foreach (var _ in Enumerable.Range(0, 10))
                {
                    var blob = disposable.Container.GetBlobClient(GetNewBlobName());

                    downloadTasks.Add(RoundTripData(blob, data));
                }

                var downloads = await Task.WhenAll(downloadTasks);

                foreach (byte[] downloadData in downloads)
                {
                    Assert.AreEqual(data, downloadData);
                }
            }
        }

        [Test]
        [LiveOnly] // cannot seed content encryption key
        [Ignore("stress test")]
        public async Task StressLargeBlobAsync([ValueSource("GetEncryptionVersions")] ClientSideEncryptionVersion version)
        {
            const int dataSize = 100 * Constants.MB;
            const int blockSize = 8 * Constants.MB;

            var data = GetRandomBuffer(dataSize);
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object;
            var mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, mockKey).Object;
            var transferOptions = new StorageTransferOptions
            {
                InitialTransferSize = blockSize,
                MaximumTransferSize = blockSize,
                MaximumConcurrency = 100
            };
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(version)
                {
                    KeyEncryptionKey = mockKey,
                    KeyResolver = mockKeyResolver,
                    KeyWrapAlgorithm = s_algorithmName
                }))
            {
                var client = disposable.Container.GetBlobClient(GetNewBlobName());
                using (var dataStream = new MemoryStream(data))
                {
                    await client.UploadAsync(dataStream, transferOptions: transferOptions, cancellationToken: s_cancellationToken);
                }

                byte[] downloadResult;
                using (var downloadStream = new MemoryStream())
                {
                    await client.DownloadToAsync(downloadStream, transferOptions: transferOptions, cancellationToken: s_cancellationToken);
                    downloadResult = downloadStream.ToArray();
                }

                Assert.AreEqual(data, downloadResult);
            }
        }

        [Test]
        [LiveOnly]
        public async Task EncryptedReuploadSuccess([ValueSource("GetEncryptionVersions")] ClientSideEncryptionVersion version)
        {
            var originalData = GetRandomBuffer(Constants.KB);
            var editedData = GetRandomBuffer(Constants.KB);
            (string Key, string Value) originalMetadata = ("foo", "bar");
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(version)
                {
                    KeyEncryptionKey = mockKey,
                    KeyWrapAlgorithm = s_algorithmName
                }))
            {
                var encryptedBlobClient = InstrumentClient(disposable.Container.GetBlobClient(GetNewBlobName()));

                // upload data with encryption
                await encryptedBlobClient.UploadAsync(
                    new MemoryStream(originalData),
                    new BlobUploadOptions
                    {
                        Metadata = new Dictionary<string, string> { { originalMetadata.Key, originalMetadata.Value } }
                    },
                    cancellationToken: s_cancellationToken);

                // download with decryption
                var downloadResult = await encryptedBlobClient.DownloadAsync(cancellationToken: s_cancellationToken);
                Assert.AreEqual(2, downloadResult.Value.Details.Metadata.Count);
                Assert.IsTrue(downloadResult.Value.Details.Metadata.ContainsKey(originalMetadata.Key));
                Assert.IsTrue(downloadResult.Value.Details.Metadata.ContainsKey(Constants.ClientSideEncryption.EncryptionDataKey));
                var firstDownloadEncryptionData = downloadResult.Value.Details.Metadata[Constants.ClientSideEncryption.EncryptionDataKey];

                // reupload edited blob, maintaining metadata as we recommend to customers
                await encryptedBlobClient.UploadAsync(
                    new MemoryStream(editedData),
                    new BlobUploadOptions
                    {
                        Metadata = downloadResult.Value.Details.Metadata
                    },
                    cancellationToken: s_cancellationToken);

                // if we didn't throw, success in reuploading with new encryption metadata
                // download edited blob to assert expected data was uploaded
                downloadResult = await encryptedBlobClient.DownloadAsync(cancellationToken: s_cancellationToken);
                Assert.AreEqual(2, downloadResult.Value.Details.Metadata.Count);
                Assert.IsTrue(downloadResult.Value.Details.Metadata.ContainsKey(originalMetadata.Key));
                Assert.IsTrue(downloadResult.Value.Details.Metadata.ContainsKey(Constants.ClientSideEncryption.EncryptionDataKey));
                Assert.AreNotEqual(firstDownloadEncryptionData, downloadResult.Value.Details.Metadata[Constants.ClientSideEncryption.EncryptionDataKey]);
            }
        }

        [Test]
        [Combinatorial]
        [LiveOnly]
        /// <summary>
        /// Crypto transform streams are unseekable and have no <see cref="Stream.Length"/>.
        /// When length is unknown, <see cref="PartitionedUploader{TServiceSpecificArgs, TCompleteUploadReturn}"/>
        /// doesn't even attempt a one-shot upload.
        /// This tests if we correctly inform the uploader of an expected stream length so it
        /// can respect the given <see cref="StorageTransferOptions"/>.
        /// </summary>
        public async Task PutBlobPutBlockSwitch(
            [Values(true, false)] bool oneshot,
            [ValueSource("GetEncryptionVersions")] ClientSideEncryptionVersion version)
        {
            const int dataSize = 1 * Constants.KB;

            // Arrange
            byte[] data = GetRandomBuffer(dataSize);
            int transferSize = oneshot
                    ? 2 * dataSize // big enough for put blob even after padding or nonces/tags
                    : dataSize / 2;
            StorageTransferOptions transferOptions = new StorageTransferOptions
            {
                InitialTransferSize = transferSize,
                MaximumTransferSize = transferSize
            };

            IKeyEncryptionKey key = this.GetIKeyEncryptionKey(s_cancellationToken).Object;
            await using var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(version)
                {
                    KeyEncryptionKey = key,
                    KeyWrapAlgorithm = s_algorithmName
                });
            var blob = disposable.Container.GetBlobClient(GetNewBlobName());

            // Act
            await blob.UploadAsync(
                new MemoryStream(data),
                new BlobUploadOptions { TransferOptions = transferOptions },
                cancellationToken: s_cancellationToken);

            // Assert
            Assert.IsTrue(await blob.ExistsAsync());
            Assert.Greater((await blob.GetPropertiesAsync()).Value.ContentLength, 0);
            // block list will return empty when putblob was used
            BlockList blockList = await BlobsClientBuilder.ToBlockBlobClient(blob).GetBlockListAsync();
            Assert.IsEmpty(blockList.UncommittedBlocks);
            if (oneshot)
            {
                Assert.IsEmpty(blockList.CommittedBlocks);
            }
            else
            {
                Assert.IsNotEmpty(blockList.CommittedBlocks);
            }
        }

        [RecordedTest]
        public void CanGenerateSas_WithClientSideEncryptionOptions_True(
            [ValueSource("GetEncryptionVersions")] ClientSideEncryptionVersion version)
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            var options = new ClientSideEncryptionOptions(version)
            {
                KeyEncryptionKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object,
                KeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, default).Object,
                KeyWrapAlgorithm = "bar"
            };

            // Create blob
            BlobClient blob = InstrumentClient(new BlobClient(
                connectionString,
                GetNewContainerName(),
                GetNewBlobName()));
            Assert.IsTrue(blob.CanGenerateSasUri);

            // Act
            BlobClient blobEncrypted = blob.WithClientSideEncryptionOptions(options);

            // Assert
            Assert.IsTrue(blobEncrypted.CanGenerateSasUri);
        }

        [RecordedTest]
        public void CanGenerateSas_WithClientSideEncryptionOptions_False(
            [ValueSource("GetEncryptionVersions")] ClientSideEncryptionVersion version)
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);

            var options = new ClientSideEncryptionOptions(version)
            {
                KeyEncryptionKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object,
                KeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, default).Object,
                KeyWrapAlgorithm = "bar"
            };

            // Create blob
            BlobClient blob = InstrumentClient(new BlobClient(
                blobEndpoint,
                GetOptions()));
            Assert.IsFalse(blob.CanGenerateSasUri);

            // Act
            BlobClient blobEncrypted = blob.WithClientSideEncryptionOptions(options);

            // Assert
            Assert.IsFalse(blobEncrypted.CanGenerateSasUri);
        }
        [Test]
        public void CanParseLargeContentRange()
        {
            long compareValue = (long)Int32.MaxValue + 1; //Increase max int32 by one
            ContentRange contentRange = ContentRange.Parse($"bytes 0 {compareValue} {compareValue}");
            Assert.AreEqual((long)Int32.MaxValue + 1, contentRange.Size);
            Assert.AreEqual(0, contentRange.Start);
            Assert.AreEqual((long)Int32.MaxValue + 1, contentRange.End);
        }

        [RecordedTest]
        [Combinatorial]
        public async Task UpdateKey(
            [Values(true, false)] bool useOverrides,
            [ValueSource("GetEncryptionVersions")] ClientSideEncryptionVersion version)
        {
            /* Test does not actually upload encrypted data, only simulates it by setting specific
             * metadata. This allows the test to be recordable and to hopefully catch breaks in playback CI.
             */

            // Arrange
            byte[] data = GetRandomBuffer(Constants.KB);
            Mock<IKeyEncryptionKey> mockKey1 = this.GetIKeyEncryptionKey(s_cancellationToken);
            Mock<IKeyEncryptionKey> mockKey2 = this.GetIKeyEncryptionKey(s_cancellationToken);
            IKeyEncryptionKeyResolver mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, mockKey1.Object, mockKey2.Object).Object;

            byte[] cek = GetRandomBuffer(32);
            EncryptionData simulatedEncryptionData = await GetMockEncryptionDataAsync(cek, mockKey1.Object);

            // do NOT get an encryption client for data upload. we won't be able to record.
            await using DisposingContainer disposable = await GetTestContainerAsync();
            BlobClient blob = InstrumentClient(disposable.Container.GetBlobClient(GetNewBlobName()));
            await blob.UploadAsync(new MemoryStream(data), metadata: new Dictionary<string, string> {
                { Constants.ClientSideEncryption.EncryptionDataKey, EncryptionDataSerializer.Serialize(simulatedEncryptionData) }
            });
            // assure proper setup
            await AssertKeyAsync(blob, mockKey1.Object);

            // Act
            await CallCorrectKeyUpdateAsync(blob, useOverrides, mockKey2.Object, mockKeyResolver, version);

            // Assert
            await AssertKeyAsync(blob, mockKey2.Object, cek);
        }

        [Test]
        public async Task DoesETagLockOnKeyUpdate()
        {
            /* Test does not actually upload encrypted data, only simulates it by setting specific
             * metadata. This allows the test to be recordable and to hopefully catch breaks in playback CI.
             */

            // Arrange
            const float updatePauseTimeSeconds = 1f;

            byte[] data = GetRandomBuffer(Constants.KB);
            Mock<IKeyEncryptionKey> mockKey1 = this.GetIKeyEncryptionKey(s_cancellationToken);
            // delay forces pause in update where we can mess with blob and change etag
            Mock<IKeyEncryptionKey> mockKey2 = this.GetIKeyEncryptionKey(s_cancellationToken, optionalDelay: TimeSpan.FromSeconds(updatePauseTimeSeconds));
            IKeyEncryptionKeyResolver mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, mockKey1.Object, mockKey2.Object).Object;

            byte[] cek = GetRandomBuffer(32);
            EncryptionData simulatedEncryptionData = await GetMockEncryptionDataAsync(cek, mockKey1.Object);

            // do NOT get an encryption client for data upload. we won't be able to record.
            await using DisposingContainer disposable = await GetTestContainerAsync();
            BlobClient blob = InstrumentClient(disposable.Container.GetBlobClient(GetNewBlobName()));
            await blob.UploadAsync(new MemoryStream(data), metadata: new Dictionary<string, string> {
                { Constants.ClientSideEncryption.EncryptionDataKey, EncryptionDataSerializer.Serialize(simulatedEncryptionData) }
            });
            // assure proper setup
            await AssertKeyAsync(blob, mockKey1.Object);

            // Act
            Task updateResult;
            // update will take a while thanks to delay on mockKey2
            if (IsAsync)
            {
                updateResult = blob.UpdateClientSideKeyEncryptionKeyAsync(
                    encryptionOptionsOverride: new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V2_0)
                    {
                        KeyEncryptionKey = mockKey2.Object,
                        KeyResolver = mockKeyResolver,
                        KeyWrapAlgorithm = s_algorithmName
                    },
                    cancellationToken: s_cancellationToken);
            }
            else
            {
                updateResult = Task.Run(() => blob.UpdateClientSideKeyEncryptionKey(
                    encryptionOptionsOverride: new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V2_0)
                    {
                        KeyEncryptionKey = mockKey2.Object,
                        KeyResolver = mockKeyResolver,
                        KeyWrapAlgorithm = s_algorithmName
                    },
                    cancellationToken: s_cancellationToken));
            }

            // partway through, mess with blob while key is updating, changing the etag
            await Task.Delay(TimeSpan.FromSeconds(updatePauseTimeSeconds / 2));
            await blob.SetHttpHeadersAsync(new BlobHttpHeaders
            {
                ContentLanguage = "foo"
            });

            // Assert
            // if it doesn't throw, consider upping `optionalDelay` on mockKey2 creation as a sanity check
            // though current value (1 sec) should be more than enough
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await updateResult);
            Assert.AreEqual(BlobErrorCode.ConditionNotMet.ToString(), ex.ErrorCode);
        }

        [Test]
        [Combinatorial]
        [LiveOnly]
        public async Task CanRoundtripWithKeyUpdate(
            bool useOverrides,
            [ValueSource("GetEncryptionVersions")] ClientSideEncryptionVersion version)
        {
            // Arrange
            byte[] data = GetRandomBuffer(Constants.KB);
            Mock<IKeyEncryptionKey> mockKey1 = this.GetIKeyEncryptionKey(s_cancellationToken);
            Mock<IKeyEncryptionKey> mockKey2 = this.GetIKeyEncryptionKey(s_cancellationToken);
            IKeyEncryptionKeyResolver mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, mockKey1.Object, mockKey2.Object).Object;

            var initialUploadEncryptionOptions = new ClientSideEncryptionOptions(version)
            {
                KeyEncryptionKey = mockKey1.Object,
                KeyResolver = mockKeyResolver,
                KeyWrapAlgorithm = s_algorithmName
            };

            await using var disposable = await GetTestContainerEncryptionAsync(initialUploadEncryptionOptions);

            BlobClient blob = InstrumentClient(disposable.Container.GetBlobClient(GetNewBlobName()));

            // upload with encryption
            await blob.UploadAsync(new MemoryStream(data), cancellationToken: s_cancellationToken);

            // assure proper setup
            await AssertKeyAsync(blob, mockKey1.Object);

            // Act
            await CallCorrectKeyUpdateAsync(blob, useOverrides, mockKey2.Object, mockKeyResolver, version);

            // Assert
            await AssertKeyAsync(blob, mockKey2.Object);

            // can download and decrypt
            byte[] downloadData;
            using (var stream = new MemoryStream())
            {
                await blob.DownloadToAsync(stream, cancellationToken: s_cancellationToken);
                downloadData = stream.ToArray();
            }
            Assert.AreEqual(data, downloadData);
        }

        [Test]
        [Combinatorial]
        [LiveOnly] // current pipeline limitation
        public void AesGcmStreaming(
            [Values(true, false)] bool alligned,
            [Values(1, 3)] int numAuthBlocks)
        {
            // test doesn't need recording
            static byte[] GetRandomBytes(int length)
            {
                byte[] bytes = new byte[length];
                new Random().NextBytes(bytes);
                return bytes;
            }

            // Arrange
            const int authRegionDataLength = Constants.KB;
            int plaintextLength = (alligned ? authRegionDataLength : 500) + ((numAuthBlocks - 1) * authRegionDataLength);
            ReadOnlySpan<byte> plaintext = new ReadOnlySpan<byte>(GetRandomBytes(plaintextLength));
            byte[] key = GetRandomBytes(Constants.ClientSideEncryption.EncryptionKeySizeBits / 8);

            var encryptingReadStream = new AuthenticatedRegionCryptoStream(
                new MemoryStream(plaintext.ToArray()),
                new GcmAuthenticatedCryptographicTransform(key, TransformMode.Encrypt),
                authRegionDataLength,
                CryptoStreamMode.Read);

            var decryptingReadStream = new AuthenticatedRegionCryptoStream(
                encryptingReadStream,
                new GcmAuthenticatedCryptographicTransform(key, TransformMode.Decrypt),
                authRegionDataLength,
                CryptoStreamMode.Read);

            // Act
            var roundtrippedPlaintext = new byte[plaintext.Length];
            decryptingReadStream.CopyTo(new MemoryStream(roundtrippedPlaintext));

            // Assert
            CollectionAssert.AreEqual(plaintext.ToArray(), roundtrippedPlaintext);
        }

        [Test]
        [Combinatorial]
        [LiveOnly]
        public async Task EncryptionDataCaseInsensitivity(
            [Values("ENCRYPTIONDATA", "EncryptionData", "eNcRyPtIoNdAtA")] string newKey,
            [ValueSource("GetEncryptionVersions")] ClientSideEncryptionVersion version)
        {
            // Arrange
            ReadOnlyMemory<byte> data = GetRandomBuffer(Constants.KB);
            Mock<IKeyEncryptionKey> mockKey1 = this.GetIKeyEncryptionKey(s_cancellationToken);
            var encryptionOptions = new ClientSideEncryptionOptions(version)
            {
                KeyEncryptionKey = mockKey1.Object,
                KeyWrapAlgorithm = s_algorithmName
            };

            await using var disposable = await GetTestContainerAsync();

            BlobClient standardBlobClient = disposable.Container.GetBlobClient(GetNewBlobName());
            BlobClient encryptedBlobClient = InstrumentClient(standardBlobClient.WithClientSideEncryptionOptions(encryptionOptions));

            await encryptedBlobClient.UploadAsync(BinaryData.FromBytes(data), cancellationToken: s_cancellationToken);

            // change casing of encryptiondata key
            string rawEncryptiondata = (await standardBlobClient.GetPropertiesAsync()).Value.Metadata[EncryptionDataKey];
            Assert.IsNotEmpty(rawEncryptiondata); // quick check we're testing the right thing
            await standardBlobClient.SetMetadataAsync(new Dictionary<string, string> { { newKey, rawEncryptiondata } });

            // Act
            ReadOnlyMemory<byte> downloadedContent = (await encryptedBlobClient.DownloadContentAsync(s_cancellationToken)).Value.Content.ToMemory();

            // Assert
            Assert.IsTrue(data.Span.SequenceEqual(downloadedContent.Span));
        }

        /// <summary>
        /// There's a few too many things to switch on for key updates. Separate method to determine the correct way to call it.
        /// </summary>
        /// <param name="blob">Blob to update key on.</param>
        /// <param name="useOverrides">Whether to use client options or method overrides as parameters for key update.</param>
        /// <param name="newKey">New KEK for encryption data.</param>
        /// <param name="keyResolver">Key resolver for unwraping the old key.</param>
        /// <returns></returns>
        private async Task CallCorrectKeyUpdateAsync(
            BlobClient blob,
            bool useOverrides,
            IKeyEncryptionKey newKey,
            IKeyEncryptionKeyResolver keyResolver,
            ClientSideEncryptionVersion version)
        {
            if (useOverrides)
            {
                // switch over to a client with no clientside encryption options configured
                blob = BlobsClientBuilder.RotateBlobClientSharedKey(blob, default);

                // have to actually switch on IsAsync for extension methods
                if (IsAsync)
                {
                    await blob.UpdateClientSideKeyEncryptionKeyAsync(
                        encryptionOptionsOverride: new ClientSideEncryptionOptions(version)
                        {
                            KeyEncryptionKey = newKey,
                            KeyResolver = keyResolver,
                            KeyWrapAlgorithm = s_algorithmName
                        },
                        cancellationToken: s_cancellationToken);
                }
                else
                {
                    blob.UpdateClientSideKeyEncryptionKey(
                        encryptionOptionsOverride: new ClientSideEncryptionOptions(version)
                        {
                            KeyEncryptionKey = newKey,
                            KeyResolver = keyResolver,
                            KeyWrapAlgorithm = s_algorithmName
                        },
                        cancellationToken: s_cancellationToken);
                }
            }
            else
            {
                // switch over to a client with clientside encryption options configured and use them
                blob = BlobsClientBuilder.RotateBlobClientSharedKey(blob, options => options._clientSideEncryptionOptions = new ClientSideEncryptionOptions(version)
                {
                    KeyEncryptionKey = newKey,
                    KeyResolver = keyResolver,
                    KeyWrapAlgorithm = s_algorithmName
                });

                // have to actually switch on IsAsync for extension methods
                if (IsAsync)
                {
                    await blob.UpdateClientSideKeyEncryptionKeyAsync(cancellationToken: s_cancellationToken);
                }
                else
                {
                    blob.UpdateClientSideKeyEncryptionKey(cancellationToken: s_cancellationToken);
                }
            }
        }

        /// <summary>
        /// Asserts a blob's encryption metadata keys are as expected
        /// </summary>
        /// <param name="client">Client to the blob.</param>
        /// <param name="kek">Key Encryption Key that should be ID'd in the metadata and wrapping the Content Encryption Key.</param>
        /// <param name="knownCek">Optional. If the Content Encryption Key is known, will unwrap the cek from metadata and assert it is as expected.</param>
        /// <returns></returns>
        private async Task AssertKeyAsync(BlobBaseClient client, IKeyEncryptionKey kek, byte[] knownCek = default)
        {
            var metadata = (await client.GetPropertiesAsync()).Value.Metadata;
            if (!metadata.TryGetValue(Constants.ClientSideEncryption.EncryptionDataKey, out string encryptionDataString))
            {
                Assert.Fail("No encryption data on blob.");
            }
            var wrappedCek = EncryptionDataSerializer.Deserialize(encryptionDataString).WrappedContentKey;

            Assert.AreEqual(kek.KeyId, wrappedCek.KeyId);
            if (knownCek != default)
            {
                Assert.AreEqual(
                    knownCek,
                    IsAsync
                        ? await kek.UnwrapKeyAsync(wrappedCek.Algorithm, wrappedCek.EncryptedKey, s_cancellationToken)
                        : kek.UnwrapKey(wrappedCek.Algorithm, wrappedCek.EncryptedKey, s_cancellationToken));
            }
        }
    }
}
