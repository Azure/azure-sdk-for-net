// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Cryptography;
using Azure.Storage.Sas;
using Azure.Storage.Shared;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

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
        /// The <see cref="ClientSideEncryptionOptions"/> to be used when sending/receiving requests.
        /// </summary>
        private readonly ClientSideEncryptionOptions _clientSideEncryption;

        /// <summary>
        /// The <see cref="ClientSideEncryptionOptions"/> to be used when sending/receiving requests.
        /// </summary>
        internal virtual ClientSideEncryptionOptions ClientSideEncryption => _clientSideEncryption;

        internal bool UsingClientSideEncryption => ClientSideEncryption != default;

        /// <summary>
        /// The name of the Encryption Scope to be used when sending requests.
        /// </summary>
        internal readonly string _encryptionScope;

        /// <summary>
        /// The name of the Encryption Scope to be used when sending requests.
        /// </summary>
        internal virtual string EncryptionScope => _encryptionScope;

        /// <summary>
        /// Optional. The snapshot of the blob.
        /// </summary>
        private string _snapshot;

        /// <summary>
        /// Optional. The version of the blob.
        /// </summary>
        private string _blobVersionId;

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

        /// <summary>
        /// The <see cref="StorageSharedKeyCredential"/> used to authenticate and generate SAS.
        /// </summary>
        private readonly StorageSharedKeyCredential _storageSharedKeyCredential;

        /// <summary>
        /// Gets the The <see cref="StorageSharedKeyCredential"/> used to authenticate and generate SAS.
        /// </summary>
        internal virtual StorageSharedKeyCredential SharedKeyCredential => _storageSharedKeyCredential;

        /// <summary>
        /// Determines whether the client is able to generate a SAS.
        /// If the client is authenticated with a <see cref="StorageSharedKeyCredential"/>.
        /// </summary>
        public bool CanGenerateSasUri => SharedKeyCredential != null;

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
        /// For more information,
        /// <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">
        /// Configure Azure Storage connection strings</see>
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
        /// For more information,
        /// <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">
        /// Configure Azure Storage connection strings</see>
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
            _clientSideEncryption = options._clientSideEncryptionOptions?.Clone();
            _encryptionScope = options.EncryptionScope;
            _storageSharedKeyCredential = conn.Credentials as StorageSharedKeyCredential;
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
            : this(blobUri, (HttpPipelinePolicy)null, options, null)
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
            : this(blobUri, credential.AsPolicy(), options, credential)
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
        public BlobBaseClient(Uri blobUri, AzureSasCredential credential, BlobClientOptions options = default)
            : this(blobUri, credential.AsPolicy<BlobUriBuilder>(blobUri), options, null)
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
            : this(blobUri, credential.AsPolicy(), options, null)
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
        /// <param name="storageSharedKeyCredential">
        /// The shared key credential used to sign requests.
        /// </param>
        internal BlobBaseClient(
            Uri blobUri,
            HttpPipelinePolicy authentication,
            BlobClientOptions options,
            StorageSharedKeyCredential storageSharedKeyCredential)
        {
            Argument.AssertNotNull(blobUri, nameof(blobUri));
            options ??= new BlobClientOptions();
            _uri = blobUri;
            if (!string.IsNullOrEmpty(blobUri.Query))
            {
                UriQueryParamsCollection queryParamsCollection = new UriQueryParamsCollection(blobUri.Query);
                if (queryParamsCollection.ContainsKey(Constants.SnapshotParameterName))
                {
                    _snapshot = System.Web.HttpUtility.ParseQueryString(blobUri.Query).Get(Constants.SnapshotParameterName);
                }
                if (queryParamsCollection.ContainsKey(Constants.VersionIdParameterName))
                {
                    _blobVersionId = System.Web.HttpUtility.ParseQueryString(blobUri.Query).Get(Constants.VersionIdParameterName);
                }
            }
            _pipeline = options.Build(authentication);
            _version = options.Version;
            _clientDiagnostics = new ClientDiagnostics(options);
            _customerProvidedKey = options.CustomerProvidedKey;
            _clientSideEncryption = options._clientSideEncryptionOptions?.Clone();
            _encryptionScope = options.EncryptionScope;
            _storageSharedKeyCredential = storageSharedKeyCredential;
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
        /// <param name="storageSharedKeyCredential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="clientDiagnostics">Client diagnostics.</param>
        /// <param name="customerProvidedKey">Customer provided key.</param>
        /// <param name="clientSideEncryption">Client-side encryption options.</param>
        /// <param name="encryptionScope">Encryption scope.</param>
        internal BlobBaseClient(
            Uri blobUri,
            HttpPipeline pipeline,
            StorageSharedKeyCredential storageSharedKeyCredential,
            BlobClientOptions.ServiceVersion version,
            ClientDiagnostics clientDiagnostics,
            CustomerProvidedKey? customerProvidedKey,
            ClientSideEncryptionOptions clientSideEncryption,
            string encryptionScope)
        {
            _uri = blobUri;
            if (!string.IsNullOrEmpty(blobUri.Query))
            {
                UriQueryParamsCollection queryParamsCollection = new UriQueryParamsCollection(blobUri.Query);
                if (queryParamsCollection.ContainsKey(Constants.SnapshotParameterName))
                {
                    _snapshot = System.Web.HttpUtility.ParseQueryString(blobUri.Query).Get(Constants.SnapshotParameterName);
                }
                if (queryParamsCollection.ContainsKey(Constants.VersionIdParameterName))
                {
                    _blobVersionId = System.Web.HttpUtility.ParseQueryString(blobUri.Query).Get(Constants.VersionIdParameterName);
                }
            }
            _pipeline = pipeline;
            _storageSharedKeyCredential = storageSharedKeyCredential;
            _version = version;
            _clientDiagnostics = clientDiagnostics;
            _customerProvidedKey = customerProvidedKey;
            _clientSideEncryption = clientSideEncryption?.Clone();
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/creating-a-snapshot-of-a-blob">
        /// Create a snapshot of a blob</see>.
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
            _snapshot = snapshot;
            var blobUriBuilder = new BlobUriBuilder(Uri)
            {
                Snapshot = snapshot
            };

            return new BlobBaseClient(
                blobUriBuilder.ToUri(),
                Pipeline,
                SharedKeyCredential,
                Version,
                ClientDiagnostics,
                CustomerProvidedKey,
                ClientSideEncryption,
                EncryptionScope);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobBaseClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="versionId"/> timestamp.
        ///
        /// </summary>
        /// <param name="versionId">The version identifier.</param>
        /// <returns>A new <see cref="BlobBaseClient"/> instance.</returns>
        /// <remarks>
        /// Pass null or empty string to remove the version returning a URL
        /// to the base blob.
        /// </remarks>
        public virtual BlobBaseClient WithVersion(string versionId) => WithVersionCore(versionId);

        /// <summary>
        /// Creates a new instance of the <see cref="BlobBaseClient"/> class
        /// with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="versionId"/> timestamp.
        /// </summary>
        /// <param name="versionId">The version identifier.</param>
        /// <returns>A new <see cref="BlobBaseClient"/> instance.</returns>
        private protected virtual BlobBaseClient WithVersionCore(string versionId)
        {
            _blobVersionId = versionId;
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(Uri)
            {
                VersionId = versionId
            };

            return new BlobBaseClient(
                blobUriBuilder.ToUri(),
                Pipeline,
                SharedKeyCredential,
                Version,
                ClientDiagnostics,
                CustomerProvidedKey,
                ClientSideEncryption,
                EncryptionScope);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobLeaseClient"/> class.
        /// </summary>
        /// <param name="leaseId">
        /// An optional lease ID.  If no lease ID is provided, a random lease
        /// ID will be created.
        /// </param>
        protected internal virtual BlobLeaseClient GetBlobLeaseClientCore(string leaseId) =>
            new BlobLeaseClient(this, leaseId);

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
        ///// Pass null or empty string to remove the version ID returning a URL to the base blob.
        ///// </remarks>
        ///// <param name="versionId">The version ID to use on this blob. An empty string or null indicates to use the base blob.</param>
        ///// <returns>The new <see cref="BlobBaseClient"/> instance referencing the versionId.</returns>
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="range">
        /// If provided, only download the bytes of the blob in the specified
        /// range.  If not provided, download the entire blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// downloading this blob.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="range">
        /// If provided, only download the bytes of the blob in the specified
        /// range.  If not provided, download the entire blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// downloading this blob.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="range">
        /// If provided, only download the bytes of the blob in the specified
        /// range.  If not provided, download the entire blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// downloading this blob.
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
            HttpRange requestedRange = range;
            using (Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                Pipeline.LogMethodEnter(nameof(BlobBaseClient), message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    if (UsingClientSideEncryption)
                    {
                        range = BlobClientSideDecryptor.GetEncryptedBlobRange(range);
                    }

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
                    stream = RetriableStream.Create(
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

                    // if using clientside encryption, wrap the auto-retry stream in a decryptor
                    // we already return a nonseekable stream; returning a crypto stream is fine
                    if (UsingClientSideEncryption)
                    {
                        stream = await new BlobClientSideDecryptor(new ClientSideDecryptor(ClientSideEncryption))
                            .DecryptInternal(stream, response.Value.Metadata, requestedRange, response.Value.ContentRange, async, cancellationToken).ConfigureAwait(false);
                    }

                    response.Value.Content = stream;

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
        /// downloading this blob.
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
            HttpRange? pageRange = null;
            if (range != default || startOffset != 0)
            {
                pageRange = new HttpRange(
                    range.Offset + startOffset,
                    range.Length.HasValue ?
                        range.Length.Value - startOffset :
                        (long?)null);
            }

            Pipeline.LogTrace($"Download {Uri} with range: {pageRange}");

            (Response<FlattenedDownloadProperties> response, Stream stream) =
                await BlobRestClient.Blob.DownloadAsync(
                    ClientDiagnostics,
                    Pipeline,
                    Uri,
                    version: Version.ToVersionString(),
                    range: pageRange?.ToString(),
                    leaseId: conditions?.LeaseId,
                    rangeGetContentHash: rangeGetContentHash ? (bool?)true : null,
                    encryptionKey: CustomerProvidedKey?.EncryptionKey,
                    encryptionKeySha256: CustomerProvidedKey?.EncryptionKeyHash,
                    encryptionAlgorithm: CustomerProvidedKey?.EncryptionAlgorithm,
                    ifModifiedSince: conditions?.IfModifiedSince,
                    ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                    ifMatch: conditions?.IfMatch,
                    ifNoneMatch: conditions?.IfNoneMatch,
                    ifTags: conditions?.TagConditions,
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
        /// This operation will download a blob of arbitrary size by downloading it as individually staged
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
            var client = new BlobBaseClient(Uri, Pipeline, SharedKeyCredential, Version, ClientDiagnostics, CustomerProvidedKey, ClientSideEncryption, EncryptionScope);

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

        #region OpenRead
        /// <summary>
        /// Opens a stream for reading from the blob.  The stream will only download
        /// the blob as the stream is read from.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns a stream that will download the blob as the stream
        /// is read from.
        /// </returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Stream OpenRead(
#pragma warning restore AZC0015 // Unexpected client method return type.
            BlobOpenReadOptions options,
            CancellationToken cancellationToken = default)
            => OpenReadInternal(
                options?.Position ?? 0,
                options?.BufferSize,
                options?.Conditions,
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// Opens a stream for reading from the blob.  The stream will only download
        /// the blob as the stream is read from.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns a stream that will download the blob as the stream
        /// is read from.
        /// </returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Stream> OpenReadAsync(
#pragma warning restore AZC0015 // Unexpected client method return type.
            BlobOpenReadOptions options,
            CancellationToken cancellationToken = default)
            => await OpenReadInternal(
                options.Position,
                options?.BufferSize,
                options?.Conditions,
                async: true,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Opens a stream for reading from the blob.  The stream will only download
        /// the blob as the stream is read from.
        /// </summary>
        /// <param name="position">
        /// The position within the blob to begin the stream.
        /// Defaults to the beginning of the blob.
        /// </param>
        /// <param name="bufferSize">
        /// The buffer size to use when the stream downloads parts
        /// of the blob.  Defaults to 1 MB.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// the download of the blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns a stream that will download the blob as the stream
        /// is read from.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Stream OpenRead(
#pragma warning restore AZC0015 // Unexpected client method return type.
            long position = 0,
            int? bufferSize = default,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
            => OpenReadInternal(
                position,
                bufferSize,
                conditions,
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// Opens a stream for reading from the blob.  The stream will only download
        /// the blob as the stream is read from.
        /// </summary>
        /// <param name="allowBlobModifications">
        /// If true, you can continue streaming a blob even if it has been modified.
        /// </param>
        /// <param name="position">
        /// The position within the blob to begin the stream.
        /// Defaults to the beginning of the blob.
        /// </param>
        /// <param name="bufferSize">
        /// The buffer size to use when the stream downloads parts
        /// of the blob.  Defaults to 1 MB.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns a stream that will download the blob as the stream
        /// is read from.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Stream OpenRead(
#pragma warning restore AZC0015 // Unexpected client method return type.
            bool allowBlobModifications,
            long position = 0,
            int? bufferSize = default,
            CancellationToken cancellationToken = default)
                => OpenRead(
                    position,
                    bufferSize,
                    allowBlobModifications ? new BlobRequestConditions() : null,
                    cancellationToken);

        /// <summary>
        /// Opens a stream for reading from the blob.  The stream will only download
        /// the blob as the stream is read from.
        /// </summary>
        /// <param name="position">
        /// The position within the blob to begin the stream.
        /// Defaults to the beginning of the blob.
        /// </param>
        /// <param name="bufferSize">
        /// The buffer size to use when the stream downloads parts
        /// of the blob.  Defaults to 1 MB.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// the download of the blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns a stream that will download the blob as the stream
        /// is read from.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Stream> OpenReadAsync(
#pragma warning restore AZC0015 // Unexpected client method return type.
            long position = 0,
            int? bufferSize = default,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
            => await OpenReadInternal(
                position,
                bufferSize,
                conditions,
                async: true,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Opens a stream for reading from the blob.  The stream will only download
        /// the blob as the stream is read from.
        /// </summary>
        /// <param name="allowBlobModifications">
        /// If true, you can continue streaming a blob even if it has been modified.
        /// </param>
        /// <param name="position">
        /// The position within the blob to begin the stream.
        /// Defaults to the beginning of the blob.
        /// </param>
        /// <param name="bufferSize">
        /// The buffer size to use when the stream downloads parts
        /// of the blob.  Defaults to 1 MB.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns a stream that will download the blob as the stream
        /// is read from.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Stream> OpenReadAsync(
#pragma warning restore AZC0015 // Unexpected client method return type.
            bool allowBlobModifications,
            long position = 0,
            int? bufferSize = default,
            CancellationToken cancellationToken = default)
                => await OpenReadAsync(
                    position,
                    bufferSize,
                    allowBlobModifications ? new BlobRequestConditions() : null,
                    cancellationToken)
                    .ConfigureAwait(false);

        /// <summary>
        /// Opens a stream for reading from the blob.  The stream will only download
        /// the blob as the stream is read from.
        /// </summary>
        /// <param name="position">
        /// The position within the blob to begin the stream.
        /// Defaults to the beginning of the blob.
        /// </param>
        /// <param name="bufferSize">
        /// The buffer size to use when the stream downloads parts
        /// of the blob.  Defaults to 1 MB.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// the download of the blob.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns a stream that will download the blob as the stream
        /// is read from.
        /// </returns>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        internal async Task<Stream> OpenReadInternal(
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            long position,
            int? bufferSize,
            BlobRequestConditions conditions,
#pragma warning disable CA1801
            bool async,
            CancellationToken cancellationToken)
#pragma warning restore CA1801
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                Pipeline.LogMethodEnter(
                nameof(BlobBaseClient),
                message:
                $"{nameof(position)}: {position}\n" +
                $"{nameof(bufferSize)}: {bufferSize}\n" +
                $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(BlobBaseClient)}.{nameof(OpenRead)}");
                try
                {
                    scope.Start();

                    // This also makes sure that we fail fast if file doesn't exist.
                    var blobProperties = await GetPropertiesInternal(conditions: conditions, async, cancellationToken).ConfigureAwait(false);

                    return new LazyLoadingReadOnlyStream<BlobRequestConditions, BlobProperties>(
                        async (HttpRange range,
                        BlobRequestConditions conditions,
                        bool rangeGetContentHash,
                        bool async,
                        CancellationToken cancellationToken) =>
                        {
                            Response<BlobDownloadInfo> response = await DownloadInternal(
                                range,
                                conditions,
                                rangeGetContentHash,
                                async,
                                cancellationToken).ConfigureAwait(false);

                            return Response.FromValue(
                                (IDownloadedContent)response.Value,
                                response.GetRawResponse());
                        },
                        (ETag? eTag) => new BlobRequestConditions { IfMatch = eTag },
                        async (bool async, CancellationToken cancellationToken)
                            => await GetPropertiesInternal(conditions: default, async, cancellationToken).ConfigureAwait(false),
                        blobProperties.Value.ContentLength,
                        position,
                        bufferSize,
                        conditions);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    scope.Dispose();
                    Pipeline.LogMethodExit(nameof(BlobContainerClient));
                }
            }
        }

        #endregion OpenRead

        #region StartCopyFromUri
        /// <summary>
        /// The <see cref="StartCopyFromUri(Uri, BlobCopyFromUriOptions, CancellationToken)"/>
        /// operation begins an asynchronous copy of the data from the <paramref name="source"/> to this blob.
        /// You can check the <see cref="BlobProperties.CopyStatus"/>
        /// returned from the <see cref="GetProperties"/> to determine if the
        /// copy has completed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob">
        /// Copy Blob</see>.
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
        /// <param name="options">
        /// Optional parameters.
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
            BlobCopyFromUriOptions options,
            CancellationToken cancellationToken = default)
        {
            Response<BlobCopyInfo> response = StartCopyFromUriInternal(
                source,
                options?.Metadata,
                options?.Tags,
                options?.AccessTier,
                options?.SourceConditions,
                options?.DestinationConditions,
                options?.RehydratePriority,
                options?.ShouldSealDestination,
                async: false,
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
        /// operation begins an asynchronous copy of the data from the <paramref name="source"/> to this blob.
        /// You can check the <see cref="BlobProperties.CopyStatus"/>
        /// returned from the <see cref="GetProperties"/> to determine if the
        /// copy has completed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob">
        /// Copy Blob</see>.
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
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                default,
                accessTier,
                sourceConditions,
                destinationConditions,
                rehydratePriority,
                sealBlob: default,
                async: false,
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
        /// operation begins an asynchronous copy of the data from the <paramref name="source"/>
        /// to this blob.  You can check the <see cref="BlobProperties.CopyStatus"/>
        /// returned from the <see cref="GetPropertiesAsync"/> to determine if
        /// the copy has completed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob">
        /// Copy Blob</see>.
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
        /// <param name="options">
        /// Optional parameters.
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
            BlobCopyFromUriOptions options,
            CancellationToken cancellationToken = default)
        {
            Response<BlobCopyInfo> response = await StartCopyFromUriInternal(
                source,
                options?.Metadata,
                options?.Tags,
                options?.AccessTier,
                options?.SourceConditions,
                options?.DestinationConditions,
                options?.RehydratePriority,
                options?.ShouldSealDestination,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);
            return new CopyFromUriOperation(
                this,
                response.Value.CopyId,
                response.GetRawResponse(),
                cancellationToken);
        }

        /// <summary>
        /// The <see cref="StartCopyFromUri(Uri, Metadata, AccessTier?, BlobRequestConditions, BlobRequestConditions, RehydratePriority?, CancellationToken)"/>
        /// operation begins an asynchronous copy of the data from the <paramref name="source"/>
        /// to this blob.You can check the <see cref="BlobProperties.CopyStatus"/>
        /// returned from the <see cref="GetPropertiesAsync"/> to determine if
        /// the copy has completed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob">
        /// Copy Blob</see>.
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
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                default,
                accessTier,
                sourceConditions,
                destinationConditions,
                rehydratePriority,
                sealBlob: default,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);
            return new CopyFromUriOperation(
                this,
                response.Value.CopyId,
                response.GetRawResponse(),
                cancellationToken);
        }

        /// <summary>
        /// The <see cref="StartCopyFromUriInternal"/> operation begins an
        /// asynchronous copy of the data from the <paramref name="source"/>
        /// to this blob.  You can check <see cref="BlobProperties.CopyStatus"/>
        /// returned from the<see cref="GetPropertiesAsync"/> to determine if
        /// the copy has completed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob">
        /// Copy Blob</see>.
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
        /// <param name="tags">
        /// Optional tags to set for this blob.
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
        /// <param name="sealBlob">
        /// If the destination blob should be sealed.
        /// Only applicable for Append Blobs.
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
            Tags tags,
            AccessTier? accessTier,
            BlobRequestConditions sourceConditions,
            BlobRequestConditions destinationConditions,
            RehydratePriority? rehydratePriority,
            bool? sealBlob,
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
                        sourceIfTags: sourceConditions?.TagConditions,
                        ifModifiedSince: destinationConditions?.IfModifiedSince,
                        ifUnmodifiedSince: destinationConditions?.IfUnmodifiedSince,
                        ifMatch: destinationConditions?.IfMatch,
                        ifNoneMatch: destinationConditions?.IfNoneMatch,
                        leaseId: destinationConditions?.LeaseId,
                        ifTags: destinationConditions?.TagConditions,
                        metadata: metadata,
                        blobTagsString: tags?.ToTagsString(),
                        sealBlob: sealBlob,
                        async: async,
                        operationName: $"{nameof(BlobBaseClient)}.{nameof(StartCopyFromUri)}",
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/abort-copy-blob">
        /// Abort Copy Blob</see>.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/abort-copy-blob">
        /// Abort Copy Blob</see>.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/abort-copy-blob">
        /// Abort Copy Blob</see>.
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

        #region CopyFromUri
        /// <summary>
        /// The Copy Blob From URL operation copies a blob to a destination within the storage account synchronously
        /// for source blob sizes up to 256 MB. This API is available starting in version 2018-03-28.
        /// The source for a Copy Blob From URL operation can be any committed block blob in any Azure storage account
        /// which is either public or authorized with a shared access signature.
        ///
        /// The size of the source blob can be a maximum length of up to 256 MB.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob-from-url">
        /// Copy Blob From URL</see>.
        /// </summary>
        /// <param name="source">
        /// Required. Specifies the URL of the source blob. The value may be a URL of up to 2 KB in length
        /// that specifies a blob. The value should be URL-encoded as it would appear in a request URI. The
        /// source blob must either be public or must be authorized via a shared access signature. If the
        /// source blob is public, no authorization is required to perform the operation. If the size of the
        /// source blob is greater than 256 MB, the request will fail with 409 (Conflict). The blob type of
        /// the source blob has to be block blob.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
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
        public virtual Response<BlobCopyInfo> SyncCopyFromUri(
            Uri source,
            BlobCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default)
            => SyncCopyFromUriInternal(
                source: source,
                metadata: options?.Metadata,
                tags: options?.Tags,
                accessTier: options?.AccessTier,
                sourceConditions: options?.SourceConditions,
                destinationConditions: options?.DestinationConditions,
                async: false,
                cancellationToken: cancellationToken)
            .EnsureCompleted();

        /// <summary>
        /// The Copy Blob From URL operation copies a blob to a destination within the storage account synchronously
        /// for source blob sizes up to 256 MB. This API is available starting in version 2018-03-28.
        /// The source for a Copy Blob From URL operation can be any committed block blob in any Azure storage account
        /// which is either public or authorized with a shared access signature.
        ///
        /// The size of the source blob can be a maximum length of up to 256 MB.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob-from-url">
        /// Copy Blob From URL</see>.
        /// </summary>
        /// <param name="source">
        /// Required. Specifies the URL of the source blob. The value may be a URL of up to 2 KB in length
        /// that specifies a blob. The value should be URL-encoded as it would appear in a request URI. The
        /// source blob must either be public or must be authorized via a shared access signature. If the
        /// source blob is public, no authorization is required to perform the operation. If the size of the
        /// source blob is greater than 256 MB, the request will fail with 409 (Conflict). The blob type of
        /// the source blob has to be block blob.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
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
        public virtual async Task<Response<BlobCopyInfo>> SyncCopyFromUriAsync(
            Uri source,
            BlobCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default)
            => await SyncCopyFromUriInternal(
                source: source,
                metadata: options?.Metadata,
                tags: options?.Tags,
                accessTier: options?.AccessTier,
                sourceConditions: options?.SourceConditions,
                destinationConditions: options?.DestinationConditions,
                async: true,
                cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// The Copy Blob From URL operation copies a blob to a destination within the storage account synchronously
        /// for source blob sizes up to 256 MB. This API is available starting in version 2018-03-28.
        /// The source for a Copy Blob From URL operation can be any committed block blob in any Azure storage account
        /// which is either public or authorized with a shared access signature.
        ///
        /// The size of the source blob can be a maximum length of up to 256 MB.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob-from-url">
        /// Copy Blob From URL</see>.
        /// </summary>
        /// <param name="source">
        /// Required. Specifies the URL of the source blob. The value may be a URL of up to 2 KB in length
        /// that specifies a blob. The value should be URL-encoded as it would appear in a request URI. The
        /// source blob must either be public or must be authorized via a shared access signature. If the
        /// source blob is public, no authorization is required to perform the operation. If the size of the
        /// source blob is greater than 256 MB, the request will fail with 409 (Conflict). The blob type of
        /// the source blob has to be block blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this blob.
        /// </param>
        /// <param name="tags">
        /// Optional tags to set for this blob.
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
        private async Task<Response<BlobCopyInfo>> SyncCopyFromUriInternal(
            Uri source,
            Metadata metadata,
            Tags tags,
            AccessTier? accessTier,
            BlobRequestConditions sourceConditions,
            BlobRequestConditions destinationConditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                try
                {
                    Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(source)}: {source}\n" +
                    $"{nameof(sourceConditions)}: {sourceConditions}\n" +
                    $"{nameof(destinationConditions)}: {destinationConditions}");

                    return await BlobRestClient.Blob.CopyFromUriAsync(
                        clientDiagnostics: ClientDiagnostics,
                        pipeline: Pipeline,
                        resourceUri: Uri,
                        copySource: source,
                        version: Version.ToVersionString(),
                        tier: accessTier,
                        sourceIfModifiedSince: sourceConditions?.IfModifiedSince,
                        sourceIfUnmodifiedSince: sourceConditions?.IfUnmodifiedSince,
                        sourceIfMatch: sourceConditions?.IfMatch,
                        sourceIfNoneMatch: sourceConditions?.IfNoneMatch,
                        ifModifiedSince: destinationConditions?.IfModifiedSince,
                        ifUnmodifiedSince: destinationConditions?.IfUnmodifiedSince,
                        ifMatch: destinationConditions?.IfMatch,
                        ifNoneMatch: destinationConditions?.IfNoneMatch,
                        ifTags: destinationConditions?.TagConditions,
                        leaseId: destinationConditions?.LeaseId,
                        metadata: metadata,
                        blobTagsString: tags?.ToTagsString(),
                        async: async,
                        operationName: $"{nameof(BlobBaseClient)}.{nameof(SyncCopyFromUri)}",
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
        #endregion CopyFromUri

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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-blob">
        /// Delete Blob</see>.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-blob">
        /// Delete Blob</see>.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-blob">
        /// Delete Blob</see>.
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
        /// A <see cref="Response"/> Returns true if blob exists and was
        /// deleted, return false otherwise.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-blob">
        /// Delete Blob</see>.
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
        /// A <see cref="Response"/> Returns true if blob exists and was
        /// deleted, return false otherwise.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-blob">
        /// Delete Blob</see>.
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
        internal async Task<Response<bool>> DeleteIfExistsInternal(
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
                when (storageRequestFailedException.ErrorCode == BlobErrorCode.BlobNotFound
                    || storageRequestFailedException.ErrorCode == BlobErrorCode.ContainerNotFound)
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-blob">
        /// Delete Blob</see>.
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
                        ifTags: conditions?.TagConditions,
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
                    Response<BlobProperties> response = await GetPropertiesInternal(
                        conditions: default,
                        async: async,
                        cancellationToken: cancellationToken,
                        $"{nameof(BlobBaseClient)}.{nameof(Exists)}")
                        .ConfigureAwait(false);

                    return Response.FromValue(true, response.GetRawResponse());
                }
                catch (RequestFailedException storageRequestFailedException)
                when (storageRequestFailedException.ErrorCode == BlobErrorCode.BlobNotFound
                    || storageRequestFailedException.ErrorCode == BlobErrorCode.ContainerNotFound)
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/undelete-blob">
        /// Undelete Blob</see>.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/undelete-blob">
        /// Undelete Blob</see>.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/undelete-blob">
        /// Undelete Blob</see>.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob-properties">
        /// Get Blob Properties</see>.
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
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetPropertiesAsync"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the blob. It does not return the content of the
        /// blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob-properties">
        /// Get Blob Properties</see>.
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
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetPropertiesInternal"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the blob. It does not return the content of the
        /// blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob-properties">
        /// Get Blob Properties</see>.
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
        /// <param name="operationName">
        /// The name of the calling operation.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobProperties}"/> describing the
        /// blob's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<Response<BlobProperties>> GetPropertiesInternal(
            BlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken,
            string operationName = default)
        {
            operationName ??= $"{nameof(BlobBaseClient)}.{nameof(GetProperties)}";
            using (Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(conditions)}: {conditions}");
                try
                {
                    Response<BlobPropertiesInternal> response = await BlobRestClient.Blob.GetPropertiesAsync(
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
                        ifTags: conditions?.TagConditions,
                        async: async,
                        operationName: operationName,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return Response.FromValue(
                        response.Value.ToBlobProperties(),
                        response.GetRawResponse());
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-properties">
        /// Set Blob Properties</see>.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional. The standard HTTP header system properties to set.
        /// If not specified, existing values will be cleared.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-properties">
        /// Set Blob Properties</see>.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-properties">
        /// Set Blob Properties</see>.
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
                            ifTags: conditions?.TagConditions,
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-metadata">
        /// Set Blob Metadata</see>.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-metadata">
        /// Set Blob Metadata</see>.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-metadata">
        /// Set Blob Metadata</see>.
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
                            ifTags: conditions?.TagConditions,
                            async: async,
                            operationName: "BlobBaseClient.SetMetadata",
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    return Response.FromValue(
                        new BlobInfo
                        {
                            LastModified = response.Value.LastModified,
                            ETag = response.Value.ETag,
                            VersionId = response.Value.VersionId
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/snapshot-blob">
        /// Snapshot Blob</see>.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/snapshot-blob">
        /// Snapshot Blob</see>.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/snapshot-blob">
        /// Snapshot Blob</see>.
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
                        ifTags: conditions?.TagConditions,
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
        /// tiering <see href="https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blob-storage-tiers">
        /// Blob Storage Tiers</see>.
        ///
        /// For more information about setting the tier, see
        /// <see href="https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blob-storage-tiers">
        /// Blob Storage Tiers</see>.
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
        /// tiering <see href="https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blob-storage-tiers">
        /// Blob Storage Tiers</see>.
        ///
        /// For more information about setting the tier, see
        /// <see href="https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blob-storage-tiers">
        /// Blob Storage Tiers</see>.
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
        /// tiering <see href="https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blob-storage-tiers">
        /// Blob Storage Tiers</see>.
        ///
        /// For more information about setting the tier, see
        /// <see href="https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blob-storage-tiers">
        /// Blob Storage Tiers</see>.
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
                        ifTags: conditions?.TagConditions,
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

        #region GetTags
        /// <summary>
        /// Gets the tags associated with the underlying blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-blob-tags">
        /// Get Blob Tags</see>
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// getting the blob's tags.  Note that TagConditions is currently the
        /// only condition supported by GetTags.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Tags}"/> on successfully getting tags.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<GetBlobTagResult> GetTags(
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            GetTagsInternal(
                conditions: conditions,
                async: false,
                cancellationToken: cancellationToken)
            .EnsureCompleted();

        /// <summary>
        /// Gets the tags associated with the underlying blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-blob-tags">
        /// Get Blob Tags</see>
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// getting the blob's tags.  Note that TagConditions is currently the
        /// only condition supported by GetTags.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Tags}"/> on successfully getting tags.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<GetBlobTagResult>> GetTagsAsync(
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await GetTagsInternal(
                conditions: conditions,
                async: true,
                cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// Gets the tags associated with the underlying blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-blob-tags">
        /// Get Blob Tags</see>
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// getting the blob's tags.  Note that TagConditions is currently the
        /// only condition supported by GetTags.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Tags}"/> on successfully getting tags.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<GetBlobTagResult>> GetTagsInternal(
            bool async,
            BlobRequestConditions conditions,
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
                    Response<BlobTags> response = await BlobRestClient.Blob.GetTagsAsync(
                        clientDiagnostics: ClientDiagnostics,
                        pipeline: Pipeline,
                        resourceUri: Uri,
                        version: Version.ToVersionString(),
                        ifTags: conditions?.TagConditions,
                        leaseId: conditions?.LeaseId,
                        async: async,
                        operationName: $"{nameof(BlobBaseClient)}.{nameof(GetTags)}",
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    GetBlobTagResult result = new GetBlobTagResult
                    {
                        Tags = response.Value.ToTagDictionary()
                    };

                    return Response.FromValue(
                        result,
                        response.GetRawResponse());
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
        #endregion

        #region SetTags
        /// <summary>
        /// Sets tags on the underlying blob.
        /// A blob can have up to 10 tags.  Tag keys must be between 1 and 128 characters.  Tag values must be between 0 and 256 characters.
        /// Valid tag key and value characters include lower and upper case letters, digits (0-9),
        /// space (' '), plus ('+'), minus ('-'), period ('.'), foward slash ('/'), colon (':'), equals ('='), and underscore ('_').
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-blob-tags">
        /// Set Blob Tags</see>.
        /// </summary>
        /// <param name="tags">
        /// The tags to set on the blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// setting the blob's tags.  Note that TagConditions is currently the
        /// only condition supported by SetTags.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully setting the blob tags..
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response SetTags(
            Tags tags,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            SetTagsInternal(
                tags: tags,
                conditions: conditions,
                async: false,
                cancellationToken: cancellationToken)
            .EnsureCompleted();

        /// <summary>
        /// Sets tags on the underlying blob.
        /// A blob can have up to 10 tags.  Tag keys must be between 1 and 128 characters.  Tag values must be between 0 and 256 characters.
        /// Valid tag key and value characters include lower and upper case letters, digits (0-9),
        /// space (' '), plus ('+'), minus ('-'), period ('.'), foward slash ('/'), colon (':'), equals ('='), and underscore ('_').
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-blob-tags">
        /// Set Blob Tags</see>.
        /// </summary>
        /// <param name="tags">
        /// The tags to set on the blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// setting the blob's tags.  Note that TagConditions is currently the
        /// only condition supported by SetTags.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully setting the blob tags..
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> SetTagsAsync(
            Tags tags,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await SetTagsInternal(
                tags: tags,
                conditions: conditions,
                async: true,
                cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// Sets tags on the underlying blob.
        /// A blob can have up to 10 tags.  Tag keys must be between 1 and 128 characters.  Tag values must be between 0 and 256 characters.
        /// Valid tag key and value characters include lower and upper case letters, digits (0-9),
        /// space (' '), plus ('+'), minus ('-'), period ('.'), foward slash ('/'), colon (':'), equals ('='), and underscore ('_').
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-blob-tags">
        /// Set Blob Tags</see>.
        /// </summary>
        /// <param name="tags">
        /// The tags to set on the blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// setting the blob's tags.  Note that TagConditions is currently the
        /// only condition supported by SetTags.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully setting the blob tags..
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        //TODO what about content CRC and content MD5?
        private async Task<Response> SetTagsInternal(
            Tags tags,
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
                    $"{nameof(tags)}: {tags}");
                try
                {
                    return await BlobRestClient.Blob.SetTagsAsync(
                        clientDiagnostics: ClientDiagnostics,
                        pipeline: Pipeline,
                        resourceUri: Uri,
                        version: Version.ToVersionString(),
                        tags: tags.ToBlobTags(),
                        ifTags: conditions?.TagConditions,
                        leaseId: conditions?.LeaseId,
                        async: async,
                        operationName: $"{nameof(BlobBaseClient)}.{nameof(SetTags)}",
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
        #endregion

        #region GenerateSas
        /// <summary>
        /// The <see cref="GenerateSasUri(BlobSasPermissions, DateTimeOffset)"/>
        /// returns a <see cref="Uri"/> that generates a Blob Service
        /// Shared Access Signature (SAS) Uri based on the Client properties and
        /// parameters passed. The SAS is signed by the shared key credential
        /// of the client.
        ///
        /// To check if the client is able to sign a Service Sas see
        /// <see cref="CanGenerateSasUri"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas">
        /// Constructing a service SAS</see>.
        /// </summary>
        /// <param name="permissions">
        /// Required. Specifies the list of permissions to be associated with the SAS.
        /// See <see cref="BlobSasPermissions"/>.
        /// </param>
        /// <param name="expiresOn">
        /// Required. Specifies the time at which the SAS becomes invalid. This field
        /// must be omitted if it has been specified in an associated stored access policy.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if a failure occurs.
        /// </remarks>
        public virtual Uri GenerateSasUri(BlobSasPermissions permissions, DateTimeOffset expiresOn) =>
            GenerateSasUri(new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = BlobContainerName,
                BlobName = Name,
                Snapshot = _snapshot,
                BlobVersionId = _blobVersionId
            });

        /// <summary>
        /// The <see cref="GenerateSasUri(BlobSasBuilder)"/> returns a <see cref="Uri"/>
        /// that generates a Blob Service Shared Access Signature (SAS) Uri
        /// based on the Client properties and and builder. The SAS is signed
        /// by the shared key credential of the client.
        ///
        /// To check if the client is able to sign a Service Sas see
        /// <see cref="CanGenerateSasUri"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas">
        /// Constructing a Service SAS</see>.
        /// </summary>
        /// <param name="builder">
        /// Used to generate a Shared Access Signature (SAS).
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Uri GenerateSasUri(BlobSasBuilder builder)
        {
            builder = builder ?? throw Errors.ArgumentNull(nameof(builder));
            if (!builder.BlobContainerName.Equals(BlobContainerName, StringComparison.InvariantCulture))
            {
                throw Errors.SasNamesNotMatching(
                    nameof(builder.BlobContainerName),
                    nameof(BlobSasBuilder),
                    nameof(BlobContainerName));
            }
            if (!builder.BlobName.Equals(Name, StringComparison.InvariantCulture))
            {
                throw Errors.SasNamesNotMatching(
                    nameof(builder.BlobName),
                    nameof(BlobSasBuilder),
                    nameof(Name));
            }
            if (string.Compare(_snapshot, builder.Snapshot, StringComparison.InvariantCulture) != 0)
            {
                throw Errors.SasNamesNotMatching(
                    nameof(builder.Snapshot),
                    nameof(BlobSasBuilder));
            }
            if (string.Compare(_blobVersionId, builder.BlobVersionId, StringComparison.InvariantCulture) != 0)
            {
                throw Errors.SasNamesNotMatching(
                    nameof(builder.BlobVersionId),
                    nameof(BlobSasBuilder));
            }
            BlobUriBuilder sasUri = new BlobUriBuilder(Uri)
            {
                Query = builder.ToSasQueryParameters(SharedKeyCredential).ToString()
            };
            return sasUri.ToUri();
        }
        #endregion

        #region GetParentBlobContainerClientCore

        private BlobContainerClient _parentBlobContainerClient;

        /// <summary>
        /// Create a new <see cref="BlobContainerClient"/> that pointing to this <see cref="BlobBaseClient"/>'s parent container.
        /// The new <see cref="BlockBlobClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="BlobBaseClient"/>.
        /// </summary>
        /// <returns>A new <see cref="BlobContainerClient"/> instance.</returns>
        protected internal virtual BlobContainerClient GetParentBlobContainerClientCore()
        {
            if (_parentBlobContainerClient == null)
            {
                BlobUriBuilder blobUriBuilder = new BlobUriBuilder(Uri)
                {
                    // erase parameters unrelated to container
                    BlobName = null,
                    VersionId = null,
                    Snapshot = null,
                };

                _parentBlobContainerClient = new BlobContainerClient(
                    blobUriBuilder.ToUri(),
                    Pipeline,
                    SharedKeyCredential,
                    Version,
                    ClientDiagnostics,
                    CustomerProvidedKey,
                    ClientSideEncryption,
                    EncryptionScope);
            }

            return _parentBlobContainerClient;
        }
        #endregion
    }

    /// <summary>
    /// Add easy to discover methods to <see cref="BlobContainerClient"/> for
    /// creating <see cref="BlobBaseClient"/> instances.
    /// </summary>
    public static partial class SpecializedBlobExtensions
    {
        /// <summary>
        /// Create a new <see cref="BlobContainerClient"/> that pointing to this <see cref="BlobBaseClient"/>'s parent container.
        /// The new <see cref="BlockBlobClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="BlobBaseClient"/>.
        /// </summary>
        /// <param name="client">The <see cref="BlobBaseClient"/>.</param>
        /// <returns>A new <see cref="BlobContainerClient"/> instance.</returns>
        public static BlobContainerClient GetParentBlobContainerClient(this BlobBaseClient client)
        {
            return client.GetParentBlobContainerClientCore();
        }

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
            client.GetBlobBaseClientCore(blobName);

        /// <summary>
        /// Creates a new instance of the <see cref="BlobClient"/> class, maintaining all the same
        /// internals but specifying new <see cref="ClientSideEncryptionOptions"/>.
        /// </summary>
        /// <param name="client">Client to base off of.</param>
        /// <param name="clientSideEncryptionOptions">New encryption options. Setting this to <code>default</code> will clear client-side encryption.</param>
        /// <returns>New instance with provided options and same internals otherwise.</returns>
        public static BlobClient WithClientSideEncryptionOptions(this BlobClient client, ClientSideEncryptionOptions clientSideEncryptionOptions)
            => client.WithClientSideEncryptionOptionsCore(clientSideEncryptionOptions);
    }
}
