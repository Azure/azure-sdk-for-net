// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Amqp;
    using Core;
    using Primitives;

    public sealed class TopicClient : ClientEntity, ITopicClient
    {
        public TopicClient(string connectionString, string entityPath, RetryPolicy retryPolicy = null)
            : this(new ServiceBusNamespaceConnection(connectionString), entityPath, retryPolicy ?? RetryPolicy.Default)
        {
        }

        TopicClient(ServiceBusNamespaceConnection serviceBusConnection, string entityPath, RetryPolicy retryPolicy)
            : base($"{nameof(TopicClient)}{GetNextId()}({entityPath})", retryPolicy)
        {
            this.TopicName = entityPath;
            this.InnerClient = new AmqpClient(serviceBusConnection, entityPath, MessagingEntityType.Topic, retryPolicy);
        }

        public string TopicName { get; }

        internal IInnerSender InnerClient { get; }

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