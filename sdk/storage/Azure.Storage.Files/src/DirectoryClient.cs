// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Common;
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
        /// Gets the directory's primary <see cref="Uri"/> endpoint.
        /// </summary>
        public Uri Uri { get; }

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send 
        /// every request.
        /// </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryClient"/>
        /// class.
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
            var conn = StorageConnectionString.Parse(connectionString);
            var builder =
                new FileUriBuilder(conn.FileEndpoint)
                {
                    ShareName = shareName,
                    DirectoryOrFilePath = directoryPath
                };
            this.Uri = builder.ToUri();
            this._pipeline = (options ?? new FileClientOptions()).Build(conn.Credentials);
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
            this.Uri = directoryUri;
            this._pipeline = (options ?? new FileClientOptions()).Build(authentication);
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
        internal DirectoryClient(Uri directoryUri, HttpPipeline pipeline)
        {
            this.Uri = directoryUri;
            this._pipeline = pipeline;
        }

        /// <summary>
        /// Creates a new <see cref="FileClient"/> object by appending
        /// <paramref name="fileName"/> to the end of <see cref="Uri"/>.  The
        /// new <see cref="FileClient"/> uses the same request policy
        /// pipeline as the <see cref="DirectoryClient"/>.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>A new <see cref="FileClient"/> instance.</returns>
        public FileClient GetFileClient(string fileName)
            => new FileClient(this.Uri.AppendToPath(fileName), this._pipeline);

        /// <summary>
        /// Creates a new <see cref="DirectoryClient"/> object by appending
        /// <paramref name="directoryName"/> to the end of <see cref="Uri"/>.  The
        /// new <see cref="DirectoryClient"/> uses the same request policy
        /// pipeline as the <see cref="DirectoryClient"/>.
        /// </summary>
        /// <param name="directoryName">The name of the subdirectory.</param>
        /// <returns>A new <see cref="DirectoryClient"/> instance.</returns>
        public DirectoryClient GetDirectoryClient(string directoryName)
            => new DirectoryClient(this.Uri.AppendToPath(directoryName), this._pipeline);

        /// <summary>
        /// The <see cref="CreateAsync"/> operation creates a new directory
        /// at the specified <see cref="Uri"/>.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/create-directory"/>.
        /// </summary>
        /// <param name="metadata">
        /// Optional custom metadata to set for this directory.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{StorageDirectoryInfo}}"/> describing the newly
        /// created directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<StorageDirectoryInfo>> CreateAsync(
            Metadata metadata = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(DirectoryClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(DirectoryClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await FileRestClient.Directory.CreateAsync(
                        this._pipeline,
                        this.Uri,
                        metadata: metadata,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(DirectoryClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="DeleteAsync"/> operation removes the specified empty directory.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/delete-directory"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response}}"/> if successful.
        /// </returns>
        /// <remarks>
        /// Note that the directory must be empty before it can be deleted.
        /// </remarks>
        public async Task<Response> DeleteAsync(
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(DirectoryClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(DirectoryClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await FileRestClient.Directory.DeleteAsync(
                        this._pipeline,
                        this.Uri,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(DirectoryClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="GetPropertiesAsync"/> operation returns all
        /// user-defined metadata and system properties for the specified
        /// directory. The data returned does not include the directory's 
        /// list of subdirectories or files.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/en-us/rest/api/storageservices/get-directory-properties"/>.
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
        /// A <see cref="Task{Response{StorageDirectoryProperties}}"/> describing the
        /// directory and its properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>       
        public async Task<Response<StorageDirectoryProperties>> GetPropertiesAsync(
            string shareSnapshot = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(DirectoryClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(DirectoryClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(shareSnapshot)}: {shareSnapshot}");
                try
                {
                    return await FileRestClient.Directory.GetPropertiesAsync(
                        this._pipeline,
                        this.Uri,
                        sharesnapshot: shareSnapshot,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(DirectoryClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="SetMetadataAsync"/> operation sets one or more
        /// user-defined name-value pairs for the specified directory.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/set-directory-metadata"/>.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this directory.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{StorageDirectoryInfo}}}"/> if successful.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<StorageDirectoryInfo>> SetMetadataAsync(
            Metadata metadata,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(DirectoryClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(DirectoryClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await FileRestClient.Directory.SetMetadataAsync(
                        this._pipeline,
                        this.Uri,
                        metadata: metadata,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(DirectoryClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="ListFilesAndDirectoriesSegmentAsync"/> operation returns a
        /// single segment of files and subdirectories in this directory, starting
        /// from the specified <paramref name="marker"/>.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/en-us/rest/api/storageservices/list-directories-and-files"/>.
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
        /// <param name="shareSnapshot">
        /// Optional. Specifies the share snapshot to query.
        /// </param>
        /// <param name="options">
        /// Specifies options for listing, filtering, and shaping the items.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{FilesAndDirectoriesSegment}}"/> describing a
        /// segment of the items in the directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<FilesAndDirectoriesSegment>> ListFilesAndDirectoriesSegmentAsync(
            string marker = default,
            string shareSnapshot = default,
            FilesAndDirectoriesSegmentOptions? options = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(DirectoryClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(DirectoryClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(marker)}: {marker}\n" +
                    $"{nameof(options)}: {options}");
                try
                {
                    return await FileRestClient.Directory.ListFilesAndDirectoriesSegmentAsync(
                        this._pipeline,
                        this.Uri,
                        marker: marker,
                        prefix: options?.Prefix,
                        maxresults: options?.MaxResults,
                        sharesnapshot: shareSnapshot,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(DirectoryClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="ListHandlesAsync"/> operation returns a list of open handles on a directory or a file.
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
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{StorageHandlesSegment}}"/> describing a
        /// segment of the handles in the directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<StorageHandlesSegment>> ListHandlesAsync(
            string marker = default,
            int? maxResults = default,
            bool? recursive = default,
            CancellationToken cancellationToken = default)
        {
            // TODO Support share snapshot

            using (this._pipeline.BeginLoggingScope(nameof(DirectoryClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(DirectoryClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(marker)}: {marker}\n" +
                    $"{nameof(maxResults)}: {maxResults}\n" +
                    $"{nameof(recursive)}: {recursive}");
                try
                {
                    return await FileRestClient.Directory.ListHandlesAsync(
                        this._pipeline,
                        this.Uri,
                        marker: marker,
                        maxresults: maxResults,
                        recursive: recursive,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(DirectoryClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="ForceCloseHandlesAsync"/> operation closes a handle or handles opened on a directory 
        /// or a file at the service. It supports closing a single handle specified by <paramref name="handleId"/> on a file or 
        /// directory or closing all handles opened on that resource. It optionally supports recursively closing 
        /// handles on subresources when the resource is a directory.
        /// 
        /// This API is intended to be used alongside <see cref="ListHandlesAsync"/> to force close handles that 
        /// block operations, such as renaming a directory. These handles may have leaked or been lost track of by 
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
        /// <param name="recursive">
        /// Optional. A boolean value that specifies if the operation should also apply to the files and subdirectories of the directory specified.
        /// </param>
        /// <param name="cancellationToken">
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
            bool? recursive = default,
            CancellationToken cancellationToken = default)
        {
            // TODO Support share snapshot

            using (this._pipeline.BeginLoggingScope(nameof(DirectoryClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(DirectoryClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(handleId)}: {handleId}\n" +
                    $"{nameof(marker)}: {marker}\n" +
                    $"{nameof(recursive)}: {recursive}");
                try
                {
                    return await FileRestClient.Directory.ForceCloseHandlesAsync(
                        this._pipeline,
                        this.Uri,
                        marker: marker,
                        handleId: handleId,
                        recursive: recursive,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(DirectoryClient));
                }
            }
        }
    }
}

namespace Azure.Storage.Files.Models
{
    /// <summary>
    /// Specifies options for listing files and directories with the 
    /// <see cref="DirectoryClient.ListFilesAndDirectoriesSegmentAsync"/>
    /// operation.
    /// </summary>
    public struct FilesAndDirectoriesSegmentOptions : IEquatable<FilesAndDirectoriesSegmentOptions>
    {
        /// <summary>
        /// Gets or sets a string that filters the results to return only
        /// files and directories whose name begins with the specified prefix.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of items to return.
        /// </summary>
        /// <remarks>
        /// The service may return fewer results than requested.
        /// </remarks>
        public int? MaxResults { get; set; }

        /// <summary>
        /// Check if two FilesAndDirectoriesSegmentOptions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is FilesAndDirectoriesSegmentOptions other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the FilesAndDirectoriesSegmentOptions.
        /// </summary>
        /// <returns>Hash code for the FilesAndDirectoriesSegmentOptions.</returns>
        public override int GetHashCode()
            => this.Prefix.GetHashCode()
            ^ this.MaxResults.GetHashCode()
            ;

        /// <summary>
        /// Check if two FilesAndDirectoriesSegmentOptions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(FilesAndDirectoriesSegmentOptions left, FilesAndDirectoriesSegmentOptions right) => left.Equals(right);

        /// <summary>
        /// Check if two FilesAndDirectoriesSegmentOptions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(FilesAndDirectoriesSegmentOptions left, FilesAndDirectoriesSegmentOptions right) => !(left == right);

        /// <summary>
        /// Check if two FilesAndDirectoriesSegmentOptions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(FilesAndDirectoriesSegmentOptions other)
            => this.Prefix == other.Prefix
            && this.MaxResults == other.MaxResults
            ;
    }
}
