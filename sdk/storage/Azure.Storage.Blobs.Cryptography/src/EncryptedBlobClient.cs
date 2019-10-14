// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using Azure.Core;
using Azure.Core.Cryptography;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Specialized.Cryptography.Models;
using Azure.Storage.Common;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Specialized.Cryptography
{
    /// <summary>
    /// The <see cref="EncryptedBlobClient"/> allows you to manipulate
    /// Azure Storage block blobs with client-side encryption. See
    /// <see cref="BlobClient"/> for more details.
    /// </summary>
    public class EncryptedBlobClient : BlobClient
    {

        /// <summary>
        /// The wrapper used to wrap the content encryption key.
        /// </summary>
        private IKeyEncryptionKey KeyWrapper { get; }

        /// <summary>
        /// The algorithm identifier to use with <see cref="KeyWrapper"/>.
        /// </summary>
        private string KeyWrapAlgorithm { get; }

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="EncryptedBlobClient"/>
        /// class for mocking.
        /// </summary>
        protected EncryptedBlobClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EncryptedBlobClient"/>
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
        /// <param name="keyEncryptionKey">
        /// Required for uploads. Provider to wrap the one-time content encryption key via the envelope technique.
        /// </param>
        /// <param name="keyResolver">
        /// Required for downloads. Provider to get the correct <see cref="IKeyEncryptionKey"/> for a given download.
        /// The fetched <see cref="IKeyEncryptionKey"/> will be used to unwrap the one-time content encryption key via
        /// the envelope technique.
        /// </param>
        /// <param name="encryptionKeyWrapAlgorithm">
        /// Required for uploads. String identifier of the key wrapping algorithm the client should use with
        /// <paramref name="keyEncryptionKey"/>.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public EncryptedBlobClient(
            string connectionString,
            string containerName,
            string blobName,
            IKeyEncryptionKey keyEncryptionKey = default,
            IKeyEncryptionKeyResolver keyResolver = default,
            string encryptionKeyWrapAlgorithm = default,
            BlobClientOptions options = default)
            : base(
                  connectionString,
                  containerName,
                  blobName,
                  options.WithPolicy(new ClientSideDecryptionPolicy(keyResolver, keyEncryptionKey)))
        {
            this.KeyWrapper = keyEncryptionKey;
            this.KeyWrapAlgorithm = encryptionKeyWrapAlgorithm;
        }

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
        /// <param name="keyEncryptionKey">
        /// Required for uploads. Provider to wrap the one-time content encryption key via the envelope technique.
        /// </param>
        /// <param name="keyResolver">
        /// Required for downloads. Provider to get the correct <see cref="IKeyEncryptionKey"/> for a given download.
        /// The fetched <see cref="IKeyEncryptionKey"/> will be used to unwrap the one-time content encryption key via
        /// the envelope technique.
        /// </param>
        /// <param name="encryptionKeyWrapAlgorithm">
        /// Required for uploads. String identifier of the key wrapping algorithm the client should use with
        /// <paramref name="keyEncryptionKey"/>.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public EncryptedBlobClient(
            Uri blobUri,
            StorageSharedKeyCredential credential,
            IKeyEncryptionKey keyEncryptionKey = default,
            IKeyEncryptionKeyResolver keyResolver = default,
            string encryptionKeyWrapAlgorithm = default,
            BlobClientOptions options = default)
            : base(
                  blobUri,
                  credential,
                  options.WithPolicy(new ClientSideDecryptionPolicy(keyResolver, keyEncryptionKey)))
        {
            this.KeyWrapper = keyEncryptionKey;
            this.KeyWrapAlgorithm = encryptionKeyWrapAlgorithm;
        }

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
        /// <param name="keyEncryptionKey">
        /// Required for uploads. Provider to wrap the one-time content encryption key via the envelope technique.
        /// </param>
        /// <param name="keyResolver">
        /// Required for downloads. Provider to get the correct <see cref="IKeyEncryptionKey"/> for a given download.
        /// The fetched <see cref="IKeyEncryptionKey"/> will be used to unwrap the one-time content encryption key via
        /// the envelope technique.
        /// </param>
        /// <param name="encryptionKeyWrapAlgorithm">
        /// Required for uploads. String identifier of the key wrapping algorithm the client should use with
        /// <paramref name="keyEncryptionKey"/>.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public EncryptedBlobClient(
            Uri blobUri,
            TokenCredential credential,
            IKeyEncryptionKey keyEncryptionKey = default,
            IKeyEncryptionKeyResolver keyResolver = default,
            string encryptionKeyWrapAlgorithm = default,
            BlobClientOptions options = default)
            : base(
                  blobUri,
                  credential,
                  options.WithPolicy(new ClientSideDecryptionPolicy(keyResolver, keyEncryptionKey)))
        {
            this.KeyWrapper = keyEncryptionKey;
            this.KeyWrapAlgorithm = encryptionKeyWrapAlgorithm;
        }

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
        internal EncryptedBlobClient(Uri blobUri, HttpPipeline pipeline)
            : base(blobUri, pipeline)
        {
            //TODO make new pipeline for this one
        }
        #endregion ctors

        /// <summary>
        /// This method performs a transform on the content stream for uploads. It is a no-op by default.
        /// </summary>
        /// <param name="content">Content to transform.</param>
        /// <param name="metadata">Content metadata to transform.</param>
        /// <returns>Transformed content stream.</returns>
        internal override (Stream, Metadata) TransformContent(Stream content, Metadata metadata)
        {
            metadata ??= new Dictionary<string, string>();

            var (encryptionStream, encryptionData) = EncryptStream(content);

            using (var stream = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(EncryptionData));
                serializer.WriteObject(stream, encryptionData);
                stream.Position = 0;
                metadata.Add(EncryptionConstants.ENCRYPTION_DATA_KEY, new StreamReader(stream).ReadToEnd());
            }

            return (encryptionStream, metadata);
        }

        private (Stream, EncryptionData) EncryptStream(Stream plaintext)
        {
            var generatedKey = CreateKey(EncryptionConstants.ENCRYPTION_KEY_SIZE_BITS);

            using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider() { Key = generatedKey })
            {

                var encryptionData = new EncryptionData()
                {
                    EncryptionMode = EncryptionConstants.ENCRYPTION_MODE,
                    ContentEncryptionIV = aesProvider.IV,
                    EncryptionAgent = new EncryptionAgent()
                    {
                        EncryptionAlgorithm = Enum.GetName(typeof(ClientsideEncryptionAlgorithm), ClientsideEncryptionAlgorithm.AES_CBC_256),
                        Protocol = EncryptionConstants.ENCRYPTION_PROTOCOL_V1
                    },
                    KeyWrappingMetadata = new Dictionary<string, string>()
                    {
                        { EncryptionConstants.AGENT_METADATA_KEY, EncryptionConstants.AGENT_METADATA_VALUE }
                    },
                    WrappedContentKey = new WrappedKey()
                    {
                        Algorithm = KeyWrapAlgorithm,
                        EncryptedKey = KeyWrapper.WrapKey(KeyWrapAlgorithm, generatedKey).ToArray(),
                        KeyId = KeyWrapper.KeyId
                    }
                };

                return (
                    new RollingBufferStream(
                        new CryptoStream(plaintext, aesProvider.CreateEncryptor(), CryptoStreamMode.Read),
                        EncryptionConstants.DEFAULT_ROLLING_BUFFER_SIZE,
                        plaintext.Length + (EncryptionConstants.ENCRYPTION_BLOCK_SIZE - plaintext.Length % EncryptionConstants.ENCRYPTION_BLOCK_SIZE)),
                    encryptionData);
            }
        }

        /// <summary>
        /// Securely generate a key.
        /// </summary>
        /// <param name="numBits">Key size.</param>
        /// <returns>The generated key bytes.</returns>
        private static byte[] CreateKey(int numBits)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var buff = new byte[numBits / 8];
                rng.GetBytes(buff);
                return buff;
            }
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal static class BlobClientOptionsExtensions
#pragma warning restore SA1402 // File may only contain a single type
    {
        public static BlobClientOptions WithPolicy(
           this BlobClientOptions options,
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
