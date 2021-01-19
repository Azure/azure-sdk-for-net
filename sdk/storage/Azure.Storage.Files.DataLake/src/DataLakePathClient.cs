// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Sas;
using Azure.Storage.Shared;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.DataLake
{
    /// <summary>
    /// A PathClient represents a URI to the Azure DataLake service allowing you to manipulate a file or directory.
    /// </summary>
    public class DataLakePathClient
    {
        /// <summary>
        /// A <see cref="BlockBlobClient"/> associated with the path.
        /// </summary>
        internal readonly BlockBlobClient _blockBlobClient;

        /// <summary>
        /// A <see cref="BlockBlobClient"/> associated with the path.
        /// </summary>
        internal virtual BlockBlobClient BlobClient => _blockBlobClient;

        /// <summary>
        /// A <see cref="DataLakeFileSystemClient"/> associated with Directory's parent File System.
        /// </summary>
        internal readonly DataLakeFileSystemClient _fileSystemClient;

        /// <summary>
        /// A <see cref="DataLakeFileSystemClient"/> associated with Directory's parent File System.
        /// </summary>
        internal virtual DataLakeFileSystemClient FileSystemClient => _fileSystemClient;

        /// <summary>
        /// The paths's primary <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _uri;

        /// <summary>
        /// The paths's blob <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _blobUri;

        /// <summary>
        /// The paths's blob <see cref="Uri"/> endpoint.
        /// </summary>
        internal virtual Uri BlobUri => _blobUri;

        /// <summary>
        /// The path's dfs <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _dfsUri;

        /// <summary>
        /// DFS Uri
        /// </summary>
        internal virtual Uri DfsUri => _dfsUri;

        /// <summary>
        /// Gets the directory's primary <see cref="Uri"/> endpoint.
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
        /// The Storage account name corresponding to the directory client.
        /// </summary>
        private string _accountName;

        /// <summary>
        /// Gets the Storage account name corresponding to the directory client.
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
        /// The file system name corresponding to the directory client.
        /// </summary>
        private string _fileSystemName;

        /// <summary>
        /// Gets the file system name name corresponding to the directory client.
        /// </summary>
        public virtual string FileSystemName
        {
            get
            {
                SetNameFieldsIfNull();
                return _fileSystemName;
            }
        }

        /// <summary>
        /// The path corresponding to the path client.
        /// </summary>
        private string _path;

        /// <summary>
        /// Gets the path corresponding to the path client.
        /// </summary>
        public virtual string Path
        {
            get
            {
                SetNameFieldsIfNull();
                return _path;
            }
        }

        /// <summary>
        /// The name of the file or directory.
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets the name of the file or directory.
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
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>
        /// class for mocking.
        /// </summary>
        protected DataLakePathClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>
        /// class.
        /// </summary>
        /// <param name="pathUri">
        /// A <see cref="Uri"/> referencing the resource that includes the
        /// name of the account, the name of the file system, and the path to the
        /// resource.
        /// </param>
        public DataLakePathClient(Uri pathUri)
            : this(pathUri, (HttpPipelinePolicy)null, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>
        /// class.
        /// </summary>
        /// <param name="pathUri">
        /// A <see cref="Uri"/> referencing the resource that includes the
        /// name of the account, the name of the file system, and the path to the
        /// resource.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="DataLakeClientOptions"/> that define the transport
        /// pipeline policies for authentication, retries, etc., that are
        /// applied to every request.
        /// </param>
        public DataLakePathClient(Uri pathUri, DataLakeClientOptions options)
            : this(pathUri, (HttpPipelinePolicy)null, options, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>.
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
        /// <param name="fileSystemName">
        /// The name of the file system containing this path.
        /// </param>
        /// <param name="path">
        /// The path to the file or directory.
        /// </param>
        public DataLakePathClient(string connectionString, string fileSystemName, string path)
            : this(connectionString, fileSystemName, path, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>.
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
        /// <param name="fileSystemName">
        /// The name of the file system containing this path.
        /// </param>
        /// <param name="path">
        /// The path to the file or directory.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public DataLakePathClient(
            string connectionString,
            string fileSystemName,
            string path,
            DataLakeClientOptions options)
        {
            StorageConnectionString conn = StorageConnectionString.Parse(connectionString);
            StorageSharedKeyCredential sharedKeyCredential = conn.Credentials as StorageSharedKeyCredential;
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(conn.BlobEndpoint)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            options ??= new DataLakeClientOptions();

            _uri = uriBuilder.ToUri();
            _blobUri = uriBuilder.ToBlobUri();
            _dfsUri = uriBuilder.ToDfsUri();
            _pipeline = options.Build(conn.Credentials);
            _version = options.Version;
            _clientDiagnostics = new ClientDiagnostics(options);
            _storageSharedKeyCredential = sharedKeyCredential;
            _blockBlobClient = BlockBlobClientInternals.Create(_blobUri, _pipeline, Version.AsBlobsVersion(), _clientDiagnostics);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>
        /// class.
        /// </summary>
        /// <param name="pathUri">
        /// A <see cref="Uri"/> referencing the resource that includes the
        /// name of the account, the name of the file system, and the path to the
        /// resource.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        public DataLakePathClient(Uri pathUri, StorageSharedKeyCredential credential)
            : this(pathUri, credential.AsPolicy(), null, credential)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>
        /// class.
        /// </summary>
        /// <param name="pathUri">
        /// A <see cref="Uri"/> referencing the resource that includes the
        /// name of the account, the name of the file system, and the path to the
        /// resource.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public DataLakePathClient(Uri pathUri, StorageSharedKeyCredential credential, DataLakeClientOptions options)
            : this(pathUri, credential.AsPolicy(), options, credential)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>
        /// class.
        /// </summary>
        /// <param name="pathUri">
        /// A <see cref="Uri"/> referencing the resource that includes the
        /// name of the account, the name of the file system, and the path to the
        /// resource.
        /// Must not contain shared access signature, which should be passed in the second parameter.
        /// </param>
        /// <param name="credential">
        /// The shared access signature credential used to sign requests.
        /// </param>
        /// <remarks>
        /// This constructor should only be used when shared access signature needs to be updated during lifespan of this client.
        /// </remarks>
        public DataLakePathClient(Uri pathUri, AzureSasCredential credential)
            : this(pathUri, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>
        /// class.
        /// </summary>
        /// <param name="pathUri">
        /// A <see cref="Uri"/> referencing the resource that includes the
        /// name of the account, the name of the file system, and the path to the
        /// resource.
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
        public DataLakePathClient(Uri pathUri, AzureSasCredential credential, DataLakeClientOptions options)
            : this(pathUri, credential.AsPolicy<DataLakeUriBuilder>(pathUri), options, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>
        /// class.
        /// </summary>
        /// <param name="pathUri">
        /// A <see cref="Uri"/> referencing the resource that includes the
        /// name of the account, the name of the file system, and the path to the
        /// resource.
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        public DataLakePathClient(Uri pathUri, TokenCredential credential)
            : this(pathUri, credential.AsPolicy(), null, null)
        {
            Errors.VerifyHttpsTokenAuth(pathUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>
        /// class.
        /// </summary>
        /// <param name="pathUri">
        /// A <see cref="Uri"/> referencing the resource that includes the
        /// name of the account, the name of the file system, and the path to the
        /// resource.
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public DataLakePathClient(Uri pathUri, TokenCredential credential, DataLakeClientOptions options)
            : this(pathUri, credential.AsPolicy(), options, null)
        {
            Errors.VerifyHttpsTokenAuth(pathUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>.
        /// </summary>
        /// <param name="fileSystemClient"><see cref="DataLakeFileSystemClient"/> of the path's File System.</param>
        /// <param name="path">The path to the <see cref="DataLakePathClient"/>.</param>
        public DataLakePathClient(DataLakeFileSystemClient fileSystemClient, string path)
            : this(
                  (new DataLakeUriBuilder(fileSystemClient.Uri) { DirectoryOrFilePath = path }).ToDfsUri(),
                  fileSystemClient.Pipeline,
                  fileSystemClient.Version,
                  fileSystemClient.ClientDiagnostics)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>
        /// class.
        /// </summary>
        /// <param name="pathUri">
        /// A <see cref="Uri"/> referencing the path that includes the
        /// name of the account, the name of the file system, and the path to
        /// the resource.
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
        internal DataLakePathClient(
            Uri pathUri,
            HttpPipelinePolicy authentication,
            DataLakeClientOptions options,
            StorageSharedKeyCredential storageSharedKeyCredential)
        {
            Argument.AssertNotNull(pathUri, nameof(pathUri));
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(pathUri);
            options ??= new DataLakeClientOptions();
            _uri = pathUri;
            _blobUri = uriBuilder.ToBlobUri();
            _dfsUri = uriBuilder.ToDfsUri();
            _pipeline = options.Build(authentication);
            _version = options.Version;
            _clientDiagnostics = new ClientDiagnostics(options);
            _storageSharedKeyCredential = storageSharedKeyCredential;
            _blockBlobClient = BlockBlobClientInternals.Create(_blobUri, _pipeline, Version.AsBlobsVersion(), _clientDiagnostics);

            uriBuilder.DirectoryOrFilePath = null;
            _fileSystemClient = new DataLakeFileSystemClient(
                uriBuilder.ToDfsUri(),
                _pipeline,
                storageSharedKeyCredential,
                Version,
                ClientDiagnostics);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>
        /// class.
        /// </summary>
        /// <param name="pathUri">
        /// A <see cref="Uri"/> referencing the directory that includes the
        /// name of the account, the name of the file system, and the path to the
        /// resource.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        /// <param name="storageSharedKeyCredential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        internal DataLakePathClient(
            Uri pathUri,
            HttpPipeline pipeline,
            StorageSharedKeyCredential storageSharedKeyCredential,
            DataLakeClientOptions options = default)
        {
            options ??= new DataLakeClientOptions();
            var uriBuilder = new DataLakeUriBuilder(pathUri);
            _uri = pathUri;
            _blobUri = uriBuilder.ToBlobUri();
            _dfsUri = uriBuilder.ToDfsUri();
            _pipeline = pipeline;
            _storageSharedKeyCredential = storageSharedKeyCredential;
            _version = options.Version;
            _clientDiagnostics = new ClientDiagnostics(options);
            _blockBlobClient = BlockBlobClientInternals.Create(_blobUri, _pipeline, Version.AsBlobsVersion(), _clientDiagnostics);

            uriBuilder.DirectoryOrFilePath = null;
            _fileSystemClient = new DataLakeFileSystemClient(
                uriBuilder.ToDfsUri(),
                _pipeline,
                storageSharedKeyCredential,
                Version,
                ClientDiagnostics);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>
        /// class.
        /// </summary>
        /// <param name="pathUri">
        /// A <see cref="Uri"/> referencing the directory that includes the
        /// name of the account, the name of the file system, and the path to the
        /// resource.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        /// <param name="version">
        /// The version of the service to use when sending requests.
        /// </param>
        /// <param name="clientDiagnostics">
        /// The <see cref="ClientDiagnostics"/> instance used to create
        /// diagnostic scopes every request.
        /// </param>
        internal DataLakePathClient(
            Uri pathUri,
            HttpPipeline pipeline,
            DataLakeClientOptions.ServiceVersion version,
            ClientDiagnostics clientDiagnostics)
        {
            var uriBuilder = new DataLakeUriBuilder(pathUri);
            _uri = pathUri;
            _blobUri = uriBuilder.ToBlobUri();
            _dfsUri = uriBuilder.ToDfsUri();
            _pipeline = pipeline;
            _version = version;
            _clientDiagnostics = clientDiagnostics;
            _blockBlobClient = BlockBlobClientInternals.Create(
                _blobUri,
                _pipeline,
                Version.AsBlobsVersion(),
                _clientDiagnostics);

            uriBuilder.DirectoryOrFilePath = null;
            _fileSystemClient = new DataLakeFileSystemClient(
                uriBuilder.ToDfsUri(),
                pipeline,
                null,
                version,
                clientDiagnostics);
        }

        internal DataLakePathClient(
            Uri fileSystemUri,
            string directoryOrFilePath,
            HttpPipeline pipeline,
            StorageSharedKeyCredential storageSharedKeyCredential,
            DataLakeClientOptions.ServiceVersion version,
            ClientDiagnostics clientDiagnostics)
        {
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(fileSystemUri)
            {
                DirectoryOrFilePath = directoryOrFilePath
            };
            _uri = uriBuilder.ToUri();
            _blobUri = uriBuilder.ToBlobUri();
            _dfsUri = uriBuilder.ToDfsUri();
            _pipeline = pipeline;
            _storageSharedKeyCredential = storageSharedKeyCredential;
            _version = version;
            _clientDiagnostics = clientDiagnostics;
            _blockBlobClient = BlockBlobClientInternals.Create(
                _blobUri,
                _pipeline,
                Version.AsBlobsVersion(),
                _clientDiagnostics);

            uriBuilder.DirectoryOrFilePath = null;
            _fileSystemClient = new DataLakeFileSystemClient(
                uriBuilder.ToDfsUri(),
                pipeline,
                storageSharedKeyCredential,
                version,
                clientDiagnostics);
        }

        /// <summary>
        /// Helper to access protected static members of BlockBlobClient
        /// that should not be exposed directly to customers.
        /// </summary>
        private class BlockBlobClientInternals : BlockBlobClient
        {
            public static BlockBlobClient Create(Uri uri, HttpPipeline pipeline, BlobClientOptions.ServiceVersion version, ClientDiagnostics diagnostics)
            {
                return BlockBlobClient.CreateClient(
                    uri,
                    new BlobClientOptions(version)
                    {
                        Diagnostics = { IsDistributedTracingEnabled = diagnostics.IsActivityEnabled }
                    },
                    pipeline);
            }
        }
        #endregion

        /// <summary>
        /// Converts metadata in DFS metadata string
        /// </summary>
        internal static string BuildMetadataString(Metadata metadata)
        {
            if (metadata == null)
            {
                return null;
            }
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> kv in metadata)
            {
                sb.Append(kv.Key);
                sb.Append('=');
                byte[] valueBytes = Encoding.UTF8.GetBytes(kv.Value);
                sb.Append(Convert.ToBase64String(valueBytes));
                sb.Append(',');
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        /// <summary>
        /// Sets the various name fields if they are currently null.
        /// </summary>
        internal virtual void SetNameFieldsIfNull()
        {
            if (_fileSystemName == null
                || _accountName == null
                || _path == null
                || _name == null)
            {
                var builder = new DataLakeUriBuilder(Uri);
                _fileSystemName = builder.FileSystemName;
                _accountName = builder.AccountName;
                _path = builder.DirectoryOrFilePath;
                _name = builder.LastDirectoryOrFileName;
            }
        }

        #region Create
        /// <summary>
        /// The <see cref="Create"/> operation creates a file or directory.
        /// If the path already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing path, consider using the <see cref="CreateIfNotExists"/> API.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="resourceType">
        /// Resource type of this path - file or directory.
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
        /// newly created path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<PathInfo> Create(
            PathResourceType resourceType,
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(Create)}");

            try
            {
                scope.Start();

                return CreateInternal(
                    resourceType,
                    httpHeaders,
                    metadata,
                    permissions,
                    umask,
                    conditions,
                    false, // async
                    cancellationToken)
                    .EnsureCompleted();
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
        /// The <see cref="Create"/> operation creates a file or directory.
        /// If the path already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing path, consider using the <see cref="CreateIfNotExists"/> API.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="resourceType">
        /// Resource type of this path - file or directory.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new file or directory.
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
        /// newly created path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<PathInfo>> CreateAsync(
            PathResourceType resourceType,
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(Create)}");

            try
            {
                scope.Start();

                return await CreateInternal(
                    resourceType,
                    httpHeaders,
                    metadata,
                    permissions,
                    umask,
                    conditions,
                    true, // async
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

        /// <summary>
        /// The <see cref="Create"/> operation creates a file or directory.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="resourceType">
        /// Resource type of this path - file or directory.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new file or directory.
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
        /// conditions on the creation of this file or directory..
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal virtual async Task<Response<PathInfo>> CreateInternal(
            PathResourceType resourceType,
            PathHttpHeaders httpHeaders,
            Metadata metadata,
            string permissions,
            string umask,
            DataLakeRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(DataLakePathClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(DataLakePathClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(httpHeaders)}: {httpHeaders}\n" +
                    $"{nameof(metadata)}: {metadata}\n" +
                    $"{nameof(permissions)}: {permissions}\n" +
                    $"{nameof(umask)}: {umask}\n");
                try
                {
                    Response<PathCreateResult> createResponse = await DataLakeRestClient.Path.CreateAsync(
                        clientDiagnostics: _clientDiagnostics,
                        pipeline: Pipeline,
                        resourceUri: _dfsUri,
                        version: Version.ToVersionString(),
                        resource: resourceType,
                        cacheControl: httpHeaders?.CacheControl,
                        contentEncoding: httpHeaders?.ContentEncoding,
                        contentDisposition: httpHeaders?.ContentDisposition,
                        contentType: httpHeaders?.ContentType,
                        contentLanguage: httpHeaders?.ContentLanguage,
                        leaseId: conditions?.LeaseId,
                        properties: BuildMetadataString(metadata),
                        permissions: permissions,
                        umask: umask,
                        ifMatch: conditions?.IfMatch,
                        ifNoneMatch: conditions?.IfNoneMatch,
                        ifModifiedSince: conditions?.IfModifiedSince,
                        ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return Response.FromValue(
                        new PathInfo()
                        {
                            ETag = createResponse.Value.ETag,
                            LastModified = createResponse.Value.LastModified
                        },
                        createResponse.GetRawResponse());
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(DataLakePathClient));
                }
            }
        }
        #endregion Create

        #region Create If Not Exists
        /// <summary>
        /// The <see cref="CreateIfNotExists(PathResourceType, PathHttpHeaders, Metadata, string, string, CancellationToken)"/>
        /// operation creates a file or directory.  If the file or directory already exists, it is not changed.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="resourceType">
        /// Resource type of this path - file or directory.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new file or directory..
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this file or directory..
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
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<PathInfo> CreateIfNotExists(
            PathResourceType resourceType,
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            CancellationToken cancellationToken = default)
            => CreateIfNotExistsInternal(
                    resourceType,
                    httpHeaders,
                    metadata,
                    permissions,
                    umask,
                    false, // async
                    cancellationToken)
                    .EnsureCompleted();

        /// <summary>
        /// The <see cref="CreateIfNotExistsAsync(PathResourceType, PathHttpHeaders, Metadata, string, string, CancellationToken)"/>
        /// operation creates a file or directory.  If the file or directory already exists, it is not changed.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="resourceType">
        /// Resource type of this path - file or directory.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new file or directory.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this file or directory..
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
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<PathInfo>> CreateIfNotExistsAsync(
            PathResourceType resourceType,
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            CancellationToken cancellationToken = default)
            => await CreateIfNotExistsInternal(
                resourceType,
                httpHeaders,
                metadata,
                permissions,
                umask,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CreateIfNotExistsInternal(PathResourceType, PathHttpHeaders, Metadata, string, string, bool, CancellationToken)"/>
        /// operation creates a file or directory.  If the file or directory already exists, it is not changed.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="resourceType">
        /// Resource type of this path - file or directory.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new file or directory.
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
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<PathInfo>> CreateIfNotExistsInternal(
            PathResourceType resourceType,
            PathHttpHeaders httpHeaders,
            Metadata metadata,
            string permissions,
            string umask,
            bool async,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(Create)}");
            Response<PathInfo> response;
            try
            {
                scope.Start();
                DataLakeRequestConditions conditions = new DataLakeRequestConditions { IfNoneMatch = new ETag(Constants.Wildcard) };
                response = await CreateInternal(
                    resourceType,
                    httpHeaders,
                    metadata,
                    permissions,
                    umask,
                    conditions,
                    async,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException storageRequestFailedException)
            when (storageRequestFailedException.ErrorCode == "PathAlreadyExists")
            {
                response = default;
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
            return response;
        }
        #endregion Create If Not Exists

        #region Exists
        /// <summary>
        /// The <see cref="Exists"/> operation can be called on a
        /// <see cref="DataLakePathClient"/> to see if the associated
        /// file or director exists in the file system.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns true if the file or directory exists.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs. If you want to create the file system if
        /// it doesn't exist, use
        /// <see cref="CreateIfNotExists"/>
        /// instead.
        /// </remarks>
        /// <remarks>
        /// Note that if you call FileClient.Exists on a path that does not
        /// represent a file, Exists will return true. Similarly, if you
        /// call DirectoryClient.Exists on a path that is not a directory,
        /// Exists will return true.
        /// </remarks>
        public virtual Response<bool> Exists(
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(Exists)}");

            try
            {
                scope.Start();

                return _blockBlobClient.Exists(cancellationToken);
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
        /// <see cref="DataLakePathClient"/> to see if the associated
        /// file or directory exists in the file system.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns true if the file or directory exists.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs. If you want to create the file system if
        /// it doesn't exist, use
        /// <see cref="CreateIfNotExistsAsync"/>
        /// instead.
        /// </remarks>
        /// <remarks>
        /// Note that if you call FileClient.Exists on a path that does not
        /// represent a file, Exists will return true. Similarly, if you
        /// call DirectoryClient.Exists on a path that is not a directory,
        /// Exists will return true.
        /// </remarks>
        public virtual async Task<Response<bool>> ExistsAsync(
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(Exists)}");

            try
            {
                scope.Start();

                return await _blockBlobClient.ExistsAsync(cancellationToken).ConfigureAwait(false);
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

        #region Delete
        /// <summary>
        /// The <see cref="Delete"/> operation marks the specified path
        /// deletion. The path is later deleted during
        /// garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete">
        /// Delete Path</see>.
        /// </summary>
        /// <param name="recursive">
        /// Required and valid only when the resource is a directory. If "true", all paths beneath the directory will be deleted.
        /// If "false" and the directory is non-empty, an error occurs.
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
        public virtual Response Delete(
            bool? recursive = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(Delete)}");

            try
            {
                scope.Start();

                return DeleteInternal(
                    recursive,
                    conditions,
                    false, // async
                    cancellationToken)
                    .EnsureCompleted();
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
        /// The <see cref="DeleteAsync"/> operation marks the specified path
        /// deletion. The path is later deleted during
        /// garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete">
        /// Delete Path</see>.
        /// </summary>
        /// <param name="recursive">
        /// Required and valid only when the resource is a directory. If "true", all paths beneath the directory will be deleted.
        /// If "false" and the directory is non-empty, an error occurs.
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
        public virtual async Task<Response> DeleteAsync(
            bool? recursive = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(Delete)}");

            try
            {
                scope.Start();

                return await DeleteInternal(
                    recursive,
                    conditions,
                    true, // async
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

        /// <summary>
        /// The <see cref="DeleteInternal"/> operation marks the specified path
        /// deletion. The path is later deleted during
        /// garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete">
        /// Delete Path</see>.
        /// </summary>
        /// <param name="recursive">
        /// Required and valid only when the resource is a directory. If "true", all paths beneath the directory will be deleted.
        /// If "false" and the directory is non-empty, an error occurs.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// deleting this path.
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
        private async Task<Response> DeleteInternal(
            bool? recursive,
            DataLakeRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(DataLakePathClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(DataLakePathClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(recursive)}: {recursive}\n" +
                    $"{nameof(conditions)}: {conditions}");
                try
                {
                    Response<PathDeleteResult> response = await DataLakeRestClient.Path.DeleteAsync(
                        clientDiagnostics: _clientDiagnostics,
                        pipeline: Pipeline,
                        resourceUri: _dfsUri,
                        version: Version.ToVersionString(),
                        recursive: recursive,
                        leaseId: conditions?.LeaseId,
                        ifMatch: conditions?.IfMatch,
                        ifNoneMatch: conditions?.IfNoneMatch,
                        ifModifiedSince: conditions?.IfModifiedSince,
                        ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return response.GetRawResponse();
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(DataLakePathClient));
                }
            }
        }
        #endregion Delete

        #region Delete If Exists
        /// <summary>
        /// The <see cref="DeleteIfExists"/> operation marks the specified path
        /// for deletion, if the path exists. The path is later deleted during
        /// garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete">
        /// Delete Path</see>.
        /// </summary>
        /// <param name="recursive">
        /// Required and valid only when the resource is a directory. If "true", all paths beneath the directory will be deleted.
        /// If "false" and the directory is non-empty, an error occurs.
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
        public virtual Response<bool> DeleteIfExists(
            bool? recursive = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
            => DeleteIfExistsInternal(
                recursive,
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="DeleteIfExistsAsync"/> operation marks the specified path
        /// deletion, if the path exists. The path is later deleted during
        /// garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete">
        /// Delete Path</see>.
        /// </summary>
        /// <param name="recursive">
        /// Required and valid only when the resource is a directory. If "true", all paths beneath the directory will be deleted.
        /// If "false" and the directory is non-empty, an error occurs.
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
        public virtual async Task<Response<bool>> DeleteIfExistsAsync(
            bool? recursive = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
            => await DeleteIfExistsInternal(
                recursive,
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DeleteIfExistsInternal"/> operation marks the specified path
        /// deletion, if the path exists. The path is later deleted during
        /// garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete">
        /// Delete Path</see>.
        /// </summary>
        /// <param name="recursive">
        /// Required and valid only when the resource is a directory. If "true", all paths beneath the directory will be deleted.
        /// If "false" and the directory is non-empty, an error occurs.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// deleting this path.
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
            bool? recursive,
            DataLakeRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(DeleteIfExists)}");
            try
            {
                scope.Start();
                Response response = await DeleteInternal(
                    recursive: recursive,
                    conditions: conditions,
                    async: async,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(true, response);
            }
            catch (RequestFailedException ex)
            when (ex.ErrorCode == Constants.DataLake.PathNotFound
                || ex.ErrorCode == Constants.DataLake.FilesystemNotFound)
            {
                return Response.FromValue(false, default);
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

        #region Rename
        /// <summary>
        /// The <see cref="Rename"/> operation renames a file or directory.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="destinationPath">
        /// The destination path to rename the path to.
        /// </param>
        /// <param name="destinationFileSystem">
        /// Optional destination file system.  If null, path will be renamed within the
        /// current file system.
        /// </param>
        /// <param name="sourceConditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the source on the creation of this file or directory.
        /// </param>
        /// <param name="destinationConditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the creation of this file or directory.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<DataLakePathClient> Rename(
            string destinationPath,
            string destinationFileSystem = default,
            DataLakeRequestConditions sourceConditions = default,
            DataLakeRequestConditions destinationConditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(Rename)}");

            try
            {
                scope.Start();

                return RenameInternal(
                    destinationFileSystem,
                    destinationPath,
                    sourceConditions,
                    destinationConditions,
                    false, // async
                    cancellationToken)
                    .EnsureCompleted();
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
        /// The <see cref="RenameAsync"/> operation renames a file or directory.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="destinationPath">
        /// The destination path to rename the path to.
        /// </param>
        /// <param name="destinationFileSystem">
        /// Optional destination file system.  If null, path will be renamed within the
        /// current file system.
        /// </param>
        /// <param name="sourceConditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the source on the creation of this file or directory.
        /// </param>
        /// <param name="destinationConditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the creation of this file or directory.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<DataLakePathClient>> RenameAsync(
            string destinationPath,
            string destinationFileSystem = default,
            DataLakeRequestConditions sourceConditions = default,
            DataLakeRequestConditions destinationConditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(Rename)}");

            try
            {
                scope.Start();

                return await RenameInternal(
                    destinationFileSystem,
                    destinationPath,
                    sourceConditions,
                    destinationConditions,
                    true, // async
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

        /// <summary>
        /// The <see cref="RenameInternal"/> operation renames a file or directory.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="destinationPath">
        /// The destination path to rename the path to.
        /// </param>
        /// <param name="destinationFileSystem">
        /// Optional destination file system.  If null, path will be renamed within the
        /// current file system.
        /// </param>
        /// <param name="sourceConditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the source on the creation of this file or directory.
        /// </param>
        /// <param name="destinationConditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the creation of this file or directory.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<DataLakePathClient>> RenameInternal(
            string destinationPath,
            string destinationFileSystem,
            DataLakeRequestConditions sourceConditions,
            DataLakeRequestConditions destinationConditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(DataLakePathClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(DataLakePathClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(destinationFileSystem)}: {destinationFileSystem}\n" +
                    $"{nameof(destinationPath)}: {destinationPath}\n" +
                    $"{nameof(destinationConditions)}: {destinationConditions}\n" +
                    $"{nameof(sourceConditions)}: {sourceConditions}");
                try
                {
                    // Build renameSource
                    DataLakeUriBuilder sourceUriBuilder = new DataLakeUriBuilder(_dfsUri);
                    string renameSource = "/" + sourceUriBuilder.FileSystemName + "/" + sourceUriBuilder.DirectoryOrFilePath.EscapePath();

                    if (sourceUriBuilder.Sas != null)
                    {
                        renameSource += "?" + sourceUriBuilder.Sas;
                    }

                    // Build destination URI
                    DataLakeUriBuilder destUriBuilder = new DataLakeUriBuilder(_dfsUri)
                    {
                        Sas = null,
                        Query = null
                    };
                    destUriBuilder.FileSystemName = destinationFileSystem ?? destUriBuilder.FileSystemName;

                    // DataLakeUriBuider will encode the DirectoryOrFilePath.  We don't want the query parameters,
                    // especially SAS, to be encoded.
                    string[] split = destinationPath.Split('?');
                    if (split.Length == 2)
                    {
                        destUriBuilder.DirectoryOrFilePath = split[0];
                        destUriBuilder.Query = split[1];
                    }
                    else
                    {
                        destUriBuilder.DirectoryOrFilePath = destinationPath;
                    }

                    // Build destPathClient
                    DataLakePathClient destPathClient = new DataLakePathClient(destUriBuilder.ToUri(), Pipeline, SharedKeyCredential);

                    Response<PathCreateResult> response = await DataLakeRestClient.Path.CreateAsync(
                        clientDiagnostics: _clientDiagnostics,
                        pipeline: Pipeline,
                        resourceUri: destPathClient.DfsUri,
                        version: Version.ToVersionString(),
                        mode: PathRenameMode.Legacy,
                        renameSource: renameSource,
                        leaseId: destinationConditions?.LeaseId,
                        sourceLeaseId: sourceConditions?.LeaseId,
                        ifMatch: destinationConditions?.IfMatch,
                        ifNoneMatch: destinationConditions?.IfNoneMatch,
                        ifModifiedSince: destinationConditions?.IfModifiedSince,
                        ifUnmodifiedSince: destinationConditions?.IfUnmodifiedSince,
                        sourceIfMatch: sourceConditions?.IfMatch,
                        sourceIfNoneMatch: sourceConditions?.IfNoneMatch,
                        sourceIfModifiedSince: sourceConditions?.IfModifiedSince,
                        sourceIfUnmodifiedSince: sourceConditions?.IfUnmodifiedSince,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return Response.FromValue(
                        destPathClient,
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(DataLakePathClient));
                }
            }
        }
        #endregion Rename

        #region Get Access Control
        /// <summary>
        /// The <see cref="GetAccessControl"/> operation returns the
        /// access control data for a path.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/getproperties">
        /// Get Properties</see>.
        /// </summary>
        /// <param name="userPrincipalName">
        /// Optional.Valid only when Hierarchical Namespace is enabled for the account.If "true",
        /// the user identity values returned in the x-ms-owner, x-ms-group, and x-ms-acl response
        /// headers will be transformed from Azure Active Directory Object IDs to User Principal Names.
        /// If "false", the values will be returned as Azure Active Directory Object IDs.The default
        /// value is false. Note that group and application Object IDs are not translated because they
        /// do not have unique friendly names.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on getting the path's access control.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathAccessControl}"/> describing the
        /// path's access control.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<PathAccessControl> GetAccessControl(
            bool? userPrincipalName = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(GetAccessControl)}");

            try
            {
                scope.Start();

                return GetAccessControlInternal(
                    userPrincipalName,
                    conditions,
                    false, // async
                    cancellationToken)
                    .EnsureCompleted();
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
        /// The <see cref="GetAccessControlAsync"/> operation returns the
        /// access control data for a path.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/getproperties">
        /// Get Properties</see>.
        /// </summary>
        /// <param name="userPrincipalName">
        /// Optional.Valid only when Hierarchical Namespace is enabled for the account.If "true",
        /// the user identity values returned in the x-ms-owner, x-ms-group, and x-ms-acl response
        /// headers will be transformed from Azure Active Directory Object IDs to User Principal Names.
        /// If "false", the values will be returned as Azure Active Directory Object IDs.The default
        /// value is false. Note that group and application Object IDs are not translated because they
        /// do not have unique friendly names.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on getting the path's access control.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathAccessControl}"/> describing the
        /// path's access control.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<PathAccessControl>> GetAccessControlAsync(
            bool? userPrincipalName = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(GetAccessControl)}");

            try
            {
                scope.Start();

                return await GetAccessControlInternal(
                    userPrincipalName,
                    conditions,
                    true, // async
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

        /// <summary>
        /// The <see cref="GetAccessControlInternal"/> operation returns the
        /// access control data for a path.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/getproperties">
        /// Get Properties</see>.
        /// </summary>
        /// <param name="userPrincipalName">
        /// Optional.Valid only when Hierarchical Namespace is enabled for the account.If "true",
        /// the user identity values returned in the x-ms-owner, x-ms-group, and x-ms-acl response
        /// headers will be transformed from Azure Active Directory Object IDs to User Principal Names.
        /// If "false", the values will be returned as Azure Active Directory Object IDs.The default
        /// value is false. Note that group and application Object IDs are not translated because they
        /// do not have unique friendly names.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on getting the path's access control.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathAccessControl}"/> describing the
        /// path's access control.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<PathAccessControl>> GetAccessControlInternal(
            bool? userPrincipalName,
            DataLakeRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(DataLakePathClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(DataLakePathClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n");
                try
                {
                    Response<PathGetPropertiesResult> response = await DataLakeRestClient.Path.GetPropertiesAsync(
                        clientDiagnostics: _clientDiagnostics,
                        pipeline: Pipeline,
                        resourceUri: _dfsUri,
                        version: Version.ToVersionString(),
                        action: PathGetPropertiesAction.GetAccessControl,
                        upn: userPrincipalName,
                        leaseId: conditions?.LeaseId,
                        ifMatch: conditions?.IfMatch,
                        ifNoneMatch: conditions?.IfNoneMatch,
                        ifModifiedSince: conditions?.IfModifiedSince,
                        ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return Response.FromValue(
                        new PathAccessControl()
                        {
                            Owner = response.Value.Owner,
                            Group = response.Value.Group,
                            Permissions = PathPermissions.ParseSymbolicPermissions(response.Value.Permissions),
                            AccessControlList = PathAccessControlExtensions.ParseAccessControlList(response.Value.ACL)
                        },
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(DataLakePathClient));
                }
            }
        }
        #endregion Get Access Control

        #region Set Access Control
        /// <summary>
        /// The <see cref="SetAccessControlList"/> operation sets the
        /// Access Control on a path
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
        /// </summary>
        /// <param name="accessControlList">
        /// The POSIX access control list for the file or directory.
        /// </param>
        /// <param name="owner">
        /// The owner of the file or directory.
        /// </param>
        /// <param name="group">
        /// The owning group of the file or directory.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the the path's access control.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the updated
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<PathInfo> SetAccessControlList(
            IList<PathAccessControlItem> accessControlList,
            string owner = default,
            string group = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(SetAccessControlList)}");

            try
            {
                scope.Start();

                return SetAccessControlListInternal(
                    accessControlList,
                    owner,
                    group,
                    conditions,
                    false, // async
                    cancellationToken)
                    .EnsureCompleted();
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
        /// The <see cref="SetAccessControlListAsync"/> operation sets the
        /// Access Control on a path
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
        /// </summary>
        /// <param name="accessControlList">
        /// The POSIX access control list for the file or directory.
        /// </param>
        /// <param name="owner">
        /// The owner of the file or directory.
        /// </param>
        /// <param name="group">
        /// The owning group of the file or directory.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the the path's access control.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the updated
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<PathInfo>> SetAccessControlListAsync(
            IList<PathAccessControlItem> accessControlList,
            string owner = default,
            string group = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(SetAccessControlList)}");

            try
            {
                scope.Start();

                return await SetAccessControlListInternal(
                    accessControlList,
                    owner,
                    group,
                    conditions,
                    true, // async
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

        /// <summary>
        /// The <see cref="SetAccessControlListInternal"/> operation sets the
        /// Access Control on a path
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
        /// </summary>
        /// <param name="accessControlList">
        /// The POSIX access control list for the file or directory.
        /// </param>
        /// <param name="owner">
        /// The owner of the file or directory.
        /// </param>
        /// <param name="group">
        /// The owning group of the file or directory.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the the path's access control.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the updated
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<PathInfo>> SetAccessControlListInternal(
            IList<PathAccessControlItem> accessControlList,
            string owner,
            string group,
            DataLakeRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(DataLakePathClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(DataLakePathClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(accessControlList)}: {accessControlList}\n" +
                    $"{nameof(owner)}: {owner}\n" +
                    $"{nameof(group)}: {group}\n" +
                    $"{nameof(conditions)}: {conditions}");
                try
                {
                    Response<PathSetAccessControlResult> response =
                        await DataLakeRestClient.Path.SetAccessControlAsync(
                            clientDiagnostics: _clientDiagnostics,
                            pipeline: Pipeline,
                            resourceUri: _dfsUri,
                            version: Version.ToVersionString(),
                            leaseId: conditions?.LeaseId,
                            owner: owner,
                            group: group,
                            acl: PathAccessControlExtensions.ToAccessControlListString(accessControlList),
                            ifMatch: conditions?.IfMatch,
                            ifNoneMatch: conditions?.IfNoneMatch,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            async: async,
                            cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return Response.FromValue(
                        new PathInfo()
                        {
                            ETag = response.Value.ETag,
                            LastModified = response.Value.LastModified
                        },
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(DataLakePathClient));
                }
            }
        }
        #endregion Set Access Control

        #region Set Access Control Recursive
        /// <summary>
        /// The <see cref="SetAccessControlRecursive"/> operation sets the
        /// Access Control on a path and subpaths
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
        /// </summary>
        /// <param name="accessControlList">
        /// The POSIX access control list for the file or directory.
        /// </param>
        /// <param name="continuationToken">
        /// Optional continuation token that can be used to resume previously stopped operation.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="AccessControlChangeOptions"/> with additional controls.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{AccessControlChangeResult}"/> that contains summary stats of the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="DataLakeAclChangeFailedException"/> will be thrown if a request to
        /// storage throws a <see cref="RequestFailedException"/> or <see cref="Exception"/>.
        ///
        /// Otherwise if a failure occurs outside the request, the respective <see cref="Exception"/>
        /// type will be thrown if a failure occurs.
        /// </remarks>
        public virtual Response<AccessControlChangeResult> SetAccessControlRecursive(
            IList<PathAccessControlItem> accessControlList,
            string continuationToken = default,
            AccessControlChangeOptions options = default,
            CancellationToken cancellationToken = default)
        {
            return SetAccessControlRecursiveInternal(
                $"{nameof(DataLakePathClient)}.{nameof(SetAccessControlRecursive)}",
                PathAccessControlExtensions.ToAccessControlListString(accessControlList),
                PathSetAccessControlRecursiveMode.Set,
                continuationToken,
                options,
                async: false,
                cancellationToken)
                .EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="SetAccessControlRecursiveAsync"/> operation sets the
        /// Access Control on a path and subpaths
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
        /// </summary>
        /// <param name="accessControlList">
        /// The POSIX access control list for the file or directory.
        /// </param>
        /// <param name="continuationToken">
        /// Optional continuation token that can be used to resume previously stopped operation.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="AccessControlChangeOptions"/> with additional controls.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{AccessControlChangeResult}"/> that contains summary stats of the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="DataLakeAclChangeFailedException"/> will be thrown if a request to
        /// storage throws a <see cref="RequestFailedException"/> or <see cref="Exception"/>.
        ///
        /// Otherwise if a failure occurs outside the request, the respective <see cref="Exception"/>
        /// type will be thrown if a failure occurs.
        /// </remarks>
        public virtual async Task<Response<AccessControlChangeResult>> SetAccessControlRecursiveAsync(
            IList<PathAccessControlItem> accessControlList,
            string continuationToken = default,
            AccessControlChangeOptions options = default,
            CancellationToken cancellationToken = default)
        {
            return await SetAccessControlRecursiveInternal(
                $"{nameof(DataLakePathClient)}.{nameof(SetAccessControlRecursive)}",
                PathAccessControlExtensions.ToAccessControlListString(accessControlList),
                PathSetAccessControlRecursiveMode.Set,
                continuationToken,
                options,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// The <see cref="UpdateAccessControlRecursive"/> operation modifies the
        /// Access Control on a path and subpaths
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
        /// </summary>
        /// <param name="accessControlList">
        /// The POSIX access control list for the file or directory.
        /// </param>
        /// <param name="continuationToken">
        /// Optional continuation token that can be used to resume previously stopped operation.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="AccessControlChangeOptions"/> with additional controls.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{AccessControlChangeResult}"/> that contains summary stats of the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="DataLakeAclChangeFailedException"/> will be thrown if a request to
        /// storage throws a <see cref="RequestFailedException"/> or <see cref="Exception"/>.
        ///
        /// Otherwise if a failure occurs outside the request, the respective <see cref="Exception"/>
        /// type will be thrown if a failure occurs.
        /// </remarks>
        public virtual Response<AccessControlChangeResult> UpdateAccessControlRecursive(
            IList<PathAccessControlItem> accessControlList,
            string continuationToken = default,
            AccessControlChangeOptions options = default,
            CancellationToken cancellationToken = default)
        {
            return SetAccessControlRecursiveInternal(
                $"{nameof(DataLakePathClient)}.{nameof(UpdateAccessControlRecursive)}",
                PathAccessControlExtensions.ToAccessControlListString(accessControlList),
                PathSetAccessControlRecursiveMode.Modify,
                continuationToken,
                options,
                async: false,
                cancellationToken)
                .EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="UpdateAccessControlRecursiveAsync"/> operation modifies the
        /// Access Control on a path and subpaths
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
        /// </summary>
        /// <param name="accessControlList">
        /// The POSIX access control list for the file or directory.
        /// </param>
        /// <param name="continuationToken">
        /// Optional continuation token that can be used to resume previously stopped operation.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="AccessControlChangeOptions"/> with additional controls.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{AccessControlChangeResult}"/> that contains summary stats of the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="DataLakeAclChangeFailedException"/> will be thrown if a request to
        /// storage throws a <see cref="RequestFailedException"/> or <see cref="Exception"/>.
        ///
        /// Otherwise if a failure occurs outside the request, the respective <see cref="Exception"/>
        /// type will be thrown if a failure occurs.
        /// </remarks>
        public virtual async Task<Response<AccessControlChangeResult>> UpdateAccessControlRecursiveAsync(
            IList<PathAccessControlItem> accessControlList,
            string continuationToken = default,
            AccessControlChangeOptions options = default,
            CancellationToken cancellationToken = default)
        {
            return await SetAccessControlRecursiveInternal(
                $"{nameof(DataLakePathClient)}.{nameof(UpdateAccessControlRecursive)}",
                PathAccessControlExtensions.ToAccessControlListString(accessControlList),
                PathSetAccessControlRecursiveMode.Modify,
                continuationToken,
                options,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// The <see cref="RemoveAccessControlRecursive"/> operation removes the
        /// Access Control on a path and subpaths
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
        /// </summary>
        /// <param name="accessControlList">
        /// The POSIX access control list for the file or directory.
        /// </param>
        /// <param name="continuationToken">
        /// Optional continuation token that can be used to resume previously stopped operation.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="AccessControlChangeOptions"/> with additional controls.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{AccessControlChangeResult}"/> that contains summary stats of the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="DataLakeAclChangeFailedException"/> will be thrown if a request to
        /// storage throws a <see cref="RequestFailedException"/> or <see cref="Exception"/>.
        ///
        /// Otherwise if a failure occurs outside the request, the respective <see cref="Exception"/>
        /// type will be thrown if a failure occurs.
        /// </remarks>
        public virtual Response<AccessControlChangeResult> RemoveAccessControlRecursive(
            IList<RemovePathAccessControlItem> accessControlList,
            string continuationToken = default,
            AccessControlChangeOptions options = default,
            CancellationToken cancellationToken = default)
        {
            return SetAccessControlRecursiveInternal(
                $"{nameof(DataLakePathClient)}.{nameof(RemoveAccessControlRecursive)}",
                RemovePathAccessControlItem.ToAccessControlListString(accessControlList),
                PathSetAccessControlRecursiveMode.Remove,
                continuationToken,
                options,
                async: false,
                cancellationToken)
                .EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="RemoveAccessControlRecursiveAsync"/> operation removes the
        /// Access Control on a path and subpaths
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
        /// </summary>
        /// <param name="accessControlList">
        /// The POSIX access control list for the file or directory.
        /// </param>
        /// <param name="continuationToken">
        /// Optional continuation token that can be used to resume previously stopped operation.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="AccessControlChangeOptions"/> with additional controls.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{AccessControlChangeResult}"/> that contains summary stats of the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="DataLakeAclChangeFailedException"/> will be thrown if a request to
        /// storage throws a <see cref="RequestFailedException"/> or <see cref="Exception"/>.
        ///
        /// Otherwise if a failure occurs outside the request, the respective <see cref="Exception"/>
        /// type will be thrown if a failure occurs.
        /// </remarks>
        public virtual async Task<Response<AccessControlChangeResult>> RemoveAccessControlRecursiveAsync(
            IList<RemovePathAccessControlItem> accessControlList,
            string continuationToken = default,
            AccessControlChangeOptions options = default,
            CancellationToken cancellationToken = default)
        {
            return await SetAccessControlRecursiveInternal(
                $"{nameof(DataLakePathClient)}.{nameof(RemoveAccessControlRecursive)}",
                RemovePathAccessControlItem.ToAccessControlListString(accessControlList),
                PathSetAccessControlRecursiveMode.Remove,
                continuationToken,
                options,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// The <see cref="SetAccessControlRecursiveInternal"/> operation sets the
        /// Access Control on a path and subpaths
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
        /// </summary>
        /// <param name="operationName">
        /// The operation name for diagnostic purpose.
        /// </param>
        /// <param name="accessControlList">
        /// The POSIX access control list for the file or directory.
        /// </param>
        /// <param name="mode">
        /// Mode \"set\" sets POSIX access control rights on files and directories,
        /// \"modify\" modifies one or more POSIX access control rights  that pre-exist on files and directories,
        /// \"remove\" removes one or more POSIX access control rights that were present earlier on files and directories.
        /// </param>
        /// <param name="continuationToken">
        /// Optional continuation token that can be used to resume previously stopped operation.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="AccessControlChangeOptions"/> with additional controls.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{AccessControlChangeResult}"/> describing the updated
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="DataLakeAclChangeFailedException"/> will be thrown if a request to
        /// storage throws a <see cref="RequestFailedException"/> or <see cref="Exception"/>.
        ///
        /// Otherwise if a failure occurs outside the request, the respective <see cref="Exception"/>
        /// type will be thrown if a failure occurs.
        /// </remarks>
        private async Task<Response<AccessControlChangeResult>> SetAccessControlRecursiveInternal(
            string operationName,
            string accessControlList,
            PathSetAccessControlRecursiveMode mode,
            string continuationToken,
            AccessControlChangeOptions options,
            bool async,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope(operationName);

            try
            {
                scope.Start();
                using (Pipeline.BeginLoggingScope(nameof(DataLakePathClient)))
                {
                    Pipeline.LogMethodEnter(
                        nameof(DataLakePathClient),
                        message:
                        $"{nameof(Uri)}: {Uri}\n" +
                        $"{nameof(accessControlList)}: {accessControlList}\n" +
                        $"{nameof(mode)}: {mode}\n" +
                        $"batchSize: {options.BatchSize}");
                    try
                    {
                        Response<PathSetAccessControlRecursiveResult> jsonResponse = null;
                        string lastContinuationToken = null;

                        int directoriesSuccessfulCount = 0;
                        int filesSuccessfulCount = 0;
                        int failureCount = 0;
                        int batchesCount = 0;
                        AccessControlChangeFailure[] batchFailures = default;

                        do
                        {
                            try
                            {
                                jsonResponse =
                                    await DataLakeRestClient.Path.SetAccessControlRecursiveAsync(
                                        clientDiagnostics: ClientDiagnostics,
                                        pipeline: Pipeline,
                                        resourceUri: DfsUri,
                                        mode: mode,
                                        maxRecords: options?.BatchSize,
                                        version: Version.ToVersionString(),
                                        acl: accessControlList,
                                        async: async,
                                        continuation: continuationToken,
                                        forceFlag: options?.ContinueOnFailure,
                                        cancellationToken: cancellationToken)
                                    .ConfigureAwait(false);
                            }
                            catch (RequestFailedException exception)
                            {
                                throw DataLakeErrors.ChangeAclRequestFailed(exception, continuationToken);
                            }
                            catch (Exception exception)
                            {
                                throw DataLakeErrors.ChangeAclFailed(exception, continuationToken);
                            }
                            continuationToken = jsonResponse.Value.Continuation;

                            if (!string.IsNullOrEmpty(continuationToken))
                            {
                                lastContinuationToken = continuationToken;
                            }

                            using (JsonDocument document = JsonDocument.Parse(jsonResponse.Value.Body))
                            {
                                SetAccessControlRecursiveResponse response = document.RootElement.DeserializeSetAccessControlRecursiveResponse();

                                int currentDirectoriesSuccessfulCount = response.DirectoriesSuccessful ?? 0;
                                int currentFilesSuccessfulCount = response.FilesSuccessful ?? 0;
                                int currentFailureCount = response.FailureCount ?? 0;

                                directoriesSuccessfulCount += currentDirectoriesSuccessfulCount;
                                filesSuccessfulCount += currentFilesSuccessfulCount;
                                failureCount += currentFailureCount;

                                if ((currentFailureCount > 0) && (batchFailures == default))
                                {
                                    batchFailures = response.FailedEntries
                                    .Select(failedEntry => new AccessControlChangeFailure()
                                    {
                                        Name = failedEntry.Name,
                                        IsDirectory = failedEntry.Type.Equals("DIRECTORY", StringComparison.InvariantCultureIgnoreCase),
                                        ErrorMessage = failedEntry.ErrorMessage,
                                    }).ToArray();
                                }
                                if (options?.ProgressHandler != null)
                                {
                                    var failedEntries = response.FailedEntries
                                        .Select(failedEntry => new AccessControlChangeFailure()
                                        {
                                            Name = failedEntry.Name,
                                            IsDirectory = failedEntry.Type.Equals("DIRECTORY", StringComparison.InvariantCultureIgnoreCase),
                                            ErrorMessage = failedEntry.ErrorMessage,
                                        }).ToList();

                                    options.ProgressHandler.Report(
                                        Response.FromValue(
                                            new AccessControlChanges()
                                            {
                                                BatchCounters = new AccessControlChangeCounters()
                                                {
                                                    ChangedDirectoriesCount = currentDirectoriesSuccessfulCount,
                                                    ChangedFilesCount = currentFilesSuccessfulCount,
                                                    FailedChangesCount = currentFailureCount,
                                                },
                                                AggregateCounters = new AccessControlChangeCounters()
                                                {
                                                    ChangedDirectoriesCount = directoriesSuccessfulCount,
                                                    ChangedFilesCount = filesSuccessfulCount,
                                                    FailedChangesCount = failureCount,
                                                },
                                                BatchFailures = failedEntries.ToArray(),
                                                ContinuationToken = lastContinuationToken,
                                            },
                                            jsonResponse.GetRawResponse()));
                                }
                            }
                            batchesCount++;
                        } while (!string.IsNullOrEmpty(continuationToken)
                            && (!options.MaxBatches.HasValue || batchesCount < options.MaxBatches.Value));

                        return Response.FromValue(
                            new AccessControlChangeResult()
                            {
                                Counters = new AccessControlChangeCounters()
                                {
                                    ChangedDirectoriesCount = directoriesSuccessfulCount,
                                    ChangedFilesCount = filesSuccessfulCount,
                                    FailedChangesCount = failureCount,
                                },
                                ContinuationToken =
                                    (failureCount > 0) && !(options?.ContinueOnFailure == true)
                                        ? lastContinuationToken
                                        : continuationToken,
                                BatchFailures = batchFailures
                            },
                            jsonResponse.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        Pipeline.LogException(ex);
                        throw;
                    }
                    finally
                    {
                        Pipeline.LogMethodExit(nameof(DataLakePathClient));
                    }
                }
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
        #endregion Set Access Control Recursive

        #region Set Permissions
        /// <summary>
        /// The <see cref="SetPermissions"/> operation sets the
        /// file permissions on a path.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
        /// </summary>
        /// <param name="permissions">
        ///  The POSIX access permissions for the file owner, the file owning group, and others.
        /// </param>
        /// <param name="owner">
        /// The owner of the file or directory.
        /// </param>
        /// <param name="group">
        /// The owning group of the file or directory.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the the path's access control.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the updated
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<PathInfo> SetPermissions(
            PathPermissions permissions,
            string owner = default,
            string group = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(SetPermissions)}");

            try
            {
                scope.Start();

                return SetPermissionsInternal(
                    permissions,
                    owner,
                    group,
                    conditions,
                    false, // async
                    cancellationToken)
                    .EnsureCompleted();
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
        /// The <see cref="SetPermissionsAsync"/> operation sets the
        /// file permissions on a path.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
        /// </summary>
        /// <param name="permissions">
        ///  The POSIX access permissions for the file owner, the file owning group, and others.
        /// </param>
        /// <param name="owner">
        /// The owner of the file or directory.
        /// </param>
        /// <param name="group">
        /// The owning group of the file or directory.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the the path's access control.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the updated
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<PathInfo>> SetPermissionsAsync(
            PathPermissions permissions,
            string owner = default,
            string group = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(SetPermissions)}");

            try
            {
                scope.Start();

                return await SetPermissionsInternal(
                    permissions,
                    owner,
                    group,
                    conditions,
                    true, // async
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

        /// <summary>
        /// The <see cref="SetPermissionsInternal"/> operation sets the
        /// file permissions on a path.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
        /// </summary>
        /// <param name="permissions">
        ///  The POSIX access permissions for the file owner, the file owning group, and others.
        /// </param>
        /// <param name="owner">
        /// The owner of the file or directory.
        /// </param>
        /// <param name="group">
        /// The owning group of the file or directory.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the the path's access control.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the updated
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<PathInfo>> SetPermissionsInternal(
            PathPermissions permissions,
            string owner,
            string group,
            DataLakeRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(DataLakePathClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(DataLakePathClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(permissions)}: {permissions}\n" +
                    $"{nameof(owner)}: {owner}\n" +
                    $"{nameof(group)}: {group}\n" +
                    $"{nameof(conditions)}: {conditions}");
                try
                {
                    Response<PathSetAccessControlResult> response =
                        await DataLakeRestClient.Path.SetAccessControlAsync(
                            clientDiagnostics: _clientDiagnostics,
                            pipeline: Pipeline,
                            resourceUri: _dfsUri,
                            version: Version.ToVersionString(),
                            leaseId: conditions?.LeaseId,
                            owner: owner,
                            group: group,
                            permissions: permissions?.ToSymbolicPermissions(),
                            ifMatch: conditions?.IfMatch,
                            ifNoneMatch: conditions?.IfNoneMatch,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            async: async,
                            cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return Response.FromValue(
                        new PathInfo()
                        {
                            ETag = response.Value.ETag,
                            LastModified = response.Value.LastModified
                        },
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(DataLakePathClient));
                }
            }
        }
        #endregion Set Permission

        #region Get Properties
        /// <summary>
        /// The <see cref="GetProperties"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the path. It does not return the content of the
        /// path.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob-properties">
        /// Get Properties</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on getting the path's properties.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathProperties}"/> describing the
        /// path's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<PathProperties> GetProperties(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(GetProperties)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobProperties> response = _blockBlobClient.GetProperties(
                    conditions.ToBlobRequestConditions(),
                    cancellationToken);

                return Response.FromValue(
                    response.Value.ToPathProperties(),
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
        /// The <see cref="GetPropertiesAsync"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the path. It does not return the content of the
        /// path.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob-properties">
        /// Get Properties</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on getting the path's properties.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathProperties}"/> describing the
        /// paths's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<PathProperties>> GetPropertiesAsync(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(GetProperties)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobProperties> response = await _blockBlobClient.GetPropertiesAsync(
                    conditions.ToBlobRequestConditions(),
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    response.Value.ToPathProperties(),
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
        #endregion Get Properties

        #region Set Http Headers
        /// <summary>
        /// The <see cref="SetHttpHeaders"/> operation sets system
        /// properties on the path.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-properties">
        /// Set Properties</see>.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional. The standard HTTP header system properties to set.  If not specified, existing values will be cleared.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the paths's HTTP headers.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{httpHeaders}"/> describing the updated
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<PathInfo> SetHttpHeaders(
            PathHttpHeaders httpHeaders = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(SetHttpHeaders)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobInfo> response = _blockBlobClient.SetHttpHeaders(
                    httpHeaders.ToBlobHttpHeaders(),
                    conditions.ToBlobRequestConditions(),
                    cancellationToken);

                return Response.FromValue(
                    response.Value.ToPathInfo(),
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
        /// The <see cref="SetHttpHeadersAsync"/> operation sets system
        /// properties on the PATH.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-properties">
        /// Set Properties</see>.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional. The standard HTTP header system properties to set.  If not specified, existing values will be cleared.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the path's HTTP headers.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the updated
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<PathInfo>> SetHttpHeadersAsync(
            PathHttpHeaders httpHeaders = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(SetHttpHeaders)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobInfo> response = await _blockBlobClient.SetHttpHeadersAsync(
                    httpHeaders.ToBlobHttpHeaders(),
                    conditions.ToBlobRequestConditions(),
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    response.Value.ToPathInfo(),
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
        #endregion Set Http Headers

        #region Set Metadata
        /// <summary>
        /// The <see cref="SetMetadata"/> operation sets user-defined
        /// metadata for the specified path as one or more name-value pairs.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-metadata">
        /// Set Metadata</see>.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this path.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the path's metadata.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the updated
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<PathInfo> SetMetadata(
            Metadata metadata,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(SetMetadata)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobInfo> response = _blockBlobClient.SetMetadata(
                    metadata,
                    conditions.ToBlobRequestConditions(),
                    cancellationToken);

                return Response.FromValue(
                    response.Value.ToPathInfo(),
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
        /// The <see cref="SetMetadataAsync"/> operation sets user-defined
        /// metadata for the specified path as one or more name-value pairs.
        ///
        ///For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-metadata">
        /// Set Metadata</see>.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this path.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the path's metadata.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobInfo}"/> describing the updated
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<PathInfo>> SetMetadataAsync(
            Metadata metadata,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(SetMetadata)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobInfo> response = await _blockBlobClient.SetMetadataAsync(
                    metadata,
                    conditions.ToBlobRequestConditions(),
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    response.Value.ToPathInfo(),
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
        #endregion Set Metadata

        #region GenerateSas
        /// <summary>
        /// The <see cref="GenerateSasUri(DataLakeSasPermissions, DateTimeOffset)"/>
        /// returns a <see cref="Uri"/> that generates a DataLake Path Service
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
        /// See <see cref="DataLakeSasPermissions"/>.
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
        public virtual Uri GenerateSasUri(DataLakeSasPermissions permissions, DateTimeOffset expiresOn) =>
            GenerateSasUri(new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = FileSystemName,
                Path = Path
            });

        /// <summary>
        /// The <see cref="GenerateSasUri(DataLakeSasBuilder)"/> returns a <see cref="Uri"/>
        /// that generates a DataLake File Service Shared Access Signature (SAS) Uri
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
        public virtual Uri GenerateSasUri(DataLakeSasBuilder builder)
        {
            builder = builder ?? throw Errors.ArgumentNull(nameof(builder));
            if (builder.IsDirectory.GetValueOrDefault(false))
            {
                throw Errors.SasIncorrectResourceType(
                    nameof(builder),
                    nameof(builder.IsDirectory),
                    nameof(Constants.FalseName),
                    nameof(this.GetType));
            }
            if (!builder.FileSystemName.Equals(FileSystemName, StringComparison.InvariantCulture))
            {
                throw Errors.SasNamesNotMatching(
                    nameof(builder.FileSystemName),
                    nameof(DataLakeSasBuilder),
                    nameof(FileSystemName));
            }
            if (!builder.Path.Equals(Path, StringComparison.InvariantCulture))
            {
                throw Errors.SasNamesNotMatching(
                    nameof(builder.Path),
                    nameof(DataLakeSasBuilder),
                    nameof(Path));
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
