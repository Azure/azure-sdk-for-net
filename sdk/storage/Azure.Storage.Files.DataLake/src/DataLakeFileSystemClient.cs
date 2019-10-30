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
        /// ContainerClient
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
        protected virtual HttpPipeline Pipeline => _pipeline;

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
        /// The <see cref="ClientDiagnostics"/> instance used to create diagnostic scopes
        /// every request.
        /// </summary>
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// The <see cref="ClientDiagnostics"/> instance used to create diagnostic scopes
        /// every request.
        /// </summary>
        internal virtual ClientDiagnostics ClientDiagnostics => _clientDiagnostics;

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
            : this(fileSystemUri, (HttpPipelinePolicy)null, null)
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
            : this(fileSystemUri, (HttpPipelinePolicy)null, options)
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
        public DataLakeFileSystemClient(Uri fileSystemUri, StorageSharedKeyCredential credential)
            : this(fileSystemUri, credential.AsPolicy(), null)
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
            : this(fileSystemUri, credential.AsPolicy(), options)
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
            : this(fileSystemUri, credential.AsPolicy(), null)
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
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public DataLakeFileSystemClient(Uri fileSystemUri, TokenCredential credential, DataLakeClientOptions options)
            : this(fileSystemUri, credential.AsPolicy(), options)
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
        /// <param name="authentication">
        /// An optional authentication policy used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        internal DataLakeFileSystemClient(Uri fileSystemUri, HttpPipelinePolicy authentication, DataLakeClientOptions options)
        {
            options ??= new DataLakeClientOptions();
            _uri = fileSystemUri;
            _blobUri = GetBlobUri(fileSystemUri);
            _dfsUri = GetDfsUri(fileSystemUri);
            _pipeline = options.Build(authentication);
            _clientDiagnostics = new ClientDiagnostics(options);
            _containerClient = new BlobContainerClient(_blobUri, _pipeline, _clientDiagnostics, null);
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
       /// <param name="clientDiagnostics"></param>
        internal DataLakeFileSystemClient(Uri fileSystemUri, HttpPipeline pipeline, ClientDiagnostics clientDiagnostics)
        {
            _uri = fileSystemUri;
            _blobUri = GetBlobUri(fileSystemUri);
            _dfsUri = GetDfsUri(fileSystemUri);
            _pipeline = pipeline;
            _clientDiagnostics = clientDiagnostics;
            _containerClient = new BlobContainerClient(_blobUri, pipeline, clientDiagnostics, null);
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
            => new DataLakeDirectoryClient(Uri.AppendToPath(directoryName), Pipeline);

        /// <summary>
        /// Create a new <see cref="DataLakeFileClient"/> object by appending
        /// <paramref name="fileName"/> to the end of <see cref="Uri"/>.  The
        /// new <see cref="DataLakeFileClient"/> uses the same request policy
        /// pipeline as the <see cref="DataLakeFileClient"/>.
        /// </summary>
        /// <param name="fileName">The name of the directory.</param>
        /// <returns>A new <see cref="DataLakeFileClient"/> instance.</returns>
        public virtual DataLakeFileClient GetFileClient(string fileName)
            => new DataLakeFileClient(Uri.AppendToPath(fileName), Pipeline);

        /// <summary>
        /// Gets the blob Uri.
        /// </summary>
        private static Uri GetBlobUri(Uri uri)
        {
            Uri blobUri;
            if (uri.Host.Contains(Constants.DataLake.DfsUriSuffix))
            {
                UriBuilder uriBuilder = new UriBuilder(uri);
                uriBuilder.Host = uriBuilder.Host.Replace(
                    Constants.DataLake.DfsUriSuffix,
                    Constants.DataLake.BlobUriSuffix);
                blobUri = uriBuilder.Uri;
            }
            else
            {
                blobUri = uri;
            }
            return blobUri;
        }

        /// <summary>
        /// Gets the dfs Uri.
        /// </summary>
        private static Uri GetDfsUri(Uri uri)
        {
            Uri dfsUri;
            if (uri.Host.Contains(Constants.DataLake.BlobUriSuffix))
            {
                UriBuilder uriBuilder = new UriBuilder(uri);
                uriBuilder.Host = uriBuilder.Host.Replace(
                    Constants.DataLake.BlobUriSuffix,
                    Constants.DataLake.DfsUriSuffix);
                dfsUri = uriBuilder.Uri;
            }
            else
            {
                dfsUri = uri;
            }
            return dfsUri;
        }

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
        /// under the specified account. If the container with the same name
        /// already exists, the operation fails.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/create-container"/>.
        /// </summary>
        /// <param name="publicAccessType">
        /// Optionally specifies whether data in the container may be accessed
        /// publicly and the level of access. <see cref="Models.PublicAccessType.Container"/>
        /// specifies full public read access for container and blob data.
        /// Clients can enumerate blobs within the container via anonymous
        /// request, but cannot enumerate containers within the storage
        /// account.  <see cref="Models.PublicAccessType.Blob"/> specifies public
        /// read access for blobs.  Blob data within this container can be
        /// read via anonymous request, but file system data is not available.
        /// Clients cannot enumerate blobs within the file system via anonymous
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
        /// created container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<FileSystemInfo> Create(
            Models.PublicAccessType publicAccessType = Models.PublicAccessType.None,
            Metadata metadata = default,
            CancellationToken cancellationToken = default)
        {
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

        /// <summary>
        /// The <see cref="CreateAsync"/> operation creates a new file system
        /// under the specified account. If the file system with the same name
        /// already exists, the operation fails.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/create-container"/>.
        /// </summary>
        /// <param name="publicAccessType">
        /// Optionally specifies whether data in the file system may be accessed
        /// publicly and the level of access. <see cref="Models.PublicAccessType.Container"/>
        /// specifies full public read access for file system and blob data.
        /// Clients can enumerate blobs within the file system via anonymous
        /// request, but cannot enumerate file system within the storage
        /// account.  <see cref="Models.PublicAccessType.Blob"/> specifies public
        /// read access for blobs.  Blob data within this file system can be
        /// read via anonymous request, but file system data is not available.
        /// Clients cannot enumerate blobs within the file system via anonymous
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
        [ForwardsClientCalls]
        public virtual async Task<Response<FileSystemInfo>> CreateAsync(
            Models.PublicAccessType publicAccessType = Models.PublicAccessType.None,
            Metadata metadata = default,
            CancellationToken cancellationToken = default)
        {
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
        #endregion Create

        #region Delete
        /// <summary>
        /// The <see cref="Delete"/> operation marks the specified
        /// file system for deletion. The file system and any blobs contained
        /// within it are later deleted during garbage collection.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-container" />.
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
        [ForwardsClientCalls]
        public virtual Response Delete(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            _containerClient.Delete(
                conditions.ToBlobRequestConditions(),
                cancellationToken);

        /// <summary>
        /// The <see cref="DeleteAsync"/> operation marks the specified
        /// file system for deletion. The file system and any blobs contained
        /// within it are later deleted during garbage collection.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-container" />.
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
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteAsync(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await _containerClient.DeleteAsync(
                conditions.ToBlobRequestConditions(),
                cancellationToken)
                .ConfigureAwait(false);
        #endregion Delete

        #region GetProperties
        /// <summary>
        /// The <see cref="GetProperties"/> operation returns all
        /// user-defined metadata and system properties for the specified
        /// file system. The data returned does not include the file system's
        /// list of blobs.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-container-properties" />.
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
        [ForwardsClientCalls]
        public virtual Response<FileSystemProperties> GetProperties(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            Response<BlobContainerProperties> containerResponse = _containerClient.GetProperties(
                conditions.ToBlobRequestConditions(),
                cancellationToken);

            return Response.FromValue(
                containerResponse.Value.ToFileSystemProperties(),
                containerResponse.GetRawResponse());
        }

        /// <summary>
        /// The <see cref="GetPropertiesAsync"/> operation returns all
        /// user-defined metadata and system properties for the specified
        /// file system. The data returned does not include the file system's
        /// list of blobs.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-container-properties" />.
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
        /// A <see cref="Response{ContainerItem}"/> describing the
        /// file system and its properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<FileSystemProperties>> GetPropertiesAsync(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            Response<BlobContainerProperties> response = await _containerClient.GetPropertiesAsync(
                conditions.ToBlobRequestConditions(),
                cancellationToken)
                .ConfigureAwait(false);

            return Response.FromValue(
                response.Value.ToFileSystemProperties(),
                response.GetRawResponse());
        }
        #endregion GetProperties

        #region SetMetadata
        /// <summary>
        /// The <see cref="SetMetadata"/> operation sets one or more
        /// user-defined name-value pairs for the specified file system.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-container-metadata" />.
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
        /// A <see cref="Response{ContainerInfo}"/> if successful.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<FileSystemInfo> SetMetadata(
            Metadata metadata,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
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

        /// <summary>
        /// The <see cref="SetMetadataAsync"/> operation sets one or more
        /// user-defined name-value pairs for the specified file system.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-container-metadata" />.
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
        [ForwardsClientCalls]
        public virtual async Task<Response<FileSystemInfo>> SetMetadataAsync(
            Metadata metadata,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
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
        #endregion SetMetadata

        #region List Paths
        /// <summary>
        /// The <see cref="ListPaths"/> operation returns an async sequence
        /// of paths in this file system.  Enumerating the paths may make
        /// multiple requests to the service while fetching all the values.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/list"/>.
        /// </summary>
        /// <param name="path">
        /// Filters results to paths within the specified directory.
        /// </param>
        /// <param name="recursive">
        /// If "true", all paths are listed; otherwise, only paths at the root of the filesystem are listed.
        /// </param>
        /// <param name="upn">
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
        /// An <see cref="Pageable{T}"/> of <see cref="BlobItem"/>
        /// describing the paths in the file system.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Pageable<PathItem> ListPaths(
            string path = default,
            bool recursive = default,
            bool upn = default,
            CancellationToken cancellationToken = default) =>
            new GetPathsAsyncCollection(
                this,
                path,
                recursive,
                upn).ToSyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="ListPathsAsync"/> operation returns an async
        /// sequence of paths in this file system.  Enumerating the paths may
        /// make multiple requests to the service while fetching all the
        /// values.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/list"/>.
        /// </summary>
        /// <param name="path">
        /// Filters results to paths within the specified directory.
        /// </param>
        /// <param name="recursive">
        /// If "true", all paths are listed; otherwise, only paths at the root of the filesystem are listed.
        /// </param>
        /// <param name="upn">
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
        public virtual AsyncPageable<PathItem> ListPathsAsync(
            string path = default,
            bool recursive = default,
            bool upn = default,
            CancellationToken cancellationToken = default) =>
            new GetPathsAsyncCollection(this,
                path,
                recursive,
                upn).ToAsyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="ListPathsInternal"/> operation returns a
        /// single segment of paths in this file system, starting
        /// from the specified <paramref name="continuation"/>.  Use an empty
        /// <paramref name="continuation"/> to start enumeration from the beginning
        /// and the <see cref="PathSegment.Continuation"/> if it's not
        /// empty to make subsequent calls to <see cref="ListPathsAsync"/>
        /// to continue enumerating the paths segment by segment. Blobs are
        /// ordered lexicographically by name.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/list"/>.
        /// </summary>
        /// <param name="path">
        /// Filters results to paths within the specified directory.
        /// </param>
        /// <param name="recursive">
        /// If "true", all paths are listed; otherwise, only paths at the root of the filesystem are listed.
        /// </param>
        /// <param name="upn">
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
        internal async Task<Response<PathSegment>> ListPathsInternal(
            string path,
            bool recursive,
            bool upn,
            string continuation,
            int? maxResults,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(DataLakeFileSystemClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
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
                        continuation: continuation,
                        recursive: recursive,
                        maxResults: maxResults,
                        upn: upn,
                        path: path,
                        async: async,
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
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the creation of this file or directory..
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<DataLakeDirectoryClient> CreateDirectory(
            string path,
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
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

        /// <summary>
        /// The <see cref="CreateDirectoryAsync"/> operation creates a directory in this file system.
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
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the creation of this file or directory..
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<DataLakeDirectoryClient>> CreateDirectoryAsync(
            string path,
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DataLakeDirectoryClient directoryClient = GetDirectoryClient(path);

            Response<PathInfo> response = await GetDirectoryClient(path).CreateAsync(
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
        #endregion Create Directory

        #region Delete Directory
        /// <summary>
        /// The <see cref="DeleteDirectory"/> operation marks the specified path
        /// deletion. The path is later deleted during
        /// garbage collection.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete" />.
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
        [ForwardsClientCalls]
        public virtual Response DeleteDirectory(
            string path,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            GetDirectoryClient(path).Delete(
                recursive: true,
                conditions,
                cancellationToken);

        /// <summary>
        /// The <see cref="DeleteDirectoryAsync"/> deletes a directory in this file system.
        /// garbage collection.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete" />.
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
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteDirectoryAsync(
            string path,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await GetDirectoryClient(path).DeleteAsync(
                recursive: true,
                conditions,
                cancellationToken)
                .ConfigureAwait(false);
        #endregion Delete Directory

        #region Create File
        /// <summary>
        /// The <see cref="CreateFile"/> operation creates a file or directory.
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
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the creation of this file or directory..
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<DataLakeFileClient> CreateFile(
            string path,
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
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

        /// <summary>
        /// The <see cref="CreateFileAsync"/> creates a file in this file system
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
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the creation of this file or directory..
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<DataLakeFileClient>> CreateFileAsync(
            string path,
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
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
        #endregion Create File

        #region Delete File
        /// <summary>
        /// The <see cref="DeleteFile"/> deletes a file in this file system.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete" />.
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
        [ForwardsClientCalls]
        public virtual Response DeleteFile(
            string path,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            GetFileClient(path).Delete(
                conditions,
                cancellationToken);

        /// <summary>
        /// The <see cref="DeleteFileAsync"/> deletes a file in this file system.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete" />.
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
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteFileAsync(
            string path,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
            => await GetFileClient(path).DeleteAsync(
                conditions,
                cancellationToken)
                .ConfigureAwait(false);

        #endregion Delete File
    }
}
