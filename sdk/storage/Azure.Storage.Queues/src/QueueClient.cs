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
using Azure.Storage.Cryptography;
using Azure.Storage.Queues.Models;
using Azure.Storage.Queues.Specialized;
using Azure.Storage.Sas;
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
        /// The <see cref="QueueClientSideEncryptionOptions"/> to be used when sending/receiving requests.
        /// </summary>
        private readonly QueueClientSideEncryptionOptions _clientSideEncryption;

        /// <summary>
        /// The <see cref="QueueClientSideEncryptionOptions"/> to be used when sending/receiving requests.
        /// </summary>
        internal virtual QueueClientSideEncryptionOptions ClientSideEncryption => _clientSideEncryption;

        internal bool UsingClientSideEncryption => ClientSideEncryption != default;

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

        private QueueMessageEncoding _messageEncoding;

        internal virtual QueueMessageEncoding MessageEncoding => _messageEncoding;

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
        public bool CanGenerateSasUri => SharedKeyCredential != null;

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
            var conn = StorageConnectionString.Parse(connectionString);
            var builder = new QueueUriBuilder(conn.QueueEndpoint)
            {
                QueueName = queueName
            };
            _uri = builder.ToUri();
            _messagesUri = _uri.AppendToPath(Constants.Queue.MessagesUri);
            options ??= new QueueClientOptions();
            _pipeline = options.Build(conn.Credentials);
            _version = options.Version;
            _clientDiagnostics = new ClientDiagnostics(options);
            _clientSideEncryption = QueueClientSideEncryptionOptions.CloneFrom(options._clientSideEncryptionOptions);
            _storageSharedKeyCredential = conn.Credentials as StorageSharedKeyCredential;
            _messageEncoding = options.MessageEncoding;
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
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public QueueClient(Uri queueUri, QueueClientOptions options = default)
            : this(queueUri, (HttpPipelinePolicy)null, options, null)
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
            : this(queueUri, credential.AsPolicy(), options, credential)
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
            : this(queueUri, credential.AsPolicy<QueueUriBuilder>(queueUri), options, null)
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
            : this(queueUri, credential.AsPolicy(), options, null)
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
        /// <param name="storageSharedKeyCredential">
        /// The shared key credential used to sign requests.
        /// </param>
        internal QueueClient(
            Uri queueUri,
            HttpPipelinePolicy authentication,
            QueueClientOptions options,
            StorageSharedKeyCredential storageSharedKeyCredential)
        {
            Argument.AssertNotNull(queueUri, nameof(queueUri));
            _uri = queueUri;
            _messagesUri = queueUri.AppendToPath(Constants.Queue.MessagesUri);
            options ??= new QueueClientOptions();
            _pipeline = options.Build(authentication);
            _version = options.Version;
            _clientDiagnostics = new ClientDiagnostics(options);
            _clientSideEncryption = QueueClientSideEncryptionOptions.CloneFrom(options._clientSideEncryptionOptions);
            _storageSharedKeyCredential = storageSharedKeyCredential;
            _messageEncoding = options.MessageEncoding;
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
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        /// <param name="storageSharedKeyCredential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="version">
        /// The version of the service to use when sending requests.
        /// </param>
        /// <param name="clientDiagnostics">
        /// The <see cref="ClientDiagnostics"/> instance used to create
        /// diagnostic scopes every request.
        /// </param>
        /// <param name="encryptionOptions">
        /// Options for client-side encryption.
        /// </param>
        /// <param name="messageEncoding">
        /// The encoding of the message sent over the wire.
        /// </param>
        internal QueueClient(
            Uri queueUri,
            HttpPipeline pipeline,
            StorageSharedKeyCredential storageSharedKeyCredential,
            QueueClientOptions.ServiceVersion version,
            ClientDiagnostics clientDiagnostics,
            ClientSideEncryptionOptions encryptionOptions,
            QueueMessageEncoding messageEncoding)
        {
            _uri = queueUri;
            _messagesUri = queueUri.AppendToPath(Constants.Queue.MessagesUri);
            _pipeline = pipeline;
            _storageSharedKeyCredential = storageSharedKeyCredential;
            _version = version;
            _clientDiagnostics = clientDiagnostics;
            _clientSideEncryption = QueueClientSideEncryptionOptions.CloneFrom(encryptionOptions);
            _messageEncoding = messageEncoding;
            AssertEncodingForEncryption();
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
            return new QueueClient(
                Uri,
                Pipeline,
                SharedKeyCredential,
                Version,
                ClientDiagnostics,
                clientSideEncryptionOptions,
                MessageEncoding);
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
            using (Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    return await QueueRestClient.Queue.CreateAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        metadata: metadata,
                        async: async,
                        operationName: operationName ?? $"{nameof(QueueClient)}.{nameof(Create)}",
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
                    Pipeline.LogMethodExit(nameof(QueueClient));
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
            using (Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                Pipeline.LogMethodEnter(
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
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(QueueClient));
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
            using (Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                Pipeline.LogMethodEnter(
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
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(QueueClient));
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
            using (Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                Pipeline.LogMethodEnter(
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
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(QueueClient));
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
            using (Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    return await QueueRestClient.Queue.DeleteAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        async: async,
                        operationName: operationName ?? $"{nameof(QueueClient)}.{nameof(Delete)}",
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
                    Pipeline.LogMethodExit(nameof(QueueClient));
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
            using (Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    return await QueueRestClient.Queue.GetPropertiesAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        async: async,
                        operationName: operationName ?? $"{nameof(QueueClient)}.{nameof(GetProperties)}",
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
                    Pipeline.LogMethodExit(nameof(QueueClient));
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
            using (Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    return await QueueRestClient.Queue.SetMetadataAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        metadata: metadata,
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
                    Pipeline.LogMethodExit(nameof(QueueClient));
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
            using (Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    return await QueueRestClient.Queue.GetAccessPolicyAsync(
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
                    Pipeline.LogMethodExit(nameof(QueueClient));
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
            using (Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(Uri)}: {Uri}");
                try
                {
                    return await QueueRestClient.Queue.SetAccessPolicyAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        version: Version.ToVersionString(),
                        permissions: permissions,
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
                    Pipeline.LogMethodExit(nameof(QueueClient));
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
            using (Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"Uri: {MessagesUri}");
                try
                {
                    return await QueueRestClient.Messages.ClearAsync(
                        ClientDiagnostics,
                        Pipeline,
                        MessagesUri,
                        version: Version.ToVersionString(),
                        async: async,
                        operationName: $"{nameof(QueueClient)}.{nameof(ClearMessages)}",
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
                    Pipeline.LogMethodExit(nameof(QueueClient));
                }
            }
        }
        #endregion ClearMessages

        #region SendMessage
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
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message:
                    $"Uri: {MessagesUri}\n" +
                    $"{nameof(visibilityTimeout)}: {visibilityTimeout}\n" +
                    $"{nameof(timeToLive)}: {timeToLive}");
                try
                {
                    if (UsingClientSideEncryption)
                    {
                        message = await new QueueClientSideEncryptor(new ClientSideEncryptor(ClientSideEncryption))
                            .ClientSideEncryptInternal(message, async, cancellationToken).ConfigureAwait(false);
                    }

                    Response<IEnumerable<SendReceipt>> messages =
                        await QueueRestClient.Messages.EnqueueAsync(
                            ClientDiagnostics,
                            Pipeline,
                            MessagesUri,
                            message: new QueueSendMessage { MessageText = QueueMessageCodec.EncodeMessageBody(message, _messageEncoding) },
                            version: Version.ToVersionString(),
                            visibilitytimeout: (int?)visibilityTimeout?.TotalSeconds,
                            messageTimeToLive: (int?)timeToLive?.TotalSeconds,
                            async: async,
                            operationName: $"{nameof(QueueClient)}.{nameof(SendMessage)}",
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    // The service returns a sequence of messages, but the
                    // sequence only ever has one value so we'll unwrap it
                    return Response.FromValue(messages.Value.FirstOrDefault(), messages.GetRawResponse());
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(QueueClient));
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
        /// </param>
        /// <param name="operationName">
        /// Operation name for diagnostic logging.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>
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
            using (Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message:
                    $"Uri: {MessagesUri}\n" +
                    $"{nameof(maxMessages)}: {maxMessages}\n" +
                    $"{nameof(visibilityTimeout)}: {visibilityTimeout}");
                try
                {
                    var response = await QueueRestClient.Messages.DequeueAsync(
                        ClientDiagnostics,
                        Pipeline,
                        MessagesUri,
                        version: Version.ToVersionString(),
                        numberOfMessages: maxMessages,
                        visibilitytimeout: (int?)visibilityTimeout?.TotalSeconds,
                        async: async,
                        operationName: operationName,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    // Return an exploding Response on 304
                    if (response.IsUnavailable())
                    {
                        return response.GetRawResponse().AsNoBodyResponse<QueueMessage[]>();
                    }
                    else if (UsingClientSideEncryption)
                    {
                        return Response.FromValue(
                            await new QueueClientSideDecryptor(ClientSideEncryption)
                                .ClientSideDecryptMessagesInternal(response.Value.Select(x => QueueMessage.ToQueueMessage(x, _messageEncoding)).ToArray(), async, cancellationToken).ConfigureAwait(false),
                            response.GetRawResponse());
                    }
                    else
                    {
                        return Response.FromValue(response.Value.Select(x => QueueMessage.ToQueueMessage(x, _messageEncoding)).ToArray(), response.GetRawResponse());
                    }
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(QueueClient));
                }
            }
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
            var response = await ReceiveMessagesInternal(
                1,
                visibilityTimeout,
                $"{nameof(QueueClient)}.{nameof(ReceiveMessage)}",
                async,
                cancellationToken).ConfigureAwait(false);
            var queueMessage = response.Value.FirstOrDefault();
            var rawResponse = response.GetRawResponse();
            return Response.FromValue(queueMessage, rawResponse);
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
        /// <see cref="Response{T}"/> where T is a <see cref="PeekedMessage"/>
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
        /// <see cref="Response{T}"/> where T is a <see cref="PeekedMessage"/>
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
            var response = await PeekMessagesInternal(1, $"{nameof(QueueClient)}.{nameof(PeekMessage)}", async, cancellationToken).ConfigureAwait(false);
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
                $"{nameof(QueueClient)}.{nameof(PeekMessages)}",
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
                $"{nameof(QueueClient)}.{nameof(PeekMessages)}",
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
        /// <param name="operationName">
        /// Operation name for diagnostic logging.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Response{T}"/> where T is an array of <see cref="PeekedMessage"/>
        /// </returns>
        private async Task<Response<PeekedMessage[]>> PeekMessagesInternal(
            int? maxMessages,
            string operationName,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message:
                    $"Uri: {MessagesUri}\n" +
                    $"{nameof(maxMessages)}: {maxMessages}");
                try
                {
                    Response<IEnumerable<PeekedMessageItem>> response = await QueueRestClient.Messages.PeekAsync(
                        ClientDiagnostics,
                        Pipeline,
                        MessagesUri,
                        version: Version.ToVersionString(),
                        numberOfMessages: maxMessages,
                        async: async,
                        operationName: operationName,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    // Return an exploding Response on 304
                    if (response.IsUnavailable())
                    {
                        return response.GetRawResponse().AsNoBodyResponse<PeekedMessage[]>();
                    }
                    else if (UsingClientSideEncryption)
                    {
                        return Response.FromValue(
                            await new QueueClientSideDecryptor(ClientSideEncryption)
                                .ClientSideDecryptMessagesInternal(response.Value.Select(x => PeekedMessage.ToPeekedMessage(x, _messageEncoding)).ToArray(), async, cancellationToken).ConfigureAwait(false),
                            response.GetRawResponse());
                    }
                    else
                    {
                        return Response.FromValue(response.Value.Select(x => PeekedMessage.ToPeekedMessage(x, _messageEncoding)).ToArray(), response.GetRawResponse());
                    }
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(QueueClient));
                }
            }
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
            using (Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message:
                    $"Uri: {uri}\n" +
                    $"{nameof(popReceipt)}: {popReceipt}");
                try
                {
                    return await QueueRestClient.MessageId.DeleteAsync(
                        ClientDiagnostics,
                        Pipeline,
                        uri,
                        popReceipt: popReceipt,
                        version: Version.ToVersionString(),
                        async: async,
                        operationName: $"{nameof(QueueClient)}.{nameof(DeleteMessage)}",
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
                    Pipeline.LogMethodExit(nameof(QueueClient));
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
            CancellationToken cancellationToken)
        {
            Uri uri = GetMessageUri(messageId);
            using (Pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message:
                    $"Uri: {uri}\n" +
                    $"{nameof(popReceipt)}: {popReceipt}" +
                    $"{nameof(visibilityTimeout)}: {visibilityTimeout}");
                try
                {
                    if (UsingClientSideEncryption)
                    {
                        message = await new QueueClientSideEncryptor(new ClientSideEncryptor(ClientSideEncryption))
                            .ClientSideEncryptInternal(message, async, cancellationToken).ConfigureAwait(false);
                    }
                    QueueSendMessage queueSendMessage = null;
                    if (message != null)
                    {
                        queueSendMessage = new QueueSendMessage { MessageText = QueueMessageCodec.EncodeMessageBody(message, _messageEncoding) };
                    }

                    return await QueueRestClient.MessageId.UpdateAsync(
                        ClientDiagnostics,
                        Pipeline,
                        uri,
                        message: queueSendMessage,
                        popReceipt: popReceipt,
                        visibilitytimeout: (int)visibilityTimeout.TotalSeconds,
                        version: Version.ToVersionString(),
                        async: async,
                        operationName: $"{nameof(QueueClient)}.{nameof(UpdateMessage)}",
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
                    Pipeline.LogMethodExit(nameof(QueueClient));
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
        public virtual Uri GenerateSasUri(
            QueueSasBuilder builder)
        {
            builder = builder ?? throw Errors.ArgumentNull(nameof(builder));
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
            QueueUriBuilder sasUri = new QueueUriBuilder(Uri);
            sasUri.Query = builder.ToSasQueryParameters(SharedKeyCredential).ToString();
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
            if (UsingClientSideEncryption && _messageEncoding != QueueMessageEncoding.None)
            {
                throw new ArgumentException($"{nameof(SpecializedQueueClientOptions)} requires {nameof(QueueMessageEncoding)}.{nameof(QueueMessageEncoding.None)}" +
                    $" if {nameof(SpecializedQueueClientOptions.ClientSideEncryption)} is enabled as encrypted payload is already Base64 encoded.");
            }
        }
        #endregion Encoding
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
    }
}
