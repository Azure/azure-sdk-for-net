// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Cryptography;
using Azure.Storage.Queues.Models;
using Azure.Storage.Queues.Specialized;
using Azure.Storage.Sas;
using Azure.Storage.Shared;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Queues
{
    /// <summary>
    /// A QueueClient represents a URI to the Azure Storage Queue service allowing you to manipulate a queue.
    /// </summary>
    public class QueueClient
    {
        /// <summary>
        /// The Uri endpoint used by the object.
        /// </summary>
        private readonly Uri _uri;

        /// <summary>
        /// Gets the Uri endpoint used by the object.
        /// </summary>
        public virtual Uri Uri => _uri;

        /// <summary>
        /// The Uri endpoint used by the object's messages.
        /// </summary>
        private readonly Uri _messagesUri;

        /// <summary>
        /// Gets the Uri endpoint used by the object's messages.
        /// </summary>
        protected virtual Uri MessagesUri => _messagesUri;

        /// <summary>
        /// QueueClientConfiguration.
        /// </summary>
        private readonly QueueClientConfiguration _clientConfiguration;

        /// <summary>
        /// QueueClientConfiguration.
        /// </summary>
        internal virtual QueueClientConfiguration ClientConfiguration => _clientConfiguration;

        /// <summary>
        /// QueueRestClient.
        /// </summary>
        private readonly QueueRestClient _queueRestClient;

        /// <summary>
        /// Gets the QueueRestClient.
        /// </summary>
        internal virtual QueueRestClient QueueRestClient => _queueRestClient;

        /// <summary>
        /// MessagesRestClient.
        /// </summary>
        private readonly MessagesRestClient _messagesRestClient;

        /// <summary>
        /// Gets the MessagesRestClient.
        /// </summary>
        internal virtual MessagesRestClient MessagesRestClient => _messagesRestClient;

        /// <summary>
        /// MessageIdRestClient.
        /// </summary>
        private readonly MessageIdRestClient _messageIdRestClient;

        /// <summary>
        /// Gets the MessageIdRestClient.
        /// </summary>
        internal virtual MessageIdRestClient MessageIdRestClient => _messageIdRestClient;

        internal bool UsingClientSideEncryption => _clientConfiguration.ClientSideEncryption != default;

        /// <summary>
        /// QueueMaxMessagesPeek indicates the maximum number of messages
        /// you can retrieve with each call to Peek.
        /// </summary>
        public virtual int MaxPeekableMessages => Constants.Queue.MaxMessagesDequeue;

        /// <summary>
        /// Gets the maximum number of bytes allowed for a message's UTF-8 text.
        /// </summary>
        public virtual int MessageMaxBytes => Constants.Queue.QueueMessageMaxBytes;

        /// <summary>
        /// The Storage account name corresponding to the queue client.
        /// </summary>
        private string _accountName;

        /// <summary>
        /// Gets the Storage account name corresponding to the queue client.
        /// </summary>
        public virtual string AccountName
        {
            get
            {
                SetNameFieldsIfNull();
                return _accountName;
            }
        }

        /// <summary>
        /// The name of the queue.
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets the name of the queue.
        /// </summary>
        public virtual string Name
        {
            get
            {
                SetNameFieldsIfNull();
                return _name;
            }
        }

        /// <summary>
        /// Determines whether the client is able to generate a SAS.
        /// If the client is authenticated with a <see cref="StorageSharedKeyCredential"/>.
        /// </summary>
        public virtual bool CanGenerateSasUri => ClientConfiguration.SharedKeyCredential != null;

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClient"/>
        /// class for mocking.
        /// </summary>
        protected QueueClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClient"/>
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
        /// <param name="queueName">
        /// The name of the queue in the storage account to reference.
        /// </param>
        public QueueClient(string connectionString, string queueName)
            : this(connectionString, queueName, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClient"/>
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
        /// <param name="queueName">
        /// The name of the queue in the storage account to reference.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public QueueClient(string connectionString, string queueName, QueueClientOptions options)
        {
            StorageConnectionString conn = StorageConnectionString.Parse(connectionString);
            QueueUriBuilder uriBuilder = new QueueUriBuilder(conn.QueueEndpoint)
            {
                QueueName = queueName
            };

            _uri = uriBuilder.ToUri();
            _messagesUri = _uri.AppendToPath(Constants.Queue.MessagesUri);
            options ??= new QueueClientOptions();

            _clientConfiguration = new QueueClientConfiguration(
                pipeline: options.Build(conn.Credentials),
                sharedKeyCredential: conn.Credentials as StorageSharedKeyCredential,
                clientDiagnostics: new ClientDiagnostics(options),
                version: options.Version,
                clientSideEncryption: QueueClientSideEncryptionOptions.CloneFrom(options._clientSideEncryptionOptions),
                messageEncoding: options.MessageEncoding,
                queueMessageDecodingFailedHandlers: options.GetMessageDecodingFailedHandlers());

            (QueueRestClient queueRestClient, MessagesRestClient messagesRestClient, MessageIdRestClient messageIdRestClient) = BuildRestClients();
            _queueRestClient = queueRestClient;
            _messagesRestClient = messagesRestClient;
            _messageIdRestClient = messageIdRestClient;

            AssertEncodingForEncryption();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClient"/>
        /// class.
        /// </summary>
        /// <param name="queueUri">
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
        public QueueClient(Uri queueUri, QueueClientOptions options = default)
            : this(
                  queueUri,
                  (HttpPipelinePolicy)null,
                  options,
                  sharedKeyCredential: null,
                  sasCredential: null,
                  tokenCredential: null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClient"/>
        /// class.
        /// </summary>
        /// <param name="queueUri">
        /// A <see cref="Uri"/> referencing the queue that includes the
        /// name of the account, and the name of the queue.
        /// This is likely to be similar to "https://{account_name}.queue.core.windows.net/{queue_name}".
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public QueueClient(Uri queueUri, StorageSharedKeyCredential credential, QueueClientOptions options = default)
            : this(
                  queueUri,
                  credential.AsPolicy(),
                  options,
                  sharedKeyCredential: credential,
                  sasCredential: null,
                  tokenCredential: null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClient"/>
        /// class.
        /// </summary>
        /// <param name="queueUri">
        /// A <see cref="Uri"/> referencing the queue that includes the
        /// name of the account, and the name of the queue.
        /// This is likely to be similar to "https://{account_name}.queue.core.windows.net/{queue_name}".
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
        public QueueClient(Uri queueUri, AzureSasCredential credential, QueueClientOptions options = default)
            : this(
                  queueUri,
                  credential.AsPolicy<QueueUriBuilder>(queueUri),
                  options,
                  sharedKeyCredential: null,
                  sasCredential: credential,
                  tokenCredential: null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClient"/>
        /// class.
        /// </summary>
        /// <param name="queueUri">
        /// A <see cref="Uri"/> referencing the queue that includes the
        /// name of the account, and the name of the queue.
        /// This is likely to be similar to "https://{account_name}.queue.core.windows.net/{queue_name}".
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public QueueClient(Uri queueUri, TokenCredential credential, QueueClientOptions options = default)
            : this(
                  queueUri,
                  credential.AsPolicy(
                    string.IsNullOrEmpty(options?.Audience?.ToString()) ? QueueAudience.PublicAudience.CreateDefaultScope() : options.Audience.Value.CreateDefaultScope(),
                    options),
                  options,
                  sharedKeyCredential: null,
                  sasCredential: null,
                  tokenCredential: credential)
        {
            Errors.VerifyHttpsTokenAuth(queueUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClient"/>
        /// class.
        /// </summary>
        /// <param name="queueUri">
        /// A <see cref="Uri"/> referencing the queue that includes the
        /// name of the account, and the name of the queue.
        /// This is likely to be similar to "https://{account_name}.queue.core.windows.net/{queue_name}".
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
        internal QueueClient(
            Uri queueUri,
            HttpPipelinePolicy authentication,
            QueueClientOptions options,
            StorageSharedKeyCredential sharedKeyCredential,
            AzureSasCredential sasCredential,
            TokenCredential tokenCredential)
        {
            Argument.AssertNotNull(queueUri, nameof(queueUri));
            _uri = queueUri;
            _messagesUri = queueUri.AppendToPath(Constants.Queue.MessagesUri);
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

            (QueueRestClient queueRestClient, MessagesRestClient messagesRestClient, MessageIdRestClient messageIdRestClient) = BuildRestClients();
            _queueRestClient = queueRestClient;
            _messagesRestClient = messagesRestClient;
            _messageIdRestClient = messageIdRestClient;

            AssertEncodingForEncryption();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClient"/>
        /// class.
        /// </summary>
        /// <param name="queueUri">
        /// A <see cref="Uri"/> referencing the queue that includes the
        /// name of the account, and the name of the queue.
        /// This is likely to be similar to "https://{account_name}.queue.core.windows.net/{queue_name}".
        /// </param>
        /// <param name="clientConfiguration">
        /// <see cref="QueueClientConfiguration"/>.
        /// </param>
        internal QueueClient(
            Uri queueUri,
            QueueClientConfiguration clientConfiguration)
        {
            _uri = queueUri;
            _messagesUri = queueUri.AppendToPath(Constants.Queue.MessagesUri);
            _clientConfiguration = clientConfiguration;

            (QueueRestClient, MessagesRestClient, MessageIdRestClient) clients = BuildRestClients();
            _queueRestClient = clients.Item1;
            _messagesRestClient = clients.Item2;
            _messageIdRestClient = clients.Item3;

            AssertEncodingForEncryption();
        }

        private (QueueRestClient QueueClient, MessagesRestClient MessagesClient, MessageIdRestClient MessageIdClient) BuildRestClients()
        {
            QueueRestClient queueRestClient = new QueueRestClient(
                _clientConfiguration.ClientDiagnostics,
                _clientConfiguration.Pipeline,
                _uri.AbsoluteUri,
                _clientConfiguration.Version.ToVersionString());

            MessagesRestClient messagesRestClient = new MessagesRestClient(
                _clientConfiguration.ClientDiagnostics,
                _clientConfiguration.Pipeline,
                _uri.AbsoluteUri,
                _clientConfiguration.Version.ToVersionString());

            MessageIdRestClient messageIdRestClient = new MessageIdRestClient(
                _clientConfiguration.ClientDiagnostics,
                _clientConfiguration.Pipeline,
                _uri.AbsoluteUri,
                _clientConfiguration.Version.ToVersionString());

            return (queueRestClient, messagesRestClient, messageIdRestClient);
        }

        #endregion ctors

        /// <summary>
        /// Sets the various name fields if they are currently null.
        /// </summary>
        private void SetNameFieldsIfNull()
        {
            if (_name == null || _accountName == null)
            {
                var builder = new QueueUriBuilder(Uri);
                _name = builder.QueueName;
                _accountName = builder.AccountName;
            }
        }

        /// <summary>
        /// Creates a new instance of the <see cref="QueueClient"/> class, maintaining all the same
        /// internals but specifying new <see cref="ClientSideEncryptionOptions"/>.
        /// </summary>
        /// <param name="clientSideEncryptionOptions">New encryption options. Setting this to <code>default</code> will clear client-side encryption.</param>
        /// <returns>New instance with provided options and same internals otherwise.</returns>
        protected internal virtual QueueClient WithClientSideEncryptionOptionsCore(ClientSideEncryptionOptions clientSideEncryptionOptions)
        {
            QueueClientConfiguration queueClientConfiguration = new QueueClientConfiguration(
                ClientConfiguration.Pipeline,
                ClientConfiguration.SharedKeyCredential,
                ClientConfiguration.ClientDiagnostics,
                ClientConfiguration.Version,
                QueueClientSideEncryptionOptions.CloneFrom(clientSideEncryptionOptions),
                ClientConfiguration.MessageEncoding,
                ClientConfiguration.QueueMessageDecodingFailedHandlers);

            return new QueueClient(
                Uri,
                queueClientConfiguration);
        }

        #region Create
        /// <summary>
        /// Creates a queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-queue4">
        /// Create Queue</see>.
        /// </summary>
        /// <param name="metadata">
        /// Optional <see cref="Metadata"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response" />
        /// </returns>
        public virtual Response Create(
            Metadata metadata = default,
            CancellationToken cancellationToken = default) =>
            CreateInternal(
                metadata,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Creates a queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-queue4">
        /// Create Queue</see>.
        /// </summary>
        /// <param name="metadata">
        /// Optional <see cref="Metadata"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response"/>
        /// </returns>
        public virtual async Task<Response> CreateAsync(
            Metadata metadata = default,
            CancellationToken cancellationToken = default) =>
            await CreateInternal(
                metadata,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Creates a queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-queue4">
        /// Create Queue</see>.
        /// </summary>
        /// <param name="metadata">
        /// Optional <see cref="Metadata"/>.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <param name="operationName">
        /// Optional. To indicate if the name of the operation.
        /// </param>
        /// <returns>
        /// <see cref="Response"/>
        /// </returns>
        private async Task<Response> CreateInternal(
            Metadata metadata,
            bool async,
            CancellationToken cancellationToken,
            string operationName = default)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(Uri)}: {Uri}");

                operationName ??= $"{nameof(QueueClient)}.{nameof(Create)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);

                try
                {
                    scope.Start();
                    ResponseWithHeaders<QueueCreateHeaders> reponse;
                    if (async)
                    {
                        reponse = await _queueRestClient.CreateAsync(
                            metadata: metadata,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        reponse = _queueRestClient.Create(
                            metadata: metadata,
                            cancellationToken: cancellationToken);
                    }
                    return reponse.GetRawResponse();
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(QueueClient));
                    scope.Dispose();
                }
            }
        }
        #endregion Create

        #region CreateIfNotExists
        /// <summary>
        /// The <see cref="CreateIfNotExists"/>
        /// operation creates a new queue under the specified account.
        /// If the queue already exists, it is not changed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-queue4">
        /// Create Queue</see>.
        /// </summary>
        /// <param name="metadata">
        /// Optional custom metadata to set for this queue.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// If the queue does not already exist, a <see cref="Response"/>
        /// describing the newly created queue. If the queue already exists, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response CreateIfNotExists(
            Metadata metadata = default,
            CancellationToken cancellationToken = default) =>
            CreateIfNotExistsInternal(
                metadata,
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// The <see cref="CreateIfNotExistsAsync"/>
        /// operation creates a new queue under the specified account.
        /// If the queue already exists, it is not changed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-queue4">
        /// Create Queue</see>.
        /// </summary>
        /// <param name="metadata">
        /// Optional custom metadata to set for this queue.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// If the queue does not already exist, a <see cref="Response"/>
        /// describing the newly created queue. If the queue already exists, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> CreateIfNotExistsAsync(
            Metadata metadata = default,
            CancellationToken cancellationToken = default) =>
            await CreateIfNotExistsInternal(
                metadata,
                async: true,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CreateIfNotExistsInternal"/>
        /// operation creates a new queue under the specified account.
        /// If the queue already exists, it is not changed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-queue4">
        /// Create Queue</see>.
        /// </summary>
        /// <param name="metadata">
        /// Optional custom metadata to set for this queue.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// If the queue does not already exist, a <see cref="Response"/>
        /// describing the newly created queue. If the queue already exists, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response> CreateIfNotExistsInternal(
            Metadata metadata,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(metadata)}: {metadata}");
                Response response;
                try
                {
                    response = await CreateInternal(
                        metadata,
                        async,
                        cancellationToken,
                        $"{nameof(QueueClient)}.{nameof(CreateIfNotExists)}")
                        .ConfigureAwait(false);

                    if (response.Status == Constants.Queue.StatusCodeNoContent)
                    {
                        response = default;
                    }
                }
                catch (RequestFailedException storageRequestFailedException)
                when (storageRequestFailedException.ErrorCode == QueueErrorCode.QueueAlreadyExists)
                {
                    response = default;
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(QueueClient));
                }
                return response;
            }
        }
        #endregion CreateIfNotExists

        #region Exists
        /// <summary>
        /// The <see cref="Exists"/> operation can be called on a
        /// <see cref="QueueClient"/> to see if the associated queue
        /// exists on the storage account in the storage service.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns true if the queue exists.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<bool> Exists(
            CancellationToken cancellationToken = default) =>
            ExistsInternal(
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// The <see cref="ExistsAsync"/> operation can be called on a
        /// <see cref="QueueClient"/> to see if the associated queue
        /// exists on the storage account in the storage service.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns true if the queue exists.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<bool>> ExistsAsync(
            CancellationToken cancellationToken = default) =>
            await ExistsInternal(
                async: true,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="ExistsInternal"/> operation can be called on a
        /// <see cref="QueueClient"/> to see if the associated queue
        /// exists on the storage account in the storage service.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns true if the queue exists.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<bool>> ExistsInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");

                try
                {
                    Response<QueueProperties> response = await GetPropertiesInternal(
                        async: async,
                        operationName: $"{nameof(QueueClient)}.{nameof(Exists)}",
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return Response.FromValue(true, response.GetRawResponse());
                }
                catch (RequestFailedException storageRequestFailedException)
                when (storageRequestFailedException.ErrorCode == QueueErrorCode.QueueNotFound)
                {
                    return Response.FromValue(false, default);
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(QueueClient));
                }
            }
        }
        #endregion Exists

        #region DeleteIfExists
        /// <summary>
        /// The <see cref="DeleteIfExists"/> operation deletes the specified
        /// queue if it exists.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/delete-queue3">
        /// Delete Queue</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> Returns true if queue exists and was
        /// deleted, return false otherwise.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<bool> DeleteIfExists(
            CancellationToken cancellationToken = default) =>
            DeleteIfExistsInternal(
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// The <see cref="DeleteIfExistsAsync"/> operation deletes the specified
        /// queue if it exists.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/delete-queue3">
        /// Delete Queue</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> Returns true if queue exists and was
        /// deleted, return false otherwise.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<bool>> DeleteIfExistsAsync(
            CancellationToken cancellationToken = default) =>
            await DeleteIfExistsInternal(
                async: true,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DeleteIfExistsInternal"/> operation deletes the specified
        /// queue if it exists.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/delete-queue3">
        /// Delete Queue</see>.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> Returns true if queue exists and was
        /// deleted, return false otherwise.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<bool>> DeleteIfExistsInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");
                try
                {
                    Response response = await DeleteInternal(
                        async,
                        cancellationToken,
                        $"{nameof(QueueClient)}.{nameof(DeleteIfExists)}")
                        .ConfigureAwait(false);
                    return Response.FromValue(true, response);
                }
                catch (RequestFailedException storageRequestFailedException)
                when (storageRequestFailedException.ErrorCode == QueueErrorCode.QueueNotFound)
                {
                    return Response.FromValue(false, default);
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(QueueClient));
                }
            }
        }
        #endregion DeleteIfExists

        #region Delete
        /// <summary>
        /// Deletes a queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-queue3">
        /// Delete Queue</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response"/>
        /// </returns>
        public virtual Response Delete(
            CancellationToken cancellationToken = default) =>
            DeleteInternal(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Deletes a queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-queue3">
        /// Delete Queue</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response"/>
        /// </returns>
        public virtual async Task<Response> DeleteAsync(
            CancellationToken cancellationToken = default) =>
            await DeleteInternal(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Deletes a queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-queue3">
        /// Delete Queue</see>.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <param name="operationName">
        /// Optional. To indicate if the name of the operation.
        /// </param>
        /// <returns>
        /// <see cref="Response"/>
        /// </returns>
        private async Task<Response> DeleteInternal(
            bool async,
            CancellationToken cancellationToken,
            string operationName = default)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(Uri)}: {Uri}");

                operationName ??= $"{nameof(QueueClient)}.{nameof(Delete)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);
                try
                {
                    scope.Start();
                    ResponseWithHeaders<QueueDeleteHeaders> response;
                    if (async)
                    {
                        response = await _queueRestClient.DeleteAsync(
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = _queueRestClient.Delete(
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(QueueClient));
                    scope.Dispose();
                }
            }
        }
        #endregion Delete

        #region GetProperties
        /// <summary>
        /// Retrieves queue properties and user-defined metadata and properties on the specified queue.
        /// Metadata is associated with the queue as name-values pairs.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-queue-metadata">
        /// Get Queue Metadata</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{QueueProperties}"/>
        /// </returns>
        public virtual Response<QueueProperties> GetProperties(
            CancellationToken cancellationToken = default) =>
            GetPropertiesInternal(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Retrieves queue properties and user-defined metadata and properties on the specified queue.
        /// Metadata is associated with the queue as name-values pairs.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-queue-metadata">
        /// Get Queue Metadata</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{QueueProperties}"/>
        /// </returns>
        public virtual async Task<Response<QueueProperties>> GetPropertiesAsync(
            CancellationToken cancellationToken = default) =>
            await GetPropertiesInternal(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Retrieves queue properties and user-defined metadata and properties on the specified queue.
        /// Metadata is associated with the queue as name-values pairs.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-queue-metadata">
        /// Get Queue Metadata</see>.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <param name="operationName">
        /// Optional. To indicate if the name of the operation.
        /// </param>
        /// <returns>
        /// <see cref="Response{QueueProperties}"/>
        /// </returns>
        private async Task<Response<QueueProperties>> GetPropertiesInternal(
            bool async,
            CancellationToken cancellationToken,
            string operationName = default)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(Uri)}: {Uri}");

                operationName ??= $"{nameof(QueueClient)}.{nameof(GetProperties)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);
                try
                {
                    scope.Start();
                    ResponseWithHeaders<QueueGetPropertiesHeaders> response;
                    if (async)
                    {
                        response = await _queueRestClient.GetPropertiesAsync(
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = _queueRestClient.GetProperties(
                            cancellationToken: cancellationToken);
                    }

                    QueueProperties queueProperties = new QueueProperties
                    {
                        ApproximateMessagesCount = response.Headers.ApproximateMessagesCount.GetValueOrDefault(),
                        Metadata = response.Headers.Metadata
                    };

                    return Response.FromValue(
                        queueProperties,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(QueueClient));
                    scope.Dispose();
                }
            }
        }
        #endregion GetProperties

        #region SetMetadata
        /// <summary>
        /// Sets user-defined metadata on the specified queue. Metadata is associated with the queue as name-value pairs.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-queue-metadata">
        /// Set Queue Metadata</see>.
        /// </summary>
        /// <param name="metadata">
        /// <see cref="Metadata"/>
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response"/>
        /// </returns>
        public virtual Response SetMetadata(
            Metadata metadata,
            CancellationToken cancellationToken = default) =>
            SetMetadataInternal(
                metadata,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Sets user-defined metadata on the specified queue. Metadata is associated with the queue as name-value pairs.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-queue-metadata">
        /// Set Queue Metadata</see>.
        /// </summary>
        /// <param name="metadata">
        /// <see cref="Metadata"/>
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response"/>
        /// </returns>
        public virtual async Task<Response> SetMetadataAsync(
            Metadata metadata,
            CancellationToken cancellationToken = default) =>
            await SetMetadataInternal(
                metadata,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Sets user-defined metadata on the specified queue. Metadata is associated with the queue as name-value pairs.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-queue-metadata">
        /// Set Queue Metadata</see>.
        /// </summary>
        /// <param name="metadata">
        /// <see cref="Metadata"/>
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
        private async Task<Response> SetMetadataInternal(
            Metadata metadata,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(QueueClient)}.{nameof(SetMetadata)}");

                try
                {
                    ResponseWithHeaders<QueueSetMetadataHeaders> response;

                    scope.Start();

                    if (async)
                    {
                        response = await _queueRestClient.SetMetadataAsync(
                            metadata: metadata,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = _queueRestClient.SetMetadata(
                            metadata: metadata,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(QueueClient));
                    scope.Dispose();
                }
            }
        }
        #endregion SetMetadata

        #region GetAccessPolicy
        /// <summary>
        /// Returns details about any stored access policies specified on the queue that may be used with
        /// Shared Access Signatures.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-queue-acl">
        /// Get Queue ACL</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{T}"/> of <see cref="IEnumerable{SignedIdentifier}" />
        /// </returns>
        public virtual Response<IEnumerable<QueueSignedIdentifier>> GetAccessPolicy(
            CancellationToken cancellationToken = default) =>
            GetAccessPolicyInternal(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Returns details about any stored access policies specified on the queue that may be used with
        /// Shared Access Signatures.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-queue-acl">
        /// Get Queue ACL</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{T}"/> of <see cref="IEnumerable{SignedIdentifier}" />
        /// </returns>
        public virtual async Task<Response<IEnumerable<QueueSignedIdentifier>>> GetAccessPolicyAsync(
            CancellationToken cancellationToken = default) =>
            await GetAccessPolicyInternal(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Returns details about any stored access policies specified on the queue that may be used with
        /// Shared Access Signatures.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-queue-acl">
        /// Get Queue ACL</see>.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{T}"/> of <see cref="IEnumerable{SignedIdentifier}" />
        /// </returns>
        private async Task<Response<IEnumerable<QueueSignedIdentifier>>> GetAccessPolicyInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(QueueClient)}.{nameof(GetAccessPolicy)}");

                try
                {
                    ResponseWithHeaders<IReadOnlyList<QueueSignedIdentifier>, QueueGetAccessPolicyHeaders> response;
                    scope.Start();

                    if (async)
                    {
                        response = await _queueRestClient.GetAccessPolicyAsync(
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = _queueRestClient.GetAccessPolicy(
                            cancellationToken: cancellationToken);
                    }

                    IEnumerable<QueueSignedIdentifier> signedIdentifiers = response.Value.ToList();

                    return Response.FromValue(
                        signedIdentifiers,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(QueueClient));
                    scope.Dispose();
                }
            }
        }
        #endregion GetAccessPolicy

        #region SetAccessPolicy
        /// <summary>
        /// SetAccessPolicyAsync sets stored access policies for the queue that may be used with Shared Access Signatures.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-queue-acl">
        /// Set Queue ACL</see>.
        /// </summary>
        /// <param name="permissions">
        /// IEnumerable of <see cref="QueueSignedIdentifier"/>
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response"/>
        /// </returns>
        public virtual Response SetAccessPolicy(
            IEnumerable<QueueSignedIdentifier> permissions,
            CancellationToken cancellationToken = default) =>
            SetAccessPolicyInternal(
                permissions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// SetAccessPolicyAsync sets stored access policies for the queue that may be used with Shared Access Signatures.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-queue-acl">
        /// Set Queue ACL</see>.
        /// </summary>
        /// <param name="permissions">
        /// IEnumerable of <see cref="QueueSignedIdentifier"/>
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response"/>
        /// </returns>
        public virtual async Task<Response> SetAccessPolicyAsync(
            IEnumerable<QueueSignedIdentifier> permissions,
            CancellationToken cancellationToken = default) =>
            await SetAccessPolicyInternal(
                permissions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// SetAccessPolicyInternal sets stored access policies for the queue that may be used with Shared Access Signatures.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-queue-acl">
        /// Set Queue ACL</see>.
        /// </summary>
        /// <param name="permissions">
        /// IEnumerable of <see cref="QueueSignedIdentifier"/>
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
        private async Task<Response> SetAccessPolicyInternal(
            IEnumerable<QueueSignedIdentifier> permissions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(QueueClient)}.{nameof(SetAccessPolicy)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<QueueSetAccessPolicyHeaders> response;

                    if (async)
                    {
                        response = await _queueRestClient.SetAccessPolicyAsync(
                            queueAcl: permissions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = _queueRestClient.SetAccessPolicy(
                            queueAcl: permissions,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(QueueClient));
                    scope.Dispose();
                }
            }
        }
        #endregion SetAccessPolicy

        #region ClearMessages
        /// <summary>
        /// Deletes all messages from a queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/clear-messages">
        /// Clear Messages</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Response"/>
        /// </returns>
        public virtual Response ClearMessages(
            CancellationToken cancellationToken = default) =>
            ClearMessagesInternal(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Deletes all messages from a queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/clear-messages">
        /// Clear Messages</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Response"/>
        /// </returns>
        public virtual async Task<Response> ClearMessagesAsync(
            CancellationToken cancellationToken = default) =>
            await ClearMessagesInternal(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Deletes all messages from a queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/clear-messages">
        /// Clear Messages</see>.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Response"/>
        /// </returns>
        private async Task<Response> ClearMessagesInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"Uri: {MessagesUri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(QueueClient)}.{nameof(ClearMessages)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<MessagesClearHeaders> response;

                    if (async)
                    {
                        response = await _messagesRestClient.ClearAsync(
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = _messagesRestClient.Clear(
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(QueueClient));
                    scope.Dispose();
                }
            }
        }
        #endregion ClearMessages

        #region SendMessage
        /// <summary>
        /// Adds a new message to the back of a queue.
        ///
        /// A message must be in a format that can be included in an XML request with UTF-8 encoding.
        /// Otherwise <see cref="QueueClientOptions.MessageEncoding"/> option can be set to <see cref="QueueMessageEncoding.Base64"/> to handle non compliant messages.
        /// The encoded message can be up to 64 KiB in size for versions 2011-08-18 and newer, or 8 KiB in size for previous versions.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-message">
        /// Put Message</see>.
        /// </summary>
        /// <param name="messageText">
        /// Message text.
        /// </param>
        /// <returns>
        /// <see cref="Response{SendReceipt}"/>
        /// </returns>
        /// <remarks>
        /// This version of library does not encode message by default.
        /// <see cref="QueueMessageEncoding.Base64"/> was the default behavior in the prior v11 library.  See
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.storage.queue.cloudqueue.encodemessage?view=azure-dotnet-legacy">CloudQueue.EncodeMessage</see>.
        /// </remarks>
        public virtual Response<SendReceipt> SendMessage(string messageText) =>
            SendMessage(
                messageText,
                null); // Pass anything else so we don't recurse on this overload

        /// <summary>
        /// Adds a new message to the back of a queue.
        ///
        /// A message must be in a format that can be included in an XML request with UTF-8 encoding.
        /// Otherwise <see cref="QueueClientOptions.MessageEncoding"/> option can be set to <see cref="QueueMessageEncoding.Base64"/> to handle non compliant messages.
        /// The encoded message can be up to 64 KiB in size for versions 2011-08-18 and newer, or 8 KiB in size for previous versions.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-message">
        /// Put Message</see>.
        /// </summary>
        /// <param name="messageText">
        /// Message text.
        /// </param>
        /// <returns>
        /// <see cref="Response{SendReceipt}"/>
        /// </returns>
        /// <remarks>
        /// This version of library does not encode message by default.
        /// <see cref="QueueMessageEncoding.Base64"/> was the default behavior in the prior v11 library.  See
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.storage.queue.cloudqueue.encodemessage?view=azure-dotnet-legacy">CloudQueue.EncodeMessage</see>.
        /// </remarks>
        public virtual async Task<Response<SendReceipt>> SendMessageAsync(string messageText) =>
            await SendMessageAsync(
                messageText,
                null) // Pass anything else so we don't recurse on this overload
            .ConfigureAwait(false);

        /// <summary>
        /// Adds a new message to the back of a queue.
        ///
        /// A message must be in a format that can be included in an XML request with UTF-8 encoding.
        /// Otherwise <see cref="QueueClientOptions.MessageEncoding"/> option can be set to <see cref="QueueMessageEncoding.Base64"/> to handle non compliant messages.
        /// The encoded message can be up to 64 KiB in size for versions 2011-08-18 and newer, or 8 KiB in size for previous versions.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-message">
        /// Put Message</see>.
        /// </summary>
        /// <param name="messageText">
        /// Message text.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Response{SendReceipt}"/>
        /// </returns>
        /// <remarks>
        /// This version of library does not encode message by default.
        /// <see cref="QueueMessageEncoding.Base64"/> was the default behavior in the prior v11 library.  See
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.storage.queue.cloudqueue.encodemessage?view=azure-dotnet-legacy">CloudQueue.EncodeMessage</see>.
        /// </remarks>
        public virtual Response<SendReceipt> SendMessage(string messageText, CancellationToken cancellationToken = default) =>
            SendMessage(
                messageText,
                cancellationToken: cancellationToken,
                visibilityTimeout: default); // Pass anything else so we don't recurse on this overload

        /// <summary>
        /// Adds a new message to the back of a queue.
        ///
        /// A message must be in a format that can be included in an XML request with UTF-8 encoding.
        /// Otherwise <see cref="QueueClientOptions.MessageEncoding"/> option can be set to <see cref="QueueMessageEncoding.Base64"/> to handle non compliant messages.
        /// The encoded message can be up to 64 KiB in size for versions 2011-08-18 and newer, or 8 KiB in size for previous versions.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-message">
        /// Put Message</see>.
        /// </summary>
        /// <param name="messageText">
        /// Message text.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Response{SendReceipt}"/>
        /// </returns>
        /// <remarks>
        /// This version of library does not encode message by default.
        /// <see cref="QueueMessageEncoding.Base64"/> was the default behavior in the prior v11 library.  See
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.storage.queue.cloudqueue.encodemessage?view=azure-dotnet-legacy">CloudQueue.EncodeMessage</see>.
        /// </remarks>
        public virtual async Task<Response<SendReceipt>> SendMessageAsync(string messageText, CancellationToken cancellationToken = default) =>
            await SendMessageAsync(messageText,
                cancellationToken: cancellationToken,
                visibilityTimeout: default) // Pass anything else so we don't recurse on this overload
            .ConfigureAwait(false);

        /// <summary>
        /// Adds a new message to the back of a queue. The visibility timeout specifies how long the message should be invisible
        /// to Dequeue and Peek operations.
        ///
        /// A message must be in a format that can be included in an XML request with UTF-8 encoding.
        /// Otherwise <see cref="QueueClientOptions.MessageEncoding"/> option can be set to <see cref="QueueMessageEncoding.Base64"/> to handle non compliant messages.
        /// The encoded message can be up to 64 KiB in size for versions 2011-08-18 and newer, or 8 KiB in size for previous versions.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-message">
        /// Put Message</see>.
        /// </summary>
        /// <param name="messageText">
        /// Message text.
        /// </param>
        /// <param name="visibilityTimeout">
        /// Visibility timeout.  Optional with a default value of 0.  Cannot be larger than 7 days.
        /// </param>
        /// <param name="timeToLive">
        /// Optional. Specifies the time-to-live interval for the message
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Response{SendReceipt}"/>
        /// </returns>
        /// <remarks>
        /// This version of library does not encode message by default.
        /// <see cref="QueueMessageEncoding.Base64"/> was the default behavior in the prior v11 library.  See
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.storage.queue.cloudqueue.encodemessage?view=azure-dotnet-legacy">CloudQueue.EncodeMessage</see>.
        /// </remarks>
        public virtual Response<SendReceipt> SendMessage(
            string messageText,
            TimeSpan? visibilityTimeout = default,
            TimeSpan? timeToLive = default,
            CancellationToken cancellationToken = default) =>
            SendMessageInternal(
                ToBinaryData(messageText),
                visibilityTimeout,
                timeToLive,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Adds a new message to the back of a queue. The visibility timeout specifies how long the message should be invisible
        /// to Dequeue and Peek operations.
        ///
        /// A message must be in a format that can be included in an XML request with UTF-8 encoding.
        /// Otherwise <see cref="QueueClientOptions.MessageEncoding"/> option can be set to <see cref="QueueMessageEncoding.Base64"/> to handle non compliant messages.
        /// The encoded message can be up to 64 KiB in size for versions 2011-08-18 and newer, or 8 KiB in size for previous versions.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-message">
        /// Put Message</see>.
        /// </summary>
        /// <param name="message">
        /// Message.
        /// </param>
        /// <param name="visibilityTimeout">
        /// Visibility timeout.  Optional with a default value of 0.  Cannot be larger than 7 days.
        /// </param>
        /// <param name="timeToLive">
        /// Optional. Specifies the time-to-live interval for the message
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Response{SendReceipt}"/>
        /// </returns>
        /// <remarks>
        /// This version of library does not encode message by default.
        /// <see cref="QueueMessageEncoding.Base64"/> was the default behavior in the prior v11 library.  See
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.storage.queue.cloudqueue.encodemessage?view=azure-dotnet-legacy">CloudQueue.EncodeMessage</see>.
        /// </remarks>
        public virtual Response<SendReceipt> SendMessage(
            BinaryData message,
            TimeSpan? visibilityTimeout = default,
            TimeSpan? timeToLive = default,
            CancellationToken cancellationToken = default) =>
            SendMessageInternal(
                message,
                visibilityTimeout,
                timeToLive,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Adds a new message to the back of a queue. The visibility timeout specifies how long the message should be invisible
        /// to Dequeue and Peek operations.
        ///
        /// A message must be in a format that can be included in an XML request with UTF-8 encoding.
        /// Otherwise <see cref="QueueClientOptions.MessageEncoding"/> option can be set to <see cref="QueueMessageEncoding.Base64"/> to handle non compliant messages.
        /// The encoded message can be up to 64 KiB in size for versions 2011-08-18 and newer, or 8 KiB in size for previous versions.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-message">
        /// Put Message</see>.
        /// </summary>
        /// <param name="messageText">
        /// Message text.
        /// </param>
        /// <param name="visibilityTimeout">
        /// Visibility timeout.  Optional with a default value of 0.  Cannot be larger than 7 days.
        /// </param>
        /// <param name="timeToLive">
        /// Optional. Specifies the time-to-live interval for the message
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Response{SendReceipt}"/>
        /// </returns>
        /// <remarks>
        /// This version of library does not encode message by default.
        /// <see cref="QueueMessageEncoding.Base64"/> was the default behavior in the prior v11 library.  See
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.storage.queue.cloudqueue.encodemessage?view=azure-dotnet-legacy">CloudQueue.EncodeMessage</see>.
        /// </remarks>
        public virtual async Task<Response<SendReceipt>> SendMessageAsync(
            string messageText,
            TimeSpan? visibilityTimeout = default,
            TimeSpan? timeToLive = default,
            CancellationToken cancellationToken = default) =>
            await SendMessageInternal(
                ToBinaryData(messageText),
                visibilityTimeout,
                timeToLive,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Adds a new message to the back of a queue. The visibility timeout specifies how long the message should be invisible
        /// to Dequeue and Peek operations.
        ///
        /// A message must be in a format that can be included in an XML request with UTF-8 encoding.
        /// Otherwise <see cref="QueueClientOptions.MessageEncoding"/> option can be set to <see cref="QueueMessageEncoding.Base64"/> to handle non compliant messages.
        /// The encoded message can be up to 64 KiB in size for versions 2011-08-18 and newer, or 8 KiB in size for previous versions.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-message">
        /// Put Message</see>.
        /// </summary>
        /// <param name="message">
        /// Message.
        /// </param>
        /// <param name="visibilityTimeout">
        /// Visibility timeout.  Optional with a default value of 0.  Cannot be larger than 7 days.
        /// </param>
        /// <param name="timeToLive">
        /// Optional. Specifies the time-to-live interval for the message
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Response{SendReceipt}"/>
        /// </returns>
        /// <remarks>
        /// This version of library does not encode message by default.
        /// <see cref="QueueMessageEncoding.Base64"/> was the default behavior in the prior v11 library.  See
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.storage.queue.cloudqueue.encodemessage?view=azure-dotnet-legacy">CloudQueue.EncodeMessage</see>.
        /// </remarks>
        public virtual async Task<Response<SendReceipt>> SendMessageAsync(
            BinaryData message,
            TimeSpan? visibilityTimeout = default,
            TimeSpan? timeToLive = default,
            CancellationToken cancellationToken = default) =>
            await SendMessageInternal(
                message,
                visibilityTimeout,
                timeToLive,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Adds a new message to the back of a queue. The visibility timeout specifies how long the message should be invisible
        /// to Dequeue and Peek operations.
        ///
        /// A message must be in a format that can be included in an XML request with UTF-8 encoding.
        /// Otherwise <see cref="QueueClientOptions.MessageEncoding"/> option can be set to <see cref="QueueMessageEncoding.Base64"/> to handle non compliant messages.
        /// The encoded message can be up to 64 KiB in size for versions 2011-08-18 and newer, or 8 KiB in size for previous versions.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-message">
        /// Put Message</see>.
        /// </summary>
        /// <param name="message">
        /// Message text.
        /// </param>
        /// <param name="visibilityTimeout">
        /// Visibility timeout.  Optional with a default value of 0.  Cannot be larger than 7 days.
        /// </param>
        /// <param name="timeToLive">
        /// Optional. Specifies the time-to-live interval for the message
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>.
        /// </param>
        /// <param name="operationName">
        /// The name of the calling operation.
        /// </param>
        /// <returns>
        /// <see cref="Response{SendMessageResult}"/>
        /// </returns>
        /// <remarks>
        /// This version of library does not encode message by default.
        /// <see cref="QueueMessageEncoding.Base64"/> was the default behavior in the prior v11 library.  See
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.storage.queue.cloudqueue.encodemessage?view=azure-dotnet-legacy">CloudQueue.EncodeMessage</see>.
        /// </remarks>
        private async Task<Response<SendReceipt>> SendMessageInternal(
            BinaryData message,
            TimeSpan? visibilityTimeout,
            TimeSpan? timeToLive,
            bool async,
            CancellationToken cancellationToken,
            string operationName = default)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message:
                    $"Uri: {MessagesUri}\n" +
                    $"{nameof(visibilityTimeout)}: {visibilityTimeout}\n" +
                    $"{nameof(timeToLive)}: {timeToLive}");

                operationName ??= $"{nameof(QueueClient)}.{nameof(SendMessage)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);

                try
                {
                    scope.Start();

                    if (UsingClientSideEncryption)
                    {
                        IClientSideEncryptor encryptor = ClientConfiguration.ClientSideEncryption.EncryptionVersion switch
                        {
#pragma warning disable CS0618 // obsolete
                            ClientSideEncryptionVersion.V1_0 => new ClientSideEncryptorV1_0(ClientConfiguration.ClientSideEncryption),
#pragma warning restore CS0618 // obsolete
                            ClientSideEncryptionVersion.V2_0 => new ClientSideEncryptorV2_0(ClientConfiguration.ClientSideEncryption),
                            _ => throw new InvalidOperationException()
                        };
                        message = await new QueueClientSideEncryptor(encryptor)
                            .ClientSideEncryptInternal(message, async, cancellationToken).ConfigureAwait(false);
                    }

                    ResponseWithHeaders<IReadOnlyList<SendReceipt>, MessagesEnqueueHeaders> response;

                    if (async)
                    {
                        response = await _messagesRestClient.EnqueueAsync(
                            queueMessage: new QueueMessage { MessageText = QueueMessageCodec.EncodeMessageBody(message, ClientConfiguration.MessageEncoding) },
                            visibilitytimeout: (int?)visibilityTimeout?.TotalSeconds,
                            messageTimeToLive: (int?)timeToLive?.TotalSeconds,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = _messagesRestClient.Enqueue(
                            queueMessage: new QueueMessage { MessageText = QueueMessageCodec.EncodeMessageBody(message, ClientConfiguration.MessageEncoding) },
                            visibilitytimeout: (int?)visibilityTimeout?.TotalSeconds,
                            messageTimeToLive: (int?)timeToLive?.TotalSeconds,
                            cancellationToken: cancellationToken);
                    }

                    // The service returns a sequence of messages, but the
                    // sequence only ever has one value so we'll unwrap it
#pragma warning disable CA1826 // Do not use Enumerable methods on indexable collections
                    return Response.FromValue(response.Value.FirstOrDefault(), response.GetRawResponse());
#pragma warning restore CA1826 // Do not use Enumerable methods on indexable collections
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(QueueClient));
                    scope.Dispose();
                }
            }
        }
        #endregion SendMessage

        #region ReceiveMessages
        /// <summary>
        /// Receives one or more messages from the front of the queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-messages">
        /// Get Messages</see>.
        /// </summary>
        /// <returns>
        /// <see cref="Response{T}"/> where T is an array of <see cref="QueueMessage"/>
        /// </returns>
        public virtual Response<QueueMessage[]> ReceiveMessages() => ReceiveMessages(null); // Pass anything else so we don't recurse on this overload

        /// <summary>
        /// Retrieves one or more messages from the front of the queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-messages">
        /// Get Messages</see>.
        /// </summary>
        /// <returns>
        /// <see cref="Response{T}"/> where T is an array of <see cref="QueueMessage"/>
        /// </returns>
        public virtual async Task<Response<QueueMessage[]>> ReceiveMessagesAsync() =>
            await ReceiveMessagesAsync(null)  // Pass anything else so we don't recurse on this overload
            .ConfigureAwait(false);

        /// <summary>
        /// Receives one or more messages from the front of the queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-messages">
        /// Get Messages</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{T}"/> where T is an array of <see cref="QueueMessage"/>
        /// </returns>
        public virtual Response<QueueMessage[]> ReceiveMessages(CancellationToken cancellationToken = default) =>
            ReceiveMessages(
                cancellationToken: cancellationToken,
                visibilityTimeout: null); // Pass anything else so we don't recurse on this overload

        /// <summary>
        /// Retrieves one or more messages from the front of the queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-messages">
        /// Get Messages</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{T}"/> where T is an array of <see cref="QueueMessage"/>
        /// </returns>
        public virtual async Task<Response<QueueMessage[]>> ReceiveMessagesAsync(CancellationToken cancellationToken = default) =>
            await ReceiveMessagesAsync(
                cancellationToken: cancellationToken,
                visibilityTimeout: null) // Pass anything else so we don't recurse on this overload
            .ConfigureAwait(false);

        /// <summary>
        /// Receives one or more messages from the front of the queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-messages">
        /// Get Messages</see>.
        /// </summary>
        /// <param name="maxMessages">
        /// Optional. A nonzero integer value that specifies the number of messages to retrieve from the queue, up to a maximum of 32.
        /// If fewer are visible, the visible messages are returned. By default, a single message is retrieved from the queue with this operation.
        /// </param>
        /// <param name="visibilityTimeout">
        /// Optional. Specifies the new visibility timeout value, in seconds, relative to server time. The default value is 30 seconds.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{T}"/> where T is an array of <see cref="QueueMessage"/>
        /// </returns>
        public virtual Response<QueueMessage[]> ReceiveMessages(
            int? maxMessages = default,
            TimeSpan? visibilityTimeout = default,
            CancellationToken cancellationToken = default) =>
            ReceiveMessagesInternal(
                maxMessages,
                visibilityTimeout,
                $"{nameof(QueueClient)}.{nameof(ReceiveMessages)}",
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Retrieves one or more messages from the front of the queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-messages">
        /// Get Messages</see>.
        /// </summary>
        /// <param name="maxMessages">
        /// Optional. A nonzero integer value that specifies the number of messages to retrieve from the queue, up to a maximum of 32.
        /// If fewer are visible, the visible messages are returned. By default, a single message is retrieved from the queue with this operation.
        /// </param>
        /// <param name="visibilityTimeout">
        /// Optional. Specifies the new visibility timeout value, in seconds, relative to server time. The default value is 30 seconds.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{T}"/> where T is an array of <see cref="QueueMessage"/>
        /// </returns>
        public virtual async Task<Response<QueueMessage[]>> ReceiveMessagesAsync(
            int? maxMessages = default,
            TimeSpan? visibilityTimeout = default,
            CancellationToken cancellationToken = default) =>
            await ReceiveMessagesInternal(
                maxMessages,
                visibilityTimeout,
                $"{nameof(QueueClient)}.{nameof(ReceiveMessages)}",
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Retrieves one or more messages from the front of the queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-messages">
        /// Get Messages</see>.
        /// </summary>
        /// <param name="maxMessages">
        /// Optional. A nonzero integer value that specifies the number of messages to retrieve from the queue, up to a maximum of 32.
        /// If fewer are visible, the visible messages are returned. By default, a single message is retrieved from the queue with this operation.
        /// </param>
        /// <param name="visibilityTimeout">
        /// Optional. Specifies the new visibility timeout value, in seconds, relative to server time. The default value is 30 seconds.
        /// </param>s
        /// <param name="operationName">
        /// The name of the calling operation.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Response{T}"/> where T is an array of <see cref="QueueMessage"/>
        /// </returns>
        private async Task<Response<QueueMessage[]>> ReceiveMessagesInternal(
            int? maxMessages,
            TimeSpan? visibilityTimeout,
            string operationName,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message:
                    $"Uri: {MessagesUri}\n" +
                    $"{nameof(maxMessages)}: {maxMessages}\n" +
                    $"{nameof(visibilityTimeout)}: {visibilityTimeout}");

                operationName ??= $"{nameof(QueueClient)}.{nameof(ReceiveMessages)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);
                try
                {
                    scope.Start();
                    ResponseWithHeaders<IReadOnlyList<DequeuedMessageItem>, MessagesDequeueHeaders> response;

                    if (async)
                    {
                        response = await _messagesRestClient.DequeueAsync(
                            numberOfMessages: maxMessages,
                            visibilitytimeout: (int?)visibilityTimeout?.TotalSeconds,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = _messagesRestClient.Dequeue(
                            numberOfMessages: maxMessages,
                            visibilitytimeout: (int?)visibilityTimeout?.TotalSeconds,
                            cancellationToken: cancellationToken);
                    }

                    // Return an exploding Response on 304
                    if (response.IsUnavailable())
                    {
                        return response.GetRawResponse().AsNoBodyResponse<QueueMessage[]>();
                    } else
                    {
                        QueueMessage[] queueMessages = await ToQueueMessagesWithInvalidMessageHandling(response.Value, async, cancellationToken).ConfigureAwait(false);

                        if (UsingClientSideEncryption)
                        {
                            return Response.FromValue(
                                await new QueueClientSideDecryptor(ClientConfiguration.ClientSideEncryption)
                                    .ClientSideDecryptMessagesInternal(queueMessages, async, cancellationToken).ConfigureAwait(false),
                                response.GetRawResponse());
                        }
                        else
                        {
                            return Response.FromValue(queueMessages, response.GetRawResponse());
                        }
                    }
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(QueueClient));
                    scope.Dispose();
                }
            }
        }

        private async Task<QueueMessage[]> ToQueueMessagesWithInvalidMessageHandling(
            IEnumerable<DequeuedMessageItem> dequeuedMessageItems,
            bool async,
            CancellationToken cancellationToken)
        {
            List<QueueMessage> queueMessages = new List<QueueMessage>();

            foreach (var dequeuedMessageItem in dequeuedMessageItems)
            {
                try
                {
                    queueMessages.Add(QueueMessage.ToQueueMessage(dequeuedMessageItem, ClientConfiguration.MessageEncoding));
                }
                catch (FormatException) when (ClientConfiguration.QueueMessageDecodingFailedHandlers != null)
                {
#pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                    await OnMessageDecodingFailedAsync(
                        QueueMessage.ToQueueMessage(dequeuedMessageItem, QueueMessageEncoding.None),
                        null,
                        !async,
                        cancellationToken).ConfigureAwait(false);
#pragma warning restore AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                }
            }

            return queueMessages.ToArray();
        }

        #endregion ReceiveMessages

        #region ReceiveMessage

        /// <summary>
        /// Receives one message from the front of the queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-messages">
        /// Get Messages</see>.
        /// </summary>
        /// <param name="visibilityTimeout">
        /// Optional. Specifies the new visibility timeout value, in seconds, relative to server time. The default value is 30 seconds.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{T}"/> where T is a <see cref="QueueMessage"/>
        /// </returns>
        public virtual Response<QueueMessage> ReceiveMessage(
            TimeSpan? visibilityTimeout = default,
            CancellationToken cancellationToken = default) =>
            ReceiveMessageInternal(
                visibilityTimeout,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Retrieves one message from the front of the queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-messages">
        /// Get Messages</see>.
        /// </summary>
        /// <param name="visibilityTimeout">
        /// Optional. Specifies the new visibility timeout value, in seconds, relative to server time. The default value is 30 seconds.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{T}"/> where T is a <see cref="QueueMessage"/>
        /// </returns>
        public virtual async Task<Response<QueueMessage>> ReceiveMessageAsync(
            TimeSpan? visibilityTimeout = default,
            CancellationToken cancellationToken = default) =>
            await ReceiveMessageInternal(
                visibilityTimeout,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Retrieves one message from the front of the queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-messages">
        /// Get Messages</see>.
        /// </summary>
        /// <param name="visibilityTimeout">
        /// Optional. Specifies the new visibility timeout value, in seconds, relative to server time. The default value is 30 seconds.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{T}"/> where T is a <see cref="QueueMessage"/>
        /// </returns>
        private async Task<Response<QueueMessage>> ReceiveMessageInternal(
            TimeSpan? visibilityTimeout,
            bool async,
            CancellationToken cancellationToken)
        {
            Response<QueueMessage[]> response = await ReceiveMessagesInternal(
                maxMessages: 1,
                visibilityTimeout: visibilityTimeout,
                operationName: $"{nameof(QueueClient)}.{nameof(ReceiveMessage)}",
                async: async,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            return Response.FromValue(response.Value.FirstOrDefault(), response.GetRawResponse());
        }
        #endregion ReceiveMessage

        #region PeekMessage
        /// <summary>
        /// Retrieves one message from the front of the queue but does not alter the visibility of the message.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/peek-messages">
        /// Peek Messages</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{T}"/> where T is a <see cref="PeekedMessage"/>. Returns null if there are no messages in the queue.
        /// </returns>
        public virtual Response<PeekedMessage> PeekMessage(
            CancellationToken cancellationToken = default) =>
            PeekMessageInternal(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Retrieves one message from the front of the queue but does not alter the visibility of the message.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/peek-messages">
        /// Peek Messages</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{T}"/> where T is a <see cref="PeekedMessage"/>. Returns null if there are no messages in the queue.
        /// </returns>
        public virtual async Task<Response<PeekedMessage>> PeekMessageAsync(
            CancellationToken cancellationToken = default) =>
            await PeekMessageInternal(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Retrieves one message from the front of the queue but does not alter the visibility of the message.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/peek-messages">
        /// Peek Messages</see>.
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{T}"/> where T is a <see cref="PeekedMessage"/>
        /// </returns>
        private async Task<Response<PeekedMessage>> PeekMessageInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            var response = await PeekMessagesInternal(1, async, cancellationToken, $"{nameof(QueueClient)}.{nameof(PeekMessage)}").ConfigureAwait(false);
            var message = response.Value.FirstOrDefault();
            var rawResonse = response.GetRawResponse();
            return Response.FromValue(message, rawResonse);
        }
        #endregion PeekMessage

        #region PeekMessages
        /// <summary>
        /// Retrieves one or more messages from the front of the queue but does not alter the visibility of the message.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/peek-messages">
        /// Peek Messages</see>.
        /// </summary>
        /// <param name="maxMessages">
        /// Optional. A nonzero integer value that specifies the number of messages to peek from the queue, up to a maximum of 32.
        /// By default, a single message is peeked from the queue with this operation.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{T}"/> where T is an array of <see cref="PeekedMessage"/>
        /// </returns>
        public virtual Response<PeekedMessage[]> PeekMessages(
            int? maxMessages = default,
            CancellationToken cancellationToken = default) =>
            PeekMessagesInternal(
                maxMessages,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Retrieves one or more messages from the front of the queue but does not alter the visibility of the message.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/peek-messages">
        /// Peek Messages</see>.
        /// </summary>
        /// <param name="maxMessages">
        /// Optional. A nonzero integer value that specifies the number of messages to peek from the queue, up to a maximum of 32.
        /// By default, a single message is peeked from the queue with this operation.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{T}"/> where T is an array of <see cref="PeekedMessage"/>
        /// </returns>
        public virtual async Task<Response<PeekedMessage[]>> PeekMessagesAsync(
            int? maxMessages = default,
            CancellationToken cancellationToken = default) =>
            await PeekMessagesInternal(
                maxMessages,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Retrieves one or more messages from the front of the queue but does not alter the visibility of the message.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/peek-messages">
        /// Peek Messages</see>.
        /// </summary>
        /// <param name="maxMessages">
        /// Optional. A nonzero integer value that specifies the number of messages to peek from the queue, up to a maximum of 32.
        /// By default, a single message is peeked from the queue with this operation.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>
        /// </param>
        /// <param name="operationName">
        /// The name of the calling operation.
        /// </param>
        /// <returns>
        /// <see cref="Response{T}"/> where T is an array of <see cref="PeekedMessage"/>
        /// </returns>
        private async Task<Response<PeekedMessage[]>> PeekMessagesInternal(
            int? maxMessages,
            bool async,
            CancellationToken cancellationToken,
            string operationName = null)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message:
                    $"Uri: {MessagesUri}\n" +
                    $"{nameof(maxMessages)}: {maxMessages}");

                operationName ??= $"{nameof(QueueClient)}.{nameof(PeekMessages)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);
                try
                {
                    scope.Start();
                    ResponseWithHeaders<IReadOnlyList<PeekedMessageItem>, MessagesPeekHeaders> response;

                    if (async)
                    {
                        response = await _messagesRestClient.PeekAsync(
                            numberOfMessages: maxMessages,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = _messagesRestClient.Peek(
                            numberOfMessages: maxMessages,
                            cancellationToken: cancellationToken);
                    }

                    // Return an exploding Response on 304
                    if (response.IsUnavailable())
                    {
                        return response.GetRawResponse().AsNoBodyResponse<PeekedMessage[]>();
                    }
                    else
                    {
                        PeekedMessage[] peekedMessages = await ToPeekedMessagesWithInvalidMessageHandling(response.Value, async, cancellationToken).ConfigureAwait(false);

                        if (UsingClientSideEncryption)
                        {
                            return Response.FromValue(
                                await new QueueClientSideDecryptor(ClientConfiguration.ClientSideEncryption)
                                    .ClientSideDecryptMessagesInternal(peekedMessages, async, cancellationToken).ConfigureAwait(false),
                                response.GetRawResponse());
                        }
                        else
                        {
                            return Response.FromValue(peekedMessages, response.GetRawResponse());
                        }
                    }
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(QueueClient));
                    scope.Dispose();
                }
            }
        }

        private async Task<PeekedMessage[]> ToPeekedMessagesWithInvalidMessageHandling(
            IEnumerable<PeekedMessageItem> peekedMessageItems,
            bool async,
            CancellationToken cancellationToken)
        {
            List<PeekedMessage> peekedMessages = new List<PeekedMessage>();

            foreach (var peekedMessageItem in peekedMessageItems)
            {
                try
                {
                    peekedMessages.Add(PeekedMessage.ToPeekedMessage(peekedMessageItem, ClientConfiguration.MessageEncoding));
                }
                catch (FormatException) when (ClientConfiguration.QueueMessageDecodingFailedHandlers != null)
                {
#pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                    await OnMessageDecodingFailedAsync(
                        null,
                        PeekedMessage.ToPeekedMessage(peekedMessageItem, QueueMessageEncoding.None),
                        !async,
                        cancellationToken).ConfigureAwait(false);
#pragma warning restore AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                }
            }

            return peekedMessages.ToArray();
        }

        #endregion PeekMessages

        /// <summary>
        /// Get the URI to a specific message given its ID.
        /// </summary>
        /// <param name="messageId">ID of the message.</param>
        /// <returns>URI to the given message.</returns>
        private Uri GetMessageUri(string messageId) =>
            MessagesUri.AppendToPath(messageId.ToString(CultureInfo.InvariantCulture));

        #region DeleteMessage
        /// <summary>
        /// Permanently removes the specified message from its queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-message2">
        /// Delete Message</see>.
        /// </summary>
        /// <param name="messageId">ID of the message to delete.</param>
        /// <param name="popReceipt">
        /// Required. A valid pop receipt value returned from an earlier call to the Get Messages or Update Message operation.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Response"/>.
        /// </returns>
        public virtual Response DeleteMessage(
            string messageId,
            string popReceipt,
            CancellationToken cancellationToken = default) =>
            DeleteMessageInternal(
                messageId,
                popReceipt,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Permanently removes the specified message from its queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-message2">
        /// Delete Message</see>.
        /// </summary>
        /// <param name="messageId">ID of the message to delete.</param>
        /// <param name="popReceipt">
        /// Required. A valid pop receipt value returned from an earlier call to the Get Messages or Update Message operation.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Response"/>.
        /// </returns>
        public virtual async Task<Response> DeleteMessageAsync(
            string messageId,
            string popReceipt,
            CancellationToken cancellationToken = default) =>
            await DeleteMessageInternal(
                messageId,
                popReceipt,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Permanently removes the specified message from its queue.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-message2">
        /// Delete Message</see>.
        /// </summary>
        /// <param name="messageId">ID of the message to delete.</param>
        /// <param name="popReceipt">
        /// Required. A valid pop receipt value returned from an earlier call to the Get Messages or Update Message operation.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Response"/>.
        /// </returns>
        private async Task<Response> DeleteMessageInternal(
            string messageId,
            string popReceipt,
            bool async,
            CancellationToken cancellationToken)
        {
            Uri uri = GetMessageUri(messageId);
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message:
                    $"Uri: {uri}\n" +
                    $"{nameof(popReceipt)}: {popReceipt}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(QueueClient)}.{nameof(DeleteMessage)}");

                try
                {
                    ResponseWithHeaders<MessageIdDeleteHeaders> response;
                    scope.Start();

                    if (async)
                    {
                        response = await _messageIdRestClient.DeleteAsync(
                            messageid: messageId,
                            popReceipt: popReceipt,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = _messageIdRestClient.Delete(
                            messageid: messageId,
                            popReceipt: popReceipt,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(QueueClient));
                    scope.Dispose();
                }
            }
        }
        #endregion DeleteMessage

        #region UpdateMessage
        /// <summary>
        /// Changes a message's visibility timeout and contents.
        ///
        /// A message must be in a format that can be included in an XML request with UTF-8 encoding.
        /// Otherwise <see cref="QueueClientOptions.MessageEncoding"/> option can be set to <see cref="QueueMessageEncoding.Base64"/> to handle non compliant messages.
        /// The encoded message can be up to 64 KiB in size for versions 2011-08-18 and newer, or 8 KiB in size for previous versions.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/update-message">
        /// Update Message</see>.
        /// </summary>
        /// <param name="messageId">ID of the message to update.</param>
        /// <param name="popReceipt">
        /// Required. Specifies the valid pop receipt value returned from an earlier call to the Get Messages or Update Message operation.
        /// </param>
        /// <param name="messageText">
        /// Optional. Updated message text.
        /// </param>
        /// <param name="visibilityTimeout">
        /// Required. Specifies the new visibility timeout value, in seconds, relative to server time. The new value must be larger than
        /// or equal to 0, and cannot be larger than 7 days. The visibility timeout of a message cannot be set to a value later than the
        /// expiry time. A message can be updated until it has been deleted or has expired.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Response{UpdateReceipt}"/>.
        /// </returns>
        /// <remarks>
        /// This version of library does not encode message by default.
        /// <see cref="QueueMessageEncoding.Base64"/> was the default behavior in the prior v11 library.  See
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.storage.queue.cloudqueue.encodemessage?view=azure-dotnet-legacy">CloudQueue.EncodeMessage</see>.
        /// </remarks>
        public virtual Response<UpdateReceipt> UpdateMessage(
            string messageId,
            string popReceipt,
            string messageText = null,
            TimeSpan visibilityTimeout = default,
            CancellationToken cancellationToken = default) =>
            UpdateMessageInternal(
                ToBinaryData(messageText),
                messageId,
                popReceipt,
                visibilityTimeout,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Changes a message's visibility timeout and contents.
        ///
        /// A message must be in a format that can be included in an XML request with UTF-8 encoding.
        /// Otherwise <see cref="QueueClientOptions.MessageEncoding"/> option can be set to <see cref="QueueMessageEncoding.Base64"/> to handle non compliant messages.
        /// The encoded message can be up to 64 KiB in size for versions 2011-08-18 and newer, or 8 KiB in size for previous versions.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/update-message">
        /// Update Message</see>.
        /// </summary>
        /// <param name="messageId">ID of the message to update.</param>
        /// <param name="popReceipt">
        /// Required. Specifies the valid pop receipt value returned from an earlier call to the Get Messages or Update Message operation.
        /// </param>
        /// <param name="message">
        /// Optional. Updated message.
        /// </param>
        /// <param name="visibilityTimeout">
        /// Required. Specifies the new visibility timeout value, in seconds, relative to server time. The new value must be larger than
        /// or equal to 0, and cannot be larger than 7 days. The visibility timeout of a message cannot be set to a value later than the
        /// expiry time. A message can be updated until it has been deleted or has expired.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Response{UpdateReceipt}"/>.
        /// </returns>
        /// <remarks>
        /// This version of library does not encode message by default.
        /// <see cref="QueueMessageEncoding.Base64"/> was the default behavior in the prior v11 library.  See
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.storage.queue.cloudqueue.encodemessage?view=azure-dotnet-legacy">CloudQueue.EncodeMessage</see>.
        /// </remarks>
        public virtual Response<UpdateReceipt> UpdateMessage(
            string messageId,
            string popReceipt,
            BinaryData message,
            TimeSpan visibilityTimeout = default,
            CancellationToken cancellationToken = default) =>
            UpdateMessageInternal(
                message,
                messageId,
                popReceipt,
                visibilityTimeout,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Changes a message's visibility timeout and contents.
        ///
        /// A message must be in a format that can be included in an XML request with UTF-8 encoding.
        /// Otherwise <see cref="QueueClientOptions.MessageEncoding"/> option can be set to <see cref="QueueMessageEncoding.Base64"/> to handle non compliant messages.
        /// The encoded message can be up to 64 KiB in size for versions 2011-08-18 and newer, or 8 KiB in size for previous versions.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/update-message">
        /// Update Message</see>.
        /// </summary>
        /// <param name="messageId">ID of the message to update.</param>
        /// <param name="popReceipt">
        /// Required. Specifies the valid pop receipt value returned from an earlier call to the Get Messages or Update Message operation.
        /// </param>
        /// <param name="messageText">
        /// Optional. Updated message text.
        /// </param>
        /// <param name="visibilityTimeout">
        /// Required. Specifies the new visibility timeout value, in seconds, relative to server time. The new value must be larger than
        /// or equal to 0, and cannot be larger than 7 days. The visibility timeout of a message cannot be set to a value later than the
        /// expiry time. A message can be updated until it has been deleted or has expired.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Response{UpdateReceipt}"/>.
        /// </returns>
        /// <remarks>
        /// This version of library does not encode message by default.
        /// <see cref="QueueMessageEncoding.Base64"/> was the default behavior in the prior v11 library.  See
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.storage.queue.cloudqueue.encodemessage?view=azure-dotnet-legacy">CloudQueue.EncodeMessage</see>.
        /// </remarks>
        public virtual async Task<Response<UpdateReceipt>> UpdateMessageAsync(
            string messageId,
            string popReceipt,
            string messageText = null,
            TimeSpan visibilityTimeout = default,
            CancellationToken cancellationToken = default) =>
            await UpdateMessageInternal(
                ToBinaryData(messageText),
                messageId,
                popReceipt,
                visibilityTimeout,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Changes a message's visibility timeout and contents.
        ///
        /// A message must be in a format that can be included in an XML request with UTF-8 encoding.
        /// Otherwise <see cref="QueueClientOptions.MessageEncoding"/> option can be set to <see cref="QueueMessageEncoding.Base64"/> to handle non compliant messages.
        /// The encoded message can be up to 64 KiB in size for versions 2011-08-18 and newer, or 8 KiB in size for previous versions.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/update-message">
        /// Update Message</see>.
        /// </summary>
        /// <param name="messageId">ID of the message to update.</param>
        /// <param name="popReceipt">
        /// Required. Specifies the valid pop receipt value returned from an earlier call to the Get Messages or Update Message operation.
        /// </param>
        /// <param name="message">
        /// Optional. Updated message.
        /// </param>
        /// <param name="visibilityTimeout">
        /// Required. Specifies the new visibility timeout value, in seconds, relative to server time. The new value must be larger than
        /// or equal to 0, and cannot be larger than 7 days. The visibility timeout of a message cannot be set to a value later than the
        /// expiry time. A message can be updated until it has been deleted or has expired.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Response{UpdateReceipt}"/>.
        /// </returns>
        /// <remarks>
        /// This version of library does not encode message by default.
        /// <see cref="QueueMessageEncoding.Base64"/> was the default behavior in the prior v11 library.  See
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.storage.queue.cloudqueue.encodemessage?view=azure-dotnet-legacy">CloudQueue.EncodeMessage</see>.
        /// </remarks>
        public virtual async Task<Response<UpdateReceipt>> UpdateMessageAsync(
            string messageId,
            string popReceipt,
            BinaryData message,
            TimeSpan visibilityTimeout = default,
            CancellationToken cancellationToken = default) =>
            await UpdateMessageInternal(
                message,
                messageId,
                popReceipt,
                visibilityTimeout,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Changes a message's visibility timeout and contents.
        ///
        /// A message must be in a format that can be included in an XML request with UTF-8 encoding.
        /// Otherwise <see cref="QueueClientOptions.MessageEncoding"/> option can be set to <see cref="QueueMessageEncoding.Base64"/> to handle non compliant messages.
        /// The encoded message can be up to 64 KiB in size for versions 2011-08-18 and newer, or 8 KiB in size for previous versions.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/update-message">
        /// Update Message</see>.
        /// </summary>
        /// <param name="message">
        /// Updated message.
        /// </param>
        /// <param name="messageId">ID of the message to update.</param>
        /// <param name="popReceipt">
        /// Required. Specifies the valid pop receipt value returned from an earlier call to the Get Messages or Update Message operation.
        /// </param>
        /// <param name="visibilityTimeout">
        /// Required. Specifies the new visibility timeout value, in seconds, relative to server time. The new value must be larger than
        /// or equal to 0, and cannot be larger than 7 days. The visibility timeout of a message cannot be set to a value later than the
        /// expiry time. A message can be updated until it has been deleted or has expired.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>.
        /// </param>
        /// <param name="operationName">
        /// The name of the calling operatation.
        /// </param>
        /// <returns>
        /// <see cref="Response{UpdateReceipt}"/>.
        /// </returns>
        /// <remarks>
        /// This version of library does not encode message by default.
        /// <see cref="QueueMessageEncoding.Base64"/> was the default behavior in the prior v11 library.  See
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.storage.queue.cloudqueue.encodemessage?view=azure-dotnet-legacy">CloudQueue.EncodeMessage</see>.
        /// </remarks>
        private async Task<Response<UpdateReceipt>> UpdateMessageInternal(
            BinaryData message,
            string messageId,
            string popReceipt,
            TimeSpan visibilityTimeout,
            bool async,
            CancellationToken cancellationToken,
            string operationName = null)
        {
            Uri uri = GetMessageUri(messageId);
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message:
                    $"Uri: {uri}\n" +
                    $"{nameof(popReceipt)}: {popReceipt}" +
                    $"{nameof(visibilityTimeout)}: {visibilityTimeout}");

                operationName ??= $"{nameof(QueueClient)}.{nameof(UpdateMessage)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);

                try
                {
                    scope.Start();
                    if (UsingClientSideEncryption)
                    {
                        IClientSideEncryptor encryptor = ClientConfiguration.ClientSideEncryption.EncryptionVersion switch
                        {
#pragma warning disable CS0618 // obsolete
                            ClientSideEncryptionVersion.V1_0 => new ClientSideEncryptorV1_0(ClientConfiguration.ClientSideEncryption),
#pragma warning restore CS0618 // obsolete
                            ClientSideEncryptionVersion.V2_0 => new ClientSideEncryptorV2_0(ClientConfiguration.ClientSideEncryption),
                            _ => throw new InvalidOperationException()
                        };
                        message = await new QueueClientSideEncryptor(encryptor)
                            .ClientSideEncryptInternal(message, async, cancellationToken).ConfigureAwait(false);
                    }
                    QueueMessage queueSendMessage = null;
                    if (message != null)
                    {
                        queueSendMessage = new QueueMessage { MessageText = QueueMessageCodec.EncodeMessageBody(message, ClientConfiguration.MessageEncoding) };
                    }

                    ResponseWithHeaders<MessageIdUpdateHeaders> response;

                    if (async)
                    {
                        response = await _messageIdRestClient.UpdateAsync(
                            messageid: messageId,
                            popReceipt: popReceipt,
                            visibilitytimeout: (int)visibilityTimeout.TotalSeconds,
                            queueMessage: queueSendMessage,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = _messageIdRestClient.Update(
                            messageid: messageId,
                            popReceipt: popReceipt,
                            visibilitytimeout: (int)visibilityTimeout.TotalSeconds,
                            queueMessage: queueSendMessage,
                            cancellationToken: cancellationToken);
                    }

                    UpdateReceipt updateReceipt = new UpdateReceipt
                    {
                        NextVisibleOn = response.Headers.TimeNextVisible.GetValueOrDefault(),
                        PopReceipt = response.Headers.PopReceipt
                    };

                    return Response.FromValue(
                        updateReceipt,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(QueueClient));
                    scope.Dispose();
                }
            }
        }
        #endregion UpdateMessage

        #region GenerateSas
        /// <summary>
        /// The <see cref="GenerateSasUri(QueueSasPermissions, DateTimeOffset)"/>
        /// returns a <see cref="Uri"/> that generates a Queue Service
        /// Shared Access Signature (SAS) Uri based on the Client properties
        /// and parameters passed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas">
        /// Constructing a Service SAS</see>.
        /// </summary>
        /// <param name="permissions">
        /// Required. Specifies the list of permissions to be associated with the SAS.
        /// See <see cref="QueueSasPermissions"/>.
        /// </param>
        /// <param name="expiresOn">
        /// Required. Specifies the time at which the SAS becomes invalid. This field
        /// must be omitted if it has been specified in an associated stored access policy.
        /// </param>
        /// <returns>
        /// A <see cref="QueueSasBuilder"/> on successfully deleting.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if a failure occurs.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-queues")]
        public virtual Uri GenerateSasUri(QueueSasPermissions permissions, DateTimeOffset expiresOn)
            => GenerateSasUri(new QueueSasBuilder(permissions, expiresOn) { QueueName = Name });

        /// <summary>
        /// The <see cref="GenerateSasUri(QueueSasBuilder)"/> returns a
        /// <see cref="Uri"/> that generates a Queue Service SAS Uri based
        /// on the Client properties and builder passed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas">
        /// Constructing a Service SAS</see>
        /// </summary>
        /// <param name="builder">
        /// Used to generate a Shared Access Signature (SAS)
        /// </param>
        /// <returns>
        /// A <see cref="QueueSasBuilder"/> on successfully deleting.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if a failure occurs.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-queues")]
        public virtual Uri GenerateSasUri(
            QueueSasBuilder builder)
        {
            builder = builder ?? throw Errors.ArgumentNull(nameof(builder));

            // Deep copy of builder so we don't modify the user's original DataLakeSasBuilder.
            builder = QueueSasBuilder.DeepCopy(builder);

            // Assigned builder's QueueName if it is null
            builder.QueueName ??= Name;

            if (!builder.QueueName.Equals(Name, StringComparison.InvariantCulture))
            {
                // TODO: throw proper exception for non-matching builder name
                // e.g. containerName doesn't match or leave the containerName in builder
                // should be left empty. Or should we always default to the client's ContainerName
                // and chug along if they don't match?
                throw Errors.SasNamesNotMatching(
                    nameof(builder.QueueName),
                    nameof(QueueSasBuilder),
                    nameof(Name));
            }
            QueueUriBuilder sasUri = new QueueUriBuilder(Uri)
            {
                Sas = builder.ToSasQueryParameters(ClientConfiguration.SharedKeyCredential)
            };
            return sasUri.ToUri();
        }
        #endregion

        #region Encoding
        private static BinaryData ToBinaryData(string input)
        {
            if (input == null)
            {
                return null;
            } else
            {
                return new BinaryData(input);
            }
        }

        private void AssertEncodingForEncryption()
        {
            if (UsingClientSideEncryption && ClientConfiguration.MessageEncoding != QueueMessageEncoding.None)
            {
                throw new ArgumentException($"{nameof(SpecializedQueueClientOptions)} requires {nameof(QueueMessageEncoding)}.{nameof(QueueMessageEncoding.None)}" +
                    $" if {nameof(SpecializedQueueClientOptions.ClientSideEncryption)} is enabled as encrypted payload is already Base64 encoded.");
            }
        }

        /// <summary>
        /// Raises <see cref="QueueClientOptions.MessageDecodingFailed"/> event.
        /// </summary>
        /// <param name="receivedMessage">The <see cref="QueueMessage"/> with raw body, if present.</param>
        /// <param name="peekedMessage">The <see cref="PeekedMessage"/> with raw body, if present.</param>
        /// <param name="isRunningSynchronously">A value indicating whether the event handler was invoked
        /// synchronously or asynchronously.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        protected virtual async Task OnMessageDecodingFailedAsync(QueueMessage receivedMessage, PeekedMessage peekedMessage,
            bool isRunningSynchronously, CancellationToken cancellationToken)
        {
            await ClientConfiguration.QueueMessageDecodingFailedHandlers.RaiseAsync(
                new QueueMessageDecodingFailedEventArgs(
                    queueClient: this,
                    receivedMessage: receivedMessage,
                    peekedMessage: peekedMessage,
                    isRunningSynchronously: isRunningSynchronously,
                    cancellationToken: cancellationToken),
                nameof(QueueClientOptions),
                nameof(QueueClientOptions.MessageDecodingFailed),
                ClientConfiguration.ClientDiagnostics).ConfigureAwait(false);
        }

        #endregion Encoding

        #region GetParentQueueServiceClientCore

        private QueueServiceClient _parentQueueServiceClient;

        /// <summary>
        /// Create a new <see cref="QueueServiceClient"/> that pointing to this <see cref="QueueClient"/>'s queue service.
        /// The new <see cref="QueueServiceClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="QueueClient"/>.
        /// </summary>
        /// <returns>A new <see cref="QueueServiceClient"/> instance.</returns>
        protected internal virtual QueueServiceClient GetParentQueueServiceClientCore()
        {
            if (_parentQueueServiceClient == null)
            {
                QueueUriBuilder queueUriBuilder = new QueueUriBuilder(Uri)
                {
                    // erase parameters unrelated to service
                    QueueName = null,
                };

                _parentQueueServiceClient = new QueueServiceClient(
                    queueUriBuilder.ToUri(),
                    ClientConfiguration);
            }

            return _parentQueueServiceClient;
        }
        #endregion
    }
}

namespace Azure.Storage.Queues.Specialized
{
    /// <summary>
    /// Add methods to <see cref="Queues"/> clients.
    /// </summary>
    public static partial class SpecializedQueueExtensions
    {
        /// <summary>
        /// Creates a new instance of the <see cref="QueueClient"/> class, maintaining all the same
        /// internals but specifying new <see cref="ClientSideEncryptionOptions"/>.
        /// </summary>
        /// <param name="client">Client to base off of.</param>
        /// <param name="clientSideEncryptionOptions">New encryption options. Setting this to <code>default</code> will clear client-side encryption.</param>
        /// <returns>New instance with provided options and same internals otherwise.</returns>
        public static QueueClient WithClientSideEncryptionOptions(this QueueClient client, ClientSideEncryptionOptions clientSideEncryptionOptions)
            => client.WithClientSideEncryptionOptionsCore(clientSideEncryptionOptions);

        /// <summary>
        /// Create a new <see cref="QueueServiceClient"/> that pointing to this <see cref="QueueClient"/>'s queue service.
        /// The new <see cref="QueueServiceClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="QueueClient"/>.
        /// </summary>
        /// <returns>A new <see cref="QueueServiceClient"/> instance.</returns>
        public static QueueServiceClient GetParentQueueServiceClient(this QueueClient client)
        {
            Argument.AssertNotNull(client, nameof(client));
            return client.GetParentQueueServiceClientCore();
        }
    }
}
