// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Files.DataLake.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using System.Text.Json;
using System.Collections.Generic;
using Azure.Storage.Shared;
using Azure.Storage.Sas;
using System.ComponentModel;

namespace Azure.Storage.Files.DataLake
{
    /// <summary>
    /// The <see cref="DataLakeFileSystemClient"/> allows you to manipulate Azure
    /// Data Lake file systems and their directories and files.
    /// </summary>
    public class DataLakeFileSystemClient
    {
        /// <summary>
        /// A <see cref="BlobContainerClient"/> assoicated with the file system.
        /// </summary>
        internal readonly BlobContainerClient _containerClient;

        /// <summary>
        /// ContainerClient.
        /// </summary>
        internal virtual BlobContainerClient ContainerClient => _containerClient;

        /// <summary>
        /// The file systems's user-provided <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _uri;

        /// <summary>
        /// The file system's blob <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _blobUri;

        /// <summary>
        /// The path's dfs <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _dfsUri;

        /// <summary>
        /// Gets the file systems's primary <see cref="Uri"/> endpoint.
        /// </summary>
        public virtual Uri Uri => _uri;

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send
        /// every request.
        /// </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary>
        /// Gets the <see cref="HttpPipeline"/> transport pipeline used to send
        /// every request.
        /// </summary>
        internal virtual HttpPipeline Pipeline => _pipeline;

        /// <summary>
        /// The version of the service to use when sending requests.
        /// </summary>
        private readonly DataLakeClientOptions.ServiceVersion _version;

        /// <summary>
        /// The version of the service to use when sending requests.
        /// </summary>
        internal virtual DataLakeClientOptions.ServiceVersion Version => _version;

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
        /// The Storage account name corresponding to the share client.
        /// </summary>
        private string _accountName;

