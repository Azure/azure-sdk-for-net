﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Common;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

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
    public class AppendBlobClient : BlobClient
    {
        /// <summary>
        /// <see cref="AppendBlobMaxAppendBlockBytes"/> indicates the maximum
        /// number of bytes that can be sent in a call to AppendBlock.
        /// </summary>
        public const int AppendBlobMaxAppendBlockBytes = 4 * Constants.MB; // 4MB

        /// <summary>
        /// <see cref="AppendBlobMaxBlocks"/> indicates the maximum number of
        /// blocks allowed in an append blob.
        /// </summary>
        public const int AppendBlobMaxBlocks = 50000;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendBlobClient"/>
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
        /// The name of the container containing this append blob.
        /// </param>
        /// <param name="blobName">
        /// The name of this append blob.
        /// </param>
        /// <param name="connectionOptions">
        /// Optional connection options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        /// <remarks>
        /// The credentials on <paramref name="connectionString"/> will override those on <paramref name="connectionOptions"/>.
        /// </remarks>
        public AppendBlobClient(string connectionString, string containerName, string blobName, BlobConnectionOptions connectionOptions = default)
            : base(connectionString, containerName, blobName, connectionOptions)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="primaryUri">
        /// A <see cref="Uri"/> referencing the append blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// </param>
        /// <param name="connectionOptions">
        /// Optional connection options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public AppendBlobClient(Uri primaryUri, BlobConnectionOptions connectionOptions = default)
            : base(primaryUri, connectionOptions)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="primaryUri">
        /// A <see cref="Uri"/> referencing the append blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        internal AppendBlobClient(Uri primaryUri, HttpPipeline pipeline)
            : base(primaryUri, pipeline)
        {
        }

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
            var builder = new BlobUriBuilder(this.Uri) { Snapshot = snapshot };
            return new AppendBlobClient(builder.ToUri(), this.Pipeline);
        }

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
        /// <param name="accessConditions">
        /// Optional <see cref="AppendBlobAccessConditions"/> to add
        /// conditions on the creation of this new append blob.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{BlobContentInfo}}"/> describing the
        /// newly created append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<BlobContentInfo>> CreateAsync(
            BlobHttpHeaders? httpHeaders = default, 
            Metadata metadata = default, 
            AppendBlobAccessConditions? accessConditions = default,
            CancellationToken cancellation = default)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(AppendBlobClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(AppendBlobClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(httpHeaders)}: {httpHeaders}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    return await BlobRestClient.AppendBlob.CreateAsync(
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
                        cancellation: cancellation)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(AppendBlobClient));
                }
            }
        }

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
        /// operation will fail with a <see cref="StorageRequestFailedException"/>.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="AppendBlobAccessConditions"/> to add
        /// conditions on appending content to this append blob.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{StorageProgress}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{BlobAppendInfo}}"/> describing the
        /// state of the updated append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<BlobAppendInfo>> AppendBlockAsync(
            Stream content,
            byte[] transactionalContentHash = default, 
            AppendBlobAccessConditions? accessConditions = default, 
            IProgress<StorageProgress> progressHandler = default,
            CancellationToken cancellation = default)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(AppendBlobClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(AppendBlobClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    content = content.WithNoDispose().WithProgress(progressHandler);
                    var appendAttempt = 0;
                    return await ReliableOperation.DoAsync(
                        reset: () => content.Seek(0, SeekOrigin.Begin),
                        predicate: e => true,
                        maximumRetries: Constants.MaxReliabilityRetries,
                        operation:
                            async () =>
                            {
                                this.Pipeline.LogTrace($"Append attempt {++appendAttempt}");
                                return await BlobRestClient.AppendBlob.AppendBlockAsync(
                                    this.Pipeline,
                                    this.Uri,
                                    body: content,
                                    contentLength: content.Length,
                                    transactionalContentHash: transactionalContentHash,
                                    leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                                    maxSize: accessConditions?.IfMaxSizeLessThanOrEqual,
                                    appendPosition: accessConditions?.IfAppendPositionEqual,
                                    ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                                    ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                                    ifMatch: accessConditions?.HttpAccessConditions?.IfMatch,
                                    ifNoneMatch: accessConditions?.HttpAccessConditions?.IfNoneMatch,                                    
                                    cancellation: cancellation)
                                    .ConfigureAwait(false);
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
                    this.Pipeline.LogMethodExit(nameof(AppendBlobClient));
                }
            }
        }

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
        /// with a <see cref="StorageRequestFailedException"/>.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="AppendBlobAccessConditions"/> to add
        /// conditions on the copying of data to this append blob.
        /// </param>
        /// <param name="sourceAccessConditions">
        /// Optional <see cref="AppendBlobAccessConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{BlobAppendInfo}}"/> describing the
        /// state of the updated append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<BlobAppendInfo>> AppendBlockFromUriAsync(
            Uri sourceUri,
            HttpRange sourceRange = default,
            byte[] sourceContentHash = default,
            AppendBlobAccessConditions? accessConditions = default,
            AppendBlobAccessConditions? sourceAccessConditions = default,
            CancellationToken cancellation = default)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(AppendBlobClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(AppendBlobClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(sourceUri)}: {sourceUri}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    return await BlobRestClient.AppendBlob.AppendBlockFromUriAsync(
                        this.Pipeline,
                        this.Uri,
                        sourceUri: sourceUri,
                        sourceRange: sourceRange.ToRange(),
                        sourceContentHash: sourceContentHash,
                        contentLength: default,
                        leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                        maxSize: accessConditions?.IfMaxSizeLessThanOrEqual,
                        appendPosition: accessConditions?.IfAppendPositionEqual,
                        ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        ifMatch: accessConditions?.HttpAccessConditions?.IfMatch,
                        ifNoneMatch: accessConditions?.HttpAccessConditions?.IfNoneMatch,
                        sourceIfModifiedSince: sourceAccessConditions?.HttpAccessConditions?.IfModifiedSince,
                        sourceIfUnmodifiedSince: sourceAccessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        sourceIfMatch: sourceAccessConditions?.HttpAccessConditions?.IfMatch,
                        sourceIfNoneMatch: sourceAccessConditions?.HttpAccessConditions?.IfNoneMatch,
                        cancellation: cancellation)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(AppendBlobClient));
                }
            }
        }
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
            => new AppendBlobClient(client.Uri.AppendToPath(blobName), client._pipeline);
    }
}
