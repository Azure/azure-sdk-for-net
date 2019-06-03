// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Common;
using Azure.Storage.Queues.Models;

namespace Azure.Storage.Queues
{
    /// <summary>
    /// A MessageIdClient represents a URL to a specific Azure Storage Queue message allowing you to manipulate the message.
    /// </summary>
    public class MessageIdClient
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
        /// Creates a <see cref="MessageIdClient"/>.
        /// </summary>
        /// <param name="primaryUri">
        /// The primary <see cref="Uri"/> endpoint for the service.
        /// </param>
        /// <param name="connectionOptions">
        /// Optional <see cref="QueueConnectionOptions"/>
        /// </param>
        public MessageIdClient(Uri primaryUri, QueueConnectionOptions connectionOptions = default)
            : this(primaryUri, (connectionOptions ?? new QueueConnectionOptions()).Build())
        {
        }

        /// <summary>
        /// Creates a <see cref="MessageIdClient"/>.
        /// </summary>
        /// <param name="primaryUri">
        /// The primary <see cref="Uri"/> endpoint for the service.
        /// </param>
        /// <param name="pipeline">
        /// The <see cref="HttpPipeline"/> used to execute operations.
        /// </param>
        internal MessageIdClient(Uri primaryUri, HttpPipeline pipeline)
        {
            this.Uri = primaryUri;
            this._pipeline = pipeline;
        }

        /// <summary>
        /// Permanently removes the specified message from its queue.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/delete-message2"/>.
        /// </summary>
        /// <param name="popReceipt">
        /// Required. A valid pop receipt value returned from an earlier call to the Get Messages or Update Message operation.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Task{Response}"/>.
        /// </returns>
        public async Task<Response> DeleteAsync(
            string popReceipt,
            CancellationToken cancellation = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(MessageIdClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(MessageIdClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(popReceipt)}: {popReceipt}");
                try
                {
                    return await QueueRestClient.MessageId.DeleteAsync(
                        this._pipeline,
                        this.Uri,
                        popReceipt: popReceipt,
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
                    this._pipeline.LogMethodExit(nameof(MessageIdClient));
                }
            }
        }

        /// <summary>
        /// Changes a message's visibility timeout and contents. The message content must be a UTF-8 encoded string that is up to 64KB in size.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/update-message"/>.
        /// </summary>
        /// <param name="message">
        /// Updated message text.
        /// </param>
        /// <param name="popReceipt">
        /// Required. Specifies the valid pop receipt value returned from an earlier call to the Get Messages or Update Message operation.
        /// </param>
        /// <param name="visibilityTimeout">
        /// Required. Specifies the new visibility timeout value, in seconds, relative to server time. The new value must be larger than 
        /// or equal to 0, and cannot be larger than 7 days. The visibility timeout of a message cannot be set to a value later than the 
        /// expiry time. A message can be updated until it has been deleted or has expired.
        /// </param>
        /// <param name="cancellation">
        /// Optional <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// <see cref="Task{Response{UpdatedMessage}}"/>.
        /// </returns>
        public async Task<Response<UpdatedMessage>> UpdateAsync(
            string messageText,
            string popReceipt,
            TimeSpan visibilityTimeout = default, 
            CancellationToken cancellation = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(MessageIdClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(MessageIdClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(popReceipt)}: {popReceipt}" +
                    $"{nameof(visibilityTimeout)}: {visibilityTimeout}");
                try
                {
                    return await QueueRestClient.MessageId.UpdateAsync(
                        this._pipeline,
                        this.Uri,
                        message: new QueueMessage { MessageText = messageText },
                        popReceipt: popReceipt,
                        visibilitytimeout: (int)visibilityTimeout.TotalSeconds,
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
                    this._pipeline.LogMethodExit(nameof(MessageIdClient));
                }
            }
        }
    }
}
