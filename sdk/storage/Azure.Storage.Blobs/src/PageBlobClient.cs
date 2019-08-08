﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.IO;
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
    /// The <see cref="PageBlobClient"/> allows you to manipulate Azure
    /// Storage page blobs.
    ///
    /// Page blobs are a collection of 512-byte pages optimized for random
    /// read and write operations. To create a page blob, you initialize the
    /// page blob and specify the maximum size the page blob will grow. To add
    /// or update the contents of a page blob, you write a page or pages by
    /// specifying an offset and a range that align to 512-byte page
    /// boundaries.  A write to a page blob can overwrite just one page, some
    /// pages, or up to 4 MB of the page blob.  Writes to page blobs happen
    /// in-place and are immediately committed to the blob. The maximum size
    /// for a page blob is 8 TB.
    /// </summary>
    public class PageBlobClient : BlobBaseClient
    {
        /// <summary>
        /// <see cref="PageBlobPageBytes"/> indicates the number of bytes in a
        /// page (512).
        /// </summary>
		public const int PageBlobPageBytes = 512;

        /// <summary>
        /// <see cref="PageBlobMaxUploadPagesBytes"/> indicates the maximum
        /// number of bytes that can be sent in a call to the
        /// <see cref="UploadPagesAsync"/> operation.
        /// </summary>
        public const int PageBlobMaxUploadPagesBytes = 4 * Constants.MB; // 4MB

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="PageBlobClient"/>
        /// class for mocking.
        /// </summary>
        protected PageBlobClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageBlobClient"/>
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
        /// The name of the container containing this page blob.
        /// </param>
        /// <param name="blobName">
        /// The name of this page blob.
        /// </param>
        public PageBlobClient(string connectionString, string containerName, string blobName)
            : base(connectionString, containerName, blobName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageBlobClient"/>
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
        /// The name of the container containing this page blob.
        /// </param>
        /// <param name="blobName">
        /// The name of this page blob.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public PageBlobClient(string connectionString, string containerName, string blobName, BlobClientOptions options)
            : base(connectionString, containerName, blobName, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the page blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public PageBlobClient(Uri blobUri, BlobClientOptions options = default)
            : base(blobUri, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the page blob that includes the
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
        public PageBlobClient(Uri blobUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            : base(blobUri, credential, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the page blob that includes the
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
        public PageBlobClient(Uri blobUri, TokenCredential credential, BlobClientOptions options = default)
            : base(blobUri, credential, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the page blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        internal PageBlobClient(Uri blobUri, HttpPipeline pipeline)
            : base(blobUri, pipeline)
        {
        }
        #endregion ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="PageBlobClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// snapshot timestamp.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/creating-a-snapshot-of-a-blob" />.
        /// </summary>
        /// <param name="snapshot">The snapshot identifier.</param>
        /// <returns>A new <see cref="PageBlobClient"/> instance.</returns>
        /// <remarks>
        /// Pass null or empty string to remove the snapshot returning a URL
        /// to the base blob.
        /// </remarks>
        public new PageBlobClient WithSnapshot(string snapshot) => (PageBlobClient)this.WithSnapshotImpl(snapshot);

        /// <summary>
        /// Creates a new instance of the <see cref="PageBlobClient"/> class
        /// with an identical <see cref="Uri"/> source but the specified
        /// snapshot timestamp.
        /// </summary>
        /// <param name="snapshot">The snapshot identifier.</param>
        /// <returns>A new <see cref="PageBlobClient"/> instance.</returns>
        protected sealed override BlobBaseClient WithSnapshotImpl(string snapshot)
        {
            var builder = new BlobUriBuilder(this.Uri) { Snapshot = snapshot };
            return new PageBlobClient(builder.ToUri(), this.Pipeline);
        }

        ///// <summary>
        ///// Creates a new PageBlobClient object identical to the source but with the specified version ID.
        ///// Pass "" to remove the version ID returning a URL to the base blob.
        ///// </summary>
        ///// <param name="versionId">version ID</param>
        ///// <returns></returns>
        //public new PageBlobClient WithVersionId(string versionId) => (PageBlobUri)this.WithVersionIdImpl(versionId);

        //protected sealed override BlobBaseClient WithVersionIdImpl(string versionId)
        //{
        //    var builder = new BlobUriBuilder(this.Uri) { VersionId = versionId };
        //    return new PageBlobClient(builder.ToUri(), this.Pipeline);
        //}

        #region Create
        /// <summary>
        /// The <see cref="Create"/> operation creates a new page blob of
        /// the specified <paramref name="size"/>.  The content of any
        /// existing blob is overwritten with the newly initialized page blob
        /// To add content to the page blob, call the
        /// <see cref="UploadPages"/> operation.
        ///
        /// For more information, see https://docs.microsoft.com/rest/api/storageservices/put-blob.
        /// </summary>
        /// <param name="size">
        /// Specifies the maximum size for the page blob, up to 8 TB.  The
        /// size must be aligned to a 512-byte boundary.
        /// </param>
        /// <param name="sequenceNumber">
        /// Optional user-controlled value that you can use to track requests.
        /// The value of the <paramref name="sequenceNumber"/> must be between
        /// 0 and 2^63 - 1.  The default value is 0.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new page blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this page blob.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add
        /// conditions on the creation of this new page blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// newly created page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobContentInfo> Create(
            long size,
            long? sequenceNumber = default,
            BlobHttpHeaders? httpHeaders = default,
            Metadata metadata = default,
            PageBlobAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default) =>
            this.CreateInternal(
                size,
                sequenceNumber,
                httpHeaders,
                metadata,
                accessConditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="CreateAsync"/> operation creates a new page blob of
        /// the specified <paramref name="size"/>.  The content of any
        /// existing blob is overwritten with the newly initialized page blob
        /// To add content to the page blob, call the
        /// <see cref="UploadPagesAsync"/> operation.
        ///
        /// For more information, see https://docs.microsoft.com/rest/api/storageservices/put-blob.
        /// </summary>
        /// <param name="size">
        /// Specifies the maximum size for the page blob, up to 8 TB.  The
        /// size must be aligned to a 512-byte boundary.
        /// </param>
        /// <param name="sequenceNumber">
        /// Optional user-controlled value that you can use to track requests.
        /// The value of the <paramref name="sequenceNumber"/> must be between
        /// 0 and 2^63 - 1.  The default value is 0.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new page blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this page blob.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add
        /// conditions on the creation of this new page blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// newly created page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobContentInfo>> CreateAsync(
            long size,
            long? sequenceNumber = default,
            BlobHttpHeaders? httpHeaders = default,
            Metadata metadata = default,
            PageBlobAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default) =>
            await this.CreateInternal(
                size,
                sequenceNumber,
                httpHeaders,
                metadata,
                accessConditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CreateInternal"/> operation creates a new page blob
        /// of the specified <paramref name="size"/>.  The content of any
        /// existing blob is overwritten with the newly initialized page blob
        /// To add content to the page blob, call the
        /// <see cref="UploadPagesAsync"/> operation.
        ///
        /// For more information, see https://docs.microsoft.com/rest/api/storageservices/put-blob.
        /// </summary>
        /// <param name="size">
        /// Specifies the maximum size for the page blob, up to 8 TB.  The
        /// size must be aligned to a 512-byte boundary.
        /// </param>
        /// <param name="sequenceNumber">
        /// Optional user-controlled value that you can use to track requests.
        /// The value of the <paramref name="sequenceNumber"/> must be between
        /// 0 and 2^63 - 1.  The default value is 0.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new page blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this page blob.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add
        /// conditions on the creation of this new page blob.
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
        /// newly created page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobContentInfo>> CreateInternal(
            long size,
            long? sequenceNumber,
            BlobHttpHeaders? httpHeaders,
            Metadata metadata,
            PageBlobAccessConditions? accessConditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(PageBlobClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(PageBlobClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(size)}: {size}\n" +
                    $"{nameof(sequenceNumber)}: {sequenceNumber}\n" +
                    $"{nameof(httpHeaders)}: {httpHeaders}");
                try
                {
                    return await BlobRestClient.PageBlob.CreateAsync(
                        this.Pipeline,
                        this.Uri,
                        contentLength: default,
                        blobContentType: httpHeaders?.ContentType,
                        blobContentEncoding: httpHeaders?.ContentEncoding,
                        blobContentLanguage: httpHeaders?.ContentLanguage,
                        blobContentHash: httpHeaders?.ContentHash,
                        blobCacheControl: httpHeaders?.CacheControl,
                        metadata: metadata,
                        leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                        blobContentDisposition: httpHeaders?.ContentDisposition,
                        ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        ifMatch: accessConditions?.HttpAccessConditions?.IfMatch,
                        ifNoneMatch: accessConditions?.HttpAccessConditions?.IfNoneMatch,
                        blobContentLength: size,
                        blobSequenceNumber: sequenceNumber,
                        async: async,
                        operationName: "Azure.Storage.Blobs.Specialized.PageBlobClient.Create",
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(PageBlobClient));
                }
            }
        }
        #endregion Create

        #region UploadPages
        /// <summary>
        /// The <see cref="UploadPages"/> operation writes
        /// <paramref name="content"/> to a range of pages in a page blob,
        /// starting at <paramref name="offset"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-page" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the pages to
        /// upload.  The content can be up to 4 MB in size.
        /// </param>
        /// <param name="offset">
        /// Specifies the starting offset for the <paramref name="content"/>
        /// to be written as a page.  Given that pages must be aligned with
        /// 512-byte boundaries, the start offset must be a modulus of 512.
        /// </param>
        /// <param name="transactionalContentHash">
        /// Optional MD5 hash of the block content.  This hash is used to
        /// verify the integrity of the block during transport. When this hash
        /// is specified, the storage service compares the hash of the content
        /// that has arrived with this value.  Note that this MD5 hash is not
        /// stored with the blob.  If the two hashes do not match, the
        /// operation will fail with a <see cref="StorageRequestFailedException"/>.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add
        /// conditions on uploading pages to this page blob.
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
        /// A <see cref="Response{PageInfo}"/> describing the
        /// state of the updated pages.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<PageInfo> UploadPages(
            Stream content,
            long offset,
            byte[] transactionalContentHash = default,
            PageBlobAccessConditions? accessConditions = default,
            IProgress<StorageProgress> progressHandler = default,
            CancellationToken cancellationToken = default) =>
            this.UploadPagesInternal(
                content,
                offset,
                transactionalContentHash,
                accessConditions,
                progressHandler,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="UploadPagesAsync"/> operation writes
        /// <paramref name="content"/> to a range of pages in a page blob,
        /// starting at <paramref name="offset"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-page" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the pages to
        /// upload.  The content can be up to 4 MB in size.
        /// </param>
        /// <param name="offset">
        /// Specifies the starting offset for the <paramref name="content"/>
        /// to be written as a page.  Given that pages must be aligned with
        /// 512-byte boundaries, the start offset must be a modulus of 512.
        /// </param>
        /// <param name="transactionalContentHash">
        /// Optional MD5 hash of the block content.  This hash is used to
        /// verify the integrity of the block during transport. When this hash
        /// is specified, the storage service compares the hash of the content
        /// that has arrived with this value.  Note that this MD5 hash is not
        /// stored with the blob.  If the two hashes do not match, the
        /// operation will fail with a <see cref="StorageRequestFailedException"/>.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add
        /// conditions on uploading pages to this page blob.
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
        /// A <see cref="Response{PageInfo}"/> describing the
        /// state of the updated pages.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<PageInfo>> UploadPagesAsync(
            Stream content,
            long offset,
            byte[] transactionalContentHash = default,
            PageBlobAccessConditions? accessConditions = default,
            IProgress<StorageProgress> progressHandler = default,
            CancellationToken cancellationToken = default) =>
            await this.UploadPagesInternal(
                content,
                offset,
                transactionalContentHash,
                accessConditions,
                progressHandler,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UploadPagesInternal"/> operation writes
        /// <paramref name="content"/> to a range of pages in a page blob,
        /// starting at <paramref name="offset"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-page" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the pages to
        /// upload.  The content can be up to 4 MB in size.
        /// </param>
        /// <param name="offset">
        /// Specifies the starting offset for the <paramref name="content"/>
        /// to be written as a page.  Given that pages must be aligned with
        /// 512-byte boundaries, the start offset must be a modulus of 512.
        /// </param>
        /// <param name="transactionalContentHash">
        /// Optional MD5 hash of the block content.  This hash is used to
        /// verify the integrity of the block during transport. When this hash
        /// is specified, the storage service compares the hash of the content
        /// that has arrived with this value.  Note that this MD5 hash is not
        /// stored with the blob.  If the two hashes do not match, the
        /// operation will fail with a <see cref="StorageRequestFailedException"/>.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add
        /// conditions on uploading pages to this page blob.
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
        /// A <see cref="Response{PageInfo}"/> describing the
        /// state of the updated pages.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<PageInfo>> UploadPagesInternal(
            Stream content,
            long offset,
            byte[] transactionalContentHash,
            PageBlobAccessConditions? accessConditions,
            IProgress<StorageProgress> progressHandler,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(PageBlobClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(PageBlobClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(offset)}: {offset}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    content = content.WithNoDispose().WithProgress(progressHandler);
                    var range = new HttpRange(offset, content.Length);
                    var uploadAttempt = 0;
                    return await ReliableOperation.DoSyncOrAsync(
                        async,
                        reset: () => content.Seek(0, SeekOrigin.Begin),
                        predicate: e => true,
                        maximumRetries: Constants.MaxReliabilityRetries,
                        operation:
                            () =>
                            {
                                this.Pipeline.LogTrace($"Upload attempt {++uploadAttempt}");
                                return BlobRestClient.PageBlob.UploadPagesAsync(
                                    this.Pipeline,
                                    this.Uri,
                                    body: content,
                                    contentLength: content.Length,
                                    transactionalContentHash: transactionalContentHash,
                                    timeout: default,
                                    range: range.ToString(),
                                    leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                                    ifSequenceNumberLessThanOrEqualTo: accessConditions?.IfSequenceNumberLessThanOrEqual,
                                    ifSequenceNumberLessThan: accessConditions?.IfSequenceNumberLessThan,
                                    ifSequenceNumberEqualTo: accessConditions?.IfSequenceNumberEqual,
                                    ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                                    ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                                    ifMatch: accessConditions?.HttpAccessConditions?.IfMatch,
                                    ifNoneMatch: accessConditions?.HttpAccessConditions?.IfNoneMatch,
                                    async: async,
                                    operationName: "Azure.Storage.Blobs.Specialized.PageBlobClient.UploadPages",
                                    cancellationToken: cancellationToken);
                            },
                        cleanup: () => { })
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(PageBlobClient));
                }
            }
        }
        #endregion UploadPages

        #region ClearPages
        /// <summary>
        /// The <see cref="ClearPages"/> operation clears one or more
        /// pages from the page blob, as specificed by the <paramref name="range"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-page" />.
        /// </summary>
        /// <param name="range">
        /// Specifies the range of bytes to be cleared. Both the start and
        /// end of the range must be specified.  For a page clear operation,
        /// the page range can be up to the value of the blob's full size.
        /// Given that pages must be aligned with 512-byte boundaries, the
        /// start of the range must be a modulus of 512 and the end of the
        /// range must be a modulus of 512 – 1.  Examples of valid byte ranges
        /// are 0-511, 512-1023, etc.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add
        /// conditions on clearing pages from this page blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageInfo}"/> describing the
        /// state of the updated pages.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<PageInfo> ClearPages(
            HttpRange range,
            PageBlobAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default) =>
            this.ClearPagesInternal(
                range,
                accessConditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="ClearPagesAsync"/> operation clears one or more
        /// pages from the page blob, as specificed by the <paramref name="range"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-page" />.
        /// </summary>
        /// <param name="range">
        /// Specifies the range of bytes to be cleared. Both the start and
        /// end of the range must be specified.  For a page clear operation,
        /// the page range can be up to the value of the blob's full size.
        /// Given that pages must be aligned with 512-byte boundaries, the
        /// start of the range must be a modulus of 512 and the end of the
        /// range must be a modulus of 512 – 1.  Examples of valid byte ranges
        /// are 0-511, 512-1023, etc.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add
        /// conditions on clearing pages from this page blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageInfo}"/> describing the
        /// state of the updated pages.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<PageInfo>> ClearPagesAsync(
            HttpRange range,
            PageBlobAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default) =>
            await this.ClearPagesInternal(
                range,
                accessConditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="ClearPagesInternal"/> operation clears one or more
        /// pages from the page blob, as specificed by the <paramref name="range"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-page" />.
        /// </summary>
        /// <param name="range">
        /// Specifies the range of bytes to be cleared. Both the start and
        /// end of the range must be specified.  For a page clear operation,
        /// the page range can be up to the value of the blob's full size.
        /// Given that pages must be aligned with 512-byte boundaries, the
        /// start of the range must be a modulus of 512 and the end of the
        /// range must be a modulus of 512 – 1.  Examples of valid byte ranges
        /// are 0-511, 512-1023, etc.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add
        /// conditions on clearing pages from this page blob.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageInfo}"/> describing the
        /// state of the updated pages.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<PageInfo>> ClearPagesInternal(
            HttpRange range,
            PageBlobAccessConditions? accessConditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(PageBlobClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(PageBlobClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    return await BlobRestClient.PageBlob.ClearPagesAsync(
                        this.Pipeline,
                        this.Uri,
                        contentLength: default,
                        range: range.ToString(),
                        leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                        ifSequenceNumberLessThanOrEqualTo: accessConditions?.IfSequenceNumberLessThanOrEqual,
                        ifSequenceNumberLessThan: accessConditions?.IfSequenceNumberLessThan,
                        ifSequenceNumberEqualTo: accessConditions?.IfSequenceNumberEqual,
                        ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        ifMatch: accessConditions?.HttpAccessConditions?.IfMatch,
                        ifNoneMatch: accessConditions?.HttpAccessConditions?.IfNoneMatch,
                        async: async,
                        operationName: "Azure.Storage.Blobs.Specialized.PageBlobClient.ClearPages",
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(PageBlobClient));
                }
            }
        }
        #endregion ClearPages

        #region GetPageRanges
        /// <summary>
        /// The <see cref="GetPageRanges"/> operation returns the list of
        /// valid page ranges for a page blob or snapshot of a page blob.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-page-ranges" />.
        /// </summary>
        /// <param name="range">
        /// Optionally specifies the range of bytes over which to list ranges,
        /// inclusively. If omitted, then all ranges for the blob are returned.
        /// </param>
        /// <param name="snapshot">
        /// Optionally specifies the blob snapshot to retrieve page ranges
        /// information from. For more information on working with blob snapshots,
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/creating-a-snapshot-of-a-blob"/>.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add
        /// conditions on getting page ranges for the this blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageRangesInfo}"/> describing the
        /// valid page ranges for this blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<PageRangesInfo> GetPageRanges(
            HttpRange? range = default,
            string snapshot = default,
            PageBlobAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default) =>
            this.GetPageRangesInternal(
                range,
                snapshot,
                accessConditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetPageRangesAsync"/> operation returns the list of
        /// valid page ranges for a page blob or snapshot of a page blob.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-page-ranges" />.
        /// </summary>
        /// <param name="range">
        /// Optionally specifies the range of bytes over which to list ranges,
        /// inclusively. If omitted, then all ranges for the blob are returned.
        /// </param>
        /// <param name="snapshot">
        /// Optionally specifies the blob snapshot to retrieve page ranges
        /// information from. For more information on working with blob snapshots,
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/creating-a-snapshot-of-a-blob"/>.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add
        /// conditions on getting page ranges for the this blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageRangesInfo}"/> describing the
        /// valid page ranges for this blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<PageRangesInfo>> GetPageRangesAsync(
            HttpRange? range = default,
            string snapshot = default,
            PageBlobAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default) =>
            await this.GetPageRangesInternal(
                range,
                snapshot,
                accessConditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetPageRangesInternal"/> operation returns the list
        /// of valid page ranges for a page blob or snapshot of a page blob.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-page-ranges" />.
        /// </summary>
        /// <param name="range">
        /// Optionally specifies the range of bytes over which to list ranges,
        /// inclusively. If omitted, then all ranges for the blob are returned.
        /// </param>
        /// <param name="snapshot">
        /// Optionally specifies the blob snapshot to retrieve page ranges
        /// information from. For more information on working with blob snapshots,
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/creating-a-snapshot-of-a-blob"/>.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add
        /// conditions on getting page ranges for the this blob.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageRangesInfo}"/> describing the
        /// valid page ranges for this blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<PageRangesInfo>> GetPageRangesInternal(
            HttpRange? range,
            string snapshot,
            PageBlobAccessConditions? accessConditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(PageBlobClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(PageBlobClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(snapshot)}: {snapshot}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    return await BlobRestClient.PageBlob.GetPageRangesAsync(
                        this.Pipeline,
                        this.Uri,
                        snapshot: snapshot,
                        range: range?.ToString(),
                        leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                        ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        ifMatch: accessConditions?.HttpAccessConditions?.IfMatch,
                        ifNoneMatch: accessConditions?.HttpAccessConditions?.IfNoneMatch,
                        async: async,
                        operationName: "Azure.Storage.Blobs.Specialized.PageBlobClient.GetPageRanges",
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(PageBlobClient));
                }
            }
        }
        #endregion GetPageRanges

        #region GetPageRangesDiff
        /// <summary>
        /// The <see cref="GetPageRangesDiff"/> operation returns the
        /// list of page ranges that differ between a
        /// <paramref name="previousSnapshot"/> and this page blob. Changed pages
        /// include both updated and cleared pages.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-page-ranges" />.
        /// </summary>
        /// <param name="range">
        /// Optionally specifies the range of bytes over which to list ranges,
        /// inclusively. If omitted, then all ranges for the blob are returned.
        /// </param>
        /// <param name="snapshot">
        /// Optionally specifies the blob snapshot to retrieve page ranges
        /// information from. For more information on working with blob snapshots,
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/creating-a-snapshot-of-a-blob"/>.
        /// </param>
        /// <param name="previousSnapshot">
        /// Specifies that the response will contain only pages that were
        /// changed between target blob and previous snapshot.  Changed pages
        /// include both updated and cleared pages. The target blob may be a
        /// snapshot, as long as the snapshot specified by
        /// <paramref name="previousSnapshot"/> is the older of the two.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add
        /// conditions on getting page ranges for the this blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageRangesInfo}"/> describing the
        /// valid page ranges for this blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<PageRangesInfo> GetPageRangesDiff(
            HttpRange? range = default,
            string snapshot = default,
            string previousSnapshot = default,
            PageBlobAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default) =>
            this.GetPageRangesDiffInternal(
                range,
                snapshot,
                previousSnapshot,
                accessConditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetPageRangesDiffAsync"/> operation returns the
        /// list of page ranges that differ between a
        /// <paramref name="previousSnapshot"/> and this page blob. Changed pages
        /// include both updated and cleared pages.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-page-ranges" />.
        /// </summary>
        /// <param name="range">
        /// Optionally specifies the range of bytes over which to list ranges,
        /// inclusively. If omitted, then all ranges for the blob are returned.
        /// </param>
        /// <param name="snapshot">
        /// Optionally specifies the blob snapshot to retrieve page ranges
        /// information from. For more information on working with blob snapshots,
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/creating-a-snapshot-of-a-blob"/>.
        /// </param>
        /// <param name="previousSnapshot">
        /// Specifies that the response will contain only pages that were
        /// changed between target blob and previous snapshot.  Changed pages
        /// include both updated and cleared pages. The target blob may be a
        /// snapshot, as long as the snapshot specified by
        /// <paramref name="previousSnapshot"/> is the older of the two.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add
        /// conditions on getting page ranges for the this blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageRangesInfo}"/> describing the
        /// valid page ranges for this blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<PageRangesInfo>> GetPageRangesDiffAsync(
            HttpRange? range = default,
            string snapshot = default,
            string previousSnapshot = default,
            PageBlobAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default) =>
            await this.GetPageRangesDiffInternal(
                range,
                snapshot,
                previousSnapshot,
                accessConditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetPageRangesDiffInternal"/> operation returns the
        /// list of page ranges that differ between a
        /// <paramref name="previousSnapshot"/> and this page blob. Changed pages
        /// include both updated and cleared pages.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-page-ranges" />.
        /// </summary>
        /// <param name="range">
        /// Optionally specifies the range of bytes over which to list ranges,
        /// inclusively. If omitted, then all ranges for the blob are returned.
        /// </param>
        /// <param name="snapshot">
        /// Optionally specifies the blob snapshot to retrieve page ranges
        /// information from. For more information on working with blob snapshots,
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/creating-a-snapshot-of-a-blob"/>.
        /// </param>
        /// <param name="previousSnapshot">
        /// Specifies that the response will contain only pages that were
        /// changed between target blob and previous snapshot.  Changed pages
        /// include both updated and cleared pages. The target blob may be a
        /// snapshot, as long as the snapshot specified by
        /// <paramref name="previousSnapshot"/> is the older of the two.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add
        /// conditions on getting page ranges for the this blob.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageRangesInfo}"/> describing the
        /// valid page ranges for this blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<PageRangesInfo>> GetPageRangesDiffInternal(
            HttpRange? range,
            string snapshot,
            string previousSnapshot,
            PageBlobAccessConditions? accessConditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(PageBlobClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(PageBlobClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(snapshot)}: {snapshot}\n" +
                    $"{nameof(previousSnapshot)}: {previousSnapshot}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    return await BlobRestClient.PageBlob.GetPageRangesDiffAsync(
                        this.Pipeline,
                        this.Uri,
                        snapshot: snapshot,
                        prevsnapshot: previousSnapshot,
                        range: range?.ToString(),
                        leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                        ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        ifMatch: accessConditions?.HttpAccessConditions?.IfMatch,
                        ifNoneMatch: accessConditions?.HttpAccessConditions?.IfNoneMatch,
                        async: async,
                        operationName: "Azure.Storage.Blobs.Specialized.PageBlobClient.GetPageRangesDiff",
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(PageBlobClient));
                }
            }
        }
        #endregion GetPageRangesDiff

        #region Resize
        /// <summary>
        /// The <see cref="Resize"/> operation resizes the page blob to
        /// the specified size (which must be a multiple of 512).  If the
        /// specified value is less than the current size of the blob, then
        /// all pages above the specified value are cleared.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-properties" />.
        /// </summary>
        /// <param name="size">
        /// Specifies the maximum size for the page blob, up to 8 TB.  The
        /// size must be aligned to a 512-byte boundary.  If the specified
        /// value is less than the current size of the blob, then all pages
        /// above the specified value are cleared.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add
        /// conditions on the resize of this page blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageBlobInfo}"/> describing the resized
        /// page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<PageBlobInfo> Resize(
            long size,
            PageBlobAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default) =>
            this.ResizeInternal(
                size,
                accessConditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="ResizeAsync"/> operation resizes the page blob to
        /// the specified size (which must be a multiple of 512).  If the
        /// specified value is less than the current size of the blob, then
        /// all pages above the specified value are cleared.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-properties" />.
        /// </summary>
        /// <param name="size">
        /// Specifies the maximum size for the page blob, up to 8 TB.  The
        /// size must be aligned to a 512-byte boundary.  If the specified
        /// value is less than the current size of the blob, then all pages
        /// above the specified value are cleared.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add
        /// conditions on the resize of this page blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageBlobInfo}"/> describing the resized
        /// page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<PageBlobInfo>> ResizeAsync(
            long size,
            PageBlobAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default) =>
            await this.ResizeInternal(
                size,
                accessConditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="ResizeAsync"/> operation resizes the page blob to
        /// the specified size (which must be a multiple of 512).  If the
        /// specified value is less than the current size of the blob, then
        /// all pages above the specified value are cleared.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-properties" />.
        /// </summary>
        /// <param name="size">
        /// Specifies the maximum size for the page blob, up to 8 TB.  The
        /// size must be aligned to a 512-byte boundary.  If the specified
        /// value is less than the current size of the blob, then all pages
        /// above the specified value are cleared.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add
        /// conditions on the resize of this page blob.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageBlobInfo}"/> describing the resized
        /// page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<PageBlobInfo>> ResizeInternal(
            long size,
            PageBlobAccessConditions? accessConditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(PageBlobClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(PageBlobClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(size)}: {size}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    return await BlobRestClient.PageBlob.ResizeAsync(
                        this.Pipeline,
                        this.Uri,
                        blobContentLength: size,
                        leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                        ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        ifMatch: accessConditions?.HttpAccessConditions?.IfMatch,
                        ifNoneMatch: accessConditions?.HttpAccessConditions?.IfNoneMatch,
                        async: async,
                        operationName: "Azure.Storage.Blobs.Specialized.PageBlobClient.Resize",
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(PageBlobClient));
                }
            }
        }
        #endregion Resize

        #region UpdateSequenceNumber
        /// <summary>
        /// The <see cref="UpdateSequenceNumber"/> operation changes the
        /// sequence number <paramref name="action"/> and <paramref name="sequenceNumber"/>
        /// for this page blob.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-properties" />.
        /// </summary>
        /// <param name="action">
        /// Specifies how the service should modify the blob's sequence number.
        /// <see cref="SequenceNumberAction.Max"/> sets the sequence number to
        /// be the higher of the value included with the request and the value
        /// currently stored for the blob.  <see cref="SequenceNumberAction.Update"/>
        /// sets the sequence number to the <paramref name="sequenceNumber"/>
        /// value.  <see cref="SequenceNumberAction.Increment"/> increments
        /// the value of the sequence number by 1.  If specifying
        /// <see cref="SequenceNumberAction.Increment"/>, do not include the
        /// <paramref name="sequenceNumber"/> because that will throw a
        /// <see cref="StorageRequestFailedException"/>.
        /// </param>
        /// <param name="sequenceNumber">
        /// An updated sequence number of your choosing, if
        /// <paramref name="action"/> is <see cref="SequenceNumberAction.Max"/>
        /// or <see cref="SequenceNumberAction.Update"/>.  The value should
        /// not be provided if <paramref name="action"/> is
        /// <see cref="SequenceNumberAction.Increment"/>.  The sequence number
        /// is a user-controlled property that you can use to track requests
        /// and manage concurrency issues via <see cref="PageBlobAccessConditions"/>.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add conditions
        /// on updating the sequence number of this page blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageBlobInfo}"/> describing the updated
        /// page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<PageBlobInfo> UpdateSequenceNumber(
            SequenceNumberAction action,
            long? sequenceNumber = default,
            PageBlobAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default) =>
            this.UpdateSequenceNumberInternal(
                action,
                sequenceNumber,
                accessConditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="UpdateSequenceNumberAsync"/> operation changes the
        /// sequence number <paramref name="action"/> and <paramref name="sequenceNumber"/>
        /// for this page blob.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-properties" />.
        /// </summary>
        /// <param name="action">
        /// Specifies how the service should modify the blob's sequence number.
        /// <see cref="SequenceNumberAction.Max"/> sets the sequence number to
        /// be the higher of the value included with the request and the value
        /// currently stored for the blob.  <see cref="SequenceNumberAction.Update"/>
        /// sets the sequence number to the <paramref name="sequenceNumber"/>
        /// value.  <see cref="SequenceNumberAction.Increment"/> increments
        /// the value of the sequence number by 1.  If specifying
        /// <see cref="SequenceNumberAction.Increment"/>, do not include the
        /// <paramref name="sequenceNumber"/> because that will throw a
        /// <see cref="StorageRequestFailedException"/>.
        /// </param>
        /// <param name="sequenceNumber">
        /// An updated sequence number of your choosing, if
        /// <paramref name="action"/> is <see cref="SequenceNumberAction.Max"/>
        /// or <see cref="SequenceNumberAction.Update"/>.  The value should
        /// not be provided if <paramref name="action"/> is
        /// <see cref="SequenceNumberAction.Increment"/>.  The sequence number
        /// is a user-controlled property that you can use to track requests
        /// and manage concurrency issues via <see cref="PageBlobAccessConditions"/>.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add conditions
        /// on updating the sequence number of this page blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageBlobInfo}"/> describing the updated
        /// page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<PageBlobInfo>> UpdateSequenceNumberAsync(
            SequenceNumberAction action,
            long? sequenceNumber = default,
            PageBlobAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default) =>
            await this.UpdateSequenceNumberInternal(
                action,
                sequenceNumber,
                accessConditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UpdateSequenceNumberInternal"/> operation changes the
        /// sequence number <paramref name="action"/> and <paramref name="sequenceNumber"/>
        /// for this page blob.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-properties" />.
        /// </summary>
        /// <param name="action">
        /// Specifies how the service should modify the blob's sequence number.
        /// <see cref="SequenceNumberAction.Max"/> sets the sequence number to
        /// be the higher of the value included with the request and the value
        /// currently stored for the blob.  <see cref="SequenceNumberAction.Update"/>
        /// sets the sequence number to the <paramref name="sequenceNumber"/>
        /// value.  <see cref="SequenceNumberAction.Increment"/> increments
        /// the value of the sequence number by 1.  If specifying
        /// <see cref="SequenceNumberAction.Increment"/>, do not include the
        /// <paramref name="sequenceNumber"/> because that will throw a
        /// <see cref="StorageRequestFailedException"/>.
        /// </param>
        /// <param name="sequenceNumber">
        /// An updated sequence number of your choosing, if
        /// <paramref name="action"/> is <see cref="SequenceNumberAction.Max"/>
        /// or <see cref="SequenceNumberAction.Update"/>.  The value should
        /// not be provided if <paramref name="action"/> is
        /// <see cref="SequenceNumberAction.Increment"/>.  The sequence number
        /// is a user-controlled property that you can use to track requests
        /// and manage concurrency issues via <see cref="PageBlobAccessConditions"/>.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add conditions
        /// on updating the sequence number of this page blob.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageBlobInfo}"/> describing the updated
        /// page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<PageBlobInfo>> UpdateSequenceNumberInternal(
            SequenceNumberAction action,
            long? sequenceNumber,
            PageBlobAccessConditions? accessConditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(PageBlobClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(PageBlobClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(action)}: {action}\n" +
                    $"{nameof(sequenceNumber)}: {sequenceNumber}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    return await BlobRestClient.PageBlob.UpdateSequenceNumberAsync(
                        this.Pipeline,
                        this.Uri,
                        sequenceNumberAction: action,
                        blobSequenceNumber: sequenceNumber,
                        leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                        ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        ifMatch: accessConditions?.HttpAccessConditions?.IfMatch,
                        ifNoneMatch: accessConditions?.HttpAccessConditions?.IfNoneMatch,
                        operationName: "Azure.Storage.Blobs.Specialized.PageBlobClient.UpdateSequenceNumber",
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(PageBlobClient));
                }
            }
        }
        #endregion UpdateSequenceNumber

        #region StartCopyIncremental
        /// <summary>
        /// The <see cref="StartCopyIncremental(Uri, String, PageBlobAccessConditions?, CancellationToken)"/>
        /// operation starts copying a snapshot of the sourceUri page blob to
        /// this page blob.  The snapshot is copied such that only the
        /// differential changes between the previously copied snapshot are
        /// transferred to the destination.  The copied snapshots are complete
        /// copies of the original snapshot and can be read or copied from as
        /// usual.  You can check the <see cref="BlobProperties.CopyStatus"/>
        /// returned from the <see cref="BlobBaseClient.GetProperties"/> to
        /// determine if the copy has completed.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/incremental-copy-blob" />
        /// and <see href="https://docs.microsoft.com/en-us/azure/virtual-machines/windows/incremental-snapshots"/>.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the to the source page blob as a <see cref="Uri"/> up to
        /// 2 KB in length.  The source blob must either be public or must be
        /// authenticated via a shared access signature.
        /// </param>
        /// <param name="snapshot">
        /// The name of a snapshot to start copying from
        /// sourceUri.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add
        /// conditions on the incremental copy into this page blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Operation{Int64}"/> referencing the incremental
        /// copy operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        ///
        /// The destination of an incremental copy must either not exist, or
        /// must have been created with a previous incremental copy from the
        /// same source blob.  Once created, the destination blob is
        /// permanently associated with the source and may only be used for
        /// incremental copies.
        ///
        /// The <see cref="BlobBaseClient.GetProperties"/>,
        /// <see cref="BlobContainerClient.GetBlobs"/>, and
        /// <see cref="BlobContainerClient.GetBlobsByHierarchy"/>
        /// operations indicate whether the blob is an incremental copy blob
        /// created in this way.  Incremental copy blobs may not be downloaded
        /// directly.  The only supported operations are
        /// <see cref="BlobBaseClient.GetProperties"/>,
        /// <see cref="StartCopyIncremental(Uri, String, PageBlobAccessConditions?, CancellationToken)"/>,
        /// and <see cref="BlobBaseClient.Delete"/>.  The copied snapshots may
        /// be read and deleted as usual.
        ///
        /// An incremental copy is performed asynchronously on the service and
        /// must be polled for completion.  You can poll
        /// <see cref="BlobBaseClient.GetProperties"/> and check
        /// <see cref="BlobProperties.CopyStatus"/> to determine when the copy
        /// has completed.  When the copy completes, the destination blob will
        /// contain a new snapshot.  The <see cref="BlobBaseClient.GetProperties"/>
        /// operation returns the snapshot time of the newly created snapshot.
        ///
        /// The first time an incremental copy is performed on a destination
        /// blob, a new blob is created with a snapshot that is fully copied
        /// from the source.  Each subsequent call to <see cref="StartCopyIncremental(Uri, String, PageBlobAccessConditions?, CancellationToken)"/>
        /// will create a new snapshot by copying only the differential
        /// changes from the previously copied snapshot.  The differential
        /// changes are computed on the server by issuing a <see cref="GetPageRanges"/>
        /// call on the source blob snapshot with prevSnapshot set to the most
        /// recently copied snapshot. Therefore, the same restrictions on
        /// <see cref="GetPageRanges"/> apply to
        /// <see cref="StartCopyIncremental(Uri, String, PageBlobAccessConditions?, CancellationToken)"/>.
        /// Specifically, snapshots must be copied in ascending order and if
        /// the source blob is recreated using <see cref="UploadPages"/> or
        /// <see cref="BlobBaseClient.StartCopyFromUri(Uri, Metadata, BlobAccessConditions?, BlobAccessConditions?, CancellationToken)"/>
        /// then  <see cref="StartCopyIncremental(Uri, String, PageBlobAccessConditions?, CancellationToken)"/>
        /// on new snapshots will fail.
        ///
        /// The additional storage space consumed by the copied snapshot is
        /// the size of the differential data transferred during the copy.
        /// This can be determined by performing a <see cref="GetPageRangesDiff"/>
        /// call on the snapshot to compare it to the previous snapshot.
        /// </remarks>
        public virtual Operation<long> StartCopyIncremental(
            Uri sourceUri,
            string snapshot,
            PageBlobAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default)
        {
            var response = this.StartCopyIncrementalInternal(
                sourceUri,
                snapshot,
                accessConditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();
            return new CopyFromUriOperation(
                this,
                response.Value.CopyId,
                response.GetRawResponse(),
                cancellationToken);
        }

        /// <summary>
        /// The <see cref="StartCopyIncrementalAsync(Uri, String, PageBlobAccessConditions?, CancellationToken)"/>
        /// operation starts copying a snapshot of the sourceUri page blob to
        /// this page blob.  The snapshot is copied such that only the
        /// differential changes between the previously copied snapshot are
        /// transferred to the destination. The copied snapshots are complete
        /// copies of the original snapshot and can be read or copied from as
        /// usual.  You can check the <see cref="BlobProperties.CopyStatus"/>
        /// returned from the <see cref="BlobBaseClient.GetPropertiesAsync"/>
        /// to determine if thecopy has completed.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/incremental-copy-blob" />
        /// and <see href="https://docs.microsoft.com/en-us/azure/virtual-machines/windows/incremental-snapshots"/>.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the to the source page blob as a <see cref="Uri"/> up to
        /// 2 KB in length.  The source blob must either be public or must be
        /// authenticated via a shared access signature.
        /// </param>
        /// <param name="snapshot">
        /// The name of a snapshot to start copying from
        /// sourceUri.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add
        /// conditions on the incremental copy into this page blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Operation{Int64}"/> describing the
        /// state of the incremental copy operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        ///
        /// The destination of an incremental copy must either not exist, or
        /// must have been created with a previous incremental copy from the
        /// same source blob.  Once created, the destination blob is
        /// permanently associated with the source and may only be used for
        /// incremental copies.
        ///
        /// The <see cref="BlobBaseClient.GetPropertiesAsync"/>,
        /// <see cref="BlobContainerClient.GetBlobsAsync"/>, and
        /// <see cref="BlobContainerClient.GetBlobsByHierarchyAsync"/>
        /// operations indicate whether the blob is an incremental copy blob
        /// created in this way.  Incremental copy blobs may not be downloaded
        /// directly.  The only supported operations are
        /// <see cref="BlobBaseClient.GetPropertiesAsync"/>,
        /// <see cref="StartCopyIncrementalAsync(Uri, String, PageBlobAccessConditions?, CancellationToken)"/>,
        /// and  <see cref="BlobBaseClient.DeleteAsync"/>.  The copied
        /// snapshots may be read and deleted as usual.
        ///
        /// An incremental copy is performed asynchronously on the service and
        /// must be polled for completion.  You can poll
        /// <see cref="BlobBaseClient.GetPropertiesAsync"/> and check
        /// <see cref="BlobProperties.CopyStatus"/> to determine when the copy
        /// has completed.  When the copy completes, the destination blob will
        /// contain a new snapshot.  The <see cref="BlobBaseClient.GetPropertiesAsync"/>
        /// operation returns the snapshot time of the newly created snapshot.
        ///
        /// The first time an incremental copy is performed on a destination
        /// blob, a new blob is created with a snapshot that is fully copied
        /// from the source.  Each subsequent call to <see cref="StartCopyIncrementalAsync(Uri, String, PageBlobAccessConditions?, CancellationToken)"/>
        /// will create a new snapshot by copying only the differential
        /// changes from the previously copied snapshot.  The differential
        /// changes are computed on the server by issuing a <see cref="GetPageRangesAsync"/>
        /// call on the source blob snapshot with prevSnapshot set to the most
        /// recently copied snapshot. Therefore, the same restrictions on
        /// <see cref="GetPageRangesAsync"/> apply to
        /// <see cref="StartCopyIncrementalAsync(Uri, String, PageBlobAccessConditions?, CancellationToken)"/>.
        /// Specifically, snapshots must be copied in ascending order and if
        /// the source blob is recreated using <see cref="UploadPagesAsync"/> or
        /// <see cref="BlobBaseClient.StartCopyFromUriAsync(Uri, Metadata, BlobAccessConditions?, BlobAccessConditions?, CancellationToken)"/>
        /// then <see cref="StartCopyIncrementalAsync(Uri, String, PageBlobAccessConditions?, CancellationToken)"/>
        /// on new snapshots will fail.
        ///
        /// The additional storage space consumed by the copied snapshot is
        /// the size of the differential data transferred during the copy.
        /// This can be determined by performing a <see cref="GetPageRangesDiffAsync"/>
        /// call on the snapshot to compare it to the previous snapshot.
        /// </remarks>
        public virtual async Task<Operation<long>> StartCopyIncrementalAsync(
            Uri sourceUri,
            string snapshot,
            PageBlobAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default)
        {
            var response = await this.StartCopyIncrementalInternal(
                sourceUri,
                snapshot,
                accessConditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);
            return new CopyFromUriOperation(
                this,
                response.Value.CopyId,
                response.GetRawResponse(),
                cancellationToken);
        }

        /// <summary>
        /// The <see cref="StartCopyIncremental(String, CancellationToken)"/>
        /// operation gets the status of an existing copy operation, specified
        /// by the <paramref name="copyId"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/incremental-copy-blob" />
        /// and <see href="https://docs.microsoft.com/en-us/azure/virtual-machines/windows/incremental-snapshots"/>.
        /// </summary>
        /// <param name="copyId">
        /// The ID of a copy operation that's already beeen started.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Operation{Int64}"/> referencing the incremental
        /// copy operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Operation<long> StartCopyIncremental(
            string copyId,
            CancellationToken cancellationToken = default)
        {
            var response = this.GetProperties(null, cancellationToken);
            return new CopyFromUriOperation(
                this,
                copyId,
                response.GetRawResponse(),
                cancellationToken);
        }

        /// <summary>
        /// The <see cref="StartCopyIncrementalAsync(String, CancellationToken)"/>
        /// operation gets the status of an existing copy operation, specified
        /// by the <paramref name="copyId"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/incremental-copy-blob" />
        /// and <see href="https://docs.microsoft.com/en-us/azure/virtual-machines/windows/incremental-snapshots"/>.
        /// </summary>
        /// <param name="copyId">
        /// The ID of a copy operation that's already beeen started.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Operation{Int64}"/> describing the
        /// state of the incremental copy operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Operation<long>> StartCopyIncrementalAsync(
            string copyId,
            CancellationToken cancellationToken = default)
        {
            var response = await this.GetPropertiesAsync(null, cancellationToken).ConfigureAwait(false);
            return new CopyFromUriOperation(
                this,
                copyId,
                response.GetRawResponse(),
                cancellationToken);
        }

        /// <summary>
        /// The <see cref="StartCopyIncrementalInternal"/> operation starts
        /// copying a snapshot of the
        /// sourceUri page blob to this page blob.  The
        /// snapshot is copied such that only the differential changes between
        /// the previously copied snapshot are transferred to the destination.
        /// The copied snapshots are complete copies of the original snapshot
        /// and can be read or copied from as usual.  You can check the
        /// <see cref="BlobProperties.CopyStatus"/> returned from the
        /// <see cref="BlobBaseClient.GetPropertiesAsync"/> to determine if the
        /// copy has completed.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/incremental-copy-blob" />
        /// and <see href="https://docs.microsoft.com/en-us/azure/virtual-machines/windows/incremental-snapshots"/>.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the to the source page blob as a <see cref="Uri"/> up to
        /// 2 KB in length.  The source blob must either be public or must be
        /// authenticated via a shared access signature.
        /// </param>
        /// <param name="snapshot">
        /// The name of a snapshot to start copying from
        /// sourceUri.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="PageBlobAccessConditions"/> to add
        /// conditions on the incremental copy into this page blob.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobCopyInfo}"/> describing the
        /// state of the incremental copy operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        ///
        /// The destination of an incremental copy must either not exist, or
        /// must have been created with a previous incremental copy from the
        /// same source blob.  Once created, the destination blob is
        /// permanently associated with the source and may only be used for
        /// incremental copies.
        ///
        /// The <see cref="BlobBaseClient.GetPropertiesAsync"/>,
        /// <see cref="BlobContainerClient.GetBlobsAsync"/>, and
        /// <see cref="BlobContainerClient.GetBlobsByHierarchyAsync"/>
        /// operations indicate whether the blob is an incremental copy blob
        /// created in this way.  Incremental copy blobs may not be downloaded
        /// directly.  The only supported operations are
        /// <see cref="BlobBaseClient.GetPropertiesAsync"/>,
        /// <see cref="StartCopyIncremental(Uri, String, PageBlobAccessConditions?, CancellationToken)"/>,
        /// and  <see cref="BlobBaseClient.DeleteAsync"/>.  The copied
        /// snapshots may be read and deleted as usual.
        ///
        /// An incremental copy is performed asynchronously on the service and
        /// must be polled for completion.  You can poll
        /// <see cref="BlobBaseClient.GetPropertiesAsync"/> and check
        /// <see cref="BlobProperties.CopyStatus"/> to determine when the copy
        /// has completed.  When the copy completes, the destination blob will
        /// contain a new snapshot.  The <see cref="BlobBaseClient.GetPropertiesAsync"/>
        /// operation returns the snapshot time of the newly created snapshot.
        ///
        /// The first time an incremental copy is performed on a destination
        /// blob, a new blob is created with a snapshot that is fully copied
        /// from the source.  Each subsequent call to <see cref="StartCopyIncrementalAsync(Uri, String, PageBlobAccessConditions?, CancellationToken)"/>
        /// will create a new snapshot by copying only the differential
        /// changes from the previously copied snapshot.  The differential
        /// changes are computed on the server by issuing a <see cref="GetPageRangesAsync"/>
        /// call on the source blob snapshot with prevSnapshot set to the most
        /// recently copied snapshot. Therefore, the same restrictions on
        /// <see cref="GetPageRangesAsync"/> apply to
        /// <see cref="StartCopyIncrementalAsync(Uri, String, PageBlobAccessConditions?, CancellationToken)"/>.
        /// Specifically, snapshots must be copied in ascending order and if
        /// the source blob is recreated using <see cref="UploadPagesAsync"/>
        /// or  <see cref="BlobBaseClient.StartCopyFromUriAsync(Uri, Metadata, BlobAccessConditions?, BlobAccessConditions?, CancellationToken)"/>
        /// then <see cref="StartCopyIncrementalAsync(Uri, String, PageBlobAccessConditions?, CancellationToken)"/>
        /// on new snapshots will fail.
        ///
        /// The additional storage space consumed by the copied snapshot is
        /// the size of the differential data transferred during the copy.
        /// This can be determined by performing a <see cref="GetPageRangesDiffAsync"/>
        /// call on the snapshot to compare it to the previous snapshot.
        /// </remarks>
        private async Task<Response<BlobCopyInfo>> StartCopyIncrementalInternal(
            Uri sourceUri,
            string snapshot,
            PageBlobAccessConditions? accessConditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(PageBlobClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(PageBlobClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(sourceUri)}: {sourceUri}\n" +
                    $"{nameof(snapshot)}: {snapshot}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    // Create copySource Uri
                    var pageBlobUri = new PageBlobClient(sourceUri, this.Pipeline).WithSnapshot(snapshot);

                    return await BlobRestClient.PageBlob.CopyIncrementalAsync(
                        this.Pipeline,
                        this.Uri,
                        copySource: pageBlobUri.Uri,
                        ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        ifMatch: accessConditions?.HttpAccessConditions?.IfMatch,
                        ifNoneMatch: accessConditions?.HttpAccessConditions?.IfNoneMatch,
                        async: async,
                        operationName: "Azure.Storage.Blobs.Specialized.PageBlobClient.StartCopyIncremental",
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(PageBlobClient));
                }
            }
        }
        #endregion StartCopyIncremental

        #region UploadPagesFromUri
        /// <summary>
        /// The <see cref="UploadPagesFromUri"/> operation writes a range
        /// of pages to a page blob where the contents are read from
        /// sourceUri.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-page-from-url" />.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the <see cref="Uri"/> of the source blob.  The value may
        /// be a <see cref="Uri" /> of up to 2 KB in length that specifies a
        /// blob.  The source blob must either be public or must be
        /// authenticated via a shared access signature.  If the source blob
        /// is public, no authentication is required to perform the operation.
        /// </param>
        /// <param name="sourceRange">
        /// Optionally only upload the bytes of the blob in the
        /// sourceUri in the specified range.
        /// </param>
        /// <param name="range">
        /// Specifies the range to be written as a page. Both the start and
        /// end of the range must be specified and can be up to 4MB in size.
        /// Given that pages must be aligned with 512-byte boundaries, the
        /// start of the range must be a modulus of 512 and the end of the
        /// range must be a modulus of 512 – 1.  Examples of valid byte ranges
        /// are 0-511, 512-1023, etc.
        /// </param>
        /// <param name="sourceContentHash">
        /// Optional MD5 hash of the page block content from the
        /// sourceUri.  This hash is used to verify the
        /// integrity of the block during transport of the data from the Uri.
        /// When this hash is specified, the storage service compares the hash
        /// of the content that has arrived from the sourceUri
        /// with this value.  Note that this md5 hash is not stored with the
        /// blob.  If the two hashes do not match, the operation will fail
        /// with a <see cref="StorageRequestFailedException"/>.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="AppendBlobAccessConditions"/> to add
        /// conditions on the copying of data to this page blob.
        /// </param>
        /// <param name="sourceAccessConditions">
        /// Optional <see cref="AppendBlobAccessConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageInfo}"/> describing the
        /// state of the updated pages.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<PageInfo> UploadPagesFromUri(
            Uri sourceUri,
            HttpRange sourceRange,
            HttpRange range,
            byte[] sourceContentHash = default,
            PageBlobAccessConditions? accessConditions = default,
            PageBlobAccessConditions? sourceAccessConditions = default,
            CancellationToken cancellationToken = default) =>
            this.UploadPagesFromUriInternal(
                sourceUri,
                sourceRange,
                range,
                sourceContentHash,
                accessConditions,
                sourceAccessConditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="UploadPagesFromUriAsync"/> operation writes a range
        /// of pages to a page blob where the contents are read from
        /// sourceUri.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-page-from-url" />.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the <see cref="Uri"/> of the source blob.  The value may
        /// be a <see cref="Uri" /> of up to 2 KB in length that specifies a
        /// blob.  The source blob must either be public or must be
        /// authenticated via a shared access signature.  If the source blob
        /// is public, no authentication is required to perform the operation.
        /// </param>
        /// <param name="sourceRange">
        /// Optionally only upload the bytes of the blob in the
        /// sourceUri in the specified range.
        /// </param>
        /// <param name="range">
        /// Specifies the range to be written as a page. Both the start and
        /// end of the range must be specified and can be up to 4MB in size.
        /// Given that pages must be aligned with 512-byte boundaries, the
        /// start of the range must be a modulus of 512 and the end of the
        /// range must be a modulus of 512 – 1.  Examples of valid byte ranges
        /// are 0-511, 512-1023, etc.
        /// </param>
        /// <param name="sourceContentHash">
        /// Optional MD5 hash of the page block content from the
        /// sourceUri.  This hash is used to verify the
        /// integrity of the block during transport of the data from the Uri.
        /// When this hash is specified, the storage service compares the hash
        /// of the content that has arrived from the sourceUri
        /// with this value.  Note that this md5 hash is not stored with the
        /// blob.  If the two hashes do not match, the operation will fail
        /// with a <see cref="StorageRequestFailedException"/>.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="AppendBlobAccessConditions"/> to add
        /// conditions on the copying of data to this page blob.
        /// </param>
        /// <param name="sourceAccessConditions">
        /// Optional <see cref="AppendBlobAccessConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageInfo}"/> describing the
        /// state of the updated pages.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<PageInfo>> UploadPagesFromUriAsync(
            Uri sourceUri,
            HttpRange sourceRange,
            HttpRange range,
            byte[] sourceContentHash = default,
            PageBlobAccessConditions? accessConditions = default,
            PageBlobAccessConditions? sourceAccessConditions = default,
            CancellationToken cancellationToken = default) =>
            await this.UploadPagesFromUriInternal(
                sourceUri,
                sourceRange,
                range,
                sourceContentHash,
                accessConditions,
                sourceAccessConditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UploadPagesFromUriInternal"/> operation writes a
        /// range of pages to a page blob where the contents are read from
        /// sourceUri.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-page-from-url" />.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the <see cref="Uri"/> of the source blob.  The value may
        /// be a <see cref="Uri" /> of up to 2 KB in length that specifies a
        /// blob.  The source blob must either be public or must be
        /// authenticated via a shared access signature.  If the source blob
        /// is public, no authentication is required to perform the operation.
        /// </param>
        /// <param name="sourceRange">
        /// Optionally only upload the bytes of the blob in the
        /// sourceUri in the specified range.
        /// </param>
        /// <param name="range">
        /// Specifies the range to be written as a page. Both the start and
        /// end of the range must be specified and can be up to 4MB in size.
        /// Given that pages must be aligned with 512-byte boundaries, the
        /// start of the range must be a modulus of 512 and the end of the
        /// range must be a modulus of 512 – 1.  Examples of valid byte ranges
        /// are 0-511, 512-1023, etc.
        /// </param>
        /// <param name="sourceContentHash">
        /// Optional MD5 hash of the page block content from the
        /// sourceUri.  This hash is used to verify the
        /// integrity of the block during transport of the data from the Uri.
        /// When this hash is specified, the storage service compares the hash
        /// of the content that has arrived from the sourceUri
        /// with this value.  Note that this md5 hash is not stored with the
        /// blob.  If the two hashes do not match, the operation will fail
        /// with a <see cref="StorageRequestFailedException"/>.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="AppendBlobAccessConditions"/> to add
        /// conditions on the copying of data to this page blob.
        /// </param>
        /// <param name="sourceAccessConditions">
        /// Optional <see cref="AppendBlobAccessConditions"/> to add
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
        /// A <see cref="Response{PageInfo}"/> describing the
        /// state of the updated pages.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<PageInfo>> UploadPagesFromUriInternal(
            Uri sourceUri,
            HttpRange sourceRange,
            HttpRange range,
            byte[] sourceContentHash,
            PageBlobAccessConditions? accessConditions,
            PageBlobAccessConditions? sourceAccessConditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(PageBlobClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(PageBlobClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(sourceUri)}: {sourceUri}");
                try
                {
                    return await BlobRestClient.PageBlob.UploadPagesFromUriAsync(
                        this.Pipeline,
                        this.Uri,
                        sourceUri: sourceUri,
                        sourceRange: sourceRange.ToString(),
                        sourceContentHash: sourceContentHash,
                        contentLength: default,
                        timeout: default,
                        range: range.ToString(),
                        leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                        ifSequenceNumberLessThanOrEqualTo: accessConditions?.IfSequenceNumberLessThanOrEqual,
                        ifSequenceNumberLessThan: accessConditions?.IfSequenceNumberLessThan,
                        ifSequenceNumberEqualTo: accessConditions?.IfSequenceNumberEqual,
                        ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        ifMatch: accessConditions?.HttpAccessConditions?.IfMatch,
                        ifNoneMatch: accessConditions?.HttpAccessConditions?.IfNoneMatch,
                        sourceIfModifiedSince: sourceAccessConditions?.HttpAccessConditions?.IfModifiedSince,
                        sourceIfUnmodifiedSince: sourceAccessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        sourceIfMatch: sourceAccessConditions?.HttpAccessConditions?.IfMatch,
                        sourceIfNoneMatch: sourceAccessConditions?.HttpAccessConditions?.IfNoneMatch,
                        async: async,
                        operationName: "Azure.Storage.Blobs.Specialized.PageBlobClient.UploadPagesFromUri",
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(PageBlobClient));
                }
            }
        }
        #endregion UploadPagesFromUri
    }

    /// <summary>
    /// Add easy to discover methods to <see cref="BlobContainerClient"/> for
    /// creating <see cref="PageBlobClient"/> instances.
    /// </summary>
    public static partial class SpecializedBlobExtensions
    {
        /// <summary>
        /// Create a new <see cref="PageBlobClient"/> object by
        /// concatenating <paramref name="blobName"/> to
        /// the end of the <paramref name="client"/>'s
        /// <see cref="BlobContainerClient.Uri"/>. The new
        /// <see cref="PageBlobClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="BlobContainerClient"/>.
        /// </summary>
        /// <param name="client">The <see cref="BlobContainerClient"/>.</param>
        /// <param name="blobName">The name of the page blob.</param>
        /// <returns>A new <see cref="PageBlobClient"/> instance.</returns>
        public static PageBlobClient GetPageBlobClient(
            this BlobContainerClient client,
            string blobName)
            => new PageBlobClient(client.Uri.AppendToPath(blobName), client.Pipeline);
    }
}
