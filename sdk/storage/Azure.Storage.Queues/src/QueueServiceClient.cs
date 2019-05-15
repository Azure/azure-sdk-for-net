// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Common;
using Azure.Storage.Queues.Models;

namespace Azure.Storage.Queues
{
    /// <summary>
    /// A QueueServiceClient represents a URL to the Azure Storage Queue service.
    /// </summary>
    public class QueueServiceClient
    {
        /// <summary>
        /// The Uri endpoint used by the object.
        /// </summary>
        public Uri Uri { get; }

        /// <summary>
        /// The HttpPipeline used to send REST requests.
        /// </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueServiceClient"/>
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
        public QueueServiceClient(string connectionString, QueueConnectionOptions connectionOptions = default)
        {
            var conn = StorageConnectionString.Parse(connectionString);

            // TODO: perform a copy of the options instead
            var connOptions = connectionOptions ?? new QueueConnectionOptions();
            connOptions.Credentials = conn.Credentials;

            this.Uri = conn.QueueEndpoint;
            this._pipeline = connOptions.Build();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="primaryUri">
        /// A <see cref="Uri"/> referencing the queue service.
        /// </param>
        /// <param name="connectionOptions">
        /// Optional connection options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public QueueServiceClient(Uri primaryUri, QueueConnectionOptions connectionOptions = default)
            : this(primaryUri, (connectionOptions ?? new QueueConnectionOptions()).Build())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="primaryUri">
        /// A <see cref="Uri"/> referencing the queue service.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        internal QueueServiceClient(Uri primaryUri, HttpPipeline pipeline)
        {
            this.Uri = primaryUri;
            this._pipeline = pipeline;
        }

        /// <summary>
        /// Create a new <see cref="QueueClient"/> object by appending
        /// <paramref name="queueName"/> to the end of <see cref="Uri"/>.
        /// The new <see cref="QueueClient"/> uses the same request
        /// policy pipeline as the <see cref="QueueServiceClient"/>.
        /// </summary>
        /// <param name="queueName">
        /// The name of the queue to reference.
        /// </param>
        /// <returns>
        /// A <see cref="QueueClient"/> for the desired queue.
        /// </returns>
        public QueueClient GetQueueClient(string queueName)
            => new QueueClient(this.Uri.AppendToPath(queueName), this._pipeline);

        /// <summary>
        /// Returns a single segment of containers starting from the specified marker.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/list-queues1"/>
        /// </summary>
        /// <param name="options">
        /// <see cref="QueuesSegmentOptions"/>
        /// </param>
        /// <param name="marker">
        /// Marker from the previous request.
        /// </param>
        /// <param name="cancellation">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// A single segment of containers starting from the specified marker, including the next marker if appropriate.
        /// </returns>
        /// <remarks>
        /// Use an empty marker to start enumeration from the beginning. Queue names are returned in lexicographic order.
        /// After getting a segment, process it, and then call ListQueuesSegmentAsync again (passing in the next marker) to get the next segment. 
        /// </remarks>
        public async Task<Response<QueuesSegment>> ListQueuesSegmentAsync(
            QueuesSegmentOptions? options = default,
            string marker = default,
            CancellationToken cancellation = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(QueueServiceClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(QueueServiceClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(marker)}: {marker}\n" +
                    $"{nameof(options)}: {options}");
                try
                {
                    return await QueueRestClient.Service.ListQueuesSegmentAsync(
                        this._pipeline,
                        this.Uri,
                        marker: marker,
                        prefix: options?.Prefix,
                        maxresults: options?.MaxResults,
                        include: options?.Detail.AsIncludeType(),
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
                    this._pipeline.LogMethodExit(nameof(QueueServiceClient));
                }
            }
        }

        /// <summary>
        /// Gets the properties of the queue service.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-queue-service-properties"/>.
        /// </summary>
        /// <param name="cancellation">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Task{Response{QueueServiceProperties}}"/>
        /// </returns>
        public async Task<Response<QueueServiceProperties>> GetPropertiesAsync(
            CancellationToken cancellation = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(QueueServiceClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(QueueServiceClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await QueueRestClient.Service.GetPropertiesAsync(
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
                    this._pipeline.LogMethodExit(nameof(QueueServiceClient));
                }
            }
        }

        /// <summary>
        /// Sets the properties of the queue service.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-queue-service-properties"/>.
        /// </summary>
        /// <param name="properties">
        /// <see cref="QueueServiceProperties"/>
        /// </param>
        /// <param name="cancellation">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Task{Response}"/>
        /// </returns>
        public async Task<Response> SetPropertiesAsync(
            QueueServiceProperties properties,
            CancellationToken cancellation = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(QueueServiceClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(QueueServiceClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(properties)}: {properties}");
                try
                {
                    return await QueueRestClient.Service.SetPropertiesAsync(
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
                    this._pipeline.LogMethodExit(nameof(QueueServiceClient));
                }
            }
        }

        /// <summary>
        /// Retrieves statistics related to replication for the Blob service. It is
        /// only available on the secondary location endpoint when read-access
        /// geo-redundant replication is enabled for the storage account.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-queue-service-stats"/>.
        /// </summary>
        /// <param name="cancellation">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Task{Response{QueueServiceStatistics}}"/>
        /// </returns>
        public async Task<Response<QueueServiceStatistics>> GetStatisticsAsync(
            CancellationToken cancellation = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(QueueServiceClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(QueueServiceClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}\n");
                try
                {
                    return await QueueRestClient.Service.GetStatisticsAsync(
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
                    this._pipeline.LogMethodExit(nameof(QueueServiceClient));
                }
            }
        }
    }

    /// <summary>
    /// QueuesSegmentOptions defines options available when calling ListQueues.
    /// </summary>
    public struct QueuesSegmentOptions : IEquatable<QueuesSegmentOptions>
    {
        public ListQueuesSegmentDetail Detail { get; set; }
        public string Prefix { get; set; }
        public int? MaxResults { get; set; }

        public override bool Equals(object obj)
            => obj is QueuesSegmentOptions other
            && this.Equals(other)
            ;

        /// <summary>
        /// Get a hash code for the QueuesSegmentOptions.
        /// </summary>
        /// <returns>Hash code for the QueuesSegmentOptions.</returns>
        public override int GetHashCode()
            => this.Detail.GetHashCode()
            ^ this.Prefix.GetHashCode()
            ^ this.MaxResults.GetHashCode()
            ;

        /// <summary>
        /// Check if two QueuesSegmentOptions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(QueuesSegmentOptions left, QueuesSegmentOptions right) => left.Equals(right);

        /// <summary>
        /// Check if two QueuesSegmentOptions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(QueuesSegmentOptions left, QueuesSegmentOptions right) => !(left == right);

        /// <summary>
        /// Check if two QueuesSegmentOptions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(QueuesSegmentOptions other)
            => this.Detail == other.Detail
            && this.Prefix == other.Prefix
            && this.MaxResults == other.MaxResults
            ;
    }

    /// <summary>
    /// ListQueuesSegmentDetail indicates what additional information the service should return with each queue.
    /// </summary>
    public struct ListQueuesSegmentDetail : IEquatable<ListQueuesSegmentDetail>
    {
        public bool Metadata { get; set; }

        internal IEnumerable<ListQueuesIncludeType> AsIncludeType()
            => this.Metadata ?
                new ListQueuesIncludeType[] { ListQueuesIncludeType.Metadata } :
                Array.Empty<ListQueuesIncludeType>();

        /// <summary>
        /// Check if two ListQueuesSegmentDetail instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is ListQueuesSegmentDetail other
            && this.Equals(other)
            ;

        /// <summary>
        /// Get a hash code for the ListQueuesSegmentDetail.
        /// </summary>
        /// <returns>Hash code for the ListQueuesSegmentDetail.</returns>
        public override int GetHashCode()
            => this.Metadata.GetHashCode()
            ;

        /// <summary>
        /// Check if two ListQueuesSegmentDetail instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(ListQueuesSegmentDetail left, ListQueuesSegmentDetail right) => left.Equals(right);

        /// <summary>
        /// Check if two ListQueuesSegmentDetail instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(ListQueuesSegmentDetail left, ListQueuesSegmentDetail right) => !(left == right);

        /// <summary>
        /// Check if two ListQueuesSegmentDetail instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(ListQueuesSegmentDetail other)
            => this.Metadata == other.Metadata
            ;
    }
}
