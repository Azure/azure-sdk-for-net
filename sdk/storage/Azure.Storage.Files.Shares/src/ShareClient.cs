﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Sas;
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
        /// <see cref="ShareClientConfiguration"/>.
        /// </summary>
        private readonly ShareClientConfiguration _clientConfiguration;

        /// <summary>
        /// <see cref="ShareClientConfiguration"/>.
        /// </summary>
        internal virtual ShareClientConfiguration ClientConfiguration => _clientConfiguration;

        /// <summary>
        /// ShareRestClient.
        /// </summary>
        private readonly ShareRestClient _shareRestClient;

        /// <summary>
        /// ShareRestClient.
        /// </summary>
        internal virtual ShareRestClient ShareRestClient => _shareRestClient;

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

        /// <summary>
        /// Determines whether the client is able to generate a SAS.
        /// If the client is authenticated with a <see cref="StorageSharedKeyCredential"/>.
        /// </summary>
        public virtual bool CanGenerateSasUri => ClientConfiguration.SharedKeyCredential != null;

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
        /// For more information,
        /// <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">
        /// Configure Azure Storage connection strings</see>
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
        /// For more information,
        /// <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">
        /// Configure Azure Storage connection strings</see>
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
            ShareUriBuilder uriBuilder = new ShareUriBuilder(conn.FileEndpoint) { ShareName = shareName };
            _uri = uriBuilder.ToUri();
            _clientConfiguration = new ShareClientConfiguration(
                pipeline: options.Build(conn.Credentials),
                sharedKeyCredential: conn.Credentials as StorageSharedKeyCredential,
                clientDiagnostics: new ClientDiagnostics(options),
                version: options.Version);
            _shareRestClient = BuildShareRestClient(_uri);
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
            : this(shareUri, (HttpPipelinePolicy)null, options, null)
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
            : this(shareUri, credential.AsPolicy(), options, credential)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareClient"/>
        /// class.
        /// </summary>
        /// <param name="shareUri">
        /// A <see cref="Uri"/> referencing the share that includes the
        /// name of the account and the name of the share.
        /// Must not contain shared access signature, which should be passed in the second parameter.
        /// </param>
        /// <param name="credential">
        /// The shared access signature credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        /// <remarks>
        /// This constructor should only be used when shared access signature needs to be updated during lifespan of this client.
        /// </remarks>
        public ShareClient(Uri shareUri, AzureSasCredential credential, ShareClientOptions options = default)
            : this(shareUri, credential.AsPolicy<ShareUriBuilder>(shareUri), options, null)
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
        /// <param name="storageSharedKeyCredential">
        /// The shared key credential used to sign requests.
        /// </param>
        internal ShareClient(
            Uri shareUri,
            HttpPipelinePolicy authentication,
            ShareClientOptions options,
            StorageSharedKeyCredential storageSharedKeyCredential)
        {
            Argument.AssertNotNull(shareUri, nameof(shareUri));
            options ??= new ShareClientOptions();
            _uri = shareUri;
            _clientConfiguration = new ShareClientConfiguration(
                pipeline: options.Build(authentication),
                sharedKeyCredential: storageSharedKeyCredential,
                clientDiagnostics: new ClientDiagnostics(options),
                version: options.Version);
            _shareRestClient = BuildShareRestClient(shareUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareClient"/>
        /// class.
        /// </summary>
        /// <param name="shareUri">
        /// A <see cref="Uri"/> referencing the share that includes the
        /// name of the account and the name of the share.
        /// </param>
        /// <param name="clientConfiguration">
        /// <see cref="ShareClientConfiguration"/>.
        /// </param>
        internal ShareClient(
            Uri shareUri,
            ShareClientConfiguration clientConfiguration)
        {
            _uri = shareUri;
            _clientConfiguration = clientConfiguration;
            _shareRestClient = BuildShareRestClient(shareUri);
        }

        private ShareRestClient BuildShareRestClient(Uri uri)
        {
            ShareUriBuilder uriBuilder = new ShareUriBuilder(uri);
            _name = uriBuilder.ShareName;
            uriBuilder.ShareName = null;
            return new ShareRestClient(
                _clientConfiguration.ClientDiagnostics,
                _clientConfiguration.Pipeline,
                uriBuilder.ToUri().ToString(),
                path: _name,
                _clientConfiguration.Version.ToVersionString());
        }
        #endregion ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="snapshot"/> timestamp.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/snapshot-share">
        /// Snapshot Share</see>.
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
            return new ShareClient(p.ToUri(), ClientConfiguration);
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
        {
            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(Uri)
            {
                DirectoryOrFilePath = directoryName
            };
            return new ShareDirectoryClient(
                shareUriBuilder.ToUri(),
                ClientConfiguration);
        }

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
        /// The <see cref="Create(ShareCreateOptions, CancellationToken)"/> operation creates a new share
        /// under the specified account. If a share with the same name
        /// already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-share">
        /// Create Share</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
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
            ShareCreateOptions options,
            CancellationToken cancellationToken = default) =>
            CreateInternal(
                options?.Metadata,
                options?.QuotaInGB,
                options?.AccessTier,
                options?.Protocols,
                options?.RootSquash,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="CreateAsync(ShareCreateOptions, CancellationToken)"/> operation creates a new share
        /// under the specified account. If a share with the same name
        /// already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-share">
        /// Create Share</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
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
            ShareCreateOptions options,
            CancellationToken cancellationToken = default) =>
            await CreateInternal(
                options?.Metadata,
                options?.QuotaInGB,
                options?.AccessTier,
                options?.Protocols,
                options?.RootSquash,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="Create(Metadata, int?, CancellationToken)"/> operation creates a new share
        /// under the specified account. If a share with the same name
        /// already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-share">
        /// Create Share</see>.
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ShareInfo> Create(
            Metadata metadata = default,
            int? quotaInGB = default,
            CancellationToken cancellationToken = default) =>
            CreateInternal(
                metadata,
                quotaInGB,
                accessTier: default,
                enabledProtocols: default,
                rootSquash: default,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="CreateAsync(Metadata, int?, CancellationToken)"/> operation creates a new share
        /// under the specified account. If a share with the same name
        /// already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-share">
        /// Create Share</see>.
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ShareInfo>> CreateAsync(
            Metadata metadata = default,
            int? quotaInGB = default,
            CancellationToken cancellationToken = default) =>
            await CreateInternal(
                metadata,
                quotaInGB,
                accessTier: default,
                enabledProtocols: default,
                rootSquash: default,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CreateInternal"/> operation creates a new share
        /// under the specified account. If a share with the same name
        /// already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-share">
        /// Create Share</see>.
        /// </summary>
        /// <param name="metadata">
        /// Optional custom metadata to set for this share.
        /// </param>
        /// <param name="quotaInGB">
        /// Optional. Maximum size of the share in bytes.  If unspecified, use the service's default value.
        /// </param>
        /// <param name="accessTier">
        /// Optional.  Specifies the access tier of the share.
        /// </param>
        /// <param name="enabledProtocols">
        /// The protocols to enable on the share.
        /// </param>
        /// <param name="rootSquash">
        /// Squash root to set on the share.
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
        /// A <see cref="Response{ShareInfo}"/> describing the newly
        /// created share.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<Response<ShareInfo>> CreateInternal(
            Metadata metadata,
            int? quotaInGB,
            ShareAccessTier? accessTier,
            ShareProtocols? enabledProtocols,
            ShareRootSquash? rootSquash,
            bool async,
            CancellationToken cancellationToken,
            string operationName = default)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(quotaInGB)}: {quotaInGB}");

                operationName ??= $"{nameof(ShareClient)}.{nameof(Create)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);

                try
                {
                    scope.Start();
                    ResponseWithHeaders<ShareCreateHeaders> response;

                    if (async)
                    {
                        response = await ShareRestClient.CreateAsync(
                            metadata: metadata,
                            quota: quotaInGB,
                            accessTier: accessTier,
                            enabledProtocols: enabledProtocols.ToShareEnableProtocolsString(),
                            rootSquash: rootSquash,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ShareRestClient.Create(
                            metadata: metadata,
                            quota: quotaInGB,
                            accessTier: accessTier,
                            enabledProtocols: enabledProtocols.ToShareEnableProtocolsString(),
                            rootSquash: rootSquash,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToShareInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareClient));
                    scope.Dispose();
                }
            }
        }
        #endregion Create

        #region Create If Not Exists
        /// <summary>
        /// The <see cref="CreateIfNotExists(ShareCreateOptions, CancellationToken)"/> operation creates a new share
        /// under the specified account. If a share with the same name
        /// already exists, it is not changed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-share">
        /// Create Share</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareInfo}"/> describing the newly
        /// created share.  If the share already exists, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareInfo> CreateIfNotExists(
            ShareCreateOptions options,
            CancellationToken cancellationToken = default) =>
            CreateIfNotExistsInternal(
                options?.Metadata,
                options?.QuotaInGB,
                options?.AccessTier,
                options?.Protocols,
                options?.RootSquash,
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// The <see cref="CreateIfNotExistsAsync(Metadata, int?, CancellationToken)"/> operation creates a new share
        /// under the specified account. If a share with the same name
        /// already exists, it is not changed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-share">
        /// Create Share</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareInfo}"/> describing the newly
        /// created share.  If the share already exists, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareInfo>> CreateIfNotExistsAsync(
            ShareCreateOptions options,
            CancellationToken cancellationToken = default) =>
            await CreateIfNotExistsInternal(
                options?.Metadata,
                options?.QuotaInGB,
                options?.AccessTier,
                options?.Protocols,
                options?.RootSquash,
                async: true,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="Create(Metadata, int?, CancellationToken)"/> operation creates a new share
        /// under the specified account. If a share with the same name
        /// already exists, it is not changed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-share">
        /// Create Share</see>.
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
        /// created share.  If the share already exists, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ShareInfo> CreateIfNotExists(
            Metadata metadata = default,
            int? quotaInGB = default,
            CancellationToken cancellationToken = default) =>
            CreateIfNotExistsInternal(
                metadata,
                quotaInGB,
                accessTier: default,
                enabledProtocols: default,
                squashRoot: default,
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// The <see cref="CreateIfNotExistsAsync(Metadata, int?, CancellationToken)"/> operation creates a new share
        /// under the specified account. If a share with the same name
        /// already exists, it is not changed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-share">
        /// Create Share</see>.
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
        /// created share.  If the share already exists, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareInfo>> CreateIfNotExistsAsync(
            Metadata metadata = default,
            int? quotaInGB = default,
            CancellationToken cancellationToken = default) =>
            await CreateIfNotExistsInternal(
                metadata,
                quotaInGB,
                accessTier: default,
                enabledProtocols: default,
                squashRoot: default,
                async: true,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CreateIfNotExistsInternal"/> operation creates a new share
        /// under the specified account. If a share with the same name
        /// already exists, it is not changed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-share">
        /// Create Share</see>.
        /// </summary>
        /// <param name="metadata">
        /// Optional custom metadata to set for this share.
        /// </param>
        /// <param name="quotaInGB">
        /// Optional. Maximum size of the share in bytes.  If unspecified, use the service's default value.
        /// </param>
        /// <param name="accessTier">
        /// Optional.  Specifies the access tier of the share.
        /// </param>
        /// <param name="enabledProtocols">
        /// The protocols to enable on the share.
        /// </param>
        /// <param name="squashRoot">
        /// Squash root to set on the share.
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
        /// created share.  If the share already exists, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareInfo>> CreateIfNotExistsInternal(
            Metadata metadata,
            int? quotaInGB,
            ShareAccessTier? accessTier,
            ShareProtocols? enabledProtocols,
            ShareRootSquash? squashRoot,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(quotaInGB)}: {quotaInGB}");
                Response<ShareInfo> response;
                try
                {
                    response = await CreateInternal(
                        metadata,
                        quotaInGB,
                        accessTier,
                        enabledProtocols,
                        squashRoot,
                        async,
                        cancellationToken,
                        operationName: $"{nameof(ShareClient)}.{nameof(CreateIfNotExists)}")
                        .ConfigureAwait(false);
                }
                catch (RequestFailedException storageRequestFailedException)
                when (storageRequestFailedException.ErrorCode == ShareErrorCode.ShareAlreadyExists)
                {
                    response = default;
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareClient));
                }
                return response;
            }
        }
        #endregion Create If Not Exists

        #region Exists
        /// <summary>
        /// The <see cref="Exists"/> operation can be called on a
        /// <see cref="ShareClient"/> to see if the associated share
        /// exists on the storage account in the storage service.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns true if the share exists.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<bool> Exists(
            CancellationToken cancellationToken = default) =>
            ExistsInternal(
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// The <see cref="ExistsAsync"/> operation can be called on a
        /// <see cref="ShareClient"/> to see if the associated share
        /// exists on the storage account in the storage service.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns true if the share exists.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<bool>> ExistsAsync(
            CancellationToken cancellationToken = default) =>
            await ExistsInternal(
                async: true,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="ExistsInternal"/> operation can be called on a
        /// <see cref="ShareClient"/> to see if the associated share
        /// exists on the storage account in the storage service.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns true if the share exists.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<bool>> ExistsInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");

                try
                {
                    Response<ShareProperties> response = await GetPropertiesInternal(
                        conditions: null,
                        async: async,
                        cancellationToken: cancellationToken,
                        operationName: $"{nameof(ShareClient)}.{nameof(Exists)}")
                        .ConfigureAwait(false);

                    return Response.FromValue(true, response.GetRawResponse());
                }
                catch (RequestFailedException storageRequestFailedException)
                when (storageRequestFailedException.ErrorCode == ShareErrorCode.ShareNotFound)
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareClient));
                }
            }
        }
        #endregion Exists

        #region Delete If Exists
        /// <summary>
        /// Marks the specified share or share snapshot for deletion, if it exists.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-share">
        /// Delete Share</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
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
        public virtual Response<bool> DeleteIfExists(
            ShareDeleteOptions options,
            CancellationToken cancellationToken = default) =>
            DeleteIfExistsInternal(
                includeSnapshots: default,
                shareSnapshotsDeleteOption: options?.ShareSnapshotsDeleteOption,
                conditions: options?.Conditions,
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// Marks the specified share or share snapshot for deletion, if it exists.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-share">
        /// Delete Share</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
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
        public virtual async Task<Response<bool>> DeleteIfExistsAsync(
            ShareDeleteOptions options,
            CancellationToken cancellationToken = default) =>
            await DeleteIfExistsInternal(
                includeSnapshots: default,
                shareSnapshotsDeleteOption: options?.ShareSnapshotsDeleteOption,
                conditions: options?.Conditions,
                async: true,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Marks the specified share or share snapshot for deletion, if it exists.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-share">
        /// Delete Share</see>.
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
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<bool> DeleteIfExists(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            bool includeSnapshots = true,
            CancellationToken cancellationToken = default) =>
            DeleteIfExistsInternal(
                includeSnapshots,
                shareSnapshotsDeleteOption: default,
                conditions: default,
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// Marks the specified share or share snapshot for deletion, if it exists.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-share">
        /// Delete Share</see>.
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
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<bool>> DeleteIfExistsAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            bool includeSnapshots = true,
            CancellationToken cancellationToken = default) =>
            await DeleteIfExistsInternal(
                includeSnapshots,
                shareSnapshotsDeleteOption: default,
                conditions: default,
                async: true,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Marks the specified share or share snapshot for deletion, if it exists.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-share">
        /// Delete Share</see>.
        /// </summary>
        /// <param name="includeSnapshots">
        /// A value indicating whether to delete a share's snapshots in addition
        /// to the share itself.
        /// </param>
        /// <param name="shareSnapshotsDeleteOption">
        /// Parameter indicating if the share's snapshots or leased snapshots should be deleted.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on deleting the share.
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
        private async Task<Response<bool>> DeleteIfExistsInternal(
            bool includeSnapshots,
            ShareSnapshotsDeleteOption? shareSnapshotsDeleteOption,
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");
                try
                {
                    Response response = await DeleteInternal(
                        includeSnapshots,
                        shareSnapshotsDeleteOption,
                        conditions,
                        async,
                        cancellationToken,
                        operationName: $"{nameof(ShareClient)}.{nameof(DeleteIfExists)}")
                        .ConfigureAwait(false);
                    return Response.FromValue(true, response);
                }
                catch (RequestFailedException storageRequestFailedException)
                when (storageRequestFailedException.ErrorCode == ShareErrorCode.ShareNotFound)
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareClient));
                }
            }
        }
        #endregion Delete If Exists

        #region CreateSnapshot
        /// <summary>
        /// Creates a read-only snapshot of a share.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/snapshot-share">
        /// Snapshot Share</see>.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/snapshot-share">
        /// Snapshot Share</see>.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/snapshot-share">
        /// Snapshot Share</see>.
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
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message: $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareClient)}.{nameof(CreateSnapshot)}");

                try
                {
                    ResponseWithHeaders<ShareCreateSnapshotHeaders> response;

                    scope.Start();

                    if (async)
                    {
                        response = await ShareRestClient.CreateSnapshotAsync(
                            metadata: metadata,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ShareRestClient.CreateSnapshot(
                            metadata: metadata,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToShareSnapshotInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareClient));
                    scope.Dispose();
                }
            }
        }
        #endregion CreateSnapshot

        #region Delete
        /// <summary>
        /// Marks the specified share or share snapshot for deletion.
        /// The share or share snapshot and any files contained within it are later deleted during garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-share">
        /// Delete Share</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
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
            ShareDeleteOptions options,
            CancellationToken cancellationToken = default) =>
            DeleteInternal(
                includeSnapshots: default,
                shareSnapshotsDeleteOption: options?.ShareSnapshotsDeleteOption,
                conditions: options?.Conditions,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Marks the specified share or share snapshot for deletion.
        /// The share or share snapshot and any files contained within it are later deleted during garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-share">
        /// Delete Share</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
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
            ShareDeleteOptions options,
            CancellationToken cancellationToken = default) =>
            await DeleteInternal(
                includeSnapshots: default,
                shareSnapshotsDeleteOption: options?.ShareSnapshotsDeleteOption,
                conditions: options?.Conditions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Marks the specified share or share snapshot for deletion.
        /// The share or share snapshot and any files contained within it are later deleted during garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-share">
        /// Delete Share</see>.
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response Delete(
            bool includeSnapshots = true,
            CancellationToken cancellationToken = default) =>
            DeleteInternal(
                includeSnapshots,
                shareSnapshotsDeleteOption: default,
                conditions: default,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Marks the specified share or share snapshot for deletion.
        /// The share or share snapshot and any files contained within it are later deleted during garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-share">
        /// Delete Share</see>.
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> DeleteAsync(
            bool includeSnapshots = true,
            CancellationToken cancellationToken = default) =>
            await DeleteInternal(
                includeSnapshots,
                shareSnapshotsDeleteOption: default,
                conditions: default,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Marks the specified share or share snapshot for deletion.
        /// The share or share snapshot and any files contained within it are later deleted during garbage collection.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-share">
        /// Delete Share</see>.
        /// </summary>
        /// <param name="includeSnapshots">
        /// If this share snapshots should be deleted.  This parameter is for backwards compatibility.
        /// </param>
        /// <param name="shareSnapshotsDeleteOption">
        /// Parameter indicating if the share's snapshots or leased snapshots should be deleted.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on deleting the share.
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
        internal async Task<Response> DeleteInternal(
            bool? includeSnapshots,
            ShareSnapshotsDeleteOption? shareSnapshotsDeleteOption,
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken,
            string operationName = default)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");

                operationName ??= $"{nameof(ShareClient)}.{nameof(Delete)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);

                try
                {
                    scope.Start();

                    // DeleteSnapshotsOptionType.Include is not valid when deleting a Snapshot Share.
                    if (Uri.GetQueryParameters().ContainsKey(Constants.ShareSnapshotParameterName))
                    {
                        shareSnapshotsDeleteOption = null;
                    }
                    // This is for backwards compatibility.  Perviously, ShareClient.Delete() took a bool includSnapshots parameter.s
                    else if ((includeSnapshots == null || includeSnapshots == true) && shareSnapshotsDeleteOption == null)
                    {
                        shareSnapshotsDeleteOption = ShareSnapshotsDeleteOption.Include;
                    }

                    ResponseWithHeaders<ShareDeleteHeaders> response;

                    if (async)
                    {
                        response = await ShareRestClient.DeleteAsync(
                            deleteSnapshots: shareSnapshotsDeleteOption.ToShareSnapshotsDeleteOptionInternal(),
                            leaseAccessConditions: conditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ShareRestClient.Delete(
                            deleteSnapshots: shareSnapshotsDeleteOption.ToShareSnapshotsDeleteOptionInternal(),
                            leaseAccessConditions: conditions,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareClient));
                    scope.Dispose();
                }
            }
        }
        #endregion Delete

        #region GetProperties
        /// <summary>
        /// The <see cref="GetProperties(ShareFileRequestConditions, CancellationToken)"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the share.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-share-properties">
        /// Get Share Properties</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on getting share properties.
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
        public virtual Response<ShareProperties> GetProperties(
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            GetPropertiesInternal(
                conditions: conditions,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetPropertiesAsync(ShareFileRequestConditions, CancellationToken)"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the share.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-share-properties">
        /// Get Share Properties</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on getting share properties.
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
        public virtual async Task<Response<ShareProperties>> GetPropertiesAsync(
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await GetPropertiesInternal(
                conditions: conditions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetProperties(CancellationToken)"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the share.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-share-properties">
        /// Get Share Properties</see>.
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
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<ShareProperties> GetProperties(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            CancellationToken cancellationToken) =>
            GetPropertiesInternal(
                conditions: default,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetPropertiesAsync(CancellationToken)"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the share.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-share-properties">
        /// Get Share Properties</see>.
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
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<ShareProperties>> GetPropertiesAsync(
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
        /// properties for the share.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-share-properties">
        /// Get Share Properties</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on getting share properties.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <param name="operationName">
        /// Operation name.
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
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken,
            string operationName = null)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");

                operationName ??= $"{nameof(ShareClient)}.{nameof(GetProperties)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);

                try
                {
                    ResponseWithHeaders<ShareGetPropertiesHeaders> response;
                    scope.Start();

                    if (async)
                    {
                        response = await ShareRestClient.GetPropertiesAsync(
                            leaseAccessConditions: conditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ShareRestClient.GetProperties(
                            leaseAccessConditions: conditions,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToShareProperties(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareClient));
                    scope.Dispose();
                }
            }
        }
        #endregion GetProperties

        #region SetProperties
        /// <summary>
        /// Sets properties of the share.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-share-properties">
        /// Set Share Properties</see>.
        /// </summary>
        /// <param name="options">
        /// Properties to set on the share.
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
        public virtual Response<ShareInfo> SetProperties(
            ShareSetPropertiesOptions options,
            CancellationToken cancellationToken = default) =>
            SetPropertiesInternal(
                quotaInGB: options?.QuotaInGB,
                accessTier: options?.AccessTier,
                rootSquash: options?.RootSquash,
                conditions: options?.Conditions,
                operationName: $"{nameof(ShareClient)}.{nameof(SetProperties)}",
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Sets properties of the share.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-share-properties">
        /// Set Share Properties</see>.
        /// </summary>
        /// <param name="options">
        /// Properties to set on the share.
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
        public virtual async Task<Response<ShareInfo>> SetPropertiesAsync(
            ShareSetPropertiesOptions options,
            CancellationToken cancellationToken = default) =>
            await SetPropertiesInternal(
                quotaInGB: options?.QuotaInGB,
                accessTier: options?.AccessTier,
                rootSquash: options?.RootSquash,
                conditions: options?.Conditions,
                operationName: $"{nameof(ShareClient)}.{nameof(SetProperties)}",
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Sets access tier of the share.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-share-properties">
        /// Set Share Properties</see>.
        /// </summary>
        /// <param name="quotaInGB">
        /// Optional. The maximum size of the share.
        /// If unspecified, use the service's default value.
        /// </param>
        /// <param name="accessTier">
        /// Access tier to set on the share.
        /// </param>
        /// <param name="rootSquash">
        /// The root squash to set for the share.  Only valid for NFS shares.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on setting the quota.
        /// </param>
        /// <param name="operationName">
        /// The name of the calling operation.
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
        internal virtual async Task<Response<ShareInfo>> SetPropertiesInternal(
            int? quotaInGB,
            ShareAccessTier? accessTier,
            ShareRootSquash? rootSquash,
            ShareFileRequestConditions conditions,
            string operationName,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(accessTier)}: {accessTier}");

                operationName ??= $"{nameof(ShareClient)}.{nameof(SetProperties)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);

                try
                {
                    ResponseWithHeaders<ShareSetPropertiesHeaders> response;

                    scope.Start();

                    if (async)
                    {
                        response = await ShareRestClient.SetPropertiesAsync(
                            quota: quotaInGB,
                            accessTier: accessTier,
                            rootSquash: rootSquash,
                            leaseAccessConditions: conditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ShareRestClient.SetProperties(
                            quota: quotaInGB,
                            accessTier: accessTier,
                            rootSquash: rootSquash,
                            leaseAccessConditions: conditions,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToShareInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareClient));
                    scope.Dispose();
                }
            }
        }
        #endregion SetProperties

        #region SetQuota
        /// <summary>
        /// Sets the maximum size of the share.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-share-properties">
        /// Set Share Properties</see>.
        /// </summary>
        /// <param name="quotaInGB">
        /// Optional. The maximum size of the share.
        /// If unspecified, use the service's default value.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on setting the quota.
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ShareInfo> SetQuota(
            int quotaInGB = default,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            SetPropertiesInternal(
                quotaInGB: quotaInGB,
                accessTier: default,
                rootSquash: default,
                conditions: conditions,
                operationName: $"{nameof(ShareClient)}.{nameof(SetQuota)}",
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Sets the maximum size of the share.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-share-properties">
        /// Set Share Properties</see>.
        /// </summary>
        /// <param name="quotaInGB">
        /// Optional. The maximum size of the share.
        /// If unspecified, use the service's default value.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on setting the quota.
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ShareInfo>> SetQuotaAsync(
            int quotaInGB = default,
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await SetPropertiesInternal(
                quotaInGB: quotaInGB,
                accessTier: default,
                rootSquash: default,
                conditions: conditions,
                operationName: $"{nameof(ShareClient)}.{nameof(SetQuota)}",
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Sets the maximum size of the share.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-share-properties">
        /// Set Share Properties</see>.
        /// </summary>
        /// <param name="quotaInGB">
        /// Optional. The maximum size of the share.
        /// If unspecified, use the service's default value.
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
        [EditorBrowsable(EditorBrowsableState.Never)]

#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<ShareInfo> SetQuota(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            int quotaInGB,
            CancellationToken cancellationToken) =>
            SetPropertiesInternal(
                quotaInGB: quotaInGB,
                accessTier: default,
                rootSquash: default,
                conditions: default,
                operationName: $"{nameof(ShareClient)}.{nameof(SetQuota)}",
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Sets the maximum size of the share.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-share-properties">
        /// Set Share Properties</see>.
        /// </summary>
        /// <param name="quotaInGB">
        /// Optional. The maximum size of the share.
        /// If unspecified, use the service's default value.
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
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<ShareInfo>> SetQuotaAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            int quotaInGB,
            CancellationToken cancellationToken) =>
            await SetPropertiesInternal(
                quotaInGB: quotaInGB,
                accessTier: default,
                rootSquash: default,
                conditions: default,
                operationName: $"{nameof(ShareClient)}.{nameof(SetQuota)}",
                async: true,
                cancellationToken)
                .ConfigureAwait(false);
        #endregion SetQuota

        #region SetMetadata
        /// <summary>
        /// The <see cref="SetMetadata(Metadata, ShareFileRequestConditions, CancellationToken)"/>
        /// operation sets user-defined metadata for the specified share as one or more name-value pairs.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-share-metadata">
        /// Set Share Metadata</see>.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this share.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on setting share metadata.
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
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            SetMetadataInternal(
                metadata,
                conditions: conditions,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="SetMetadataAsync(Metadata, ShareFileRequestConditions, CancellationToken)"/>
        /// operation sets user-defined metadata for the specified share as one or more name-value pairs.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-share-metadata">
        /// Set Share Metadata</see>.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this share.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on setting share metadata.
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
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await SetMetadataInternal(
                metadata,
                conditions: conditions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetMetadata(Metadata, CancellationToken)"/> operation sets user-defined
        /// metadata for the specified share as one or more name-value pairs.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-share-metadata">
        /// Set Share Metadata</see>.
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
        [EditorBrowsable(EditorBrowsableState.Never)]

#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<ShareInfo> SetMetadata(
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
        /// The <see cref="SetMetadataAsync(Metadata, CancellationToken)"/> operation sets user-defined
        /// metadata for the specified share as one or more name-value pairs.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-share-metadata">
        /// Set Share Metadata</see>.
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
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<ShareInfo>> SetMetadataAsync(
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
        /// metadata for the specified share as one or more name-value pairs.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-share-metadata">
        /// Set Share Metadata</see>.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this share.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on setting share metadata.
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
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message: $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareClient)}.{nameof(SetMetadata)}");

                try
                {
                    ResponseWithHeaders<ShareSetMetadataHeaders> response;

                    scope.Start();

                    if (async)
                    {
                        response = await ShareRestClient.SetMetadataAsync(
                            metadata: metadata,
                            leaseAccessConditions: conditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ShareRestClient.SetMetadata(
                            metadata: metadata,
                            leaseAccessConditions: conditions,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToShareInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareClient));
                    scope.Dispose();
                }
            }
        }
        #endregion SetMetadata

        #region GetAccessPolicy
        /// <summary>
        /// The <see cref="GetAccessPolicy(ShareFileRequestConditions, CancellationToken)"/> operation gets the
        /// permissions for this share. The permissions indicate whether
        /// share data may be accessed publicly.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-share-acl">
        /// Get Share ACL</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on getting share access policy.
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<IEnumerable<ShareSignedIdentifier>> GetAccessPolicy(
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            GetAccessPolicyInternal(
                conditions: conditions,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetAccessPolicyAsync(ShareFileRequestConditions, CancellationToken)"/> operation gets the
        /// permissions for this share. The permissions indicate whether
        /// share data may be accessed publicly.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-share-acl">
        /// Get Share ACL</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on getting share access policy.
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
        public virtual async Task<Response<IEnumerable<ShareSignedIdentifier>>> GetAccessPolicyAsync(
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await GetAccessPolicyInternal(
                conditions: conditions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetAccessPolicy(CancellationToken)"/> operation gets the
        /// permissions for this share. The permissions indicate whether
        /// share data may be accessed publicly.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-share-acl">
        /// Get Share ACL</see>.
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
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<IEnumerable<ShareSignedIdentifier>> GetAccessPolicy(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            CancellationToken cancellationToken) =>
            GetAccessPolicyInternal(
                conditions: default,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetAccessPolicyAsync(CancellationToken)"/> operation gets the
        /// permissions for this share. The permissions indicate whether
        /// share data may be accessed publicly.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-share-acl">
        /// Get Share ACL</see>.
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
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<IEnumerable<ShareSignedIdentifier>>> GetAccessPolicyAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            CancellationToken cancellationToken) =>
            await GetAccessPolicyInternal(
                conditions: default,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetAccessPolicyInternal"/> operation gets the
        /// permissions for this share. The permissions indicate whether
        /// share data may be accessed publicly.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-share-acl">
        /// Get Share ACL</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on getting share access policy.
        /// </param>
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
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message: $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareClient)}.{nameof(GetAccessPolicy)}");

                try
                {
                    ResponseWithHeaders<IReadOnlyList<ShareSignedIdentifier>, ShareGetAccessPolicyHeaders> response;
                    scope.Start();

                    if (async)
                    {
                        response = await ShareRestClient.GetAccessPolicyAsync(
                            leaseAccessConditions: conditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ShareRestClient.GetAccessPolicy(
                            leaseAccessConditions: conditions,
                            cancellationToken: cancellationToken);
                    }

                    IEnumerable<ShareSignedIdentifier> shareSignedIdentifiers = response.Value.ToList();

                    return Response.FromValue(
                        shareSignedIdentifiers,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareClient));
                    scope.Dispose();
                }
            }
        }
        #endregion GetAccessPolicy

        #region SetAccessPolicy
        /// <summary>
        /// The <see cref="SetAccessPolicy(IEnumerable{ShareSignedIdentifier}, ShareFileRequestConditions, CancellationToken)"/>
        /// operation sets the permissions for the specified share. The permissions indicate
        /// whether share data may be accessed publicly.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-share-acl">
        /// Set Share ACL</see>.
        /// </summary>
        /// <param name="permissions">
        /// Stored access policies that you can use to provide fine grained
        /// control over share permissions.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on setting the access policy.
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
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            SetAccessPolicyInternal(
                permissions,
                conditions: conditions,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="SetAccessPolicyAsync(IEnumerable{ShareSignedIdentifier}, ShareFileRequestConditions, CancellationToken)"/>
        /// operation sets the permissions for the specified share. The permissions indicate
        /// whether share data may be accessed publicly.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-share-acl">
        /// Set Share ACL</see>.
        /// </summary>
        /// <param name="permissions">
        /// Stored access policies that you can use to provide fine grained
        /// control over share permissions.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on setting the access policy.
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
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await SetAccessPolicyInternal(
                permissions,
                conditions: conditions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetAccessPolicy(IEnumerable{ShareSignedIdentifier}, CancellationToken)"/>
        /// operation sets the permissions for the specified share. The permissions indicate
        /// whether share data may be accessed publicly.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-share-acl">
        /// Set Share ACL</see>.
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
        [EditorBrowsable(EditorBrowsableState.Never)]

#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<ShareInfo> SetAccessPolicy(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            IEnumerable<ShareSignedIdentifier> permissions,
            CancellationToken cancellationToken) =>
            SetAccessPolicyInternal(
                permissions,
                conditions: default,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="SetAccessPolicyAsync(IEnumerable{ShareSignedIdentifier}, CancellationToken)"/>
        /// operation sets the permissions for the specified share. The permissions indicate
        /// whether share data may be accessed publicly.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-share-acl">
        /// Set Share ACL</see>.
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
        [EditorBrowsable(EditorBrowsableState.Never)]

#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<ShareInfo>> SetAccessPolicyAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            IEnumerable<ShareSignedIdentifier> permissions,
            CancellationToken cancellationToken) =>
            await SetAccessPolicyInternal(
                permissions,
                conditions: default,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetAccessPolicyInternal"/> operation sets the
        /// permissions for the specified share. The permissions indicate
        /// whether share data may be accessed publicly.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-share-acl">
        /// Set Share ACL</see>.
        /// </summary>
        /// <param name="permissions">
        /// Stored access policies that you can use to provide fine grained
        /// control over share permissions.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on setting the access policy.
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
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message: $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareClient)}.{nameof(SetAccessPolicy)}");

                try
                {
                    ResponseWithHeaders<ShareSetAccessPolicyHeaders> response;
                    scope.Start();

                    if (async)
                    {
                        response = await ShareRestClient.SetAccessPolicyAsync(
                            shareAcl: permissions,
                            leaseAccessConditions: conditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ShareRestClient.SetAccessPolicy(
                            shareAcl: permissions,
                            leaseAccessConditions: conditions,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToShareInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareClient));
                    scope.Dispose();
                }
            }
        }
        #endregion SetAccessPolicy

        #region GetStatistics
        /// <summary>
        /// Retrieves statistics related to the share.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-share-stats">
        /// Get Share Stats</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on getting share stats.
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
        public virtual Response<ShareStatistics> GetStatistics(
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            GetStatisticsInternal(
                conditions: conditions,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Retrieves statistics related to the share.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-share-stats">
        /// Get Share Stats</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on getting share stats.
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
        public virtual async Task<Response<ShareStatistics>> GetStatisticsAsync(
            ShareFileRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await GetStatisticsInternal(
                conditions: conditions,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Retrieves statistics related to the share.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-share-stats">
        /// Get Share Stats</see>.
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
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<ShareStatistics> GetStatistics(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            CancellationToken cancellationToken) =>
            GetStatisticsInternal(
                conditions: default,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Retrieves statistics related to the share.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-share-stats">
        /// Get Share Stats</see>.
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
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<ShareStatistics>> GetStatisticsAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            CancellationToken cancellationToken) =>
            await GetStatisticsInternal(
                conditions: default,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Retrieves statistics related to the share.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-share-stats"
        /// >Get Share Stats</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on getting share stats.
        /// </param>
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
            ShareFileRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message: $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareClient)}.{nameof(GetStatistics)}");

                try
                {
                    ResponseWithHeaders<ShareStatistics, ShareGetStatisticsHeaders> response;

                    scope.Start();

                    if (async)
                    {
                        response = await ShareRestClient.GetStatisticsAsync(
                            leaseAccessConditions: conditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ShareRestClient.GetStatistics(
                            leaseAccessConditions: conditions,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.Value,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareClient));
                    scope.Dispose();
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
                async: false,
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
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        private async Task<Response<string>> GetPermissionInternal(
            string filePermissionKey,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message: $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareClient)}.{nameof(GetPermission)}");

                try
                {
                    ResponseWithHeaders<SharePermission, ShareGetPermissionHeaders> response;

                    scope.Start();

                    if (async)
                    {
                        response = await ShareRestClient.GetPermissionAsync(
                            filePermissionKey: filePermissionKey,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ShareRestClient.GetPermission(
                            filePermissionKey: filePermissionKey,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.Value.Permission,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareClient));
                    scope.Dispose();
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
                async: false,
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
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        internal async Task<Response<PermissionInfo>> CreatePermissionInternal(
            string permission,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareClient),
                    message: $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareClient)}.{nameof(CreatePermission)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<ShareCreatePermissionHeaders> response;
                    SharePermission sharePermission = new SharePermission(permission);

                    if (async)
                    {
                        response = await ShareRestClient.CreatePermissionAsync(
                            sharePermission: sharePermission,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ShareRestClient.CreatePermission(
                            sharePermission: sharePermission,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToPermissionInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareClient));
                    scope.Dispose();
                }
            }
        }
        #endregion CreatePermission

        #region CreateDirectory
        /// <summary>
        /// The <see cref="CreateDirectory"/> operation creates a new
        /// directory in this share.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-directory">
        /// Create Directory</see>.
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
        public virtual Response<ShareDirectoryClient> CreateDirectory(
           string directoryName,
           IDictionary<string, string> metadata = default,
           FileSmbProperties smbProperties = default,
           string filePermission = default,
           CancellationToken cancellationToken = default)
        {
            ShareDirectoryClient directory = GetDirectoryClient(directoryName);
            Response<ShareDirectoryInfo> response = directory.CreateInternal(
                metadata,
                smbProperties,
                filePermission,
                async: false,
                cancellationToken,
                operationName: $"{nameof(ShareClient)}.{nameof(CreateDirectory)}")
                .EnsureCompleted();
            return Response.FromValue(directory, response.GetRawResponse());
        }

        /// <summary>
        /// The <see cref="CreateDirectoryAsync"/> operation creates a new
        /// directory in this share.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-directory">
        /// Create Directory</see>.
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
        public virtual async Task<Response<ShareDirectoryClient>> CreateDirectoryAsync(
           string directoryName,
           IDictionary<string, string> metadata = default,
           FileSmbProperties smbProperties = default,
           string filePermission = default,
           CancellationToken cancellationToken = default)
        {
            ShareDirectoryClient directory = GetDirectoryClient(directoryName);
            Response<ShareDirectoryInfo> response = await directory.CreateInternal(
                metadata,
                smbProperties,
                filePermission,
                async: true,
                cancellationToken,
                operationName: $"{nameof(ShareClient)}.{nameof(CreateDirectory)}")
                .ConfigureAwait(false);
            return Response.FromValue(directory, response.GetRawResponse());
        }
        #endregion CreateDirectory

        #region DeleteDirectory
        /// <summary>
        /// The <see cref="DeleteDirectory"/> operation removes the specified empty
        /// directory.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-directory">
        /// Delete Directory</see>.
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
            GetDirectoryClient(directoryName).DeleteInternal(
                async: false,
                cancellationToken,
                operationName: $"{nameof(ShareClient)}.{nameof(DeleteDirectory)}")
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="DeleteDirectoryAsync"/> operation removes the specified empty
        /// directory.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-directory">
        /// Delete Directory</see>.
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
        public virtual async Task<Response> DeleteDirectoryAsync(
            string directoryName,
            CancellationToken cancellationToken = default) =>
            await GetDirectoryClient(directoryName)
                .DeleteInternal(
                async: true,
                cancellationToken,
                operationName: $"{nameof(ShareClient)}.{nameof(DeleteDirectory)}")
                .ConfigureAwait(false);
        #endregion DeleteDirectory

        #region GenerateSas
        /// <summary>
        /// The <see cref="GenerateSasUri(ShareSasPermissions, DateTimeOffset)"/>
        /// returns a <see cref="Uri"/> that generates a Share Service
        /// Shared Access Signature (SAS) Uri based on the
        /// Client properties and parameters passed.
        /// The SAS is signed by the shared key credential of the client.
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
        /// See <see cref="ShareSasPermissions"/>.
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
        public virtual Uri GenerateSasUri(ShareSasPermissions permissions, DateTimeOffset expiresOn) =>
            GenerateSasUri(new ShareSasBuilder(permissions, expiresOn) { ShareName = Name });

        /// <summary>
        /// The <see cref="GenerateSasUri(ShareSasBuilder)"/> returns a <see cref="Uri"/>
        /// that generates a Blob Container Service Shared Access Signature (SAS) Uri
        /// based on the Client properties and builder passed.
        /// The SAS is signed by the shared key credential of the client.
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
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if a failure occurs.
        /// </remarks>
        public virtual Uri GenerateSasUri(ShareSasBuilder builder)
        {
            builder = builder ?? throw Errors.ArgumentNull(nameof(builder));

            // Deep copy of builder so we don't modify the user's original DataLakeSasBuilder.
            builder = ShareSasBuilder.DeepCopy(builder);

            // Assign builder's ShareName and Path, if they are null.
            builder.ShareName ??= Name;

            if (!builder.ShareName.Equals(Name, StringComparison.InvariantCulture))
            {
                throw Errors.SasNamesNotMatching(
                    nameof(builder.ShareName),
                    nameof(ShareSasBuilder),
                    nameof(Name));
            }
            if (!string.IsNullOrEmpty(builder.FilePath))
            {
                throw Errors.SasBuilderEmptyParam(
                    nameof(builder),
                    nameof(builder.FilePath),
                    nameof(Constants.File.Share.Name));
            }
            ShareUriBuilder sasUri = new ShareUriBuilder(Uri)
            {
                Query = builder.ToSasQueryParameters(ClientConfiguration.SharedKeyCredential).ToString()
            };
            return sasUri.ToUri();
        }
        #endregion
    }
}
