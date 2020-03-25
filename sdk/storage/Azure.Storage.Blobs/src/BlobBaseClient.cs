﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
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
    /// The <see cref="BlobBaseClient"/> allows you to manipulate Azure Storage
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
        internal virtual HttpPipeline Pipeline => _pipeline;

        /// <summary>
        /// The version of the service to use when sending requests.
        /// </summary>
        private readonly BlobClientOptions.ServiceVersion _version;

        /// <summary>
        /// The version of the service to use when sending requests.
        /// </summary>
        internal virtual BlobClientOptions.ServiceVersion Version => _version;

        /// <summary>
        /// The <see cref="ClientDiagnostics"/> instance used to create diagnostic scopes
        /// every request.
        /// </summary>
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// The <see cref="ClientDiagnostics"/> instance used to create diagnostic scopes
        /// every request.
        /// </summary>
        internal virtual ClientDiagnostics ClientDiagnostics => _clientDiagnostics;

        /// <summary>
        /// The <see cref="CustomerProvidedKey"/> to be used when sending requests.
        /// </summary>
        internal readonly CustomerProvidedKey? _customerProvidedKey;

        /// <summary>
        /// The <see cref="CustomerProvidedKey"/> to be used when sending requests.
        /// </summary>
        internal virtual CustomerProvidedKey? CustomerProvidedKey => _customerProvidedKey;

        /// <summary>
        /// The name of the Encryption Scope to be used when sending requests.
        /// </summary>
        internal readonly string _encryptionScope;

        /// <summary>
        /// The name of the Encryption Scope to be used when sending requests.
        /// </summary>
        internal virtual string EncryptionScope => _encryptionScope;

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
        public virtual string BlobContainerName
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
        /// Initializes a new instance of the <see cref="BlobBaseClient"/>
        /// class.
        /// </summary>
        protected BlobBaseClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobBaseClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information, <see href="https://docs.microsoft.com/en-us/azure/storage/common/storage-configure-connection-string"/>.
        /// </param>
        /// <param name="blobContainerName">
        /// The name of the container containing this blob.
        /// </param>
        /// <param name="blobName">
        /// The name of this blob.
        /// </param>
        public BlobBaseClient(string connectionString, string blobContainerName, string blobName)
            : this(connectionString, blobContainerName, blobName, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobBaseClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information, <see href="https://docs.microsoft.com/en-us/azure/storage/common/storage-configure-connection-string"/>.
        /// </param>
        /// <param name="blobContainerName">
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
        public BlobBaseClient(string connectionString, string blobContainerName, string blobName, BlobClientOptions options)
        {
            options ??= new BlobClientOptions();
            var conn = StorageConnectionString.Parse(connectionString);
            var builder =
                new BlobUriBuilder(conn.BlobEndpoint)
                {
                    BlobContainerName = blobContainerName,
                    BlobName = blobName
                };
            _uri = builder.ToUri();
            _pipeline = options.Build(conn.Credentials);
            _version = options.Version;
            _clientDiagnostics = new ClientDiagnostics(options);
            _customerProvidedKey = options.CustomerProvidedKey;
            _encryptionScope = options.EncryptionScope;
            BlobErrors.VerifyHttpsCustomerProvidedKey(_uri, _customerProvidedKey);
            BlobErrors.VerifyCpkAndEncryptionScopeNotBothSet(_customerProvidedKey, _encryptionScope);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobBaseClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}/{blob_name}".
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
        /// Initializes a new instance of the <see cref="BlobBaseClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the blob that includes the
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
        public BlobBaseClient(Uri blobUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            : this(blobUri, credential.AsPolicy(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobBaseClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the blob that includes the
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
        public BlobBaseClient(Uri blobUri, TokenCredential credential, BlobClientOptions options = default)
            : this(blobUri, credential.AsPolicy(), options)
        {
            Errors.VerifyHttpsTokenAuth(blobUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobBaseClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}/{blob_name}".
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
            options ??= new BlobClientOptions();
            _uri = blobUri;
            _pipeline = options.Build(authentication);
            _version = options.Version;
            _clientDiagnostics = new ClientDiagnostics(options);
            _customerProvidedKey = options.CustomerProvidedKey;
            _encryptionScope = options.EncryptionScope;
            BlobErrors.VerifyHttpsCustomerProvidedKey(_uri, _customerProvidedKey);
            BlobErrors.VerifyCpkAndEncryptionScopeNotBothSet(_customerProvidedKey, _encryptionScope);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobBaseClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the blob that includes the
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
        internal BlobBaseClient(
            Uri blobUri,
            HttpPipeline pipeline,
            BlobClientOptions.ServiceVersion version,
            ClientDiagnostics clientDiagnostics,
            CustomerProvidedKey? customerProvidedKey,
            string encryptionScope)
        {
            _uri = blobUri;
            _pipeline = pipeline;
            _version = version;
            _clientDiagnostics = clientDiagnostics;
            _customerProvidedKey = customerProvidedKey;
            _encryptionScope = encryptionScope;
            BlobErrors.VerifyHttpsCustomerProvidedKey(_uri, _customerProvidedKey);
            BlobErrors.VerifyCpkAndEncryptionScopeNotBothSet(_customerProvidedKey, _encryptionScope);
        }
        #endregion ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobBaseClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="snapshot"/> timestamp.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/creating-a-snapshot-of-a-blob" />.
        /// </summary>
        /// <param name="snapshot">The snapshot identifier.</param>
        /// <returns>A new <see cref="BlobBaseClient"/> instance.</returns>
        /// <remarks>
        /// Pass null or empty string to remove the snapshot returning a URL
        /// to the base blob.
        /// </remarks>
        public virtual BlobBaseClient WithSnapshot(string snapshot) => WithSnapshotCore(snapshot);

        /// <summary>
        /// Creates a new instance of the <see cref="BlobBaseClient"/> class
        /// with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="snapshot"/> timestamp.
        /// </summary>
        /// <param name="snapshot">The snapshot identifier.</param>
        /// <returns>A new <see cref="BlobBaseClient"/> instance.</returns>
        protected virtual BlobBaseClient WithSnapshotCore(string snapshot)
        {
            var builder = new BlobUriBuilder(Uri) { Snapshot = snapshot };
            return new BlobBaseClient(builder.ToUri(), Pipeline, Version, ClientDiagnostics, CustomerProvidedKey, EncryptionScope);
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
                _containerName = builder.BlobContainerName;
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
        ///// <returns>The new <see cref="BlobBaseClient"/> instance referencing the verionId.</returns>
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobDownloadInfo> Download() =>
            Download(CancellationToken.None);

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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobDownloadInfo>> DownloadAsync() =>
            await DownloadAsync(CancellationToken.None).ConfigureAwait(false);

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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobDownloadInfo> Download(
            CancellationToken cancellationToken = default) =>
            Download(
                conditions: default, // Pass anything else so we don't recurse on this overload
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobDownloadInfo>> DownloadAsync(
            CancellationToken cancellationToken) =>
            await DownloadAsync(
                conditions: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="Download(HttpRange, BlobRequestConditions, bool, CancellationToken)"/>
        /// operation downloads a blob from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob" />.
        /// </summary>
        /// <param name="range">
        /// If provided, only donwload the bytes of the blob in the specified
        /// range.  If not provided, download the entire blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// donwloading this blob.
        /// </param>
        /// <param name="rangeGetContentHash">
        /// When set to true and specified together with the <paramref name="range"/>,
        /// the service returns the MD5 hash for the range, as long as the
        /// range is less than or equal to 4 MB in size.  If this value is
        /// specified without <paramref name="range"/> or set to true when the
        /// range exceeds 4 MB in size, a <see cref="RequestFailedException"/>
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobDownloadInfo> Download(
            HttpRange range = default,
            BlobRequestConditions conditions = default,
            bool rangeGetContentHash = default,
            CancellationToken cancellationToken = default) =>
            DownloadInternal(
                range,
                conditions,
                rangeGetContentHash,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="DownloadAsync(HttpRange, BlobRequestConditions, bool, CancellationToken)"/>
        /// operation downloads a blob from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob" />.
        /// </summary>
        /// <param name="range">
        /// If provided, only donwload the bytes of the blob in the specified
        /// range.  If not provided, download the entire blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// donwloading this blob.
        /// </param>
        /// <param name="rangeGetContentHash">
        /// When set to true and specified together with the <paramref name="range"/>,
        /// the service returns the MD5 hash for the range, as long as the
        /// range is less than or equal to 4 MB in size.  If this value is
        /// specified without <paramref name="range"/> or set to true when the
        /// range exceeds 4 MB in size, a <see cref="RequestFailedException"/>
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobDownloadInfo>> DownloadAsync(
            HttpRange range = default,
            BlobRequestConditions conditions = default,
            bool rangeGetContentHash = default,
            CancellationToken cancellationToken = default) =>
            await DownloadInternal(
                range,
                conditions,
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
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// donwloading this blob.
        /// </param>
        /// <param name="rangeGetContentHash">
        /// When set to true and specified together with the <paramref name="range"/>,
        /// the service returns the MD5 hash for the range, as long as the
        /// range is less than or equal to 4 MB in size.  If this value is
        /// specified without <paramref name="range"/> or set to true when the
        /// range exceeds 4 MB in size, a <see cref="RequestFailedException"/>
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobDownloadInfo>> DownloadInternal(
            HttpRange range,
            BlobRequestConditions conditions,
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
                        conditions,
                        rangeGetContentHash,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    // Return an exploding Response on 304
                    if (response.IsUnavailable())
                    {
                        return response.GetRawResponse().AsNoBodyResponse<BlobDownloadInfo>();
                    }

                    // Wrap the response Content in a RetriableStream so we
                    // can return it before it's finished downloading, but still
                    // allow retrying if it fails.
                    response.Value.Content = RetriableStream.Create(
                        stream,
                         startOffset =>
                            StartDownloadAsync(
                                    range,
                                    conditions,
                                    rangeGetContentHash,
                                    startOffset,
                                    async,
                                    cancellationToken)
                                .EnsureCompleted()
                            .Item2,
                        async startOffset =>
                            (await StartDownloadAsync(
                                range,
                                conditions,
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
                    return Response.FromValue(new BlobDownloadInfo(response.Value), response.GetRawResponse());
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
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// donwloading this blob.
        /// </param>
        /// <param name="rangeGetContentHash">
        /// When set to true and specified together with the <paramref name="range"/>,
        /// the service returns the MD5 hash for the range, as long as the
        /// range is less than or equal to 4 MB in size.  If this value is
        /// specified without <paramref name="range"/> or set to true when the
        /// range exceeds 4 MB in size, a <see cref="RequestFailedException"/>
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<(Response<FlattenedDownloadProperties>, Stream)> StartDownloadAsync(
            HttpRange range = default,
            BlobRequestConditions conditions = default,
            bool rangeGetContentHash = default,
            long startOffset = 0,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            var pageRange = new HttpRange(
                range.Offset + startOffset,
                range.Length.HasValue ?
                    range.Length.Value - startOffset :
                    (long?)null);

            Pipeline.LogTrace($"Download {Uri} with range: {pageRange}");

            (Response<FlattenedDownloadProperties> response, Stream stream) =
                await BlobRestClient.Blob.DownloadAsync(
                    ClientDiagnostics,
                    Pipeline,
                    Uri,
                    version: Version.ToVersionString(),
                    range: pageRange.ToString(),
                    leaseId: conditions?.LeaseId,
                    rangeGetContentHash: rangeGetContentHash ? (bool?)true : null,
                    encryptionKey: CustomerProvidedKey?.EncryptionKey,
                    encryptionKeySha256: CustomerProvidedKey?.EncryptionKeyHash,
                    encryptionAlgorithm: CustomerProvidedKey?.EncryptionAlgorithm,
                    ifModifiedSince: conditions?.IfModifiedSince,
                    ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                    ifMatch: conditions?.IfMatch,
                    ifNoneMatch: conditions?.IfNoneMatch,
                    async: async,
                    operationName: "BlobBaseClient.Download",
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

            // Watch out for exploding Responses
            long length = response.IsUnavailable() ? 0 : response.Value.ContentLength;
            Pipeline.LogTrace($"Response: {response.GetRawResponse().Status}, ContentLength: {length}");

            return (response, stream);
        }
        #endregion Download

        #region Parallel Download
        /// <summary>
        /// The <see cref="DownloadTo(Stream)"/> operation downloads a blob using parallel requests,
        /// and writes the content to <paramref name="destination"/>.
        /// </summary>
        /// <param name="destination">
        /// A <see cref="Stream"/> to write the downloaded content to.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response DownloadTo(Stream destination) =>
            DownloadTo(destination, CancellationToken.None);

        /// <summary>
        /// The <see cref="DownloadTo(string)"/> operation downloads a blob using parallel requests,
        /// and writes the content to <paramref name="path"/>.
        /// </summary>
        /// <param name="path">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response DownloadTo(string path) =>
            DownloadTo(path, CancellationToken.None);

        /// <summary>
        /// The <see cref="DownloadToAsync(Stream)"/> downloads a blob using parallel requests,
        /// and writes the content to <paramref name="destination"/>.
        /// </summary>
        /// <param name="destination">
        /// A <see cref="Stream"/> to write the downloaded content to.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> DownloadToAsync(Stream destination) =>
            await DownloadToAsync(destination, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DownloadToAsync(string)"/> downloads a blob using parallel requests,
        /// and writes the content to <paramref name="path"/>.
        /// </summary>
        /// <param name="path">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> DownloadToAsync(string path) =>
            await DownloadToAsync(path, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DownloadTo(Stream, CancellationToken)"/> operation
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
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response DownloadTo(
            Stream destination,
            CancellationToken cancellationToken) =>
            DownloadTo(
                destination,
                conditions: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="DownloadTo(string, CancellationToken)"/> operation
        /// downloads a blob using parallel requests,
        /// and writes the content to <paramref name="path"/>.
        /// </summary>
        /// <param name="path">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response DownloadTo(
            string path,
            CancellationToken cancellationToken) =>
            DownloadTo(
                path,
                conditions: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="DownloadToAsync(Stream, CancellationToken)"/> operation
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
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> DownloadToAsync(
            Stream destination,
            CancellationToken cancellationToken) =>
            await DownloadToAsync(
                destination,
                conditions: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DownloadToAsync(string, CancellationToken)"/> operation
        /// downloads a blob using parallel requests,
        /// and writes the content to <paramref name="path"/>.
        /// </summary>
        /// <param name="path">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> DownloadToAsync(
            string path,
            CancellationToken cancellationToken) =>
            await DownloadToAsync(
                path,
                conditions: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DownloadTo(Stream, BlobRequestConditions, StorageTransferOptions, CancellationToken)"/>
        /// operation downloads a blob using parallel requests,
        /// and writes the content to <paramref name="destination"/>.
        /// </summary>
        /// <param name="destination">
        /// A <see cref="Stream"/> to write the downloaded content to.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// the creation of this new block blob.
        /// </param>
        /// <param name="transferOptions">
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response DownloadTo(
            Stream destination,
            BlobRequestConditions conditions = default,
            ///// <param name="progressHandler">
            ///// Optional <see cref="IProgress{Long}"/> to provide
            ///// progress updates about data transfers.
            ///// </param>
            //IProgress<long> progressHandler = default,
            StorageTransferOptions transferOptions = default,
            CancellationToken cancellationToken = default) =>
            StagedDownloadAsync(
                destination,
                conditions,
                //progressHandler, // TODO: #8506
                transferOptions: transferOptions,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="DownloadTo(string, BlobRequestConditions, StorageTransferOptions, CancellationToken)"/>
        /// operation downloads a blob using parallel requests,
        /// and writes the content to <paramref name="path"/>.
        /// </summary>
        /// <param name="path">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// the creation of this new block blob.
        /// </param>
        /// <param name="transferOptions">
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response DownloadTo(
            string path,
            BlobRequestConditions conditions = default,
            ///// <param name="progressHandler">
            ///// Optional <see cref="IProgress{Long}"/> to provide
            ///// progress updates about data transfers.
            ///// </param>
            //IProgress<long> progressHandler = default,
            StorageTransferOptions transferOptions = default,
            CancellationToken cancellationToken = default)
        {
            using Stream destination = File.Create(path);
            return StagedDownloadAsync(
                destination,
                conditions,
                //progressHandler, // TODO: #8506
                transferOptions: transferOptions,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="DownloadToAsync(Stream, BlobRequestConditions, StorageTransferOptions, CancellationToken)"/>
        /// operation downloads a blob using parallel requests,
        /// and writes the content to <paramref name="destination"/>.
        /// </summary>
        /// <param name="destination">
        /// A <see cref="Stream"/> to write the downloaded content to.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// the creation of this new block blob.
        /// </param>
        /// <param name="transferOptions">
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> DownloadToAsync(
            Stream destination,
            BlobRequestConditions conditions = default,
            ///// <param name="progressHandler">
            ///// Optional <see cref="IProgress{Long}"/> to provide
            ///// progress updates about data transfers.
            ///// </param>
            //IProgress<long> progressHandler = default,
            StorageTransferOptions transferOptions = default,
            CancellationToken cancellationToken = default) =>
            await StagedDownloadAsync(
                destination,
                conditions,
                //progressHandler, // TODO: #8506
                transferOptions: transferOptions,
                async: true,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DownloadToAsync(string, BlobRequestConditions, StorageTransferOptions, CancellationToken)"/>
        /// operation downloads a blob using parallel requests,
        /// and writes the content to <paramref name="path"/>.
        /// </summary>
        /// <param name="path">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// the creation of this new block blob.
        /// </param>
        /// <param name="transferOptions">
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> DownloadToAsync(
            string path,
            BlobRequestConditions conditions = default,
            ///// <param name="progressHandler">
            ///// Optional <see cref="IProgress{Long}"/> to provide
            ///// progress updates about data transfers.
            ///// </param>
            //IProgress<long> progressHandler = default,
            StorageTransferOptions transferOptions = default,
            CancellationToken cancellationToken = default)
        {
            using Stream destination = File.Create(path);
            return await StagedDownloadAsync(
                destination,
                conditions,
                //progressHandler, // TODO: #8506
                transferOptions: transferOptions,
                async: true,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// This operation will download a blob of arbitrary size by downloading it as indiviually staged
        /// partitions if it's larger than the
        /// <paramref name="transferOptions"/> MaximumTransferLength.
        /// </summary>
        /// <param name="destination">
        /// A <see cref="Stream"/> to write the downloaded content to.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// the creation of this new block blob.
        /// </param>
        /// <param name="transferOptions">
        /// Optional <see cref="StorageTransferOptions"/> to configure
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
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<Response> StagedDownloadAsync(
            Stream destination,
            BlobRequestConditions conditions = default,
            ///// <param name="progressHandler">
            ///// Optional <see cref="IProgress{Long}"/> to provide
            ///// progress updates about data transfers.
            ///// </param>
            //IProgress<long> progressHandler, // TODO: #8506
            StorageTransferOptions transferOptions = default,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            var client = new BlobBaseClient(Uri, Pipeline, Version, ClientDiagnostics, CustomerProvidedKey, EncryptionScope);

            PartitionedDownloader downloader = new PartitionedDownloader(client, transferOptions);

            if (async)
            {
                return await downloader.DownloadToAsync(destination, conditions, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                return downloader.DownloadTo(destination, conditions, cancellationToken);
            }
        }
        #endregion Parallel Download

        #region StartCopyFromUri
        /// <summary>
        /// The <see cref="StartCopyFromUri(Uri, Metadata, AccessTier?, BlobRequestConditions, BlobRequestConditions, RehydratePriority?, CancellationToken)"/>
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
        /// <param name="sourceConditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="destinationConditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
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
        /// A <see cref="CopyFromUriOperation"/> describing the
        /// state of the copy operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual CopyFromUriOperation StartCopyFromUri(
            Uri source,
            Metadata metadata = default,
            AccessTier? accessTier = default,
            BlobRequestConditions sourceConditions = default,
            BlobRequestConditions destinationConditions = default,
            RehydratePriority? rehydratePriority = default,
            CancellationToken cancellationToken = default)
        {
            Response<BlobCopyInfo> response = StartCopyFromUriInternal(
                source,
                metadata,
                accessTier,
                sourceConditions,
                destinationConditions,
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
        /// The <see cref="StartCopyFromUri(Uri, Metadata, AccessTier?, BlobRequestConditions, BlobRequestConditions, RehydratePriority?, CancellationToken)"/>
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
        /// <param name="sourceConditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="destinationConditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
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
        /// A <see cref="CopyFromUriOperation"/> describing the
        /// state of the copy operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<CopyFromUriOperation> StartCopyFromUriAsync(
            Uri source,
            Metadata metadata = default,
            AccessTier? accessTier = default,
            BlobRequestConditions sourceConditions = default,
            BlobRequestConditions destinationConditions = default,
            RehydratePriority? rehydratePriority = default,
            CancellationToken cancellationToken = default)
        {
            Response<BlobCopyInfo> response = await StartCopyFromUriInternal(
                source,
                metadata,
                accessTier,
                sourceConditions,
                destinationConditions,
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
        /// <param name="sourceConditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="destinationConditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobCopyInfo>> StartCopyFromUriInternal(
            Uri source,
            Metadata metadata,
            AccessTier? accessTier,
            BlobRequestConditions sourceConditions,
            BlobRequestConditions destinationConditions,
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
                    $"{nameof(sourceConditions)}: {sourceConditions}\n" +
                    $"{nameof(destinationConditions)}: {destinationConditions}");
                try
                {
                    return await BlobRestClient.Blob.StartCopyFromUriAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        copySource: source,
                        version: Version.ToVersionString(),
                        rehydratePriority: rehydratePriority,
                        tier: accessTier,
                        sourceIfModifiedSince: sourceConditions?.IfModifiedSince,
                        sourceIfUnmodifiedSince: sourceConditions?.IfUnmodifiedSince,
                        sourceIfMatch: sourceConditions?.IfMatch,
                        sourceIfNoneMatch: sourceConditions?.IfNoneMatch,
                        ifModifiedSince: destinationConditions?.IfModifiedSince,
                        ifUnmodifiedSince: destinationConditions?.IfUnmodifiedSince,
                        ifMatch: destinationConditions?.IfMatch,
                        ifNoneMatch: destinationConditions?.IfNoneMatch,
                        leaseId: destinationConditions?.LeaseId,
                        metadata: metadata,
                        async: async,
                        operationName: "BlobBaseClient.StartCopyFromUri",
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
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response AbortCopyFromUri(
            string copyId,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            AbortCopyFromUriInternal(
                copyId,
                conditions,
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
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> AbortCopyFromUriAsync(
            string copyId,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await AbortCopyFromUriInternal(
                copyId,
                conditions,
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
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response> AbortCopyFromUriInternal(
            string copyId,
            BlobRequestConditions conditions,
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
                    $"{nameof(conditions)}: {conditions}");
                try
                {
                    return await BlobRestClient.Blob.AbortCopyFromUriAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        copyId: copyId,
                        version: Version.ToVersionString(),
                        leaseId: conditions?.LeaseId,
                        async: async,
                        operationName: "BlobBaseClient.AbortCopyFromUri",
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
        /// <see cref="DeleteSnapshotsOption.IncludeSnapshots"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-blob" />.
        /// </summary>
        /// <param name="snapshotsOption">
        /// Specifies options for deleting blob snapshots.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response Delete(
            DeleteSnapshotsOption snapshotsOption = default,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            DeleteInternal(
                snapshotsOption,
                conditions,
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
        /// <see cref="DeleteSnapshotsOption.IncludeSnapshots"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-blob" />.
        /// </summary>
        /// <param name="snapshotsOption">
        /// Specifies options for deleting blob snapshots.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> DeleteAsync(
            DeleteSnapshotsOption snapshotsOption = default,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await DeleteInternal(
                snapshotsOption,
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DeleteIfExists"/> operation marks the specified blob
        /// or snapshot for deletion, if the blob exists. The blob is later deleted
        /// during garbage collection.
        ///
        /// Note that in order to delete a blob, you must delete all of its
        /// snapshots. You can delete both at the same time using
        /// <see cref="DeleteSnapshotsOption.IncludeSnapshots"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-blob" />.
        /// </summary>
        /// <param name="snapshotsOption">
        /// Specifies options for deleting blob snapshots.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<bool> DeleteIfExists(
            DeleteSnapshotsOption snapshotsOption = default,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            DeleteIfExistsInternal(
                snapshotsOption,
                conditions ?? default,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="DeleteIfExistsAsync"/> operation marks the specified blob
        /// or snapshot for deletion, if the blob exists. The blob is later deleted
        /// during garbage collection.
        ///
        /// Note that in order to delete a blob, you must delete all of its
        /// snapshots. You can delete both at the same time using
        /// <see cref="DeleteSnapshotsOption.IncludeSnapshots"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-blob" />.
        /// </summary>
        /// <param name="snapshotsOption">
        /// Specifies options for deleting blob snapshots.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<bool>> DeleteIfExistsAsync(
            DeleteSnapshotsOption snapshotsOption = default,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await DeleteIfExistsInternal(
                snapshotsOption,
                conditions ?? default,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DeleteIfExistsInternal"/> operation marks the specified blob
        /// or snapshot for deletion, if the blob exists. The blob is later deleted
        /// during garbage collection.
        ///
        /// Note that in order to delete a blob, you must delete all of its
        /// snapshots. You can delete both at the same time using
        /// <see cref="DeleteSnapshotsOption.IncludeSnapshots"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-blob" />.
        /// </summary>
        /// <param name="snapshotsOption">
        /// Specifies options for deleting blob snapshots.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<bool>> DeleteIfExistsInternal(
            DeleteSnapshotsOption snapshotsOption,
            BlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(snapshotsOption)}: {snapshotsOption}\n" +
                    $"{nameof(conditions)}: {conditions}");
                try
                {
                    Response response = await DeleteInternal(
                        snapshotsOption,
                        conditions,
                        async,
                        cancellationToken,
                        $"{nameof(BlobBaseClient)}.{nameof(DeleteIfExists)}")
                        .ConfigureAwait(false);
                    return Response.FromValue(true, response);
                }
                catch (RequestFailedException storageRequestFailedException)
                when (storageRequestFailedException.ErrorCode == BlobErrorCode.BlobNotFound)
                {
                    return Response.FromValue(false, default);
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
        /// The <see cref="DeleteInternal"/> operation marks the specified blob
        /// or snapshot for  deletion. The blob is later deleted during
        /// garbage collection.
        ///
        /// Note that in order to delete a blob, you must delete all of its
        /// snapshots. You can delete both at the same time using
        /// <see cref="DeleteSnapshotsOption.IncludeSnapshots"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-blob" />.
        /// </summary>
        /// <param name="snapshotsOption">
        /// Specifies options for deleting blob snapshots.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// deleting this blob.
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
        /// A <see cref="Response"/> on successfully deleting.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response> DeleteInternal(
            DeleteSnapshotsOption snapshotsOption,
            BlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken,
            string operationName = null)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(snapshotsOption)}: {snapshotsOption}\n" +
                    $"{nameof(conditions)}: {conditions}");
                try
                {
                    return await BlobRestClient.Blob.DeleteAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        deleteSnapshots: snapshotsOption == DeleteSnapshotsOption.None ? null : (DeleteSnapshotsOption?)snapshotsOption,
                        leaseId: conditions?.LeaseId,
                        ifModifiedSince: conditions?.IfModifiedSince,
                        ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                        ifMatch: conditions?.IfMatch,
                        ifNoneMatch: conditions?.IfNoneMatch,
                        async: async,
                        operationName: operationName ?? $"{nameof(BlobBaseClient)}.{nameof(Delete)}",
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

        #region Exists
        /// <summary>
        /// The <see cref="Exists"/> operation can be called on a
        /// <see cref="BlobBaseClient"/> to see if the associated blob
        /// exists in the container on the storage account in the
        /// storage service.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns true if the blob exists.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<bool> Exists(
            CancellationToken cancellationToken = default) =>
            ExistsInternal(
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// The <see cref="ExistsAsync"/> operation can be called on a
        /// <see cref="BlobBaseClient"/> to see if the associated blob
        /// exists in the container on the storage account in the storage service.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns true if the blob exists.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<bool>> ExistsAsync(
            CancellationToken cancellationToken = default) =>
            await ExistsInternal(
                async: true,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="ExistsInternal"/> operation can be called on a
        /// <see cref="BlobBaseClient"/> to see if the associated blob
        /// exists on the storage account in the storage service.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns true if the blob exists.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<bool>> ExistsInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");

                try
                {
                    Response<BlobProperties> response = await BlobRestClient.Blob.GetPropertiesAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        async: async,
                        operationName: $"{nameof(BlobBaseClient)}.{nameof(Exists)}",
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return Response.FromValue(true, response.GetRawResponse());
                }
                catch (RequestFailedException storageRequestFailedException)
                when (storageRequestFailedException.ErrorCode == BlobErrorCode.BlobNotFound)
                {
                    return Response.FromValue(false, default);
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
        #endregion Exists

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
        /// A <see cref="RequestFailedException"/> will be thrown if
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
        /// A <see cref="RequestFailedException"/> will be thrown if
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
        /// A <see cref="RequestFailedException"/> will be thrown if
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
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        async: async,
                        cancellationToken: cancellationToken,
                        operationName: "BlobBaseClient.Undelete")
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
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobProperties> GetProperties(
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            GetPropertiesInternal(
                conditions,
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
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobProperties>> GetPropertiesAsync(
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await GetPropertiesInternal(
                conditions,
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
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobProperties>> GetPropertiesInternal(
            BlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(conditions)}: {conditions}");
                try
                {
                    return await BlobRestClient.Blob.GetPropertiesAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        leaseId: conditions?.LeaseId,
                        encryptionKey: CustomerProvidedKey?.EncryptionKey,
                        encryptionKeySha256: CustomerProvidedKey?.EncryptionKeyHash,
                        encryptionAlgorithm: CustomerProvidedKey?.EncryptionAlgorithm,
                        ifModifiedSince: conditions?.IfModifiedSince,
                        ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                        ifMatch: conditions?.IfMatch,
                        ifNoneMatch: conditions?.IfNoneMatch,
                        async: async,
                        operationName: "BlobBaseClient.GetProperties",
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
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobInfo> SetHttpHeaders(
            BlobHttpHeaders httpHeaders = default,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            SetHttpHeadersInternal(
                httpHeaders,
                conditions,
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
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobInfo>> SetHttpHeadersAsync(
            BlobHttpHeaders httpHeaders = default,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await SetHttpHeadersInternal(
                httpHeaders,
                conditions,
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
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobInfo>> SetHttpHeadersInternal(
            BlobHttpHeaders httpHeaders,
            BlobRequestConditions conditions,
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
                    $"{nameof(conditions)}: {conditions}");
                try
                {
                    Response<SetHttpHeadersOperation> response =
                        await BlobRestClient.Blob.SetHttpHeadersAsync(
                            ClientDiagnostics,
                            Pipeline,
                            Uri,
                            version: Version.ToVersionString(),
                            blobCacheControl: httpHeaders?.CacheControl,
                            blobContentType: httpHeaders?.ContentType,
                            blobContentHash: httpHeaders?.ContentHash,
                            blobContentEncoding: httpHeaders?.ContentEncoding,
                            blobContentLanguage: httpHeaders?.ContentLanguage,
                            blobContentDisposition: httpHeaders?.ContentDisposition,
                            leaseId: conditions?.LeaseId,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch,
                            ifNoneMatch: conditions?.IfNoneMatch,
                            async: async,
                            operationName: "BlobBaseClient.SetHttpHeaders",
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    return Response.FromValue(
                        new BlobInfo
                        {
                            LastModified = response.Value.LastModified,
                            ETag = response.Value.ETag,
                            BlobSequenceNumber = response.Value.BlobSequenceNumber
                        }, response.GetRawResponse());
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
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobInfo> SetMetadata(
            Metadata metadata,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            SetMetadataInternal(
                metadata,
                conditions,
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
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobInfo>> SetMetadataAsync(
            Metadata metadata,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await SetMetadataInternal(
                metadata,
                conditions,
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
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobInfo>> SetMetadataInternal(
            Metadata metadata,
            BlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(conditions)}: {conditions}");
                try
                {
                    Response<SetMetadataOperation> response =
                        await BlobRestClient.Blob.SetMetadataAsync(
                            ClientDiagnostics,
                            Pipeline,
                            Uri,
                            version: Version.ToVersionString(),
                            metadata: metadata,
                            leaseId: conditions?.LeaseId,
                            encryptionKey: CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: CustomerProvidedKey?.EncryptionAlgorithm,
                            encryptionScope: EncryptionScope,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch,
                            ifNoneMatch: conditions?.IfNoneMatch,
                            async: async,
                            operationName: "BlobBaseClient.SetMetadata",
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    return Response.FromValue(
                        new BlobInfo
                        {
                            LastModified = response.Value.LastModified,
                            ETag = response.Value.ETag
                        }, response.GetRawResponse());
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
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobSnapshotInfo> CreateSnapshot(
            Metadata metadata = default,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            CreateSnapshotInternal(
                metadata,
                conditions,
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
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobSnapshotInfo>> CreateSnapshotAsync(
            Metadata metadata = default,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await CreateSnapshotInternal(
                metadata,
                conditions,
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
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobSnapshotInfo>> CreateSnapshotInternal(
            Metadata metadata,
            BlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(conditions)}: {conditions}");
                try
                {
                    return await BlobRestClient.Blob.CreateSnapshotAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        metadata: metadata,
                        encryptionKey: CustomerProvidedKey?.EncryptionKey,
                        encryptionKeySha256: CustomerProvidedKey?.EncryptionKeyHash,
                        encryptionAlgorithm: CustomerProvidedKey?.EncryptionAlgorithm,
                        encryptionScope: EncryptionScope,
                        ifModifiedSince: conditions?.IfModifiedSince,
                        ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                        ifMatch: conditions?.IfMatch,
                        ifNoneMatch: conditions?.IfNoneMatch,
                        leaseId: conditions?.LeaseId,
                        async: async,
                        operationName: "BlobBaseClient.CreateSnapshot",
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

        #region SetAccessTier
        /// <summary>
        /// The <see cref="SetAccessTier"/> operation sets the tier on a blob.
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
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response SetAccessTier(
            AccessTier accessTier,
            BlobRequestConditions conditions = default,
            RehydratePriority? rehydratePriority = default,
            CancellationToken cancellationToken = default) =>
            SetAccessTierInternal(
                accessTier,
                conditions,
                rehydratePriority,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="SetAccessTierAsync"/> operation sets the tier on a blob.
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
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> SetAccessTierAsync(
            AccessTier accessTier,
            BlobRequestConditions conditions = default,
            RehydratePriority? rehydratePriority = default,
            CancellationToken cancellationToken = default) =>
            await SetAccessTierInternal(
                accessTier,
                conditions,
                rehydratePriority,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetAccessTierInternal"/> operation sets the tier on a blob.
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
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response> SetAccessTierInternal(
            AccessTier accessTier,
            BlobRequestConditions conditions,
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
                    $"{nameof(conditions)}: {conditions}");
                try
                {
                    return await BlobRestClient.Blob.SetAccessTierAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        tier: accessTier,
                        version: Version.ToVersionString(),
                        rehydratePriority: rehydratePriority,
                        leaseId: conditions?.LeaseId,
                        async: async,
                        operationName: "BlobBaseClient.SetAccessTier",
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
        #endregion SetAccessTier
    }

    /// <summary>
    /// Add easy to discover methods to <see cref="BlobContainerClient"/> for
    /// creating <see cref="BlobBaseClient"/> instances.
    /// </summary>
    public static partial class SpecializedBlobExtensions
    {
        /// <summary>
        /// Create a new <see cref="BlobBaseClient"/> object by concatenating
        /// <paramref name="blobName"/> to the end of the
        /// <paramref name="client"/>'s <see cref="BlobContainerClient.Uri"/>.
        /// The new <see cref="BlobBaseClient"/> uses the same request policy
        /// pipeline as the <see cref="BlobContainerClient"/>.
        /// </summary>
        /// <param name="client">The <see cref="BlobContainerClient"/>.</param>
        /// <param name="blobName">The name of the blob.</param>
        /// <returns>A new <see cref="BlobBaseClient"/> instance.</returns>
        public static BlobBaseClient GetBlobBaseClient(
            this BlobContainerClient client,
            string blobName) =>
            new BlobBaseClient(
                client.Uri.AppendToPath(blobName),
                client.Pipeline,
                client.Version,
                client.ClientDiagnostics,
                client.CustomerProvidedKey,
                client.EncryptionScope);
    }
}
