// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Cryptography;
using Azure.Storage.Cryptography.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs
{
    internal class BlobClientSideEncryptor
    {
        private readonly ClientSideEncryptor _encryptor;

        public BlobClientSideEncryptor(ClientSideEncryptor encryptor)
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
        public async Task<(Stream, Metadata)> ClientSideEncryptInternal(
            Stream content,
            Metadata metadata,
            bool async,
            CancellationToken cancellationToken)
        {
            (Stream nonSeekableCiphertext, EncryptionData encryptionData) = await _encryptor.EncryptInternal(
                content,
                async,
                cancellationToken).ConfigureAwait(false);

            metadata ??= new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            metadata[Constants.ClientSideEncryption.EncryptionDataKey] = EncryptionDataSerializer.Serialize(encryptionData);

            return (nonSeekableCiphertext, metadata);
        }
    }
}
