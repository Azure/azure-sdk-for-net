// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized.Cryptography.Models;
using Azure.Storage.Common;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Specialized.Cryptography
{
    /// <summary>
    /// The <see cref="EncryptedBlockBlobClient"/> allows you to manipulate
    /// Azure Storage block blobs with client-side encryption. See
    /// <see cref="BlockBlobClient"/> for more details.
    /// 
    /// This class does support partial writes as a normal block blob client
    /// would. Due to the nature of this encryption algorithm, the entire blob
    /// must be reuploaded. Partial reads are still supported.
    /// </summary>
    public class EncryptedBlockBlobClient : BlobBaseClient
    {
        private readonly BlobClient _blockBlobClient;

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="EncryptedBlockBlobClient"/>
        /// class for mocking.
        /// </summary>
        protected EncryptedBlockBlobClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EncryptedBlockBlobClient"/>
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
        /// <param name="key"></param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public EncryptedBlockBlobClient(
            string connectionString,
            string containerName,
            string blobName,
            ClientSideEncryptionKey key,
            BlobClientOptions options = default)
            : base(connectionString, containerName, blobName, FluentAddPolicy(options, new ClientSideBlobDecryptionPolicy(key)))
        {
            _blockBlobClient = new BlobClient(connectionString, containerName, blobName, options);
        }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="BlockBlobClient"/>
        ///// class.
        ///// </summary>
        ///// <param name="blobUri">
        ///// A <see cref="Uri"/> referencing the encrypted block blob that includes the
        ///// name of the account, the name of the container, and the name of
        ///// the blob.
        ///// </param>
        ///// <param name="key"></param>
        ///// <param name="options">
        ///// Optional client options that define the transport pipeline
        ///// policies for authentication, retries, etc., that are applied to
        ///// every request.
        ///// </param>
        //public EncryptedBlockBlobClient(
        //    Uri blobUri,
        //    ClientSideEncryptionKey key,
        //    BlobClientOptions options = default)
        //    : base(blobUri, FluentAddPolicy(options, new ClientSideBlobDecryptionPolicy(key)))
        //{
        //    _blockBlobClient = new BlobClient(blobUri, options);
        //}

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
        /// <param name="key"></param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public EncryptedBlockBlobClient(
            Uri blobUri,
            StorageSharedKeyCredential credential,
            ClientSideEncryptionKey key,
            BlobClientOptions options = default)
            : base(blobUri, credential, FluentAddPolicy(options, new ClientSideBlobDecryptionPolicy(key)))
        {
            _blockBlobClient = new BlobClient(blobUri, credential, options);
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
        /// <param name="key"></param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public EncryptedBlockBlobClient(
            Uri blobUri,
            TokenCredential credential,
            ClientSideEncryptionKey key,
            BlobClientOptions options = default)
            : base(blobUri, credential, FluentAddPolicy(options, new ClientSideBlobDecryptionPolicy(key)))
        {
            _blockBlobClient = new BlobClient(blobUri, credential, options);
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
        internal EncryptedBlockBlobClient(Uri blobUri, HttpPipeline pipeline)
            : base(blobUri, pipeline)
        {
            //TODO make new pipeline form this one
        }

        private static BlobClientOptions FluentAddPolicy(
           BlobClientOptions options,
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
        #endregion ctors

        #region Upload

        /// <summary>
        /// The <see cref="Upload(Stream, BlobHttpHeaders?, Metadata, BlobAccessConditions?, CustomerProvidedKey?, IProgress{StorageProgress}, AccessTier?, ParallelTransferOptions, CancellationToken)"/>
        /// operation creates a new block blob or updates the content of an
        /// existing block blob.  Updating an existing block blob overwrites
        /// any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
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
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// the creation of this new block blob.
        /// </param>
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{StorageProgress}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
        /// </param>
        /// <param name="parallelTransferOptions">
        /// Optional <see cref="ParallelTransferOptions"/> to configure
        /// parallel transfer behavior.
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
        [ForwardsClientCalls]
        public virtual Response<BlobContentInfo> Upload(
            Stream content,
            BlobHttpHeaders? blobHttpHeaders = default,
            Metadata metadata = default,
            BlobAccessConditions? blobAccessConditions = default,
            CustomerProvidedKey? customerProvidedKey = default,
            IProgress<StorageProgress> progressHandler = default,
            AccessTier? accessTier = default,
            ParallelTransferOptions parallelTransferOptions = default,
            CancellationToken cancellationToken = default) =>
            this.StagedUploadAsync(
                content,
                blobHttpHeaders,
                metadata,
                blobAccessConditions,
                customerProvidedKey,
                progressHandler,
                accessTier,
                parallelTransferOptions: parallelTransferOptions,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="Upload(FileInfo, BlobHttpHeaders?, Metadata, BlobAccessConditions?, CustomerProvidedKey?, IProgress{StorageProgress}, AccessTier?, ParallelTransferOptions, CancellationToken)"/>
        /// operation creates a new block blob or updates the content of an
        /// existing block blob.  Updating an existing block blob overwrites
        /// any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="FileInfo"/> containing the content to upload.
        /// </param>
        /// <param name="blobHttpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// block blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this block blob.
        /// </param>
        /// <param name="blobAccessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// the creation of this new block blob.
        /// </param>
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{StorageProgress}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
        /// </param>
        /// <param name="parallelTransferOptions">
        /// Optional <see cref="ParallelTransferOptions"/> to configure
        /// parallel transfer behavior.
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
        [ForwardsClientCalls]
        public virtual Response<BlobContentInfo> Upload(
            FileInfo content,
            BlobHttpHeaders? blobHttpHeaders = default,
            Metadata metadata = default,
            BlobAccessConditions? blobAccessConditions = default,
            CustomerProvidedKey? customerProvidedKey = default,
            IProgress<StorageProgress> progressHandler = default,
            AccessTier? accessTier = default,
            ParallelTransferOptions parallelTransferOptions = default,
            CancellationToken cancellationToken = default) =>
            this.StagedUploadAsync(
                content,
                blobHttpHeaders,
                metadata,
                blobAccessConditions,
                customerProvidedKey,
                progressHandler,
                accessTier,
                parallelTransferOptions: parallelTransferOptions,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="UploadAsync(Stream, BlobHttpHeaders?, Metadata, BlobAccessConditions?, CustomerProvidedKey?, IProgress{StorageProgress}, AccessTier?, ParallelTransferOptions, CancellationToken)"/>
        /// operation creates a new block blob or updates the content of an
        /// existing block blob.  Updating an existing block blob overwrites
        /// any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
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
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// the creation of this new block blob.
        /// </param>
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="parallelTransferOptions">
        /// Optional <see cref="ParallelTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{StorageProgress}"/> to provide
        /// progress updates about data transfers.
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Task<Response<BlobContentInfo>> UploadAsync(
            Stream content,
            BlobHttpHeaders? blobHttpHeaders = default,
            Metadata metadata = default,
            BlobAccessConditions? blobAccessConditions = default,
            CustomerProvidedKey? customerProvidedKey = default,
            IProgress<StorageProgress> progressHandler = default,
            AccessTier? accessTier = default,
            ParallelTransferOptions parallelTransferOptions = default,
            CancellationToken cancellationToken = default) =>
            this.StagedUploadAsync(
                content,
                blobHttpHeaders,
                metadata,
                blobAccessConditions,
                customerProvidedKey,
                progressHandler,
                accessTier,
                parallelTransferOptions: parallelTransferOptions,
                async: true,
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="UploadAsync(FileInfo, BlobHttpHeaders?, Metadata, BlobAccessConditions?, CustomerProvidedKey?, IProgress{StorageProgress}, AccessTier?, ParallelTransferOptions, CancellationToken)"/>
        /// operation creates a new block blob or updates the content of an
        /// existing block blob.  Updating an existing block blob overwrites
        /// any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="FileInfo"/> containing the content to upload.
        /// </param>
        /// <param name="blobHttpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// block blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this block blob.
        /// </param>
        /// <param name="blobAccessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// the creation of this new block blob.
        /// </param>
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{StorageProgress}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
        /// </param>
        /// <param name="parallelTransferOptions">
        /// Optional <see cref="ParallelTransferOptions"/> to configure
        /// parallel transfer behavior.
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
        [ForwardsClientCalls]
        public virtual Task<Response<BlobContentInfo>> UploadAsync(
            FileInfo content,
            BlobHttpHeaders? blobHttpHeaders = default,
            Metadata metadata = default,
            BlobAccessConditions? blobAccessConditions = default,
            CustomerProvidedKey? customerProvidedKey = default,
            IProgress<StorageProgress> progressHandler = default,
            AccessTier? accessTier = default,
            ParallelTransferOptions parallelTransferOptions = default,
            CancellationToken cancellationToken = default) =>
            this.StagedUploadAsync(
                content,
                blobHttpHeaders,
                metadata,
                blobAccessConditions,
                customerProvidedKey,
                progressHandler,
                accessTier,
                parallelTransferOptions: parallelTransferOptions,
                async: true,
                cancellationToken: cancellationToken);

        /// <summary>
        /// This operation will create a new
        /// block blob of arbitrary size by uploading it as indiviually staged
        /// blocks if it's larger than the
        /// <paramref name="singleBlockThreshold"/>.
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
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// the creation of this new block blob.
        /// </param>
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{StorageProgress}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
        /// </param>
        /// <param name="singleBlockThreshold">
        /// The maximum size stream that we'll upload as a single block.  The
        /// default value is 256MB.
        /// </param>
        /// <param name="parallelTransferOptions">
        /// Optional <see cref="ParallelTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="async">
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
        internal async Task<Response<BlobContentInfo>> StagedUploadAsync(
            Stream content,
            BlobHttpHeaders? blobHttpHeaders,
            Metadata metadata,
            BlobAccessConditions? blobAccessConditions,
            CustomerProvidedKey? customerProvidedKey,
            IProgress<StorageProgress> progressHandler,
            AccessTier? accessTier = default,
            long singleBlockThreshold = BlockBlobClient.BlockBlobMaxUploadBlobBytes,
            ParallelTransferOptions parallelTransferOptions = default,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            Debug.Assert(singleBlockThreshold <= BlockBlobClient.BlockBlobMaxUploadBlobBytes);

            content = this.EncryptStream(content);

            var client = new BlockBlobClient(this.Uri, this.Pipeline);
            var blockMap = new ConcurrentDictionary<long, string>();
            var blockName = 0;
            var uploadTask = PartitionedUploader.UploadAsync(
                UploadStreamAsync,
                StageBlockAsync,
                CommitBlockListAsync,
                threshold => TryGetStreamLength(content, out var length) && length < threshold,
                memoryPool => new StreamPartitioner(content, memoryPool),
                singleBlockThreshold,
                parallelTransferOptions,
                async,
                cancellationToken);
            return async ?
                await uploadTask.ConfigureAwait(false) :
                uploadTask.EnsureCompleted();

            bool TryGetStreamLength(Stream stream, out long length)
            {
                length = 0;
                try
                {
                    length = stream.Length;
                    return true;
                }
                catch
                {
                }
                return false;
            }

            // Upload the entire stream
            Task<Response<BlobContentInfo>> UploadStreamAsync()
                =>
                client.UploadInternal(
                    content,
                    blobHttpHeaders,
                    metadata,
                    blobAccessConditions,
                    customerProvidedKey,
                    accessTier,
                    progressHandler,
                    async,
                    cancellationToken);

            string GetNewBase64BlockId(long blockOrdinal)
            {
                // Create and record a new block ID, storing the order information 
                // (nominally the block's start position in the original stream)

                var newBlockName = Interlocked.Increment(ref blockName);
                var blockId = Constants.BlockNameFormat;
                blockId = String.Format(CultureInfo.InvariantCulture, blockId, newBlockName);
                blockId = Convert.ToBase64String(Encoding.UTF8.GetBytes(blockId));
                var success = blockMap.TryAdd(blockOrdinal, blockId);

                Debug.Assert(success);

                return blockId;
            }

            // Upload a single partition of the stream
            Task<Response<BlockInfo>> StageBlockAsync(
                Stream partition,
                long blockOrdinal,
                bool async,
                CancellationToken cancellation)
            {
                var base64BlockId = GetNewBase64BlockId(blockOrdinal);

                //var bytes = new byte[10];
                //partition.Read(bytes, 0, 10);
                partition.Position = 0;
                //Console.WriteLine($"Commiting partition {blockOrdinal} => {base64BlockId}, {String.Join(" ", bytes)}");

                // Upload the block
                return client.StageBlockInternal(
                    base64BlockId,
                    partition,
                    null,
                    blobAccessConditions?.LeaseAccessConditions,
                    customerProvidedKey,
                    progressHandler,
                    async,
                    cancellationToken);
            }

            // Commit a series of partitions
            Task<Response<BlobContentInfo>> CommitBlockListAsync(
                bool async,
                CancellationToken cancellation)
            {
                var base64BlockIds = blockMap.OrderBy(kvp => kvp.Key).Select(kvp => kvp.Value).ToArray();
                //Console.WriteLine($"Commiting block list:\n{String.Join("\n", base64BlockIds)}");

                return
                    client.CommitBlockListInternal(
                        base64BlockIds,
                        blobHttpHeaders,
                        metadata,
                        blobAccessConditions,
                        customerProvidedKey,
                        accessTier,
                        async,
                        cancellationToken);
            }
        }

        /// <summary>
        /// This operation will create a new
        /// block blob of arbitrary size by uploading it as indiviually staged
        /// blocks if it's larger than the
        /// <paramref name="singleBlockThreshold"/>.
        /// </summary>
        /// <param name="file">
        /// A <see cref="FileInfo"/> of the file to upload.
        /// </param>
        /// <param name="blobHttpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// block blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this block blob.
        /// </param>
        /// <param name="blobAccessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// the creation of this new block blob.
        /// </param>
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{StorageProgress}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
        /// </param>
        /// <param name="singleBlockThreshold">
        /// The maximum size stream that we'll upload as a single block.  The
        /// default value is 256MB.
        /// </param>
        /// <param name="parallelTransferOptions">
        /// Optional <see cref="ParallelTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="async">
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
        internal async Task<Response<BlobContentInfo>> StagedUploadAsync(
            FileInfo file,
            BlobHttpHeaders? blobHttpHeaders,
            Metadata metadata,
            BlobAccessConditions? blobAccessConditions,
            CustomerProvidedKey? customerProvidedKey,
            IProgress<StorageProgress> progressHandler,
            AccessTier? accessTier = default,
            long singleBlockThreshold = BlockBlobClient.BlockBlobMaxUploadBlobBytes,
            ParallelTransferOptions parallelTransferOptions = default,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            using (var content = file.OpenRead())
            {
                return await StagedUploadAsync(
                    content,
                    blobHttpHeaders,
                    metadata,
                    blobAccessConditions,
                    customerProvidedKey,
                    progressHandler,
                    accessTier,
                    singleBlockThreshold,
                    parallelTransferOptions,
                    async,
                    cancellationToken).ConfigureAwait(false);
            }
        }
        #endregion Upload

        private Stream EncryptStream(Stream plaintext, byte[] keyEncryptionKey, out EncryptionData encryptionData)
        {
            var generatedKey = CreateKey(EncryptionConstants.ENCRYPTION_KEY_SIZE);

            using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider() { Key = generatedKey })
            {
                encryptionData = new EncryptionData()
                {
                    EncryptionMode = "FullBlob",
                    ContentEncryptionIV = aesProvider.IV,
                    EncryptionAgent = new EncryptionAgent()
                    {
                        Algorithm = ClientsideEncryptionAlgorithm.AES_CBC_256,
                        Protocol = EncryptionConstants.ENCRYPTION_PROTOCOL_V1
                    },
                    KeyWrappingMetadata = new Dictionary<string, string>()
                    {
                        { EncryptionConstants.AGENT_METADATA_KEY, EncryptionConstants.AGENT_METADATA_VALUE }
                    },
                    WrappedContentKey = new WrappedKey()
                    {
                        Algorithm = null, // TODO
                        EncryptedKey = null, // TODO
                        KeyId = null // TODO
                    }
                };

                return new CryptoStream(plaintext, aesProvider.CreateEncryptor(), CryptoStreamMode.Write);
            }
        }

        /// <summary>
        /// Securely generate a key.
        /// </summary>
        /// <param name="numBytes">Key size.</param>
        /// <returns>The generated key bytes.</returns>
        private static byte[] CreateKey(int numBytes)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var buff = new byte[numBytes];
                rng.GetBytes(buff);
                return buff;
            }
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
