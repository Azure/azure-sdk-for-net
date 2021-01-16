// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Sas;

namespace Azure.Storage.Files.Shares
{
    /// <summary>
    /// The <see cref="ShareServiceClient"/> allows you to manipulate Azure
    /// Storage service resources and shares. The storage account provides
    /// the top-level namespace for the File service.
    /// </summary>
    public class ShareServiceClient
    {
        /// <summary>
        /// The file service's primary <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _uri;

        /// <summary>
        /// Gets the file service's primary <see cref="Uri"/> endpoint.
        /// </summary>
        public virtual Uri Uri => _uri;

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send
        /// every request.
        /// </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary>
        /// Gets tghe <see cref="HttpPipeline"/> transport pipeline used to
        /// send every request.
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
        /// The Storage account name corresponding to the file service client.
        /// </summary>
        private string _accountName;

        /// <summary>
        /// Gets the Storage account name corresponding to the file service client.
        /// </summary>
        public virtual string AccountName
        {
            get
            {
                if (_accountName == null)
                {
                    _accountName = new ShareUriBuilder(Uri).AccountName;
                }
                return _accountName;
            }
        }

        /// <summary>
        /// The <see cref="StorageSharedKeyCredential"/> used to authenticate and generate SAS
        /// </summary>
        private StorageSharedKeyCredential _storageSharedKeyCredential;

        /// <summary>
        /// Gets the The <see cref="StorageSharedKeyCredential"/> used to authenticate and generate SAS.
        /// </summary>
        internal virtual StorageSharedKeyCredential SharedKeyCredential => _storageSharedKeyCredential;

