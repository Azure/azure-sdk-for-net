// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Blobs.Specialized
{
    /// <summary>
    /// The <see cref="AppendBlobClient"/> allows you to manipulate Azure
    /// Storage append blobs.
    ///
    /// An append blob is comprised of blocks and is optimized for append
    /// operations.  When you modify an append blob, blocks are added to the
    /// end of the blob only, via the <see cref="AppendBlockAsync"/>
    /// operation.  Updating or deleting of existing blocks is not supported.
    /// Unlike a block blob, an append blob does not expose its block IDs.
    ///
    /// Each block in an append blob can be a different size, up to a maximum
    /// of 4 MB, and an append blob can include up to 50,000 blocks.  The
    /// maximum size of an append blob is therefore slightly more than 195 GB
    /// (4 MB X 50,000 blocks).
    /// </summary>
    public class AppendBlobClient : BlobBaseClient
    {
        /// <summary>
        /// Gets the maximum number of bytes that can be sent in a call
        /// to AppendBlock.
        /// </summary>
        public virtual int AppendBlobMaxAppendBlockBytes => Constants.Blob.Append.MaxAppendBlockBytes;

        /// <summary>
        /// Gets the maximum number of blocks allowed in an append blob.
        /// </summary>
        public virtual int AppendBlobMaxBlocks => Constants.Blob.Append.MaxBlocks;

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="AppendBlobClient"/>
        /// class for mocking.
        /// </summary>
        protected AppendBlobClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information, <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">Configure Azure Storage connection strings</see>
        /// </param>
        /// <param name="blobContainerName">
        /// The name of the container containing this append blob.
        /// </param>
        /// <param name="blobName">
        /// The name of this append blob.
        /// </param>
        public AppendBlobClient(string connectionString, string blobContainerName, string blobName)
            : base(connectionString, blobContainerName, blobName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information, <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">Configure Azure Storage connection strings</see>
        /// </param>
        /// <param name="blobContainerName">
        /// The name of the container containing this append blob.
        /// </param>
        /// <param name="blobName">
        /// The name of this append blob.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public AppendBlobClient(string connectionString, string blobContainerName, string blobName, BlobClientOptions options)
            : base(connectionString, blobContainerName, blobName, options)
        {
            AssertNoClientSideEncryption(options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the append blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}/{blob_name}".
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public AppendBlobClient(Uri blobUri, BlobClientOptions options = default)
            : base(blobUri, options)
        {
            AssertNoClientSideEncryption(options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the append blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}/{blob_name}".
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public AppendBlobClient(Uri blobUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            : base(blobUri, credential, options)
        {
            AssertNoClientSideEncryption(options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the append blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}/{blob_name}".
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public AppendBlobClient(Uri blobUri, TokenCredential credential, BlobClientOptions options = default)
            : base(blobUri, credential, options)
        {
            AssertNoClientSideEncryption(options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the append blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}/{blob_name}".
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        /// <param name="version">
        /// The version of the service to use when sending requests.
        /// </param>
        /// <param name="clientDiagnostics">Client diagnostics.</param>
        /// <param name="customerProvidedKey">Customer provided key.</param>
        /// <param name="encryptionScope">Encryption scope.</param>
        internal AppendBlobClient(
            Uri blobUri,
            HttpPipeline pipeline,
            BlobClientOptions.ServiceVersion version,
            ClientDiagnostics clientDiagnostics,
            CustomerProvidedKey? customerProvidedKey,
            string encryptionScope)
            : base(
                  blobUri,
                  pipeline,
                  version,
                  clientDiagnostics,
                  customerProvidedKey,
                  clientSideEncryption: default,
                  encryptionScope)
        {
        }

        private static void AssertNoClientSideEncryption(BlobClientOptions options)
        {
            if (options?._clientSideEncryptionOptions != default)
            {
                throw Errors.ClientSideEncryption.TypeNotSupported(typeof(AppendBlobClient));
            }
        }
        #endregion ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendBlobClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="snapshot"/> timestamp.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/creating-a-snapshot-of-a-blob" />.
        /// </summary>
        /// <param name="snapshot">The snapshot identifier.</param>
        /// <returns>A new <see cref="AppendBlobClient"/> instance.</returns>
        /// <remarks>
        /// Pass null or empty string to remove the snapshot returning a URL
        /// to the base blob.
        /// </remarks>
        public new AppendBlobClient WithSnapshot(string snapshot)
        {
            var builder = new BlobUriBuilder(Uri) { Snapshot = snapshot };

            return new AppendBlobClient(builder.ToUri(), Pipeline, Version, ClientDiagnostics, CustomerProvidedKey, EncryptionScope);
        }

        #region Create
        /// <summary>
        /// The <see cref="Create"/> operation creates a new 0-length
        /// append blob.  The content of any existing blob is overwritten with
        /// the newly initialized append blob.  To add content to the append
        /// blob, call the <see cref="AppendBlock"/> operation.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob" />.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new append blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this append blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the creation of this new append blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// newly created append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobContentInfo> Create(
            BlobHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            AppendBlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            CreateInternal(
                httpHeaders,
                metadata,
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="CreateAsync"/> operation creates a new 0-length
        /// append blob.  The content of any existing blob is overwritten with
        /// the newly initialized append blob.  To add content to the append
        /// blob, call the <see cref="AppendBlockAsync"/> operation.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob" />.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new append blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this append blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the creation of this new append blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// newly created append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobContentInfo>> CreateAsync(
            BlobHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            AppendBlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await CreateInternal(
                httpHeaders,
                metadata,
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CreateIfNotExists"/> operation creates a new 0-length
        /// append blob.  If the append blob already exists, the content of
        /// the existing append blob will remain unchanged.  To add content to the append
        /// blob, call the <see cref="AppendBlockAsync"/> operation.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob" />.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new append blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this append blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// If the append blob does not already exist, a <see cref="Response{BlobContentInfo}"/>
        /// describing the newly created append blob. Otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobContentInfo> CreateIfNotExists(
            BlobHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            CancellationToken cancellationToken = default) =>
            CreateIfNotExistsInternal(
                httpHeaders,
                metadata,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="CreateIfNotExistsAsync"/> operation creates a new 0-length
        /// append blob.  If the append blob already exists, the content of
        /// the existing append blob will remain unchanged.  To add content to the append
        /// blob, call the <see cref="AppendBlockAsync"/> operation.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob" />.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new append blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this append blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// If the append blob does not already exist, a <see cref="Response{BlobContentInfo}"/>
        /// describing the newly created append blob. Otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobContentInfo>> CreateIfNotExistsAsync(
            BlobHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            CancellationToken cancellationToken = default) =>
            await CreateIfNotExistsInternal(
                httpHeaders,
                metadata,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CreateIfNotExistsInternal"/> operation creates a new 0-length
        /// append blob.  If the append blob already exists, the content of
        /// the existing append blob will remain unchanged.  To add content to the append
        /// blob, call the <see cref="AppendBlockAsync"/> operation.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob" />.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new append blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this append blob.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// If the append blob does not already exist, a <see cref="Response{BlobContentInfo}"/>
        /// describing the newly created append blob. Otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobContentInfo>> CreateIfNotExistsInternal(
            BlobHttpHeaders httpHeaders,
            Metadata metadata,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(AppendBlobClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(AppendBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(httpHeaders)}: {httpHeaders}");
                var conditions = new AppendBlobRequestConditions { IfNoneMatch = new ETag(Constants.Wildcard) };
                try
                {
                    Response<BlobContentInfo> response = await CreateInternal(
                        httpHeaders,
                        metadata,
                        conditions,
                        async,
                        cancellationToken,
                        $"{nameof(AppendBlobClient)}.{nameof(CreateIfNotExists)}")
                        .ConfigureAwait(false);

                    return response;
                }
                catch (RequestFailedException storageRequestFailedException)
                when (storageRequestFailedException.ErrorCode == BlobErrorCode.BlobAlreadyExists)
                {
                    return default;
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(AppendBlobClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="CreateInternal"/> operation creates a new 0-length
        /// append blob.  The content of any existing blob is overwritten with
        /// the newly initialized append blob.  To add content to the append
        /// blob, call the <see cref="AppendBlockAsync"/> operation.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob" />.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new append blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this append blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the creation of this new append blob.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <param name="operationName">
        /// Optional. To indicate if the name of the operation.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// newly created append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobContentInfo>> CreateInternal(
            BlobHttpHeaders httpHeaders,
            Metadata metadata,
            AppendBlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken,
            string operationName = null)
        {
            using (Pipeline.BeginLoggingScope(nameof(AppendBlobClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(AppendBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(httpHeaders)}: {httpHeaders}\n" +
                    $"{nameof(conditions)}: {conditions}");
                try
                {
                    return await BlobRestClient.AppendBlob.CreateAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        contentLength: default,
                        version: Version.ToVersionString(),
                        blobContentType: httpHeaders?.ContentType,
                        blobContentEncoding: httpHeaders?.ContentEncoding,
                        blobContentLanguage: httpHeaders?.ContentLanguage,
                        blobContentHash: httpHeaders?.ContentHash,
                        blobCacheControl: httpHeaders?.CacheControl,
                        metadata: metadata,
                        leaseId: conditions?.LeaseId,
                        blobContentDisposition: httpHeaders?.ContentDisposition,
                        encryptionKey: CustomerProvidedKey?.EncryptionKey,
                        encryptionKeySha256: CustomerProvidedKey?.EncryptionKeyHash,
                        encryptionAlgorithm: CustomerProvidedKey?.EncryptionAlgorithm,
                        encryptionScope: EncryptionScope,
                        ifModifiedSince: conditions?.IfModifiedSince,
                        ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                        ifMatch: conditions?.IfMatch,
                        ifNoneMatch: conditions?.IfNoneMatch,
                        async: async,
                        operationName: operationName ?? $"{nameof(AppendBlobClient)}.{nameof(Create)}",
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(AppendBlobClient));
                }
            }
        }
        #endregion Create

        #region AppendBlock
        /// <summary>
        /// The <see cref="AppendBlock"/> operation commits a new block
        /// of data, represented by the <paramref name="content"/> <see cref="Stream"/>,
        /// to the end of the existing append blob.  The <see cref="AppendBlock"/>
        /// operation is only permitted if the blob was created as an append
        /// blob.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/append-block" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the block to
        /// append.
        /// </param>
        /// <param name="transactionalContentHash">
        /// Optional MD5 hash of the block content.  This hash is used to
        /// verify the integrity of the block during transport. When this hash
        /// is specified, the storage service compares the hash of the content
        /// that has arrived with this value.  Note that this MD5 hash is not
        /// stored with the blob.  If the two hashes do not match, the
        /// operation will fail with a <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on appending content to this append blob.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobAppendInfo}"/> describing the
        /// state of the updated append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobAppendInfo> AppendBlock(
            Stream content,
            byte[] transactionalContentHash = default,
            AppendBlobRequestConditions conditions = default,
            IProgress<long> progressHandler = default,
            CancellationToken cancellationToken = default) =>
            AppendBlockInternal(
                content,
                transactionalContentHash,
                conditions,
                progressHandler,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="AppendBlockAsync"/> operation commits a new block
        /// of data, represented by the <paramref name="content"/> <see cref="Stream"/>,
        /// to the end of the existing append blob.  The <see cref="AppendBlockAsync"/>
        /// operation is only permitted if the blob was created as an append
        /// blob.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/append-block" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the block to
        /// append.
        /// </param>
        /// <param name="transactionalContentHash">
        /// Optional MD5 hash of the block content.  This hash is used to
        /// verify the integrity of the block during transport. When this hash
        /// is specified, the storage service compares the hash of the content
        /// that has arrived with this value.  Note that this MD5 hash is not
        /// stored with the blob.  If the two hashes do not match, the
        /// operation will fail with a <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on appending content to this append blob.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobAppendInfo}"/> describing the
        /// state of the updated append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobAppendInfo>> AppendBlockAsync(
            Stream content,
            byte[] transactionalContentHash = default,
            AppendBlobRequestConditions conditions = default,
            IProgress<long> progressHandler = default,
            CancellationToken cancellationToken = default) =>
            await AppendBlockInternal(
                content,
                transactionalContentHash,
                conditions,
                progressHandler,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="AppendBlockInternal"/> operation commits a new block
        /// of data, represented by the <paramref name="content"/> <see cref="Stream"/>,
        /// to the end of the existing append blob.  The <see cref="AppendBlockInternal"/>
        /// operation is only permitted if the blob was created as an append
        /// blob.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/append-block" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the block to
        /// append.
        /// </param>
        /// <param name="transactionalContentHash">
        /// Optional MD5 hash of the block content.  This hash is used to
        /// verify the integrity of the block during transport. When this hash
        /// is specified, the storage service compares the hash of the content
        /// that has arrived with this value.  Note that this MD5 hash is not
        /// stored with the blob.  If the two hashes do not match, the
        /// operation will fail with a <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on appending content to this append blob.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobAppendInfo}"/> describing the
        /// state of the updated append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobAppendInfo>> AppendBlockInternal(
            Stream content,
            byte[] transactionalContentHash,
            AppendBlobRequestConditions conditions,
            IProgress<long> progressHandler,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(AppendBlobClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(AppendBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(conditions)}: {conditions}");
                try
                {
                    BlobErrors.VerifyHttpsCustomerProvidedKey(Uri, CustomerProvidedKey);

                    content = content?.WithNoDispose().WithProgress(progressHandler);
                    return await BlobRestClient.AppendBlob.AppendBlockAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        body: content,
                        contentLength: content?.Length ?? 0,
                        version: Version.ToVersionString(),
                        transactionalContentHash: transactionalContentHash,
                        leaseId: conditions?.LeaseId,
                        maxSize: conditions?.IfMaxSizeLessThanOrEqual,
                        encryptionKey: CustomerProvidedKey?.EncryptionKey,
                        encryptionKeySha256: CustomerProvidedKey?.EncryptionKeyHash,
                        encryptionAlgorithm: CustomerProvidedKey?.EncryptionAlgorithm,
                        encryptionScope: EncryptionScope,
                        appendPosition: conditions?.IfAppendPositionEqual,
                        ifModifiedSince: conditions?.IfModifiedSince,
                        ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                        ifMatch: conditions?.IfMatch,
                        ifNoneMatch: conditions?.IfNoneMatch,
                        async: async,
                        operationName: "AppendBlobClient.AppendBlock",
                        cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(AppendBlobClient));
                }
            }
        }
        #endregion AppendBlock

        #region AppendBlockFromUri
        /// <summary>
        /// The <see cref="AppendBlockFromUri"/> operation commits a new
        /// block of data, represented by the <paramref name="sourceUri"/>,
        /// to the end of the existing append blob.  The
        /// <see cref="AppendBlockFromUri"/> operation is only permitted
        /// if the blob was created as an append blob.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/append-block-from-url" />.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the <see cref="Uri"/> of the source blob.  The value may
        /// be a <see cref="Uri"/> of up to 2 KB in length that specifies a
        /// blob.  The source blob must either be public or must be
        /// authenticated via a shared access signature.  If the source blob
        /// is public, no authentication is required to perform the operation.
        /// </param>
        /// <param name="sourceRange">
        /// Optionally only upload the bytes of the blob in the
        /// <paramref name="sourceUri"/> in the specified range.  If this is
        /// not specified, the entire source blob contents are uploaded as a
        /// single append block.
        /// </param>
        /// <param name="sourceContentHash">
        /// Optional MD5 hash of the append block content from the
        /// <paramref name="sourceUri"/>.  This hash is used to verify the
        /// integrity of the block during transport of the data from the Uri.
        /// When this hash is specified, the storage service compares the hash
        /// of the content that has arrived from the <paramref name="sourceUri"/>
        /// with this value.  Note that this md5 hash is not stored with the
        /// blob.  If the two hashes do not match, the operation will fail
        /// with a <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the copying of data to this append blob.
        /// </param>
        /// <param name="sourceConditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobAppendInfo}"/> describing the
        /// state of the updated append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobAppendInfo> AppendBlockFromUri(
            Uri sourceUri,
            HttpRange sourceRange = default,
            byte[] sourceContentHash = default,
            AppendBlobRequestConditions conditions = default,
            AppendBlobRequestConditions sourceConditions = default,
            CancellationToken cancellationToken = default) =>
            AppendBlockFromUriInternal(
                sourceUri,
                sourceRange,
                sourceContentHash,
                conditions,
                sourceConditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="AppendBlockFromUriAsync"/> operation commits a new
        /// block of data, represented by the <paramref name="sourceUri"/>,
        /// to the end of the existing append blob.  The
        /// <see cref="AppendBlockFromUriAsync"/> operation is only permitted
        /// if the blob was created as an append blob.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/append-block-from-url" />.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the <see cref="Uri"/> of the source blob.  The value may
        /// be a <see cref="Uri"/> of up to 2 KB in length that specifies a
        /// blob.  The source blob must either be public or must be
        /// authenticated via a shared access signature.  If the source blob
        /// is public, no authentication is required to perform the operation.
        /// </param>
        /// <param name="sourceRange">
        /// Optionally only upload the bytes of the blob in the
        /// <paramref name="sourceUri"/> in the specified range.  If this is
        /// not specified, the entire source blob contents are uploaded as a
        /// single append block.
        /// </param>
        /// <param name="sourceContentHash">
        /// Optional MD5 hash of the append block content from the
        /// <paramref name="sourceUri"/>.  This hash is used to verify the
        /// integrity of the block during transport of the data from the Uri.
        /// When this hash is specified, the storage service compares the hash
        /// of the content that has arrived from the <paramref name="sourceUri"/>
        /// with this value.  Note that this md5 hash is not stored with the
        /// blob.  If the two hashes do not match, the operation will fail
        /// with a <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the copying of data to this append blob.
        /// </param>
        /// <param name="sourceConditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobAppendInfo}"/> describing the
        /// state of the updated append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobAppendInfo>> AppendBlockFromUriAsync(
            Uri sourceUri,
            HttpRange sourceRange = default,
            byte[] sourceContentHash = default,
            AppendBlobRequestConditions conditions = default,
            AppendBlobRequestConditions sourceConditions = default,
            CancellationToken cancellationToken = default) =>
            await AppendBlockFromUriInternal(
                sourceUri,
                sourceRange,
                sourceContentHash,
                conditions,
                sourceConditions,
                true,  // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="AppendBlockFromUriInternal"/> operation commits a new
        /// block of data, represented by the <paramref name="sourceUri"/>,
        /// to the end of the existing append blob.  The
        /// <see cref="AppendBlockFromUriInternal"/> operation is only permitted
        /// if the blob was created as an append blob.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/append-block-from-url" />.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the <see cref="Uri"/> of the source blob.  The value may
        /// be a <see cref="Uri"/> of up to 2 KB in length that specifies a
        /// blob.  The source blob must either be public or must be
        /// authenticated via a shared access signature.  If the source blob
        /// is public, no authentication is required to perform the operation.
        /// </param>
        /// <param name="sourceRange">
        /// Optionally only upload the bytes of the blob in the
        /// <paramref name="sourceUri"/> in the specified range.  If this is
        /// not specified, the entire source blob contents are uploaded as a
        /// single append block.
        /// </param>
        /// <param name="sourceContentHash">
        /// Optional MD5 hash of the append block content from the
        /// <paramref name="sourceUri"/>.  This hash is used to verify the
        /// integrity of the block during transport of the data from the Uri.
        /// When this hash is specified, the storage service compares the hash
        /// of the content that has arrived from the <paramref name="sourceUri"/>
        /// with this value.  Note that this md5 hash is not stored with the
        /// blob.  If the two hashes do not match, the operation will fail
        /// with a <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the copying of data to this append blob.
        /// </param>
        /// <param name="sourceConditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobAppendInfo}"/> describing the
        /// state of the updated append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobAppendInfo>> AppendBlockFromUriInternal(
            Uri sourceUri,
            HttpRange sourceRange,
            byte[] sourceContentHash,
            AppendBlobRequestConditions conditions,
            AppendBlobRequestConditions sourceConditions,
            bool async,
            CancellationToken cancellationToken = default)
        {
            using (Pipeline.BeginLoggingScope(nameof(AppendBlobClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(AppendBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(sourceUri)}: {sourceUri}\n" +
                    $"{nameof(conditions)}: {conditions}");
                try
                {
                    return await BlobRestClient.AppendBlob.AppendBlockFromUriAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        sourceUri: sourceUri,
                        sourceRange: sourceRange.ToString(),
                        sourceContentHash: sourceContentHash,
                        contentLength: default,
                        version: Version.ToVersionString(),
                        encryptionKey: CustomerProvidedKey?.EncryptionKey,
                        encryptionKeySha256: CustomerProvidedKey?.EncryptionKeyHash,
                        encryptionAlgorithm: CustomerProvidedKey?.EncryptionAlgorithm,
                        encryptionScope: EncryptionScope,
                        leaseId: conditions?.LeaseId,
                        maxSize: conditions?.IfMaxSizeLessThanOrEqual,
                        appendPosition: conditions?.IfAppendPositionEqual,
                        ifModifiedSince: conditions?.IfModifiedSince,
                        ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                        ifMatch: conditions?.IfMatch,
                        ifNoneMatch: conditions?.IfNoneMatch,
                        sourceIfModifiedSince: sourceConditions?.IfModifiedSince,
                        sourceIfUnmodifiedSince: sourceConditions?.IfUnmodifiedSince,
                        sourceIfMatch: sourceConditions?.IfMatch,
                        sourceIfNoneMatch: sourceConditions?.IfNoneMatch,
                        async: async,
                        operationName: "AppendBlobClient.AppendBlockFromUri",
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(AppendBlobClient));
                }
            }
        }
        #endregion AppendBlockFromUri
    }

    /// <summary>
    /// Add easy to discover methods to <see cref="BlobContainerClient"/> for
    /// creating <see cref="AppendBlobClient"/> instances.
    /// </summary>
    public static partial class SpecializedBlobExtensions
    {
        /// <summary>
        /// Create a new <see cref="AppendBlobClient"/> object by
        /// concatenating <paramref name="blobName"/> to
        /// the end of the <paramref name="client"/>'s
        /// <see cref="BlobContainerClient.Uri"/>. The new
        /// <see cref="AppendBlobClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="BlobContainerClient"/>.
        /// </summary>
        /// <param name="client">The <see cref="BlobContainerClient"/>.</param>
        /// <param name="blobName">The name of the append blob.</param>
        /// <returns>A new <see cref="AppendBlobClient"/> instance.</returns>
        public static AppendBlobClient GetAppendBlobClient(
            this BlobContainerClient client,
            string blobName)
        {
            if (client.ClientSideEncryption != default)
            {
                throw Errors.ClientSideEncryption.TypeNotSupported(typeof(AppendBlobClient));
            }
            return new AppendBlobClient(
                client.Uri.AppendToPath(blobName),
                client.Pipeline,
                client.Version,
                client.ClientDiagnostics,
                client.CustomerProvidedKey,
                client.EncryptionScope);
        }
    }
}
