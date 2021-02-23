﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Cryptography;
using Azure.Storage.Sas;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// The <see cref="BlobContainerClient"/> allows you to manipulate Azure
    /// Storage containers and their blobs.
    /// </summary>
	public class BlobContainerClient
    {
        /// <summary>
        /// The Azure Storage name used to identify a storage account's root container.
        /// </summary>
        public static readonly string RootBlobContainerName = Constants.Blob.Container.RootName;

        /// <summary>
        /// The Azure Storage name used to identify a storage account's logs container.
        /// </summary>
        public static readonly string LogsBlobContainerName = Constants.Blob.Container.LogsName;

        /// <summary>
        /// The Azure Storage name used to identify a storage account's web content container.
        /// </summary>
        public static readonly string WebBlobContainerName = Constants.Blob.Container.WebName;

#pragma warning disable IDE0032 // Use auto property
        /// <summary>
        /// Gets the container's primary <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _uri;
#pragma warning restore IDE0032 // Use auto property

        /// <summary>
        /// Gets the container's primary <see cref="Uri"/> endpoint.
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
        /// The Storage account name corresponding to the container client.
        /// </summary>
        private string _accountName;

        /// <summary>
        /// Gets the Storage account name corresponding to the container client.
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
        /// The name of the container.
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets the name of the container.
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
        /// ContainerRestClient.
        /// </summary>
        private readonly ContainerRestClient _containerRestClient;

        /// <summary>
        /// ContainerRestClient.
        /// </summary>
        internal virtual ContainerRestClient ContainerRestClient => _containerRestClient;

        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerClient"/>
        /// class for mocking.
        /// </summary>
        protected BlobContainerClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerClient"/>
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
        /// The name of the blob container in the storage account to reference.
        /// </param>
        public BlobContainerClient(string connectionString, string blobContainerName)
            : this(connectionString, blobContainerName, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerClient"/>
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
        /// The name of the container in the storage account to reference.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobContainerClient(string connectionString, string blobContainerName, BlobClientOptions options)
        {
            var conn = StorageConnectionString.Parse(connectionString);
            var builder = new BlobUriBuilder(conn.BlobEndpoint) { BlobContainerName = blobContainerName };
            _uri = builder.ToUri();
            options ??= new BlobClientOptions();

            _clientConfiguration = new BlobClientConfiguration(
                pipeline: options.Build(conn.Credentials),
                sharedKeyCredential: conn.Credentials as StorageSharedKeyCredential,
                clientDiagnostics: new ClientDiagnostics(options),
                version: options.Version,
                customerProvidedKey: options.CustomerProvidedKey,
                encryptionScope: options.EncryptionScope);

            _authenticationPolicy = StorageClientOptions.GetAuthenticationPolicy(conn.Credentials);
            _containerRestClient = BuildContainerRestClient(_uri);

            BlobErrors.VerifyHttpsCustomerProvidedKey(_uri, _clientConfiguration.CustomerProvidedKey);
            BlobErrors.VerifyCpkAndEncryptionScopeNotBothSet(_clientConfiguration.CustomerProvidedKey, _clientConfiguration.EncryptionScope);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerClient"/>
        /// class.
        /// </summary>
        /// <param name="blobContainerUri">
        /// A <see cref="Uri"/> referencing the blob container that includes the
        /// name of the account and the name of the container.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}".
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobContainerClient(Uri blobContainerUri, BlobClientOptions options = default)
            : this(blobContainerUri, (HttpPipelinePolicy)null, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerClient"/>
        /// class.
        /// </summary>
        /// <param name="blobContainerUri">
        /// A <see cref="Uri"/> referencing the blob container that includes the
        /// name of the account and the name of the container.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}".
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobContainerClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
        {
            Argument.AssertNotNull(blobContainerUri, nameof(blobContainerUri));
            HttpPipelinePolicy authPolicy = credential.AsPolicy();
            _uri = blobContainerUri;
            _authenticationPolicy = authPolicy;
            options ??= new BlobClientOptions();

            _clientConfiguration = new BlobClientConfiguration(
                pipeline: options.Build(authPolicy),
                sharedKeyCredential: credential,
                clientDiagnostics: new ClientDiagnostics(options),
                version: options.Version,
                customerProvidedKey: options.CustomerProvidedKey,
                encryptionScope: options.EncryptionScope);

            _clientSideEncryption = options._clientSideEncryptionOptions?.Clone();
            _containerRestClient = BuildContainerRestClient(blobContainerUri);

            BlobErrors.VerifyHttpsCustomerProvidedKey(_uri, _clientConfiguration.CustomerProvidedKey);
            BlobErrors.VerifyCpkAndEncryptionScopeNotBothSet(_clientConfiguration.CustomerProvidedKey, _clientConfiguration.EncryptionScope);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerClient"/>
        /// class.
        /// </summary>
        /// <param name="blobContainerUri">
        /// A <see cref="Uri"/> referencing the blob container that includes the
        /// name of the account and the name of the container.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}".
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
        public BlobContainerClient(Uri blobContainerUri, AzureSasCredential credential, BlobClientOptions options = default)
            : this(blobContainerUri, credential.AsPolicy<BlobUriBuilder>(blobContainerUri), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerClient"/>
        /// class.
        /// </summary>
        /// <param name="blobContainerUri">
        /// A <see cref="Uri"/> referencing the blob container that includes the
        /// name of the account and the name of the container.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}".
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobContainerClient(Uri blobContainerUri, TokenCredential credential, BlobClientOptions options = default)
            : this(blobContainerUri, credential.AsPolicy(), options)
        {
            Errors.VerifyHttpsTokenAuth(blobContainerUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerClient"/>
        /// class.
        /// </summary>
        /// <param name="blobContainerUri">
        /// A <see cref="Uri"/> referencing the blob container that includes the
        /// name of the account and the name of the container.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}".
        /// </param>
        /// <param name="authentication">
        /// An optional authentication policy used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        internal BlobContainerClient(Uri blobContainerUri, HttpPipelinePolicy authentication, BlobClientOptions options)
        {
            Argument.AssertNotNull(blobContainerUri, nameof(blobContainerUri));
            _uri = blobContainerUri;
            _authenticationPolicy = authentication;
            options ??= new BlobClientOptions();

            _clientConfiguration = new BlobClientConfiguration(
                pipeline: options.Build(authentication),
                sharedKeyCredential: null,
                clientDiagnostics: new ClientDiagnostics(options),
                version: options.Version,
                customerProvidedKey: options.CustomerProvidedKey,
                encryptionScope: options.EncryptionScope);

            _clientSideEncryption = options._clientSideEncryptionOptions?.Clone();
            _containerRestClient = BuildContainerRestClient(blobContainerUri);

            BlobErrors.VerifyHttpsCustomerProvidedKey(_uri, _clientConfiguration.CustomerProvidedKey);
            BlobErrors.VerifyCpkAndEncryptionScopeNotBothSet(_clientConfiguration.CustomerProvidedKey, _clientConfiguration.EncryptionScope);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerClient"/>
        /// class.
        /// </summary>
        /// <param name="containerUri">
        /// A <see cref="Uri"/> referencing the blob container that includes the
        /// name of the account and the name of the container.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}".
        /// </param>
        /// <param name="clientConfiguration">
        /// <see cref="BlobClientConfiguration"/>.
        /// </param>
        /// <param name="clientSideEncryption">
        /// Client side encryption.
        /// </param>
        internal BlobContainerClient(
            Uri containerUri,
            BlobClientConfiguration clientConfiguration,
            ClientSideEncryptionOptions clientSideEncryption)
        {
            _uri = containerUri;
            _clientConfiguration = clientConfiguration;
            _authenticationPolicy = StorageClientOptions.GetAuthenticationPolicy(_clientConfiguration.SharedKeyCredential);
            _clientSideEncryption = clientSideEncryption?.Clone();
            _containerRestClient = BuildContainerRestClient(containerUri);

            BlobErrors.VerifyHttpsCustomerProvidedKey(_uri, _clientConfiguration.CustomerProvidedKey);
            BlobErrors.VerifyCpkAndEncryptionScopeNotBothSet(_clientConfiguration.CustomerProvidedKey, _clientConfiguration.EncryptionScope);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerClient"/>
        /// class.
        /// </summary>
        /// <param name="containerUri">
        /// A <see cref="Uri"/> referencing the block blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        /// <returns>
        /// New instance of the <see cref="BlobContainerClient"/> class.
        /// </returns>
        protected static BlobContainerClient CreateClient(Uri containerUri, BlobClientOptions options, HttpPipeline pipeline)
        {
            return new BlobContainerClient(
                containerUri,
                new BlobClientConfiguration(
                    pipeline: pipeline,
                    sharedKeyCredential: null,
                    clientDiagnostics: new ClientDiagnostics(options),
                    version: options.Version,
                    customerProvidedKey: null,
                    encryptionScope: null),
                clientSideEncryption: null);
        }

        private ContainerRestClient BuildContainerRestClient(Uri uri)
        {
            BlobUriBuilder uriBuilder = new BlobUriBuilder(uri);
            string containerName = uriBuilder.BlobContainerName;
            uriBuilder.BlobContainerName = null;

            return new ContainerRestClient(
                clientDiagnostics: _clientConfiguration.ClientDiagnostics,
                pipeline: _clientConfiguration.Pipeline,
                url: uriBuilder.ToString(),
                containerName: containerName,
                version: _clientConfiguration.Version.ToVersionString());
        }
        #endregion ctor

        /// <summary>
        /// Create a new <see cref="BlobBaseClient"/> object by appending
        /// <paramref name="blobName"/> to the end of <see cref="Uri"/>.  The
        /// new <see cref="BlobBaseClient"/> uses the same request policy
        /// pipeline as the <see cref="BlobContainerClient"/>.
        /// </summary>
        /// <param name="blobName">The name of the blob.</param>
        /// <returns>A new <see cref="BlobBaseClient"/> instance.</returns>
        protected internal virtual BlobBaseClient GetBlobBaseClientCore(string blobName)
        {
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(Uri)
            {
                BlobName = blobName
            };

            return new BlobBaseClient(
                blobUriBuilder.ToUri(),
                ClientConfiguration,
                ClientSideEncryption);
        }

        /// <summary>
        /// Create a new <see cref="BlobClient"/> object by appending
        /// <paramref name="blobName"/> to the end of <see cref="Uri"/>.  The
        /// new <see cref="BlobClient"/> uses the same request policy
        /// pipeline as the <see cref="BlobContainerClient"/>.
        /// </summary>
        /// <param name="blobName">The name of the blob.</param>
        /// <returns>A new <see cref="BlobClient"/> instance.</returns>
        public virtual BlobClient GetBlobClient(string blobName)
        {
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(Uri)
            {
                BlobName = blobName
            };

            return new BlobClient(
                blobUriBuilder.ToUri(),
                ClientConfiguration,
                ClientSideEncryption);
        }

        /// <summary>
        /// Create a new <see cref="BlockBlobClient"/> object by
        /// concatenating <paramref name="blobName"/> to
        /// the end of the <see cref="Uri"/>. The new
        /// <see cref="BlockBlobClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="BlobContainerClient"/>.
        /// </summary>
        /// <param name="blobName">The name of the block blob.</param>
        /// <returns>A new <see cref="BlockBlobClient"/> instance.</returns>
        protected internal virtual BlockBlobClient GetBlockBlobClientCore(string blobName)
        {
            if (ClientSideEncryption != default)
            {
                throw Errors.ClientSideEncryption.TypeNotSupported(typeof(BlockBlobClient));
            }

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(Uri)
            {
                BlobName = blobName
            };

            return new BlockBlobClient(
                blobUriBuilder.ToUri(),
                ClientConfiguration);
        }

        /// <summary>
        /// Create a new <see cref="AppendBlobClient"/> object by
        /// concatenating <paramref name="blobName"/> to
        /// the end of the <see cref="BlobContainerClient.Uri"/>. The new
        /// <see cref="AppendBlobClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="BlobContainerClient"/>.
        /// </summary>
        /// <param name="blobName">The name of the append blob.</param>
        /// <returns>A new <see cref="AppendBlobClient"/> instance.</returns>
        protected internal virtual AppendBlobClient GetAppendBlobClientCore(string blobName)
        {
            if (ClientSideEncryption != default)
            {
                throw Errors.ClientSideEncryption.TypeNotSupported(typeof(AppendBlobClient));
            }

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(Uri)
            {
                BlobName = blobName
            };

            return new AppendBlobClient(
                blobUriBuilder.ToUri(),
                ClientConfiguration);
        }

        /// <summary>
        /// Create a new <see cref="PageBlobClient"/> object by
        /// concatenating <paramref name="blobName"/> to
        /// the end of the <see cref="BlobContainerClient.Uri"/>. The new
        /// <see cref="PageBlobClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="BlobContainerClient"/>.
        /// </summary>
        /// <param name="blobName">The name of the page blob.</param>
        /// <returns>A new <see cref="PageBlobClient"/> instance.</returns>
        protected internal virtual PageBlobClient GetPageBlobClientCore(string blobName)
        {
            if (ClientSideEncryption != default)
            {
                throw Errors.ClientSideEncryption.TypeNotSupported(typeof(PageBlobClient));
            }

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(Uri)
            {
                BlobName = blobName
            };

            return new PageBlobClient(
                blobUriBuilder.ToUri(),
                ClientConfiguration);
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
            if (_name == null || _accountName == null)
            {
                var builder = new BlobUriBuilder(Uri);
                _name = builder.BlobContainerName;
                _accountName = builder.AccountName;
            }
        }

        #region Create
        /// <summary>
        /// The <see cref="Create(PublicAccessType, Metadata, BlobContainerEncryptionScopeOptions, CancellationToken)"/>
        /// operation creates a new container
        /// under the specified account. If the container with the same name
        /// already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-container">
        /// Create Container</see>.
        /// </summary>
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
        /// <param name="encryptionScopeOptions">
        /// Optional encryption scope options to set for this container.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerInfo}"/> describing the newly
        /// created blob container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobContainerInfo> Create(
            PublicAccessType publicAccessType = PublicAccessType.None,
            Metadata metadata = default,
            BlobContainerEncryptionScopeOptions encryptionScopeOptions = default,
            CancellationToken cancellationToken = default) =>
            CreateInternal(
                publicAccessType,
                metadata,
                encryptionScopeOptions,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="Create(PublicAccessType, Metadata, CancellationToken)"/> operation creates a new container
        /// under the specified account. If the container with the same name
        /// already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-container">
        /// Create Container</see>.
        /// </summary>
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
        /// A <see cref="Response{BlobContainerInfo}"/> describing the newly
        /// created blob container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BlobContainerInfo> Create(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            PublicAccessType publicAccessType,
            Metadata metadata,
            CancellationToken cancellationToken) =>
            CreateInternal(
                publicAccessType,
                metadata,
                encryptionScopeOptions: default,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="CreateAsync(PublicAccessType, Metadata, BlobContainerEncryptionScopeOptions, CancellationToken)"/>
        /// operation creates a new container under the specified account. If the container with the same name
        /// already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-container">
        /// Create Container</see>.
        /// </summary>
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
        /// <param name="encryptionScopeOptions">
        /// Optional encryption scope options to set for this container.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerInfo}"/> describing the newly
        /// created container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobContainerInfo>> CreateAsync(
            PublicAccessType publicAccessType = PublicAccessType.None,
            Metadata metadata = default,
            BlobContainerEncryptionScopeOptions encryptionScopeOptions = default,
            CancellationToken cancellationToken = default) =>
            await CreateInternal(
                publicAccessType,
                metadata,
                encryptionScopeOptions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CreateAsync(PublicAccessType, Metadata, CancellationToken)"/> operation creates a new container
        /// under the specified account. If the container with the same name
        /// already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-container">
        /// Create Container</see>.
        /// </summary>
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
        /// A <see cref="Response{BlobContainerInfo}"/> describing the newly
        /// created container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BlobContainerInfo>> CreateAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            PublicAccessType publicAccessType,
            Metadata metadata,
            CancellationToken cancellationToken) =>
            await CreateInternal(
                publicAccessType,
                metadata,
                encryptionScopeOptions: default,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CreateIfNotExists(PublicAccessType, Metadata, BlobContainerEncryptionScopeOptions, CancellationToken)"/>
        /// operation creates a new container under the specified account. If the container with the same name
        /// already exists, it is not changed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-container">
        /// Create Container</see>.
        /// </summary>
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
        /// <param name="encryptionScopeOptions">
        /// Optional encryption scope options to set for this container.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// If the container does not already exist, a <see cref="Response{ContainerInfo}"/>
        /// describing the newly created container. If the container already exists, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobContainerInfo> CreateIfNotExists(
            PublicAccessType publicAccessType = PublicAccessType.None,
            Metadata metadata = default,
            BlobContainerEncryptionScopeOptions encryptionScopeOptions = default,
            CancellationToken cancellationToken = default) =>
            CreateIfNotExistsInternal(
                publicAccessType,
                metadata,
                encryptionScopeOptions,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="CreateIfNotExists(PublicAccessType, Metadata, CancellationToken)"/> operation creates a new container
        /// under the specified account. If the container with the same name
        /// already exists, it is not changed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-container">
        /// Create Container</see>.
        /// </summary>
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
        /// If the container does not already exist, a <see cref="Response{ContainerInfo}"/>
        /// describing the newly created container. If the container already exists, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BlobContainerInfo> CreateIfNotExists(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            PublicAccessType publicAccessType,
            Metadata metadata,
            CancellationToken cancellationToken) =>
            CreateIfNotExistsInternal(
                publicAccessType,
                metadata,
                encryptionScopeOptions: default,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="CreateIfNotExistsAsync(PublicAccessType, Metadata, BlobContainerEncryptionScopeOptions, CancellationToken)"/>
        /// operation creates a new container under the specified account. If the container with the same name
        /// already exists, it is not changed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-container">
        /// Create Container</see>.
        /// </summary>
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
        /// <param name="encryptionScopeOptions">
        /// Optional encryption scope options to set for this container.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ContainerInfo}"/> describing the newly
        /// created container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobContainerInfo>> CreateIfNotExistsAsync(
            PublicAccessType publicAccessType = PublicAccessType.None,
            Metadata metadata = default,
            BlobContainerEncryptionScopeOptions encryptionScopeOptions = default,
            CancellationToken cancellationToken = default) =>
            await CreateIfNotExistsInternal(
                publicAccessType,
                metadata,
                encryptionScopeOptions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CreateIfNotExists(PublicAccessType, Metadata, CancellationToken)"/> operation creates a new container
        /// under the specified account. If the container with the same name
        /// already exists, it is not changed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-container">
        /// Create Container</see>.
        /// </summary>
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
        /// A <see cref="Response{ContainerInfo}"/> describing the newly
        /// created container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BlobContainerInfo>> CreateIfNotExistsAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            PublicAccessType publicAccessType,
            Metadata metadata,
            CancellationToken cancellationToken) =>
            await CreateIfNotExistsInternal(
                publicAccessType,
                metadata,
                encryptionScopeOptions: default,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CreateIfNotExistsInternal(PublicAccessType, Metadata, BlobContainerEncryptionScopeOptions, bool, CancellationToken)"/>
        /// operation creates a new container under the specified account.  If the container already exists, it is
        /// not changed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-container">
        /// Create Container</see>.
        /// </summary>
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
        /// <param name="encryptionScopeOptions">
        /// Optional encryption scope options to set for this container.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// If the container does not already exist, a <see cref="Response{ContainerInfo}"/>
        /// describing the newly created container. If the container already exists, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobContainerInfo>> CreateIfNotExistsInternal(
            PublicAccessType publicAccessType,
            Metadata metadata,
            BlobContainerEncryptionScopeOptions encryptionScopeOptions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(publicAccessType)}: {publicAccessType}");

                string operationName = $"{nameof(BlobContainerClient)}.{nameof(CreateIfNotExists)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);
                scope.Start();

                Response <BlobContainerInfo> response;

                try
                {
                    response = await CreateInternal(
                        publicAccessType,
                        metadata,
                        encryptionScopeOptions,
                        async,
                        cancellationToken,
                        operationName)
                        .ConfigureAwait(false);
                }
                catch (RequestFailedException storageRequestFailedException)
                when (storageRequestFailedException.ErrorCode == BlobErrorCode.ContainerAlreadyExists)
                {
                    response = default;
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
                return response;
            }
        }

        /// <summary>
        /// The <see cref="CreateInternal"/> operation creates a new container
        /// under the specified account, if it does not already exist.
        /// If the container with the same name already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-container">
        /// Create Container</see>.
        /// </summary>
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
        /// <param name="encryptionScopeOptions">
        /// Optional encryption scope options to set for this container.
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
        /// A <see cref="Response{ContainerInfo}"/> describing the newly
        /// created container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobContainerInfo>> CreateInternal(
            PublicAccessType publicAccessType,
            Metadata metadata,
            BlobContainerEncryptionScopeOptions encryptionScopeOptions,
            bool async,
            CancellationToken cancellationToken,
#pragma warning disable CA1801 // Review unused parameters
            string operationName = null)
#pragma warning restore CA1801 // Review unused parameters
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(publicAccessType)}: {publicAccessType}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobContainerClient)}.{nameof(Create)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<ContainerCreateHeaders> response;

                    if (async)
                    {
                        response = await ContainerRestClient.CreateAsync(
                            metadata: metadata,
                            access: publicAccessType == PublicAccessType.None ? null : publicAccessType,
                            defaultEncryptionScope: encryptionScopeOptions?.DefaultEncryptionScope,
                            preventEncryptionScopeOverride: encryptionScopeOptions?.PreventEncryptionScopeOverride,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ContainerRestClient.Create(
                            metadata: metadata,
                            access: publicAccessType == PublicAccessType.None ? null : publicAccessType,
                            defaultEncryptionScope: encryptionScopeOptions?.DefaultEncryptionScope,
                            preventEncryptionScopeOverride: encryptionScopeOptions?.PreventEncryptionScopeOverride,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToBlobContainerInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobContainerClient));
                    scope.Dispose();
                }
            }
        }
        #endregion Create

        #region Delete
        /// <summary>
        /// The <see cref="Delete"/> operation marks the specified
        /// container for deletion. The container and any blobs contained
        /// within it are later deleted during garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-container">
        /// Delete Container</see>.
        /// </summary>
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
        public virtual Response Delete(
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            DeleteInternal(
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="DeleteAsync"/> operation marks the specified
        /// container for deletion. The container and any blobs contained
        /// within it are later deleted during garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-container">
        /// Delete Container</see>.
        /// </summary>
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
        public virtual async Task<Response> DeleteAsync(
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await DeleteInternal(
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DeleteIfExists"/> operation marks the specified
        /// container for deletion if it exists. The container and any blobs
        /// contained within it are later deleted during garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-container">
        /// Delete Container</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the deletion of this container.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> Returns true if container exists and was
        /// deleted, return false otherwise.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<bool> DeleteIfExists(
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            DeleteIfExistsInternal(
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="DeleteIfExistsAsync"/> operation marks the specified
        /// container for deletion if it exists. The container and any blobs
        /// contained within it are later deleted during garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-container">
        /// Delete Container</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the deletion of this container.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> Returns true if container exists and was
        /// deleted, return false otherwise.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<bool>> DeleteIfExistsAsync(
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await DeleteIfExistsInternal(
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DeleteIfExistsInternal"/> operation marks the specified
        /// container for deletion if it exists. The container and any blobs
        /// contained within it are later deleted during garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-container">
        /// Delete Container</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the deletion of this container.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> Returns true if container exists and was
        /// deleted, return false otherwise.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<bool>> DeleteIfExistsInternal(
            BlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(conditions)}: {conditions}");

                string operationName = $"{nameof(BlobContainerClient)}.{nameof(DeleteIfExists)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobContainerClient)}.{nameof(DeleteIfExists)}");
                scope.Start();

                try
                {
                    Response response = await DeleteInternal(
                        conditions,
                        async,
                        cancellationToken,
                        operationName)
                        .ConfigureAwait(false);
                    return Response.FromValue(true, response);
                }
                catch (RequestFailedException storageRequestFailedException)
                when (storageRequestFailedException.ErrorCode == BlobErrorCode.ContainerNotFound
                || storageRequestFailedException.ErrorCode == BlobErrorCode.BlobNotFound)
                {
                    return Response.FromValue(false, default);
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

        /// <summary>
        /// The <see cref="DeleteAsync"/> operation marks the specified
        /// container for deletion. The container and any blobs contained
        /// within it are later deleted during garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-container">
        /// Delete Container</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the deletion of this container.
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
        /// A <see cref="Response"/> if successful.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response> DeleteInternal(
            BlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken,
#pragma warning disable CA1801 // Review unused parameters
            string operationName = null)
#pragma warning restore CA1801 // Review unused parameters
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobContainerClient)}.{nameof(Delete)}");

                try
                {
                    scope.Start();

                    if (conditions?.IfMatch != default ||
                        conditions?.IfNoneMatch != default)
                    {
                        throw BlobErrors.BlobConditionsMustBeDefault(nameof(RequestConditions.IfMatch), nameof(RequestConditions.IfNoneMatch));
                    }

                    ResponseWithHeaders<ContainerDeleteHeaders> response;

                    if (async)
                    {
                        response = await ContainerRestClient.DeleteAsync(
                            leaseId: conditions?.LeaseId,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ContainerRestClient.Delete(
                            leaseId: conditions?.LeaseId,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobContainerClient));
                    scope.Dispose();
                }
            }
        }
        #endregion Delete

        #region Exists
        /// <summary>
        /// The <see cref="Exists"/> operation can be called on a
        /// <see cref="BlobContainerClient"/> to see if the associated container
        /// exists on the storage account in the storage service.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns true if the container exists.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs. If you want to create the container if
        /// it doesn't exist, use
        /// <see cref="CreateIfNotExists(PublicAccessType, Metadata, BlobContainerEncryptionScopeOptions, CancellationToken)"/>
        /// instead.
        /// </remarks>
        public virtual Response<bool> Exists(
            CancellationToken cancellationToken = default) =>
            ExistsInternal(
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// The <see cref="ExistsAsync"/> operation can be called on a
        /// <see cref="BlobContainerClient"/> to see if the associated container
        /// exists on the storage account in the storage service.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns true if the container exists.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs. If you want to create the container if
        /// it doesn't exist, use
        /// <see cref="CreateIfNotExists(PublicAccessType, Metadata, BlobContainerEncryptionScopeOptions, CancellationToken)"/>
        /// instead.
        /// </remarks>
        public virtual async Task<Response<bool>> ExistsAsync(
            CancellationToken cancellationToken = default) =>
            await ExistsInternal(
                async: true,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="ExistsInternal"/> operation can be called on a
        /// <see cref="BlobContainerClient"/> to see if the associated container
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
        /// Returns true if the container exists.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<bool>> ExistsInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobContainerClient)}.{nameof(Exists)}");
                scope.Start();

                try
                {
                    Response<BlobContainerProperties> response =  await GetPropertiesInternal(
                        conditions: null,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return Response.FromValue(true, response.GetRawResponse());
                }
                catch (RequestFailedException storageRequestFailedException)
                when (storageRequestFailedException.ErrorCode == BlobErrorCode.ContainerNotFound)
                {
                    return Response.FromValue(false, default);
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
        #endregion Exists

        #region GetProperties
        /// <summary>
        /// The <see cref="GetProperties"/> operation returns all
        /// user-defined metadata and system properties for the specified
        /// container. The data returned does not include the container's
        /// list of blobs.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-container-properties">
        /// Get Container Properties</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on getting the blob container's properties.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerProperties}"/> describing the
        /// container and its properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobContainerProperties> GetProperties(
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            GetPropertiesInternal(
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetPropertiesAsync"/> operation returns all
        /// user-defined metadata and system properties for the specified
        /// container. The data returned does not include the container's
        /// list of blobs.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-container-properties">
        /// Get Container Properties</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on getting the blob container's properties.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerProperties}"/> describing the
        /// container and its properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobContainerProperties>> GetPropertiesAsync(
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await GetPropertiesInternal(
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetPropertiesAsync"/> operation returns all
        /// user-defined metadata and system properties for the specified
        /// container. The data returned does not include the container's
        /// list of blobs.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-container-properties">
        /// Get Container Properties</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on getting the blob container's properties.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerItem}"/> describing the
        /// container and its properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobContainerProperties>> GetPropertiesInternal(
            BlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobContainerClient)}.{nameof(GetProperties)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<ContainerGetPropertiesHeaders> response;

                    if (async)
                    {
                        response = await ContainerRestClient.GetPropertiesAsync(
                            leaseId: conditions?.LeaseId,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ContainerRestClient.GetProperties(
                            leaseId: conditions?.LeaseId,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToBlobContainerProperties(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobContainerClient));
                    scope.Dispose();
                }
            }
        }
        #endregion GetProperties

        #region SetMetadata
        /// <summary>
        /// The <see cref="SetMetadata"/> operation sets one or more
        /// user-defined name-value pairs for the specified container.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-container-metadata">
        /// Set Container Metadata</see>.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this container.
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
        /// A <see cref="Response{BlobContainerInfo}"/> if successful.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobContainerInfo> SetMetadata(
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
        /// The <see cref="SetMetadataAsync"/> operation sets one or more
        /// user-defined name-value pairs for the specified container.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-container-metadata">
        /// Set Container Metadata</see>.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this container.
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
        /// A <see cref="Response{BlobContainerInfo}"/> if successful.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobContainerInfo>> SetMetadataAsync(
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
        /// The <see cref="SetMetadataInternal"/> operation sets one or more
        /// user-defined name-value pairs for the specified container.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-container-metadata">
        /// Set Container Metadata</see>.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this container.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the deletion of this container.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerInfo}"/> if successful.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobContainerInfo>> SetMetadataInternal(
            Metadata metadata,
            BlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobContainerClient)}.{nameof(SetMetadata)}");

                try
                {
                    scope.Start();

                    if (conditions?.IfUnmodifiedSince != default ||
                        conditions?.IfMatch != default ||
                        conditions?.IfNoneMatch != default)
                    {
                        throw BlobErrors.BlobConditionsMustBeDefault(
                            nameof(RequestConditions.IfUnmodifiedSince),
                            nameof(RequestConditions.IfMatch),
                            nameof(RequestConditions.IfNoneMatch));
                    }

                    ResponseWithHeaders<ContainerSetMetadataHeaders> response;

                    if (async)
                    {
                        response = await ContainerRestClient.SetMetadataAsync(
                            leaseId: conditions?.LeaseId,
                            metadata: metadata,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ContainerRestClient.SetMetadata(
                            leaseId: conditions?.LeaseId,
                            metadata: metadata,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToBlobContainerInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobContainerClient));
                    scope.Dispose();
                }
            }
        }
        #endregion SetMetadata

        #region GetAccessPolicy
        /// <summary>
        /// The <see cref="GetAccessPolicy"/> operation gets the
        /// permissions for this container. The permissions indicate whether
        /// container data may be accessed publicly.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-container-acl">
        /// Get Container ACL</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on getting the blob container's access policy.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerAccessPolicy}"/> describing
        /// the container's access policy.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobContainerAccessPolicy> GetAccessPolicy(
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            GetAccessPolicyInternal(
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetAccessPolicyAsync"/> operation gets the
        /// permissions for this container. The permissions indicate whether
        /// container data may be accessed publicly.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-container-acl">
        /// Get Container ACL</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on getting the blob container's access policy.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerAccessPolicy}"/> describing
        /// the container's access policy.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobContainerAccessPolicy>> GetAccessPolicyAsync(
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await GetAccessPolicyInternal(
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetAccessPolicyAsync"/> operation gets the
        /// permissions for this container. The permissions indicate whether
        /// container data may be accessed publicly.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-container-acl">
        /// Get Container ACL</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on getting the blob container's access policy.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerAccessPolicy}"/> describing
        /// the container's access policy.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobContainerAccessPolicy>> GetAccessPolicyInternal(
            BlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobContainerClient)}.{nameof(GetAccessPolicy)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<IReadOnlyList<BlobSignedIdentifier>, ContainerGetAccessPolicyHeaders> response;

                    if (async)
                    {
                        response = await ContainerRestClient.GetAccessPolicyAsync(
                            leaseId: conditions?.LeaseId,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ContainerRestClient.GetAccessPolicy(
                            leaseId: conditions?.LeaseId,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToBlobContainerAccessPolicy(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobContainerClient));
                    scope.Dispose();
                }
            }
        }
        #endregion GetAccessPolicy

        #region SetAccessPolicy
        /// <summary>
        /// The <see cref="SetAccessPolicy"/> operation sets the
        /// permissions for the specified container. The permissions indicate
        /// whether blob container data may be accessed publicly.
        ///
        /// For more information, see
        /// <see href=" https://docs.microsoft.com/rest/api/storageservices/set-container-acl">
        /// Set Container ACL</see>.
        /// </summary>
        /// <param name="accessType">
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
        /// <param name="permissions">
        /// Stored access policies that you can use to provide fine grained
        /// control over container permissions.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on setting this blob container's access policy.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerInfo}"/> describing the
        /// updated container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobContainerInfo> SetAccessPolicy(
            PublicAccessType accessType = PublicAccessType.None,
            IEnumerable<BlobSignedIdentifier> permissions = default,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            SetAccessPolicyInternal(
                accessType,
                permissions,
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="SetAccessPolicyAsync"/> operation sets the
        /// permissions for the specified container. The permissions indicate
        /// whether blob container data may be accessed publicly.
        ///
        /// For more information, see
        /// <see href=" https://docs.microsoft.com/rest/api/storageservices/set-container-acl">
        /// Set Container ACL</see>.
        /// </summary>
        /// <param name="accessType">
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
        /// <param name="permissions">
        /// Stored access policies that you can use to provide fine grained
        /// control over container permissions.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on setting this blob container's access policy.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerInfo}"/> describing the
        /// updated container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobContainerInfo>> SetAccessPolicyAsync(
            PublicAccessType accessType = PublicAccessType.None,
            IEnumerable<BlobSignedIdentifier> permissions = default,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await SetAccessPolicyInternal(
                accessType,
                permissions,
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetAccessPolicyAsync"/> operation sets the
        /// permissions for the specified container. The permissions indicate
        /// whether blob container data may be accessed publicly.
        ///
        /// For more information, see
        /// <see href=" https://docs.microsoft.com/rest/api/storageservices/set-container-acl">
        /// Set Container ACL</see>.
        /// </summary>
        /// <param name="accessType">
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
        /// <param name="permissions">
        /// Stored access policies that you can use to provide fine grained
        /// control over container permissions.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on setting this blob container's access policy.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerInfo}"/> describing the
        /// updated container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobContainerInfo>> SetAccessPolicyInternal(
            PublicAccessType accessType,
            IEnumerable<BlobSignedIdentifier> permissions,
            BlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(accessType)}: {accessType}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobContainerClient)}.{nameof(SetAccessPolicy)}");

                try
                {
                    scope.Start();

                    if (conditions?.IfMatch != default ||
                        conditions?.IfNoneMatch != default)
                    {
                        throw BlobErrors.BlobConditionsMustBeDefault(nameof(RequestConditions.IfMatch), nameof(RequestConditions.IfNoneMatch));
                    }

                    List<BlobSignedIdentifier> sanitizedPermissions = null;
                    if (permissions != null)
                    {
                        sanitizedPermissions = new List<BlobSignedIdentifier>();

                        foreach (BlobSignedIdentifier signedIdentifier in permissions)
                        {
                            signedIdentifier.AccessPolicy.Permissions = SasExtensions.ValidateAndSanitizeRawPermissions(
                                signedIdentifier.AccessPolicy.Permissions,
                                Constants.Sas.ValidPermissionsInOrder);

                            sanitizedPermissions.Add(signedIdentifier);
                        }
                    }

                    ResponseWithHeaders<ContainerSetAccessPolicyHeaders> response;

                    if (async)
                    {
                        response = await ContainerRestClient.SetAccessPolicyAsync(
                            leaseId: conditions?.LeaseId,
                            access: accessType == PublicAccessType.None ? null : accessType,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            containerAcl: sanitizedPermissions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ContainerRestClient.SetAccessPolicy(
                            leaseId: conditions?.LeaseId,
                            access: accessType == PublicAccessType.None ? null : accessType,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            containerAcl: sanitizedPermissions,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToBlobContainerInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobContainerClient));
                    scope.Dispose();
                }
            }
        }
        #endregion SetAccessPolicy

        #region GetBlobs
        /// <summary>
        /// The <see cref="GetBlobs"/> operation returns an async sequence
        /// of blobs in this container.  Enumerating the blobs may make
        /// multiple requests to the service while fetching all the values.
        /// Blobs are ordered lexicographically by name.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-blobs">
        /// List Blobs</see>.
        /// </summary>
        /// <param name="traits">
        /// Specifies trait options for shaping the blobs.
        /// </param>
        /// <param name="states">
        /// Specifies state options for filtering the blobs.
        /// </param>
        /// <param name="prefix">
        /// Specifies a string that filters the results to return only blobs
        /// whose name begins with the specified <paramref name="prefix"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="Pageable{T}"/> of <see cref="BlobItem"/>
        /// describing the blobs in the container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Pageable<BlobItem> GetBlobs(
            BlobTraits traits = BlobTraits.None,
            BlobStates states = BlobStates.None,
            string prefix = default,
            CancellationToken cancellationToken = default) =>
            new GetBlobsAsyncCollection(this, traits, states, prefix).ToSyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetBlobsAsync"/> operation returns an async
        /// sequence of blobs in this container.  Enumerating the blobs may
        /// make multiple requests to the service while fetching all the
        /// values.  Blobs are ordered lexicographically by name.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-blobs">
        /// List Blobs</see>.
        /// </summary>
        /// <param name="traits">
        /// Specifies trait options for shaping the blobs.
        /// </param>
        /// <param name="states">
        /// Specifies state options for filtering the blobs.
        /// </param>
        /// <param name="prefix">
        /// Specifies a string that filters the results to return only blobs
        /// whose name begins with the specified <paramref name="prefix"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="AsyncPageable{T}"/> describing the
        /// blobs in the container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual AsyncPageable<BlobItem> GetBlobsAsync(
            BlobTraits traits = BlobTraits.None,
            BlobStates states = BlobStates.None,
            string prefix = default,
            CancellationToken cancellationToken = default) =>
            new GetBlobsAsyncCollection(this, traits, states, prefix).ToAsyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetBlobsInternal"/> operation returns a
        /// single segment of blobs in this container, starting
        /// from the specified <paramref name="marker"/>.  Use an empty
        /// <paramref name="marker"/> to start enumeration from the beginning
        /// and the <see cref="ListBlobsFlatSegmentResponse.NextMarker"/> if it's not
        /// empty to make subsequent calls to <see cref="GetBlobsAsync"/>
        /// to continue enumerating the blobs segment by segment. Blobs are
        /// ordered lexicographically by name.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-blobs">
        /// List Blobs</see>.
        /// </summary>
        /// <param name="marker">
        /// An optional string value that identifies the segment of the list
        /// of blobs to be returned with the next listing operation.  The
        /// operation returns a non-empty <see cref="ListBlobsFlatSegmentResponse.NextMarker"/>
        /// if the listing operation did not return all blobs remaining to be
        /// listed with the current segment.  The NextMarker value can
        /// be used as the value for the <paramref name="marker"/> parameter
        /// in a subsequent call to request the next segment of list items.
        /// </param>
        /// <param name="traits">
        /// Specifies trait options for shaping the blobs.
        /// </param>
        /// <param name="states">
        /// Specifies state options for filtering the blobs.
        /// </param>
        /// <param name="prefix">
        /// Specifies a string that filters the results to return only blobs
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
        /// A <see cref="Response{BlobsFlatSegment}"/> describing a
        /// segment of the blobs in the container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<Response<ListBlobsFlatSegmentResponse>> GetBlobsInternal(
            string marker,
            BlobTraits traits,
            BlobStates states,
            string prefix,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(marker)}: {marker}\n" +
                    $"{nameof(traits)}: {traits}\n" +
                    $"{nameof(states)}: {states}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobContainerClient)}.{nameof(GetBlobs)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<ListBlobsFlatSegmentResponse, ContainerListBlobFlatSegmentHeaders> response;

                    if (async)
                    {
                        response = await ContainerRestClient.ListBlobFlatSegmentAsync(
                            prefix: prefix,
                            marker: marker,
                            maxresults: pageSizeHint,
                            include: BlobExtensions.AsIncludeItems(traits, states),
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ContainerRestClient.ListBlobFlatSegment(
                            prefix: prefix,
                            marker: marker,
                            maxresults: pageSizeHint,
                            include: BlobExtensions.AsIncludeItems(traits, states),
                            cancellationToken: cancellationToken);
                    }

                    ListBlobsFlatSegmentResponse listblobFlatResponse = response.Value;

                    if ((traits & BlobTraits.Metadata) != BlobTraits.Metadata)
                    {
                        List<BlobItemInternal> blobItemInternals = response.Value.Segment.BlobItems.Select(r => new BlobItemInternal(
                            r.Name,
                            r.Deleted,
                            r.Snapshot,
                            r.VersionId,
                            r.IsCurrentVersion,
                            r.Properties,
                            metadata: null,
                            r.BlobTags,
                            r.ObjectReplicationMetadata))
                            .ToList();
                    }

                    return Response.FromValue(
                        listblobFlatResponse,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobContainerClient));
                    scope.Dispose();
                }
            }
        }
        #endregion GetBlobs

        #region GetBlobsByHierarchy
        /// <summary>
        /// The <see cref="GetBlobsByHierarchy"/> operation returns
        /// an async collection of blobs in this container.  Enumerating the
        /// blobs may make multiple requests to the service while fetching all
        /// the values.  Blobs are ordered lexicographically by name.   A
        /// <paramref name="delimiter"/> can be used to traverse a virtual
        /// hierarchy of blobs as though it were a file system.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-blobs">
        /// List Blobs</see>.
        /// </summary>
        /// <param name="traits">
        /// Specifies trait options for shaping the blobs.
        /// </param>
        /// <param name="states">
        /// Specifies state options for filtering the blobs.
        /// </param>
        /// <param name="delimiter">
        /// A <paramref name="delimiter"/> that can be used to traverse a
        /// virtual hierarchy of blobs as though it were a file system.  The
        /// delimiter may be a single character or a string.
        /// <see cref="BlobHierarchyItem.Prefix"/> will be returned
        /// in place of all blobs whose names begin with the same substring up
        /// to the appearance of the delimiter character.  The value of a
        /// prefix is substring+delimiter, where substring is the common
        /// substring that begins one or more blob  names, and delimiter is the
        /// value of <paramref name="delimiter"/>. You can use the value of
        /// prefix to make a subsequent call to list the blobs that begin with
        /// this prefix, by specifying the value of the prefix for the
        /// <paramref name="prefix"/>.
        ///
        /// Note that each BlobPrefix element returned counts toward the
        /// maximum result, just as each Blob element does.
        /// </param>
        /// <param name="prefix">
        /// Specifies a string that filters the results to return only blobs
        /// whose name begins with the specified <paramref name="prefix"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="Pageable{T}"/> of <see cref="BlobHierarchyItem"/>
        /// describing the blobs in the container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Pageable<BlobHierarchyItem> GetBlobsByHierarchy(
            BlobTraits traits = BlobTraits.None,
            BlobStates states = BlobStates.None,
            string delimiter = default,
            string prefix = default,
            CancellationToken cancellationToken = default) =>
            new GetBlobsByHierarchyAsyncCollection(this, delimiter, traits, states, prefix).ToSyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetBlobsByHierarchyAsync"/> operation returns
        /// an async collection of blobs in this container.  Enumerating the
        /// blobs may make multiple requests to the service while fetching all
        /// the values.  Blobs are ordered lexicographically by name.   A
        /// <paramref name="delimiter"/> can be used to traverse a virtual
        /// hierarchy of blobs as though it were a file system.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-blobs">
        /// List Blobs</see>.
        /// </summary>
        /// <param name="traits">
        /// Specifies trait options for shaping the blobs.
        /// </param>
        /// <param name="states">
        /// Specifies state options for filtering the blobs.
        /// </param>
        /// <param name="delimiter">
        /// A <paramref name="delimiter"/> that can be used to traverse a
        /// virtual hierarchy of blobs as though it were a file system.  The
        /// delimiter may be a single character or a string.
        /// <see cref="BlobHierarchyItem.Prefix"/> will be returned
        /// in place of all blobs whose names begin with the same substring up
        /// to the appearance of the delimiter character.  The value of a
        /// prefix is substring+delimiter, where substring is the common
        /// substring that begins one or more blob  names, and delimiter is the
        /// value of <paramref name="delimiter"/>. You can use the value of
        /// prefix to make a subsequent call to list the blobs that begin with
        /// this prefix, by specifying the value of the prefix for the
        /// <paramref name="prefix"/>.
        ///
        /// Note that each BlobPrefix element returned counts toward the
        /// maximum result, just as each Blob element does.
        /// </param>
        /// <param name="prefix">
        /// Specifies a string that filters the results to return only blobs
        /// whose name begins with the specified <paramref name="prefix"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="AsyncPageable{T}"/> describing the
        /// blobs in the container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual AsyncPageable<BlobHierarchyItem> GetBlobsByHierarchyAsync(
            BlobTraits traits = BlobTraits.None,
            BlobStates states = BlobStates.None,
            string delimiter = default,
            string prefix = default,
            CancellationToken cancellationToken = default) =>
            new GetBlobsByHierarchyAsyncCollection(this, delimiter, traits, states, prefix).ToAsyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetBlobsByHierarchyInternal"/> operation returns
        /// a single segment of blobs in this container, starting
        /// from the specified <paramref name="marker"/>.  Use an empty
        /// <paramref name="marker"/> to start enumeration from the beginning
        /// and the <see cref="ListBlobsHierarchySegmentResponse.NextMarker"/> if it's not
        /// empty to make subsequent calls to <see cref="GetBlobsByHierarchyAsync"/>
        /// to continue enumerating the blobs segment by segment. Blobs are
        /// ordered lexicographically by name.   A <paramref name="delimiter"/>
        /// can be used to traverse a virtual hierarchy of blobs as though
        /// it were a file system.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-blobs">
        /// List Blobs</see>.
        /// </summary>
        /// <param name="marker">
        /// An optional string value that identifies the segment of the list
        /// of blobs to be returned with the next listing operation.  The
        /// operation returns a non-empty <see cref="ListBlobsHierarchySegmentResponse.NextMarker"/>
        /// if the listing operation did not return all blobs remaining to be
        /// listed with the current segment.  The NextMarker value can
        /// be used as the value for the <paramref name="marker"/> parameter
        /// in a subsequent call to request the next segment of list items.
        /// </param>
        /// <param name="delimiter">
        /// A <paramref name="delimiter"/> that can be used to traverse a
        /// virtual hierarchy of blobs as though it were a file system.  The
        /// delimiter may be a single character or a string.
        /// <see cref="BlobHierarchyItem.Prefix"/> will be returned
        /// in place of all blobs whose names begin with the same substring up
        /// to the appearance of the delimiter character.  The value of a
        /// prefix is substring+delimiter, where substring is the common
        /// substring that begins one or more blob  names, and delimiter is the
        /// value of <paramref name="delimiter"/>. You can use the value of
        /// prefix to make a subsequent call to list the blobs that begin with
        /// this prefix, by specifying the value of the prefix for the
        /// <paramref name="prefix"/>.
        ///
        /// Note that each BlobPrefix element returned counts toward the
        /// maximum result, just as each Blob element does.
        /// </param>
        /// <param name="traits">
        /// Specifies trait options for shaping the blobs.
        /// </param>
        /// <param name="states">
        /// Specifies state options for filtering the blobs.
        /// </param>
        /// <param name="prefix">
        /// Specifies a string that filters the results to return only blobs
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
        /// A <see cref="Response{BlobsHierarchySegment}"/> describing a
        /// segment of the blobs in the container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<Response<ListBlobsHierarchySegmentResponse>> GetBlobsByHierarchyInternal(
            string marker,
            string delimiter,
            BlobTraits traits,
            BlobStates states,
            string prefix,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(marker)}: {marker}\n" +
                    $"{nameof(delimiter)}: {delimiter}\n" +
                    $"{nameof(traits)}: {traits}\n" +
                    $"{nameof(states)}: {states}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobContainerClient)}.{nameof(GetBlobsByHierarchy)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<ListBlobsHierarchySegmentResponse, ContainerListBlobHierarchySegmentHeaders> response;

                    if (async)
                    {
                        response = await ContainerRestClient.ListBlobHierarchySegmentAsync(
                            delimiter: delimiter,
                            prefix: prefix,
                            marker: marker,
                            maxresults: pageSizeHint,
                            include: BlobExtensions.AsIncludeItems(traits, states),
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ContainerRestClient.ListBlobHierarchySegment(
                            delimiter: delimiter,
                            prefix: prefix,
                            marker: marker,
                            maxresults: pageSizeHint,
                            include: BlobExtensions.AsIncludeItems(traits, states),
                            cancellationToken: cancellationToken);
                    }

                    ListBlobsHierarchySegmentResponse listblobHierachyResponse = response.Value;

                    if ((traits & BlobTraits.Metadata) != BlobTraits.Metadata)
                    {
                        List<BlobItemInternal> blobItemInternals = response.Value.Segment.BlobItems.Select(r => new BlobItemInternal(
                            r.Name,
                            r.Deleted,
                            r.Snapshot,
                            r.VersionId,
                            r.IsCurrentVersion,
                            r.Properties,
                            metadata: null,
                            r.BlobTags,
                            r.ObjectReplicationMetadata))
                            .ToList();
                    }

                    return Response.FromValue(
                        listblobHierachyResponse,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobContainerClient));
                    scope.Dispose();
                }
            }
        }
        #endregion GetBlobsByHierarchy

        #region UploadBlob
        /// <summary>
        /// The <see cref="UploadBlobAsync"/> operation creates a new block
        /// blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="blobName">The name of the blob to upload.</param>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown
        /// if the blob already exists.  To overwrite an existing block blob,
        /// get a <see cref="BlobClient"/> by calling <see cref="GetBlobClient(string)"/>,
        /// and then call <see cref="BlobClient.UploadAsync(Stream, bool, CancellationToken)"/>
        /// with the override parameter set to true.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<BlobContentInfo> UploadBlob(
            string blobName,
            Stream content,
            CancellationToken cancellationToken = default) =>
            GetBlobClient(blobName)
                .Upload(
                    content,
                    cancellationToken);

        /// <summary>
        /// The <see cref="UploadBlob"/> operation creates a new block
        /// blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="blobName">The name of the blob to upload.</param>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown
        /// if the blob already exists.  To overwrite an existing block blob,
        /// get a <see cref="BlobClient"/> by calling <see cref="GetBlobClient(string)"/>,
        /// and then call <see cref="BlobClient.Upload(Stream, bool, CancellationToken)"/>
        /// with the override parameter set to true.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<BlobContentInfo>> UploadBlobAsync(
            string blobName,
            Stream content,
            CancellationToken cancellationToken = default) =>
            await GetBlobClient(blobName)
                .UploadAsync(
                    content,
                    cancellationToken)
                    .ConfigureAwait(false);
        #endregion UploadBlob

        #region DeleteBlob
        /// <summary>
        /// The <see cref="DeleteBlob"/> operation marks the specified
        /// blob or snapshot for deletion. The blob is later deleted during
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
        /// <param name="blobName">The name of the blob to delete.</param>
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
        [ForwardsClientCalls]
        public virtual Response DeleteBlob(
            string blobName,
            DeleteSnapshotsOption snapshotsOption = default,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            GetBlobClient(blobName)
                .Delete(
                    snapshotsOption,
                    conditions,
                    cancellationToken);

        /// <summary>
        /// The <see cref="DeleteBlobAsync"/> operation marks the specified
        /// blob or snapshot for deletion. The blob is later deleted during
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
        /// <param name="blobName">The name of the blob to delete.</param>
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
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteBlobAsync(
            string blobName,
            DeleteSnapshotsOption snapshotsOption = default,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await GetBlobClient(blobName)
                .DeleteAsync(
                    snapshotsOption,
                    conditions,
                    cancellationToken)
                    .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DeleteBlobIfExists"/> operation marks the specified
        /// blob or snapshot for deletion, if the blob or snapshot exists. The blob
        /// is later deleted during garbage collection.
        ///
        /// Note that in order to delete a blob, you must delete all of its
        /// snapshots. You can delete both at the same time using
        /// <see cref="DeleteSnapshotsOption.IncludeSnapshots"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-blob">
        /// Delete Blob</see>.
        /// </summary>
        /// <param name="blobName">The name of the blob to delete.</param>
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
        [ForwardsClientCalls]
        public virtual Response<bool> DeleteBlobIfExists(
            string blobName,
            DeleteSnapshotsOption snapshotsOption = default,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
                GetBlobClient(blobName).
                DeleteIfExists(
                    snapshotsOption,
                    conditions ?? default,
                    cancellationToken);

        /// <summary>
        /// The <see cref="DeleteBlobIfExistsAsync"/> operation marks the specified
        /// blob or snapshot for deletion, if the blob or snapshot exists. The blob
        /// is later deleted during garbage collection.
        ///
        /// Note that in order to delete a blob, you must delete all of its
        /// snapshots. You can delete both at the same time using
        /// <see cref="DeleteSnapshotsOption.IncludeSnapshots"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-blob">
        /// Delete Blob</see>.
        /// </summary>
        /// <param name="blobName">The name of the blob to delete.</param>
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
        [ForwardsClientCalls]
        public virtual async Task<Response<bool>> DeleteBlobIfExistsAsync(
            string blobName,
            DeleteSnapshotsOption snapshotsOption = default,
            BlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await GetBlobClient(blobName).DeleteIfExistsAsync(
                    snapshotsOption,
                    conditions ?? default,
                    cancellationToken)
                    .ConfigureAwait(false);

        #endregion DeleteBlob

        #region Rename
        /// <summary>
        /// Renames an existing Blob Container.
        /// </summary>
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
        /// </remarks>
        internal virtual Response<BlobContainerClient> Rename(
            string destinationContainerName,
            BlobRequestConditions sourceConditions = default,
            CancellationToken cancellationToken = default)
            => RenameInternal(
                destinationContainerName,
                sourceConditions,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Renames an existing Blob Container.
        /// </summary>
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
        /// </remarks>
        internal virtual async Task<Response<BlobContainerClient>> RenameAsync(
            string destinationContainerName,
            BlobRequestConditions sourceConditions = default,
            CancellationToken cancellationToken = default)
            => await RenameInternal(
                destinationContainerName,
                sourceConditions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Renames an existing Blob Container.
        /// </summary>
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
        /// </remarks>
        internal async Task<Response<BlobContainerClient>> RenameInternal(
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
                    $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobContainerClient)}.{nameof(Rename)}");

                try
                {
                    scope.Start();

                    BlobUriBuilder uriBuilder = new BlobUriBuilder(Uri)
                    {
                        BlobContainerName = destinationContainerName
                    };
                    BlobContainerClient destContainerClient = new BlobContainerClient(
                        uriBuilder.ToUri(),
                        ClientConfiguration,
                        ClientSideEncryption);

                    ResponseWithHeaders<ContainerRenameHeaders> response;

                    if (async)
                    {
                        response = await destContainerClient.ContainerRestClient.RenameAsync(
                            sourceContainerName: Name,
                            sourceLeaseId: sourceConditions?.LeaseId,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = destContainerClient.ContainerRestClient.Rename(
                            sourceContainerName: Name,
                            sourceLeaseId: sourceConditions?.LeaseId,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        destContainerClient,
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
        #endregion Rename

        #region GenerateSas
        /// <summary>
        /// The <see cref="GenerateSasUri(BlobContainerSasPermissions, DateTimeOffset)"/>
        /// returns a <see cref="Uri"/> that generates a Blob Container Service
        /// Shared Access Signature (SAS) Uri based on the Client properties
        /// and parameters passed. The SAS is signed by the shared key credential
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
        /// See <see cref="BlobContainerSasPermissions"/>.
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
        public virtual Uri GenerateSasUri(BlobContainerSasPermissions permissions, DateTimeOffset expiresOn) =>
            GenerateSasUri(new BlobSasBuilder(permissions, expiresOn) { BlobContainerName = Name });

        /// <summary>
        /// The <see cref="GenerateSasUri(BlobSasBuilder)"/> returns a <see cref="Uri"/>
        /// that generates a Blob Container Service Shared Access Signature (SAS) Uri
        /// based on the Client properties and builder passed. The SAS is signed by
        /// the shared key credential of the client.
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
        /// A <see cref="Exception"/> will be thrown if a failure occurs.
        /// </remarks>
        public virtual Uri GenerateSasUri(BlobSasBuilder builder)
        {
            builder = builder ?? throw Errors.ArgumentNull(nameof(builder));
            if (!builder.BlobContainerName.Equals(Name, StringComparison.InvariantCulture))
            {
                throw Errors.SasNamesNotMatching(
                    nameof(builder.BlobContainerName),
                    nameof(BlobSasBuilder),
                    nameof(Name));
            }
            if (!string.IsNullOrEmpty(builder.BlobName))
            {
                throw Errors.SasBuilderEmptyParam(
                    nameof(builder),
                    nameof(builder.BlobName),
                    nameof(Constants.Blob.Container.Name));
            }
            BlobUriBuilder sasUri = new BlobUriBuilder(Uri)
            {
                Query = builder.ToSasQueryParameters(ClientConfiguration.SharedKeyCredential).ToString()
            };
            return sasUri.ToUri();
        }
        #endregion

        #region GetParentBlobServiceClientCore

        private BlobServiceClient _parentBlobServiceClient;

        /// <summary>
        /// Create a new <see cref="BlobServiceClient"/> that pointing to this <see cref="BlobContainerClient"/>'s blob service.
        /// The new <see cref="BlobServiceClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="BlobContainerClient"/>.
        /// </summary>
        /// <returns>A new <see cref="BlobServiceClient"/> instance.</returns>
        protected internal virtual BlobServiceClient GetParentBlobServiceClientCore()
        {
            if (_parentBlobServiceClient == null)
            {
                BlobUriBuilder blobUriBuilder = new BlobUriBuilder(Uri)
                {
                    // erase parameters unrelated to service
                    BlobContainerName = null,
                    BlobName = null,
                    VersionId = null,
                    Snapshot = null,
                };

                _parentBlobServiceClient = new BlobServiceClient(
                    blobUriBuilder.ToUri(),
                    ClientConfiguration,
                    AuthenticationPolicy,
                    ClientSideEncryption);
            }

            return _parentBlobServiceClient;
        }
        #endregion
    }

    namespace Specialized
    {
        /// <summary>
        /// Add easy to discover methods to <see cref="BlobContainerClient"/> for
        /// creating <see cref="BlobServiceClient"/> instances.
        /// </summary>
        public static partial class SpecializedBlobExtensions
        {
            /// <summary>
            /// Create a new <see cref="BlobServiceClient"/> that pointing to this <see cref="BlobContainerClient"/>'s blob service.
            /// The new <see cref="BlobServiceClient"/>
            /// uses the same request policy pipeline as the
            /// <see cref="BlobContainerClient"/>.
            /// </summary>
            /// <returns>A new <see cref="BlobServiceClient"/> instance.</returns>
            public static BlobServiceClient GetParentBlobServiceClient(this BlobContainerClient client)
            {
                return client.GetParentBlobServiceClientCore();
            }
        }
    }
}
