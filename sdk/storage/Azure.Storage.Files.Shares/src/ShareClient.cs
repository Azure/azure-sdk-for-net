﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Files.Shares.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.Shares
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
        /// The name of the share.
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets the name of the share.
        /// </summary>
        public virtual string Name
        {
            get
            {
                SetNameFieldsIfNull();
                return _name;
            }
        }

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
        public ShareClient(string connectionString, string shareName, ShareClientOptions options)
        {
            options ??= new ShareClientOptions();
            var conn = StorageConnectionString.Parse(connectionString);
            var builder = new ShareUriBuilder(conn.FileEndpoint) { ShareName = shareName };
            _uri = builder.ToUri();
            _pipeline = options.Build(conn.Credentials);
            _version = options.Version;
            _clientDiagnostics = new ClientDiagnostics(options);
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
        public ShareClient(Uri shareUri, ShareClientOptions options = default)
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
        public ShareClient(Uri shareUri, StorageSharedKeyCredential credential, ShareClientOptions options = default)
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
        internal ShareClient(Uri shareUri, HttpPipelinePolicy authentication, ShareClientOptions options)
        {
            options ??= new ShareClientOptions();
            _uri = shareUri;
            _pipeline = options.Build(authentication);
            _version = options.Version;
            _clientDiagnostics = new ClientDiagnostics(options);
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
        /// <param name="version">
        /// The version of the service to use when sending requests.
        /// </param>
        /// <param name="clientDiagnostics">
        /// The <see cref="ClientDiagnostics"/> instance used to create
        /// diagnostic scopes every request.
        /// </param>
        internal ShareClient(Uri shareUri, HttpPipeline pipeline, ShareClientOptions.ServiceVersion version, ClientDiagnostics clientDiagnostics)
        {
            _uri = shareUri;
            _pipeline = pipeline;
            _version = version;
            _clientDiagnostics = clientDiagnostics;
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
            var p = new ShareUriBuilder(Uri) { Snapshot = snapshot };
            return new ShareClient(p.ToUri(), Pipeline, Version, ClientDiagnostics);
        }

        /// <summary>
        /// Create a new <see cref="ShareDirectoryClient"/> object by appending
        /// <paramref name="directoryName"/> to the end of <see cref="Uri"/>.  The
        /// new <see cref="ShareDirectoryClient"/> uses the same request policy
        /// pipeline as the <see cref="ShareClient"/>.
        /// </summary>
        /// <param name="directoryName">The name of the directory.</param>
        /// <returns>A new <see cref="ShareDirectoryClient"/> instance.</returns>
        public virtual ShareDirectoryClient GetDirectoryClient(string directoryName)
            => new ShareDirectoryClient(Uri.AppendToPath(directoryName), Pipeline, Version, ClientDiagnostics);

        /// <summary>
        /// Create a <see cref="ShareDirectoryClient"/> object for the root of the
        /// share.  The new <see cref="ShareDirectoryClient"/> uses the same request
        /// policy pipeline as the <see cref="ShareClient"/>.
        /// </summary>
        /// <returns>A new <see cref="ShareDirectoryClient"/> instance.</returns>
        public virtual ShareDirectoryClient GetRootDirectoryClient()
            => GetDirectoryClient("");

        /// <summary>
        /// Sets the various name fields if they are currently null.
        /// </summary>
        private void SetNameFieldsIfNull()
        {
            if (_name == null || _accountName == null)
            {
                var builder = new ShareUriBuilder(Uri);
                _name = builder.ShareName;
                _accountName = builder.AccountName;
            }
        }

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
        /// <param name="quotaInGB">
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareInfo> Create(
            Metadata metadata = default,
            int? quotaInGB = default,
            CancellationToken cancellationToken = default) =>
            CreateInternal(
                metadata,
                quotaInGB,
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
        /// <param name="quotaInGB">
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareInfo>> CreateAsync(
            Metadata metadata = default,
            int? quotaInGB = default,
            CancellationToken cancellationToken = default) =>
            await CreateInternal(
                metadata,
                quotaInGB,
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
        /// <param name="quotaInGB">
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareInfo>> CreateInternal(
            Metadata metadata,
            int? quotaInGB,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(quotaInGB)}: {quotaInGB}");
                try
                {
                    return await FileRestClient.Share.CreateAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        metadata: metadata,
                        quotaInGB: quotaInGB,
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
        /// A <see cref="RequestFailedException"/> will be thrown if
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
        /// A <see cref="RequestFailedException"/> will be thrown if
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
        /// A <see cref="RequestFailedException"/> will be thrown if
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
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
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
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-share"/>.
        /// </summary>
        /// <param name="includeSnapshots">
        /// A value indicating whether to delete a share's snapshots in addition
        /// to the share itself.
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
            bool includeSnapshots = true,
            CancellationToken cancellationToken = default) =>
            DeleteInternal(
                includeSnapshots,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Marks the specified share or share snapshot for deletion.
        /// The share or share snapshot and any files contained within it are later deleted during garbage collection.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-share"/>.
        /// </summary>
        /// <param name="includeSnapshots">
        /// A value indicating whether to delete a share's snapshots in addition
        /// to the share itself.
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
            bool includeSnapshots = true,
            CancellationToken cancellationToken = default) =>
            await DeleteInternal(
                includeSnapshots,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Marks the specified share or share snapshot for deletion.
        /// The share or share snapshot and any files contained within it are later deleted during garbage collection.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-share"/>.
        /// </summary>
        /// <param name="includeSnapshots">
        /// A value indicating whether to delete a share's snapshots in addition
        /// to the share itself.
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response> DeleteInternal(
            bool includeSnapshots,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");
                try
                {
                    return await FileRestClient.Share.DeleteAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        deleteSnapshots: includeSnapshots ? DeleteSnapshotsOptionType.Include : (DeleteSnapshotsOptionType?)null,
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
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareProperties}"/> describing the
        /// share's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareProperties> GetProperties(
            CancellationToken cancellationToken = default) =>
            GetPropertiesInternal(
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
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareProperties}"/> describing the
        /// share's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareProperties>> GetPropertiesAsync(
            CancellationToken cancellationToken = default) =>
            await GetPropertiesInternal(
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareProperties>> GetPropertiesInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");
                try
                {
                    return await FileRestClient.Share.GetPropertiesAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
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
        /// <param name="quotaInGB">Optional. The maximum size of the share. If unspecified, use the service's default value.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareInfo}"/> describing the updated
        /// share.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareInfo> SetQuota(
            int quotaInGB = default,
            CancellationToken cancellationToken = default) =>
            SetQuotaInternal(
                quotaInGB,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Sets the maximum size of the share.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-share-properties"/>.
        /// </summary>
        /// <param name="quotaInGB">Optional. The maximum size of the share. If unspecified, use the service's default value.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareInfo}"/> describing the updated
        /// share.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareInfo>> SetQuotaAsync(
            int quotaInGB = default,
            CancellationToken cancellationToken = default) =>
            await SetQuotaInternal(
                quotaInGB,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Sets the maximum size of the share.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-share-properties"/>.
        /// </summary>
        /// <param name="quotaInGB">Optional. The maximum size of the share. If unspecified, use the service's default value.</param>
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal virtual async Task<Response<ShareInfo>> SetQuotaInternal(
            int quotaInGB,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(quotaInGB)}: {quotaInGB}");
                try
                {
                    return await FileRestClient.Share.SetQuotaAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        quotaInGB: quotaInGB,
                        async: async,
                        operationName: Constants.File.Share.SetQuotaOperationName,
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
        /// A <see cref="RequestFailedException"/> will be thrown if
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
        /// A <see cref="RequestFailedException"/> will be thrown if
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
        /// A <see cref="RequestFailedException"/> will be thrown if
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
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<IEnumerable<ShareSignedIdentifier>> GetAccessPolicy(
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
        /// A <see cref="Response{T}"/> of <see cref="IEnumerable{FileSignedIdentifier}"/>
        /// describing the share's access policy.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<IEnumerable<ShareSignedIdentifier>>> GetAccessPolicyAsync(
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
        /// A <see cref="Response{T}"/> of <see cref="IEnumerable{FileSignedIdentifier}"/>
        /// describing the share's access policy.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<IEnumerable<ShareSignedIdentifier>>> GetAccessPolicyInternal(
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
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareInfo> SetAccessPolicy(
            IEnumerable<ShareSignedIdentifier> permissions,
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareInfo>> SetAccessPolicyAsync(
            IEnumerable<ShareSignedIdentifier> permissions,
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareInfo>> SetAccessPolicyInternal(
            IEnumerable<ShareSignedIdentifier> permissions,
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
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
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
        /// A <see cref="RequestFailedException"/> will be thrown if
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
        /// A <see cref="RequestFailedException"/> will be thrown if
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
        /// A <see cref="RequestFailedException"/> will be thrown if
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
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
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
                            ClientDiagnostics,
                            Pipeline,
                            Uri,
                            filePermissionKey: filePermissionKey,
                            version: Version.ToVersionString(),
                            async: async,
                            operationName: Constants.File.Share.GetPermissionOperationName,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);

                    // Return an exploding Response on 304
                    if (jsonResponse.IsUnavailable())
                    {
                        return jsonResponse;
                    }

                    // Parse the JSON object
                    using var doc = JsonDocument.Parse(jsonResponse.Value);
                    if (doc.RootElement.ValueKind != JsonValueKind.Object ||
                        !doc.RootElement.TryGetProperty("permission", out JsonElement permissionProperty) ||
                        permissionProperty.ValueKind != JsonValueKind.String)
                    {
                        throw ShareErrors.InvalidPermissionJson(jsonResponse.Value);
                    }
                    var permission = permissionProperty.GetString();

                    // Return the Permission string
                    return Response.FromValue(permission, jsonResponse.GetRawResponse());
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
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<ShareDirectoryClient> CreateDirectory(
           string directoryName,
           IDictionary<string, string> metadata = default,
           FileSmbProperties smbProperties = default,
           string filePermission = default,
           CancellationToken cancellationToken = default)
        {
            ShareDirectoryClient directory = GetDirectoryClient(directoryName);
            Response<ShareDirectoryInfo> response = directory.Create(
                metadata,
                smbProperties,
                filePermission,
                cancellationToken);
            return Response.FromValue(directory, response.GetRawResponse());
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<ShareDirectoryClient>> CreateDirectoryAsync(
           string directoryName,
           IDictionary<string, string> metadata = default,
           FileSmbProperties smbProperties = default,
           string filePermission = default,
           CancellationToken cancellationToken = default)
        {
            ShareDirectoryClient directory = GetDirectoryClient(directoryName);
            Response<ShareDirectoryInfo> response = await directory.CreateAsync(
                metadata,
                smbProperties,
                filePermission,
                cancellationToken).ConfigureAwait(false);
            return Response.FromValue(directory, response.GetRawResponse());
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
