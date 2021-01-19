// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Shared;
using Azure.Storage.Sas;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.Shares
{
    /// <summary>
    /// The <see cref="ShareFileClient"/> allows you to manipulate Azure Storage files.
    /// </summary>
    public class ShareFileClient
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
        /// The version of the service to use when sending requests.
        /// </summary>
        private readonly ShareClientOptions.ServiceVersion _version;

        /// <summary>
        /// The version of the service to use when sending requests.
        /// </summary>
        internal virtual ShareClientOptions.ServiceVersion Version => _version;

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
        /// The Storage account name corresponding to the file client.
        /// </summary>
        private string _accountName;

        /// <summary>
        /// Gets the Storage account name corresponding to the file client.
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
        /// The share name corresponding to the file client.
        /// </summary>
        private string _shareName;

        /// <summary>
        /// Gets the share name corresponding to the file client.
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
        /// The name of the file.
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets the name of the file.
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
        /// The path of the file.
        /// </summary>
        private string _path;

        /// <summary>
        /// Gets the path of the file.
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
        /// The <see cref="StorageSharedKeyCredential"/> used to authenticate and generate SAS
        /// </summary>
        internal readonly StorageSharedKeyCredential _storageSharedKeyCredential;

        /// <summary>
        /// Gets the The <see cref="StorageSharedKeyCredential"/> used to authenticate and generate SAS.
        /// </summary>
        internal virtual StorageSharedKeyCredential SharedKeyCredential => _storageSharedKeyCredential;

        /// <summary>
        /// Determines whether the client is able to generate a SAS.
        /// If the client is authenticated with a <see cref="StorageSharedKeyCredential"/>.
        /// </summary>
        public bool CanGenerateSasUri => SharedKeyCredential != null;

        //const string fileType = "file";

        //// FileMaxUploadRangeBytes indicates the maximum number of bytes that can be sent in a call to UploadRange.
        //public const Int64 FileMaxUploadRangeBytes = 4 * Constants.MB; // 4MB

        //// FileMaxSizeInBytes indicates the maxiumum file size, in bytes.
        //public const Int64 FileMaxSizeInBytes = 1 * Constants.TB; // 1TB

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="ShareFileClient"/>
        /// class for mocking.
        /// </summary>
        protected ShareFileClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareFileClient"/> class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">
        /// Configure Azure Storage connection strings</see>
        /// </param>
        /// <param name="shareName">
        /// The name of the share in the storage account to reference.
        /// </param>
        /// <param name="filePath">
        /// The path of the file in the storage account to reference.
        /// </param>
        public ShareFileClient(string connectionString, string shareName, string filePath)
            : this(connectionString, shareName, filePath, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareFileClient"/> class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">
        /// Configure Azure Storage connection strings</see>
        /// </param>
        /// <param name="shareName">
        /// The name of the share in the storage account to reference.
        /// </param>
        /// <param name="filePath">
        /// The path of the file in the storage account to reference.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="ShareClientOptions"/> that define the transport
        /// pipeline policies for authentication, retries, etc., that are
        /// applied to every request.
        /// </param>
        public ShareFileClient(string connectionString, string shareName, string filePath, ShareClientOptions options)
        {
            options ??= new ShareClientOptions();
            var conn = StorageConnectionString.Parse(connectionString);
            var builder =
                new ShareUriBuilder(conn.FileEndpoint)
                {
                    ShareName = shareName,
                    DirectoryOrFilePath = filePath
                };
            _uri = builder.ToUri();
            _pipeline = options.Build(conn.Credentials);
            _version = options.Version;
            _clientDiagnostics = new ClientDiagnostics(options);
            _storageSharedKeyCredential = conn.Credentials as StorageSharedKeyCredential;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareFileClient"/> class.
        /// </summary>
        /// <param name="fileUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the share, and the path of the
        /// file.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="ShareClientOptions"/> that define the transport
        /// pipeline policies for authentication, retries, etc., that are
        /// applied to every request.
        /// </param>
        public ShareFileClient(Uri fileUri, ShareClientOptions options = default)
            : this(fileUri, (HttpPipelinePolicy)null, options, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareFileClient"/> class.
        /// </summary>
        /// <param name="fileUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the share, and the path of the
        /// file.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="ShareClientOptions"/> that define the transport
        /// pipeline policies for authentication, retries, etc., that are
        /// applied to every request.
        /// </param>
        public ShareFileClient(Uri fileUri, StorageSharedKeyCredential credential, ShareClientOptions options = default)
            : this(fileUri, credential.AsPolicy(), options, credential)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareFileClient"/> class.
        /// </summary>
        /// <param name="fileUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the share, and the path of the
        /// file.
        /// Must not contain shared access signature, which should be passed in the second parameter.
        /// </param>
        /// <param name="credential">
        /// The shared access signature credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="ShareClientOptions"/> that define the transport
        /// pipeline policies for authentication, retries, etc., that are
        /// applied to every request.
        /// </param>
        /// <remarks>
        /// This constructor should only be used when shared access signature needs to be updated during lifespan of this client.
        /// </remarks>
        public ShareFileClient(Uri fileUri, AzureSasCredential credential, ShareClientOptions options = default)
            : this(fileUri, credential.AsPolicy<ShareUriBuilder>(fileUri), options, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareFileClient"/>
        /// class.
        /// </summary>
        /// <param name="fileUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the share, and the path of the
        /// file.
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
        internal ShareFileClient(
            Uri fileUri,
            HttpPipelinePolicy authentication,
            ShareClientOptions options,
            StorageSharedKeyCredential storageSharedKeyCredential)
        {
            Argument.AssertNotNull(fileUri, nameof(fileUri));
            options ??= new ShareClientOptions();
            _uri = fileUri;
            _pipeline = options.Build(authentication);
            _version = options.Version;
            _clientDiagnostics = new ClientDiagnostics(options);
            _storageSharedKeyCredential = storageSharedKeyCredential;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareFileClient"/> class.
        /// </summary>
        /// <param name="fileUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the share, and the path of the file.
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
        internal ShareFileClient(
            Uri fileUri,
            HttpPipeline pipeline,
            StorageSharedKeyCredential storageSharedKeyCredential,
            ShareClientOptions.ServiceVersion version,
            ClientDiagnostics clientDiagnostics)
        {
            _uri = fileUri;
            _pipeline = pipeline;
            _storageSharedKeyCredential = storageSharedKeyCredential;
            _version = version;
            _clientDiagnostics = clientDiagnostics;
        }
        #endregion ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareFileClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="shareSnapshot"/> timestamp.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/snapshot-share">
        /// Snapshot Share</see>.
        /// </summary>
        /// <remarks>
        /// Pass null or empty string to remove the snapshot returning a URL to the base file.
        /// </remarks>
        /// <param name="shareSnapshot">
        /// The snapshot identifier.
        /// </param>
        /// <returns>
        /// A new <see cref="ShareFileClient"/> instance.
        /// </returns>
        public virtual ShareFileClient WithSnapshot(string shareSnapshot)
        {
            var builder = new ShareUriBuilder(Uri) { Snapshot = shareSnapshot };
            return new ShareFileClient(builder.ToUri(), Pipeline, SharedKeyCredential, Version, ClientDiagnostics);
        }

        /// <summary>
        /// Sets the various name fields if they are currently null.
        /// </summary>
        private void SetNameFieldsIfNull()
        {
            if (_name == null || _shareName == null || _accountName == null || _path == null)
            {
                var builder = new ShareUriBuilder(Uri);
                _name = builder.LastDirectoryOrFileName;
                _shareName = builder.ShareName;
                _accountName = builder.AccountName;
                _path = builder.DirectoryOrFilePath;
            }
        }

        #region Create
        /// <summary>
        /// Creates a new file or replaces an existing file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-file">
        /// Create File</see>.
        /// </summary>
        /// <remarks>
        /// This method only initializes the file.
        /// To add content, use <see cref="UploadRangeAsync(HttpRange, Stream, byte[], IProgress{long}, ShareFileRequestConditions, CancellationToken)"/>.
        /// </remarks>
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
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareFileInfo> Create(
            long maxSize,
            ShareFileHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            FileSmbProperties smbProperties = default,
            string filePermission = default,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            CreateInternal(
                maxSize,
                httpHeaders,
                metadata,
                smbProperties,
                filePermission,
                conditions,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Creates a new file or replaces an existing file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-file">
        /// Create File</see>.
        /// </summary>
        /// <remarks>
        /// This method only initializes the file.
        /// To add content, use <see cref="UploadRangeAsync(HttpRange, Stream, byte[], IProgress{long}, ShareFileRequestConditions, CancellationToken)"/>.
        /// </remarks>
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
        /// A <see cref="Response{StorageFileInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ShareFileInfo> Create(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            long maxSize,
            ShareFileHttpHeaders httpHeaders,
            Metadata metadata,
            FileSmbProperties smbProperties,
            string filePermission,
            CancellationToken cancellationToken) =>
            CreateInternal(
                maxSize,
                httpHeaders,
                metadata,
                smbProperties,
                filePermission,
                conditions: default,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Creates a new file or replaces an existing file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-file">
        /// Create File</see>.
        /// </summary>
        /// <remarks>
        /// This method only initializes the file.
        /// To add content, use <see cref="UploadRangeAsync(HttpRange, Stream, byte[], IProgress{long}, ShareFileRequestConditions, CancellationToken)"/>.
        /// </remarks>
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
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareFileInfo>> CreateAsync(
            long maxSize,
            ShareFileHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            FileSmbProperties smbProperties = default,
            string filePermission = default,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await CreateInternal(
                maxSize,
                httpHeaders,
                metadata,
                smbProperties,
                filePermission,
                conditions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Creates a new file or replaces an existing file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-file">
        /// Create File</see>.
        /// </summary>
        /// <remarks>
        /// This method only initializes the file.
        /// To add content, use <see cref="UploadRangeAsync(HttpRange, Stream, byte[], IProgress{long}, ShareFileRequestConditions, CancellationToken)"/>.
        /// </remarks>
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
        /// A <see cref="Response{StorageFileInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ShareFileInfo>> CreateAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            long maxSize,
            ShareFileHttpHeaders httpHeaders,
            Metadata metadata,
            FileSmbProperties smbProperties,
            string filePermission,
            CancellationToken cancellationToken) =>
            await CreateInternal(
                maxSize,
                httpHeaders,
                metadata,
                smbProperties,
                filePermission,
                conditions: default,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Creates a new file or replaces an existing file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-file">
        /// Create File</see>.
        /// </summary>
        /// <remarks>
        /// This method only initializes the file.
        /// To add content, use <see cref="UploadRangeAsync(HttpRange, Stream, byte[], IProgress{long}, ShareFileRequestConditions, CancellationToken)"/>.
        /// </remarks>
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
        /// Optional file permission to set on the file.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
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
        /// A <see cref="Response{StorageFileInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareFileInfo>> CreateInternal(
            long maxSize,
            ShareFileHttpHeaders httpHeaders,
            Metadata metadata,
            FileSmbProperties smbProperties,
            string filePermission,
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken,
            string operationName = default)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(maxSize)}: {maxSize}\n" +
                    $"{nameof(httpHeaders)}: {httpHeaders}");
                try
                {
                    FileSmbProperties smbProps = smbProperties ?? new FileSmbProperties();

                    ShareExtensions.AssertValidFilePermissionAndKey(filePermission, smbProps.FilePermissionKey);

                    if (filePermission == null && smbProps.FilePermissionKey == null)
                    {
                        filePermission = Constants.File.FilePermissionInherit;
                    }

                    Response<RawStorageFileInfo> response = await FileRestClient.File.CreateAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        fileContentLength: maxSize,
                        fileContentType: httpHeaders?.ContentType,
                        fileContentEncoding: httpHeaders?.ContentEncoding,
                        fileContentLanguage: httpHeaders?.ContentLanguage,
                        fileCacheControl: httpHeaders?.CacheControl,
                        fileContentHash: httpHeaders?.ContentHash,
                        fileContentDisposition: httpHeaders?.ContentDisposition,
                        metadata: metadata,
                        fileAttributes: smbProps.FileAttributes?.ToAttributesString() ?? Constants.File.FileAttributesNone,
                        filePermission: filePermission,
                        fileCreationTime: smbProps.FileCreatedOn.ToFileDateTimeString() ?? Constants.File.FileTimeNow,
                        fileLastWriteTime: smbProps.FileLastWrittenOn.ToFileDateTimeString() ?? Constants.File.FileTimeNow,
                        filePermissionKey: smbProps.FilePermissionKey,
                        leaseId: conditions?.LeaseId,
                        async: async,
                        cancellationToken: cancellationToken,
                        operationName: operationName ?? $"{nameof(ShareFileClient)}.{nameof(Create)}")
                        .ConfigureAwait(false);

                    return Response.FromValue(new ShareFileInfo(response.Value), response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(ShareFileClient));
                }
            }
        }
        #endregion Create

        #region Exists
        /// <summary>
        /// The <see cref="Exists"/> operation can be called on a
        /// <see cref="ShareFileClient"/> to see if the associated file
        /// exists in the share on the storage account.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns true if the file exists.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<bool> Exists(
            CancellationToken cancellationToken = default) =>
            ExistsInternal(
                async: false,
                cancellationToken: cancellationToken).EnsureCompleted();

        /// <summary>
        /// The <see cref="Exists"/> operation can be called on a
        /// <see cref="ShareFileClient"/> to see if the associated file
        /// exists in the share on the storage account.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns true if the file exists.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<bool>> ExistsAsync(
            CancellationToken cancellationToken = default) =>
            await ExistsInternal(
                async: true,
                cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="ExistsInternal"/> operation can be called on a
        /// <see cref="ShareFileClient"/> to see if the associated file
        /// exists in the share on the storage account.
        /// </summary>
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
        /// Returns true if the file exists.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<bool>> ExistsInternal(
            bool async,
            CancellationToken cancellationToken,
            string operationName = default)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");

                try
                {
                    Response<ShareFileProperties> response = await GetPropertiesInternal(
                        conditions: default,
                        async: async,
                        cancellationToken: cancellationToken,
                        operationName: operationName ?? $"{nameof(ShareFileClient)}.{nameof(Exists)}")
                        .ConfigureAwait(false);

                    return Response.FromValue(true, response.GetRawResponse());
                }
                catch (RequestFailedException storageRequestFailedException)
                when (storageRequestFailedException.ErrorCode == ShareErrorCode.ResourceNotFound
                    || storageRequestFailedException.ErrorCode == ShareErrorCode.ShareNotFound
                    || storageRequestFailedException.ErrorCode == ShareErrorCode.ParentNotFound)
                {
                    return Response.FromValue(false, default);
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(ShareFileClient));
                }
            }
        }
        #endregion Exists

        #region DeleteIfExists
        /// <summary>
        /// The <see cref="DeleteIfExists"/> operation immediately removes the file from the storage account,
        /// if it exists.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-file2">
        /// Delete File</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// True if the file existed.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<bool> DeleteIfExists(
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            DeleteIfExistsInternal(
                conditions,
                async: false,
                cancellationToken: cancellationToken)
            .EnsureCompleted();

        /// <summary>
        /// The <see cref="DeleteIfExists"/> operation immediately removes the file from the storage account,
        /// if it exists.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-file2">
        /// Delete File</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// True if the file existed.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<bool>> DeleteIfExistsAsync(
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await DeleteIfExistsInternal(
                conditions,
                async: true,
                cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DeleteIfExistsInternal"/> operation immediately removes the file from the storage account,
        /// if it exists.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-file2">
        /// Delete File</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// True if the file existed.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<bool>> DeleteIfExistsInternal(
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");
                try
                {
                    Response response = await DeleteInternal(
                        conditions,
                        async,
                        cancellationToken,
                        operationName: $"{nameof(ShareFileClient)}.{nameof(DeleteIfExists)}")
                        .ConfigureAwait(false);
                    return Response.FromValue(true, response);
                }
                catch (RequestFailedException storageRequestFailedException)
                when (storageRequestFailedException.ErrorCode == ShareErrorCode.ResourceNotFound
                    || storageRequestFailedException.ErrorCode == ShareErrorCode.ShareNotFound
                    || storageRequestFailedException.ErrorCode == ShareErrorCode.ParentNotFound)
                {
                    return Response.FromValue(false, default);
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(ShareFileClient));
                }
            }
        }
        #endregion DeleteIfExists

        #region StartCopy
        /// <summary>
        /// Copies a blob or file to a destination file within the storage account.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/copy-file">
        /// Copy File</see>.
        /// </summary>
        /// <param name="sourceUri">
        /// Required. Specifies the URL of the source file or blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for the file.
        /// </param>
        /// <param name="smbProperties">
        /// Optional SMB paramters to set on the target file.
        /// </param>
        /// <param name="filePermission">
        /// Optional file permission to set for the file.
        /// </param>
        /// <param name="filePermissionCopyMode">
        /// Specifies the option to copy file security descriptor from source file or
        /// to set it using the value which is defined by the header value of FilePermission
        /// or FilePermissionKey.
        /// </param>
        /// <param name="ignoreReadOnly">
        /// Optional boolean specifying to overwrite the target file if it already
        /// exists and has read-only attribute set.
        /// </param>
        /// <param name="setArchiveAttribute">
        /// Optional boolean Specifying to set archive attribute on a target file. True
        /// means archive attribute will be set on a target file despite attribute
        /// overrides or a source file state.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileInfo}"/> describing the
        /// state of the file copy.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareFileCopyInfo> StartCopy(
            Uri sourceUri,
            Metadata metadata = default,
            FileSmbProperties smbProperties = default,
            string filePermission = default,
            PermissionCopyMode? filePermissionCopyMode = default,
            bool? ignoreReadOnly = default,
            bool? setArchiveAttribute = default,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            StartCopyInternal(
                sourceUri,
                metadata,
                smbProperties,
                filePermission,
                filePermissionCopyMode,
                ignoreReadOnly,
                setArchiveAttribute,
                conditions,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Copies a blob or file to a destination file within the storage account.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/copy-file">
        /// Copy File</see>.
        /// </summary>
        /// <param name="sourceUri">
        /// Required. Specifies the URL of the source file or blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileInfo}"/> describing the
        /// state of the file copy.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ShareFileCopyInfo> StartCopy(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Uri sourceUri,
            Metadata metadata,
            CancellationToken cancellationToken) =>
            StartCopyInternal(
                sourceUri,
                metadata,
                smbProperties: default,
                filePermission: default,
                filePermissionCopyMode: default,
                ignoreReadOnly: default,
                setArchiveAttribute: default,
                conditions: default,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Copies a blob or file to a destination file within the storage account.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/copy-file">
        /// Copy File</see>.
        /// </summary>
        /// <param name="sourceUri">
        /// Required. Specifies the URL of the source file or blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for the file.
        /// </param>
        /// <param name="smbProperties">
        /// Optional SMB properties to set on the target file.
        /// </param>
        /// <param name="filePermission">
        /// Optional file permission to set for the file.
        /// </param>
        /// <param name="filePermissionCopyMode">
        /// Specifies the option to copy file security descriptor from source file or
        /// to set it using the value which is defined by the header value of FilePermission
        /// or FilePermissionKey.
        /// </param>
        /// <param name="ignoreReadOnly">
        /// Optional boolean specifying to overwrite the target file if it already
        /// exists and has read-only attribute set.
        /// </param>
        /// <param name="setArchiveAttribute">
        /// Optional boolean Specifying to set archive attribute on a target file. True
        /// means archive attribute will be set on a target file despite attribute
        /// overrides or a source file state.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileInfo}"/> describing the
        /// state of the file copy.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareFileCopyInfo>> StartCopyAsync(
            Uri sourceUri,
            Metadata metadata = default,
            FileSmbProperties smbProperties = default,
            string filePermission = default,
            PermissionCopyMode? filePermissionCopyMode = default,
            bool? ignoreReadOnly = default,
            bool? setArchiveAttribute = default,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await StartCopyInternal(
                sourceUri,
                metadata,
                smbProperties,
                filePermission,
                filePermissionCopyMode,
                ignoreReadOnly,
                setArchiveAttribute,
                conditions,
                async: true,
                cancellationToken).
                ConfigureAwait(false);

        /// <summary>
        /// Copies a blob or file to a destination file within the storage account.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/copy-file">
        /// Copy File</see>.
        /// </summary>
        /// <param name="sourceUri">
        /// Required. Specifies the URL of the source file or blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileInfo}"/> describing the
        /// state of the file copy.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ShareFileCopyInfo>> StartCopyAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Uri sourceUri,
            Metadata metadata,
            CancellationToken cancellationToken) =>
            await StartCopyInternal(
                sourceUri,
                metadata,
                smbProperties: default,
                filePermission: default,
                filePermissionCopyMode: default,
                ignoreReadOnly: default,
                setArchiveAttribute: default,
                conditions: default,
                async: true,
                cancellationToken).
                ConfigureAwait(false);

        /// <summary>
        /// Copies a blob or file to a destination file within the storage account.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/copy-file">
        /// Copy File</see>.
        /// </summary>
        /// <param name="sourceUri">
        /// Required. Specifies the URL of the source file or blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for the file.
        /// </param>
        /// <param name="smbProperties">
        /// Optional SMB properties to set on the target file.
        /// </param>
        /// <param name="filePermission">
        /// Optional file permission to set for the file.
        /// </param>
        /// <param name="filePermissionCopyMode">
        /// Specifies the option to copy file security descriptor from source file or
        /// to set it using the value which is defined by the header value of FilePermission
        /// or FilePermissionKey.
        /// </param>
        /// <param name="ignoreReadOnly">
        /// Optional boolean specifying to overwrite the target file if it already
        /// exists and has read-only attribute set.
        /// </param>
        /// <param name="setArchiveAttribute">
        /// Optional boolean Specifying to set archive attribute on a target file. True
        /// means archive attribute will be set on a target file despite attribute
        /// overrides or a source file state.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
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
        /// state of the file copy.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareFileCopyInfo>> StartCopyInternal(
            Uri sourceUri,
            Metadata metadata,
            FileSmbProperties smbProperties,
            string filePermission,
            PermissionCopyMode? filePermissionCopyMode,
            bool? ignoreReadOnly,
            bool? setArchiveAttribute,
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(sourceUri)}: {sourceUri}");
                try
                {
                    return await FileRestClient.File.StartCopyAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        copySource: sourceUri,
                        metadata: metadata,
                        leaseId: conditions?.LeaseId,
                        filePermission: filePermission,
                        filePermissionKey: smbProperties?.FilePermissionKey,
                        filePermissionCopyMode: filePermissionCopyMode,
                        ignoreReadOnly: ignoreReadOnly,
                        fileAttributes: smbProperties?.FileAttributes?.ToAttributesString(),
                        fileCreationTime: smbProperties?.FileCreatedOn.ToFileDateTimeString(),
                        fileLastWriteTime: smbProperties?.FileLastWrittenOn.ToFileDateTimeString(),
                        setArchiveAttribute: setArchiveAttribute,
                        async: async,
                        cancellationToken: cancellationToken,
                        operationName: $"{nameof(ShareFileClient)}.{nameof(StartCopy)}")
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(ShareFileClient));
                }
            }
        }
        #endregion StartCopy

        // TODO The REST documentation say "full metadata", not "empty".  Doc bug?

        #region AbortCopy
        /// <summary>
        /// Attempts to cancel a pending copy that was previously started and leaves a destination file with zero length and full metadata.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/abort-copy-file">
        /// Abort Copy File</see>.
        /// </summary>
        /// <param name="copyId">
        /// String identifier for the copy operation.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
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
        public virtual Response AbortCopy(
            string copyId,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            AbortCopyInternal(
                copyId,
                conditions,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Attempts to cancel a pending copy that was previously started and leaves a destination file with zero length and full metadata.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/abort-copy-file">
        /// Abort Copy File</see>.
        /// </summary>
        /// <param name="copyId">
        /// String identifier for the copy operation.
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
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response AbortCopy(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            string copyId,
            CancellationToken cancellationToken) =>
            AbortCopyInternal(
                copyId,
                conditions: default,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Attempts to cancel a pending copy that was previously started and leaves a destination file with zero length and full metadata.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/abort-copy-file">
        /// Abort Copy File</see>.
        /// </summary>
        /// <param name="copyId">
        /// String identifier for the copy operation.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
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
        public virtual async Task<Response> AbortCopyAsync(
            string copyId,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await AbortCopyInternal(
                copyId,
                conditions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Attempts to cancel a pending copy that was previously started and leaves a destination file with zero length and full metadata.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/abort-copy-file">
        /// Abort Copy File</see>.
        /// </summary>
        /// <param name="copyId">
        /// String identifier for the copy operation.
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
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> AbortCopyAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            string copyId,
            CancellationToken cancellationToken) =>
            await AbortCopyInternal(
                copyId,
                conditions: default,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Attempts to cancel a pending copy that was previously started and leaves a destination file with zero length and full metadata.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/abort-copy-file">
        /// Abort Copy File</see>.
        /// </summary>
        /// <param name="copyId">
        /// String identifier for the copy operation.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
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
        private async Task<Response> AbortCopyInternal(
            string copyId,
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(copyId)}: {copyId}");
                try
                {
                    return await FileRestClient.File.AbortCopyAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        copyId: copyId,
                        leaseId: conditions?.LeaseId,
                        version: Version.ToVersionString(),
                        async: async,
                        cancellationToken: cancellationToken,
                        operationName: $"{nameof(ShareFileClient)}.{nameof(AbortCopy)}")
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(ShareFileClient));
                }
            }
        }
        #endregion AbortCopy

        #region Download
        /// <summary>
        /// The <see cref="Download(HttpRange, bool, ShareFileRequestConditions, CancellationToken)"/>
        /// operation reads or downloads a file from the system, including its metadata and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-file">
        /// Get File</see>.
        /// </summary>
        /// <param name="range">
        /// Optional. Only download the bytes of the file in the specified
        /// range.  If not provided, download the entire file.
        /// </param>
        /// <param name="rangeGetContentHash">
        /// When set to true and specified together with the <paramref name="range"/>,
        /// the service returns the MD5 hash for the range, as long as the
        /// range is less than or equal to 4 MB in size.  If this value is
        /// specified without <paramref name="range"/> or set to true when the
        /// range exceeds 4 MB in size, a <see cref="RequestFailedException"/>
        /// is thrown.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileDownloadInfo}"/> describing the
        /// downloaded file.  <see cref="ShareFileDownloadInfo.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareFileDownloadInfo> Download(
            HttpRange range = default,
            bool rangeGetContentHash = default,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            DownloadInternal(
                range,
                rangeGetContentHash,
                conditions,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="Download(HttpRange, bool, CancellationToken)"/> operation reads
        /// or downloads a file from the system, including its metadata and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-file">
        /// Get File</see>.
        /// </summary>
        /// <param name="range">
        /// Optional. Only download the bytes of the file in the specified
        /// range.  If not provided, download the entire file.
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
        /// A <see cref="Response{StorageFileDownloadInfo}"/> describing the
        /// downloaded file.  <see cref="ShareFileDownloadInfo.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ShareFileDownloadInfo> Download(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            HttpRange range,
            bool rangeGetContentHash,
            CancellationToken cancellationToken) =>
            DownloadInternal(
                range,
                rangeGetContentHash,
                conditions: default,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="DownloadAsync(HttpRange, bool, ShareFileRequestConditions, CancellationToken)"/>
        /// operation reads or downloads a file from the system, including its metadata and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-file">
        /// Get File</see>.
        /// </summary>
        /// <param name="range">
        /// Optional. Only download the bytes of the file in the specified
        /// range.  If not provided, download the entire file.
        /// </param>
        /// <param name="rangeGetContentHash">
        /// When set to true and specified together with the <paramref name="range"/>,
        /// the service returns the MD5 hash for the range, as long as the
        /// range is less than or equal to 4 MB in size.  If this value is
        /// specified without <paramref name="range"/> or set to true when the
        /// range exceeds 4 MB in size, a <see cref="RequestFailedException"/>
        /// is thrown.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileDownloadInfo}"/> describing the
        /// downloaded file.  <see cref="ShareFileDownloadInfo.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareFileDownloadInfo>> DownloadAsync(
            HttpRange range = default,
            bool rangeGetContentHash = default,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await DownloadInternal(
                range,
                rangeGetContentHash,
                conditions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DownloadAsync(HttpRange, bool, CancellationToken)"/> operation reads
        /// or downloads a file from the system, including its metadata and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-file">
        /// Get File</see>.
        /// </summary>
        /// <param name="range">
        /// Optional. Only download the bytes of the file in the specified
        /// range.  If not provided, download the entire file.
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
        /// A <see cref="Response{StorageFileDownloadInfo}"/> describing the
        /// downloaded file.  <see cref="ShareFileDownloadInfo.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ShareFileDownloadInfo>> DownloadAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            HttpRange range,
            bool rangeGetContentHash,
            CancellationToken cancellationToken) =>
            await DownloadInternal(
                range,
                rangeGetContentHash,
                conditions: default,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DownloadInternal"/> operation reads or downloads a file from the system, including its metadata and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-file">
        /// Get File</see>.
        /// </summary>
        /// <param name="range">
        /// Optional. Only download the bytes of the file in the specified
        /// range.  If not provided, download the entire file.
        /// </param>
        /// <param name="rangeGetContentHash">
        /// When set to true and specified together with the <paramref name="range"/>,
        /// the service returns the MD5 hash for the range, as long as the
        /// range is less than or equal to 4 MB in size.  If this value is
        /// specified without <paramref name="range"/> or set to true when the
        /// range exceeds 4 MB in size, a <see cref="RequestFailedException"/>
        /// is thrown.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileDownloadInfo}"/> describing the
        /// downloaded file.  <see cref="ShareFileDownloadInfo.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareFileDownloadInfo>> DownloadInternal(
            HttpRange range,
            bool rangeGetContentHash,
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(rangeGetContentHash)}: {rangeGetContentHash}");
                try
                {
                    // Start downloading the file
                    (Response<FlattenedStorageFileProperties> response, Stream stream) = await StartDownloadAsync(
                        range,
                        rangeGetContentHash,
                        conditions: conditions,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    // Wrap the response Content in a RetriableStream so we
                    // can return it before it's finished downloading, but still
                    // allow retrying if it fails.
                    response.Value.Content = RetriableStream.Create(
                        stream,
                        startOffset =>
                            StartDownloadAsync(
                                range,
                                rangeGetContentHash,
                                startOffset,
                                conditions,
                                async,
                                cancellationToken)
                                .EnsureCompleted()
                                .Item2,
                        async startOffset =>
                            (await StartDownloadAsync(
                                range,
                                rangeGetContentHash,
                                startOffset,
                                conditions,
                                async,
                                cancellationToken)
                                .ConfigureAwait(false))
                                .Item2,
                        Pipeline.ResponseClassifier,
                        Constants.MaxReliabilityRetries);

                    // Wrap the FlattenedStorageFileProperties into a StorageFileDownloadInfo
                    // to make the Content easier to find
                    return Response.FromValue(new ShareFileDownloadInfo(response.Value), response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(ShareFileClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="StartDownloadAsync"/> operation starts to read or downloads a file from the system, including its metadata and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-file">
        /// Get File</see>.
        /// </summary>
        /// <param name="range">
        /// Optional. Only download the bytes of the file in the specified
        /// range.  If not provided, download the entire file.
        /// </param>
        /// <param name="rangeGetContentHash">
        /// When set to true and specified together with the <paramref name="range"/>,
        /// the service returns the MD5 hash for the range, as long as the
        /// range is less than or equal to 4 MB in size.  If this value is
        /// specified without <paramref name="range"/> or set to true when the
        /// range exceeds 4 MB in size, a <see cref="RequestFailedException"/>
        /// is thrown.
        /// </param>
        /// <param name="startOffset">
        /// Optional. Starting offset to request - in the event of a retry.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FlattenedStorageFileProperties}"/> describing the
        /// downloaded file.  <see cref="FlattenedStorageFileProperties.Content"/> contains
        /// the file's data.
        /// </returns>
        private async Task<(Response<FlattenedStorageFileProperties>, Stream)> StartDownloadAsync(
            HttpRange range = default,
            bool rangeGetContentHash = default,
            long startOffset = 0,
            ShareFileRequestConditions conditions = default,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            var pageRange = new HttpRange(
                range.Offset + startOffset,
                range.Length.HasValue ?
                    range.Length.Value - startOffset :
                    (long?)null);
            Pipeline.LogTrace($"Download {Uri} with range: {pageRange}");
            (Response<FlattenedStorageFileProperties> response, Stream stream) =
                await FileRestClient.File.DownloadAsync(
                    ClientDiagnostics,
                    Pipeline,
                    Uri,
                    version: Version.ToVersionString(),
                    range: pageRange.ToString(),
                    rangeGetContentHash: rangeGetContentHash ? (bool?)true : null,
                    leaseId: conditions?.LeaseId,
                    async: async,
                    cancellationToken: cancellationToken,
                    operationName: $"{nameof(ShareFileClient)}.{nameof(Download)}")
                    .ConfigureAwait(false);
            Pipeline.LogTrace($"Response: {response.GetRawResponse().Status}, ContentLength: {response.Value.ContentLength}");
            return (response, stream);
        }
        #endregion Download

        #region OpenRead
        /// <summary>
        /// Opens a stream for reading from the file.  The stream will only download
        /// the file as the stream is read from.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns a stream that will download the file as the stream
        /// is read from.
        /// </returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Stream OpenRead(
#pragma warning restore AZC0015 // Unexpected client method return type.
            ShareFileOpenReadOptions options,
            CancellationToken cancellationToken = default)
            => OpenReadInteral(
                options?.Position ?? 0,
                options?.BufferSize,
                options?.Conditions,
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// Opens a stream for reading from the file.  The stream will only download
        /// the file as the stream is read from.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns a stream that will download the file as the stream
        /// is read from.
        /// </returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Stream> OpenReadAsync(
#pragma warning restore AZC0015 // Unexpected client method return type.
            ShareFileOpenReadOptions options,
            CancellationToken cancellationToken = default)
            => await OpenReadInteral(
                options?.Position ?? 0,
                options?.BufferSize,
                options?.Conditions,
                async: true,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Opens a stream for reading from the file.  The stream will only download
        /// the file as the stream is read from.
        /// </summary>
        /// <param name="position">
        /// The position within the file to begin the stream.
        /// Defaults to the beginning of the file.
        /// </param>
        /// <param name="bufferSize">
        /// The buffer size to use when the stream downloads parts
        /// of the file.  Defaults to 1 MB.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions on
        /// the download of this file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns a stream that will download the file as the stream
        /// is read from.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Stream OpenRead(
#pragma warning restore AZC0015 // Unexpected client method return type.
            long position = 0,
            int? bufferSize = default,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
            => OpenReadInteral(
                position,
                bufferSize,
                conditions,
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// Opens a stream for reading from the file.  The stream will only download
        /// the file as the stream is read from.
        /// </summary>
        /// <param name="allowfileModifications">
        /// If true, you can continue streaming a blob even if it has been modified.
        /// </param>
        /// <param name="position">
        /// The position within the file to begin the stream.
        /// Defaults to the beginning of the file.
        /// </param>
        /// <param name="bufferSize">
        /// The buffer size to use when the stream downloads parts
        /// of the file.  Defaults to 1 MB.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns a stream that will download the file as the stream
        /// is read from.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Stream OpenRead(
#pragma warning restore AZC0015 // Unexpected client method return type.
            bool allowfileModifications,
            long position = 0,
            int? bufferSize = default,
            CancellationToken cancellationToken = default)
                => OpenRead(
                    position,
                    bufferSize,
                    allowfileModifications ? new ShareFileRequestConditions() : null,
                    cancellationToken);

        /// <summary>
        /// Opens a stream for reading from the file.  The stream will only download
        /// the file as the stream is read from.
        /// </summary>
        /// <param name="position">
        /// The position within the file to begin the stream.
        /// Defaults to the beginning of the file.
        /// </param>
        /// <param name="bufferSize">
        /// The buffer size to use when the stream downloads parts
        /// of the file.  Defaults to 1 MB.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions on
        /// the download of the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns a stream that will download the file as the stream
        /// is read from.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Stream> OpenReadAsync(
#pragma warning restore AZC0015 // Unexpected client method return type.
            long position = 0,
            int? bufferSize = default,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
            => await OpenReadInteral(
                position,
                bufferSize,
                conditions,
                async: true,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Opens a stream for reading from the file.  The stream will only download
        /// the file as the stream is read from.
        /// </summary>
        /// <param name="allowfileModifications">
        /// If true, you can continue streaming a blob even if it has been modified.
        /// </param>
        /// <param name="position">
        /// The position within the file to begin the stream.
        /// Defaults to the beginning of the file.
        /// </param>
        /// <param name="bufferSize">
        /// The buffer size to use when the stream downloads parts
        /// of the file.  Defaults to 1 MB.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns a stream that will download the file as the stream
        /// is read from.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Stream> OpenReadAsync(
#pragma warning restore AZC0015 // Unexpected client method return type.
            bool allowfileModifications,
            long position = 0,
            int? bufferSize = default,
            CancellationToken cancellationToken = default)
                => await OpenReadAsync(
                    position,
                    bufferSize,
                    allowfileModifications ? new ShareFileRequestConditions() : null,
                    cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Opens a stream for reading from the file.  The stream will only download
        /// the file as the stream is read from.
        /// </summary>
        /// <param name="position">
        /// The position within the file to begin the stream.
        /// Defaults to the beginning of the file.
        /// </param>
        /// <param name="bufferSize">
        /// The buffer size to use when the stream downloads parts
        /// of the file.  Defaults to 1 MB.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions on
        /// the download of the file.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns a stream that will download the file as the stream
        /// is read from.
        /// </returns>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        internal async Task<Stream> OpenReadInteral(
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            long position,
            int? bufferSize,
            ShareFileRequestConditions conditions,
#pragma warning disable CA1801
            bool async,
            CancellationToken cancellationToken)
#pragma warning restore CA1801
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ShareFileClient)}.{nameof(OpenRead)}");
            try
            {
                scope.Start();

                // This also makes sure that we fail fast if file doesn't exist.
                ShareFileProperties properties = await GetPropertiesInternal(conditions: conditions, async, cancellationToken).ConfigureAwait(false);

                return new LazyLoadingReadOnlyStream<ShareFileRequestConditions, ShareFileProperties>(
                    async (HttpRange range,
                    ShareFileRequestConditions conditions,
                    bool rangeGetContentHash,
                    bool async,
                    CancellationToken cancellationToken) =>
                    {
                        Response<ShareFileDownloadInfo> response = await DownloadInternal(
                            range,
                            rangeGetContentHash,
                            conditions,
                            async,
                            cancellationToken).ConfigureAwait(false);

                        return Response.FromValue(
                            (IDownloadedContent)response.Value,
                            response.GetRawResponse());
                    },
                    (ETag? eTag) => new ShareFileRequestConditions { },
                    async (bool async, CancellationToken cancellationToken)
                        => await GetPropertiesInternal(conditions: default, async, cancellationToken).ConfigureAwait(false),
                    properties.ContentLength,
                    position,
                    bufferSize,
                    conditions);
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
        #endregion OpenRead

        #region Delete
        /// <summary>
        /// The <see cref="Delete(ShareFileRequestConditions, CancellationToken)"/>
        /// operation immediately removes the file from the storage account.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-file2">
        /// Delete File</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
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
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            DeleteInternal(
                conditions,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="Delete(CancellationToken)"/> operation immediately
        /// removes the file from the storage account.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-file2">
        /// Delete File</see>.
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
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response Delete(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            CancellationToken cancellationToken) =>
            DeleteInternal(
                conditions: default,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="DeleteAsync(ShareFileRequestConditions, CancellationToken)"/> operation
        /// immediately removes the file from the storage account.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-file2">
        /// Delete File</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
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
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await DeleteInternal(
                conditions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DeleteAsync(CancellationToken)"/> operation
        /// immediately removes the file from the storage account.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-file2">
        /// Delete File</see>.
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
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> DeleteAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            CancellationToken cancellationToken) =>
            await DeleteInternal(
                conditions: default,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DeleteInternal"/> operation immediately removes the file from the storage account.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-file2">
        /// Delete File</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
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
        /// A <see cref="Response"/> on successfully deleting.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response> DeleteInternal(
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken,
            string operationName = default)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    return await FileRestClient.File.DeleteAsync(
                        clientDiagnostics: ClientDiagnostics,
                        pipeline: Pipeline,
                        resourceUri: Uri,
                        leaseId: conditions?.LeaseId,
                        version: Version.ToVersionString(),
                        async: async,
                        cancellationToken: cancellationToken,
                        operationName: operationName ?? $"{nameof(ShareFileClient)}.{nameof(Delete)}")
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(ShareFileClient));
                }
            }
        }
        #endregion Delete

        #region GetProperties
        /// <summary>
        /// The <see cref="GetProperties(ShareFileRequestConditions, CancellationToken)"/>
        /// operation returns all user-defined metadata, standard HTTP properties,
        /// and system properties for the file. It does not return the content of the
        /// file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-file-properties">
        /// Get File Properties</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileProperties}"/> describing the
        /// file's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareFileProperties> GetProperties(
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            GetPropertiesInternal(
                conditions,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetProperties(CancellationToken)"/> operation
        /// returns all user-defined metadata, standard HTTP properties,
        /// and system properties for the file. It does not return the
        /// content of the file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-file-properties">
        /// Get File Properties</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileProperties}"/> describing the
        /// file's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<ShareFileProperties> GetProperties(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            CancellationToken cancellationToken) =>
            GetPropertiesInternal(
                conditions: default,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetPropertiesAsync(ShareFileRequestConditions, CancellationToken)"/>
        /// operation returns all user-defined metadata, standard HTTP properties, and system
        /// properties for the file. It does not return the content of the file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-file-properties">
        /// Get File Properties</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileProperties}"/> describing the
        /// file's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareFileProperties>> GetPropertiesAsync(
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await GetPropertiesInternal(
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetPropertiesAsync(CancellationToken)"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the file. It does not return the content of the
        /// file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-file-properties">
        /// Get File Properties</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileProperties}"/> describing the
        /// file's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ShareFileProperties>> GetPropertiesAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            CancellationToken cancellationToken) =>
            await GetPropertiesInternal(
                conditions: default,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetPropertiesInternal"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the file. It does not return the content of the
        /// file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-file-properties">
        /// Get File Properties</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
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
        /// A <see cref="Response{StorageFileProperties}"/> describing the
        /// file's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareFileProperties>> GetPropertiesInternal(
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken,
            string operationName = default)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");
                try
                {
                    Response<RawStorageFileProperties> response = await FileRestClient.File.GetPropertiesAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        leaseId: conditions?.LeaseId,
                        version: Version.ToVersionString(),
                        async: async,
                        cancellationToken: cancellationToken,
                        operationName: operationName ?? $"{nameof(ShareFileClient)}.{nameof(GetProperties)}")
                        .ConfigureAwait(false);

                    // Return an exploding Response on 304
                    return response.IsUnavailable() ?
                        response.GetRawResponse().AsNoBodyResponse<ShareFileProperties>() :
                        Response.FromValue(new ShareFileProperties(response.Value), response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(ShareFileClient));
                }
            }
        }
        #endregion GetProperties

        #region SetHttpHeaders
        /// <summary>
        /// The <see cref="SetHttpHeaders(long?, ShareFileHttpHeaders, FileSmbProperties, string, ShareFileRequestConditions, CancellationToken)"/>
        /// operation sets system properties on the file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-file-properties">
        /// Set File Properties</see>.
        /// </summary>
        /// <param name="newSize">
        /// Optional. Resizes a file to the specified size.
        /// If the specified byte value is less than the current size
        /// of the file, then all ranges above the specified byte value
        /// are cleared.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional. The standard HTTP header system properties to set.  If not specified, existing values will be cleared.
        /// </param>
        /// <param name="smbProperties">
        /// Optional SMB properties to set for the file.
        /// </param>
        /// <param name="filePermission">
        /// Optional file permission to set for the file.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareFileInfo> SetHttpHeaders(
            long? newSize = default,
            ShareFileHttpHeaders httpHeaders = default,
            FileSmbProperties smbProperties = default,
            string filePermission = default,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            SetHttpHeadersInternal(
                newSize,
                httpHeaders,
                smbProperties,
                filePermission,
                conditions,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="SetHttpHeaders(long?, ShareFileHttpHeaders, FileSmbProperties, string, CancellationToken)"/>
        /// operation sets system
        /// properties on the file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-file-properties">
        /// Set File Properties</see>.
        /// </summary>
        /// <param name="newSize">
        /// Optional. Resizes a file to the specified size.
        /// If the specified byte value is less than the current size
        /// of the file, then all ranges above the specified byte value
        /// are cleared.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional. The standard HTTP header system properties to set.  If not specified, existing values will be cleared.
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
        /// A <see cref="Response{StorageFileInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>s
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ShareFileInfo> SetHttpHeaders(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            long? newSize,
            ShareFileHttpHeaders httpHeaders,
            FileSmbProperties smbProperties,
            string filePermission,
            CancellationToken cancellationToken) =>
            SetHttpHeadersInternal(
                newSize,
                httpHeaders,
                smbProperties,
                filePermission,
                conditions: default,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="SetHttpHeadersAsync(long?, ShareFileHttpHeaders, FileSmbProperties, string, ShareFileRequestConditions, CancellationToken)"/>
        /// operation sets system properties on the file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-file-properties">
        /// Set File Properties</see>.
        /// </summary>
        /// <param name="newSize">
        /// Optional. Resizes a file to the specified size.
        /// If the specified byte value is less than the current size
        /// of the file, then all ranges above the specified byte value
        /// are cleared.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional. The standard HTTP header system properties to set.  If not specified, existing values will be cleared.
        /// </param>
        /// <param name="smbProperties">
        /// Optional SMB properties to set for the file.
        /// </param>
        /// <param name="filePermission">
        /// Optional file permission to set for the file.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareFileInfo>> SetHttpHeadersAsync(
            long? newSize = default,
            ShareFileHttpHeaders httpHeaders = default,
            FileSmbProperties smbProperties = default,
            string filePermission = default,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await SetHttpHeadersInternal(
                newSize,
                httpHeaders,
                smbProperties,
                filePermission,
                conditions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetHttpHeadersAsync(long?, ShareFileHttpHeaders, FileSmbProperties, string, CancellationToken)"/>
        /// operation sets system properties on the file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-file-properties">
        /// Set File Properties</see>.
        /// </summary>
        /// <param name="newSize">
        /// Optional. Resizes a file to the specified size.
        /// If the specified byte value is less than the current size
        /// of the file, then all ranges above the specified byte value
        /// are cleared.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional. The standard HTTP header system properties to set.  If not specified, existing values will be cleared.
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
        /// A <see cref="Response{StorageFileInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ShareFileInfo>> SetHttpHeadersAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            long? newSize,
            ShareFileHttpHeaders httpHeaders,
            FileSmbProperties smbProperties,
            string filePermission,
            CancellationToken cancellationToken) =>
            await SetHttpHeadersInternal(
                newSize,
                httpHeaders,
                smbProperties,
                filePermission,
                conditions: default,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetHttpHeadersInternal"/> operation sets system
        /// properties on the file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-file-properties">
        /// Set File Properties</see>.
        /// </summary>
        /// <param name="newSize">
        /// Optional. Resizes a file to the specified size.
        /// If the specified byte value is less than the current size
        /// of the file, then all ranges above the specified byte value
        /// are cleared.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional. The standard HTTP header system properties to set.  If not specified, existing values will be cleared.
        /// </param>
        /// <param name="smbProperties">
        /// Optional SMB properties to set for the file.
        /// </param>
        /// <param name="filePermission">
        /// Optional file permission to set ofr the file.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareFileInfo>> SetHttpHeadersInternal(
            long? newSize,
            ShareFileHttpHeaders httpHeaders,
            FileSmbProperties smbProperties,
            string filePermission,
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(newSize)}: {newSize}\n" +
                    $"{nameof(httpHeaders)}: {httpHeaders}");
                try
                {
                    FileSmbProperties smbProps = smbProperties ?? new FileSmbProperties();

                    ShareExtensions.AssertValidFilePermissionAndKey(filePermission, smbProps.FilePermissionKey);
                    if (filePermission == null && smbProps.FilePermissionKey == null)
                    {
                        filePermission = Constants.File.Preserve;
                    }

                    Response<RawStorageFileInfo> response = await FileRestClient.File.SetPropertiesAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        fileContentLength: newSize,
                        fileContentType: httpHeaders?.ContentType,
                        fileContentEncoding: httpHeaders?.ContentEncoding,
                        fileContentLanguage: httpHeaders?.ContentLanguage,
                        fileCacheControl: httpHeaders?.CacheControl,
                        fileContentHash: httpHeaders?.ContentHash,
                        fileContentDisposition: httpHeaders?.ContentDisposition,
                        fileAttributes: smbProps.FileAttributes?.ToAttributesString() ?? Constants.File.Preserve,
                        filePermission: filePermission,
                        fileCreationTime: smbProps.FileCreatedOn.ToFileDateTimeString() ?? Constants.File.Preserve,
                        fileLastWriteTime: smbProps.FileLastWrittenOn.ToFileDateTimeString() ?? Constants.File.Preserve,
                        filePermissionKey: smbProps.FilePermissionKey,
                        leaseId: conditions?.LeaseId,
                        async: async,
                        operationName: $"{nameof(ShareFileClient)}.{nameof(SetHttpHeaders)}",
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return Response.FromValue(new ShareFileInfo(response.Value), response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(ShareFileClient));
                }
            }
        }
        #endregion SetHttpHeaders

        #region SetMetadata
        /// <summary>
        /// The <see cref="SetMetadata(Metadata, ShareFileRequestConditions, CancellationToken)"/> operation sets user-defined
        /// metadata for the specified file as one or more name-value pairs.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-file-metadata">
        /// Set File Metadata</see>.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this file.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileInfo}"/> describing the updated
        /// file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareFileInfo> SetMetadata(
            Metadata metadata,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            SetMetadataInternal(
                metadata,
                conditions,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="SetMetadata(Metadata, CancellationToken)"/> operation sets user-defined
        /// metadata for the specified file as one or more name-value pairs.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-file-metadata">
        /// Set File Metadata</see>.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileInfo}"/> describing the updated
        /// file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ShareFileInfo> SetMetadata(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Metadata metadata,
            CancellationToken cancellationToken) =>
            SetMetadataInternal(
                metadata,
                conditions: default,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="SetMetadataAsync(Metadata, ShareFileRequestConditions, CancellationToken)"/> operation sets user-defined
        /// metadata for the specified file as one or more name-value pairs.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-file-metadata">
        /// Set File Metadata</see>.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this file.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileInfo}"/> describing the updated
        /// file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareFileInfo>> SetMetadataAsync(
            Metadata metadata,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await SetMetadataInternal(
                metadata,
                conditions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetMetadata(Metadata, CancellationToken)"/> operation sets user-defined
        /// metadata for the specified file as one or more name-value pairs.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-file-metadata">
        /// Set File Metadata</see>.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileInfo}"/> describing the updated
        /// file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ShareFileInfo>> SetMetadataAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Metadata metadata,
            CancellationToken cancellationToken) =>
            await SetMetadataInternal(
                metadata,
                conditions: default,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetMetadataInternal"/> operation sets user-defined
        /// metadata for the specified file as one or more name-value pairs.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-file-metadata">
        /// Set File Metadata</see>.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this file.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileInfo}"/> describing the updated
        /// file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareFileInfo>> SetMetadataInternal(
            Metadata metadata,
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    Response<RawStorageFileInfo> response = await FileRestClient.File.SetMetadataAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        metadata: metadata,
                        leaseId: conditions?.LeaseId,
                        async: async,
                        cancellationToken: cancellationToken,
                        operationName: $"{nameof(ShareFileClient)}.{nameof(SetMetadata)}")
                        .ConfigureAwait(false);

                    return Response.FromValue(new ShareFileInfo(response.Value), response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(ShareFileClient));
                }
            }
        }
        #endregion SetMetadata

        #region ClearRange
        /// <summary>
        /// The <see cref="ClearRange"/>
        /// operation clears the <paramref name="range"/> of a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-range">
        /// Put Range</see>.
        /// </summary>
        /// <param name="range">
        /// Specifies the range of bytes to be cleared. Both the start and end of the range must be specified.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareFileUploadInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareFileUploadInfo> ClearRange(
            HttpRange range,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
                ClearRangeInternal(
                    range: range,
                    conditions: conditions,
                    async: false,
                    cancellationToken: cancellationToken)
                    .EnsureCompleted();

        /// <summary>
        /// The <see cref="ClearRangeAsync"/>
        /// operation clears the <paramref name="range"/> of a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-range">
        /// Put Range</see>.
        /// </summary>
        /// <param name="range">
        /// Specifies the range of bytes to be cleared. Both the start and end of the range must be specified.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareFileUploadInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareFileUploadInfo>> ClearRangeAsync(
            HttpRange range,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
                await ClearRangeInternal(
                    range: range,
                    conditions: conditions,
                    async: true,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UploadRangeInternal"/> operation clears the
        /// <paramref name="range"/> of a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-range">
        /// Put Range</see>.
        /// </summary>
        /// <param name="range">
        /// Specifies the range of bytes to be cleated. Both the start and end of the range must be specified.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareFileUploadInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareFileUploadInfo>> ClearRangeInternal(
            HttpRange range,
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ShareFileClient)}.{nameof(ClearRange)}");

                Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");
                try
                {
                    scope.Start();
                    return await FileRestClient.File.UploadRangeAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        range: range.ToString(),
                        fileRangeWrite: ShareFileRangeWriteType.Clear,
                        contentLength: 0,
                        leaseId: conditions?.LeaseId,
                        async: async,
                        cancellationToken: cancellationToken,
                        operationName: $"{nameof(ShareFileClient)}.{nameof(UploadRange)}").ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    scope.Dispose();
                    Pipeline.LogMethodExit(nameof(ShareFileClient));
                }
            }
        }
        #endregion ClearRange

        #region UploadRange
        /// <summary>
        /// The <see cref="UploadRange(HttpRange, Stream, byte[], IProgress{long}, ShareFileRequestConditions, CancellationToken)"/>
        /// operation writes <paramref name="content"/> to a <paramref name="range"/> of a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-range">
        /// Put Range</see>.
        /// </summary>
        /// <param name="range">
        /// Specifies the range of bytes to be written. Both the start and end of the range must be specified.
        /// </param>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the range to upload.
        /// </param>
        /// <param name="transactionalContentHash">
        /// Optional MD5 hash of the range content.
        ///
        /// This hash is used to verify the integrity of the range during transport. When this hash
        /// is specified, the storage service compares the hash of the content
        /// that has arrived with this value.  Note that this MD5 hash is not
        /// stored with the file.  If the two hashes do not match, the
        /// operation will fail with a <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareFileUploadInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareFileUploadInfo> UploadRange(
            HttpRange range,
            Stream content,
            byte[] transactionalContentHash = null,
            IProgress<long> progressHandler = default,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            UploadRangeInternal(
                range,
                content,
                transactionalContentHash,
                progressHandler,
                conditions: conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="UploadRangeAsync(HttpRange, Stream, byte[], IProgress{long}, ShareFileRequestConditions, CancellationToken)"/>
        /// operation writes <paramref name="content"/> to a <paramref name="range"/> of a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-range">
        /// Put Range</see>.
        /// </summary>
        /// <param name="range">
        /// Specifies the range of bytes to be written. Both the start and end of the range must be specified.
        /// </param>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the range to upload.
        /// </param>
        /// <param name="transactionalContentHash">
        /// Optional MD5 hash of the range content.
        ///
        /// This hash is used to verify the integrity of the range during transport. When this hash
        /// is specified, the storage service compares the hash of the content
        /// that has arrived with this value.  Note that this MD5 hash is not
        /// stored with the file.  If the two hashes do not match, the
        /// operation will fail with a <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareFileUploadInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareFileUploadInfo>> UploadRangeAsync(
            HttpRange range,
            Stream content,
            byte[] transactionalContentHash = default,
            IProgress<long> progressHandler = default,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await UploadRangeInternal(
                range,
                content,
                transactionalContentHash,
                progressHandler,
                conditions: conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UploadRange(ShareFileRangeWriteType, HttpRange, Stream, byte[], IProgress{long}, CancellationToken)"/>
        /// operation writes <paramref name="content"/> to a <paramref name="range"/> of a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-range">
        /// Put Range</see>.
        /// </summary>
        /// <param name="writeType">Required. Specifies whether to update or clear the range.
        /// </param>
        /// <param name="range">
        /// Specifies the range of bytes to be written. Both the start and end of the range must be specified.
        /// </param>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the range to upload.
        /// </param>
        /// <param name="transactionalContentHash">
        /// Optional MD5 hash of the range content.  Must not be used when <paramref name="writeType"/> is set to <see cref="ShareFileRangeWriteType.Clear"/>.
        ///
        /// This hash is used to verify the integrity of the range during transport. When this hash
        /// is specified, the storage service compares the hash of the content
        /// that has arrived with this value.  Note that this MD5 hash is not
        /// stored with the file.  If the two hashes do not match, the
        /// operation will fail with a <see cref="RequestFailedException"/>.
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
        /// A <see cref="Response{ShareFileUploadInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ShareFileUploadInfo> UploadRange(
            ShareFileRangeWriteType writeType,
            HttpRange range,
            Stream content,
            byte[] transactionalContentHash = default,
            IProgress<long> progressHandler = default,
            CancellationToken cancellationToken = default) =>
            UploadRangeInternal(
                range,
                content,
                transactionalContentHash,
                progressHandler,
                conditions: default,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="UploadRange(ShareFileRangeWriteType, HttpRange, Stream, byte[], IProgress{long}, CancellationToken)"/>
        /// operation writes <paramref name="content"/> to a <paramref name="range"/> of a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-range">
        /// Put Range</see>.
        /// </summary>
        /// <param name="writeType">Required. Specifies whether to update or clear the range.
        /// </param>
        /// <param name="range">
        /// Specifies the range of bytes to be written. Both the start and end of the range must be specified.
        /// </param>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the range to upload.
        /// </param>
        /// <param name="transactionalContentHash">
        /// Optional MD5 hash of the range content.  Must not be used when <paramref name="writeType"/> is set to <see cref="ShareFileRangeWriteType.Clear"/>.
        ///
        /// This hash is used to verify the integrity of the range during transport. When this hash
        /// is specified, the storage service compares the hash of the content
        /// that has arrived with this value.  Note that this MD5 hash is not
        /// stored with the file.  If the two hashes do not match, the
        /// operation will fail with a <see cref="RequestFailedException"/>.
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
        /// A <see cref="Response{ShareFileUploadInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ShareFileUploadInfo>> UploadRangeAsync(
            ShareFileRangeWriteType writeType,
            HttpRange range,
            Stream content,
            byte[] transactionalContentHash = default,
            IProgress<long> progressHandler = default,
            CancellationToken cancellationToken = default) =>
            await UploadRangeInternal(
                range,
                content,
                transactionalContentHash,
                progressHandler,
                conditions: default,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UploadRangeInternal"/> operation writes
        /// <paramref name="content"/> to a <paramref name="range"/> of a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-range">
        /// Put Range</see>.
        /// </summary>
        /// <param name="range">
        /// Specifies the range of bytes to be written. Both the start and end of the range must be specified.
        /// </param>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the range to upload.
        /// </param>
        /// <param name="transactionalContentHash">
        /// Optional MD5 hash of the range content.
        ///
        /// This hash is used to verify the integrity of the range during transport. When this hash
        /// is specified, the storage service compares the hash of the content
        /// that has arrived with this value.  Note that this MD5 hash is not
        /// stored with the file.  If the two hashes do not match, the
        /// operation will fail with a <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileUploadInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareFileUploadInfo>> UploadRangeInternal(
            HttpRange range,
            Stream content,
            byte[] transactionalContentHash,
            IProgress<long> progressHandler,
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");
                try
                {
                    Errors.VerifyStreamPosition(content, nameof(content));
                    content = content.WithNoDispose().WithProgress(progressHandler);
                    return await FileRestClient.File.UploadRangeAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        optionalbody: content,
                        contentLength: (content?.Length - content?.Position) ?? 0,
                        range: range.ToString(),
                        fileRangeWrite: ShareFileRangeWriteType.Update,
                        contentHash: transactionalContentHash,
                        leaseId: conditions?.LeaseId,
                        async: async,
                        cancellationToken: cancellationToken,
                        operationName: $"{nameof(ShareFileClient)}.{nameof(UploadRange)}").ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(ShareFileClient));
                }
            }
        }
        #endregion UploadRange

        #region UploadRangeFromUrl
        /// <summary>
        /// The <see cref="UploadRangeFromUri(Uri, HttpRange, HttpRange, ShareFileRequestConditions, CancellationToken)"/>
        /// operation writes a range from an Azure File to another Azure file. This API is supported only for version 2019-02-02 and higher.
        /// </summary>
        /// <param name="sourceUri">
        /// Required. Specifies the URL of the source file, up to 2 KB in length.
        /// If source is an Azure blob or Azure file, it must either be public or must be authenticated via a
        /// shared access signature. If the source is public, no authentication is required to perform the operation.
        /// </param>
        /// <param name="range">
        /// Specifies the range of bytes to be written. Both the start and end of the range must be specified.
        /// </param>
        /// <param name="sourceRange">
        /// Specifies the range of bytes to be written from. Both the start and end of the range must be specified.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileUploadInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareFileUploadInfo> UploadRangeFromUri(
            Uri sourceUri,
            HttpRange range,
            HttpRange sourceRange,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            this.UploadRangeFromUriInternal(
                sourceUri,
                range,
                sourceRange,
                conditions,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="UploadRangeFromUri(Uri, HttpRange, HttpRange, CancellationToken)"/>
        /// operation writes a range from an Azure File to another Azure file. This API is supported only for version 2019-02-02 and higher.
        /// </summary>
        /// <param name="sourceUri">
        /// Required. Specifies the URL of the source file, up to 2 KB in length.
        /// If source is an Azure blob or Azure file, it must either be public or must be authenticated via a
        /// shared access signature. If the source is public, no authentication is required to perform the operation.
        /// </param>
        /// <param name="range">
        /// Specifies the range of bytes to be written. Both the start and end of the range must be specified.
        /// </param>
        /// <param name="sourceRange">
        /// Specifies the range of bytes to be written from. Both the start and end of the range must be specified.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileUploadInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ShareFileUploadInfo> UploadRangeFromUri(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Uri sourceUri,
            HttpRange range,
            HttpRange sourceRange,
            CancellationToken cancellationToken) =>
            this.UploadRangeFromUriInternal(
                sourceUri,
                range,
                sourceRange,
                conditions: default,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="UploadRangeFromUriAsync(Uri, HttpRange, HttpRange, ShareFileRequestConditions, CancellationToken)"/>
        /// operation writes a range from an Azure File to another Azure file. This API is supported only for version 2019-02-02 and higher.
        /// </summary>
        /// <param name="sourceUri">
        /// Required. Specifies the URL of the source file, up to 2 KB in length.
        /// If source is an Azure blob or Azure file, it must either be public or must be authenticated via a
        /// shared access signature. If the source is public, no authentication is required to perform the operation.
        /// </param>
        /// <param name="range">
        /// Specifies the range of bytes to be written. Both the start and end of the range must be specified.
        /// </param>
        /// <param name="sourceRange">
        /// Specifies the range of bytes to be written from. Both the start and end of the range must be specified.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileUploadInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<ShareFileUploadInfo>> UploadRangeFromUriAsync(
            Uri sourceUri,
            HttpRange range,
            HttpRange sourceRange,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await this.UploadRangeFromUriInternal(
                sourceUri,
                range,
                sourceRange,
                conditions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UploadRangeFromUriAsync(Uri, HttpRange, HttpRange, CancellationToken)"/>
        /// operation writes a range from an Azure File to another Azure file. This API is supported only for version 2019-02-02 and higher.
        /// </summary>
        /// <param name="sourceUri">
        /// Required. Specifies the URL of the source file, up to 2 KB in length.
        /// If source is an Azure blob or Azure file, it must either be public or must be authenticated via a
        /// shared access signature. If the source is public, no authentication is required to perform the operation.
        /// </param>
        /// <param name="range">
        /// Specifies the range of bytes to be written. Both the start and end of the range must be specified.
        /// </param>
        /// <param name="sourceRange">
        /// Specifies the range of bytes to be written from. Both the start and end of the range must be specified.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileUploadInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ShareFileUploadInfo>> UploadRangeFromUriAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Uri sourceUri,
            HttpRange range,
            HttpRange sourceRange,
            CancellationToken cancellationToken) =>
            await this.UploadRangeFromUriInternal(
                sourceUri,
                range,
                sourceRange,
                conditions: default,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UploadRangeInternal"/> operation writes a range from an Azure File to another Azure file.
        /// This API is supported only for version 2019-02-02 and higher.
        /// </summary>
        /// <param name="sourceUri">
        /// Required. Specifies the URL of the source file, up to 2 KB in length.
        /// If source is an Azure blob or Azure file, it must either be public or must be authenticated via a
        /// shared access signature. If the source is public, no authentication is required to perform the operation.
        /// </param>
        /// <param name="range">
        /// Specifies the range of bytes to be written. Both the start and end of the range must be specified.
        /// </param>
        /// <param name="sourceRange">
        /// Specifies the range of bytes to be written from. Both the start and end of the range must be specified.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareFileUploadInfo>> UploadRangeFromUriInternal(
            Uri sourceUri,
            HttpRange range,
            HttpRange sourceRange,
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(sourceUri)}: {sourceUri}");
                try
                {
                    var response = await FileRestClient.File.UploadRangeFromURLAsync(
                        clientDiagnostics: ClientDiagnostics,
                        pipeline: Pipeline,
                        resourceUri: Uri,
                        range: range.ToString(),
                        copySource: sourceUri,
                        contentLength: default,
                        version: Version.ToVersionString(),
                        sourceRange: sourceRange.ToString(),
                        leaseId: conditions?.LeaseId,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return Response.FromValue(
                        new ShareFileUploadInfo
                        {
                            ETag = response.Value.ETag,
                            LastModified = response.Value.LastModified,
                            ContentHash = response.Value.XMSContentCrc64,
                            IsServerEncrypted = response.Value.IsServerEncrypted
                        }, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(ShareFileClient));
                }
            }
        }
        #endregion UploadRangeFromUrl

        #region Upload
        /// <summary>
        /// The <see cref="Upload(Stream, IProgress{long}, ShareFileRequestConditions, CancellationToken)"/>
        /// operation writes <paramref name="content"/> to a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-range">
        /// Put Range</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the file to upload.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileUploadInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<ShareFileUploadInfo> Upload(
            Stream content,
            IProgress<long> progressHandler = default,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            UploadInternal(
                content,
                progressHandler,
                conditions,
                Constants.File.MaxFileUpdateRange,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="Upload(Stream, IProgress{long}, ShareFileRequestConditions, CancellationToken)"/>
        /// operation writes <paramref name="content"/> to a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-range">
        /// Put Range</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the file to upload.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileUploadInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ShareFileUploadInfo> Upload(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Stream content,
            IProgress<long> progressHandler,
            CancellationToken cancellationToken) =>
            UploadInternal(
                content,
                progressHandler,
                conditions: default,
                Constants.File.MaxFileUpdateRange,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="UploadAsync(Stream, IProgress{long}, ShareFileRequestConditions, CancellationToken)"/> operation writes
        /// <paramref name="content"/> to a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-range">
        /// Put Range</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the file to upload.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileUploadInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<ShareFileUploadInfo>> UploadAsync(
            Stream content,
            IProgress<long> progressHandler = default,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await UploadInternal(
                content,
                progressHandler,
                conditions,
                Constants.File.MaxFileUpdateRange,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UploadAsync(Stream, IProgress{long}, CancellationToken)"/> operation writes
        /// <paramref name="content"/> to a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-range">
        /// Put Range</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the file to upload.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileUploadInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ShareFileUploadInfo>> UploadAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Stream content,
            IProgress<long> progressHandler,
            CancellationToken cancellationToken) =>
            await UploadInternal(
                content,
                progressHandler,
                conditions: default,
                Constants.File.MaxFileUpdateRange,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UploadInternal"/> operation writes
        /// <paramref name="content"/> to a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-range">
        /// Put Range</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="singleRangeThreshold">
        /// The maximum size stream that we'll upload as a single range.  The
        /// default value is 4MB.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileUploadInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<Response<ShareFileUploadInfo>> UploadInternal(
            Stream content,
            IProgress<long> progressHandler,
            ShareFileRequestConditions conditions,
            int singleRangeThreshold,
            bool async,
            CancellationToken cancellationToken)
        {
            Errors.VerifyStreamPosition(content, nameof(content));

            // Try to upload the file as a single range
            Debug.Assert(singleRangeThreshold <= Constants.File.MaxFileUpdateRange);
            var length = content?.Length - content?.Position;
            if (length <= singleRangeThreshold)
            {
                return await UploadRangeInternal(
                    new HttpRange(0, length),
                    content,
                    null,
                    progressHandler,
                    conditions,
                    async,
                    cancellationToken)
                    .ConfigureAwait(false);
            }

            // Otherwise naively split the file into ranges and upload them individually
            var response = default(Response<ShareFileUploadInfo>);
            var pool = default(MemoryPool<byte>);

            long initalPosition = content.Position;

            try
            {
                pool = (singleRangeThreshold < MemoryPool<byte>.Shared.MaxBufferSize) ?
                    MemoryPool<byte>.Shared :
                    new StorageMemoryPool(singleRangeThreshold, 1);
                for (; ; )
                {
                    // Get the next chunk of content
                    var parentPosition = content.Position;
                    IMemoryOwner<byte> buffer = pool.Rent(singleRangeThreshold);
                    if (!MemoryMarshal.TryGetArray<byte>(buffer.Memory, out ArraySegment<byte> segment))
                    {
                        throw Errors.UnableAccessArray();
                    }
                    var count = async ?
                        await content.ReadAsync(segment.Array, 0, singleRangeThreshold, cancellationToken).ConfigureAwait(false) :
                        content.Read(segment.Array, 0, singleRangeThreshold);

                    // Stop when we've exhausted the content
                    if (count <= 0) { break; }

                    // Upload the chunk
                    var partition = new StreamPartition(
                        buffer.Memory,
                        parentPosition,
                        count,
                        () => buffer.Dispose(),
                        cancellationToken);
                    response = await UploadRangeInternal(
                        new HttpRange(partition.ParentPosition - initalPosition, partition.Length),
                        partition,
                        null,
                        progressHandler,
                        conditions,
                        async,
                        cancellationToken)
                        .ConfigureAwait(false);
                }
            }
            finally
            {
                if (pool is StorageMemoryPool)
                {
                    pool.Dispose();
                }
            }
            return response;
        }
        #endregion Upload

        #region GetRangeList
        /// <summary>
        /// Returns the list of valid ranges for a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-ranges">
        /// List Ranges</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileRangeInfo}"/> describing the
        /// valid ranges for this file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareFileRangeInfo> GetRangeList(
            ShareFileGetRangeListOptions options = default,
            CancellationToken cancellationToken = default) =>
            GetRangeListInternal(
                options?.Range,
                options?.Snapshot,
                previousSnapshot: default,
                options?.Conditions,
                operationName: default,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Returns the list of valid ranges for a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-ranges">
        /// List Ranges</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileRangeInfo}"/> describing the
        /// valid ranges for this file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareFileRangeInfo>> GetRangeListAsync(
            ShareFileGetRangeListOptions options = default,
            CancellationToken cancellationToken = default) =>
            await GetRangeListInternal(
                options?.Range,
                options?.Snapshot,
                previousSnapshot: default,
                options?.Conditions,
                operationName: default,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Returns the list of valid ranges for a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-ranges">
        /// List Ranges</see>.
        /// </summary>
        /// <param name="range">
        /// Optional. Specifies the range of bytes over which to list ranges, inclusively.
        /// If omitted, then all ranges for the file are returned.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileRangeInfo}"/> describing the
        /// valid ranges for this file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ShareFileRangeInfo> GetRangeList(
            HttpRange range,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            GetRangeListInternal(
                range,
                snapshot: default,
                previousSnapshot: default,
                conditions,
                operationName: default,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Returns the list of valid ranges for a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-ranges">
        /// List Ranges</see>.
        /// </summary>
        /// <param name="range">
        /// Optional. Specifies the range of bytes over which to list ranges, inclusively.
        /// If omitted, then all ranges for the file are returned.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileRangeInfo}"/> describing the
        /// valid ranges for this file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ShareFileRangeInfo> GetRangeList(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            HttpRange range,
            CancellationToken cancellationToken) =>
            GetRangeListInternal(
                range,
                snapshot: default,
                previousSnapshot: default,
                conditions: default,
                operationName: default,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Returns the list of valid ranges for a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-ranges">
        /// List Ranges</see>.
        /// </summary>
        /// <param name="range">
        /// Optional. Specifies the range of bytes over which to list ranges, inclusively.
        /// If omitted, then all ranges for the file are returned.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileRangeInfo}"/> describing the
        /// valid ranges for this file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ShareFileRangeInfo>> GetRangeListAsync(
            HttpRange range,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await GetRangeListInternal(
                range,
                snapshot: default,
                previousSnapshot: default,
                conditions,
                operationName: default,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Returns the list of valid ranges for a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-ranges">
        /// List Ranges</see>.
        /// </summary>
        /// <param name="range">
        /// Optional. Specifies the range of bytes over which to list ranges, inclusively.
        /// If omitted, then all ranges for the file are returned.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileRangeInfo}"/> describing the
        /// valid ranges for this file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ShareFileRangeInfo>> GetRangeListAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            HttpRange range,
            CancellationToken cancellationToken) =>
            await GetRangeListInternal(
                range,
                snapshot: default,
                previousSnapshot: default,
                conditions: default,
                operationName: default,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Returns the list of valid ranges for a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-ranges">
        /// List Ranges</see>.
        /// </summary>
        /// <param name="range">
        /// Optional. Specifies the range of bytes over which to list ranges, inclusively.
        /// If omitted, then all ranges for the file are returned.
        /// </param>
        /// <param name="snapshot">
        /// Optionally specifies the share snapshot to retrieve ranges
        /// information from. For more information on working with share snapshots,
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-share">
        /// Create a snapshot of a share</see>.
        /// </param>
        /// <param name="previousSnapshot">
        /// Specifies that the response will contain only ranges that were
        /// changed between target file and previous snapshot.  Changed ranges
        /// include both updated and cleared ranges. The target file may be a
        /// snapshot, as long as the snapshot specified by
        /// <paramref name="previousSnapshot"/> is the older of the two.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </param>
        /// <param name="operationName">
        /// Name of the calling API
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileRangeInfo}"/> describing the
        /// valid ranges for this file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareFileRangeInfo>> GetRangeListInternal(
            HttpRange? range,
            string snapshot,
            string previousSnapshot,
            ShareFileRequestConditions conditions,
            string operationName,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");
                try
                {
                    Response<ShareFileRangeInfoInternal> response = await FileRestClient.File.GetRangeListAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        sharesnapshot: snapshot,
                        prevsharesnapshot: previousSnapshot,
                        range: range?.ToString(),
                        leaseId: conditions?.LeaseId,
                        async: async,
                        cancellationToken: cancellationToken,
                        operationName: operationName?? $"{nameof(ShareFileClient)}.{nameof(GetRangeList)}")
                        .ConfigureAwait(false);
                    return Response.FromValue(new ShareFileRangeInfo(response.Value), response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(ShareFileClient));
                }
            }
        }
        #endregion GetRangeList

        #region GetRangeListDiff
        /// <summary>
        /// Returns the list of ranges that have changed in the file since previousSnapshot
        /// was taken.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-ranges">
        /// List Ranges</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileRangeInfo}"/> describing the
        /// valid ranges for this file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareFileRangeInfo> GetRangeListDiff(
            ShareFileGetRangeListDiffOptions options = default,
            CancellationToken cancellationToken = default) =>
            GetRangeListInternal(
                options?.Range,
                options?.Snapshot,
                options?.PreviousSnapshot,
                options?.Conditions,
                operationName: $"{nameof(ShareFileClient)}.{nameof(GetRangeListDiff)}",
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Returns the list of ranges that have changed in the file since previousSnapshot
        /// was taken.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-ranges">
        /// List Ranges</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileRangeInfo}"/> describing the
        /// valid ranges for this file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareFileRangeInfo>> GetRangeListDiffAsync(
            ShareFileGetRangeListDiffOptions options = default,
            CancellationToken cancellationToken = default) =>
            await GetRangeListInternal(
                options?.Range,
                options?.Snapshot,
                options?.PreviousSnapshot,
                options?.Conditions,
                operationName: $"{nameof(ShareFileClient)}.{nameof(GetRangeListDiff)}",
                async: true,
                cancellationToken)
                .ConfigureAwait(false);
        #endregion GetRangeListDiff

        #region GetHandles
        /// <summary>
        /// The <see cref="GetHandles"/> operation returns an async sequence
        /// of the open handles on a directory or a file.  Enumerating the
        /// handles may make multiple requests to the service while fetching
        /// all the values.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-handles">
        /// List Handles</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of <see cref="Response{StorageHandle}"/>
        /// describing the handles in the directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Pageable<ShareFileHandle> GetHandles(
            CancellationToken cancellationToken = default) =>
            new GetFileHandlesAsyncCollection(this).ToSyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetHandlesAsync"/> operation returns an async
        /// sequence of the open handles on a directory or a file.
        /// Enumerating the handles may make multiple requests to the service
        /// while fetching all the values.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-handles">
        /// List Handles</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="AsyncPageable{T}"/> describing the
        /// handles on the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual AsyncPageable<ShareFileHandle> GetHandlesAsync(
            CancellationToken cancellationToken = default) =>
            new GetFileHandlesAsyncCollection(this).ToAsyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetHandlesInternal"/> operation returns a list of open
        /// handles on the file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-handles">
        /// List Handles</see>.
        /// </summary>
        /// <remarks>
        /// </remarks>
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
        /// Optional. Specifies the maximum number of handles to return.
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
        /// segment of the handles on the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<Response<StorageHandlesSegment>> GetHandlesInternal(
            string marker,
            int? maxResults,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(marker)}: {marker}\n" +
                    $"{nameof(maxResults)}: {maxResults}");
                try
                {
                    return await FileRestClient.File.ListHandlesAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        marker: marker,
                        maxresults: maxResults,
                        async: async,
                        operationName: $"{nameof(ShareFileClient)}.{nameof(GetHandles)}",
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
                    Pipeline.LogMethodExit(nameof(ShareFileClient));
                }
            }
        }
        #endregion GetHandles

        #region ForceCloseHandles
        /// <summary>
        /// The <see cref="ForceCloseHandle"/> operation closes a handle opened on a file
        /// at the service. It supports closing a single handle specified by <paramref name="handleId"/>.
        ///
        /// This API is intended to be used alongside <see cref="GetHandlesAsync"/> to force close handles that
        /// block operations. These handles may have leaked or been lost track of by
        /// SMB clients. The API has client-side impact on the handle being closed, including user visible
        /// errors due to failed attempts to read or write files. This API is not intended for use as a replacement
        /// or alternative for SMB close.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/force-close-handles">
        /// Force Close Handles</see>.
        /// </summary>
        /// <param name="handleId">
        /// Specifies the handle ID to be closed.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{CloseHandlesResult}"/> describing the status of the
        /// <see cref="ForceCloseHandle"/> operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<CloseHandlesResult> ForceCloseHandle(
            string handleId,
            CancellationToken cancellationToken = default)
        {
            Response<StorageClosedHandlesSegment> response = ForceCloseHandlesInternal(
                handleId,
                null,
                false, // async,
                cancellationToken,
                $"{nameof(ShareFileClient)}.{nameof(ForceCloseHandle)}")
                .EnsureCompleted();

            return Response.FromValue(
                response.ToCloseHandlesResult(),
                response.GetRawResponse());
        }

        /// <summary>
        /// The <see cref="ForceCloseHandleAsync"/> operation closes a handle opened on a file
        /// at the service. It supports closing a single handle specified by <paramref name="handleId"/>.
        ///
        /// This API is intended to be used alongside <see cref="GetHandlesAsync"/> to force close handles that
        /// block operations. These handles may have leaked or been lost track of by
        /// SMB clients. The API has client-side impact on the handle being closed, including user visible
        /// errors due to failed attempts to read or write files. This API is not intended for use as a replacement
        /// or alternative for SMB close.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/force-close-handles">
        /// Force Close Handles</see>.
        /// </summary>
        /// <param name="handleId">
        /// Specifies the handle ID to be closed.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{CloseHandlesResult}"/> describing the status of the
        /// <see cref="ForceCloseHandleAsync"/> operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<CloseHandlesResult>> ForceCloseHandleAsync(
            string handleId,
            CancellationToken cancellationToken = default)
        {
            Response<StorageClosedHandlesSegment> response = await ForceCloseHandlesInternal(
                handleId,
                null,
                true, // async,
                cancellationToken,
                $"{nameof(ShareFileClient)}.{nameof(ForceCloseHandle)}")
                .ConfigureAwait(false);

            return Response.FromValue(
                response.ToCloseHandlesResult(),
                response.GetRawResponse());
        }

        /// <summary>
        /// The <see cref="ForceCloseAllHandles"/> operation closes all handles opened on a file
        /// at the service.
        ///
        /// This API is intended to be used alongside <see cref="GetHandlesAsync"/> to force close handles that
        /// block operations. These handles may have leaked or been lost track of by
        /// SMB clients. The API has client-side impact on the handle being closed, including user visible
        /// errors due to failed attempts to read or write files. This API is not intended for use as a replacement
        /// or alternative for SMB close.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/force-close-handles">
        /// Force Close Handles</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="CloseHandlesResult"/> describing the status of the
        /// <see cref="ForceCloseAllHandles"/> operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual CloseHandlesResult ForceCloseAllHandles(
            CancellationToken cancellationToken = default) =>
            ForceCloseAllHandlesInternal(
                false, // async,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="ForceCloseAllHandlesAsync"/> operation closes all handles opened on a file
        /// at the service.
        ///
        /// This API is intended to be used alongside <see cref="GetHandlesAsync"/> to force close handles that
        /// block operations. These handles may have leaked or been lost track of by
        /// SMB clients. The API has client-side impact on the handle being closed, including user visible
        /// errors due to failed attempts to read or write files. This API is not intended for use as a replacement
        /// or alternative for SMB close.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/force-close-handles">
        /// Force Close Handles</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="CloseHandlesResult"/> describing the status of the
        /// <see cref="ForceCloseAllHandlesAsync"/> operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<CloseHandlesResult> ForceCloseAllHandlesAsync(
            CancellationToken cancellationToken = default) =>
            await ForceCloseAllHandlesInternal(
                true, // async,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="ForceCloseAllHandlesInternal"/> operation closes a handle or handles opened on a file
        /// at the service. It supports closing all handles opened on that resource.
        ///
        /// This API is intended to be used alongside <see cref="GetHandlesAsync"/> to force close handles that
        /// block operations. These handles may have leaked or been lost track of by
        /// SMB clients. The API has client-side impact on the handle being closed, including user visible
        /// errors due to failed attempts to read or write files. This API is not intended for use as a replacement
        /// or alternative for SMB close.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/force-close-handles">
        /// Force Close Handles</see>.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ClosedHandlesInfo}"/> describing the status of the
        /// <see cref="ForceCloseAllHandlesInternal"/> operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<CloseHandlesResult> ForceCloseAllHandlesInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            int handlesClosed = 0;
            int handlesFailed = 0;
            string marker = null;
            do
            {
                Response<StorageClosedHandlesSegment> response =
                    await ForceCloseHandlesInternal(Constants.CloseAllHandles, marker, async, cancellationToken).ConfigureAwait(false);
                marker = response.Value.Marker;
                handlesClosed += response.Value.NumberOfHandlesClosed;
                handlesFailed += response.Value.NumberOfHandlesFailedToClose;
            } while (!string.IsNullOrEmpty(marker));

            return new CloseHandlesResult()
            {
                ClosedHandlesCount = handlesClosed,
                FailedHandlesCount = handlesFailed
            };
        }

        /// <summary>
        /// The <see cref="ForceCloseHandlesInternal"/> operation closes a handle or handles opened on a file
        /// at the service. It supports closing a single handle specified by <paramref name="handleId"/> or
        /// or closing all handles opened on that resource.
        ///
        /// This API is intended to be used alongside <see cref="GetHandlesAsync"/> to force close handles that
        /// block operations. These handles may have leaked or been lost track of by
        /// SMB clients. The API has client-side impact on the handle being closed, including user visible
        /// errors due to failed attempts to read or write files. This API is not intended for use as a replacement
        /// or alternative for SMB close.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/force-close-handles">
        /// Force Close Handles</see>.
        /// </summary>
        /// <param name="handleId">
        /// Optional. Specifies the handle ID to be closed. If not specified, or if equal to &quot;*&quot;, will close all handles.
        /// </param>
        /// <param name="marker">
        /// An optional string value that identifies the segment of the handles
        /// to be closed with the next call to <see cref="ForceCloseAllHandlesAsync"/>.  The
        /// operation returns a non-empty <see cref="StorageClosedHandlesSegment.Marker"/>
        /// if the operation did not return all items remaining to be
        /// closed with the current segment.  The NextMarker value can
        /// be used as the value for the <paramref name="marker"/> parameter
        /// in a subsequent call to request the closure of the next segment of handles.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <param name="operationName">
        /// Optional. Used to indicate the name of the operation.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageClosedHandlesSegment}"/> describing a
        /// segment of the handles closed.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<StorageClosedHandlesSegment>> ForceCloseHandlesInternal(
            string handleId,
            string marker,
            bool async,
            CancellationToken cancellationToken,
            string operationName = null)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(handleId)}: {handleId}\n" +
                    $"{nameof(marker)}: {marker}");
                try
                {
                    return await FileRestClient.File.ForceCloseHandlesAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        marker: marker,
                        handleId: handleId,
                        version: Version.ToVersionString(),
                        async: async,
                        cancellationToken: cancellationToken,
                        operationName: operationName ?? $"{nameof(ShareFileClient)}.{nameof(ForceCloseAllHandles)}")
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(ShareFileClient));
                }
            }
        }
        #endregion ForceCloseHandles

        #region OpenWrite
        /// <summary>
        /// Opens a stream for writing to the file.
        /// </summary>
        /// <param name="overwrite">
        /// Whether an existing blob should be deleted and recreated.
        /// </param>
        /// <param name="position">
        /// The offset within the blob to begin writing from.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A stream to write to the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Stream OpenWrite(
