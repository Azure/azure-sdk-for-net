// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Shared;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

#pragma warning disable SA1402  // File may only contain a single type

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
    /// size, up to a maximum of 4,000 MB (100 MB for requests using REST
    /// versions before 2019-12-12 and 4 MB for requests using REST versions
    /// before 2016-05-31), and a block blob can include up to 50,000 blocks.
    /// The maximum size of a block blob is therefore approximately 190.73 TiB
    /// (4,000 MB X 50,000 blocks).  If you are writing a block blob that is
    /// no more than 5,000 MB in size, you can upload it in its entirety with a
    /// single write operation; see <see cref="UploadAsync(Stream, BlobUploadOptions, CancellationToken)"/>.
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
    /// blob can have up to 100,000 uncommitted blocks, with a max total size
    /// of appoximately 381.46 TiB (4,000 MB x 100,000 blocks)
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
        /// Gets the maximum number of bytes that can be sent in a call
        /// to <see cref="UploadAsync(Stream, BlobUploadOptions, CancellationToken)"/>. Supported value is now larger
        /// than <see cref="int.MaxValue"/>; please use
        /// <see cref="BlockBlobMaxUploadBlobLongBytes"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int BlockBlobMaxUploadBlobBytes => Version < BlobClientOptions.ServiceVersion.V2019_12_12
            ? Constants.Blob.Block.Pre_2019_12_12_MaxUploadBytes
            : int.MaxValue; // value is larger than can be represented by an int

        /// <summary>
        /// Gets the maximum number of bytes that can be sent in a call
        /// to <see cref="UploadAsync(Stream, BlobUploadOptions, CancellationToken)"/>.
        /// </summary>
        public virtual long BlockBlobMaxUploadBlobLongBytes => Version < BlobClientOptions.ServiceVersion.V2019_12_12
            ? Constants.Blob.Block.Pre_2019_12_12_MaxUploadBytes
            : Constants.Blob.Block.MaxUploadBytes;

        /// <summary>
        /// Gets the maximum number of bytes that can be sent in a call
        /// to <see cref="StageBlockAsync"/>. Supported value is now larger
        /// than <see cref="int.MaxValue"/>; please use
        /// <see cref="BlockBlobMaxStageBlockLongBytes"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int BlockBlobMaxStageBlockBytes => Version < BlobClientOptions.ServiceVersion.V2019_12_12
            ? Constants.Blob.Block.Pre_2019_12_12_MaxStageBytes
            : int.MaxValue; // value is larger than can be represented by an int

        /// <summary>
        /// Gets the maximum number of bytes that can be sent in a call
        /// to <see cref="StageBlockAsync"/>.
        /// </summary>
        public virtual long BlockBlobMaxStageBlockLongBytes => Version < BlobClientOptions.ServiceVersion.V2019_12_12
            ? Constants.Blob.Block.Pre_2019_12_12_MaxStageBytes
            : Constants.Blob.Block.MaxStageBytes;

        /// <summary>
        /// Gets the maximum number of blocks allowed in a block blob.
        /// </summary>
        public virtual int BlockBlobMaxBlocks => Constants.Blob.Block.MaxBlocks;

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
        /// For more information,
        /// <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">
        /// Configure Azure Storage connection strings</see>
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
        /// For more information,
        /// <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">
        /// Configure Azure Storage connection strings</see>
        /// </param>
        /// <param name="blobContainerName">
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
        public BlockBlobClient(string connectionString, string blobContainerName, string blobName, BlobClientOptions options)
            : base(connectionString, blobContainerName, blobName, options)
        {
            AssertNoClientSideEncryption(options);
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
            AssertNoClientSideEncryption(options);
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
            AssertNoClientSideEncryption(options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// Must not contain shared access signature, which should be passed in the second parameter.
        /// </param>
        /// <param name="credential">
        /// The shared access signature credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        /// <remarks>
        /// This constructor should only be used when shared access signature needs to be updated during lifespan of this client.
        /// </remarks>
        public BlockBlobClient(Uri blobUri, AzureSasCredential credential, BlobClientOptions options = default)
            : base(blobUri, credential, options)
        {
            AssertNoClientSideEncryption(options);
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
            AssertNoClientSideEncryption(options);
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
        /// <param name="storageSharedKeyCredential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="version">
        /// The version of the service to use when sending requests.
        /// </param>
        /// <param name="clientDiagnostics">Client diagnostics.</param>
        /// <param name="customerProvidedKey">Customer provided key.</param>
        /// <param name="encryptionScope">Encryption scope.</param>
        internal BlockBlobClient(
            Uri blobUri,
            HttpPipeline pipeline,
            StorageSharedKeyCredential storageSharedKeyCredential,
            BlobClientOptions.ServiceVersion version,
            ClientDiagnostics clientDiagnostics,
            CustomerProvidedKey? customerProvidedKey,
            string encryptionScope)
            : base(
                  blobUri,
                  pipeline,
                  storageSharedKeyCredential,
                  version,
                  clientDiagnostics,
                  customerProvidedKey,
                  clientSideEncryption: default,
                  encryptionScope)
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
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        /// <returns>
        /// New instanc of the <see cref="BlockBlobClient"/> class.
        /// </returns>
        protected static BlockBlobClient CreateClient(Uri blobUri, BlobClientOptions options, HttpPipeline pipeline)
        {
            return new BlockBlobClient(blobUri, pipeline, null, options.Version, new ClientDiagnostics(options), null, null);
        }

        private static void AssertNoClientSideEncryption(BlobClientOptions options)
        {
            if (options?._clientSideEncryptionOptions != default)
            {
                throw Errors.ClientSideEncryption.TypeNotSupported(typeof(BlockBlobClient));
            }
        }
        #endregion ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockBlobClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="snapshot"/> timestamp.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/creating-a-snapshot-of-a-blob">
        /// Create a snapshot of a blob</see>.
        /// </summary>
        /// <param name="snapshot">The snapshot identifier.</param>
        /// <returns>A new <see cref="BlockBlobClient"/> instance.</returns>
        /// <remarks>
        /// Pass null or empty string to remove the snapshot returning a URL
        /// to the base blob.
        /// </remarks>
        public new BlockBlobClient WithSnapshot(string snapshot) => (BlockBlobClient)WithSnapshotCore(snapshot);

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockBlobClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="versionId"/> timestamp.
        ///
        /// </summary>
        /// <param name="versionId">The version identifier.</param>
        /// <returns>A new <see cref="BlockBlobClient"/> instance.</returns>
        /// <remarks>
        /// Pass null or empty string to remove the snapshot returning a URL
        /// to the base blob.
        /// </remarks>
        public new BlockBlobClient WithVersion(string versionId)
        {
            var builder = new BlobUriBuilder(Uri) { VersionId = versionId };
            return new BlockBlobClient(builder.ToUri(), Pipeline, SharedKeyCredential, Version, ClientDiagnostics, CustomerProvidedKey, EncryptionScope);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="BlockBlobClient"/> class
        /// with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="snapshot"/> timestamp.
        /// </summary>
        /// <param name="snapshot">The snapshot identifier.</param>
        /// <returns>A new <see cref="BlockBlobClient"/> instance.</returns>
        protected sealed override BlobBaseClient WithSnapshotCore(string snapshot)
        {
            var builder = new BlobUriBuilder(Uri) { Snapshot = snapshot };

            return new BlockBlobClient(builder.ToUri(), Pipeline, SharedKeyCredential, Version, ClientDiagnostics, CustomerProvidedKey, EncryptionScope);
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
        /// The <see cref="Upload(Stream, BlobUploadOptions, CancellationToken)"/>
        /// operation creates a new block  blob,  or updates the content of an existing block blob.
        /// Updating an existing block blob overwrites any existing metadata on the blob.
        ///
        /// Partial updates are not supported with <see cref="Upload(Stream, BlobUploadOptions, CancellationToken)"/>;
        /// the content of the existing blob is overwritten with the content
        /// of the new blob.  To perform a partial update of the content of a
        /// block blob, use the <see cref="StageBlock"/> and
        /// <see cref="CommitBlockList(IEnumerable{string}, CommitBlockListOptions, CancellationToken)" /> operations.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobContentInfo> Upload(
            Stream content,
            BlobUploadOptions options,
            CancellationToken cancellationToken = default)
        {
            var uploader = GetPartitionedUploader(
                transferOptions: options?.TransferOptions ?? default,
                operationName: $"{nameof(BlockBlobClient)}.{nameof(Upload)}");

            return uploader.UploadInternal(
                content,
                options,
                options.ProgressHandler,
                async: false,
                cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="UploadAsync(Stream, BlobUploadOptions, CancellationToken)"/>
        /// operation creates a new block  blob,  or updates the content of an existing block blob.
        /// Updating an existing block blob overwrites any existing metadata on the blob.
        ///
        /// Partial updates are not supported with <see cref="UploadAsync(Stream, BlobUploadOptions, CancellationToken)"/>;
        /// the content of the existing blob is overwritten with the content
        /// of the new blob.  To perform a partial update of the content of a
        /// block blob, use the <see cref="StageBlock"/> and
        /// <see cref="CommitBlockListAsync(IEnumerable{string}, CommitBlockListOptions, CancellationToken)" /> operations.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobContentInfo>> UploadAsync(
            Stream content,
            BlobUploadOptions options,
            CancellationToken cancellationToken = default)
        {
            var uploader = GetPartitionedUploader(
                transferOptions: options?.TransferOptions ?? default,
                operationName: $"{nameof(BlockBlobClient)}.{nameof(Upload)}");

            return await uploader.UploadInternal(
                content,
                options,
                options.ProgressHandler,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// The <see cref="Upload(Stream, BlobHttpHeaders, Metadata, BlobRequestConditions, AccessTier?, IProgress{long}, CancellationToken)"/>
        /// operation creates a new block  blob, or updates the content of an existing block blob.  Updating an
        /// existing block blob overwrites any existing metadata on the blob.
        ///
        /// Partial updates are not supported with <see cref="Upload(Stream, BlobHttpHeaders, Metadata, BlobRequestConditions, AccessTier?, IProgress{long}, CancellationToken)"/>;
        /// the content of the existing blob is overwritten with the content
        /// of the new blob.  To perform a partial update of the content of a
        /// block blob, use the <see cref="StageBlock"/> and
        /// <see cref="CommitBlockList(IEnumerable{string}, BlobHttpHeaders, Metadata, BlobRequestConditions, AccessTier?, CancellationToken)" /> operations.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// block blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this block blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlockBlobClient"/> to add
        /// conditions on the creation of this new block blob.
        /// </param>
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
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
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BlobContentInfo> Upload(
            Stream content,
            BlobHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            BlobRequestConditions conditions = default,
            AccessTier? accessTier = default,
            IProgress<long> progressHandler = default,
            CancellationToken cancellationToken = default)
            => Upload(
                content,
                new BlobUploadOptions
                {
                    HttpHeaders = httpHeaders,
                    Metadata = metadata,
                    Conditions = conditions,
                    AccessTier = accessTier,
                    ProgressHandler = progressHandler,
                },
                cancellationToken);

        /// <summary>
        /// The <see cref="UploadAsync(Stream, BlobHttpHeaders, Metadata, BlobRequestConditions, AccessTier?, IProgress{long}, CancellationToken)"/>
        /// operation creates a new block  blob, or updates the content of an existing block blob.  Updating an
        /// existing block blob overwrites any existing metadata on the blob.
        ///
        /// Partial updates are not supported with <see cref="UploadAsync(Stream, BlobHttpHeaders, Metadata, BlobRequestConditions, AccessTier?, IProgress{long}, CancellationToken)"/>;
        /// the content of the existing blob is overwritten with the content
        /// of the new blob.  To perform a partial update of the content of a
        /// block blob, use the <see cref="StageBlockAsync"/> and
        /// <see cref="CommitBlockListAsync(IEnumerable{string}, BlobHttpHeaders, Metadata, BlobRequestConditions, AccessTier?, CancellationToken)" /> operations.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// block blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this block blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the creation of this new block blob.
        /// </param>
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
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
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BlobContentInfo>> UploadAsync(
            Stream content,
            BlobHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            BlobRequestConditions conditions = default,
            AccessTier? accessTier = default,
            IProgress<long> progressHandler = default,
            CancellationToken cancellationToken = default)
            => await UploadAsync(
                content,
                new BlobUploadOptions
                {
                    HttpHeaders = httpHeaders,
                    Metadata = metadata,
                    Conditions = conditions,
                    AccessTier = accessTier,
                    ProgressHandler = progressHandler,
                },
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UploadInternal"/> operation creates a new block blob,
        /// or updates the content of an existing block blob.  Updating an
        /// existing block blob overwrites any existing metadata on the blob.
        ///
        /// Partial updates are not supported with <see cref="UploadInternal"/>;
        /// the content of the existing blob is overwritten with the content
        /// of the new blob.  To perform a partial update of the content of a
        /// block blob, use the <see cref="StageBlockInternal"/> and
        /// <see cref="CommitBlockListInternal" /> operations.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
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
        /// <param name="tags">
        /// Optional tags to set for this block blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlockBlobClient"/> to add
        /// conditions on the creation of this new block blob.
        /// </param>
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="operationName">
        /// The name of the calling operation.
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal virtual async Task<Response<BlobContentInfo>> UploadInternal(
            Stream content,
            BlobHttpHeaders blobHttpHeaders,
            Metadata metadata,
            Tags tags,
            BlobRequestConditions conditions,
            AccessTier? accessTier,
            IProgress<long> progressHandler,
            string operationName,
            bool async,
            CancellationToken cancellationToken)
        {
            content = content?.WithNoDispose().WithProgress(progressHandler);
            using (Pipeline.BeginLoggingScope(nameof(BlockBlobClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlockBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(blobHttpHeaders)}: {blobHttpHeaders}\n" +
                    $"{nameof(conditions)}: {conditions}");
                try
                {
                    Errors.VerifyStreamPosition(content, nameof(content));

                    return await BlobRestClient.BlockBlob.UploadAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        body: content,
                        contentLength: (content?.Length - content?.Position) ?? 0,
                        version: Version.ToVersionString(),
                        blobContentType: blobHttpHeaders?.ContentType,
                        blobContentEncoding: blobHttpHeaders?.ContentEncoding,
                        blobContentLanguage: blobHttpHeaders?.ContentLanguage,
                        blobContentHash: blobHttpHeaders?.ContentHash,
                        blobCacheControl: blobHttpHeaders?.CacheControl,
                        metadata: metadata,
                        leaseId: conditions?.LeaseId,
                        blobContentDisposition: blobHttpHeaders?.ContentDisposition,
                        encryptionKey: CustomerProvidedKey?.EncryptionKey,
                        encryptionKeySha256: CustomerProvidedKey?.EncryptionKeyHash,
                        encryptionAlgorithm: CustomerProvidedKey?.EncryptionAlgorithm,
                        encryptionScope: EncryptionScope,
                        tier: accessTier,
                        ifModifiedSince: conditions?.IfModifiedSince,
                        ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                        ifMatch: conditions?.IfMatch,
                        ifNoneMatch: conditions?.IfNoneMatch,
                        ifTags: conditions?.TagConditions,
                        blobTagsString: tags?.ToTagsString(),
                        async: async,
                        operationName: operationName ?? $"{nameof(BlockBlobClient)}.{nameof(Upload)}",
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
        #endregion Upload

        #region StageBlock
        /// <summary>
        /// The <see cref="StageBlock"/> operation creates a new block as
        /// part of a block blob's "staging area" to be eventually committed
        /// via the <see cref="CommitBlockList(IEnumerable{string}, CommitBlockListOptions, CancellationToken)"/> operation.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-block">
        /// Put Block</see>.
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
        /// <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the upload of this block.
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
        /// A <see cref="Response{BlockInfo}"/> describing the
        /// state of the updated block.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlockInfo> StageBlock(
            string base64BlockId,
            Stream content,
            byte[] transactionalContentHash = default,
            BlobRequestConditions conditions = default,
            IProgress<long> progressHandler = default,
            CancellationToken cancellationToken = default) =>
            StageBlockInternal(
                base64BlockId,
                content,
                transactionalContentHash,
                conditions,
                progressHandler,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="StageBlockAsync"/> operation creates a new block as
        /// part of a block blob's "staging area" to be eventually committed
        /// via the <see cref="CommitBlockListAsync(IEnumerable{string}, CommitBlockListOptions, CancellationToken)"/> operation.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-block">
        /// Put Block</see>.
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
        /// <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the upload of this block.
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
        /// A <see cref="Response{BlockInfo}"/> describing the
        /// state of the updated block.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlockInfo>> StageBlockAsync(
            string base64BlockId,
            Stream content,
            byte[] transactionalContentHash = default,
            BlobRequestConditions conditions = default,
            IProgress<long> progressHandler = default,
            CancellationToken cancellationToken = default) =>
            await StageBlockInternal(
                base64BlockId,
                content,
                transactionalContentHash,
                conditions,
                progressHandler,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="StageBlockInternal"/> operation creates a new block
        /// as part of a block blob's "staging area" to be eventually committed
        /// via the <see cref="CommitBlockListInternal"/> operation.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-block">
        /// Put Block</see>.
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
        /// <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the upload of this block.
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
        /// A <see cref="Response{BlockInfo}"/> describing the
        /// state of the updated block.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal virtual async Task<Response<BlockInfo>> StageBlockInternal(
            string base64BlockId,
            Stream content,
            byte[] transactionalContentHash,
            BlobRequestConditions conditions,
            IProgress<long> progressHandler,
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
                    $"{nameof(conditions)}: {conditions}");
                try
                {
                    Errors.VerifyStreamPosition(content, nameof(content));
                    content = content.WithNoDispose().WithProgress(progressHandler);
                    return await BlobRestClient.BlockBlob.StageBlockAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        blockId: base64BlockId,
                        body: content,
                        contentLength: (content?.Length - content?.Position) ?? 0,
                        version: Version.ToVersionString(),
                        transactionalContentHash: transactionalContentHash,
                        leaseId: conditions?.LeaseId,
                        encryptionKey: CustomerProvidedKey?.EncryptionKey,
                        encryptionKeySha256: CustomerProvidedKey?.EncryptionKeyHash,
                        encryptionAlgorithm: CustomerProvidedKey?.EncryptionAlgorithm,
                        encryptionScope: EncryptionScope,
                        async: async,
                        operationName: $"{nameof(BlockBlobClient)}.{nameof(StageBlock)}",
                        cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-block-from-url">
        /// Put Block From URL</see>.
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
        /// with a <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="sourceConditions">
        /// Optional <see cref="RequestConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the staging of this block.
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlockInfo> StageBlockFromUri(
            Uri sourceUri,
            string base64BlockId,
            HttpRange sourceRange = default,
            byte[] sourceContentHash = default,
            RequestConditions sourceConditions = default,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            StageBlockFromUriInternal(
                sourceUri,
                base64BlockId,
                sourceRange,
                sourceContentHash,
                sourceConditions,
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="StageBlockFromUriAsync"/> operation creates a new
        /// block to be committed as part of a blob where the contents are
        /// read from the <paramref name="sourceUri" />.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-block-from-url">
        /// Put Block From URL</see>.
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
        /// with a <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="sourceConditions">
        /// Optional <see cref="RequestConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the staging of this block.
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlockInfo>> StageBlockFromUriAsync(
            Uri sourceUri,
            string base64BlockId,
            HttpRange sourceRange = default,
            byte[] sourceContentHash = default,
            RequestConditions sourceConditions = default,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await StageBlockFromUriInternal(
                sourceUri,
                base64BlockId,
                sourceRange,
                sourceContentHash,
                sourceConditions,
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="StageBlockFromUriInternal"/> operation creates a new
        /// block to be committed as part of a blob where the contents are
        /// read from the <paramref name="sourceUri" />.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-block-from-url">
        /// Put Block From URL</see>.
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
        /// with a <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="sourceConditions">
        /// Optional <see cref="RequestConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the staging of this block.
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlockInfo>> StageBlockFromUriInternal(
            Uri sourceUri,
            string base64BlockId,
            HttpRange sourceRange,
            byte[] sourceContentHash,
            RequestConditions sourceConditions,
            BlobRequestConditions conditions,
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
                    $"{nameof(conditions)}: {conditions}");
                try
                {
                    return await BlobRestClient.BlockBlob.StageBlockFromUriAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        contentLength: default,
                        blockId: base64BlockId,
                        sourceUri: sourceUri,
                        version: Version.ToVersionString(),
                        sourceRange: sourceRange.ToString(),
                        sourceContentHash: sourceContentHash,
                        encryptionKey: CustomerProvidedKey?.EncryptionKey,
                        encryptionKeySha256: CustomerProvidedKey?.EncryptionKeyHash,
                        encryptionAlgorithm: CustomerProvidedKey?.EncryptionAlgorithm,
                        encryptionScope: EncryptionScope,
                        leaseId: conditions?.LeaseId,
                        sourceIfModifiedSince: sourceConditions?.IfModifiedSince,
                        sourceIfUnmodifiedSince: sourceConditions?.IfUnmodifiedSince,
                        sourceIfMatch: sourceConditions?.IfMatch,
                        sourceIfNoneMatch: sourceConditions?.IfNoneMatch,
                        async: async,
                        operationName: $"{nameof(BlockBlobClient)}.{nameof(StageBlockFromUri)}",
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
        /// The <see cref="CommitBlockList(IEnumerable{string}, CommitBlockListOptions, CancellationToken)"/>
        /// operation writes a blob by specifying the list of block IDs that make up the blob.  In order
        /// to be written as part of a blob, a block must have been
        /// successfully written to the server in a prior <see cref="StageBlock"/>
        /// operation.  You can call <see cref="CommitBlockList(IEnumerable{string}, CommitBlockListOptions, CancellationToken)"/>
        /// to update a blob by uploading only those blocks that have changed,
        /// then committing the new and existing blocks together.  You can do
        /// this by specifying whether to commit a block from the committed
        /// block list or from the uncommitted block list, or to commit the
        /// most recently uploaded version of the block, whichever list it
        /// may belong to.  Any blocks not specified in the block list and
        /// permanently deleted.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-block-list">
        /// Put Block List</see>.
        /// </summary>
        /// <param name="base64BlockIds">
        /// Specify the Uncommitted Base64 encoded block IDs to indicate that
        /// the blob service should search only the uncommitted block list for
        /// the named blocks.  If the block is not found in the uncommitted
        /// block list, it will not be written as part of the blob, and a
        /// <see cref="RequestFailedException"/> will be thrown.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobContentInfo> CommitBlockList(
            IEnumerable<string> base64BlockIds,
            CommitBlockListOptions options,
            CancellationToken cancellationToken = default) =>
            CommitBlockListInternal(
                base64BlockIds,
                options?.HttpHeaders,
                options?.Metadata,
                options?.Tags,
                options?.Conditions,
                options?.AccessTier,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="CommitBlockList(IEnumerable{string}, BlobHttpHeaders, Metadata, BlobRequestConditions, AccessTier?, CancellationToken)"/>
        /// operation writes a blob by specifying the list of block IDs that make up the blob.
        /// In order to be written as part of a blob, a block must have been
        /// successfully written to the server in a prior <see cref="StageBlock"/>
        /// operation.  You can call <see cref="CommitBlockList(IEnumerable{string}, BlobHttpHeaders, Metadata, BlobRequestConditions, AccessTier?, CancellationToken)"/>
        /// to update a blob by uploading only those blocks that have changed,
        /// then committing the new and existing blocks together.  You can do
        /// this by specifying whether to commit a block from the committed
        /// block list or from the uncommitted block list, or to commit the
        /// most recently uploaded version of the block, whichever list it
        /// may belong to.  Any blocks not specified in the block list and
        /// permanently deleted.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-block-list">
        /// Put Block List</see>.
        /// </summary>
        /// <param name="base64BlockIds">
        /// Specify the Uncommitted Base64 encoded block IDs to indicate that
        /// the blob service should search only the uncommitted block list for
        /// the named blocks.  If the block is not found in the uncommitted
        /// block list, it will not be written as part of the blob, and a
        /// <see cref="RequestFailedException"/> will be thrown.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// block blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this block blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlockBlobClient"/> to add
        /// conditions on committing this block list.
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
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BlobContentInfo> CommitBlockList(
            IEnumerable<string> base64BlockIds,
            BlobHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            BlobRequestConditions conditions = default,
            AccessTier? accessTier = default,
            CancellationToken cancellationToken = default) =>
            CommitBlockListInternal(
                base64BlockIds,
                httpHeaders,
                metadata,
                default,
                conditions,
                accessTier,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="CommitBlockListAsync(IEnumerable{string}, CommitBlockListOptions, CancellationToken)"/>
        /// operation writes a blob by specifying the list of block IDs that make up the blob.  In order
        /// to be written as part of a blob, a block must have been
        /// successfully written to the server in a prior <see cref="StageBlock"/>
        /// operation.  You can call <see cref="CommitBlockListAsync(IEnumerable{string}, CommitBlockListOptions, CancellationToken)"/>
        /// to update a blob by uploading only those blocks that have changed,
        /// then committing the new and existing blocks together.  You can do
        /// this by specifying whether to commit a block from the committed
        /// block list or from the uncommitted block list, or to commit the
        /// most recently uploaded version of the block, whichever list it
        /// may belong to.  Any blocks not specified in the block list and
        /// permanently deleted.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-block-list">
        /// Put Block List</see>.
        /// </summary>
        /// <param name="base64BlockIds">
        /// Specify the Uncommitted Base64 encoded block IDs to indicate that
        /// the blob service should search only the uncommitted block list for
        /// the named blocks.  If the block is not found in the uncommitted
        /// block list, it will not be written as part of the blob, and a
        /// <see cref="RequestFailedException"/> will be thrown.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobContentInfo>> CommitBlockListAsync(
            IEnumerable<string> base64BlockIds,
            CommitBlockListOptions options,
            CancellationToken cancellationToken = default) =>
            await CommitBlockListInternal(
                base64BlockIds,
                options?.HttpHeaders,
                options?.Metadata,
                options?.Tags,
                options?.Conditions,
                options?.AccessTier,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CommitBlockListAsync(IEnumerable{string}, BlobHttpHeaders, Metadata, BlobRequestConditions, AccessTier?, CancellationToken)"/>
        /// operation writes a blob bys pecifying the list of block IDs that make up the blob.
        /// In order to be written as part of a blob, a block must have been
        /// successfully written to the server in a prior <see cref="StageBlockAsync"/>
        /// operation.  You can call <see cref="CommitBlockListAsync(IEnumerable{string}, BlobHttpHeaders, Metadata, BlobRequestConditions, AccessTier?, CancellationToken)"/>
        /// to update a blob by uploading only those blocks that have changed,
        /// then committing the new and existing blocks together.  You can do
        /// this by specifying whether to commit a block from the committed
        /// block list or from the uncommitted block list, or to commit the
        /// most recently uploaded version of the block, whichever list it
        /// may belong to.  Any blocks not specified in the block list and
        /// permanently deleted.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-block-list">
        /// Put Block List</see>.
        /// </summary>
        /// <param name="base64BlockIds">
        /// Specify the Uncommitted Base64 encoded block IDs to indicate that
        /// the blob service should search only the uncommitted block list for
        /// the named blocks.  If the block is not found in the uncommitted
        /// block list, it will not be written as part of the blob, and a
        /// <see cref="RequestFailedException"/> will be thrown.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// block blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this block blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlockBlobClient"/> to add
        /// conditions on committing this block list.
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BlobContentInfo>> CommitBlockListAsync(
            IEnumerable<string> base64BlockIds,
            BlobHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            BlobRequestConditions conditions = default,
            AccessTier? accessTier = default,
            CancellationToken cancellationToken = default) =>
            await CommitBlockListInternal(
                base64BlockIds,
                httpHeaders,
                metadata,
                default,
                conditions,
                accessTier,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CommitBlockListInternal"/> operation writes a blob by
        /// specifying the list of block IDs that make up the blob.  In order
        /// to be written as part of a blob, a block must have been
        /// successfully written to the server in a prior <see cref="StageBlockAsync"/>
        /// operation.  You can call <see cref="CommitBlockListInternal"/> to
        /// update a blob by uploading only those blocks that have changed,
        /// then committing the new and existing blocks together.  You can do
        /// this by specifying whether to commit a block from the committed
        /// block list or from the uncommitted block list, or to commit the
        /// most recently uploaded version of the block, whichever list it
        /// may belong to.  Any blocks not specified in the block list and
        /// permanently deleted.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-block-list">
        /// Put Block List</see>.
        /// </summary>
        /// <param name="base64BlockIds">
        /// Specify the Uncommitted Base64 encoded block IDs to indicate that
        /// the blob service should search only the uncommitted block list for
        /// the named blocks.  If the block is not found in the uncommitted
        /// block list, it will not be written as part of the blob, and a
        /// <see cref="RequestFailedException"/> will be thrown.
        /// </param>
        /// <param name="blobHttpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// block blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this block blob.
        /// </param>
        /// <param name="tags">
        /// Optional tags to set for this block blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlockBlobClient"/> to add
        /// conditions on committing this block list.
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal virtual async Task<Response<BlobContentInfo>> CommitBlockListInternal(
            IEnumerable<string> base64BlockIds,
            BlobHttpHeaders blobHttpHeaders,
            Metadata metadata,
            Tags tags,
            BlobRequestConditions conditions,
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
                    $"{nameof(conditions)}: {conditions}");
                try
                {
                    var blocks = new BlockLookupList() { Latest = base64BlockIds.ToList() };
                    return await BlobRestClient.BlockBlob.CommitBlockListAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        blocks,
                        version: Version.ToVersionString(),
                        blobCacheControl: blobHttpHeaders?.CacheControl,
                        blobContentType: blobHttpHeaders?.ContentType,
                        blobContentEncoding: blobHttpHeaders?.ContentEncoding,
                        blobContentLanguage: blobHttpHeaders?.ContentLanguage,
                        blobContentHash: blobHttpHeaders?.ContentHash,
                        metadata: metadata,
                        leaseId: conditions?.LeaseId,
                        blobContentDisposition: blobHttpHeaders?.ContentDisposition,
                        encryptionKey: CustomerProvidedKey?.EncryptionKey,
                        encryptionKeySha256: CustomerProvidedKey?.EncryptionKeyHash,
                        encryptionAlgorithm: CustomerProvidedKey?.EncryptionAlgorithm,
                        encryptionScope: EncryptionScope,
                        tier: accessTier,
                        ifModifiedSince: conditions?.IfModifiedSince,
                        ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                        ifMatch: conditions?.IfMatch,
                        ifNoneMatch: conditions?.IfNoneMatch,
                        ifTags: conditions?.TagConditions,
                        blobTagsString: tags?.ToTagsString(),
                        async: async,
                        operationName: $"{nameof(BlockBlobClient)}.{nameof(CommitBlockList)}",
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
        /// given blob with <see cref="CommitBlockList(IEnumerable{string}, CommitBlockListOptions, CancellationToken)"/>.
        /// The Uncommitted Block list has blocks that have been uploaded for a
        /// blob using <see cref="StageBlock"/>, but that have not yet
        /// been committed.  These blocks are stored in Azure in association
        /// with a blob, but do not yet form part of the blob.
        /// </summary>
        /// <param name="blockListTypes">
        /// Specifies whether to return the list of committed blocks, the
        /// list of uncommitted blocks, or both lists together.  If you omit
        /// this parameter, Get Block List returns the list of committed blocks.
        /// </param>
        /// <param name="snapshot">
        /// Optionally specifies the blob snapshot to retrieve the block list
        /// from. For more information on working with blob snapshots, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/creating-a-snapshot-of-a-blob">
        /// Create a snapshot of a blob</see>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlockList> GetBlockList(
            BlockListTypes blockListTypes = BlockListTypes.All,
            string snapshot = default,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            GetBlockListInternal(
                blockListTypes,
                snapshot,
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetBlockListAsync"/> operation operation retrieves
        /// the list of blocks that have been uploaded as part of a block blob.
        /// There are two block lists maintained for a blob.  The Committed
        /// Block list has blocks that have been successfully committed to a
        /// given blob with <see cref="CommitBlockListAsync(IEnumerable{string}, CommitBlockListOptions, CancellationToken)"/>.
        /// The Uncommitted Block list has blocks that have been uploaded for a
        /// blob using <see cref="StageBlockAsync"/>, but that have not yet
        /// been committed.  These blocks are stored in Azure in association
        /// with a blob, but do not yet form part of the blob.
        /// </summary>
        /// <param name="blockListTypes">
        /// Specifies whether to return the list of committed blocks, the
        /// list of uncommitted blocks, or both lists together.  If you omit
        /// this parameter, Get Block List returns the list of committed blocks.
        /// </param>
        /// <param name="snapshot">
        /// Optionally specifies the blob snapshot to retrieve the block list
        /// from. For more information on working with blob snapshots, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/creating-a-snapshot-of-a-blob">
        /// Create a snapshot of a blob</see>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlockList>> GetBlockListAsync(
            BlockListTypes blockListTypes = BlockListTypes.All,
            string snapshot = default,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await GetBlockListInternal(
                blockListTypes,
                snapshot,
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetBlockListInternal"/> operation operation retrieves
        /// the list of blocks that have been uploaded as part of a block blob.
        /// There are two block lists maintained for a blob.  The Committed
        /// Block list has blocks that have been successfully committed to a
        /// given blob with <see cref="CommitBlockListInternal"/>.  The
        /// Uncommitted Block list has blocks that have been uploaded for a
        /// blob using <see cref="StageBlockAsync"/>, but that have not yet
        /// been committed.  These blocks are stored in Azure in association
        /// with a blob, but do not yet form part of the blob.
        /// </summary>
        /// <param name="blockListTypes">
        /// Specifies whether to return the list of committed blocks, the
        /// list of uncommitted blocks, or both lists together.  If you omit
        /// this parameter, Get Block List returns the list of committed blocks.
        /// </param>
        /// <param name="snapshot">
        /// Optionally specifies the blob snapshot to retrieve the block list
        /// from. For more information on working with blob snapshots, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/creating-a-snapshot-of-a-blob">
        /// Create a snapshot of a blob</see>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlockList>> GetBlockListInternal(
            BlockListTypes blockListTypes,
            string snapshot,
            BlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlockBlobClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlockBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(blockListTypes)}: {blockListTypes}\n" +
                    $"{nameof(snapshot)}: {snapshot}\n" +
                    $"{nameof(conditions)}: {conditions}");
                try
                {
                    return (await BlobRestClient.BlockBlob.GetBlockListAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        listType: blockListTypes.ToBlockListType(),
                        version: Version.ToVersionString(),
                        snapshot: snapshot,
                        leaseId: conditions?.LeaseId,
                        ifTags: conditions?.TagConditions,
                        async: async,
                        operationName: $"{nameof(BlockBlobClient)}.{nameof(GetBlockList)}",
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

        #region Query
        /// <summary>
        /// The <see cref="Query"/> API returns the
        /// result of a query against the blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/query-blob-contents">
        /// Query Blob Contents</see>.
        /// </summary>
        /// <param name="querySqlExpression">
        /// The query.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        /// <returns>
        /// A <see cref="Response{BlobDownloadInfo}"/>.
        /// </returns>
        public virtual Response<BlobDownloadInfo> Query(
            string querySqlExpression,
            BlobQueryOptions options = default,
            CancellationToken cancellationToken = default) =>
            QueryInternal(
                querySqlExpression,
                options,
                async: false,
                cancellationToken)
            .EnsureCompleted();

        /// <summary>
        /// The <see cref="QueryAsync"/> API returns the
        /// result of a query against the blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/query-blob-contents">
        /// Query Blob Contents</see>.
        /// </summary>
        /// <param name="querySqlExpression">
        /// The query.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        /// <returns>
        /// A <see cref="Response{BlobDownloadInfo}"/>.
        /// </returns>
        public virtual async Task<Response<BlobDownloadInfo>> QueryAsync(
            string querySqlExpression,
            BlobQueryOptions options = default,
            CancellationToken cancellationToken = default) =>
            await QueryInternal(
                querySqlExpression,
                options,
                async: true,
                cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="QueryInternal"/> API returns the
        /// result of a query against the blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/query-blob-contents">
        /// Query Blob Contents</see>.
        /// </summary>
        /// <param name="querySqlExpression">
        /// The query.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        /// <returns>
        /// A <see cref="Response{BlobDownloadInfo}"/>.
        /// </returns>
        private async Task<Response<BlobDownloadInfo>> QueryInternal(
            string querySqlExpression,
            BlobQueryOptions options,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlockBlobClient)))
            {
                Pipeline.LogMethodEnter(nameof(BlockBlobClient), message: $"{nameof(Uri)}: {Uri}");

                try
                {
                    QueryRequest queryRequest = new QueryRequest()
                    {
                        QueryType = Constants.QuickQuery.SqlQueryType,
                        Expression = querySqlExpression,
                        InputSerialization = options?.InputTextConfiguration.ToQuickQuerySerialization(isInput: true),
                        OutputSerialization = options?.OutputTextConfiguration.ToQuickQuerySerialization(isInput: false)
                    };
                    (Response<BlobQueryResult> result, Stream stream) = await BlobRestClient.Blob.QueryAsync(
                        clientDiagnostics: ClientDiagnostics,
                        pipeline: Pipeline,
                        resourceUri: Uri,
                        version: Version.ToVersionString(),
                        queryRequest: queryRequest,
                        leaseId: options?.Conditions?.LeaseId,
                        encryptionKey: CustomerProvidedKey?.EncryptionKey,
                        encryptionKeySha256: CustomerProvidedKey?.EncryptionKeyHash,
                        encryptionAlgorithm: CustomerProvidedKey?.EncryptionAlgorithm,
                        ifModifiedSince: options?.Conditions?.IfModifiedSince,
                        ifUnmodifiedSince: options?.Conditions?.IfUnmodifiedSince,
                        ifMatch: options?.Conditions?.IfMatch,
                        ifNoneMatch: options?.Conditions?.IfNoneMatch,
                        ifTags: options?.Conditions?.TagConditions,
                        async: async,
                        operationName: $"{nameof(BlockBlobClient)}.{nameof(Query)}",
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    Action<BlobQueryError> errorHandler = options?._errorHandler;
                    Stream parsedStream = new BlobQuickQueryStream(stream, options?.ProgressHandler, errorHandler);
                    result.Value.Body = parsedStream;

                    return Response.FromValue(result.Value.ToBlobDownloadInfo(), result.GetRawResponse());
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
        #endregion Query

        #region OpenWrite
        /// <summary>
        /// Opens a stream for writing to the blob.
        /// </summary>
        /// <param name="overwrite">
        /// Whether an existing blob should be deleted and recreated.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A stream to write to the Append Blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Stream OpenWrite(
#pragma warning restore AZC0015 // Unexpected client method return type.
            bool overwrite,
            BlockBlobOpenWriteOptions options = default,
            CancellationToken cancellationToken = default)
            => OpenWriteInternal(
                overwrite: overwrite,
                options: options,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Opens a stream for writing to the blob.  If the blob exists,
        /// it will be overwritten.
        /// </summary>
        /// <param name="overwrite">
        /// Whether an existing blob should be deleted and recreated.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A stream to write to the Append Blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Stream> OpenWriteAsync(
#pragma warning restore AZC0015 // Unexpected client method return type.
            bool overwrite,
            BlockBlobOpenWriteOptions options = default,
            CancellationToken cancellationToken = default)
            => await OpenWriteInternal(
                overwrite: overwrite,
                options: options,
                async: true,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Opens a stream for writing to the blob.  If the blob exists,
        /// it will be overwritten.
        /// </summary>
        /// <param name="overwrite">
        /// Whether an existing blob should be deleted and recreated.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A stream to write to the Append Blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Stream> OpenWriteInternal(
            bool overwrite,
            BlockBlobOpenWriteOptions options,
            bool async,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(BlockBlobClient)}.{nameof(OpenWrite)}");

            try
            {
                scope.Start();

                if (!overwrite)
                {
                    throw new ArgumentException($"{nameof(BlockBlobClient)}.{nameof(BlockBlobClient.OpenWrite)} only supports overwriting");
                }

                long position = 0;

                // Create Block Blob
                Response<BlobContentInfo> response = await UploadInternal(
                    content: new MemoryStream(Array.Empty<byte>()),
                    blobHttpHeaders: options?.HttpHeaders,
                    metadata: options?.Metadata,
                    tags: options?.Tags,
                    conditions: options?.OpenConditions,
                    accessTier: default,
                    progressHandler: default,
                    operationName: default,
                    async: async,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                BlobRequestConditions conditions = new BlobRequestConditions
                {
                    IfMatch = response.Value.ETag,
                    LeaseId = options?.OpenConditions?.LeaseId
                };

                return new BlockBlobWriteStream(
                    blockBlobClient: this,
                    bufferSize: options?.BufferSize ?? Constants.DefaultBufferSize,
                    position: position,
                    conditions: conditions,
                    progressHandler: options?.ProgressHandler,
                    blobHttpHeaders: options?.HttpHeaders,
                    metadata: options?.Metadata,
                    tags: options?.Tags);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }
        #endregion OpenWrite

        #region SyncUploadFromUri
        /// <summary>
        /// The Upload from Uri operation creates a new Block Blob where the contents of the
        /// blob are read from a given URL.  This API is supported beginning with the 2020-04-08 version.
        ///
        /// Partial updates are not supported with Put Blob from URL; the content of an existing blob is
        /// overwritten with the content of the new blob.  To perform partial updates to a block blob’s
        /// contents using a source URL, use the Put Block from URL API in conjunction with Put Block List.
        /// </summary>
        /// <param name="copySource">
        /// Required.  Specifies the URL of the source blob.  The source blob may be of any type,
        /// including a block blob, append blob, or page blob.  The value may be a URL of up to 2
        /// KiB in length that specifies a blob.  The value should be URL-encoded as it would appear
        /// in a request URI.  The source blob must either be public or must be authorized via a
        /// shared access signature.  If the source blob is public, no authorization is required
        /// to perform the operation.
        /// </param>
        /// <param name="overwrite">
        /// Whether the upload should overwrite the existing blob.  The
        /// default value is false.
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobContentInfo> SyncUploadFromUri(
            Uri copySource,
            bool overwrite = false,
            CancellationToken cancellationToken = default)
            => SyncUploadFromUriInternal(
                copySource,
                overwrite ? null : new BlobSyncUploadFromUriOptions{ DestinationConditions = new BlobRequestConditions
                    { IfNoneMatch = new ETag(Constants.Wildcard) } },
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The Upload from Uri operation creates a new Block Blob where the contents of the
        /// blob are read from a given URL.  This API is supported beginning with the 2020-04-08 version.
        ///
        /// Partial updates are not supported with Put Blob from URL; the content of an existing blob is
        /// overwritten with the content of the new blob.  To perform partial updates to a block blob’s
        /// contents using a source URL, use the Put Block from URL API in conjunction with Put Block List.
        /// </summary>
        /// <param name="copySource">
        /// Required.  Specifies the URL of the source blob.  The source blob may be of any type,
        /// including a block blob, append blob, or page blob.  The value may be a URL of up to 2
        /// KiB in length that specifies a blob.  The value should be URL-encoded as it would appear
        /// in a request URI.  The source blob must either be public or must be authorized via a
        /// shared access signature.  If the source blob is public, no authorization is required
        /// to perform the operation.
        /// </param>
        /// <param name="overwrite">
        /// Whether the upload should overwrite the existing blob.  The
        /// default value is false.
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobContentInfo>> SyncUploadFromUriAsync(
            Uri copySource,
            bool overwrite = false,
            CancellationToken cancellationToken = default)
            => await SyncUploadFromUriInternal(
                copySource,
                overwrite ? null : new BlobSyncUploadFromUriOptions { DestinationConditions = new BlobRequestConditions
                    { IfNoneMatch = new ETag(Constants.Wildcard) } },
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The Upload from Uri operation creates a new Block Blob where the contents of the
        /// blob are read from a given URL.  This API is supported beginning with the 2020-04-08 version.
        ///
        /// Partial updates are not supported with Put Blob from URL; the content of an existing blob is
        /// overwritten with the content of the new blob.  To perform partial updates to a block blob’s
        /// contents using a source URL, use the Put Block from URL API in conjunction with Put Block List.
        /// </summary>
        /// <param name="copySource">
        /// Required.  Specifies the URL of the source blob.  The source blob may be of any type,
        /// including a block blob, append blob, or page blob.  The value may be a URL of up to 2
        /// KiB in length that specifies a blob.  The value should be URL-encoded as it would appear
        /// in a request URI.  The source blob must either be public or must be authorized via a
        /// shared access signature.  If the source blob is public, no authorization is required
        /// to perform the operation.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobContentInfo> SyncUploadFromUri(
            Uri copySource,
            BlobSyncUploadFromUriOptions options,
            CancellationToken cancellationToken = default)
            => SyncUploadFromUriInternal(
                copySource,
                options,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The Upload from Uri operation creates a new Block Blob where the contents of the
        /// blob are read from a given URL.  This API is supported beginning with the 2020-04-08 version.
        ///
        /// Partial updates are not supported with Put Blob from URL; the content of an existing blob is
        /// overwritten with the content of the new blob.  To perform partial updates to a block blob’s
        /// contents using a source URL, use the Put Block from URL API in conjunction with Put Block List.
        /// </summary>
        /// <param name="copySource">
        /// Required.  Specifies the URL of the source blob.  The source blob may be of any type,
        /// including a block blob, append blob, or page blob.  The value may be a URL of up to 2
        /// KiB in length that specifies a blob.  The value should be URL-encoded as it would appear
        /// in a request URI.  The source blob must either be public or must be authorized via a
        /// shared access signature.  If the source blob is public, no authorization is required
        /// to perform the operation.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobContentInfo>> SyncUploadFromUriAsync(
            Uri copySource,
            BlobSyncUploadFromUriOptions options,
            CancellationToken cancellationToken = default)
            => await SyncUploadFromUriInternal(
                copySource,
                options,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The Upload from Uri operation creates a new Block Blob where the contents of the
        /// blob are read from a given URL.  This API is supported beginning with the 2020-04-08 version.
        ///
        /// Partial updates are not supported with Put Blob from URL; the content of an existing blob is
        /// overwritten with the content of the new blob.  To perform partial updates to a block blob’s
        /// contents using a source URL, use the Put Block from URL API in conjunction with Put Block List.
        /// </summary>
        /// <param name="copySource">
        /// Required.  Specifies the URL of the source blob.  The source blob may be of any type,
        /// including a block blob, append blob, or page blob.  The value may be a URL of up to 2
        /// KiB in length that specifies a blob.  The value should be URL-encoded as it would appear
        /// in a request URI.  The source blob must either be public or must be authorized via a
        /// shared access signature.  If the source blob is public, no authorization is required
        /// to perform the operation.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal virtual async Task<Response<BlobContentInfo>> SyncUploadFromUriInternal(
            Uri copySource,
            BlobSyncUploadFromUriOptions options,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlockBlobClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlockBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(options.HttpHeaders)}: {options?.HttpHeaders}\n" +
                    $"{nameof(options.DestinationConditions)}: {options?.DestinationConditions}");
                try
                {
                    return await BlobRestClient.BlockBlob.PutBlobFromUrlAsync(
                        clientDiagnostics: ClientDiagnostics,
                        pipeline: Pipeline,
                        resourceUri: Uri,
                        contentLength: 0,
                        version: Version.ToVersionString(),
                        copySource: copySource,
                        timeout: default,
                        transactionalContentHash: default,
                        blobContentType: options?.HttpHeaders?.ContentType,
                        blobContentEncoding: options?.HttpHeaders?.ContentEncoding,
                        blobContentLanguage: options?.HttpHeaders?.ContentLanguage,
                        blobContentHash: options?.HttpHeaders?.ContentHash,
                        blobCacheControl: options?.HttpHeaders?.CacheControl,
                        // TODO service bug.  https://github.com/Azure/azure-sdk-for-net/issues/15969
                        // metadata: options?.Metadata,
                        leaseId: options?.DestinationConditions?.LeaseId,
                        blobContentDisposition: options?.HttpHeaders?.ContentDisposition,
                        encryptionKey: CustomerProvidedKey?.EncryptionKey,
                        encryptionKeySha256: CustomerProvidedKey?.EncryptionKeyHash,
                        encryptionAlgorithm: CustomerProvidedKey?.EncryptionAlgorithm,
                        encryptionScope: EncryptionScope,
                        tier: options?.AccessTier,
                        ifModifiedSince: options?.DestinationConditions?.IfModifiedSince,
                        ifUnmodifiedSince: options?.DestinationConditions?.IfUnmodifiedSince,
                        ifMatch: options?.DestinationConditions?.IfMatch,
                        ifNoneMatch: options?.DestinationConditions?.IfNoneMatch,
                        ifTags: options?.DestinationConditions?.TagConditions,
                        sourceIfModifiedSince: options?.SourceConditions?.IfModifiedSince,
                        sourceIfUnmodifiedSince: options?.SourceConditions?.IfUnmodifiedSince,
                        sourceIfMatch: options?.SourceConditions?.IfMatch,
                        sourceIfNoneMatch: options?.SourceConditions?.IfNoneMatch,
                        sourceIfTags: options?.SourceConditions?.TagConditions,
                        requestId: default,
                        sourceContentHash: options?.ContentHash,
                        blobTagsString: options?.Tags?.ToTagsString(),
                        copySourceBlobProperties: options?.CopySourceBlobProperties,
                        async: async,
                        operationName: $"{nameof(BlockBlobClient)}.{nameof(SyncUploadFromUri)}",
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
        #endregion UploadFromUri

        #region PartitionedUploader
        internal PartitionedUploader<BlobUploadOptions, BlobContentInfo> GetPartitionedUploader(
            StorageTransferOptions transferOptions,
            ArrayPool<byte> arrayPool = null,
            string operationName = null)
            =>  new PartitionedUploader<BlobUploadOptions, BlobContentInfo>(
                GetPartitionedUploaderBehaviors(this),
                transferOptions,
                arrayPool,
                operationName);

        internal static PartitionedUploader<BlobUploadOptions, BlobContentInfo>.Behaviors GetPartitionedUploaderBehaviors(BlockBlobClient client)
        {
            return new PartitionedUploader<BlobUploadOptions, BlobContentInfo>.Behaviors
            {
                SingleUpload = async (stream, args, progressHandler, operationName, async, cancellationToken)
                    => await client.UploadInternal(
                        stream,
                        args.HttpHeaders,
                        args.Metadata,
                        args.Tags,
                        args.Conditions,
                        args.AccessTier,
                        progressHandler,
                        operationName,
                        async,
                        cancellationToken).ConfigureAwait(false),
                UploadPartition = async (stream, offset, args, progressHandler, async, cancellationToken)
                    => await client.StageBlockInternal(
                        StorageExtensions.GenerateBlockId(offset),
                        stream,
                        transactionalContentHash: default,
                        args.Conditions,
                        progressHandler,
                        async,
                        cancellationToken).ConfigureAwait(false),
                CommitPartitionedUpload = async (partitions, args, async, cancellationToken)
                    => await client.CommitBlockListInternal(
                        partitions.Select(partition => StorageExtensions.GenerateBlockId(partition.Offset)),
                        args.HttpHeaders,
                        args.Metadata,
                        args.Tags,
                        args.Conditions,
                        args.AccessTier,
                        async,
                        cancellationToken).ConfigureAwait(false),
                Scope = operationName => client.ClientDiagnostics.CreateScope(operationName
                    ?? $"{nameof(Azure)}.{nameof(Storage)}.{nameof(Blobs)}.{nameof(BlobClient)}.{nameof(BlobClient.Upload)}")
            };
        }
        #endregion
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
        /// <param name="blobName">The name of the block blob.</param>
        /// <returns>A new <see cref="BlockBlobClient"/> instance.</returns>
        public static BlockBlobClient GetBlockBlobClient(
            this BlobContainerClient client,
            string blobName)
        {
            return client.GetBlockBlobClientCore(blobName);
        }
    }
}
