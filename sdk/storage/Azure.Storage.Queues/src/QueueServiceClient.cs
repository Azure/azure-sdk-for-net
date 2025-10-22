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
        /// QueueClientConfiguration.
        /// </summary>
        private readonly QueueClientConfiguration _clientConfiguration;

        /// <summary>
        /// QueueClientConfiguration.
        /// </summary>
        internal virtual QueueClientConfiguration ClientConfiguration => _clientConfiguration;

        /// <summary>
        /// ServiceRestClient.
        /// </summary>
        private readonly ServiceRestClient _serviceRestClient;

        /// <summary>
        /// ServiceRestClient.
        /// </summary>
        internal virtual ServiceRestClient ServiceRestClient => _serviceRestClient;

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
        /// Determines whether the client is able to generate a SAS.
        /// If the client is authenticated with a <see cref="StorageSharedKeyCredential"/>.
        /// </summary>
        public virtual bool CanGenerateAccountSasUri => ClientConfiguration.SharedKeyCredential != null;

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
            _accountName = conn.AccountName;
            options ??= new QueueClientOptions();
            _clientConfiguration = new QueueClientConfiguration(
                pipeline: options.Build(conn.Credentials),
                sharedKeyCredential: conn.Credentials as StorageSharedKeyCredential,
                clientDiagnostics: new ClientDiagnostics(options),
                version: options.Version,
                clientSideEncryption: QueueClientSideEncryptionOptions.CloneFrom(options._clientSideEncryptionOptions),
                messageEncoding: options.MessageEncoding,
                queueMessageDecodingFailedHandlers: options.GetMessageDecodingFailedHandlers());

            _serviceRestClient = BuildServiceRestClient();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the queue that includes the
        /// name of the account, the name of the queue, and a SAS token.
        /// This is likely to be similar to "https://{account_name}.queue.core.windows.net/{queue_name}?{sas_token}".
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        /// <seealso href="https://docs.microsoft.com/azure/storage/common/storage-sas-overview">Storage SAS Token Overview</seealso>
        public QueueServiceClient(Uri serviceUri, QueueClientOptions options = default)
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
            : this(
                  serviceUri,
                  credential.AsPolicy(),
                  options,
                  credential,
                  sasCredential: null,
                  tokenCredential: null)
        {
            _accountName ??= credential?.AccountName;
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
            : this(
                  serviceUri,
                  credential.AsPolicy<QueueUriBuilder>(serviceUri),
                  options,
                  sharedKeyCredential: null,
                  sasCredential: credential,
                  tokenCredential: null)
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
            : this(
                  serviceUri,
                  credential.AsPolicy(
                    string.IsNullOrEmpty(options?.Audience?.ToString()) ? QueueAudience.PublicAudience.CreateDefaultScope() : options.Audience.Value.CreateDefaultScope(),
                    options),
                  options,
                  sharedKeyCredential: null,
                  sasCredential: null,
                  tokenCredential: credential)
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
        /// <param name="sharedKeyCredential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="tokenCredential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="sasCredential">
        /// The SAS credential used to sign requests.
        /// </param>
        internal QueueServiceClient(
            Uri serviceUri,
            HttpPipelinePolicy authentication,
            QueueClientOptions options,
            StorageSharedKeyCredential sharedKeyCredential,
            AzureSasCredential sasCredential,
            TokenCredential tokenCredential)
        {
            Argument.AssertNotNull(serviceUri, nameof(serviceUri));
            _uri = serviceUri;
            options ??= new QueueClientOptions();

            _clientConfiguration = new QueueClientConfiguration(
                pipeline: options.Build(authentication),
                sharedKeyCredential: sharedKeyCredential,
                sasCredential: sasCredential,
                tokenCredential: tokenCredential,
                clientDiagnostics: new ClientDiagnostics(options),
                version: options.Version,
                clientSideEncryption: QueueClientSideEncryptionOptions.CloneFrom(options._clientSideEncryptionOptions),
                messageEncoding: options.MessageEncoding,
                queueMessageDecodingFailedHandlers: options.GetMessageDecodingFailedHandlers());

            _serviceRestClient = BuildServiceRestClient();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the queue service.
        /// This is likely to be similar to "https://{account_name}.queue.core.windows.net".
        /// </param>
        /// <param name="clientConfiguration">
        /// <see cref="QueueClientConfiguration"/>.
        /// </param>
        internal QueueServiceClient(
            Uri serviceUri,
            QueueClientConfiguration clientConfiguration)
        {
            Argument.AssertNotNull(serviceUri, nameof(serviceUri));
            Argument.AssertNotNull(clientConfiguration, nameof(clientConfiguration));
            _uri = serviceUri;
            _clientConfiguration = clientConfiguration;
            _serviceRestClient = BuildServiceRestClient();
        }

        private ServiceRestClient BuildServiceRestClient()
            => new ServiceRestClient(
                _clientConfiguration.ClientDiagnostics,
                _clientConfiguration.Pipeline,
                _uri.AbsoluteUri,
                _clientConfiguration.Version.ToVersionString());
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
            => new QueueClient(
                Uri.AppendToPath(queueName),
                ClientConfiguration);

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
        internal async Task<Response<ListQueuesSegmentResponse>> GetQueuesInternal(
            string marker,
            QueueTraits traits,
            string prefix,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(QueueServiceClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(QueueServiceClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(marker)}: {marker}\n" +
                    $"{nameof(traits)}: {traits}\n" +
                    $"{nameof(prefix)}: {prefix}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(QueueServiceClient)}.{nameof(GetQueues)}");

                try
                {
                    ResponseWithHeaders<ListQueuesSegmentResponse, ServiceListQueuesSegmentHeaders> response;

                    scope.Start();
                    IEnumerable<string> includeTypes = traits.AsIncludeTypes();
                    if (async)
                    {
                        response = await _serviceRestClient.ListQueuesSegmentAsync(
                            prefix: prefix,
                            marker: marker,
                            maxresults: pageSizeHint,
                            include: includeTypes.Any() ? includeTypes : null,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = _serviceRestClient.ListQueuesSegment(
                            prefix: prefix,
                            marker: marker,
                            maxresults: pageSizeHint,
                            include: includeTypes.Any() ? includeTypes : null,
                            cancellationToken: cancellationToken);
                    }

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
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(QueueServiceClient));
                    scope.Dispose();
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
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(QueueServiceClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(QueueServiceClient),
                    message: $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(QueueServiceClient)}.{nameof(GetProperties)}");

                try
                {
                    ResponseWithHeaders<QueueServiceProperties, ServiceGetPropertiesHeaders> response;

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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(QueueServiceClient));
                    scope.Dispose();
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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-queues")]
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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-queues")]
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
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(QueueServiceClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(QueueServiceClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(properties)}: {properties}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(QueueServiceClient)}.{nameof(SetProperties)}");

                try
                {
                    ResponseWithHeaders<ServiceSetPropertiesHeaders> response;

                    scope.Start();

                    if (async)
                    {
                        response = await _serviceRestClient.SetPropertiesAsync(
                            queueServiceProperties: properties,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = _serviceRestClient.SetProperties(
                            queueServiceProperties: properties,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(QueueServiceClient));
                    scope.Dispose();
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
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(QueueServiceClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(QueueServiceClient),
                    message: $"{nameof(Uri)}: {Uri}\n");
                try
                {
                    ResponseWithHeaders<QueueServiceStatistics, ServiceGetStatisticsHeaders> response;

                    if (async)
                    {
                        response = await _serviceRestClient.GetStatisticsAsync(
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = _serviceRestClient.GetStatistics(
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.Value,
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(QueueServiceClient));
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

        #region GetUserDelegationKey
        /// <summary>
        /// The <see cref="GetUserDelegationKey(DateTimeOffset, QueueGetUserDelegationKeyOptions, CancellationToken)"/> operation retrieves a
        /// key that can be used to delegate Active Directory authorization to
        /// shared access signatures created with <see cref="Sas.QueueSasBuilder"/>.
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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-queues")]
        public virtual Response<UserDelegationKey> GetUserDelegationKey(
            DateTimeOffset expiresOn,
            QueueGetUserDelegationKeyOptions options = default,
            CancellationToken cancellationToken = default) =>
            GetUserDelegationKeyInternal(
                options?.StartsOn,
                expiresOn,
                options?.DelegatedUserTenantId,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetUserDelegationKeyAsync(DateTimeOffset, QueueGetUserDelegationKeyOptions, CancellationToken)"/> operation retrieves a
        /// key that can be used to delegate Active Directory authorization to
        /// shared access signatures created with <see cref="Sas.QueueSasBuilder"/>.
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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-queues")]
        public virtual async Task<Response<UserDelegationKey>> GetUserDelegationKeyAsync(
            DateTimeOffset expiresOn,
            QueueGetUserDelegationKeyOptions options = default,
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
        /// shared access signatures created with <see cref="Sas.QueueSasBuilder"/>.
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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-queues")]
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
        /// shared access signatures created with <see cref="Sas.QueueSasBuilder"/>.
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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-queues")]
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
        /// shared access signatures created with <see cref="Sas.QueueSasBuilder"/>.
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
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(QueueServiceClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(nameof(QueueServiceClient), message: $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(QueueServiceClient)}.{nameof(GetUserDelegationKey)}");

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
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(QueueServiceClient));
                    scope.Dispose();
                }
            }
        }
        #endregion GetUserDelegationKey

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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-queues")]
        public Uri GenerateAccountSasUri(
            AccountSasPermissions permissions,
            DateTimeOffset expiresOn,
            AccountSasResourceTypes resourceTypes) =>
            GenerateAccountSasUri(permissions, expiresOn, resourceTypes, out _);

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
        /// <param name="stringToSign">
        /// For debugging purposes only.  This string will be overwritten with the string to sign that was used to generate the SAS Uri.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-queues")]
        public Uri GenerateAccountSasUri(
            AccountSasPermissions permissions,
            DateTimeOffset expiresOn,
            AccountSasResourceTypes resourceTypes,
            out string stringToSign) =>
            GenerateAccountSasUri(new AccountSasBuilder(
                permissions,
                expiresOn,
                AccountSasServices.Queues,
                resourceTypes),
                out stringToSign);

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
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-queues")]
        public Uri GenerateAccountSasUri(AccountSasBuilder builder)
            => GenerateAccountSasUri(builder, out _);

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
        /// <param name="stringToSign">
        /// For debugging purposes only.  This string will be overwritten with the string to sign that was used to generate the SAS Uri.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-queues")]
        public Uri GenerateAccountSasUri(AccountSasBuilder builder, out string stringToSign)
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
            sasUri.Query = builder.ToSasQueryParameters(ClientConfiguration.SharedKeyCredential, out stringToSign).ToString();
            return sasUri.ToUri();
        }
        #endregion
    }
}
