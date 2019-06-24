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

namespace Azure.Storage.Queues
{
    /// <summary>
    /// A MessagesClient represents a URL to an Azure Storage Queue's messages
    /// allowing you to manipulate its messages.
    /// </summary>
    public class MessagesClient
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
        /// Initializes a new instance of the <see cref="MessagesClient"/>
        /// class.
        /// </summary>
        protected MessagesClient()
        {
        }

        /// <summary>
        /// Creates a <see cref="MessagesClient"/>.
        /// </summary>
        /// <param name="messagesUri">
        /// The messages <see cref="Uri"/> endpoint for the service.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="QueueClientOptions"/>.
        /// </param>
        public MessagesClient(Uri messagesUri, QueueClientOptions options = default)
            : this(messagesUri, (HttpPipelinePolicy)null, options)
        {
        }

        /// <summary>
        /// Creates a <see cref="MessagesClient"/>.
        /// </summary>
        /// <param name="messagesUri">
        /// The messages <see cref="Uri"/> endpoint for the service.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="QueueClientOptions"/>.
        /// </param>
        public MessagesClient(Uri messagesUri, StorageSharedKeyCredential credential, QueueClientOptions options = default)
            : this(messagesUri, credential.AsPolicy(), options)
        {
        }

        /// <summary>
        /// Creates a <see cref="MessagesClient"/>.
        /// </summary>
        /// <param name="messagesUri">
        /// The messages <see cref="Uri"/> endpoint for the service.
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="QueueClientOptions"/>.
        /// </param>
        public MessagesClient(Uri messagesUri, TokenCredential credential, QueueClientOptions options = default)
            : this(messagesUri, credential.AsPolicy(), options)
        {
        }

        /// <summary>
        /// Creates a <see cref="MessagesClient"/>.
        /// </summary>
        /// <param name="messagesUri">
        /// The messages <see cref="Uri"/> endpoint for the service.
        /// </param>
        /// <param name="authentication">
        /// An optional authentication policy used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="QueueClientOptions"/>.
        /// </param>
        internal MessagesClient(Uri messagesUri, HttpPipelinePolicy authentication, QueueClientOptions options)
        {
            this.Uri = messagesUri;
            this._pipeline = (options ?? new QueueClientOptions()).Build(authentication);
        }

        /// <summary>
        /// Creates a <see cref="MessagesClient"/>.
        /// </summary>
        /// <param name="messagesUri">
        /// The messages <see cref="Uri"/> endpoint for the service.
        /// </param>
        /// <param name="pipeline">
        /// The <see cref="HttpPipeline"/> used to execute operations.
        /// </param>
        internal MessagesClient(Uri messagesUri, HttpPipeline pipeline)
        {
            this.Uri = messagesUri;
            this._pipeline = pipeline;
        }

        /// <summary>
        /// Creates a new MessageIdClient object by concatenating
        /// messageID to the end of MessagesClient's URL. The new MessageIdClient
        /// uses the same request policy pipeline as the MessagesURL.
        /// </summary>
        /// <param name="messageId">
        /// Message ID.
        /// </param>
        /// <returns>
        /// <see cref="MessageIdClient"/>
        /// </returns>
        public virtual MessageIdClient GetMessageIdClient(string messageId) =>
            new MessageIdClient(this.Uri.AppendToPath(messageId.ToString(CultureInfo.InvariantCulture)), this._pipeline);

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
        public virtual async Task<Response> ClearAsync(
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(MessagesClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(MessagesClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await QueueRestClient.Messages.ClearAsync(
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
                    this._pipeline.LogMethodExit(nameof(MessagesClient));
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
        public virtual async Task<Response<EnqueuedMessage>> EnqueueAsync(
            string messageText, 
            TimeSpan? visibilityTimeout = default,
            TimeSpan? timeToLive = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(MessagesClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(MessagesClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(visibilityTimeout)}: {visibilityTimeout}\n" +
                    $"{nameof(timeToLive)}: {timeToLive}");
                try
                {
                    // The service returns a sequence of messages, but the
                    // sequence only ever has one value so we'll unwrap it
                    var messages =
                        await QueueRestClient.Messages.EnqueueAsync(
                            this._pipeline,
                            this.Uri,
                            message: new QueueMessage { MessageText = messageText },
                            visibilitytimeout: (int?)visibilityTimeout?.TotalSeconds,
                            messageTimeToLive: (int?)timeToLive?.TotalSeconds,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
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
                    this._pipeline.LogMethodExit(nameof(MessagesClient));
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
        public virtual async Task<Response<IEnumerable<DequeuedMessage>>> DequeueAsync(
            int? maxMessages = default,
            TimeSpan? visibilityTimeout = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(MessagesClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(MessagesClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(maxMessages)}: {maxMessages}\n" +
                    $"{nameof(visibilityTimeout)}: {visibilityTimeout}");
                try
                {
                    return await QueueRestClient.Messages.DequeueAsync(
                        this._pipeline,
                        this.Uri,
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
                    this._pipeline.LogMethodExit(nameof(MessagesClient));
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
        public virtual async Task<Response<IEnumerable<PeekedMessage>>> PeekAsync(
            int? maxMessages = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(MessagesClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(MessagesClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(maxMessages)}: {maxMessages}");
                try
                {
                    return await QueueRestClient.Messages.PeekAsync(
                        this._pipeline,
                        this.Uri,
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
                    this._pipeline.LogMethodExit(nameof(MessagesClient));
                }
            }
        }
    }
}
