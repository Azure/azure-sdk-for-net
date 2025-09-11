// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Shared;
using Azure.Storage.Sas;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Azure.Storage.Common;
using System.Net.Http.Headers;

#pragma warning disable SA1402  // File may only contain a single type

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
        /// <see cref="ShareClientConfiguration"/>.
        /// </summary>
        private readonly ShareClientConfiguration _clientConfiguration;

        /// <summary>
        /// <see cref="ShareClientConfiguration"/>.
        /// </summary>
        internal virtual ShareClientConfiguration ClientConfiguration => _clientConfiguration;

        /// <summary>
        /// FileRestClient.
        /// </summary>
        private readonly FileRestClient _fileRestClient;

        /// <summary>
        /// FileRestClient.
        /// </summary>
        internal virtual FileRestClient FileRestClient => _fileRestClient;

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
        /// Indicates whether the client is able to generate a SAS uri.
        /// Client can generate a SAS url if it is authenticated with a <see cref="StorageSharedKeyCredential"/>.
        /// </summary>
        public virtual bool CanGenerateSasUri => ClientConfiguration.SharedKeyCredential != null;

        //const string filetype = "file";

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
        public ShareFileClient(
            string connectionString,
            string shareName,
            string filePath,
            ShareClientOptions options)
        {
            Argument.AssertNotNullOrWhiteSpace(shareName, nameof(shareName));
            Argument.AssertNotNullOrWhiteSpace(filePath, nameof(filePath));
            options ??= new ShareClientOptions();
            var conn = StorageConnectionString.Parse(connectionString);
            ShareErrors.AssertNotDevelopment(conn, nameof(connectionString));
            ShareUriBuilder uriBuilder =
                new ShareUriBuilder(conn.FileEndpoint)
                {
                    ShareName = shareName,
                    DirectoryOrFilePath = filePath
                };
            _uri = uriBuilder.ToUri();
            _accountName = conn.AccountName;
            _shareName = shareName;
            _path = filePath;
            _clientConfiguration = new ShareClientConfiguration(
                pipeline: options.Build(conn.Credentials),
                sharedKeyCredential: conn.Credentials as StorageSharedKeyCredential,
                clientDiagnostics: new ClientDiagnostics(options),
                clientOptions: options);
            _fileRestClient = BuildFileRestClient(_uri);
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
        public ShareFileClient(
            Uri fileUri,
            ShareClientOptions options = default)
            : this(
                  fileUri: fileUri,
                  authentication: (HttpPipelinePolicy)null,
                  options: options,
                  storageSharedKeyCredential: null,
                  sasCredential: null,
                  tokenCredential: null)
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
        public ShareFileClient(
            Uri fileUri,
            StorageSharedKeyCredential credential,
            ShareClientOptions options = default)
            : this(
                  fileUri: fileUri,
                  authentication: credential.AsPolicy(),
                  options: options,
                  storageSharedKeyCredential: credential,
                  sasCredential: null,
                  tokenCredential: null)
        {
            _accountName ??= credential?.AccountName;
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
        public ShareFileClient(
            Uri fileUri,
            AzureSasCredential credential,
            ShareClientOptions options = default)
            : this(
                  fileUri,
                  credential.AsPolicy<ShareUriBuilder>(fileUri),
                  options,
                  storageSharedKeyCredential: null,
                  sasCredential: credential,
                  tokenCredential: null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareFileClient"/>
        /// class.
        ///
        /// Note that <see cref="ShareClientOptions.ShareTokenIntent"/> is currently required for token authentication.
        /// </summary>
        /// <param name="fileUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the share, and the path of the
        /// file.
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public ShareFileClient(
            Uri fileUri,
            TokenCredential credential,
            ShareClientOptions options = default)
            : this(
                  fileUri: fileUri,
                  authentication: credential.AsPolicy(
                    string.IsNullOrEmpty(options?.Audience?.ToString()) ? ShareAudience.DefaultAudience.CreateDefaultScope() : options.Audience.Value.CreateDefaultScope(),
                    options),
                  options: options ?? new ShareClientOptions(),
                  storageSharedKeyCredential: null,
                  sasCredential: null,
                  tokenCredential: credential)
        {
            Errors.VerifyHttpsTokenAuth(fileUri);
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
        /// <param name="diagnostics">
        /// The diagnostics from the parent client.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        internal ShareFileClient(
            Uri fileUri,
            ClientDiagnostics diagnostics,
            ShareClientOptions options)
        {
            Argument.AssertNotNull(fileUri, nameof(fileUri));
            options ??= new ShareClientOptions();
            _uri = fileUri;

            _clientConfiguration = new ShareClientConfiguration(
                pipeline: options.Build(),
                sharedKeyCredential: default,
                clientDiagnostics: diagnostics,
                clientOptions: options);

            _fileRestClient = BuildFileRestClient(fileUri);
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
        /// <param name="sasCredential">
        /// The SAS credential used to sign requests.
        /// </param>
        /// <param name="tokenCredential">
        /// The token credential used to sign requests.
        /// </param>
        internal ShareFileClient(
            Uri fileUri,
            HttpPipelinePolicy authentication,
            ShareClientOptions options,
            StorageSharedKeyCredential storageSharedKeyCredential,
            AzureSasCredential sasCredential,
            TokenCredential tokenCredential)
        {
            Argument.AssertNotNull(fileUri, nameof(fileUri));
            options ??= new ShareClientOptions();
            _uri = fileUri;
            _clientConfiguration = new ShareClientConfiguration(
                pipeline: options.Build(authentication),
                sharedKeyCredential: storageSharedKeyCredential,
                sasCredential: sasCredential,
                tokenCredential: tokenCredential,
                clientDiagnostics: new ClientDiagnostics(options),
                clientOptions: options)
            {
                Audience = options.Audience ?? ShareAudience.DefaultAudience,
            };
            _fileRestClient = BuildFileRestClient(fileUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareFileClient"/> class.
        /// </summary>
        /// <param name="fileUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the share, and the path of the file.
        /// </param>
        /// <param name="clientConfiguration">
        /// <see cref="ShareClientConfiguration"/>.
        /// </param>
        internal ShareFileClient(
            Uri fileUri,
            ShareClientConfiguration clientConfiguration)
        {
            _uri = fileUri;
            _clientConfiguration = clientConfiguration;
            _fileRestClient = BuildFileRestClient(fileUri);
        }

        private FileRestClient BuildFileRestClient(Uri uri)
        {
            return new FileRestClient(
                clientDiagnostics: _clientConfiguration.ClientDiagnostics,
                pipeline: _clientConfiguration.Pipeline,
                url: uri.AbsoluteUri,
                version: _clientConfiguration.ClientOptions.Version.ToVersionString(),
                fileRequestIntent: _clientConfiguration.ClientOptions.ShareTokenIntent,
                allowTrailingDot: _clientConfiguration.ClientOptions.AllowTrailingDot,
                fileRangeWriteFromUrl: "update",
                allowSourceTrailingDot: _clientConfiguration.ClientOptions.AllowSourceTrailingDot);
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
            return new ShareFileClient(builder.ToUri(), ClientConfiguration);
        }

        /// <summary>
        /// Sets the various name fields if they are currently null.
        /// </summary>
        private void SetNameFieldsIfNull()
        {
            if (_name == null || _shareName == null || _accountName == null || _path == null)
            {
                var builder = new ShareUriBuilder(Uri);
                _name ??= builder.LastDirectoryOrFileName;
                _shareName ??= builder.ShareName;
                _accountName ??= builder.AccountName;
                _path ??= builder.DirectoryOrFilePath;
            }
        }

        #region internal static accessors for Azure.Storage.DataMovement.Blobs
        /// <summary>
        /// Get a <see cref="ShareFileClient"/>'s <see cref="HttpAuthorization"/>
        /// for passing the authorization when performing service to service copy
        /// where OAuth is necessary to authenticate the source.
        /// </summary>
        /// <param name="client">
        /// The storage client which to generate the
        /// authorization header off of.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The BlobServiceClient's HttpPipeline.</returns>
        protected static async Task<HttpAuthorization> GetCopyAuthorizationHeaderAsync(
            ShareFileClient client,
            CancellationToken cancellationToken = default)
        {
            if (client.ClientConfiguration.TokenCredential != default)
            {
                AccessToken accessToken = await client.ClientConfiguration.TokenCredential.GetTokenAsync(
                    new TokenRequestContext(new string[] { client.ClientConfiguration.Audience.CreateDefaultScope() }),
                    cancellationToken).ConfigureAwait(false);
                return new HttpAuthorization(
                    Constants.CopyHttpAuthorization.BearerScheme,
                    accessToken.Token);
            }
            return default;
        }
        #endregion internal static accessors for Azure.Storage.DataMovement.Blobs

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
        /// Required. Specifies the maximum size for the file in bytes.  The max supported file size is 4 TiB.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<ShareFileInfo> Create(
            long maxSize,
            ShareFileCreateOptions options = default,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            CreateInternal(
                maxSize,
                httpHeaders: options?.HttpHeaders,
                metadata: options?.Metadata,
                smbProperties: options?.SmbProperties,
                filePermission: options?.FilePermission?.Permission,
                filePermissionFormat: options?.FilePermission?.PermissionFormat,
                posixProperties: options?.PosixProperties,
                filePropertySemantics: options?.PropertySemantics,
                content: options?.Content,
                transferValidationOverride: options?.TransferValidation,
                progressHandler: options?.ProgressHandler,
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
        /// Required. Specifies the maximum size for the file in bytes.  The max supported file size is 4 TiB.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<ShareFileInfo>> CreateAsync(
            long maxSize,
            ShareFileCreateOptions options = default,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await CreateInternal(
                maxSize,
                httpHeaders: options?.HttpHeaders,
                metadata: options?.Metadata,
                smbProperties: options?.SmbProperties,
                filePermission: options?.FilePermission?.Permission,
                filePermissionFormat: options?.FilePermission?.PermissionFormat,
                posixProperties: options?.PosixProperties,
                filePropertySemantics: options?.PropertySemantics,
                content: options?.Content,
                transferValidationOverride: options?.TransferValidation,
                progressHandler: options?.ProgressHandler,
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
        /// Required. Specifies the maximum size for the file in bytes.  The max supported file size is 4 TiB.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<ShareFileInfo> Create(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            long maxSize,
            ShareFileHttpHeaders httpHeaders,
            Metadata metadata,
            FileSmbProperties smbProperties,
            string filePermission,
            ShareFileRequestConditions conditions,
            CancellationToken cancellationToken) =>
            CreateInternal(
                maxSize,
                httpHeaders,
                metadata,
                smbProperties,
                filePermission,
                filePermissionFormat: default,
                posixProperties: default,
                filePropertySemantics: default,
                content: default,
                transferValidationOverride: default,
                progressHandler: default,
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
        /// Required. Specifies the maximum size for the file in bytes.  The max supported file size is 4 TiB.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
                filePermissionFormat: default,
                posixProperties: default,
                filePropertySemantics: default,
                content: default,
                transferValidationOverride: default,
                progressHandler: default,
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
        /// Required. Specifies the maximum size for the file in bytes.  The max supported file size is 4 TiB.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<ShareFileInfo>> CreateAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            long maxSize,
            ShareFileHttpHeaders httpHeaders,
            Metadata metadata,
            FileSmbProperties smbProperties,
            string filePermission,
            ShareFileRequestConditions conditions,
            CancellationToken cancellationToken) =>
            await CreateInternal(
                maxSize,
                httpHeaders,
                metadata,
                smbProperties,
                filePermission,
                filePermissionFormat: default,
                posixProperties: default,
                filePropertySemantics: default,
                content: default,
                transferValidationOverride: default,
                progressHandler: default,
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
        /// Required. Specifies the maximum size for the file in bytes.  The max supported file size is 4 TiB.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
                filePermissionFormat: default,
                posixProperties: default,
                filePropertySemantics: default,
                content: default,
                transferValidationOverride: default,
                progressHandler: default,
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
        /// Required. Specifies the maximum size for the file in bytes.  The max supported file size is 4 TiB.
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
        /// <param name="filePermissionFormat">
        /// Optional file permission format.
        /// </param>
        /// <param name="posixProperties">
        /// Optional NFS properties.
        /// </param>
        /// <param name="filePropertySemantics">
        /// Optional, only applicable to SMB files.
        /// How attributes and permissions should be set on the file.
        /// </param>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the range to upload.
        /// </param>
        /// <param name="transferValidationOverride">
        /// Optional override for transfer validation on upload.
        /// </param>
        /// <param name="progressHandler">
        /// Progress handler for upload operation.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<ShareFileInfo>> CreateInternal(
            long maxSize,
            ShareFileHttpHeaders httpHeaders,
            Metadata metadata,
            FileSmbProperties smbProperties,
            string filePermission,
            FilePermissionFormat? filePermissionFormat,
            FilePosixProperties posixProperties,
            FilePropertySemantics? filePropertySemantics,
            Stream content,
            UploadTransferValidationOptions transferValidationOverride,
            IProgress<long> progressHandler,
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken,
            string operationName = default)
        {
            UploadTransferValidationOptions validationOptions = transferValidationOverride ?? ClientConfiguration.TransferValidation.Upload;
            ShareErrors.AssertAlgorithmSupport(validationOptions?.ChecksumAlgorithm);

            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(maxSize)}: {maxSize}\n" +
                    $"{nameof(httpHeaders)}: {httpHeaders}");

                operationName ??= $"{nameof(ShareFileClient)}.{nameof(Create)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);

                try
                {
                    scope.Start();

                    Errors.VerifyStreamPosition(content, nameof(content));

                    // compute hash BEFORE attaching progress handler
                    ContentHasher.GetHashResult hashResult = null;
                    if (content != null)
                    {
                        hashResult = await ContentHasher.GetHashOrDefaultInternal(
                            content,
                            validationOptions,
                            async,
                            cancellationToken).ConfigureAwait(false);
                    }

                    content = content?.WithNoDispose().WithProgress(progressHandler);

                    FileSmbProperties smbProps = smbProperties ?? new FileSmbProperties();

                    ShareExtensions.AssertValidFilePermissionAndKey(filePermission, smbProps.FilePermissionKey);

                    ResponseWithHeaders<FileCreateHeaders> response;

                    if (async)
                    {
                        response = await FileRestClient.CreateAsync(
                            fileContentLength: maxSize,
                            contentLength: (content?.Length - content?.Position),
                            fileAttributes: smbProps.FileAttributes.ToAttributesString(),
                            fileCreationTime: smbProps.FileCreatedOn.ToFileDateTimeString(),
                            fileLastWriteTime: smbProps.FileLastWrittenOn.ToFileDateTimeString(),
                            fileChangeTime: smbProps.FileChangedOn.ToFileDateTimeString(),
                            owner: posixProperties?.Owner,
                            group: posixProperties?.Group,
                            fileMode: posixProperties?.FileMode?.ToOctalFileMode(),
                            nfsFileType: posixProperties?.FileType,
                            contentMD5: hashResult?.MD5AsArray,
                            filePropertySemantics: filePropertySemantics,
                            optionalbody: content,
                            metadata: metadata,
                            filePermission: filePermission,
                            filePermissionFormat: filePermissionFormat,
                            filePermissionKey: smbProps.FilePermissionKey,
                            fileHttpHeaders: httpHeaders.ToFileHttpHeaders(),
                            shareFileRequestConditions: conditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = FileRestClient.Create(
                            fileContentLength: maxSize,
                            contentLength: (content?.Length - content?.Position),
                            fileAttributes: smbProps.FileAttributes.ToAttributesString(),
                            fileCreationTime: smbProps.FileCreatedOn.ToFileDateTimeString(),
                            fileLastWriteTime: smbProps.FileLastWrittenOn.ToFileDateTimeString(),
                            fileChangeTime: smbProps.FileChangedOn.ToFileDateTimeString(),
                            owner: posixProperties?.Owner,
                            group: posixProperties?.Group,
                            fileMode: posixProperties?.FileMode?.ToOctalFileMode(),
                            nfsFileType: posixProperties?.FileType,
                            contentMD5: hashResult?.MD5AsArray,
                            filePropertySemantics: filePropertySemantics,
                            optionalbody: content,
                            metadata: metadata,
                            filePermission: filePermission,
                            filePermissionFormat: filePermissionFormat,
                            filePermissionKey: smbProps.FilePermissionKey,
                            fileHttpHeaders: httpHeaders.ToFileHttpHeaders(),
                            shareFileRequestConditions: conditions,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToShareFileInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareFileClient));
                    scope.Dispose();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<bool>> ExistsInternal(
            bool async,
            CancellationToken cancellationToken,
            string operationName = default)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
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
                    ClientConfiguration.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareFileClient));
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<bool>> DeleteIfExistsInternal(
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
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
                    ClientConfiguration.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareFileClient));
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
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<ShareFileCopyInfo> StartCopy(
            Uri sourceUri,
            ShareFileCopyOptions options = default,
            CancellationToken cancellationToken = default) =>
            StartCopyInternal(
                sourceUri: sourceUri,
                metadata: options?.Metadata,
                smbProperties: options?.SmbProperties,
                filePermission: options?.FilePermission,
                filePermissionFormat: options?.PermissionFormat,
                filePermissionCopyMode: options?.FilePermissionCopyMode,
                ignoreReadOnly: options?.IgnoreReadOnly,
                setArchiveAttribute: options?.Archive,
                conditions: options?.Conditions,
                copyableFileSmbProperties: options?.SmbPropertiesToCopy,
                posixProperties: options?.PosixProperties,
                modeCopyMode: options?.ModeCopyMode,
                ownerCopyMode: options?.OwnerCopyMode,
                async: false,
                cancellationToken: cancellationToken)
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<ShareFileCopyInfo> StartCopy(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Uri sourceUri,
            Metadata metadata,
            FileSmbProperties smbProperties,
            string filePermission,
            PermissionCopyMode? filePermissionCopyMode,
            bool? ignoreReadOnly,
            bool? setArchiveAttribute,
            ShareFileRequestConditions conditions,
            CancellationToken cancellationToken) =>
            StartCopyInternal(
                sourceUri,
                metadata,
                smbProperties,
                filePermission,
                filePermissionFormat: default,
                filePermissionCopyMode,
                ignoreReadOnly,
                setArchiveAttribute,
                conditions,
                copyableFileSmbProperties: default,
                posixProperties: default,
                modeCopyMode: default,
                ownerCopyMode: default,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
                filePermissionFormat: default,
                filePermissionCopyMode: default,
                ignoreReadOnly: default,
                setArchiveAttribute: default,
                conditions: default,
                copyableFileSmbProperties: default,
                posixProperties: default,
                modeCopyMode: default,
                ownerCopyMode: default,
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
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<ShareFileCopyInfo>> StartCopyAsync(
            Uri sourceUri,
            ShareFileCopyOptions options = default,
            CancellationToken cancellationToken = default) =>
            await StartCopyInternal(
                sourceUri: sourceUri,
                metadata: options?.Metadata,
                smbProperties: options?.SmbProperties,
                filePermission: options?.FilePermission,
                filePermissionFormat: options?.PermissionFormat,
                filePermissionCopyMode: options?.FilePermissionCopyMode,
                ignoreReadOnly: options?.IgnoreReadOnly,
                setArchiveAttribute: options?.Archive,
                conditions: options?.Conditions,
                copyableFileSmbProperties: options?.SmbPropertiesToCopy,
                posixProperties: options?.PosixProperties,
                modeCopyMode: options?.ModeCopyMode,
                ownerCopyMode: options?.OwnerCopyMode,
                async: true,
                cancellationToken: cancellationToken).
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<ShareFileCopyInfo>> StartCopyAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Uri sourceUri,
            Metadata metadata,
            FileSmbProperties smbProperties,
            string filePermission,
            PermissionCopyMode? filePermissionCopyMode,
            bool? ignoreReadOnly,
            bool? setArchiveAttribute,
            ShareFileRequestConditions conditions,
            CancellationToken cancellationToken) =>
            await StartCopyInternal(
                sourceUri,
                metadata,
                smbProperties,
                filePermission,
                filePermissionFormat: default,
                filePermissionCopyMode,
                ignoreReadOnly,
                setArchiveAttribute,
                conditions,
                copyableFileSmbProperties: default,
                posixProperties: default,
                modeCopyMode: default,
                ownerCopyMode: default,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
                filePermissionFormat: default,
                filePermissionCopyMode: default,
                ignoreReadOnly: default,
                setArchiveAttribute: default,
                conditions: default,
                copyableFileSmbProperties: default,
                posixProperties: default,
                modeCopyMode: default,
                ownerCopyMode: default,
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
        /// <param name="filePermissionFormat">
        /// Optional file permission format.
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
        /// <param name="copyableFileSmbProperties">
        /// SMB properties to copy from the source file.
        /// </param>
        /// <param name="posixProperties">
        /// NFS files only.  NFS properties to set on the destination file.
        /// </param>
        /// <param name="modeCopyMode">
        /// Optional, only applicable to NFS Files.
        /// If not populated, the desination file will have the default File Mode.
        /// </param>
        /// <param name="ownerCopyMode">
        /// Optional, only applicable to NFS Files.
        /// If not populated, the desination file will have the default Owner and Group.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<ShareFileCopyInfo>> StartCopyInternal(
            Uri sourceUri,
            Metadata metadata,
            FileSmbProperties smbProperties,
            string filePermission,
            FilePermissionFormat? filePermissionFormat,
            PermissionCopyMode? filePermissionCopyMode,
            bool? ignoreReadOnly,
            bool? setArchiveAttribute,
            ShareFileRequestConditions conditions,
            CopyableFileSmbProperties? copyableFileSmbProperties,
            FilePosixProperties posixProperties,
            ModeCopyMode? modeCopyMode,
            OwnerCopyMode? ownerCopyMode,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(sourceUri)}: {sourceUri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareFileClient)}.{nameof(StartCopy)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<FileStartCopyHeaders> response;

                    if ((copyableFileSmbProperties.GetValueOrDefault() & CopyableFileSmbProperties.FileAttributes) == CopyableFileSmbProperties.FileAttributes
                        && smbProperties?.FileAttributes != null)
                    {
                        throw new ArgumentException($"{nameof(ShareFileCopyOptions)}.{nameof(ShareFileCopyOptions.SmbProperties)}.{nameof(ShareFileCopyOptions.SmbProperties.FileAttributes)} and {nameof(ShareFileCopyOptions)}.{nameof(CopyableFileSmbProperties)}.{nameof(CopyableFileSmbProperties.FileAttributes)} cannot both be set.");
                    }

                    if ((copyableFileSmbProperties.GetValueOrDefault() & CopyableFileSmbProperties.CreatedOn) == CopyableFileSmbProperties.CreatedOn
                        && smbProperties?.FileCreatedOn != null)
                    {
                        throw new ArgumentException($"{nameof(ShareFileCopyOptions)}.{nameof(ShareFileCopyOptions.SmbProperties)}.{nameof(ShareFileCopyOptions.SmbProperties.FileCreatedOn)} and {nameof(ShareFileCopyOptions)}.{nameof(CopyableFileSmbProperties)}.{nameof(CopyableFileSmbProperties.CreatedOn)} cannot both be set.");
                    }

                    if ((copyableFileSmbProperties.GetValueOrDefault() & CopyableFileSmbProperties.LastWrittenOn) == CopyableFileSmbProperties.LastWrittenOn
                        && smbProperties?.FileLastWrittenOn != null)
                    {
                        throw new ArgumentException($"{nameof(ShareFileCopyOptions)}.{nameof(ShareFileCopyOptions.SmbProperties)}.{nameof(ShareFileCopyOptions.SmbProperties.FileLastWrittenOn)} and {nameof(ShareFileCopyOptions)}.{nameof(CopyableFileSmbProperties)}.{nameof(CopyableFileSmbProperties.LastWrittenOn)} cannot both be set.");
                    }

                    if ((copyableFileSmbProperties.GetValueOrDefault() & CopyableFileSmbProperties.ChangedOn) == CopyableFileSmbProperties.ChangedOn
                        && smbProperties?.FileChangedOn != null)
                    {
                        throw new ArgumentException($"{nameof(ShareFileCopyOptions)}.{nameof(ShareFileCopyOptions.SmbProperties)}.{nameof(ShareFileCopyOptions.SmbProperties.FileChangedOn)} and {nameof(ShareFileCopyOptions)}.{nameof(CopyableFileSmbProperties)}.{nameof(CopyableFileSmbProperties.ChangedOn)} cannot both be set.");
                    }

                    string fileAttributes = null;
                    if ((copyableFileSmbProperties.GetValueOrDefault() & CopyableFileSmbProperties.FileAttributes)
                        == CopyableFileSmbProperties.FileAttributes)
                    {
                        fileAttributes = Constants.File.Source;
                    }
                    else
                    {
                        fileAttributes = smbProperties?.FileAttributes.ToAttributesString();
                    }

                    string fileCreatedOn = null;
                    if ((copyableFileSmbProperties.GetValueOrDefault() & CopyableFileSmbProperties.CreatedOn)
                        == CopyableFileSmbProperties.CreatedOn)
                    {
                        fileCreatedOn = Constants.File.Source;
                    }
                    else
                    {
                        fileCreatedOn = smbProperties?.FileCreatedOn.ToFileDateTimeString();
                    }

                    string fileLastWrittenOn = null;
                    if ((copyableFileSmbProperties.GetValueOrDefault() & CopyableFileSmbProperties.LastWrittenOn)
                        == CopyableFileSmbProperties.LastWrittenOn)
                    {
                        fileLastWrittenOn = Constants.File.Source;
                    }
                    else
                    {
                        fileLastWrittenOn = smbProperties?.FileLastWrittenOn.ToFileDateTimeString();
                    }

                    string fileChangedOn = null;
                    if ((copyableFileSmbProperties.GetValueOrDefault() & CopyableFileSmbProperties.ChangedOn)
                        == CopyableFileSmbProperties.ChangedOn)
                    {
                        fileChangedOn = Constants.File.Source;
                    }
                    else
                    {
                        fileChangedOn = smbProperties?.FileChangedOn.ToFileDateTimeString();
                    }

                    CopyFileSmbInfo copyFileSmbInfo = new CopyFileSmbInfo
                    {
                        FilePermissionCopyMode = filePermissionCopyMode,
                        IgnoreReadOnly = ignoreReadOnly,
                        FileAttributes = fileAttributes,
                        FileCreationTime = fileCreatedOn,
                        FileLastWriteTime = fileLastWrittenOn,
                        FileChangeTime = fileChangedOn,
                        SetArchiveAttribute = setArchiveAttribute
                    };

                    ShareUriBuilder uriBuilder = new ShareUriBuilder(sourceUri);

                    if (async)
                    {
                        response = await FileRestClient.StartCopyAsync(
                            copySource: uriBuilder.ToString(),
                            metadata: metadata,
                            filePermission: filePermission,
                            filePermissionFormat: filePermissionFormat,
                            filePermissionKey: smbProperties?.FilePermissionKey,
                            owner: posixProperties?.Owner,
                            group: posixProperties?.Group,
                            fileMode: posixProperties?.FileMode?.ToOctalFileMode(),
                            fileModeCopyMode: modeCopyMode,
                            fileOwnerCopyMode: ownerCopyMode,
                            copyFileSmbInfo: copyFileSmbInfo,
                            shareFileRequestConditions: conditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = FileRestClient.StartCopy(
                            copySource: uriBuilder.ToString(),
                            metadata: metadata,
                            filePermission: filePermission,
                            filePermissionFormat: filePermissionFormat,
                            filePermissionKey: smbProperties?.FilePermissionKey,
                            owner: posixProperties?.Owner,
                            group: posixProperties?.Group,
                            fileMode: posixProperties?.FileMode?.ToOctalFileMode(),
                            fileModeCopyMode: modeCopyMode,
                            fileOwnerCopyMode: ownerCopyMode,
                            copyFileSmbInfo: copyFileSmbInfo,
                            shareFileRequestConditions: conditions,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToShareFileCopyInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareFileClient));
                    scope.Dispose();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response> AbortCopyInternal(
            string copyId,
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(copyId)}: {copyId}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareFileClient)}.{nameof(AbortCopy)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<FileAbortCopyHeaders> response;

                    if (async)
                    {
                        response = await FileRestClient.AbortCopyAsync(
                            copyId: copyId,
                            shareFileRequestConditions: conditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = FileRestClient.AbortCopy(
                            copyId: copyId,
                            shareFileRequestConditions: conditions,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareFileClient));
                    scope.Dispose();
                }
            }
        }
        #endregion AbortCopy

        #region Download
        /// <summary>
        /// The <see cref="Download(ShareFileDownloadOptions, CancellationToken)"/>
        /// operation reads or downloads a file from the system, including its metadata and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-file">
        /// Get File</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<ShareFileDownloadInfo> Download(
            ShareFileDownloadOptions options = default,
            CancellationToken cancellationToken = default) =>
            DownloadInternal(
                options?.Range ?? default,
                options?.TransferValidation,
                options?.Conditions,
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// The <see cref="DownloadAsync(ShareFileDownloadOptions, CancellationToken)"/>
        /// operation reads or downloads a file from the system, including its metadata and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-file">
        /// Get File</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<ShareFileDownloadInfo>> DownloadAsync(
            ShareFileDownloadOptions options = default,
            CancellationToken cancellationToken = default) =>
            await DownloadInternal(
                options?.Range ?? default,
                options?.TransferValidation,
                options?.Conditions,
                async: true,
                cancellationToken).ConfigureAwait(false);

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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<ShareFileDownloadInfo> Download(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            HttpRange range,
            bool rangeGetContentHash,
            ShareFileRequestConditions conditions,
            CancellationToken cancellationToken)
        {
            return DownloadInternal(
                range,
                rangeGetContentHash
                    ? new DownloadTransferValidationOptions { ChecksumAlgorithm = StorageChecksumAlgorithm.MD5 }
                    : default,
                conditions,
                async: false,
                cancellationToken)
                .EnsureCompleted();
        }

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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ShareFileDownloadInfo> Download(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            HttpRange range,
            bool rangeGetContentHash,
            CancellationToken cancellationToken)
        {
            return DownloadInternal(
                range,
                rangeGetContentHash
                    ? new DownloadTransferValidationOptions { ChecksumAlgorithm = StorageChecksumAlgorithm.MD5 }
                    : default,
                conditions: default,
                async: false,
                cancellationToken)
                .EnsureCompleted();
        }

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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<ShareFileDownloadInfo>> DownloadAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            HttpRange range,
            bool rangeGetContentHash,
            ShareFileRequestConditions conditions,
            CancellationToken cancellationToken)
        {
            return await DownloadInternal(
                range,
                rangeGetContentHash
                    ? new DownloadTransferValidationOptions { ChecksumAlgorithm = StorageChecksumAlgorithm.MD5 }
                    : default,
                conditions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);
        }

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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ShareFileDownloadInfo>> DownloadAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            HttpRange range,
            bool rangeGetContentHash,
            CancellationToken cancellationToken)
        {
            return await DownloadInternal(
                range,
                rangeGetContentHash
                    ? new DownloadTransferValidationOptions { ChecksumAlgorithm = StorageChecksumAlgorithm.MD5 }
                    : default,
                conditions: default,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// The <see cref="DownloadInternal"/> operation reads or downloads a file from the system, including its metadata and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-file">
        /// Get File</see>.
        /// </summary>
        /// <param name="range">
        /// Range to download.
        /// </param>
        /// <param name="transferValidationOverride">
        /// Override for client-configured transfer validation options.
        /// </param>
        /// <param name="conditions">
        /// Request conditions for download.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<ShareFileDownloadInfo>> DownloadInternal(
            HttpRange range,
            DownloadTransferValidationOptions transferValidationOverride,
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            DownloadTransferValidationOptions validationOptions = transferValidationOverride ?? ClientConfiguration.TransferValidation.Download;

            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareFileClient)}.{nameof(Download)}");

                try
                {
                    scope.Start();

                    // Start downloading the file
                    (Response<ShareFileDownloadInfo> initialResponse, Stream stream) = await StartDownloadAsync(
                        range,
                        validationOptions,
                        conditions,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    ETag etag = initialResponse.GetRawResponse().Headers.ETag.GetValueOrDefault();

                    // Wrap the response Content in a RetriableStream so we
                    // can return it before it's finished downloading, but still
                    // allow retrying if it fails.
                    initialResponse.Value.Content = RetriableStream.Create(
                        stream,
                        startOffset =>
                        {
                            (Response<ShareFileDownloadInfo> Response, Stream ContentStream) = StartDownloadAsync(
                                range,
                                validationOptions,
                                conditions,
                                startOffset,
                                async,
                                cancellationToken)
                                .EnsureCompleted();
                            if (etag != Response.GetRawResponse().Headers.ETag)
                            {
                                throw new ShareFileModifiedException(
                                    "File has been modified concurrently",
                                    Uri, etag, Response.GetRawResponse().Headers.ETag.GetValueOrDefault(), range);
                            }
                            return ContentStream;
                        },
                        async startOffset =>
                        {
                            (Response<ShareFileDownloadInfo> Response, Stream ContentStream) = await StartDownloadAsync(
                                range,
                                validationOptions,
                                conditions,
                                startOffset,
                                async,
                                cancellationToken)
                                .ConfigureAwait(false);
                            if (etag != Response.GetRawResponse().Headers.ETag)
                            {
                                throw new ShareFileModifiedException(
                                    "File has been modified concurrently",
                                    Uri, etag, Response.GetRawResponse().Headers.ETag.GetValueOrDefault(), range);
                            }
                            return ContentStream;
                        },
                        ClientConfiguration.Pipeline.ResponseClassifier,
                        Constants.MaxReliabilityRetries);

                    // buffer response stream and ensure it matches the transactional hash if any
                    // Storage will not return a hash for payload >4MB, so this buffer is capped similarly
                    // hashing is opt-in, so this buffer is part of that opt-in
                    if (validationOptions != default && validationOptions.ChecksumAlgorithm != StorageChecksumAlgorithm.None && validationOptions.AutoValidateChecksum)
                    {
                        // safe-buffer; transactional hash download limit well below maxInt
                        var readDestStream = new MemoryStream((int)initialResponse.Value.ContentLength);
                        if (async)
                        {
#if NET6_0_OR_GREATER
                            await initialResponse.Value.Content.CopyToAsync(readDestStream, cancellationToken).ConfigureAwait(false);
#else
                            await initialResponse.Value.Content.CopyToAsync(readDestStream).ConfigureAwait(false);
#endif
                        }
                        else
                        {
                            initialResponse.Value.Content.CopyTo(readDestStream);
                        }
                        readDestStream.Position = 0;

                        await ContentHasher.AssertResponseHashMatchInternal(
                            readDestStream,
                            validationOptions.ChecksumAlgorithm,
                            initialResponse.GetRawResponse(),
                            async,
                            cancellationToken).ConfigureAwait(false);

                        // we've consumed the network stream to hash it; return buffered stream to the user
                        initialResponse.Value.Content = readDestStream;
                    }

                    return initialResponse;
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareFileClient));
                    scope.Dispose();
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
        /// Range to download.
        /// </param>
        /// <param name="transferValidationOverride">
        /// Transfer validation options to use. This method assumes defaults and overrides have already been checked
        /// and will use exactly what is provided through this argument.
        /// </param>
        /// <param name="conditions">
        /// Request conditions for download.
        /// </param>
        /// <param name="startOffset">
        /// Optional. Starting offset to request - in the event of a retry.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// <see cref="Response{ShareFileDownloadInfo}"/> and a <see cref="Stream"/>.
        /// </returns>
        private async Task<(Response<ShareFileDownloadInfo> Response, Stream ContentStream)> StartDownloadAsync(
            HttpRange range,
            DownloadTransferValidationOptions transferValidationOverride,
            ShareFileRequestConditions conditions,
            long startOffset = 0,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            ShareErrors.AssertAlgorithmSupport(transferValidationOverride?.ChecksumAlgorithm);

            // calculation gets illegible with null coalesce; just pre-initialize
            var pageRange = range;
            pageRange = new HttpRange(
                pageRange.Offset + startOffset,
                pageRange.Length.HasValue ?
                    pageRange.Length.Value - startOffset :
                    (long?)null);
            ClientConfiguration.Pipeline.LogTrace($"Download {Uri} with range: {pageRange}");

            ResponseWithHeaders<Stream, FileDownloadHeaders> response;

            if (async)
            {
                response = await FileRestClient.DownloadAsync(
                    range: pageRange == default ? null : pageRange.ToString(),
                    rangeGetContentMD5: transferValidationOverride?.ChecksumAlgorithm.ResolveAuto() == StorageChecksumAlgorithm.MD5 ? true : null,
                    shareFileRequestConditions: conditions,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }
            else
            {
                response = FileRestClient.Download(
                    range: pageRange == default ? null : pageRange.ToString(),
                    rangeGetContentMD5: transferValidationOverride?.ChecksumAlgorithm.ResolveAuto() == StorageChecksumAlgorithm.MD5 ? true : null,
                    shareFileRequestConditions: conditions,
                    cancellationToken: cancellationToken);
            }

            return (
                Response.FromValue(
                    response.ToShareFileDownloadInfo(),
                    response.GetRawResponse()),
                response.Value);
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
        /// <remarks>
        /// The stream returned might throw <see cref="ShareFileModifiedException"/>
        /// if the file is concurrently modified and <see cref="ShareFileOpenReadOptions"/> don't allow modification.
        ///
        /// A <see cref="RequestFailedException" /> will be thrown if other failures occur.
        /// </remarks>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Stream OpenRead(
#pragma warning restore AZC0015 // Unexpected client method return type.
            ShareFileOpenReadOptions options,
            CancellationToken cancellationToken = default)
            => OpenReadInteral(
                options?.Position ?? 0,
                options?.BufferSize,
                options?.Conditions,
                allowModifications: options?.AllowModifications ?? false,
                options?.TransferValidation,
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
        /// <remarks>
        /// The stream returned might throw <see cref="ShareFileModifiedException"/>
        /// if the file is concurrently modified and <see cref="ShareFileOpenReadOptions"/> don't allow modification.
        ///
        /// A <see cref="RequestFailedException" /> will be thrown if other failures occur.
        /// </remarks>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Stream> OpenReadAsync(
#pragma warning restore AZC0015 // Unexpected client method return type.
            ShareFileOpenReadOptions options,
            CancellationToken cancellationToken = default)
            => await OpenReadInteral(
                options?.Position ?? 0,
                options?.BufferSize,
                options?.Conditions,
                allowModifications: options?.AllowModifications ?? false,
                options?.TransferValidation,
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
        /// The buffer size (in bytes) to use when the stream downloads parts
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
        /// <remarks>
        /// The stream returned might throw <see cref="ShareFileModifiedException"/>
        /// if the file is concurrently modified.
        ///
        /// A <see cref="RequestFailedException" /> will be thrown if other failures occur.
        /// </remarks>
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
                allowModifications: false,
                transferValidationOverride: default,
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
        /// The buffer size (in bytes) to use when the stream downloads parts
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
        /// <remarks>
        /// The stream returned might throw <see cref="ShareFileModifiedException"/>
        /// if the file is concurrently modified.
        ///
        /// A <see cref="RequestFailedException" /> will be thrown if other failures occur.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Stream OpenRead(
#pragma warning restore AZC0015 // Unexpected client method return type.
            bool allowfileModifications,
            long position = 0,
            int? bufferSize = default,
            CancellationToken cancellationToken = default)
                => OpenReadInteral(
                    position: position,
                    bufferSize: bufferSize,
                    conditions: allowfileModifications ? new ShareFileRequestConditions() : null,
                    allowModifications: allowfileModifications,
                    transferValidationOverride: default,
                    async: false,
                    cancellationToken: cancellationToken).EnsureCompleted();

        /// <summary>
        /// Opens a stream for reading from the file.  The stream will only download
        /// the file as the stream is read from.
        /// </summary>
        /// <param name="position">
        /// The position within the file to begin the stream.
        /// Defaults to the beginning of the file.
        /// </param>
        /// <param name="bufferSize">
        /// The buffer size (in bytes) to use when the stream downloads parts
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
        /// <remarks>
        /// The stream returned might throw <see cref="ShareFileModifiedException"/>
        /// if the file is concurrently modified.
        ///
        /// A <see cref="RequestFailedException" /> will be thrown if other failures occur.
        /// </remarks>
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
                allowModifications: false,
                transferValidationOverride: default,
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
        /// The buffer size (in bytes) to use when the stream downloads parts
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
        /// <remarks>
        /// The stream returned might throw <see cref="ShareFileModifiedException"/>
        /// if the file is concurrently modified.
        ///
        /// A <see cref="RequestFailedException" /> will be thrown if other failures occur.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Stream> OpenReadAsync(
#pragma warning restore AZC0015 // Unexpected client method return type.
            bool allowfileModifications,
            long position = 0,
            int? bufferSize = default,
            CancellationToken cancellationToken = default)
                => await OpenReadInteral(
                    position: position,
                    bufferSize: bufferSize,
                    conditions: allowfileModifications ? new ShareFileRequestConditions() : null,
                    allowModifications: allowfileModifications,
                    transferValidationOverride: default,
                    async: true,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Opens a stream for reading from the file.  The stream will only download
        /// the file as the stream is read from.
        /// </summary>
        /// <param name="position">
        /// The position within the file to begin the stream.
        /// Defaults to the beginning of the file.
        /// </param>
        /// <param name="bufferSize">
        /// The buffer size (in bytes) to use when the stream downloads parts
        /// of the file.  Defaults to 1 MB.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions on
        /// the download of the file.
        /// </param>
        /// <param name="allowModifications">
        /// Whether to allow modifications during the read.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="transferValidationOverride">
        /// Optional override for client-configured transfer validation options.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns a stream that will download the file as the stream
        /// is read from.
        /// </returns>
        /// <remarks>
        /// The stream returned might throw <see cref="ShareFileModifiedException"/>
        /// if the file is concurrently modified and allowModifications is false.
        ///
        /// A <see cref="RequestFailedException" /> will be thrown if other failures occur.
        /// </remarks>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        internal async Task<Stream> OpenReadInteral(
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            long position,
            int? bufferSize,
            ShareFileRequestConditions conditions,
            bool allowModifications,
            DownloadTransferValidationOptions transferValidationOverride,
#pragma warning disable CA1801
            bool async,
            CancellationToken cancellationToken)
