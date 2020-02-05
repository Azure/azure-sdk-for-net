// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using Azure.Core;
using Azure.Core.Cryptography;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized.Models;
using Azure.Storage.Common;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Specialized
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
        /// <param name="blobContainerName">
        /// The name of the container containing this encrypted block blob.
        /// </param>
        /// <param name="blobName">
        /// The name of this encrypted block blob.
        /// </param>
        /// <param name="encryptionOptions">
        /// Clientside encryption options to provide encryption and/or
        /// decryption implementations to the client.
        /// every request.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public EncryptedBlobClient(
            string connectionString,
            string blobContainerName,
            string blobName,
            ClientsideEncryptionOptions encryptionOptions,
            BlobClientOptions options = default)
            : base(
                  connectionString,
                  blobContainerName,
                  blobName,
                  options.WithPolicy(new ClientSideDecryptionPolicy(
                      encryptionOptions.KeyResolver,
                      encryptionOptions.KeyEncryptionKey)))
        {
            KeyWrapper = encryptionOptions.KeyEncryptionKey;
            KeyWrapAlgorithm = encryptionOptions.EncryptionKeyWrapAlgorithm;
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
        /// <param name="encryptionOptions">
        /// Clientside encryption options to provide encryption and/or
        /// decryption implementations to the client.
        /// every request.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public EncryptedBlobClient(
            Uri blobUri,
            ClientsideEncryptionOptions encryptionOptions,
            BlobClientOptions options = default)
            : base(
                  blobUri,
                  options.WithPolicy(new ClientSideDecryptionPolicy(
                      encryptionOptions.KeyResolver,
                      encryptionOptions.KeyEncryptionKey)))
        {
            KeyWrapper = encryptionOptions.KeyEncryptionKey;
            KeyWrapAlgorithm = encryptionOptions.EncryptionKeyWrapAlgorithm;
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
        /// <param name="encryptionOptions">
        /// Clientside encryption options to provide encryption and/or
        /// decryption implementations to the client.
        /// every request.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public EncryptedBlobClient(
            Uri blobUri,
            StorageSharedKeyCredential credential,
            ClientsideEncryptionOptions encryptionOptions,
            BlobClientOptions options = default)
            : base(
                  blobUri,
                  credential,
                  options.WithPolicy(new ClientSideDecryptionPolicy(
                      encryptionOptions.KeyResolver,
                      encryptionOptions.KeyEncryptionKey)))
        {
            KeyWrapper = encryptionOptions.KeyEncryptionKey;
            KeyWrapAlgorithm = encryptionOptions.EncryptionKeyWrapAlgorithm;
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
        /// <param name="encryptionOptions">
        /// Clientside encryption options to provide encryption and/or
        /// decryption implementations to the client.
        /// every request.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public EncryptedBlobClient(
            Uri blobUri,
            TokenCredential credential,
            ClientsideEncryptionOptions encryptionOptions,
            BlobClientOptions options = default)
            : base(
                  blobUri,
                  credential,
                  options.WithPolicy(new ClientSideDecryptionPolicy(
                      encryptionOptions.KeyResolver,
                      encryptionOptions.KeyEncryptionKey)))
        {
            KeyWrapper = encryptionOptions.KeyEncryptionKey;
            KeyWrapAlgorithm = encryptionOptions.EncryptionKeyWrapAlgorithm;
        }

        private EncryptedBlobClient(
            Uri blobUri,
            ClientsideEncryptionOptions encryptionOptions,
            HttpPipelinePolicy authentication,
            BlobClientOptions options)
            : base(blobUri, authentication, options)
        {
            KeyWrapper = encryptionOptions.KeyEncryptionKey;
            KeyWrapAlgorithm = encryptionOptions.EncryptionKeyWrapAlgorithm;
        }

        /// <summary>
        /// This behaves like a constructor. It has a conflicting signature with another public construtor, but
        /// has different behavior. The necessary extra behavior happens in this method and then invokes a private
        /// constructor with a now-unique signature.
        /// </summary>
        /// <param name="containerClient"></param>
        /// <param name="blobName"></param>
        /// <param name="encryptionOptions"></param>
        /// <returns></returns>
        internal static EncryptedBlobClient EncryptedBlobClientFromContainerClient(
            BlobContainerClient containerClient,
            string blobName,
            ClientsideEncryptionOptions encryptionOptions)
        {
            (var options, var authPolicy) = GetContainerPipelineInfo(containerClient);

            var editedOptions = new BlobClientOptions(options);
            editedOptions.AddPolicy(
                new ClientSideDecryptionPolicy(encryptionOptions.KeyResolver, encryptionOptions.KeyEncryptionKey),
                HttpPipelinePosition.PerCall);

            return new EncryptedBlobClient(
                containerClient.Uri.AppendToPath(blobName),
                encryptionOptions,
                authPolicy,
                editedOptions);
        }
        #endregion ctors

        /// <summary>
        /// Encrypts the upload stream.
        /// </summary>
        /// <param name="content">Content to transform.</param>
        /// <param name="metadata">Content metadata to transform.</param>
        /// <returns>Transformed content stream.</returns>
        public override (Stream, Metadata) TransformContent(Stream content, Metadata metadata)
        {
            metadata ??= new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            (Stream encryptionStream, EncryptionData encryptionData) = EncryptStream(content);
            metadata.Add(EncryptionConstants.EncryptionDataKey, encryptionData.Serialize());

            return (encryptionStream, metadata);
        }

        private (Stream, EncryptionData) EncryptStream(Stream plaintext)
        {
            var generatedKey = CreateKey(EncryptionConstants.EncryptionKeySizeBits);

            using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider() { Key = generatedKey })
            {

                var encryptionData = new EncryptionData()
                {
                    EncryptionMode = EncryptionConstants.EncryptionMode,
                    ContentEncryptionIV = aesProvider.IV,
                    EncryptionAgent = new EncryptionAgent()
                    {
                        EncryptionAlgorithm = Enum.GetName(typeof(ClientsideEncryptionAlgorithm), ClientsideEncryptionAlgorithm.AES_CBC_256),
                        Protocol = EncryptionConstants.EncryptionProtocolV1
                    },
                    KeyWrappingMetadata = new Dictionary<string, string>()
                    {
                        { EncryptionConstants.AgentMetadataKey, EncryptionConstants.AgentMetadataValue }
                    },
                    WrappedContentKey = new WrappedKey()
                    {
                        Algorithm = KeyWrapAlgorithm,
                        EncryptedKey = KeyWrapper.WrapKey(KeyWrapAlgorithm, generatedKey), // TODO async-branching
                        KeyId = KeyWrapper.KeyId
                    }
                };

                return (
                    new RollingBufferStream(
                        new CryptoStream(plaintext, aesProvider.CreateEncryptor(), CryptoStreamMode.Read),
                        EncryptionConstants.DefaultRollingBufferSize,
                        plaintext.Length + (EncryptionConstants.EncryptionBlockSize - plaintext.Length % EncryptionConstants.EncryptionBlockSize)),
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

    /// <summary>
    /// Add easy to discover methods to <see cref="BlobContainerClient"/> for
    /// creating <see cref="EncryptedBlobClient"/> instances.
    /// </summary>
#pragma warning disable SA1402 // File may only contain a single type
    public static partial class SpecializedBlobExtensions
#pragma warning restore SA1402 // File may only contain a single type
    {
        /// <summary>
        /// Create a new <see cref="EncryptedBlobClient"/> object by
        /// concatenating <paramref name="blobName"/> to
        /// the end of the <paramref name="containerClient"/>'s
        /// <see cref="BlobContainerClient.Uri"/>.
        /// </summary>
        /// <param name="containerClient">The <see cref="BlobContainerClient"/>.</param>
        /// <param name="blobName">The name of the encrypted block blob.</param>
        /// <param name="encryptionOptions">
        /// Clientside encryption options to provide encryption and/or
        /// decryption implementations to the client.
        /// every request.
        /// </param>
        /// <returns>A new <see cref="EncryptedBlobClient"/> instance.</returns>
        public static EncryptedBlobClient GetEncryptedBlobClient(
            this BlobContainerClient containerClient,
            string blobName,
            ClientsideEncryptionOptions encryptionOptions)
            /*
             * Extension methods have to be in their own static class, but the logic for this method needs a protected
             * static method in BlobBaseClient. So this extension method just passes the arguments on to a place with
             * access to that method.
             */
            => EncryptedBlobClient.EncryptedBlobClientFromContainerClient(
                containerClient,
                blobName,
                encryptionOptions);
    }
}
