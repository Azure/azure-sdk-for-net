﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
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
        /// Creates a <see cref="MessagesClient"/>.
        /// </summary>
        /// <param name="primaryUri">
        /// The primary <see cref="Uri"/> endpoint for the service.
        /// </param>
        /// <param name="connectionOptions">
        /// Optional <see cref="QueueConnectionOptions"/>.
        /// </param>
        public MessagesClient(Uri primaryUri, QueueConnectionOptions connectionOptions = default)
            : this(primaryUri, (connectionOptions ?? new QueueConnectionOptions()).Build())
        {
        }

        /// <summary>
        /// Creates a <see cref="MessagesClient"/>.
        /// </summary>
        /// <param name="primaryUri">
        /// The primary <see cref="Uri"/> endpoint for the service.
        /// </param>
        /// <param name="pipeline">
        /// The <see cref="HttpPipeline"/> used to execute operations.
        /// </param>
        internal MessagesClient(Uri primaryUri, HttpPipeline pipeline)
        {
            this.Uri = primaryUri;
            this._pipeline = pipeline;
        }

        /// <summary>
        /// Creates a new MessageIdClient object by concatenating
        /// messageID to the end of MessagesClient's URL. The new MessageIdClient
        /// uses the same request policy pipeline as the MessagesURL.
        /// </summary>
        /// <param name="messageID">
        /// Message ID.
        /// </param>
        /// <returns>
        /// <see cref="MessageIdClient"/>
        /// </returns>
        public MessageIdClient GetMessageIdClient(string messageID) =>
            new MessageIdClient(this.Uri.AppendToPath(messageID.ToString(CultureInfo.InvariantCulture)), this._pipeline);

        /// <summary>
        /// Clear deletes all messages from a queue.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/clear-messages"/>.
        /// </summary>
        /// <param name="cancellation">
        /// <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Task{Response}"/>
        /// </returns>
        public async Task<Response> ClearAsync(
            CancellationToken cancellation = default)
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
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Task{Response{IEnumerable{EnqueuedMessage}}}"/>
        /// </returns>
        public async Task<Response<IEnumerable<EnqueuedMessage>>> EnqueueAsync(
            string messageText, 
            TimeSpan? visibilityTimeout = default,
            TimeSpan? timeToLive = default,
            CancellationToken cancellation = default)
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
                    return await QueueRestClient.Messages.EnqueueAsync(
                        this._pipeline,
                        this.Uri,
                        message: new QueueMessage { MessageText = messageText },
                        visibilitytimeout: (int?)visibilityTimeout?.TotalSeconds,
                        messageTimeToLive: (int?)timeToLive?.TotalSeconds,
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
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// IEnumerable of <see cref="Task{Response{IEnumerable{DequeuedMessage}}}"/>.
        /// </returns>
        public async Task<Response<IEnumerable<DequeuedMessage>>> DequeueAsync(
            int? maxMessages = default,
            TimeSpan? visibilityTimeout = default,
            CancellationToken cancellation = default)
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
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// IEnumerable of <see cref="Task{Response{IEnumerable{PeekedMessage}}}"/>.
        /// </returns>
        public async Task<Response<IEnumerable<PeekedMessage>>> PeekAsync(
            int? maxMessages = default,
            CancellationToken cancellation = default)
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
                    this._pipeline.LogMethodExit(nameof(MessagesClient));
                }
            }
        }
    }
}
