// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.Files.DataLake.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.DataLake
{
    /// <summary>
    /// The <see cref="DataLakeServiceClient"/> allows you to manipulate Azure
    /// Data Lake service resources and file systems. The storage account provides
    /// the top-level namespace for the Data Lake service.
    /// </summary>
    public class DataLakeServiceClient
    {
        /// <summary>
        /// The <see cref="BlobServiceClient"/> associated with the file system.
        /// </summary>
        private readonly BlobServiceClient _blobServiceClient;

        /// <summary>
        /// The Data Lake service's customer-provided <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _uri;

        /// <summary>
        /// The Data Lake service's blob <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _blobUri;

        /// <summary>
        /// Gets the Data Lake service's primary <see cref="Uri"/> endpoint.
        /// </summary>
        public virtual Uri Uri => _uri;

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send
        /// every request.
        /// </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary>
        /// Gets tghe <see cref="HttpPipeline"/> transport pipeline used to
        /// send every request.
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
        /// The Storage account name corresponding to the file service client.
        /// </summary>
        private string _accountName;

        /// <summary>
        /// Gets the Storage account name corresponding to the file service client.
        /// </summary>
        public virtual string AccountName
        {
            get
            {
                if (_accountName == null)
                {
                    _accountName = new DataLakeUriBuilder(Uri).AccountName;
                }
                return _accountName;
            }
        }

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeServiceClient"/>
        /// class for mocking.
        /// </summary>
        protected DataLakeServiceClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the Data Lake service.
        /// </param>
        public DataLakeServiceClient(Uri serviceUri)
            : this(serviceUri, (HttpPipelinePolicy)null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the Data Lake service.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public DataLakeServiceClient(Uri serviceUri, DataLakeClientOptions options)
            : this(serviceUri, (HttpPipelinePolicy)null, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the Data Lake service.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        public DataLakeServiceClient(Uri serviceUri, StorageSharedKeyCredential credential)
            : this(serviceUri, credential.AsPolicy(), null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the Data Lake service.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public DataLakeServiceClient(Uri serviceUri, StorageSharedKeyCredential credential, DataLakeClientOptions options)
            : this(serviceUri, credential.AsPolicy(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the Data Lake service.
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        public DataLakeServiceClient(Uri serviceUri, TokenCredential credential)
            : this(serviceUri, credential.AsPolicy(), null)
        {
            Errors.VerifyHttpsTokenAuth(serviceUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the Data Lake service.
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public DataLakeServiceClient(Uri serviceUri, TokenCredential credential, DataLakeClientOptions options)
            : this(serviceUri, credential.AsPolicy(), options)
        {
            Errors.VerifyHttpsTokenAuth(serviceUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the Data Lake service
        /// </param>
        /// <param name="authentication">
        /// An optional authentication policy used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        internal DataLakeServiceClient(Uri serviceUri, HttpPipelinePolicy authentication, DataLakeClientOptions options)
            : this(serviceUri, authentication, options, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the Data Lake service.
        /// </param>
        /// <param name="authentication">
        /// An optional authentication policy used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        /// <param name="clientDiagnostics"></param>
        internal DataLakeServiceClient(
            Uri serviceUri,
            HttpPipelinePolicy authentication,
            DataLakeClientOptions options,
            ClientDiagnostics clientDiagnostics)
        {
            options ??= new DataLakeClientOptions();
            _pipeline = options.Build(authentication);
            _uri = serviceUri;
            _blobUri = new DataLakeUriBuilder(serviceUri).ToBlobUri();
            _version = options.Version;
            _clientDiagnostics = clientDiagnostics ?? new ClientDiagnostics(options);
            _blobServiceClient = BlobServiceClientInternals.Create(
                _blobUri,
                _pipeline,
                authentication,
                Version.AsBlobsVersion(),
                _clientDiagnostics);
        }

        /// <summary>
        /// Helper to access protected static members of BlobServiceClient
        /// that should not be exposed directly to customers.
        /// </summary>
        private class BlobServiceClientInternals : BlobServiceClient
        {
            public static BlobServiceClient Create(Uri uri, HttpPipeline pipeline, HttpPipelinePolicy authentication, BlobClientOptions.ServiceVersion version, ClientDiagnostics diagnostics)
            {
                return BlobServiceClient.CreateClient(
                    uri,
                    new BlobClientOptions(version)
                    {
                        Diagnostics = { IsDistributedTracingEnabled = diagnostics.IsActivityEnabled }
                    },
                    authentication,
                    pipeline);
            }
        }
        #endregion ctors

        /// <summary>
        /// Create a new <see cref="DataLakeFileSystemClient"/> object by appending
        /// <paramref name="fileSystemName"/> to the end of <see cref="Uri"/>.
        /// The new <see cref="DataLakeFileSystemClient"/> uses the same request
        /// policy pipeline as the <see cref="DataLakeFileSystemClient"/>.
        /// </summary>
        /// <param name="fileSystemName">
        /// The name of the share to reference.
        /// </param>
        /// <returns>
        /// A <see cref="DataLakeFileSystemClient"/> for the desired share.
        /// </returns>
        public virtual DataLakeFileSystemClient GetFileSystemClient(string fileSystemName)
            => new DataLakeFileSystemClient(Uri.AppendToPath(fileSystemName), Pipeline, Version, ClientDiagnostics);

        #region Get User Delegation Key
        /// <summary>
        /// The <see cref="GetUserDelegationKey"/> operation retrieves a
        /// key that can be used to delegate Active Directory authorization to
        /// shared access signatures created with <see cref="Sas.DataLakeSasBuilder"/>.
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
        /// A <see cref="Response{UserDelegationKey}"/> describing
        /// the use delegation key.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<UserDelegationKey> GetUserDelegationKey(
            DateTimeOffset? startsOn,
            DateTimeOffset expiresOn,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(GetUserDelegationKey)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.UserDelegationKey> response = _blobServiceClient.GetUserDelegationKey(
                    startsOn,
                    expiresOn,
                    cancellationToken);

                return Response.FromValue(
                    new UserDelegationKey(response.Value),
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
        /// The <see cref="GetUserDelegationKeyAsync"/> operation retrieves a
        /// key that can be used to delegate Active Directory authorization to
        /// shared access signatures created with <see cref="Sas.DataLakeSasBuilder"/>.
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
        /// A <see cref="Response{UserDelegationKey}"/> describing
        /// the use delegation key.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<UserDelegationKey>> GetUserDelegationKeyAsync(
            DateTimeOffset? startsOn,
            DateTimeOffset expiresOn,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(GetUserDelegationKey)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.UserDelegationKey> response = await _blobServiceClient.GetUserDelegationKeyAsync(
                    startsOn,
                    expiresOn,
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    new UserDelegationKey(response.Value),
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

        #endregion Get User Delegation Key

        #region Get File Systems
        /// <summary>
        /// The <see cref="GetFileSystems"/> operation returns an async
        /// sequence of file systems in the storage account.  Enumerating the
        /// file systems may make multiple requests to the service while fetching
        /// all the values.  File systems are ordered lexicographically by name.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-containers2">
        /// List Containers</see>.
        /// </summary>
        /// <param name="traits">
        /// Specifies trait options for shaping the file systems.
        /// </param>
        /// <param name="prefix">
        /// Specifies a string that filters the results to return only file systems
        /// whose name begins with the specified <paramref name="prefix"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of <see cref="Response{FileSystemItem}"/>
        /// describing the file systems in the storage account.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Pageable<FileSystemItem> GetFileSystems(
            FileSystemTraits traits = FileSystemTraits.None,
            string prefix = default,
            CancellationToken cancellationToken = default) =>
            new GetFileSystemsAsyncCollection(_blobServiceClient, traits, prefix).ToSyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetFileSystemsAsync"/> operation returns an async
        /// sequence of file systems in the storage account.  Enumerating the
        /// files systems may make multiple requests to the service while fetching
        /// all the values.  File systems are ordered lexicographically by name.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-containers2">
        /// List Containers</see>.
        /// </summary>
        /// <param name="traits">
        /// Specifies trait options for shaping the file systems.
        /// </param>
        /// <param name="prefix">
        /// Specifies a string that filters the results to return only file systems
        /// whose name begins with the specified <paramref name="prefix"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="AsyncPageable{T}"/> describing the
        /// file systems in the storage account.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual AsyncPageable<FileSystemItem> GetFileSystemsAsync(
            FileSystemTraits traits = FileSystemTraits.None,
            string prefix = default,
            CancellationToken cancellationToken = default) =>
            new GetFileSystemsAsyncCollection(_blobServiceClient, traits, prefix).ToAsyncCollection(cancellationToken);
        #endregion Get File Systems

        #region Create File System
        /// <summary>
        /// The <see cref="CreateFileSystem"/> operation creates a new
        /// file system under the specified account. If the file systen with the
        /// same name already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-container">
        /// Create Container</see>.
        /// </summary>
        /// <param name="fileSystemName">
        /// The name of the file system to create.
        /// </param>
        /// <param name="publicAccessType">
        /// Optionally specifies whether data in the file system may be accessed
        /// publicly and the level of access. <see cref="PublicAccessType.FileSystem"/>
        /// specifies full public read access for file system and path data.
        /// Clients can enumerate paths within the file system via anonymous
        /// request, but cannot enumerate file systems within the storage
        /// account.  <see cref="PublicAccessType.Path"/> specifies public
        /// read access for paths.  Path data within this file system can be
        /// read via anonymous request, but file system data is not available.
        /// Clients cannot enumerate paths within the file system via anonymous
        /// request.  <see cref="PublicAccessType.None"/> specifies that the
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
        /// A <see cref="Response{FileSystemClient}"/> referencing the
        /// newly created file system.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<DataLakeFileSystemClient> CreateFileSystem(
            string fileSystemName,
            PublicAccessType publicAccessType = PublicAccessType.None,
            Metadata metadata = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(CreateFileSystem)}");

            try
            {
                scope.Start();

                DataLakeFileSystemClient fileSystem = GetFileSystemClient(fileSystemName);
                Response<FileSystemInfo> response = fileSystem.Create(publicAccessType, metadata, cancellationToken);
                return Response.FromValue(fileSystem, response.GetRawResponse());
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
        /// The <see cref="CreateFileSystemAsync"/> operation creates a new
        /// file system under the specified account. If the file system with the
        /// same name already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-container">
        /// Create Container</see>.
        /// </summary>
        /// <param name="fileSystemName">
        /// The name of the file system to create.
        /// </param>
        /// <param name="publicAccessType">
        /// Optionally specifies whether data in the file system may be accessed
        /// publicly and the level of access. <see cref="PublicAccessType.FileSystem"/>
        /// specifies full public read access for file system and path data.
        /// Clients can enumerate paths within the file system via anonymous
        /// request, but cannot enumerate file systems within the storage
        /// account.  <see cref="PublicAccessType.Path"/> specifies public
        /// read access for paths.  Path data within this file system can be
        /// read via anonymous request, but file system data is not available.
        /// Clients cannot enumerate paths within the file system via anonymous
        /// request.  <see cref="PublicAccessType.None"/> specifies that the
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
        /// A <see cref="Response{FileSystemClient}"/> referencing the
        /// newly created file system.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<DataLakeFileSystemClient>> CreateFileSystemAsync(
            string fileSystemName,
            PublicAccessType publicAccessType = PublicAccessType.None,
            Metadata metadata = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(CreateFileSystem)}");

            try
            {
                scope.Start();

                DataLakeFileSystemClient fileSystem = GetFileSystemClient(fileSystemName);
                Response<FileSystemInfo> response = await fileSystem.CreateAsync(publicAccessType, metadata, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(fileSystem, response.GetRawResponse());
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
        #endregion Create File System

        #region Delete File System
        /// <summary>
        /// The <see cref="DeleteFileSystem"/> operation marks the
        /// specified file system for deletion. The file system and any paths
        /// contained within it are later deleted during garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-container">
        /// Delete Container</see>.
        /// </summary>
        /// <param name="fileSystemName">
        /// The name of the file system to delete.
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
        /// A <see cref="Response"/> if successful.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response DeleteFileSystem(
            string fileSystemName,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(DeleteFileSystem)}");

            try
            {
                scope.Start();

                return GetFileSystemClient(fileSystemName)
                    .Delete(
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
        /// The <see cref="DeleteFileSystemAsync"/> operation marks the
        /// specified file system for deletion. The file system and any paths
        /// contained within it are later deleted during garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-container">
        /// Delete Container</see>.
        /// </summary>
        /// <param name="fileSystemName">
        /// The name of the file system to delete.
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
        /// A <see cref="Response"/> if successful.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> DeleteFileSystemAsync(
            string fileSystemName,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(DeleteFileSystem)}");

            try
            {
                scope.Start();

                return await GetFileSystemClient(fileSystemName)
                    .DeleteAsync(
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
        #endregion Delete File System
    }
}
