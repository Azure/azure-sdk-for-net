// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Cryptography;
using Azure.Core.Testing;
using Azure.Security.KeyVault.Keys.Cryptography;
using Azure.Storage.Blobs.Specialized.Cryptography;
using Azure.Storage.Blobs.Specialized.Cryptography.Models;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class EncryptedBlockBlobClientTests : BlobTestBase
    {
        public EncryptedBlockBlobClientTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        #region Utility

        /// <summary>
        /// Gets a client to a nonexistent blob using client-side encryption in a brand new disposable container.
        /// </summary>
        /// <param name="blob">The blob client created.</param>
        /// <returns>The IDisposable to delete the container when finished.</returns>
        private IDisposable GetEncryptedBlockBlobClient(out EncryptedBlobClient blob, MockKeyEncryptionKey mock)
        {
            var disposable = this.GetNewContainer(out var container);
            blob = InstrumentClient(new EncryptedBlobClient(
                    new Uri(Path.Combine(container.Uri.ToString(), this.GetNewBlobName())), this.GetNewSharedKeyCredentials(),
                    keyEncryptionKey: mock,
                    keyResolver: mock));

            return disposable;
        }

        // TODO this is a copy/paste. fix that.
        /// <summary>
        /// Gets and validates a blob's encryption-related metadata
        /// </summary>
        /// <param name="metadata">The blob's metadata</param>
        /// <returns>The relevant metadata.</returns>
        private EncryptionData GetAndValidateEncryptionData(IDictionary<string, string> metadata)
        {
            _ = metadata ?? throw new InvalidOperationException();

            EncryptionData encryptionData;
            if (metadata.TryGetValue(EncryptionConstants.ENCRYPTION_DATA_KEY, out string encryptedDataString))
            {
                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(encryptedDataString)))
                {
                    var serializer = new DataContractJsonSerializer(typeof(EncryptionData));
                    encryptionData = (EncryptionData)serializer.ReadObject(stream);
                }
            }
            else
            {
                throw new InvalidOperationException("Encryption data does not exist.");
            }

            _ = encryptionData.ContentEncryptionIV ?? throw new NullReferenceException();
            _ = encryptionData.WrappedContentKey.EncryptedKey ?? throw new NullReferenceException();

            // Throw if the encryption protocol on the message doesn't match the version that this client library
            // understands
            // and is able to decrypt.
            if (EncryptionConstants.ENCRYPTION_PROTOCOL_V1 != encryptionData.EncryptionAgent.Protocol)
            {
                throw new ArgumentException(
                    "Invalid Encryption Agent. This version of the client library does not understand the " +
                        $"Encryption Agent set on the queue message: {encryptionData.EncryptionAgent}");
            }

            return encryptionData;
        }

        private byte[] LocalManualEncryption(byte[] data, byte[] key, byte[] iv)
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
            Security.KeyVault.Keys.Key key = await keyClient.CreateRsaKeyAsync(
                new Security.KeyVault.Keys.RsaKeyCreateOptions($"CloudRsaKey-{Guid.NewGuid()}", false));
            return new CryptographyClient(key.Id, GetTokenCredential_TargetKeyClient());
        }

        #endregion

        [TestCase(16)] // a single cipher block
        [TestCase(14)] // a single unalligned cipher block
        [TestCase(Constants.KB)] // multiple blocks
        [TestCase(Constants.KB - 4)] // multiple unalligned blocks
        [LiveOnly] // cannot seed content encryption key
        public async Task UploadAsync(long dataSize)
        {
            var data = GetRandomBuffer(dataSize);
            var key = new MockKeyEncryptionKey();
            using (GetEncryptedBlockBlobClient(out var blob, key))
            {
                // upload with encryption
                await blob.UploadAsync(new MemoryStream(data));

                // download without decrypting
                var normalBlob = (await new BlobClient(blob.Uri, this.GetNewSharedKeyCredentials()).DownloadAsync()).Value;
                var encryptedData = new byte[normalBlob.ContentLength];
                await normalBlob.Content.ReadAsync(encryptedData, 0, encryptedData.Length);

                // encrypt original data manually for comparison
                var encryptionMetadata = GetAndValidateEncryptionData(normalBlob.Properties.Metadata);
                byte[] expectedEncryptedData = LocalManualEncryption(
                    data,
                    (await key.UnwrapKeyAsync(null, encryptionMetadata.WrappedContentKey.EncryptedKey)
                        .ConfigureAwait(false)).ToArray(),
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
            var key = new MockKeyEncryptionKey();
            using (this.GetEncryptedBlockBlobClient(out var blob, key))
            {
                // upload with encryption
                await blob.UploadAsync(new MemoryStream(data));

                // download with decryption
                byte[] downloadData;
                using (var stream = new MemoryStream())
                {
                    await blob.DownloadAsync(stream);
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
            var key = new MockKeyEncryptionKey();
            using (this.GetEncryptedBlockBlobClient(out var blob, key))
            {
                // upload with encryption
                await blob.UploadAsync(new MemoryStream(data));

                // download range with decryption
                byte[] downloadData; // no overload that takes Stream and HttpRange; we must buffer read
                var downloadStream = (await blob.DownloadAsync(new HttpRange(offset, count))).Value.Content;
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
            var key = new MockKeyEncryptionKey();
            using (this.GetEncryptedBlockBlobClient(out var track2Blob, key))
            {
                // upload with track 1
                var creds = GetNewSharedKeyCredentials();
                var track1Blob = new Microsoft.Azure.Storage.Blob.CloudBlockBlob(
                    track2Blob.Uri,
                    new Microsoft.Azure.Storage.Auth.StorageCredentials(creds.AccountName, creds.AccountKeyValue));
                await track1Blob.UploadFromByteArrayAsync(
                    data, 0, data.Length, default,
                    new Microsoft.Azure.Storage.Blob.BlobRequestOptions()
                    {
                        EncryptionPolicy = new Microsoft.Azure.Storage.Blob.BlobEncryptionPolicy(key, key)
                    },
                    default, default);

                // download with track 2
                var downloadStream = new MemoryStream();
                await track2Blob.DownloadAsync(downloadStream);

                // compare original data to downloaded data
                Assert.AreEqual(data, downloadStream.ToArray());
            }
        }

        [Test]
        [LiveOnly] // cannot seed content encryption key
        public async Task Track1DownloadTrack2Blob()
        {
            var data = GetRandomBuffer(Constants.KB); // ensure we have enough room in original data
            var key = new MockKeyEncryptionKey();
            using (GetEncryptedBlockBlobClient(out var track2Blob, key))
            {
                // upload with track 2
                await track2Blob.UploadAsync(new MemoryStream(data));

                // download with track 1
                var creds = GetNewSharedKeyCredentials();
                var track1Blob = new Microsoft.Azure.Storage.Blob.CloudBlockBlob(
                    track2Blob.Uri,
                    new Microsoft.Azure.Storage.Auth.StorageCredentials(creds.AccountName, creds.AccountKeyValue));
                var downloadData = new byte[data.Length];
                await track1Blob.DownloadToByteArrayAsync(downloadData, 0, default,
                    new Microsoft.Azure.Storage.Blob.BlobRequestOptions()
                    {
                        EncryptionPolicy = new Microsoft.Azure.Storage.Blob.BlobEncryptionPolicy(key, key)
                    },
                    default, default);

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
            using (GetNewContainer(out var container))
            {
                var blob = new EncryptedBlobClient(
                    new Uri(Path.Combine(container.Uri.ToString(), this.GetNewBlobName())),
                    this.GetNewSharedKeyCredentials(),
                    keyEncryptionKey: key,
                    encryptionKeyWrapAlgorithm: "RSA-OAEP-256");

                await blob.UploadAsync(new MemoryStream(data));

                var downloadStream = new MemoryStream();
                await blob.DownloadAsync(downloadStream);

                Assert.AreEqual(data, downloadStream.ToArray());
            }
        }
    }
}
