// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Azure.Storage.Cryptography;
using Azure.Storage.Cryptography.Models;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Moq;
using NUnit.Framework;
using static Moq.It;

namespace Azure.Storage.Blobs.Test
{
    public class ClientSideEncryptionTests : BlobTestBase
    {
        private const string s_algorithmName = "some algorithm name";
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
            using (var aesProvider = new AesCryptoServiceProvider() { Key = key, IV = iv })
            using (var encryptor = aesProvider.CreateEncryptor())
            using (var memStream = new MemoryStream())
            using (var cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
            {
                cryptoStream.Write(data, 0, data.Length);
                cryptoStream.FlushFinalBlock();
                return memStream.ToArray();
            }
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
            var service = GetServiceClient_SharedKey(options);

            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(containerName));
            await container.CreateAsync(metadata: metadata);
            return new DisposingContainer(container);
        }

        private Mock<IKeyEncryptionKey> GetIKeyEncryptionKey(byte[] userKeyBytes = default, string keyId = default)
        {
            if (userKeyBytes == default)
            {
                const int keySizeBits = 256;
                var bytes = new byte[keySizeBits >> 3];
                new RNGCryptoServiceProvider().GetBytes(bytes);
                userKeyBytes = bytes;
            }
            keyId ??= Guid.NewGuid().ToString();

            var keyMock = new Mock<IKeyEncryptionKey>(MockBehavior.Strict);
            keyMock.SetupGet(k => k.KeyId).Returns(keyId);
            if (IsAsync)
            {
                keyMock.Setup(k => k.WrapKeyAsync(s_algorithmName, IsNotNull<ReadOnlyMemory<byte>>(), s_cancellationToken))
                    .Returns<string, ReadOnlyMemory<byte>, CancellationToken>((algorithm, key, cancellationToken) => Task.FromResult(Xor(userKeyBytes, key.ToArray())));
                keyMock.Setup(k => k.UnwrapKeyAsync(s_algorithmName, IsNotNull<ReadOnlyMemory<byte>>(), s_cancellationToken))
                    .Returns<string, ReadOnlyMemory<byte>, CancellationToken>((algorithm, wrappedKey, cancellationToken) => Task.FromResult(Xor(userKeyBytes, wrappedKey.ToArray())));
            }
            else
            {
                keyMock.Setup(k => k.WrapKey(s_algorithmName, IsNotNull<ReadOnlyMemory<byte>>(), s_cancellationToken))
                    .Returns<string, ReadOnlyMemory<byte>, CancellationToken>((algorithm, key, cancellationToken) => Xor(userKeyBytes, key.ToArray()));
                keyMock.Setup(k => k.UnwrapKey(s_algorithmName, IsNotNull<ReadOnlyMemory<byte>>(), s_cancellationToken))
                    .Returns<string, ReadOnlyMemory<byte>, CancellationToken>((algorithm, wrappedKey, cancellationToken) => Xor(userKeyBytes, wrappedKey.ToArray()));
            }

            return keyMock;
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

        private Mock<IKeyEncryptionKeyResolver> GetIKeyEncryptionKeyResolver(IKeyEncryptionKey iKey)
        {
            var resolverMock = new Mock<IKeyEncryptionKeyResolver>(MockBehavior.Strict);
            if (IsAsync)
            {
                resolverMock.Setup(r => r.ResolveAsync(IsNotNull<string>(), s_cancellationToken))
                    .Returns<string, CancellationToken>((keyId, cancellationToken) => iKey?.KeyId == keyId ? Task.FromResult(iKey) : throw new Exception("Mock resolver couldn't resolve key id."));
            }
            else
            {
                resolverMock.Setup(r => r.Resolve(IsNotNull<string>(), s_cancellationToken))
                    .Returns<string, CancellationToken>((keyId, cancellationToken) => iKey?.KeyId == keyId ? iKey : throw new Exception("Mock resolver couldn't resolve key id."));
            }

            return resolverMock;
        }

        private Mock<Microsoft.Azure.KeyVault.Core.IKey> GetTrackOneIKey(byte[] userKeyBytes = default, string keyId = default)
        {
            if (userKeyBytes == default)
            {
                const int keySizeBits = 256;
                var bytes = new byte[keySizeBits >> 3];
                new RNGCryptoServiceProvider().GetBytes(bytes);
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

        [Test]
        [LiveOnly]
        public void CanSwapKey()
        {
            var options1 = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
            {
                KeyEncryptionKey = GetIKeyEncryptionKey().Object,
                KeyResolver = GetIKeyEncryptionKeyResolver(default).Object,
                KeyWrapAlgorithm = "foo"
            };
            var options2 = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
            {
                KeyEncryptionKey = GetIKeyEncryptionKey().Object,
                KeyResolver = GetIKeyEncryptionKeyResolver(default).Object,
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
            var data = GetRandomBuffer(dataSize);
            var mockKey = GetIKeyEncryptionKey().Object;
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
                await blob.UploadAsync(new MemoryStream(data), cancellationToken: s_cancellationToken);

                // download without decrypting
                var encryptedDataStream = new MemoryStream();
                await InstrumentClient(new BlobClient(blob.Uri, GetNewSharedKeyCredentials())).DownloadToAsync(encryptedDataStream, cancellationToken: s_cancellationToken);
                var encryptedData = encryptedDataStream.ToArray();

                // encrypt original data manually for comparison
                if (!(await blob.GetPropertiesAsync()).Value.Metadata.TryGetValue(Constants.ClientSideEncryption.EncryptionDataKey, out string serialEncryptionData))
                {
                    Assert.Fail("No encryption metadata present.");
                }
                EncryptionData encryptionMetadata = EncryptionDataSerializer.Deserialize(serialEncryptionData);
                Assert.NotNull(encryptionMetadata, "Never encrypted data.");

                var explicitlyUnwrappedKey = IsAsync // can't instrument this
                    ? await mockKey.UnwrapKeyAsync(s_algorithmName, encryptionMetadata.WrappedContentKey.EncryptedKey, s_cancellationToken).ConfigureAwait(false)
                    : mockKey.UnwrapKey(s_algorithmName, encryptionMetadata.WrappedContentKey.EncryptedKey, s_cancellationToken);
                byte[] expectedEncryptedData = EncryptData(
                    data,
                    explicitlyUnwrappedKey,
                    encryptionMetadata.ContentEncryptionIV);

                // compare data
                Assert.AreEqual(expectedEncryptedData, encryptedData);
            }
        }

        [TestCase(16)] // a single cipher block
        [TestCase(14)] // a single unalligned cipher block
        [TestCase(Constants.KB)] // multiple blocks
        [TestCase(Constants.KB - 4)] // multiple unalligned blocks
        [LiveOnly] // cannot seed content encryption key
        public async Task RoundtripAsync(long dataSize)
        {
            var data = GetRandomBuffer(dataSize);
            var mockKey = GetIKeyEncryptionKey().Object;
            var mockKeyResolver = GetIKeyEncryptionKeyResolver(mockKey).Object;
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

                // download with decryption
                byte[] downloadData;
                using (var stream = new MemoryStream())
                {
                    await blob.DownloadToAsync(stream, cancellationToken: s_cancellationToken);
                    downloadData = stream.ToArray();
                }

                // compare data
                Assert.AreEqual(data, downloadData);
            }
        }

        [Test] // multiple unalligned blocks
        [LiveOnly] // cannot seed content encryption key
        public async Task KeyResolverKicksIn()
        {
            var data = GetRandomBuffer(Constants.KB);
            var mockKey = GetIKeyEncryptionKey().Object;
            var mockKeyResolver = GetIKeyEncryptionKeyResolver(mockKey).Object;
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
                    await InstrumentClient(new BlobContainerClient(disposable.Container.Uri, GetNewSharedKeyCredentials(), options).GetBlobClient(blobName)).DownloadToAsync(stream, cancellationToken: s_cancellationToken);
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
            var mockKey = GetIKeyEncryptionKey().Object;
            var mockKeyResolver = GetIKeyEncryptionKeyResolver(mockKey).Object;
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
            new RNGCryptoServiceProvider().GetBytes(keyEncryptionKeyBytes);
            var keyId = Guid.NewGuid().ToString();

            var mockKey = GetTrackOneIKey(keyEncryptionKeyBytes, keyId).Object;
            var mockKeyResolver = GetIKeyEncryptionKeyResolver(GetIKeyEncryptionKey(keyEncryptionKeyBytes, keyId).Object).Object;
            await using (var disposable = await GetTestContainerEncryptionAsync(new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
            {
                KeyResolver = mockKeyResolver,
                KeyWrapAlgorithm = s_algorithmName
            }))
            {
                var track2Blob = InstrumentClient(disposable.Container.GetBlobClient(GetNewBlobName()));

                // upload with track 1
                var creds = GetNewSharedKeyCredentials();
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
            new RNGCryptoServiceProvider().GetBytes(keyEncryptionKeyBytes);
            var keyId = Guid.NewGuid().ToString();

            var mockKey = GetIKeyEncryptionKey(keyEncryptionKeyBytes, keyId).Object;
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
                var creds = GetNewSharedKeyCredentials();
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

        [TestCase(true)]
        [TestCase(false)]
        [LiveOnly]
        public async Task CannotFindKeyAsync(bool resolverThrows)
        {
            var data = GetRandomBuffer(Constants.KB);
            var mockKey = GetIKeyEncryptionKey().Object;
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
                var resolver = GetAlwaysFailsKeyResolver(resolverThrows);
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
                    await InstrumentClient(new BlobClient(blob.Uri, GetNewSharedKeyCredentials(), options)).DownloadToAsync(encryptedDataStream, cancellationToken: s_cancellationToken);
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
            var mockKeyResolver = GetIKeyEncryptionKeyResolver(GetIKeyEncryptionKey().Object).Object;
            await using (var disposable = await GetTestContainerAsync())
            {
                // upload plaintext
                var blob = disposable.Container.GetBlobClient(GetNewBlobName());
                await blob.UploadAsync(new MemoryStream(data));

                // download plaintext range with encrypted client
                var cryptoClient = InstrumentClient(new BlobClient(blob.Uri, GetNewSharedKeyCredentials(), new SpecializedBlobClientOptions()
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
        public async Task StressAsync()
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
            var mockKey = GetIKeyEncryptionKey().Object;
            var mockKeyResolver = GetIKeyEncryptionKeyResolver(mockKey).Object;
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
        [LiveOnly]
        public async Task EncryptedReuploadSuccess()
        {
            var originalData = GetRandomBuffer(Constants.KB);
            var editedData = GetRandomBuffer(Constants.KB);
            (string Key, string Value) originalMetadata = ("foo", "bar");
            var mockKey = GetIKeyEncryptionKey().Object;
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
        public void CanGenerateSas_WithClientSideEncryptionOptions_True()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            var options = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
            {
                KeyEncryptionKey = GetIKeyEncryptionKey().Object,
                KeyResolver = GetIKeyEncryptionKeyResolver(default).Object,
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

        [Test]
        public void CanGenerateSas_WithClientSideEncryptionOptions_False()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);

            var options = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
            {
                KeyEncryptionKey = GetIKeyEncryptionKey().Object,
                KeyResolver = GetIKeyEncryptionKeyResolver(default).Object,
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
    }
}
