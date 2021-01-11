// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Cryptography;
using Azure.Storage.Queues.Models;
using Azure.Storage.Queues.Specialized;
using Azure.Storage.Sas;

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
        public virtual Uri Uri => _uri;

        /// <summary>
        /// The HttpPipeline used to send REST requests.
        /// </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary>
        /// Gets the HttpPipeline used to send REST requests.
        /// </summary>
        internal virtual HttpPipeline Pipeline => _pipeline;

        /// <summary>
        /// The version of the service to use when sending requests.
        /// </summary>
        private readonly QueueClientOptions.ServiceVersion _version;

        /// <summary>
        /// The version of the service to use when sending requests.
        /// </summary>
        internal virtual QueueClientOptions.ServiceVersion Version => _version;

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
        /// The <see cref="ClientSideEncryptionOptions"/> to be used when sending/receiving requests.
        /// </summary>
        private readonly ClientSideEncryptionOptions _clientSideEncryption;

        /// <summary>
        /// The <see cref="ClientSideEncryptionOptions"/> to be used when sending/receiving requests.
        /// </summary>
        internal virtual ClientSideEncryptionOptions ClientSideEncryption => _clientSideEncryption;

        private readonly QueueMessageEncoding _messageEncoding;

        internal virtual QueueMessageEncoding MessageEncoding => _messageEncoding;

        /// <summary>
        /// The Storage account name corresponding to the service client.
        /// </summary>
        private string _accountName;

        /// <summary>
        /// Gets the Storage account name corresponding to the service client.
        /// </summary>
        public virtual string AccountName
        {
            get
            {
                if (_accountName == null)
                {
                    _accountName = new QueueUriBuilder(Uri).AccountName;
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">
        /// Configure Azure Storage connection strings</see>.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">
        /// Configure Azure Storage connection strings</see>.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public QueueServiceClient(string connectionString, QueueClientOptions options)
        {
            var conn = StorageConnectionString.Parse(connectionString);
            _uri = conn.QueueEndpoint;
            options ??= new QueueClientOptions();
            _pipeline = options.Build(conn.Credentials);
            _version = options.Version;
            _clientDiagnostics = new ClientDiagnostics(options);
            _clientSideEncryption = QueueClientSideEncryptionOptions.CloneFrom(options._clientSideEncryptionOptions);
            _storageSharedKeyCredential = conn.Credentials as StorageSharedKeyCredential;
            _messageEncoding = options.MessageEncoding;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the queue service.
        /// This is likely to be similar to "https://{account_name}.queue.core.windows.net".
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public QueueServiceClient(Uri serviceUri, QueueClientOptions options = default)
            : this(serviceUri, (HttpPipelinePolicy)null, options, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the queue service.
        /// This is likely to be similar to "https://{account_name}.queue.core.windows.net".
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
            : this(serviceUri, credential.AsPolicy(), options, credential)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the queue service.
        /// This is likely to be similar to "https://{account_name}.queue.core.windows.net".
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
        public QueueServiceClient(Uri serviceUri, AzureSasCredential credential, QueueClientOptions options = default)
            : this(serviceUri, credential.AsPolicy<QueueUriBuilder>(serviceUri), options, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the queue service.
        /// This is likely to be similar to "https://{account_name}.queue.core.windows.net".
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
            : this(serviceUri, credential.AsPolicy(), options, null)
        {
            Errors.VerifyHttpsTokenAuth(serviceUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the queue service.
        /// This is likely to be similar to "https://{account_name}.queue.core.windows.net".
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
        internal QueueServiceClient(
            Uri serviceUri,
            HttpPipelinePolicy authentication,
            QueueClientOptions options,
            StorageSharedKeyCredential storageSharedKeyCredential)
        {
            Argument.AssertNotNull(serviceUri, nameof(serviceUri));
            _uri = serviceUri;
            options ??= new QueueClientOptions();
            _pipeline = options.Build(authentication);
            _version = options.Version;
            _clientDiagnostics = new ClientDiagnostics(options);
            _clientSideEncryption = QueueClientSideEncryptionOptions.CloneFrom(options._clientSideEncryptionOptions);
            _storageSharedKeyCredential = storageSharedKeyCredential;
            _messageEncoding = options.MessageEncoding;
        }
        #endregion ctors

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
            => new QueueClient(Uri.AppendToPath(queueName), Pipeline, SharedKeyCredential, Version, ClientDiagnostics, ClientSideEncryption, MessageEncoding);

        #region GetQueues
        /// <summary>
        /// The <see cref="GetQueues"/> operation returns an async
        /// sequence of queues in the storage account.  Enumerating the
        /// queues may make multiple requests to the service while fetching
        /// all the values.  Queue names are returned in lexicographic order.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-queues1">
        /// List Queues</see>.
        /// </summary>
        /// <param name="traits">
        /// Optional trait options for shaping the queues.
        /// </param>
        /// <param name="prefix">
        /// Optional string that filters the results to return only queues
        /// whose name begins with the specified <paramref name="prefix"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// The queues in the storage account.
        /// </returns>
        public virtual Pageable<QueueItem> GetQueues(
            QueueTraits traits = QueueTraits.None,
            string prefix = default,
            CancellationToken cancellationToken = default) =>
            new GetQueuesAsyncCollection(this, traits, prefix).ToSyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetQueuesAsync"/> operation returns an async
        /// collection of queues in the storage account.  Enumerating the
        /// queues may make multiple requests to the service while fetching
        /// all the values.  Queue names are returned in lexicographic order.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-queues1">
        /// List Queues</see>.
        /// </summary>
        /// <param name="traits">
        /// Optional trait options for shaping the queues.
        /// </param>
        /// <param name="prefix">
        /// Optional string that filters the results to return only queues
        /// whose name begins with the specified <paramref name="prefix"/>.
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
        public virtual AsyncPageable<QueueItem> GetQueuesAsync(
            QueueTraits traits = QueueTraits.None,
            string prefix = default,
            CancellationToken cancellationToken = default) =>
            new GetQueuesAsyncCollection(this, traits, prefix).ToAsyncCollection(cancellationToken);

        /// <summary>
        /// Returns a single segment of containers starting from the specified marker.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-queues1">
        /// List Queues</see>.
        /// </summary>
        /// <param name="marker">
        /// Marker from the previous request.
        /// </param>
        /// <param name="traits">
        /// Optional trait options for shaping the queues.
        /// </param>
        /// <param name="prefix">
        /// Optional string that filters the results to return only queues
        /// whose name begins with the specified <paramref name="prefix"/>.
        /// </param>
        /// <param name="pageSizeHint">
        /// Optional hint to specify the desired size of the page returned.
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
        internal async Task<Response<QueuesSegment>> GetQueuesInternal(
            string marker,
            QueueTraits traits,
            string prefix,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(QueueServiceClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(QueueServiceClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(marker)}: {marker}\n" +
                    $"{nameof(traits)}: {traits}\n" +
                    $"{nameof(prefix)}: {prefix}");
                try
                {
                    IEnumerable<ListQueuesIncludeType> includeTypes = traits.AsIncludeTypes();
                    Response<QueuesSegment> response = await QueueRestClient.Service.ListQueuesSegmentAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        marker: marker,
                        prefix: prefix,
                        maxresults: pageSizeHint,
                        include: includeTypes.Any() ? includeTypes : null,
                        async: async,
                        operationName: $"{nameof(QueueServiceClient)}.{nameof(GetQueues)}",
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                    if ((traits & QueueTraits.Metadata) != QueueTraits.Metadata)
                    {
                        IEnumerable<QueueItem> queueItems = response.Value.QueueItems;
                        foreach (QueueItem queueItem in queueItems)
                        {
                            queueItem.Metadata = null;
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
                    Pipeline.LogMethodExit(nameof(QueueServiceClient));
                }
            }
        }
        #endregion GetQueues

        #region GetProperties
        /// <summary>
        /// Gets the properties of the queue service.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-queue-service-properties">
        /// Get Queue Service Properties</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{QueueServiceProperties}"/>
        /// </returns>
        public virtual Response<QueueServiceProperties> GetProperties(
            CancellationToken cancellationToken = default) =>
            GetPropertiesInternal(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Gets the properties of the queue service.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-queue-service-properties">
        /// Get Queue Service Properties</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{QueueServiceProperties}"/>
        /// </returns>
        public virtual async Task<Response<QueueServiceProperties>> GetPropertiesAsync(
            CancellationToken cancellationToken = default) =>
            await GetPropertiesInternal(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Gets the properties of the queue service.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-queue-service-properties">
        /// Get Queue Service Properties</see>.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{QueueServiceProperties}"/>
        /// </returns>
        private async Task<Response<QueueServiceProperties>> GetPropertiesInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(QueueServiceClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(QueueServiceClient),
                    message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    return await QueueRestClient.Service.GetPropertiesAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        async: async,
                        operationName: $"{nameof(QueueServiceClient)}.{nameof(GetProperties)}",
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
                    Pipeline.LogMethodExit(nameof(QueueServiceClient));
                }
            }
        }
        #endregion GetProperties

        #region SetProperties
        /// <summary>
        /// Sets the properties of the queue service.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-queue-service-properties">
        /// Set Queue Service Properties</see>.
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
            SetPropertiesInternal(
                properties,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Sets the properties of the queue service.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-queue-service-properties">
        /// Set Queue Service Properties</see>.
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
        public virtual async Task<Response> SetPropertiesAsync(
            QueueServiceProperties properties,
            CancellationToken cancellationToken = default) =>
            await SetPropertiesInternal(
                properties,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Sets the properties of the queue service.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-queue-service-properties">
        /// Set Queue Service Properties</see>.
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
        /// <see cref="Response"/>
        /// </returns>
        private async Task<Response> SetPropertiesInternal(
            QueueServiceProperties properties,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(QueueServiceClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(QueueServiceClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(properties)}: {properties}");
                try
                {
                    return await QueueRestClient.Service.SetPropertiesAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        properties: properties,
                        version: Version.ToVersionString(),
                        async: async,
                        operationName: $"{nameof(QueueServiceClient)}.{nameof(SetProperties)}",
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
                    Pipeline.LogMethodExit(nameof(QueueServiceClient));
                }
            }
        }
        #endregion SetProperties

        #region GetStatistics
        /// <summary>
        /// Retrieves statistics related to replication for the Blob service. It is
        /// only available on the secondary location endpoint when read-access
        /// geo-redundant replication is enabled for the storage account.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-queue-service-stats">
        /// Get Queue Service Stats</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{QueueServiceStatistics}"/>
        /// </returns>
        public virtual Response<QueueServiceStatistics> GetStatistics(
            CancellationToken cancellationToken = default) =>
            GetStatisticsInternal(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Retrieves statistics related to replication for the Blob service. It is
        /// only available on the secondary location endpoint when read-access
        /// geo-redundant replication is enabled for the storage account.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-queue-service-stats">
        /// Get Queue Service Stats</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{QueueServiceStatistics}"/>
        /// </returns>
        public virtual async Task<Response<QueueServiceStatistics>> GetStatisticsAsync(
            CancellationToken cancellationToken = default) =>
            await GetStatisticsInternal(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Retrieves statistics related to replication for the Blob service. It is
        /// only available on the secondary location endpoint when read-access
        /// geo-redundant replication is enabled for the storage account.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-queue-service-stats">
        /// Get Queue Service Stats</see>.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{QueueServiceStatistics}"/>
        /// </returns>
        private async Task<Response<QueueServiceStatistics>> GetStatisticsInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(QueueServiceClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(QueueServiceClient),
                    message: $"{nameof(Uri)}: {Uri}\n");
                try
                {
                    return await QueueRestClient.Service.GetStatisticsAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        async: async,
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
                    Pipeline.LogMethodExit(nameof(QueueServiceClient));
                }
            }
        }
        #endregion GetStatistics

        #region CreateQueue
        /// <summary>
        /// Creates a queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-queue4">
        /// Create Queue</see>.
        /// </summary>
        /// <param name="queueName">
        /// The name of the queue to create.
        /// </param>
        /// <param name="metadata">
        /// Optional <see cref="IDictionary{String, String}"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// A newly created <see cref="Response{QueueClient}"/>.
        /// </returns>
        [ForwardsClientCalls]
        public virtual Response<QueueClient> CreateQueue(
            string queueName,
            IDictionary<string, string> metadata = default,
            CancellationToken cancellationToken = default)
        {
            QueueClient queue = GetQueueClient(queueName);
            Response response = queue.Create(metadata, cancellationToken);
            return Response.FromValue(queue, response);
        }

        /// <summary>
        /// Creates a queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-queue4">
        /// Create Queue</see>.
        /// </summary>
        /// <param name="queueName">
        /// The name of the queue to create.
        /// </param>
        /// <param name="metadata">
        /// Optional <see cref="IDictionary{String, String}"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// A newly created <see cref="Response{QueueClient}"/>.
        /// </returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<QueueClient>> CreateQueueAsync(
            string queueName,
            IDictionary<string, string> metadata = default,
            CancellationToken cancellationToken = default)
        {
            QueueClient queue = GetQueueClient(queueName);
            Response response = await queue.CreateAsync(metadata, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(queue, response);
        }
        #endregion CreateQueue

        #region DeleteQueue
        /// <summary>
        /// Deletes a queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-queue3">
        /// Delete Queue</see>.
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
        [ForwardsClientCalls]
        public virtual Response DeleteQueue(
            string queueName,
            CancellationToken cancellationToken = default) =>
            GetQueueClient(queueName).Delete(cancellationToken);

        /// <summary>
        /// Deletes a queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-queue3">
        /// Delete Queue</see>.
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
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteQueueAsync(
            string queueName,
            CancellationToken cancellationToken = default) =>
            await GetQueueClient(queueName)
                .DeleteAsync(cancellationToken)
                .ConfigureAwait(false);
        #endregion DeleteQueue

        #region GenerateSas
        /// <summary>
        /// The <see cref="GenerateAccountSasUri(AccountSasPermissions, DateTimeOffset, AccountSasResourceTypes)"/>
        /// returns a <see cref="Uri"/> that generates a Queue
        /// Account Shared Access Signature based on the
        /// Client properties and parameters passed. The SAS is signed by the
        /// shared key credential of the client.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-account-sas">
        /// Constructing a Service SAS</see>
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
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public Uri GenerateAccountSasUri(
            AccountSasPermissions permissions,
            DateTimeOffset expiresOn,
            AccountSasResourceTypes resourceTypes) =>
            GenerateAccountSasUri(new AccountSasBuilder(
                permissions,
                expiresOn,
                AccountSasServices.Queues,
                resourceTypes));

        /// <summary>
        /// The <see cref="GenerateAccountSasUri(AccountSasBuilder)"/> returns a Uri that
        /// generates a Service SAS based on the Client properties and builder passed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-account-sas">
        /// Constructing a Service SAS</see>
        /// </summary>
        /// <param name="builder">
        /// Used to generate a Shared Access Signature (SAS).
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public Uri GenerateAccountSasUri(AccountSasBuilder builder)
        {
            builder = builder ?? throw Errors.ArgumentNull(nameof(builder));
            if (!builder.Services.HasFlag(AccountSasServices.Queues))
            {
                throw Errors.SasServiceNotMatching(
                    nameof(builder.Services),
                    nameof(builder),
                    nameof(AccountSasServices.Queues));
            }
            QueueUriBuilder sasUri = new QueueUriBuilder(Uri);
            sasUri.Query = builder.ToSasQueryParameters(SharedKeyCredential).ToString();
            return sasUri.ToUri();
        }
        #endregion
    }
}
