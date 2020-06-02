// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Cryptography;
using Azure.Storage.Cryptography;
using Azure.Storage.Cryptography.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs
{
    internal class BlobClientSideEncryptor
    {
        private readonly IKeyEncryptionKey _keyEncryptionKey;
        private readonly string _keyWrapAlgorithm;

        public BlobClientSideEncryptor(ClientSideEncryptionOptions options)
        {
            _keyEncryptionKey = options.KeyEncryptionKey;
            _keyWrapAlgorithm = options.KeyWrapAlgorithm;
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
            if (_keyEncryptionKey == default || _keyWrapAlgorithm == default)
            {
                throw Errors.ClientSideEncryption.MissingRequiredEncryptionResources(nameof(_keyEncryptionKey), nameof(_keyWrapAlgorithm));
            }

            //long originalLength = content.Length;

            (Stream nonSeekableCiphertext, EncryptionData encryptionData) = await ClientSideEncryptor.EncryptInternal(
                content,
                _keyEncryptionKey,
                _keyWrapAlgorithm,
                async,
                cancellationToken).ConfigureAwait(false);

            //Stream seekableCiphertext = new RollingBufferStream(
            //        nonSeekableCiphertext,
            //        EncryptionConstants.DefaultRollingBufferSize,
            //        GetExpectedCryptoStreamLength(originalLength));

            metadata ??= new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            metadata.Add(EncryptionConstants.EncryptionDataKey, EncryptionDataSerializer.Serialize(encryptionData));

            return (nonSeekableCiphertext, metadata);
        }

        private static long GetExpectedCryptoStreamLength(long originalLength)
            => originalLength + (EncryptionConstants.EncryptionBlockSize - originalLength % EncryptionConstants.EncryptionBlockSize);
    }
}