        /// <summary>
        /// Gets the Storage account name corresponding to the share client.
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
        /// The name of the file system.
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets the name of the file system.
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
        public bool CanGenerateSasUri => SharedKeyCredential != null;

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileSystemClient"/>
        /// class for mocking.
        /// </summary>
        protected DataLakeFileSystemClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileSystemClient"/>
        /// class.
        /// </summary>
        /// <param name="fileSystemUri">
        /// A <see cref="Uri"/> referencing the share that includes the
        /// name of the account and the name of the file system.
        /// </param>
        public DataLakeFileSystemClient(Uri fileSystemUri)
            : this(fileSystemUri, (HttpPipelinePolicy)null, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileSystemClient"/>
        /// class.
        /// </summary>
        /// <param name="fileSystemUri">
        /// A <see cref="Uri"/> referencing the share that includes the
        /// name of the account and the name of the file system.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public DataLakeFileSystemClient(Uri fileSystemUri, DataLakeClientOptions options)
            : this(fileSystemUri, (HttpPipelinePolicy)null, options, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileSystemClient"/>
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
        /// <param name="fileSystemName">
        /// The name of the blob container in the storage account to reference.
        /// </param>
        public DataLakeFileSystemClient(string connectionString, string fileSystemName)
            : this(connectionString, fileSystemName, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileSystemClient"/>
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
        /// <param name="fileSystemName">
        /// The name of the blob container in the storage account to reference.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public DataLakeFileSystemClient(string connectionString, string fileSystemName, DataLakeClientOptions options)
        {
            StorageConnectionString conn = StorageConnectionString.Parse(connectionString);
            StorageSharedKeyCredential sharedKeyCredential = conn.Credentials as StorageSharedKeyCredential;
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(conn.BlobEndpoint)
            {
                FileSystemName = fileSystemName
            };
            options ??= new DataLakeClientOptions();

            _uri = uriBuilder.ToUri();
            _blobUri = uriBuilder.ToBlobUri();
            _dfsUri = uriBuilder.ToDfsUri();
            _pipeline = options.Build(conn.Credentials);
            _storageSharedKeyCredential = sharedKeyCredential;
            _version = options.Version;
            _clientDiagnostics = new ClientDiagnostics(options);
            _containerClient = BlobContainerClientInternals.Create(_blobUri, _pipeline, Version.AsBlobsVersion(), _clientDiagnostics);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileSystemClient"/>
        /// class.
        /// </summary>
        /// <param name="fileSystemUri">
        /// A <see cref="Uri"/> referencing the share that includes the
        /// name of the account and the name of the file system.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        public DataLakeFileSystemClient(Uri fileSystemUri, StorageSharedKeyCredential credential)
            : this(fileSystemUri, credential.AsPolicy(), null, credential)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileSystemClient"/>
        /// class.
        /// </summary>
        /// <param name="fileSystemUri">
        /// A <see cref="Uri"/> referencing the share that includes the
        /// name of the account and the name of the file system.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public DataLakeFileSystemClient(Uri fileSystemUri, StorageSharedKeyCredential credential, DataLakeClientOptions options)
            : this(fileSystemUri, credential.AsPolicy(), options, credential)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileSystemClient"/>
        /// class.
        /// </summary>
        /// <param name="fileSystemUri">
        /// A <see cref="Uri"/> referencing the share that includes the
        /// name of the account and the name of the file system.
        /// Must not contain shared access signature, which should be passed in the second parameter.
        /// </param>
        /// <param name="credential">
        /// The shared access signature credential used to sign requests.
        /// </param>
        /// <remarks>
        /// This constructor should only be used when shared access signature needs to be updated during lifespan of this client.
        /// </remarks>
        public DataLakeFileSystemClient(Uri fileSystemUri, AzureSasCredential credential)
            : this(fileSystemUri, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileSystemClient"/>
        /// class.
        /// </summary>
        /// <param name="fileSystemUri">
        /// A <see cref="Uri"/> referencing the share that includes the
        /// name of the account and the name of the file system.
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
        public DataLakeFileSystemClient(Uri fileSystemUri, AzureSasCredential credential, DataLakeClientOptions options)
            : this(fileSystemUri, credential.AsPolicy<DataLakeUriBuilder>(fileSystemUri), options, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileSystemClient"/>
        /// class.
        /// </summary>
        /// <param name="fileSystemUri">
        /// A <see cref="Uri"/> referencing the file system that includes the
        /// name of the account and the name of the file system.
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        public DataLakeFileSystemClient(Uri fileSystemUri, TokenCredential credential)
            : this(fileSystemUri, credential.AsPolicy(), null, null)
        {
            Errors.VerifyHttpsTokenAuth(fileSystemUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileSystemClient"/>
        /// class.
        /// </summary>
        /// <param name="fileSystemUri">
        /// A <see cref="Uri"/> referencing the file system that includes the
        /// name of the account and the name of the file system.
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public DataLakeFileSystemClient(Uri fileSystemUri, TokenCredential credential, DataLakeClientOptions options)
            : this(fileSystemUri, credential.AsPolicy(), options, null)
        {
            Errors.VerifyHttpsTokenAuth(fileSystemUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileSystemClient"/>
        /// class.
        /// </summary>
        /// <param name="fileSystemUri">
        /// A <see cref="Uri"/> referencing the file system that includes the
        /// name of the account and the name of the file system.
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
        internal DataLakeFileSystemClient(
            Uri fileSystemUri,
            HttpPipelinePolicy authentication,
            DataLakeClientOptions options,
            StorageSharedKeyCredential storageSharedKeyCredential)
        {
            Argument.AssertNotNull(fileSystemUri, nameof(fileSystemUri));
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(fileSystemUri);
            options ??= new DataLakeClientOptions();
            _uri = fileSystemUri;
            _blobUri = uriBuilder.ToBlobUri();
            _dfsUri = uriBuilder.ToDfsUri();
            _pipeline = options.Build(authentication);
            _version = options.Version;
            _clientDiagnostics = new ClientDiagnostics(options);
            _storageSharedKeyCredential = storageSharedKeyCredential;
            _containerClient = BlobContainerClientInternals.Create(_blobUri, _pipeline, Version.AsBlobsVersion(), _clientDiagnostics);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileSystemClient"/>
        /// class.
        /// </summary>
        /// <param name="fileSystemUri">
        /// A <see cref="Uri"/> referencing the file system that includes the
        /// name of the account and the name of the file system.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        /// <param name="storageSharedKeyCredential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="version">
        /// The version of the service to use when sending requests.
        /// </param>
        /// <param name="clientDiagnostics">
        /// The <see cref="ClientDiagnostics"/> instance used to create
        /// diagnostic scopes every request.
        /// </param>
        internal DataLakeFileSystemClient(
            Uri fileSystemUri,
            HttpPipeline pipeline,
            StorageSharedKeyCredential storageSharedKeyCredential,
            DataLakeClientOptions.ServiceVersion version,
            ClientDiagnostics clientDiagnostics)
        {
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(fileSystemUri);
            _uri = fileSystemUri;
            _blobUri = uriBuilder.ToBlobUri();
            _dfsUri = uriBuilder.ToDfsUri();
            _pipeline = pipeline;
            _storageSharedKeyCredential = storageSharedKeyCredential;
            _version = version;
            _clientDiagnostics = clientDiagnostics;
            _containerClient = BlobContainerClientInternals.Create(_blobUri, pipeline, Version.AsBlobsVersion(), _clientDiagnostics);
        }

        /// <summary>
        /// Helper to access protected static members of BlobContainerClient
        /// that should not be exposed directly to customers.
        /// </summary>
        private class BlobContainerClientInternals : BlobContainerClient
        {
            public static BlobContainerClient Create(Uri uri, HttpPipeline pipeline, BlobClientOptions.ServiceVersion version, ClientDiagnostics diagnostics)
            {
                return BlobContainerClient.CreateClient(
                    uri,
                    new BlobClientOptions(version)
                    {
                        Diagnostics = { IsDistributedTracingEnabled = diagnostics.IsActivityEnabled }
                    },
                    pipeline);
            }
        }
        #endregion ctors

        /// <summary>
        /// Create a new <see cref="DataLakeDirectoryClient"/> object by appending
        /// <paramref name="directoryName"/> to the end of <see cref="Uri"/>.  The
        /// new <see cref="DataLakeDirectoryClient"/> uses the same request policy
        /// pipeline as the <see cref="DataLakeFileSystemClient"/>.
        /// </summary>
        /// <param name="directoryName">The name of the directory.</param>
        /// <returns>A new <see cref="DataLakeDirectoryClient"/> instance.</returns>
        public virtual DataLakeDirectoryClient GetDirectoryClient(string directoryName)
        {
            if (directoryName.Length == 0)
            {
                return new DataLakeDirectoryClient(
                    Uri.AppendToPath(directoryName),
                    Pipeline,
                    Version,
                    ClientDiagnostics);
            }
            else
            {
                return new DataLakeDirectoryClient(
                Uri,
                directoryName,
                Pipeline,
                _storageSharedKeyCredential,
                Version,
                ClientDiagnostics);
            }
        }

        /// <summary>
        /// Creates a new <see cref="DataLakeDirectoryClient"/> for the
        /// root directory of the file system.
        /// </summary>
        /// <returns>A new <see cref="DataLakeDirectoryClient"/></returns>
        internal virtual DataLakeDirectoryClient GetRootDirectoryClient()
        {
            return GetDirectoryClient(string.Empty);
        }

        /// <summary>
        /// Create a new <see cref="DataLakeFileClient"/> object by appending
        /// <paramref name="fileName"/> to the end of <see cref="Uri"/>.  The
        /// new <see cref="DataLakeFileClient"/> uses the same request policy
        /// pipeline as the <see cref="DataLakeFileClient"/>.
        /// </summary>
        /// <param name="fileName">The name of the directory.</param>
        /// <returns>A new <see cref="DataLakeFileSystemClient"/> instance.</returns>
        public virtual DataLakeFileClient GetFileClient(string fileName)
            => new DataLakeFileClient(
                Uri,
                fileName,
                Pipeline,
                _storageSharedKeyCredential,
                Version,
                ClientDiagnostics);

        /// <summary>
        /// Sets the various name fields if they are currently null.
        /// </summary>
        private void SetNameFieldsIfNull()
        {
            if (_name == null || _accountName == null)
            {
                var builder = new DataLakeUriBuilder(Uri);
                _name = builder.FileSystemName;
                _accountName = builder.AccountName;
            }
        }

        #region Create
        /// <summary>
        /// The <see cref="Create"/> operation creates a new file system
        /// under the specified account. If the file system with the same name
        /// already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-container">
        /// Create Container</see>.
        /// </summary>
        /// <param name="publicAccessType">
        /// Optionally specifies whether data in the file system may be accessed
        /// publicly and the level of access. <see cref="Models.PublicAccessType.FileSystem"/>
        /// specifies full public read access for file system and path data.
        /// Clients can enumerate paths within the file system via anonymous
        /// request, but cannot enumerate file systems within the storage
        /// account.  <see cref="Models.PublicAccessType.Path"/> specifies public
        /// read access for paths.  Path data within this file system can be
        /// read via anonymous request, but file system data is not available.
        /// Clients cannot enumerate paths within the file system via anonymous
        /// request.  <see cref="Models.PublicAccessType.None"/> specifies that the
        /// file system data is private to the account owner.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this file system.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileSystemInfo}"/> describing the newly
        /// created file system.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<FileSystemInfo> Create(
            Models.PublicAccessType publicAccessType = Models.PublicAccessType.None,
            Metadata metadata = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(Create)}");

            try
            {
                scope.Start();

                Response<BlobContainerInfo> containerResponse = _containerClient.Create(
                    (Blobs.Models.PublicAccessType)publicAccessType,
                    metadata,
                    cancellationToken);

                return Response.FromValue(
                    new FileSystemInfo()
                    {
                        ETag = containerResponse.Value.ETag,
                        LastModified = containerResponse.Value.LastModified
                    },
                    containerResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// The <see cref="CreateAsync"/> operation creates a new file system
        /// under the specified account. If the file system with the same name
        /// already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-container">
        /// Create Container</see>.
        /// </summary>
        /// <param name="publicAccessType">
        /// Optionally specifies whether data in the file system may be accessed
        /// publicly and the level of access. <see cref="Models.PublicAccessType.FileSystem"/>
        /// specifies full public read access for file system and path data.
        /// Clients can enumerate paths within the file system via anonymous
        /// request, but cannot enumerate file system within the storage
        /// account.  <see cref="Models.PublicAccessType.Path"/> specifies public
        /// read access for pathss.  Path data within this file system can be
        /// read via anonymous request, but file system data is not available.
        /// Clients cannot enumerate pathss within the file system via anonymous
        /// request.  <see cref="Models.PublicAccessType.None"/> specifies that the
        /// file system data is private to the account owner.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this file system.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileSystemInfo}"/> describing the newly
        /// created file system.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<FileSystemInfo>> CreateAsync(
            Models.PublicAccessType publicAccessType = Models.PublicAccessType.None,
            Metadata metadata = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(Create)}");

            try
            {
                scope.Start();

                Response<BlobContainerInfo> containerResponse = await _containerClient.CreateAsync(
                    (Blobs.Models.PublicAccessType)publicAccessType,
                    metadata,
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    new FileSystemInfo()
                    {
                        ETag = containerResponse.Value.ETag,
                        LastModified = containerResponse.Value.LastModified
                    },
                    containerResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }
        #endregion Create

        #region Create If Not Exists
        /// <summary>
        /// The <see cref="CreateIfNotExists"/> operation creates a new file system
        /// under the specified account. If the file system with the same name
        /// already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-container">
        /// Create Container</see>.
        /// </summary>
        /// <param name="publicAccessType">
        /// Optionally specifies whether data in the file system may be accessed
        /// publicly and the level of access. <see cref="Models.PublicAccessType.FileSystem"/>
        /// specifies full public read access for file system and path data.
        /// Clients can enumerate paths within the file system via anonymous
        /// request, but cannot enumerate file system within the storage
        /// account.  <see cref="Models.PublicAccessType.Path"/> specifies public
        /// read access for pathss.  Path data within this file system can be
        /// read via anonymous request, but file system data is not available.
        /// Clients cannot enumerate pathss within the file system via anonymous
        /// request.  <see cref="Models.PublicAccessType.None"/> specifies that the
        /// file system data is private to the account owner.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this file system.
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
        public virtual Response<FileSystemInfo> CreateIfNotExists(
            Models.PublicAccessType publicAccessType = Models.PublicAccessType.None,
            Metadata metadata = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(CreateIfNotExists)}");
            try
            {
                scope.Start();
                Response<BlobContainerInfo> containerResponse = _containerClient.CreateIfNotExists(
                    (Blobs.Models.PublicAccessType)publicAccessType,
                    metadata,
                    cancellationToken);

                if (containerResponse == default)
                {
                    return default;
                }

                return Response.FromValue(
                    new FileSystemInfo()
                    {
                        ETag = containerResponse.Value.ETag,
                        LastModified = containerResponse.Value.LastModified
                    },
                    containerResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// The <see cref="CreateIfNotExistsAsync"/> operation creates a new file system
        /// under the specified account. If the file system with the same name
        /// already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-container">
        /// Create Container</see>.
        /// </summary>
        /// <param name="publicAccessType">
        /// Optionally specifies whether data in the file system may be accessed
        /// publicly and the level of access. <see cref="Models.PublicAccessType.FileSystem"/>
        /// specifies full public read access for file system and path data.
        /// Clients can enumerate paths within the file system via anonymous
        /// request, but cannot enumerate file system within the storage
        /// account.  <see cref="Models.PublicAccessType.Path"/> specifies public
        /// read access for pathss.  Path data within this file system can be
        /// read via anonymous request, but file system data is not available.
        /// Clients cannot enumerate pathss within the file system via anonymous
        /// request.  <see cref="Models.PublicAccessType.None"/> specifies that the
        /// file system data is private to the account owner.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this file system.
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
        public virtual async Task<Response<FileSystemInfo>> CreateIfNotExistsAsync(
            Models.PublicAccessType publicAccessType = Models.PublicAccessType.None,
            Metadata metadata = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(CreateIfNotExists)}");
            try
            {
                scope.Start();
                Response<BlobContainerInfo> containerResponse = await _containerClient.CreateIfNotExistsAsync(
                    (Blobs.Models.PublicAccessType)publicAccessType,
                    metadata,
                    cancellationToken).ConfigureAwait(false);

                if (containerResponse == default)
                {
                    return default;
                }

                return Response.FromValue(
                    new FileSystemInfo()
                    {
                        ETag = containerResponse.Value.ETag,
                        LastModified = containerResponse.Value.LastModified
                    },
                    containerResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }
        #endregion Create If Not Exists

        #region Delete
        /// <summary>
        /// The <see cref="Delete"/> operation marks the specified
        /// file system for deletion. The file system and any paths contained
        /// within it are later deleted during garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-container">
        /// Delete Container</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the deletion of this file system.
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
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(Delete)}");

            try
            {
                scope.Start();

                return _containerClient.Delete(
                    conditions.ToBlobRequestConditions(),
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// The <see cref="DeleteAsync"/> operation marks the specified
        /// file system for deletion. The file system and any paths contained
        /// within it are later deleted during garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-container">
        /// Delete Container</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the deletion of this cofile systemntainer.
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
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(Delete)}");

            try
            {
                scope.Start();

                return await _containerClient.DeleteAsync(
                    conditions.ToBlobRequestConditions(),
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }
        #endregion Delete

        #region Delete If Exists
        /// <summary>
        /// The <see cref="DeleteIfExists"/> operation marks the specified
        /// file system for deletion if it exists. The file system and any files
        /// and directories contained within it are later deleted during garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-container">
        /// Delete Container</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the deletion of this file system.
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
        public virtual Response<bool> DeleteIfExists(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(DeleteIfExists)}");

            try
            {
                scope.Start();

                return _containerClient.DeleteIfExists(
                    conditions.ToBlobRequestConditions(),
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// The <see cref="DeleteIfExistsAsync"/> operation marks the specified
        /// file system for deletion if it exists. The file system and any files
        /// and directories contained within it are later deleted during garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-container">
        /// Delete Container</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the deletion of this cofile systemntainer.
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
        public virtual async Task<Response<bool>> DeleteIfExistsAsync(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(DeleteIfExists)}");

            try
            {
                scope.Start();

                return await _containerClient.DeleteIfExistsAsync(
                    conditions.ToBlobRequestConditions(),
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }
        #endregion Delete If Exists

        #region Exists
        /// <summary>
        /// The <see cref="Exists"/> operation can be called on a
        /// <see cref="DataLakeFileClient"/> to see if the associated
        /// file system exists on the storage account in the storage service.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns true if the file system exists.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs. If you want to create the file system if
        /// it doesn't exist, use
        /// <see cref="CreateIfNotExists"/>
        /// instead.
        /// </remarks>
        public virtual Response<bool> Exists(
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(Exists)}");

            try
            {
                scope.Start();

                return _containerClient.Exists(
                cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// The <see cref="ExistsAsync"/> operation can be called on a
        /// <see cref="DataLakeFileSystemClient"/> to see if the associated
        /// file system exists on the storage account in the storage service.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns true if the file system exists.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs. If you want to create the file system if
        /// it doesn't exist, use
        /// <see cref="CreateIfNotExistsAsync"/>
        /// instead.
        /// </remarks>
        public virtual async Task<Response<bool>> ExistsAsync(
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(Exists)}");

            try
            {
                scope.Start();

                return await _containerClient.ExistsAsync(
                cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }
        #endregion Exists

        #region GetProperties
        /// <summary>
        /// The <see cref="GetProperties"/> operation returns all
        /// user-defined metadata and system properties for the specified
        /// file system. The data returned does not include the file system's
        /// list of paths.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-container-properties">
        /// Get Container Properties</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on getting the file system's properties.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileSystemItem}"/> describing the
        /// file system and its properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<FileSystemProperties> GetProperties(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(GetProperties)}");

            try
            {
                scope.Start();

                Response<BlobContainerProperties> containerResponse = _containerClient.GetProperties(
                    conditions.ToBlobRequestConditions(),
                    cancellationToken);

                return Response.FromValue(
                    containerResponse.Value.ToFileSystemProperties(),
                    containerResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// The <see cref="GetPropertiesAsync"/> operation returns all
        /// user-defined metadata and system properties for the specified
        /// file system. The data returned does not include the file system's
        /// list of paths.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-container-properties">
        /// Get Container Properties</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on getting the file system's properties.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileSystemProperties}"/> describing the
        /// file system and its properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<FileSystemProperties>> GetPropertiesAsync(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(GetProperties)}");

            try
            {
                scope.Start();

                Response<BlobContainerProperties> response = await _containerClient.GetPropertiesAsync(
                    conditions.ToBlobRequestConditions(),
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    response.Value.ToFileSystemProperties(),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }
        #endregion GetProperties

        #region SetMetadata
        /// <summary>
        /// The <see cref="SetMetadata"/> operation sets one or more
        /// user-defined name-value pairs for the specified file system.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-container-metadata">
        /// Set Container Metadata</see>.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this file system.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the deletion of this file system.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileSystemInfo}"/> if successful.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<FileSystemInfo> SetMetadata(
            Metadata metadata,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(SetMetadata)}");

            try
            {
                scope.Start();

                Response<BlobContainerInfo> response = _containerClient.SetMetadata(
                    metadata,
                    conditions.ToBlobRequestConditions(),
                    cancellationToken);

                return Response.FromValue(
                    new FileSystemInfo()
                    {
                        ETag = response.Value.ETag,
                        LastModified = response.Value.LastModified
                    },
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// The <see cref="SetMetadataAsync"/> operation sets one or more
        /// user-defined name-value pairs for the specified file system.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-container-metadata">
        /// Set Container Metadata</see>.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this file system.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the deletion of this file system.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileSystemInfo}"/> if successful.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<FileSystemInfo>> SetMetadataAsync(
            Metadata metadata,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(SetMetadata)}");

            try
            {
                scope.Start();

                Response<BlobContainerInfo> response = await _containerClient.SetMetadataAsync(
                    metadata,
                    conditions.ToBlobRequestConditions(),
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    new FileSystemInfo()
                    {
                        ETag = response.Value.ETag,
                        LastModified = response.Value.LastModified
                    },
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }
        #endregion SetMetadata

        #region Get Paths
        /// <summary>
        /// The <see cref="GetPaths"/>
        /// operation returns an async sequence of paths in this file system.
        /// Enumerating the paths may make multiple requests to the service
        /// while fetching all the values.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/datalakestoragegen2/path/list">
        /// List Path(s)</see>.
        /// </summary>
        /// <param name="path">
        /// Filters results to paths within the specified directory.
        /// </param>
        /// <param name="recursive">
        /// If "true", all paths are listed; otherwise, only paths at the root of the filesystem are listed.
        /// </param>
        /// <param name="userPrincipalName">
        /// Optional. Valid only when Hierarchical Namespace is enabled for the account. If
        /// "true", the user identity values returned in the owner and group fields of each list
        /// entry will be transformed from Azure Active Directory Object IDs to User Principal
        /// Names. If "false", the values will be returned as Azure Active Directory Object IDs.
        /// The default value is false. Note that group and application Object IDs are not translated
        /// because they do not have unique friendly names.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="Pageable{PathItem}"/>
        /// describing the paths in the file system.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Pageable<PathItem> GetPaths(
            string path = default,
            bool recursive = default,
            bool userPrincipalName = default,
            CancellationToken cancellationToken = default) =>
            new GetPathsAsyncCollection(
                this,
                path,
                recursive,
                userPrincipalName,
                $"{nameof(DataLakeFileSystemClient)}.{nameof(GetPaths)}")
                .ToSyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetPathsAsync(string, bool, bool, CancellationToken)"/>
        /// operation returns an async sequence of paths in this file system.  Enumerating
        /// the paths may make multiple requests to the service while fetching all the
        /// values.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/datalakestoragegen2/path/list">
        /// List Path(s)</see>.
        /// </summary>
        /// <param name="path">
        /// Filters results to paths within the specified directory.
        /// </param>
        /// <param name="recursive">
        /// If "true", all paths are listed; otherwise, only paths at the root of the filesystem are listed.
        /// </param>
        /// <param name="userPrincipalName">
        /// Optional. Valid only when Hierarchical Namespace is enabled for the account. If
        /// "true", the user identity values returned in the owner and group fields of each list
        /// entry will be transformed from Azure Active Directory Object IDs to User Principal
        /// Names. If "false", the values will be returned as Azure Active Directory Object IDs.
        /// The default value is false. Note that group and application Object IDs are not translated
        /// because they do not have unique friendly names.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="AsyncPageable{T}"/> describing the
        /// paths in the file system.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual AsyncPageable<PathItem> GetPathsAsync(
            string path = default,
            bool recursive = default,
            bool userPrincipalName = default,
            CancellationToken cancellationToken = default) =>
            new GetPathsAsyncCollection(this,
                path,
                recursive,
                userPrincipalName,
                $"{nameof(DataLakeFileSystemClient)}.{nameof(GetPaths)}")
            .ToAsyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetPathsInternal"/> operation returns a
        /// single segment of paths in this file system, starting
        /// from the specified <paramref name="continuation"/>.  Use an empty
        /// <paramref name="continuation"/> to start enumeration from the beginning
        /// and the <see cref="PathSegment.Continuation"/> if it's not
        /// empty to make subsequent calls to
        /// <see cref="GetPathsAsync"/>
        /// to continue enumerating the paths segment by segment. Paths are
        /// ordered lexicographically by name.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/datalakestoragegen2/path/list">
        /// List Path(s)</see>.
        /// </summary>
        /// <param name="path">
        /// Filters results to paths within the specified directory.
        /// </param>
        /// <param name="recursive">
        /// If "true", all paths are listed; otherwise, only paths at the root of the filesystem are listed.
        /// </param>
        /// <param name="userPrincipalName">
        /// Optional. Valid only when Hierarchical Namespace is enabled for the account. If
        /// "true", the user identity values returned in the owner and group fields of each list
        /// entry will be transformed from Azure Active Directory Object IDs to User Principal
        /// Names. If "false", the values will be returned as Azure Active Directory Object IDs.
        /// The default value is false. Note that group and application Object IDs are not translated
        /// because they do not have unique friendly names.
        /// </param>
        /// <param name="continuation">
        /// The number of paths returned with each invocation is limited. If the number of paths
        /// to be returned exceeds this limit, a continuation token is returned in the response header
        /// x-ms-continuation. When a continuation token is returned in the response, it must be specified
        /// in a subsequent invocation of the list operation to continue listing the paths.
        /// </param>
        /// <param name="maxResults">
        /// An optional value that specifies the maximum number of items to return. If omitted or greater than 5,000,
        /// the response will include up to 5,000 items.
        /// </param>
        /// <param name="operationName">
        /// The name of the operation.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathSegment}"/> describing a
        /// segment of the paths in the file system.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<Response<PathSegment>> GetPathsInternal(
            string path,
            bool recursive,
            bool userPrincipalName,
            string continuation,
            int? maxResults,
            string operationName,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(DataLakeFileSystemClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(DataLakeFileSystemClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(continuation)}: {continuation}\n" +
                    $"{nameof(maxResults)}: {maxResults})");
                try
                {
                    Response<FileSystemListPathsResult> response = await DataLakeRestClient.FileSystem.ListPathsAsync(
                        clientDiagnostics: _clientDiagnostics,
                        pipeline: Pipeline,
                        resourceUri: _dfsUri,
                        version: Version.ToVersionString(),
                        continuation: continuation,
                        recursive: recursive,
                        maxResults: maxResults,
                        upn: userPrincipalName,
                        path: path,
                        async: async,
                        operationName: operationName,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    string jsonString;
                    using (var reader = new System.IO.StreamReader(response.Value.Body))
                    {
                        jsonString = reader.ReadToEnd();
                    }

                    Dictionary<string, List<Dictionary<string, string>>> pathDictionary
                        = JsonSerializer.Deserialize<Dictionary<string, List<Dictionary<string, string>>>>(jsonString);

                    return Response.FromValue(
                        new PathSegment()
                        {
                            Continuation = response.Value.Continuation,
                            Paths = pathDictionary["paths"].Select(path => path.ToPathItem())
                        },
                        response.GetRawResponse());
                    ;
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(DataLakeFileSystemClient));
                }
            }
        }
        #endregion List Paths

        #region Create Directory
        /// <summary>
        /// The <see cref="CreateDirectory"/> operation creates a directory in this file system.
        /// If the directory already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing directory, consider using the <see cref="DataLakeDirectoryClient.CreateIfNotExists"/> API.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="path">
        /// The path to the directory to create.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new file or directory..
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this file or directory.
        /// </param>
        /// <param name="permissions">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access
        /// permissions for the file owner, the file owning group, and others. Each class may be granted read,
        /// write, or execute permission. The sticky bit is also supported. Both symbolic (rwxrw-rw-) and 4-digit
        /// octal notation (e.g. 0766) are supported.
        /// </param>
        /// <param name="umask">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account.
        /// When creating a file or directory and the parent folder does not have a default ACL,
        /// the umask restricts the permissions of the file or directory to be created. The resulting
        /// permission is given by p bitwise-and ^u, where p is the permission and u is the umask. For example,
        /// if p is 0777 and u is 0057, then the resulting permission is 0720. The default permission is
        /// 0777 for a directory and 0666 for a file. The default umask is 0027. The umask must be specified
        /// in 4-digit octal notation (e.g. 0766).
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the creation of this file or directory.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<DataLakeDirectoryClient> CreateDirectory(
            string path,
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(CreateDirectory)}");

            try
            {
                scope.Start();

                DataLakeDirectoryClient directoryClient = GetDirectoryClient(path);

                Response<PathInfo> response = directoryClient.Create(
                    httpHeaders,
                    metadata,
                    permissions,
                    umask,
                    conditions,
                    cancellationToken);

                return Response.FromValue(
                    directoryClient,
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// The <see cref="CreateDirectoryAsync"/> operation creates a directory in this file system.
        /// If the directory already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing directory, consider using the <see cref="DataLakeDirectoryClient.CreateIfNotExistsAsync"/> API.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="path">
        /// The path to the directory to create.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new file or directory..
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this file or directory.
        /// </param>
        /// <param name="permissions">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access
        /// permissions for the file owner, the file owning group, and others. Each class may be granted read,
        /// write, or execute permission. The sticky bit is also supported. Both symbolic (rwxrw-rw-) and 4-digit
        /// octal notation (e.g. 0766) are supported.
        /// </param>
        /// <param name="umask">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account.
        /// When creating a file or directory and the parent folder does not have a default ACL,
        /// the umask restricts the permissions of the file or directory to be created. The resulting
        /// permission is given by p bitwise-and ^u, where p is the permission and u is the umask. For example,
        /// if p is 0777 and u is 0057, then the resulting permission is 0720. The default permission is
        /// 0777 for a directory and 0666 for a file. The default umask is 0027. The umask must be specified
        /// in 4-digit octal notation (e.g. 0766).
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the creation of this file or directory.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<DataLakeDirectoryClient>> CreateDirectoryAsync(
            string path,
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(CreateDirectory)}");

            try
            {
                scope.Start();

                DataLakeDirectoryClient directoryClient = GetDirectoryClient(path);

                Response<PathInfo> response = await directoryClient.CreateAsync(
                    httpHeaders,
                    metadata,
                    permissions,
                    umask,
                    conditions,
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    directoryClient,
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }
        #endregion Create Directory

        #region Delete Directory
        /// <summary>
        /// The <see cref="DeleteDirectory"/> operation marks the specified path
        /// deletion. The path is later deleted during
        /// garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete">
        /// Delete Path</see>.
        /// </summary>
        /// <param name="path">
        /// The path to the directory to delete.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// deleting this path.
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
        public virtual Response DeleteDirectory(
            string path,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(DeleteDirectory)}");

            try
            {
                scope.Start();

                return GetDirectoryClient(path).Delete(
                    recursive: true,
                    conditions,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// The <see cref="DeleteDirectoryAsync"/> deletes a directory in this file system.
        /// garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete">
        /// Delete Path</see>.
        /// </summary>
        /// <param name="path">
        /// The path to the directory to delete.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// deleting this path.
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
        public virtual async Task<Response> DeleteDirectoryAsync(
            string path,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(DeleteDirectory)}");

            try
            {
                scope.Start();

                return await GetDirectoryClient(path).DeleteAsync(
                    recursive: true,
                    conditions,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }
        #endregion Delete Directory

        #region Create File
        /// <summary>
        /// The <see cref="CreateFile"/> operation creates a file in this file system.
        /// If the file already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing file, consider using the <see cref="DataLakeFileClient.CreateIfNotExists"/> API.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="path">
        /// The path to the file to create.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new file or directory..
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this file or directory.
        /// </param>
        /// <param name="permissions">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access
        /// permissions for the file owner, the file owning group, and others. Each class may be granted read,
        /// write, or execute permission. The sticky bit is also supported. Both symbolic (rwxrw-rw-) and 4-digit
        /// octal notation (e.g. 0766) are supported.
        /// </param>
        /// <param name="umask">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account.
        /// When creating a file or directory and the parent folder does not have a default ACL,
        /// the umask restricts the permissions of the file or directory to be created. The resulting
        /// permission is given by p bitwise-and ^u, where p is the permission and u is the umask. For example,
        /// if p is 0777 and u is 0057, then the resulting permission is 0720. The default permission is
        /// 0777 for a directory and 0666 for a file. The default umask is 0027. The umask must be specified
        /// in 4-digit octal notation (e.g. 0766).
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the creation of this file or directory.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<DataLakeFileClient> CreateFile(
            string path,
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(CreateFile)}");

            try
            {
                scope.Start();

                DataLakeFileClient fileClient = GetFileClient(path);

                Response<PathInfo> response = fileClient.Create(
                    httpHeaders,
                    metadata,
                    permissions,
                    umask,
                    conditions,
                    cancellationToken);

                return Response.FromValue(
                    fileClient,
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// The <see cref="CreateFileAsync"/> creates a file in this file system.
        /// If the file already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing file, consider using the <see cref="DataLakeFileClient.CreateIfNotExistsAsync"/> API.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="path">
        /// The path to the file to create.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new file or directory..
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this file or directory.
        /// </param>
        /// <param name="permissions">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access
        /// permissions for the file owner, the file owning group, and others. Each class may be granted read,
        /// write, or execute permission. The sticky bit is also supported. Both symbolic (rwxrw-rw-) and 4-digit
        /// octal notation (e.g. 0766) are supported.
        /// </param>
        /// <param name="umask">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account.
        /// When creating a file or directory and the parent folder does not have a default ACL,
        /// the umask restricts the permissions of the file or directory to be created. The resulting
        /// permission is given by p bitwise-and ^u, where p is the permission and u is the umask. For example,
        /// if p is 0777 and u is 0057, then the resulting permission is 0720. The default permission is
        /// 0777 for a directory and 0666 for a file. The default umask is 0027. The umask must be specified
        /// in 4-digit octal notation (e.g. 0766).
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the creation of this file or directory.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<DataLakeFileClient>> CreateFileAsync(
            string path,
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(CreateFile)}");

            try
            {
                scope.Start();

                DataLakeFileClient fileClient = GetFileClient(path);

                Response<PathInfo> response = await fileClient.CreateAsync(
                    httpHeaders,
                    metadata,
                    permissions,
                    umask,
                    conditions,
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    fileClient,
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }
        #endregion Create File

        #region Delete File
        /// <summary>
        /// The <see cref="DeleteFile"/> deletes a file in this file system.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete">
        /// Delete Path</see>.
        /// </summary>
        /// <param name="path">
        /// The path to the file to delete.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// deleting this path.
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
        public virtual Response DeleteFile(
            string path,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(DeleteFile)}");

            try
            {
                scope.Start();

                return GetFileClient(path).Delete(
                    conditions,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// The <see cref="DeleteFileAsync"/> deletes a file in this file system.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete">
        /// Delete Path</see>.
        /// </summary>
        /// <param name="path">
        /// The path to the file to delete.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// deleting this path.
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
        public virtual async Task<Response> DeleteFileAsync(
            string path,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(DeleteFile)}");

            try
            {
                scope.Start();

                return await GetFileClient(path).DeleteAsync(
                    conditions,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }
        #endregion Delete File

        #region GetAccessPolicy
        /// <summary>
        /// The <see cref="GetAccessPolicy"/> operation gets the
        /// permissions for this file system. The permissions indicate whether
        /// file system data may be accessed publicly.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-container-acl">
        /// Get Container ACL</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on getting the file system's access policy.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileSystemAccessPolicy}"/> describing
        /// the filesystems's access policy.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<FileSystemAccessPolicy> GetAccessPolicy(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(GetAccessPolicy)}");

            try
            {
                scope.Start();

                Response<BlobContainerAccessPolicy> response = _containerClient.GetAccessPolicy(
                    conditions.ToBlobRequestConditions(),
                    cancellationToken);

                return Response.FromValue(
                    response.Value.ToFileSystemAccessPolicy(),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// The <see cref="GetAccessPolicyAsync"/> operation gets the
        /// permissions for this file system. The permissions indicate whether
        /// file system data may be accessed publicly.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-container-acl">
        /// Get Container ACL</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on getting the file system's access policy.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileSystemAccessPolicy}"/> describing
        /// the file system's access policy.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<FileSystemAccessPolicy>> GetAccessPolicyAsync(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(GetAccessPolicy)}");

            try
            {
                scope.Start();

                Response<BlobContainerAccessPolicy> response = await _containerClient.GetAccessPolicyAsync(
                    conditions.ToBlobRequestConditions(),
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    response.Value.ToFileSystemAccessPolicy(),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }
        #endregion GetAccessPolicy

        #region SetAccessPolicy
        /// <summary>
        /// The <see cref="SetAccessPolicy"/> operation sets the
        /// permissions for the specified file system. The permissions indicate
        /// whether file system data may be accessed publicly.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-container-acl">
        /// Set Container ACL</see>.
        /// </summary>
        /// <param name="accessType">
        /// Optionally specifies whether data in the file system may be accessed
        /// publicly and the level of access. <see cref="Models.PublicAccessType.FileSystem"/>
        /// specifies full public read access for file system and path data.
        /// Clients can enumerate paths within the file system via anonymous
        /// request, but cannot enumerate file systems within the storage
        /// account.  <see cref="Models.PublicAccessType.Path"/> specifies public
        /// read access for paths.  Path data within this file system can be
        /// read via anonymous request, but file system data is not available.
        /// Clients cannot enumerate paths within the file system via anonymous
        /// request.  <see cref="Models.PublicAccessType.None"/> specifies that the
        /// file system data is private to the account owner.
        /// </param>
        /// <param name="permissions">
        /// Stored access policies that you can use to provide fine grained
        /// control over file system permissions.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on setting this file systems's access policy.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileSystemInfo}"/> describing the
        /// updated file system.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<FileSystemInfo> SetAccessPolicy(
            Models.PublicAccessType accessType = Models.PublicAccessType.None,
            IEnumerable<DataLakeSignedIdentifier> permissions = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(SetAccessPolicy)}");

            try
            {
                scope.Start();

                Response<BlobContainerInfo> containerResponse = _containerClient.SetAccessPolicy(
                    (Blobs.Models.PublicAccessType)accessType,
                    permissions.ToBlobSignedIdentifiers(),
                    conditions.ToBlobRequestConditions(),
                    cancellationToken);

                return Response.FromValue(
                    new FileSystemInfo()
                    {
                        ETag = containerResponse.Value.ETag,
                        LastModified = containerResponse.Value.LastModified
                    },
                    containerResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// The <see cref="SetAccessPolicyAsync"/> operation sets the
        /// permissions for the specified file system. The permissions indicate
        /// whether the file system data may be accessed publicly.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-container-acl">
        /// Set Container ACL</see>.
        /// </summary>
        /// <param name="accessType">
        /// Optionally specifies whether data in the file system may be accessed
        /// publicly and the level of access. <see cref="Models.PublicAccessType.FileSystem"/>
        /// specifies full public read access for file system and path data.
        /// Clients can enumerate paths within the file system via anonymous
        /// request, but cannot enumerate file systems within the storage
        /// account.  <see cref="Models.PublicAccessType.Path"/> specifies public
        /// read access for paths.  Path data within this file system can be
        /// read via anonymous request, but file system data is not available.
        /// Clients cannot enumerate paths within the file system via anonymous
        /// request.  <see cref="Models.PublicAccessType.None"/> specifies that the
        /// file system data is private to the account owner.
        /// </param>
        /// <param name="permissions">
        /// Stored access policies that you can use to provide fine grained
        /// control over file system permissions.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on setting this file system's access policy.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileSystemInfo}"/> describing the
        /// updated file system.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<FileSystemInfo>> SetAccessPolicyAsync(
            Models.PublicAccessType accessType = Models.PublicAccessType.None,
            IEnumerable<DataLakeSignedIdentifier> permissions = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileSystemClient)}.{nameof(SetAccessPolicy)}");

            try
            {
                scope.Start();

                Response<BlobContainerInfo> containerResponse = await _containerClient.SetAccessPolicyAsync(
                    (Blobs.Models.PublicAccessType)accessType,
                    permissions.ToBlobSignedIdentifiers(),
                    conditions.ToBlobRequestConditions(),
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    new FileSystemInfo()
                    {
                        ETag = containerResponse.Value.ETag,
                        LastModified = containerResponse.Value.LastModified
                    },
                    containerResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }
        #endregion SetAccessPolicy

        #region GenerateSas
        /// <summary>
        /// The <see cref="GenerateSasUri(DataLakeFileSystemSasPermissions, DateTimeOffset)"/>
        /// returns a <see cref="Uri"/> that generates a DataLake FileSystem Service
        /// Shared Access Signature (SAS) Uri based on the <see cref="BlobContainerClient"/>
        /// properties and parameters passed. The SAS is signed by the shared key credential
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
        /// See <see cref="DataLakeFileSystemSasPermissions"/>.
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
        public virtual Uri GenerateSasUri(DataLakeFileSystemSasPermissions permissions, DateTimeOffset expiresOn) =>
            GenerateSasUri(new DataLakeSasBuilder(permissions, expiresOn) { FileSystemName = Name });

        /// <summary>
        /// The <see cref="GenerateSasUri(DataLakeSasBuilder)"/> returns a <see cref="Uri"/>
        /// that generates a DataLake FileSystem Service Shared Access Signature (SAS)
        /// Uri based on the Client properties and builder passed.
        /// The SAS is signed by the shared key credential of the client.
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
        /// A <see cref="DataLakeSasBuilder"/> on successfully deleting.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Uri GenerateSasUri(
            DataLakeSasBuilder builder)
        {
            builder = builder ?? throw Errors.ArgumentNull(nameof(builder));
            if (!builder.FileSystemName.Equals(Name, StringComparison.InvariantCulture))
            {
                throw Errors.SasNamesNotMatching(
                    nameof(builder.FileSystemName),
                    nameof(DataLakeSasBuilder),
                    nameof(Name));
            }
            if (!string.IsNullOrEmpty(builder.Path))
            {
                throw Errors.SasBuilderEmptyParam(
                    nameof(builder),
                    nameof(builder.Path),
                    nameof(Constants.DataLake.FileSystemName));
            }
            DataLakeUriBuilder sasUri = new DataLakeUriBuilder(Uri)
            {
                Query = builder.ToSasQueryParameters(SharedKeyCredential).ToString()
            };
            return sasUri.ToUri();
        }
        #endregion
    }
}
