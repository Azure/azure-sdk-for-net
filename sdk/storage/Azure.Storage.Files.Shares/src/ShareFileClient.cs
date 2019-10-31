// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Files.Shares.Models;
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
        /// For more information, <see href="https://docs.microsoft.com/en-us/azure/storage/common/storage-configure-connection-string"/>.
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
        /// For more information, <see href="https://docs.microsoft.com/en-us/azure/storage/common/storage-configure-connection-string"/>.
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
            _clientDiagnostics = new ClientDiagnostics(options);
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
            : this(fileUri, (HttpPipelinePolicy)null, options)
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
            : this(fileUri, credential.AsPolicy(), options)
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
        internal ShareFileClient(Uri fileUri, HttpPipelinePolicy authentication, ShareClientOptions options)
        {
            options ??= new ShareClientOptions();
            _uri = fileUri;
            _pipeline = options.Build(authentication);
            _clientDiagnostics = new ClientDiagnostics(options);
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
        /// <param name="clientDiagnostics"></param>
        internal ShareFileClient(Uri fileUri, HttpPipeline pipeline, ClientDiagnostics clientDiagnostics)
        {
            _uri = fileUri;
            _pipeline = pipeline;
            _clientDiagnostics = clientDiagnostics;
        }
        #endregion ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareFileClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="shareSnapshot"/> timestamp.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/snapshot-share"/>.
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
            return new ShareFileClient(builder.ToUri(), Pipeline, ClientDiagnostics);
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
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-file"/>.
        /// </summary>
        /// <remarks>
        /// This method only initializes the file.
        /// To add content, use <see cref="UploadRange"/>.
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
        public virtual Response<ShareFileInfo> Create(
            long maxSize,
            ShareFileHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            FileSmbProperties smbProperties = default,
            string filePermission = default,
            CancellationToken cancellationToken = default) =>
            CreateInternal(
                maxSize,
                httpHeaders,
                metadata,
                smbProperties,
                filePermission,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Creates a new file or replaces an existing file.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-file"/>.
        /// </summary>
        /// <remarks>
        /// This method only initializes the file.
        /// To add content, use <see cref="UploadRangeAsync"/>.
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
        public virtual async Task<Response<ShareFileInfo>> CreateAsync(
            long maxSize,
            ShareFileHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            FileSmbProperties smbProperties = default,
            string filePermission = default,
            CancellationToken cancellationToken = default) =>
            await CreateInternal(
                maxSize,
                httpHeaders,
                metadata,
                smbProperties,
                filePermission,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Creates a new file or replaces an existing file.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-file"/>.
        /// </summary>
        /// <remarks>
        /// This method only initializes the file.
        /// To add content, use <see cref="UploadRangeAsync"/>.
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
        private async Task<Response<ShareFileInfo>> CreateInternal(
            long maxSize,
            ShareFileHttpHeaders httpHeaders,
            Metadata metadata,
            FileSmbProperties smbProperties,
            string filePermission,
            bool async,
            CancellationToken cancellationToken)
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
                        fileCreationTime: smbProps.FileCreationTimeToString() ?? Constants.File.FileTimeNow,
                        fileLastWriteTime: smbProps.FileLastWriteTimeToString() ?? Constants.File.FileTimeNow,
                        filePermissionKey: smbProps.FilePermissionKey,
                        async: async,
                        cancellationToken: cancellationToken,
                        operationName: Constants.File.CreateOperationName)
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

        #region StartCopy
        /// <summary>
        /// Copies a blob or file to a destination file within the storage account.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/copy-file"/>.
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
        public virtual Response<ShareFileCopyInfo> StartCopy(
            Uri sourceUri,
            Metadata metadata = default,
            CancellationToken cancellationToken = default) =>
            StartCopyInternal(
                sourceUri,
                metadata,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Copies a blob or file to a destination file within the storage account.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/copy-file"/>.
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
        public virtual async Task<Response<ShareFileCopyInfo>> StartCopyAsync(
            Uri sourceUri,
            Metadata metadata = default,
            CancellationToken cancellationToken = default) =>
            await StartCopyInternal(
                sourceUri,
                metadata,
                true, // async
                cancellationToken).
                ConfigureAwait(false);

        /// <summary>
        /// Copies a blob or file to a destination file within the storage account.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/copy-file"/>.
        /// </summary>
        /// <param name="sourceUri">
        /// Required. Specifies the URL of the source file or blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for the file.
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
                        copySource: sourceUri,
                        metadata: metadata,
                        async: async,
                        cancellationToken: cancellationToken,
                        operationName: Constants.File.StartCopyOperationName)
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
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/abort-copy-file"/>.
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
        public virtual Response AbortCopy(
            string copyId,
            CancellationToken cancellationToken = default) =>
            AbortCopyInternal(
                copyId,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Attempts to cancel a pending copy that was previously started and leaves a destination file with zero length and full metadata.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/abort-copy-file"/>.
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
        public virtual async Task<Response> AbortCopyAsync(
            string copyId,
            CancellationToken cancellationToken = default) =>
            await AbortCopyInternal(
                copyId,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Attempts to cancel a pending copy that was previously started and leaves a destination file with zero length and full metadata.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/abort-copy-file"/>.
        /// </summary>
        /// <param name="copyId">
        /// String identifier for the copy operation.
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
                        async: async,
                        cancellationToken: cancellationToken,
                        operationName: Constants.File.AbortCopyOperationName)
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
        /// The <see cref="Download"/> operation reads or downloads a file from the system, including its metadata and properties.
        ///
        /// For more information <see href="https://docs.microsoft.com/rest/api/storageservices/get-file"/>.
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
        public virtual Response<ShareFileDownloadInfo> Download(
            HttpRange range = default,
            bool rangeGetContentHash = default,
            CancellationToken cancellationToken = default) =>
            DownloadInternal(
                range,
                rangeGetContentHash,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="DownloadAsync"/> operation reads or downloads a file from the system, including its metadata and properties.
        ///
        /// For more information <see href="https://docs.microsoft.com/rest/api/storageservices/get-file"/>.
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
        public virtual async Task<Response<ShareFileDownloadInfo>> DownloadAsync(
            HttpRange range = default,
            bool rangeGetContentHash = default,
            CancellationToken cancellationToken = default) =>
            await DownloadInternal(
                range,
                rangeGetContentHash,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DownloadInternal"/> operation reads or downloads a file from the system, including its metadata and properties.
        ///
        /// For more information <see href="https://docs.microsoft.com/rest/api/storageservices/get-file"/>.
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
                                async,
                                cancellationToken)
                                .EnsureCompleted()
                                .Item2,
                        async startOffset =>
                            (await StartDownloadAsync(
                                range,
                                rangeGetContentHash,
                                startOffset,
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
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/get-file"/>.
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
                    range: pageRange.ToString(),
                    rangeGetContentHash: rangeGetContentHash ? (bool?)true : null,
                    async: async,
                    cancellationToken: cancellationToken,
                    operationName: Constants.File.DownloadOperationName)
                    .ConfigureAwait(false);
            Pipeline.LogTrace($"Response: {response.GetRawResponse().Status}, ContentLength: {response.Value.ContentLength}");
            return (response, stream);
        }
        #endregion Download

        #region Delete
        /// <summary>
        /// The <see cref="Delete"/> operation immediately removes the file from the storage account.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/delete-file2"/>.
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
        public virtual Response Delete(
            CancellationToken cancellationToken = default) =>
            DeleteInternal(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="DeleteAsync"/> operation immediately removes the file from the storage account.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/delete-file2"/>.
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
        public virtual async Task<Response> DeleteAsync(
            CancellationToken cancellationToken = default) =>
            await DeleteInternal(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DeleteInternal"/> operation immediately removes the file from the storage account.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/delete-file2"/>.
        /// </summary>
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
                    return await FileRestClient.File.DeleteAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        async: async,
                        cancellationToken: cancellationToken,
                        operationName: Constants.File.DeleteOperationName)
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
        /// The <see cref="GetProperties"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the file. It does not return the content of the
        /// file.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/get-file-properties"/>
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
        public virtual Response<ShareFileProperties> GetProperties(
            CancellationToken cancellationToken = default) =>
            GetPropertiesInternal(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetPropertiesAsync"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the file. It does not return the content of the
        /// file.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/get-file-properties"/>
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
        public virtual async Task<Response<ShareFileProperties>> GetPropertiesAsync(
            CancellationToken cancellationToken = default) =>
            await GetPropertiesInternal(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetPropertiesAsync"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the file. It does not return the content of the
        /// file.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/get-file-properties"/>
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
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
        private async Task<Response<ShareFileProperties>> GetPropertiesInternal(
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
                    Response<RawStorageFileProperties> response = await FileRestClient.File.GetPropertiesAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        async: async,
                        cancellationToken: cancellationToken,
                        operationName: Constants.File.GetPropertiesOperationName)
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
        /// The <see cref="SetHttpHeaders"/> operation sets system
        /// properties on the file.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-file-properties"/>.
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
        public virtual Response<ShareFileInfo> SetHttpHeaders(
            long? newSize = default,
            ShareFileHttpHeaders httpHeaders = default,
            FileSmbProperties smbProperties = default,
            string filePermission = default,
            CancellationToken cancellationToken = default) =>
            SetHttpHeadersInternal(
                newSize,
                httpHeaders,
                smbProperties,
                filePermission,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="SetHttpHeadersAsync"/> operation sets system
        /// properties on the file.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-file-properties"/>.
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
        public virtual async Task<Response<ShareFileInfo>> SetHttpHeadersAsync(
            long? newSize = default,
            ShareFileHttpHeaders httpHeaders = default,
            FileSmbProperties smbProperties = default,
            string filePermission = default,
            CancellationToken cancellationToken = default) =>
            await SetHttpHeadersInternal(
                newSize,
                httpHeaders,
                smbProperties,
                filePermission,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetHttpHeadersInternal"/> operation sets system
        /// properties on the file.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-file-properties"/>.
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
                        fileContentLength: newSize,
                        fileContentType: httpHeaders?.ContentType,
                        fileContentEncoding: httpHeaders?.ContentEncoding,
                        fileContentLanguage: httpHeaders?.ContentLanguage,
                        fileCacheControl: httpHeaders?.CacheControl,
                        fileContentHash: httpHeaders?.ContentHash,
                        fileContentDisposition: httpHeaders?.ContentDisposition,
                        fileAttributes: smbProps.FileAttributes?.ToAttributesString() ?? Constants.File.Preserve,
                        filePermission: filePermission,
                        fileCreationTime: smbProps.FileCreationTimeToString() ?? Constants.File.Preserve,
                        fileLastWriteTime: smbProps.FileLastWriteTimeToString() ?? Constants.File.Preserve,
                        filePermissionKey: smbProps.FilePermissionKey,
                        async: async,
                        operationName: Constants.File.SetHttpHeadersOperationName,
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
        /// The <see cref="SetMetadata"/> operation sets user-defined
        /// metadata for the specified file as one or more name-value pairs.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-file-metadata"/>
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
        public virtual Response<ShareFileInfo> SetMetadata(
            Metadata metadata,
            CancellationToken cancellationToken = default) =>
            SetMetadataInternal(
                metadata,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="SetMetadataAsync"/> operation sets user-defined
        /// metadata for the specified file as one or more name-value pairs.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-file-metadata"/>
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
        public virtual async Task<Response<ShareFileInfo>> SetMetadataAsync(
            Metadata metadata,
            CancellationToken cancellationToken = default) =>
            await SetMetadataInternal(
                metadata,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetMetadataInternal"/> operation sets user-defined
        /// metadata for the specified file as one or more name-value pairs.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-file-metadata"/>
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this file.
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
                        metadata: metadata,
                        async: async,
                        cancellationToken: cancellationToken,
                        operationName: Constants.File.SetMetadataOperationName)
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

        #region UploadRange
        /// <summary>
        /// The <see cref="UploadRange"/> operation writes
        /// <paramref name="content"/> to a <paramref name="range"/> of a file.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-range"/>
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
        /// A <see cref="Response{StorageFileUploadInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareFileUploadInfo> UploadRange(
            ShareFileRangeWriteType writeType,
            HttpRange range,
            Stream content,
            byte[] transactionalContentHash = null,
            IProgress<long> progressHandler = default,
            CancellationToken cancellationToken = default) =>
            UploadRangeInternal(
                writeType,
                range,
                content,
                transactionalContentHash,
                progressHandler,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="UploadRangeAsync"/> operation writes
        /// <paramref name="content"/> to a <paramref name="range"/> of a file.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-range"/>
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
        /// A <see cref="Response{StorageFileUploadInfo}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareFileUploadInfo>> UploadRangeAsync(
            ShareFileRangeWriteType writeType,
            HttpRange range,
            Stream content,
            byte[] transactionalContentHash = null,
            IProgress<long> progressHandler = default,
            CancellationToken cancellationToken = default) =>
            await UploadRangeInternal(
                writeType,
                range,
                content,
                transactionalContentHash,
                progressHandler,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UploadRangeInternal"/> operation writes
        /// <paramref name="content"/> to a <paramref name="range"/> of a file.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-range"/>
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
            ShareFileRangeWriteType writeType,
            HttpRange range,
            Stream content,
            byte[] transactionalContentHash,
            IProgress<long> progressHandler,
            bool async,
            CancellationToken cancellationToken)
        {
            // TODO We should probably raise an exception if Stream is non-empty and writeType is Clear.

            using (Pipeline.BeginLoggingScope(nameof(ShareFileClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(writeType)}: {writeType}");
                try
                {
                    content = content.WithNoDispose().WithProgress(progressHandler);
                    var uploadAttempt = 0;
                    return await ReliableOperation.DoSyncOrAsync(
                        async,
                        reset: () => content.Seek(0, SeekOrigin.Begin),
                        predicate: e => true,
                        maximumRetries: Constants.MaxReliabilityRetries,
                        operation:
                            () =>
                            {
                                Pipeline.LogTrace($"Upload attempt {++uploadAttempt}");
                                return FileRestClient.File.UploadRangeAsync(
                                    ClientDiagnostics,
                                    Pipeline,
                                    Uri,
                                    optionalbody: content,
                                    contentLength: content.Length,
                                    range: range.ToString(),
                                    fileRangeWrite: writeType,
                                    contentHash: transactionalContentHash,
                                    async: async,
                                    cancellationToken: cancellationToken,
                                    operationName: Constants.File.UploadRangeOperationName);
                            },
                        cleanup: () => { })
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
        #endregion UploadRange

        #region UploadRangeFromUrl
        /// <summary>
        /// The <see cref="UploadRangeFromUri"/> operation writes a range from an Azure File to another Azure file.
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
            CancellationToken cancellationToken = default) =>
            this.UploadRangeFromUriInternal(
                sourceUri,
                range,
                sourceRange,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="UploadRangeFromUriAsync"/> operation writes a range from an Azure File to another Azure file.
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
        public virtual async Task<Response<ShareFileUploadInfo>> UploadRangeFromUriAsync(
            Uri sourceUri,
            HttpRange range,
            HttpRange sourceRange,
            CancellationToken cancellationToken = default) =>
            await this.UploadRangeFromUriInternal(
                sourceUri,
                range,
                sourceRange,
                true, // async
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
                        sourceRange: sourceRange.ToString(),
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
        /// The <see cref="Upload"/> operation writes <paramref name="content"/>
        /// to a file.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-range"/>
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
        [ForwardsClientCalls]
        public virtual Response<ShareFileUploadInfo> Upload(
            Stream content,
            IProgress<long> progressHandler = default,
            CancellationToken cancellationToken = default) =>
            UploadInternal(
                content,
                progressHandler,
                Constants.File.MaxFileUpdateRange,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="UploadAsync"/> operation writes
        /// <paramref name="content"/> to a file.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-range"/>
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
        [ForwardsClientCalls]
        public virtual async Task<Response<ShareFileUploadInfo>> UploadAsync(
            Stream content,
            IProgress<long> progressHandler = default,
            CancellationToken cancellationToken = default) =>
            await UploadInternal(
                content,
                progressHandler,
                Constants.File.MaxFileUpdateRange,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UploadInternal"/> operation writes
        /// <paramref name="content"/> to a file.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-range"/>
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
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
            int singleRangeThreshold,
            bool async,
            CancellationToken cancellationToken)
        {
            // Try to upload the file as a single range
            Debug.Assert(singleRangeThreshold <= Constants.File.MaxFileUpdateRange);
            try
            {
                var length = content.Length;
                if (length <= singleRangeThreshold)
                {
                    return await UploadRangeInternal(
                        ShareFileRangeWriteType.Update,
                        new HttpRange(0, length),
                        content,
                        null,
                        progressHandler,
                        async,
                        cancellationToken)
                        .ConfigureAwait(false);
                }
            }
            catch
            {
            }

            // Otherwise naively split the file into ranges and upload them individually
            var response = default(Response<ShareFileUploadInfo>);
            var pool = default(MemoryPool<byte>);
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
                        ShareFileRangeWriteType.Update,
                        new HttpRange(partition.ParentPosition, partition.Length),
                        partition,
                        null,
                        progressHandler,
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
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/list-ranges"/>.
        /// </summary>
        /// <param name="range">
        /// Optional. Specifies the range of bytes over which to list ranges, inclusively. If omitted, then all ranges for the file are returned.
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
            HttpRange range,
            CancellationToken cancellationToken = default) =>
            GetRangeListInternal(
                range,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Returns the list of valid ranges for a file.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/list-ranges"/>.
        /// </summary>
        /// <param name="range">
        /// Optional. Specifies the range of bytes over which to list ranges, inclusively. If omitted, then all ranges for the file are returned.
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
            HttpRange range,
            CancellationToken cancellationToken = default) =>
            await GetRangeListInternal(
                range,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Returns the list of valid ranges for a file.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/list-ranges"/>.
        /// </summary>
        /// <param name="range">
        /// Optional. Specifies the range of bytes over which to list ranges, inclusively. If omitted, then all ranges for the file are returned.
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
            HttpRange range,
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
                    return await FileRestClient.File.GetRangeListAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        range: range.ToString(),
                        async: async,
                        cancellationToken: cancellationToken,
                        operationName: Constants.File.GetRangeListOperationName)
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
        #endregion GetRangeList

        #region GetHandles
        /// <summary>
        /// The <see cref="GetHandles"/> operation returns an async sequence
        /// of the open handles on a directory or a file.  Enumerating the
        /// handles may make multiple requests to the service while fetching
        /// all the values.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/list-handles"/>.
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
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/list-handles"/>.
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
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/list-handles"/>.
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
                        marker: marker,
                        maxresults: maxResults,
                        async: async,
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
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/force-close-handles"/>.
        /// </summary>
        /// <param name="handleId">
        /// Specifies the handle ID to be closed.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the status of the
        /// <see cref="ForceCloseHandle"/> operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response ForceCloseHandle(
            string handleId,
            CancellationToken cancellationToken = default) =>
            ForceCloseHandlesInternal(
                handleId,
                null,
                false, // async,
                cancellationToken,
                Constants.File.ForceCloseHandleOperationName)
                .EnsureCompleted()
            .GetRawResponse();

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
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/force-close-handles"/>.
        /// </summary>
        /// <param name="handleId">
        /// Specifies the handle ID to be closed.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the status of the
        /// <see cref="ForceCloseHandle"/> operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> ForceCloseHandleAsync(
            string handleId,
            CancellationToken cancellationToken = default) =>
            (await ForceCloseHandlesInternal(
                handleId,
                null,
                true, // async,
                cancellationToken,
                Constants.File.ForceCloseHandleOperationName)
                .ConfigureAwait(false)).
            GetRawResponse();

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
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/force-close-handles"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// The number of handles closed.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual int ForceCloseAllHandles(
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
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/force-close-handles"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// The number of handles closed.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<int> ForceCloseAllHandlesAsync(
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
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/force-close-handles"/>.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// The number of handles closed.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<int> ForceCloseAllHandlesInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            int handlesClosed = 0;
            string marker = null;
            do
            {
                Response<StorageClosedHandlesSegment> response =
                    await ForceCloseHandlesInternal(Constants.CloseAllHandles, marker, async, cancellationToken).ConfigureAwait(false);
                marker = response.Value.Marker;
                handlesClosed += response.Value.NumberOfHandlesClosed;

            } while (!string.IsNullOrEmpty(marker));

            return handlesClosed;
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
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/force-close-handles"/>.
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
            string operationName = Constants.File.ForceCloseAllHandlesOperationName)
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
                        async: async,
                        cancellationToken: cancellationToken,
                        operationName: operationName)
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

        #region Helpers

        #endregion Helpers
    }
}
