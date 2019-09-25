// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Azure.Core;
using Azure.Core.Cryptography;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Specialized.Cryptography.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Specialized.Cryptography
{
    /// <summary>
    /// The <see cref="EncryptedBlockBlobClient"/> allows you to manipulate
    /// Azure Storage block blobs with client-side encryption. See
    /// <see cref="BlockBlobClient"/> for more details.
    /// 
    /// This class does support partial writes as a normal block blob client
    /// would. Due to the nature of this encryption algorithm, the entire blob
    /// must be reuploaded. Partial reads are still supported.
    /// </summary>
    public class EncryptedBlockBlobClient : BlobClient
    {
        private IKeyEncryptionKeyResolver KeyResolver { get; }

        /// <summary>
        /// The wrapper is used to wrap/unwrap the content key during encryption.
        /// </summary>
        private IKeyEncryptionKey KeyWrapper { get; }

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="EncryptedBlockBlobClient"/>
        /// class for mocking.
        /// </summary>
        protected EncryptedBlockBlobClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EncryptedBlockBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information, <see href="https://docs.microsoft.com/en-us/azure/storage/common/storage-configure-connection-string"/>.
        /// </param>
        /// <param name="containerName">
        /// The name of the container containing this encrypted block blob.
        /// </param>
        /// <param name="blobName">
        /// The name of this encrypted block blob.
        /// </param>
        /// <param name="key"></param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public EncryptedBlockBlobClient(
            string connectionString,
            string containerName,
            string blobName,
            ClientSideEncryptionKey key,
            BlobClientOptions options = default)
            : base(connectionString, containerName, blobName, FluentAddPolicy(options, new ClientSideBlobDecryptionPolicy(key)))
        { }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="BlockBlobClient"/>
        ///// class.
        ///// </summary>
        ///// <param name="blobUri">
        ///// A <see cref="Uri"/> referencing the encrypted block blob that includes the
        ///// name of the account, the name of the container, and the name of
        ///// the blob.
        ///// </param>
        ///// <param name="key"></param>
        ///// <param name="options">
        ///// Optional client options that define the transport pipeline
        ///// policies for authentication, retries, etc., that are applied to
        ///// every request.
        ///// </param>
        //public EncryptedBlockBlobClient(
        //    Uri blobUri,
        //    ClientSideEncryptionKey key,
        //    BlobClientOptions options = default)
        //    : base(blobUri, FluentAddPolicy(options, new ClientSideBlobDecryptionPolicy(key)))
        //{
        //    _blockBlobClient = new BlobClient(blobUri, options);
        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="key"></param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public EncryptedBlockBlobClient(
            Uri blobUri,
            StorageSharedKeyCredential credential,
            ClientSideEncryptionKey key,
            BlobClientOptions options = default)
            : base(blobUri, credential, FluentAddPolicy(options, new ClientSideBlobDecryptionPolicy(key)))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="key"></param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public EncryptedBlockBlobClient(
            Uri blobUri,
            TokenCredential credential,
            ClientSideEncryptionKey key,
            BlobClientOptions options = default)
            : base(blobUri, credential, FluentAddPolicy(options, new ClientSideBlobDecryptionPolicy(key)))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the encrypted block blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        internal EncryptedBlockBlobClient(Uri blobUri, HttpPipeline pipeline)
            : base(blobUri, pipeline)
        {
            //TODO make new pipeline form this one
        }

        private static BlobClientOptions FluentAddPolicy(
           BlobClientOptions options,
           HttpPipelinePolicy policy,
           HttpPipelinePosition position = HttpPipelinePosition.PerCall)
        {
            if (options == default)
            {
                options = new BlobClientOptions();
            }
            options.AddPolicy(policy, position);
            return options;
        }
        #endregion ctors

        /// <summary>
        /// This method performs a transform on the content stream for uploads. It is a no-op by default.
        /// </summary>
        /// <param name="content">Content to transform.</param>
        /// <param name="metadata">Content metadata to transform.</param>
        /// <returns>Transformed content stream.</returns>
        internal protected override (Stream, Metadata) TransformContent(Stream content, Metadata metadata)
        {
            var (encryptionStream, encryptionData) = EncryptStream(content, null); // TODO add key
            //TODO add encryption data to metadata
            return (encryptionStream, metadata);
        }

        private (Stream, EncryptionData) EncryptStream(Stream plaintext, byte[] keyEncryptionKey)
        {
            var generatedKey = CreateKey(EncryptionConstants.ENCRYPTION_KEY_SIZE);

            using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider() { Key = generatedKey })
            {

                var encryptionData = new EncryptionData()
                {
                    EncryptionMode = "FullBlob",
                    ContentEncryptionIV = aesProvider.IV,
                    EncryptionAgent = new EncryptionAgent()
                    {
                        Algorithm = ClientsideEncryptionAlgorithm.AES_CBC_256,
                        Protocol = EncryptionConstants.ENCRYPTION_PROTOCOL_V1
                    },
                    KeyWrappingMetadata = new Dictionary<string, string>()
                    {
                        { EncryptionConstants.AGENT_METADATA_KEY, EncryptionConstants.AGENT_METADATA_VALUE }
                    },
                    WrappedContentKey = new WrappedKey()
                    {
                        Algorithm = null, // TODO
                        EncryptedKey = this.KeyWrapper.WrapKey(null /*algorithm*/, keyEncryptionKey).ToArray(), // TODO what algorithm?
                        KeyId = null // TODO need interface update from identity
                    }
                };

                return (new CryptoStream(plaintext, aesProvider.CreateEncryptor(), CryptoStreamMode.Write), encryptionData);
            }
        }

        /// <summary>
        /// Securely generate a key.
        /// </summary>
        /// <param name="numBytes">Key size.</param>
        /// <returns>The generated key bytes.</returns>
        private static byte[] CreateKey(int numBytes)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var buff = new byte[numBytes];
                rng.GetBytes(buff);
                return buff;
            }
        }
    }

    // TODO to be re-added upon resolution of https://github.com/Azure/azure-sdk-for-net/issues/7713
    ///// <summary>
    ///// Add easy to discover methods to <see cref="BlobContainerClient"/> for
    ///// creating <see cref="EncryptedBlockBlobClient"/> instances.
    ///// </summary>
    //public static partial class SpecializedBlobExtensions
    //{
    //    /// <summary>
    //    /// Create a new <see cref="EncryptedBlockBlobClient"/> object by
    //    /// concatenating <paramref name="blobName"/> to
    //    /// the end of the <paramref name="client"/>'s
    //    /// <see cref="BlobContainerClient.Uri"/>. The new
    //    /// <see cref="EncryptedBlockBlobClient"/>
    //    /// uses the same request policy pipeline as the
    //    /// <see cref="BlobContainerClient"/>.
    //    /// </summary>
    //    /// <param name="client">The <see cref="BlobContainerClient"/>.</param>
    //    /// <param name="blobName">The name of the encrypted block blob.</param>
    //    /// <returns>A new <see cref="EncryptedBlockBlobClient"/> instance.</returns>
    //    public static EncryptedBlockBlobClient GetEncryptedBlockBlobClient(
    //        this BlobContainerClient client,
    //        string blobName)
    //        => new EncryptedBlockBlobClient(client.Uri.AppendToPath(blobName), client.Pipeline);
    //}
}
