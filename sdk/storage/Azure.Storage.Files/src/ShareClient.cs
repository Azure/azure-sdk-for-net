// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
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
    /// The <see cref="ShareClient"/> allows you to manipulate Azure
    /// Storage shares and their directories and files.
    /// </summary>
    public class ShareClient
    {
        /// <summary>
        /// The share's primary <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _uri;

        /// <summary>
        /// Gets the share's primary <see cref="Uri"/> endpoint.
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

        #region ctors
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
            _uri = builder.Uri;
            _pipeline = (options ?? new FileClientOptions()).Build(conn.Credentials);
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
            _uri = shareUri;
            _pipeline = (options ?? new FileClientOptions()).Build(authentication);
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
            _uri = shareUri;
            _pipeline = pipeline;
        }
        #endregion ctors

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
            var p = new FileUriBuilder(Uri) { Snapshot = snapshot };
            return new ShareClient(p.Uri, Pipeline);
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
            => new DirectoryClient(Uri.AppendToPath(directoryName), Pipeline);

        /// <summary>
        /// Create a <see cref="DirectoryClient"/> object for the root of the
        /// share.  The new <see cref="DirectoryClient"/> uses the same request
        /// policy pipeline as the <see cref="ShareClient"/>.
        /// </summary>
        /// <returns>A new <see cref="DirectoryClient"/> instance.</returns>
        public virtual DirectoryClient GetRootDirectoryClient()
            => GetDirectoryClient("");

        #region Create
        /// <summary>
        /// The <see cref="Create"/> operation creates a new share
        /// under the specified account. If a share with the same name
        /// already exists, the operation fails.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/create-share"/>.
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
            CreateInternal(
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
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/create-share"/>.
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
        public virtual async Task<Response<ShareInfo>> CreateAsync(
            Metadata metadata = default,
            int? quotaInBytes = default,
            CancellationToken cancellationToken = default) =>
            await CreateInternal(
                metadata,
                quotaInBytes,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CreateInternal"/> operation creates a new share
        /// under the specified account. If a share with the same name
        /// already exists, the operation fails.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/create-share"/>.
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
        /// A <see cref="Response{ShareInfo}"/> describing the newly
        /// created share.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareInfo>> CreateInternal(
            Metadata metadata,
            int? quotaInBytes,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(quotaInBytes)}: {quotaInBytes}");
                try
                {
                    return await FileRestClient.Share.CreateAsync(
                        Pipeline,
                        Uri,
                        metadata: metadata,
                        quota: quotaInBytes,
                        async: async,
                        operationName: Constants.File.Share.CreateOperationName,
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
                    Pipeline.LogMethodExit(nameof(ShareClient));
                }
            }
        }
        #endregion Create

        #region CreateSnapshot
        /// <summary>
        /// Creates a read-only snapshot of a share.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/snapshot-share"/>.
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
            CreateSnapshotInternal(
                metadata,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Creates a read-only snapshot of a share.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/snapshot-share"/>.
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
        public virtual async Task<Response<ShareSnapshotInfo>> CreateSnapshotAsync(
            Metadata metadata = default,
            CancellationToken cancellationToken = default) =>
            await CreateSnapshotInternal(
                metadata,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Creates a read-only snapshot of a share.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/snapshot-share"/>.
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
        /// A <see cref="Response{ShareSnapshotInfo}"/> describing the newly
        /// created snapshot.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareSnapshotInfo>> CreateSnapshotInternal(
            Metadata metadata,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    return await FileRestClient.Share.CreateSnapshotAsync(
                        Pipeline,
                        Uri,
                        metadata: metadata,
                        async: async,
                        operationName: Constants.File.Share.CreateSnapshotOperationName,
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
                    Pipeline.LogMethodExit(nameof(ShareClient));
                }
            }
        }
        #endregion CreateSnapshot

        #region Delete
        /// <summary>
        /// Marks the specified share or share snapshot for deletion.
        /// The share or share snapshot and any files contained within it are later deleted during garbage collection.
        ///
        /// Currently, this method will always delete snapshots.  There's no way to specify a separate value for x-ms-delete-snapshots.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-share"/>.
        /// </summary>
        /// <param name="shareSnapshot">
        /// Optional. Specifies the share snapshot to delete.
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
        public virtual Response Delete(
            string shareSnapshot = default,
            CancellationToken cancellationToken = default) =>
            DeleteInternal(
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
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-share"/>.
        /// </summary>
        /// <param name="shareSnapshot">
        /// Optional. Specifies the share snapshot to delete.
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
        public virtual async Task<Response> DeleteAsync(
            string shareSnapshot = default,
            CancellationToken cancellationToken = default) =>
            await DeleteInternal(
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
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-share"/>.
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
        /// A <see cref="Response"/> on successfully deleting.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response> DeleteInternal(
            string shareSnapshot,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(shareSnapshot)}: {shareSnapshot}");
                try
                {
                    return await FileRestClient.Share.DeleteAsync(
                        Pipeline,
                        Uri,
                        sharesnapshot: shareSnapshot,
                        async: async,
                        operationName: Constants.File.Share.DeleteOperationName,
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
                    Pipeline.LogMethodExit(nameof(ShareClient));
                }
            }
        }
        #endregion Delete

        #region GetProperties
        /// <summary>
        /// The <see cref="GetProperties"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the share.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-share-properties"/>.
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
            GetPropertiesInternal(
                shareSnapshot,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetPropertiesAsync"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the share.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-share-properties"/>.
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
        public virtual async Task<Response<ShareProperties>> GetPropertiesAsync(
            string shareSnapshot = default,
            CancellationToken cancellationToken = default) =>
            await GetPropertiesInternal(
                shareSnapshot,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetPropertiesInternal"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the share.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-share-properties"/>.
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
        /// A <see cref="Response{ShareProperties}"/> describing the
        /// share's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareProperties>> GetPropertiesInternal(
            string shareSnapshot,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(shareSnapshot)}: {shareSnapshot}");
                try
                {
                    return await FileRestClient.Share.GetPropertiesAsync(
                        Pipeline,
                        Uri,
                        sharesnapshot: shareSnapshot,
                        async: async,
                        operationName: Constants.File.Share.GetPropertiesOperationName,
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
                    Pipeline.LogMethodExit(nameof(ShareClient));
                }
            }
        }
        #endregion GetProperties

        #region SetQuota
        /// <summary>
        /// Sets the maximum size of the share.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-share-properties"/>.
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
            SetQuotaInternal(
                quotaInBytes,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Sets the maximum size of the share.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-share-properties"/>.
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
        public virtual async Task<Response<ShareInfo>> SetQuotaAsync(
            int quotaInBytes = default,
            CancellationToken cancellationToken = default) =>
            await SetQuotaInternal(
                quotaInBytes,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Sets the maximum size of the share.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-share-properties"/>.
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
        /// A <see cref="Response{ShareInfo}"/> describing the updated
        /// share.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareInfo>> SetQuotaInternal(
            int quotaInBytes,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(quotaInBytes)}: {quotaInBytes}");
                try
                {
                    return await FileRestClient.Share.SetQuotaAsync(
                        Pipeline,
                        Uri,
                        quota: quotaInBytes,
                        async: async,
                        operationName: "Azure.Storage.Files.ShareClient.SetQuota",
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
                    Pipeline.LogMethodExit(nameof(ShareClient));
                }
            }
        }
        #endregion SetQuota

        #region SetMetadata
        /// <summary>
        /// The <see cref="SetMetadata"/> operation sets user-defined
        /// metadata for the specified share as one or more name-value pairs.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-share-metadata"/>.
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
            SetMetadataInternal(
                metadata,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="SetMetadataAsync"/> operation sets user-defined
        /// metadata for the specified share as one or more name-value pairs.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-share-metadata"/>.
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
        public virtual async Task<Response<ShareInfo>> SetMetadataAsync(
            Metadata metadata,
            CancellationToken cancellationToken = default) =>
            await SetMetadataInternal(
                metadata,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetMetadataInternal"/> operation sets user-defined
        /// metadata for the specified share as one or more name-value pairs.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-share-metadata"/>.
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
        /// A <see cref="Response{ShareInfo}"/> describing the updated
        /// share.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareInfo>> SetMetadataInternal(
            Metadata metadata,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    return await FileRestClient.Share.SetMetadataAsync(
                        Pipeline,
                        Uri,
                        metadata: metadata,
                        async: async,
                        operationName: Constants.File.Share.SetMetadataOperationName,
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
                    Pipeline.LogMethodExit(nameof(ShareClient));
                }
            }
        }
        #endregion SetMetadata

        #region GetAccessPolicy
        /// <summary>
        /// The <see cref="GetAccessPolicy"/> operation gets the
        /// permissions for this share. The permissions indicate whether
        /// share data may be accessed publicly.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/get-share-acl"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{T}"/> of <see cref="IEnumerable{SignedIdentifier}"/>
        /// describing the share's access policy.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<IEnumerable<SignedIdentifier>> GetAccessPolicy(
            CancellationToken cancellationToken = default) =>
            GetAccessPolicyInternal(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetAccessPolicyAsync"/> operation gets the
        /// permissions for this share. The permissions indicate whether
        /// share data may be accessed publicly.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/get-share-acl"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{T}"/> of <see cref="IEnumerable{SignedIdentifier}"/>
        /// describing the share's access policy.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<IEnumerable<SignedIdentifier>>> GetAccessPolicyAsync(
            CancellationToken cancellationToken = default) =>
            await GetAccessPolicyInternal(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetAccessPolicyInternal"/> operation gets the
        /// permissions for this share. The permissions indicate whether
        /// share data may be accessed publicly.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/get-share-acl"/>.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{T}"/> of <see cref="IEnumerable{SignedIdentifier}"/>
        /// describing the share's access policy.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<IEnumerable<SignedIdentifier>>> GetAccessPolicyInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    return await FileRestClient.Share.GetAccessPolicyAsync(
                        Pipeline,
                        Uri,
                        async: async,
                        operationName: Constants.File.Share.GetAccessPolicyOperationName,
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
                    Pipeline.LogMethodExit(nameof(ShareClient));
                }
            }
        }
        #endregion GetAccessPolicy

        #region SetAccessPolicy
        /// <summary>
        /// The <see cref="SetAccessPolicy"/> operation sets the
        /// permissions for the specified share. The permissions indicate
        /// whether share data may be accessed publicly.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-share-acl"/>.
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
            SetAccessPolicyInternal(
                permissions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="SetAccessPolicyAsync"/> operation sets the
        /// permissions for the specified share. The permissions indicate
        /// whether share data may be accessed publicly.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-share-acl"/>.
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
        public virtual async Task<Response<ShareInfo>> SetAccessPolicyAsync(
            IEnumerable<SignedIdentifier> permissions,
            CancellationToken cancellationToken = default) =>
            await SetAccessPolicyInternal(
                permissions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetAccessPolicyInternal"/> operation sets the
        /// permissions for the specified share. The permissions indicate
        /// whether share data may be accessed publicly.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-share-acl"/>.
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
        /// A <see cref="Response{ShareInfo}"/> describing the
        /// updated share.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareInfo>> SetAccessPolicyInternal(
            IEnumerable<SignedIdentifier> permissions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    return await FileRestClient.Share.SetAccessPolicyAsync(
                        Pipeline,
                        Uri,
                        permissions: permissions,
                        async: async,
                        operationName: Constants.File.Share.SetAccessPolicyOperationName,
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
                    Pipeline.LogMethodExit(nameof(ShareClient));
                }
            }
        }
        #endregion SetAccessPolicy

        #region GetStatistics
        /// <summary>
        /// Retrieves statistics related to the share.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-share-stats"/>.
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
            GetStatisticsInternal(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Retrieves statistics related to the share.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-share-stats"/>.
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
        public virtual async Task<Response<ShareStatistics>> GetStatisticsAsync(
            CancellationToken cancellationToken = default) =>
            await GetStatisticsInternal(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Retrieves statistics related to the share.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-share-stats"/>.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
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
        private async Task<Response<ShareStatistics>> GetStatisticsInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    return await FileRestClient.Share.GetStatisticsAsync(
                        Pipeline,
                        Uri,
                        async: async,
                        operationName: Constants.File.Share.GetStatisticsOperationName,
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
                    Pipeline.LogMethodExit(nameof(ShareClient));
                }
            }
        }
        #endregion GetStatistics

        #region GetPermission
        /// <summary>
        /// Gets the file permission in Security Descriptor Definition Language (SDDL).
        /// </summary>
        /// <param name="filePermissionKey">
        /// The file permission key.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{String}"/> file permission.
        /// </returns>
        public virtual Response<string> GetPermission(
            string filePermissionKey = default,
            CancellationToken cancellationToken = default) =>
            GetPermissionInternal(
                filePermissionKey,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Gets the file permission in Security Descriptor Definition Language (SDDL).
        /// </summary>
        /// <param name="filePermissionKey">
        /// The file permission key.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{String}"/> file permission.
        /// </returns>
        public virtual async Task<Response<string>> GetPermissionAsync(
            string filePermissionKey = default,
            CancellationToken cancellationToken = default) =>
            await GetPermissionInternal(
                filePermissionKey,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        private async Task<Response<string>> GetPermissionInternal(
            string filePermissionKey,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    // Get the permission as a JSON object
                    Response<string> jsonResponse =
                        await FileRestClient.Share.GetPermissionAsync(
                            Pipeline,
                            Uri,
                            filePermissionKey: filePermissionKey,
                            async: async,
                            operationName: Constants.File.Share.GetPermissionOperationName,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);

                    // Parse the JSON object
                    using var doc = JsonDocument.Parse(jsonResponse.Value);
                    if (doc.RootElement.ValueKind != JsonValueKind.Object ||
                        !doc.RootElement.TryGetProperty("permission", out JsonElement permissionProperty) ||
                        permissionProperty.ValueKind != JsonValueKind.String)
                    {
                        throw FileErrors.InvalidPermissionJson(jsonResponse.Value);
                    }
                    var permission = permissionProperty.GetString();

                    // Return the Permission string
                    return new Response<string>(
                        jsonResponse.GetRawResponse(),
                        permission);
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(ShareClient));
                }
            }
        }
        #endregion GetPermission

        #region CreatePermission
        /// <summary>
        /// Creates a permission (a security descriptor) at the share level. The created security descriptor
        /// can be used for the files/directories in the share.
        /// </summary>
        /// <param name="permission">
        /// File permission in the Security Descriptor Definition Language (SDDL). SDDL must have an owner, group,
        /// and discretionary access control list (DACL). The provided SDDL string format of the security descriptor
        /// should not have domain relative identifier (like 'DU', 'DA', 'DD' etc) in it.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PermissionInfo}"/> with ID of the newly created file permission.
        /// </returns>
        public virtual Response<PermissionInfo> CreatePermission(
            string permission,
            CancellationToken cancellationToken = default) =>
            CreatePermissionInternal(
                permission,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Creates a permission (a security descriptor) at the share level. The created security descriptor
        /// can be used for the files/directories in the share.
        /// </summary>
        /// <param name="permission">
        /// File permission in the Security Descriptor Definition Language (SDDL). SDDL must have an owner, group,
        /// and discretionary access control list (DACL). The provided SDDL string format of the security descriptor
        /// should not have domain relative identifier (like 'DU', 'DA', 'DD' etc) in it.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PermissionInfo}"/> with ID of the newly created file permission.
        /// </returns>
        public virtual async Task<Response<PermissionInfo>> CreatePermissionAsync(
            string permission,
            CancellationToken cancellationToken = default) =>
            await CreatePermissionInternal(
                permission,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        private async Task<Response<PermissionInfo>> CreatePermissionInternal(
            string permission,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    // Serialize the permission as a JSON object
                    using var stream = new MemoryStream();
                    using var writer = new Utf8JsonWriter(stream);
                    writer.WriteStartObject();
                    writer.WriteString("permission", permission);
                    writer.WriteEndObject();
                    if (async)
                    {
                        await writer.FlushAsync().ConfigureAwait(false);
                    }
                    else
                    {
                        writer.Flush();
                    }
                    var json = Encoding.UTF8.GetString(stream.ToArray());

                    return await FileRestClient.Share.CreatePermissionAsync(
                        Pipeline,
                        Uri,
                        sharePermissionJson: json,
                        async: async,
                        operationName: Constants.File.Share.CreatePermissionOperationName,
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
                    Pipeline.LogMethodExit(nameof(ShareClient));
                }
            }
        }
        #endregion CreatePermission

        #region CreateDirectory
        /// <summary>
        /// The <see cref="CreateDirectory"/> operation creates a new
        /// directory in this share.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/create-directory"/>.
        /// </summary>
        /// <param name="directoryName">T
        /// The name of the directory to create.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for the directory.
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
        /// A <see cref="Response{DirectoryClient}"/> referencing the
        /// newly created directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<DirectoryClient> CreateDirectory(
           string directoryName,
           IDictionary<string, string> metadata = default,
           FileSmbProperties? smbProperties = default,
           string filePermission = default,
           CancellationToken cancellationToken = default)
        {
            DirectoryClient directory = GetDirectoryClient(directoryName);
            Response<StorageDirectoryInfo> response = directory.Create(
                metadata,
                smbProperties,
                filePermission,
                cancellationToken);
            return new Response<DirectoryClient>(response.GetRawResponse(), directory);
        }

        /// <summary>
        /// The <see cref="CreateDirectoryAsync"/> operation creates a new
        /// directory in this share.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/create-directory"/>.
        /// </summary>
        /// <param name="directoryName">T
        /// The name of the directory to create.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for the directory.
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
        /// A <see cref="Response{DirectoryClient}"/> referencing the
        /// newly created directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<DirectoryClient>> CreateDirectoryAsync(
           string directoryName,
           IDictionary<string, string> metadata = default,
           FileSmbProperties? smbProperties = default,
           string filePermission = default,
           CancellationToken cancellationToken = default)
        {
            DirectoryClient directory = GetDirectoryClient(directoryName);
            Response<StorageDirectoryInfo> response = await directory.CreateAsync(
                metadata,
                smbProperties,
                filePermission,
                cancellationToken).ConfigureAwait(false);
            return new Response<DirectoryClient>(response.GetRawResponse(), directory);
        }
        #endregion CreateDirectory

        #region DeleteDirectory
        /// <summary>
        /// The <see cref="DeleteDirectory"/> operation removes the specified empty
        /// directory.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-directory"/>.
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
        [ForwardsClientCalls]
        public virtual Response DeleteDirectory(
            string directoryName,
            CancellationToken cancellationToken = default) =>
            GetDirectoryClient(directoryName).Delete(cancellationToken);

        /// <summary>
        /// The <see cref="DeleteDirectoryAsync"/> operation removes the specified empty
        /// directory.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-directory"/>.
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
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteDirectoryAsync(
            string directoryName,
            CancellationToken cancellationToken = default) =>
            await GetDirectoryClient(directoryName)
                .DeleteAsync(cancellationToken)
                .ConfigureAwait(false);
        #endregion DeleteDirectory
    }
}
