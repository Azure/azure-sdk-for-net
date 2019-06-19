// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Common;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Specialized
{
    /// <summary>
    /// The <see cref="BlobClient"/> allows you to manipulate Azure Storage
    /// blobs.
    /// </summary>
	public class BlobClient
    {
        /// <summary>
        /// Gets the blob's primary <see cref="Uri"/> endpoint.
        /// </summary>
        public Uri Uri { get; }

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send 
        /// every request.
        /// </summary>
        protected HttpPipeline Pipeline { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/>
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
        /// The name of the container containing this blob.
        /// </param>
        /// <param name="blobName">
        /// The name of this blob.
        /// </param>
        /// <param name="connectionOptions">
        /// Optional connection options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        /// <remarks>
        /// The credentials on <paramref name="connectionString"/> will override those on <paramref name="connectionOptions"/>.
        /// </remarks>
        public BlobClient(string connectionString, string containerName, string blobName, BlobConnectionOptions connectionOptions = default)
        {
            var conn = StorageConnectionString.Parse(connectionString);

            var builder = 
                new BlobUriBuilder(conn.BlobEndpoint)
                {
                    ContainerName = containerName,
                    BlobName = blobName
                };

            // TODO: perform a copy of the options instead
            var connOptions = connectionOptions ?? new BlobConnectionOptions();
            connOptions.Credentials = conn.Credentials;

            this.Uri = builder.ToUri();
            this.Pipeline = connOptions.Build();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/>
        /// class.
        /// </summary>
        /// <param name="primaryUri">
        /// A <see cref="Uri"/> referencing the blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// </param>
        /// <param name="connectionOptions">
        /// Optional connection options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobClient(Uri primaryUri, BlobConnectionOptions connectionOptions = default)
            : this(primaryUri, (connectionOptions ?? new BlobConnectionOptions()).Build())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/>
        /// class.
        /// </summary>
        /// <param name="primaryUri">
        /// A <see cref="Uri"/> referencing the blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        internal BlobClient(Uri primaryUri, HttpPipeline pipeline)
        {
            this.Uri = primaryUri;
            this.Pipeline = pipeline;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="snapshot"/> timestamp.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/creating-a-snapshot-of-a-blob" />.
        /// </summary>
        /// <param name="snapshot">The snapshot identifier.</param>
        /// <returns>A new <see cref="BlobClient"/> instance.</returns>
        /// <remarks>
        /// Pass null or empty string to remove the snapshot returning a URL
        /// to the base blob.
        /// </remarks>
        public BlobClient WithSnapshot(string snapshot) => this.WithSnapshotImpl(snapshot);

        /// <summary>
        /// Creates a new instance of the <see cref="BlobClient"/> class
        /// with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="snapshot"/> timestamp.
        /// </summary>
        /// <param name="snapshot">The snapshot identifier.</param>
        /// <returns>A new <see cref="BlobClient"/> instance.</returns>
        protected virtual BlobClient WithSnapshotImpl(string snapshot)
        {
            var builder = new BlobUriBuilder(this.Uri) { Snapshot = snapshot };
            return new BlobClient(builder.ToUri(), this.Pipeline);
        }

        /// <summary>
        /// Creates a clone of this instance that references a version ID rather than the base blob.
        /// </summary>
        /// /// <remarks>
        /// Pass null or empty string to remove the verion ID returning a URL to the base blob.
        /// </remarks>
        /// <param name="versionId">The version ID to use on this blob. An empty string or null indicates to use the base blob.</param>
        /// <returns>The new <see cref="BlobClient"/> instance referencing the verionId.</returns>
        //public BlobClient WithVersionId(string versionId) => this.WithVersionIdImpl(versionId);

        //protected virtual BlobClient WithVersionIdImpl(string versionId)
        //{
        //    var builder = new BlobUriBuilder(this.Uri)
        //    {
        //        VersionId = versionId
        //    };
        //    return new BlobUri(builder.ToUri(), this.Pipeline);
        //}

        /// <summary>
        /// The <see cref="DownloadAsync"/> operation downloads a blob from
        /// the service, including its metadata and properties.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob" />.
        /// </summary>
        /// <param name="range">
        /// If provided, only donwload the bytes of the blob in the specified
        /// range.  If not provided, download the entire blob.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// donwloading this blob.
        /// </param>
        /// <param name="rangeGetContentHash">
        /// When set to true and specified together with the <paramref name="range"/>,
        /// the service returns the MD5 hash for the range, as long as the
        /// range is less than or equal to 4 MB in size.  If this value is
        /// specified without <paramref name="range"/> or set to true when the
        /// range exceeds 4 MB in size, a <see cref="StorageRequestFailedException"/>
        /// is thrown.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{BlobDownloadInfo}}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadInfo.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<BlobDownloadInfo>> DownloadAsync(
            HttpRange range = default,
            BlobAccessConditions? accessConditions = default, 
            bool rangeGetContentHash = default,
            CancellationToken cancellation = default)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobClient)))
            {
                this.Pipeline.LogMethodEnter(nameof(BlobClient), message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    // Start downloading the blob
                    var response = await this.StartDownloadAsync(
                        range,
                        accessConditions,
                        rangeGetContentHash,
                        cancellation: cancellation)
                        .ConfigureAwait(false);

                    // Wrap the response Content in a RetriableStream so we
                    // can return it before it's finished downloading, but still
                    // allow retrying if it fails.
                    response.Value.Content = RetriableStream.Create(
                        response.Raw,
                        async startOffset =>
                            (await this.StartDownloadAsync(
                                range,
                                accessConditions,
                                rangeGetContentHash,
                                startOffset,
                                cancellation)
                                .ConfigureAwait(false))
                                .Raw,
                        // TODO: For now we're using the default ResponseClassifier
                        // on BlobConnectionOptions so we'll do the same here
                        new ResponseClassifier(),
                        Constants.MaxReliabilityRetries);

                    // Wrap the FlattenedDownloadProperties into a BlobDownloadOperation
                    // to make the Content easier to find
                    return new Response<BlobDownloadInfo>(response.Raw, new BlobDownloadInfo(response.Value));
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(BlobClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="StartDownloadAsync"/> operation starts downloading
        /// a blob from the service from a given <paramref name="startOffset"/>.
        /// </summary>
        /// <param name="range">
        /// If provided, only download the bytes of the blob in the specified
        /// range.  If not provided, download the entire blob.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// donwloading this blob.
        /// </param>
        /// <param name="rangeGetContentHash">
        /// When set to true and specified together with the <paramref name="range"/>,
        /// the service returns the MD5 hash for the range, as long as the
        /// range is less than or equal to 4 MB in size.  If this value is
        /// specified without <paramref name="range"/> or set to true when the
        /// range exceeds 4 MB in size, a <see cref="StorageRequestFailedException"/>
        /// is thrown.
        /// </param>
        /// <param name="startOffset">
        /// Starting offset to request - in the event of a retry.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{BlobDownloadInfo}}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadInfo.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<FlattenedDownloadProperties>> StartDownloadAsync(
            HttpRange range = default,
            BlobAccessConditions? accessConditions = default,
            bool rangeGetContentHash = default,
            long startOffset = 0,
            CancellationToken cancellation = default)
        {
            var pageRange = new HttpRange(
                range.Offset + startOffset,
                range.Count.HasValue ?
                    range.Count.Value - startOffset :
                    default);

            this.Pipeline.LogTrace($"Download {this.Uri} with range: {pageRange}");

            var response =
                await BlobRestClient.Blob.DownloadAsync(
                    this.Pipeline,
                    this.Uri,
                    range: pageRange.ToRange(),
                    leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                    rangeGetContentHash: rangeGetContentHash ? (bool?)true : null,
                    ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                    ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                    ifMatch: accessConditions?.HttpAccessConditions?.IfMatch,
                    ifNoneMatch: accessConditions?.HttpAccessConditions?.IfNoneMatch,
                    cancellation: cancellation)
                    .ConfigureAwait(false);

            this.Pipeline.LogTrace($"Response: {response.Raw.Status}, ContentLength: {response.Value.ContentLength}");

            return response;
        }

        /// <summary>
        /// The <see cref="StartCopyFromUriAsync"/> operation copies data at
        /// from the <paramref name="source"/> to this blob.  You can check
        /// the <see cref="BlobProperties.CopyStatus"/> returned from the
        /// <see cref="GetPropertiesAsync"/> to determine if the copy has
        /// completed.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob" />.
        /// </summary>
        /// <param name="source">
        /// Specifies the <see cref="Uri"/> of the source blob.  The value may
        /// be a <see cref="Uri" /> of up to 2 KB in length that specifies a
        /// blob.  A source blob in the same storage account can be 
        /// authenticated via Shared Key.  However, if the source is a blob in
        /// another account, the source blob must either be public or must be
        /// authenticated via a shared access signature. If the source blob
        /// is public, no authentication is required to perform the copy
        /// operation.
        /// 
        /// The source object may be a file in the Azure File service.  If the
        /// source object is a file that is to be copied to a blob, then the
        /// source file must be authenticated using a shared access signature,
        /// whether it resides in the same account or in a different account.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this blob.
        /// </param>
        /// <param name="sourceAccessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="destinationAccessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// the copying of data to this blob.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{BlobCopyInfo}}"/> describing the
        /// state of the copy operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<BlobCopyInfo>> StartCopyFromUriAsync(
            Uri source, 
            Metadata metadata = default, 
            BlobAccessConditions? sourceAccessConditions = default, 
            BlobAccessConditions? destinationAccessConditions = default,
            CancellationToken cancellation = default)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(BlobClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(source)}: {source}\n" +
                    $"{nameof(sourceAccessConditions)}: {sourceAccessConditions}\n" +
                    $"{nameof(destinationAccessConditions)}: {destinationAccessConditions}");
                try
                {
                    return await BlobRestClient.Blob.StartCopyFromUriAsync(
                        this.Pipeline,
                        this.Uri,
                        copySource: source,
                        sourceIfModifiedSince: sourceAccessConditions?.HttpAccessConditions?.IfModifiedSince,
                        sourceIfUnmodifiedSince: sourceAccessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        sourceIfMatch: sourceAccessConditions?.HttpAccessConditions?.IfMatch,
                        sourceIfNoneMatch: sourceAccessConditions?.HttpAccessConditions?.IfNoneMatch,
                        ifModifiedSince: destinationAccessConditions?.HttpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: destinationAccessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        ifMatch: destinationAccessConditions?.HttpAccessConditions?.IfMatch,
                        ifNoneMatch: destinationAccessConditions?.HttpAccessConditions?.IfNoneMatch,                    
                        leaseId: destinationAccessConditions?.LeaseAccessConditions?.LeaseId,
                        metadata: metadata,
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
                    this.Pipeline.LogMethodExit(nameof(BlobClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="AbortCopyFromUriAsync"/> operation aborts a pending
        /// <see cref="StartCopyFromUriAsync"/> operation, and leaves a this
        /// blob with zero length and full metadata.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/abort-copy-blob" />.
        /// </summary>
        /// <param name="copyId">
        /// ID of the copy operation to abort.
        /// </param>
        /// <param name="leaseAccessConditions">
        /// Optional <see cref="LeaseAccessConditions"/> to add
        /// conditions on aborting the copy operation.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response}"/> on successfully aborting.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response> AbortCopyFromUriAsync(
            string copyId, 
            LeaseAccessConditions? leaseAccessConditions = default,
            CancellationToken cancellation = default)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(BlobClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(copyId)}: {copyId}\n" +
                    $"{nameof(leaseAccessConditions)}: {leaseAccessConditions}");
                try
                {
                    return await BlobRestClient.Blob.AbortCopyFromUriAsync(
                        this.Pipeline,
                        this.Uri,
                        copyId: copyId,
                        leaseId: leaseAccessConditions?.LeaseId,
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
                    this.Pipeline.LogMethodExit(nameof(BlobClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="DeleteAsync"/> operation marks the specified blob
        /// or snapshot for  deletion. The blob is later deleted during
        /// garbage collection.
        /// 
        /// Note that in order to delete a blob, you must delete all of its
        /// snapshots. You can delete both at the same time using 
        /// <see cref="DeleteSnapshotsOption.Include"/>.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-blob" />.
        /// </summary>
        /// <param name="deleteOptions">
        /// Specifies options for deleting blob snapshots.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// deleting this blob.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response}"/> on successfully deleting.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public StorageTask<Response> DeleteAsync(
            DeleteSnapshotsOption? deleteOptions = default,
            BlobAccessConditions? accessConditions = default,
            CancellationToken cancellation = default)
        => StorageTask.Create(
            pipeline: this.Pipeline,
            cancellationToken: cancellation,
            operation:
                async (pipeline, cancel) =>
                {
                    using (pipeline.BeginLoggingScope(nameof(BlobClient)))
                    {
                        pipeline.LogMethodEnter(
                            nameof(BlobClient),
                            message:
                            $"{nameof(this.Uri)}: {this.Uri}\n" +
                            $"{nameof(deleteOptions)}: {deleteOptions}\n" +
                            $"{nameof(accessConditions)}: {accessConditions}");
                        try
                        {
                            return await BlobRestClient.Blob.DeleteAsync(
                                pipeline,
                                this.Uri,
                                leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                                deleteSnapshots: deleteOptions,
                                ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                                ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                                ifMatch: accessConditions?.HttpAccessConditions?.IfMatch,
                                ifNoneMatch: accessConditions?.HttpAccessConditions?.IfNoneMatch,
                                cancellation: cancel)
                                .ConfigureAwait(false);
                        }
                        catch (Exception ex)
                        {
                            pipeline.LogException(ex);
                            throw;
                        }
                        finally
                        {
                            pipeline.LogMethodExit(nameof(BlobClient));
                        }
                    }
                });

        /// <summary>
        /// The <see cref="UndeleteAsync"/> operation restores the contents
        /// and metadata of a soft deleted blob and any associated soft
        /// deleted snapshots.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/undelete-blob" />.
        /// </summary>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response}"/> on successfully deleting.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response> UndeleteAsync(
            CancellationToken cancellation = default)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobClient)))
            {
                this.Pipeline.LogMethodEnter(nameof(BlobClient), message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await BlobRestClient.Blob.UndeleteAsync(
                        this.Pipeline,
                        this.Uri,
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
                    this.Pipeline.LogMethodExit(nameof(BlobClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="GetAccountInfoAsync"/> operation returns the sku
        /// name and account kind for the account of the blob.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-account-information" />.
        /// </summary>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{AccountInfo}}"/> describing the account.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if a
        /// failure occurs.
        /// </remarks>
        public async Task<Response<AccountInfo>> GetAccountInfoAsync(
            CancellationToken cancellation = default)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobClient)))
            {
                this.Pipeline.LogMethodEnter(nameof(BlobClient), message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await BlobRestClient.Blob.GetAccountInfoAsync(
                        this.Pipeline,
                        this.Uri,
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
                    this.Pipeline.LogMethodExit(nameof(BlobClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="GetPropertiesAsync"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the blob. It does not return the content of the
        /// blob.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob-properties" />.
        /// </summary>
        /// <param name="accessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add
        /// conditions on getting the blob's properties.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{BlobProperties}}"/> describing the
        /// blob's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<BlobProperties>> GetPropertiesAsync(
            BlobAccessConditions? accessConditions = default,
            CancellationToken cancellation = default)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(BlobClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    return await BlobRestClient.Blob.GetPropertiesAsync(
                        this.Pipeline,
                        this.Uri,
                        leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
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
                    this.Pipeline.LogMethodExit(nameof(BlobClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="SetHttpHeadersAsync"/> operation sets system
        /// properties on the blob.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-properties" />.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional. The standard HTTP header system properties to set.  If not specified, existing values will be cleared.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// setting the blob's HTTP headers.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{BlobInfo}}"/> describing the updated
        /// blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<BlobInfo>> SetHttpHeadersAsync(
            BlobHttpHeaders? httpHeaders = default,
            BlobAccessConditions? accessConditions = default,
            CancellationToken cancellation = default)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(BlobClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(httpHeaders)}: {httpHeaders}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    var response =
                        await BlobRestClient.Blob.SetHttpHeadersAsync(
                            this.Pipeline,
                            this.Uri,
                            blobCacheControl: httpHeaders?.CacheControl,
                            blobContentType: httpHeaders?.ContentType,
                            blobContentHash: httpHeaders?.ContentHash,
                            blobContentEncoding: httpHeaders?.ContentEncoding,
                            blobContentLanguage: httpHeaders?.ContentLanguage,
                            blobContentDisposition: httpHeaders?.ContentDisposition,
                            leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                            ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                            ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                            ifMatch: accessConditions?.HttpAccessConditions?.IfMatch,
                            ifNoneMatch: accessConditions?.HttpAccessConditions?.IfNoneMatch,
                            cancellation: cancellation)
                            .ConfigureAwait(false);
                    return new Response<BlobInfo>(
                        response.Raw,
                        new BlobInfo
                        {
                            LastModified = response.Value.LastModified,
                            ETag = response.Value.ETag,
                            BlobSequenceNumber = response.Value.BlobSequenceNumber
                        });
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(BlobClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="SetMetadataAsync"/> operation sets user-defined 
        /// metadata for the specified blob as one or more name-value pairs.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-metadata" />.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this blob.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// setting the blob's metadata.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{BlobInfo}}"/> describing the updated
        /// blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<BlobInfo>> SetMetadataAsync(
            Metadata metadata, 
            BlobAccessConditions? accessConditions = default,
            CancellationToken cancellation = default)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(BlobClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    var response =
                        await BlobRestClient.Blob.SetMetadataAsync(
                            this.Pipeline,
                            this.Uri,
                            metadata: metadata,
                            leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                            ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                            ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                            ifMatch: accessConditions?.HttpAccessConditions?.IfMatch,
                            ifNoneMatch: accessConditions?.HttpAccessConditions?.IfNoneMatch,
                            cancellation: cancellation)
                            .ConfigureAwait(false);
                    return new Response<BlobInfo>(
                        response.Raw,
                        new BlobInfo
                        {
                            LastModified = response.Value.LastModified,
                            ETag = response.Value.ETag
                        });
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(BlobClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="CreateSnapshotAsync"/> operation creates a
        /// read-only snapshot of a blob.
        /// 
        /// For more infomration, see <see href="https://docs.microsoft.com/rest/api/storageservices/snapshot-blob" />.
        /// </summary>
        /// <param name="metadata">
        /// Optional custom metadata to set for this blob snapshot.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// setting creating this snapshot.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{BlobSnapshotInfo}}"/> describing the
        /// new blob snapshot.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<BlobSnapshotInfo>> CreateSnapshotAsync(
            Metadata metadata = default, 
            BlobAccessConditions? accessConditions = default,
            CancellationToken cancellation = default)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(BlobClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    return await BlobRestClient.Blob.CreateSnapshotAsync(
                        this.Pipeline,
                        this.Uri,
                        metadata: metadata,
                        ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        ifMatch: accessConditions?.HttpAccessConditions?.IfMatch,
                        ifNoneMatch: accessConditions?.HttpAccessConditions?.IfNoneMatch,
                        leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
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
                    this.Pipeline.LogMethodExit(nameof(BlobClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="AcquireLeaseAsync"/> operation acquires a lease on
        /// the blob for write and delete operations.  The lease 
        /// <paramref name="duration"/> must be between 15 to 60 seconds, or
        /// infinite (-1).
        /// 
        /// If the blob does not have an active lease, the Blob service
        /// creates a lease on the blob and returns it.  If the blob has an
        /// active lease, you can only request a new lease using the active
        /// lease ID as <paramref name="proposedId"/>, but you can specify a
        /// new <paramref name="duration"/>.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-blob" />.
        /// </summary>
        /// <param name="duration">
        /// Specifies the duration of the lease, in seconds, or -1 for a lease
        /// that never expires.  A non-infinite lease can be between 15 and
        /// 60 seconds. A lease duration cannot be changed using
        /// <see cref="RenewLeaseAsync"/> or <see cref="ChangeLeaseAsync"/>.
        /// </param>
        /// <param name="proposedId">
        /// An optional proposed lease ID, in a GUID string format. A
        /// <see cref="StorageRequestFailedException"/> will be thrown if the
        /// proposed lease ID is not in the correct format.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="HttpAccessConditions"/> to add
        /// conditions on acquiring a lease.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{Lease}}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<Lease>> AcquireLeaseAsync( 
            int duration,
            string proposedID = default,
            HttpAccessConditions? httpAccessConditions = default,
            CancellationToken cancellation = default)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(BlobClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(proposedID)}: {proposedID}\n" +
                    $"{nameof(duration)}: {duration}");
                try
                {
                    return await BlobRestClient.Blob.AcquireLeaseAsync(
                        this.Pipeline,
                        this.Uri,
                        duration: duration,
                        proposedLeaseId: proposedID,
                        ifModifiedSince: httpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: httpAccessConditions?.IfUnmodifiedSince,
                        ifMatch: httpAccessConditions?.IfMatch,
                        ifNoneMatch: httpAccessConditions?.IfNoneMatch,
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
                    this.Pipeline.LogMethodExit(nameof(BlobClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="RenewLeaseAsync"/> operation renews the blob's
        /// previously-acquired lease.
        /// 
        /// The lease can be renewed if the <paramref name="leaseId"/> 
        /// matches that associated with the blob.  Note that the lease may be
        /// renewed even if it has expired as long as the blob has not been
        /// modified or leased again since the expiration of that lease.  When
        /// you renew a lease, the lease duration clock resets.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-blob" />.
        /// </summary>
        /// <param name="leaseId">
        /// The ID of the lease to be renewed.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="HttpAccessConditions"/> to add
        /// conditions on renewing a lease.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{Lease}}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<Lease>> RenewLeaseAsync(
            string leaseID, 
            HttpAccessConditions? httpAccessConditions = default,
            CancellationToken cancellation = default)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(BlobClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(leaseID)}: {leaseID}\n" +
                    $"{nameof(httpAccessConditions)}: {httpAccessConditions}");
                try
                {
                    return await BlobRestClient.Blob.RenewLeaseAsync(
                        this.Pipeline,
                        this.Uri,
                        leaseId: leaseID,
                        ifModifiedSince: httpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: httpAccessConditions?.IfUnmodifiedSince,
                        ifMatch: httpAccessConditions?.IfMatch,
                        ifNoneMatch: httpAccessConditions?.IfNoneMatch,
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
                    this.Pipeline.LogMethodExit(nameof(BlobClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="ReleaseLeaseAsync"/> operation releases the 
        /// blob's previously-acquired lease.
        /// 
        /// The lease may be released if the <paramref name="leaseId"/>
        /// matches that associated with the blob.  Releasing the lease allows 
        /// another client to immediately acquire the lease for the blob as
        /// soon as the release is complete.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-blob" />.
        /// </summary>
        /// <param name="leaseId">
        /// The ID of the lease to be released.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="ContainerAccessConditions"/> to add
        /// conditions on releasing a lease.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{BlobInfo}}"/> describing the updated
        /// blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<BlobInfo>> ReleaseLeaseAsync(
            string leaseID,
            HttpAccessConditions? httpAccessConditions = default,
            CancellationToken cancellation = default)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(BlobClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(leaseID)}: {leaseID}\n" +
                    $"{nameof(httpAccessConditions)}: {httpAccessConditions}");
                try
                {
                    return await BlobRestClient.Blob.ReleaseLeaseAsync(
                        this.Pipeline,
                        this.Uri,
                        leaseId: leaseID,
                        ifModifiedSince: httpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: httpAccessConditions?.IfUnmodifiedSince,
                        ifMatch: httpAccessConditions?.IfMatch,
                        ifNoneMatch: httpAccessConditions?.IfNoneMatch,
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
                    this.Pipeline.LogMethodExit(nameof(BlobClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="BreakLeaseAsync"/> operation breaks the blob's
        /// previously-acquired lease (if it exists).
        /// 
        /// Once a lease is broken, it cannot be renewed.  Any authorized 
        /// request can break the lease; the request is not required to
        /// specify a matching lease ID.  When a lease is broken, the lease
        /// break <paramref name="period"/> is allowed to elapse, during which
        /// time no lease operation except <see cref="BreakLeaseAsync"/> and
        /// <see cref="ReleaseLeaseAsync"/> can be performed on the blob.
        /// When a lease is successfully broken, the response indicates the
        /// interval in seconds until a new lease can be acquired.
        /// 
        /// A lease that has been broken can also be released.  A client can
        /// immediately acquire a blob lease that has been released.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-blob" />.
        /// </summary>
        /// <param name="period">
        /// Specifies the proposed duration the lease should continue before
        /// it is broken, in seconds, between 0 and 60.  This break period is
        /// only used if it is shorter than the time remaining on the lease.
        /// If longer, the time remaining on the lease is used.  A new lease
        /// will not be available before the break period has expired, but the
        /// lease may be held for longer than the break period.  If this value
        /// is not provided, a fixed-duration lease breaks after the remaining
        /// lease period elapses, and an infinite lease breaks immediately.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="HttpAccessConditions"/> to add
        /// conditions on breaking a lease.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{Lease}}"/> describing the broken lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<Lease>> BreakLeaseAsync(
            int? breakPeriodInSeconds = default, 
            HttpAccessConditions? httpAccessConditions = default,
            CancellationToken cancellation = default)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(BlobClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    "{nameof(breakPeriodInSeconds)}: {breakPeriodInSeconds}\n" +
                    "{nameof(httpAccessConditions)}: {httpAccessConditions}");
                try
                {
                    return (await BlobRestClient.Blob.BreakLeaseAsync(
                        this.Pipeline,
                        this.Uri,
                        breakPeriod: breakPeriodInSeconds,
                        ifModifiedSince: httpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: httpAccessConditions?.IfUnmodifiedSince,
                        ifMatch: httpAccessConditions?.IfMatch,
                        ifNoneMatch: httpAccessConditions?.IfNoneMatch,
                        cancellation: cancellation)
                        .ConfigureAwait(false))
                        .ToLease();
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(BlobClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="ChangeLeaseAsync"/> operation changes the lease 
        /// of an active lease.  A change must include the current
        /// <paramref name="leaseId"/> and a new
        /// <paramref name="proposedId"/>.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-blob" />.
        /// </summary>
        /// <param name="leaseId">
        /// The ID of the lease to be changed.
        /// </param>
        /// <param name="proposedId">
        /// An optional proposed lease ID, in a GUID string format. A
        /// <see cref="StorageRequestFailedException"/> will be thrown if the
        /// proposed lease ID is not in the correct format.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="HttpAccessConditions"/> to add conditions on
        /// changing a lease.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{Lease}}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<Lease>> ChangeLeaseAsync(
            string leaseID,
            string proposedID, 
            HttpAccessConditions? httpAccessConditions = default,
            CancellationToken cancellation = default)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(BlobClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(leaseID)}: {leaseID}\n" +
                    $"{nameof(proposedID)}: {proposedID}\n" +
                    $"{nameof(httpAccessConditions)}: {httpAccessConditions}");
                try
                {
                    return await BlobRestClient.Blob.ChangeLeaseAsync(
                        this.Pipeline,
                        this.Uri,
                        leaseId: leaseID,
                        proposedLeaseId: proposedID,
                        ifModifiedSince: httpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: httpAccessConditions?.IfUnmodifiedSince,
                        ifMatch: httpAccessConditions?.IfMatch,
                        ifNoneMatch: httpAccessConditions?.IfNoneMatch,
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
                    this.Pipeline.LogMethodExit(nameof(BlobClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="SetTierAsync"/> operation sets the tier on a blob.
        /// The operation is allowed on a page blob in a premium storage
        /// account and on a block blob in a blob storage or general purpose
        /// v2 account.
        /// 
        /// A premium page blob's tier determines the allowed size, IOPS, and
        /// bandwidth of the blob.  A block blob's tier determines
        /// Hot/Cool/Archive storage type.  This operation does not update the
        /// blob's ETag.  For detailed information about block blob level
        /// tiering <see href="https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blob-storage-tiers" />
        /// 
        /// For more information about setting the tier, see
        /// <see href="https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blob-storage-tiers" />.
        /// </summary>
        /// <param name="accessTier">
        /// Indicates the tier to be set on the blob.
        /// </param>
        /// <param name="leaseAccessConditions">
        /// Optional <see cref="LeaseAccessConditions"/> to add conditions on
        /// setting the access tier.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response}"/> on successfully setting the tier.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public StorageTask<Response> SetTierAsync(
            AccessTier accessTier,
            LeaseAccessConditions? leaseAccessConditions = default,
            CancellationToken cancellation = default)
            => StorageTask.Create(
                pipeline: this.Pipeline,
                cancellationToken: cancellation,
                operation:
                    async (pipeline, cancel) =>
                    {
                        using (pipeline.BeginLoggingScope(nameof(BlobClient)))
                        {
                            pipeline.LogMethodEnter(
                                nameof(BlobClient),
                                message:
                                $"{nameof(this.Uri)}: {this.Uri}\n" +
                                $"{nameof(accessTier)}: {accessTier}\n" +
                                $"{nameof(leaseAccessConditions)}: {leaseAccessConditions}");
                            try
                            {
                                return await BlobRestClient.Blob.SetTierAsync(
                                    pipeline,
                                    this.Uri,
                                    tier: accessTier,
                                    leaseId: leaseAccessConditions?.LeaseId,
                                    cancellation: cancel)
                                    .ConfigureAwait(false);
                            }
                            catch (Exception ex)
                            {
                                pipeline.LogException(ex);
                                throw;
                            }
                            finally
                            {
                                pipeline.LogMethodExit(nameof(BlobClient));
                            }
                        }
                    });
    }
}

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobInfo
    /// </summary>
    public partial class BlobInfo
    {
        /// <summary>
        /// The current sequence number for a page blob. This header is not
        /// returned for block blobs or append blobs
        /// </summary>
        public long BlobSequenceNumber { get; internal set; }
    }

    /// <summary>
    /// The properties and Content returned from downloading a blob
    /// </summary>
    public partial class BlobDownloadInfo
    {
        /// <summary>
        /// Internal flattened property representation
        /// </summary>
        internal FlattenedDownloadProperties _flattened;

        /// <summary>
        /// The blob's type.
        /// </summary>
        public BlobType BlobType => this._flattened.BlobType;

        /// <summary>
        /// The number of bytes present in the response body.
        /// </summary>
        public long ContentLength => this._flattened.ContentLength;

        /// <summary>
        /// Content
        /// </summary>
        public Stream Content => this._flattened.Content;

        /// <summary>
        /// If the blob has an MD5 hash and this operation is to read the full blob, this response header is returned so that the client can check for message content integrity.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash => this._flattened.ContentHash;
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// Properties returned when downloading a Blob
        /// </summary>
        public BlobDownloadProperties Properties { get; private set; }
        
        /// <summary>
        /// Creates a new DownloadInfo backed by FlattenedDownloadProperties
        /// </summary>
        /// <param name="flattened">The FlattenedDownloadProperties returned with the request</param>
        internal BlobDownloadInfo(FlattenedDownloadProperties flattened)
        {
            this._flattened = flattened;
            this.Properties = new BlobDownloadProperties() { _flattened = flattened };
        }
    }

    /// <summary>
    /// Properties returned when downloading a Blob
    /// </summary>
    public partial class BlobDownloadProperties
    {
        /// <summary>
        /// Internal flattened property representation
        /// </summary>
        internal FlattenedDownloadProperties _flattened;

        /// <summary>
        /// Returns the date and time the container was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public DateTimeOffset LastModified => this._flattened.LastModified;

        /// <summary>
        /// x-ms-meta
        /// </summary>
        public IDictionary<string, string> Metadata => this._flattened.Metadata;

        /// <summary>
        /// The media type of the body of the response. For Download Blob this is 'application/octet-stream'
        /// </summary>
        public string ContentType => this._flattened.ContentType;

        /// <summary>
        /// Indicates the range of bytes returned in the event that the client requested a subset of the blob by setting the 'Range' request header.
        /// </summary>
        public string ContentRange => this._flattened.ContentRange;

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public ETag ETag => this._flattened.ETag;

        /// <summary>
        /// This header returns the value that was specified for the Content-Encoding request header
        /// </summary>
        public string ContentEncoding => this._flattened.ContentEncoding;

        /// <summary>
        /// This header is returned if it was previously specified for the blob.
        /// </summary>
        public string CacheControl => this._flattened.CacheControl;

        /// <summary>
        /// This header returns the value that was specified for the 'x-ms-blob-content-disposition' header. The Content-Disposition response header field conveys additional information about how to process the response payload, and also can be used to attach additional metadata. For example, if set to attachment, it indicates that the user-agent should not display the response, but instead show a Save As dialog with a filename other than the blob name specified.
        /// </summary>
        public string ContentDisposition => this._flattened.ContentDisposition;

        /// <summary>
        /// This header returns the value that was specified for the Content-Language request header.
        /// </summary>
        public string ContentLanguage => this._flattened.ContentLanguage;

        /// <summary>
        /// The current sequence number for a page blob. This header is not returned for block blobs or append blobs
        /// </summary>
        public long BlobSequenceNumber => this._flattened.BlobSequenceNumber;
        
        /// <summary>
        /// Conclusion time of the last attempted Copy Blob operation where this blob was the destination blob. This value can specify the time of a completed, aborted, or failed copy attempt. This header does not appear if a copy is pending, if this blob has never been the destination in a Copy Blob operation, or if this blob has been modified after a concluded Copy Blob operation using Set Blob Properties, Put Blob, or Put Block List.
        /// </summary>
        public DateTimeOffset CopyCompletionTime => this._flattened.CopyCompletionTime;

        /// <summary>
        /// Only appears when x-ms-copy-status is failed or pending. Describes the cause of the last fatal or non-fatal copy operation failure. This header does not appear if this blob has never been the destination in a Copy Blob operation, or if this blob has been modified after a concluded Copy Blob operation using Set Blob Properties, Put Blob, or Put Block List
        /// </summary>
        public string CopyStatusDescription => this._flattened.CopyStatusDescription;

        /// <summary>
        /// String identifier for this copy operation. Use with Get Blob Properties to check the status of this copy operation, or pass to Abort Copy Blob to abort a pending copy.
        /// </summary>
        public string CopyId => this._flattened.CopyId;

        /// <summary>
        /// Contains the number of bytes copied and the total bytes in the source in the last attempted Copy Blob operation where this blob was the destination blob. Can show between 0 and Content-Length bytes copied. This header does not appear if this blob has never been the destination in a Copy Blob operation, or if this blob has been modified after a concluded Copy Blob operation using Set Blob Properties, Put Blob, or Put Block List
        /// </summary>
        public string CopyProgress => this._flattened.CopyProgress;

        /// <summary>
        /// URL up to 2 KB in length that specifies the source blob or file used in the last attempted Copy Blob operation where this blob was the destination blob. This header does not appear if this blob has never been the destination in a Copy Blob operation, or if this blob has been modified after a concluded Copy Blob operation using Set Blob Properties, Put Blob, or Put Block List.
        /// </summary>
        public Uri CopySource => this._flattened.CopySource;

        /// <summary>
        /// State of the copy operation identified by x-ms-copy-id.
        /// </summary>
        public CopyStatus CopyStatus => this._flattened.CopyStatus;

        /// <summary>
        /// When a blob is leased, specifies whether the lease is of infinite or fixed duration.
        /// </summary>
        public LeaseDurationType LeaseDuration => this._flattened.LeaseDuration;

        /// <summary>
        /// Lease state of the blob.
        /// </summary>
        public LeaseState LeaseState => this._flattened.LeaseState;

        /// <summary>
        /// The current lease status of the blob.
        /// </summary>
        public LeaseStatus LeaseStatus => this._flattened.LeaseStatus;

        /// <summary>
        /// This header uniquely identifies the request that was made and can be used for troubleshooting the request.
        /// </summary>
        public string RequestId => this._flattened.RequestId;

        /// <summary>
        /// Indicates the version of the Blob service used to execute the request. This header is returned for requests made against version 2009-09-19 and above.
        /// </summary>
        public string Version => this._flattened.Version;

        /// <summary>
        /// Indicates that the service supports requests for partial blob content.
        /// </summary>
        public string AcceptRanges => this._flattened.AcceptRanges;

        /// <summary>
        /// UTC date/time value generated by the service that indicates the time at which the response was initiated
        /// </summary>
        public DateTimeOffset Date => this._flattened.Date;

        /// <summary>
        /// The number of committed blocks present in the blob. This header is returned only for append blobs.
        /// </summary>
        public int BlobCommittedBlockCount => this._flattened.BlobCommittedBlockCount;

        /// <summary>
        /// The value of this header is set to true if the blob data and application metadata are completely encrypted using the specified algorithm. Otherwise, the value is set to false (when the blob is unencrypted, or if only parts of the blob/application metadata are encrypted).
        /// </summary>
        public bool IsServerEncrypted => this._flattened.IsServerEncrypted;

        /// <summary>
        /// If the blob has a MD5 hash, and if request contains range header (Range or x-ms-range), this response header is returned with the value of the whole blob's MD5 value. This value may or may not be equal to the value returned in Content-MD5 header, with the latter calculated from the requested range
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] BlobContentHash => this._flattened.BlobContentHash;
#pragma warning restore CA1819 // Properties should not return arrays
    }

    // public partial interface IBlobDeleteAcceptedResponseHeaders : IBatchable { }

    // public partial interface IBlobSetTierOKResponseHeaders : IBatchable { }
}
