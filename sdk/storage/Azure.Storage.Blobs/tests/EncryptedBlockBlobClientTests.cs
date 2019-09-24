// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Azure.Core.Cryptography;
using Azure.Core.Testing;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Specialized.Cryptography;
using Azure.Storage.Blobs.Specialized.Cryptography.Models;
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
        private IDisposable GetEncryptedBlockBlobClient(out EncryptedBlockBlobClient blob, byte[] key)
        {
            var disposable = this.GetNewContainer(out var container);
            blob = new EncryptedBlockBlobClient(
                    new Uri(container.Uri, this.GetNewBlobName()), this.GetNewSharedKeyCredentials(),
                    new ClientSideEncryptionKey(new IKeyEncryptionKey()));

            return disposable;
        }

        /// <summary>
        /// Generates a new key to use for encryption.
        /// IMPORTANT: this does not generate a secure key. We are generating a throwaway key for testing purposes, so
        /// we generate it quickly but insecurely.
        /// </summary>
        /// <returns>A byte buffer with the generated key.</returns>
        private byte[] GetRandomKey()
        {
            var buf = new byte[EncryptionConstants.ENCRYPTION_KEY_SIZE];
            new Random().NextBytes(buf);
            return buf;
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
                using (var reader = new StringReader(encryptedDataString))
                {
                    var serializer = new XmlSerializer(typeof(EncryptionData));
                    encryptionData = (EncryptionData)serializer.Deserialize(reader);
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
                cryptoStream.Write(data);
                return memStream.ToArray();
            }
        }

        #endregion

        //// Placeholder test to verify things work end-to-end
        //[Test]
        //public async Task DeleteAsync()
        //{
        //    using (this.GetNewContainer(out var container))
        //    {
        //        // First upload a regular block blob
        //        var blobName = this.GetNewBlobName();
        //        var blob = this.InstrumentClient(container.GetBlockBlobClient(blobName));
        //        var data = this.GetRandomBuffer(Constants.KB);
        //        using var stream = new MemoryStream(data);
        //        await blob.UploadAsync(stream);

        //        // Create an EncryptedBlockBlobClient pointing at the same blob
        //        var encryptedBlob = this.InstrumentClient(container.GetEncryptedBlockBlobClient(blobName));

        //        // Delete the blob
        //        var response = await encryptedBlob.DeleteAsync();
        //        Assert.IsNotNull(response.Headers.RequestId);
        //    }
        //}
        
        [TestCase(16)] // a single cipher block
        [TestCase(14)] // a single unalligned cipher block
        [TestCase(Constants.KB)] // multiple blocks
        [TestCase(Constants.KB - 4)] // multiple unalligned blocks
        public void Upload(long dataSize)
        {
            var data = GetRandomBuffer(dataSize);
            var key = GetRandomKey();
            using (this.GetEncryptedBlockBlobClient(out var blob, key))
            {
                // upload with encryption
                blob.Upload(new MemoryStream(data));

                // download without decrypting
                var normalBlob = new BlobClient(blob.Uri, this.GetNewSharedKeyCredentials()).Download().Value;
                var encryptedData = new byte[normalBlob.ContentLength];
                normalBlob.Content.Read(encryptedData);

                // encrypt original data manually for comparison
                byte[] expectedEncryptedData = LocalManualEncryption(data, key,
                    GetAndValidateEncryptionData(normalBlob.Properties.Metadata).ContentEncryptionIV);

                // compare data
                Assert.AreEqual(expectedEncryptedData, encryptedData);
            }
        }

        [TestCase(16)] // a single cipher block
        [TestCase(14)] // a single unalligned cipher block
        [TestCase(Constants.KB)] // multiple blocks
        [TestCase(Constants.KB - 4)] // multiple unalligned blocks
        public async Task UploadAsync(long dataSize)
        {
            var data = GetRandomBuffer(dataSize);
            var key = GetRandomKey();
            using (this.GetEncryptedBlockBlobClient(out var blob, key))
            {
                // upload with encryption
                await blob.UploadAsync(new MemoryStream(data));

                // download without decrypting
                var blobInfo = (await new BlobClient(blob.Uri, this.GetNewSharedKeyCredentials()).DownloadAsync()).Value;
                var encryptedData = new byte[blobInfo.ContentLength];
                await blobInfo.Content.ReadAsync(encryptedData);

                // encrypt original data manually for comparison
                byte[] expectedEncryptedData = LocalManualEncryption(data, key,
                    GetAndValidateEncryptionData(blobInfo.Properties.Metadata).ContentEncryptionIV);

                // compare data
                Assert.AreEqual(expectedEncryptedData, encryptedData);
            }
        }
    }
}
