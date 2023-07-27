// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Cryptography;
using Azure.Storage.Cryptography.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs
{
    internal class BlobClientSideEncryptor
    {
        private readonly IClientSideEncryptor _encryptor;

        public BlobClientSideEncryptor(IClientSideEncryptor encryptor)
        {
            _encryptor = encryptor;
        }

        /// <summary>
        /// Applies client-side encryption to the data for upload.
        /// </summary>
        /// <param name="content">
        /// Content to encrypt.
        /// </param>
        /// <param name="metadata">
        /// Metadata to add encryption metadata to.
        /// </param>
        /// <param name="async">
        /// Whether to perform this operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Cancellation token.
        /// </param>
        /// <returns>Transformed content stream and metadata.</returns>
        public async Task<(Stream NonSeekableCiphertext, Metadata Metadata)> ClientSideEncryptInternal(
            Stream content,
            Metadata metadata,
            bool async,
            CancellationToken cancellationToken)
        {
            (Stream NonSeekableCiphertext, EncryptionData EncryptionData) = await _encryptor.EncryptInternal(
                content,
                async,
                cancellationToken).ConfigureAwait(false);

            Metadata modifiedMetadata = TransformMetadata(metadata, EncryptionData);

            return (NonSeekableCiphertext, modifiedMetadata);
        }

        /// <summary>
        /// Creates a crypto transform stream to write blob contents to.
        /// </summary>
        /// <param name="blobClient">
        /// BlobClient to open write with.
        /// </param>
        /// <param name="overwrite">
        /// Overwrite parameter to open write.
        /// </param>
        /// <param name="options">
        /// Options parameter to open write.
        /// </param>
        /// <param name="async">
        /// Whether to perform this operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Content transform write stream and metadata.
        /// </returns>
        public async Task<Stream> ClientSideEncryptionOpenWriteInternal(
            BlockBlobClient blobClient,
            bool overwrite,
            BlockBlobOpenWriteOptions options,
            bool async,
            CancellationToken cancellationToken)
        {
            Stream encryptionWriteStream = await _encryptor.EncryptedOpenWriteInternal(
                async (encryptiondata, funcAsync, funcCancellationToken) =>
                {
                    options ??= new BlockBlobOpenWriteOptions();
                    options.Metadata = TransformMetadata(options.Metadata, encryptiondata);

                    return await blobClient.OpenWriteInternal(
                            overwrite,
                            options,
                            funcAsync,
                            funcCancellationToken).ConfigureAwait(false);
                },
                async,
                cancellationToken).ConfigureAwait(false);

            return encryptionWriteStream;
        }

        /// <summary>
        /// Adds encryption data to provided blob metadata, overwriting previous entry if any.
        /// Safely creates new metadata object if none is provided.
        /// </summary>
        /// <param name="metadata">Optionally existing metadata.</param>
        /// <param name="encryptionData">Encryption data to add.</param>
        private static Metadata TransformMetadata(Metadata metadata, EncryptionData encryptionData)
        {
            Metadata modifiedMetadata = metadata == default
                ? new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                : new Dictionary<string, string>(metadata, StringComparer.OrdinalIgnoreCase);
            modifiedMetadata[Constants.ClientSideEncryption.EncryptionDataKey] = EncryptionDataSerializer.Serialize(encryptionData);

            return modifiedMetadata;
        }
    }
}
