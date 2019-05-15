// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        /// Gets the file service's primary <see cref="Uri"/> endpoint.
        /// </summary>
        public Uri Uri { get; }

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send 
        /// every request.
        /// </summary>
        private readonly HttpPipeline _pipeline;

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
        /// <param name="connectionOptions">
        /// Optional connection options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        /// <remarks>
        /// The credentials on <paramref name="connectionString"/> will override those on <paramref name="connectionOptions"/>.
        /// </remarks>
        public FileServiceClient(string connectionString, FileConnectionOptions connectionOptions = default)
        {
            var conn = StorageConnectionString.Parse(connectionString);

            // TODO: perform a copy of the options instead
            var connOptions = connectionOptions ?? new FileConnectionOptions();
            connOptions.Credentials = conn.Credentials;

            this.Uri = conn.FileEndpoint;
            this._pipeline = connOptions.Build();
        }

         /// <summary>
        /// Initializes a new instance of the <see cref="FileServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="primaryUri">
        /// A <see cref="Uri"/> referencing the file service.
        /// </param>
        /// <param name="connectionOptions">
        /// Optional connection options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public FileServiceClient(Uri primaryUri, FileConnectionOptions connectionOptions = default)
            : this(primaryUri, (connectionOptions ?? new FileConnectionOptions()).Build())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="primaryUri">
        /// A <see cref="Uri"/> referencing the file service.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        internal FileServiceClient(Uri primaryUri, HttpPipeline pipeline)
        {
            this.Uri = primaryUri;
            this._pipeline = pipeline;
        }

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
        public ShareClient GetShareClient(string shareName) => new ShareClient(this.Uri.AppendToPath(shareName), this._pipeline);

        /// <summary>
        /// The <see cref="ListSharesSegmentAsync"/> operation returns a
        /// single segment of shares in the storage account, starting
        /// from the specified <paramref name="marker"/>.  Use an empty
        /// <paramref name="marker"/> to start enumeration from the beginning
        /// and the <see cref="SharesSegment.NextMarker"/> if it's not
        /// empty to make subsequent calls to <see cref="ListSharesSegmentAsync"/>
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
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{SharesSegment}}"/> describing a
        /// segment of the shares in the storage account.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<SharesSegment>> ListSharesSegmentAsync(
            string marker = default, 
            SharesSegmentOptions? options = default,
            CancellationToken cancellation = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(FileServiceClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(FileServiceClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(marker)}: {marker}\n" +
                    $"{nameof(options)}: {options}");
                try
                {
                    return await FileRestClient.Service.ListSharesSegmentAsync(
                        this._pipeline,
                        this.Uri,
                        marker: marker,
                        prefix: options?.Prefix,
                        maxresults: options?.MaxResults,
                        include: options?.Details?.ToArray(),
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
                    this._pipeline.LogMethodExit(nameof(FileServiceClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="GetPropertiesAsync"/> operation gets the properties
        /// of a storage account’s file service, including properties for
        /// Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-file-service-properties" />.
        /// </summary>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{FileServiceProperties}}"/> describing
        /// the service properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<FileServiceProperties>> GetPropertiesAsync(
            CancellationToken cancellation = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(FileServiceClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(FileServiceClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await FileRestClient.Service.GetPropertiesAsync(
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
                    this._pipeline.LogMethodExit(nameof(FileServiceClient));
                }
            }
        }

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
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response}"/> if the operation was successful.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response> SetPropertiesAsync(
            FileServiceProperties properties,
            CancellationToken cancellation = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(FileServiceClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(FileServiceClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await FileRestClient.Service.SetPropertiesAsync(
                        this._pipeline,
                        this.Uri,
                        properties: properties,
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
                    this._pipeline.LogMethodExit(nameof(FileServiceClient));
                }
            }
        }
    }

    /// <summary>
    /// Specifies options for listing shares with the 
    /// <see cref="FileServiceClient.ListSharesSegmentAsync"/> operation.
    /// </summary>
    public struct SharesSegmentOptions : IEquatable<SharesSegmentOptions>
    {
        /// <summary>
        /// Gets or sets a string that filters the results to return only
        /// shares whose name begins with the specified prefix.
        /// </summary>
        public string Prefix { get; set; }                   // No Prefix header is produced if ""

        /// <summary>
        /// Gets or sets the maximum number of shares to return. If the
        /// request does not specify <see cref="MaxResults"/>, or specifies a
        /// value greater than 5000, the server will return up to 5000 items.
        /// 
        /// Note that if the listing operation crosses a partition boundary,
        /// then the service will return a <see cref="SharesSegment.NextMarker"/>
        /// for retrieving the remainder of the results.  For this reason, it
        /// is possible that the service will return fewer results than
        /// specified by maxresults, or than the default of 5000. 
        /// 
        /// If the parameter is set to a value less than or equal to zero, 
        /// a <see cref="StorageRequestFailedException"/> will be thrown.
        /// </summary>
        public int? MaxResults { get; set; }                    // 0 means unspecified

        // TODO: update swagger to generate this type?

        /// <summary>
        /// Gets or sets the details about each share that should be
        /// returned with the request.
        /// </summary>
        public ICollection<ListSharesIncludeType> Details { get; set; }

        /// <summary>
        /// Check if two ListSharesSegmentOptions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is SharesSegmentOptions other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the ListSharesSegmentOptions.
        /// </summary>
        /// <returns>Hash code for the ListSharesSegmentOptions.</returns>
        public override int GetHashCode()
            => this.Prefix.GetHashCode()
            ^ this.MaxResults.GetHashCode()
            ^ this.Details.GetHashCode()
            ;

        /// <summary>
        /// Check if two ListSharesSegmentOptions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(SharesSegmentOptions left, SharesSegmentOptions right) => left.Equals(right);

        /// <summary>
        /// Check if two ListSharesSegmentOptions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(SharesSegmentOptions left, SharesSegmentOptions right) => !(left == right);

        /// <summary>
        /// Check if two ListSharesSegmentOptions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(SharesSegmentOptions other)
            => this.Prefix == other.Prefix
            && this.MaxResults == other.MaxResults
            && this.Details == other.Details
            ;
    }
}
