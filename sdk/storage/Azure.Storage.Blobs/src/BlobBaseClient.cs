// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Http;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Common;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Specialized
{
    /// <summary>
    /// The <see cref="BlobClient"/> allows you to manipulate Azure Storage
    /// blobs.
    /// </summary>
	public class BlobBaseClient
    {
        /// <summary>
        /// The blob's primary <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _uri;

        /// <summary>
        /// Gets the blob's primary <see cref="Uri"/> endpoint.
        /// </summary>
        public virtual Uri Uri => this._uri;

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send
        /// every request.
        /// </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send
        /// every request.
        /// </summary>
        protected internal virtual HttpPipeline Pipeline => this._pipeline;

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/>
        /// class.
        /// </summary>
        protected BlobBaseClient()
        {
        }

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
        public BlobBaseClient(string connectionString, string containerName, string blobName)
            : this(connectionString, containerName, blobName, null)
        {
        }

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
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobBaseClient(string connectionString, string containerName, string blobName, BlobClientOptions options)
        {
            var conn = StorageConnectionString.Parse(connectionString);
            var builder =
                new BlobUriBuilder(conn.BlobEndpoint)
                {
                    ContainerName = containerName,
                    BlobName = blobName
                };
            this._uri = builder.ToUri();
            this._pipeline = (options ?? new BlobClientOptions()).Build(conn.Credentials);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobBaseClient(Uri blobUri, BlobClientOptions options = default)
            : this(blobUri, (HttpPipelinePolicy)null, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/>
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
        public BlobBaseClient(Uri blobUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            : this(blobUri, credential.AsPolicy(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/>
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
        public BlobBaseClient(Uri blobUri, TokenCredential credential, BlobClientOptions options = default)
            : this(blobUri, credential.AsPolicy(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// </param>
        /// <param name="authentication">
        /// An optional authentication policy used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        internal BlobBaseClient(Uri blobUri, HttpPipelinePolicy authentication, BlobClientOptions options)
        {
            this._uri = blobUri;
            this._pipeline = (options ?? new BlobClientOptions()).Build(authentication);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        internal BlobBaseClient(Uri blobUri, HttpPipeline pipeline)
        {
            this._uri = blobUri;
            this._pipeline = pipeline;
        }
        #endregion ctors

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
        public virtual BlobBaseClient WithSnapshot(string snapshot) => this.WithSnapshotImpl(snapshot);

        /// <summary>
        /// Creates a new instance of the <see cref="BlobClient"/> class
        /// with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="snapshot"/> timestamp.
        /// </summary>
        /// <param name="snapshot">The snapshot identifier.</param>
        /// <returns>A new <see cref="BlobClient"/> instance.</returns>
        protected virtual BlobBaseClient WithSnapshotImpl(string snapshot)
        {
            var builder = new BlobUriBuilder(this.Uri) { Snapshot = snapshot };
            return new BlobBaseClient(builder.ToUri(), this.Pipeline);
        }

        ///// <summary>
        ///// Creates a clone of this instance that references a version ID rather than the base blob.
        ///// </summary>
        ///// /// <remarks>
        ///// Pass null or empty string to remove the verion ID returning a URL to the base blob.
        ///// </remarks>
        ///// <param name="versionId">The version ID to use on this blob. An empty string or null indicates to use the base blob.</param>
        ///// <returns>The new <see cref="BlobClient"/> instance referencing the verionId.</returns>
        //public virtual BlobBaseClient WithVersionId(string versionId) => this.WithVersionIdImpl(versionId);

        //protected virtual BlobBaseClient WithVersionIdImpl(string versionId)
        //{
        //    var builder = new BlobUriBuilder(this.Uri)
        //    {
        //        VersionId = versionId
        //    };
        //    return new BlobUri(builder.ToUri(), this.Pipeline);
        //}

        #region Download
        /// <summary>
        /// The <see cref="Download()"/> operation downloads a blob from
        /// the service, including its metadata and properties.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob" />.
        /// </summary>
        /// <returns>
        /// A <see cref="Response{BlobDownloadInfo}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadInfo.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // Client method should have cancellationToken as the last optional parameter
        public virtual Response<BlobDownloadInfo> Download() =>
            this.Download(CancellationToken.None);
#pragma warning restore AZC0002 // Client method should have cancellationToken as the last optional parameter

        /// <summary>
        /// The <see cref="DownloadAsync()"/> operation downloads a blob from
        /// the service, including its metadata and properties.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob" />.
        /// </summary>
        /// <returns>
        /// A <see cref="Response{BlobDownloadInfo}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadInfo.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // Client method should have cancellationToken as the last optional parameter
        public virtual async Task<Response<BlobDownloadInfo>> DownloadAsync() =>
            await this.DownloadAsync(CancellationToken.None).ConfigureAwait(false);
#pragma warning restore AZC0002 // Client method should have cancellationToken as the last optional parameter

        /// <summary>
        /// The <see cref="Download(CancellationToken)"/> operation downloads
        /// a blob from the service, including its metadata and properties.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob" />.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobDownloadInfo}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadInfo.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobDownloadInfo> Download(
            CancellationToken cancellationToken = default) =>
            this.Download(
                accessConditions: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="DownloadAsync(CancellationToken)"/> operation
        /// downloads a blob from the service, including its metadata and
        /// properties.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob" />.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobDownloadInfo}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadInfo.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // Client method should have cancellationToken as the last optional parameter
        public virtual async Task<Response<BlobDownloadInfo>> DownloadAsync(
            CancellationToken cancellationToken) =>
            await this.DownloadAsync(
                accessConditions: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
#pragma warning restore AZC0002 // Client method should have cancellationToken as the last optional parameter

        /// <summary>
        /// The <see cref="Download(HttpRange, BlobAccessConditions?, CustomerProvidedKey?, Boolean, CancellationToken)"/>
        /// operation downloads a blob from the service, including its metadata
        /// and properties.
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
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="rangeGetContentHash">
        /// When set to true and specified together with the <paramref name="range"/>,
        /// the service returns the MD5 hash for the range, as long as the
        /// range is less than or equal to 4 MB in size.  If this value is
        /// specified without <paramref name="range"/> or set to true when the
        /// range exceeds 4 MB in size, a <see cref="StorageRequestFailedException"/>
        /// is thrown.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobDownloadInfo}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadInfo.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobDownloadInfo> Download(
            HttpRange range = default,
            BlobAccessConditions? accessConditions = default,
            CustomerProvidedKey? customerProvidedKey = default,
            bool rangeGetContentHash = default,
            CancellationToken cancellationToken = default) =>
            this.DownloadInternal(
                range,
                accessConditions,
                customerProvidedKey,
                rangeGetContentHash,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="DownloadAsync(HttpRange, BlobAccessConditions?, CustomerProvidedKey?, Boolean, CancellationToken)"/>
        /// operation downloads a blob from the service, including its metadata
        /// and properties.
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
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="rangeGetContentHash">
        /// When set to true and specified together with the <paramref name="range"/>,
        /// the service returns the MD5 hash for the range, as long as the
        /// range is less than or equal to 4 MB in size.  If this value is
        /// specified without <paramref name="range"/> or set to true when the
        /// range exceeds 4 MB in size, a <see cref="StorageRequestFailedException"/>
        /// is thrown.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobDownloadInfo}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadInfo.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobDownloadInfo>> DownloadAsync(
            HttpRange range = default,
            BlobAccessConditions? accessConditions = default,
            CustomerProvidedKey? customerProvidedKey = default,
            bool rangeGetContentHash = default,
            CancellationToken cancellationToken = default) =>
            await this.DownloadInternal(
                range,
                accessConditions,
                customerProvidedKey,
                rangeGetContentHash,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DownloadInternal"/> operation downloads a blob
        /// from the service, including its metadata and properties.
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
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="rangeGetContentHash">
        /// When set to true and specified together with the <paramref name="range"/>,
        /// the service returns the MD5 hash for the range, as long as the
        /// range is less than or equal to 4 MB in size.  If this value is
        /// specified without <paramref name="range"/> or set to true when the
        /// range exceeds 4 MB in size, a <see cref="StorageRequestFailedException"/>
        /// is thrown.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobDownloadInfo}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadInfo.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobDownloadInfo>> DownloadInternal(
            HttpRange range,
            BlobAccessConditions? accessConditions,
            CustomerProvidedKey? customerProvidedKey,
            bool rangeGetContentHash,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                this.Pipeline.LogMethodEnter(nameof(BlobBaseClient), message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    // Start downloading the blob
                    var response = await this.StartDownloadAsync(
                        range,
                        accessConditions,
                        customerProvidedKey,
                        rangeGetContentHash,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    // Wrap the response Content in a RetriableStream so we
                    // can return it before it's finished downloading, but still
                    // allow retrying if it fails.
                    response.Value.Content = RetriableStream.Create(
                        response.GetRawResponse(),
                         startOffset =>
                            this.StartDownloadAsync(
                                    range,
                                    accessConditions,
                                    customerProvidedKey,
                                    rangeGetContentHash,
                                    startOffset,
                                    async,
                                    cancellationToken)
                                .ConfigureAwait(false).GetAwaiter().GetResult()
                            .GetRawResponse(),
                        async startOffset =>
                            (await this.StartDownloadAsync(
                                range,
                                accessConditions,
                                customerProvidedKey,
                                rangeGetContentHash,
                                startOffset,
                                async,
                                cancellationToken)
                                .ConfigureAwait(false))
                            .GetRawResponse(),
                        // TODO: For now we're using the default ResponseClassifier
                        // on BlobConnectionOptions so we'll do the same here
                        new ResponseClassifier(),
                        Constants.MaxReliabilityRetries);

                    // Wrap the FlattenedDownloadProperties into a BlobDownloadOperation
                    // to make the Content easier to find
                    return new Response<BlobDownloadInfo>(response.GetRawResponse(), new BlobDownloadInfo(response.Value));
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(BlobBaseClient));
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
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
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
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobDownloadInfo}"/> describing the
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
            CustomerProvidedKey? customerProvidedKey = default,
            bool rangeGetContentHash = default,
            long startOffset = 0,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            BlobErrors.VerifyHttpsCustomerProvidedKey(this.Uri, customerProvidedKey);

            var pageRange = new HttpRange(
                range.Offset + startOffset,
                range.Count.HasValue ?
                    range.Count.Value - startOffset :
                    (long?)null);

            this.Pipeline.LogTrace($"Download {this.Uri} with range: {pageRange}");

            var response =
                await BlobRestClient.Blob.DownloadAsync(
                    this.Pipeline,
                    this.Uri,
                    range: pageRange.ToString(),
                    leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                    rangeGetContentHash: rangeGetContentHash ? (bool?)true : null,
                    encryptionKey: customerProvidedKey?.EncryptionKey,
                    encryptionKeySha256: customerProvidedKey?.EncryptionKeyHash,
                    encryptionAlgorithm: customerProvidedKey?.EncryptionAlgorithm,
                    ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                    ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                    ifMatch: accessConditions?.HttpAccessConditions?.IfMatch,
                    ifNoneMatch: accessConditions?.HttpAccessConditions?.IfNoneMatch,
                    async: async,
                    operationName: "Azure.Storage.Blobs.Specialized.BlobBaseClient.Download",
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

            this.Pipeline.LogTrace($"Response: {response.GetRawResponse().Status}, ContentLength: {response.Value.ContentLength}");

            return response;
        }
        #endregion Download

        #region Parallel Download
        /// <summary>
        /// The <see cref="Download(Stream)"/> operation downloads a blob using parallel requests, 
        /// and writes the content to <paramref name="destination"/>.
        /// </summary>
        /// <param name="destination">
        /// A <see cref="Stream"/> to write the downloaded content to.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobProperties}"/> describing the
        /// blob's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // Client method should have cancellationToken as the last optional parameter
        public virtual Response<BlobProperties> Download(Stream destination) =>
            this.Download(destination, CancellationToken.None);
#pragma warning restore AZC0002 // Client method should have cancellationToken as the last optional parameter

        /// <summary>
        /// The <see cref="Download(FileInfo)"/> operation downloads a blob using parallel requests, 
        /// and writes the content to <paramref name="destination"/>.
        /// </summary>
        /// <param name="destination">
        /// A <see cref="FileInfo"/> representing a file to write the downloaded content to.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobProperties}"/> describing the
        /// blob's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // Client method should have cancellationToken as the last optional parameter
        public virtual Response<BlobProperties> Download(FileInfo destination) =>
            this.Download(destination, CancellationToken.None);
#pragma warning restore AZC0002 // Client method should have cancellationToken as the last optional parameter

        /// <summary>
        /// The <see cref="DownloadAsync(Stream)"/> downloads a blob using parallel requests, 
        /// and writes the content to <paramref name="destination"/>.
        /// </summary>
        /// <param name="destination">
        /// A <see cref="Stream"/> to write the downloaded content to.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobProperties}"/> describing the
        /// blob's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // Client method should have cancellationToken as the last optional parameter
        public virtual Task<Response<BlobProperties>> DownloadAsync(Stream destination) =>
            this.DownloadAsync(destination, CancellationToken.None);
#pragma warning restore AZC0002 // Client method should have cancellationToken as the last optional parameter

        /// <summary>
        /// The <see cref="DownloadAsync(FileInfo)"/> downloads a blob using parallel requests, 
        /// and writes the content to <paramref name="destination"/>.
        /// </summary>
        /// <param name="destination">
        /// A <see cref="FileInfo"/> representing a file to write the downloaded content to.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobProperties}"/> describing the
        /// blob's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // Client method should have cancellationToken as the last optional parameter
        public virtual Task<Response<BlobProperties>> DownloadAsync(FileInfo destination) =>
            this.DownloadAsync(destination, CancellationToken.None);
#pragma warning restore AZC0002 // Client method should have cancellationToken as the last optional parameter

        /// <summary>
        /// The <see cref="Download(Stream, CancellationToken)"/> operation 
        /// downloads a blob using parallel requests, 
        /// and writes the content to <paramref name="destination"/>.
        /// </summary>
        /// <param name="destination">
        /// A <see cref="Stream"/> to write the downloaded content to.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobProperties}"/> describing the
        /// blob's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // Client method should have cancellationToken as the last optional parameter
        public virtual Response<BlobProperties> Download(
            Stream destination,
            CancellationToken cancellationToken) =>
            this.Download(
                destination,
                blobAccessConditions: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken);
#pragma warning restore AZC0002 // Client method should have cancellationToken as the last optional parameter

        /// <summary>
        /// The <see cref="Download(FileInfo, CancellationToken)"/> operation
        /// downloads a blob using parallel requests, 
        /// and writes the content to <paramref name="destination"/>.
        /// </summary>
        /// <param name="destination">
        /// A <see cref="FileInfo"/> representing a file to write the downloaded content to.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobProperties}"/> describing the
        /// blob's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // Client method should have cancellationToken as the last optional parameter
        public virtual Response<BlobProperties> Download(
            FileInfo destination,
            CancellationToken cancellationToken) =>
            this.Download(
                destination,
                blobAccessConditions: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken);
#pragma warning restore AZC0002 // Client method should have cancellationToken as the last optional parameter

        /// <summary>
        /// The <see cref="DownloadAsync(Stream, CancellationToken)"/> operation
        /// downloads a blob using parallel requests, 
        /// and writes the content to <paramref name="destination"/>.
        /// </summary>
        /// <param name="destination">
        /// A <see cref="Stream"/> to write the downloaded content to.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobProperties}"/> describing the
        /// blob's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // Client method should have cancellationToken as the last optional parameter
        public virtual Task<Response<BlobProperties>> DownloadAsync(
            Stream destination,
            CancellationToken cancellationToken) =>
            this.DownloadAsync(
                destination,
                blobAccessConditions: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken);
#pragma warning restore AZC0002 // Client method should have cancellationToken as the last optional parameter

        /// <summary>
        /// The <see cref="DownloadAsync(FileInfo, CancellationToken)"/> operation
        /// downloads a blob using parallel requests, 
        /// and writes the content to <paramref name="destination"/>.
        /// </summary>
        /// <param name="destination">
        /// A <see cref="FileInfo"/> representing a file to write the downloaded content to.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobProperties}"/> describing the
        /// blob's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // Client method should have cancellationToken as the last optional parameter
        public virtual Task<Response<BlobProperties>> DownloadAsync(
            FileInfo destination,
            CancellationToken cancellationToken) =>
            this.DownloadAsync(
                destination,
                blobAccessConditions: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken);
#pragma warning restore AZC0002 // Client method should have cancellationToken as the last optional parameter

        /// <summary>
        /// The <see cref="Download(Stream, BlobAccessConditions?, ParallelTransferOptions, CancellationToken)"/>
        /// operation downloads a blob using parallel requests, 
        /// and writes the content to <paramref name="destination"/>.
        /// </summary>
        /// <param name="destination">
        /// A <see cref="Stream"/> to write the downloaded content to.
        /// </param>
        /// <param name="blobAccessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// the creation of this new block blob.
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
        /// A <see cref="Response{BlobProperties}"/> describing the
        /// blob's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobProperties> Download(
            Stream destination,
            BlobAccessConditions? blobAccessConditions = default,
            ///// <param name="progressHandler">
            ///// Optional <see cref="IProgress{StorageProgress}"/> to provide
            ///// progress updates about data transfers.
            ///// </param>
            //IProgress<StorageProgress> progressHandler = default,
            ParallelTransferOptions parallelTransferOptions = default,
            CancellationToken cancellationToken = default) =>
            this.StagedDownloadAsync(
                destination,
                blobAccessConditions,
                //progressHandler,
                parallelTransferOptions: parallelTransferOptions,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="Download(FileInfo, BlobAccessConditions?, ParallelTransferOptions, CancellationToken)"/>
        /// operation downloads a blob using parallel requests, 
        /// and writes the content to <paramref name="destination"/>.
        /// </summary>
        /// <param name="destination">
        /// A <see cref="FileInfo"/> representing a file to write the downloaded content to.
        /// </param>
        /// <param name="blobAccessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// the creation of this new block blob.
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
        /// A <see cref="Response{BlobProperties}"/> describing the
        /// blob's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobProperties> Download(
            FileInfo destination,
            BlobAccessConditions? blobAccessConditions = default,
            ///// <param name="progressHandler">
            ///// Optional <see cref="IProgress{StorageProgress}"/> to provide
            ///// progress updates about data transfers.
            ///// </param>
            //IProgress<StorageProgress> progressHandler = default,
            ParallelTransferOptions parallelTransferOptions = default,
            CancellationToken cancellationToken = default) =>
            this.StagedDownloadAsync(
                destination,
                blobAccessConditions,
                //progressHandler,
                parallelTransferOptions: parallelTransferOptions,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="DownloadAsync(Stream, BlobAccessConditions?, ParallelTransferOptions, CancellationToken)"/>
        /// operation downloads a blob using parallel requests, 
        /// and writes the content to <paramref name="destination"/>.
        /// </summary>
        /// <param name="destination">
        /// A <see cref="Stream"/> to write the downloaded content to.
        /// </param>
        /// <param name="blobAccessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// the creation of this new block blob.
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
        /// A <see cref="Response{BlobProperties}"/> describing the
        /// blob's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Task<Response<BlobProperties>> DownloadAsync(
            Stream destination,
            BlobAccessConditions? blobAccessConditions = default,
            ///// <param name="progressHandler">
            ///// Optional <see cref="IProgress{StorageProgress}"/> to provide
            ///// progress updates about data transfers.
            ///// </param> 
            //IProgress<StorageProgress> progressHandler = default,
            ParallelTransferOptions parallelTransferOptions = default,
            CancellationToken cancellationToken = default) =>
            this.StagedDownloadAsync(
                destination,
                blobAccessConditions,
                //progressHandler,
                parallelTransferOptions: parallelTransferOptions,
                async: true,
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="DownloadAsync(FileInfo, BlobAccessConditions?, ParallelTransferOptions, CancellationToken)"/>
        /// operation downloads a blob using parallel requests, 
        /// and writes the content to <paramref name="destination"/>.
        /// </summary>
        /// <param name="destination">
        /// A <see cref="FileInfo"/> representing a file to write the downloaded content to.
        /// </param>
        /// <param name="blobAccessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// the creation of this new block blob.
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
        /// A <see cref="Response{BlobProperties}"/> describing the
        /// blob's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Task<Response<BlobProperties>> DownloadAsync(
            FileInfo destination,
            BlobAccessConditions? blobAccessConditions = default,
            ///// <param name="progressHandler">
            ///// Optional <see cref="IProgress{StorageProgress}"/> to provide
            ///// progress updates about data transfers.
            ///// </param>
            //IProgress<StorageProgress> progressHandler = default,
            ParallelTransferOptions parallelTransferOptions = default,
            CancellationToken cancellationToken = default) =>
            this.StagedDownloadAsync(
                destination,
                blobAccessConditions,
                //progressHandler,
                parallelTransferOptions: parallelTransferOptions,
                async: true,
                cancellationToken: cancellationToken);

        /// <summary>
        /// This operation will download a blob of arbitrary size by downloading it as indiviually staged
        /// partitions if it's larger than the
        /// <paramref name="singleBlockThreshold"/>.
        /// </summary>
        /// <param name="destination">
        /// A <see cref="Stream"/> to write the downloaded content to.
        /// </param>
        /// <param name="blobAccessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// the creation of this new block blob.
        /// </param>
        /// <param name="singleBlockThreshold">
        /// The maximum size stream that we'll download as a single block.  The
        /// default value is 256MB.
        /// </param>
        /// <param name="parallelTransferOptions">
        /// Optional <see cref="ParallelTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobProperties}"/> describing the
        /// blob's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal Task<Response<BlobProperties>> StagedDownloadAsync(
            Stream destination,
            BlobAccessConditions? blobAccessConditions = default,
            ///// <param name="progressHandler">
            ///// Optional <see cref="IProgress{StorageProgress}"/> to provide
            ///// progress updates about data transfers.
            ///// </param>
            //IProgress<StorageProgress> progressHandler,
            long singleBlockThreshold = Constants.Blob.Block.MaxDownloadBytes,
            ParallelTransferOptions parallelTransferOptions = default,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            Debug.Assert(singleBlockThreshold <= Constants.Blob.Block.MaxDownloadBytes);

            var client = new BlobBaseClient(this.Uri, this.Pipeline);
            var downloadTask =
                PartitionedDownloader.DownloadAsync(
                    destination,
                    GetPropertiesAsync,
                    GetEtag,
                    GetLength,
                    DownloadStreamAsync,
                    DownloadPartitionAsync,
                    WritePartitionAsync,
                    singleBlockThreshold,
                    parallelTransferOptions,
                    async,
                    cancellationToken
                    );

            return downloadTask;

            Task<Response<BlobProperties>> GetPropertiesAsync(bool async, CancellationToken ct)
                =>
                client.GetPropertiesAsync(
                        accessConditions: blobAccessConditions,
                        cancellationToken: ct
                        );

            static ETag GetEtag(BlobProperties blobProperties) => blobProperties.ETag;

            static long GetLength(BlobProperties blobProperties) => blobProperties.ContentLength;

            // Download the entire stream
            async Task<Response<BlobDownloadInfo>> DownloadStreamAsync(bool async, CancellationToken ct)
            {
                var response = await client.DownloadAsync(accessConditions: blobAccessConditions, cancellationToken: ct).ConfigureAwait(false);
                await response.Value.Content.CopyToAsync(destination, 81920 /* default value */, ct).ConfigureAwait(false);

                return response;
            }

            Task<Response<BlobDownloadInfo>> DownloadPartitionAsync(ETag eTag, HttpRange httpRange, bool async, CancellationToken ct)
            {
                // copy ETag to the access conditions

                var accessConditions = blobAccessConditions ?? new BlobAccessConditions();
                accessConditions.HttpAccessConditions ??= new HttpAccessConditions();

                var httpAccessConditions = accessConditions.HttpAccessConditions.Value;
                httpAccessConditions.IfMatch = eTag;

                accessConditions.HttpAccessConditions = httpAccessConditions;

                return client.DownloadAsync(range: httpRange, accessConditions: accessConditions, cancellationToken: cancellationToken);
            }

            static Task WritePartitionAsync(Response<BlobDownloadInfo> response, Stream destination, bool async, CancellationToken ct)
                => response.Value.Content.CopyToAsync(destination);
        }

        /// <summary>
        /// This operation will download a blob of arbitrary size by downloading it as indiviually staged
        /// partitions if it's larger than the
        /// <paramref name="singleBlockThreshold"/>.
        /// </summary>
        /// <param name="destination">
        /// A <see cref="FileInfo"/> representing a file to write the downloaded content to.
        /// </param>
        /// <param name="blobAccessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// the creation of this new block blob.
        /// </param>
        /// <param name="singleBlockThreshold">
        /// The maximum size stream that we'll download as a single block.  The
        /// default value is 256MB.
        /// </param>
        /// <param name="parallelTransferOptions">
        /// Optional <see cref="ParallelTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobProperties}"/> describing the
        /// blob's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal Task<Response<BlobProperties>> StagedDownloadAsync(
            FileInfo destination,
            BlobAccessConditions? blobAccessConditions = default,
            ///// <param name="progressHandler">
            ///// Optional <see cref="IProgress{StorageProgress}"/> to provide
            ///// progress updates about data transfers.
            ///// </param>
            //IProgress<StorageProgress> progressHandler,
            long singleBlockThreshold = Constants.Blob.Block.MaxDownloadBytes,
            ParallelTransferOptions parallelTransferOptions = default,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            var stream = destination.OpenWrite();

            return this.StagedDownloadAsync(
                stream,
                blobAccessConditions,
                //progressHandler,
                singleBlockThreshold,
                parallelTransferOptions,
                async,
                cancellationToken
                ).ContinueWith(
                    t =>
                    {
                        stream.Flush();
                        stream.Dispose();

                        return t.Result;
                    },
                    CancellationToken.None,
                    TaskContinuationOptions.RunContinuationsAsynchronously,
                    TaskScheduler.Default
                );
        }
        #endregion Parallel Download

        #region StartCopyFromUri
        /// <summary>
        /// The <see cref="StartCopyFromUri(Uri, Metadata, AccessTier?, BlobAccessConditions?, BlobAccessConditions?, CancellationToken)"/>
        /// operation copies data at from the <paramref name="source"/> to this
        /// blob.  You can check the <see cref="BlobProperties.CopyStatus"/>
        /// returned from the <see cref="GetProperties"/> to determine if the
        /// copy has completed.
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
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
        /// </param>
        /// <param name="sourceAccessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="destinationAccessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// the copying of data to this blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Operation{Int64}"/> describing the
        /// state of the copy operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Operation<long> StartCopyFromUri(
            Uri source,
            Metadata metadata = default,
            AccessTier? accessTier = default,
            BlobAccessConditions? sourceAccessConditions = default,
            BlobAccessConditions? destinationAccessConditions = default,
            CancellationToken cancellationToken = default)
        {
            var response = this.StartCopyFromUriInternal(
                source,
                metadata,
                accessTier,
                sourceAccessConditions,
                destinationAccessConditions,
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
        /// The <see cref="StartCopyFromUri(Uri, Metadata, AccessTier?, BlobAccessConditions?, BlobAccessConditions?, CancellationToken)"/>
        /// operation copies data at from the <paramref name="source"/> to this
        /// blob.  You can check the <see cref="BlobProperties.CopyStatus"/>
        /// returned from the <see cref="GetPropertiesAsync"/> to determine if
        /// the copy has completed.
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
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
        /// </param>
        /// <param name="sourceAccessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="destinationAccessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// the copying of data to this blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Operation{Int64}"/> describing the
        /// state of the copy operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Operation<long>> StartCopyFromUriAsync(
            Uri source,
            Metadata metadata = default,
            AccessTier? accessTier = default,
            BlobAccessConditions? sourceAccessConditions = default,
            BlobAccessConditions? destinationAccessConditions = default,
            CancellationToken cancellationToken = default)
        {
            var response = await this.StartCopyFromUriInternal(
                source,
                metadata,
                accessTier,
                sourceAccessConditions,
                destinationAccessConditions,
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
        /// Get an existing <see cref="CopyFromUriOperation"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob" />.
        /// </summary>
        /// <param name="copyId">
        /// The ID of a copy operation that's already beeen started.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Operation{Int64}"/> representing the copy
        /// operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Operation<long> StartCopyFromUri(
            string copyId,
            CancellationToken cancellationToken = default)
        {
            var response = this.GetPropertiesInternal(
                null,
                null,
                false, // async
                cancellationToken)
                .EnsureCompleted();
            return new CopyFromUriOperation(
                this,
                copyId,
                response.GetRawResponse(),
                cancellationToken);
        }

        /// <summary>
        /// Get an existing <see cref="CopyFromUriOperation"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob" />.
        /// </summary>
        /// <param name="copyId">
        /// The ID of a copy operation that's already beeen started.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Operation{Int64}"/> representing the copy
        /// operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Operation<long>> StartCopyFromUriAsync(
            string copyId,
            CancellationToken cancellationToken = default)
        {
            var response = await this.GetPropertiesInternal(
                null,
                null,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);
            return new CopyFromUriOperation(
                this,
                copyId,
                response.GetRawResponse(),
                cancellationToken);
        }

        /// <summary>
        /// The <see cref="StartCopyFromUriInternal"/> operation copies data at
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
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
        /// </param>
        /// <param name="sourceAccessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="destinationAccessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// the copying of data to this blob.
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
        /// state of the copy operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobCopyInfo>> StartCopyFromUriInternal(
            Uri source,
            Metadata metadata,
            AccessTier? accessTier,
            BlobAccessConditions? sourceAccessConditions,
            BlobAccessConditions? destinationAccessConditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
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
                        tier: accessTier,
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
                        async: async,
                        operationName: "Azure.Storage.Blobs.Specialized.BlobBaseClient.StartCopyFromUri",
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
                    this.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                }
            }
        }
        #endregion StartCopyFromUri

        #region AbortCopyFromUri
        /// <summary>
        /// The <see cref="AbortCopyFromUri"/> operation aborts a pending
        /// <see cref="CopyFromUriOperation"/>, and leaves a this
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
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully aborting.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response AbortCopyFromUri(
            string copyId,
            LeaseAccessConditions? leaseAccessConditions = default,
            CancellationToken cancellationToken = default) =>
            this.AbortCopyFromUriInternal(
                copyId,
                leaseAccessConditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="AbortCopyFromUriAsync"/> operation aborts a pending
        /// <see cref="CopyFromUriOperation"/>, and leaves a this
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
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully aborting.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> AbortCopyFromUriAsync(
            string copyId,
            LeaseAccessConditions? leaseAccessConditions = default,
            CancellationToken cancellationToken = default) =>
            await this.AbortCopyFromUriInternal(
                copyId,
                leaseAccessConditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="AbortCopyFromUriAsync"/> operation aborts a pending
        /// <see cref="CopyFromUriOperation"/>, and leaves a this
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
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully aborting.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response> AbortCopyFromUriInternal(
            string copyId,
            LeaseAccessConditions? leaseAccessConditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
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
                        async: async,
                        operationName: "Azure.Storage.Blobs.Specialized.BlobBaseClient.AbortCopyFromUri",
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
                    this.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                }
            }
        }
        #endregion AbortCopyFromUri

        #region Delete
        /// <summary>
        /// The <see cref="Delete"/> operation marks the specified blob
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
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully deleting.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response Delete(
            DeleteSnapshotsOption? deleteOptions = default,
            BlobAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default) =>
            this.DeleteInternal(
                deleteOptions,
                accessConditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

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
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully deleting.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> DeleteAsync(
            DeleteSnapshotsOption? deleteOptions = default,
            BlobAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default) =>
            await this.DeleteInternal(
                deleteOptions,
                accessConditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DeleteInternal"/> operation marks the specified blob
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
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully deleting.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response> DeleteInternal(
            DeleteSnapshotsOption? deleteOptions,
            BlobAccessConditions? accessConditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(deleteOptions)}: {deleteOptions}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    return await BlobRestClient.Blob.DeleteAsync(
                        this.Pipeline,
                        this.Uri,
                        leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                        deleteSnapshots: deleteOptions,
                        ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        ifMatch: accessConditions?.HttpAccessConditions?.IfMatch,
                        ifNoneMatch: accessConditions?.HttpAccessConditions?.IfNoneMatch,
                        async: async,
                        operationName: "Azure.Storage.Blobs.Specialized.BlobBaseClient.Delete",
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
                    this.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                }
            }
        }
        #endregion Delete

        #region Undelete
        /// <summary>
        /// The <see cref="Undelete"/> operation restores the contents
        /// and metadata of a soft deleted blob and any associated soft
        /// deleted snapshots.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/undelete-blob" />.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully deleting.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response Undelete(
            CancellationToken cancellationToken = default) =>
            this.UndeleteInternal(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="UndeleteAsync"/> operation restores the contents
        /// and metadata of a soft deleted blob and any associated soft
        /// deleted snapshots.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/undelete-blob" />.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully deleting.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> UndeleteAsync(
            CancellationToken cancellationToken = default) =>
            await this.UndeleteInternal(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UndeleteInternal"/> operation restores the contents
        /// and metadata of a soft deleted blob and any associated soft
        /// deleted snapshots.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/undelete-blob" />.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully deleting.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response> UndeleteInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                this.Pipeline.LogMethodEnter(nameof(BlobBaseClient), message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await BlobRestClient.Blob.UndeleteAsync(
                        this.Pipeline,
                        this.Uri,
                        async: async,
                        cancellationToken: cancellationToken,
                        operationName: "Azure.Storage.Blobs.Specialized.BlobBaseClient.Undelete")
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                }
            }
        }
        #endregion Undelete

        #region GetProperties
        /// <summary>
        /// The <see cref="GetProperties"/> operation returns all
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
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobProperties}"/> describing the
        /// blob's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobProperties> GetProperties(
            BlobAccessConditions? accessConditions = default,
            CustomerProvidedKey? customerProvidedKey = default,
            CancellationToken cancellationToken = default) =>
            this.GetPropertiesInternal(
                accessConditions,
                customerProvidedKey,
                false, // async
                cancellationToken)
                .EnsureCompleted();

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
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobProperties}"/> describing the
        /// blob's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobProperties>> GetPropertiesAsync(
            BlobAccessConditions? accessConditions = default,
            CustomerProvidedKey? customerProvidedKey = default,
            CancellationToken cancellationToken = default) =>
            await this.GetPropertiesInternal(
                accessConditions,
                customerProvidedKey,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetPropertiesInternal"/> operation returns all
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
        /// A <see cref="Response{BlobProperties}"/> describing the
        /// blob's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobProperties>> GetPropertiesInternal(
            BlobAccessConditions? accessConditions,
            CustomerProvidedKey? customerProvidedKey,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    BlobErrors.VerifyHttpsCustomerProvidedKey(this.Uri, customerProvidedKey);

                    return await BlobRestClient.Blob.GetPropertiesAsync(
                        this.Pipeline,
                        this.Uri,
                        leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                        encryptionKey: customerProvidedKey?.EncryptionKey,
                        encryptionKeySha256: customerProvidedKey?.EncryptionKeyHash,
                        encryptionAlgorithm: customerProvidedKey?.EncryptionAlgorithm,
                        ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        ifMatch: accessConditions?.HttpAccessConditions?.IfMatch,
                        ifNoneMatch: accessConditions?.HttpAccessConditions?.IfNoneMatch,
                        async: async,
                        operationName: "Azure.Storage.Blobs.Specialized.BlobBaseClient.GetProperties",
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
                    this.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                }
            }
        }
        #endregion GetProperties

        #region SetHttpHeaders
        /// <summary>
        /// The <see cref="SetHttpHeaders"/> operation sets system
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
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobInfo}"/> describing the updated
        /// blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobInfo> SetHttpHeaders(
            BlobHttpHeaders? httpHeaders = default,
            BlobAccessConditions? accessConditions = default,
            CustomerProvidedKey? customerProvidedKey = default,
            CancellationToken cancellationToken = default) =>
            this.SetHttpHeadersInternal(
                httpHeaders,
                accessConditions,
                customerProvidedKey,
                false, // async
                cancellationToken)
                .EnsureCompleted();

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
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobInfo}"/> describing the updated
        /// blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobInfo>> SetHttpHeadersAsync(
            BlobHttpHeaders? httpHeaders = default,
            BlobAccessConditions? accessConditions = default,
            CustomerProvidedKey? customerProvidedKey = default,
            CancellationToken cancellationToken = default) =>
            await this.SetHttpHeadersInternal(
                httpHeaders,
                accessConditions,
                customerProvidedKey,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetHttpHeadersInternal"/> operation sets system
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
        /// A <see cref="Response{BlobInfo}"/> describing the updated
        /// blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobInfo>> SetHttpHeadersInternal(
            BlobHttpHeaders? httpHeaders,
            BlobAccessConditions? accessConditions,
            CustomerProvidedKey? customerProvidedKey,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(httpHeaders)}: {httpHeaders}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    BlobErrors.VerifyHttpsCustomerProvidedKey(this.Uri, customerProvidedKey);

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
                            async: async,
                            operationName: "Azure.Storage.Blobs.Specialized.BlobBaseClient.SetHttpHeaders",
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    return new Response<BlobInfo>(
                        response.GetRawResponse(),
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
                    this.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                }
            }
        }
        #endregion SetHttpHeaders

        #region SetMetadata
        /// <summary>
        /// The <see cref="SetMetadata"/> operation sets user-defined
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
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobInfo}"/> describing the updated
        /// blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobInfo> SetMetadata(
            Metadata metadata,
            BlobAccessConditions? accessConditions = default,
            CustomerProvidedKey? customerProvidedKey = default,
            CancellationToken cancellationToken = default) =>
            this.SetMetadataInternal(
                metadata,
                accessConditions,
                customerProvidedKey,
                false, // async
                cancellationToken)
                .EnsureCompleted();

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
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobInfo}"/> describing the updated
        /// blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobInfo>> SetMetadataAsync(
            Metadata metadata,
            BlobAccessConditions? accessConditions = default,
            CustomerProvidedKey? customerProvidedKey = default,
            CancellationToken cancellationToken = default) =>
            await this.SetMetadataInternal(
                metadata,
                accessConditions,
                customerProvidedKey,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetMetadataInternal"/> operation sets user-defined
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
        /// A <see cref="Response{BlobInfo}"/> describing the updated
        /// blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobInfo>> SetMetadataInternal(
            Metadata metadata,
            BlobAccessConditions? accessConditions,
            CustomerProvidedKey? customerProvidedKey,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    BlobErrors.VerifyHttpsCustomerProvidedKey(this.Uri, customerProvidedKey);

                    var response =
                        await BlobRestClient.Blob.SetMetadataAsync(
                            this.Pipeline,
                            this.Uri,
                            metadata: metadata,
                            leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                            encryptionKey: customerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: customerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: customerProvidedKey?.EncryptionAlgorithm,
                            ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                            ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                            ifMatch: accessConditions?.HttpAccessConditions?.IfMatch,
                            ifNoneMatch: accessConditions?.HttpAccessConditions?.IfNoneMatch,
                            async: async,
                            operationName: "Azure.Storage.Blobs.Specialized.BlobBaseClient.SetMetadata",
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    return new Response<BlobInfo>(
                        response.GetRawResponse(),
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
                    this.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                }
            }
        }
        #endregion SetMetadata

        #region CreateSnapshot
        /// <summary>
        /// The <see cref="CreateSnapshot"/> operation creates a
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
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>s
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobSnapshotInfo}"/> describing the
        /// new blob snapshot.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobSnapshotInfo> CreateSnapshot(
            Metadata metadata = default,
            BlobAccessConditions? accessConditions = default,
            CustomerProvidedKey? customerProvidedKey = default,
            CancellationToken cancellationToken = default) =>
            this.CreateSnapshotInternal(
                metadata,
                accessConditions,
                customerProvidedKey,
                false, // async
                cancellationToken)
                .EnsureCompleted();

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
        /// <param name="customerProvidedKey">
        /// Optional CustomerProvidedKeyInfo for use in customer-provided key
        /// server-side encryption.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobSnapshotInfo}"/> describing the
        /// new blob snapshot.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobSnapshotInfo>> CreateSnapshotAsync(
            Metadata metadata = default,
            BlobAccessConditions? accessConditions = default,
            CustomerProvidedKey? customerProvidedKey = default,
            CancellationToken cancellationToken = default) =>
            await this.CreateSnapshotInternal(
                metadata,
                accessConditions,
                customerProvidedKey,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CreateSnapshotInternal"/> operation creates a
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
        /// A <see cref="Response{BlobSnapshotInfo}"/> describing the
        /// new blob snapshot.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobSnapshotInfo>> CreateSnapshotInternal(
            Metadata metadata,
            BlobAccessConditions? accessConditions,
            CustomerProvidedKey? customerProvidedKey,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    BlobErrors.VerifyHttpsCustomerProvidedKey(this.Uri, customerProvidedKey);

                    return await BlobRestClient.Blob.CreateSnapshotAsync(
                        this.Pipeline,
                        this.Uri,
                        metadata: metadata,
                        encryptionKey: customerProvidedKey?.EncryptionKey,
                        encryptionKeySha256: customerProvidedKey?.EncryptionKeyHash,
                        encryptionAlgorithm: customerProvidedKey?.EncryptionAlgorithm,
                        ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        ifMatch: accessConditions?.HttpAccessConditions?.IfMatch,
                        ifNoneMatch: accessConditions?.HttpAccessConditions?.IfNoneMatch,
                        leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                        async: async,
                        operationName: "Azure.Storage.Blobs.Specialized.BlobBaseClient.CreateSnapshot",
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
                    this.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                }
            }
        }
        #endregion CreateSnapshot

        #region SetTier
        /// <summary>
        /// The <see cref="SetTier"/> operation sets the tier on a blob.
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
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully setting the tier.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response SetTier(
            AccessTier accessTier,
            LeaseAccessConditions? leaseAccessConditions = default,
            CancellationToken cancellationToken = default) =>
            this.SetTierInternal(
                accessTier,
                leaseAccessConditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

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
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully setting the tier.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> SetTierAsync(
            AccessTier accessTier,
            LeaseAccessConditions? leaseAccessConditions = default,
            CancellationToken cancellationToken = default) =>
            await this.SetTierInternal(
                accessTier,
                leaseAccessConditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetTierInternal"/> operation sets the tier on a blob.
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
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully setting the tier.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response> SetTierInternal(
            AccessTier accessTier,
            LeaseAccessConditions? leaseAccessConditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(accessTier)}: {accessTier}\n" +
                    $"{nameof(leaseAccessConditions)}: {leaseAccessConditions}");
                try
                {
                    return await BlobRestClient.Blob.SetTierAsync(
                        this.Pipeline,
                        this.Uri,
                        tier: accessTier.ToAccessTier(),
                        leaseId: leaseAccessConditions?.LeaseId,
                        async: async,
                        operationName: "Azure.Storage.Blobs.Specialized.BlobBaseClient.SetTier",
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
                    this.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                }
            }
        }
        #endregion SetTier
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
        /// Indicates that the service supports requests for partial blob content.
        /// </summary>
        public string AcceptRanges => this._flattened.AcceptRanges;

        /// <summary>
        /// The number of committed blocks present in the blob. This header is returned only for append blobs.
        /// </summary>
        public int BlobCommittedBlockCount => this._flattened.BlobCommittedBlockCount;

        /// <summary>
        /// The value of this header is set to true if the blob data and application metadata are completely encrypted using the specified algorithm. Otherwise, the value is set to false (when the blob is unencrypted, or if only parts of the blob/application metadata are encrypted).
        /// </summary>
        public bool IsServerEncrypted => this._flattened.IsServerEncrypted;

        /// <summary>
        /// The SHA-256 hash of the encryption key used to encrypt the blob. This header is only returned when the blob was encrypted with a customer-provided key.
        /// </summary>
        public string EncryptionKeySha256 => this._flattened.EncryptionKeySha256;

        /// <summary>
        /// If the blob has a MD5 hash, and if request contains range header (Range or x-ms-range), this response header is returned with the value of the whole blob's MD5 value. This value may or may not be equal to the value returned in Content-MD5 header, with the latter calculated from the requested range
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] BlobContentHash => this._flattened.BlobContentHash;
#pragma warning restore CA1819 // Properties should not return arrays
    }

    /// <summary>
    /// Add easy to discover methods to <see cref="BlobContainerClient"/> for
    /// creating <see cref="BlobClient"/> instances.
    /// </summary>
    public static partial class SpecializedBlobExtensions
    {
        /// <summary>
        /// Create a new <see cref="BlobClient"/> object by concatenating
        /// <paramref name="blobName"/> to the end of the
        /// <paramref name="client"/>'s <see cref="BlobContainerClient.Uri"/>.
        /// The new <see cref="BlobClient"/> uses the same request policy
        /// pipeline as the <see cref="BlobContainerClient"/>.
        /// </summary>
        /// <param name="client">The <see cref="BlobContainerClient"/>.</param>
        /// <param name="blobName">The name of the blob.</param>
        /// <returns>A new <see cref="BlobClient"/> instance.</returns>
        public static BlobBaseClient GetBlobClient(
            this BlobContainerClient client,
            string blobName)
            => new BlobBaseClient(client.Uri.AppendToPath(blobName), client.Pipeline);
    }
}
