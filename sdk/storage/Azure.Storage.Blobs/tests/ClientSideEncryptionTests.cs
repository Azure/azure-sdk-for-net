// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Cryptography;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Keys.Cryptography;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.Cryptography.Models;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Moq;
using NUnit.Framework;
using static Azure.Storage.Blobs.Tests.ClientSideEncryptionTestExtensions;
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
        }

        /// <summary>
        /// Provides encryption functionality clone of client logic, letting us validate the client got it right end-to-end.
        /// </summary>
        private byte[] EncryptData(byte[] data, byte[] key, byte[] iv)
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

        private Mock<IKeyEncryptionKeyResolver> GetAlwaysFailsKeyResolver(bool throws)
        {
            var mock = new Mock<IKeyEncryptionKeyResolver>(MockBehavior.Strict);
            if (IsAsync)
            {
                if (throws)
                {
                    mock.Setup(r => r.ResolveAsync(IsNotNull<string>(), s_cancellationToken))
                        .Throws<Exception>();
                }
                else
                {
                    mock.Setup(r => r.ResolveAsync(IsNotNull<string>(), s_cancellationToken))
                        .Returns(Task.FromResult<IKeyEncryptionKey>(null));
                }
            }
            else
            {
                if (throws)
                {
                    mock.Setup(r => r.Resolve(IsNotNull<string>(), s_cancellationToken))
                        .Throws<Exception>();
                }
                else
                {
                    mock.Setup(r => r.Resolve(IsNotNull<string>(), s_cancellationToken))
                        .Returns((IKeyEncryptionKey)null);
                }
            }

            return mock;
        }

        private Mock<Microsoft.Azure.KeyVault.Core.IKey> GetTrackOneIKey(byte[] userKeyBytes = default, string keyId = default)
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

            var keyMock = new Mock<Microsoft.Azure.KeyVault.Core.IKey>(MockBehavior.Strict);
            keyMock.SetupGet(k => k.Kid).Returns(keyId);
            keyMock.SetupGet(k => k.DefaultKeyWrapAlgorithm).Returns(s_algorithmName);
            // track one had async-only key wrapping
            keyMock.Setup(k => k.WrapKeyAsync(IsNotNull<byte[]>(), IsAny<string>(), IsNotNull<CancellationToken>())) // track 1 doesn't pass in the same cancellation token?
                // track 1 doesn't pass in the algorithm name, it lets the implementation return the default algorithm it chose
                .Returns<byte[], string, CancellationToken>((key, algorithm, cancellationToken) => Task.FromResult(Tuple.Create(Xor(userKeyBytes, key), s_algorithmName)));
            keyMock.Setup(k => k.UnwrapKeyAsync(IsNotNull<byte[]>(), s_algorithmName, IsNotNull<CancellationToken>())) // track 1 doesn't pass in the same cancellation token?
                .Returns<byte[], string, CancellationToken>((wrappedKey, algorithm, cancellationToken) => Task.FromResult(Xor(userKeyBytes, wrappedKey)));

            return keyMock;
        }

        private Mock<Microsoft.Azure.KeyVault.Core.IKeyResolver> GetTrackOneIKeyResolver(Microsoft.Azure.KeyVault.Core.IKey iKey)
        {
            var resolverMock = new Mock<Microsoft.Azure.KeyVault.Core.IKeyResolver>(MockBehavior.Strict);
            resolverMock.Setup(r => r.ResolveKeyAsync(IsNotNull<string>(), IsNotNull<CancellationToken>())) // track 1 doesn't pass in the same cancellation token?
                .Returns<string, CancellationToken>((keyId, cancellationToken) => iKey?.Kid == keyId ? Task.FromResult(iKey) : throw new Exception("Mock resolver couldn't resolve key id."));

            return resolverMock;
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
            Assert.NotNull(encryptionMetadata, "Never encrypted data.");

            var explicitlyUnwrappedKey = IsAsync // can't instrument this
                ? await keyEncryptionKey.UnwrapKeyAsync(s_algorithmName, encryptionMetadata.WrappedContentKey.EncryptedKey, s_cancellationToken).ConfigureAwait(false)
                : keyEncryptionKey.UnwrapKey(s_algorithmName, encryptionMetadata.WrappedContentKey.EncryptedKey, s_cancellationToken);

            return EncryptData(
                plaintext,
                explicitlyUnwrappedKey,
                encryptionMetadata.ContentEncryptionIV);
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
                ContentEncryptionIV = GetRandomBuffer(32),
                EncryptionAgent = new EncryptionAgent()
                {
                    EncryptionAlgorithm = "foo",
                    EncryptionVersion = ClientSideEncryptionVersion.V1_0
                },
                EncryptionMode = "bar",
                KeyWrappingMetadata = new Dictionary<string, string> { { "fizz", "buzz" } }
            };
        }

        [Test]
        [LiveOnly]
        public void CanSwapKey()
        {
            var options1 = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
            {
                KeyEncryptionKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object,
                KeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, default).Object,
                KeyWrapAlgorithm = "foo"
            };
            var options2 = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
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

        [TestCase(16)] // a single cipher block
        [TestCase(14)] // a single unalligned cipher block
        [TestCase(Constants.KB)] // multiple blocks
        [TestCase(Constants.KB - 4)] // multiple unalligned blocks
        [TestCase(Constants.MB)] // larger test, increasing likelihood to trigger async extension usage bugs
        [LiveOnly] // cannot seed content encryption key
        public async Task UploadAsync(long dataSize)
        {
            var plaintext = GetRandomBuffer(dataSize);
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
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

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(8)]
        [LiveOnly] // cannot seed content encryption key
        public async Task UploadAsyncSplit(int concurrency)
        {
            int blockSize = Constants.KB;
            int dataSize = 16 * Constants.KB;
            var plaintext = GetRandomBuffer(dataSize);
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
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

        [TestCase(16, null)] // a single cipher block
        [TestCase(14, null)] // a single unalligned cipher block
        [TestCase(Constants.KB, null)] // multiple blocks
        [TestCase(Constants.KB - 4, null)] // multiple unalligned blocks
        [TestCase(Constants.MB, 64*Constants.KB)] // make sure we cache unwrapped key for large downloads
        [LiveOnly] // cannot seed content encryption key
        public async Task RoundtripAsync(long dataSize, long? initialDownloadRequestSize)
        {
            var data = GetRandomBuffer(dataSize);
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken);
            var mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, mockKey.Object).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
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

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(8)]
        [LiveOnly] // cannot seed content encryption key
        public async Task RoundtripSplitAsync(int concurrency)
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
                new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
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

        [TestCase(Constants.MB, 64*Constants.KB)]
        [TestCase(Constants.MB, Constants.MB)]
        [TestCase(Constants.MB, 4*Constants.MB)]
        [LiveOnly] // cannot seed content encryption key
        public async Task RoundtripAsyncWithOpenRead(long dataSize, int bufferSize)
        {
            var data = GetRandomBuffer(dataSize);
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken);
            var mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, mockKey.Object).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
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
        public async Task RoundtripWithMetadata()
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
                new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
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
                Assert.IsTrue(downloadedMetadata.ContainsKey(Constants.ClientSideEncryption.EncryptionDataKey));
            }
        }

        [RecordedTest] // multiple unalligned blocks
        [LiveOnly] // cannot seed content encryption key
        public async Task KeyResolverKicksIn()
        {
            var data = GetRandomBuffer(Constants.KB);
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object;
            var mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, mockKey).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
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
                    options._clientSideEncryptionOptions = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
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

        [TestCase(0, 16)]  // first block
        [TestCase(16, 16)] // not first block
        [TestCase(32, 32)] // multiple blocks; IV not at blob start
        [TestCase(16, 17)] // overlap end of block
        [TestCase(32, 17)] // overlap end of block; IV not at blob start
        [TestCase(15, 17)] // overlap beginning of block
        [TestCase(31, 17)] // overlap beginning of block; IV not at blob start
        [TestCase(15, 18)] // overlap both sides
        [TestCase(31, 18)] // overlap both sides; IV not at blob start
        [TestCase(16, null)]
        [LiveOnly] // cannot seed content encryption key
        public async Task PartialDownloadAsync(int offset, int? count)
        {
            var data = GetRandomBuffer(offset + (count ?? 16) + 32); // ensure we have enough room in original data
            var mockKey = this.GetIKeyEncryptionKey(expectedCancellationToken: s_cancellationToken).Object;
            var mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, mockKey).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
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

            const int keySizeBits = 256;
            var keyEncryptionKeyBytes = new byte[keySizeBits >> 3];
