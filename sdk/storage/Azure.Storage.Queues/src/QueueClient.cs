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
using Azure.Storage.Common;
using Azure.Storage.Queues.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

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
        private Uri _uri;

        /// <summary>
        /// The Uri endpoint used by the object's messages.
        /// </summary>
        private Uri _messagesUri;

        /// <summary>
        /// The Uri endpoint used by the object.
        /// </summary>
        public Uri Uri
        {
            get => this._uri;
            private set
            {
                this._uri = value;
                this._messagesUri = value.AppendToPath("messages");
            }
        }

        /// <summary>
        /// The HttpPipeline used to send REST requests.
        /// </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary>
        /// QueueMaxMessagesDequeue indicates the maximum number of messages
        /// you can retrieve with each call to Dequeue.
        /// </summary>
        public const int MaxMessagesDequeue = 32;

        /// <summary>
        /// QueueMaxMessagesPeek indicates the maximum number of messages
        /// you can retrieve with each call to Peek.
        /// </summary>
        public const int MaxMessagesPeek = MaxMessagesDequeue;

        /// <summary>
        /// QueueMessageMaxBytes indicates the maximum number of bytes allowed for a message's UTF-8 text.
        /// </summary>
        public const int MessageMaxBytes = 64 * Constants.KB;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClient"/>
        /// class.
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
        /// For more information, <see href="https://docs.microsoft.com/en-us/azure/storage/common/storage-configure-connection-string"/>.
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
        /// For more information, <see href="https://docs.microsoft.com/en-us/azure/storage/common/storage-configure-connection-string"/>.
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
            var builder =
                new QueueUriBuilder(conn.QueueEndpoint)
                {
                    QueueName = queueName
                };
            this.Uri = builder.ToUri();
            this._pipeline = (options ?? new QueueClientOptions()).Build(conn.Credentials);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClient"/>
        /// class.
        /// </summary>
        /// <param name="queueUri">
        /// A <see cref="Uri"/> referencing the queue that includes the
        /// name of the account, and the name of the queue.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public QueueClient(Uri queueUri, QueueClientOptions options = default)
            : this(queueUri, (HttpPipelinePolicy)null, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClient"/>
        /// class.
        /// </summary>
        /// <param name="queueUri">
        /// A <see cref="Uri"/> referencing the queue that includes the
        /// name of the account, and the name of the queue.
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
            : this(queueUri, credential.AsPolicy(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClient"/>
        /// class.
        /// </summary>
        /// <param name="queueUri">
        /// A <see cref="Uri"/> referencing the queue that includes the
        /// name of the account, and the name of the queue.
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
            : this(queueUri, credential.AsPolicy(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClient"/>
        /// class.
        /// </summary>
        /// <param name="queueUri">
        /// A <see cref="Uri"/> referencing the queue that includes the
        /// name of the account, and the name of the queue.
        /// </param>
        /// <param name="authentication">
        /// An optional authentication policy used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        internal QueueClient(Uri queueUri, HttpPipelinePolicy authentication, QueueClientOptions options)
        {
            this.Uri = queueUri;
            this._pipeline = (options ?? new QueueClientOptions()).Build(authentication);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClient"/>
        /// class.
        /// </summary>
        /// <param name="queueUri">
        /// A <see cref="Uri"/> referencing the queue that includes the
        /// name of the account, and the name of the queue.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        internal QueueClient(Uri queueUri, HttpPipeline pipeline)
        {
            this.Uri = queueUri;
            this._pipeline = pipeline;
        }

        /// <summary>
        /// Creates a queue.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-queue4"/>.
        /// </summary>
        /// <param name="metadata">
        /// Optional <see cref="Metadata"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Task{Response}"/>
        /// </returns>
        public virtual async Task<Response> CreateAsync(
            Metadata metadata = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await QueueRestClient.Queue.CreateAsync(
                        this._pipeline,
                        this.Uri,
                        metadata: metadata,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(QueueClient));
                }
            }
        }

        /// <summary>
        /// Deletes a queue.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/delete-queue3"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Task{Response}"/>
        /// </returns>
        public virtual async Task<Response> DeleteAsync(
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await QueueRestClient.Queue.DeleteAsync(
                        this._pipeline,
                        this.Uri,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(QueueClient));
                }
            }
        }

        /// <summary>
        /// Retrieves queue properties and user-defined metadata and properties on the specified queue.
        /// Metadata is associated with the queue as name-values pairs.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-queue-metadata"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Task{Response{QueueProperties}}"/>
        /// </returns>
        public virtual async Task<Response<QueueProperties>> GetPropertiesAsync(
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await QueueRestClient.Queue.GetPropertiesAsync(
                        this._pipeline,
                        this.Uri,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(QueueClient));
                }
            }
        }

        /// <summary>
        /// Sets user-defined metadata on the specified queue. Metadata is associated with the queue as name-value pairs.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-queue-metadata"/>.
        /// </summary>
        /// <param name="metadata">
        /// <see cref="Metadata"/>
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Task{Response}"/>
        /// </returns>
        public virtual async Task<Response> SetMetadataAsync(
            Metadata metadata,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await QueueRestClient.Queue.SetMetadataAsync(
                        this._pipeline,
                        this.Uri,
                        metadata: metadata,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(QueueClient));
                }
            }
        }

        /// <summary>
        /// Returns details about any stored access policies specified on the queue that may be used with
        /// Shared Access Signatures.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-queue-acl"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// IEnumerable of <see cref="Task{Response{IEnumerable{SignedIdentifier}}}"/>
        /// </returns>
        public virtual async Task<Response<IEnumerable<SignedIdentifier>>> GetAccessPolicyAsync(
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await QueueRestClient.Queue.GetAccessPolicyAsync(
                        this._pipeline,
                        this.Uri,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(QueueClient));
                }
            }
        }

        /// <summary>
        /// SetAccessPolicyAsync sets stored access policies for the queue that may be used with Shared Access Signatures.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-queue-acl"/>.
        /// </summary>
        /// <param name="permissions">
        /// IEnumerable of <see cref="SignedIdentifier"/>
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Task{Response}"/>
        /// </returns>
        public virtual async Task<Response> SetAccessPolicyAsync(
            IEnumerable<SignedIdentifier> permissions,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await QueueRestClient.Queue.SetAccessPolicyAsync(
                        this._pipeline,
                        this.Uri,
                        permissions: permissions,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(QueueClient));
                }
            }
        }

        /// <summary>
        /// Clear deletes all messages from a queue.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/clear-messages"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Task{Response}"/>
        /// </returns>
        public virtual async Task<Response> ClearMessagesAsync(
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"Uri: {this._messagesUri}");
                try
                {
                    return await QueueRestClient.Messages.ClearAsync(
                        this._pipeline,
                        this._messagesUri,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(QueueClient));
                }
            }
        }

        /// <summary>
        /// Adds a new message to the back of a queue. The visibility timeout specifies how long the message should be invisible
        /// to Dequeue and Peek operations. The message content must be a UTF-8 encoded string that is up to 64KB in size.
        /// For more information, see <see cref="https://docs.microsoft.com/en-us/rest/api/storageservices/put-message"/>.
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
        /// <see cref="Task{Response{EnqueuedMessage}}"/>
        /// </returns>
        public virtual async Task<Response<EnqueuedMessage>> EnqueueMessageAsync(
            string messageText,
            TimeSpan? visibilityTimeout = default,
            TimeSpan? timeToLive = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message:
                    $"Uri: {this._messagesUri}\n" +
                    $"{nameof(visibilityTimeout)}: {visibilityTimeout}\n" +
                    $"{nameof(timeToLive)}: {timeToLive}");
                try
                {
                    var messages =
                        await QueueRestClient.Messages.EnqueueAsync(
                            this._pipeline,
                            this._messagesUri,
                            message: new QueueMessage { MessageText = messageText },
                            visibilitytimeout: (int?)visibilityTimeout?.TotalSeconds,
                            messageTimeToLive: (int?)timeToLive?.TotalSeconds,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    // The service returns a sequence of messages, but the
                    // sequence only ever has one value so we'll unwrap it
                    return new Response<EnqueuedMessage>(
                        messages.GetRawResponse(),
                        messages.Value.FirstOrDefault());
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(QueueClient));
                }
            }
        }

        /// <summary>
        /// Retrieves one or more messages from the front of the queue.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-messages"/>.
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
        /// IEnumerable of <see cref="Task{Response{IEnumerable{DequeuedMessage}}}"/>.
        /// </returns>
        public virtual async Task<Response<IEnumerable<DequeuedMessage>>> DequeueMessagesAsync(
            int? maxMessages = default,
            TimeSpan? visibilityTimeout = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message:
                    $"Uri: {this._messagesUri}\n" +
                    $"{nameof(maxMessages)}: {maxMessages}\n" +
                    $"{nameof(visibilityTimeout)}: {visibilityTimeout}");
                try
                {
                    return await QueueRestClient.Messages.DequeueAsync(
                        this._pipeline,
                        this._messagesUri,
                        numberOfMessages: maxMessages,
                        visibilitytimeout: (int?)visibilityTimeout?.TotalSeconds,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(QueueClient));
                }
            }
        }

        /// <summary>
        /// Retrieves one or more messages from the front of the queue but does not alter the visibility of the message.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/peek-messages"/>.
        /// </summary>
        /// <param name="maxMessages">
        /// Optional. A nonzero integer value that specifies the number of messages to peek from the queue, up to a maximum of 32. 
        /// By default, a single message is peeked from the queue with this operation.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// IEnumerable of <see cref="Task{Response{IEnumerable{PeekedMessage}}}"/>.
        /// </returns>
        public virtual async Task<Response<IEnumerable<PeekedMessage>>> PeekMessagesAsync(
            int? maxMessages = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message:
                    $"Uri: {this._messagesUri}\n" +
                    $"{nameof(maxMessages)}: {maxMessages}");
                try
                {
                    return await QueueRestClient.Messages.PeekAsync(
                        this._pipeline,
                        this._messagesUri,
                        numberOfMessages: maxMessages,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(QueueClient));
                }
            }
        }

        /// <summary>
        /// Get the URI to a specific message given its ID.
        /// </summary>
        /// <param name="messageId">ID of the message.</param>
        /// <returns>URI to the given message.</returns>
        private Uri GetMessageUri(string messageId) =>
            this._messagesUri.AppendToPath(messageId.ToString(CultureInfo.InvariantCulture));

        /// <summary>
        /// Permanently removes the specified message from its queue.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/delete-message2"/>.
        /// </summary>
        /// <param name="messageId">ID of the message to delete.</param>
        /// <param name="popReceipt">
        /// Required. A valid pop receipt value returned from an earlier call to the Get Messages or Update Message operation.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Task{Response}"/>.
        /// </returns>
        public virtual async Task<Response> DeleteMessageAsync(
            string messageId,
            string popReceipt,
            CancellationToken cancellationToken = default)
        {
            var uri = this.GetMessageUri(messageId);
            using (this._pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message:
                    $"Uri: {uri}\n" +
                    $"{nameof(popReceipt)}: {popReceipt}");
                try
                {
                    return await QueueRestClient.MessageId.DeleteAsync(
                        this._pipeline,
                        uri,
                        popReceipt: popReceipt,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(QueueClient));
                }
            }
        }

        /// <summary>
        /// Changes a message's visibility timeout and contents. The message content must be a UTF-8 encoded string that is up to 64KB in size.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/update-message"/>.
        /// </summary>
        /// <param name="messageText">
        /// Updated message text.
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
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Task{Response{UpdatedMessage}}"/>.
        /// </returns>
        public virtual async Task<Response<UpdatedMessage>> UpdateMessageAsync(
            string messageText,
            string messageId,
            string popReceipt,
            TimeSpan visibilityTimeout = default,
            CancellationToken cancellationToken = default)
        {
            var uri = this.GetMessageUri(messageId);
            using (this._pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message:
                    $"Uri: {uri}\n" +
                    $"{nameof(popReceipt)}: {popReceipt}" +
                    $"{nameof(visibilityTimeout)}: {visibilityTimeout}");
                try
                {
                    return await QueueRestClient.MessageId.UpdateAsync(
                        this._pipeline,
                        uri,
                        message: new QueueMessage { MessageText = messageText },
                        popReceipt: popReceipt,
                        visibilitytimeout: (int)visibilityTimeout.TotalSeconds,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(QueueClient));
                }
            }
        }
    }
}

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// The object returned in the QueueMessageList array when calling Get
    /// Messages on a Queue.
    /// </summary>
    public partial class DequeuedMessage
    {
        /// <summary>
        /// Update a <see cref="DequeuedMessage"/> after calling
        /// <see cref="QueueClient.UpdateMessageAsync"/> with the resulting
        /// <see cref="UpdatedMessage"/>
        /// </summary>
        /// <param name="updated">The message details.</param>
        /// <returns>The updated <see cref="DequeuedMessage"/>.</returns>
        public DequeuedMessage Update(UpdatedMessage updated) =>
            QueueModelFactory.DequeuedMessage(
                this.MessageId,
                this.InsertionTime,
                this.ExpirationTime,
                updated.PopReceipt,
                updated.TimeNextVisible,
                this.DequeueCount,
                this.MessageText);
    }
}
