// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The <see cref="ProcessMessageEventArgs"/> contain event args that are specific
    /// to the <see cref="ServiceBusReceivedMessage"/> that is being processed.
    /// </summary>
    public class ProcessMessageEventArgs : EventArgs
    {

        /// <summary>
        /// The received message to be processed.
        /// </summary>
        public ServiceBusReceivedMessage Message { get; }

        /// <summary>
        /// A <see cref="System.Threading.CancellationToken"/> instance to signal the request to cancel the operation.
        /// </summary>
        public CancellationToken CancellationToken { get; }

        private readonly ServiceBusReceiver _receiver;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessMessageEventArgs"/> class.
        /// </summary>
        ///
        /// <param name="message"></param>
        /// <param name="receiver"></param>
        /// <param name="cancellationToken"></param>
        internal ProcessMessageEventArgs(ServiceBusReceivedMessage message, ServiceBusReceiver receiver, CancellationToken cancellationToken)
        {
            Message = message;
            _receiver = receiver;
            CancellationToken = cancellationToken;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="propertiesToModify"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task AbandonMessageAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = default,
            CancellationToken cancellationToken = default)
        {
            await _receiver.AbandonMessageAsync(message, propertiesToModify, cancellationToken)
            .ConfigureAwait(false);
            message.IsSettled = true;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task CompleteMessageAsync(
            ServiceBusReceivedMessage message,
            CancellationToken cancellationToken = default)
        {
            await _receiver.CompleteMessageAsync(
                message,
                cancellationToken)
            .ConfigureAwait(false);
            message.IsSettled = true;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="deadLetterReason"></param>
        /// <param name="deadLetterErrorDescription"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DeadLetterMessageAsync(
            ServiceBusReceivedMessage message,
            string deadLetterReason,
            string deadLetterErrorDescription = default,
            CancellationToken cancellationToken = default)
        {
            await _receiver.DeadLetterMessageAsync(
                message,
                deadLetterReason,
                deadLetterErrorDescription,
                cancellationToken)
            .ConfigureAwait(false);
            message.IsSettled = true;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="propertiesToModify"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DeadLetterMessageAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = default,
            CancellationToken cancellationToken = default)
        {
            await _receiver.DeadLetterMessageAsync(
                message,
                propertiesToModify,
                cancellationToken)
            .ConfigureAwait(false);
            message.IsSettled = true;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="propertiesToModify"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DeferMessageAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = default,
            CancellationToken cancellationToken = default)
        {
            await _receiver.DeferMessageAsync(
                message,
                propertiesToModify,
                cancellationToken)
            .ConfigureAwait(false);
            message.IsSettled = true;
        }
    }
}
