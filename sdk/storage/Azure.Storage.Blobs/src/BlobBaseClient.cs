// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Http;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Common;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

#pragma warning disable SA1402  // File may only contain a single type

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
        public virtual Uri Uri => _uri;

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send
        /// every request.
        /// </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send
        /// every request.
        /// </summary>
        protected internal virtual HttpPipeline Pipeline => _pipeline;

        /// <summary>
        /// The <see cref="CustomerProvidedKey"/> to be used when sending requests.
        /// </summary>
        private readonly CustomerProvidedKey? _customerProvidedKey;

        /// <summary>
        /// The <see cref="CustomerProvidedKey"/> to be used when sending requests.
        /// </summary>
        public virtual CustomerProvidedKey? CustomerProvidedKey => _customerProvidedKey;

        /// <summary>
        /// The Storage account name corresponding to the blob client.
        /// </summary>
        private string _accountName;

        /// <summary>
        /// Gets the Storage account name corresponding to the blob client.
        /// </summary>
        public virtual string AccountName
        {
            get
            {
                SetNameFieldsIfNull();
                return _accountName;
            }
        }

        /// <summary>
        /// The container name corresponding to the blob client.
        /// </summary>
        private string _containerName;

        /// <summary>
        /// Gets the container name corresponding to the blob client.
        /// </summary>
        public virtual string ContainerName
        {
            get
            {
                SetNameFieldsIfNull();
                return _containerName;
            }
        }

        /// <summary>
        /// The name of the blob.
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets the name of the blob.
        /// </summary>
        public virtual string Name
        {
            get
            {
                SetNameFieldsIfNull();
                return _name;
            }
        }

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
            _uri = builder.ToUri();
            _pipeline = (options ?? new BlobClientOptions()).Build(conn.Credentials);
            _customerProvidedKey = options?.CustomerProvidedKey;
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
            _uri = blobUri;
            _pipeline = (options ?? new BlobClientOptions()).Build(authentication);
            _customerProvidedKey = options?.CustomerProvidedKey;
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
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// </param>
        internal BlobBaseClient(Uri blobUri, HttpPipeline pipeline, BlobClientOptions options = default)
        {
            _uri = blobUri;
            _pipeline = pipeline;
            _customerProvidedKey = options?.CustomerProvidedKey;
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
        public virtual BlobBaseClient WithSnapshot(string snapshot) => WithSnapshotImpl(snapshot);

        /// <summary>
        /// Creates a new instance of the <see cref="BlobClient"/> class
        /// with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="snapshot"/> timestamp.
        /// </summary>
        /// <param name="snapshot">The snapshot identifier.</param>
        /// <returns>A new <see cref="BlobClient"/> instance.</returns>
        protected virtual BlobBaseClient WithSnapshotImpl(string snapshot)
        {
            var builder = new BlobUriBuilder(Uri) { Snapshot = snapshot };
            return new BlobBaseClient(builder.ToUri(), Pipeline);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/> class
        /// with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="customerProvidedKey"/> customer provided key.
        /// </summary>
        /// <param name="customerProvidedKey">
        /// The customer provided key to be used by the service to encrypt data.
        /// </param>
        /// <returns>A new <see cref="BlobClient"/></returns>
        public virtual BlobBaseClient WithCustomerProvidedKey(CustomerProvidedKey customerProvidedKey) =>
            WithCustomerProvidedKeyImpl(customerProvidedKey);

        /// <summary>
        /// Creates a new instance of the <see cref="BlobClient"/> class
        /// with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="customerProvidedKey"/> customer provided key.
        /// </summary>
        /// <param name="customerProvidedKey">
        /// The customer provided key to be used by the service to encrypt data.
        /// </param>
        /// <returns>A new <see cref="BlobClient"/></returns>
        protected virtual BlobBaseClient WithCustomerProvidedKeyImpl(CustomerProvidedKey customerProvidedKey)
        {
            var uriBuilder = new UriBuilder(Uri)
            {
                Scheme = Constants.Blob.Https,
                Port = Constants.Blob.HttpsPort
            };
            return new BlobBaseClient(
                uriBuilder.Uri,
                Pipeline,
                new BlobClientOptions(customerProvidedKey: customerProvidedKey));

        }

        /// <summary>
        /// Sets the various name fields if they are currently null.
        /// </summary>
        private void SetNameFieldsIfNull()
        {
            if (_name == null || _containerName == null || _accountName == null)
            {
                var builder = new BlobUriBuilder(Uri);
                _name = builder.BlobName;
                _containerName = builder.ContainerName;
                _accountName = builder.AccountName;
            }
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
            Download(CancellationToken.None);
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
            await DownloadAsync(CancellationToken.None).ConfigureAwait(false);
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
            Download(
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
            await DownloadAsync(
                accessConditions: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
#pragma warning restore AZC0002 // Client method should have cancellationToken as the last optional parameter

        /// <summary>
        /// The <see cref="Download(HttpRange, BlobAccessConditions?, Boolean, CancellationToken)"/>
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
            bool rangeGetContentHash = default,
            CancellationToken cancellationToken = default) =>
            DownloadInternal(
                range,
                accessConditions,
                rangeGetContentHash,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="DownloadAsync(HttpRange, BlobAccessConditions?, Boolean, CancellationToken)"/>
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
            bool rangeGetContentHash = default,
            CancellationToken cancellationToken = default) =>
            await DownloadInternal(
                range,
                accessConditions,
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
            bool rangeGetContentHash,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                Pipeline.LogMethodEnter(nameof(BlobBaseClient), message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    // Start downloading the blob
                    (Response<FlattenedDownloadProperties> response, Stream stream) = await StartDownloadAsync(
                        range,
                        accessConditions,
                        rangeGetContentHash,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    // Wrap the response Content in a RetriableStream so we
                    // can return it before it's finished downloading, but still
                    // allow retrying if it fails.
                    response.Value.Content = RetriableStream.Create(
                        stream,
                         startOffset =>
                            StartDownloadAsync(
                                    range,
                                    accessConditions,
                                    rangeGetContentHash,
                                    startOffset,
                                    async,
                                    cancellationToken)
                                .ConfigureAwait(false).GetAwaiter().GetResult()
                            .Item2,
                        async startOffset =>
                            (await StartDownloadAsync(
                                range,
                                accessConditions,
                                rangeGetContentHash,
                                startOffset,
                                async,
                                cancellationToken)
                                .ConfigureAwait(false))
                            .Item2,
                        Pipeline.ResponseClassifier,
                        Constants.MaxReliabilityRetries);

                    // Wrap the FlattenedDownloadProperties into a BlobDownloadOperation
                    // to make the Content easier to find
                    return Response.FromValue(response.GetRawResponse(), new BlobDownloadInfo(response.Value));
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(BlobBaseClient));
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
        private async Task<(Response<FlattenedDownloadProperties>, Stream)> StartDownloadAsync(
            HttpRange range = default,
            BlobAccessConditions? accessConditions = default,
            bool rangeGetContentHash = default,
            long startOffset = 0,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            BlobErrors.VerifyHttpsCustomerProvidedKey(Uri, CustomerProvidedKey);

            var pageRange = new HttpRange(
                range.Offset + startOffset,
                range.Count.HasValue ?
                    range.Count.Value - startOffset :
                    (long?)null);

            Pipeline.LogTrace($"Download {Uri} with range: {pageRange}");

            (Response<FlattenedDownloadProperties> response, Stream stream) =
                await BlobRestClient.Blob.DownloadAsync(
                    Pipeline,
                    Uri,
                    range: pageRange.ToString(),
                    leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                    rangeGetContentHash: rangeGetContentHash ? (bool?)true : null,
                    encryptionKey: CustomerProvidedKey?.EncryptionKey,
                    encryptionKeySha256: CustomerProvidedKey?.EncryptionKeyHash,
                    encryptionAlgorithm: CustomerProvidedKey?.EncryptionAlgorithm,
                    ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                    ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                    ifMatch: accessConditions?.HttpAccessConditions?.IfMatch,
                    ifNoneMatch: accessConditions?.HttpAccessConditions?.IfNoneMatch,
                    async: async,
                    operationName: "Azure.Storage.Blobs.Specialized.BlobBaseClient.Download",
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

            Pipeline.LogTrace($"Response: {response.GetRawResponse().Status}, ContentLength: {response.Value.ContentLength}");

            return (response, stream);
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
            Download(destination, CancellationToken.None);
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
            Download(destination, CancellationToken.None);
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
            DownloadAsync(destination, CancellationToken.None);
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
            DownloadAsync(destination, CancellationToken.None);
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
            Download(
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
            Download(
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
            DownloadAsync(
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
            DownloadAsync(
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
            StagedDownloadAsync(
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
            StagedDownloadAsync(
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
            StagedDownloadAsync(
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
            StagedDownloadAsync(
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

            var client = new BlobBaseClient(Uri, Pipeline);
            Task<Response<BlobProperties>> downloadTask =
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
                Response<BlobDownloadInfo> response = await client.DownloadAsync(accessConditions: blobAccessConditions, cancellationToken: ct).ConfigureAwait(false);
                await response.Value.Content.CopyToAsync(destination, 81920 /* default value */, ct).ConfigureAwait(false);

                return response;
            }

            Task<Response<BlobDownloadInfo>> DownloadPartitionAsync(ETag eTag, HttpRange httpRange, bool async, CancellationToken ct)
            {
                // copy ETag to the access conditions

                BlobAccessConditions accessConditions = blobAccessConditions ?? new BlobAccessConditions();
                accessConditions.HttpAccessConditions ??= new HttpAccessConditions();

                HttpAccessConditions httpAccessConditions = accessConditions.HttpAccessConditions.Value;
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
            FileStream stream = destination.OpenWrite();

            return StagedDownloadAsync(
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
        /// The <see cref="StartCopyFromUri(Uri, Metadata, AccessTier?, BlobAccessConditions?, BlobAccessConditions?, RehydratePriority?, CancellationToken)"/>
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
        /// <param name="rehydratePriority">
        /// Optional <see cref="RehydratePriority"/>
        /// Indicates the priority with which to rehydrate an archived blob.
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
            RehydratePriority? rehydratePriority = default,
            CancellationToken cancellationToken = default)
        {
            Response<BlobCopyInfo> response = StartCopyFromUriInternal(
                source,
                metadata,
                accessTier,
                sourceAccessConditions,
                destinationAccessConditions,
                rehydratePriority,
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
        /// The <see cref="StartCopyFromUri(Uri, Metadata, AccessTier?, BlobAccessConditions?, BlobAccessConditions?, RehydratePriority?, CancellationToken)"/>
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
        /// <param name="rehydratePriority">
        /// Optional <see cref="RehydratePriority"/>
        /// Indicates the priority with which to rehydrate an archived blob.
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
            RehydratePriority? rehydratePriority = default,
            CancellationToken cancellationToken = default)
        {
            Response<BlobCopyInfo> response = await StartCopyFromUriInternal(
                source,
                metadata,
                accessTier,
                sourceAccessConditions,
                destinationAccessConditions,
                rehydratePriority,
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
            Response<BlobProperties> response = GetPropertiesInternal(
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
            Response<BlobProperties> response = await GetPropertiesInternal(
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
        /// <param name="rehydratePriority">
        /// Optional <see cref="RehydratePriority"/>
        /// Indicates the priority with which to rehydrate an archived blob.
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
            RehydratePriority? rehydratePriority,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(source)}: {source}\n" +
                    $"{nameof(sourceAccessConditions)}: {sourceAccessConditions}\n" +
                    $"{nameof(destinationAccessConditions)}: {destinationAccessConditions}");
                try
                {
                    return await BlobRestClient.Blob.StartCopyFromUriAsync(
                        Pipeline,
                        Uri,
                        copySource: source,
                        rehydratePriority: rehydratePriority,
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
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(BlobBaseClient));
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
            AbortCopyFromUriInternal(
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
            await AbortCopyFromUriInternal(
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
            using (Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(copyId)}: {copyId}\n" +
                    $"{nameof(leaseAccessConditions)}: {leaseAccessConditions}");
                try
                {
                    return await BlobRestClient.Blob.AbortCopyFromUriAsync(
                        Pipeline,
                        Uri,
                        copyId: copyId,
                        leaseId: leaseAccessConditions?.LeaseId,
                        async: async,
                        operationName: "Azure.Storage.Blobs.Specialized.BlobBaseClient.AbortCopyFromUri",
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
                    Pipeline.LogMethodExit(nameof(BlobBaseClient));
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
            DeleteInternal(
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
            await DeleteInternal(
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
            using (Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(deleteOptions)}: {deleteOptions}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    return await BlobRestClient.Blob.DeleteAsync(
                        Pipeline,
                        Uri,
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
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(BlobBaseClient));
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
            UndeleteInternal(
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
            await UndeleteInternal(
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
            using (Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                Pipeline.LogMethodEnter(nameof(BlobBaseClient), message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    return await BlobRestClient.Blob.UndeleteAsync(
                        Pipeline,
                        Uri,
                        async: async,
                        cancellationToken: cancellationToken,
                        operationName: "Azure.Storage.Blobs.Specialized.BlobBaseClient.Undelete")
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(BlobBaseClient));
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
            CancellationToken cancellationToken = default) =>
            GetPropertiesInternal(
                accessConditions,
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
            CancellationToken cancellationToken = default) =>
            await GetPropertiesInternal(
                accessConditions,
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
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    BlobErrors.VerifyHttpsCustomerProvidedKey(Uri, CustomerProvidedKey);

                    return await BlobRestClient.Blob.GetPropertiesAsync(
                        Pipeline,
                        Uri,
                        leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                        encryptionKey: CustomerProvidedKey?.EncryptionKey,
                        encryptionKeySha256: CustomerProvidedKey?.EncryptionKeyHash,
                        encryptionAlgorithm: CustomerProvidedKey?.EncryptionAlgorithm,
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
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(BlobBaseClient));
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
            CancellationToken cancellationToken = default) =>
            SetHttpHeadersInternal(
                httpHeaders,
                accessConditions,
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
            CancellationToken cancellationToken = default) =>
            await SetHttpHeadersInternal(
                httpHeaders,
                accessConditions,
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
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(httpHeaders)}: {httpHeaders}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    BlobErrors.VerifyHttpsCustomerProvidedKey(Uri, CustomerProvidedKey);

                    Response<SetHttpHeadersOperation> response =
                        await BlobRestClient.Blob.SetHttpHeadersAsync(
                            Pipeline,
                            Uri,
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
                    return Response.FromValue(response.GetRawResponse(), new BlobInfo
                    {
                        LastModified = response.Value.LastModified,
                        ETag = response.Value.ETag,
                        BlobSequenceNumber = response.Value.BlobSequenceNumber
                    });
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(BlobBaseClient));
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
            CancellationToken cancellationToken = default) =>
            SetMetadataInternal(
                metadata,
                accessConditions,
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
            CancellationToken cancellationToken = default) =>
            await SetMetadataInternal(
                metadata,
                accessConditions,
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
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    BlobErrors.VerifyHttpsCustomerProvidedKey(Uri, CustomerProvidedKey);

                    Response<SetMetadataOperation> response =
                        await BlobRestClient.Blob.SetMetadataAsync(
                            Pipeline,
                            Uri,
                            metadata: metadata,
                            leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                            encryptionKey: CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: CustomerProvidedKey?.EncryptionAlgorithm,
                            ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                            ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                            ifMatch: accessConditions?.HttpAccessConditions?.IfMatch,
                            ifNoneMatch: accessConditions?.HttpAccessConditions?.IfNoneMatch,
                            async: async,
                            operationName: "Azure.Storage.Blobs.Specialized.BlobBaseClient.SetMetadata",
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    return Response.FromValue(response.GetRawResponse(), new BlobInfo
                    {
                        LastModified = response.Value.LastModified,
                        ETag = response.Value.ETag
                    });
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(BlobBaseClient));
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
            CancellationToken cancellationToken = default) =>
            CreateSnapshotInternal(
                metadata,
                accessConditions,
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
            CancellationToken cancellationToken = default) =>
            await CreateSnapshotInternal(
                metadata,
                accessConditions,
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
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    BlobErrors.VerifyHttpsCustomerProvidedKey(Uri, CustomerProvidedKey);

                    return await BlobRestClient.Blob.CreateSnapshotAsync(
                        Pipeline,
                        Uri,
                        metadata: metadata,
                        encryptionKey: CustomerProvidedKey?.EncryptionKey,
                        encryptionKeySha256: CustomerProvidedKey?.EncryptionKeyHash,
                        encryptionAlgorithm: CustomerProvidedKey?.EncryptionAlgorithm,
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
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(BlobBaseClient));
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
        /// <param name="rehydratePriority">
        /// Optional <see cref="RehydratePriority"/>
        /// Indicates the priority with which to rehydrate an archived blob.
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
            RehydratePriority? rehydratePriority = default,
            CancellationToken cancellationToken = default) =>
            SetTierInternal(
                accessTier,
                leaseAccessConditions,
                rehydratePriority,
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
        /// <param name="rehydratePriority">
        /// Optional <see cref="RehydratePriority"/>
        /// Indicates the priority with which to rehydrate an archived blob.
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
            RehydratePriority? rehydratePriority = default,
            CancellationToken cancellationToken = default) =>
            await SetTierInternal(
                accessTier,
                leaseAccessConditions,
                rehydratePriority,
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
        /// <param name="rehydratePriority">
        /// Optional <see cref="RehydratePriority"/>
        /// Indicates the priority with which to rehydrate an archived blob.
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
            RehydratePriority? rehydratePriority,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(accessTier)}: {accessTier}\n" +
                    $"{nameof(leaseAccessConditions)}: {leaseAccessConditions}");
                try
                {
                    return await BlobRestClient.Blob.SetTierAsync(
                        Pipeline,
                        Uri,
                        tier: accessTier,
                        rehydratePriority: rehydratePriority,
                        leaseId: leaseAccessConditions?.LeaseId,
                        async: async,
                        operationName: "Azure.Storage.Blobs.Specialized.BlobBaseClient.SetTier",
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
                    Pipeline.LogMethodExit(nameof(BlobBaseClient));
                }
            }
        }
        #endregion SetTier
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
