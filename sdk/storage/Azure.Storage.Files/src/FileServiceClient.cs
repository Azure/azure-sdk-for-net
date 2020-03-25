// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Common;
using Azure.Storage.Files.Models;

namespace Azure.Storage.Files
{
    /// <summary>
    /// The <see cref="FileServiceClient"/> allows you to manipulate Azure
    /// Storage service resources and shares. The storage account provides
    /// the top-level namespace for the File service.
    /// </summary>
    public class FileServiceClient
    {
        /// <summary>
        /// The file service's primary <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _uri;

        /// <summary>
        /// Gets the file service's primary <see cref="Uri"/> endpoint.
        /// </summary>
        public virtual Uri Uri => this._uri;

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send
        /// every request.
        /// </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary>
        /// Gets tghe <see cref="HttpPipeline"/> transport pipeline used to
        /// send every request.
        /// </summary>
        protected virtual HttpPipeline Pipeline => this._pipeline;

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="FileServiceClient"/>
        /// class for mocking.
        /// </summary>
        protected FileServiceClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information, <see href="https://docs.microsoft.com/en-us/azure/storage/common/storage-configure-connection-string"/>.
        /// </param>
        public FileServiceClient(string connectionString)
            : this(connectionString, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileServiceClient"/>
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
        public FileServiceClient(string connectionString, FileClientOptions options)
        {
            var conn = StorageConnectionString.Parse(connectionString);
            this._uri = conn.FileEndpoint;
            this._pipeline = (options ?? new FileClientOptions()).Build(conn.Credentials);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileServiceClient"/>
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
        public FileServiceClient(Uri serviceUri, FileClientOptions options = default)
            : this(serviceUri, (HttpPipelinePolicy)null, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileServiceClient"/>
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
        public FileServiceClient(Uri serviceUri, StorageSharedKeyCredential credential, FileClientOptions options = default)
            : this(serviceUri, credential.AsPolicy(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileServiceClient"/>
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
        internal FileServiceClient(Uri serviceUri, HttpPipelinePolicy authentication, FileClientOptions options)
        {
            this._uri = serviceUri;
            this._pipeline = (options ?? new FileClientOptions()).Build(authentication);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the file service.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        internal FileServiceClient(Uri serviceUri, HttpPipeline pipeline)
        {
            this._uri = serviceUri;
            this._pipeline = pipeline;
        }
        #endregion ctors

        /// <summary>
        /// Create a new <see cref="ShareClient"/> object by appending
        /// <paramref name="shareName"/> to the end of <see cref="Uri"/>.
        /// The new <see cref="ShareClient"/> uses the same request
        /// policy pipeline as the <see cref="FileServiceClient"/>.
        /// </summary>
        /// <param name="shareName">
        /// The name of the share to reference.
        /// </param>
        /// <returns>
        /// A <see cref="ShareClient"/> for the desired share.
        /// </returns>
        public virtual ShareClient GetShareClient(string shareName) => new ShareClient(this.Uri.AppendToPath(shareName), this.Pipeline);

        #region GetShares
        /// <summary>
        /// The <see cref="GetShares"/> operation returns an async sequence
        /// of the shares in the storage account.  Enumerating the shares may
        /// make multiple requests to the service while fetching all the
        /// values.
        ///
        /// For more information, <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/list-shares"/>.
        /// </summary>
        /// <param name="options">
        /// Specifies options for listing, filtering, and shaping the
        /// shares.
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual IEnumerable<Response<ShareItem>> GetShares(
            GetSharesOptions? options = default,
            CancellationToken cancellationToken = default) =>
            new GetSharesAsyncCollection(this, options, cancellationToken);

        /// <summary>
        /// The <see cref="GetSharesAsync"/> operation returns an async collection
        /// of the shares in the storage account.  Enumerating the shares may
        /// make multiple requests to the service while fetching all the
        /// values.
        ///
        /// For more information, <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/list-shares"/>.
        /// </summary>
        /// <param name="options">
        /// Specifies options for listing, filtering, and shaping the
        /// shares.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="AsyncCollection{ShareItem}"/> describing the shares in
        /// the storage account.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual AsyncCollection<ShareItem> GetSharesAsync(
            GetSharesOptions? options = default,
            CancellationToken cancellationToken = default) =>
            new GetSharesAsyncCollection(this, options, cancellationToken);

        /// <summary>
        /// The <see cref="GetSharesInternal"/> operation returns a
        /// single segment of shares in the storage account, starting
        /// from the specified <paramref name="marker"/>.  Use an empty
        /// <paramref name="marker"/> to start enumeration from the beginning
        /// and the <see cref="SharesSegment.NextMarker"/> if it's not
        /// empty to make subsequent calls to <see cref="GetSharesAsync"/>
        /// to continue enumerating the shares segment by segment.
        ///
        /// For more information, <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/list-shares"/>.
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
        /// <param name="options">
        /// Specifies options for listing, filtering, and shaping the
        /// shares.
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<Response<SharesSegment>> GetSharesInternal(
            string marker,
            GetSharesOptions? options,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(FileServiceClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(FileServiceClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(marker)}: {marker}\n" +
                    $"{nameof(options)}: {options}");
                try
                {
                    return await FileRestClient.Service.ListSharesSegmentAsync(
                        this.Pipeline,
                        this.Uri,
                        marker: marker,
                        prefix: options?.Prefix,
                        maxresults: pageSizeHint,
                        include: options?.AsIncludeItems(),
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
                    this.Pipeline.LogMethodExit(nameof(FileServiceClient));
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
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-file-service-properties" />.
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<FileServiceProperties> GetProperties(
            CancellationToken cancellationToken = default) =>
            this.GetPropertiesInternal(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetPropertiesAsync"/> operation gets the properties
        /// of a storage account’s file service, including properties for
        /// Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-file-service-properties" />.
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<FileServiceProperties>> GetPropertiesAsync(
            CancellationToken cancellationToken = default) =>
            await this.GetPropertiesInternal(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetPropertiesInternal"/> operation gets the properties
        /// of a storage account’s file service, including properties for
        /// Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-file-service-properties" />.
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<FileServiceProperties>> GetPropertiesInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(FileServiceClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(FileServiceClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await FileRestClient.Service.GetPropertiesAsync(
                        this.Pipeline,
                        this.Uri,
                        async: async,
                        operationName: Constants.File.Service.GetPropertiesOperationName,
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
                    this.Pipeline.LogMethodExit(nameof(FileServiceClient));
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
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-file-service-properties"/>.
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response SetProperties(
            FileServiceProperties properties,
            CancellationToken cancellationToken = default) =>
            this.SetPropertiesInternal(
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
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-file-service-properties"/>.
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> SetPropertiesAsync(
            FileServiceProperties properties,
            CancellationToken cancellationToken = default) =>
            await this.SetPropertiesInternal(
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
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-file-service-properties"/>.
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response> SetPropertiesInternal(
            FileServiceProperties properties,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(FileServiceClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(FileServiceClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await FileRestClient.Service.SetPropertiesAsync(
                        this.Pipeline,
                        this.Uri,
                        properties: properties,
                        async: async,
                        operationName: Constants.File.Service.SetPropertiesOperationName,
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
                    this.Pipeline.LogMethodExit(nameof(FileServiceClient));
                }
            }
        }
        #endregion SetProperties

        #region CreateShare
        /// <summary>
        /// The <see cref="CreateShare"/> operation creates a new share
        /// under the specified account. If a share with the same name
        /// already exists, the operation fails.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/create-share"/>.
        /// </summary>
        /// <param name="shareName">
        /// The name of the share to create.
        /// </param>
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
        /// A <see cref="Response{ShareClient}"/> referencing the newly
        /// created share.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<ShareClient> CreateShare(
            string shareName,
            IDictionary<string, string> metadata = default,
            int? quotaInBytes = default,
            CancellationToken cancellationToken = default)
        {
            var share = this.GetShareClient(shareName);
            var response = share.Create(metadata, quotaInBytes, cancellationToken);
            return new Response<ShareClient>(response.GetRawResponse(), share);
        }

        /// <summary>
        /// The <see cref="CreateShareAsync"/> operation creates a new share
        /// under the specified account. If a share with the same name
        /// already exists, the operation fails.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/create-share"/>.
        /// </summary>
        /// <param name="shareName">
        /// The name of the share to create.
        /// </param>
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
        /// A <see cref="Response{ShareClient}"/> referencing the newly
        /// created share.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<ShareClient>> CreateShareAsync(
            string shareName,
            IDictionary<string, string> metadata = default,
            int? quotaInBytes = default,
            CancellationToken cancellationToken = default)
        {
            var share = this.GetShareClient(shareName);
            var response = await share.CreateAsync(metadata, quotaInBytes, cancellationToken).ConfigureAwait(false);
            return new Response<ShareClient>(response.GetRawResponse(), share);
        }
        #endregion CreateShare

        #region DeleteShare
        /// <summary>
        /// Marks the specified share or share snapshot for deletion.
        /// The share or share snapshot and any files contained within it are later deleted during garbage collection.
        ///
        /// Currently, this method will always delete snapshots.  There's no way to specify a separate value for x-ms-delete-snapshots.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-share"/>.
        /// </summary>
        /// <param name="shareName">
        /// The name of the share to delete.
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
        [ForwardsClientCalls]
        public virtual Response DeleteShare(
            string shareName,
            CancellationToken cancellationToken = default) =>
            this.GetShareClient(shareName).Delete(cancellationToken: cancellationToken);

        /// <summary>
        /// Marks the specified share or share snapshot for deletion.
        /// The share or share snapshot and any files contained within it are later deleted during garbage collection.
        ///
        /// Currently, this method will always delete snapshots.  There's no way to specify a separate value for x-ms-delete-snapshots.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-share"/>.
        /// </summary>
        /// <param name="shareName">
        /// The name of the share to delete.
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
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteShareAsync(
            string shareName,
            CancellationToken cancellationToken = default) =>
            await this.GetShareClient(shareName)
                .DeleteAsync(cancellationToken: cancellationToken)
                .ConfigureAwait(false);
        #endregion DeleteShare
    }
}