#pragma warning restore CA1801
        {
            DownloadTransferValidationOptions validaitonOptions = transferValidationOverride ?? ClientConfiguration.TransferValidation.Download;

            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareFileClient)}.{nameof(OpenRead)}");
            try
            {
                scope.Start();

                // This also makes sure that we fail fast if file doesn't exist.
                Response<ShareFileProperties> properties = await GetPropertiesInternal(conditions: conditions, async, cancellationToken).ConfigureAwait(false);

                ETag etag = (ETag) properties.GetRawResponse().Headers.ETag;

                return new LazyLoadingReadOnlyStream<ShareFileProperties>(
                    async (HttpRange range,
                    DownloadTransferValidationOptions downloadValidationOptions,
                    bool async,
                    CancellationToken cancellationToken) =>
                    {
                        Response<ShareFileDownloadInfo> response = await DownloadInternal(
                            range,
                            transferValidationOverride: downloadValidationOptions,
                            conditions,
                            async,
                            cancellationToken).ConfigureAwait(false);

                        if (!allowModifications && etag != response.GetRawResponse().Headers.ETag)
                        {
                            throw new ShareFileModifiedException(
                                "File has been modified concurrently",
                                Uri, etag, response.GetRawResponse().Headers.ETag.GetValueOrDefault(), range);
                        }

                        return Response.FromValue(
                            (IDownloadedContent)response.Value,
                            response.GetRawResponse());
                    },
                    async (bool async, CancellationToken cancellationToken)
                        => await GetPropertiesInternal(conditions: default, async, cancellationToken).ConfigureAwait(false),
                    validaitonOptions,
                    allowModifications,
                    properties.Value.ContentLength,
                    position,
                    bufferSize);
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response> DeleteInternal(
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken,
            string operationName = default)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message: $"{nameof(Uri)}: {Uri}");

                operationName ??= $"{nameof(ShareFileClient)}.{nameof(Delete)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);

                try
                {
                    scope.Start();
                    ResponseWithHeaders<FileDeleteHeaders> response;

                    if (async)
                    {
                        response = await FileRestClient.DeleteAsync(
                            shareFileRequestConditions: conditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = FileRestClient.Delete(
                            shareFileRequestConditions: conditions,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareFileClient));
                    scope.Dispose();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<ShareFileProperties>> GetPropertiesInternal(
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken,
            string operationName = default)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");

                operationName ??= $"{nameof(ShareFileClient)}.{nameof(GetProperties)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);

                try
                {
                    scope.Start();
                    ResponseWithHeaders<FileGetPropertiesHeaders> response;

                    if (async)
                    {
                        response = await FileRestClient.GetPropertiesAsync(
                            shareFileRequestConditions: conditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = FileRestClient.GetProperties(
                            shareFileRequestConditions: conditions,
                            cancellationToken: cancellationToken);
                    }

                    // Return an exploding Response on 304
                    return response.GetRawResponse().Status == Constants.HttpStatusCode.NotModified
                        ? response.GetRawResponse().AsNoBodyResponse<ShareFileProperties>()
                        : Response.FromValue(
                        response.ToShareFileProperties(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareFileClient));
                    scope.Dispose();
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
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<ShareFileInfo> SetHttpHeaders(
            ShareFileSetHttpHeadersOptions options = default,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            SetHttpHeadersInternal(
                options?.NewSize,
                options?.HttpHeaders,
                options?.SmbProperties,
                options?.FilePermission?.Permission,
                options?.FilePermission?.PermissionFormat,
                options?.PosixProperties,
                conditions,
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
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<ShareFileInfo>> SetHttpHeadersAsync(
            ShareFileSetHttpHeadersOptions options = default,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await SetHttpHeadersInternal(
                options?.NewSize,
                options?.HttpHeaders,
                options?.SmbProperties,
                options?.FilePermission?.Permission,
                options?.FilePermission?.PermissionFormat,
                options?.PosixProperties,
                conditions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<ShareFileInfo> SetHttpHeaders(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            long? newSize,
            ShareFileHttpHeaders httpHeaders,
            FileSmbProperties smbProperties,
            string filePermission,
            ShareFileRequestConditions conditions,
            CancellationToken cancellationToken) =>
            SetHttpHeadersInternal(
                newSize,
                httpHeaders,
                smbProperties,
                filePermission,
                filePermissionFormat: default,
                posixProperties: default,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
                filePermissionFormat: default,
                posixProperties: default,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<ShareFileInfo>> SetHttpHeadersAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            long? newSize,
            ShareFileHttpHeaders httpHeaders,
            FileSmbProperties smbProperties,
            string filePermission,
            ShareFileRequestConditions conditions,
            CancellationToken cancellationToken) =>
            await SetHttpHeadersInternal(
                newSize,
                httpHeaders,
                smbProperties,
                filePermission,
                filePermissionFormat: default,
                posixProperties: default,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
                filePermissionFormat: default,
                posixProperties: default,
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
        /// Optional file permission to set for the file.
        /// </param>
        /// <param name="filePermissionFormat">
        /// Optional file permission format.
        /// </param>
        /// <param name="posixProperties">
        /// Optional NFS properties.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<ShareFileInfo>> SetHttpHeadersInternal(
            long? newSize,
            ShareFileHttpHeaders httpHeaders,
            FileSmbProperties smbProperties,
            string filePermission,
            FilePermissionFormat? filePermissionFormat,
            FilePosixProperties posixProperties,
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(newSize)}: {newSize}\n" +
                    $"{nameof(httpHeaders)}: {httpHeaders}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareFileClient)}.{nameof(SetHttpHeaders)}");

                try
                {
                    scope.Start();
                    FileSmbProperties smbProps = smbProperties ?? new FileSmbProperties();

                    ShareExtensions.AssertValidFilePermissionAndKey(filePermission, smbProps.FilePermissionKey);

                    ResponseWithHeaders<FileSetHttpHeadersHeaders> response;

                    if (async)
                    {
                        response = await FileRestClient.SetHttpHeadersAsync(
                            fileAttributes: smbProps.FileAttributes.ToAttributesString(),
                            fileCreationTime: smbProps.FileCreatedOn.ToFileDateTimeString(),
                            fileLastWriteTime: smbProps.FileLastWrittenOn.ToFileDateTimeString(),
                            fileContentLength: newSize,
                            filePermission: filePermission,
                            filePermissionFormat: filePermissionFormat,
                            filePermissionKey: smbProps.FilePermissionKey,
                            fileChangeTime: smbProps.FileChangedOn.ToFileDateTimeString(),
                            owner: posixProperties?.Owner,
                            group: posixProperties?.Group,
                            fileMode: posixProperties?.FileMode?.ToOctalFileMode(),
                            fileHttpHeaders: httpHeaders.ToFileHttpHeaders(),
                            shareFileRequestConditions: conditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = FileRestClient.SetHttpHeaders(
                            fileAttributes: smbProps.FileAttributes.ToAttributesString(),
                            fileCreationTime: smbProps.FileCreatedOn.ToFileDateTimeString(),
                            fileLastWriteTime: smbProps.FileLastWrittenOn.ToFileDateTimeString(),
                            fileContentLength: newSize,
                            filePermission: filePermission,
                            filePermissionFormat: filePermissionFormat,
                            filePermissionKey: smbProps.FilePermissionKey,
                            fileChangeTime: smbProps.FileChangedOn.ToFileDateTimeString(),
                            owner: posixProperties?.Owner,
                            group: posixProperties?.Group,
                            fileMode: posixProperties?.FileMode?.ToOctalFileMode(),
                            fileHttpHeaders: httpHeaders.ToFileHttpHeaders(),
                            shareFileRequestConditions: conditions,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToShareFileInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareFileClient));
                    scope.Dispose();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<ShareFileInfo>> SetMetadataInternal(
            Metadata metadata,
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message: $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareFileClient)}.{nameof(SetMetadata)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<FileSetMetadataHeaders> response;

                    if (async)
                    {
                        response = await FileRestClient.SetMetadataAsync(
                            metadata: metadata,
                            shareFileRequestConditions: conditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = FileRestClient.SetMetadata(
                            metadata: metadata,
                            shareFileRequestConditions: conditions,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToShareFileInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareFileClient));
                    scope.Dispose();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<ShareFileUploadInfo>> ClearRangeInternal(
            HttpRange range,
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareFileClient)}.{nameof(ClearRange)}");

                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");
                try
                {
                    scope.Start();

                    ResponseWithHeaders<FileUploadRangeHeaders> response;

                    if (async)
                    {
                        response = await FileRestClient.UploadRangeAsync(
                            range: range.ToString(),
                            fileRangeWrite: ShareFileRangeWriteType.Clear,
                            contentLength: 0,
                            // TODO remove this
                            optionalbody: new MemoryStream(),
                            shareFileRequestConditions: conditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = FileRestClient.UploadRange(
                            range: range.ToString(),
                            fileRangeWrite: ShareFileRangeWriteType.Clear,
                            contentLength: 0,
                            // TODO remove this
                            optionalbody: new MemoryStream(),
                            shareFileRequestConditions: conditions,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToShareFileUploadInfo(),
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    ClientConfiguration.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    scope.Dispose();
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareFileClient));
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
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<ShareFileUploadInfo> UploadRange(
            HttpRange range,
            Stream content,
            ShareFileUploadRangeOptions options = default,
            CancellationToken cancellationToken = default) =>
            UploadRangeInternal(
                range: range,
                content: content,
                transferValidationOverride: options?.TransferValidation,
                progressHandler: options?.ProgressHandler,
                conditions: options?.Conditions,
                fileLastWrittenMode: options?.FileLastWrittenMode,
                async: false,
                cancellationToken: cancellationToken)
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
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<ShareFileUploadInfo>> UploadRangeAsync(
            HttpRange range,
            Stream content,
            ShareFileUploadRangeOptions options = default,
            CancellationToken cancellationToken = default) =>
            await UploadRangeInternal(
                range: range,
                content: content,
                transferValidationOverride: options?.TransferValidation,
                progressHandler: options?.ProgressHandler,
                conditions: options?.Conditions,
                fileLastWrittenMode: options?.FileLastWrittenMode,
                async: true,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<ShareFileUploadInfo> UploadRange(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            HttpRange range,
            Stream content,
            byte[] transactionalContentHash,
            IProgress<long> progressHandler,
            ShareFileRequestConditions conditions,
            CancellationToken cancellationToken)
        {
            return UploadRangeInternal(
                range,
                content,
                transferValidationOverride: transactionalContentHash != default
                    ? new UploadTransferValidationOptions()
                    {
                        ChecksumAlgorithm = StorageChecksumAlgorithm.MD5,
                        PrecalculatedChecksum = transactionalContentHash
                    }
                    : default,
                progressHandler,
                conditions,
                fileLastWrittenMode: default,
                false, // async
                cancellationToken)
                .EnsureCompleted();
        }

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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<ShareFileUploadInfo>> UploadRangeAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            HttpRange range,
            Stream content,
            byte[] transactionalContentHash,
            IProgress<long> progressHandler,
            ShareFileRequestConditions conditions,
            CancellationToken cancellationToken)
        {
            return await UploadRangeInternal(
                range,
                content,
                transferValidationOverride: transactionalContentHash != default
                    ? new UploadTransferValidationOptions()
                    {
                        ChecksumAlgorithm = StorageChecksumAlgorithm.MD5,
                        PrecalculatedChecksum = transactionalContentHash
                    }
                    : default,
                progressHandler,
                conditions,
                fileLastWrittenMode: default,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);
        }

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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ShareFileUploadInfo> UploadRange(
            ShareFileRangeWriteType writeType,
            HttpRange range,
            Stream content,
            byte[] transactionalContentHash = default,
            IProgress<long> progressHandler = default,
            CancellationToken cancellationToken = default)
        {
            return UploadRangeInternal(
                range,
                content,
                transferValidationOverride: transactionalContentHash != default
                    ? new UploadTransferValidationOptions()
                    {
                        ChecksumAlgorithm = StorageChecksumAlgorithm.MD5,
                        PrecalculatedChecksum = transactionalContentHash
                    }
                    : default,
                progressHandler,
                conditions: default,
                fileLastWrittenMode: default,
                false, // async
                cancellationToken)
                .EnsureCompleted();
        }

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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ShareFileUploadInfo>> UploadRangeAsync(
            ShareFileRangeWriteType writeType,
            HttpRange range,
            Stream content,
            byte[] transactionalContentHash = default,
            IProgress<long> progressHandler = default,
            CancellationToken cancellationToken = default)
        {
            return await UploadRangeInternal(
                range,
                content,
                transferValidationOverride: transactionalContentHash != default
                    ? new UploadTransferValidationOptions()
                    {
                        ChecksumAlgorithm = StorageChecksumAlgorithm.MD5,
                        PrecalculatedChecksum = transactionalContentHash
                    }
                    : default,
                progressHandler,
                conditions: default,
                fileLastWrittenMode: default,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);
        }

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
        /// <param name="transferValidationOverride">
        /// Optional override for transfer validation on upload.
        /// </param>
        /// <param name="progressHandler">
        /// Progress handler for upload operation.
        /// </param>
        /// <param name="conditions">
        /// Request conditions for upload range.
        /// </param>
        /// <param name="fileLastWrittenMode">
        /// Optional.  Specifies if the file last write time should be set to the current time,
        /// or the last write time currently associated with the file should be preserved.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        internal async Task<Response<ShareFileUploadInfo>> UploadRangeInternal(
            HttpRange range,
            Stream content,
            UploadTransferValidationOptions transferValidationOverride,
            IProgress<long> progressHandler,
            ShareFileRequestConditions conditions,
            FileLastWrittenMode? fileLastWrittenMode,
            bool async,
            CancellationToken cancellationToken)
        {
            UploadTransferValidationOptions validationOptions = transferValidationOverride ?? ClientConfiguration.TransferValidation.Upload;
            ShareErrors.AssertAlgorithmSupport(validationOptions?.ChecksumAlgorithm);

            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareFileClient)}.{nameof(UploadRange)}");

                try
                {
                    scope.Start();
                    Errors.VerifyStreamPosition(content, nameof(content));

                    // compute hash BEFORE attaching progress handler
                    ContentHasher.GetHashResult hashResult = await ContentHasher.GetHashOrDefaultInternal(
                        content,
                        validationOptions,
                        async,
                        cancellationToken).ConfigureAwait(false);

                    content = content.WithNoDispose().WithProgress(progressHandler);

                    ResponseWithHeaders<FileUploadRangeHeaders> response;

                    if (async)
                    {
                        response = await FileRestClient.UploadRangeAsync(
                            range: range.ToString(),
                            fileRangeWrite: ShareFileRangeWriteType.Update,
                            contentLength: (content?.Length - content?.Position) ?? 0,
                            fileLastWrittenMode: fileLastWrittenMode,
                            optionalbody: content,
                            contentMD5: hashResult?.MD5AsArray,
                            shareFileRequestConditions: conditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = FileRestClient.UploadRange(
                            range: range.ToString(),
                            fileRangeWrite: ShareFileRangeWriteType.Update,
                            contentLength: (content?.Length - content?.Position) ?? 0,
                            fileLastWrittenMode: fileLastWrittenMode,
                            optionalbody: content,
                            contentMD5: hashResult?.MD5AsArray,
                            shareFileRequestConditions: conditions,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToShareFileUploadInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareFileClient));
                    scope.Dispose();
                }
            }
        }
        #endregion UploadRange

        #region UploadRangeFromUrl
        /// <summary>
        /// The <see cref="UploadRangeFromUri(Uri, HttpRange, HttpRange, ShareFileUploadRangeFromUriOptions, CancellationToken)"/>
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
        /// <param name="options">
        /// Optional parameters.  <see cref="ShareFileUploadRangeFromUriOptions"/>.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<ShareFileUploadInfo> UploadRangeFromUri(
            Uri sourceUri,
            HttpRange range,
            HttpRange sourceRange,
            ShareFileUploadRangeFromUriOptions options = default,
            CancellationToken cancellationToken = default) =>
            UploadRangeFromUriInternal(
                sourceUri: sourceUri,
                range: range,
                sourceRange: sourceRange,
                conditions: options?.Conditions,
                sourceAuthentication: options?.SourceAuthentication,
                fileLastWrittenMode: options?.FileLastWrittenMode,
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
        /// <param name="options">
        /// Optional parameters.  <see cref="ShareFileUploadRangeFromUriOptions"/>.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<ShareFileUploadInfo>> UploadRangeFromUriAsync(
            Uri sourceUri,
            HttpRange range,
            HttpRange sourceRange,
            ShareFileUploadRangeFromUriOptions options = default,
            CancellationToken cancellationToken = default) =>
            await UploadRangeFromUriInternal(
                sourceUri: sourceUri,
                range: range,
                sourceRange: sourceRange,
                conditions: options?.Conditions,
                sourceAuthentication: options?.SourceAuthentication,
                fileLastWrittenMode: options?.FileLastWrittenMode,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<ShareFileUploadInfo> UploadRangeFromUri(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Uri sourceUri,
            HttpRange range,
            HttpRange sourceRange,
            ShareFileRequestConditions conditions,
            CancellationToken cancellationToken) =>
            UploadRangeFromUriInternal(
                sourceUri: sourceUri,
                range: range,
                sourceRange: sourceRange,
                conditions: conditions,
                sourceAuthentication: default,
                fileLastWrittenMode: default,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
            UploadRangeFromUriInternal(
                sourceUri: sourceUri,
                range: range,
                sourceRange: sourceRange,
                conditions: default,
                sourceAuthentication: default,
                fileLastWrittenMode: default,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<ShareFileUploadInfo>> UploadRangeFromUriAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Uri sourceUri,
            HttpRange range,
            HttpRange sourceRange,
            ShareFileRequestConditions conditions,
            CancellationToken cancellationToken) =>
            await UploadRangeFromUriInternal(
                sourceUri: sourceUri,
                range: range,
                sourceRange: sourceRange,
                conditions: conditions,
                sourceAuthentication: default,
                fileLastWrittenMode: default,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ShareFileUploadInfo>> UploadRangeFromUriAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Uri sourceUri,
            HttpRange range,
            HttpRange sourceRange,
            CancellationToken cancellationToken) =>
            await UploadRangeFromUriInternal(
                sourceUri: sourceUri,
                range: range,
                sourceRange: sourceRange,
                conditions: default,
                sourceAuthentication: default,
                fileLastWrittenMode: default,
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
        /// <param name="sourceAuthentication">
        /// Optional. Source authentication used to access the source blob.
        /// </param>
        /// <param name="fileLastWrittenMode">
        /// Optional.  Specifies if the file last write time should be set to the current time,
        /// or the last write time currently associated with the file should be preserved.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<ShareFileUploadInfo>> UploadRangeFromUriInternal(
            Uri sourceUri,
            HttpRange range,
            HttpRange sourceRange,
            ShareFileRequestConditions conditions,
            HttpAuthorization sourceAuthentication,
            FileLastWrittenMode? fileLastWrittenMode,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(sourceUri)}: {sourceUri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareFileClient)}.{nameof(UploadRangeFromUri)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<FileUploadRangeFromURLHeaders> response;

                    if (async)
                    {
                        response = await FileRestClient.UploadRangeFromURLAsync(
                            range: range.ToString(),
                            copySource: sourceUri.AbsoluteUri,
                            contentLength: 0,
                            sourceRange: sourceRange.ToString(),
                            copySourceAuthorization: sourceAuthentication?.ToString(),
                            fileLastWrittenMode: fileLastWrittenMode,
                            shareFileRequestConditions: conditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = FileRestClient.UploadRangeFromURL(
                            range: range.ToString(),
                            copySource: sourceUri.AbsoluteUri,
                            contentLength: 0,
                            sourceRange: sourceRange.ToString(),
                            copySourceAuthorization: sourceAuthentication?.ToString(),
                            fileLastWrittenMode: fileLastWrittenMode,
                            shareFileRequestConditions: conditions,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToShareFileUploadInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareFileClient));
                    scope.Dispose();
                }
            }
        }
        #endregion UploadRangeFromUrl

        #region Upload
        /// <summary>
        /// The <see cref="Upload(Stream, ShareFileUploadOptions, CancellationToken)"/>
        /// operation writes <paramref name="options.Stream"/> to a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-range">
        /// Put Range</see>.
        /// </summary>
        /// <param name="stream">
        /// Content stream to upload.
        /// </param>
        /// <param name="options">
        /// Upload options.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<ShareFileUploadInfo> Upload(
            Stream stream,
            ShareFileUploadOptions options = default,
            CancellationToken cancellationToken = default) =>
            UploadInternal(
                stream,
                options?.ProgressHandler,
                options?.Conditions,
                options?.TransferValidation,
                options?.TransferOptions ?? default,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="UploadAsync(Stream, ShareFileUploadOptions, CancellationToken)"/> operation writes
        /// <paramref name="options.Stream"/> to a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-range">
        /// Put Range</see>.
        /// </summary>
        /// <param name="stream">
        /// Content stream to upload.
        /// </param>
        /// <param name="options">
        /// Upload options.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<ShareFileUploadInfo>> UploadAsync(
            Stream stream,
            ShareFileUploadOptions options = default,
            CancellationToken cancellationToken = default) =>
            await UploadInternal(
                stream,
                options?.ProgressHandler,
                options?.Conditions,
                options?.TransferValidation,
                options?.TransferOptions ?? default,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<ShareFileUploadInfo> Upload(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Stream content,
            IProgress<long> progressHandler,
            ShareFileRequestConditions conditions,
            CancellationToken cancellationToken) =>
            UploadInternal(
                content,
                progressHandler,
                conditions,
                transferValidationOverride: default,
                transferOptions: default,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
                transferValidationOverride: default,
                transferOptions: default,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<ShareFileUploadInfo>> UploadAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Stream content,
            IProgress<long> progressHandler,
            ShareFileRequestConditions conditions,
            CancellationToken cancellationToken) =>
            await UploadInternal(
                content,
                progressHandler,
                conditions,
                transferValidationOverride: default,
                transferOptions: default,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
                transferValidationOverride: default,
                transferOptions: default,
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
        /// <param name="transferValidationOverride">
        /// Optional override for client-configured transfer validation options.
        /// </param>
        /// <param name="transferOptions">
        /// Partitioned transfer options for upload.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        internal async Task<Response<ShareFileUploadInfo>> UploadInternal(
            Stream content,
            IProgress<long> progressHandler,
            ShareFileRequestConditions conditions,
            UploadTransferValidationOptions transferValidationOverride,
            StorageTransferOptions transferOptions,
            bool async,
            CancellationToken cancellationToken)
        {
            UploadTransferValidationOptions validationOptions = transferValidationOverride ?? ClientConfiguration.TransferValidation.Upload;
            transferOptions = StorageArgument.PopulateShareFileUploadTransferOptionDefaults(transferOptions);
            StorageArgument.AssertShareFileUploadTransferOptionBounds(transferOptions, nameof(transferOptions));

            var uploader = GetPartitionedUploader(
                transferOptions,
                validationOptions,
                operationName: $"{nameof(ShareFileClient)}.{nameof(Upload)}");

            return await uploader.UploadInternal(
                content,
                expectedContentLength: default,
                new ShareFileUploadData
                {
                    Conditions = conditions,
                },
                progressHandler,
                async,
                cancellationToken)
                .ConfigureAwait(false);
        }
        #endregion Upload

        #region PartitionedUploader
        internal class ShareFileUploadData
        {
            public ShareFileRequestConditions Conditions { get; set; }
            public Response<ShareFileUploadInfo> LastUploadRangeResponse { get; set; }
        }

        internal PartitionedUploader<ShareFileUploadData, ShareFileUploadInfo> GetPartitionedUploader(
            StorageTransferOptions transferOptions,
            UploadTransferValidationOptions transferValidation,
            ArrayPool<byte> arrayPool = null,
            string operationName = null)
            => new PartitionedUploader<ShareFileUploadData, ShareFileUploadInfo>(
                GetPartitionedUploaderBehaviors(this),
                transferOptions,
                transferValidation,
                arrayPool,
                operationName);

        // static because it makes mocking easier in tests
        internal static PartitionedUploader<ShareFileUploadData, ShareFileUploadInfo>.Behaviors GetPartitionedUploaderBehaviors(ShareFileClient client)
            => new PartitionedUploader<ShareFileUploadData, ShareFileUploadInfo>.Behaviors
            {
                SingleUploadStreaming = async (stream, data, progressHandler, validationOptions, operationName, async, cancellationToken) =>
                {
                    return await client.UploadRangeInternal(
                        new HttpRange(offset: 0, length: stream.Length),
                        stream,
                        validationOptions,
                        progressHandler,
                        data.Conditions,
                        fileLastWrittenMode: null,
                        async,
                        cancellationToken)
                        .ConfigureAwait(false);
                },
                SingleUploadBinaryData = async (content, data, progressHandler, validationOptions, operationName, async, cancellationToken) =>
                {
                    return await client.UploadRangeInternal(
                        new HttpRange(offset: 0, length: content.ToMemory().Length),
                        content.ToStream(),
                        validationOptions,
                        progressHandler,
                        data.Conditions,
                        fileLastWrittenMode: null,
                        async,
                        cancellationToken)
                        .ConfigureAwait(false);
                },
                UploadPartitionStreaming = async (stream, offset, data, progressHandler, validationOptions, async, cancellationToken) =>
                {
                    data.LastUploadRangeResponse = await client.UploadRangeInternal(
                        new HttpRange(offset: offset, length: stream.Length),
                        stream,
                        validationOptions,
                        progressHandler,
                        data.Conditions,
                        fileLastWrittenMode: null,
                        async,
                        cancellationToken)
                        .ConfigureAwait(false);
                },
                UploadPartitionBinaryData = async (content, offset, data, progressHandler, validationOptions, async, cancellationToken) =>
                {
                    data.LastUploadRangeResponse = await client.UploadRangeInternal(
                        new HttpRange(offset: offset, length: content.ToMemory().Length),
                        content.ToStream(),
                        validationOptions,
                        progressHandler,
                        data.Conditions,
                        fileLastWrittenMode: null,
                        async,
                        cancellationToken)
                        .ConfigureAwait(false);
                },
                CommitPartitionedUpload = (partitions, data, async, cancellationToken) => Task.FromResult(data.LastUploadRangeResponse),
                Scope = operationName => client.ClientConfiguration.ClientDiagnostics.CreateScope(operationName ??
                    $"{nameof(Azure)}.{nameof(Storage)}.{nameof(Files)}.{nameof(Shares)}.{nameof(ShareFileClient)}.{nameof(ShareFileClient.Upload)}")
            };
        #endregion

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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<ShareFileRangeInfo> GetRangeList(
            ShareFileGetRangeListOptions options = default,
            CancellationToken cancellationToken = default) =>
            GetRangeListInternal(
                options?.Range,
                options?.Snapshot,
                previousSnapshot: default,
                supportRename: default,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<ShareFileRangeInfo>> GetRangeListAsync(
            ShareFileGetRangeListOptions options = default,
            CancellationToken cancellationToken = default) =>
            await GetRangeListInternal(
                options?.Range,
                options?.Snapshot,
                previousSnapshot: default,
                supportRename: default,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
                supportRename: default,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
                supportRename: default,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
                supportRename: default,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
                supportRename: default,
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
        /// <param name="supportRename">
        /// This header is allowed only when PreviousSnapshot query parameter is set.
        /// Determines whether the changed ranges for a file that has been renamed or moved between the target snapshot (or the live file) and the previous snapshot should be listed.
        /// If the value is true, the valid changed ranges for the file will be returned. If the value is false, the operation will result in a failure with 409 (Conflict) response.
        /// The default value is false.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<ShareFileRangeInfo>> GetRangeListInternal(
            HttpRange? range,
            string snapshot,
            string previousSnapshot,
            bool? supportRename,
            ShareFileRequestConditions conditions,
            string operationName,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");

                operationName ??= $"{nameof(ShareFileClient)}.{nameof(GetRangeList)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);

                try
                {
                    scope.Start();
                    ResponseWithHeaders<ShareFileRangeList, FileGetRangeListHeaders> response;

                    if (async)
                    {
                        response = await FileRestClient.GetRangeListAsync(
                            sharesnapshot: snapshot,
                            prevsharesnapshot: previousSnapshot,
                            supportRename: supportRename,
                            range: range?.ToString(),
                            shareFileRequestConditions: conditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = FileRestClient.GetRangeList(
                            sharesnapshot: snapshot,
                            prevsharesnapshot: previousSnapshot,
                            supportRename: supportRename,
                            range: range?.ToString(),
                            shareFileRequestConditions: conditions,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToShareFileRangeInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareFileClient));
                    scope.Dispose();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<ShareFileRangeInfo> GetRangeListDiff(
            ShareFileGetRangeListDiffOptions options = default,
            CancellationToken cancellationToken = default) =>
            GetRangeListInternal(
                options?.Range,
                options?.Snapshot,
                options?.PreviousSnapshot,
                options?.IncludeRenames,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<ShareFileRangeInfo>> GetRangeListDiffAsync(
            ShareFileGetRangeListDiffOptions options = default,
            CancellationToken cancellationToken = default) =>
            await GetRangeListInternal(
                options?.Range,
                options?.Snapshot,
                options?.PreviousSnapshot,
                options?.IncludeRenames,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        internal async Task<Response<StorageHandlesSegment>> GetHandlesInternal(
            string marker,
            int? maxResults,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(marker)}: {marker}\n" +
                    $"{nameof(maxResults)}: {maxResults}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareFileClient)}.{nameof(GetHandles)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<ListHandlesResponse, FileListHandlesHeaders> response;

                    if (async)
                    {
                        response = await FileRestClient.ListHandlesAsync(
                            marker: marker,
                            maxresults: maxResults,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = FileRestClient.ListHandles(
                            marker: marker,
                            maxresults: maxResults,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.Value.ToStorageHandlesSegment(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareFileClient));
                    scope.Dispose();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<StorageClosedHandlesSegment>> ForceCloseHandlesInternal(
            string handleId,
            string marker,
            bool async,
            CancellationToken cancellationToken,
            string operationName = null)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(handleId)}: {handleId}\n" +
                    $"{nameof(marker)}: {marker}");

                operationName ??= $"{nameof(ShareFileClient)}.{nameof(ForceCloseAllHandles)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);

                try
                {
                    scope.Start();
                    ResponseWithHeaders<FileForceCloseHandlesHeaders> response;

                    if (async)
                    {
                        response = await FileRestClient.ForceCloseHandlesAsync(
                            handleId: handleId,
                            marker: marker,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = FileRestClient.ForceCloseHandles(
                            handleId: handleId,
                            marker: marker,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToStorageClosedHandlesSegment(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareFileClient));
                    scope.Dispose();
                }
            }
        }
        #endregion ForceCloseHandles

        #region Rename
        /// <summary>
        /// Renames a file.
        /// This API does not support renaming a file from one share to another, or between storage accounts.
        /// </summary>
        /// <param name="destinationPath">
        /// The destination path to rename the file to.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareFileClient}"/> pointed at the newly renamed File.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<ShareFileClient> Rename(
            string destinationPath,
            ShareFileRenameOptions options = default,
            CancellationToken cancellationToken = default)
            => RenameInternal(
                destinationPath: destinationPath,
                options: options,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Renames a file.
        /// This API does not support renaming a file from one share to another, or between storage accounts.
        /// </summary>
        /// <param name="destinationPath">
        /// The destination path to rename the file to.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareFileClient}"/> pointed at the newly renamed File.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<ShareFileClient>> RenameAsync(
            string destinationPath,
            ShareFileRenameOptions options = default,
            CancellationToken cancellationToken = default)
            => await RenameInternal(
                destinationPath: destinationPath,
                options: options,
                async: true,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Renames a file.
        /// This API does not support renaming a file from one share to another, or between storage accounts.
        /// </summary>
        /// <param name="destinationPath">
        /// The destination path to rename the file to.
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
        /// A <see cref="Response{ShareFileClient}"/> pointed at the newly renamed File.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<ShareFileClient>> RenameInternal(
            string destinationPath,
            ShareFileRenameOptions options,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(destinationPath)}: {destinationPath}\n" +
                    $"{nameof(options)}: {options}\n");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareFileClient)}.{nameof(Rename)}");

                try
                {
                    scope.Start();

                    ShareExtensions.AssertValidFilePermissionAndKey(options?.FilePermission, options?.SmbProperties?.FilePermissionKey);

                    // TODO: this seems weird to do, probably should build a way to append to the query.. without altering it somehow
                    // in the case that the customer wants the query to be in a certain order
                    ShareUriBuilder shareUriBuilder = new ShareUriBuilder(Uri);
                    ShareUriBuilder sourceUriBuilder = new ShareUriBuilder(Uri);
                    // There's already a check in at the client constructor to prevent both SAS in Uri and AzureSasCredential
                    if (shareUriBuilder.Sas == null && ClientConfiguration.SasCredential != null)
                    {
                        sourceUriBuilder.Query += ClientConfiguration.SasCredential.Signature;
                    }

                    // Build destination URI
                    ShareUriBuilder destUriBuilder = new ShareUriBuilder(Uri)
                    {
                        Sas = null,
                        Query = null
                    };

                    // ShareUriBuider will encode the DirectoryOrFilePath.
                    // We don't want the query parameters, especially SAS, to be encoded.
                    // We also have to build the destination client depending on if a SAS was passed with the destination.
                    ShareFileClient destFileClient;
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
                            destFileClient = new ShareFileClient(destUriBuilder.ToUri(), ClientConfiguration);
                        }
                        else
                        {
                            // There's a SAS in the destination path
                            // Create the destination path with the destination SAS
                            destFileClient = new ShareFileClient(
                                destUriBuilder.ToUri(),
                                ClientConfiguration.ClientDiagnostics,
                                ClientConfiguration.ClientOptions);
                        }
                    }
                    else
                    {
                        // No SAS in the destination, use the source credentials to build the destination path
                        destUriBuilder.DirectoryOrFilePath = destinationPath;
                        destUriBuilder.Sas = sourceUriBuilder.Sas;
                        destFileClient = new ShareFileClient(
                            destUriBuilder.ToUri(),
                            ClientConfiguration);
                    }

                    ResponseWithHeaders<FileRenameHeaders> response;

                    CopyFileSmbInfo copyFileSmbInfo = new CopyFileSmbInfo
                    {
                        FileAttributes = options?.SmbProperties?.FileAttributes.ToAttributesString(),
                        FileCreationTime = options?.SmbProperties?.FileCreatedOn.ToFileDateTimeString(),
                        FileChangeTime = options?.SmbProperties?.FileChangedOn.ToFileDateTimeString(),
                        FileLastWriteTime = options?.SmbProperties?.FileLastWrittenOn.ToFileDateTimeString(),
                        IgnoreReadOnly = options?.IgnoreReadOnly
                    };

                    FileHttpHeaders fileHttpHeaders = new FileHttpHeaders
                    {
                        FileContentType = options?.ContentType
                    };

                    if (async)
                    {
                        response = await destFileClient.FileRestClient.RenameAsync(
                            renameSource: sourceUriBuilder.ToUri().AbsoluteUri,
                            replaceIfExists: options?.ReplaceIfExists,
                            ignoreReadOnly: options?.IgnoreReadOnly,
                            sourceLeaseId: options?.SourceConditions?.LeaseId,
                            destinationLeaseId: options?.DestinationConditions?.LeaseId,
                            filePermission: options?.FilePermission,
                            filePermissionFormat: options?.FilePermissionFormat,
                            filePermissionKey: options?.SmbProperties?.FilePermissionKey,
                            metadata: options?.Metadata,
                            copyFileSmbInfo: copyFileSmbInfo,
                            fileHttpHeaders: fileHttpHeaders,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = destFileClient.FileRestClient.Rename(
                            renameSource: sourceUriBuilder.ToUri().AbsoluteUri,
                            replaceIfExists: options?.ReplaceIfExists,
                            ignoreReadOnly: options?.IgnoreReadOnly,
                            sourceLeaseId: options?.SourceConditions?.LeaseId,
                            destinationLeaseId: options?.DestinationConditions?.LeaseId,
                            filePermission: options?.FilePermission,
                            filePermissionFormat: options?.FilePermissionFormat,
                            filePermissionKey: options?.SmbProperties?.FilePermissionKey,
                            metadata: options?.Metadata,
                            copyFileSmbInfo: copyFileSmbInfo,
                            fileHttpHeaders: fileHttpHeaders,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        destFileClient,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareFileClient));
                    scope.Dispose();
                }
            }
        }
        #endregion Rename

        #region GetSymbolicLink
        /// <summary>
        /// Reads the value of the symbolic link.
        /// Only applicable if this <see cref="ShareFileClient"/> is pointed at an NFS symbolic link.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileSymbolicLinkInfo}"/> describing the symbolic link.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<ShareFileSymbolicLinkInfo> GetSymbolicLink(
            CancellationToken cancellationToken = default) =>
            GetSymbolicLinkInternal(
                async: false,
                cancellationToken: cancellationToken)
            .EnsureCompleted();

        /// <summary>
        /// Reads the value of the symbolic link.
        /// Only applicable if this <see cref="ShareFileClient"/> is pointed at an NFS symbolic link.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileSymbolicLinkInfo}"/> describing the symbolic link.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<ShareFileSymbolicLinkInfo>> GetSymbolicLinkAsync(
            CancellationToken cancellationToken = default) =>
            await GetSymbolicLinkInternal(
                async: true,
                cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// Reads the value of the symbolic link.
        /// Only applicable if this <see cref="ShareFileClient"/> is pointed at an NFS symbolic link.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileSymbolicLinkInfo}"/> describing the symbolic link.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<ShareFileSymbolicLinkInfo>> GetSymbolicLinkInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(nameof(ShareFileClient), message: string.Empty);

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareFileClient)}.{nameof(GetSymbolicLink)}");

                ResponseWithHeaders<FileGetSymbolicLinkHeaders> response;

                try
                {
                    scope.Start();

                    if (async)
                    {
                        response = await FileRestClient.GetSymbolicLinkAsync(
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = FileRestClient.GetSymbolicLink(
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToFileSymbolicLinkInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareFileClient));
                    scope.Dispose();
                }
            }
        }
        #endregion

        #region CreateSymbolicLink
        /// <summary>
        /// NFS only.  Creates a symoblic link to the file specified by path.
        /// </summary>
        /// <param name="linkText">
        /// The absolution or relative path to the file to be linked to.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<ShareFileInfo> CreateSymbolicLink(
            string linkText,
            ShareFileCreateSymbolicLinkOptions options = default,
            CancellationToken cancellationToken = default) =>
            CreateSymbolicLinkInternal(
                linkText: linkText,
                options: options,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// NFS only.  Creates a symoblic link to the file specified by path.
        /// </summary>
        /// <param name="linkText">
        /// The absolution or relative path to the file to be linked to.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<ShareFileInfo>> CreateSymbolicLinkAsync(
            string linkText,
            ShareFileCreateSymbolicLinkOptions options = default,
            CancellationToken cancellationToken = default) =>
            await CreateSymbolicLinkInternal(
                linkText: linkText,
                options: options,
                async: true,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// NFS only.  Creates a symoblic link to the file specified by path.
        /// </summary>
        /// <param name="linkText">
        /// The absolution or relative path to the file to be linked to.
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
        /// A <see cref="Response{StorageFileInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<ShareFileInfo>> CreateSymbolicLinkInternal(
            string linkText,
            ShareFileCreateSymbolicLinkOptions options,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareFileClient)}.{nameof(CreateSymbolicLink)}");

                ResponseWithHeaders<FileCreateSymbolicLinkHeaders> response;

                try
                {
                    scope.Start();

                    if (async)
                    {
                        response = await FileRestClient.CreateSymbolicLinkAsync(
                            linkText: linkText,
                            metadata: options?.Metadata,
                            fileCreationTime: options?.FileCreatedOn.ToFileDateTimeString(),
                            fileLastWriteTime: options?.FileLastWrittenOn.ToFileDateTimeString(),
                            owner: options?.Owner,
                            group: options?.Group,
                            shareFileRequestConditions: options?.Conditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = FileRestClient.CreateSymbolicLink(
                            linkText: linkText,
                            metadata: options?.Metadata,
                            fileCreationTime: options?.FileCreatedOn.ToFileDateTimeString(),
                            fileLastWriteTime: options?.FileLastWrittenOn.ToFileDateTimeString(),
                            owner: options?.Owner,
                            group: options?.Group,
                            shareFileRequestConditions: options?.Conditions,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToShareFileInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareFileClient));
                    scope.Dispose();
                }
            }
        }
        #endregion

        #region CreateHardLink
        /// <summary>
        /// NFS only.  Creates a hard link to the file file specified by path.
        /// </summary>
        /// <param name="targetFile">
        /// Path of the file to create the hard link to, not including the share.
        /// For example: "targetDirectory/targetSubDirectory/.../targetFile"
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the hard link.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileInfo}"/> describing the
        /// state of the hard link.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<ShareFileInfo> CreateHardLink(
            string targetFile,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
            => CreateHardLinkInternal(
                targetFile: targetFile,
                conditions: conditions,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// NFS only.  Creates a hard link to the file file specified by path.
        /// </summary>
        /// <param name="targetFile">
        /// Path of the file to create the hard link to, not including the share.
        /// For example: "targetDirectory/targetSubDirectory/.../targetFile"
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the hard link.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileInfo}"/> describing the
        /// state of the hard link.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public async virtual Task<Response<ShareFileInfo>> CreateHardLinkAsync(
            string targetFile,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
            => await CreateHardLinkInternal(
                targetFile: targetFile,
                conditions: conditions,
                async: true,
                cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// NFS only.  Creates a hard link to the file file specified by path.
        /// </summary>
        /// <param name="targetFile">
        /// Path of the file to create the hard link to, not including the share.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the hard link.
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
        /// state of the hard link.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<ShareFileInfo>> CreateHardLinkInternal(
            string targetFile,
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(targetFile)}: {targetFile}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareFileClient)}.{nameof(CreateHardLink)}");

                try
                {
                    scope.Start();

                    ResponseWithHeaders<FileCreateHardLinkHeaders> response;

                    if (async)
                    {
                        response = await FileRestClient.CreateHardLinkAsync(
                            targetFile: targetFile,
                            shareFileRequestConditions: conditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = FileRestClient.CreateHardLink(
                            targetFile: targetFile,
                            shareFileRequestConditions: conditions,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToShareFileInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareFileClient));
                    scope.Dispose();
                }
            }
        }
        #endregion

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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Stream> OpenWriteInternal(
            bool overwrite,
            long position,
            ShareFileOpenWriteOptions options,
            bool async,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareFileClient)}.{nameof(OpenWrite)}");

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
                        filePermissionFormat: default,
                        posixProperties: default,
                        filePropertySemantics: default,
                        content: default,
                        transferValidationOverride: default,
                        progressHandler: default,
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
                            filePermissionFormat: default,
                            posixProperties: default,
                            filePropertySemantics: default,
                            content: default,
                            transferValidationOverride: default,
                            progressHandler: default,
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
                    progressHandler: options?.ProgressHandler,
                    options?.TransferValidation ?? ClientConfiguration.TransferValidation.Upload
                    );
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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-shares")]
        public virtual Uri GenerateSasUri(ShareFileSasPermissions permissions, DateTimeOffset expiresOn) =>
            GenerateSasUri(permissions, expiresOn, out _);

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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-shares")]
        public virtual Uri GenerateSasUri(ShareFileSasPermissions permissions, DateTimeOffset expiresOn, out string stringToSign) =>
            GenerateSasUri(new ShareSasBuilder(permissions, expiresOn)
            {
                ShareName = ShareName,
                FilePath = Path
            }, out stringToSign);

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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-shares")]
        public virtual Uri GenerateSasUri(ShareSasBuilder builder)
            => GenerateSasUri(builder, out _);

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
        /// <param name="stringToSign">
        /// For debugging purposes only.  This string will be overwritten with the string to sign that was used to generate the SAS Uri.
        /// </param>
        /// <returns>
        /// A <see cref="ShareSasBuilder"/> on successfully deleting.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-shares")]
        public virtual Uri GenerateSasUri(ShareSasBuilder builder, out string stringToSign)
        {
            builder = builder ?? throw Errors.ArgumentNull(nameof(builder));

            // Deep copy of builder so we don't modify the user's original ShareSasBuilder.
            builder = ShareSasBuilder.DeepCopy(builder);

            SetBuilderAndValidate(builder);

            ShareUriBuilder sasUri = new ShareUriBuilder(Uri)
            {
                Query = builder.ToSasQueryParameters(ClientConfiguration.SharedKeyCredential, out stringToSign).ToString()
            };
            return sasUri.ToUri();
        }
        #endregion

        #region GenerateUserDelegationSas
        /// <summary>
        /// The <see cref="GenerateUserDelegationSasUri(ShareFileSasPermissions, DateTimeOffset, UserDelegationKey, out string)"/>
        /// returns a <see cref="Uri"/> that generates a Share Directory Service Shared Access Signature (SAS)
        /// Uri based on the Client properties and parameter passed. The SAS is signed by the user delegation key passed in.
        ///
        /// For more information, see
        /// <see href="https://learn.microsoft.com/en-us/rest/api/storageservices/create-user-delegation-sas">
        /// Creating an user delegation SAS</see>.
        /// </summary>
        /// <param name="permissions">
        /// Required. Specifies the list of permissions to be associated with the SAS.
        /// See <see cref="ShareSasPermissions"/>.
        /// </param>
        /// <param name="expiresOn">
        /// Required. Specifies the time at which the SAS becomes invalid. This field
        /// must be omitted if it has been specified in an associated stored access policy.
        /// </param>
        /// <param name="userDelegationKey">
        /// Required. A <see cref="UserDelegationKey"/> returned from
        /// <see cref="ShareServiceClient.GetUserDelegationKeyAsync"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-shares")]
        public Uri GenerateUserDelegationSasUri(ShareFileSasPermissions permissions, DateTimeOffset expiresOn, UserDelegationKey userDelegationKey)
            => GenerateUserDelegationSasUri(permissions, expiresOn, userDelegationKey, out _);

        /// <summary>
        /// The <see cref="GenerateUserDelegationSasUri(ShareFileSasPermissions, DateTimeOffset, UserDelegationKey, out string)"/>
        /// returns a <see cref="Uri"/> that generates a Share Directory Service Shared Access Signature (SAS)
        /// Uri based on the Client properties and parameter passed. The SAS is signed by the user delegation key passed in.
        ///
        /// For more information, see
        /// <see href="https://learn.microsoft.com/en-us/rest/api/storageservices/create-user-delegation-sas">
        /// Creating an user delegation SAS</see>.
        /// </summary>
        /// <param name="permissions">
        /// Required. Specifies the list of permissions to be associated with the SAS.
        /// See <see cref="ShareSasPermissions"/>.
        /// </param>
        /// <param name="expiresOn">
        /// Required. Specifies the time at which the SAS becomes invalid. This field
        /// must be omitted if it has been specified in an associated stored access policy.
        /// </param>
        /// <param name="userDelegationKey">
        /// Required. A <see cref="UserDelegationKey"/> returned from
        /// <see cref="ShareServiceClient.GetUserDelegationKeyAsync"/>.
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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-shares")]
        public Uri GenerateUserDelegationSasUri(ShareFileSasPermissions permissions, DateTimeOffset expiresOn, UserDelegationKey userDelegationKey, out string stringToSign) =>
            GenerateUserDelegationSasUri(new ShareSasBuilder(permissions, expiresOn)
            {
                ShareName = ShareName,
                FilePath = Path,
            }, userDelegationKey, out stringToSign);

        /// <summary>
        /// The <see cref="GenerateUserDelegationSasUri(ShareSasBuilder, UserDelegationKey, out string)"/>
        /// returns a <see cref="Uri"/> that generates a Share Directory Service Shared Access Signature (SAS)
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
        /// <see cref="ShareServiceClient.GetUserDelegationKeyAsync"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if a failure occurs.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-shares")]
        public Uri GenerateUserDelegationSasUri(ShareSasBuilder builder, UserDelegationKey userDelegationKey)
            => GenerateUserDelegationSasUri(builder, userDelegationKey, out _);

        /// <summary>
        /// The <see cref="GenerateUserDelegationSasUri(ShareSasBuilder, UserDelegationKey, out string)"/>
        /// returns a <see cref="Uri"/> that generates a Share File Service Shared Access Signature (SAS)
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
        /// <see cref="ShareServiceClient.GetUserDelegationKeyAsync"/>.
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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-shares")]
        public Uri GenerateUserDelegationSasUri(ShareSasBuilder builder, UserDelegationKey userDelegationKey, out string stringToSign)
        {
            builder = builder ?? throw Errors.ArgumentNull(nameof(builder));

            // Deep copy of builder so we don't modify the user's original DataLakeSasBuilder.
            builder = ShareSasBuilder.DeepCopy(builder);

            SetBuilderAndValidate(builder);

            ShareUriBuilder sasUri = new ShareUriBuilder(Uri)
            {
                Sas = builder.ToSasQueryParameters(userDelegationKey, this.AccountName, out stringToSign)
            };
            return sasUri.ToUri();
        }
        #endregion

        private void SetBuilderAndValidate(ShareSasBuilder builder)
        {
            // Assign builder's ShareName and Path, if they are null.
            builder.ShareName ??= ShareName;
            builder.FilePath ??= Path;

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
        }

        #region GetParentClientCore

        private ShareClient _parentShareClient;
        private ShareDirectoryClient _parentShareDirectoryClient;

        /// <summary>
        /// Create a new <see cref="ShareClient"/> that pointing to this <see cref="ShareFileClient"/>'s parent container.
        /// The new <see cref="ShareClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="ShareFileClient"/>.
        /// </summary>
        /// <returns>A new <see cref="ShareFileClient"/> instance.</returns>
        protected internal virtual ShareClient GetParentShareClientCore()
        {
            if (_parentShareClient == null)
            {
                ShareUriBuilder shareUriBuilder = new ShareUriBuilder(Uri)
                {
                    // erase parameters unrelated to container
                    DirectoryOrFilePath = null,
                    Snapshot = null,
                };

                _parentShareClient = new ShareClient(
                    shareUriBuilder.ToUri(),
                    ClientConfiguration);
            }

            return _parentShareClient;
        }

        /// <summary>
        /// Create a new <see cref="ShareDirectoryClient"/> that pointing to this <see cref="ShareFileClient"/>'s parent container.
        /// The new <see cref="ShareDirectoryClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="ShareFileClient"/>.
        /// </summary>
        /// <returns>A new <see cref="ShareFileClient"/> instance.</returns>
        protected internal virtual ShareDirectoryClient GetParentShareDirectoryClientCore()
        {
            if (_parentShareDirectoryClient == null)
            {
                ShareUriBuilder shareUriBuilder = new ShareUriBuilder(Uri)
                {
                    Snapshot = null,
                };

                if (shareUriBuilder.DirectoryOrFilePath == null || shareUriBuilder.LastDirectoryOrFileName == null)
                {
                    throw new InvalidOperationException();
                }
                shareUriBuilder.DirectoryOrFilePath = shareUriBuilder.DirectoryOrFilePath.GetParentPath();

                _parentShareDirectoryClient = new ShareDirectoryClient(
                    shareUriBuilder.ToUri(),
                    ClientConfiguration);
            }

            return _parentShareDirectoryClient;
        }
        #endregion
    }

    namespace Specialized
    {
        /// <summary>
        /// Add easy to discover methods to <see cref="ShareFileClient"/> for
        /// creating <see cref="ShareClient"/> instances.
        /// </summary>
        public static partial class SpecializedShareExtensions
        {
            /// <summary>
            /// Create a new <see cref="ShareClient"/> that pointing to this <see cref="ShareFileClient"/>'s parent container.
            /// The new <see cref="ShareClient"/>
            /// uses the same request policy pipeline as the
            /// <see cref="ShareFileClient"/>.
            /// </summary>
            /// <param name="client">The <see cref="ShareFileClient"/>.</param>
            /// <returns>A new <see cref="ShareClient"/> instance.</returns>
            public static ShareClient GetParentShareClient(this ShareFileClient client)
            {
                return client.GetParentShareClientCore();
            }

            /// <summary>
            /// Create a new <see cref="ShareDirectoryClient"/> that pointing to this <see cref="ShareFileClient"/>'s parent container.
            /// The new <see cref="ShareDirectoryClient"/>
            /// uses the same request policy pipeline as the
            /// <see cref="ShareFileClient"/>.
            /// </summary>
            /// <param name="client">The <see cref="ShareFileClient"/>.</param>
            /// <returns>A new <see cref="ShareDirectoryClient"/> instance.</returns>
            public static ShareDirectoryClient GetParentShareDirectoryClient(this ShareFileClient client)
            {
                return client.GetParentShareDirectoryClientCore();
            }
        }
    }
}
