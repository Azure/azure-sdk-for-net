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
using Azure.Storage.Cryptography.Models;

namespace Azure.Storage.Blobs.Specialized
{
    /// <summary>
    /// Specialized extensions for <see cref="BlobClient"/>.
    /// </summary>
    public static class BlobClientSpecializedExtensions
    {
        /// <summary>
        /// Rotates the Key Encryption Key (KEK) for a client-side encrypted blob without
        /// needing to reupload the entire blob.
        /// </summary>
        /// <param name="client">
        /// Client to the blob.
        /// </param>
        /// <param name="requestConditions">
        /// Request conditions for accessing the blob.
        /// </param>
        /// <param name="newKeyOverride">
        /// Optional override of the new Key Encryption Key for the blob. Will default to the
        /// client's <see cref="ClientSideEncryptionOptions.KeyEncryptionKey"/>.
        /// </param>
        /// <param name="oldKeyResolverOverride">
        /// Optional override for the resolver to resolve the blob's current Key Encryption
        /// Key. Will default to the client's <see cref="ClientSideEncryptionOptions.KeyResolver"/>.
        /// </param>
        /// <param name="keywrapAlgorithmOverride">
        /// Optional override for the key-wrap algorithm to re-wrap the Content Encryption Key.
        /// Will default to the client's <see cref="ClientSideEncryptionOptions.KeyWrapAlgorithm"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Cancellation token for the operation.
        /// </param>
        public static void RotateClientSideEncryptionKey(
            this BlobClient client,
            BlobRequestConditions requestConditions = default,
            IKeyEncryptionKey newKeyOverride = default,
            IKeyEncryptionKeyResolver oldKeyResolverOverride = default,
            string keywrapAlgorithmOverride = default,
            CancellationToken cancellationToken = default)
            => RotateClientsideEncryptionKeyInternal(
                client,
                requestConditions,
                newKeyOverride,
                oldKeyResolverOverride,
                keywrapAlgorithmOverride,
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// Rotates the Key Encryption Key (KEK) for a client-side encrypted blob without
        /// needing to reupload the entire blob.
        /// </summary>
        /// <param name="client">
        /// Client to the blob.
        /// </param>
        /// <param name="requestConditions">
        /// Request conditions for accessing the blob.
        /// </param>
        /// <param name="newKeyOverride">
        /// Optional override of the new Key Encryption Key for the blob. Will default to the
        /// client's <see cref="ClientSideEncryptionOptions.KeyEncryptionKey"/>.
        /// </param>
        /// <param name="oldKeyResolverOverride">
        /// Optional override for the resolver to resolve the blob's current Key Encryption
        /// Key. Will default to the client's <see cref="ClientSideEncryptionOptions.KeyResolver"/>.
        /// </param>
        /// <param name="keywrapAlgorithmOverride">
        /// Optional override for the key-wrap algorithm to re-wrap the Content Encryption Key.
        /// Will default to the client's <see cref="ClientSideEncryptionOptions.KeyWrapAlgorithm"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Cancellation token for the operation.
        /// </param>
        public static async Task RotateClientSideEncryptionKeyAsync(
            this BlobClient client,
            BlobRequestConditions requestConditions = default,
            IKeyEncryptionKey newKeyOverride = default,
            IKeyEncryptionKeyResolver oldKeyResolverOverride = default,
            string keywrapAlgorithmOverride = default,
            CancellationToken cancellationToken = default)
            => await RotateClientsideEncryptionKeyInternal(
                client,
                requestConditions,
                newKeyOverride,
                oldKeyResolverOverride,
                keywrapAlgorithmOverride,
                async: true,
                cancellationToken).ConfigureAwait(false);

        private static async Task RotateClientsideEncryptionKeyInternal(
            BlobClient client,
            BlobRequestConditions requestConditions,
            IKeyEncryptionKey newKeyOverride,
            IKeyEncryptionKeyResolver oldKeyResolverOverride,
            string keywrapAlgorithmOverride,
            bool async,
            CancellationToken cancellationToken)
        {
            // argument validation
            Argument.AssertNotNull(client, nameof(client));
            IKeyEncryptionKey newKey = newKeyOverride ?? client.ClientSideEncryption?.KeyEncryptionKey ?? throw new ArgumentException("");
            IKeyEncryptionKeyResolver oldKeyResolver = oldKeyResolverOverride ?? client.ClientSideEncryption?.KeyResolver ?? throw new ArgumentException("");
            string newKeywrapAlgorithm = keywrapAlgorithmOverride ?? client.ClientSideEncryption.KeyWrapAlgorithm ?? throw new ArgumentException("");

            using (client.ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobClient)))
            {
                client.ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                        $"{nameof(Uri)}: {client.Uri}\n" +
                        $"{nameof(requestConditions)}: {requestConditions}");

                DiagnosticScope scope = client.ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobClient)}.{nameof(RotateClientSideEncryptionKey)}");

                try
                {
                    // hold onto etag, metadata, encryptiondata
                    var getPropertiesResponse = await client.GetPropertiesInternal(requestConditions, async, cancellationToken).ConfigureAwait(false);
                    ETag etag = getPropertiesResponse.Value.ETag;
                    var metadata = getPropertiesResponse.Value.Metadata;
                    EncryptionData encryptionData = BlobClientSideDecryptor.GetAndValidateEncryptionDataOrDefault(metadata)
                        ?? throw new InvalidOperationException("Resource has no client-side encryption key to rotate.");

                    // rotate keywrapping
                    byte[] newWrappedKey = await WrapKeyInternal(
                        await UnwrapKeyInternal(
                            encryptionData,
                            oldKeyResolver,
                            async,
                            cancellationToken).ConfigureAwait(false),
                        newKeywrapAlgorithm,
                        newKey,
                        async,
                        cancellationToken).ConfigureAwait(false);

                    // set new wrapped key info and reinsert into metadata
                    encryptionData.WrappedContentKey = new KeyEnvelope
                    {
                        EncryptedKey = newWrappedKey,
                        Algorithm = newKeywrapAlgorithm,
                        KeyId = newKey.KeyId
                    };
                    metadata[Constants.ClientSideEncryption.EncryptionDataKey] = EncryptionDataSerializer.Serialize(encryptionData);

                    // update blob ONLY IF ETAG MATCHES (do not take chances encryption info is now out of sync)
                    var modifiedRequestConditions = BlobRequestConditions.CloneOrDefault(requestConditions) ?? new BlobRequestConditions();
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
                : key.UnwrapKey(
                    keyWrapAlgorithm,
                    contentEncryptionKey,
                    cancellationToken);
        }
    }
}
