// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Common;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Sas;
using Azure.Storage.Shared;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

#pragma warning disable SA1402  // File may only contain a single type

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
        /// <see cref="DataLakeClientConfiguration"/>.
        /// </summary>
        private readonly DataLakeClientConfiguration _clientConfiguration;

        /// <summary>
        /// <see cref="DataLakeClientConfiguration"/>.
        /// </summary>
        internal virtual DataLakeClientConfiguration ClientConfiguration => _clientConfiguration;

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
        /// Indicates whether the client is able to generate a SAS uri.
        /// Client can generate a SAS url if it is authenticated with a <see cref="StorageSharedKeyCredential"/>.
        /// </summary>
        public virtual bool CanGenerateSasUri => ClientConfiguration.SharedKeyCredential != null;

        /// <summary>
        /// <see cref="PathRestClient"/> pointed at the DFS endpoint.
        /// </summary>
        private readonly PathRestClient _pathRestClient;

        /// <summary>
        /// <see cref="PathRestClient"/> pointed at the DFS endpoint.
        /// </summary>
        internal virtual PathRestClient PathRestClient => _pathRestClient;

        /// <summary>
        /// <see cref="PathRestClient"/> pointed at the Blob endpoint.
        /// </summary>
        private readonly PathRestClient _blobPathRestClient;

        /// <summary>
        /// <see cref="PathRestClient"/> pointed at the Blob endpoint.
        /// </summary>
        internal virtual PathRestClient BlobPathRestClient => _blobPathRestClient;

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
            : this(pathUri, options: null)
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
            : this(
                  pathUri,
                  (HttpPipelinePolicy)null,
                  options,
                  storageSharedKeyCredential: null,
                  sasCredential: null,
                  tokenCredential: null)
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
            Argument.AssertNotNullOrWhiteSpace(fileSystemName, nameof(fileSystemName));
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
            _accountName = conn.AccountName;
            _path = path;

            _clientConfiguration = new DataLakeClientConfiguration(
                pipeline: options.Build(conn.Credentials),
                sharedKeyCredential: sharedKeyCredential,
                clientDiagnostics: new ClientDiagnostics(options),
                clientOptions: options,
                customerProvidedKey: options.CustomerProvidedKey);

            _blockBlobClient = BlockBlobClientInternals.Create(
                _blobUri,
                _clientConfiguration);

            (PathRestClient dfsPathRestClient, PathRestClient blobPathRestClient) = BuildPathRestClients(_dfsUri, _blobUri);
            _pathRestClient = dfsPathRestClient;
            _blobPathRestClient = blobPathRestClient;

            DataLakeErrors.VerifyHttpsCustomerProvidedKey(_uri, _clientConfiguration.CustomerProvidedKey);
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
            : this(pathUri, credential, default)
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
            : this(
                  pathUri,
                  credential.AsPolicy(),
                  options,
                  storageSharedKeyCredential: credential,
                  sasCredential: null,
                  tokenCredential: null)
        {
            _accountName ??= credential?.AccountName;
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
            : this(
                  pathUri,
                  credential.AsPolicy<DataLakeUriBuilder>(pathUri),
                  options,
                  storageSharedKeyCredential: null,
                  sasCredential: credential,
                  tokenCredential: null)
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
            : this(pathUri, credential, null)
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
            : this(
                pathUri,
                credential.AsPolicy(
                    string.IsNullOrEmpty(options?.Audience?.ToString()) ? DataLakeAudience.DefaultAudience.CreateDefaultScope() : options.Audience.Value.CreateDefaultScope(),
                    options),
                options,
                storageSharedKeyCredential: null,
                sasCredential: null,
                tokenCredential: credential)
        {
            Errors.VerifyHttpsTokenAuth(pathUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>.
        /// </summary>
        /// <param name="fileSystemClient"><see cref="DataLakeFileSystemClient"/> of the path's File System.</param>
        /// <param name="path">The path to the <see cref="DataLakePathClient"/>.</param>
        public DataLakePathClient(DataLakeFileSystemClient fileSystemClient, string path)
            : this((new DataLakeUriBuilder(fileSystemClient.Uri) { DirectoryOrFilePath = path }).ToDfsUri(),
                  fileSystemClient.ClientConfiguration)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>
        /// class.
        ///
        /// This will create an instance that uses the same diagnostics as another
        /// client. This client will be used within another API call of the parent
        /// client (namely Rename). This is in the case that the new child client
        /// has different credentials than the parent client.
        /// </summary>
        /// <param name="pathUri">
        /// A <see cref="Uri"/> referencing the resource that includes the
        /// name of the account, the name of the file system, and the path to the
        /// resource.
        /// </param>
        /// <param name="diagnostics">
        /// The diagnostics from the parent client.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="DataLakeClientOptions"/> that define the transport
        /// pipeline policies for authentication, retries, etc., that are
        /// applied to every request.
        /// </param>
        internal DataLakePathClient(
            Uri pathUri,
            ClientDiagnostics diagnostics,
            DataLakeClientOptions options)
        {
            Argument.AssertNotNull(pathUri, nameof(pathUri));
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(pathUri);
            options ??= new DataLakeClientOptions();
            _uri = pathUri;
            _blobUri = uriBuilder.ToBlobUri();
            _dfsUri = uriBuilder.ToDfsUri();

            _clientConfiguration = new DataLakeClientConfiguration(
                pipeline: options.Build(),
                sharedKeyCredential: default,
                clientDiagnostics: diagnostics,
                clientOptions: options,
                customerProvidedKey: options.CustomerProvidedKey);

            _blockBlobClient = BlockBlobClientInternals.Create(_blobUri, _clientConfiguration);

            uriBuilder.DirectoryOrFilePath = null;

            _fileSystemClient = new DataLakeFileSystemClient(
                uriBuilder.ToDfsUri(),
                _clientConfiguration);

            (PathRestClient dfsPathRestClient, PathRestClient blobPathRestClient) = BuildPathRestClients(_dfsUri, _blobUri);
            _pathRestClient = dfsPathRestClient;
            _blobPathRestClient = blobPathRestClient;

            DataLakeErrors.VerifyHttpsCustomerProvidedKey(_uri, _clientConfiguration.CustomerProvidedKey);
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
        /// <param name="sasCredential">
        /// The SAS credential used to sign requests.
        /// </param>
        /// <param name="tokenCredential">
        /// The token credential used to sign requests.
        /// </param>
        internal DataLakePathClient(
            Uri pathUri,
            HttpPipelinePolicy authentication,
            DataLakeClientOptions options,
            StorageSharedKeyCredential storageSharedKeyCredential,
            AzureSasCredential sasCredential,
            TokenCredential tokenCredential)
        {
            Argument.AssertNotNull(pathUri, nameof(pathUri));
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(pathUri);
            options ??= new DataLakeClientOptions();
            _uri = pathUri;
            _blobUri = uriBuilder.ToBlobUri();
            _dfsUri = uriBuilder.ToDfsUri();

            _clientConfiguration = new DataLakeClientConfiguration(
                pipeline: options.Build(authentication),
                sharedKeyCredential: storageSharedKeyCredential,
                sasCredential: sasCredential,
                tokenCredential: tokenCredential,
                clientDiagnostics: new ClientDiagnostics(options),
                clientOptions: options,
                customerProvidedKey: options.CustomerProvidedKey);

            _blockBlobClient = BlockBlobClientInternals.Create(_blobUri, _clientConfiguration);

            uriBuilder.DirectoryOrFilePath = null;

            _fileSystemClient = new DataLakeFileSystemClient(
                uriBuilder.ToDfsUri(),
                _clientConfiguration);

            (PathRestClient dfsPathRestClient, PathRestClient blobPathRestClient) = BuildPathRestClients(_dfsUri, _blobUri);
            _pathRestClient = dfsPathRestClient;
            _blobPathRestClient = blobPathRestClient;

            DataLakeErrors.VerifyHttpsCustomerProvidedKey(_uri, _clientConfiguration.CustomerProvidedKey);
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
        /// <param name="clientConfiguration">
        /// <see cref="DataLakeClientConfiguration"/>.
        /// </param>
        internal DataLakePathClient(
            Uri pathUri,
            DataLakeClientConfiguration clientConfiguration)
        {
            var uriBuilder = new DataLakeUriBuilder(pathUri);
            _uri = pathUri;
            _blobUri = uriBuilder.ToBlobUri();
            _dfsUri = uriBuilder.ToDfsUri();
            _clientConfiguration = clientConfiguration;

            _blockBlobClient = BlockBlobClientInternals.Create(
                _blobUri,
                _clientConfiguration);

            uriBuilder.DirectoryOrFilePath = null;

            _fileSystemClient = new DataLakeFileSystemClient(
                uriBuilder.ToDfsUri(),
                _clientConfiguration);

            (PathRestClient dfsPathRestClient, PathRestClient blobPathRestClient) = BuildPathRestClients(_dfsUri, _blobUri);
            _pathRestClient = dfsPathRestClient;
            _blobPathRestClient = blobPathRestClient;

            DataLakeErrors.VerifyHttpsCustomerProvidedKey(_uri, _clientConfiguration.CustomerProvidedKey);
        }

        internal DataLakePathClient(
            Uri fileSystemUri,
            string directoryOrFilePath,
            DataLakeClientConfiguration clientConfiguration)
        {
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(fileSystemUri)
            {
                DirectoryOrFilePath = directoryOrFilePath
            };
            _uri = uriBuilder.ToUri();
            _blobUri = uriBuilder.ToBlobUri();
            _dfsUri = uriBuilder.ToDfsUri();

            _clientConfiguration = clientConfiguration;

            _blockBlobClient = BlockBlobClientInternals.Create(
                _blobUri,
                _clientConfiguration);

            uriBuilder.DirectoryOrFilePath = null;
            _fileSystemClient = new DataLakeFileSystemClient(
                uriBuilder.ToDfsUri(),
                clientConfiguration);

            (PathRestClient dfsPathRestClient, PathRestClient blobPathRestClient) = BuildPathRestClients(_dfsUri, _blobUri);
            _pathRestClient = dfsPathRestClient;
            _blobPathRestClient = blobPathRestClient;

            DataLakeErrors.VerifyHttpsCustomerProvidedKey(_uri, _clientConfiguration.CustomerProvidedKey);
        }

        private (PathRestClient DfsPathClient, PathRestClient BlobPathClient) BuildPathRestClients(Uri dfsUri, Uri blobUri)
        {
            PathRestClient dfsPathRestClient = new PathRestClient(
                clientDiagnostics: _clientConfiguration.ClientDiagnostics,
                pipeline: _clientConfiguration.Pipeline,
                url: dfsUri.AbsoluteUri,
                version: _clientConfiguration.ClientOptions.Version.ToVersionString());

            PathRestClient blobPathRestClient = new PathRestClient(
                clientDiagnostics: _clientConfiguration.ClientDiagnostics,
                pipeline: _clientConfiguration.Pipeline,
                url: blobUri.AbsoluteUri,
                version: _clientConfiguration.ClientOptions.Version.ToVersionString());

            return (dfsPathRestClient, blobPathRestClient);
        }

        /// <summary>
        /// Helper to access protected static members of BlockBlobClient
        /// that should not be exposed directly to customers.
        /// </summary>
        private class BlockBlobClientInternals : BlockBlobClient
        {
            public static BlockBlobClient Create(
                Uri uri,
                DataLakeClientConfiguration clientConfiguration)
            {
                var options = new BlobClientOptions(clientConfiguration.ClientOptions.Version.AsBlobsVersion())
                {
                    Diagnostics = { IsDistributedTracingEnabled = clientConfiguration.ClientDiagnostics.IsActivityEnabled },
                    CustomerProvidedKey = clientConfiguration.CustomerProvidedKey.ToBlobCustomerProvidedKey(),
                };
                clientConfiguration.TransferValidation.CopyTo(options.TransferValidation);
                return BlockBlobClient.CreateClient(
                    uri,
                    options,
                    clientConfiguration.Pipeline);
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="customerProvidedKey"/>.
        ///
        /// </summary>
        /// <param name="customerProvidedKey">The customer provided key.</param>
        /// <returns>A new <see cref="DataLakePathClient"/> instance.</returns>
        /// <remarks>
        /// Pass null to remove the customer provide key in the returned <see cref="DataLakePathClient"/>.
        /// </remarks>
        public DataLakePathClient WithCustomerProvidedKey(Models.DataLakeCustomerProvidedKey? customerProvidedKey)
        {
            DataLakeClientConfiguration newClientConfiguration = DataLakeClientConfiguration.DeepCopy(ClientConfiguration);
            newClientConfiguration.CustomerProvidedKey = customerProvidedKey;
            return new DataLakePathClient(
                pathUri: Uri,
                clientConfiguration: newClientConfiguration);
        }

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
                _fileSystemName ??= builder.FileSystemName;
                _accountName ??= builder.AccountName;
                _path ??= builder.DirectoryOrFilePath;
                _name ??= builder.LastDirectoryOrFileName;
            }
        }

        #region Create

        /// <summary>
        /// The <see cref="Create(PathResourceType, DataLakePathCreateOptions, CancellationToken)"/> operation creates a file or directory.
        /// If the path already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing path, consider using the <see cref="CreateIfNotExists(PathResourceType, DataLakePathCreateOptions, CancellationToken)"/> API.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="resourceType">
        /// Resource type of this path - file or directory.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<PathInfo> Create(
            PathResourceType resourceType,
            DataLakePathCreateOptions options = default,
            CancellationToken cancellationToken = default)
        {
            return CreateInternal(
                resourceType: resourceType,
                httpHeaders: options?.HttpHeaders,
                metadata: options?.Metadata,
                permissions: options?.AccessOptions?.Permissions,
                umask: options?.AccessOptions?.Umask,
                owner: options?.AccessOptions?.Owner,
                group: options?.AccessOptions?.Group,
                accessControlList: options?.AccessOptions?.AccessControlList,
                leaseId: options?.LeaseId,
                leaseDuration: options?.LeaseDuration,
                timeToExpire: options?.ScheduleDeletionOptions?.TimeToExpire,
                expiresOn: options?.ScheduleDeletionOptions?.ExpiresOn,
                encryptionContext: options?.EncryptionContext,
                conditions: options?.Conditions,
                async: false,
                cancellationToken)
                .EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="CreateAsync(PathResourceType, DataLakePathCreateOptions, CancellationToken)"/> operation creates a file or directory.
        /// If the path already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing path, consider using the <see cref="CreateIfNotExistsAsync(PathResourceType, DataLakePathCreateOptions, CancellationToken)"/> API.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="resourceType">
        /// Resource type of this path - file or directory.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<PathInfo>> CreateAsync(
            PathResourceType resourceType,
            DataLakePathCreateOptions options = default,
            CancellationToken cancellationToken = default)
        {
            return await CreateInternal(
                resourceType: resourceType,
                httpHeaders: options?.HttpHeaders,
                metadata: options?.Metadata,
                permissions: options?.AccessOptions?.Permissions,
                umask: options?.AccessOptions?.Umask,
                owner: options?.AccessOptions?.Owner,
                group: options?.AccessOptions?.Group,
                accessControlList: options?.AccessOptions?.AccessControlList,
                leaseId: options?.LeaseId,
                leaseDuration: options?.LeaseDuration,
                timeToExpire: options?.ScheduleDeletionOptions?.TimeToExpire,
                expiresOn: options?.ScheduleDeletionOptions?.ExpiresOn,
                encryptionContext: options?.EncryptionContext,
                conditions: options?.Conditions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// The <see cref="Create(PathResourceType, PathHttpHeaders, Metadata, string, string, DataLakeRequestConditions, CancellationToken)"/>
        /// operation creates a file or directory.
        /// If the path already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing path, consider using the <see cref="CreateIfNotExists(PathResourceType, DataLakePathCreateOptions, CancellationToken)"/> API.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<PathInfo> Create(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            PathResourceType resourceType,
            PathHttpHeaders httpHeaders,
            Metadata metadata,
            string permissions,
            string umask,
            DataLakeRequestConditions conditions,
            CancellationToken cancellationToken)
        {
            return CreateInternal(
                resourceType: resourceType,
                httpHeaders: httpHeaders,
                metadata: metadata,
                permissions: permissions,
                umask: umask,
                owner: null,
                group: null,
                accessControlList: null,
                leaseId: null,
                leaseDuration: null,
                timeToExpire: null,
                expiresOn: null,
                encryptionContext: null,
                conditions: conditions,
                async: false,
                cancellationToken)
                .EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="CreateAsync(PathResourceType, PathHttpHeaders, Metadata, string, string, DataLakeRequestConditions, CancellationToken)"/>
        /// operation creates a file or directory.
        /// If the path already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing path, consider using the <see cref="CreateIfNotExistsAsync(PathResourceType, DataLakePathCreateOptions, CancellationToken)"/> API.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<PathInfo>> CreateAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            PathResourceType resourceType,
            PathHttpHeaders httpHeaders,
            Metadata metadata,
            string permissions,
            string umask,
            DataLakeRequestConditions conditions,
            CancellationToken cancellationToken)
        {
            return await CreateInternal(
                resourceType: resourceType,
                httpHeaders: httpHeaders,
                metadata: metadata,
                permissions: permissions,
                umask: umask,
                owner: null,
                group: null,
                accessControlList: null,
                leaseId: null,
                leaseDuration: null,
                timeToExpire: null,
                expiresOn: null,
                encryptionContext: null,
                conditions: conditions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// The <see cref="CreateInternal(PathResourceType, PathHttpHeaders, Metadata, string, string, string, string, IList{PathAccessControlItem}, string, TimeSpan?, TimeSpan?, DateTimeOffset?, string, DataLakeRequestConditions, bool, CancellationToken)"/>
        /// operation creates a file or directory.
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
        /// <param name="owner">
        /// The owner of the file or directory.
        /// </param>
        /// <param name="group">
        /// Optional.  The owning group of the file or directory.
        /// </param>
        /// <param name="accessControlList">
        /// The POSIX access control list for the file or directory.
        /// </param>
        /// <param name="leaseId">
        /// Proposed LeaseId.
        /// </param>
        /// <param name="leaseDuration">
        ///  Specifies the duration of the lease.
        /// </param>
        /// <param name="timeToExpire">
        /// Duration before file should be deleted.
        /// </param>
        /// <param name="expiresOn">
        /// The <see cref="DateTimeOffset"/> to set for when
        /// the file will be deleted.  If null, the existing
        /// ExpiresOn time on the file will be removed, if it exists.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the creation of this file or directory..
        /// </param>
        /// <param name="encryptionContext">
        /// Encryption context.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        internal virtual async Task<Response<PathInfo>> CreateInternal(
            PathResourceType resourceType,
            PathHttpHeaders httpHeaders,
            Metadata metadata,
            string permissions,
            string umask,
            string owner,
            string group,
            IList<PathAccessControlItem> accessControlList,
            string leaseId,
            TimeSpan? leaseDuration,
            TimeSpan? timeToExpire,
            DateTimeOffset? expiresOn,
            string encryptionContext,
            DataLakeRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(DataLakePathClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(DataLakePathClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(httpHeaders)}: {httpHeaders}\n" +
                    $"{nameof(metadata)}: {metadata}\n" +
                    $"{nameof(permissions)}: {permissions}\n" +
                    $"{nameof(umask)}: {umask}\n");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(Create)}");

                if (resourceType == PathResourceType.Directory)
                {
                    if (leaseId != null)
                    {
                        throw new ArgumentException($"{nameof(DataLakePathCreateOptions)}.{nameof(DataLakePathCreateOptions.LeaseId)} does not apply to directories.");
                    }

                    if (leaseDuration.HasValue)
                    {
                        throw new ArgumentException($"{nameof(DataLakePathCreateOptions)}.{nameof(DataLakePathCreateOptions.LeaseDuration)} does not apply to directories.");
                    }

                    if (timeToExpire.HasValue)
                    {
                        throw new ArgumentException($"{nameof(DataLakePathCreateOptions)}.{nameof(DataLakePathCreateOptions.ScheduleDeletionOptions.TimeToExpire)} does not apply to directories.");
                    }

                    if (expiresOn.HasValue)
                    {
                        throw new ArgumentException($"{nameof(DataLakePathCreateOptions)}.{nameof(DataLakePathCreateOptions.ScheduleDeletionOptions.ExpiresOn)} does not apply to directories.");
                    }
                }

                if (expiresOn.HasValue && timeToExpire.HasValue)
                {
                    throw new ArgumentException($"{nameof(DataLakePathCreateOptions)}.{nameof(DataLakePathCreateOptions.ScheduleDeletionOptions.ExpiresOn)} and {nameof(DataLakePathCreateOptions)}.{nameof(DataLakePathCreateOptions.ScheduleDeletionOptions.TimeToExpire)} cannot both be set.");
                }

                try
                {
                    scope.Start();
                    ResponseWithHeaders<PathCreateHeaders> response;

                    long? serviceLeaseDuration = null;
                    if (leaseDuration.HasValue)
                    {
                        serviceLeaseDuration = leaseDuration < TimeSpan.Zero ? Constants.Blob.Lease.InfiniteLeaseDuration : Convert.ToInt64(leaseDuration.Value.TotalSeconds);
                    }

                    PathExpiryOptions? pathExpiryOptions = null;
                    string expiresOnString = null;

                    // Relative
                    if (timeToExpire.HasValue)
                    {
                        pathExpiryOptions = PathExpiryOptions.RelativeToNow;
                        expiresOnString = timeToExpire.Value.TotalMilliseconds.ToString(CultureInfo.InvariantCulture);
                    }
                    // Absolute
                    else if (expiresOn.HasValue)
                    {
                        pathExpiryOptions = PathExpiryOptions.Absolute;
                        expiresOnString = expiresOn?.ToString("R", CultureInfo.InvariantCulture);
                    }

                    if (async)
                    {
                        response = await PathRestClient.CreateAsync(
                            resource: resourceType,
                            cacheControl: httpHeaders?.CacheControl,
                            contentEncoding: httpHeaders?.ContentEncoding,
                            contentLanguage: httpHeaders?.ContentLanguage,
                            contentDisposition: httpHeaders?.ContentDisposition,
                            contentType: httpHeaders?.ContentType,
                            leaseId: conditions?.LeaseId,
                            properties: BuildMetadataString(metadata),
                            permissions: permissions,
                            umask: umask,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                            owner: owner,
                            group: group,
                            acl: PathAccessControlExtensions.ToAccessControlListString(accessControlList),
                            proposedLeaseId: leaseId,
                            leaseDuration: serviceLeaseDuration,
                            expiryOptions: pathExpiryOptions,
                            expiresOn: expiresOnString,
                            encryptionContext: encryptionContext,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = PathRestClient.Create(
                            resource: resourceType,
                            cacheControl: httpHeaders?.CacheControl,
                            contentEncoding: httpHeaders?.ContentEncoding,
                            contentLanguage: httpHeaders?.ContentLanguage,
                            contentDisposition: httpHeaders?.ContentDisposition,
                            contentType: httpHeaders?.ContentType,
                            leaseId: conditions?.LeaseId,
                            properties: BuildMetadataString(metadata),
                            permissions: permissions,
                            umask: umask,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                            owner: owner,
                            group: group,
                            acl: PathAccessControlExtensions.ToAccessControlListString(accessControlList),
                            proposedLeaseId: leaseId,
                            leaseDuration: serviceLeaseDuration,
                            expiryOptions: pathExpiryOptions,
                            expiresOn: expiresOnString,
                            encryptionContext: encryptionContext,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToPathInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(DataLakePathClient));
                    scope.Dispose();
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
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<PathInfo> CreateIfNotExists(
            PathResourceType resourceType,
            DataLakePathCreateOptions options = default,
            CancellationToken cancellationToken = default)
            => CreateIfNotExistsInternal(
                    resourceType: resourceType,
                    httpHeaders: options?.HttpHeaders,
                    metadata: options?.Metadata,
                    permissions: options?.AccessOptions?.Permissions,
                    umask: options?.AccessOptions?.Umask,
                    owner: options?.AccessOptions?.Owner,
                    group: options?.AccessOptions?.Group,
                    accessControlList: options?.AccessOptions?.AccessControlList,
                    leaseId: options?.LeaseId,
                    leaseDuration: options?.LeaseDuration,
                    timeToExpire: options?.ScheduleDeletionOptions?.TimeToExpire,
                    expiresOn: options?.ScheduleDeletionOptions?.ExpiresOn,
                    encryptionContext: options?.EncryptionContext,
                    async: false,
                    cancellationToken: cancellationToken)
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
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<PathInfo>> CreateIfNotExistsAsync(
            PathResourceType resourceType,
            DataLakePathCreateOptions options = default,
            CancellationToken cancellationToken = default)
            => await CreateIfNotExistsInternal(
                resourceType: resourceType,
                httpHeaders: options?.HttpHeaders,
                metadata: options?.Metadata,
                permissions: options?.AccessOptions?.Permissions,
                umask: options?.AccessOptions?.Umask,
                owner: options?.AccessOptions?.Owner,
                group: options?.AccessOptions?.Group,
                accessControlList: options?.AccessOptions?.AccessControlList,
                leaseId: options?.LeaseId,
                leaseDuration: options?.LeaseDuration,
                timeToExpire: options?.ScheduleDeletionOptions?.TimeToExpire,
                expiresOn: options?.ScheduleDeletionOptions?.ExpiresOn,
                encryptionContext: options?.EncryptionContext,
                async: true,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<PathInfo> CreateIfNotExists(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            PathResourceType resourceType,
            PathHttpHeaders httpHeaders,
            Metadata metadata,
            string permissions,
            string umask,
            CancellationToken cancellationToken)
            => CreateIfNotExistsInternal(
                    resourceType: resourceType,
                    httpHeaders: httpHeaders,
                    metadata: metadata,
                    permissions: permissions,
                    umask: umask,
                    owner: null,
                    group: null,
                    accessControlList: null,
                    leaseId: null,
                    leaseDuration: null,
                    timeToExpire: null,
                    expiresOn: null,
                    encryptionContext: null,
                    async: false,
                    cancellationToken: cancellationToken)
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<PathInfo>> CreateIfNotExistsAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            PathResourceType resourceType,
            PathHttpHeaders httpHeaders,
            Metadata metadata,
            string permissions,
            string umask,
            CancellationToken cancellationToken)
            => await CreateIfNotExistsInternal(
                resourceType: resourceType,
                httpHeaders: httpHeaders,
                metadata: metadata,
                permissions: permissions,
                umask: umask,
                owner: null,
                group: null,
                accessControlList: null,
                leaseId: null,
                leaseDuration: null,
                timeToExpire: null,
                expiresOn: null,
                encryptionContext: null,
                async: true,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CreateIfNotExistsInternal(PathResourceType, PathHttpHeaders, Metadata, string, string, string, string, IList{PathAccessControlItem}, string, TimeSpan?, TimeSpan?, DateTimeOffset?, string, bool, CancellationToken)"/>
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
        /// <param name="owner">
        /// The owner of the file or directory.
        /// </param>
        /// <param name="group">
        /// Optional.  The owning group of the file or directory.
        /// </param>
        /// <param name="accessControlList">
        /// The POSIX access control list for the file or directory.
        /// </param>
        /// <param name="leaseId">
        /// Proposed LeaseId.
        /// </param>
        /// <param name="leaseDuration">
        ///  Specifies the duration of the lease.
        /// </param>
        /// <param name="timeToExpire">
        /// Duration before file should be deleted.
        /// </param>
        /// <param name="expiresOn">
        /// The <see cref="DateTimeOffset"/> to set for when
        /// the file will be deleted.  If null, the existing
        /// ExpiresOn time on the file will be removed, if it exists.
        /// </param>
        /// <param name="encryptionContext">
        /// Encryption context.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<PathInfo>> CreateIfNotExistsInternal(
            PathResourceType resourceType,
            PathHttpHeaders httpHeaders,
            Metadata metadata,
            string permissions,
            string umask,
            string owner,
            string group,
            IList<PathAccessControlItem> accessControlList,
            string leaseId,
            TimeSpan? leaseDuration,
            TimeSpan? timeToExpire,
            DateTimeOffset? expiresOn,
            string encryptionContext,
            bool async,
            CancellationToken cancellationToken)
        {
            Response<PathInfo> response;
            try
            {
                DataLakeRequestConditions conditions = new DataLakeRequestConditions { IfNoneMatch = new ETag(Constants.Wildcard) };
                response = await CreateInternal(
                    resourceType: resourceType,
                    httpHeaders: httpHeaders,
                    metadata: metadata,
                    permissions: permissions,
                    umask: umask,
                    owner: owner,
                    group: group,
                    accessControlList: accessControlList,
                    leaseId: leaseId,
                    leaseDuration: leaseDuration,
                    timeToExpire: timeToExpire,
                    expiresOn: expiresOn,
                    encryptionContext: encryptionContext,
                    conditions: conditions,
                    async: async,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (RequestFailedException storageRequestFailedException)
            when (storageRequestFailedException.ErrorCode == Constants.DataLake.PathAlreadyExists)
            {
                response = default;
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
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance. If you want to create the file system if
        /// it doesn't exist, use
        /// <see cref="CreateIfNotExists(PathResourceType, DataLakePathCreateOptions, CancellationToken)"/>
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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(Exists)}");

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
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance. If you want to create the file system if
        /// it doesn't exist, use
        /// <see cref="CreateIfNotExistsAsync(PathResourceType, DataLakePathCreateOptions, CancellationToken)"/>
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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(Exists)}");

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
        /// deletion.
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
        /// A <see cref="Response"/> on successfully marking for deletion.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response Delete(
            bool? recursive = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            return DeleteInternal(
                recursive,
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="DeleteAsync"/> operation marks the specified path
        /// deletion.
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
        /// A <see cref="Response"/> on successfully marking for deletion.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response> DeleteAsync(
            bool? recursive = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            return await DeleteInternal(
                recursive,
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// The <see cref="DeleteInternal"/> operation marks the specified path
        /// deletion.
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
        /// A <see cref="Response"/> on successfully marking for deletion.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response> DeleteInternal(
            bool? recursive,
            DataLakeRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(DataLakePathClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(DataLakePathClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(recursive)}: {recursive}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(Delete)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<PathDeleteHeaders> response = null;

                    // Pagination only applies to service version 2023-08-03 and later, when using OAuth.
                    bool? paginated = null;
                    if (_clientConfiguration.ClientOptions.Version >= DataLakeClientOptions.ServiceVersion.V2023_08_03
                        && recursive.GetValueOrDefault()
                        && _clientConfiguration.TokenCredential != null)
                    {
                        paginated = true;
                    }

                    do
                    {
                        if (async)
                        {
                            response = await PathRestClient.DeleteAsync(
                                recursive: recursive,
                                continuation: response?.Headers?.Continuation,
                                leaseId: conditions?.LeaseId,
                                ifMatch: conditions?.IfMatch?.ToString(),
                                ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                                ifModifiedSince: conditions?.IfModifiedSince,
                                ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                                paginated: paginated,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            response = PathRestClient.Delete(
                                recursive: recursive,
                                continuation: response?.Headers?.Continuation,
                                leaseId: conditions?.LeaseId,
                                ifMatch: conditions?.IfMatch?.ToString(),
                                ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                                ifModifiedSince: conditions?.IfModifiedSince,
                                ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                                paginated: paginated,
                                cancellationToken: cancellationToken);
                        }
                    }
                    while (!string.IsNullOrEmpty(response?.Headers?.Continuation));

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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(DataLakePathClient));
                    scope.Dispose();
                }
            }
        }
        #endregion Delete

        #region Delete If Exists
        /// <summary>
        /// The <see cref="DeleteIfExists"/> operation marks the specified path
        /// for deletion, if the path exists.
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
        /// A <see cref="Response"/> on successfully marking for deletion.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// deletion, if the path exists.
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
        /// A <see cref="Response"/> on successfully marking for deletion.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// deletion, if the path exists.
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
        /// A <see cref="Response"/> on successfully marking for deletion.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<bool>> DeleteIfExistsInternal(
            bool? recursive,
            DataLakeRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(DeleteIfExists)}");
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<DataLakePathClient> Rename(
            string destinationPath,
            string destinationFileSystem = default,
            DataLakeRequestConditions sourceConditions = default,
            DataLakeRequestConditions destinationConditions = default,
            CancellationToken cancellationToken = default)
        {
            return RenameInternal(
                destinationPath: destinationPath,
                destinationFileSystem: destinationFileSystem,
                sourceConditions: sourceConditions,
                destinationConditions: destinationConditions,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<DataLakePathClient>> RenameAsync(
            string destinationPath,
            string destinationFileSystem = default,
            DataLakeRequestConditions sourceConditions = default,
            DataLakeRequestConditions destinationConditions = default,
            CancellationToken cancellationToken = default)
        {
            return await RenameInternal(
                destinationPath: destinationPath,
                destinationFileSystem: destinationFileSystem,
                sourceConditions: sourceConditions,
                destinationConditions: destinationConditions,
                async: true,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<DataLakePathClient>> RenameInternal(
            string destinationPath,
            string destinationFileSystem,
            DataLakeRequestConditions sourceConditions,
            DataLakeRequestConditions destinationConditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(DataLakePathClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(DataLakePathClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(destinationFileSystem)}: {destinationFileSystem}\n" +
                    $"{nameof(destinationPath)}: {destinationPath}\n" +
                    $"{nameof(destinationConditions)}: {destinationConditions}\n" +
                    $"{nameof(sourceConditions)}: {sourceConditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(Rename)}");

                try
                {
                    scope.Start();

                    // Build renameSource
                    DataLakeUriBuilder sourceUriBuilder = new DataLakeUriBuilder(_dfsUri);
                    string renameSource = Constants.PathBackSlashDelimiter + sourceUriBuilder.FileSystemName +
                        Constants.PathBackSlashDelimiter + sourceUriBuilder.DirectoryOrFilePath.EscapePath();

                    // There's already a check in at the client constructor to prevent both SAS in Uri and AzureSasCredential
                    if (sourceUriBuilder.Sas != null)
                    {
                        renameSource += Constants.QueryDelimiter + sourceUriBuilder.Sas;
                    }
                    if (_clientConfiguration.SasCredential != null)
                    {
                        renameSource += Constants.QueryDelimiter + ClientConfiguration.SasCredential.Signature;
                    }

                    // Build destination URI
                    DataLakeUriBuilder destUriBuilder = new DataLakeUriBuilder(_dfsUri)
                    {
                        Sas = null,
                        Query = null
                    };
                    destUriBuilder.FileSystemName = destinationFileSystem ?? destUriBuilder.FileSystemName;

                    // DataLakeUriBuilder will encode the DirectoryOrFilePath.
                    // We don't want the query parameters, especially SAS, to be encoded.
                    // We also have to build the destination client depending on if a SAS was passed with the destination.
                    DataLakePathClient destPathClient;
                    string[] split = destinationPath.Split('?');
                    if (split.Length == 2)
                    {
                        destUriBuilder.DirectoryOrFilePath = split[0];
                        destUriBuilder.Query = split[1];
                        // If the destination already has a SAS, then let's not further add to the Uri if it contains
                        // AzureSasCredential on the source.
                        var paramsMap = new UriQueryParamsCollection(split[1]);
                        if (!paramsMap.ContainsKey(Constants.Sas.Parameters.Version))
                        {
                            // No SAS in the destination, use the source credentials to build the destination path
                            destPathClient = new DataLakePathClient(destUriBuilder.ToUri(), ClientConfiguration);
                        }
                        else
                        {
                            // There's a SAS in the destination path
                            // Create the destination path with the destination SAS
                            destPathClient = new DataLakePathClient(
                                destUriBuilder.ToUri(),
                                ClientConfiguration.ClientDiagnostics,
                                ClientConfiguration.ClientOptions);
                        }
                    }
                    else
                    {
                        // No SAS in the destination, use the source credentials as a default
                        destUriBuilder.DirectoryOrFilePath = destinationPath;
                        destUriBuilder.Sas = sourceUriBuilder.Sas;
                        destPathClient = new DataLakePathClient(
                            destUriBuilder.ToUri(),
                            ClientConfiguration);
                    }

                    ResponseWithHeaders<PathCreateHeaders> response;

                    if (async)
                    {
                        response = await destPathClient.PathRestClient.CreateAsync(
                            mode: PathRenameMode.Legacy,
                            renameSource: renameSource,
                            leaseId: destinationConditions?.LeaseId,
                            sourceLeaseId: sourceConditions?.LeaseId,
                            ifMatch: destinationConditions?.IfMatch?.ToString(),
                            ifNoneMatch: destinationConditions?.IfNoneMatch?.ToString(),
                            ifModifiedSince: destinationConditions?.IfModifiedSince,
                            ifUnmodifiedSince: destinationConditions?.IfUnmodifiedSince,
                            sourceIfMatch: sourceConditions?.IfMatch?.ToString(),
                            sourceIfNoneMatch: sourceConditions?.IfNoneMatch?.ToString(),
                            sourceIfModifiedSince: sourceConditions?.IfModifiedSince,
                            sourceIfUnmodifiedSince: sourceConditions?.IfUnmodifiedSince,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = destPathClient.PathRestClient.Create(
                            mode: PathRenameMode.Legacy,
                            renameSource: renameSource,
                            leaseId: destinationConditions?.LeaseId,
                            sourceLeaseId: sourceConditions?.LeaseId,
                            ifMatch: destinationConditions?.IfMatch?.ToString(),
                            ifNoneMatch: destinationConditions?.IfNoneMatch?.ToString(),
                            ifModifiedSince: destinationConditions?.IfModifiedSince,
                            ifUnmodifiedSince: destinationConditions?.IfUnmodifiedSince,
                            sourceIfMatch: sourceConditions?.IfMatch?.ToString(),
                            sourceIfNoneMatch: sourceConditions?.IfNoneMatch?.ToString(),
                            sourceIfModifiedSince: sourceConditions?.IfModifiedSince,
                            sourceIfUnmodifiedSince: sourceConditions?.IfUnmodifiedSince,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        destPathClient,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(DataLakePathClient));
                    scope.Dispose();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<PathAccessControl> GetAccessControl(
            bool? userPrincipalName = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            return GetAccessControlInternal(
                userPrincipalName,
                conditions,
                async: false,
                cancellationToken)
                .EnsureCompleted();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<PathAccessControl>> GetAccessControlAsync(
            bool? userPrincipalName = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            return await GetAccessControlInternal(
                userPrincipalName,
                conditions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<PathAccessControl>> GetAccessControlInternal(
            bool? userPrincipalName,
            DataLakeRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(DataLakePathClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(DataLakePathClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(GetAccessControl)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<PathGetPropertiesHeaders> response;

                    if (async)
                    {
                        response = await PathRestClient.GetPropertiesAsync(
                            action: PathGetPropertiesAction.GetAccessControl,
                             upn: userPrincipalName,
                             leaseId: conditions?.LeaseId,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = PathRestClient.GetProperties(
                            action: PathGetPropertiesAction.GetAccessControl,
                             upn: userPrincipalName,
                             leaseId: conditions?.LeaseId,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToPathAccessControl(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(DataLakePathClient));
                    scope.Dispose();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public virtual Response<PathInfo> SetAccessControlList(
            IList<PathAccessControlItem> accessControlList,
            string owner = default,
            string group = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            return SetAccessControlListInternal(
                    accessControlList,
                    owner,
                    group,
                    conditions,
                    async: false,
                    cancellationToken)
                    .EnsureCompleted();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public virtual async Task<Response<PathInfo>> SetAccessControlListAsync(
            IList<PathAccessControlItem> accessControlList,
            string owner = default,
            string group = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            return await SetAccessControlListInternal(
                accessControlList,
                owner,
                group,
                conditions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<PathInfo>> SetAccessControlListInternal(
            IList<PathAccessControlItem> accessControlList,
            string owner,
            string group,
            DataLakeRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(DataLakePathClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(DataLakePathClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(accessControlList)}: {accessControlList}\n" +
                    $"{nameof(owner)}: {owner}\n" +
                    $"{nameof(group)}: {group}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(SetAccessControlList)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<PathSetAccessControlHeaders> response;

                    if (async)
                    {
                        response = await PathRestClient.SetAccessControlAsync(
                            leaseId: conditions?.LeaseId,
                            owner: owner,
                            group: group,
                            acl: PathAccessControlExtensions.ToAccessControlListString(accessControlList),
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = PathRestClient.SetAccessControl(
                            leaseId: conditions?.LeaseId,
                            owner: owner,
                            group: group,
                            acl: PathAccessControlExtensions.ToAccessControlListString(accessControlList),
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToPathInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(DataLakePathClient));
                    scope.Dispose();
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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);

            try
            {
                scope.Start();
                using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(DataLakePathClient)))
                {
                    ClientConfiguration.Pipeline.LogMethodEnter(
                        nameof(DataLakePathClient),
                        message:
                        $"{nameof(Uri)}: {Uri}\n" +
                        $"{nameof(accessControlList)}: {accessControlList}\n" +
                        $"{nameof(mode)}: {mode}\n" +
                        $"batchSize: {options.BatchSize}");
                    try
                    {
                        ResponseWithHeaders<SetAccessControlRecursiveResponse, PathSetAccessControlRecursiveHeaders> response;
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
                                if (async)
                                {
                                    response = await PathRestClient.SetAccessControlRecursiveAsync(
                                        mode: mode,
                                        continuation: continuationToken,
                                        forceFlag: options?.ContinueOnFailure,
                                        maxRecords: options?.BatchSize,
                                        acl: accessControlList,
                                        cancellationToken: cancellationToken)
                                        .ConfigureAwait(false);
                                }
                                else
                                {
                                    response = PathRestClient.SetAccessControlRecursive(
                                        mode: mode,
                                        continuation: continuationToken,
                                        forceFlag: options?.ContinueOnFailure,
                                        maxRecords: options?.BatchSize,
                                        acl: accessControlList,
                                        cancellationToken: cancellationToken);
                                }
                            }
                            catch (RequestFailedException exception)
                            {
                                throw DataLakeErrors.ChangeAclRequestFailed(exception, continuationToken);
                            }
                            catch (Exception exception)
                            {
                                throw DataLakeErrors.ChangeAclFailed(exception, continuationToken);
                            }
                            continuationToken = response.Headers.Continuation;

                            if (!string.IsNullOrEmpty(continuationToken))
                            {
                                lastContinuationToken = continuationToken;
                            }

                            int currentDirectoriesSuccessfulCount = response.Value.DirectoriesSuccessful ?? 0;
                            int currentFilesSuccessfulCount = response.Value.FilesSuccessful ?? 0;
                            int currentFailureCount = response.Value.FailureCount ?? 0;

                            directoriesSuccessfulCount += currentDirectoriesSuccessfulCount;
                            filesSuccessfulCount += currentFilesSuccessfulCount;
                            failureCount += currentFailureCount;

                            if ((currentFailureCount > 0) && (batchFailures == default))
                            {
                                batchFailures = response.Value.FailedEntries
                                .Select(failedEntry => new AccessControlChangeFailure()
                                {
                                    Name = failedEntry.Name,
                                    IsDirectory = failedEntry.Type.Equals("DIRECTORY", StringComparison.InvariantCultureIgnoreCase),
                                    ErrorMessage = failedEntry.ErrorMessage,
                                }).ToArray();
                            }
                            if (options?.ProgressHandler != null)
                            {
                                var failedEntries = response.Value.FailedEntries
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
                                        response.GetRawResponse()));
                            }
                            batchesCount++;
                        } while (!string.IsNullOrEmpty(continuationToken)
                            && (options == null || !options.MaxBatches.HasValue || batchesCount < options.MaxBatches.Value));

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
                            response.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        ClientConfiguration.Pipeline.LogException(ex);
                        throw;
                    }
                    finally
                    {
                        ClientConfiguration.Pipeline.LogMethodExit(nameof(DataLakePathClient));
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public virtual Response<PathInfo> SetPermissions(
            PathPermissions permissions,
            string owner = default,
            string group = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            return SetPermissionsInternal(
                permissions,
                owner,
                group,
                conditions,
                async: false,
                cancellationToken)
                .EnsureCompleted();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public virtual async Task<Response<PathInfo>> SetPermissionsAsync(
            PathPermissions permissions,
            string owner = default,
            string group = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            return await SetPermissionsInternal(
                permissions,
                owner,
                group,
                conditions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<PathInfo>> SetPermissionsInternal(
            PathPermissions permissions,
            string owner,
            string group,
            DataLakeRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(DataLakePathClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(DataLakePathClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(permissions)}: {permissions}\n" +
                    $"{nameof(owner)}: {owner}\n" +
                    $"{nameof(group)}: {group}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(SetPermissions)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<PathSetAccessControlHeaders> response;

                    if (async)
                    {
                        response = await PathRestClient.SetAccessControlAsync(
                            leaseId: conditions?.LeaseId,
                            owner: owner,
                            group: group,
                            permissions: permissions?.ToSymbolicPermissions(),
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = PathRestClient.SetAccessControl(
                            leaseId: conditions?.LeaseId,
                            owner: owner,
                            group: group,
                            permissions: permissions?.ToSymbolicPermissions(),
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToPathInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(DataLakePathClient));
                    scope.Dispose();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<PathProperties> GetProperties(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(GetProperties)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobProperties> response = _blockBlobClient.GetProperties(
                    conditions.ToBlobRequestConditions(),
                    cancellationToken);

                return Response.FromValue(
                    response.ToPathProperties(),
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<PathProperties>> GetPropertiesAsync(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(GetProperties)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobProperties> response = await _blockBlobClient.GetPropertiesAsync(
                    conditions.ToBlobRequestConditions(),
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    response.ToPathProperties(),
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<PathInfo> SetHttpHeaders(
            PathHttpHeaders httpHeaders = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(SetHttpHeaders)}");

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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<PathInfo>> SetHttpHeadersAsync(
            PathHttpHeaders httpHeaders = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(SetHttpHeaders)}");

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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<PathInfo> SetMetadata(
            Metadata metadata,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(SetMetadata)}");

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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<PathInfo>> SetMetadataAsync(
            Metadata metadata,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(SetMetadata)}");

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

        #region Get Tags
        /// <summary>
        /// Gets the tags associated with the underlying path.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-blob-tags">
        /// Get Blob Tags</see>
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// getting the path's tags.  Note that TagConditions is currently the
        /// only condition supported by GetTaggs.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        // https://github.com/Azure/azure-sdk-for-net/issues/52168
        internal virtual Response<GetPathTagResult> GetTags(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(GetTags)}");
            try
            {
                scope.Start();
                Response<Blobs.Models.GetBlobTagResult> response = _blockBlobClient.GetTags(
                    conditions.ToBlobRequestConditions(),
                    cancellationToken);
                return Response.FromValue(
                    response.Value.ToGetPathTagResult(),
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
        /// Gets the tags associated with the underlying path.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-blob-tags">
        /// Get Blob Tags</see>
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// getting the path's tags.  Note that TagConditions is currently the
        /// only condition supported by GetTaggs.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        // https://github.com/Azure/azure-sdk-for-net/issues/52168
        internal virtual async Task<Response<GetPathTagResult>> GetTagsAsync(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(GetTags)}");
            try
            {
                scope.Start();
                Response<Blobs.Models.GetBlobTagResult> response = await _blockBlobClient.GetTagsAsync(
                    conditions.ToBlobRequestConditions(),
                    cancellationToken)
                    .ConfigureAwait(false);
                return Response.FromValue(
                    response.Value.ToGetPathTagResult(),
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
        #endregion Get Tags

        #region Set Tags
        /// <summary>
        /// Sets tags on the underlying path.
        /// A path can have up to 10 tags.  Tag keys must be between 1 and 128 characters.  Tag values must be between 0 and 256 characters.
        /// Valid tag key and value characters include lower and upper case letters, digits (0-9),
        /// space (' '), plus ('+'), minus ('-'), period ('.'), forward slash ('/'), colon (':'), equals ('='), and underscore ('_').
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-blob-tags">
        /// Set Blob Tags</see>.
        /// </summary>
        /// <param name="tags">
        /// The tags to set on the path.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the path's tags.  Note that TagConditions is currently the
        /// only condition supported by SetTags.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully setting the path's tags..
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        // https://github.com/Azure/azure-sdk-for-net/issues/52168
        internal virtual Response SetTags(
            Tags tags,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(SetTags)}");
            try
            {
                scope.Start();
                Response response = _blockBlobClient.SetTags(
                    tags,
                    conditions.ToBlobRequestConditions(),
                    cancellationToken);
                return response;
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
        /// Sets tags on the underlying path.
        /// A path can have up to 10 tags.  Tag keys must be between 1 and 128 characters.  Tag values must be between 0 and 256 characters.
        /// Valid tag key and value characters include lower and upper case letters, digits (0-9),
        /// space (' '), plus ('+'), minus ('-'), period ('.'), forward slash ('/'), colon (':'), equals ('='), and underscore ('_').
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-blob-tags">
        /// Set Blob Tags</see>.
        /// </summary>
        /// <param name="tags">
        /// The tags to set on the path.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the path's tags.  Note that TagConditions is currently the
        /// only condition supported by SetTags.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully setting the path's tags..
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        // https://github.com/Azure/azure-sdk-for-net/issues/52168
        internal virtual async Task<Response> SetTagsAsync(
            Tags tags,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakePathClient)}.{nameof(SetTags)}");
            try
            {
                scope.Start();
                Response response = await _blockBlobClient.SetTagsAsync(
                    tags,
                    conditions.ToBlobRequestConditions(),
                    cancellationToken)
                    .ConfigureAwait(false);
                return response;
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
        #endregion Set Tags

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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public virtual Uri GenerateSasUri(DataLakeSasPermissions permissions, DateTimeOffset expiresOn)
            => GenerateSasUri(permissions, expiresOn, out _);

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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public virtual Uri GenerateSasUri(DataLakeSasPermissions permissions, DateTimeOffset expiresOn, out string stringToSign) =>
            GenerateSasUri(new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = FileSystemName,
                Path = Path
            }, out stringToSign);

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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public virtual Uri GenerateSasUri(DataLakeSasBuilder builder)
            => GenerateSasUri(builder, out _);

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
        /// <param name="stringToSign">
        /// For debugging purposes only.  This string will be overwritten with the string to sign that was used to generate the SAS Uri.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public virtual Uri GenerateSasUri(DataLakeSasBuilder builder, out string stringToSign)
        {
            builder = builder ?? throw Errors.ArgumentNull(nameof(builder));

            // Deep copy of builder so we don't modify the user's original DataLakeSasBuilder.
            builder = DataLakeSasBuilder.DeepCopy(builder);

            SetBuilderAndValidate(builder);
            DataLakeUriBuilder sasUri = new DataLakeUriBuilder(Uri)
            {
                Sas = builder.ToSasQueryParameters(ClientConfiguration.SharedKeyCredential, out stringToSign)
            };
            return sasUri.ToUri();
        }
        #endregion

        #region GenerateUserDelegationSas
        /// <summary>
        /// The <see cref="GenerateUserDelegationSasUri(DataLakeSasPermissions, DateTimeOffset, UserDelegationKey)"/>
        /// returns a <see cref="Uri"/> that generates a DataLake Path Service Shared Access Signature (SAS)
        /// Uri based on the Client properties and parameter passed. The SAS is signed by the user delegation key passed in.
        ///
        /// For more information, see
        /// <see href="https://learn.microsoft.com/en-us/rest/api/storageservices/create-user-delegation-sas">
        /// Creating an user delegation SAS</see>.
        /// </summary>
        /// <param name="permissions">
        /// Required. Specifies the list of permissions to be associated with the SAS.
        /// See <see cref="DataLakeSasPermissions"/>.
        /// </param>
        /// <param name="expiresOn">
        /// Required. Specifies the time at which the SAS becomes invalid. This field
        /// must be omitted if it has been specified in an associated stored access policy.
        /// </param>
        /// <param name="userDelegationKey">
        /// Required. A <see cref="UserDelegationKey"/> returned from
        /// <see cref="DataLakeServiceClient.GetUserDelegationKeyAsync(DataLakeGetUserDelegationKeyOptions, CancellationToken)"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if a failure occurs.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public virtual Uri GenerateUserDelegationSasUri(DataLakeSasPermissions permissions, DateTimeOffset expiresOn, UserDelegationKey userDelegationKey)
            => GenerateUserDelegationSasUri(permissions, expiresOn, userDelegationKey, out _);

        /// <summary>
        /// The <see cref="GenerateUserDelegationSasUri(DataLakeSasPermissions, DateTimeOffset, UserDelegationKey, out string)"/>
        /// returns a <see cref="Uri"/> that generates a DataLake Path Service Shared Access Signature (SAS)
        /// Uri based on the Client properties and parameter passed. The SAS is signed by the user delegation key passed in.
        ///
        /// For more information, see
        /// <see href="https://learn.microsoft.com/en-us/rest/api/storageservices/create-user-delegation-sas">
        /// Creating an user delegation SAS</see>.
        /// </summary>
        /// <param name="permissions">
        /// Required. Specifies the list of permissions to be associated with the SAS.
        /// See <see cref="DataLakeSasPermissions"/>.
        /// </param>
        /// <param name="expiresOn">
        /// Required. Specifies the time at which the SAS becomes invalid. This field
        /// must be omitted if it has been specified in an associated stored access policy.
        /// </param>
        /// <param name="userDelegationKey">
        /// Required. A <see cref="UserDelegationKey"/> returned from
        /// <see cref="DataLakeServiceClient.GetUserDelegationKeyAsync(DataLakeGetUserDelegationKeyOptions, CancellationToken)"/>.
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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public virtual Uri GenerateUserDelegationSasUri(DataLakeSasPermissions permissions, DateTimeOffset expiresOn, UserDelegationKey userDelegationKey, out string stringToSign) =>
            GenerateUserDelegationSasUri(new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = FileSystemName,
                Path = Path
            }, userDelegationKey, out stringToSign);

        /// <summary>
        /// The <see cref="GenerateUserDelegationSasUri(DataLakeSasBuilder, UserDelegationKey)"/>
        /// returns a <see cref="Uri"/> that generates a DataLake Path Service Shared Access Signature (SAS)
        /// Uri based on the Client properties and builder passed. The SAS is signed by the user delegation key passed in.
        ///
        /// For more information, see
        /// <see href="https://learn.microsoft.com/en-us/rest/api/storageservices/create-user-delegation-sas">
        /// Creating an user delegation SAS</see>.
        /// </summary>
        /// <param name="builder">
        /// Required. Used to generate a Shared Access Signature (SAS).
        /// </param>
        /// <param name="userDelegationKey">
        /// Required. A <see cref="UserDelegationKey"/> returned from
        /// <see cref="DataLakeServiceClient.GetUserDelegationKeyAsync(DataLakeGetUserDelegationKeyOptions, CancellationToken)"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public virtual Uri GenerateUserDelegationSasUri(DataLakeSasBuilder builder, UserDelegationKey userDelegationKey)
            => GenerateUserDelegationSasUri(builder, userDelegationKey, out _);

        /// <summary>
        /// The <see cref="GenerateUserDelegationSasUri(DataLakeSasBuilder, UserDelegationKey, out string)"/>
        /// returns a <see cref="Uri"/> that generates a DataLake Path Service Shared Access Signature (SAS)
        /// Uri based on the Client properties and builder passed. The SAS is signed by the user delegation key passed in.
        ///
        /// For more information, see
        /// <see href="https://learn.microsoft.com/en-us/rest/api/storageservices/create-user-delegation-sas">
        /// Creating an user delegation SAS</see>.
        /// </summary>
        /// <param name="builder">
        /// Required. Used to generate a Shared Access Signature (SAS).
        /// </param>
        /// <param name="userDelegationKey">
        /// Required. A <see cref="UserDelegationKey"/> returned from
        /// <see cref="DataLakeServiceClient.GetUserDelegationKeyAsync(DataLakeGetUserDelegationKeyOptions, CancellationToken)"/>.
        /// </param>
        /// <param name="stringToSign">
        /// For debugging purposes only.  This string will be overwritten with the string to sign that was used to generate the SAS Uri.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public virtual Uri GenerateUserDelegationSasUri(DataLakeSasBuilder builder, UserDelegationKey userDelegationKey, out string stringToSign)
        {
            builder = builder ?? throw Errors.ArgumentNull(nameof(builder));
            userDelegationKey = userDelegationKey ?? throw Errors.ArgumentNull(nameof(userDelegationKey));

            // Deep copy of builder so we don't modify the user's original DataLakeSasBuilder.
            builder = DataLakeSasBuilder.DeepCopy(builder);

            SetBuilderAndValidate(builder);
            if (string.IsNullOrEmpty(AccountName))
            {
                throw Errors.SasClientMissingData(nameof(AccountName));
            }

            DataLakeUriBuilder sasUri = new DataLakeUriBuilder(Uri)
            {
                Sas = builder.ToSasQueryParameters(userDelegationKey, AccountName, out stringToSign)
            };
            return sasUri.ToUri();
        }
        #endregion

        #region GetParentDataLakeFileSystemClientCore

        private DataLakeFileSystemClient _parentFileSystemClient;
        private DataLakeDirectoryClient _parentDirectoryClient;

        /// <summary>
        /// Create a new <see cref="DataLakeFileSystemClient"/> that pointing to this <see cref="DataLakePathClient"/>'s parent container.
        /// The new <see cref="DataLakeFileSystemClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="DataLakePathClient"/>.
        /// </summary>
        /// <returns>A new <see cref="BlobContainerClient"/> instance.</returns>
        protected internal virtual DataLakeFileSystemClient GetParentFileSystemClientCore()
        {
            if (_parentFileSystemClient == null)
            {
                DataLakeUriBuilder datalakeUriBuilder = new DataLakeUriBuilder(Uri)
                {
                    // erase parameters unrelated to container
                    DirectoryOrFilePath = null,
                    Snapshot = null,
                };

                _parentFileSystemClient = new DataLakeFileSystemClient(
                    datalakeUriBuilder.ToUri(),
                    ClientConfiguration);
            }

            return _parentFileSystemClient;
        }

        /// <summary>
        /// Create a new <see cref="DataLakeDirectoryClient"/> that pointing to this <see cref="DataLakePathClient"/>'s parent container.
        /// The new <see cref="DataLakeDirectoryClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="DataLakePathClient"/>.
        /// </summary>
        /// <returns>A new <see cref="DataLakeDirectoryClient"/> instance.</returns>
        protected internal virtual DataLakeDirectoryClient GetParentDirectoryClientCore()
        {
            if (_parentDirectoryClient == null)
            {
                DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(Uri)
                {
                    Snapshot = null,
                };

                if (dataLakeUriBuilder.DirectoryOrFilePath == null || dataLakeUriBuilder.LastDirectoryOrFileName == null)
                {
                    throw new InvalidOperationException();
                }
                dataLakeUriBuilder.DirectoryOrFilePath = dataLakeUriBuilder.DirectoryOrFilePath.GetParentPath();

                _parentDirectoryClient = new DataLakeDirectoryClient(
                    dataLakeUriBuilder.ToUri(),
                    ClientConfiguration);
            }

            return _parentDirectoryClient;
        }
        #endregion

        private void SetBuilderAndValidate(DataLakeSasBuilder builder)
        {
            // Assign builder's IsDirectory, FileSystemName, and Path, if they are null.
            builder.IsDirectory ??= GetType() == typeof(DataLakeDirectoryClient);
            builder.FileSystemName ??= FileSystemName;
            builder.Path ??= Path;

            // Validate that builder is properly set
            if (builder.IsDirectory.GetValueOrDefault(false))
            {
                throw Errors.SasIncorrectResourceType(
                    nameof(builder),
                    nameof(builder.IsDirectory),
                    Constants.FalseName,
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
        }
    }

    namespace Specialized
    {
        /// <summary>
        /// Add easy to discover methods to <see cref="DataLakePathClient"/> for
        /// creating <see cref="DataLakeFileSystemClient"/> instances.
        /// </summary>
        public static partial class SpecializedDataLakeExtensions
        {
            /// <summary>
            /// Create a new <see cref="DataLakeFileSystemClient"/> that pointing to this <see cref="DataLakePathClient"/>'s parent container.
            /// The new <see cref="DataLakeFileSystemClient"/>
            /// uses the same request policy pipeline as the
            /// <see cref="DataLakePathClient"/>.
            /// </summary>
            /// <param name="client">The <see cref="DataLakePathClient"/>.</param>
            /// <returns>A new <see cref="DataLakeFileSystemClient"/> instance.</returns>
            public static DataLakeFileSystemClient GetParentFileSystemClient(this DataLakePathClient client)
            {
                return client.GetParentFileSystemClientCore();
            }

            /// <summary>
            /// Create a new <see cref="DataLakeDirectoryClient"/> that pointing to this <see cref="DataLakePathClient"/>'s parent directory.
            /// The new <see cref="DataLakeDirectoryClient"/>
            /// uses the same request policy pipeline as the
            /// <see cref="DataLakePathClient"/>.
            /// </summary>
            /// <param name="client">The <see cref="DataLakePathClient"/>.</param>
            /// <returns>A new <see cref="DataLakeDirectoryClient"/> instance.</returns>
            public static DataLakeDirectoryClient GetParentDirectoryClient(this DataLakePathClient client)
            {
                return client.GetParentDirectoryClientCore();
            }
        }
    }
}
