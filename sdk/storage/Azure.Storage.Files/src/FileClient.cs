// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

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
using Azure.Core.Http;
using Azure.Core.Pipeline;
using Azure.Storage.Common;
using Azure.Storage.Files.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files
{
    /// <summary>
    /// The <see cref="FileClient"/> allows you to manipulate Azure Storage files.
    /// </summary>
    public class FileClient
    {
        /// <summary>
        /// The directory's primary <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _uri;

        /// <summary>
        /// Gets the directory's primary <see cref="Uri"/> endpoint.
        /// </summary>
        public virtual Uri Uri => this._uri;

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send
        /// every request.
        /// </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary>
        /// Gets the <see cref="HttpPipeline"/> transport pipeline used to send
        /// every request.
        /// </summary>
        protected virtual HttpPipeline Pipeline => this._pipeline;

        //const string fileType = "file";

        //// FileMaxUploadRangeBytes indicates the maximum number of bytes that can be sent in a call to UploadRange.
        //public const Int64 FileMaxUploadRangeBytes = 4 * Constants.MB; // 4MB

        //// FileMaxSizeInBytes indicates the maxiumum file size, in bytes.
        //public const Int64 FileMaxSizeInBytes = 1 * Constants.TB; // 1TB

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="FileClient"/>
        /// class for mocking.
        /// </summary>
        protected FileClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileClient"/> class.
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
        public FileClient(string connectionString, string shareName, string filePath)
            : this(connectionString, shareName, filePath, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileClient"/> class.
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
        /// Optional <see cref="FileClientOptions"/> that define the transport
        /// pipeline policies for authentication, retries, etc., that are
        /// applied to every request.
        /// </param>
        public FileClient(string connectionString, string shareName, string filePath, FileClientOptions options)
        {
            var conn = StorageConnectionString.Parse(connectionString);
            var builder =
                new FileUriBuilder(conn.FileEndpoint)
                {
                    ShareName = shareName,
                    DirectoryOrFilePath = filePath
                };
            this._uri = builder.Uri;
            this._pipeline = (options ?? new FileClientOptions()).Build(conn.Credentials);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileClient"/> class.
        /// </summary>
        /// <param name="fileUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the share, and the path of the
        /// file.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="FileClientOptions"/> that define the transport
        /// pipeline policies for authentication, retries, etc., that are
        /// applied to every request.
        /// </param>
        public FileClient(Uri fileUri, FileClientOptions options = default)
            : this(fileUri, (HttpPipelinePolicy)null, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileClient"/> class.
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
        /// Optional <see cref="FileClientOptions"/> that define the transport
        /// pipeline policies for authentication, retries, etc., that are
        /// applied to every request.
        /// </param>
        public FileClient(Uri fileUri, StorageSharedKeyCredential credential, FileClientOptions options = default)
            : this(fileUri, credential.AsPolicy(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileClient"/>
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
        internal FileClient(Uri fileUri, HttpPipelinePolicy authentication, FileClientOptions options)
        {
            this._uri = fileUri;
            this._pipeline = (options ?? new FileClientOptions()).Build(authentication);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileClient"/> class.
        /// </summary>
        /// <param name="fileUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the share, and the path of the file.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        internal FileClient(Uri fileUri, HttpPipeline pipeline)
        {
            this._uri = fileUri;
            this._pipeline = pipeline;
        }
        #endregion ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="FileClient"/>
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
        /// A new <see cref="FileClient"/> instance.
        /// </returns>
        public virtual FileClient WithSnapshot(string shareSnapshot)
        {
            var builder = new FileUriBuilder(this.Uri) { Snapshot = shareSnapshot };
            return new FileClient(builder.Uri, this.Pipeline);
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<StorageFileInfo> Create(
            long maxSize,
            FileHttpHeaders? httpHeaders = default,
            Metadata metadata = default,
            FileSmbProperties? smbProperties = default,
            string filePermission = default,
            CancellationToken cancellationToken = default) =>
            this.CreateInternal(
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<StorageFileInfo>> CreateAsync(
            long maxSize,
            FileHttpHeaders? httpHeaders = default,
            Metadata metadata = default,
            FileSmbProperties? smbProperties = default,
            string filePermission = default,
            CancellationToken cancellationToken = default) =>
            await this.CreateInternal(
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<StorageFileInfo>> CreateInternal(
            long maxSize,
            FileHttpHeaders? httpHeaders,
            Metadata metadata,
            FileSmbProperties? smbProperties,
            string filePermission,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(FileClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(maxSize)}: {maxSize}\n" +
                    $"{nameof(httpHeaders)}: {httpHeaders}");
                try
                {
                    var smbProps = smbProperties ?? new FileSmbProperties();

                    FileExtensions.AssertValidFilePermissionAndKey(filePermission, smbProps.FilePermissionKey);

                    if(filePermission == null && smbProps.FilePermissionKey == null)
                    {
                        filePermission = Constants.File.FilePermissionInherit;
                    }

                    var response = await FileRestClient.File.CreateAsync(
                        this.Pipeline,
                        this.Uri,
                        fileContentLength: maxSize,
                        fileContentType: httpHeaders?.ContentType,
                        fileContentEncoding: httpHeaders?.ContentEncoding,
                        fileContentLanguage: httpHeaders?.ContentLanguage,
                        fileCacheControl: httpHeaders?.CacheControl,
                        fileContentHash: httpHeaders?.ContentHash,
                        fileContentDisposition: httpHeaders?.ContentDisposition,
                        metadata: metadata,
                        fileAttributes: smbProps.FileAttributes?.ToString() ?? Constants.File.FileAttributesNone,
                        filePermission: filePermission,
                        fileCreationTime: smbProps.FileCreationTimeToString() ?? Constants.File.FileTimeNow,
                        fileLastWriteTime: smbProps.FileLastWriteTimeToString() ?? Constants.File.FileTimeNow,
                        filePermissionKey: smbProps.FilePermissionKey,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return new Response<StorageFileInfo>(
                        response.GetRawResponse(),
                        new StorageFileInfo(response.Value));
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(FileClient));
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<StorageFileCopyInfo> StartCopy(
            Uri sourceUri,
            Metadata metadata = default,
            CancellationToken cancellationToken = default) =>
            this.StartCopyInternal(
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<StorageFileCopyInfo>> StartCopyAsync(
            Uri sourceUri,
            Metadata metadata = default,
            CancellationToken cancellationToken = default) =>
            await this.StartCopyInternal(
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<StorageFileCopyInfo>> StartCopyInternal(
            Uri sourceUri,
            Metadata metadata,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(FileClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(sourceUri)}: {sourceUri}");
                try
                {
                    return await FileRestClient.File.StartCopyAsync(
                        this.Pipeline,
                        this.Uri,
                        copySource: sourceUri,
                        metadata: metadata,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(FileClient));
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response AbortCopy(
            string copyId,
            CancellationToken cancellationToken = default) =>
            this.AbortCopyInternal(
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> AbortCopyAsync(
            string copyId,
            CancellationToken cancellationToken = default) =>
            await this.AbortCopyInternal(
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response> AbortCopyInternal(
            string copyId,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(FileClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(copyId)}: {copyId}");
                try
                {
                    return await FileRestClient.File.AbortCopyAsync(
                        this.Pipeline,
                        this.Uri,
                        copyId: copyId,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(FileClient));
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
        /// range exceeds 4 MB in size, a <see cref="StorageRequestFailedException"/>
        /// is thrown.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileDownloadInfo}"/> describing the
        /// downloaded file.  <see cref="StorageFileDownloadInfo.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<StorageFileDownloadInfo> Download(
            HttpRange range = default,
            bool rangeGetContentHash = default,
            CancellationToken cancellationToken = default) =>
            this.DownloadInternal(
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
        /// range exceeds 4 MB in size, a <see cref="StorageRequestFailedException"/>
        /// is thrown.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{StorageFileDownloadInfo}"/> describing the
        /// downloaded file.  <see cref="StorageFileDownloadInfo.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<StorageFileDownloadInfo>> DownloadAsync(
            HttpRange range = default,
            bool rangeGetContentHash = default,
            CancellationToken cancellationToken = default) =>
            await this.DownloadInternal(
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
        /// range exceeds 4 MB in size, a <see cref="StorageRequestFailedException"/>
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
        /// downloaded file.  <see cref="StorageFileDownloadInfo.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<StorageFileDownloadInfo>> DownloadInternal(
            HttpRange range,
            bool rangeGetContentHash,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(FileClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(rangeGetContentHash)}: {rangeGetContentHash}");
                try
                {
                    // Start downloading the file
                    var response = await this.StartDownloadAsync(
                        range,
                        rangeGetContentHash,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    // Wrap the response Content in a RetriableStream so we
                    // can return it before it's finished downloading, but still
                    // allow retrying if it fails.
                    response.Value.Content = RetriableStream.Create(
                        response.GetRawResponse(),
                        startOffset =>
                            this.StartDownloadAsync(
                                range,
                                rangeGetContentHash,
                                startOffset,
                                async,
                                cancellationToken)
                                .EnsureCompleted()
                                .GetRawResponse(),
                        async startOffset =>
                            (await this.StartDownloadAsync(
                                range,
                                rangeGetContentHash,
                                startOffset,
                                async,
                                cancellationToken)
                                .ConfigureAwait(false))
                                .GetRawResponse(),
                        // TODO: For now we're using the default ResponseClassifier
                        // on FileConnectionOptions so we'll do the same here
                        new ResponseClassifier(),
                        Constants.MaxReliabilityRetries);

                    // Wrap the FlattenedStorageFileProperties into a StorageFileDownloadInfo
                    // to make the Content easier to find
                    return new Response<StorageFileDownloadInfo>(
                        response.GetRawResponse(),
                        new StorageFileDownloadInfo(response.Value));
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(FileClient));
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
        /// range exceeds 4 MB in size, a <see cref="StorageRequestFailedException"/>
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
        private async Task<Response<FlattenedStorageFileProperties>> StartDownloadAsync(
            HttpRange range = default,
            bool rangeGetContentHash = default,
            long startOffset = 0,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            var pageRange = new HttpRange(
                range.Offset + startOffset,
                range.Count.HasValue ?
                    range.Count.Value - startOffset :
                    (long?)null);
            this.Pipeline.LogTrace($"Download {this.Uri} with range: {pageRange}");
            var response =
                await FileRestClient.File.DownloadAsync(
                    this.Pipeline,
                    this.Uri,
                    range: pageRange.ToString(),
                    rangeGetContentHash: rangeGetContentHash ? (bool?)true : null,
                    async: async,
                    bufferResponse: false,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            this.Pipeline.LogTrace($"Response: {response.GetRawResponse().Status}, ContentLength: {response.Value.ContentLength}");
            return response;
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response Delete(
            CancellationToken cancellationToken = default) =>
            this.DeleteInternal(
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> DeleteAsync(
            CancellationToken cancellationToken = default) =>
            await this.DeleteInternal(
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response> DeleteInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(FileClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await FileRestClient.File.DeleteAsync(
                        this.Pipeline,
                        this.Uri,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(FileClient));
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
        /// <param name="shareSnapshot">
        /// Optional. The snapshot identifier.
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<StorageFileProperties> GetProperties(
            string shareSnapshot = default,
            CancellationToken cancellationToken = default) =>
            this.GetPropertiesInternal(
                shareSnapshot,
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
        /// <param name="shareSnapshot">
        /// Optional. The snapshot identifier.
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<StorageFileProperties>> GetPropertiesAsync(
            string shareSnapshot = default,
            CancellationToken cancellationToken = default) =>
            await this.GetPropertiesInternal(
                shareSnapshot,
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
        /// <param name="shareSnapshot">
        /// Optional. The snapshot identifier.
        /// </param>
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<StorageFileProperties>> GetPropertiesInternal(
            string shareSnapshot,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(FileClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(shareSnapshot)}: {shareSnapshot}");
                try
                {
                    var response = await FileRestClient.File.GetPropertiesAsync(
                        this.Pipeline,
                        this.Uri,
                        sharesnapshot: shareSnapshot,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return new Response<StorageFileProperties>(
                        response.GetRawResponse(),
                        new StorageFileProperties(response.Value));
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(FileClient));
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<StorageFileInfo> SetHttpHeaders(
            long? newSize = default,
            FileHttpHeaders? httpHeaders = default,
            FileSmbProperties?  smbProperties = default,
            string filePermission = default,
            CancellationToken cancellationToken = default) =>
            this.SetHttpHeadersInternal(
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<StorageFileInfo>> SetHttpHeadersAsync(
            long? newSize = default,
            FileHttpHeaders? httpHeaders = default,
            FileSmbProperties? smbProperties = default,
            string filePermission = default,
            CancellationToken cancellationToken = default) =>
            await this.SetHttpHeadersInternal(
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<StorageFileInfo>> SetHttpHeadersInternal(
            long? newSize,
            FileHttpHeaders? httpHeaders,
            FileSmbProperties? smbProperties,
            string filePermission,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(FileClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(newSize)}: {newSize}\n" +
                    $"{nameof(httpHeaders)}: {httpHeaders}");
                try
                {
                    var smbProps = smbProperties ?? new FileSmbProperties();

                    FileExtensions.AssertValidFilePermissionAndKey(filePermission, smbProps.FilePermissionKey);
                    if(filePermission == null && smbProps.FilePermissionKey == null)
                    {
                        filePermission = Constants.File.Preserve;
                    }

                    var response = await FileRestClient.File.SetPropertiesAsync(
                        this.Pipeline,
                        this.Uri,
                        fileContentLength: newSize,
                        fileContentType: httpHeaders?.ContentType,
                        fileContentEncoding: httpHeaders?.ContentEncoding,
                        fileContentLanguage: httpHeaders?.ContentLanguage,
                        fileCacheControl: httpHeaders?.CacheControl,
                        fileContentHash: httpHeaders?.ContentHash,
                        fileContentDisposition: httpHeaders?.ContentDisposition,
                        fileAttributes: smbProps.FileAttributes?.ToString() ?? Constants.File.Preserve,
                        filePermission:  filePermission,
                        fileCreationTime: smbProps.FileCreationTimeToString() ?? Constants.File.Preserve,
                        fileLastWriteTime: smbProps.FileLastWriteTimeToString() ?? Constants.File.Preserve,
                        filePermissionKey: smbProps.FilePermissionKey,
                        async: async,
                        operationName: Constants.File.SetHttpHeadersOperationName,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return new Response<StorageFileInfo>(
                        response.GetRawResponse(),
                        new StorageFileInfo(response.Value));
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(FileClient));
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<StorageFileInfo> SetMetadata(
            Metadata metadata,
            CancellationToken cancellationToken = default) =>
            this.SetMetadataInternal(
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<StorageFileInfo>> SetMetadataAsync(
            Metadata metadata,
            CancellationToken cancellationToken = default) =>
            await this.SetMetadataInternal(
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<StorageFileInfo>> SetMetadataInternal(
            Metadata metadata,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(FileClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    var response = await FileRestClient.File.SetMetadataAsync(
                        this.Pipeline,
                        this.Uri,
                        metadata: metadata,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return new Response<StorageFileInfo>(
                        response.GetRawResponse(),
                        new StorageFileInfo(response.Value));
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(FileClient));
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
        /// Optional MD5 hash of the range content.  Must not be used when <paramref name="writeType"/> is set to <see cref="FileRangeWriteType.Clear"/>.
        ///
        /// This hash is used to verify the integrity of the range during transport. When this hash
        /// is specified, the storage service compares the hash of the content
        /// that has arrived with this value.  Note that this MD5 hash is not
        /// stored with the file.  If the two hashes do not match, the
        /// operation will fail with a <see cref="StorageRequestFailedException"/>.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{StorageProgress}"/> to provide
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<StorageFileUploadInfo> UploadRange(
            FileRangeWriteType writeType,
            HttpRange range,
            Stream content,
            byte[] transactionalContentHash = null,
            IProgress<StorageProgress> progressHandler = default,
            CancellationToken cancellationToken = default) =>
            this.UploadRangeInternal(
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
        /// Optional MD5 hash of the range content.  Must not be used when <paramref name="writeType"/> is set to <see cref="FileRangeWriteType.Clear"/>.
        ///
        /// This hash is used to verify the integrity of the range during transport. When this hash
        /// is specified, the storage service compares the hash of the content
        /// that has arrived with this value.  Note that this MD5 hash is not
        /// stored with the file.  If the two hashes do not match, the
        /// operation will fail with a <see cref="StorageRequestFailedException"/>.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{StorageProgress}"/> to provide
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<StorageFileUploadInfo>> UploadRangeAsync(
            FileRangeWriteType writeType,
            HttpRange range,
            Stream content,
            byte[] transactionalContentHash = null,
            IProgress<StorageProgress> progressHandler = default,
            CancellationToken cancellationToken = default) =>
            await this.UploadRangeInternal(
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
        /// Optional MD5 hash of the range content.  Must not be used when <paramref name="writeType"/> is set to <see cref="FileRangeWriteType.Clear"/>.
        ///
        /// This hash is used to verify the integrity of the range during transport. When this hash
        /// is specified, the storage service compares the hash of the content
        /// that has arrived with this value.  Note that this MD5 hash is not
        /// stored with the file.  If the two hashes do not match, the
        /// operation will fail with a <see cref="StorageRequestFailedException"/>.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{StorageProgress}"/> to provide
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<StorageFileUploadInfo>> UploadRangeInternal(
            FileRangeWriteType writeType,
            HttpRange range,
            Stream content,
            byte[] transactionalContentHash,
            IProgress<StorageProgress> progressHandler,
            bool async,
            CancellationToken cancellationToken)
        {
            // TODO We should probably raise an exception if Stream is non-empty and writeType is Clear.

            using (this.Pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(FileClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
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
                                this.Pipeline.LogTrace($"Upload attempt {++uploadAttempt}");
                                return FileRestClient.File.UploadRangeAsync(
                                    this.Pipeline,
                                    this.Uri,
                                    optionalbody: content,
                                    contentLength: content.Length,
                                    range: range.ToString(),
                                    fileRangeWrite: writeType,
                                    contentHash: transactionalContentHash,
                                    async: async,
                                    cancellationToken: cancellationToken);
                            },
                        cleanup: () => { })
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(FileClient));
                }
            }
        }
        #endregion UploadRange

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
        /// Optional <see cref="IProgress{StorageProgress}"/> to provide
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<StorageFileUploadInfo> Upload(
            Stream content,
            IProgress<StorageProgress> progressHandler = default,
            CancellationToken cancellationToken = default) =>
            this.UploadInternal(
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
        /// Optional <see cref="IProgress{StorageProgress}"/> to provide
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<StorageFileUploadInfo>> UploadAsync(
            Stream content,
            IProgress<StorageProgress> progressHandler = default,
            CancellationToken cancellationToken = default) =>
            await this.UploadInternal(
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
        /// Optional <see cref="IProgress{StorageProgress}"/> to provide
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<Response<StorageFileUploadInfo>> UploadInternal(
            Stream content,
            IProgress<StorageProgress> progressHandler,
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
                    return await this.UploadRangeInternal(
                        FileRangeWriteType.Update,
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
            var response = default(Response<StorageFileUploadInfo>);
            var pool = default(MemoryPool<byte>);
            try
            {
                pool = (singleRangeThreshold < MemoryPool<byte>.Shared.MaxBufferSize) ?
                    MemoryPool<byte>.Shared :
                    new StorageMemoryPool(singleRangeThreshold, 1);
                for (;;)
                {
                    // Get the next chunk of content
                    var parentPosition = content.Position;
                    var buffer = pool.Rent(singleRangeThreshold);
                    if (!MemoryMarshal.TryGetArray<byte>(buffer.Memory, out var segment))
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
                    response = await this.UploadRangeInternal(
                        FileRangeWriteType.Update,
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
        /// <param name="shareSnapshot">
        /// Optional. Specifies the share snapshot to query.
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<StorageFileRangeInfo> GetRangeList(
            HttpRange range,
            string shareSnapshot = default,
            CancellationToken cancellationToken = default) =>
            this.GetRangeListInternal(
                range,
                shareSnapshot,
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
        /// <param name="shareSnapshot">
        /// Optional. Specifies the share snapshot to query.
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<StorageFileRangeInfo>> GetRangeListAsync(
            HttpRange range,
            string shareSnapshot = default,
            CancellationToken cancellationToken = default) =>
            await this.GetRangeListInternal(
                range,
                shareSnapshot,
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
        /// <param name="shareSnapshot">
        /// Optional. Specifies the share snapshot to query.
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<StorageFileRangeInfo>> GetRangeListInternal(
            HttpRange range,
            string shareSnapshot,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(FileClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(shareSnapshot)}: {shareSnapshot}");
                try
                {
                    return await FileRestClient.File.GetRangeListAsync(
                        this.Pipeline,
                        this.Uri,
                        sharesnapshot: shareSnapshot,
                        range: range.ToString(),
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(FileClient));
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual IEnumerable<Response<StorageHandle>> GetHandles(
            CancellationToken cancellationToken = default) =>
            new GetFileHandlesAsyncCollection(this, cancellationToken);

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
        /// A <see cref="AsyncCollection{StorageHandle}"/> describing the
        /// handles on the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual AsyncCollection<StorageHandle> GetHandlesAsync(
            CancellationToken cancellationToken = default) =>
            new GetFileHandlesAsyncCollection(this, cancellationToken);

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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<Response<StorageHandlesSegment>> GetHandlesInternal(
            string marker,
            int? maxResults,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(FileClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(marker)}: {marker}\n" +
                    $"{nameof(maxResults)}: {maxResults}");
                try
                {
                    return await FileRestClient.File.ListHandlesAsync(
                        this.Pipeline,
                        this.Uri,
                        marker: marker,
                        maxresults: maxResults,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(FileClient));
                }
            }
        }
        #endregion GetHandles

        #region ForceCloseHandles
        /// <summary>
        /// The <see cref="ForceCloseHandles"/> operation closes a handle or handles opened on a file
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
        /// to be closed with the next call to <see cref="ForceCloseHandles"/>.  The
        /// operation returns a non-empty <see cref="StorageClosedHandlesSegment.Marker"/>
        /// if the operation did not return all items remaining to be
        /// closed with the current segment.  The NextMarker value can
        /// be used as the value for the <paramref name="marker"/> parameter
        /// in a subsequent call to request the closure of the next segment of handles.
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
            CancellationToken cancellationToken = default) =>
            this.ForceCloseHandlesInternal(
                handleId,
                marker,
                false, // async,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="ForceCloseHandlesAsync"/> operation closes a handle or handles opened on a file
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
        /// to be closed with the next call to <see cref="ForceCloseHandlesAsync"/>.  The
        /// operation returns a non-empty <see cref="StorageClosedHandlesSegment.Marker"/>
        /// if the operation did not return all items remaining to be
        /// closed with the current segment.  The NextMarker value can
        /// be used as the value for the <paramref name="marker"/> parameter
        /// in a subsequent call to request the closure of the next segment of handles.
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
            CancellationToken cancellationToken = default) =>
            await this.ForceCloseHandlesInternal(
                handleId,
                marker,
                true, // async,
                cancellationToken)
                .ConfigureAwait(false);

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
        /// to be closed with the next call to <see cref="ForceCloseHandlesAsync"/>.  The
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
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(FileClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(handleId)}: {handleId}\n" +
                    $"{nameof(marker)}: {marker}");
                try
                {
                    return await FileRestClient.File.ForceCloseHandlesAsync(
                        this.Pipeline,
                        this.Uri,
                        marker: marker,
                        handleId: handleId,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(FileClient));
                }
            }
        }
        #endregion ForceCloseHandles

        #region Helpers

        #endregion Helpers
    }
}
