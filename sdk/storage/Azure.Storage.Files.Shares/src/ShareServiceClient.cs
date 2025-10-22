// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Common;
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
        /// <see cref="ShareClientConfiguration"/>.
        /// </summary>
        private readonly ShareClientConfiguration _clientConfiguration;

        /// <summary>
        /// <see cref="ShareClientConfiguration"/>.
        /// </summary>
        internal virtual ShareClientConfiguration ClientConfiguration => _clientConfiguration;

        /// <summary>
        /// ServiceRestClient.
        /// </summary>
        private readonly ServiceRestClient _serviceRestClient;

        /// <summary>
        /// ServiceRestClient.
        /// </summary>
        internal virtual ServiceRestClient ServiceRestClient => _serviceRestClient;

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
        /// Determines whether the client is able to generate a SAS.
        /// If the client is authenticated with a <see cref="StorageSharedKeyCredential"/>.
        /// </summary>
        public virtual bool CanGenerateAccountSasUri => ClientConfiguration.SharedKeyCredential != null;

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
        public ShareServiceClient(
            string connectionString,
            ShareClientOptions options)
        {
            options ??= new ShareClientOptions();
            var conn = StorageConnectionString.Parse(connectionString);
            ShareErrors.AssertNotDevelopment(conn, nameof(connectionString));
            _uri = conn.FileEndpoint;
            _accountName = conn.AccountName;
            _clientConfiguration = new ShareClientConfiguration(
                pipeline: options.Build(conn.Credentials),
                sharedKeyCredential: conn.Credentials as StorageSharedKeyCredential,
                clientDiagnostics: new ClientDiagnostics(options),
                clientOptions: options);
            _serviceRestClient = BuildServiceRestClient();
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
        public ShareServiceClient(
            Uri serviceUri,
            ShareClientOptions options = default)
            : this(
                  serviceUri,
                  (HttpPipelinePolicy)null,
                  options,
                  sharedKeyCredential: null,
                  sasCredential: null,
                  tokenCredential: null)
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
        public ShareServiceClient(
            Uri serviceUri,
            StorageSharedKeyCredential credential,
            ShareClientOptions options = default)
            : this(
                  serviceUri,
                  credential.AsPolicy(),
                  options,
                  sharedKeyCredential: credential,
                  sasCredential: null,
                  tokenCredential: null)
        {
            _accountName ??= credential?.AccountName;
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
        public ShareServiceClient(
            Uri serviceUri,
            AzureSasCredential credential,
            ShareClientOptions options = default)
            : this(
                  serviceUri,
                  credential.AsPolicy<ShareUriBuilder>(serviceUri),
                  options,
                  sharedKeyCredential: null,
                  sasCredential: credential,
                  tokenCredential: null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareDirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="directoryUri">
        /// A <see cref="Uri"/> referencing the directory that includes the
        /// name of the account, the name of the share, and the path of the
        /// directory.
        /// </param>
        /// <param name="clientConfiguration">
        /// <see cref="ShareClientConfiguration"/>
        /// </param>
        internal ShareServiceClient(
            Uri directoryUri,
            ShareClientConfiguration clientConfiguration)
        {
            _uri = directoryUri;
            _clientConfiguration = clientConfiguration;
            _serviceRestClient = BuildServiceRestClient();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareServiceClient"/>
        /// class.
        ///
        /// Note that service-level operations do not support token credential authentication.
        /// This constructor exists to allow the construction of a <see cref="ShareServiceClient"/> that can be used to derive
        /// a <see cref="ShareClient"/> that has token credential authentication.
        ///
        /// Also note that <see cref="ShareClientOptions.ShareTokenIntent"/> is currently required for token authentication.
        ///
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the file service.
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public ShareServiceClient(
            Uri serviceUri,
            TokenCredential credential,
            ShareClientOptions options = default)
            : this(
                  serviceUri: serviceUri,
                  authentication: credential.AsPolicy(
                    string.IsNullOrEmpty(options?.Audience?.ToString()) ? ShareAudience.DefaultAudience.CreateDefaultScope() : options.Audience.Value.CreateDefaultScope(),
                    options),
                  options: options ?? new ShareClientOptions(),
                  sharedKeyCredential: null,
                  sasCredential: null,
                  tokenCredential: credential)
        {
            Errors.VerifyHttpsTokenAuth(serviceUri);
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
        /// <param name="sharedKeyCredential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="sasCredential">
        /// The SAS credential used to sign requests.
        /// </param>
        /// <param name="tokenCredential">
        /// The token credential used to sign requests.
        /// </param>
        internal ShareServiceClient(
            Uri serviceUri,
            HttpPipelinePolicy authentication,
            ShareClientOptions options,
            StorageSharedKeyCredential sharedKeyCredential,
            AzureSasCredential sasCredential,
            TokenCredential tokenCredential)
        {
            Argument.AssertNotNull(serviceUri, nameof(serviceUri));
            options ??= new ShareClientOptions();
            _uri = serviceUri;
            _clientConfiguration = new ShareClientConfiguration(
                pipeline: options.Build(authentication),
                sharedKeyCredential: sharedKeyCredential,
                sasCredential: sasCredential,
                tokenCredential: tokenCredential,
                clientDiagnostics: new ClientDiagnostics(options),
                clientOptions: options)
            {
                Audience = options.Audience ?? ShareAudience.DefaultAudience,
            };
            _serviceRestClient = BuildServiceRestClient();
        }

        private ServiceRestClient BuildServiceRestClient()
            => new ServiceRestClient(
                _clientConfiguration.ClientDiagnostics,
                _clientConfiguration.Pipeline,
                _uri.AbsoluteUri,
                _clientConfiguration.ClientOptions.Version.ToVersionString());
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
            new ShareClient(Uri.AppendToPath(shareName), ClientConfiguration);

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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// and the <see cref="ListSharesResponse.NextMarker"/> if it's not
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
        /// operation returns a non-empty <see cref="ListSharesResponse.NextMarker"/>
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        internal async Task<Response<ListSharesResponse>> GetSharesInternal(
            string marker,
            ShareTraits traits,
            ShareStates states,
            string prefix,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareServiceClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareServiceClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(marker)}: {marker}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareServiceClient)}.{nameof(GetShares)}");

                try
                {
                    ResponseWithHeaders<ListSharesResponse, ServiceListSharesSegmentHeaders> response;

                    scope.Start();

                    if (async)
                    {
                        response = await ServiceRestClient.ListSharesSegmentAsync(
                            prefix: prefix,
                            marker: marker,
                            maxresults: pageSizeHint,
                            include: ShareExtensions.AsIncludeItems(traits, states),
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ServiceRestClient.ListSharesSegment(
                            prefix: prefix,
                            marker: marker,
                            maxresults: pageSizeHint,
                            include: ShareExtensions.AsIncludeItems(traits, states),
                            cancellationToken: cancellationToken);
                    }

                    ListSharesResponse listSharesResponse = response.Value;

                    if ((traits & ShareTraits.Metadata) != ShareTraits.Metadata)
                    {
                        List<ShareItemInternal> shareItemInternals = response.Value.ShareItems.Select(r => new ShareItemInternal(
                            r.Name,
                            r.Snapshot,
                            r.Deleted,
                            r.Version,
                            r.Properties,
                            metadata: null))
                            .ToList();

                        listSharesResponse = new ListSharesResponse(
                            response.Value.ServiceEndpoint,
                            response.Value.Prefix,
                            response.Value.Marker,
                            response.Value.MaxResults,
                            shareItemInternals.AsReadOnly(),
                            response.Value.NextMarker);
                    }
                    return Response.FromValue(
                        listSharesResponse,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareServiceClient));
                    scope.Dispose();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<ShareServiceProperties>> GetPropertiesInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareServiceClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareServiceClient),
                    message: $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareServiceClient)}.{nameof(GetProperties)}");

                try
                {
                    ResponseWithHeaders<ShareServiceProperties, ServiceGetPropertiesHeaders> response;

                    scope.Start();

                    if (async)
                    {
                        response = await ServiceRestClient.GetPropertiesAsync(
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ServiceRestClient.GetProperties(
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareServiceClient));
                    scope.Dispose();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-shares")]
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-shares")]
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response> SetPropertiesInternal(
            ShareServiceProperties properties,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareServiceClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareServiceClient),
                    message: $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareServiceClient)}.{nameof(SetProperties)}");

                try
                {
                    ResponseWithHeaders<ServiceSetPropertiesHeaders> response;

                    scope.Start();

                    if (async)
                    {
                        response = await ServiceRestClient.SetPropertiesAsync(
                            shareServiceProperties: properties,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = ServiceRestClient.SetProperties(
                            shareServiceProperties: properties,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareServiceClient));
                    scope.Dispose();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<ShareClient> CreateShare(
            string shareName,
            ShareCreateOptions options,
            CancellationToken cancellationToken = default)
        {
            ShareClient share = GetShareClient(shareName);

            Response<ShareInfo> response = share.CreateInternal(
                metadata: options?.Metadata,
                quotaInGB: options?.QuotaInGB,
                accessTier: options?.AccessTier,
                enabledProtocols: options?.Protocols,
                rootSquash: options?.RootSquash,
                enableSnapshotVirtualDirectoryAccess: options?.EnableSnapshotVirtualDirectoryAccess,
                enablePaidBursting: options?.EnablePaidBursting,
                paidBurstingMaxIops: options?.PaidBurstingMaxIops,
                paidBurstingMaxBandwidthMibps: options?.PaidBurstingMaxBandwidthMibps,
                provisionedMaxIops: options?.PaidBurstingMaxIops,
                provisionedMaxBandwidthMibps: options?.ProvisionedMaxBandwidthMibps,
                enableDirectoryLease: options?.EnableDirectoryLease,
                async: false,
                cancellationToken: cancellationToken,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<ShareClient>> CreateShareAsync(
            string shareName,
            ShareCreateOptions options,
            CancellationToken cancellationToken = default)
        {
            ShareClient share = GetShareClient(shareName);

            Response<ShareInfo> response = await share.CreateInternal(
                metadata: options?.Metadata,
                quotaInGB: options?.QuotaInGB,
                accessTier: options?.AccessTier,
                enabledProtocols: options?.Protocols,
                rootSquash: options?.RootSquash,
                enableSnapshotVirtualDirectoryAccess: options?.EnableSnapshotVirtualDirectoryAccess,
                enablePaidBursting: options?.EnablePaidBursting,
                paidBurstingMaxIops: options?.PaidBurstingMaxIops,
                paidBurstingMaxBandwidthMibps: options?.PaidBurstingMaxBandwidthMibps,
                provisionedMaxIops: options?.PaidBurstingMaxIops,
                provisionedMaxBandwidthMibps: options?.ProvisionedMaxBandwidthMibps,
                enableDirectoryLease: options?.EnableDirectoryLease,
                async: true,
                cancellationToken: cancellationToken,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
                enableSnapshotVirtualDirectoryAccess: default,
                enablePaidBursting: default,
                paidBurstingMaxIops: default,
                paidBurstingMaxBandwidthMibps: default,
                provisionedMaxIops: default,
                provisionedMaxBandwidthMibps: default,
                enableDirectoryLease: default,
                async: false,
                cancellationToken: cancellationToken,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
                enableSnapshotVirtualDirectoryAccess: default,
                enablePaidBursting: default,
                paidBurstingMaxIops: default,
                paidBurstingMaxBandwidthMibps: default,
                provisionedMaxIops: default,
                provisionedMaxBandwidthMibps: default,
                enableDirectoryLease: default,
                async: true,
                cancellationToken: cancellationToken,
                operationName: $"{nameof(ShareServiceClient)}.{nameof(CreateShare)}")
                .ConfigureAwait(false);

            return Response.FromValue(share, response.GetRawResponse());
        }
        #endregion CreateShare

        #region DeleteShare
        /// <summary>
        /// Marks the specified share or share snapshot for deletion.
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
        /// A <see cref="Response"/> on successfully marking for deletion.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// A <see cref="Response"/> on successfully marking for deletion.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// A <see cref="Response"/> on successfully marking for deletion.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// A <see cref="Response"/> on successfully marking for deletion.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<ShareClient>> UndeleteShareInternal(
            string deletedShareName,
            string deletedShareVersion,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareServiceClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareServiceClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(deletedShareName)}: {deletedShareName}\n" +
                    $"{nameof(deletedShareVersion)}: {deletedShareVersion}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareServiceClient)}.{nameof(UndeleteShare)}");

                try
                {
                    scope.Start();
                    ShareClient shareClient = GetShareClient(deletedShareName);

                    ResponseWithHeaders<ShareRestoreHeaders> response;

                    if (async)
                    {
                        response = await shareClient.ShareRestClient.RestoreAsync(
                            deletedShareName: deletedShareName,
                            deletedShareVersion: deletedShareVersion,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = shareClient.ShareRestClient.Restore(
                            deletedShareName: deletedShareName,
                            deletedShareVersion: deletedShareVersion,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(shareClient, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareServiceClient));
                    scope.Dispose();
                }
            }
        }
        #endregion

        #region GetUserDelegationKey
        /// <summary>
        /// The <see cref="GetUserDelegationKey(DateTimeOffset, ShareGetUserDelegationKeyOptions, CancellationToken)"/> operation retrieves a
        /// key that can be used to delegate Active Directory authorization to
        /// shared access signatures created with <see cref="ShareSasBuilder"/>.
        /// </summary>
        /// <param name="expiresOn">
        /// Expiration of the key's validity.  The time should be specified
        /// in UTC.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobServiceStatistics}"/> describing
        /// the service replication statistics.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-shares")]
        public virtual Response<UserDelegationKey> GetUserDelegationKey(
            DateTimeOffset expiresOn,
            ShareGetUserDelegationKeyOptions options = default,
            CancellationToken cancellationToken = default) =>
            GetUserDelegationKeyInternal(
                options?.StartsOn,
                expiresOn,
                options?.DelegatedUserTenantId,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetUserDelegationKeyAsync(DateTimeOffset, ShareGetUserDelegationKeyOptions, CancellationToken)"/> operation retrieves a
        /// key that can be used to delegate Active Directory authorization to
        /// shared access signatures created with <see cref="ShareSasBuilder"/>.
        /// </summary>
        /// <param name="expiresOn">
        /// Expiration of the key's validity.  The time should be specified
        /// in UTC.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobServiceStatistics}"/> describing
        /// the service replication statistics.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-shares")]
        public virtual async Task<Response<UserDelegationKey>> GetUserDelegationKeyAsync(
            DateTimeOffset expiresOn,
            ShareGetUserDelegationKeyOptions options = default,
            CancellationToken cancellationToken = default) =>
            await GetUserDelegationKeyInternal(
                options?.StartsOn,
                expiresOn,
                options?.DelegatedUserTenantId,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetUserDelegationKey(DateTimeOffset?, DateTimeOffset, CancellationToken)"/> operation retrieves a
        /// key that can be used to delegate Active Directory authorization to
        /// shared access signatures created with <see cref="ShareSasBuilder"/>.
        /// </summary>
        /// <param name="startsOn">
        /// Start time for the key's validity, with null indicating an
        /// immediate start.  The time should be specified in UTC.
        ///
        /// Note: If you set the start time to the current time, failures
        /// might occur intermittently for the first few minutes. This is due to different
        /// machines having slightly different current times (known as clock skew).
        /// </param>
        /// <param name="expiresOn">
        /// Expiration of the key's validity.  The time should be specified
        /// in UTC.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobServiceStatistics}"/> describing
        /// the service replication statistics.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-shares")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<UserDelegationKey> GetUserDelegationKey(
            DateTimeOffset? startsOn,
            DateTimeOffset expiresOn,
            CancellationToken cancellationToken = default) =>
            GetUserDelegationKeyInternal(
                startsOn,
                expiresOn,
                default,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetUserDelegationKeyAsync(DateTimeOffset?, DateTimeOffset, CancellationToken)"/> operation retrieves a
        /// key that can be used to delegate Active Directory authorization to
        /// shared access signatures created with <see cref="ShareSasBuilder"/>.
        /// </summary>
        /// <param name="startsOn">
        /// Start time for the key's validity, with null indicating an
        /// immediate start.  The time should be specified in UTC.
        ///
        /// Note: If you set the start time to the current time, failures
        /// might occur intermittently for the first few minutes. This is due to different
        /// machines having slightly different current times (known as clock skew).
        /// </param>
        /// <param name="expiresOn">
        /// Expiration of the key's validity.  The time should be specified
        /// in UTC.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobServiceStatistics}"/> describing
        /// the service replication statistics.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-shares")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<UserDelegationKey>> GetUserDelegationKeyAsync(
            DateTimeOffset? startsOn,
            DateTimeOffset expiresOn,
            CancellationToken cancellationToken = default) =>
            await GetUserDelegationKeyInternal(
                startsOn,
                expiresOn,
                default,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetUserDelegationKeyInternal"/> operation retrieves a
        /// key that can be used to delegate Active Directory authorization to
        /// shared access signatures created with <see cref="ShareSasBuilder"/>.
        /// </summary>
        /// <param name="startsOn">
        /// Start time for the key's validity, with null indicating an
        /// immediate start.  The time should be specified in UTC.
        ///
        /// Note: If you set the start time to the current time, failures
        /// might occur intermittently for the first few minutes. This is due to different
        /// machines having slightly different current times (known as clock skew).
        /// </param>
        /// <param name="expiresOn">
        /// Expiration of the key's validity.  The time should be specified
        /// in UTC.
        /// </param>
        /// <param name="delegatedUserTenantId">
        /// The delegated user tenant id in Azure AD.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <param name="async"/>
        /// <returns>
        /// A <see cref="Response{BlobServiceStatistics}"/> describing
        /// the service replication statistics.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<UserDelegationKey>> GetUserDelegationKeyInternal(
            DateTimeOffset? startsOn,
            DateTimeOffset expiresOn,
            string delegatedUserTenantId,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareServiceClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(GetUserDelegationKeyInternal),
                    message: $"{nameof(startsOn)}: {startsOn}\n" +
                             $"{nameof(expiresOn)}: {expiresOn}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareServiceClient)}.{nameof(GetUserDelegationKey)}");

                try
                {
                    scope.Start();

                    if (startsOn.HasValue && startsOn.Value.Offset != TimeSpan.Zero)
                    {
                        throw Errors.InvalidDateTimeUtc(nameof(startsOn));
                    }

                    if (expiresOn.Offset != TimeSpan.Zero)
                    {
                        throw Errors.InvalidDateTimeUtc(nameof(expiresOn));
                    }

                    KeyInfo keyInfo = new KeyInfo(expiresOn.ToString(Constants.Iso8601Format, CultureInfo.InvariantCulture))
                    {
                        Start = startsOn?.ToString(Constants.Iso8601Format, CultureInfo.InvariantCulture),
                        DelegatedUserTid = delegatedUserTenantId
                    };

                    ResponseWithHeaders<UserDelegationKey, ServiceGetUserDelegationKeyHeaders> response;

                    if (async)
                    {
                        response = await ServiceRestClient.GetUserDelegationKeyAsync(
                            keyInfo: keyInfo,
                            cancellationToken: cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        response = ServiceRestClient.GetUserDelegationKey(
                            keyInfo: keyInfo,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(GetUserDelegationKeyInternal));
                    scope.Dispose();
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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-shares")]
        public Uri GenerateAccountSasUri(
            AccountSasPermissions permissions,
            DateTimeOffset expiresOn,
            AccountSasResourceTypes resourceTypes) =>
            GenerateAccountSasUri(permissions, expiresOn, resourceTypes, out _);

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
        public Uri GenerateAccountSasUri(
            AccountSasPermissions permissions,
            DateTimeOffset expiresOn,
            AccountSasResourceTypes resourceTypes,
            out string stringToSign) =>
            GenerateAccountSasUri(new AccountSasBuilder(
                permissions,
                expiresOn,
                AccountSasServices.Files,
                resourceTypes),
                out stringToSign);

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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-shares")]
        public Uri GenerateAccountSasUri(AccountSasBuilder builder)
            => GenerateAccountSasUri(builder, out _);

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
        public Uri GenerateAccountSasUri(AccountSasBuilder builder, out string stringToSign)
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
            sasUri.Query = builder.ToSasQueryParameters(ClientConfiguration.SharedKeyCredential, out stringToSign).ToString();
            return sasUri.Uri;
        }
        #endregion
    }
}
