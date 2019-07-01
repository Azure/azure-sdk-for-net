// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
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
        private readonly Uri _uri;
        
        /// <summary>
        /// The Uri endpoint used by the object.
        /// </summary>
        public virtual Uri Uri => this._uri;

        /// <summary>
        /// The HttpPipeline used to send REST requests.
        /// </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary>
        /// Gets the HttpPipeline used to send REST requests.
        /// </summary>
        protected virtual HttpPipeline Pipeline => this._pipeline;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueServiceClient"/>
        /// class for mocking.
        /// </summary>
        protected QueueServiceClient()
        {
        }

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
        public QueueServiceClient(string connectionString)
            : this(connectionString, null)
        {
        }

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
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public QueueServiceClient(string connectionString, QueueClientOptions options)
        {
            var conn = StorageConnectionString.Parse(connectionString);
            this._uri = conn.QueueEndpoint;
            this._pipeline = (options ?? new QueueClientOptions()).Build(conn.Credentials);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the queue service.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public QueueServiceClient(Uri serviceUri, QueueClientOptions options = default)
            : this(serviceUri, (HttpPipelinePolicy)null, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the queue service.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public QueueServiceClient(Uri serviceUri, StorageSharedKeyCredential credential, QueueClientOptions options = default)
            : this(serviceUri, credential.AsPolicy(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the queue service.
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public QueueServiceClient(Uri serviceUri, TokenCredential credential, QueueClientOptions options = default)
            : this(serviceUri, credential.AsPolicy(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the queue service.
        /// </param>
        /// <param name="authentication">
        /// An optional authentication policy used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        internal QueueServiceClient(Uri serviceUri, HttpPipelinePolicy authentication, QueueClientOptions options)
        {
            this._uri = serviceUri;
            this._pipeline = (options ?? new QueueClientOptions()).Build(authentication);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the queue service.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        internal QueueServiceClient(Uri serviceUri, HttpPipeline pipeline)
        {
            this._uri = serviceUri;
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
        public virtual QueueClient GetQueueClient(string queueName)
            => new QueueClient(this.Uri.AppendToPath(queueName), this.Pipeline);

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
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// A single segment of containers starting from the specified marker, including the next marker if appropriate.
        /// </returns>
        /// <remarks>
        /// Use an empty marker to start enumeration from the beginning. Queue names are returned in lexicographic order.
        /// After getting a segment, process it, and then call ListQueuesSegment again (passing in the next marker) to get the next segment. 
        /// </remarks>
        public virtual Response<QueuesSegment> ListQueuesSegment(
            QueuesSegmentOptions? options = default,
            string marker = default,
            CancellationToken cancellationToken = default) =>
            this.ListQueuesSegmentAsync(
                options,
                marker,
                false, // async
                cancellationToken)
                .EnsureCompleted();

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
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// A single segment of containers starting from the specified marker, including the next marker if appropriate.
        /// </returns>
        /// <remarks>
        /// Use an empty marker to start enumeration from the beginning. Queue names are returned in lexicographic order.
        /// After getting a segment, process it, and then call ListQueuesSegment again (passing in the next marker) to get the next segment. 
        /// </remarks>
        public virtual Response<QueuesSegment> ListQueuesSegment(
            QueuesSegmentOptions? options = default,
            string marker = default,
            CancellationToken cancellationToken = default) =>
            this.ListQueuesSegmentAsync(
                options,
                marker,
                false, // async
                cancellationToken)
                .EnsureCompleted(syncOverAsync: true);

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
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// A single segment of containers starting from the specified marker, including the next marker if appropriate.
        /// </returns>
        /// <remarks>
        /// Use an empty marker to start enumeration from the beginning. Queue names are returned in lexicographic order.
        /// After getting a segment, process it, and then call ListQueuesSegmentAsync again (passing in the next marker) to get the next segment. 
        /// </remarks>
        public virtual async Task<Response<QueuesSegment>> ListQueuesSegmentAsync(
            QueuesSegmentOptions? options = default,
            string marker = default,
            CancellationToken cancellationToken = default) =>
            await this.ListQueuesSegmentAsync(
                options,
                marker,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

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
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// A single segment of containers starting from the specified marker, including the next marker if appropriate.
        /// </returns>
        /// <remarks>
        /// Use an empty marker to start enumeration from the beginning. Queue names are returned in lexicographic order.
        /// After getting a segment, process it, and then call ListQueuesSegmentAsync again (passing in the next marker) to get the next segment. 
        /// </remarks>
        private async Task<Response<QueuesSegment>> ListQueuesSegmentAsync(
            QueuesSegmentOptions? options,
            string marker,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(QueueServiceClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(QueueServiceClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(marker)}: {marker}\n" +
                    $"{nameof(options)}: {options}");
                try
                {
                    return await QueueRestClient.Service.ListQueuesSegmentAsync(
                        this.Pipeline,
                        this.Uri,
                        marker: marker,
                        prefix: options?.Prefix,
                        maxresults: options?.MaxResults,
                        include: options?.Detail.AsIncludeType(),
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
                    this.Pipeline.LogMethodExit(nameof(QueueServiceClient));
                }
            }
        }

        /// <summary>
        /// Gets the properties of the queue service.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-queue-service-properties"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{QueueServiceProperties}"/>
        /// </returns>
        public virtual Response<QueueServiceProperties> GetProperties(
            CancellationToken cancellationToken = default) =>
            this.GetPropertiesAsync(
                false, // async
                cancellationToken)
                .EnsureCompleted(syncOverAsync: true);

        /// <summary>
        /// Gets the properties of the queue service.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-queue-service-properties"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Task{Response{QueueServiceProperties}}"/>
        /// </returns>
        public virtual async Task<Response<QueueServiceProperties>> GetPropertiesAsync(
            CancellationToken cancellationToken = default) =>
            await this.GetPropertiesAsync(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Gets the properties of the queue service.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-queue-service-properties"/>.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Task{Response{QueueServiceProperties}}"/>
        /// </returns>
        private async Task<Response<QueueServiceProperties>> GetPropertiesAsync(
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(QueueServiceClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(QueueServiceClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await QueueRestClient.Service.GetPropertiesAsync(
                        this.Pipeline,
                        this.Uri,
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
                    this.Pipeline.LogMethodExit(nameof(QueueServiceClient));
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
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response"/>
        /// </returns>
        public virtual Response SetProperties(
            QueueServiceProperties properties,
            CancellationToken cancellationToken = default) =>
            this.SetPropertiesAsync(
                properties,
                false, // async
                cancellationToken)
                .EnsureCompleted(syncOverAsync: true);

        /// <summary>
        /// Sets the properties of the queue service.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-queue-service-properties"/>.
        /// </summary>
        /// <param name="properties">
        /// <see cref="QueueServiceProperties"/>
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Task{Response}"/>
        /// </returns>
        public virtual async Task<Response> SetPropertiesAsync(
            QueueServiceProperties properties,
            CancellationToken cancellationToken = default) =>
            await this.SetPropertiesAsync(
                properties,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Sets the properties of the queue service.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-queue-service-properties"/>.
        /// </summary>
        /// <param name="properties">
        /// <see cref="QueueServiceProperties"/>
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Task{Response}"/>
        /// </returns>
        private async Task<Response> SetPropertiesAsync(
            QueueServiceProperties properties,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(QueueServiceClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(QueueServiceClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(properties)}: {properties}");
                try
                {
                    return await QueueRestClient.Service.SetPropertiesAsync(
                        this.Pipeline,
                        this.Uri,
                        properties: properties,
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
                    this.Pipeline.LogMethodExit(nameof(QueueServiceClient));
                }
            }
        }

        /// <summary>
        /// Retrieves statistics related to replication for the Blob service. It is
        /// only available on the secondary location endpoint when read-access
        /// geo-redundant replication is enabled for the storage account.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-queue-service-stats"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{QueueServiceStatistics}"/>
        /// </returns>
        public virtual Response<QueueServiceStatistics> GetStatistics(
            CancellationToken cancellationToken = default) =>
            this.GetStatisticsAsync(
                false, // async
                cancellationToken)
                .EnsureCompleted(syncOverAsync: true);

        /// <summary>
        /// Retrieves statistics related to replication for the Blob service. It is
        /// only available on the secondary location endpoint when read-access
        /// geo-redundant replication is enabled for the storage account.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-queue-service-stats"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Task{Response{QueueServiceStatistics}}"/>
        /// </returns>
        public virtual async Task<Response<QueueServiceStatistics>> GetStatisticsAsync(
            CancellationToken cancellationToken = default) =>
            await this.GetStatisticsAsync(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Retrieves statistics related to replication for the Blob service. It is
        /// only available on the secondary location endpoint when read-access
        /// geo-redundant replication is enabled for the storage account.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-queue-service-stats"/>.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Task{Response{QueueServiceStatistics}}"/>
        /// </returns>
        private async Task<Response<QueueServiceStatistics>> GetStatisticsAsync(
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(QueueServiceClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(QueueServiceClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}\n");
                try
                {
                    return await QueueRestClient.Service.GetStatisticsAsync(
                        this.Pipeline,
                        this.Uri,
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
                    this.Pipeline.LogMethodExit(nameof(QueueServiceClient));
                }
            }
        }

        /// <summary>
        /// Creates a queue.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-queue4"/>.
        /// </summary>
        /// <param name="queueName">
        /// The name of the queue to create.
        /// </param>
        /// <param name="metadata">
        /// Optional <see cref="Metadata"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// A newly created <see cref="Response{QueueClient}"/>.
        /// </returns>
        public virtual Response<QueueClient> CreateQueue(
            string queueName,
            IDictionary<string, string> metadata = default,
            CancellationToken cancellationToken = default)
        {
            var queue = this.GetQueueClient(queueName);
            var response = queue.Create(metadata, cancellationToken);
            return new Response<QueueClient>(response, queue);
        }

        /// <summary>
        /// Creates a queue.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-queue4"/>.
        /// </summary>
        /// <param name="queueName">
        /// The name of the queue to create.
        /// </param>
        /// <param name="metadata">
        /// Optional <see cref="Metadata"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// A newly created <see cref="Response{QueueClient}"/>.
        /// </returns>
        public virtual async Task<Response<QueueClient>> CreateQueueAsync(
            string queueName,
            IDictionary<string, string> metadata = default,
            CancellationToken cancellationToken = default)
        {
            var queue = this.GetQueueClient(queueName);
            var response = await queue.CreateAsync(metadata, cancellationToken).ConfigureAwait(false);
            return new Response<QueueClient>(response, queue);
        }

        /// <summary>
        /// Deletes a queue.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/delete-queue3"/>.
        /// </summary>
        /// <param name="queueName">
        /// The name of the queue to delete.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response"/>
        /// </returns>
        public virtual Response DeleteQueue(
            string queueName,
            CancellationToken cancellationToken = default) =>
            this.GetQueueClient(queueName).Delete(cancellationToken);

        /// <summary>
        /// Deletes a queue.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/delete-queue3"/>.
        /// </summary>
        /// <param name="queueName">
        /// The name of the queue to delete.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Task{Response}"/>
        /// </returns>
        public virtual async Task<Response> DeleteQueueAsync(
            string queueName,
            CancellationToken cancellationToken = default) =>
            await this.GetQueueClient(queueName)
                .DeleteAsync(cancellationToken)
                .ConfigureAwait(false);
    }
}

namespace Azure.Storage.Queues.Models
{
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
