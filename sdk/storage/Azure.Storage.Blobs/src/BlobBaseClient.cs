// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Common;
using Azure.Storage.Cryptography;
using Azure.Storage.Cryptography.Models;
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
        private protected readonly Uri _uri;

        /// <summary>
        /// Gets the blob's primary <see cref="Uri"/> endpoint.
        /// </summary>
        public virtual Uri Uri => _uri;

        /// <summary>
        /// <see cref="BlobClientConfiguration"/>.
        /// </summary>
        internal readonly BlobClientConfiguration _clientConfiguration;

        /// <summary>
        /// <see cref="BlobClientConfiguration"/>.
        /// </summary>
        internal virtual BlobClientConfiguration ClientConfiguration => _clientConfiguration;

        /// <summary>
        /// The <see cref="ClientSideEncryptionOptions"/> to be used when sending/receiving requests.
        /// </summary>
        private readonly ClientSideEncryptionOptions _clientSideEncryption;

        /// <summary>
        /// The <see cref="ClientSideEncryptionOptions"/> to be used when sending/receiving requests.
        /// </summary>
        internal virtual ClientSideEncryptionOptions ClientSideEncryption => _clientSideEncryption;

        internal virtual bool UsingClientSideEncryption => ClientSideEncryption != default;

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
        /// Determines whether the client is able to generate a SAS.
        /// If the client is authenticated with a <see cref="StorageSharedKeyCredential"/>.
        /// </summary>
        public virtual bool CanGenerateSasUri => ClientConfiguration.SharedKeyCredential != null;

        /// <summary>
        /// BlobRestClient.
        /// </summary>
        private readonly BlobRestClient _blobRestClient;

        /// <summary>
        /// BlobRestClient.
        /// </summary>
        internal virtual BlobRestClient BlobRestClient => _blobRestClient;

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

            _clientConfiguration = new BlobClientConfiguration(
                pipeline: options.Build(conn.Credentials),
                sharedKeyCredential: conn.Credentials as StorageSharedKeyCredential,
                clientDiagnostics: new ClientDiagnostics(options),
                version: options.Version,
                customerProvidedKey: options.CustomerProvidedKey,
                transferValidation: options.TransferValidation,
                encryptionScope: options.EncryptionScope,
                trimBlobNameSlashes: options.TrimBlobNameSlashes);

            _clientSideEncryption = options._clientSideEncryptionOptions?.Clone();
            _blobRestClient = BuildBlobRestClient(_uri);

            BlobErrors.VerifyHttpsCustomerProvidedKey(_uri, _clientConfiguration.CustomerProvidedKey);
            BlobErrors.VerifyCpkAndEncryptionScopeNotBothSet(_clientConfiguration.CustomerProvidedKey, _clientConfiguration.EncryptionScope);
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
            : this(
                  blobUri,
                  (HttpPipelinePolicy)null,
                  options,
                  storageSharedKeyCredential: null,
                  sasCredential: null,
                  tokenCredential: null)
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
            : this(
                  blobUri,
                  credential.AsPolicy(),
                  options,
                  storageSharedKeyCredential: credential,
                  sasCredential: null,
                  tokenCredential: null)
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
            : this(
                  blobUri,
                  credential.AsPolicy<BlobUriBuilder>(blobUri),
                  options,
                  storageSharedKeyCredential: null,
                  sasCredential: credential,
                  tokenCredential: null)
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
            : this(
                blobUri,
                credential.AsPolicy(
                    string.IsNullOrEmpty(options?.Audience?.ToString()) ? BlobAudience.DefaultAudience.CreateDefaultScope() : options.Audience.Value.CreateDefaultScope(),
                    options),
                options,
                storageSharedKeyCredential: null,
                sasCredential: null,
                tokenCredential: credential)
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
        /// <param name="sasCredential">
        /// The SAS credential used to sign requests.
        /// </param>
        /// <param name="tokenCredential">
        /// The token credential used to sign requests.
        /// </param>
        internal BlobBaseClient(
            Uri blobUri,
            HttpPipelinePolicy authentication,
            BlobClientOptions options,
            StorageSharedKeyCredential storageSharedKeyCredential,
            AzureSasCredential sasCredential,
            TokenCredential tokenCredential)
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

            _clientConfiguration = new BlobClientConfiguration(
                pipeline: options.Build(authentication),
                sharedKeyCredential: storageSharedKeyCredential,
                sasCredential: sasCredential,
                tokenCredential: tokenCredential,
                clientDiagnostics: new ClientDiagnostics(options),
                version: options.Version,
                customerProvidedKey: options.CustomerProvidedKey,
                transferValidation: options.TransferValidation,
                encryptionScope: options.EncryptionScope,
                trimBlobNameSlashes: options.TrimBlobNameSlashes);

            _clientSideEncryption = options._clientSideEncryptionOptions?.Clone();
            _blobRestClient = BuildBlobRestClient(blobUri);

            BlobErrors.VerifyHttpsCustomerProvidedKey(_uri, _clientConfiguration.CustomerProvidedKey);
            BlobErrors.VerifyCpkAndEncryptionScopeNotBothSet(_clientConfiguration.CustomerProvidedKey, _clientConfiguration.EncryptionScope);
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
        /// <param name="clientConfiguration">
        /// <see cref="BlobClientConfiguration"/>.
        /// </param>
        /// <param name="clientSideEncryption">
        /// Client-side encryption options.
        /// </param>
        internal BlobBaseClient(
            Uri blobUri,
            BlobClientConfiguration clientConfiguration,
            ClientSideEncryptionOptions clientSideEncryption)
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

            _clientConfiguration = clientConfiguration;
            _clientSideEncryption = clientSideEncryption?.Clone();
            _blobRestClient = BuildBlobRestClient(blobUri);

            BlobErrors.VerifyHttpsCustomerProvidedKey(_uri, _clientConfiguration.CustomerProvidedKey);
            BlobErrors.VerifyCpkAndEncryptionScopeNotBothSet(_clientConfiguration.CustomerProvidedKey, _clientConfiguration.EncryptionScope);
        }

        private BlobRestClient BuildBlobRestClient(Uri blobUri)
        {
            return new BlobRestClient(
                clientDiagnostics: _clientConfiguration.ClientDiagnostics,
                pipeline: _clientConfiguration.Pipeline,
                url: blobUri.AbsoluteUri,
                version: _clientConfiguration.Version.ToVersionString());
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
                ClientConfiguration,
                ClientSideEncryption);
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
                ClientConfiguration,
                ClientSideEncryption);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobBaseClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="customerProvidedKey"/>.
        ///
        /// </summary>
        /// <param name="customerProvidedKey">The customer provided key.</param>
        /// <returns>A new <see cref="BlobBaseClient"/> instance.</returns>
        /// <remarks>
        /// Pass null to remove the customer provide key in the returned <see cref="BlobBaseClient"/>.
        /// </remarks>
        public virtual BlobBaseClient WithCustomerProvidedKey(CustomerProvidedKey? customerProvidedKey) => WithCustomerProvidedKeyCore(customerProvidedKey);

        private protected virtual BlobBaseClient WithCustomerProvidedKeyCore(CustomerProvidedKey? customerProvidedKey)
        {
            BlobClientConfiguration newClientConfiguration = BlobClientConfiguration.DeepCopy(ClientConfiguration);
            newClientConfiguration.CustomerProvidedKey = customerProvidedKey;
            return new BlobBaseClient(
                blobUri: Uri,
                clientConfiguration: newClientConfiguration,
                clientSideEncryption: ClientSideEncryption?.Clone());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobBaseClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="encryptionScope"/>.
        ///
        /// </summary>
        /// <param name="encryptionScope">The encryption scope.</param>
        /// <returns>A new <see cref="BlobBaseClient"/> instance.</returns>
        /// <remarks>
        /// Pass null to remove the encryption scope in the returned <see cref="BlobBaseClient"/>.
        /// </remarks>
        public virtual BlobBaseClient WithEncryptionScope(string encryptionScope) => WithEncryptionScopeCore(encryptionScope);

        private protected virtual BlobBaseClient WithEncryptionScopeCore(string encryptionScope)
        {
            BlobClientConfiguration newClientConfiguration = BlobClientConfiguration.DeepCopy(ClientConfiguration);
            newClientConfiguration.EncryptionScope = encryptionScope;
            return new BlobBaseClient(
                blobUri: Uri,
                clientConfiguration: newClientConfiguration,
                clientSideEncryption: ClientSideEncryption?.Clone());
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
                var builder = new BlobUriBuilder(Uri, ClientConfiguration.TrimBlobNameSlashes);
                _name = builder.BlobName;
                _containerName = builder.BlobContainerName;
                _accountName = builder.AccountName;
            }
        }

        #region internal static accessors for Azure.Storage.DataMovement.Blobs
        /// <summary>
        /// Get a <see cref="BlobBaseClient"/>'s <see cref="HttpAuthorization"/>
        /// for passing the authorization when performing service to service copy
        /// where OAuth is necessary to authenticate the source.
        /// </summary>
        /// <param name="client">
        /// The storage client which to generate the
        /// authorization header off of.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The BlobServiceClient's HttpPipeline.</returns>
        protected static async Task<HttpAuthorization> GetCopyAuthorizationHeaderAsync(
            BlobBaseClient client,
            CancellationToken cancellationToken = default)
        {
            if (client.ClientConfiguration.TokenCredential != default)
            {
                return await client.ClientConfiguration.TokenCredential.GetCopyAuthorizationHeaderAsync(cancellationToken).ConfigureAwait(false);
            }
            return default;
        }
        #endregion internal static accessors for Azure.Storage.DataMovement.Blobs

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
        ///
        /// This API has been deprecated. Consider the following alternatives:
        /// <list type="bullet">
        ///     <item>
        ///         <term>DownloadContent</term>
        ///         <description>as a prefered way of downloading small blobs that can fit into memory</description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadTo</term>
        ///         <description>to stream blob content to a path or a <see cref="Stream"/></description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadStreaming</term>
        ///         <description>as a replacement to this API. Use it to access network stream directly for any advanced scenario.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        ///
        /// This API has been deprecated. Consider the following alternatives:
        /// <list type="bullet">
        ///     <item>
        ///         <term>DownloadContentAsync</term>
        ///         <description>as a prefered way of downloading small blobs that can fit into memory</description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadToAsync</term>
        ///         <description>to stream blob content to a path or a <see cref="Stream"/></description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadStreamingAsync</term>
        ///         <description>as a replacement to this API. Use it to access network stream directly for any advanced scenario.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        ///
        /// This API has been deprecated. Consider the following alternatives:
        /// <list type="bullet">
        ///     <item>
        ///         <term>DownloadContent</term>
        ///         <description>as a prefered way of downloading small blobs that can fit into memory</description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadTo</term>
        ///         <description>to stream blob content to a path or a <see cref="Stream"/></description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadStreaming</term>
        ///         <description>as a replacement to this API. Use it to access network stream directly for any advanced scenario.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        ///
        /// This API has been deprecated. Consider the following alternatives:
        /// <list type="bullet">
        ///     <item>
        ///         <term>DownloadContentAsync</term>
        ///         <description>as a prefered way of downloading small blobs that can fit into memory</description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadToAsync</term>
        ///         <description>to stream blob content to a path or a <see cref="Stream"/></description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadStreamingAsync</term>
        ///         <description>as a replacement to this API. Use it to access network stream directly for any advanced scenario.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        ///
        /// This API has been deprecated. Consider the following alternatives:
        /// <list type="bullet">
        ///     <item>
        ///         <term>DownloadContent</term>
        ///         <description>as a prefered way of downloading small blobs that can fit into memory</description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadTo</term>
        ///         <description>to stream blob content to a path or a <see cref="Stream"/></description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadStreaming</term>
        ///         <description>as a replacement to this API. Use it to access network stream directly for any advanced scenario.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        ///
        /// This API has been deprecated. Consider the following alternatives:
        /// <list type="bullet">
        ///     <item>
        ///         <term>DownloadContentAsync</term>
        ///         <description>as a prefered way of downloading small blobs that can fit into memory</description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadToAsync</term>
        ///         <description>to stream blob content to a path or a <see cref="Stream"/></description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadStreamingAsync</term>
        ///         <description>as a replacement to this API. Use it to access network stream directly for any advanced scenario.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
            Response<BlobDownloadStreamingResult> response = await DownloadStreamingDirect(
                range,
                conditions,
                rangeGetContentHash.ToValidationOptions(),
                progressHandler: default,
                $"{nameof(BlobBaseClient)}.{nameof(Download)}",
                async,
                cancellationToken).ConfigureAwait(false);

            // Return an exploding Response on 304
            if (response.IsUnavailable())
            {
                return response.GetRawResponse().AsNoBodyResponse<BlobDownloadInfo>();
            }

            BlobDownloadStreamingResult blobDownloadStreamingResult = response.Value;
            BlobDownloadDetails blobDownloadDetails = blobDownloadStreamingResult.Details;
            return Response.FromValue(
                new BlobDownloadInfo()
                {
                    Content = blobDownloadStreamingResult.Content,
                    Details = blobDownloadDetails,
                    BlobType = blobDownloadDetails.BlobType,
                    ContentHash = blobDownloadDetails.ContentHash,
                    ContentLength = blobDownloadDetails.ContentLength,
                    ContentType = blobDownloadDetails.ContentType,
                }, response.GetRawResponse());
        }
        #endregion

        #region DownloadStreaming
        /// <summary>
        /// The <see cref="DownloadStreaming(HttpRange, BlobRequestConditions, bool, CancellationToken)"/>
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
        /// A <see cref="Response{BlobDownloadStreamingResult}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadStreamingResult.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        ///
        /// This API gives access directly to network stream that should be disposed after usage.
        /// Consider the following alternatives:
        /// <list type="bullet">
        ///     <item>
        ///         <term>DownloadContent</term>
        ///         <description>as a prefered way of downloading small blobs that can fit into memory</description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadTo</term>
        ///         <description>to stream blob content to a path or a <see cref="Stream"/></description>
        ///     </item>
        /// </list>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<BlobDownloadStreamingResult> DownloadStreaming(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            HttpRange range,
            BlobRequestConditions conditions,
            bool rangeGetContentHash,
            CancellationToken cancellationToken)
        {
            return DownloadStreaming(
                range,
                conditions,
                rangeGetContentHash,
                progressHandler: default,
                cancellationToken);
        }

        /// <summary>
        /// The <see cref="DownloadStreamingAsync(HttpRange, BlobRequestConditions, bool, CancellationToken)"/>
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
        /// A <see cref="Response{BlobDownloadStreamingResult}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadStreamingResult.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        ///
        /// This API gives access directly to network stream that should be disposed after usage.
        /// Consider the following alternatives:
        /// <list type="bullet">
        ///     <item>
        ///         <term>DownloadContentAsync</term>
        ///         <description>as a prefered way of downloading small blobs that can fit into memory</description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadToAsync</term>
        ///         <description>to stream blob content to a path or a <see cref="Stream"/></description>
        ///     </item>
        /// </list>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<BlobDownloadStreamingResult>> DownloadStreamingAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            HttpRange range,
            BlobRequestConditions conditions,
            bool rangeGetContentHash,
            CancellationToken cancellationToken)
        {
            return await DownloadStreamingAsync(
                range,
                conditions,
                rangeGetContentHash,
                progressHandler: default,
                cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// The <see cref="DownloadStreaming(HttpRange, BlobRequestConditions, bool, CancellationToken)"/>
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
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobDownloadStreamingResult}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadStreamingResult.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        ///
        /// This API gives access directly to network stream that should be disposed after usage.
        /// Consider the following alternatives:
        /// <list type="bullet">
        ///     <item>
        ///         <term>DownloadContent</term>
        ///         <description>as a prefered way of downloading small blobs that can fit into memory</description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadTo</term>
        ///         <description>to stream blob content to a path or a <see cref="Stream"/></description>
        ///     </item>
        /// </list>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<BlobDownloadStreamingResult> DownloadStreaming(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            HttpRange range,
            BlobRequestConditions conditions,
            bool rangeGetContentHash,
            IProgress<long> progressHandler,
            CancellationToken cancellationToken)
        {
            return DownloadStreamingDirect(
                range,
                conditions,
                rangeGetContentHash.ToValidationOptions(),
                progressHandler,
                $"{nameof(BlobBaseClient)}.{nameof(DownloadStreaming)}",
                false, // async
                cancellationToken)
                .EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="DownloadStreamingAsync(HttpRange, BlobRequestConditions, bool, CancellationToken)"/>
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
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobDownloadStreamingResult}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadStreamingResult.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        ///
        /// This API gives access directly to network stream that should be disposed after usage.
        /// Consider the following alternatives:
        /// <list type="bullet">
        ///     <item>
        ///         <term>DownloadContentAsync</term>
        ///         <description>as a prefered way of downloading small blobs that can fit into memory</description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadToAsync</term>
        ///         <description>to stream blob content to a path or a <see cref="Stream"/></description>
        ///     </item>
        /// </list>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<BlobDownloadStreamingResult>> DownloadStreamingAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            HttpRange range,
            BlobRequestConditions conditions,
            bool rangeGetContentHash,
            IProgress<long> progressHandler,
            CancellationToken cancellationToken)
        {
            return await DownloadStreamingDirect(
                range,
                conditions,
                rangeGetContentHash.ToValidationOptions(),
                progressHandler,
                $"{nameof(BlobBaseClient)}.{nameof(DownloadStreaming)}",
                true, // async
                cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// The <see cref="DownloadStreaming(BlobDownloadOptions, CancellationToken)"/>
        /// operation downloads a blob from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobDownloadStreamingResult}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadStreamingResult.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        ///
        /// This API gives access directly to network stream that should be disposed after usage.
        /// Consider the following alternatives:
        /// <list type="bullet">
        ///     <item>
        ///         <term>DownloadContentAsync</term>
        ///         <description>as a prefered way of downloading small blobs that can fit into memory</description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadToAsync</term>
        ///         <description>to stream blob content to a path or a <see cref="Stream"/></description>
        ///     </item>
        /// </list>
        /// </remarks>
        public virtual Response<BlobDownloadStreamingResult> DownloadStreaming(
            BlobDownloadOptions options = default,
            CancellationToken cancellationToken = default)
        {
            return DownloadStreamingDirect(
                options?.Range ?? default,
                options?.Conditions,
                options?.TransferValidation,
                options?.ProgressHandler,
                $"{nameof(BlobBaseClient)}.{nameof(DownloadStreaming)}",
                async: false,
                cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="DownloadStreamingAsync(BlobDownloadOptions, CancellationToken)"/>
        /// operation downloads a blob from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="options">Optional parameters.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// A <see cref="Response{BlobDownloadStreamingResult}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadStreamingResult.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        ///
        /// This API gives access directly to network stream that should be disposed after usage.
        /// Consider the following alternatives:
        /// <list type="bullet">
        ///     <item>
        ///         <term>DownloadContentAsync</term>
        ///         <description>as a prefered way of downloading small blobs that can fit into memory</description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadToAsync</term>
        ///         <description>to stream blob content to a path or a <see cref="Stream"/></description>
        ///     </item>
        /// </list>
        /// </remarks>
        public virtual async Task<Response<BlobDownloadStreamingResult>> DownloadStreamingAsync(
            BlobDownloadOptions options = default,
            CancellationToken cancellationToken = default)
        {
            return await DownloadStreamingDirect(
                options?.Range ?? default,
                options?.Conditions,
                options?.TransferValidation,
                options?.ProgressHandler,
                $"{nameof(BlobBaseClient)}.{nameof(DownloadStreaming)}",
                async: true,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Internal advanced download implementations should call into
        /// <see cref="DownloadStreamingInternal"/> instead.
        /// Implementation for public DownloadStreaming/DownloadContent methods to call into.
        /// </summary>
        /// <param name="range"></param>
        /// <param name="conditions"></param>
        /// <param name="transferValidationOverride"></param>
        /// <param name="progressHandler"></param>
        /// <param name="operationName"></param>
        /// <param name="async"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async ValueTask<Response<BlobDownloadStreamingResult>> DownloadStreamingDirect(
            HttpRange range,
            BlobRequestConditions conditions,
            DownloadTransferValidationOptions transferValidationOverride,
            IProgress<long> progressHandler,
            string operationName,
            bool async,
            CancellationToken cancellationToken)
        {
            HttpRange requestedRange = range;
            if (UsingClientSideEncryption)
            {
                if ((await GetPropertiesInternal(conditions, async, new RequestContext() { CancellationToken = cancellationToken }).ConfigureAwait(false)).Value.Metadata.TryGetValue(Constants.ClientSideEncryption.EncryptionDataKey, out string rawEncryptiondata))
                {
                    range = BlobClientSideDecryptor.GetEncryptedBlobRange(range, rawEncryptiondata);
                }
            }

            var response = await DownloadStreamingInternal(range, conditions, transferValidationOverride, progressHandler, operationName, async, cancellationToken).ConfigureAwait(false);

            // if using clientside encryption, wrap the auto-retry stream in a decryptor
            // we already return a nonseekable stream; returning a crypto stream is fine
            if (UsingClientSideEncryption)
            {
                response.Value.Content = await new BlobClientSideDecryptor(
                    new ClientSideDecryptor(ClientSideEncryption)).DecryptInternal(
                        response.Value.Content,
                        response.Value.Details.Metadata,
                        requestedRange,
                        response.Value.Details.ContentRange,
                        async,
                        cancellationToken).ConfigureAwait(false);
            }

            return response;
        }

        /// <summary>
        /// Impl for a ranged download. Issues a single, smart-retriable request for a specified
        /// range of this blob.
        /// </summary>
        /// <param name="range">
        /// Optionally specified range.
        /// </param>
        /// <param name="conditions">
        /// Access conditions.
        /// </param>
        /// <param name="transferValidationOverride">
        /// Override options for transfer validation.
        /// </param>
        /// <param name="progressHandler">
        /// Progress handler.
        /// </param>
        /// <param name="operationName">
        /// operation name of the calling API.
        /// </param>
        /// <param name="async">
        /// Whether to operate asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Cancellation token.
        /// </param>
        /// <returns></returns>
        internal virtual async ValueTask<Response<BlobDownloadStreamingResult>> DownloadStreamingInternal(
            HttpRange range,
            BlobRequestConditions conditions,
            DownloadTransferValidationOptions transferValidationOverride,
            IProgress<long> progressHandler,
            string operationName,
            bool async,
            CancellationToken cancellationToken)
        {
            DownloadTransferValidationOptions validationOptions = transferValidationOverride ?? ClientConfiguration.TransferValidation.Download;
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(nameof(BlobBaseClient), message: $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);

                try
                {
                    scope.Start();

                    using DisposableBucket disposableBucket = new();
                    if (ClientSideEncryption != default)
                    {
                        disposableBucket.Add(Shared.StorageExtensions.CreateClientSideEncryptionScope(ClientSideEncryption.EncryptionVersion));
                    }

                    // Start downloading the blob
                    Response<BlobDownloadStreamingResult> response = await StartDownloadAsync(
                        range,
                        conditions,
                        validationOptions,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    // Return an exploding Response on 304
                    if (response.IsUnavailable())
                    {
                        return response.GetRawResponse().AsNoBodyResponse<BlobDownloadStreamingResult>();
                    }

                    ETag etag = response.Value.Details.ETag;
                    BlobRequestConditions conditionsWithEtag = conditions?.WithIfMatch(etag) ?? new BlobRequestConditions { IfMatch = etag };

                    // Wrap the response Content in a RetriableStream so we
                    // can return it before it's finished downloading, but still
                    // allow retrying if it fails.
                    Stream stream = RetriableStream.Create(
                        response.Value.Content,
                        startOffset =>
                            StartDownloadAsync(
                                    range,
                                    conditionsWithEtag,
                                    validationOptions,
                                    startOffset,
                                    async,
                                    cancellationToken)
                                .EnsureCompleted()
                            .Value.Content,
                        async startOffset =>
                            (await StartDownloadAsync(
                                range,
                                conditionsWithEtag,
                                validationOptions,
                                startOffset,
                                async,
                                cancellationToken)
                                .ConfigureAwait(false))
                            .Value.Content,
                        ClientConfiguration.Pipeline.ResponseClassifier,
                        Constants.MaxReliabilityRetries);

                    stream = stream.WithNoDispose().WithProgress(progressHandler);

                    /* Decryption handled by caller, so safe to check checksum now.
                     * Buffer response stream and ensure it matches the transactional checksum if any.
                     * Storage will not return a checksum for payload >4MB, so this buffer is capped similarly.
                     * Checksum validation is opt-in, so this buffer is part of that opt-in. */
                    if (validationOptions != default && validationOptions.ChecksumAlgorithm != StorageChecksumAlgorithm.None && validationOptions.AutoValidateChecksum)
                    {
                        // safe-buffer; transactional hash download limit well below maxInt
                        var readDestStream = new MemoryStream((int)response.Value.Details.ContentLength);
                        if (async)
                        {
                            await stream.CopyToAsync(readDestStream, 81920, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            stream.CopyTo(readDestStream);
                        }
                        readDestStream.Position = 0;

                        await ContentHasher.AssertResponseHashMatchInternal(
                            readDestStream,
                            validationOptions.ChecksumAlgorithm,
                            response.GetRawResponse(),
                            async,
                            cancellationToken).ConfigureAwait(false);
                        ;

                        // we've consumed the network stream to hash it; return buffered stream to the user
                        stream = readDestStream;
                    }

                    response.Value.Content = stream;
                    return response;
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                    scope.Dispose();
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
        /// <param name="validationOptions">
        /// Options for requesting a checksum.
        /// This method will not check client options for this parameter and
        /// expects defaults to have already been evaluated.
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
        private async ValueTask<Response<BlobDownloadStreamingResult>> StartDownloadAsync(
            HttpRange range,
            BlobRequestConditions conditions,
            DownloadTransferValidationOptions validationOptions,
            long startOffset = 0,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            HttpRange? pageRange = null;
            if (range != default(HttpRange)) // we want to check between non-nullable ranges
            {
                pageRange = new HttpRange(
                    range.Offset + startOffset,
                    range.Length.HasValue ?
                        range.Length.Value - startOffset :
                        (long?)null);
            }
            else if (startOffset != 0)
            {
                pageRange = new HttpRange(startOffset);
            }

            ClientConfiguration.Pipeline.LogTrace($"Download {Uri} with range: {pageRange}");

            ResponseWithHeaders<Stream, BlobDownloadHeaders> response;

            // All BlobRequestConditions are valid.
            conditions.ValidateConditionsNotPresent(
                invalidConditions: BlobRequestConditionProperty.None,
                operationName: nameof(BlobBaseClient.Download),
                parameterName: nameof(conditions));

            if (async)
            {
                response = await BlobRestClient.DownloadAsync(
                    range: pageRange?.ToString(),
                    leaseId: conditions?.LeaseId,
                    rangeGetContentMD5: validationOptions?.ChecksumAlgorithm.ResolveAuto() == StorageChecksumAlgorithm.MD5 ? true : null,
                    rangeGetContentCRC64: validationOptions?.ChecksumAlgorithm.ResolveAuto() == StorageChecksumAlgorithm.StorageCrc64 ? true : null,
                    encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                    encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                    encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                    ifModifiedSince: conditions?.IfModifiedSince,
                    ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                    ifMatch: conditions?.IfMatch?.ToString(),
                    ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                    ifTags: conditions?.TagConditions,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }
            else
            {
                response = BlobRestClient.Download(
                    range: pageRange?.ToString(),
                    leaseId: conditions?.LeaseId,
                    rangeGetContentMD5: validationOptions?.ChecksumAlgorithm.ResolveAuto() == StorageChecksumAlgorithm.MD5 ? true : null,
                    rangeGetContentCRC64: validationOptions?.ChecksumAlgorithm.ResolveAuto() == StorageChecksumAlgorithm.StorageCrc64 ? true : null,
                    encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                    encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                    encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                    ifModifiedSince: conditions?.IfModifiedSince,
                    ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                    ifMatch: conditions?.IfMatch?.ToString(),
                    ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                    ifTags: conditions?.TagConditions,
                    cancellationToken: cancellationToken);
            }

            // Watch out for exploding Responses
            long length = response.IsUnavailable() ? 0 : response.Headers.ContentLength ?? 0;
            ClientConfiguration.Pipeline.LogTrace($"Response: {response.GetRawResponse().Status}, ContentLength: {length}");

            return Response.FromValue(
                response.ToBlobDownloadStreamingResult(),
                response.GetRawResponse());
        }
        #endregion

        #region DownloadContent
        /// <summary>
        /// The <see cref="DownloadContent()"/> operation downloads a blob from
        /// the service, including its metadata and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <returns>
        /// A <see cref="Response{BlobDownloadResult}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadResult.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        ///
        /// This API is a prefered way to fetch blobs that can fit into memory.
        /// The content is provided as <see cref="BinaryData"/> that provides a lightweight abstraction for a payload of bytes.
        /// It provides convenient helper methods to get out commonly used primitives, such as streams, strings, or bytes.
        /// Consider the following alternatives:
        /// <list type="bullet">
        ///     <item>
        ///         <term>DownloadTo</term>
        ///         <description>to stream blob content to a path or a <see cref="Stream"/></description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadStreaming</term>
        ///         <description>as a replacement to this API. Use it to access network stream directly for any advanced scenario.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        public virtual Response<BlobDownloadResult> DownloadContent() =>
            DownloadContent(CancellationToken.None);

        /// <summary>
        /// The <see cref="DownloadContentAsync()"/> operation downloads a blob from
        /// the service, including its metadata and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <returns>
        /// A <see cref="Response{BlobDownloadResult}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadResult.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        ///
        /// This API is a prefered way to fetch blobs that can fit into memory.
        /// The content is provided as <see cref="BinaryData"/> that provides a lightweight abstraction for a payload of bytes.
        /// It provides convenient helper methods to get out commonly used primitives, such as streams, strings, or bytes.
        /// Consider the following alternatives:
        /// <list type="bullet">
        ///     <item>
        ///         <term>DownloadToAsync</term>
        ///         <description>to stream blob content to a path or a <see cref="Stream"/></description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadStreamingAsync</term>
        ///         <description>as a replacement to this API. Use it to access network stream directly for any advanced scenario.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        public virtual async Task<Response<BlobDownloadResult>> DownloadContentAsync() =>
            await DownloadContentAsync(CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DownloadContent(CancellationToken)"/> operation downloads
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
        /// A <see cref="Response{BlobDownloadResult}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadResult.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        ///
        /// This API is a prefered way to fetch blobs that can fit into memory.
        /// The content is provided as <see cref="BinaryData"/> that provides a lightweight abstraction for a payload of bytes.
        /// It provides convenient helper methods to get out commonly used primitives, such as streams, strings, or bytes.
        /// Consider the following alternatives:
        /// <list type="bullet">
        ///     <item>
        ///         <term>DownloadTo</term>
        ///         <description>to stream blob content to a path or a <see cref="Stream"/></description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadStreaming</term>
        ///         <description>as a replacement to this API. Use it to access network stream directly for any advanced scenario.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        public virtual Response<BlobDownloadResult> DownloadContent(
            CancellationToken cancellationToken = default) =>
            DownloadContent(
                conditions: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="DownloadContentAsync(CancellationToken)"/> operation
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
        /// A <see cref="Response{BlobDownloadResult}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadResult.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        ///
        /// This API is a prefered way to fetch blobs that can fit into memory.
        /// The content is provided as <see cref="BinaryData"/> that provides a lightweight abstraction for a payload of bytes.
        /// It provides convenient helper methods to get out commonly used primitives, such as streams, strings, or bytes.
        /// Consider the following alternatives:
        /// <list type="bullet">
        ///     <item>
        ///         <term>DownloadToAsync</term>
        ///         <description>to stream blob content to a path or a <see cref="Stream"/></description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadStreamingAsync</term>
        ///         <description>as a replacement to this API. Use it to access network stream directly for any advanced scenario.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        public virtual async Task<Response<BlobDownloadResult>> DownloadContentAsync(
            CancellationToken cancellationToken) =>
            await DownloadContentAsync(
                conditions: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DownloadContent(BlobRequestConditions, CancellationToken)"/>
        /// operation downloads a blob from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// downloading this blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobDownloadResult}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadResult.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        ///
        /// This API is a prefered way to fetch blobs that can fit into memory.
        /// The content is provided as <see cref="BinaryData"/> that provides a lightweight abstraction for a payload of bytes.
        /// It provides convenient helper methods to get out commonly used primitives, such as streams, strings, or bytes.
        /// Consider the following alternatives:
        /// <list type="bullet">
        ///     <item>
        ///         <term>DownloadTo</term>
        ///         <description>to stream blob content to a path or a <see cref="Stream"/></description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadStreaming</term>
        ///         <description>as a replacement to this API. Use it to access network stream directly for any advanced scenario.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<BlobDownloadResult> DownloadContent(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            BlobRequestConditions conditions,
            CancellationToken cancellationToken) =>
            DownloadContentInternal(
                conditions,
                progressHandler: default,
                range: default,
                transferValidationOverride: default,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="DownloadContentAsync(BlobRequestConditions, CancellationToken)"/>
        /// operation downloads a blob from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// downloading this blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobDownloadResult}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadResult.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        ///
        /// This API is a prefered way to fetch blobs that can fit into memory.
        /// The content is provided as <see cref="BinaryData"/> that provides a lightweight abstraction for a payload of bytes.
        /// It provides convenient helper methods to get out commonly used primitives, such as streams, strings, or bytes.
        /// Consider the following alternatives:
        /// <list type="bullet">
        ///     <item>
        ///         <term>DownloadToAsync</term>
        ///         <description>to stream blob content to a path or a <see cref="Stream"/></description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadStreamingAsync</term>
        ///         <description>as a replacement to this API. Use it to access network stream directly for any advanced scenario.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<BlobDownloadResult>> DownloadContentAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            BlobRequestConditions conditions,
            CancellationToken cancellationToken) =>
            await DownloadContentInternal(
                conditions,
                progressHandler: default,
                range: default,
                transferValidationOverride: default,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DownloadContent(BlobRequestConditions, IProgress{long}, HttpRange, CancellationToken)"/>
        /// operation downloads a blob from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// downloading this blob.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="range">
        /// Optional range of the blob to download.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobDownloadResult}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadResult.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        ///
        /// This API is a prefered way to fetch blobs that can fit into memory.
        /// The content is provided as <see cref="BinaryData"/> that provides a lightweight abstraction for a payload of bytes.
        /// It provides convenient helper methods to get out commonly used primitives, such as streams, strings, or bytes.
        /// Consider the following alternatives:
        /// <list type="bullet">
        ///     <item>
        ///         <term>DownloadTo</term>
        ///         <description>to stream blob content to a path or a <see cref="Stream"/></description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadStreaming</term>
        ///         <description>as a replacement to this API. Use it to access network stream directly for any advanced scenario.</description>
        ///     </item>
        /// </list>
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BlobDownloadResult> DownloadContent(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            BlobRequestConditions conditions,
            IProgress<long> progressHandler,
            HttpRange range,
            CancellationToken cancellationToken) =>
            DownloadContentInternal(
                conditions,
                progressHandler,
                range,
                transferValidationOverride: default,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="DownloadContentAsync(BlobRequestConditions, IProgress{long}, HttpRange, CancellationToken)"/>
        /// operation downloads a blob from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// downloading this blob.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="range">
        /// Optional range of the blob to download.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobDownloadResult}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadResult.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        ///
        /// This API is a prefered way to fetch blobs that can fit into memory.
        /// The content is provided as <see cref="BinaryData"/> that provides a lightweight abstraction for a payload of bytes.
        /// It provides convenient helper methods to get out commonly used primitives, such as streams, strings, or bytes.
        /// Consider the following alternatives:
        /// <list type="bullet">
        ///     <item>
        ///         <term>DownloadToAsync</term>
        ///         <description>to stream blob content to a path or a <see cref="Stream"/></description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadStreamingAsync</term>
        ///         <description>as a replacement to this API. Use it to access network stream directly for any advanced scenario.</description>
        ///     </item>
        /// </list>
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BlobDownloadResult>> DownloadContentAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            BlobRequestConditions conditions,
            IProgress<long> progressHandler,
            HttpRange range,
            CancellationToken cancellationToken) =>
            await DownloadContentInternal(
                conditions,
                progressHandler,
                range,
                transferValidationOverride: default,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DownloadContent(BlobDownloadOptions, CancellationToken)"/>
        /// operation downloads a blob from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters for download operation.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobDownloadResult}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadResult.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        ///
        /// This API is a prefered way to fetch blobs that can fit into memory.
        /// The content is provided as <see cref="BinaryData"/> that provides a lightweight abstraction for a payload of bytes.
        /// It provides convenient helper methods to get out commonly used primitives, such as streams, strings, or bytes.
        /// Consider the following alternatives:
        /// <list type="bullet">
        ///     <item>
        ///         <term>DownloadToAsync</term>
        ///         <description>to stream blob content to a path or a <see cref="Stream"/></description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadStreamingAsync</term>
        ///         <description>as a replacement to this API. Use it to access network stream directly for any advanced scenario.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        public virtual Response<BlobDownloadResult> DownloadContent(
            BlobDownloadOptions options = default,
            CancellationToken cancellationToken = default) =>
            DownloadContentInternal(
                options?.Conditions,
                options?.ProgressHandler,
                options?.Range ?? default,
                options?.TransferValidation,
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// The <see cref="DownloadContentAsync(BlobDownloadOptions, CancellationToken)"/>
        /// operation downloads a blob from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters for download operation.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobDownloadResult}"/> describing the
        /// downloaded blob.  <see cref="BlobDownloadResult.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        ///
        /// This API is a prefered way to fetch blobs that can fit into memory.
        /// The content is provided as <see cref="BinaryData"/> that provides a lightweight abstraction for a payload of bytes.
        /// It provides convenient helper methods to get out commonly used primitives, such as streams, strings, or bytes.
        /// Consider the following alternatives:
        /// <list type="bullet">
        ///     <item>
        ///         <term>DownloadToAsync</term>
        ///         <description>to stream blob content to a path or a <see cref="Stream"/></description>
        ///     </item>
        ///     <item>
        ///         <term>DownloadStreamingAsync</term>
        ///         <description>as a replacement to this API. Use it to access network stream directly for any advanced scenario.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        public virtual async Task<Response<BlobDownloadResult>> DownloadContentAsync(
            BlobDownloadOptions options = default,
            CancellationToken cancellationToken = default) =>
            await DownloadContentInternal(
                options?.Conditions,
                options?.ProgressHandler,
                options?.Range ?? default,
                options?.TransferValidation,
                async: true,
                cancellationToken).ConfigureAwait(false);

        private async Task<Response<BlobDownloadResult>> DownloadContentInternal(
            BlobRequestConditions conditions,
            IProgress<long> progressHandler,
            HttpRange range,
            DownloadTransferValidationOptions transferValidationOverride,
            bool async,
            CancellationToken cancellationToken)
        {
            Response<BlobDownloadStreamingResult> response = await DownloadStreamingDirect(
                range,
                conditions,
                transferValidationOverride: transferValidationOverride,
                progressHandler,
                $"{nameof(BlobBaseClient)}.{nameof(DownloadContent)}",
                async: async,
                cancellationToken: cancellationToken).ConfigureAwait(false);

            // Return an exploding Response on 304
            if (response.IsUnavailable())
            {
                return response.GetRawResponse().AsNoBodyResponse<BlobDownloadResult>();
            }

            using BlobDownloadStreamingResult blobDownloadStreamingResult = response.Value;
            BinaryData data;
            if (async)
            {
                data = await BinaryData.FromStreamAsync(blobDownloadStreamingResult.Content, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                data = BinaryData.FromStream(blobDownloadStreamingResult.Content);
            }
            return Response.FromValue(
                new BlobDownloadResult()
                {
                    Content = data,
                    Details = blobDownloadStreamingResult.Details,
                }, response.GetRawResponse());
        }
        #endregion

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
        /// The <see cref="DownloadTo(string, BlobRequestConditions, StorageTransferOptions, CancellationToken)"/>
        /// operation downloads a blob using parallel requests,
        /// and writes the content to <paramref name="options.Path"/> or <paramref name="options.Stream"/>.
        /// </summary>
        /// <param name="destination">
        /// Stream to write download content to.
        /// </param>
        /// <param name="options">
        /// Parameters for download.
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
            BlobDownloadToOptions options,
            CancellationToken cancellationToken = default)
        {
            return StagedDownloadAsync(
                destination,
                options?.Conditions,
                options?.ProgressHandler,
                options?.TransferOptions ?? default,
                options?.TransferValidation,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="DownloadTo(string, BlobRequestConditions, StorageTransferOptions, CancellationToken)"/>
        /// operation downloads a blob using parallel requests,
        /// and writes the content to <paramref name="options.Path"/> or <paramref name="options.Stream"/>.
        /// </summary>
        /// <param name="path">
        /// File path to write download content to.
        /// </param>
        /// <param name="options">
        /// Parameters for download.
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
            BlobDownloadToOptions options,
            CancellationToken cancellationToken = default)
        {
            using Stream destination = File.Create(path);
            return StagedDownloadAsync(
                destination,
                options?.Conditions,
                options?.ProgressHandler,
                options?.TransferOptions ?? default,
                options?.TransferValidation,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="DownloadToAsync(Stream, BlobRequestConditions, StorageTransferOptions, CancellationToken)"/>
        /// operation downloads a blob using parallel requests,
        /// and writes the content to <paramref name="options.Path"/> or <paramref name="options.Stream"/>.
        /// </summary>
        /// <param name="destination">
        /// Stream to write download content to.
        /// </param>
        /// <param name="options">
        /// Parameters for download.
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
            BlobDownloadToOptions options,
            CancellationToken cancellationToken = default)
        {
            return await StagedDownloadAsync(
                destination,
                options?.Conditions,
                options?.ProgressHandler,
                options?.TransferOptions ?? default,
                options?.TransferValidation,
                async: true,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// The <see cref="DownloadToAsync(Stream, BlobRequestConditions, StorageTransferOptions, CancellationToken)"/>
        /// operation downloads a blob using parallel requests,
        /// and writes the content to <paramref name="options.Path"/> or <paramref name="options.Stream"/>.
        /// </summary>
        /// <param name="path">
        /// File path to write download content to.
        /// </param>
        /// <param name="options">
        /// Parameters for download.
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
            BlobDownloadToOptions options,
            CancellationToken cancellationToken = default)
        {
            using Stream destination = File.Create(path);
            return await StagedDownloadAsync(
                destination,
                options?.Conditions,
                options?.ProgressHandler,
                options?.TransferOptions ?? default,
                options?.TransferValidation,
                async: true,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
        }

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
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="transferOptions">
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="transferValidationOverride">
        /// Override for client options on transfer validation.
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
            IProgress<long> progressHandler = default,
            StorageTransferOptions transferOptions = default,
            DownloadTransferValidationOptions transferValidationOverride = default,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            DownloadTransferValidationOptions validationOptions = transferValidationOverride ?? ClientConfiguration.TransferValidation.Download;

            PartitionedDownloader downloader = new PartitionedDownloader(this, transferOptions, validationOptions, progressHandler);

            if (UsingClientSideEncryption)
            {
                ClientSideDecryptor.BeginContentEncryptionKeyCaching();
            }
            return await downloader.DownloadToInternal(destination, conditions, async, cancellationToken).ConfigureAwait(false);
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
                allowModifications: options?.AllowModifications ?? false,
                transferValidationOverride: options?.TransferValidation,
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
                options?.Position ?? 0,
                options?.BufferSize,
                options?.Conditions,
                allowModifications: options?.AllowModifications ?? false,
                transferValidationOverride: options?.TransferValidation,
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
                allowModifications: false,
                transferValidationOverride: default,
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
                allowModifications: false,
                transferValidationOverride: default,
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
        /// <param name="allowModifications">
        /// Whether to allow modifications during the read.
        /// </param>
        /// <param name="transferValidationOverride">
        /// Optional override for settings in the client options.
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
            bool allowModifications,
            DownloadTransferValidationOptions transferValidationOverride,
#pragma warning disable CA1801
            bool async,
            CancellationToken cancellationToken)
#pragma warning restore CA1801
        {
            DownloadTransferValidationOptions validationOptions = transferValidationOverride ?? _clientConfiguration.TransferValidation.Download;

            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                nameof(BlobBaseClient),
                message:
                $"{nameof(position)}: {position}\n" +
                $"{nameof(bufferSize)}: {bufferSize}\n" +
                $"{nameof(conditions)}: {conditions}");

                string operationName = $"{nameof(BlobBaseClient)}.{nameof(OpenRead)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);
                try
                {
                    scope.Start();

                    // This also makes sure that we fail fast if file doesn't exist.
                    Response<BlobProperties> blobProperties = await GetPropertiesInternal(
                        conditions: conditions,
                        async,
                        new RequestContext() { CancellationToken = cancellationToken }).ConfigureAwait(false);

                    ETag etag = blobProperties.Value.ETag;
                    var readConditions = conditions;
                    if (!allowModifications)
                    {
                        readConditions = readConditions?.WithIfMatch(etag) ?? new BlobRequestConditions { IfMatch = etag };
                    }

                    long blobContentLength = blobProperties.Value.ContentLength;
                    ClientSideDecryptor.ContentEncryptionKeyCache contentEncryptionKeyCache = default;
                    EncryptionData encryptionData = null;
                    if (UsingClientSideEncryption && !allowModifications)
                    {
                        contentEncryptionKeyCache = new();
                        encryptionData = BlobClientSideDecryptor.GetAndValidateEncryptionDataOrDefault(blobProperties?.Value?.Metadata);
                    }

                    LazyLoadingReadOnlyStream<BlobProperties>.PredictEncryptedRangeAdjustment rangeAdjustmentFunc = UsingClientSideEncryption
                        ? r => BlobClientSideDecryptor.GetEncryptedBlobRange(r, encryptionData)
                        : LazyLoadingReadOnlyStream<BlobProperties>.NoRangeAdjustment;
                    return new LazyLoadingReadOnlyStream<BlobProperties>(
                        async (HttpRange range,
                        DownloadTransferValidationOptions downloadValidationOptions,
                        bool async,
                        CancellationToken cancellationToken) =>
                        {
                            HttpRange requestedRange = range;
                            if (UsingClientSideEncryption)
                            {
                                ClientSideDecryptor.BeginContentEncryptionKeyCaching(contentEncryptionKeyCache);
                                range = rangeAdjustmentFunc(requestedRange);
                            }
                            Response<BlobDownloadStreamingResult> response = await DownloadStreamingInternal(
                                range,
                                readConditions,
                                transferValidationOverride: downloadValidationOptions,
                                progressHandler: default,
                                operationName,
                                async,
                                cancellationToken).ConfigureAwait(false);

                            if (UsingClientSideEncryption)
                            {
                                response.Value.Content = await new BlobClientSideDecryptor(
                                    new ClientSideDecryptor(ClientSideEncryption)).DecryptInternal(
                                        response.Value.Content,
                                        response.Value.Details.Metadata,
                                        requestedRange,
                                        response.Value.Details.ContentRange,
                                        async,
                                        cancellationToken).ConfigureAwait(false);
                            }

                            return Response.FromValue(
                                (IDownloadedContent)response.Value,
                                response.GetRawResponse());
                        },
                        async (bool async, CancellationToken cancellationToken)
                            => await GetPropertiesInternal(
                                conditions: default,
                                async,
                                new RequestContext() { CancellationToken = cancellationToken }).ConfigureAwait(false),
                        validationOptions,
                        allowModifications,
                        blobContentLength,
                        position,
                        bufferSize,
                        rangeAdjustmentFunc);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    ClientConfiguration.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    scope.Dispose();
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobContainerClient));
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
        /// Optional parameters.  Note that <see cref="BlobCopyFromUriOptions.CopySourceTagsMode"/> is not applicable to this API.
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
                options?.DestinationImmutabilityPolicy,
                options?.LegalHold,
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
                destinationImmutabilityPolicy: default,
                legalHold: default,
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
        /// Optional parameters.  Note that <see cref="BlobCopyFromUriOptions.CopySourceTagsMode"/> is not applicable to this API.
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
                options?.DestinationImmutabilityPolicy,
                options?.LegalHold,
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
                destinationImmutabilityPolicy: default,
                legalHold: default,
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
        /// <param name="destinationImmutabilityPolicy">
        /// Optional <see cref="BlobImmutabilityPolicy"/> to set on the blob.
        /// Note that is parameter is only applicable to a blob within a container that
        /// has immutable storage with versioning enabled.
        /// </param>
        /// <param name="legalHold">
        /// Optional.  Indicates if a legal hold should be placed on the blob.
        /// Note that is parameter is only applicable to a blob within a container that
        /// has immutable storage with versioning enabled.
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
            BlobImmutabilityPolicy destinationImmutabilityPolicy,
            bool? legalHold,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(source)}: {source}\n" +
                    $"{nameof(sourceConditions)}: {sourceConditions}\n" +
                    $"{nameof(destinationConditions)}: {destinationConditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobBaseClient)}.{nameof(StartCopyFromUri)}");

                // All BlobRequestConditions are valid.
                destinationConditions.ValidateConditionsNotPresent(
                    invalidConditions: BlobRequestConditionProperty.None,
                    operationName: nameof(BlobBaseClient.StartCopyFromUri),
                    parameterName: nameof(destinationConditions));

                sourceConditions.ValidateConditionsNotPresent(
                    invalidConditions:
                        BlobRequestConditionProperty.LeaseId,
                    operationName: nameof(BlobBaseClient.StartCopyFromUri),
                    parameterName: nameof(sourceConditions));

                try
                {
                    scope.Start();
                    ResponseWithHeaders<BlobStartCopyFromURLHeaders> response;

                    if (async)
                    {
                        response = await BlobRestClient.StartCopyFromURLAsync(
                            copySource: source.AbsoluteUri,
                            metadata: metadata,
                            tier: accessTier,
                            rehydratePriority: rehydratePriority,
                            sourceIfModifiedSince: sourceConditions?.IfModifiedSince,
                            sourceIfUnmodifiedSince: sourceConditions?.IfUnmodifiedSince,
                            sourceIfMatch: sourceConditions?.IfMatch?.ToString(),
                            sourceIfNoneMatch: sourceConditions?.IfNoneMatch?.ToString(),
                            sourceIfTags: sourceConditions?.TagConditions,
                            ifModifiedSince: destinationConditions?.IfModifiedSince,
                            ifUnmodifiedSince: destinationConditions?.IfUnmodifiedSince,
                            ifMatch: destinationConditions?.IfMatch?.ToString(),
                            ifNoneMatch: destinationConditions?.IfNoneMatch?.ToString(),
                            leaseId: destinationConditions?.LeaseId,
                            ifTags: destinationConditions?.TagConditions,
                            blobTagsString: tags?.ToTagsString(),
                            sealBlob: sealBlob,
                            immutabilityPolicyExpiry: destinationImmutabilityPolicy?.ExpiresOn,
                            immutabilityPolicyMode: destinationImmutabilityPolicy?.PolicyMode,
                            legalHold: legalHold,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = BlobRestClient.StartCopyFromURL(
                            copySource: source.AbsoluteUri,
                            metadata: metadata,
                            tier: accessTier,
                            rehydratePriority: rehydratePriority,
                            sourceIfModifiedSince: sourceConditions?.IfModifiedSince,
                            sourceIfUnmodifiedSince: sourceConditions?.IfUnmodifiedSince,
                            sourceIfMatch: sourceConditions?.IfMatch?.ToString(),
                            sourceIfNoneMatch: sourceConditions?.IfNoneMatch?.ToString(),
                            sourceIfTags: sourceConditions?.TagConditions,
                            ifModifiedSince: destinationConditions?.IfModifiedSince,
                            ifUnmodifiedSince: destinationConditions?.IfUnmodifiedSince,
                            ifMatch: destinationConditions?.IfMatch?.ToString(),
                            ifNoneMatch: destinationConditions?.IfNoneMatch?.ToString(),
                            leaseId: destinationConditions?.LeaseId,
                            ifTags: destinationConditions?.TagConditions,
                            blobTagsString: tags?.ToTagsString(),
                            sealBlob: sealBlob,
                            immutabilityPolicyExpiry: destinationImmutabilityPolicy?.ExpiresOn,
                            immutabilityPolicyMode: destinationImmutabilityPolicy?.PolicyMode,
                            legalHold: legalHold,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToBlobCopyInfo(),
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                    scope.Dispose();
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
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(copyId)}: {copyId}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobBaseClient)}.{nameof(AbortCopyFromUri)}");

                conditions.ValidateConditionsNotPresent(
                    invalidConditions:
                        BlobRequestConditionProperty.IfModifiedSince
                        | BlobRequestConditionProperty.IfUnmodifiedSince
                        | BlobRequestConditionProperty.IfMatch
                        | BlobRequestConditionProperty.IfNoneMatch
                        | BlobRequestConditionProperty.TagConditions,
                    operationName: nameof(BlobBaseClient.AbortCopyFromUri),
                    parameterName: nameof(conditions));

                try
                {
                    scope.Start();
                    ResponseWithHeaders<BlobAbortCopyFromURLHeaders> response;

                    if (async)
                    {
                        response = await BlobRestClient.AbortCopyFromURLAsync(
                            copyId: copyId,
                            leaseId: conditions?.LeaseId,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = BlobRestClient.AbortCopyFromURL(
                            copyId: copyId,
                            leaseId: conditions?.LeaseId,
                            cancellationToken: cancellationToken);
                    }

                    return response.GetRawResponse();
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                    scope.Dispose();
                }
            }
        }
        #endregion AbortCopyFromUri

        #region CopyFromUri
        /// <summary>
        /// The Copy Blob From URL operation copies a blob to a destination within the storage account synchronously
        /// for source blob sizes up to 256 MiB. This API is available starting in version 2018-03-28.
        /// The source for a Copy Blob From URL operation can be any committed block blob in any Azure storage account
        /// which is either public or authorized with a shared access signature.
        ///
        /// The size of the source blob can be a maximum length of up to 256 MiB.
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
        /// source blob is greater than 256 MiB, the request will fail with 409 (Conflict). The blob type of
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
                destinationImmutabilityPolicy: options?.DestinationImmutabilityPolicy,
                legalHold: options?.LegalHold,
                sourceAuthentication: options?.SourceAuthentication,
                copySourceTags: options?.CopySourceTagsMode,
                async: false,
                cancellationToken: cancellationToken)
            .EnsureCompleted();

        /// <summary>
        /// The Copy Blob From URL operation copies a blob to a destination within the storage account synchronously
        /// for source blob sizes up to 256 MiB. This API is available starting in version 2018-03-28.
        /// The source for a Copy Blob From URL operation can be any committed block blob in any Azure storage account
        /// which is either public or authorized with a shared access signature.
        ///
        /// The size of the source blob can be a maximum length of up to 256 MiB.
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
        /// source blob is greater than 256 MiB, the request will fail with 409 (Conflict). The blob type of
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
                destinationImmutabilityPolicy: options?.DestinationImmutabilityPolicy,
                legalHold: options?.LegalHold,
                sourceAuthentication: options?.SourceAuthentication,
                copySourceTags: options?.CopySourceTagsMode,
                async: true,
                cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// The Copy Blob From URL operation copies a blob to a destination within the storage account synchronously
        /// for source blob sizes up to 256 MiB. This API is available starting in version 2018-03-28.
        /// The source for a Copy Blob From URL operation can be any committed block blob in any Azure storage account
        /// which is either public or authorized with a shared access signature.
        ///
        /// The size of the source blob can be a maximum length of up to 256 MiB.
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
        /// source blob is greater than 256 MiB, the request will fail with 409 (Conflict). The blob type of
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
        /// <param name="destinationImmutabilityPolicy">
        /// Optional <see cref="BlobImmutabilityPolicy"/> to set on the blob.
        /// Note that is parameter is only applicable to a blob within a container that
        /// hasimmutable storage with versioning enabled.
        /// </param>
        /// <param name="legalHold">
        /// Optional.  Indicates if a legal hold should be placed on the blob.
        /// Note that is parameter is only applicable to a blob within a container that
        /// has immutable storage with versioning enabled.
        /// </param>
        /// <param name="sourceAuthentication">
        /// Optional. Source authentication used to access the source blob.
        /// </param>
        /// <param name="copySourceTags">
        /// Optional.  Indicates if the source blob's tags should be copied to the destination blob,
        /// or replaced on the destination blob with the tags specified by <see cref="Tags"/>.
        /// Default is to replace.
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
            BlobImmutabilityPolicy destinationImmutabilityPolicy,
            bool? legalHold,
            HttpAuthorization sourceAuthentication,
            BlobCopySourceTagsMode? copySourceTags,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobBaseClient)}.{nameof(SyncCopyFromUri)}");

                // All BlobRequestConditions are valid for destinationConditions.
                destinationConditions.ValidateConditionsNotPresent(
                    invalidConditions: BlobRequestConditionProperty.None,
                    operationName: nameof(BlobBaseClient.SyncCopyFromUri),
                    parameterName: nameof(destinationConditions));

                sourceConditions.ValidateConditionsNotPresent(
                    invalidConditions: BlobRequestConditionProperty.LeaseId,
                    operationName: nameof(BlobBaseClient.SyncCopyFromUri),
                    parameterName: nameof(sourceConditions));

                try
                {
                    ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(source)}: {source}\n" +
                    $"{nameof(sourceConditions)}: {sourceConditions}\n" +
                    $"{nameof(destinationConditions)}: {destinationConditions}");

                    scope.Start();

                    ResponseWithHeaders<BlobCopyFromURLHeaders> response;

                    if (async)
                    {
                        response = await BlobRestClient.CopyFromURLAsync(
                            copySource: source.AbsoluteUri,
                            metadata: metadata,
                            tier: accessTier,
                            sourceIfModifiedSince: sourceConditions?.IfModifiedSince,
                            sourceIfUnmodifiedSince: sourceConditions?.IfUnmodifiedSince,
                            sourceIfMatch: sourceConditions?.IfMatch.ToString(),
                            sourceIfNoneMatch: sourceConditions?.IfNoneMatch.ToString(),
                            ifModifiedSince: destinationConditions?.IfModifiedSince,
                            ifUnmodifiedSince: destinationConditions?.IfUnmodifiedSince,
                            ifMatch: destinationConditions?.IfMatch?.ToString(),
                            ifNoneMatch: destinationConditions?.IfNoneMatch?.ToString(),
                            ifTags: destinationConditions?.TagConditions,
                            leaseId: destinationConditions?.LeaseId,
                            blobTagsString: tags?.ToTagsString(),
                            immutabilityPolicyExpiry: destinationImmutabilityPolicy?.ExpiresOn,
                            immutabilityPolicyMode: destinationImmutabilityPolicy?.PolicyMode,
                            legalHold: legalHold,
                            copySourceAuthorization: sourceAuthentication?.ToString(),
                            encryptionScope: ClientConfiguration.EncryptionScope,
                            copySourceTags: copySourceTags,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = BlobRestClient.CopyFromURL(
                            copySource: source.AbsoluteUri,
                            metadata: metadata,
                            tier: accessTier,
                            sourceIfModifiedSince: sourceConditions?.IfModifiedSince,
                            sourceIfUnmodifiedSince: sourceConditions?.IfUnmodifiedSince,
                            sourceIfMatch: sourceConditions?.IfMatch.ToString(),
                            sourceIfNoneMatch: sourceConditions?.IfNoneMatch.ToString(),
                            ifModifiedSince: destinationConditions?.IfModifiedSince,
                            ifUnmodifiedSince: destinationConditions?.IfUnmodifiedSince,
                            ifMatch: destinationConditions?.IfMatch?.ToString(),
                            ifNoneMatch: destinationConditions?.IfNoneMatch?.ToString(),
                            ifTags: destinationConditions?.TagConditions,
                            leaseId: destinationConditions?.LeaseId,
                            blobTagsString: tags?.ToTagsString(),
                            immutabilityPolicyExpiry: destinationImmutabilityPolicy?.ExpiresOn,
                            immutabilityPolicyMode: destinationImmutabilityPolicy?.PolicyMode,
                            legalHold: legalHold,
                            copySourceAuthorization: sourceAuthentication?.ToString(),
                            encryptionScope: ClientConfiguration.EncryptionScope,
                            copySourceTags: copySourceTags,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToBlobCopyInfo(),
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                    scope.Dispose();
                }
            }
        }
        #endregion CopyFromUri

        #region Delete
        /// <summary>
        /// The <see cref="Delete"/> operation marks the specified blob
        /// or snapshot for  deletion. The blob is later deleted during
        /// garbage collection which could take several minutes.
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
        /// A <see cref="Response"/> on successfully marking for deletion.
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
        /// garbage collection which could take several minutes.
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
        /// A <see cref="Response"/> on successfully marking for deletion.
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
        /// during garbage collection which could take several minutes.
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
        /// marked for deletion, return false otherwise.
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
        /// during garbage collection which could take several minutes.
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
        /// marked for deletion, return false otherwise.
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
        /// during garbage collection which could take several minutes.
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
        /// A <see cref="Response"/> on successfully marking for deletion.
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
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(snapshotsOption)}: {snapshotsOption}\n" +
                    $"{nameof(conditions)}: {conditions}");

                string operationName = $"{nameof(BlobBaseClient)}.{nameof(DeleteIfExists)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);

                try
                {
                    Response response = await DeleteInternal(
                        snapshotsOption,
                        conditions,
                        async,
                        cancellationToken,
                        operationName)
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
                    ClientConfiguration.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="DeleteInternal"/> operation marks the specified blob
        /// or snapshot for  deletion. The blob is later deleted during
        /// garbage collection which could take several minutes.
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
        /// A <see cref="Response"/> on successfully marking for deletion.
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
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(snapshotsOption)}: {snapshotsOption}\n" +
                    $"{nameof(conditions)}: {conditions}");

                operationName ??= $"{nameof(BlobBaseClient)}.{nameof(Delete)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);

                // All BlobRequestConditions are valid.
                conditions.ValidateConditionsNotPresent(
                    invalidConditions: BlobRequestConditionProperty.None,
                    operationName: nameof(BlobBaseClient.Delete),
                    parameterName: nameof(conditions));

                try
                {
                    scope.Start();
                    ResponseWithHeaders<BlobDeleteHeaders> response;

                    if (async)
                    {
                        response = await BlobRestClient.DeleteAsync(
                            leaseId: conditions?.LeaseId,
                            deleteSnapshots: snapshotsOption == DeleteSnapshotsOption.None ? null : (DeleteSnapshotsOption?)snapshotsOption,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = BlobRestClient.Delete(
                            leaseId: conditions?.LeaseId,
                            deleteSnapshots: snapshotsOption == DeleteSnapshotsOption.None ? null : (DeleteSnapshotsOption?)snapshotsOption,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            cancellationToken: cancellationToken);
                    }

                    return response.GetRawResponse();
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                    scope.Dispose();
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
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");

                string operationName = $"{nameof(BlobBaseClient)}.{nameof(Exists)}";

                // 404 isn't an error for checking if the resource exists, it's false
                RequestContext context = new RequestContext() { CancellationToken = cancellationToken };
                context.AddClassifier(new BlobBaseClientExistsClassifier());

                try
                {
                    Response<BlobProperties> response = await GetPropertiesInternal(
                        conditions: default,
                        async: async,
                        context: context,
                        operationName)
                        .ConfigureAwait(false);

                    Response rawResponse = response.GetRawResponse();
                    if (BlobBaseClientExistsClassifier.IsResourceNotFoundResponse(rawResponse))
                    {
                        return Response.FromValue(false, rawResponse);
                    }

                    if (BlobBaseClientExistsClassifier.IsUsesCustomerSpecifiedEncryptionResponse(rawResponse))
                    {
                        return Response.FromValue(true, rawResponse);
                    }

                    return Response.FromValue(true, rawResponse);
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobBaseClient));
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
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(nameof(BlobBaseClient), message: $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobBaseClient)}.{nameof(Undelete)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<BlobUndeleteHeaders> response;

                    if (async)
                    {
                        response = await BlobRestClient.UndeleteAsync(
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = BlobRestClient.Undelete(
                            cancellationToken: cancellationToken);
                    }

                    return response.GetRawResponse();
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                    scope.Dispose();
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
                new RequestContext() { CancellationToken = cancellationToken })
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
                new RequestContext() { CancellationToken = cancellationToken })
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
        /// <param name="context">
        /// Optional <see cref="RequestContext"/> for the operation.
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
            RequestContext context,
            string operationName = default)
        {
            context ??= new RequestContext();
            operationName ??= $"{nameof(BlobBaseClient)}.{nameof(GetProperties)}";
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(conditions)}: {conditions}");

                operationName ??= $"{nameof(BlobBaseClient)}.{nameof(GetProperties)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);

                // All BlobRequestConditions are valid.
                conditions.ValidateConditionsNotPresent(
                    invalidConditions: BlobRequestConditionProperty.None,
                    operationName: nameof(BlobBaseClient.GetProperties),
                    parameterName: nameof(conditions));

                try
                {
                    scope.Start();
                    Response rawResponse;

                    if (async)
                    {
                        rawResponse = await BlobRestClient.GetPropertiesAsync(
                            leaseId: conditions?.LeaseId,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm.ToEncryptionAlgorithmString(),
                            requestConditions: conditions,
                            ifTags: conditions?.TagConditions,
                            context: context)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        rawResponse = BlobRestClient.GetProperties(
                            leaseId: conditions?.LeaseId,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm.ToEncryptionAlgorithmString(),
                            requestConditions: conditions,
                            ifTags: conditions?.TagConditions,
                            context: context);
                    }

                    ResponseWithHeaders<BlobGetPropertiesHeaders> response = ResponseWithHeaders.FromValue(
                        new BlobGetPropertiesHeaders(rawResponse), rawResponse);

                    return Response.FromValue(
                        response.ToBlobProperties(),
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                    scope.Dispose();
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
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(httpHeaders)}: {httpHeaders}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobBaseClient)}.{nameof(SetHttpHeaders)}");

                // All BlobRequestConditions are valid.
                conditions.ValidateConditionsNotPresent(
                    invalidConditions: BlobRequestConditionProperty.None,
                    operationName: nameof(BlobBaseClient.SetHttpHeaders),
                    parameterName: nameof(conditions));

                try
                {
                    scope.Start();
                    ResponseWithHeaders<BlobSetHttpHeadersHeaders> response;

                    if (async)
                    {
                        response = await BlobRestClient.SetHttpHeadersAsync(
                            blobCacheControl: httpHeaders?.CacheControl,
                            blobContentType: httpHeaders?.ContentType,
                            blobContentMD5: httpHeaders?.ContentHash,
                            blobContentEncoding: httpHeaders?.ContentEncoding,
                            blobContentLanguage: httpHeaders?.ContentLanguage,
                            leaseId: conditions?.LeaseId,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            blobContentDisposition: httpHeaders?.ContentDisposition,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = BlobRestClient.SetHttpHeaders(
                            blobCacheControl: httpHeaders?.CacheControl,
                            blobContentType: httpHeaders?.ContentType,
                            blobContentMD5: httpHeaders?.ContentHash,
                            blobContentEncoding: httpHeaders?.ContentEncoding,
                            blobContentLanguage: httpHeaders?.ContentLanguage,
                            leaseId: conditions?.LeaseId,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            blobContentDisposition: httpHeaders?.ContentDisposition,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToBlobInfo(),
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                    scope.Dispose();
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
        internal async Task<Response<BlobInfo>> SetMetadataInternal(
            Metadata metadata,
            BlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobBaseClient)}.{nameof(SetMetadata)}");

                // All BlobRequestConditions are valid.
                conditions.ValidateConditionsNotPresent(
                    invalidConditions: BlobRequestConditionProperty.None,
                    operationName: nameof(BlobBaseClient.SetMetadata),
                    parameterName: nameof(conditions));

                try
                {
                    scope.Start();
                    ResponseWithHeaders<BlobSetMetadataHeaders> response;

                    if (async)
                    {
                        response = await BlobRestClient.SetMetadataAsync(
                            metadata: metadata,
                            leaseId: conditions?.LeaseId,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                            encryptionScope: ClientConfiguration.EncryptionScope,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = BlobRestClient.SetMetadata(
                            metadata: metadata,
                            leaseId: conditions?.LeaseId,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                            encryptionScope: ClientConfiguration.EncryptionScope,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToBlobInfo(),
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                    scope.Dispose();
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
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobBaseClient)}.{nameof(CreateSnapshot)}");

                // All BlobRequestConditions are valid.
                conditions.ValidateConditionsNotPresent(
                    invalidConditions: BlobRequestConditionProperty.None,
                    operationName: nameof(BlobBaseClient.CreateSnapshot),
                    parameterName: nameof(conditions));

                try
                {
                    scope.Start();
                    ResponseWithHeaders<BlobCreateSnapshotHeaders> response;

                    if (async)
                    {
                        response = await BlobRestClient.CreateSnapshotAsync(
                            metadata: metadata,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                            encryptionScope: ClientConfiguration.EncryptionScope,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            leaseId: conditions?.LeaseId,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = BlobRestClient.CreateSnapshot(
                            metadata: metadata,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                            encryptionScope: ClientConfiguration.EncryptionScope,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            leaseId: conditions?.LeaseId,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToBlobSnapshotInfo(),
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                    scope.Dispose();
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
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(accessTier)}: {accessTier}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobBaseClient)}.{nameof(SetAccessTier)}");

                conditions.ValidateConditionsNotPresent(
                    invalidConditions:
                        BlobRequestConditionProperty.IfModifiedSince
                        | BlobRequestConditionProperty.IfUnmodifiedSince
                        | BlobRequestConditionProperty.IfMatch
                        | BlobRequestConditionProperty.IfNoneMatch,
                    operationName: nameof(BlobBaseClient.SetAccessTier),
                    parameterName: nameof(conditions));

                try
                {
                    scope.Start();
                    ResponseWithHeaders<BlobSetTierHeaders> response;

                    if (async)
                    {
                        response = await BlobRestClient.SetTierAsync(
                            tier: accessTier,
                            rehydratePriority: rehydratePriority,
                            leaseId: conditions?.LeaseId,
                            ifTags: conditions?.TagConditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = BlobRestClient.SetTier(
                            tier: accessTier,
                            rehydratePriority: rehydratePriority,
                            leaseId: conditions?.LeaseId,
                            ifTags: conditions?.TagConditions,
                            cancellationToken: cancellationToken);
                    }

                    return response.GetRawResponse();
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                    scope.Dispose();
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
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobBaseClient)}.{nameof(GetTags)}");

                conditions.ValidateConditionsNotPresent(
                    invalidConditions:
                        BlobRequestConditionProperty.IfModifiedSince
                        | BlobRequestConditionProperty.IfUnmodifiedSince
                        | BlobRequestConditionProperty.IfMatch
                        | BlobRequestConditionProperty.IfNoneMatch,
                    operationName: nameof(BlobBaseClient.GetTags),
                    parameterName: nameof(conditions));

                try
                {
                    scope.Start();
                    ResponseWithHeaders<BlobTags, BlobGetTagsHeaders> response;

                    if (async)
                    {
                        response = await BlobRestClient.GetTagsAsync(
                            ifTags: conditions?.TagConditions,
                            leaseId: conditions?.LeaseId,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = BlobRestClient.GetTags(
                            ifTags: conditions?.TagConditions,
                            leaseId: conditions?.LeaseId,
                            cancellationToken: cancellationToken);
                    }

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
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                    scope.Dispose();
                }
            }
        }
        #endregion

        #region SetTags
        /// <summary>
        /// Sets tags on the underlying blob.
        /// A blob can have up to 10 tags.  Tag keys must be between 1 and 128 characters.  Tag values must be between 0 and 256 characters.
        /// Valid tag key and value characters include lower and upper case letters, digits (0-9),
        /// space (' '), plus ('+'), minus ('-'), period ('.'), forward slash ('/'), colon (':'), equals ('='), and underscore ('_').
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
        /// space (' '), plus ('+'), minus ('-'), period ('.'), forward slash ('/'), colon (':'), equals ('='), and underscore ('_').
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
        /// space (' '), plus ('+'), minus ('-'), period ('.'), forward slash ('/'), colon (':'), equals ('='), and underscore ('_').
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
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(tags)}: {tags}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobBaseClient)}.{nameof(SetTags)}");

                conditions.ValidateConditionsNotPresent(
                    invalidConditions:
                        BlobRequestConditionProperty.IfModifiedSince
                        | BlobRequestConditionProperty.IfUnmodifiedSince
                        | BlobRequestConditionProperty.IfMatch
                        | BlobRequestConditionProperty.IfNoneMatch,
                    operationName: nameof(BlobBaseClient.SetTags),
                    parameterName: nameof(conditions));

                try
                {
                    scope.Start();
                    ResponseWithHeaders<BlobSetTagsHeaders> response;

                    if (async)
                    {
                        response = await BlobRestClient.SetTagsAsync(
                            ifTags: conditions?.TagConditions,
                            leaseId: conditions?.LeaseId,
                            tags: tags.ToBlobTags(),
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = BlobRestClient.SetTags(
                            ifTags: conditions?.TagConditions,
                            leaseId: conditions?.LeaseId,
                            tags: tags.ToBlobTags(),
                            cancellationToken: cancellationToken);
                    }

                    return response.GetRawResponse();
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                    scope.Dispose();
                }
            }
        }
        #endregion

        #region SetImmutabilityPolicy
        /// <summary>
        /// Sets the Immutability Policy on a Blob, Blob Snapshot, or Blob Version.
        /// Note that Blob Versioning must be enabled on your storage account, and the blob
        /// must be in a Container with immutable storage with versioning enabled to call
        /// this API.
        /// </summary>
        /// <param name="immutabilityPolicy">
        /// The <see cref="BlobImmutabilityPolicy"/> to set.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// setting the blob's HTTP headers.
        /// Note that If Unmodified Since is the only request condition applicable to this API.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobImmutabilityPolicy}"/>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobImmutabilityPolicy> SetImmutabilityPolicy(
            BlobImmutabilityPolicy immutabilityPolicy,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            SetImmutabilityPolicyInternal(
                immutabilityPolicy: immutabilityPolicy,
                conditions: conditions,
                async: false,
                cancellationToken: cancellationToken)
            .EnsureCompleted();

        /// <summary>
        /// Sets the Immutability Policy on a Blob, Blob Snapshot, or Blob Version.
        /// Note that Blob Versioning must be enabled on your storage account, and the blob
        /// must be in a Container with immutable storage with versioning enabled to call
        /// this API.
        /// </summary>
        /// <param name="immutabilityPolicy">
        /// The <see cref="BlobImmutabilityPolicy"/> to set.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// setting the blob's HTTP headers.
        /// Note that If Unmodified Since is the only request condition applicable to this API.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobImmutabilityPolicy}"/>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobImmutabilityPolicy>> SetImmutabilityPolicyAsync(
            BlobImmutabilityPolicy immutabilityPolicy,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await SetImmutabilityPolicyInternal(
                immutabilityPolicy: immutabilityPolicy,
                conditions: conditions,
                async: true,
                cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// Sets the Immutability Policy on a Blob, Blob Snapshot, or Blob Version.
        /// Note that Blob Versioning must be enabled on your storage account, and the blob
        /// must be in a Container with immutable storage with versioning enabled to call
        /// this API.
        /// </summary>
        /// <param name="immutabilityPolicy">
        /// The <see cref="BlobImmutabilityPolicy"/> to set.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// setting the blob's HTTP headers.
        /// Note that If Unmodified Since is the only request condition applicable to this API.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobImmutabilityPolicy}"/>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobImmutabilityPolicy>> SetImmutabilityPolicyInternal(
            BlobImmutabilityPolicy immutabilityPolicy,
            BlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(immutabilityPolicy)}: {immutabilityPolicy}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobBaseClient)}.{nameof(SetImmutabilityPolicy)}");

                if (immutabilityPolicy?.PolicyMode == BlobImmutabilityPolicyMode.Mutable)
                {
                    throw new ArgumentException($"{nameof(immutabilityPolicy.PolicyMode)} must be {BlobImmutabilityPolicyMode.Locked} or {BlobImmutabilityPolicyMode.Unlocked}");
                }

                conditions.ValidateConditionsNotPresent(
                    invalidConditions:
                        BlobRequestConditionProperty.IfMatch
                        | BlobRequestConditionProperty.IfNoneMatch
                        | BlobRequestConditionProperty.IfModifiedSince
                        | BlobRequestConditionProperty.LeaseId
                        | BlobRequestConditionProperty.TagConditions,
                    operationName: nameof(BlobBaseClient.SetImmutabilityPolicy),
                    parameterName: nameof(conditions));

                try
                {
                    scope.Start();
                    ResponseWithHeaders<BlobSetImmutabilityPolicyHeaders> response;

                    if (async)
                    {
                        response = await BlobRestClient.SetImmutabilityPolicyAsync(
                            timeout: null,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            immutabilityPolicyExpiry: immutabilityPolicy.ExpiresOn,
                            immutabilityPolicyMode: immutabilityPolicy.PolicyMode,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = BlobRestClient.SetImmutabilityPolicy(
                            timeout: null,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            immutabilityPolicyExpiry: immutabilityPolicy.ExpiresOn,
                            immutabilityPolicyMode: immutabilityPolicy.PolicyMode,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToBlobImmutabilityPolicy(),
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                    scope.Dispose();
                }
            }
        }
        #endregion

        #region DeleteImmutabilityPolicy
        /// <summary>
        /// Deletes the Immutability Policy associated with the Blob.
        /// Note that Blob Versioning must be enabled on your storage account, and the blob
        /// must be in a Container with immutable storage with versioning enabled to call
        /// this API.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response DeleteImmutabilityPolicy(
            CancellationToken cancellationToken = default)
            => DeleteImmutabilityPolicyInternal(
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Deletes the Immutability Policy associated with the Blob.
        /// Note that Blob Versioning must be enabled on your storage account, and the blob
        /// must be in a Container with immutable storage with versioning enabled to call
        /// this API.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> DeleteImmutabilityPolicyAsync(
            CancellationToken cancellationToken = default)
            => await DeleteImmutabilityPolicyInternal(
                async: true,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Deletes the Immutability Policy associated with the Blob.
        /// Note that Blob Versioning must be enabled on your storage account, and the blob
        /// must be in a Container with immutable storage with versioning enabled to call
        /// this API.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response> DeleteImmutabilityPolicyInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobBaseClient)}.{nameof(DeleteImmutabilityPolicy)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<BlobDeleteImmutabilityPolicyHeaders> response;

                    if (async)
                    {
                        response = await BlobRestClient.DeleteImmutabilityPolicyAsync(
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = BlobRestClient.DeleteImmutabilityPolicy(
                            cancellationToken: cancellationToken);
                    }

                    return response.GetRawResponse();
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                    scope.Dispose();
                }
            }
        }
        #endregion

        #region SetLegalHold
        /// <summary>
        /// Sets a legal hold on the blob.
        /// Note that Blob Versioning must be enabled on your storage account, and the blob
        /// must be in a Container with immutable storage with versioning enabled to call
        /// this API.
        /// </summary>
        /// <param name="hasLegalHold">
        /// Set to true to set a legal hold on the blob.
        /// Set to false to remove an existing legal hold.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobLegalHoldInfo}"/>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobLegalHoldResult> SetLegalHold(
            bool hasLegalHold,
            CancellationToken cancellationToken = default)
            => SetLegalHoldInternal(
                hasLegalHold: hasLegalHold,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Sets a legal hold on the blob.
        /// Note that Blob Versioning must be enabled on your storage account, and the blob
        /// must be in a Container with immutable storage with versioning enabled to call
        /// this API.
        /// </summary>
        /// <param name="hasLegalHold">
        /// Set to true to set a legal hold on the blob.
        /// Set to false to remove an existing legal hold.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobLegalHoldInfo}"/>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobLegalHoldResult>> SetLegalHoldAsync(
            bool hasLegalHold,
            CancellationToken cancellationToken = default)
            => await SetLegalHoldInternal(
                hasLegalHold: hasLegalHold,
                async: true,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Sets a legal hold on the blob.
        /// Note that Blob Versioning must be enabled on your storage account, and the blob
        /// must be in a Container with immutable storage with versioning enabled to call
        /// this API.
        /// </summary>
        /// <param name="hasLegalHold">
        /// Set to true to set a legal hold on the blob.
        /// Set to false to remove an existing legal hold.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobLegalHoldInfo}"/>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobLegalHoldResult>> SetLegalHoldInternal(
            bool hasLegalHold,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobBaseClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(hasLegalHold)}: {hasLegalHold}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobBaseClient)}.{nameof(SetLegalHold)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<BlobSetLegalHoldHeaders> response;

                    if (async)
                    {
                        response = await BlobRestClient.SetLegalHoldAsync(
                            legalHold: hasLegalHold,
                            timeout: null,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = BlobRestClient.SetLegalHold(
                            legalHold: hasLegalHold,
                            timeout: null,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToBlobLegalHoldInfo(),
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                    scope.Dispose();
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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-blobs")]
        public virtual Uri GenerateSasUri(BlobSasPermissions permissions, DateTimeOffset expiresOn) =>
            GenerateSasUri(new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = BlobContainerName,
                BlobName = Name,
                Snapshot = _snapshot,
                BlobVersionId = _blobVersionId,
                EncryptionScope = _clientConfiguration.EncryptionScope
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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-blobs")]
        public virtual Uri GenerateSasUri(BlobSasBuilder builder)
        {
            if (builder == null)
            {
                throw Errors.ArgumentNull(nameof(builder));
            }

            // Deep copy of builder so we don't modify the user's original BlobSasBuilder.
            builder = BlobSasBuilder.DeepCopy(builder);

            // Assign builder's ContainerName, BlobName, Snapshot, BlobVersionId, and EncryptionScope if they are null.
            builder.BlobContainerName ??= BlobContainerName;
            builder.BlobName ??= Name;
            builder.Snapshot ??= _snapshot;
            builder.BlobVersionId ??= _blobVersionId;
            builder.EncryptionScope ??= _clientConfiguration.EncryptionScope;

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
            BlobUriBuilder sasUri = new BlobUriBuilder(Uri, ClientConfiguration.TrimBlobNameSlashes)
            {
                Sas = builder.ToSasQueryParameters(ClientConfiguration.SharedKeyCredential)
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
                    ClientConfiguration,
                    ClientSideEncryption);
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
