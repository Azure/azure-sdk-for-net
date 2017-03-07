// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Amqp;
    using Core;
    using Primitives;

    /// <summary>
    /// Anchor class - all Queue client operations start here.
    /// </summary>
    public sealed class QueueClient : ClientEntity, IQueueClient
    {
        public QueueClient(string connectionString, string entityPath, ReceiveMode receiveMode = ReceiveMode.PeekLock)
            : this(new ServiceBusNamespaceConnection(connectionString), entityPath, receiveMode)
        {
        }

        private QueueClient(ServiceBusNamespaceConnection serviceBusConnection, string entityPath, ReceiveMode receiveMode)
            : base($"{nameof(QueueClient)}{ClientEntity.GetNextId()}({entityPath})")
        {
            this.QueueName = entityPath;
            this.ReceiveMode = receiveMode;
            this.InnerClient = new AmqpClient(serviceBusConnection, entityPath, MessagingEntityType.Queue, receiveMode);
        }

        public string QueueName { get; }

        public ReceiveMode ReceiveMode { get; private set; }

        public string Path => this.QueueName;

        internal IInnerSenderReceiver InnerClient { get; }

        public override async Task CloseAsync()
        {
            await this.InnerClient.CloseAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Send <see cref="Message"/> to Queue.
        /// <see cref="SendAsync(Message)"/> sends the <see cref="Message"/> to a Service Gateway, which in-turn will forward the Message to the queue.
        /// </summary>
        /// <param name="message">the <see cref="Message"/> to be sent.</param>
        /// <returns>A Task that completes when the send operations is done.</returns>
        public Task SendAsync(Message message)
        {
            return this.SendAsync(new[] { message });
        }

        public Task SendAsync(IList<Message> messageList)
        {
            return this.InnerClient.InnerSender.SendAsync(messageList);
        }

        public Task CompleteAsync(string lockToken)
        {
            return this.InnerClient.InnerReceiver.CompleteAsync(lockToken);
        }

        public Task AbandonAsync(string lockToken)
        {
            return this.InnerClient.InnerReceiver.AbandonAsync(lockToken);
        }

        public Task DeadLetterAsync(string lockToken)
        {
            return this.InnerClient.InnerReceiver.DeadLetterAsync(lockToken);
        }

        /// <summary>Asynchronously processes a message.</summary>
        /// <param name="handler"></param>
        public void RegisterMessageHandler(Func<Message, CancellationToken, Task> handler)
        {
            this.InnerClient.InnerReceiver.RegisterMessageHandler(handler);
        }

        /// <summary>Asynchronously processes a message.</summary>
        /// <param name="handler"></param>
        /// <param name="registerHandlerOptions">Calls a message option.</param>
        public void RegisterMessageHandler(Func<Message, CancellationToken, Task> handler, RegisterHandlerOptions registerHandlerOptions)
        {
            this.InnerClient.InnerReceiver.RegisterMessageHandler(handler, registerHandlerOptions);
        }

        /// <summary>
        /// Sends a scheduled message
        /// </summary>
        /// <param name="message">Message to be scheduled</param>
        /// <param name="scheduleEnqueueTimeUtc">Time of enqueue</param>
        /// <returns>Sequence number that is needed for cancelling.</returns>
        public Task<long> ScheduleMessageAsync(Message message, DateTimeOffset scheduleEnqueueTimeUtc)
        {
            return this.InnerClient.InnerSender.ScheduleMessageAsync(message, scheduleEnqueueTimeUtc);
        }

        /// <summary>
        /// Cancels a scheduled message
        /// </summary>
        /// <param name="sequenceNumber">Returned on scheduling a message.</param>
        /// <returns></returns>
        public Task CancelScheduledMessageAsync(long sequenceNumber)
        {
            return this.InnerClient.InnerSender.CancelScheduledMessageAsync(sequenceNumber);
        }
    }
}