#if NET6_0_OR_GREATER
            RandomNumberGenerator.Create().GetBytes(keyEncryptionKeyBytes);
#else
                new RNGCryptoServiceProvider().GetBytes(keyEncryptionKeyBytes);
#endif
            var keyId = Guid.NewGuid().ToString();

            var mockKey = GetTrackOneIKey(keyEncryptionKeyBytes, keyId).Object;
            var mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, this.GetIKeyEncryptionKey(s_cancellationToken, keyEncryptionKeyBytes, keyId).Object).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
            {
                KeyResolver = mockKeyResolver,
                KeyWrapAlgorithm = s_algorithmName
            }))
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

            const int keySizeBits = 256;
            var keyEncryptionKeyBytes = new byte[keySizeBits >> 3];
#if NET6_0_OR_GREATER
            RandomNumberGenerator.Create().GetBytes(keyEncryptionKeyBytes);
#else
                new RNGCryptoServiceProvider().GetBytes(keyEncryptionKeyBytes);
#endif
            var keyId = Guid.NewGuid().ToString();

            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken, keyEncryptionKeyBytes, keyId).Object;
            var mockKeyResolver = GetTrackOneIKeyResolver(GetTrackOneIKey(keyEncryptionKeyBytes, keyId).Object).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
                {
                    KeyEncryptionKey = mockKey,
                    KeyWrapAlgorithm = s_algorithmName
                }))
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

        [Test]
        [LiveOnly] // need access to keyvault service && cannot seed content encryption key
        public async Task RoundtripWithKeyvaultProvider()
        {
            var data = GetRandomBuffer(Constants.KB);
            IKeyEncryptionKey key = await GetKeyvaultIKeyEncryptionKey();
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
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

        [TestCase(Constants.MB, 64*Constants.KB)]
        [LiveOnly] // need access to keyvault service && cannot seed content encryption key
        public async Task RoundtripWithKeyvaultProviderOpenRead(long dataSize, int bufferSize)
        {
            var data = GetRandomBuffer(dataSize);
            IKeyEncryptionKey key = await GetKeyvaultIKeyEncryptionKey();
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
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

        [TestCase(true)]
        [TestCase(false)]
        [LiveOnly]
        public async Task CannotFindKeyAsync(bool resolverThrows)
        {
            var data = GetRandomBuffer(Constants.KB);
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
                {
                    KeyEncryptionKey = mockKey,
                    KeyWrapAlgorithm = s_algorithmName
                }))
            {
                var blob = InstrumentClient(disposable.Container.GetBlobClient(GetNewBlobName()));
                await blob.UploadAsync(new MemoryStream(data), cancellationToken: s_cancellationToken);

                bool threw = false;
                var resolver = this.GetAlwaysFailsKeyResolver(resolverThrows);
                try
                {
                    // download but can't find key
                    var options = GetOptions();
                    options._clientSideEncryptionOptions = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
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
        [TestCase(0, 2 * Constants.ClientSideEncryption.EncryptionBlockSize)]
        [TestCase(0, 2 * Constants.ClientSideEncryption.EncryptionBlockSize + 5)]
        [TestCase(Constants.ClientSideEncryption.EncryptionBlockSize, Constants.ClientSideEncryption.EncryptionBlockSize)]
        [TestCase(Constants.ClientSideEncryption.EncryptionBlockSize, Constants.ClientSideEncryption.EncryptionBlockSize + 5)]
        [TestCase(Constants.ClientSideEncryption.EncryptionBlockSize + 5, 2 * Constants.ClientSideEncryption.EncryptionBlockSize)]
        [LiveOnly]
        public async Task AppropriateRangeDownloadOnPlaintext(int rangeOffset, int? rangeLength)
        {
            var data = GetRandomBuffer(rangeOffset + (rangeLength ?? Constants.KB) + Constants.ClientSideEncryption.EncryptionBlockSize);
            var mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, this.GetIKeyEncryptionKey(s_cancellationToken).Object).Object;
            await using (var disposable = await GetTestContainerAsync())
            {
                // upload plaintext
                var blob = disposable.Container.GetBlobClient(GetNewBlobName());
                await blob.UploadAsync(new MemoryStream(data));

                // download plaintext range with encrypted client
                var cryptoClient = InstrumentClient(new BlobClient(blob.Uri, Tenants.GetNewSharedKeyCredentials(), new SpecializedBlobClientOptions()
                {
                    ClientSideEncryption = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
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
        public async Task StressManyBlobsAsync()
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
                new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
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
        public async Task StressLargeBlobAsync()
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
                new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
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
        public async Task EncryptedReuploadSuccess()
        {
            var originalData = GetRandomBuffer(Constants.KB);
            var editedData = GetRandomBuffer(Constants.KB);
            (string Key, string Value) originalMetadata = ("foo", "bar");
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
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
        [LiveOnly]
        /// <summary>
        /// Crypto transform streams are unseekable and have no <see cref="Stream.Length"/>.
        /// When length is unknown, <see cref="PartitionedUploader{TServiceSpecificArgs, TCompleteUploadReturn}"/>
        /// doesn't even attempt a one-shot upload.
        /// This tests if we correctly inform the uploader of an expected stream length so it
        /// can respect the given <see cref="StorageTransferOptions"/>.
        /// </summary>
        public async Task PutBlobPutBlockSwitch([Values(true, false)] bool oneshot)
        {
            const int dataSize = 1 * Constants.KB;

            // Arrange
            byte[] data = GetRandomBuffer(dataSize);
            int transferSize = oneshot
                    ? 2 * dataSize // big enough for put blob even after AES-CBC PKCS7 padding
                    : dataSize / 2;
            StorageTransferOptions transferOptions = new StorageTransferOptions
            {
                InitialTransferSize = transferSize,
                MaximumTransferSize = transferSize
            };

            IKeyEncryptionKey key = this.GetIKeyEncryptionKey(s_cancellationToken).Object;
            await using var disposable = await GetTestContainerEncryptionAsync(
                new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
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
        public void CanGenerateSas_WithClientSideEncryptionOptions_True()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            var options = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
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
        public void CanGenerateSas_WithClientSideEncryptionOptions_False()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);

            var options = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
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

        [TestCase(true)]
        [TestCase(false)]
        public async Task UpdateKey(bool useOverrides)
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
            await CallCorrectKeyUpdateAsync(blob, useOverrides, mockKey2.Object, mockKeyResolver);

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
                    new UpdateClientSideKeyEncryptionKeyOptions
                    {
                        EncryptionOptionsOverride = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
                        {
                            KeyEncryptionKey = mockKey2.Object,
                            KeyResolver = mockKeyResolver,
                            KeyWrapAlgorithm = s_algorithmName
                        }
                    },
                    cancellationToken: s_cancellationToken);
            }
            else
            {
                updateResult = Task.Run(() => blob.UpdateClientSideKeyEncryptionKey(
                    new UpdateClientSideKeyEncryptionKeyOptions
                    {
                        EncryptionOptionsOverride = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
                        {
                            KeyEncryptionKey = mockKey2.Object,
                            KeyResolver = mockKeyResolver,
                            KeyWrapAlgorithm = s_algorithmName
                        }
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

        [TestCase(true)]
        [TestCase(false)]
        [LiveOnly]
        public async Task CanRoundtripWithKeyUpdate(bool useOverrides)
        {
            // Arrange
            byte[] data = GetRandomBuffer(Constants.KB);
            Mock<IKeyEncryptionKey> mockKey1 = this.GetIKeyEncryptionKey(s_cancellationToken);
            Mock<IKeyEncryptionKey> mockKey2 = this.GetIKeyEncryptionKey(s_cancellationToken);
            IKeyEncryptionKeyResolver mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, mockKey1.Object, mockKey2.Object).Object;

            var initialUploadEncryptionOptions = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
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
            await CallCorrectKeyUpdateAsync(blob, useOverrides, mockKey2.Object, mockKeyResolver);

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

        /// <summary>
        /// There's a few too many things to switch on for key updates. Separate method to determine the correct way to call it.
        /// </summary>
        /// <param name="blob">Blob to update key on.</param>
        /// <param name="useOverrides">Whether to use client options or method overrides as parameters for key update.</param>
        /// <param name="newKey">New KEK for encryption data.</param>
        /// <param name="keyResolver">Key resolver for unwraping the old key.</param>
        /// <returns></returns>
        private async Task CallCorrectKeyUpdateAsync(BlobClient blob, bool useOverrides, IKeyEncryptionKey newKey, IKeyEncryptionKeyResolver keyResolver)
        {
            if (useOverrides)
            {
                // switch over to a client with no clientside encryption options configured
                blob = BlobsClientBuilder.RotateBlobClientSharedKey(blob, default);

                // have to actually switch on IsAsync for extension methods
                if (IsAsync)
                {
                    await blob.UpdateClientSideKeyEncryptionKeyAsync(
                        new UpdateClientSideKeyEncryptionKeyOptions
                        {
                            EncryptionOptionsOverride = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
                            {
                                KeyEncryptionKey = newKey,
                                KeyResolver = keyResolver,
                                KeyWrapAlgorithm = s_algorithmName
                            }
                        },
                        cancellationToken: s_cancellationToken);
                }
                else
                {
                    blob.UpdateClientSideKeyEncryptionKey(
                        new UpdateClientSideKeyEncryptionKeyOptions
                        {
                            EncryptionOptionsOverride = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
                            {
                                KeyEncryptionKey = newKey,
                                KeyResolver = keyResolver,
                                KeyWrapAlgorithm = s_algorithmName
                            }
                        },
                        cancellationToken: s_cancellationToken);
                }
            }
            else
            {
                // switch over to a client with clientside encryption options configured and use them
                blob = BlobsClientBuilder.RotateBlobClientSharedKey(blob, options => options._clientSideEncryptionOptions = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
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
