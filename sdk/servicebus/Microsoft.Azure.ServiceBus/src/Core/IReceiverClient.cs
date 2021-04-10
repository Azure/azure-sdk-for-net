// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An interface used to describe common functionality for receiving messages from <see cref="IQueueClient"/> and <see cref="ISubscriptionClient"/>.
    /// </summary>
    /// <remarks>Use <see cref="IMessageReceiver"/> for advanced set of functionality.</remarks>
    /// <seealso cref="IMessageReceiver"/>
    /// <seealso cref="IQueueClient"/>
    /// <seealso cref="ISubscriptionClient"/>
    public interface IReceiverClient : IClientEntity
    {
        /// <summary>
        /// Prefetch speeds up the message flow by aiming to have a message readily available for local retrieval when and before the application asks for one using Receive.
        /// Setting a non-zero value prefetches PrefetchCount number of messages.
        /// Setting the value to zero turns prefetch off.
        /// Defaults to 0.
        /// </summary>
        /// <remarks>
        /// <para>
        /// When Prefetch is enabled, the receiver will quietly acquire more messages, up to the PrefetchCount limit, than what the application
        /// immediately asks for. A single initial Receive/ReceiveAsync call will therefore acquire a message for immediate consumption
        /// that will be returned as soon as available, and the client will proceed to acquire further messages to fill the prefetch buffer in the background.
        /// </para>
        /// <para>
        /// While messages are available in the prefetch buffer, any subsequent ReceiveAsync calls will be immediately satisfied from the buffer, and the buffer is
        /// replenished in the background as space becomes available.If there are no messages available for delivery, the receive operation will drain the
        /// buffer and then wait or block as expected.
        /// </para>
        /// <para>Updates to this value take effect on the next receive call to the service.</para>
        /// </remarks>
        int PrefetchCount { get; set; }

        /// <summary>
        /// Gets the <see cref="ServiceBus.ReceiveMode"/> of the current receiver.
        /// </summary>
        ReceiveMode ReceiveMode { get; }

        /// <summary>
        /// Receive messages continuously from the entity. Registers a message handler and begins a new thread to receive messages.
        /// This handler(<see cref="Func{Message, CancellationToken, Task}"/>) is awaited on every time a new message is received by the receiver.
        /// </summary>
        /// <param name="handler">A <see cref="Func{Message, CancellationToken, Task}"/> that processes messages.</param>
        /// <param name="exceptionReceivedHandler">A <see cref="Func{T1, TResult}"/> that is invoked during exceptions.
        /// <see cref="ExceptionReceivedEventArgs"/> contains contextual information regarding the exception.</param>
        /// <remarks>Enable prefetch to speed up the receive rate.
        /// Use <see cref="RegisterMessageHandler(Func{Message,CancellationToken,Task}, MessageHandlerOptions)"/> to configure the settings of the pump.</remarks>
        void RegisterMessageHandler(Func<Message, CancellationToken, Task> handler, Func<ExceptionReceivedEventArgs, Task> exceptionReceivedHandler);

        /// <summary>
        /// Receive messages continuously from the entity. Registers a message handler and begins a new thread to receive messages.
        /// This handler(<see cref="Func{Message, CancellationToken, Task}"/>) is awaited on every time a new message is received by the receiver.
        /// </summary>
        /// <param name="handler">A <see cref="Func{Message, CancellationToken, Task}"/> that processes messages.</param>
        /// <param name="messageHandlerOptions">The <see cref="MessageHandlerOptions"/> options used to configure the settings of the pump.</param>
        /// <remarks>Enable prefetch to speed up the receive rate.</remarks>
        void RegisterMessageHandler(Func<Message, CancellationToken, Task> handler, MessageHandlerOptions messageHandlerOptions);

        /// <summary>
        /// Unregister message handler from the receiver if there is an active message handler registered. This operation waits for the completion
        /// of inflight receive and message handling operations to finish and unregisters future receives on the message handler which previously 
        /// registered. 
        /// </summary>
        /// <param name="inflightMessageHandlerTasksWaitTimeout"> is the maximum waitTimeout for inflight message handling tasks.</param>
        Task UnregisterMessageHandlerAsync(TimeSpan inflightMessageHandlerTasksWaitTimeout);

        /// <summary>
        /// Completes a <see cref="Message"/> using its lock token. This will delete the message from the queue.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to complete.</param>
        /// <remarks>
        /// A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBus.ReceiveMode.PeekLock"/>.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        Task CompleteAsync(string lockToken);

        /// <summary>
        /// Abandons a <see cref="Message"/> using a lock token. This will make the message available again for processing.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to abandon.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while abandoning the message.</param>
        /// <remarks>A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBus.ReceiveMode.PeekLock"/>.
        /// Abandoning a message will increase the delivery count on the message.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        Task AbandonAsync(string lockToken, IDictionary<string, object> propertiesToModify = null);

        /// <summary>
        /// Moves a message to the deadletter sub-queue.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to deadletter.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while moving to sub-queue.</param>
        /// <remarks>
        /// A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBus.ReceiveMode.PeekLock"/>.
        /// In order to receive a message from the deadletter queue, you will need a new <see cref="IMessageReceiver"/>, with the corresponding path.
        /// You can use <see cref="EntityNameHelper.FormatDeadLetterPath(string)"/> to help with this.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        Task DeadLetterAsync(string lockToken, IDictionary<string, object> propertiesToModify = null);

        /// <summary>
        /// Moves a message to the deadletter sub-queue.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to deadletter.</param>
        /// <param name="deadLetterReason">The reason for deadlettering the message.</param>
        /// <param name="deadLetterErrorDescription">The error description for deadlettering the message.</param>
        /// <remarks>
        /// A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBus.ReceiveMode.PeekLock"/>.
        /// In order to receive a message from the deadletter queue, you will need a new <see cref="IMessageReceiver"/>, with the corresponding path.
        /// You can use <see cref="EntityNameHelper.FormatDeadLetterPath(string)"/> to help with this.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        Task DeadLetterAsync(string lockToken, string deadLetterReason, string deadLetterErrorDescription = null);
    }
}
