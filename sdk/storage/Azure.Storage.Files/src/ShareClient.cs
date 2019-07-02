﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Common;
using Azure.Storage.Files.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files
{
    /// <summary>
    /// The <see cref="ShareClient"/> allows you to manipulate Azure
    /// Storage shares and their directories and files.
    /// </summary>
    public class ShareClient
    {
        #pragma warning disable IDE0032 // Use auto property
        /// <summary>
        /// Gets the share's primary <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _uri;
        #pragma warning restore IDE0032 // Use auto property

        /// <summary>
        /// Gets the share's primary <see cref="Uri"/> endpoint.
        /// </summary>
        public Uri Uri => this._uri;

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send 
        /// every request.
        /// </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareClient"/>
        /// class for mocking.
        /// </summary>
        protected ShareClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareClient"/>
        /// class.
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
        public ShareClient(string connectionString, string shareName)
            : this(connectionString, shareName, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareClient"/>
        /// class.
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
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public ShareClient(string connectionString, string shareName, FileClientOptions options)
        {
            var conn = StorageConnectionString.Parse(connectionString);
            var builder = new FileUriBuilder(conn.FileEndpoint) { ShareName = shareName };
            this._uri = builder.ToUri();
            this._pipeline = (options ?? new FileClientOptions()).Build(conn.Credentials);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareClient"/>
        /// class.
        /// </summary>
        /// <param name="shareUri">
        /// A <see cref="Uri"/> referencing the share that includes the
        /// name of the account and the name of the share.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public ShareClient(Uri shareUri, FileClientOptions options = default)
            : this(shareUri, (HttpPipelinePolicy)null, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareClient"/>
        /// class.
        /// </summary>
        /// <param name="shareUri">
        /// A <see cref="Uri"/> referencing the share that includes the
        /// name of the account and the name of the share.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public ShareClient(Uri shareUri, StorageSharedKeyCredential credential, FileClientOptions options = default)
            : this(shareUri, credential.AsPolicy(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareClient"/>
        /// class.
        /// </summary>
        /// <param name="shareUri">
        /// A <see cref="Uri"/> referencing the share that includes the
        /// name of the account and the name of the share.
        /// </param>
        /// <param name="authentication">
        /// An optional authentication policy used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        internal ShareClient(Uri shareUri, HttpPipelinePolicy authentication, FileClientOptions options)
        {
            this._uri = shareUri;
            this._pipeline = (options ?? new FileClientOptions()).Build(authentication);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareClient"/>
        /// class.
        /// </summary>
        /// <param name="shareUri">
        /// A <see cref="Uri"/> referencing the share that includes the
        /// name of the account and the name of the share.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        internal ShareClient(Uri shareUri, HttpPipeline pipeline)
        {
            this._uri = shareUri;
            this._pipeline = pipeline;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="snapshot"/> timestamp.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/snapshot-share"/>.
        /// </summary>
        /// <remarks>
        /// Pass null or empty string to remove the snapshot returning a URL to the base share.
        /// </remarks>
        /// <param name="snapshot">
        /// The snapshot identifier.
        /// </param>
        /// <returns>
        /// A new <see cref="ShareClient"/> instance.
        /// </returns>
        public virtual ShareClient WithSnapshot(string snapshot)
        {
            var p = new FileUriBuilder(this.Uri) { Snapshot = snapshot };
            return new ShareClient(p.ToUri(), this._pipeline);
        }

        /// <summary>
        /// Create a new <see cref="DirectoryClient"/> object by appending
        /// <paramref name="directoryName"/> to the end of <see cref="Uri"/>.  The
        /// new <see cref="DirectoryClient"/> uses the same request policy
        /// pipeline as the <see cref="ShareClient"/>.
        /// </summary>
        /// <param name="directoryName">The name of the directory.</param>
        /// <returns>A new <see cref="DirectoryClient"/> instance.</returns>
        public virtual DirectoryClient GetDirectoryClient(string directoryName)
            => new DirectoryClient(this.Uri.AppendToPath(directoryName), this._pipeline);

        /// <summary>
        /// Create a <see cref="DirectoryClient"/> object for the root of the
        /// share.  The new <see cref="DirectoryClient"/> uses the same request
        /// policy pipeline as the <see cref="ShareClient"/>.
        /// </summary>
        /// <returns>A new <see cref="DirectoryClient"/> instance.</returns>
        public virtual DirectoryClient GetRootDirectoryClient()
            => this.GetDirectoryClient("");

        /// <summary>
        /// The <see cref="Create"/> operation creates a new share
        /// under the specified account. If a share with the same name
        /// already exists, the operation fails.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/create-share"/>.
        /// </summary>
        /// <param name="metadata">
        /// Optional custom metadata to set for this share.
        /// </param>
        /// <param name="quotaInBytes">
        /// Optional. Maximum size of the share in bytes.  If unspecified, use the service's default value.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareInfo}"/> describing the newly
        /// created share.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareInfo> Create(
            Metadata metadata = default,
            int? quotaInBytes = default,
            CancellationToken cancellationToken = default) =>
            this.CreateAsync(
                metadata,
                quotaInBytes,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="CreateAsync"/> operation creates a new share
        /// under the specified account. If a share with the same name
        /// already exists, the operation fails.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/create-share"/>.
        /// </summary>
        /// <param name="metadata">
        /// Optional custom metadata to set for this share.
        /// </param>
        /// <param name="quotaInBytes">
        /// Optional. Maximum size of the share in bytes.  If unspecified, use the service's default value.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{ShareInfo}}"/> describing the newly
        /// created share.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareInfo>> CreateAsync(
            Metadata metadata = default,
            int? quotaInBytes = default,
            CancellationToken cancellationToken = default) =>
            await this.CreateAsync(
                metadata,
                quotaInBytes,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CreateAsync"/> operation creates a new share
        /// under the specified account. If a share with the same name
        /// already exists, the operation fails.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/create-share"/>.
        /// </summary>
        /// <param name="metadata">
        /// Optional custom metadata to set for this share.
        /// </param>
        /// <param name="quotaInBytes">
        /// Optional. Maximum size of the share in bytes.  If unspecified, use the service's default value.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{ShareInfo}}"/> describing the newly
        /// created share.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareInfo>> CreateAsync(
            Metadata metadata,
            int? quotaInBytes,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this._pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(quotaInBytes)}: {quotaInBytes}");
                try
                {
                    return await FileRestClient.Share.CreateAsync(
                        this._pipeline,
                        this.Uri,
                        metadata: metadata,
                        quota: quotaInBytes,
                        async: async,
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
                    this._pipeline.LogMethodExit(nameof(ShareClient));
                }
            }
        }

        /// <summary>
        /// Creates a read-only snapshot of a share.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/en-us/rest/api/storageservices/snapshot-share"/>.
        /// </summary>
        /// <param name="metadata">
        /// Optional custom metadata to set for this share.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareSnapshotInfo}"/> describing the newly
        /// created snapshot.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareSnapshotInfo> CreateSnapshot(
            Metadata metadata = default,
            CancellationToken cancellationToken = default) =>
            this.CreateSnapshotAsync(
                metadata,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Creates a read-only snapshot of a share.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/en-us/rest/api/storageservices/snapshot-share"/>.
        /// </summary>
        /// <param name="metadata">
        /// Optional custom metadata to set for this share.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{ShareSnapshotInfo}}"/> describing the newly
        /// created snapshot.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareSnapshotInfo>> CreateSnapshotAsync(
            Metadata metadata = default,
            CancellationToken cancellationToken = default) =>
            await this.CreateSnapshotAsync(
                metadata,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Creates a read-only snapshot of a share.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/en-us/rest/api/storageservices/snapshot-share"/>.
        /// </summary>
        /// <param name="metadata">
        /// Optional custom metadata to set for this share.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{ShareSnapshotInfo}}"/> describing the newly
        /// created snapshot.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareSnapshotInfo>> CreateSnapshotAsync(
            Metadata metadata,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this._pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await FileRestClient.Share.CreateSnapshotAsync(
                        this._pipeline,
                        this.Uri,
                        metadata: metadata,
                        async: async,
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
                    this._pipeline.LogMethodExit(nameof(ShareClient));
                }
            }
        }

        /// <summary>
        /// Marks the specified share or share snapshot for deletion.
        /// The share or share snapshot and any files contained within it are later deleted during garbage collection.
        /// 
        /// Currently, this method will always delete snapshots.  There's no way to specify a separate value for x-ms-delete-snapshots.
        ///
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/delete-share"/>.
        /// </summary>
        /// <param name="shareSnapshot">
        /// Optional. Specifies the share snapshot to delete.
        /// </param>
        /// <param name="cancellationToken">
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
        public virtual Response Delete(
            string shareSnapshot = default,
            CancellationToken cancellationToken = default) =>
            this.DeleteAsync(
                shareSnapshot,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Marks the specified share or share snapshot for deletion.
        /// The share or share snapshot and any files contained within it are later deleted during garbage collection.
        /// 
        /// Currently, this method will always delete snapshots.  There's no way to specify a separate value for x-ms-delete-snapshots.
        ///
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/delete-share"/>.
        /// </summary>
        /// <param name="shareSnapshot">
        /// Optional. Specifies the share snapshot to delete.
        /// </param>
        /// <param name="cancellationToken">
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
        public virtual async Task<Response> DeleteAsync(
            string shareSnapshot = default,
            CancellationToken cancellationToken = default) =>
            await this.DeleteAsync(
                shareSnapshot,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Marks the specified share or share snapshot for deletion.
        /// The share or share snapshot and any files contained within it are later deleted during garbage collection.
        /// 
        /// Currently, this method will always delete snapshots.  There's no way to specify a separate value for x-ms-delete-snapshots.
        ///
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/delete-share"/>.
        /// </summary>
        /// <param name="shareSnapshot">
        /// Optional. Specifies the share snapshot to delete.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
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
        private async Task<Response> DeleteAsync(
            string shareSnapshot,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this._pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(shareSnapshot)}: {shareSnapshot}");
                try
                {
                    return await FileRestClient.Share.DeleteAsync(
                        this._pipeline,
                        this.Uri,
                        sharesnapshot: shareSnapshot,
                        async: async,
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
                    this._pipeline.LogMethodExit(nameof(ShareClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="GetProperties"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the share.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/en-us/rest/api/storageservices/get-share-properties"/>.
        /// </summary>
        /// <param name="shareSnapshot">
        /// Optional. Specifies the share snapshot to query for properties.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareProperties}"/> describing the
        /// share's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareProperties> GetProperties(
            string shareSnapshot = default,
            CancellationToken cancellationToken = default) =>
            this.GetPropertiesAsync(
                shareSnapshot,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetPropertiesAsync"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the share.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/en-us/rest/api/storageservices/get-share-properties"/>.
        /// </summary>
        /// <param name="shareSnapshot">
        /// Optional. Specifies the share snapshot to query for properties.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{ShareProperties}}"/> describing the
        /// share's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareProperties>> GetPropertiesAsync(
            string shareSnapshot = default,
            CancellationToken cancellationToken = default) =>
            await this.GetPropertiesAsync(
                shareSnapshot,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetPropertiesAsync"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the share.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/en-us/rest/api/storageservices/get-share-properties"/>.
        /// </summary>
        /// <param name="shareSnapshot">
        /// Optional. Specifies the share snapshot to query for properties.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{ShareProperties}}"/> describing the
        /// share's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareProperties>> GetPropertiesAsync(
            string shareSnapshot,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this._pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(shareSnapshot)}: {shareSnapshot}");
                try
                {
                    return await FileRestClient.Share.GetPropertiesAsync(
                        this._pipeline,
                        this.Uri,
                        sharesnapshot: shareSnapshot,
                        async: async,
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
                    this._pipeline.LogMethodExit(nameof(ShareClient));
                }
            }
        }

        /// <summary>
        /// Sets the maximum size of the share.
        ///
        /// For more information, see <see cref="https://docs.microsoft.com/en-us/rest/api/storageservices/set-share-properties"/>.
        /// </summary>
        /// <param name="quotaInBytes">Optional. The maximum size of the share. If unspecified, use the service's default value.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareInfo}"/> describing the updated
        /// share.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareInfo> SetQuota(
            int quotaInBytes = default,
            CancellationToken cancellationToken = default) =>
            this.SetQuotaAsync(
                quotaInBytes,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Sets the maximum size of the share.
        ///
        /// For more information, see <see cref="https://docs.microsoft.com/en-us/rest/api/storageservices/set-share-properties"/>.
        /// </summary>
        /// <param name="quotaInBytes">Optional. The maximum size of the share. If unspecified, use the service's default value.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{ShareInfo}}"/> describing the updated
        /// share.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareInfo>> SetQuotaAsync(
            int quotaInBytes = default,
            CancellationToken cancellationToken = default) =>
            await this.SetQuotaAsync(
                quotaInBytes,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Sets the maximum size of the share.
        ///
        /// For more information, see <see cref="https://docs.microsoft.com/en-us/rest/api/storageservices/set-share-properties"/>.
        /// </summary>
        /// <param name="quotaInBytes">Optional. The maximum size of the share. If unspecified, use the service's default value.</param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{ShareInfo}}"/> describing the updated
        /// share.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareInfo>> SetQuotaAsync(
            int quotaInBytes,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this._pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(quotaInBytes)}: {quotaInBytes}");
                try
                {
                    return await FileRestClient.Share.SetQuotaAsync(
                        this._pipeline,
                        this.Uri,
                        quota: quotaInBytes,
                        async: async,
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
                    this._pipeline.LogMethodExit(nameof(ShareClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="SetMetadata"/> operation sets user-defined 
        /// metadata for the specified share as one or more name-value pairs.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/set-share-metadata"/>.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this share.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareInfo}"/> describing the updated
        /// share.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareInfo> SetMetadata(
            Metadata metadata,
            CancellationToken cancellationToken = default) =>
            this.SetMetadataAsync(
                metadata,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="SetMetadataAsync"/> operation sets user-defined 
        /// metadata for the specified share as one or more name-value pairs.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/set-share-metadata"/>.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this share.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{ShareInfo}}"/> describing the updated
        /// share.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareInfo>> SetMetadataAsync(
            Metadata metadata,
            CancellationToken cancellationToken = default) =>
            await this.SetMetadataAsync(
                metadata,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetMetadataAsync"/> operation sets user-defined 
        /// metadata for the specified share as one or more name-value pairs.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/set-share-metadata"/>.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this share.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{ShareInfo}}"/> describing the updated
        /// share.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareInfo>> SetMetadataAsync(
            Metadata metadata,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this._pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await FileRestClient.Share.SetMetadataAsync(
                        this._pipeline,
                        this.Uri,
                        metadata: metadata,
                        async: async,
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
                    this._pipeline.LogMethodExit(nameof(ShareClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="GetAccessPolicy"/> operation gets the
        /// permissions for this share. The permissions indicate whether
        /// share data may be accessed publicly.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/get-share-acl"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{IEnumerable{SignedIdentifier}}}"/> describing
        /// the share's access policy.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<IEnumerable<SignedIdentifier>> GetAccessPolicy(
            CancellationToken cancellationToken = default) =>
            this.GetAccessPolicyAsync(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetAccessPolicyAsync"/> operation gets the
        /// permissions for this share. The permissions indicate whether
        /// share data may be accessed publicly.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/get-share-acl"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{IEnumerable{SignedIdentifier}}}"/> describing
        /// the share's access policy.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<IEnumerable<SignedIdentifier>>> GetAccessPolicyAsync(
            CancellationToken cancellationToken = default) =>
            await this.GetAccessPolicyAsync(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetAccessPolicyAsync"/> operation gets the
        /// permissions for this share. The permissions indicate whether
        /// share data may be accessed publicly.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/get-share-acl"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{IEnumerable{SignedIdentifier}}}"/> describing
        /// the share's access policy.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<IEnumerable<SignedIdentifier>>> GetAccessPolicyAsync(
            bool async,
            CancellationToken cancellationToken)
        {
            using (this._pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await FileRestClient.Share.GetAccessPolicyAsync(
                        this._pipeline,
                        this.Uri,
                        async: async,
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
                    this._pipeline.LogMethodExit(nameof(ShareClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="SetAccessPolicy"/> operation sets the
        /// permissions for the specified share. The permissions indicate
        /// whether share data may be accessed publicly.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/set-share-acl"/>.
        /// </summary>
        /// <param name="permissions">
        /// Stored access policies that you can use to provide fine grained
        /// control over share permissions.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareInfo}"/> describing the
        /// updated share.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareInfo> SetAccessPolicy(
            IEnumerable<SignedIdentifier> permissions,
            CancellationToken cancellationToken = default) =>
            this.SetAccessPolicyAsync(
                permissions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="SetAccessPolicyAsync"/> operation sets the
        /// permissions for the specified share. The permissions indicate
        /// whether share data may be accessed publicly.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/set-share-acl"/>.
        /// </summary>
        /// <param name="permissions">
        /// Stored access policies that you can use to provide fine grained
        /// control over share permissions.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{ShareInfo}}"/> describing the
        /// updated share.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareInfo>> SetAccessPolicyAsync(
            IEnumerable<SignedIdentifier> permissions,
            CancellationToken cancellationToken = default) =>
            await this.SetAccessPolicyAsync(
                permissions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetAccessPolicyAsync"/> operation sets the
        /// permissions for the specified share. The permissions indicate
        /// whether share data may be accessed publicly.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/set-share-acl"/>.
        /// </summary>
        /// <param name="permissions">
        /// Stored access policies that you can use to provide fine grained
        /// control over share permissions.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{ShareInfo}}"/> describing the
        /// updated share.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareInfo>> SetAccessPolicyAsync(
            IEnumerable<SignedIdentifier> permissions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this._pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await FileRestClient.Share.SetAccessPolicyAsync(
                        this._pipeline,
                        this.Uri,
                        permissions: permissions,
                        async: async,
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
                    this._pipeline.LogMethodExit(nameof(ShareClient));
                }
            }
        }

        /// <summary>
        /// Retrieves statistics related to the share.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/en-us/rest/api/storageservices/get-share-stats"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareStatistics}"/> describing the
        /// share statistics.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareStatistics> GetStatistics(
            CancellationToken cancellationToken = default) =>
            this.GetStatisticsAsync(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Retrieves statistics related to the share.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/en-us/rest/api/storageservices/get-share-stats"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{ShareStatistics}}"/> describing the
        /// share statistics.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareStatistics>> GetStatisticsAsync(
            CancellationToken cancellationToken = default) =>
            await this.GetStatisticsAsync(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Retrieves statistics related to the share.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/en-us/rest/api/storageservices/get-share-stats"/>.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{ShareStatistics}}"/> describing the
        /// share statistics.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareStatistics>> GetStatisticsAsync(
            bool async,
            CancellationToken cancellationToken)
        {
            using (this._pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await FileRestClient.Share.GetStatisticsAsync(
                        this._pipeline,
                        this.Uri,
                        async: async,
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
                    this._pipeline.LogMethodExit(nameof(ShareClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="CreateDirectory"/> operation creates a new
        /// directory in this share.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/create-directory"/>.
        /// </summary>
        /// <param name="directoryName">T
        /// The name of the directory to create.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this directory.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{DirectoryClient}}"/> referencing the
        /// newly created directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<DirectoryClient> CreateDirectory(
           string directoryName,
           IDictionary<string, string> metadata = default,
           CancellationToken cancellationToken = default)
        {
            var directory = this.GetDirectoryClient(directoryName);
            var response = directory.Create(metadata, cancellationToken);
            return new Response<DirectoryClient>(response.GetRawResponse(), directory);
        }

        /// <summary>
        /// The <see cref="CreateDirectoryAsync"/> operation creates a new
        /// directory in this share.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/create-directory"/>.
        /// </summary>
        /// <param name="directoryName">T
        /// The name of the directory to create.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this directory.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{DirectoryClient}}"/> referencing the
        /// newly created directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<DirectoryClient>> CreateDirectoryAsync(
           string directoryName,
           IDictionary<string, string> metadata = default,
           CancellationToken cancellationToken = default)
        {
            var directory = this.GetDirectoryClient(directoryName);
            var response = await directory.CreateAsync(metadata, cancellationToken).ConfigureAwait(false);
            return new Response<DirectoryClient>(response.GetRawResponse(), directory);
        }

        /// <summary>
        /// The <see cref="DeleteDirectory"/> operation removes the specified empty
        /// directory.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/delete-directory"/>.
        /// </summary>
        /// <param name="directoryName">T
        /// The name of the directory to delete.
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
        public virtual Response DeleteDirectory(
            string directoryName,
            CancellationToken cancellationToken = default) =>
            this.GetDirectoryClient(directoryName).Delete(cancellationToken);

        /// <summary>
        /// The <see cref="DeleteDirectoryAsync"/> operation removes the specified empty
        /// directory.
        /// 
        /// For more information, see <see cref="https://docs.microsoft.com/rest/api/storageservices/delete-directory"/>.
        /// </summary>
        /// <param name="directoryName">T
        /// The name of the directory to delete.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response}"/> if successful.
        /// </returns>
        /// <remarks>
        /// Note that the directory must be empty before it can be deleted.
        /// </remarks>
        public virtual async Task<Response> DeleteDirectoryAsync(
            string directoryName,
            CancellationToken cancellationToken = default) =>
            await this.GetDirectoryClient(directoryName)
                .DeleteAsync(cancellationToken)
                .ConfigureAwait(false);
    }
}
