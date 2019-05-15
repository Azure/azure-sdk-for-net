// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
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
        /// Gets the directory's primary <see cref="Uri"/> endpoint.
        /// </summary>
        public Uri Uri { get; }

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send 
        /// every request.
        /// </summary>
        private readonly HttpPipeline _pipeline;

        //const string fileType = "file";

        //// FileMaxUploadRangeBytes indicates the maximum number of bytes that can be sent in a call to UploadRange.
        //public const Int64 FileMaxUploadRangeBytes = 4 * Constants.MB; // 4MB

        //// FileMaxSizeInBytes indicates the maxiumum file size, in bytes.
        //public const Int64 FileMaxSizeInBytes = 1 * Constants.TB; // 1TB

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
        /// <param name="connectionOptions">
        /// Optional <see cref="FileConnectionOptions"/> that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        /// <remarks>
        /// The credentials on <paramref name="connectionString"/> will override those on <paramref name="connectionOptions"/>.
        /// </remarks>
        public FileClient(string connectionString, string shareName, string filePath, FileConnectionOptions connectionOptions = default)
        {
            var conn = StorageConnectionString.Parse(connectionString);

            var builder =
                new FileUriBuilder(conn.FileEndpoint)
                {
                    ShareName = shareName,
                    DirectoryOrFilePath = filePath
                };

            // TODO: perform a copy of the options instead
            var connOptions = connectionOptions ?? new FileConnectionOptions();
            connOptions.Credentials = conn.Credentials;

            this.Uri = builder.ToUri();
            this._pipeline = connOptions.Build();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileClient"/> class.
        /// </summary>
        /// <param name="primaryUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the share, and the path of the file.
        /// </param>
        /// <param name="connectionOptions">
        /// Optional <see cref="FileConnectionOptions"/> that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public FileClient(Uri primaryUri, FileConnectionOptions connectionOptions = default)
            : this(primaryUri, (connectionOptions ?? new FileConnectionOptions()).Build())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileClient"/> class.
        /// </summary>
        /// <param name="primaryUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the share, and the path of the file.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        internal FileClient(Uri primaryUri, HttpPipeline pipeline)
        {
            this.Uri = primaryUri;
            this._pipeline = pipeline;
        }

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
        public FileClient WithSnapshot(string shareSnapshot)
        {
            var builder = new FileUriBuilder(this.Uri) { Snapshot = shareSnapshot };
            return new FileClient(builder.ToUri(), this._pipeline);
        }

        /// <summary>
        /// Creates a new file or replaces an existing file.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/en-us/rest/api/storageservices/create-file"/>.
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
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{StorageFileInfo}}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<StorageFileInfo>> CreateAsync(
            long maxSize, 
            FileHttpHeaders? httpHeaders = default, 
            Metadata metadata = default,
            CancellationToken cancellation = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(FileClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(maxSize)}: {maxSize}\n" +
                    $"{nameof(httpHeaders)}: {httpHeaders}");
                try
                {
                    return await FileRestClient.File.CreateAsync(
                        this._pipeline,
                        this.Uri,
                        fileContentLength: maxSize,
                        fileContentType: httpHeaders?.ContentType,
                        fileContentEncoding: httpHeaders?.ContentEncoding,
                        fileContentLanguage: httpHeaders?.ContentLanguage,
                        fileCacheControl: httpHeaders?.CacheControl,
                        fileContentHash: httpHeaders?.ContentHash,
                        fileContentDisposition: httpHeaders?.ContentDisposition,
                        metadata: metadata,
                        cancellation: cancellation)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(FileClient));
                }
            }
        }

        /// <summary>
        /// Copies a blob or file to a destination file within the storage account.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/copy-file"/>.
        /// </summary>
        /// <param name="sourceUri">
        /// Required. Specifies the URL of the source file or blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for the file.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{StorageFileInfo}}"/> describing the
        /// state of the file copy.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>   
        public async Task<Response<StorageFileCopyInfo>> StartCopyAsync(
            Uri sourceUri, 
            Metadata metadata = default,
            CancellationToken cancellation = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(FileClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(sourceUri)}: {sourceUri}");
                try
                {
                    return await FileRestClient.File.StartCopyAsync(
                        this._pipeline,
                        this.Uri,
                        copySource: sourceUri,
                        metadata: metadata,
                        cancellation: cancellation)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(FileClient));
                }
            }
        }

        // TODO The REST documentation say "full metadata", not "empty".  Doc bug?

        /// <summary>
        /// Attempts to cancel a pending copy that was previously started and leaves a destination file with zero length and full metadata.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/abort-copy-file"/>.
        /// </summary>
        /// <param name="copyId">
        /// String identifier for the copy operation.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response}"/> on successfully aborting.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response> AbortCopyAsync(
            string copyId,
            CancellationToken cancellation = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(FileClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(copyId)}: {copyId}");
                try
                {
                    return await FileRestClient.File.AbortCopyAsync(
                        this._pipeline,
                        this.Uri,
                        copyId: copyId,
                        cancellation: cancellation)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(FileClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="DownloadAsync"/> operation reads or downloads a file from the system, including its metadata and properties.
        /// 
        /// For more information <see cref="https://docs.microsoft.com/rest/api/storageservices/get-file"/>.
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
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{StorageFileDownloadInfo}}"/> describing the
        /// downloaded file.  <see cref="StorageFileDownloadInfo.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<StorageFileDownloadInfo>> DownloadAsync(
            HttpRange range = default, 
            bool rangeGetContentHash = default,
            CancellationToken cancellation = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this._pipeline.LogMethodEnter(
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
                        cancellation: cancellation)
                        .ConfigureAwait(false);

                    // Wrap the response Content in a RetriableStream so we
                    // can return it before it's finished downloading, but still
                    // allow retrying if it fails.
                    response.Value.Content = RetriableStream.Create(
                        response.Raw,
                        async startOffset =>
                            (await this.StartDownloadAsync(
                                range,
                                rangeGetContentHash,
                                startOffset,
                                cancellation)
                                .ConfigureAwait(false))
                                .Raw,
                        // TODO: For now we're using the default ResponseClassifier
                        // on FileConnectionOptions so we'll do the same here
                        new ResponseClassifier(),
                        Constants.MaxReliabilityRetries);

                    // Wrap the FlattenedStorageFileProperties into a StorageFileDownloadInfo
                    // to make the Content easier to find
                    return new Response<StorageFileDownloadInfo>(response.Raw, new StorageFileDownloadInfo(response.Value));
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(FileClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="StartDownloadAsync"/> operation starts to read or downloads a file from the system, including its metadata and properties.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/get-file"/>.
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
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{FlattenedStorageFileProperties}}"/> describing the
        /// downloaded file.  <see cref="FlattenedStorageFileProperties.Content"/> contains
        /// the file's data.
        /// </returns>
        private async Task<Response<FlattenedStorageFileProperties>> StartDownloadAsync(
        HttpRange range = default,
            bool rangeGetContentHash = default,
            long startOffset = 0,
            CancellationToken cancellation = default)
        {
            var pageRange = new HttpRange(
                range.Offset + startOffset,
                range.Count.HasValue ?
                    range.Count.Value - startOffset :
                    default);
            this._pipeline.LogTrace($"Download {this.Uri} with range: {pageRange}");
            var response =
                await FileRestClient.File.DownloadAsync(
                    this._pipeline,
                    this.Uri,
                    range: pageRange.ToRange(),
                    rangeGetContentHash: rangeGetContentHash ? (bool?)true : null,
                    cancellation: cancellation)
                    .ConfigureAwait(false);
            this._pipeline.LogTrace($"Response: {response.Raw.Status}, ContentLength: {response.Value.ContentLength}");
            return response;
        }

        /// <summary>
        /// The <see cref="DeleteAsync"/> operation immediately removes the file from the storage account.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/en-us/rest/api/storageservices/delete-file2"/>.
        /// </summary>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response}"/> on successfully deleting.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response> DeleteAsync(
            CancellationToken cancellation = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(FileClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await FileRestClient.File.DeleteAsync(
                        this._pipeline,
                        this.Uri,
                        cancellation: cancellation)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(FileClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="GetPropertiesAsync"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the file. It does not return the content of the
        /// file.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/get-file-properties"/>
        /// </summary>
        /// <param name="shareSnapshot">
        /// Optional. The snapshot identifier.
        /// </param>  
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{StorageFileProperties}}"/> describing the
        /// file's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<StorageFileProperties>> GetPropertiesAsync( 
            string shareSnapshot = default,
            CancellationToken cancellation = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(FileClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(shareSnapshot)}: {shareSnapshot}");
                try
                {
                    return await FileRestClient.File.GetPropertiesAsync(
                        this._pipeline,
                        this.Uri,
                        sharesnapshot: shareSnapshot,
                        cancellation: cancellation)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(FileClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="SetHttpHeadersAsync"/> operation sets system
        /// properties on the file.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/set-file-properties"/>.
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
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{StorageFileInfo}}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<StorageFileInfo>> SetHttpHeadersAsync(
            long? newSize = default,
            FileHttpHeaders? httpHeaders = default,
            CancellationToken cancellation = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(FileClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(newSize)}: {newSize}\n" +
                    $"{nameof(httpHeaders)}: {httpHeaders}");
                try
                {
                    return await FileRestClient.File.SetPropertiesAsync(
                        this._pipeline,
                        this.Uri,
                        fileContentLength: newSize,
                        fileContentType: httpHeaders?.ContentType,
                        fileContentEncoding: httpHeaders?.ContentEncoding,
                        fileContentLanguage: httpHeaders?.ContentLanguage,
                        fileCacheControl: httpHeaders?.CacheControl,
                        fileContentHash: httpHeaders?.ContentHash,
                        fileContentDisposition: httpHeaders?.ContentDisposition,
                        cancellation: cancellation)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(FileClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="SetMetadataAsync"/> operation sets user-defined 
        /// metadata for the specified file as one or more name-value pairs.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/set-file-metadata"/>
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this file.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{StorageFileInfo}}"/> describing the updated
        /// file.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<StorageFileInfo>> SetMetadataAsync( 
            Metadata metadata,
            CancellationToken cancellation = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(FileClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await FileRestClient.File.SetMetadataAsync(
                        this._pipeline,
                        this.Uri,
                         metadata: metadata,
                        cancellation: cancellation)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(FileClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="UploadRangeAsync"/> operation writes
        /// <paramref name="content"/> to a <paramref name="range"/> of a file.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/en-us/rest/api/storageservices/put-range"/>
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
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{StorageFileUploadInfo}}"/> describing the
        /// state of the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<StorageFileUploadInfo>> UploadRangeAsync(
            FileRangeWriteType writeType,
            HttpRange range, 
            Stream content,
            byte[] transactionalContentHash = null,
            IProgress<StorageProgress> progressHandler = default,
            CancellationToken cancellation = default)
        {
            // TODO We should probably raise an exception if Stream is non-empty and writeType is Clear.

            using (this._pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(FileClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(writeType)}: {writeType}");
                try
                {
                    content = content.WithNoDispose().WithProgress(progressHandler);
                    var uploadAttempt = 0;
                    return await ReliableOperation.DoAsync(
                        reset: () => content.Seek(0, SeekOrigin.Begin),
                        predicate: e => true,
                        maximumRetries: Constants.MaxReliabilityRetries,
                        operation:
                            async () =>
                            {
                                this._pipeline.LogTrace($"Upload attempt {++uploadAttempt}");
                                return await FileRestClient.File.UploadRangeAsync(
                                    this._pipeline,
                                    this.Uri,
                                    optionalbody: content,
                                    contentLength: content.Length,
                                    range: range.ToRange(),
                                    fileRangeWrite: writeType,
                                    contentHash: transactionalContentHash,
                                    cancellation: cancellation)
                                    .ConfigureAwait(false);
                            },
                        cleanup: () => { })
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(FileClient));
                }
            }
            /*
            using (this.Pipeline.Logger.BeginScope($"{nameof(FileUri)} {nameof(this.UploadRangeAsync)}"))
            {
                this.Pipeline.Logger.LogMethodEnter(
                    className: nameof(FileUri),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n"
                    + $"{nameof(writeType)}: {writeType}\n");
                    //+ $"{nameof(contentLength)}: {contentLength}");

                cancelContext = cancelContext ?? CancelContext.None;

                var exception = default(ExceptionDispatchInfo);

                body = body.WithNoDispose().WithProgress(progressHandler);

                var uploadAttempt = 0;

                var result =
                    await ReliableOperation.DoAsync(
                        operation: async () =>
                        {
                            this.Pipeline.Logger.LogTrace("Upload attempt {uploadAttempt}", ++uploadAttempt);

                            var responseHeaders = default(IFileUploadRangeCreatedResponseHeaders);

                            await this.StorageClient.FileUploadRange(
                                resourceUri: this.Uri,
                                pipeline: this.Pipeline,
                                context: cancelContext,
                                timeout: default,
                                range: range.ToRange(),
                                fileRangeWrite: writeType,
                                contentLength: default,
                                contentMD5: contentHash,
                                body: body,

                                onCreated:
                                (response, headers) =>
                                {
                                    responseHeaders = headers;
                                },

                                onDefault:
                                (response, error, errorHeaders) =>
                                {
                                    exception = ExceptionDispatchInfo.Capture(new StorageErrorException(error.Message, errorHeaders.ErrorCode, response));
                                }
                                ).ConfigureAwait(false);

                            return responseHeaders;
                        },
                        reset: () => body.Seek(0, SeekOrigin.Begin),
                        cleanup: () => { },
                        predicate: e => true,
                        maximumRetries: Constants.MaxReliabilityRetries
                        ).ConfigureAwait(false);

                this.Pipeline.Logger.LogAndThrow(exception);
                this.Pipeline.Logger.LogMethodExit(className: nameof(FileUri));

                return result;
            }
            */
        }

        /// <summary>
        /// Returns the list of valid ranges for a file.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/en-us/rest/api/storageservices/list-ranges"/>.
        /// </summary>
        /// <param name="range">
        /// Optional. Specifies the range of bytes over which to list ranges, inclusively. If omitted, then all ranges for the file are returned.
        /// </param>
        /// <param name="shareSnapshot">
        /// Optional. Specifies the share snapshot to query.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{StorageFileRangeInfo}}"/> describing the
        /// valid ranges for this file.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<StorageFileRangeInfo>> GetRangeListAsync(
            HttpRange range,
            string shareSnapshot = default,
            CancellationToken cancellation = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(FileClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(shareSnapshot)}: {shareSnapshot}");
                try
                {
                    return await FileRestClient.File.GetRangeListAsync(
                        this._pipeline,
                        this.Uri,
                        sharesnapshot: shareSnapshot,
                        range: range.ToRange(),
                        cancellation: cancellation)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(FileClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="ListHandlesAsync"/> operation returns a list of open handles on the file.
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
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{StorageHandlesSegment}}"/> describing a
        /// segment of the handles on the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>       
        public async Task<Response<StorageHandlesSegment>> ListHandlesAsync(
            string marker = default,
            int? maxResults = default,
            CancellationToken cancellation = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(FileClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(marker)}: {marker}\n" +
                    $"{nameof(maxResults)}: {maxResults}");
                try
                {
                    return await FileRestClient.File.ListHandlesAsync(
                        this._pipeline,
                        this.Uri,
                        marker: marker,
                        maxresults: maxResults,
                        cancellation: cancellation)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(FileClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="ForceCloseHandlesAsync"/> operation closes a handle or handles opened on a file
        /// at the service. It supports closing a single handle specified by <paramref name="handleId"/> or 
        /// or closing all handles opened on that resource. 
        /// 
        /// This API is intended to be used alongside <see cref="ListHandlesAsync"/> to force close handles that 
        /// block operations. These handles may have leaked or been lost track of by 
        /// SMB clients. The API has client-side impact on the handle being closed, including user visible 
        /// errors due to failed attempts to read or write files. This API is not intended for use as a replacement 
        /// or alternative for SMB close.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/en-us/rest/api/storageservices/force-close-handles"/>.
        /// </summary>
        /// <param name="handleId">
        /// Optional. Specifies the handle ID to be closed. If not specified, or if equal to &quot;*&quot;, will close all handles.
        /// </param>
        /// <param name="marker">
        /// An optional string value that identifies the segment of the handles
        /// to be closed with the next call to <see cref="ForceCloseHandlesAsync"/>.  The
        /// operation returns a non-empty <see cref="StorageClosedHandlesSegment.NextMarker"/>
        /// if the operation did not return all items remaining to be
        /// closed with the current segment.  The NextMarker value can
        /// be used as the value for the <paramref name="marker"/> parameter
        /// in a subsequent call to request the closure of the next segment of handles.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{StorageClosedHandlesSegment}}"/> describing a
        /// segment of the handles closed.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks> 
        public async Task<Response<StorageClosedHandlesSegment>> ForceCloseHandlesAsync(
            string handleId = Constants.CloseAllHandles,
            string marker = default,
            CancellationToken cancellation = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(FileClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(FileClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(handleId)}: {handleId}\n" +
                    $"{nameof(marker)}: {marker}");
                try
                {
                    return await FileRestClient.File.ForceCloseHandlesAsync(
                        this._pipeline,
                        this.Uri,
                        marker: marker,
                        handleId: handleId,
                        cancellation: cancellation)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(FileClient));
                }
            }
        }
    }
}

namespace Azure.Storage.Files.Models
{
    /// <summary>
    /// The properties and content returned from downloading a file
    /// </summary>
    public partial class StorageFileDownloadInfo
    {
        /// <summary>
        /// Internal flattened property representation
        /// </summary>
        internal FlattenedStorageFileProperties _flattened;
        
        /// <summary>
        /// The number of bytes present in the response body.
        /// </summary>
        public long ContentLength => this._flattened.ContentLength;

        /// <summary>
        /// Content
        /// </summary>
        public Stream Content => this._flattened.Content;

        /// <summary>
        /// If the file has an MD5 hash and this operation is to read the full content, this response header is returned so that the client can check for message content integrity.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash => this._flattened.ContentHash;
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// Properties returned when downloading a file
        /// </summary>
        public StorageFileDownloadProperties Properties { get; private set; }

        /// <summary>
        /// Creates a new StorageFileDownloadInfo backed by FlattenedStorageFileProperties
        /// </summary>
        /// <param name="flattened">The FlattenedStorageFileProperties returned with the request</param>
        internal StorageFileDownloadInfo(FlattenedStorageFileProperties flattened)
        {
            this._flattened = flattened;
            this.Properties = new StorageFileDownloadProperties() { _flattened = flattened };
        }
    }

    /// <summary>
    /// Properties returned when downloading a File
    /// </summary>
    public partial class StorageFileDownloadProperties
    {
        /// <summary>
        /// Internal flattened property representation
        /// </summary>
        internal FlattenedStorageFileProperties _flattened;

        /// <summary>
        /// Returns the date and time the file was last modified. Any operation that modifies the file or its properties updates the last modified time.
        /// </summary>
        public DateTimeOffset LastModified => this._flattened.LastModified;

        /// <summary>
        /// A set of name-value pairs associated with this file as user-defined metadata.
        /// </summary>
        public System.Collections.Generic.IDictionary<string, string> Metadata => this._flattened.Metadata;
        
        /// <summary>
        /// The content type specified for the file. The default content type is 'application/octet-stream'
        /// </summary>
        public string ContentType => this._flattened.ContentType;

        /// <summary>
        /// Indicates the range of bytes returned if the client requested a subset of the file by setting the Range request header.
        /// </summary>
        public string ContentRange => this._flattened.ContentRange;

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally, in quotes.
        /// </summary>
        public ETag ETag => this._flattened.ETag;
        
        /// <summary>
        /// Returns the value that was specified for the Content-Encoding request header.
        /// </summary>
        public string ContentEncoding => this._flattened.ContentEncoding;

        /// <summary>
        /// Returned if it was previously specified for the file.
        /// </summary>
        public string CacheControl => this._flattened.CacheControl;

        /// <summary>
        /// Returns the value that was specified for the 'x-ms-content-disposition' header and specifies how to process the response.
        /// </summary>
        public string ContentDisposition => this._flattened.ContentDisposition;

        /// <summary>
        /// Returns the value that was specified for the Content-Language request header.
        /// </summary>
        public string ContentLanguage => this._flattened.ContentLanguage;

        /// <summary>
        /// This header uniquely identifies the request that was made and can be used for troubleshooting the request.
        /// </summary>
        public string RequestId => this._flattened.RequestId;

        /// <summary>
        /// Indicates the version of the File service used to execute the request.
        /// </summary>
        public string Version => this._flattened.Version;

        /// <summary>
        /// Indicates that the service supports requests for partial file content.
        /// </summary>
        public string AcceptRanges => this._flattened.AcceptRanges;

        /// <summary>
        /// A UTC date/time value generated by the service that indicates the time at which the response was initiated.
        /// </summary>
        public DateTimeOffset Date => this._flattened.Date;

        /// <summary>
        /// Conclusion time of the last attempted Copy File operation where this file was the destination file. This value can specify the time of a completed, aborted, or failed copy attempt.
        /// </summary>
        public DateTimeOffset CopyCompletionTime => this._flattened.CopyCompletionTime;

        /// <summary>
        /// Only appears when x-ms-copy-status is failed or pending. Describes cause of fatal or non-fatal copy operation failure.
        /// </summary>
        public string CopyStatusDescription => this._flattened.CopyStatusDescription;

        /// <summary>
        /// String identifier for the last attempted Copy File operation where this file was the destination file.
        /// </summary>
        public string CopyId => this._flattened.CopyId;

        /// <summary>
        /// Contains the number of bytes copied and the total bytes in the source in the last attempted Copy File operation where this file was the destination file. Can show between 0 and Content-Length bytes copied.
        /// </summary>
        public string CopyProgress => this._flattened.CopyProgress;

        /// <summary>
        /// URL up to 2KB in length that specifies the source file used in the last attempted Copy File operation where this file was the destination file.
        /// </summary>
        public Uri CopySource => this._flattened.CopySource;

        /// <summary>
        /// State of the copy operation identified by 'x-ms-copy-id'.
        /// </summary>
        public CopyStatus CopyStatus => this._flattened.CopyStatus;

        /// <summary>
        /// If the file has a MD5 hash, and if request contains range header (Range or x-ms-range), this response header is returned with the value of the whole file's MD5 value. This value may or may not be equal to the value returned in Content-MD5 header, with the latter calculated from the requested range.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] FileContentHash => this._flattened.FileContentHash;
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// The value of this header is set to true if the file data and application metadata are completely encrypted using the specified algorithm. Otherwise, the value is set to false (when the file is unencrypted, or if only parts of the file/application metadata are encrypted).
        /// </summary>
        public bool IsServerEncrypted => this._flattened.IsServerEncrypted;
    }
}
