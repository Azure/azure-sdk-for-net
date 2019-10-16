﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Files.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files
{
    /// <summary>
    /// A DirectoryClient represents a URI to the Azure Storage File service allowing you to manipulate a directory.
    /// </summary>
    public class DirectoryClient
    {
        /// <summary>
        /// The directory's primary <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _uri;

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
        /// The share name corresponding to the directory client.
        /// </summary>
        private string _shareName;

        /// <summary>
        /// Gets the share name corresponding to the directory client.
        /// </summary>
        public virtual string ShareName
        {
            get
            {
                SetNameFieldsIfNull();
                return _shareName;
            }
        }

        /// <summary>
        /// The name of the directory.
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets the name of the directory.
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
        /// The path of the directory.
        /// </summary>
        private string _path;

        /// <summary>
        /// Gets the path of the directory.
        /// </summary>
        public virtual string Path
        {
            get
            {
                SetNameFieldsIfNull();
                return _path;
            }
        }

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryClient"/>
        /// class for mocking.
        /// </summary>
        protected DirectoryClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryClient"/> class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information, <see href="https://docs.microsoft.com/en-us/azure/storage/common/storage-configure-connection-string"/>.
        /// </param>
        /// <param name="shareName">
        /// The name of the share in the storage account to reference.
        /// </param>
        /// <param name="directoryPath">
        /// The path of the directory in the storage account to reference.
        /// </param>
        public DirectoryClient(string connectionString, string shareName, string directoryPath)
            : this(connectionString, shareName, directoryPath, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryClient"/> class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information, <see href="https://docs.microsoft.com/en-us/azure/storage/common/storage-configure-connection-string"/>.
        /// </param>
        /// <param name="shareName">
        /// The name of the share in the storage account to reference.
        /// </param>
        /// <param name="directoryPath">
        /// The path of the directory in the storage account to reference.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="FileClientOptions"/> that define the transport
        /// pipeline policies for authentication, retries, etc., that are
        /// applied to every request.
        /// </param>
        public DirectoryClient(string connectionString, string shareName, string directoryPath, FileClientOptions options)
        {
            options ??= new FileClientOptions();
            var conn = StorageConnectionString.Parse(connectionString);
            var builder =
                new FileUriBuilder(conn.FileEndpoint)
                {
                    ShareName = shareName,
                    DirectoryOrFilePath = directoryPath
                };
            _uri = builder.ToUri();
            _pipeline = options.Build(conn.Credentials);
            _clientDiagnostics = new ClientDiagnostics(options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="directoryUri">
        /// A <see cref="Uri"/> referencing the directory that includes the
        /// name of the account, the name of the share, and the path of the
        /// directory.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="FileClientOptions"/> that define the transport
        /// pipeline policies for authentication, retries, etc., that are
        /// applied to every request.
        /// </param>
        public DirectoryClient(Uri directoryUri, FileClientOptions options = default)
            : this(directoryUri, (HttpPipelinePolicy)null, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="directoryUri">
        /// A <see cref="Uri"/> referencing the directory that includes the
        /// name of the account, the name of the share, and the path of the
        /// directory.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public DirectoryClient(Uri directoryUri, StorageSharedKeyCredential credential, FileClientOptions options = default)
            : this(directoryUri, credential.AsPolicy(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="directoryUri">
        /// A <see cref="Uri"/> referencing the directory that includes the
        /// name of the account, the name of the share, and the path of the
        /// directory.
        /// </param>
        /// <param name="authentication">
        /// An optional authentication policy used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        internal DirectoryClient(Uri directoryUri, HttpPipelinePolicy authentication, FileClientOptions options)
        {
            options ??= new FileClientOptions();
            _uri = directoryUri;
            _pipeline = options.Build(authentication);
            _clientDiagnostics = new ClientDiagnostics(options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="directoryUri">
        /// A <see cref="Uri"/> referencing the directory that includes the
        /// name of the account, the name of the share, and the path of the
        /// directory.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        /// <param name="clientDiagnostics"></param>
        internal DirectoryClient(Uri directoryUri, HttpPipeline pipeline, ClientDiagnostics clientDiagnostics)
        {
            _uri = directoryUri;
            _pipeline = pipeline;
            _clientDiagnostics = clientDiagnostics;
        }
        #endregion ctors

        /// <summary>
        /// Creates a new <see cref="FileClient"/> object by appending
        /// <paramref name="fileName"/> to the end of <see cref="Uri"/>.  The
        /// new <see cref="FileClient"/> uses the same request policy
        /// pipeline as the <see cref="DirectoryClient"/>.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>A new <see cref="FileClient"/> instance.</returns>
        public virtual FileClient GetFileClient(string fileName)
            => new FileClient(Uri.AppendToPath(fileName), Pipeline, ClientDiagnostics);

        /// <summary>
        /// Creates a new <see cref="DirectoryClient"/> object by appending
        /// <paramref name="subdirectoryName"/> to the end of <see cref="Uri"/>.
        /// The new <see cref="DirectoryClient"/> uses the same request policy
        /// pipeline as the <see cref="DirectoryClient"/>.
        /// </summary>
        /// <param name="subdirectoryName">The name of the subdirectory.</param>
        /// <returns>A new <see cref="DirectoryClient"/> instance.</returns>
        public virtual DirectoryClient GetSubdirectoryClient(string subdirectoryName)
            => new DirectoryClient(Uri.AppendToPath(subdirectoryName), Pipeline, ClientDiagnostics);

        /// <summary>
        /// Sets the various name fields if they are currently null.
        /// </summary>
        private void SetNameFieldsIfNull()
        {
            if (_name == null || _shareName == null || _accountName == null || _path == null)
            {
                var builder = new FileUriBuilder(Uri);
                _name = builder.LastDirectoryOrFileName;
                _shareName = builder.ShareName;
                _accountName = builder.AccountName;
                _path = builder.DirectoryOrFilePath;
            }
        }

        #region Create
        /// <summary>
        /// The <see cref="Create"/> operation creates a new directory
        /// at the specified <see cref="Uri"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/create-directory"/>.
        /// </summary>
        /// <param name="metadata">
        /// Optional custom metadata to set for this directory.
        /// </param>
        /// <param name="smbProperties">
        /// Optional SMB properties to set for the directory.
        /// </param>
        /// <param name="filePermission">
        /// Optional file permission to set on the directory.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageDirectoryInfo}"/> describing the newly
        /// created directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<StorageDirectoryInfo> Create(
            Metadata metadata = default,
            FileSmbProperties? smbProperties = default,
            string filePermission = default,
            CancellationToken cancellationToken = default) =>
            CreateInternal(
                metadata,
                smbProperties,
                filePermission,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="CreateAsync"/> operation creates a new directory
        /// at the specified <see cref="Uri"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/create-directory"/>.
        /// </summary>
        /// <param name="metadata">
        /// Optional custom metadata to set for this directory.
        /// </param>
        /// <param name="smbProperties">
        /// Optional SMB properties to set for the directory.
        /// </param>
        /// <param name="filePermission">
        /// Optional file permission to set on the directory.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageDirectoryInfo}"/> describing the newly
        /// created directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<StorageDirectoryInfo>> CreateAsync(
            Metadata metadata = default,
            FileSmbProperties? smbProperties = default,
            string filePermission = default,
            CancellationToken cancellationToken = default) =>
            await CreateInternal(
                metadata,
                smbProperties,
                filePermission,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CreateInternal"/> operation creates a new directory
        /// at the specified <see cref="Uri"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/create-directory"/>.
        /// </summary>
        /// <param name="metadata">
        /// Optional custom metadata to set for this directory.
        /// </param>
        /// <param name="smbProperties">
        /// Optional SMB properties to set for the directory.
        /// </param>
        /// <param name="filePermission">
        /// Optional file permission to set on the directory.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageDirectoryInfo}"/> describing the newly
        /// created directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<StorageDirectoryInfo>> CreateInternal(
            Metadata metadata,
            FileSmbProperties? smbProperties,
            string filePermission,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(DirectoryClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(DirectoryClient),
                    message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    FileSmbProperties smbProps = smbProperties ?? new FileSmbProperties();

                    FileExtensions.AssertValidFilePermissionAndKey(filePermission, smbProps.FilePermissionKey);
                    if (filePermission == null && smbProps.FilePermissionKey == null)
                    {
                        filePermission = Constants.File.FilePermissionInherit;
                    }

                    Response<RawStorageDirectoryInfo> response = await FileRestClient.Directory.CreateAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        metadata: metadata,
                        fileAttributes: smbProps.FileAttributes?.ToString() ?? Constants.File.FileAttributesNone,
                        filePermission: filePermission,
                        fileCreationTime: smbProps.FileCreationTimeToString() ?? Constants.File.FileTimeNow,
                        fileLastWriteTime: smbProps.FileLastWriteTimeToString() ?? Constants.File.FileTimeNow,
                        filePermissionKey: smbProps.FilePermissionKey,
                        async: async,
                        operationName: Constants.File.Directory.CreateOperationName,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return Response.FromValue(new StorageDirectoryInfo(response.Value), response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(DirectoryClient));
                }
            }
        }
        #endregion Create

        #region Delete
        /// <summary>
        /// The <see cref="Delete"/> operation removes the specified empty directory.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-directory"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> if successful.
        /// </returns>
        /// <remarks>
        /// Note that the directory must be empty before it can be deleted.
        /// </remarks>
        public virtual Response Delete(
            CancellationToken cancellationToken = default) =>
            DeleteInternal(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="DeleteAsync"/> operation removes the specified empty directory.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-directory"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> if successful.
        /// </returns>
        /// <remarks>
        /// Note that the directory must be empty before it can be deleted.
        /// </remarks>
        public virtual async Task<Response> DeleteAsync(
            CancellationToken cancellationToken = default) =>
            await DeleteInternal(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DeleteInternal"/> operation removes the specified
        /// empty directory.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-directory"/>.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> if successful.
        /// </returns>
        /// <remarks>
        /// Note that the directory must be empty before it can be deleted.
        /// </remarks>
        private async Task<Response> DeleteInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(DirectoryClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(DirectoryClient),
                    message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    return await FileRestClient.Directory.DeleteAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        async: async,
                        operationName: Constants.File.Directory.DeleteOperationName,
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
                    Pipeline.LogMethodExit(nameof(DirectoryClient));
                }
            }
        }
        #endregion Delete

        #region GetProperties
        /// <summary>
        /// The <see cref="GetProperties"/> operation returns all
        /// user-defined metadata and system properties for the specified
        /// directory. The data returned does not include the directory's
        /// list of subdirectories or files.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-directory-properties"/>.
        /// </summary>
        /// <param name="shareSnapshot">
        /// Optionally specifies the share snapshot to retrieve the directory properties
        /// from. For more information on working with share snapshots, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/snapshot-share"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageDirectoryProperties}"/> describing the
        /// directory and its properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<StorageDirectoryProperties> GetProperties(
            string shareSnapshot = default,
            CancellationToken cancellationToken = default) =>
            GetPropertiesInternal(
                shareSnapshot,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetPropertiesAsync"/> operation returns all
        /// user-defined metadata and system properties for the specified
        /// directory. The data returned does not include the directory's
        /// list of subdirectories or files.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-directory-properties"/>.
        /// </summary>
        /// <param name="shareSnapshot">
        /// Optionally specifies the share snapshot to retrieve the directory properties
        /// from. For more information on working with share snapshots, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/snapshot-share"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageDirectoryProperties}"/> describing the
        /// directory and its properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<StorageDirectoryProperties>> GetPropertiesAsync(
            string shareSnapshot = default,
            CancellationToken cancellationToken = default) =>
            await GetPropertiesInternal(
                shareSnapshot,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetPropertiesInternal"/> operation returns all
        /// user-defined metadata and system properties for the specified
        /// directory. The data returned does not include the directory's
        /// list of subdirectories or files.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-directory-properties"/>.
        /// </summary>
        /// <param name="shareSnapshot">
        /// Optionally specifies the share snapshot to retrieve the directory properties
        /// from. For more information on working with share snapshots, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/snapshot-share"/>.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageDirectoryProperties}"/> describing the
        /// directory and its properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<StorageDirectoryProperties>> GetPropertiesInternal(
            string shareSnapshot,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(DirectoryClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(DirectoryClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(shareSnapshot)}: {shareSnapshot}");
                try
                {
                    Response<RawStorageDirectoryProperties> response = await FileRestClient.Directory.GetPropertiesAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        sharesnapshot: shareSnapshot,
                        async: async,
                        operationName: Constants.File.Directory.GetPropertiesOperationName,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return Response.FromValue(new StorageDirectoryProperties(response.Value), response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(DirectoryClient));
                }
            }
        }
        #endregion GetProperties

        #region SetHttpHeaders
        /// <summary>
        /// The <see cref="SetHttpHeaders"/> operation sets system
        /// properties on the directory.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-directory-properties"/>.
        /// </summary>
        /// <param name="smbProperties">
        /// Optional SMB properties to set for the directory.
        /// </param>
        /// <param name="filePermission">
        /// Optional file permission to set for the directory.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<StorageDirectoryInfo> SetHttpHeaders(
            FileSmbProperties? smbProperties = default,
            string filePermission = default,
            CancellationToken cancellationToken = default) =>
            SetHttpHeadersInternal(
                smbProperties,
                filePermission,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="SetHttpHeadersAsync"/> operation sets system
        /// properties on the directory.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-directory-properties"/>.
        /// </summary>
        /// <param name="smbProperties">
        /// Optional SMB properties to set for the directory.
        /// </param>
        /// <param name="filePermission">
        /// Optional file permission to set for the directory.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<StorageDirectoryInfo>> SetHttpHeadersAsync(
            FileSmbProperties? smbProperties = default,
            string filePermission = default,
            CancellationToken cancellationToken = default) =>
            await SetHttpHeadersInternal(
                smbProperties,
                filePermission,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetHttpHeadersInternal"/> operation sets system
        /// properties on the directory.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-directory-properties"/>.
        /// </summary>
        /// <param name="smbProperties">
        /// Optional SMB properties to set for the directory.
        /// </param>
        /// <param name="filePermission">
        /// Optional file permission to set ofr the directory.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<StorageDirectoryInfo>> SetHttpHeadersInternal(
            FileSmbProperties? smbProperties,
            string filePermission,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(DirectoryClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(DirectoryClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n");
                try
                {
                    FileSmbProperties smbProps = smbProperties ?? new FileSmbProperties();

                    FileExtensions.AssertValidFilePermissionAndKey(filePermission, smbProps.FilePermissionKey);
                    if (filePermission == null && smbProps.FilePermissionKey == null)
                    {
                        filePermission = Constants.File.Preserve;
                    }

                    Response<RawStorageDirectoryInfo> response = await FileRestClient.Directory.SetPropertiesAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        fileAttributes: smbProps.FileAttributes?.ToString() ?? Constants.File.Preserve,
                        filePermission: filePermission,
                        fileCreationTime: smbProps.FileCreationTimeToString() ?? Constants.File.Preserve,
                        fileLastWriteTime: smbProps.FileLastWriteTimeToString() ?? Constants.File.Preserve,
                        filePermissionKey: smbProps.FilePermissionKey,
                        async: async,
                        operationName: Constants.File.Directory.SetHttpHeadersOperationName,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return Response.FromValue(new StorageDirectoryInfo(response.Value), response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(DirectoryClient));
                }
            }
        }

        #endregion SetHttpHeaders

        #region SetMetadata
        /// <summary>
        /// The <see cref="SetMetadata"/> operation sets one or more
        /// user-defined name-value pairs for the specified directory.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-directory-metadata"/>.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this directory.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageDirectoryInfo}"/> if successful.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<StorageDirectoryInfo> SetMetadata(
            Metadata metadata,
            CancellationToken cancellationToken = default) =>
            SetMetadataInternal(
                metadata,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="SetMetadataAsync"/> operation sets one or more
        /// user-defined name-value pairs for the specified directory.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-directory-metadata"/>.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this directory.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageDirectoryInfo}"/> if successful.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<StorageDirectoryInfo>> SetMetadataAsync(
            Metadata metadata,
            CancellationToken cancellationToken = default) =>
            await SetMetadataInternal(
                metadata,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetMetadataInternal"/> operation sets one or more
        /// user-defined name-value pairs for the specified directory.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-directory-metadata"/>.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this directory.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageDirectoryInfo}"/> if successful.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<StorageDirectoryInfo>> SetMetadataInternal(
            Metadata metadata,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(DirectoryClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(DirectoryClient),
                    message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    Response<RawStorageDirectoryInfo> response = await FileRestClient.Directory.SetMetadataAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        metadata: metadata,
                        async: async,
                        operationName: Constants.File.Directory.SetMetadataOperationName,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return Response.FromValue(new StorageDirectoryInfo(response.Value), response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(DirectoryClient));
                }
            }
        }
        #endregion SetMetadata

        #region GetFilesAndDirectories
        /// <summary>
        /// The <see cref="GetFilesAndDirectories"/> operation returns an async
        /// sequence of files and subdirectories in this directory.
        /// Enumerating the files and directories may make multiple requests
        /// to the service while fetching all the values.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/list-directories-and-files"/>.
        /// </summary>
        /// <param name="options">
        /// Specifies options for listing, filtering, and shaping the items.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}" /> of <see cref="Response{StorageFileItem}"/>
        /// describing  the items in the directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Pageable<StorageFileItem> GetFilesAndDirectories(
            GetFilesAndDirectoriesOptions? options = default,
            CancellationToken cancellationToken = default) =>
            new GetFilesAndDirectoriesAsyncCollection(this, options).ToSyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetFilesAndDirectoriesAsync"/> operation returns an
        /// async collection of files and subdirectories in this directory.
        /// Enumerating the files and directories may make multiple requests
        /// to the service while fetching all the values.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/list-directories-and-files"/>.
        /// </summary>
        /// <param name="options">
        /// Specifies options for listing, filtering, and shaping the items.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="AsyncPageable{T}"/> describing the
        /// items in the directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual AsyncPageable<StorageFileItem> GetFilesAndDirectoriesAsync(
            GetFilesAndDirectoriesOptions? options = default,
            CancellationToken cancellationToken = default) =>
            new GetFilesAndDirectoriesAsyncCollection(this, options).ToAsyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetFilesAndDirectoriesInternal"/> operation returns a
        /// single segment of files and subdirectories in this directory, starting
        /// from the specified <paramref name="marker"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/list-directories-and-files"/>.
        /// </summary>
        /// <param name="marker">
        /// An optional string value that identifies the segment of the list
        /// of items to be returned with the next listing operation.  The
        /// operation returns a non-empty <see cref="FilesAndDirectoriesSegment.NextMarker"/>
        /// if the listing operation did not return all items remaining to be
        /// listed with the current segment.  The NextMarker value can
        /// be used as the value for the <paramref name="marker"/> parameter
        /// in a subsequent call to request the next segment of list items.
        /// </param>
        /// <param name="options">
        /// Specifies options for listing, filtering, and shaping the items.
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
        /// A <see cref="Response{FilesAndDirectoriesSegment}"/> describing a
        /// segment of the items in the directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<Response<FilesAndDirectoriesSegment>> GetFilesAndDirectoriesInternal(
            string marker,
            GetFilesAndDirectoriesOptions? options,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(DirectoryClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(DirectoryClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(marker)}: {marker}\n" +
                    $"{nameof(options)}: {options}");
                try
                {
                    return await FileRestClient.Directory.ListFilesAndDirectoriesSegmentAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        marker: marker,
                        prefix: options?.Prefix,
                        maxresults: pageSizeHint,
                        sharesnapshot: options?.ShareSnapshot,
                        async: async,
                        operationName: Constants.File.Directory.ListFilesAndDirectoriesSegmentOperationName,
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
                    Pipeline.LogMethodExit(nameof(DirectoryClient));
                }
            }
        }
        #endregion GetFilesAndDirectories

        #region GetHandles
        /// <summary>
        /// The <see cref="GetHandles"/> operation returns an async sequence
        /// of the open handles on a directory or a file.  Enumerating the
        /// handles may make multiple requests to the service while fetching
        /// all the values.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/list-handles"/>.
        /// </summary>
        /// <param name="recursive">
        /// Optional. A boolean value that specifies if the operation should also apply to the files and subdirectories of the directory specified.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of <see cref="Response{StorageHandle}"/>
        /// describing the handles in the directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Pageable<StorageFileHandle> GetHandles(
            bool? recursive = default,
            CancellationToken cancellationToken = default) =>
            new GetDirectoryHandlesAsyncCollection(this, recursive).ToSyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetHandlesAsync"/> operation returns an async
        /// sequence of the open handles on a directory or a file.
        /// Enumerating the handles may make multiple requests to the service
        /// while fetching all the values.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/list-handles"/>.
        /// </summary>
        /// <param name="recursive">
        /// Optional. A boolean value that specifies if the operation should also apply to the files and subdirectories of the directory specified.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="AsyncPageable{T}"/> describing the
        /// handles on the directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual AsyncPageable<StorageFileHandle> GetHandlesAsync(
            bool? recursive = default,
            CancellationToken cancellationToken = default) =>
            new GetDirectoryHandlesAsyncCollection(this, recursive).ToAsyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetHandlesAsync"/> operation returns a list of open
        /// handles on a directory or a file.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/list-handles"/>.
        /// </summary>
        /// <param name="marker">
        /// An optional string value that identifies the segment of the list
        /// of items to be returned with the next listing operation.  The
        /// operation returns a non-empty <see cref="StorageHandlesSegment.NextMarker"/>
        /// if the listing operation did not return all items remaining to be
        /// listed with the current segment.  The NextMarker value can
        /// be used as the value for the <paramref name="marker"/> parameter
        /// in a subsequent call to request the next segment of list items.
        /// </param>
        /// <param name="maxResults">
        /// Optional. Specifies the maximum number of handles taken on files and/or directories to return.
        /// </param>
        /// <param name="recursive">
        /// Optional. A boolean value that specifies if the operation should also apply to the files and subdirectories of the directory specified.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageHandlesSegment}"/> describing a
        /// segment of the handles in the directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<Response<StorageHandlesSegment>> GetHandlesInternal(
            string marker,
            int? maxResults,
            bool? recursive,
            bool async,
            CancellationToken cancellationToken)
        {
            // TODO Support share snapshot

            using (Pipeline.BeginLoggingScope(nameof(DirectoryClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(DirectoryClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(marker)}: {marker}\n" +
                    $"{nameof(maxResults)}: {maxResults}\n" +
                    $"{nameof(recursive)}: {recursive}");
                try
                {
                    return await FileRestClient.Directory.ListHandlesAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        marker: marker,
                        maxresults: maxResults,
                        recursive: recursive,
                        async: async,
                        operationName: Constants.File.Directory.GetHandlesOperationName,
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
                    Pipeline.LogMethodExit(nameof(DirectoryClient));
                }
            }
        }
        #endregion GetHandles

        #region ForceCloseHandles
        /// <summary>
        /// The <see cref="ForceCloseHandles"/> operation closes a handle or handles opened on a directory
        /// or a file at the service. It supports closing a single handle specified by <paramref name="handleId"/> on a file or
        /// directory or closing all handles opened on that resource. It optionally supports recursively closing
        /// handles on subresources when the resource is a directory.
        ///
        /// This API is intended to be used alongside <see cref="GetHandles"/> to force close handles that
        /// block operations, such as renaming a directory. These handles may have leaked or been lost track of by
        /// SMB clients. The API has client-side impact on the handle being closed, including user visible
        /// errors due to failed attempts to read or write files. This API is not intended for use as a replacement
        /// or alternative for SMB close.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/force-close-handles"/>.
        /// </summary>
        /// <param name="handleId">
        /// Optional. Specifies the handle ID to be closed. If not specified, or if equal to &quot;*&quot;, will close all handles.
        /// </param>
        /// <param name="marker">
        /// An optional string value that identifies the segment of the handles
        /// to be closed with the next call to <see cref="ForceCloseHandles"/>.  The
        /// operation returns a non-empty <see cref="StorageClosedHandlesSegment.Marker"/>
        /// if the operation did not return all items remaining to be
        /// closed with the current segment.  The NextMarker value can
        /// be used as the value for the <paramref name="marker"/> parameter
        /// in a subsequent call to request the closure of the next segment of handles.
        /// </param>
        /// <param name="recursive">
        /// Optional. A boolean value that specifies if the operation should also apply to the files and subdirectories of the directory specified.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageClosedHandlesSegment}"/> describing a
        /// segment of the handles closed.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<StorageClosedHandlesSegment> ForceCloseHandles(
            string handleId = Constants.CloseAllHandles,
            string marker = default,
            bool? recursive = default,
            CancellationToken cancellationToken = default) =>
            ForceCloseHandlesInternal(
                handleId,
                marker,
                recursive,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="ForceCloseHandlesAsync"/> operation closes a handle or handles opened on a directory
        /// or a file at the service. It supports closing a single handle specified by <paramref name="handleId"/> on a file or
        /// directory or closing all handles opened on that resource. It optionally supports recursively closing
        /// handles on subresources when the resource is a directory.
        ///
        /// This API is intended to be used alongside <see cref="GetHandlesAsync"/> to force close handles that
        /// block operations, such as renaming a directory. These handles may have leaked or been lost track of by
        /// SMB clients. The API has client-side impact on the handle being closed, including user visible
        /// errors due to failed attempts to read or write files. This API is not intended for use as a replacement
        /// or alternative for SMB close.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/force-close-handles"/>.
        /// </summary>
        /// <param name="handleId">
        /// Optional. Specifies the handle ID to be closed. If not specified, or if equal to &quot;*&quot;, will close all handles.
        /// </param>
        /// <param name="marker">
        /// An optional string value that identifies the segment of the handles
        /// to be closed with the next call to <see cref="ForceCloseHandlesAsync"/>.  The
        /// operation returns a non-empty <see cref="StorageClosedHandlesSegment.Marker"/>
        /// if the operation did not return all items remaining to be
        /// closed with the current segment.  The NextMarker value can
        /// be used as the value for the <paramref name="marker"/> parameter
        /// in a subsequent call to request the closure of the next segment of handles.
        /// </param>
        /// <param name="recursive">
        /// Optional. A boolean value that specifies if the operation should also apply to the files and subdirectories of the directory specified.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageClosedHandlesSegment}"/> describing a
        /// segment of the handles closed.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<StorageClosedHandlesSegment>> ForceCloseHandlesAsync(
            string handleId = Constants.CloseAllHandles,
            string marker = default,
            bool? recursive = default,
            CancellationToken cancellationToken = default) =>
            await ForceCloseHandlesInternal(
                handleId,
                marker,
                recursive,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="ForceCloseHandlesAsync"/> operation closes a handle or handles opened on a directory
        /// or a file at the service. It supports closing a single handle specified by <paramref name="handleId"/> on a file or
        /// directory or closing all handles opened on that resource. It optionally supports recursively closing
        /// handles on subresources when the resource is a directory.
        ///
        /// This API is intended to be used alongside <see cref="GetHandlesAsync"/> to force close handles that
        /// block operations, such as renaming a directory. These handles may have leaked or been lost track of by
        /// SMB clients. The API has client-side impact on the handle being closed, including user visible
        /// errors due to failed attempts to read or write files. This API is not intended for use as a replacement
        /// or alternative for SMB close.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/force-close-handles"/>.
        /// </summary>
        /// <param name="handleId">
        /// Optional. Specifies the handle ID to be closed. If not specified, or if equal to &quot;*&quot;, will close all handles.
        /// </param>
        /// <param name="marker">
        /// An optional string value that identifies the segment of the handles
        /// to be closed with the next call to <see cref="ForceCloseHandlesAsync"/>.  The
        /// operation returns a non-empty <see cref="StorageClosedHandlesSegment.Marker"/>
        /// if the operation did not return all items remaining to be
        /// closed with the current segment.  The NextMarker value can
        /// be used as the value for the <paramref name="marker"/> parameter
        /// in a subsequent call to request the closure of the next segment of handles.
        /// </param>
        /// <param name="recursive">
        /// Optional. A boolean value that specifies if the operation should also apply to the files and subdirectories of the directory specified.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageClosedHandlesSegment}"/> describing a
        /// segment of the handles closed.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<StorageClosedHandlesSegment>> ForceCloseHandlesInternal(
            string handleId,
            string marker,
            bool? recursive,
            bool async,
            CancellationToken cancellationToken)
        {
            // TODO Support share snapshot

            using (Pipeline.BeginLoggingScope(nameof(DirectoryClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(DirectoryClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(handleId)}: {handleId}\n" +
                    $"{nameof(marker)}: {marker}\n" +
                    $"{nameof(recursive)}: {recursive}");
                try
                {
                    return await FileRestClient.Directory.ForceCloseHandlesAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        marker: marker,
                        handleId: handleId,
                        recursive: recursive,
                        async: async,
                        operationName: Constants.File.Directory.ForceCloseHandlesOperationName,
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
                    Pipeline.LogMethodExit(nameof(DirectoryClient));
                }
            }
        }
        #endregion ForceCloseHandles

        #region CreateSubdirectory
        /// <summary>
        /// The <see cref="CreateSubdirectory"/> operation creates a new
        /// subdirectory under this directory.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/create-directory"/>.
        /// </summary>
        /// <param name="subdirectoryName">The name of the subdirectory.</param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this directory.
        /// </param>
        /// <param name="smbProperties">
        /// Optional SMB properties to set for the subdirectory.
        /// </param>
        /// <param name="filePermission">
        /// Optional file permission to set for the subdirectory.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{DirectoryClient}"/> referencing the
        /// newly created directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<DirectoryClient> CreateSubdirectory(
            string subdirectoryName,
            Metadata metadata = default,
            FileSmbProperties? smbProperties = default,
            string filePermission = default,
            CancellationToken cancellationToken = default)
        {
            DirectoryClient subdir = GetSubdirectoryClient(subdirectoryName);
            Response<StorageDirectoryInfo> response = subdir.Create(
                metadata,
                smbProperties,
                filePermission,
                cancellationToken);
            return Response.FromValue(subdir, response.GetRawResponse());
        }

        /// <summary>
        /// The <see cref="CreateSubdirectoryAsync"/> operation creates a new
        /// subdirectory under this directory.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/create-directory"/>.
        /// </summary>
        /// <param name="subdirectoryName">The name of the subdirectory.</param>
        /// <param name="metadata">
        /// Optional custom metadata to set for the subdirectory.
        /// </param>
        /// <param name="smbProperties">
        /// Optional SMB properties to set for the subdirectory.
        /// </param>
        /// <param name="filePermission">
        /// Optional file permission to set for the subdirectory.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{DirectoryClient}"/> referencing the
        /// newly created directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<DirectoryClient>> CreateSubdirectoryAsync(
            string subdirectoryName,
            Metadata metadata = default,
            FileSmbProperties? smbProperties = default,
            string filePermission = default,
            CancellationToken cancellationToken = default)
        {
            DirectoryClient subdir = GetSubdirectoryClient(subdirectoryName);
            Response<StorageDirectoryInfo> response = await subdir.CreateAsync(
                    metadata,
                    smbProperties,
                    filePermission,
                    cancellationToken)
                .ConfigureAwait(false);
            return Response.FromValue(subdir, response.GetRawResponse());
        }
        #endregion CreateSubdirectory

        #region DeleteSubdirectory
        /// <summary>
        /// The <see cref="DeleteSubdirectory"/> operation removes the
        /// specified empty subdirectory.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-directory"/>.
        /// </summary>
        /// <param name="subdirectoryName">The name of the subdirectory.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> if successful.
        /// </returns>
        /// <remarks>
        /// Note that the directory must be empty before it can be deleted.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response DeleteSubdirectory(
            string subdirectoryName,
            CancellationToken cancellationToken = default) =>
            GetSubdirectoryClient(subdirectoryName).Delete(cancellationToken);

        /// <summary>
        /// The <see cref="DeleteSubdirectoryAsync"/> operation removes the
        /// specified empty subdirectory.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-directory"/>.
        /// </summary>
        /// <param name="subdirectoryName">The name of the subdirectory.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> if successful.
        /// </returns>
        /// <remarks>
        /// Note that the directory must be empty before it can be deleted.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteSubdirectoryAsync(
            string subdirectoryName,
            CancellationToken cancellationToken = default) =>
            await GetSubdirectoryClient(subdirectoryName)
                .DeleteAsync(cancellationToken)
                .ConfigureAwait(false);
        #endregion DeleteSubdirectory

        #region CreateFile
        /// <summary>
        /// Creates a new file or replaces an existing file.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-file"/>.
        /// </summary>
        /// <remarks>
        /// This method only initializes the file.
        /// To add content, use <see cref="FileClient.UploadRangeAsync"/>.
        /// </remarks>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="maxSize">
        /// Required. Specifies the maximum size for the file.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the file.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for the file.
        /// </param>
        /// <param name="smbProperties">
        /// Optional SMB properties to set for the file.
        /// </param>
        /// <param name="filePermission">
        /// Optional file permission to set for the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileClient}"/> referencing the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<FileClient> CreateFile(
            string fileName,
            long maxSize,
            FileHttpHeaders? httpHeaders = default,
            Metadata metadata = default,
            FileSmbProperties? smbProperties = default,
            string filePermission = default,
            CancellationToken cancellationToken = default)
        {
            FileClient file = GetFileClient(fileName);
            Response<StorageFileInfo> response = file.Create(
                maxSize,
                httpHeaders,
                metadata,
                smbProperties,
                filePermission,
                cancellationToken);
            return Response.FromValue(file, response.GetRawResponse());
        }

        /// <summary>
        /// Creates a new file or replaces an existing file.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-file"/>.
        /// </summary>
        /// <remarks>
        /// This method only initializes the file.
        /// To add content, use <see cref="FileClient.UploadRangeAsync"/>.
        /// </remarks>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="maxSize">
        /// Required. Specifies the maximum size for the file.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the file.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for the file.
        /// </param>
        /// <param name="smbProperties">
        /// Optional SMB properties to set for the file.
        /// </param>
        /// <param name="filePermission">
        /// Optional file permission to set for the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileClient}"/> referencing the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<FileClient>> CreateFileAsync(
            string fileName,
            long maxSize,
            FileHttpHeaders? httpHeaders = default,
            Metadata metadata = default,
            FileSmbProperties? smbProperties = default,
            string filePermission = default,
            CancellationToken cancellationToken = default)
        {
            FileClient file = GetFileClient(fileName);
            Response<StorageFileInfo> response = await file.CreateAsync(
                maxSize,
                httpHeaders,
                metadata,
                smbProperties,
                filePermission,
                cancellationToken).ConfigureAwait(false);
            return Response.FromValue(file, response.GetRawResponse());
        }
        #endregion CreateFile

        #region DeleteFile
        /// <summary>
        /// The <see cref="DeleteFile"/> operation immediately removes
        /// the file from the storage account.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/delete-file2"/>.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully deleting.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response DeleteFile(
            string fileName,
            CancellationToken cancellationToken = default) =>
            GetFileClient(fileName).Delete(cancellationToken);

        /// <summary>
        /// The <see cref="DeleteFileAsync"/> operation immediately removes
        /// the file from the storage account.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/delete-file2"/>.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully deleting.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteFileAsync(
            string fileName,
            CancellationToken cancellationToken = default) =>
            await GetFileClient(fileName)
                .DeleteAsync(cancellationToken)
                .ConfigureAwait(false);
        #endregion DeleteFile
    }
}
