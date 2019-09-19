﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Http;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Common;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Specialized
{
    /// <summary>
    /// The <see cref="BlockBlobClient"/> allows you to manipulate Azure
    /// Storage block blobs.
    ///
    /// Block blobs let you upload large blobs efficiently.  Block blobs are
    /// comprised of blocks, each of which is identified by a block ID. You
    /// create or modify a block blob by writing a set of blocks and
    /// committing them by their block IDs. Each block can be a different
    /// size, up to a maximum of 100 MB (4 MB for requests using REST versions
    /// before 2016-05-31), and a block blob can include up to 50,000 blocks.
    /// The maximum size of a block blob is therefore slightly more than 4.75
    /// TB (100 MB X 50,000 blocks).  If you are writing a block blob that is
    /// no more than 256 MB in size, you can upload it in its entirety with a
    /// single write operation; see <see cref="BlockBlobClient.UploadAsync"/>.
    ///
    /// When you upload a block to a blob in your storage account, it is
    /// associated with the specified block blob, but it does not become part
    /// of the blob until you commit a list of blocks that includes the new
    /// block's ID. New blocks remain in an uncommitted state until they are
    /// specifically committed or discarded. Writing a block does not update
    /// the last modified time of an existing blob.
    ///
    /// Block blobs include features that help you manage large files over
    /// networks.  With a block blob, you can upload multiple blocks in
    /// parallel to decrease upload time.  Each block can include an MD5 hash
    /// to verify the transfer, so you can track upload progress and re-send
    /// blocks as needed.You can upload blocks in any order, and determine
    /// their sequence in the final block list commitment step. You can also
    /// upload a new block to replace an existing uncommitted block of the
    /// same block ID.  You have one week to commit blocks to a blob before
    /// they are discarded.  All uncommitted blocks are also discarded when a
    /// block list commitment operation occurs but does not include them.
    ///
    /// You can modify an existing block blob by inserting, replacing, or
    /// deleting existing blocks. After uploading the block or blocks that
    /// have changed, you can commit a new version of the blob by committing
    /// the new blocks with the existing blocks you want to keep using a
    /// single commit operation. To insert the same range of bytes in two
    /// different locations of the committed blob, you can commit the same
    /// block in two places within the same commit operation.For any commit
    /// operation, if any block is not found, the entire commitment operation
    /// fails with an error, and the blob is not modified. Any block commitment
    /// overwrites the blob’s existing properties and metadata, and discards
    /// all uncommitted blocks.
    ///
    /// Block IDs are strings of equal length within a blob. Block client code
    /// usually uses base-64 encoding to normalize strings into equal lengths.
    /// When using base-64 encoding, the pre-encoded string must be 64 bytes
    /// or less.  Block ID values can be duplicated in different blobs.  A
    /// blob can have up to 100,000 uncommitted blocks, but their total size
    /// cannot exceed 200,000 MB.
    ///
    /// If you write a block for a blob that does not exist, a new block blob
    /// is created, with a length of zero bytes.  This blob will appear in
    /// blob lists that include uncommitted blobs.  If you don’t commit any
    /// block to this blob, it and its uncommitted blocks will be discarded
    /// one week after the last successful block upload. All uncommitted
    /// blocks are also discarded when a new blob of the same name is created
    /// using a single step(rather than the two-step block upload-then-commit
    /// process).
    /// </summary>
    public class BlockBlobClient : BlobBaseClient
    {
        /// <summary>
        /// <see cref="BlockBlobMaxUploadBlobBytes"/> indicates the maximum number of bytes
        /// that can be sent in a call to <see cref="UploadAsync"/>.
        /// </summary>
        public const int BlockBlobMaxUploadBlobBytes = Constants.Blob.Block.MaxUploadBytes;

        /// <summary>
        /// <see cref="BlockBlobMaxStageBlockBytes"/> indicates the maximum
        /// number of bytes that can be sent in a call to <see cref="StageBlockAsync"/>.
        /// </summary>
        public const int BlockBlobMaxStageBlockBytes = Constants.Blob.Block.MaxStageBytes;

        /// <summary>
        /// <see cref="BlockBlobMaxBlocks"/> indicates the maximum number of
        /// blocks allowed in a block blob.
        /// </summary>
        public const int BlockBlobMaxBlocks = Constants.Blob.Block.MaxBlocks;

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="BlockBlobClient"/>
        /// class for mocking.
        /// </summary>
        protected BlockBlobClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockBlobClient"/>
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
        /// The name of the container containing this block blob.
        /// </param>
        /// <param name="blobName">
        /// The name of this block blob.
        /// </param>
        public BlockBlobClient(string connectionString, string containerName, string blobName)
            : base(connectionString, containerName, blobName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockBlobClient"/>
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
        /// The name of the container containing this block blob.
        /// </param>
        /// <param name="blobName">
        /// The name of this block blob.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlockBlobClient(string connectionString, string containerName, string blobName, BlobClientOptions options)
            : base(connectionString, containerName, blobName, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the block blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlockBlobClient(Uri blobUri, BlobClientOptions options = default)
            : base(blobUri, options)
        {
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
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlockBlobClient(Uri blobUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            : base(blobUri, credential, options)
        {
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
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlockBlobClient(Uri blobUri, TokenCredential credential, BlobClientOptions options = default)
            : base(blobUri, credential, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the block blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        internal BlockBlobClient(Uri blobUri, HttpPipeline pipeline)
            : base(blobUri, pipeline)
        {
        }
        #endregion ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockBlobClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="snapshot"/> timestamp.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/creating-a-snapshot-of-a-blob" />.
        /// </summary>
        /// <param name="snapshot">The snapshot identifier.</param>
        /// <returns>A new <see cref="BlockBlobClient"/> instance.</returns>
        /// <remarks>
        /// Pass null or empty string to remove the snapshot returning a URL
        /// to the base blob.
        /// </remarks>
        public new BlockBlobClient WithSnapshot(string snapshot) => (BlockBlobClient)WithSnapshotImpl(snapshot);

        /// <summary>
        /// Creates a new instance of the <see cref="BlockBlobClient"/> class
        /// with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="snapshot"/> timestamp.
        /// </summary>
        /// <param name="snapshot">The snapshot identifier.</param>
        /// <returns>A new <see cref="BlockBlobClient"/> instance.</returns>
        protected sealed override BlobBaseClient WithSnapshotImpl(string snapshot)
        {
            var builder = new BlobUriBuilder(Uri) { Snapshot = snapshot };
            return new BlockBlobClient(builder.Uri, Pipeline);
        }

        ///// <summary>
        ///// Creates a new BlockBlobURL object identical to the source but with the specified version ID.
        ///// </summary>
        ///// <remarks>
        ///// Pass null or empty string to remove the snapshot returning a URL to the base blob.
        ///// </remarks>
        ///// <param name="versionId">A string of the version identifier.</param>
        ///// <returns></returns>
        //public new BlockBlobClient WithVersionId(string versionId) => (BlockBlobUri)this.WithVersionIdImpl(versionId);

        //protected sealed override Blobclient WithVersionIdImpl(string versionId)
        //{
        //    var builder = new BlobUriBuilder(this.Uri) { VersionId = versionId };
        //    return new BlockBlobClient(builder.ToUri(), this.Pipeline);
        //}

        #region Upload
        /// <summary>
        /// The <see cref="Upload"/> operation creates a new block  blob,
        /// or updates the content of an existing block blob.  Updating an
        /// existing block blob overwrites any existing metadata on the blob.
        ///
        /// Partial updates are not supported with <see cref="Upload"/>;
        /// the content of the existing blob is overwritten with the content
        /// of the new blob.  To perform a partial update of the content of a
        /// block blob, use the <see cref="StageBlock"/> and
        /// <see cref="CommitBlockList" /> operations.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="blobHttpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// block blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this block blob.
        /// </param>
        /// <param name="blobAccessConditions">
        /// Optional <see cref="BlockBlobClient"/> to add
        /// conditions on the creation of this new block blob.
        /// </param>
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{StorageProgress}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobContentInfo> Upload(
            Stream content,
            BlobHttpHeaders? blobHttpHeaders = default,
            Metadata metadata = default,
            BlobAccessConditions? blobAccessConditions = default,
            CustomerProvidedKey? customerProvidedKey = default,
            AccessTier? accessTier = default,
            IProgress<StorageProgress> progressHandler = default,
            CancellationToken cancellationToken = default) =>
            UploadInternal(
                content,
                blobHttpHeaders,
                metadata,
                blobAccessConditions,
                customerProvidedKey,
                accessTier: accessTier,
                progressHandler,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="UploadAsync"/> operation creates a new block  blob,
        /// or updates the content of an existing block blob.  Updating an
        /// existing block blob overwrites any existing metadata on the blob.
        ///
        /// Partial updates are not supported with <see cref="UploadAsync"/>;
        /// the content of the existing blob is overwritten with the content
        /// of the new blob.  To perform a partial update of the content of a
        /// block blob, use the <see cref="StageBlockAsync"/> and
        /// <see cref="CommitBlockListAsync" /> operations.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="blobHttpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// block blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this block blob.
        /// </param>
        /// <param name="blobAccessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add
        /// conditions on the creation of this new block blob.
        /// </param>
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{StorageProgress}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobContentInfo>> UploadAsync(
            Stream content,
            BlobHttpHeaders? blobHttpHeaders = default,
            Metadata metadata = default,
            BlobAccessConditions? blobAccessConditions = default,
            CustomerProvidedKey? customerProvidedKey = default,
            AccessTier? accessTier = default,
            IProgress<StorageProgress> progressHandler = default,
            CancellationToken cancellationToken = default) =>
            await UploadInternal(
                content,
                blobHttpHeaders,
                metadata,
                blobAccessConditions,
                customerProvidedKey,
                accessTier: accessTier,
                progressHandler,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UploadInternal"/> operation creates a new block blob,
        /// or updates the content of an existing block blob.  Updating an
        /// existing block blob overwrites any existing metadata on the blob.
        ///
        /// Partial updates are not supported with <see cref="UploadAsync"/>;
        /// the content of the existing blob is overwritten with the content
        /// of the new blob.  To perform a partial update of the content of a
        /// block blob, use the <see cref="StageBlockAsync"/> and
        /// <see cref="CommitBlockListAsync" /> operations.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="blobHttpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// block blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this block blob.
        /// </param>
        /// <param name="blobAccessConditions">
        /// Optional <see cref="BlockBlobClient"/> to add
        /// conditions on the creation of this new block blob.
        /// </param>
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{StorageProgress}"/> to provide
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
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<Response<BlobContentInfo>> UploadInternal(
            Stream content,
            BlobHttpHeaders? blobHttpHeaders,
            Metadata metadata,
            BlobAccessConditions? blobAccessConditions,
            CustomerProvidedKey? customerProvidedKey,
            AccessTier? accessTier,
            IProgress<StorageProgress> progressHandler,
            bool async,
            CancellationToken cancellationToken)
        {
            content = content.WithNoDispose().WithProgress(progressHandler);
            var uploadAttempt = 0;
            using (Pipeline.BeginLoggingScope(nameof(BlockBlobClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlockBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(blobHttpHeaders)}: {blobHttpHeaders}\n" +
                    $"{nameof(blobAccessConditions)}: {blobAccessConditions}");
                try
                {
                    BlobErrors.VerifyHttpsCustomerProvidedKey(Uri, customerProvidedKey);

                    return await ReliableOperation.DoAsync(
                        async () =>
                        {
                            Pipeline.LogTrace($"Upload attempt {++uploadAttempt}");
                            return await BlobRestClient.BlockBlob.UploadAsync(
                                Pipeline,
                                Uri,
                                body: content,
                                contentLength: content.Length,
                                blobContentType: blobHttpHeaders?.ContentType,
                                blobContentEncoding: blobHttpHeaders?.ContentEncoding,
                                blobContentLanguage: blobHttpHeaders?.ContentLanguage,
                                blobContentHash: blobHttpHeaders?.ContentHash,
                                blobCacheControl: blobHttpHeaders?.CacheControl,
                                metadata: metadata,
                                leaseId: blobAccessConditions?.LeaseAccessConditions?.LeaseId,
                                blobContentDisposition: blobHttpHeaders?.ContentDisposition,
                                encryptionKey: customerProvidedKey?.EncryptionKey,
                                encryptionKeySha256: customerProvidedKey?.EncryptionKeyHash,
                                encryptionAlgorithm: customerProvidedKey?.EncryptionAlgorithm,
                                tier: accessTier,
                                ifModifiedSince: blobAccessConditions?.HttpAccessConditions?.IfModifiedSince,
                                ifUnmodifiedSince: blobAccessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                                ifMatch: blobAccessConditions?.HttpAccessConditions?.IfMatch,
                                ifNoneMatch: blobAccessConditions?.HttpAccessConditions?.IfNoneMatch,
                                async: async,
                                operationName: Constants.Blob.Block.UploadOperationName,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        },
                        new ReliabilityConfiguration(reset: () => content.Seek(0, SeekOrigin.Begin)))
                        .ConfigureAwait(false);

                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(BlockBlobClient));
                }
            }
        }
        #endregion Upload

        #region StageBlock
        /// <summary>
        /// The <see cref="StageBlock"/> operation creates a new block as
        /// part of a block blob's "staging area" to be eventually committed
        /// via the <see cref="CommitBlockList"/> operation.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-block" />.
        /// </summary>
        /// <param name="base64BlockId">
        /// A valid Base64 string value that identifies the block. Prior to
        /// encoding, the string must be less than or equal to 64 bytes in
        /// size.
        ///
        /// For a given blob, the length of the value specified for the
        /// blockid parameter must be the same size for each block. Note that
        /// the Base64 string must be URL-encoded.
        /// </param>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="transactionalContentHash">
        /// An optional MD5 hash of the block <paramref name="content"/>.
        /// This hash is used to verify the integrity of the block during
        /// transport.  When this value is specified, the storage service
        /// compares the hash of the content that has arrived with this value.
        /// Note that this MD5 hash is not stored with the blob.  If the two
        /// hashes do not match, the operation will throw a
        /// <see cref="StorageRequestFailedException"/>.
        /// </param>
        /// <param name="leaseAccessConditions">
        /// Optional <see cref="LeaseAccessConditions"/> to add
        /// conditions on the upload of this block.
        /// </param>
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{StorageProgress}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlockInfo}"/> describing the
        /// state of the updated block.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlockInfo> StageBlock(
            string base64BlockId,
            Stream content,
            byte[] transactionalContentHash = default,
            LeaseAccessConditions? leaseAccessConditions = default,
            CustomerProvidedKey? customerProvidedKey = default,
            IProgress<StorageProgress> progressHandler = default,
            CancellationToken cancellationToken = default) =>
            StageBlockInternal(
                base64BlockId,
                content,
                transactionalContentHash,
                leaseAccessConditions,
                customerProvidedKey,
                progressHandler,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="StageBlockAsync"/> operation creates a new block as
        /// part of a block blob's "staging area" to be eventually committed
        /// via the <see cref="CommitBlockListAsync"/> operation.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-block" />.
        /// </summary>
        /// <param name="base64BlockId">
        /// A valid Base64 string value that identifies the block. Prior to
        /// encoding, the string must be less than or equal to 64 bytes in
        /// size.
        ///
        /// For a given blob, the length of the value specified for the
        /// blockid parameter must be the same size for each block. Note that
        /// the Base64 string must be URL-encoded.
        /// </param>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="transactionalContentHash">
        /// An optional MD5 hash of the block <paramref name="content"/>.
        /// This hash is used to verify the integrity of the block during
        /// transport.  When this value is specified, the storage service
        /// compares the hash of the content that has arrived with this value.
        /// Note that this MD5 hash is not stored with the blob.  If the two
        /// hashes do not match, the operation will throw a
        /// <see cref="StorageRequestFailedException"/>.
        /// </param>
        /// <param name="leaseAccessConditions">
        /// Optional <see cref="LeaseAccessConditions"/> to add
        /// conditions on the upload of this block.
        /// </param>
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{StorageProgress}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlockInfo}"/> describing the
        /// state of the updated block.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlockInfo>> StageBlockAsync(
            string base64BlockId,
            Stream content,
            byte[] transactionalContentHash = default,
            LeaseAccessConditions? leaseAccessConditions = default,
            CustomerProvidedKey? customerProvidedKey = default,
            IProgress<StorageProgress> progressHandler = default,
            CancellationToken cancellationToken = default) =>
            await StageBlockInternal(
                base64BlockId,
                content,
                transactionalContentHash,
                leaseAccessConditions,
                customerProvidedKey,
                progressHandler,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="StageBlockInternal"/> operation creates a new block
        /// as part of a block blob's "staging area" to be eventually committed
        /// via the <see cref="CommitBlockListAsync"/> operation.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-block" />.
        /// </summary>
        /// <param name="base64BlockId">
        /// A valid Base64 string value that identifies the block. Prior to
        /// encoding, the string must be less than or equal to 64 bytes in
        /// size.
        ///
        /// For a given blob, the length of the value specified for the
        /// blockid parameter must be the same size for each block. Note that
        /// the Base64 string must be URL-encoded.
        /// </param>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="transactionalContentHash">
        /// An optional MD5 hash of the block <paramref name="content"/>.
        /// This hash is used to verify the integrity of the block during
        /// transport.  When this value is specified, the storage service
        /// compares the hash of the content that has arrived with this value.
        /// Note that this MD5 hash is not stored with the blob.  If the two
        /// hashes do not match, the operation will throw a
        /// <see cref="StorageRequestFailedException"/>.
        /// </param>
        /// <param name="leaseAccessConditions">
        /// Optional <see cref="LeaseAccessConditions"/> to add
        /// conditions on the upload of this block.
        /// </param>
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{StorageProgress}"/> to provide
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
        /// A <see cref="Response{BlockInfo}"/> describing the
        /// state of the updated block.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<Response<BlockInfo>> StageBlockInternal(
            string base64BlockId,
            Stream content,
            byte[] transactionalContentHash,
            LeaseAccessConditions? leaseAccessConditions,
            CustomerProvidedKey? customerProvidedKey,
            IProgress<StorageProgress> progressHandler,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlockBlobClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlockBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(base64BlockId)}: {base64BlockId}\n" +
                    $"{nameof(leaseAccessConditions)}: {leaseAccessConditions}");
                try
                {
                    BlobErrors.VerifyHttpsCustomerProvidedKey(Uri, customerProvidedKey);

                    content = content.WithNoDispose().WithProgress(progressHandler);
                    var stageBlockAttempt = 0;
                    return await ReliableOperation.DoSyncOrAsync(
                        async,
                        reset: () => content.Seek(0, SeekOrigin.Begin),
                        predicate: e => true,
                        maximumRetries: Constants.MaxReliabilityRetries,
                        operation:
                            () =>
                            {
                                Pipeline.LogTrace($"Stage Block {++stageBlockAttempt}");
                                return BlobRestClient.BlockBlob.StageBlockAsync(
                                    Pipeline,
                                    Uri,
                                    blockId: base64BlockId,
                                    body: content,
                                    contentLength: content.Length,
                                    transactionalContentHash: transactionalContentHash,
                                    leaseId: leaseAccessConditions?.LeaseId,
                                    encryptionKey: customerProvidedKey?.EncryptionKey,
                                    encryptionKeySha256: customerProvidedKey?.EncryptionKeyHash,
                                    encryptionAlgorithm: customerProvidedKey?.EncryptionAlgorithm,
                                    async: async,
                                    operationName: Constants.Blob.Block.StageBlockOperationName,
                                    cancellationToken: cancellationToken);
                            },
                        cleanup: () => { })
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(BlockBlobClient));
                }
            }
        }
        #endregion StageBlock

        #region StageBlockFromUri
        /// <summary>
        /// The <see cref="StageBlockFromUri"/> operation creates a new
        /// block to be committed as part of a blob where the contents are
        /// read from the <paramref name="sourceUri" />.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-block-from-url"/>.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the <see cref="Uri"/> of the source blob.  The value may
        /// be a URL of up to 2 KB in length that specifies a blob.  The
        /// source blob must either be public or must be authenticated via a
        /// shared access signature. If the source blob is public, no
        /// authentication is required to perform the operation.
        /// </param>
        /// <param name="base64BlockId">
        /// A valid Base64 string value that identifies the block. Prior to
        /// encoding, the string must be less than or equal to 64 bytes in
        /// size.  For a given blob, the length of the value specified for
        /// the <paramref name="base64BlockId"/> parameter must be the same
        /// size for each block.  Note that the Base64 string must be
        /// URL-encoded.
        /// </param>
        /// <param name="sourceRange">
        /// Optionally uploads only the bytes of the blob in the
        /// <paramref name="sourceUri"/> in the specified range.  If this is
        /// not specified, the entire source blob contents are uploaded as a
        /// single block.
        /// </param>
        /// <param name="sourceContentHash">
        /// Optional MD5 hash of the block content from the
        /// <paramref name="sourceUri"/>.  This hash is used to verify the
        /// integrity of the block during transport of the data from the Uri.
        /// When this hash is specified, the storage service compares the hash
        /// of the content that has arrived from the <paramref name="sourceUri"/>
        /// with this value.  Note that this md5 hash is not stored with the
        /// blob.  If the two hashes do not match, the operation will fail
        /// with a <see cref="StorageRequestFailedException"/>.
        /// </param>
        /// <param name="sourceAccessConditions">
        /// Optional <see cref="HttpAccessConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="leaseAccessConditions">
        /// Optional <see cref="LeaseAccessConditions"/> to add
        /// conditions on the staging of this block.
        /// </param>
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlockInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlockInfo> StageBlockFromUri(
            Uri sourceUri,
            string base64BlockId,
            HttpRange sourceRange = default,
            byte[] sourceContentHash = default,
            HttpAccessConditions? sourceAccessConditions = default,
            LeaseAccessConditions? leaseAccessConditions = default,
            CustomerProvidedKey? customerProvidedKey = default,
            CancellationToken cancellationToken = default) =>
            StageBlockFromUriInternal(
                sourceUri,
                base64BlockId,
                sourceRange,
                sourceContentHash,
                sourceAccessConditions,
                leaseAccessConditions,
                customerProvidedKey,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="StageBlockFromUriAsync"/> operation creates a new
        /// block to be committed as part of a blob where the contents are
        /// read from the <paramref name="sourceUri" />.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-block-from-url"/>.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the <see cref="Uri"/> of the source blob.  The value may
        /// be a URL of up to 2 KB in length that specifies a blob.  The
        /// source blob must either be public or must be authenticated via a
        /// shared access signature. If the source blob is public, no
        /// authentication is required to perform the operation.
        /// </param>
        /// <param name="base64BlockId">
        /// A valid Base64 string value that identifies the block. Prior to
        /// encoding, the string must be less than or equal to 64 bytes in
        /// size.  For a given blob, the length of the value specified for
        /// the <paramref name="base64BlockId"/> parameter must be the same
        /// size for each block.  Note that the Base64 string must be
        /// URL-encoded.
        /// </param>
        /// <param name="sourceRange">
        /// Optionally uploads only the bytes of the blob in the
        /// <paramref name="sourceUri"/> in the specified range.  If this is
        /// not specified, the entire source blob contents are uploaded as a
        /// single block.
        /// </param>
        /// <param name="sourceContentHash">
        /// Optional MD5 hash of the block content from the
        /// <paramref name="sourceUri"/>.  This hash is used to verify the
        /// integrity of the block during transport of the data from the Uri.
        /// When this hash is specified, the storage service compares the hash
        /// of the content that has arrived from the <paramref name="sourceUri"/>
        /// with this value.  Note that this md5 hash is not stored with the
        /// blob.  If the two hashes do not match, the operation will fail
        /// with a <see cref="StorageRequestFailedException"/>.
        /// </param>
        /// <param name="sourceAccessConditions">
        /// Optional <see cref="HttpAccessConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="leaseAccessConditions">
        /// Optional <see cref="LeaseAccessConditions"/> to add
        /// conditions on the staging of this block.
        /// </param>
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlockInfo}"/> describing the
        /// state of the updated block.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlockInfo>> StageBlockFromUriAsync(
            Uri sourceUri,
            string base64BlockId,
            HttpRange sourceRange = default,
            byte[] sourceContentHash = default,
            HttpAccessConditions? sourceAccessConditions = default,
            LeaseAccessConditions? leaseAccessConditions = default,
            CustomerProvidedKey? customerProvidedKey = default,
            CancellationToken cancellationToken = default) =>
            await StageBlockFromUriInternal(
                sourceUri,
                base64BlockId,
                sourceRange,
                sourceContentHash,
                sourceAccessConditions,
                leaseAccessConditions,
                customerProvidedKey,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="StageBlockFromUriInternal"/> operation creates a new
        /// block to be committed as part of a blob where the contents are
        /// read from the <paramref name="sourceUri" />.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-block-from-url"/>.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the <see cref="Uri"/> of the source blob.  The value may
        /// be a URL of up to 2 KB in length that specifies a blob.  The
        /// source blob must either be public or must be authenticated via a
        /// shared access signature. If the source blob is public, no
        /// authentication is required to perform the operation.
        /// </param>
        /// <param name="base64BlockId">
        /// A valid Base64 string value that identifies the block. Prior to
        /// encoding, the string must be less than or equal to 64 bytes in
        /// size.  For a given blob, the length of the value specified for
        /// the <paramref name="base64BlockId"/> parameter must be the same
        /// size for each block.  Note that the Base64 string must be
        /// URL-encoded.
        /// </param>
        /// <param name="sourceRange">
        /// Optionally uploads only the bytes of the blob in the
        /// <paramref name="sourceUri"/> in the specified range.  If this is
        /// not specified, the entire source blob contents are uploaded as a
        /// single block.
        /// </param>
        /// <param name="sourceContentHash">
        /// Optional MD5 hash of the block content from the
        /// <paramref name="sourceUri"/>.  This hash is used to verify the
        /// integrity of the block during transport of the data from the Uri.
        /// When this hash is specified, the storage service compares the hash
        /// of the content that has arrived from the <paramref name="sourceUri"/>
        /// with this value.  Note that this md5 hash is not stored with the
        /// blob.  If the two hashes do not match, the operation will fail
        /// with a <see cref="StorageRequestFailedException"/>.
        /// </param>
        /// <param name="sourceAccessConditions">
        /// Optional <see cref="HttpAccessConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="leaseAccessConditions">
        /// Optional <see cref="LeaseAccessConditions"/> to add
        /// conditions on the staging of this block.
        /// </param>
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlockInfo}"/> describing the
        /// state of the updated block.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlockInfo>> StageBlockFromUriInternal(
            Uri sourceUri,
            string base64BlockId,
            HttpRange sourceRange,
            byte[] sourceContentHash,
            HttpAccessConditions? sourceAccessConditions,
            LeaseAccessConditions? leaseAccessConditions,
            CustomerProvidedKey? customerProvidedKey,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlockBlobClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlockBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(base64BlockId)}: {base64BlockId}\n" +
                    $"{nameof(sourceUri)}: {sourceUri}\n" +
                    $"{nameof(leaseAccessConditions)}: {leaseAccessConditions}");
                try
                {
                    BlobErrors.VerifyHttpsCustomerProvidedKey(Uri, customerProvidedKey);

                    return await BlobRestClient.BlockBlob.StageBlockFromUriAsync(
                        Pipeline,
                        Uri,
                        contentLength: default,
                        blockId: base64BlockId,
                        sourceUri: sourceUri,
                        sourceRange: sourceRange.ToString(),
                        sourceContentHash: sourceContentHash,
                        encryptionKey: customerProvidedKey?.EncryptionKey,
                        encryptionKeySha256: customerProvidedKey?.EncryptionKeyHash,
                        encryptionAlgorithm: customerProvidedKey?.EncryptionAlgorithm,
                        leaseId: leaseAccessConditions?.LeaseId,
                        sourceIfModifiedSince: sourceAccessConditions?.IfModifiedSince,
                        sourceIfUnmodifiedSince: sourceAccessConditions?.IfUnmodifiedSince,
                        sourceIfMatch: sourceAccessConditions?.IfMatch,
                        sourceIfNoneMatch: sourceAccessConditions?.IfNoneMatch,
                        async: async,
                        operationName: Constants.Blob.Block.StageBlockFromUriOperationName,
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
                    Pipeline.LogMethodExit(nameof(BlockBlobClient));
                }
            }
        }
        #endregion StageBlockFromUri

        #region CommitBlockList
        /// <summary>
        /// The <see cref="CommitBlockList"/> operation writes a blob by
        /// specifying the list of block IDs that make up the blob.  In order
        /// to be written as part of a blob, a block must have been
        /// successfully written to the server in a prior <see cref="StageBlock"/>
        /// operation.  You can call <see cref="CommitBlockList"/> to
        /// update a blob by uploading only those blocks that have changed,
        /// then committing the new and existing blocks together.  You can do
        /// this by specifying whether to commit a block from the committed
        /// block list or from the uncommitted block list, or to commit the
        /// most recently uploaded version of the block, whichever list it
        /// may belong to.  Any blocks not specified in the block list and
        /// permanently deleted.
        ///
        /// For more information, see  <see href="https://docs.microsoft.com/rest/api/storageservices/put-block-list"/>
        /// </summary>
        /// <param name="base64BlockIds">
        /// Specify the Uncommitted Base64 encoded block IDs to indicate that
        /// the blob service should search only the uncommitted block list for
        /// the named blocks.  If the block is not found in the uncommitted
        /// block list, it will not be written as part of the blob, and a
        /// <see cref="StorageRequestFailedException"/> will be thrown.
        /// </param>
        /// <param name="blobHttpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// block blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this block blob.
        /// </param>
        /// <param name="blobAccessConditions">
        /// Optional <see cref="BlockBlobClient"/> to add
        /// conditions on committing this block list.
        /// </param>
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobAppendInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobContentInfo> CommitBlockList(
            IEnumerable<string> base64BlockIds,
            BlobHttpHeaders? blobHttpHeaders = default,
            Metadata metadata = default,
            BlobAccessConditions? blobAccessConditions = default,
            CustomerProvidedKey? customerProvidedKey = default,
            AccessTier? accessTier = default,
            CancellationToken cancellationToken = default) =>
            CommitBlockListInternal(
                base64BlockIds,
                blobHttpHeaders,
                metadata,
                blobAccessConditions,
                customerProvidedKey,
                accessTier,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="CommitBlockListAsync"/> operation writes a blob by
        /// specifying the list of block IDs that make up the blob.  In order
        /// to be written as part of a blob, a block must have been
        /// successfully written to the server in a prior <see cref="StageBlockAsync"/>
        /// operation.  You can call <see cref="CommitBlockListAsync"/> to
        /// update a blob by uploading only those blocks that have changed,
        /// then committing the new and existing blocks together.  You can do
        /// this by specifying whether to commit a block from the committed
        /// block list or from the uncommitted block list, or to commit the
        /// most recently uploaded version of the block, whichever list it
        /// may belong to.  Any blocks not specified in the block list and
        /// permanently deleted.
        ///
        /// For more information, see  <see href="https://docs.microsoft.com/rest/api/storageservices/put-block-list"/>
        /// </summary>
        /// <param name="base64BlockIds">
        /// Specify the Uncommitted Base64 encoded block IDs to indicate that
        /// the blob service should search only the uncommitted block list for
        /// the named blocks.  If the block is not found in the uncommitted
        /// block list, it will not be written as part of the blob, and a
        /// <see cref="StorageRequestFailedException"/> will be thrown.
        /// </param>
        /// <param name="blobHttpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// block blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this block blob.
        /// </param>
        /// <param name="blobAccessConditions">
        /// Optional <see cref="BlockBlobClient"/> to add
        /// conditions on committing this block list.
        /// </param>
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobAppendInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobContentInfo>> CommitBlockListAsync(
            IEnumerable<string> base64BlockIds,
            BlobHttpHeaders? blobHttpHeaders = default,
            Metadata metadata = default,
            BlobAccessConditions? blobAccessConditions = default,
            CustomerProvidedKey? customerProvidedKey = default,
            AccessTier? accessTier = default,
            CancellationToken cancellationToken = default) =>
            await CommitBlockListInternal(
                base64BlockIds,
                blobHttpHeaders,
                metadata,
                blobAccessConditions,
                customerProvidedKey,
                accessTier,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CommitBlockListInternal"/> operation writes a blob by
        /// specifying the list of block IDs that make up the blob.  In order
        /// to be written as part of a blob, a block must have been
        /// successfully written to the server in a prior <see cref="StageBlockAsync"/>
        /// operation.  You can call <see cref="CommitBlockListAsync"/> to
        /// update a blob by uploading only those blocks that have changed,
        /// then committing the new and existing blocks together.  You can do
        /// this by specifying whether to commit a block from the committed
        /// block list or from the uncommitted block list, or to commit the
        /// most recently uploaded version of the block, whichever list it
        /// may belong to.  Any blocks not specified in the block list and
        /// permanently deleted.
        ///
        /// For more information, see  <see href="https://docs.microsoft.com/rest/api/storageservices/put-block-list"/>
        /// </summary>
        /// <param name="base64BlockIds">
        /// Specify the Uncommitted Base64 encoded block IDs to indicate that
        /// the blob service should search only the uncommitted block list for
        /// the named blocks.  If the block is not found in the uncommitted
        /// block list, it will not be written as part of the blob, and a
        /// <see cref="StorageRequestFailedException"/> will be thrown.
        /// </param>
        /// <param name="blobHttpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// block blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this block blob.
        /// </param>
        /// <param name="blobAccessConditions">
        /// Optional <see cref="BlockBlobClient"/> to add
        /// conditions on committing this block list.
        /// </param>
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
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
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<Response<BlobContentInfo>> CommitBlockListInternal(
            IEnumerable<string> base64BlockIds,
            BlobHttpHeaders? blobHttpHeaders,
            Metadata metadata,
            BlobAccessConditions? blobAccessConditions,
            CustomerProvidedKey? customerProvidedKey,
            AccessTier? accessTier,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlockBlobClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlockBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(base64BlockIds)}: {base64BlockIds}\n" +
                    $"{nameof(blobHttpHeaders)}: {blobHttpHeaders}\n" +
                    $"{nameof(blobAccessConditions)}: {blobAccessConditions}");
                try
                {
                    BlobErrors.VerifyHttpsCustomerProvidedKey(Uri, customerProvidedKey);

                    var blocks = new BlockLookupList() { Uncommitted = base64BlockIds.ToList() };
                    return await BlobRestClient.BlockBlob.CommitBlockListAsync(
                        Pipeline,
                        Uri,
                        blocks,
                        blobCacheControl: blobHttpHeaders?.CacheControl,
                        blobContentType: blobHttpHeaders?.ContentType,
                        blobContentEncoding: blobHttpHeaders?.ContentEncoding,
                        blobContentLanguage: blobHttpHeaders?.ContentLanguage,
                        blobContentHash: blobHttpHeaders?.ContentHash,
                        metadata: metadata,
                        leaseId: blobAccessConditions?.LeaseAccessConditions?.LeaseId,
                        blobContentDisposition: blobHttpHeaders?.ContentDisposition,
                        encryptionKey: customerProvidedKey?.EncryptionKey,
                        encryptionKeySha256: customerProvidedKey?.EncryptionKeyHash,
                        encryptionAlgorithm: customerProvidedKey?.EncryptionAlgorithm,
                        tier: accessTier,
                        ifModifiedSince: blobAccessConditions?.HttpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: blobAccessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        ifMatch: blobAccessConditions?.HttpAccessConditions?.IfMatch,
                        ifNoneMatch: blobAccessConditions?.HttpAccessConditions?.IfNoneMatch,
                        async: async,
                        operationName: Constants.Blob.Block.CommitBlockListOperationName,
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
                    Pipeline.LogMethodExit(nameof(BlockBlobClient));
                }
            }
        }
        #endregion CommitBlockList

        #region GetBlockList
        /// <summary>
        /// The <see cref="GetBlockList"/> operation operation retrieves
        /// the list of blocks that have been uploaded as part of a block blob.
        /// There are two block lists maintained for a blob.  The Committed
        /// Block list has blocks that have been successfully committed to a
        /// given blob with <see cref="CommitBlockList"/>.  The
        /// Uncommitted Block list has blocks that have been uploaded for a
        /// blob using <see cref="StageBlock"/>, but that have not yet
        /// been committed.  These blocks are stored in Azure in association
        /// with a blob, but do not yet form part of the blob.
        /// </summary>
        /// <param name="listType">
        /// Specifies whether to return the list of committed blocks, the
        /// list of uncommitted blocks, or both lists together.  If you omit
        /// this parameter, Get Block List returns the list of committed blocks.
        /// </param>
        /// <param name="snapshot">
        /// Optionally specifies the blob snapshot to retrieve the block list
        /// from. For more information on working with blob snapshots, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/creating-a-snapshot-of-a-blob"/>.
        /// </param>
        /// <param name="leaseAccessConditions">
        /// Optional <see cref="LeaseAccessConditions"/> to add
        /// conditions on retrieving the block list.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlockList}"/> describing requested
        /// block list.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlockList> GetBlockList(
            BlockListType? listType = default,
            string snapshot = default,
            LeaseAccessConditions? leaseAccessConditions = default,
            CancellationToken cancellationToken = default) =>
            GetBlockListInternal(
                listType,
                snapshot,
                leaseAccessConditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetBlockListAsync"/> operation operation retrieves
        /// the list of blocks that have been uploaded as part of a block blob.
        /// There are two block lists maintained for a blob.  The Committed
        /// Block list has blocks that have been successfully committed to a
        /// given blob with <see cref="CommitBlockListAsync"/>.  The
        /// Uncommitted Block list has blocks that have been uploaded for a
        /// blob using <see cref="StageBlockAsync"/>, but that have not yet
        /// been committed.  These blocks are stored in Azure in association
        /// with a blob, but do not yet form part of the blob.
        /// </summary>
        /// <param name="listType">
        /// Specifies whether to return the list of committed blocks, the
        /// list of uncommitted blocks, or both lists together.  If you omit
        /// this parameter, Get Block List returns the list of committed blocks.
        /// </param>
        /// <param name="snapshot">
        /// Optionally specifies the blob snapshot to retrieve the block list
        /// from. For more information on working with blob snapshots, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/creating-a-snapshot-of-a-blob"/>.
        /// </param>
        /// <param name="leaseAccessConditions">
        /// Optional <see cref="LeaseAccessConditions"/> to add
        /// conditions on retrieving the block list.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlockList}"/> describing requested
        /// block list.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlockList>> GetBlockListAsync(
            BlockListType? listType = default,
            string snapshot = default,
            LeaseAccessConditions? leaseAccessConditions = default,
            CancellationToken cancellationToken = default) =>
            await GetBlockListInternal(
                listType,
                snapshot,
                leaseAccessConditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetBlockListInternal"/> operation operation retrieves
        /// the list of blocks that have been uploaded as part of a block blob.
        /// There are two block lists maintained for a blob.  The Committed
        /// Block list has blocks that have been successfully committed to a
        /// given blob with <see cref="CommitBlockListAsync"/>.  The
        /// Uncommitted Block list has blocks that have been uploaded for a
        /// blob using <see cref="StageBlockAsync"/>, but that have not yet
        /// been committed.  These blocks are stored in Azure in association
        /// with a blob, but do not yet form part of the blob.
        /// </summary>
        /// <param name="listType">
        /// Specifies whether to return the list of committed blocks, the
        /// list of uncommitted blocks, or both lists together.  If you omit
        /// this parameter, Get Block List returns the list of committed blocks.
        /// </param>
        /// <param name="snapshot">
        /// Optionally specifies the blob snapshot to retrieve the block list
        /// from. For more information on working with blob snapshots, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/creating-a-snapshot-of-a-blob"/>.
        /// </param>
        /// <param name="leaseAccessConditions">
        /// Optional <see cref="LeaseAccessConditions"/> to add
        /// conditions on retrieving the block list.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlockList}"/> describing requested
        /// block list.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlockList>> GetBlockListInternal(
            BlockListType? listType,
            string snapshot,
            LeaseAccessConditions? leaseAccessConditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlockBlobClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlockBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(listType)}: {listType}\n" +
                    $"{nameof(snapshot)}: {snapshot}\n" +
                    $"{nameof(leaseAccessConditions)}: {leaseAccessConditions}");
                try
                {
                    return (await BlobRestClient.BlockBlob.GetBlockListAsync(
                        Pipeline,
                        Uri,
                        listType: listType ?? BlockListType.All,
                        snapshot: snapshot,
                        leaseId: leaseAccessConditions?.LeaseId,
                        async: async,
                        operationName: Constants.Blob.Block.GetBlockListOperationName,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false))
                        .ToBlockList();
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(BlockBlobClient));
                }
            }
        }
        #endregion GetBlockList
    }

    /// <summary>
    /// Add easy to discover methods to <see cref="BlobContainerClient"/> for
    /// creating <see cref="BlockBlobClient"/> instances.
    /// </summary>
    public static partial class SpecializedBlobExtensions
    {
        /// <summary>
        /// Create a new <see cref="BlockBlobClient"/> object by
        /// concatenating <paramref name="blobName"/> to
        /// the end of the <paramref name="client"/>'s
        /// <see cref="BlobContainerClient.Uri"/>. The new
        /// <see cref="BlockBlobClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="BlobContainerClient"/>.
        /// </summary>
        /// <param name="client">The <see cref="BlobContainerClient"/>.</param>
        /// <param name="blobName">The name of the append blob.</param>
        /// <returns>A new <see cref="BlockBlobClient"/> instance.</returns>
        public static BlockBlobClient GetBlockBlobClient(
            this BlobContainerClient client,
            string blobName)
            => new BlockBlobClient(client.Uri.AppendToPath(blobName), client.Pipeline);
    }
}
