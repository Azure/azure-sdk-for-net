// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Cryptography;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Common;
using Azure.Storage.Cryptography.Models;

namespace Azure.Storage.Blobs.Specialized
{
    /// <summary>
    /// Specialized extensions for <see cref="BlobClient"/>.
    /// </summary>
    public static partial class SpecializedBlobExtensions
    {
        /// <summary>
        /// Rotates the Key Encryption Key (KEK) for a client-side encrypted blob without
        /// needing to reupload the entire blob.
        /// </summary>
        /// <param name="client">
        /// Client to the blob.
        /// </param>
        /// <param name="encryptionOptionsOverride">
        /// Optional override for client-side encryption options to use when updating the key encryption key.
        /// Defaults to the <see cref="ClientSideEncryptionOptions"/> configured on the client when this is
        /// not populated. New key encryption key for the blob will be the
        /// <see cref="ClientSideEncryptionOptions.KeyEncryptionKey"/> on whichever encryption options are
        /// used for the operation. Options must have a resolver that can resolve the old key on the blob.
        /// </param>
        /// <param name="conditions">
        /// Optional request conditions for the operation.
        /// </param>
        /// <param name="cancellationToken">
        /// Cancellation token for the operation.
        /// </param>
        public static void UpdateClientSideKeyEncryptionKey(
            this BlobClient client,
            ClientSideEncryptionOptions encryptionOptionsOverride = default,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
            => UpdateClientsideKeyEncryptionKeyInternal(
                client,
                encryptionOptionsOverride,
                conditions,
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// Rotates the Key Encryption Key (KEK) for a client-side encrypted blob without
        /// needing to reupload the entire blob.
        /// </summary>
        /// <param name="client">
        /// Client to the blob.
        /// </param>
        /// <param name="encryptionOptionsOverride">
        /// Optional override for client-side encryption options to use when updating the key encryption key.
        /// Defaults to the <see cref="ClientSideEncryptionOptions"/> configured on the client when this is
        /// not populated. New key encryption key for the blob will be the
        /// <see cref="ClientSideEncryptionOptions.KeyEncryptionKey"/> on whichever encryption options are
        /// used for the operation. Options must have a resolver that can resolve the old key on the blob.
        /// </param>
        /// <param name="conditions">
        /// Optional request conditions for the operation.
        /// </param>
        /// <param name="cancellationToken">
        /// Cancellation token for the operation.
        /// </param>
        public static async Task UpdateClientSideKeyEncryptionKeyAsync(
            this BlobClient client,
            ClientSideEncryptionOptions encryptionOptionsOverride = default,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
            => await UpdateClientsideKeyEncryptionKeyInternal(
                client,
                encryptionOptionsOverride,
                conditions,
                async: true,
                cancellationToken).ConfigureAwait(false);

        private static async Task UpdateClientsideKeyEncryptionKeyInternal(
            BlobClient client,
            ClientSideEncryptionOptions encryptionOptionsOverride,
            BlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            // argument validation
            Argument.AssertNotNull(client, nameof(client));
            ClientSideEncryptionOptions operationEncryptionOptions = encryptionOptionsOverride
                ?? client.ClientSideEncryption
                ?? throw new ArgumentException($"{nameof(ClientSideEncryptionOptions)} are not configured on this client and none were provided for the operation.");
            Argument.AssertNotNull(operationEncryptionOptions.KeyEncryptionKey, nameof(ClientSideEncryptionOptions.KeyEncryptionKey));
            Argument.AssertNotNull(operationEncryptionOptions.KeyResolver, nameof(ClientSideEncryptionOptions.KeyResolver));
            Argument.AssertNotNull(operationEncryptionOptions.KeyWrapAlgorithm, nameof(ClientSideEncryptionOptions.KeyWrapAlgorithm));

            using (client.ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobClient)))
            {
                client.ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                        $"{nameof(Uri)}: {client.Uri}\n" +
                        $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = client.ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobClient)}.{nameof(UpdateClientSideKeyEncryptionKey)}");

                try
                {
                    // hold onto etag, metadata, encryptiondata
                    BlobProperties getPropertiesResponse = await client.GetPropertiesInternal(conditions, async, new RequestContext() { CancellationToken = cancellationToken }).ConfigureAwait(false);
                    ETag etag = getPropertiesResponse.ETag;
                    IDictionary<string, string> metadata = getPropertiesResponse.Metadata;
                    EncryptionData encryptionData = BlobClientSideDecryptor.GetAndValidateEncryptionDataOrDefault(metadata)
                        ?? throw new InvalidOperationException("Resource has no client-side encryption key to rotate.");

                    // rotate keywrapping
                    byte[] newWrappedKey = await WrapKeyInternal(
                        await UnwrapKeyInternal(
                            encryptionData,
                            operationEncryptionOptions.KeyResolver,
                            async,
                            cancellationToken).ConfigureAwait(false),
                        operationEncryptionOptions.KeyWrapAlgorithm,
                        operationEncryptionOptions.KeyEncryptionKey,
                        async,
                        cancellationToken).ConfigureAwait(false);

                    // set new wrapped key info and reinsert into metadata
                    encryptionData.WrappedContentKey = new KeyEnvelope
                    {
                        EncryptedKey = newWrappedKey,
                        Algorithm = operationEncryptionOptions.KeyWrapAlgorithm,
                        KeyId = operationEncryptionOptions.KeyEncryptionKey.KeyId
                    };
                    metadata[Constants.ClientSideEncryption.EncryptionDataKey] = EncryptionDataSerializer.Serialize(encryptionData);

                    // update blob ONLY IF ETAG MATCHES (do not take chances encryption info is now out of sync)
                    BlobRequestConditions modifiedRequestConditions = BlobRequestConditions.CloneOrDefault(conditions) ?? new BlobRequestConditions();
                    modifiedRequestConditions.IfMatch = etag;
                    await client.SetMetadataInternal(metadata, modifiedRequestConditions, async, cancellationToken).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    client.ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    client.ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                    scope.Dispose();
                }
            }
        }

        private static async Task<byte[]> UnwrapKeyInternal(EncryptionData encryptionData, IKeyEncryptionKeyResolver keyResolver, bool async, CancellationToken cancellationToken)
        {
            IKeyEncryptionKey oldKey = async
                    ? await keyResolver.ResolveAsync(encryptionData.WrappedContentKey.KeyId, cancellationToken).ConfigureAwait(false)
                    : keyResolver.Resolve(encryptionData.WrappedContentKey.KeyId, cancellationToken);

            if (oldKey == default)
            {
                throw Errors.ClientSideEncryption.KeyNotFound(encryptionData.WrappedContentKey.KeyId);
            }

            return async
                ? await oldKey.UnwrapKeyAsync(
                    encryptionData.WrappedContentKey.Algorithm,
                    encryptionData.WrappedContentKey.EncryptedKey,
                    cancellationToken).ConfigureAwait(false)
                : oldKey.UnwrapKey(
                    encryptionData.WrappedContentKey.Algorithm,
                    encryptionData.WrappedContentKey.EncryptedKey,
                    cancellationToken);
        }

        private static async Task<byte[]> WrapKeyInternal(ReadOnlyMemory<byte> contentEncryptionKey, string keyWrapAlgorithm, IKeyEncryptionKey key, bool async, CancellationToken cancellationToken)
        {
            return async
                ? await key.WrapKeyAsync(
                    keyWrapAlgorithm,
                    contentEncryptionKey,
                    cancellationToken).ConfigureAwait(false)
                : key.WrapKey(
                    keyWrapAlgorithm,
                    contentEncryptionKey,
                    cancellationToken);
        }
    }
}