        /// <summary>
        /// Determines whether the client is able to generate a SAS.
        /// If the client is authenticated with a <see cref="StorageSharedKeyCredential"/>.
        /// </summary>
        public bool CanGenerateAccountSasUri => SharedKeyCredential != null;

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="ShareServiceClient"/>
        /// class for mocking.
        /// </summary>
        protected ShareServiceClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information,
        /// <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">
        /// Configure Azure Storage connection strings</see>.
        /// </param>
        public ShareServiceClient(string connectionString)
            : this(connectionString, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information,
        /// <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">
        /// Configure Azure Storage connection strings</see>.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public ShareServiceClient(string connectionString, ShareClientOptions options)
        {
            options ??= new ShareClientOptions();
            var conn = StorageConnectionString.Parse(connectionString);
            _uri = conn.FileEndpoint;
            _pipeline = options.Build(conn.Credentials);
            _version = options.Version;
            _clientDiagnostics = new ClientDiagnostics(options);
            _storageSharedKeyCredential = conn.Credentials as StorageSharedKeyCredential;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the file service.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public ShareServiceClient(Uri serviceUri, ShareClientOptions options = default)
            : this(serviceUri, (HttpPipelinePolicy)null, options, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the file service.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public ShareServiceClient(Uri serviceUri, StorageSharedKeyCredential credential, ShareClientOptions options = default)
            : this(serviceUri, credential.AsPolicy(), options, credential)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the file service.
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
        public ShareServiceClient(Uri serviceUri, AzureSasCredential credential, ShareClientOptions options = default)
            : this(serviceUri, credential.AsPolicy<ShareUriBuilder>(serviceUri), options, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the file service.
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
        internal ShareServiceClient(
            Uri serviceUri,
            HttpPipelinePolicy authentication,
            ShareClientOptions options,
            StorageSharedKeyCredential storageSharedKeyCredential)
        {
            Argument.AssertNotNull(serviceUri, nameof(serviceUri));
            options ??= new ShareClientOptions();
            _uri = serviceUri;
            _pipeline = options.Build(authentication);
            _version = options.Version;
            _clientDiagnostics = new ClientDiagnostics(options);
            _storageSharedKeyCredential = storageSharedKeyCredential;
        }
        #endregion ctors

        /// <summary>
        /// Create a new <see cref="ShareClient"/> object by appending
        /// <paramref name="shareName"/> to the end of <see cref="Uri"/>.
        /// The new <see cref="ShareClient"/> uses the same request
        /// policy pipeline as the <see cref="ShareServiceClient"/>.
        /// </summary>
        /// <param name="shareName">
        /// The name of the share to reference.
        /// </param>
        /// <returns>
        /// A <see cref="ShareClient"/> for the desired share.
        /// </returns>
        public virtual ShareClient GetShareClient(string shareName) =>
            new ShareClient(Uri.AppendToPath(shareName), Pipeline, SharedKeyCredential, Version, ClientDiagnostics);

        #region GetShares
        /// <summary>
        /// The <see cref="GetShares"/> operation returns an async sequence
        /// of the shares in the storage account.  Enumerating the shares may
        /// make multiple requests to the service while fetching all the
        /// values.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-shares">
        /// List Shares</see>.
        /// </summary>
        /// <param name="traits">
        /// Specifies traits to include in the <see cref="ShareItem"/>s.
        /// </param>
        /// <param name="states">
        /// Specifies states to include when listing shares.
        /// </param>
        /// <param name="prefix">
        /// String that filters the results to return only shares whose name
        /// begins with the specified prefix.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of <see cref="Response{ShareItem}"/>
        /// describing the shares in the storage account.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Pageable<ShareItem> GetShares(
            ShareTraits traits = ShareTraits.None,
            ShareStates states = ShareStates.None,
            string prefix = default,
            CancellationToken cancellationToken = default) =>
            new GetSharesAsyncCollection(this, traits, states, prefix).ToSyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetSharesAsync"/> operation returns an async collection
        /// of the shares in the storage account.  Enumerating the shares may
        /// make multiple requests to the service while fetching all the
        /// values.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-shares">
        /// List Shares</see>.
        /// </summary>
        /// <param name="traits">
        /// Specifies traits to include in the <see cref="ShareItem"/>s.
        /// </param>
        /// <param name="states">
        /// Specifies states to include when listing shares.
        /// </param>
        /// <param name="prefix">
        /// String that filters the results to return only shares whose name
        /// begins with the specified prefix.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="AsyncPageable{T}"/> describing the shares in
        /// the storage account.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual AsyncPageable<ShareItem> GetSharesAsync(
            ShareTraits traits = ShareTraits.None,
            ShareStates states = ShareStates.None,
            string prefix = default,
            CancellationToken cancellationToken = default) =>
            new GetSharesAsyncCollection(this, traits, states, prefix).ToAsyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetSharesInternal"/> operation returns a
        /// single segment of shares in the storage account, starting
        /// from the specified <paramref name="marker"/>.  Use an empty
        /// <paramref name="marker"/> to start enumeration from the beginning
        /// and the <see cref="SharesSegment.NextMarker"/> if it's not
        /// empty to make subsequent calls to <see cref="GetSharesAsync"/>
        /// to continue enumerating the shares segment by segment.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-shares">
        /// List Shares</see>.
        /// </summary>
        /// <param name="marker">
        /// An optional string value that identifies the segment of the list
        /// of shares to be returned with the next listing operation.  The
        /// operation returns a non-empty <see cref="SharesSegment.NextMarker"/>
        /// if the listing operation did not return all shares remaining
        /// to be listed with the current segment.  The NextMarker value can
        /// be used as the value for the <paramref name="marker"/> parameter
        /// in a subsequent call to request the next segment of list items.
        /// </param>
        /// <param name="traits">
        /// Specifies traits to include in the <see cref="ShareItem"/>s.
        /// </param>
        /// <param name="states">
        /// Specifies states to include when listing shares.
        /// </param>
        /// <param name="prefix">
        /// String that filters the results to return only shares whose name
        /// begins with the specified prefix.
        /// </param>
        /// <param name="pageSizeHint">
        /// Gets or sets a value indicating the size of the page that should be
        /// requested.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{SharesSegment}"/> describing a
        /// segment of the shares in the storage account.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<Response<SharesSegment>> GetSharesInternal(
            string marker,
            ShareTraits traits,
            ShareStates states,
            string prefix,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareServiceClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareServiceClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(marker)}: {marker}");
                try
                {
                    Response<SharesSegment> response = await FileRestClient.Service.ListSharesSegmentAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        marker: marker,
                        prefix: prefix,
                        maxresults: pageSizeHint,
                        include: ShareExtensions.AsIncludeItems(traits, states),
                        async: async,
                        operationName: $"{nameof(ShareServiceClient)}.{nameof(GetShares)}",
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                    if ((traits & ShareTraits.Metadata) != ShareTraits.Metadata)
                    {
                        IEnumerable<ShareItemInternal> shareItemInternals = response.Value.ShareItems;
                        foreach (ShareItemInternal shareItemInternal in shareItemInternals)
                        {
                            shareItemInternal.Properties.Metadata = null;
                        }
                    }
                    return response;
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(ShareServiceClient));
                }
            }
        }
        #endregion GetShares

        #region GetProperties
        /// <summary>
        /// The <see cref="GetProperties"/> operation gets the properties
        /// of a storage account’s file service, including properties for
        /// Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-file-service-properties">
        /// Get File Service Properties</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileServiceProperties}"/> describing
        /// the service properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareServiceProperties> GetProperties(
            CancellationToken cancellationToken = default) =>
            GetPropertiesInternal(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetPropertiesAsync"/> operation gets the properties
        /// of a storage account’s file service, including properties for
        /// Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-file-service-properties">
        /// Get File Service Properties</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileServiceProperties}"/> describing
        /// the service properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareServiceProperties>> GetPropertiesAsync(
            CancellationToken cancellationToken = default) =>
            await GetPropertiesInternal(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetPropertiesInternal"/> operation gets the properties
        /// of a storage account’s file service, including properties for
        /// Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-file-service-properties">
        /// Get File Service Properties</see>.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileServiceProperties}"/> describing
        /// the service properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareServiceProperties>> GetPropertiesInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareServiceClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareServiceClient),
                    message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    return await FileRestClient.Service.GetPropertiesAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        async: async,
                        operationName: $"{nameof(ShareServiceClient)}.{nameof(GetProperties)}",
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
                    Pipeline.LogMethodExit(nameof(ShareServiceClient));
                }
            }
        }
        #endregion GetProperties

        #region SetProperties
        /// <summary>
        /// The <see cref="SetProperties"/> operation sets properties for
        /// a storage account’s File service endpoint, including properties
        /// for Storage Analytics, CORS (Cross-Origin Resource Sharing) rules
        /// and soft delete settings.  You can also use this operation to set
        /// the default request version for all incoming requests to the File
        /// service that do not have a version specified.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-file-service-properties">
        /// Set File Service Properties</see>.
        /// </summary>
        /// <param name="properties">The file service properties.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> if the operation was successful.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response SetProperties(
            ShareServiceProperties properties,
            CancellationToken cancellationToken = default) =>
            SetPropertiesInternal(
                properties,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="SetPropertiesAsync"/> operation sets properties for
        /// a storage account’s File service endpoint, including properties
        /// for Storage Analytics, CORS (Cross-Origin Resource Sharing) rules
        /// and soft delete settings.  You can also use this operation to set
        /// the default request version for all incoming requests to the File
        /// service that do not have a version specified.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-file-service-properties">
        /// Set File Service Properties</see>.
        /// </summary>
        /// <param name="properties">The file service properties.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> if the operation was successful.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> SetPropertiesAsync(
            ShareServiceProperties properties,
            CancellationToken cancellationToken = default) =>
            await SetPropertiesInternal(
                properties,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetPropertiesInternal"/> operation sets properties for
        /// a storage account’s File service endpoint, including properties
        /// for Storage Analytics, CORS (Cross-Origin Resource Sharing) rules
        /// and soft delete settings.  You can also use this operation to set
        /// the default request version for all incoming requests to the File
        /// service that do not have a version specified.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-file-service-properties">
        /// Set File Service Properties</see>.
        /// </summary>
        /// <param name="properties">The file service properties.</param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> if the operation was successful.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response> SetPropertiesInternal(
            ShareServiceProperties properties,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareServiceClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareServiceClient),
                    message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    return await FileRestClient.Service.SetPropertiesAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        properties: properties,
                        async: async,
                        operationName: $"{nameof(ShareServiceClient)}.{nameof(SetProperties)}",
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
                    Pipeline.LogMethodExit(nameof(ShareServiceClient));
                }
            }
        }
        #endregion SetProperties

        #region CreateShare
        /// <summary>
        /// The <see cref="CreateShare(string, ShareCreateOptions, CancellationToken)"/>
        /// operation creates a new share under the specified account. If a share with the same name
        /// already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-share">
        /// Create Share</see>.
        /// </summary>
        /// <param name="shareName">
        /// The name of the share to create.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareClient}"/> referencing the newly
        /// created share.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareClient> CreateShare(
            string shareName,
            ShareCreateOptions options,
            CancellationToken cancellationToken = default)
        {
            ShareClient share = GetShareClient(shareName);

            Response<ShareInfo> response = share.CreateInternal(
                options?.Metadata,
                options?.QuotaInGB,
                options?.AccessTier,
                options?.Protocols,
                options?.RootSquash,
                async: false,
                cancellationToken,
                operationName: $"{nameof(ShareServiceClient)}.{nameof(CreateShare)}")
                .EnsureCompleted();

            return Response.FromValue(share, response.GetRawResponse());
        }

        /// <summary>
        /// The <see cref="CreateShare(string, ShareCreateOptions, CancellationToken)"/>
        /// operation creates a new share under the specified account. If a share with the same name
        /// already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-share">
        /// Create Share</see>.
        /// </summary>
        /// <param name="shareName">
        /// The name of the share to create.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareClient}"/> referencing the newly
        /// created share.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareClient>> CreateShareAsync(
            string shareName,
            ShareCreateOptions options,
            CancellationToken cancellationToken = default)
        {
            ShareClient share = GetShareClient(shareName);

            Response<ShareInfo> response = await share.CreateInternal(
                options?.Metadata,
                options?.QuotaInGB,
                options?.AccessTier,
                options?.Protocols,
                options?.RootSquash,
                async: true,
                cancellationToken,
                operationName: $"{nameof(ShareServiceClient)}.{nameof(CreateShare)}")
                .ConfigureAwait(false);

            return Response.FromValue(share, response.GetRawResponse());
        }

        /// <summary>
        /// The <see cref="CreateShare(string, IDictionary{string, string}, int?, CancellationToken)"/>
        /// operation creates a new share under the specified account. If a share with the same name
        /// already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-share">
        /// Create Share</see>.
        /// </summary>
        /// <param name="shareName">
        /// The name of the share to create.
        /// </param>
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
        /// A <see cref="Response{ShareClient}"/> referencing the newly
        /// created share.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ShareClient> CreateShare(
            string shareName,
            IDictionary<string, string> metadata = default,
            int? quotaInGB = default,
            CancellationToken cancellationToken = default)
        {
            ShareClient share = GetShareClient(shareName);

            Response<ShareInfo> response = share.CreateInternal(
                metadata,
                quotaInGB,
                accessTier: default,
                enabledProtocols: default,
                rootSquash: default,
                async: false,
                cancellationToken,
                operationName: $"{nameof(ShareServiceClient)}.{nameof(CreateShare)}")
                .EnsureCompleted();

            return Response.FromValue(share, response.GetRawResponse());
        }

        /// <summary>
        /// The <see cref="CreateShareAsync(string, IDictionary{string, string}, int?, CancellationToken)"/>
        /// operation creates a new share under the specified account. If a share with the same name
        /// already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-share">
        /// Create Share</see>.
        /// </summary>
        /// <param name="shareName">
        /// The name of the share to create.
        /// </param>
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
        /// A <see cref="Response{ShareClient}"/> referencing the newly
        /// created share.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ShareClient>> CreateShareAsync(
            string shareName,
            IDictionary<string, string> metadata = default,
            int? quotaInGB = default,
            CancellationToken cancellationToken = default)
        {
            ShareClient share = GetShareClient(shareName);

            Response<ShareInfo> response = await share.CreateInternal(
                metadata,
                quotaInGB,
                accessTier: default,
                enabledProtocols: default,
                rootSquash: default,
                async: true,
                cancellationToken,
                operationName: $"{nameof(ShareServiceClient)}.{nameof(CreateShare)}")
                .ConfigureAwait(false);

            return Response.FromValue(share, response.GetRawResponse());
        }
        #endregion CreateShare

        #region DeleteShare
        /// <summary>
        /// Marks the specified share or share snapshot for deletion.
        /// The share or share snapshot and any files contained within it are later deleted during garbage collection.
        ///
        /// Currently, this method will always delete snapshots.
        /// There's no way to specify a separate value for x-ms-delete-snapshots.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-share">
        /// Delete Share</see>.
        /// </summary>
        /// <param name="shareName">
        /// The name of the share to delete.
        /// </param>
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
        public virtual Response DeleteShare(
            string shareName,
            ShareDeleteOptions options,
            CancellationToken cancellationToken = default) =>
            GetShareClient(shareName).DeleteInternal(
                includeSnapshots: default,
                shareSnapshotsDeleteOption: options?.ShareSnapshotsDeleteOption,
                conditions: options?.Conditions,
                async: false,
                cancellationToken,
                operationName: $"{nameof(ShareServiceClient)}.{nameof(DeleteShare)}")
                .EnsureCompleted();

        /// <summary>
        /// Marks the specified share or share snapshot for deletion.
        /// The share or share snapshot and any files contained within it are later deleted during garbage collection.
        ///
        /// Currently, this method will always delete snapshots.  There's no way to specify a separate value for x-ms-delete-snapshots.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-share">
        /// Delete Share</see>.
        /// </summary>
        /// <param name="shareName">
        /// The name of the share to delete.
        /// </param>
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
        public virtual async Task<Response> DeleteShareAsync(
            string shareName,
            ShareDeleteOptions options,
            CancellationToken cancellationToken = default) =>
            await GetShareClient(shareName)
                .DeleteInternal(
                    includeSnapshots: default,
                    shareSnapshotsDeleteOption: options?.ShareSnapshotsDeleteOption,
                    conditions: options?.Conditions,
                    async: true,
                    cancellationToken,
                    operationName: $"{nameof(ShareServiceClient)}.{nameof(DeleteShare)}")
                .ConfigureAwait(false);

        /// <summary>
        /// Marks the specified share or share snapshot for deletion.
        /// The share or share snapshot and any files contained within it are later deleted during garbage collection.
        ///
        /// Currently, this method will always delete snapshots.
        /// There's no way to specify a separate value for x-ms-delete-snapshots.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-share">
        /// Delete Share</see>.
        /// </summary>
        /// <param name="shareName">
        /// The name of the share to delete.
        /// </param>
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
        public virtual Response DeleteShare(
            string shareName,
            bool includeSnapshots = true,
            CancellationToken cancellationToken = default) =>
            GetShareClient(shareName).DeleteInternal(
                includeSnapshots,
                shareSnapshotsDeleteOption: default,
                conditions: default,
                async: false,
                cancellationToken,
                operationName: $"{nameof(ShareServiceClient)}.{nameof(DeleteShare)}")
                .EnsureCompleted();

        /// <summary>
        /// Marks the specified share or share snapshot for deletion.
        /// The share or share snapshot and any files contained within it are later deleted during garbage collection.
        ///
        /// Currently, this method will always delete snapshots.  There's no way to specify a separate value for x-ms-delete-snapshots.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-share">
        /// Delete Share</see>.
        /// </summary>
        /// <param name="shareName">
        /// The name of the share to delete.
        /// </param>
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
        public virtual async Task<Response> DeleteShareAsync(
            string shareName,
            bool includeSnapshots = true,
            CancellationToken cancellationToken = default) =>
            await GetShareClient(shareName)
                .DeleteInternal(
                    includeSnapshots,
                    shareSnapshotsDeleteOption: default,
                    conditions: default,
                    async: true,
                    cancellationToken,
                    operationName: $"{nameof(ShareServiceClient)}.{nameof(DeleteShare)}")
                .ConfigureAwait(false);
        #endregion DeleteShare

        #region UndeleteShare
        /// <summary>
        /// Restores a previously deleted Share.
        /// This API is only functional is Share Soft Delete is enabled
        /// for the storage account associated with the share.
        /// </summary>
        /// <param name="deletedShareName">
        /// The name of the share to restore.
        /// </param>
        /// <param name="deletedShareVersion">
        /// The version of the share to restore.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareClient}"/> pointed at the restored Share.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareClient> UndeleteShare(
            string deletedShareName,
            string deletedShareVersion,
            CancellationToken cancellationToken = default)
            => UndeleteShareInternal(
                deletedShareName,
                deletedShareVersion,
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// Restores a previously deleted Share.
        /// This API is only functional is Share Soft Delete is enabled
        /// for the storage account associated with the share.
        /// </summary>
        /// <param name="deletedShareName">
        /// The name of the share to restore.
        /// </param>
        /// <param name="deletedShareVersion">
        /// The version of the share to restore.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareClient}"/> pointed at the restored Share.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs
        /// </remarks>
        public virtual async Task<Response<ShareClient>> UndeleteShareAsync(
            string deletedShareName,
            string deletedShareVersion,
            CancellationToken cancellationToken = default)
            => await UndeleteShareInternal(
                deletedShareName,
                deletedShareVersion,
                async: true,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Restores a previously deleted Share.
        /// This API is only functional is Share Soft Delete is enabled
        /// for the storage account associated with the share.
        /// </summary>
        /// <param name="deletedShareName">
        /// The name of the share to restore.
        /// </param>
        /// <param name="deletedShareVersion">
        /// The version of the share to restore.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ShareClient}"/> pointed at the restored Share.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareClient>> UndeleteShareInternal(
            string deletedShareName,
            string deletedShareVersion,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareServiceClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareServiceClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(deletedShareName)}: {deletedShareName}\n" +
                    $"{nameof(deletedShareVersion)}: {deletedShareVersion}");

                try
                {
                    ShareClient shareClient = GetShareClient(deletedShareName);

                    Response<ShareInfo> response = await FileRestClient.Share.RestoreAsync(
                        ClientDiagnostics,
                        Pipeline,
                        shareClient.Uri,
                        Version.ToVersionString(),
                        deletedShareName: deletedShareName,
                        deletedShareVersion: deletedShareVersion,
                        async: async,
                        operationName: $"{nameof(ShareServiceClient)}.{nameof(UndeleteShare)}",
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return Response.FromValue(shareClient, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(ShareServiceClient));
                }
            }
        }
        #endregion

        #region GenerateSas
        /// <summary>
        /// The <see cref="GenerateAccountSasUri(AccountSasPermissions, DateTimeOffset, AccountSasResourceTypes)"/>
        /// returns a <see cref="Uri"/> that generates a Share Account
        /// Shared Access Signature (SAS) based on the Client properties
        /// and parameters passed. The SAS is signed by the
        /// shared key credential of the client.
        ///
        /// To check if the client is able to sign a Service Sas see
        /// <see cref="CanGenerateAccountSasUri"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-account-sas">
        /// Constructing an Account SAS</see>.
        /// </summary>
        /// <param name="permissions">
        /// Required. Specifies the list of permissions to be associated with the SAS.
        /// See <see cref="AccountSasPermissions"/>.
        /// </param>
        /// <param name="expiresOn">
        /// Required. The time at which the shared access signature becomes invalid.
        /// </param>
        /// <param name="resourceTypes">
        /// Specifies the resource types associated with the shared access signature.
        /// The user is restricted to operations on the specified resources.
        /// See <see cref="AccountSasResourceTypes"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if a failure occurs.
        /// </remarks>
        public Uri GenerateAccountSasUri(
            AccountSasPermissions permissions,
            DateTimeOffset expiresOn,
            AccountSasResourceTypes resourceTypes) =>
            GenerateAccountSasUri(new AccountSasBuilder(
                permissions,
                expiresOn,
                AccountSasServices.Files,
                resourceTypes));

        /// <summary>
        /// The <see cref="GenerateAccountSasUri(AccountSasBuilder)"/>
        /// returns a <see cref="Uri"/> that generates a Share Account
        /// Shared Access Signature (SAS) based on the Client properties
        /// and builder passed. The SAS is signed by the
        /// shared key credential of the client.
        ///
        /// To check if the client is able to sign a Service Sas see
        /// <see cref="CanGenerateAccountSasUri"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-account-sas">
        /// Constructing an Account SAS</see>.
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
        public Uri GenerateAccountSasUri(AccountSasBuilder builder)
        {
            builder = builder ?? throw Errors.ArgumentNull(nameof(builder));
            if (!builder.Services.HasFlag(AccountSasServices.Files))
            {
                throw Errors.SasServiceNotMatching(
                    nameof(builder.Services),
                    nameof(builder),
                    nameof(AccountSasServices.Files));
            }
            UriBuilder sasUri = new UriBuilder(Uri);
            sasUri.Query = builder.ToSasQueryParameters(SharedKeyCredential).ToString();
            return sasUri.Uri;
        }
        #endregion
    }
}
