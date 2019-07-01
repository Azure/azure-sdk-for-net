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
        /// The <see cref="GetQueues"/> operation returns an async
        /// sequence of queues in the storage account.  Enumerating the
        /// queues may make multiple requests to the service while fetching
        /// all the values.  Queue names are returned in lexicographic order.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/list-queues1"/>
        /// </summary>
        /// <param name="options">
        /// <see cref="GetQueuesOptions"/>
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// The queues in the storage account.
        /// </returns>
        public virtual IEnumerable<Response<QueueItem>> GetQueues(
            GetQueuesOptions? options = default,
            CancellationToken cancellationToken = default) =>
            new GetQueuesAsyncCollection(this, options, cancellationToken);

        /// <summary>
        /// The <see cref="GetQueuesAsync"/> operation returns an async
        /// collection of queues in the storage account.  Enumerating the
        /// queues may make multiple requests to the service while fetching
        /// all the values.  Queue names are returned in lexicographic order.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/list-queues1"/>
        /// </summary>
        /// <param name="options">
        /// <see cref="GetQueuesOptions"/>
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// The queues in the storage account.
        /// </returns>
        /// <remarks>
        /// Use an empty marker to start enumeration from the beginning. Queue names are returned in lexicographic order.
        /// After getting a segment, process it, and then call ListQueuesSegment again (passing in the next marker) to get the next segment. 
        /// </remarks>
        public virtual AsyncCollection<QueueItem> GetQueuesAsync(
            GetQueuesOptions? options = default,
            CancellationToken cancellationToken = default) =>
            new GetQueuesAsyncCollection(this, options, cancellationToken);

        /// <summary>
        /// Returns a single segment of containers starting from the specified marker.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/list-queues1"/>
        /// </summary>
        /// <param name="marker">
        /// Marker from the previous request.
        /// </param>
        /// <param name="options">
        /// <see cref="GetQueuesOptions"/>
        /// </param>
        /// <param name="pageSizeHint">
        /// Gets or sets a value indicating the size of the page that should be
        /// requested.
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
        /// After getting a segment, process it, and then call ListQueuesSegmentAsync again (passing in the next marker) to get the next segment. 
        /// </remarks>
        internal async Task<Response<QueuesSegment>> GetQueuesAsync(
            string marker,
            GetQueuesOptions? options,
            int? pageSizeHint,
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
                        maxresults: pageSizeHint,
                        include: options?.AsIncludeTypes(),
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
                .EnsureCompleted();

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
                .EnsureCompleted();

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
                .EnsureCompleted();

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
