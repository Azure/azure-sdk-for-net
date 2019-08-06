// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Common;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// The <see cref="BlobServiceClient"/> allows you to manipulate Azure
    /// Storage service resources and containers. The storage account provides
    /// the top-level namespace for the Blob service.
    /// </summary>
    public class BlobServiceClient
    {
        /// <summary>
        /// Gets the blob service's primary <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _uri;

        /// <summary>
        /// Gets the blob service's primary <see cref="Uri"/> endpoint.
        /// </summary>
        public virtual Uri Uri => this._uri;

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send
        /// every request.
        /// </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send
        /// every request.
        /// </summary>
        protected virtual HttpPipeline Pipeline => this._pipeline;

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobServiceClient"/>
        /// class for mocking.
        /// </summary>
        protected BlobServiceClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information, <see href="https://docs.microsoft.com/en-us/azure/storage/common/storage-configure-connection-string"/>.
        /// </param>
        public BlobServiceClient(string connectionString)
            : this(connectionString, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information, <see href="https://docs.microsoft.com/en-us/azure/storage/common/storage-configure-connection-string"/>.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobServiceClient(string connectionString, BlobClientOptions options)
        {
            var conn = StorageConnectionString.Parse(connectionString);
            this._uri = conn.BlobEndpoint;
            this._pipeline = (options ?? new BlobClientOptions()).Build(conn.Credentials);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the blob service.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobServiceClient(Uri serviceUri, BlobClientOptions options = default)
            : this(serviceUri, (HttpPipelinePolicy)null, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the blob service.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobServiceClient(Uri serviceUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            : this(serviceUri, credential.AsPolicy(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the blob service.
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobServiceClient(Uri serviceUri, TokenCredential credential, BlobClientOptions options = default)
            : this(serviceUri, credential.AsPolicy(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the blob service.
        /// </param>
        /// <param name="authentication">
        /// An optional authentication policy used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        internal BlobServiceClient(Uri serviceUri, HttpPipelinePolicy authentication, BlobClientOptions options)
        {
            this._uri = serviceUri;
            this._pipeline = (options ?? new BlobClientOptions()).Build(authentication);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the blob service.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        internal BlobServiceClient(Uri serviceUri, HttpPipeline pipeline)
        {
            this._uri = serviceUri;
            this._pipeline = pipeline;
        }
        #endregion ctors

        /// <summary>
        /// Create a new <see cref="BlobContainerClient"/> object by appending
        /// <paramref name="containerName"/> to the end of <see cref="Uri"/>.
        /// The new <see cref="BlobContainerClient"/> uses the same request
        /// policy pipeline as the <see cref="BlobServiceClient"/>.
        /// </summary>
        /// <param name="containerName">
        /// The name of the container to reference.
        /// </param>
        /// <returns>
        /// A <see cref="BlobContainerClient"/> for the desired container.
        /// </returns>
        public virtual BlobContainerClient GetBlobContainerClient(string containerName) =>
            new BlobContainerClient(this.Uri.AppendToPath(containerName), this.Pipeline);

        #region GetContainers
        /// <summary>
        /// The <see cref="GetContainers"/> operation returns an async
        /// sequence of containers in the storage account.  Enumerating the
        /// containers may make multiple requests to the service while fetching
        /// all the values.  Containers are ordered lexicographically by name.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/list-containers2"/>.
        /// </summary>
        /// <param name="options">
        /// Specifies options for listing, filtering, and shaping the
        /// containers.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of <see cref="Response{ContainerItem}"/>
        /// describing the containers in the storage account.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual IEnumerable<Response<ContainerItem>> GetContainers(
            GetContainersOptions? options = default,
            CancellationToken cancellationToken = default) =>
            new GetContainersAsyncCollection(this, options, cancellationToken);

        /// <summary>
        /// The <see cref="GetContainersAsync"/> operation returns an async
        /// sequence of containers in the storage account.  Enumerating the
        /// containers may make multiple requests to the service while fetching
        /// all the values.  Containers are ordered lexicographically by name.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/list-containers2"/>.
        /// </summary>
        /// <param name="options">
        /// Specifies options for listing, filtering, and shaping the
        /// containers.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="AsyncCollection{ContainerItem}"/> describing the
        /// containers in the storage account.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual AsyncCollection<ContainerItem> GetContainersAsync(
            GetContainersOptions? options = default,
            CancellationToken cancellationToken = default) =>
            new GetContainersAsyncCollection(this, options, cancellationToken);

        /// <summary>
        /// The <see cref="GetContainersInternal"/> operation returns a
        /// single segment of containers in the storage account, starting
        /// from the specified <paramref name="continuationToken"/>.  Use an empty
        /// <paramref name="continuationToken"/> to start enumeration from the beginning
        /// and the <see cref="ContainersSegment.NextMarker"/> if it's not
        /// empty to make subsequent calls to <see cref="GetContainersAsync"/>
        /// to continue enumerating the containers segment by segment.
        /// Containers are ordered lexicographically by name.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/list-containers2"/>.
        /// </summary>
        /// <param name="continuationToken">
        /// An optional string value that identifies the segment of the list
        /// of containers to be returned with the next listing operation.  The
        /// operation returns a non-empty <see cref="ContainersSegment.NextMarker"/>
        /// if the listing operation did not return all containers remaining
        /// to be listed with the current segment.  The NextMarker value can
        /// be used as the value for the <paramref name="continuationToken"/> parameter
        /// in a subsequent call to request the next segment of list items.
        /// </param>
        /// <param name="options">
        /// Specifies options for listing, filtering, and shaping the
        /// containers.
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
        /// A <see cref="Response{ContainersSegment}"/> describing a
        /// segment of the containers in the storage account.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<Response<ContainersSegment>> GetContainersInternal(
            string continuationToken,
            GetContainersOptions? options,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobServiceClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(BlobServiceClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(continuationToken)}: {continuationToken}\n" +
                    $"{nameof(options)}: {options}");
                try
                {
                    return await BlobRestClient.Service.ListContainersSegmentAsync(
                        this.Pipeline,
                        this.Uri,
                        marker: continuationToken,
                        prefix: options?.Prefix,
                        maxresults: pageSizeHint,
                        include: options?.AsIncludeType(),
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
                    this.Pipeline.LogMethodExit(nameof(BlobServiceClient));
                }
            }
        }
        #endregion GetContainers

        #region GetAccountInfo
        /// <summary>
        /// The <see cref="GetAccountInfo"/> operation returns the sku
        /// name and account kind for the specified account.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-account-information" />.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{AccountInfo}"/> describing the account.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<AccountInfo> GetAccountInfo(
            CancellationToken cancellationToken = default) =>
            this.GetAccountInfoInternal(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetAccountInfoAsync"/> operation returns the sku
        /// name and account kind for the specified account.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-account-information" />.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{AccountInfo}"/> describing the account.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<AccountInfo>> GetAccountInfoAsync(
            CancellationToken cancellationToken = default) =>
            await this.GetAccountInfoInternal(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetAccountInfoInternal"/> operation returns the sku
        /// name and account kind for the specified account.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-account-information" />.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{AccountInfo}"/> describing the account.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<AccountInfo>> GetAccountInfoInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobServiceClient)))
            {
                this.Pipeline.LogMethodEnter(nameof(BlobServiceClient), message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await BlobRestClient.Service.GetAccountInfoAsync(
                        this.Pipeline,
                        this.Uri,
                        async: async,
                        operationName: Constants.Blob.Service.GetAccountInfoOperationName,
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
                    this.Pipeline.LogMethodExit(nameof(BlobServiceClient));
                }
            }
        }
        #endregion GetAccountInfo

        #region GetProperties
        /// <summary>
        /// The <see cref="GetProperties"/> operation gets the properties
        /// of a storage account’s blob service, including properties for
        /// Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-blob-service-properties" />.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobServiceProperties}"/> describing
        /// the service properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobServiceProperties> GetProperties(
            CancellationToken cancellationToken = default) =>
            this.GetPropertiesInternal(
                false, //async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetPropertiesAsync"/> operation gets the properties
        /// of a storage account’s blob service, including properties for
        /// Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-blob-service-properties" />.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobServiceProperties}"/> describing
        /// the service properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobServiceProperties>> GetPropertiesAsync(
            CancellationToken cancellationToken = default) =>
            await this.GetPropertiesInternal(
                true, //async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetPropertiesInternal"/> operation gets the properties
        /// of a storage account’s blob service, including properties for
        /// Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-blob-service-properties" />.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobServiceProperties}"/> describing
        /// the service properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobServiceProperties>> GetPropertiesInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobServiceClient)))
            {
                this.Pipeline.LogMethodEnter(nameof(BlobServiceClient), message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await BlobRestClient.Service.GetPropertiesAsync(
                        this.Pipeline,
                        this.Uri,
                        async: async,
                        operationName: Constants.Blob.Service.GetPropertiesOperationName,
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
                    this.Pipeline.LogMethodExit(nameof(BlobServiceClient));
                }
            }
        }
        #endregion GetProperties

        #region SetProperties
        /// <summary>
        /// The <see cref="SetProperties"/> operation sets properties for
        /// a storage account’s Blob service endpoint, including properties
        /// for Storage Analytics, CORS (Cross-Origin Resource Sharing) rules
        /// and soft delete settings.  You can also use this operation to set
        /// the default request version for all incoming requests to the Blob
        /// service that do not have a version specified.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-blob-service-properties"/>.
        /// </summary>
        /// <param name="properties">The blob service properties.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing
        /// the service properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response SetProperties(
            BlobServiceProperties properties,
            CancellationToken cancellationToken = default) =>
            this.SetPropertiesInternal(
                properties,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="SetPropertiesAsync"/> operation sets properties for
        /// a storage account’s Blob service endpoint, including properties
        /// for Storage Analytics, CORS (Cross-Origin Resource Sharing) rules
        /// and soft delete settings.  You can also use this operation to set
        /// the default request version for all incoming requests to the Blob
        /// service that do not have a version specified.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-blob-service-properties"/>.
        /// </summary>
        /// <param name="properties">The blob service properties.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing
        /// the service properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> SetPropertiesAsync(
            BlobServiceProperties properties,
            CancellationToken cancellationToken = default) =>
            await this.SetPropertiesInternal(
                properties,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetPropertiesInternal"/> operation sets properties for
        /// a storage account’s Blob service endpoint, including properties
        /// for Storage Analytics, CORS (Cross-Origin Resource Sharing) rules
        /// and soft delete settings.  You can also use this operation to set
        /// the default request version for all incoming requests to the Blob
        /// service that do not have a version specified.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-blob-service-properties"/>.
        /// </summary>
        /// <param name="properties">The blob service properties.</param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing
        /// the service properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response> SetPropertiesInternal(
            BlobServiceProperties properties,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobServiceClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(BlobServiceClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(properties)}: {properties}");
                try
                {
                    return await BlobRestClient.Service.SetPropertiesAsync(
                        this.Pipeline,
                        this.Uri,
                        properties,
                        async: async,
                        operationName: Constants.Blob.Service.SetPropertiesOperationName,
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
                    this.Pipeline.LogMethodExit(nameof(BlobServiceClient));
                }
            }
        }
        #endregion SetProperties

        #region GetStatistics
        /// <summary>
        /// The <see cref="GetStatistics"/> operation retrieves
        /// statistics related to replication for the Blob service.  It is
        /// only available on the secondary location endpoint when read-access
        /// geo-redundant replication (<see cref="Models.SkuName.StandardRAGRS"/>)
        /// is enabled for the storage account.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-blob-service-stats"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobServiceStatistics}"/> describing
        /// the service replication statistics.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobServiceStatistics> GetStatistics(
            CancellationToken cancellationToken = default) =>
            this.GetStatisticsInternal(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetStatisticsAsync"/> operation retrieves
        /// statistics related to replication for the Blob service.  It is
        /// only available on the secondary location endpoint when read-access
        /// geo-redundant replication (<see cref="Models.SkuName.StandardRAGRS"/>)
        /// is enabled for the storage account.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-blob-service-stats"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobServiceStatistics}"/> describing
        /// the service replication statistics.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobServiceStatistics>> GetStatisticsAsync(
            CancellationToken cancellationToken = default) =>
            await this.GetStatisticsInternal(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetStatisticsInternal"/> operation retrieves
        /// statistics related to replication for the Blob service.  It is
        /// only available on the secondary location endpoint when read-access
        /// geo-redundant replication (<see cref="Models.SkuName.StandardRAGRS"/>)
        /// is enabled for the storage account.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-blob-service-stats"/>.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<BlobServiceStatistics>> GetStatisticsInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobServiceClient)))
            {
                this.Pipeline.LogMethodEnter(nameof(BlobServiceClient), message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await BlobRestClient.Service.GetStatisticsAsync(
                        this.Pipeline,
                        this.Uri,
                        async: async,
                        operationName: Constants.Blob.Service.GetStatisticsOperationName,
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
                    this.Pipeline.LogMethodExit(nameof(BlobServiceClient));
                }
            }
        }
        #endregion GetStatistics

        #region GetUserDelegationKey
        /// <summary>
        /// The <see cref="GetUserDelegationKey"/> operation retrieves a
        /// key that can be used to delegate Active Directory authorization to
        /// shared access signatures created with <see cref="Sas.BlobSasBuilder"/>.
        /// </summary>
        /// <param name="start">
        /// Start time for the key's validity, with null indicating an
        /// immediate start.  The time should be specified in UTC.
        /// </param>
        /// <param name="expiry">
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<UserDelegationKey> GetUserDelegationKey(
            DateTimeOffset? start,
            DateTimeOffset expiry,
            CancellationToken cancellationToken = default) =>
            this.GetUserDelegationKeyInternal(
                start,
                expiry,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetUserDelegationKeyAsync"/> operation retrieves a
        /// key that can be used to delegate Active Directory authorization to
        /// shared access signatures created with <see cref="Sas.BlobSasBuilder"/>.
        /// </summary>
        /// <param name="start">
        /// Start time for the key's validity, with null indicating an
        /// immediate start.  The time should be specified in UTC.
        /// </param>
        /// <param name="expiry">
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<UserDelegationKey>> GetUserDelegationKeyAsync(
            DateTimeOffset? start,
            DateTimeOffset expiry,
            CancellationToken cancellationToken = default) =>
            await this.GetUserDelegationKeyInternal(
                start,
                expiry,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetUserDelegationKeyInternal"/> operation retrieves a
        /// key that can be used to delegate Active Directory authorization to
        /// shared access signatures created with <see cref="Sas.BlobSasBuilder"/>.
        /// </summary>
        /// <param name="start">
        /// Start time for the key's validity, with null indicating an
        /// immediate start.  The time should be specified in UTC.
        /// </param>
        /// <param name="expiry">
        /// Expiration of the key's validity.  The time should be specified
        /// in UTC.
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<UserDelegationKey>> GetUserDelegationKeyInternal(
            DateTimeOffset? start,
            DateTimeOffset expiry,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(BlobServiceClient)))
            {
                this.Pipeline.LogMethodEnter(nameof(BlobServiceClient), message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    if (start.HasValue && start.Value.Offset != TimeSpan.Zero)
                    {
                        throw new ArgumentException($"{nameof(start)} must be UTC");
                    }

                    if (expiry.Offset != TimeSpan.Zero)
                    {
                        throw new ArgumentException($"{nameof(expiry)} must be UTC");
                    }

                    var keyInfo = new KeyInfo { Start = start, Expiry = expiry };

                    return await BlobRestClient.Service.GetUserDelegationKeyAsync(
                        this.Pipeline,
                        this.Uri,
                        keyInfo: keyInfo,
                        async: async,
                        operationName: Constants.Blob.Service.GetUserDelegationKeyOperationName,
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
                    this.Pipeline.LogMethodExit(nameof(BlobServiceClient));
                }
            }
        }
        #endregion GetUserDelegationKey

        #region CreateBlobContainer
        /// <summary>
        /// The <see cref="CreateBlobContainer"/> operation creates a new
        /// container under the specified account. If the container with the
        /// same name already exists, the operation fails.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/create-container"/>.
        /// </summary>
        /// <param name="containerName">
        /// The name of the container to create.
        /// </param>
        /// <param name="publicAccessType">
        /// Optionally specifies whether data in the container may be accessed
        /// publicly and the level of access. <see cref="PublicAccessType.Container"/>
        /// specifies full public read access for container and blob data.
        /// Clients can enumerate blobs within the container via anonymous
        /// request, but cannot enumerate containers within the storage
        /// account.  <see cref="PublicAccessType.Blob"/> specifies public
        /// read access for blobs.  Blob data within this container can be
        /// read via anonymous request, but container data is not available.
        /// Clients cannot enumerate blobs within the container via anonymous
        /// request.  If this parameter is null, container data is private to
        /// the account owner.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this container.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerClient}"/> referencing the
        /// newly created container.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<BlobContainerClient> CreateBlobContainer(
            string containerName,
            PublicAccessType? publicAccessType = default,
            Metadata metadata = default,
            CancellationToken cancellationToken = default)
        {
            var container = this.GetBlobContainerClient(containerName);
            var response = container.Create(publicAccessType, metadata, cancellationToken);
            return new Response<BlobContainerClient>(response.GetRawResponse(), container);
        }

        /// <summary>
        /// The <see cref="CreateBlobContainerAsync"/> operation creates a new
        /// container under the specified account. If the container with the
        /// same name already exists, the operation fails.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/create-container"/>.
        /// </summary>
        /// <param name="containerName">
        /// The name of the container to create.
        /// </param>
        /// <param name="publicAccessType">
        /// Optionally specifies whether data in the container may be accessed
        /// publicly and the level of access. <see cref="PublicAccessType.Container"/>
        /// specifies full public read access for container and blob data.
        /// Clients can enumerate blobs within the container via anonymous
        /// request, but cannot enumerate containers within the storage
        /// account.  <see cref="PublicAccessType.Blob"/> specifies public
        /// read access for blobs.  Blob data within this container can be
        /// read via anonymous request, but container data is not available.
        /// Clients cannot enumerate blobs within the container via anonymous
        /// request.  If this parameter is null, container data is private to
        /// the account owner.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this container.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerClient}"/> referencing the
        /// newly created container.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<BlobContainerClient>> CreateBlobContainerAsync(
            string containerName,
            PublicAccessType? publicAccessType = default,
            Metadata metadata = default,
            CancellationToken cancellationToken = default)
        {
            var container = this.GetBlobContainerClient(containerName);
            var response = await container.CreateAsync(publicAccessType, metadata, cancellationToken).ConfigureAwait(false);
            return new Response<BlobContainerClient>(response.GetRawResponse(), container);
        }
        #endregion CreateBlobContainer

        #region DeleteBlobContainer
        /// <summary>
        /// The <see cref="DeleteBlobContainer"/> operation marks the
        /// specified container for deletion. The container and any blobs
        /// contained within it are later deleted during garbage collection.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-container" />.
        /// </summary>
        /// <param name="containerName">
        /// The name of the container to delete.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="ContainerAccessConditions"/> to add
        /// conditions on the deletion of this container.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> if successful.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response DeleteBlobContainer(
            string containerName,
            ContainerAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default) =>
            this.GetBlobContainerClient(containerName)
                .Delete(
                    accessConditions,
                    cancellationToken);

        /// <summary>
        /// The <see cref="DeleteBlobContainerAsync"/> operation marks the
        /// specified container for deletion. The container and any blobs
        /// contained within it are later deleted during garbage collection.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-container" />.
        /// </summary>
        /// <param name="containerName">
        /// The name of the container to delete.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="ContainerAccessConditions"/> to add
        /// conditions on the deletion of this container.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> if successful.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteBlobContainerAsync(
            string containerName,
            ContainerAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default) =>
            await this
                .GetBlobContainerClient(containerName)
                .DeleteAsync(
                    accessConditions,
                    cancellationToken)
                    .ConfigureAwait(false);
        #endregion DeleteBlobContainer
    }
}
