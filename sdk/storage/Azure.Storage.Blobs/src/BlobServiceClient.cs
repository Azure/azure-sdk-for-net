// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Common;
using Azure.Storage.Cryptography;
using Azure.Storage.Sas;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

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
        /// <see cref="BlobClientConfiguration"/>.
        /// </summary>
        private readonly BlobClientConfiguration _clientConfiguration;

        /// <summary>
        /// <see cref="BlobClientConfiguration"/>.
        /// </summary>
        internal virtual BlobClientConfiguration ClientConfiguration => _clientConfiguration;

        /// <summary>
        /// The authentication policy for our ClientConfiguration.Pipeline.  We cache it here in
        /// case we need to construct a pipeline for authenticating batch
        /// operations.
        /// </summary>
        private readonly HttpPipelinePolicy _authenticationPolicy;

        internal virtual HttpPipelinePolicy AuthenticationPolicy => _authenticationPolicy;

        /// <summary>
        /// The <see cref="ClientSideEncryptionOptions"/> to be used when sending/receiving requests.
        /// </summary>
        private readonly ClientSideEncryptionOptions _clientSideEncryption;

        /// <summary>
        /// The <see cref="ClientSideEncryptionOptions"/> to be used when sending/receiving requests.
        /// </summary>
        internal virtual ClientSideEncryptionOptions ClientSideEncryption => _clientSideEncryption;

        /// <summary>
        /// The Storage account name corresponding to the service client.
        /// </summary>
        private string _accountName;

        /// <summary>
        /// Gets the Storage account name corresponding to the service client.
        /// </summary>
        public virtual string AccountName
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
        /// Determines whether the client is able to generate a SAS.
        /// If the client is authenticated with a <see cref="StorageSharedKeyCredential"/>.
        /// </summary>
        public virtual bool CanGenerateAccountSasUri => ClientConfiguration.SharedKeyCredential != null;

        /// <summary>
        /// <see cref="ServiceRestClient"/>.
        /// </summary>
        private readonly ServiceRestClient _serviceRestClient;

        /// <summary>
        /// <see cref="ServiceRestClient"/>.
        /// </summary>
        internal virtual ServiceRestClient ServiceRestClient => _serviceRestClient;

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
            _accountName = conn.AccountName;

            _clientConfiguration = new BlobClientConfiguration(
                pipeline: options.Build(_authenticationPolicy),
                sharedKeyCredential: conn.Credentials as StorageSharedKeyCredential,
                clientDiagnostics: new ClientDiagnostics(options),
                version: options.Version,
                customerProvidedKey: options.CustomerProvidedKey,
                transferValidation: options.TransferValidation,
                encryptionScope: options.EncryptionScope,
                trimBlobNameSlashes: options.TrimBlobNameSlashes);

            _clientSideEncryption = options._clientSideEncryptionOptions?.Clone();
            _serviceRestClient = BuildServiceRestClient(_uri);
            BlobErrors.VerifyHttpsCustomerProvidedKey(_uri, _clientConfiguration.CustomerProvidedKey);
            BlobErrors.VerifyCpkAndEncryptionScopeNotBothSet(_clientConfiguration.CustomerProvidedKey, _clientConfiguration.EncryptionScope);
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
            : this(serviceUri, credential.AsPolicy(), credential, options ?? new BlobClientOptions())
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
            : this(serviceUri, credential.AsPolicy<BlobUriBuilder>(serviceUri), credential, options ?? new BlobClientOptions())
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
            : this(
                  serviceUri,
                  credential.AsPolicy(
                    string.IsNullOrEmpty(options?.Audience?.ToString()) ? BlobAudience.DefaultAudience.CreateDefaultScope() : options.Audience.Value.CreateDefaultScope(),
                    options),
                  credential,
                  options ?? new BlobClientOptions())
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
        internal BlobServiceClient(
            Uri serviceUri,
            HttpPipelinePolicy authentication,
            BlobClientOptions options)
            : this(serviceUri,
                  new BlobClientConfiguration(
                      pipeline: options.Build(authentication),
                      sharedKeyCredential: default,
                      clientDiagnostics: new ClientDiagnostics(options),
                      version: options?.Version ?? BlobClientOptions.LatestVersion,
                      customerProvidedKey: options?.CustomerProvidedKey,
                      transferValidation: options.TransferValidation,
                      encryptionScope: options?.EncryptionScope,
                      trimBlobNameSlashes: options?.TrimBlobNameSlashes ?? false),
                  authentication,
                  options?._clientSideEncryptionOptions?.Clone())
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
        /// <param name="storageSharedKeyCredential">
        /// Optional storage shared key credential used to sign requests and generate sas.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        internal BlobServiceClient(
            Uri serviceUri,
            HttpPipelinePolicy authentication,
            StorageSharedKeyCredential storageSharedKeyCredential,
            BlobClientOptions options)
            : this(serviceUri,
                  new BlobClientConfiguration(
                      pipeline: options.Build(authentication),
                      sharedKeyCredential: storageSharedKeyCredential,
                      clientDiagnostics: new ClientDiagnostics(options),
                      version: options?.Version ?? BlobClientOptions.LatestVersion,
                      customerProvidedKey: options?.CustomerProvidedKey,
                      transferValidation: options.TransferValidation,
                      encryptionScope: options?.EncryptionScope,
                      trimBlobNameSlashes: options?.TrimBlobNameSlashes ?? false),
                  authentication,
                  options?._clientSideEncryptionOptions?.Clone())
        {
            _accountName ??= storageSharedKeyCredential?.AccountName;
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
        /// <param name="tokenCredential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        internal BlobServiceClient(
            Uri serviceUri,
            HttpPipelinePolicy authentication,
            TokenCredential tokenCredential,
            BlobClientOptions options)
            : this(serviceUri,
                  new BlobClientConfiguration(
                      pipeline: options.Build(authentication),
                      tokenCredential: tokenCredential,
                      clientDiagnostics: new ClientDiagnostics(options),
                      version: options?.Version ?? BlobClientOptions.LatestVersion,
                      customerProvidedKey: options?.CustomerProvidedKey,
                      transferValidation: options.TransferValidation,
                      encryptionScope: options?.EncryptionScope,
                      trimBlobNameSlashes: options?.TrimBlobNameSlashes ?? false),
                  authentication,
                  options?._clientSideEncryptionOptions?.Clone())
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
        /// <param name="sasCredential">
        /// Optional SAS credential used to sign requests and generate sas.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        internal BlobServiceClient(
            Uri serviceUri,
            HttpPipelinePolicy authentication,
            AzureSasCredential sasCredential,
            BlobClientOptions options)
            : this(serviceUri,
                  new BlobClientConfiguration(
                      pipeline: options.Build(authentication),
                      sasCredential: sasCredential,
                      clientDiagnostics: new ClientDiagnostics(options),
                      version: options?.Version ?? BlobClientOptions.LatestVersion,
                      customerProvidedKey: options?.CustomerProvidedKey,
                      transferValidation: options.TransferValidation,
                      encryptionScope: options?.EncryptionScope,
                      trimBlobNameSlashes: options?.TrimBlobNameSlashes ?? false),
                  authentication,
                  options?._clientSideEncryptionOptions?.Clone())
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
        /// <param name="clientConfiguration">
        /// <see cref="BlobClientConfiguration"/>.
        /// </param>
        /// <param name="authentication">
        /// An optional authentication policy used to sign requests.
        /// </param>
        /// <param name="clientSideEncryption">
        /// Client-side encryption options.
        /// </param>
        internal BlobServiceClient(
            Uri serviceUri,
            BlobClientConfiguration clientConfiguration,
            HttpPipelinePolicy authentication,
            ClientSideEncryptionOptions clientSideEncryption)
        {
            Argument.AssertNotNull(serviceUri, nameof(serviceUri));
            _uri = serviceUri;
            _clientConfiguration = clientConfiguration;
            _authenticationPolicy = authentication;
            _clientSideEncryption = clientSideEncryption?.Clone();
            _serviceRestClient = BuildServiceRestClient(serviceUri);
            BlobErrors.VerifyCpkAndEncryptionScopeNotBothSet(_clientConfiguration.CustomerProvidedKey, _clientConfiguration.EncryptionScope);
            BlobErrors.VerifyHttpsCustomerProvidedKey(_uri, _clientConfiguration.CustomerProvidedKey);
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
        /// <param name="sharedKeyCredential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="sasCredential">
        /// The SAS credential used to sign requests.
        /// </param>
        /// <param name="tokenCredential">
        /// The token credential used to sign requests.
        /// </param>
        /// <returns>
        /// New instanc of the <see cref="BlobServiceClient"/> class.
        /// </returns>
        protected static BlobServiceClient CreateClient(
            Uri serviceUri,
            BlobClientOptions options,
            HttpPipelinePolicy authentication,
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            AzureSasCredential sasCredential,
            TokenCredential tokenCredential)
        {
            return new BlobServiceClient(
                serviceUri,
                new BlobClientConfiguration(
                    pipeline: pipeline,
                    sharedKeyCredential: sharedKeyCredential,
                    sasCredential: sasCredential,
                    tokenCredential: tokenCredential,
                    clientDiagnostics: new ClientDiagnostics(options),
                    version: options.Version,
                    customerProvidedKey: null,
                    transferValidation: options.TransferValidation,
                    encryptionScope: null,
                    trimBlobNameSlashes: options.TrimBlobNameSlashes),
                authentication,
                clientSideEncryption: null);
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected static BlobServiceClient CreateClient(
            Uri serviceUri,
            BlobClientOptions options,
            HttpPipelinePolicy authentication,
            HttpPipeline pipeline)
        {
            return new BlobServiceClient(
                serviceUri,
                new BlobClientConfiguration(
                    pipeline: pipeline,
                    sharedKeyCredential: null,
                    clientDiagnostics: new ClientDiagnostics(options),
                    version: options.Version,
                    customerProvidedKey: null,
                    transferValidation: options.TransferValidation,
                    encryptionScope: null,
                    trimBlobNameSlashes: options.TrimBlobNameSlashes),
                authentication,
                clientSideEncryption: null);
        }

        private ServiceRestClient BuildServiceRestClient(Uri uri)
            => new ServiceRestClient(
                clientDiagnostics: _clientConfiguration.ClientDiagnostics,
                pipeline: _clientConfiguration.Pipeline,
                url: uri.AbsoluteUri,
                version: _clientConfiguration.Version.ToVersionString());
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
                ClientConfiguration,
                AuthenticationPolicy,
                ClientSideEncryption);

        #region protected static accessors for Azure.Storage.Blobs.Batch
        /// <summary>
        /// Get a <see cref="BlobServiceClient"/>'s <see cref="HttpPipeline"/>
        /// for creating child clients.
        /// </summary>
        /// <param name="client">The BlobServiceClient.</param>
        /// <returns>The BlobServiceClient's HttpPipeline.</returns>
        protected static HttpPipeline GetHttpPipeline(BlobServiceClient client) =>
            client.ClientConfiguration.Pipeline;

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
            new BlobClientOptions(client.ClientConfiguration.Version)
            {
                // We only use this for communicating diagnostics, at the moment
                Diagnostics =
                {
                    IsDistributedTracingEnabled = client.ClientConfiguration.ClientDiagnostics.IsActivityEnabled
                }
            };
        #endregion protected static accessors for Azure.Storage.Blobs.Batch

        #region GetBlobContainers
        /// <summary>
        /// The <see cref="GetBlobContainers(BlobContainerTraits, BlobContainerStates, string, CancellationToken)"/>
        /// operation returns a sequence of blob containers in the storage account.  Enumerating the
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// and the <see cref="ListContainersSegmentResponse.NextMarker"/> if it's not
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
        /// operation returns a non-empty <see cref="ListContainersSegmentResponse.NextMarker"/>
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        internal async Task<Response<ListContainersSegmentResponse>> GetBlobContainersInternal(
            string continuationToken,
            BlobContainerTraits traits,
#pragma warning disable CA1801 // Review unused parameters
            BlobContainerStates states,
#pragma warning restore CA1801 // Review unused parameters
            string prefix,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobServiceClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobServiceClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(continuationToken)}: {continuationToken}\n" +
                    $"{nameof(traits)}: {traits}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobServiceClient)}.{nameof(GetBlobContainers)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<ListContainersSegmentResponse, ServiceListContainersSegmentHeaders> response;

                    if (async)
                    {
                        response = await ServiceRestClient.ListContainersSegmentAsync(
                            prefix: prefix,
                            marker: continuationToken,
                            maxresults: pageSizeHint,
                            include: BlobExtensions.AsIncludeItems(traits, states),
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ServiceRestClient.ListContainersSegment(
                            prefix: prefix,
                            marker: continuationToken,
                            maxresults: pageSizeHint,
                            include: BlobExtensions.AsIncludeItems(traits, states),
                            cancellationToken: cancellationToken);
                    }

                    ListContainersSegmentResponse listContainersResponse = response.Value;

                    if ((traits & BlobContainerTraits.Metadata) != BlobContainerTraits.Metadata)
                    {
                        List<ContainerItemInternal> containerItemInternals = response.Value.ContainerItems.Select(r => new ContainerItemInternal(
                            r.Name,
                            r.Deleted,
                            r.Version,
                            r.Properties,
                            metadata: null))
                            .ToList();

                        listContainersResponse = new ListContainersSegmentResponse(
                            response.Value.ServiceEndpoint,
                            response.Value.Prefix,
                            response.Value.Marker,
                            response.Value.MaxResults,
                            containerItemInternals.AsReadOnly(),
                            response.Value.NextMarker);
                    }

                    return Response.FromValue(
                        listContainersResponse,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobServiceClient));
                    scope.Dispose();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<AccountInfo>> GetAccountInfoInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobServiceClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(nameof(BlobServiceClient), message: $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobServiceClient)}.{nameof(GetAccountInfo)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<ServiceGetAccountInfoHeaders> response;

                    if (async)
                    {
                        response = await ServiceRestClient.GetAccountInfoAsync(
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ServiceRestClient.GetAccountInfo(
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToAccountInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobServiceClient));
                    scope.Dispose();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<BlobServiceProperties>> GetPropertiesInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobServiceClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(nameof(BlobServiceClient), message: $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobServiceClient)}.{nameof(GetProperties)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<BlobServiceProperties, ServiceGetPropertiesHeaders> response;

                    if (async)
                    {
                        response = await ServiceRestClient.GetPropertiesAsync(
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ServiceRestClient.GetProperties(
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.Value,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobServiceClient));
                    scope.Dispose();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-blobs")]
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-blobs")]
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response> SetPropertiesInternal(
            BlobServiceProperties properties,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobServiceClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobServiceClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(properties)}: {properties}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobServiceClient)}.{nameof(SetProperties)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<ServiceSetPropertiesHeaders> response;

                    if (async)
                    {
                        response  = await ServiceRestClient.SetPropertiesAsync(
                            blobServiceProperties: properties,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ServiceRestClient.SetProperties(
                            blobServiceProperties: properties,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobServiceClient));
                    scope.Dispose();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<BlobServiceStatistics>> GetStatisticsInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobServiceClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(nameof(BlobServiceClient), message: $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobServiceClient)}.{nameof(GetStatistics)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<BlobServiceStatistics, ServiceGetStatisticsHeaders> response;

                    if (async)
                    {
                        response = await ServiceRestClient.GetStatisticsAsync(
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ServiceRestClient.GetStatistics(
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.Value,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobServiceClient));
                    scope.Dispose();
                }
            }
        }
        #endregion GetStatistics

        #region GetUserDelegationKey
        /// <summary>
        /// The <see cref="GetUserDelegationKey(DateTimeOffset, BlobGetUserDelegationKeyOptions, CancellationToken)"/> operation retrieves a
        /// key that can be used to delegate Active Directory authorization to
        /// shared access signatures created with <see cref="Sas.BlobSasBuilder"/>.
        /// </summary>
        /// <param name="expiresOn">
        /// Expiration of the key's validity.  The time should be specified
        /// in UTC.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-blobs")]
        public virtual Response<UserDelegationKey> GetUserDelegationKey(
            DateTimeOffset expiresOn,
            BlobGetUserDelegationKeyOptions options = default,
            CancellationToken cancellationToken = default) =>
            GetUserDelegationKeyInternal(
                options?.StartsOn,
                expiresOn,
                options?.DelegatedUserTid,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetUserDelegationKeyAsync(DateTimeOffset, BlobGetUserDelegationKeyOptions, CancellationToken)"/> operation retrieves a
        /// key that can be used to delegate Active Directory authorization to
        /// shared access signatures created with <see cref="Sas.BlobSasBuilder"/>.
        /// </summary>
        /// <param name="expiresOn">
        /// Expiration of the key's validity.  The time should be specified
        /// in UTC.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-blobs")]
        public virtual async Task<Response<UserDelegationKey>> GetUserDelegationKeyAsync(
            DateTimeOffset expiresOn,
            BlobGetUserDelegationKeyOptions options = default,
            CancellationToken cancellationToken = default) =>
            await GetUserDelegationKeyInternal(
                options?.StartsOn,
                expiresOn,
                options?.DelegatedUserTid,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetUserDelegationKey(DateTimeOffset?, DateTimeOffset, CancellationToken)"/> operation retrieves a
        /// key that can be used to delegate Active Directory authorization to
        /// shared access signatures created with <see cref="Sas.BlobSasBuilder"/>.
        /// </summary>
        /// <param name="startsOn">
        /// Start time for the key's validity, with null indicating an
        /// immediate start.  The time should be specified in UTC.
        ///
        /// Note: If you set the start time to the current time, failures
        /// might occur intermittently for the first few minutes. This is due to different
        /// machines having slightly different current times (known as clock skew).
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-blobs")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<UserDelegationKey> GetUserDelegationKey(
            DateTimeOffset? startsOn,
            DateTimeOffset expiresOn,
            CancellationToken cancellationToken = default) =>
            GetUserDelegationKeyInternal(
                startsOn,
                expiresOn,
                default,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetUserDelegationKeyAsync(DateTimeOffset?, DateTimeOffset, CancellationToken)"/> operation retrieves a
        /// key that can be used to delegate Active Directory authorization to
        /// shared access signatures created with <see cref="Sas.BlobSasBuilder"/>.
        /// </summary>
        /// <param name="startsOn">
        /// Start time for the key's validity, with null indicating an
        /// immediate start.  The time should be specified in UTC.
        ///
        /// Note: If you set the start time to the current time, failures
        /// might occur intermittently for the first few minutes. This is due to different
        /// machines having slightly different current times (known as clock skew).
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-blobs")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<UserDelegationKey>> GetUserDelegationKeyAsync(
            DateTimeOffset? startsOn,
            DateTimeOffset expiresOn,
            CancellationToken cancellationToken = default) =>
            await GetUserDelegationKeyInternal(
                startsOn,
                expiresOn,
                default,
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
        ///
        /// Note: If you set the start time to the current time, failures
        /// might occur intermittently for the first few minutes. This is due to different
        /// machines having slightly different current times (known as clock skew).
        /// </param>
        /// <param name="expiresOn">
        /// Expiration of the key's validity.  The time should be specified
        /// in UTC.
        /// </param>
        /// <param name="delegatedUserTid">
        /// The delegated user tenant id in Azure AD.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<UserDelegationKey>> GetUserDelegationKeyInternal(
            DateTimeOffset? startsOn,
            DateTimeOffset expiresOn,
            string delegatedUserTid,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobServiceClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(nameof(BlobServiceClient), message: $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobServiceClient)}.{nameof(GetUserDelegationKey)}");

                try
                {
                    scope.Start();

                    if (startsOn.HasValue && startsOn.Value.Offset != TimeSpan.Zero)
                    {
                        throw Errors.InvalidDateTimeUtc(nameof(startsOn));
                    }

                    if (expiresOn.Offset != TimeSpan.Zero)
                    {
                        throw Errors.InvalidDateTimeUtc(nameof(expiresOn));
                    }

                    KeyInfo keyInfo = new KeyInfo(expiresOn.ToString(Constants.Iso8601Format, CultureInfo.InvariantCulture))
                    {
                        Start = startsOn?.ToString(Constants.Iso8601Format, CultureInfo.InvariantCulture),
                        DelegatedUserTid = delegatedUserTid
                    };

                    ResponseWithHeaders<UserDelegationKey, ServiceGetUserDelegationKeyHeaders> response;

                    if (async)
                    {
                        response = await ServiceRestClient.GetUserDelegationKeyAsync(
                            keyInfo: keyInfo,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ServiceRestClient.GetUserDelegationKey(
                            keyInfo: keyInfo,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.Value,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobServiceClient));
                    scope.Dispose();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// specified blob container for deletion.
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
        /// A <see cref="Response"/> on successfully marking for deletion.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// specified container for deletion.
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
        /// A <see cref="Response"/> on successfully marking for deletion.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<BlobContainerClient> UndeleteBlobContainer(
            string deletedContainerName,
            string deletedContainerVersion,
            CancellationToken cancellationToken = default)
            => UndeleteBlobContainerInternal(
                deletedContainerName,
                deletedContainerVersion,
                deletedContainerName,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<BlobContainerClient>> UndeleteBlobContainerAsync(
            string deletedContainerName,
            string deletedContainerVersion,
            CancellationToken cancellationToken = default)
            => await UndeleteBlobContainerInternal(
                deletedContainerName,
                deletedContainerVersion,
                deletedContainerName,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BlobContainerClient> UndeleteBlobContainer(
            string deletedContainerName,
            string deletedContainerVersion,
            string destinationContainerName,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BlobContainerClient>> UndeleteBlobContainerAsync(
            string deletedContainerName,
            string deletedContainerVersion,
            string destinationContainerName,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        internal async Task<Response<BlobContainerClient>> UndeleteBlobContainerInternal(
            string deletedContainerName,
            string deletedContainerVersion,
            string destinationContainerName,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(deletedContainerName)}: {deletedContainerName}\n" +
                    $"{nameof(deletedContainerVersion)}: {deletedContainerVersion}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobServiceClient)}.{nameof(UndeleteBlobContainer)}");

                try
                {
                    scope.Start();
                    BlobContainerClient containerClient;
                    if (destinationContainerName != null)
                    {
                        containerClient = GetBlobContainerClient(destinationContainerName);
                    }
                    else
                    {
                        containerClient = GetBlobContainerClient(deletedContainerName);
                    }

                    ResponseWithHeaders<ContainerRestoreHeaders> response;

                    if (async)
                    {
                        response = await containerClient.ContainerRestClient.RestoreAsync(
                            deletedContainerName: deletedContainerName,
                            deletedContainerVersion: deletedContainerVersion,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = containerClient.ContainerRestClient.Restore(
                            deletedContainerName: deletedContainerName,
                            deletedContainerVersion: deletedContainerVersion,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(containerClient, response);
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobContainerClient));
                    scope.Dispose();
                }
            }
        }
        #endregion UndeleteBlobContainer

        #region RenameBlobContainer
        /// <summary>
        /// Renames an existing Blob Container.
        /// </summary>
        /// <param name="sourceContainerName">
        /// The name of the source container.
        /// </param>
        /// <param name="destinationContainerName">
        /// The name of the destination container.
        /// </param>
        /// <param name="sourceConditions">
        /// Optional <see cref="BlobRequestConditions"/> that
        /// source container has to meet to proceed with rename.
        /// Note that LeaseId is the only request condition enforced by
        /// this API.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerClient}"/> pointed at the renamed container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        internal virtual Response<BlobContainerClient> RenameBlobContainer(
            string sourceContainerName,
            string destinationContainerName,
            BlobRequestConditions sourceConditions = default,
            CancellationToken cancellationToken = default)
            => RenameBlobContainerInternal(
                sourceContainerName,
                destinationContainerName,
                sourceConditions,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Renames an existing Blob Container.
        /// </summary>
        /// <param name="sourceContainerName">
        /// The name of the source container.
        /// </param>
        /// <param name="destinationContainerName">
        /// The name of the destination container.
        /// </param>
        /// <param name="sourceConditions">
        /// Optional <see cref="BlobRequestConditions"/> that
        /// source container has to meet to proceed with rename.
        /// Note that LeaseId is the only request condition enforced by
        /// this API.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerClient}"/> pointed at the renamed container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        internal virtual async Task<Response<BlobContainerClient>> RenameBlobContainerAsync(
            string sourceContainerName,
            string destinationContainerName,
            BlobRequestConditions sourceConditions = default,
            CancellationToken cancellationToken = default)
            => await RenameBlobContainerInternal(
                sourceContainerName,
                destinationContainerName,
                sourceConditions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Renames an existing Blob Container.
        /// </summary>
        /// <param name="sourceContainerName">
        /// The name of the source container.
        /// </param>
        /// <param name="destinationContainerName">
        /// The new name of the Blob Container.
        /// </param>
        /// <param name="sourceConditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the renaming of this container.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerClient}"/> pointed at the renamed container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        internal async Task<Response<BlobContainerClient>> RenameBlobContainerInternal(
            string sourceContainerName,
            string destinationContainerName,
            BlobRequestConditions sourceConditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(sourceContainerName)}: {sourceContainerName}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobServiceClient)}.{nameof(RenameBlobContainer)}");

                sourceConditions.ValidateConditionsNotPresent(
                    invalidConditions:
                        BlobRequestConditionProperty.IfModifiedSince
                        | BlobRequestConditionProperty.IfUnmodifiedSince
                        | BlobRequestConditionProperty.TagConditions
                        | BlobRequestConditionProperty.IfMatch
                        | BlobRequestConditionProperty.IfNoneMatch,
                    operationName: nameof(BlobServiceClient.RenameBlobContainer),
                    parameterName: nameof(sourceConditions));

                try
                {
                    scope.Start();

                    BlobContainerClient containerClient = GetBlobContainerClient(destinationContainerName);

                    ResponseWithHeaders<ContainerRenameHeaders> response;

                    if (async)
                    {
                        response = await containerClient.ContainerRestClient.RenameAsync(
                            sourceContainerName: sourceContainerName,
                            sourceLeaseId: sourceConditions?.LeaseId,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = containerClient.ContainerRestClient.Rename(
                            sourceContainerName: sourceContainerName,
                            sourceLeaseId: sourceConditions?.LeaseId,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        containerClient,
                        response);
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobContainerClient));
                    scope.Dispose();
                }
            }
        }
        #endregion RenameBlobContainer

        #region FilterBlobs
        /// <summary>
        /// The Filter Blobs operation enables callers to list blobs across all containers whose tags
        /// match a given search expression and only the tags appearing in the expression will be returned.
        /// Filter blobs searches across all containers within a storage account but can be scoped within the expression to a single container.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobServiceClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobServiceClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(expression)}: {expression}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobServiceClient)}.{nameof(FindBlobsByTags)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<FilterBlobSegment, ServiceFilterBlobsHeaders> response;

                    if (async)
                    {
                        response = await ServiceRestClient.FilterBlobsAsync(
                            where: expression,
                            marker: marker,
                            maxresults: pageSizeHint,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ServiceRestClient.FilterBlobs(
                            where: expression,
                            marker: marker,
                            maxresults: pageSizeHint,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.Value,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobServiceClient));
                    scope.Dispose();
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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-blobs")]
        public Uri GenerateAccountSasUri(
            AccountSasPermissions permissions,
            DateTimeOffset expiresOn,
            AccountSasResourceTypes resourceTypes) =>
            GenerateAccountSasUri(permissions, expiresOn, resourceTypes, out _);

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
        /// <param name="stringToSign">
        /// For debugging purposes only.  This string will be overwritten with the string to sign that was used to generate the SAS Uri.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-blobs")]
        public Uri GenerateAccountSasUri(
            AccountSasPermissions permissions,
            DateTimeOffset expiresOn,
            AccountSasResourceTypes resourceTypes,
            out string stringToSign) =>
            GenerateAccountSasUri(new AccountSasBuilder(
                permissions,
                expiresOn,
                AccountSasServices.Blobs,
                resourceTypes),
                out stringToSign);

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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-blobs")]
        public Uri GenerateAccountSasUri(AccountSasBuilder builder)
            => GenerateAccountSasUri(builder, out _);

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
        /// <param name="stringToSign">
        /// For debugging purposes only.  This string will be overwritten with the string to sign that was used to generate the SAS Uri.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-blobs")]
        public Uri GenerateAccountSasUri(AccountSasBuilder builder, out string stringToSign)
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
            sasUri.Query = builder.ToSasQueryParameters(ClientConfiguration.SharedKeyCredential, out stringToSign).ToString();
            return sasUri.Uri;
        }
        #endregion
    }
}