#pragma warning restore AZC0015 // Unexpected client method return type.
            bool overwrite,
            long position,
            ShareFileOpenWriteOptions options = default,
            CancellationToken cancellationToken = default)
            => OpenWriteInternal(
                overwrite: overwrite,
                position: position,
                options: options,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Opens a stream for writing to the file.
        /// </summary>
        /// <param name="overwrite">
        /// Whether an existing blob should be deleted and recreated.
        /// </param>
        /// <param name="position">
        /// The offset within the blob to begin writing from.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A stream to write to the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Stream> OpenWriteAsync(
#pragma warning restore AZC0015 // Unexpected client method return type.
            bool overwrite,
            long position,
            ShareFileOpenWriteOptions options = default,
            CancellationToken cancellationToken = default)
            => await OpenWriteInternal(
                overwrite: overwrite,
                position: position,
                options: options,
                async: true,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Opens a stream for writing to the file.
        /// </summary>
        /// <param name="overwrite">
        /// Whether an existing blob should be deleted and recreated.
        /// </param>
        /// <param name="position">
        /// The offset within the blob to begin writing from.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A stream to write to the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Stream> OpenWriteInternal(
            bool overwrite,
            long position,
            ShareFileOpenWriteOptions options,
            bool async,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ShareFileClient)}.{nameof(OpenWrite)}");

            try
            {
                scope.Start();

                if (overwrite)
                {
                    if (options?.MaxSize == null)
                    {
                        throw new ArgumentException($"{nameof(options)}.{nameof(options.MaxSize)} must be set if {nameof(overwrite)} is set to true");
                    }

                    Response<ShareFileInfo> createResponse = await CreateInternal(
                        maxSize: options.MaxSize.Value,
                        httpHeaders: default,
                        metadata: default,
                        smbProperties: default,
                        filePermission: default,
                        conditions: options?.OpenConditions,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                else
                {
                    try
                    {
                        Response<ShareFileProperties> propertiesResponse = await GetPropertiesInternal(
                            conditions: options?.OpenConditions,
                            async: async,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    catch (RequestFailedException ex)
                    when(ex.ErrorCode == ShareErrorCode.ResourceNotFound)
                    {
                        if (options?.MaxSize == null)
                        {
                            throw new ArgumentException($"{nameof(options)}.{nameof(options.MaxSize)} must be set if the File is being created for the first time");
                        }

                        Response<ShareFileInfo> createResponse = await CreateInternal(
                            maxSize: options.MaxSize.Value,
                            httpHeaders: default,
                            metadata: default,
                            smbProperties: default,
                            filePermission: default,
                            conditions: options?.OpenConditions,
                            async: async,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                }

                return new ShareFileWriteStream(
                    fileClient: this,
                    bufferSize: options?.BufferSize ?? Constants.DefaultBufferSize,
                    position: position,
                    conditions: options?.OpenConditions,
                    progressHandler: options?.ProgressHandler);
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
        #endregion OpenWrite

        #region GenerateSas
        /// <summary>
        /// The <see cref="GenerateSasUri(ShareFileSasPermissions, DateTimeOffset)"/>
        /// returns a <see cref="Uri"/> that generates a Share File Service
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
        /// See <see cref="ShareFileSasPermissions"/>.
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
        public virtual Uri GenerateSasUri(ShareFileSasPermissions permissions, DateTimeOffset expiresOn) =>
            GenerateSasUri(new ShareSasBuilder(permissions, expiresOn)
            {
                ShareName = ShareName,
                FilePath = Path
            });

        /// <summary>
        /// The <see cref="GenerateSasUri(ShareSasBuilder)"/> returns a
        /// <see cref="Uri"/> that generates a Share File Service
        /// Shared Access Signature (SAS) Uri based on the Client properties
        /// and and builder. The SAS is signed by the shared key credential
        /// of the client.
        ///
        /// To check if the client is able to sign a Service Sas see
        /// <see cref="CanGenerateSasUri"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas">
        /// Constructing a Service SAS</see>.
        /// </summary>
        /// <param name="builder">
        /// Used to generate a Shared Access Signature (SAS)
        /// </param>
        /// <returns>
        /// A <see cref="ShareSasBuilder"/> on successfully deleting.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Uri GenerateSasUri(ShareSasBuilder builder)
        {
            builder = builder ?? throw Errors.ArgumentNull(nameof(builder));
            if (!builder.ShareName.Equals(ShareName, StringComparison.InvariantCulture))
            {
                throw Errors.SasNamesNotMatching(
                    nameof(builder.ShareName),
                    nameof(ShareSasBuilder),
                    nameof(ShareName));
            }
            if (!builder.FilePath.Equals(Path, StringComparison.InvariantCulture))
            {
                throw Errors.SasNamesNotMatching(
                    nameof(builder.FilePath),
                    nameof(ShareSasBuilder),
                    nameof(Path));
            }
            ShareUriBuilder sasUri = new ShareUriBuilder(Uri)
            {
                Query = builder.ToSasQueryParameters(SharedKeyCredential).ToString()
            };
            return sasUri.ToUri();
        }
        #endregion
    }
}
