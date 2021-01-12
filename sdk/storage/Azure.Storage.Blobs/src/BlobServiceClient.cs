// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Cryptography;
using Azure.Storage.Sas;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using System.Linq;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// The <see cref="BlobServiceClient"/> allows you to manipulate Azure
    /// Storage service resources and blob containers. The storage account provides
    /// the top-level namespace for the Blob service.
    /// </summary>
    public class BlobServiceClient
    {
        /// <summary>
        /// Gets the blob service's primary <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _uri;

        /// <summary>
        /// Gets the blob service's primary <see cref="Uri"/> endpoint.
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
        /// The authentication policy for our pipeline.  We cache it here in
        /// case we need to construct a pipeline for authenticating batch
        /// operations.
        /// </summary>
        private readonly HttpPipelinePolicy _authenticationPolicy;

        internal virtual HttpPipelinePolicy AuthenticationPolicy => _authenticationPolicy;

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

        /// <summary>
        /// The name of the Encryption Scope to be used when sending request.
        /// </summary>
        internal readonly string _encryptionScope;

        /// <summary>
        /// The name of the Encryption Scope to be used when sending request.
        /// </summary>
        internal virtual string EncryptionScope => _encryptionScope;

        /// <summary>
        /// The Storage account name corresponding to the service client.
        /// </summary>
        private string _accountName;

        /// <summary>
        /// Gets the Storage account name corresponding to the service client.
        /// </summary>
        public string AccountName
        {
            get
            {
                if (_accountName == null)
                {
                    _accountName = new BlobUriBuilder(Uri).AccountName;
                }
                return _accountName;
            }
        }

        /// <summary>
        /// The <see cref="StorageSharedKeyCredential"/> used to authenticate and generate SAS
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
        public bool CanGenerateAccountSasUri => SharedKeyCredential != null;

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobServiceClient"/>
        /// class for mocking.
        /// </summary>
        protected BlobServiceClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information, <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">Configure Azure Storage connection strings</see>.
        /// </param>
        public BlobServiceClient(string connectionString)
            : this(connectionString, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information,
        /// <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">
        /// Configure Azure Storage connection strings</see>.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobServiceClient(string connectionString, BlobClientOptions options)
        {
            var conn = StorageConnectionString.Parse(connectionString);
            _uri = conn.BlobEndpoint;
            options ??= new BlobClientOptions();
            _authenticationPolicy = StorageClientOptions.GetAuthenticationPolicy(conn.Credentials);
            _pipeline = options.Build(_authenticationPolicy);
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
        /// Initializes a new instance of the <see cref="BlobServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the blob service.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net".
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobServiceClient(Uri serviceUri, BlobClientOptions options = default)
            : this(serviceUri, (HttpPipelinePolicy)null, options ?? new BlobClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the blob service.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net".
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobServiceClient(Uri serviceUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            : this(serviceUri, credential.AsPolicy(), options ?? new BlobClientOptions(), credential)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the blob service.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net".
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
        public BlobServiceClient(Uri serviceUri, AzureSasCredential credential, BlobClientOptions options = default)
            : this(serviceUri, credential.AsPolicy<BlobUriBuilder>(serviceUri), options ?? new BlobClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the blob service.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net".
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobServiceClient(Uri serviceUri, TokenCredential credential, BlobClientOptions options = default)
            : this(serviceUri, credential.AsPolicy(), options ?? new BlobClientOptions())
        {
            Errors.VerifyHttpsTokenAuth(serviceUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the blob service.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net".
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
        /// Optional storage shared key credential used to sign requests and generate sas.
        /// </param>
        internal BlobServiceClient(
            Uri serviceUri,
            HttpPipelinePolicy authentication,
            BlobClientOptions options,
            StorageSharedKeyCredential storageSharedKeyCredential = default)
            : this(
                  serviceUri,
                  authentication,
                  options?.Version ?? BlobClientOptions.LatestVersion,
                  new ClientDiagnostics(options),
                  options?.CustomerProvidedKey,
                  options?._clientSideEncryptionOptions?.Clone(),
                  options?.EncryptionScope,
                  options.Build(authentication),
                  storageSharedKeyCredential)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the blob service.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net".
        /// </param>
        /// <param name="authentication">
        /// An optional authentication policy used to sign requests.
        /// </param>
        /// <param name="version">
        /// The version of the service to use when sending requests.
        /// </param>
        /// <param name="clientDiagnostics">
        /// The <see cref="ClientDiagnostics"/> instance used to create
        /// diagnostic scopes every request.
        /// </param>
        /// <param name="customerProvidedKey">Customer provided key.</param>
        /// <param name="clientSideEncryption">Client-side encryption options.</param>
        /// <param name="encryptionScope">Encryption scope.</param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        /// <param name="storageSharedKeyCredential">Storage Shared Key Credential</param>
        internal BlobServiceClient(
            Uri serviceUri,
            HttpPipelinePolicy authentication,
            BlobClientOptions.ServiceVersion version,
            ClientDiagnostics clientDiagnostics,
            CustomerProvidedKey? customerProvidedKey,
            ClientSideEncryptionOptions clientSideEncryption,
            string encryptionScope,
            HttpPipeline pipeline,
            StorageSharedKeyCredential storageSharedKeyCredential)
        {
            Argument.AssertNotNull(serviceUri, nameof(serviceUri));
            _uri = serviceUri;
            _authenticationPolicy = authentication;
            _pipeline = pipeline;
            _version = version;
            _clientDiagnostics = clientDiagnostics;
            _customerProvidedKey = customerProvidedKey;
            _clientSideEncryption = clientSideEncryption?.Clone();
            _encryptionScope = encryptionScope;
            _storageSharedKeyCredential = storageSharedKeyCredential;
            BlobErrors.VerifyCpkAndEncryptionScopeNotBothSet(_customerProvidedKey, _encryptionScope);
            BlobErrors.VerifyHttpsCustomerProvidedKey(_uri, _customerProvidedKey);
        }

        /// <summary>
        /// Intended for DataLake to create a backing blob client.
        ///
        /// Initializes a new instance of the <see cref="BlobServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the block blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        /// <param name="authentication">
        /// An optional authentication policy used to sign requests.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        /// <returns>
        /// New instanc of the <see cref="BlobServiceClient"/> class.
        /// </returns>
        protected static BlobServiceClient CreateClient(
            Uri serviceUri,
            BlobClientOptions options,
            HttpPipelinePolicy authentication,
            HttpPipeline pipeline)
        {
            return new BlobServiceClient(
                serviceUri,
                authentication,
                options.Version,
                new ClientDiagnostics(options),
                customerProvidedKey: null,
                clientSideEncryption: null,
                encryptionScope: null,
                pipeline,
                storageSharedKeyCredential: null);
        }
        #endregion ctors

        /// <summary>
        /// Create a new <see cref="BlobContainerClient"/> object by appending
        /// <paramref name="blobContainerName"/> to the end of <see cref="Uri"/>.
        /// The new <see cref="BlobContainerClient"/> uses the same request
        /// policy pipeline as the <see cref="BlobServiceClient"/>.
        /// </summary>
        /// <param name="blobContainerName">
        /// The name of the blob container to reference.
        /// </param>
        /// <returns>
        /// A <see cref="BlobContainerClient"/> for the desired container.
        /// </returns>
        public virtual BlobContainerClient GetBlobContainerClient(string blobContainerName) =>
            new BlobContainerClient(
                Uri.AppendToPath(blobContainerName),
                Pipeline,
                _storageSharedKeyCredential,
                Version,
                ClientDiagnostics,
                CustomerProvidedKey,
                ClientSideEncryption,
                EncryptionScope);

        #region protected static accessors for Azure.Storage.Blobs.Batch
        /// <summary>
        /// Get a <see cref="BlobServiceClient"/>'s <see cref="HttpPipeline"/>
        /// for creating child clients.
        /// </summary>
        /// <param name="client">The BlobServiceClient.</param>
        /// <returns>The BlobServiceClient's HttpPipeline.</returns>
        protected static HttpPipeline GetHttpPipeline(BlobServiceClient client) =>
            client.Pipeline;

        /// <summary>
        /// Get a <see cref="BlobServiceClient"/>'s authentication
        /// <see cref="HttpPipelinePolicy"/> for creating child clients.
        /// </summary>
        /// <param name="client">The BlobServiceClient.</param>
        /// <returns>The BlobServiceClient's authentication policy.</returns>
        protected static HttpPipelinePolicy GetAuthenticationPolicy(BlobServiceClient client) =>
            client.AuthenticationPolicy;

        /// <summary>
        /// Get a <see cref="BlobServiceClient"/>'s <see cref="BlobClientOptions"/>
        /// for creating child clients.
        /// </summary>
        /// <param name="client">The BlobServiceClient.</param>
        /// <returns>The BlobServiceClient's BlobClientOptions.</returns>
        protected static BlobClientOptions GetClientOptions(BlobServiceClient client) =>
            new BlobClientOptions(client.Version)
            {
                // We only use this for communicating diagnostics, at the moment
                Diagnostics =
                {
                    IsDistributedTracingEnabled = client.ClientDiagnostics.IsActivityEnabled
                }
            };
        #endregion protected static accessors for Azure.Storage.Blobs.Batch

        #region GetBlobContainers
        /// <summary>
        /// The <see cref="GetBlobContainers(BlobContainerTraits, BlobContainerStates, string, CancellationToken)"/>
        /// operation returns an asyncsequence of blob containers in the storage account.  Enumerating the
        /// blob containers may make multiple requests to the service while fetching
        /// all the values.  Containers are ordered lexicographically by name.
        ///
        /// For more information,
        /// see <see href="https://docs.microsoft.com/rest/api/storageservices/list-containers2">
        /// List Containers</see>.
        /// </summary>
        /// <param name="traits">
        /// Specifies trait options for shaping the blob containers.
        /// </param>
        /// <param name="states">
        /// Specifies state options for shaping the blob containers.
        /// </param>
        /// <param name="prefix">
        /// Specifies a string that filters the results to return only containers
        /// whose name begins with the specified <paramref name="prefix"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of <see cref="Response{BlobContainerItem}"/>
        /// describing the blob containers in the storage account.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Pageable<BlobContainerItem> GetBlobContainers(
            BlobContainerTraits traits = BlobContainerTraits.None,
            BlobContainerStates states = BlobContainerStates.None,
            string prefix = default,
            CancellationToken cancellationToken = default) =>
            new GetBlobContainersAsyncCollection(this, traits, states, prefix).ToSyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetBlobContainers(BlobContainerTraits, string, CancellationToken)"/> operation returns an async
        /// sequence of blob containers in the storage account.  Enumerating the
        /// blob containers may make multiple requests to the service while fetching
        /// all the values.  Containers are ordered lexicographically by name.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-containers2">
        /// List Containers</see>.
        /// </summary>
        /// <param name="traits">
        /// Specifies trait options for shaping the blob containers.
        /// </param>
        /// <param name="prefix">
        /// Specifies a string that filters the results to return only containers
        /// whose name begins with the specified <paramref name="prefix"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of <see cref="Response{BlobContainerItem}"/>
        /// describing the blob containers in the storage account.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Pageable<BlobContainerItem> GetBlobContainers(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            BlobContainerTraits traits,
            string prefix,
            CancellationToken cancellationToken) =>
            new GetBlobContainersAsyncCollection(this, traits, default, prefix).ToSyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetBlobContainersAsync(BlobContainerTraits, BlobContainerStates, string, CancellationToken)"/>
        /// operation returns an async sequence of blob containers in the storage account.  Enumerating the
        /// blob containers may make multiple requests to the service while fetching
        /// all the values.  Containers are ordered lexicographically by name.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-containers2">
        /// List Containers</see>.
        /// </summary>
        /// <param name="traits">
        /// Specifies trait options for shaping the blob containers.
        /// </param>
        /// <param name="states">
        /// Specifies states options for shaping the blob containers.
        /// </param>
        /// <param name="prefix">
        /// Specifies a string that filters the results to return only containers
        /// whose name begins with the specified <paramref name="prefix"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="AsyncPageable{T}"/> describing the
        /// containers in the storage account.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual AsyncPageable<BlobContainerItem> GetBlobContainersAsync(
            BlobContainerTraits traits = BlobContainerTraits.None,
            BlobContainerStates states = BlobContainerStates.None,
            string prefix = default,
            CancellationToken cancellationToken = default) =>
            new GetBlobContainersAsyncCollection(this, traits, states, prefix).ToAsyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetBlobContainersAsync(BlobContainerTraits, string, CancellationToken)"/>
        /// operation returns an async sequence of blob containers in the storage account.  Enumerating the
        /// blob containers may make multiple requests to the service while fetching
        /// all the values.  Containers are ordered lexicographically by name.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-containers2">
        /// List Containers</see>.
        /// </summary>
        /// <param name="traits">
        /// Specifies trait options for shaping the blob containers.
        /// </param>
        /// <param name="prefix">
        /// Specifies a string that filters the results to return only containers
        /// whose name begins with the specified <paramref name="prefix"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="AsyncPageable{T}"/> describing the
        /// containers in the storage account.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual AsyncPageable<BlobContainerItem> GetBlobContainersAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            BlobContainerTraits traits,
            string prefix,
            CancellationToken cancellationToken) =>
            new GetBlobContainersAsyncCollection(this, traits, default, prefix).ToAsyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetBlobContainersInternal"/> operation returns a
        /// single segment of blob containers in the storage account, starting
        /// from the specified <paramref name="continuationToken"/>.  Use an empty
        /// <paramref name="continuationToken"/> to start enumeration from the beginning
        /// and the <see cref="BlobContainersSegment.NextMarker"/> if it's not
        /// empty to make subsequent calls to <see cref="GetBlobContainersInternal"/>
        /// to continue enumerating the containers segment by segment.
        /// Containers are ordered lexicographically by name.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-containers2">
        /// List Containers</see>.
        /// </summary>
        /// <param name="continuationToken">
        /// An optional string value that identifies the segment of the list
        /// of blob containers to be returned with the next listing operation.  The
        /// operation returns a non-empty <see cref="BlobContainersSegment.NextMarker"/>
        /// if the listing operation did not return all blob containers remaining
        /// to be listed with the current segment.  The NextMarker value can
        /// be used as the value for the <paramref name="continuationToken"/> parameter
        /// in a subsequent call to request the next segment of list items.
        /// </param>
        /// <param name="traits">
        /// Specifies trait options for shaping the blob containers.
        /// </param>
        /// <param name="states">
        /// Specifies state options for shaping the blob containers.
        /// </param>
        /// <param name="prefix">
        /// Specifies a string that filters the results to return only containers
        /// whose name begins with the specified <paramref name="prefix"/>.
        /// </param>
        /// <param name="pageSizeHint">
        /// Gets or sets a value indicating the size of the page that should be
        /// requested.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainersSegment}"/> describing a
        /// segment of the blob containers in the storage account.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<Response<BlobContainersSegment>> GetBlobContainersInternal(
            string continuationToken,
            BlobContainerTraits traits,
            BlobContainerStates states,
            string prefix,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobServiceClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobServiceClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(continuationToken)}: {continuationToken}\n" +
                    $"{nameof(traits)}: {traits}");
                try
                {
                    Response<BlobContainersSegment> response = await BlobRestClient.Service.ListBlobContainersSegmentAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        marker: continuationToken,
                        prefix: prefix,
                        maxresults: pageSizeHint,
                        include: BlobExtensions.AsIncludeItems(traits, states),
                        async: async,
                        operationName: $"{nameof(BlobServiceClient)}.{nameof(GetBlobContainers)}",
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                    if ((traits & BlobContainerTraits.Metadata) != BlobContainerTraits.Metadata)
                    {
                        IEnumerable<BlobContainerItem> containerItems = response.Value.BlobContainerItems;
                        foreach (BlobContainerItem containerItem in containerItems)
                        {
                            containerItem.Properties.Metadata = null;
                        }
                    }
                    return response;
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(BlobServiceClient));
                }
            }
        }
        #endregion GetBlobContainers

        #region GetAccountInfo
        /// <summary>
        /// The <see cref="GetAccountInfo"/> operation returns the sku
        /// name and account kind for the specified account.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-account-information">
        /// Get Account Information</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{AccountInfo}"/> describing the account.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<AccountInfo> GetAccountInfo(
            CancellationToken cancellationToken = default) =>
            GetAccountInfoInternal(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetAccountInfoAsync"/> operation returns the sku
        /// name and account kind for the specified account.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-account-information">
        /// Get Account Information</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{AccountInfo}"/> describing the account.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<AccountInfo>> GetAccountInfoAsync(
            CancellationToken cancellationToken = default) =>
            await GetAccountInfoInternal(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetAccountInfoInternal"/> operation returns the sku
        /// name and account kind for the specified account.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-account-information">
        /// Get Account Information</see>.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{AccountInfo}"/> describing the account.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<AccountInfo>> GetAccountInfoInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobServiceClient)))
            {
                Pipeline.LogMethodEnter(nameof(BlobServiceClient), message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    return await BlobRestClient.Service.GetAccountInfoAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        async: async,
                        operationName: $"{nameof(BlobServiceClient)}.{nameof(GetAccountInfo)}",
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
                    Pipeline.LogMethodExit(nameof(BlobServiceClient));
                }
            }
        }
        #endregion GetAccountInfo

        #region GetProperties
        /// <summary>
        /// The <see cref="GetProperties"/> operation gets the properties
        /// of a storage account’s blob service, including properties for
        /// Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-blob-service-properties">
        /// Get Blob Service Properties</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobServiceProperties}"/> describing
        /// the service properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobServiceProperties> GetProperties(
            CancellationToken cancellationToken = default) =>
            GetPropertiesInternal(
                false, //async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetPropertiesAsync"/> operation gets the properties
        /// of a storage account’s blob service, including properties for
        /// Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-blob-service-properties">
        /// Get Blob Service Properties</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobServiceProperties}"/> describing
        /// the service properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobServiceProperties>> GetPropertiesAsync(
            CancellationToken cancellationToken = default) =>
            await GetPropertiesInternal(
                true, //async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetPropertiesInternal"/> operation gets the properties
        /// of a storage account’s blob service, including properties for
        /// Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-blob-service-properties">
        /// Get Blob Service Properties</see>.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobServiceProperties}"/> describing
        /// the service properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobServiceProperties>> GetPropertiesInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobServiceClient)))
            {
                Pipeline.LogMethodEnter(nameof(BlobServiceClient), message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    return await BlobRestClient.Service.GetPropertiesAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        async: async,
                        operationName: $"{nameof(BlobServiceClient)}.{nameof(GetProperties)}",
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
                    Pipeline.LogMethodExit(nameof(BlobServiceClient));
                }
            }
        }
        #endregion GetProperties

        #region SetProperties
        /// <summary>
        /// The <see cref="SetProperties"/> operation sets properties for
        /// a storage account’s Blob service endpoint, including properties
        /// for Storage Analytics, CORS (Cross-Origin Resource Sharing) rules
        /// and soft delete settings.  You can also use this operation to set
        /// the default request version for all incoming requests to the Blob
        /// service that do not have a version specified.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-service-properties">
        /// Set Blob Service Properties</see>.
        /// </summary>
        /// <param name="properties">The blob service properties.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing
        /// the service properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response SetProperties(
            BlobServiceProperties properties,
            CancellationToken cancellationToken = default) =>
            SetPropertiesInternal(
                properties,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="SetPropertiesAsync"/> operation sets properties for
        /// a storage account’s Blob service endpoint, including properties
        /// for Storage Analytics, CORS (Cross-Origin Resource Sharing) rules
        /// and soft delete settings.  You can also use this operation to set
        /// the default request version for all incoming requests to the Blob
        /// service that do not have a version specified.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-service-properties">
        /// Set Blob Service Properties</see>.
        /// </summary>
        /// <param name="properties">The blob service properties.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing
        /// the service properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> SetPropertiesAsync(
            BlobServiceProperties properties,
            CancellationToken cancellationToken = default) =>
            await SetPropertiesInternal(
                properties,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetPropertiesInternal"/> operation sets properties for
        /// a storage account’s Blob service endpoint, including properties
        /// for Storage Analytics, CORS (Cross-Origin Resource Sharing) rules
        /// and soft delete settings.  You can also use this operation to set
        /// the default request version for all incoming requests to the Blob
        /// service that do not have a version specified.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-service-properties">
        /// Set Blob Service Properties</see>.
        /// </summary>
        /// <param name="properties">The blob service properties.</param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing
        /// the service properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response> SetPropertiesInternal(
            BlobServiceProperties properties,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobServiceClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobServiceClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(properties)}: {properties}");
                try
                {
                    return await BlobRestClient.Service.SetPropertiesAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        properties,
                        version: Version.ToVersionString(),
                        async: async,
                        operationName: $"{nameof(BlobServiceClient)}.{nameof(SetProperties)}",
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
                    Pipeline.LogMethodExit(nameof(BlobServiceClient));
                }
            }
        }
        #endregion SetProperties

        #region GetStatistics
        /// <summary>
        /// The <see cref="GetStatistics"/> operation retrieves
        /// statistics related to replication for the Blob service.  It is
        /// only available on the secondary location endpoint when read-access
        /// geo-redundant replication (<see cref="Models.SkuName.StandardRagrs"/>)
        /// is enabled for the storage account.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob-service-stats">
        /// Get Blob Service Stats</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobServiceStatistics}"/> describing
        /// the service replication statistics.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobServiceStatistics> GetStatistics(
            CancellationToken cancellationToken = default) =>
            GetStatisticsInternal(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetStatisticsAsync"/> operation retrieves
        /// statistics related to replication for the Blob service.  It is
        /// only available on the secondary location endpoint when read-access
        /// geo-redundant replication (<see cref="Models.SkuName.StandardRagrs"/>)
        /// is enabled for the storage account.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob-service-stats">
        /// Get Blob Service Stats</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobServiceStatistics}"/> describing
        /// the service replication statistics.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobServiceStatistics>> GetStatisticsAsync(
            CancellationToken cancellationToken = default) =>
            await GetStatisticsInternal(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetStatisticsInternal"/> operation retrieves
        /// statistics related to replication for the Blob service.  It is
        /// only available on the secondary location endpoint when read-access
        /// geo-redundant replication (<see cref="Models.SkuName.StandardRagrs"/>)
        /// is enabled for the storage account.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob-service-stats">
        /// Get Blob Service Stats</see>.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobServiceStatistics}"/> describing
        /// the service replication statistics.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobServiceStatistics>> GetStatisticsInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobServiceClient)))
            {
                Pipeline.LogMethodEnter(nameof(BlobServiceClient), message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    return await BlobRestClient.Service.GetStatisticsAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        async: async,
                        operationName: $"{nameof(BlobServiceClient)}.{nameof(GetStatistics)}",
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
                    Pipeline.LogMethodExit(nameof(BlobServiceClient));
                }
            }
        }
        #endregion GetStatistics

        #region GetUserDelegationKey
        /// <summary>
        /// The <see cref="GetUserDelegationKey"/> operation retrieves a
        /// key that can be used to delegate Active Directory authorization to
        /// shared access signatures created with <see cref="Sas.BlobSasBuilder"/>.
        /// </summary>
        /// <param name="startsOn">
        /// Start time for the key's validity, with null indicating an
        /// immediate start.  The time should be specified in UTC.
        /// </param>
        /// <param name="expiresOn">
        /// Expiration of the key's validity.  The time should be specified
        /// in UTC.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobServiceStatistics}"/> describing
        /// the service replication statistics.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<UserDelegationKey> GetUserDelegationKey(
            DateTimeOffset? startsOn,
            DateTimeOffset expiresOn,
            CancellationToken cancellationToken = default) =>
            GetUserDelegationKeyInternal(
                startsOn,
                expiresOn,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetUserDelegationKeyAsync"/> operation retrieves a
        /// key that can be used to delegate Active Directory authorization to
        /// shared access signatures created with <see cref="Sas.BlobSasBuilder"/>.
        /// </summary>
        /// <param name="startsOn">
        /// Start time for the key's validity, with null indicating an
        /// immediate start.  The time should be specified in UTC.
        /// </param>
        /// <param name="expiresOn">
        /// Expiration of the key's validity.  The time should be specified
        /// in UTC.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobServiceStatistics}"/> describing
        /// the service replication statistics.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<UserDelegationKey>> GetUserDelegationKeyAsync(
            DateTimeOffset? startsOn,
            DateTimeOffset expiresOn,
            CancellationToken cancellationToken = default) =>
            await GetUserDelegationKeyInternal(
                startsOn,
                expiresOn,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetUserDelegationKeyInternal"/> operation retrieves a
        /// key that can be used to delegate Active Directory authorization to
        /// shared access signatures created with <see cref="Sas.BlobSasBuilder"/>.
        /// </summary>
        /// <param name="startsOn">
        /// Start time for the key's validity, with null indicating an
        /// immediate start.  The time should be specified in UTC.
        /// </param>
        /// <param name="expiresOn">
        /// Expiration of the key's validity.  The time should be specified
        /// in UTC.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <param name="async"/>
        /// <returns>
        /// A <see cref="Response{BlobServiceStatistics}"/> describing
        /// the service replication statistics.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<UserDelegationKey>> GetUserDelegationKeyInternal(
            DateTimeOffset? startsOn,
            DateTimeOffset expiresOn,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobServiceClient)))
            {
                Pipeline.LogMethodEnter(nameof(BlobServiceClient), message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    if (startsOn.HasValue && startsOn.Value.Offset != TimeSpan.Zero)
                    {
                        throw BlobErrors.InvalidDateTimeUtc(nameof(startsOn));
                    }

                    if (expiresOn.Offset != TimeSpan.Zero)
                    {
                        throw BlobErrors.InvalidDateTimeUtc(nameof(expiresOn));
                    }

                    var keyInfo = new KeyInfo { StartsOn = startsOn, ExpiresOn = expiresOn };

                    return await BlobRestClient.Service.GetUserDelegationKeyAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        keyInfo: keyInfo,
                        version: Version.ToVersionString(),
                        async: async,
                        operationName: $"{nameof(BlobServiceClient)}.{nameof(GetUserDelegationKey)}",
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
                    Pipeline.LogMethodExit(nameof(BlobServiceClient));
                }
            }
        }
        #endregion GetUserDelegationKey

        #region CreateBlobContainer
        /// <summary>
        /// The <see cref="CreateBlobContainer"/> operation creates a new
        /// blob container under the specified account. If the container with the
        /// same name already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-container">
        /// Create Container</see>.
        /// </summary>
        /// <param name="blobContainerName">
        /// The name of the container to create.
        /// </param>
        /// <param name="publicAccessType">
        /// Optionally specifies whether data in the container may be accessed
        /// publicly and the level of access. <see cref="PublicAccessType.BlobContainer"/>
        /// specifies full public read access for container and blob data.
        /// Clients can enumerate blobs within the container via anonymous
        /// request, but cannot enumerate containers within the storage
        /// account.  <see cref="PublicAccessType.Blob"/> specifies public
        /// read access for blobs.  Blob data within this container can be
        /// read via anonymous request, but container data is not available.
        /// Clients cannot enumerate blobs within the container via anonymous
        /// request.  <see cref="PublicAccessType.None"/> specifies that the
        /// container data is private to the account owner.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this container.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerClient}"/> referencing the
        /// newly created container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<BlobContainerClient> CreateBlobContainer(
            string blobContainerName,
            PublicAccessType publicAccessType = PublicAccessType.None,
            Metadata metadata = default,
            CancellationToken cancellationToken = default)
        {
            BlobContainerClient container = GetBlobContainerClient(blobContainerName);
            Response<BlobContainerInfo> response = container.Create(publicAccessType, metadata, cancellationToken);
            return Response.FromValue(container, response.GetRawResponse());
        }

        /// <summary>
        /// The <see cref="CreateBlobContainerAsync"/> operation creates a new
        /// blob container under the specified account. If the container with the
        /// same name already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-container">
        /// Create Container</see>.
        /// </summary>
        /// <param name="blobContainerName">
        /// The name of the container to create.
        /// </param>
        /// <param name="publicAccessType">
        /// Optionally specifies whether data in the container may be accessed
        /// publicly and the level of access. <see cref="PublicAccessType.BlobContainer"/>
        /// specifies full public read access for container and blob data.
        /// Clients can enumerate blobs within the container via anonymous
        /// request, but cannot enumerate containers within the storage
        /// account.  <see cref="PublicAccessType.Blob"/> specifies public
        /// read access for blobs.  Blob data within this container can be
        /// read via anonymous request, but container data is not available.
        /// Clients cannot enumerate blobs within the container via anonymous
        /// request.  <see cref="PublicAccessType.None"/> specifies that the
        /// container data is private to the account owner.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this container.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerClient}"/> referencing the
        /// newly created container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<BlobContainerClient>> CreateBlobContainerAsync(
            string blobContainerName,
            PublicAccessType publicAccessType = PublicAccessType.None,
            Metadata metadata = default,
            CancellationToken cancellationToken = default)
        {
            BlobContainerClient container = GetBlobContainerClient(blobContainerName);
            Response<BlobContainerInfo> response = await container.CreateAsync(publicAccessType, metadata, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(container, response.GetRawResponse());
        }
        #endregion CreateBlobContainer

        #region DeleteBlobContainer
        /// <summary>
        /// The <see cref="DeleteBlobContainer"/> operation marks the
        /// specified blob container for deletion. The container and any blobs
        /// contained within it are later deleted during garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-container">
        /// Delete Container</see>.
        /// </summary>
        /// <param name="blobContainerName">
        /// The name of the container to delete.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the deletion of this container.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> if successful.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response DeleteBlobContainer(
            string blobContainerName,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            GetBlobContainerClient(blobContainerName)
                .Delete(
                    conditions,
                    cancellationToken);

        /// <summary>
        /// The <see cref="DeleteBlobContainerAsync"/> operation marks the
        /// specified container for deletion. The container and any blobs
        /// contained within it are later deleted during garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-container">
        /// Delete Container</see>.
        /// </summary>
        /// <param name="blobContainerName">
        /// The name of the blob container to delete.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the deletion of this blob container.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> if successful.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteBlobContainerAsync(
            string blobContainerName,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await
                GetBlobContainerClient(blobContainerName)
                .DeleteAsync(
                    conditions,
                    cancellationToken)
                    .ConfigureAwait(false);
        #endregion DeleteBlobContainer

        #region UndeleteBlobContainer
        /// <summary>
        /// Restores a previously deleted container.
        /// This API is only functional is Container Soft Delete is enabled
        /// for the storage account associated with the container.
        /// </summary>
        /// <param name="deletedContainerName">
        /// The name of the previously deleted container.
        /// </param>
        /// <param name="deletedContainerVersion">
        /// The version of the previously deleted container.
        /// </param>
        /// <param name="destinationContainerName">
        /// Optional.  Use this parameter if you would like to restore the container
        /// under a different name.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerClient}"/> pointed at the undeleted container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobContainerClient> UndeleteBlobContainer(
            string deletedContainerName,
            string deletedContainerVersion,
            string destinationContainerName = default,
            CancellationToken cancellationToken = default)
            => UndeleteBlobContainerInternal(
                deletedContainerName,
                deletedContainerVersion,
                destinationContainerName,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Restores a previously deleted container.
        /// This API is only functional is Container Soft Delete is enabled
        /// for the storage account associated with the container.
        /// </summary>
        /// <param name="deletedContainerName">
        /// The name of the previously deleted container.
        /// </param>
        /// <param name="deletedContainerVersion">
        /// The version of the previously deleted container.
        /// </param>
        /// <param name="destinationContainerName">
        /// Optional.  Use this parameter if you would like to restore the container
        /// under a different name.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerClient}"/> pointed at the undeleted container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobContainerClient>> UndeleteBlobContainerAsync(
            string deletedContainerName,
            string deletedContainerVersion,
            string destinationContainerName = default,
            CancellationToken cancellationToken = default)
            => await UndeleteBlobContainerInternal(
                deletedContainerName,
                deletedContainerVersion,
                destinationContainerName,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Restores a previously deleted container.
        /// This API is only functional is Container Soft Delete is enabled
        /// for the storage account associated with the container.
        /// </summary>
        /// <param name="deletedContainerName">
        /// The name of the previously deleted container.
        /// </param>
        /// <param name="deletedContainerVersion">
        /// The version of the previously deleted container.
        /// </param>
        /// <param name="destinationContainerName">
        /// Optional.  Use this parameter if you would like to restore the container
        /// under a different name.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerClient}"/> pointed at the undeleted container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<Response<BlobContainerClient>> UndeleteBlobContainerInternal(
            string deletedContainerName,
            string deletedContainerVersion,
            string destinationContainerName,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(deletedContainerName)}: {deletedContainerName}\n" +
                    $"{nameof(deletedContainerVersion)}: {deletedContainerVersion}");

                try
                {
                    BlobContainerClient containerClient;
                    if (destinationContainerName != null)
                    {
                        containerClient = GetBlobContainerClient(destinationContainerName);
                    }
                    else
                    {
                        containerClient = GetBlobContainerClient(deletedContainerName);
                    }

                    Response response = await BlobRestClient.Container.RestoreAsync(
                        ClientDiagnostics,
                        Pipeline,
                        containerClient.Uri,
                        Version.ToVersionString(),
                        deletedContainerName: deletedContainerName,
                        deletedContainerVersion: deletedContainerVersion,
                        async: async,
                        operationName: $"{nameof(BlobServiceClient)}.{nameof(UndeleteBlobContainer)}",
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return Response.FromValue(containerClient, response);
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(BlobContainerClient));
                }
            }
        }
        #endregion UndeleteBlobContainer

        #region FilterBlobs
        /// <summary>
        /// The Filter Blobs operation enables callers to list blobs across all containers whose tags
        /// match a given search expression. Filter blobs searches across all containers within a
        /// storage account but can be scoped within the expression to a single container.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/find-blobs-by-tags">
        /// Find Blobs by Tags</see>.
        /// </summary>
        /// <param name="tagFilterSqlExpression">
        /// The where parameter finds blobs in the storage account whose tags match a given expression.
        /// The expression must evaluate to true for a blob to be returned in the result set.
        /// The storage service supports a subset of the ANSI SQL WHERE clause grammar for the value of the where=expression query parameter.
        /// The following operators are supported: =, &gt;, &gt;=, &lt;, &lt;=, AND. and @container.
        /// Example expression: "tagKey"='tagValue'.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="AsyncPageable{T}"/> describing the blobs.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Pageable<TaggedBlobItem> FindBlobsByTags(
            string tagFilterSqlExpression,
            CancellationToken cancellationToken = default) =>
            new FilterBlobsAsyncCollection(this, tagFilterSqlExpression).ToSyncCollection(cancellationToken);

        /// <summary>
        /// The Filter Blobs operation enables callers to list blobs across all containers whose tags
        /// match a given search expression. Filter blobs searches across all containers within a
        /// storage account but can be scoped within the expression to a single container.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/find-blobs-by-tags">
        /// Find Blobs by Tags</see>.
        /// </summary>
        /// <param name="tagFilterSqlExpression">
        /// The where parameter finds blobs in the storage account whose tags match a given expression.
        /// The expression must evaluate to true for a blob to be returned in the result set.
        /// The storage service supports a subset of the ANSI SQL WHERE clause grammar for the value of the where=expression query parameter.
        /// The following operators are supported: =, &gt;, &gt;=, &lt;, &lt;=, AND. and @container.
        /// Example expression: "tagKey"='tagValue'.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="AsyncPageable{T}"/> describing the blobs.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual AsyncPageable<TaggedBlobItem> FindBlobsByTagsAsync(
            string tagFilterSqlExpression,
            CancellationToken cancellationToken = default) =>
            new FilterBlobsAsyncCollection(this, tagFilterSqlExpression).ToAsyncCollection(cancellationToken);

        internal async Task<Response<FilterBlobSegment>> FindBlobsByTagsInternal(
            string marker,
            string expression,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobServiceClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobServiceClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(expression)}: {expression}");

                try
                {
                    return await BlobRestClient.Service.FilterBlobsAsync(
                        clientDiagnostics: ClientDiagnostics,
                        pipeline: Pipeline,
                        resourceUri: Uri,
                        version: Version.ToVersionString(),
                        where: expression,
                        marker: marker,
                        maxresults: pageSizeHint,
                        async: async,
                        operationName: $"{nameof(BlobServiceClient)}.{nameof(FindBlobsByTags)}",
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
                    Pipeline.LogMethodExit(nameof(BlobServiceClient));
                }
            }
        }
        #endregion FilterBlobs

        #region GenerateSas
        /// <summary>
        /// The <see cref="GenerateAccountSasUri(AccountSasPermissions, DateTimeOffset, AccountSasResourceTypes)"/>
        /// returns a <see cref="Uri"/> that generates a Blob Account
        /// Shared Access Signature (SAS) based on the Client properties
        /// and parameters passed. The SAS is signed by the
        /// shared key credential of the client.
        ///
        /// To check if the client is able to sign a Service Sas see
        /// <see cref="CanGenerateAccountSasUri"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-account-sas">
        /// Constructing an Account SAS</see>.
        /// </summary>
        /// <param name="permissions">
        /// Required. Specifies the list of permissions to be associated with the SAS.
        /// See <see cref="AccountSasPermissions"/>.
        /// </param>
        /// <param name="expiresOn">
        /// Required. The time at which the shared access signature becomes invalid.
        /// </param>
        /// <param name="resourceTypes">
        /// Specifies the resource types associated with the shared access signature.
        /// The user is restricted to operations on the specified resources.
        /// See <see cref="AccountSasResourceTypes"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if a failure occurs.
        /// </remarks>
        public Uri GenerateAccountSasUri(
            AccountSasPermissions permissions,
            DateTimeOffset expiresOn,
            AccountSasResourceTypes resourceTypes) =>
            GenerateAccountSasUri(new AccountSasBuilder(
                permissions,
                expiresOn,
                AccountSasServices.Blobs,
                resourceTypes));

        /// <summary>
        /// The <see cref="GenerateAccountSasUri(AccountSasBuilder)"/> returns a <see cref="Uri"/> that
        /// generates a Blob Account Shared Access Signature (SAS) based on the
        /// Client properties and builder passed. The SAS is signed by the
        /// shared key credential of the client.
        ///
        /// To check if the client is able to sign a Service Sas see
        /// <see cref="CanGenerateAccountSasUri"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-account-sas">
        /// Constructing an Account SAS</see>.
        /// </summary>
        /// <param name="builder">
        /// Used to generate a Shared Access Signature (SAS).
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if a failure occurs.
        /// </remarks>
        public Uri GenerateAccountSasUri(AccountSasBuilder builder)
        {
            builder = builder ?? throw Errors.ArgumentNull(nameof(builder));
            if (!builder.Services.HasFlag(AccountSasServices.Blobs))
            {
                throw Errors.SasServiceNotMatching(
                    nameof(builder.Services),
                    nameof(builder),
                    nameof(AccountSasServices.Blobs));
            }
            UriBuilder sasUri = new UriBuilder(Uri);
            sasUri.Query = builder.ToSasQueryParameters(SharedKeyCredential).ToString();
            return sasUri.Uri;
        }
        #endregion
    }
}
