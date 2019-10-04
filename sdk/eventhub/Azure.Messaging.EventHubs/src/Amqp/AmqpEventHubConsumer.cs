// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Metadata;
using Microsoft.Azure.Amqp;

namespace Azure.Messaging.EventHubs.Amqp
{
    /// <summary>
    ///   A transport client abstraction responsible for brokering operations for AMQP-based connections.
    ///   It is intended that the public <see cref="EventHubConsumer" /> make use of an instance
    ///   via containment and delegate operations to it.
    /// </summary>
    ///
    /// <seealso cref="Azure.Messaging.EventHubs.Core.TransportEventHubConsumer" />
    ///
    internal class AmqpEventHubConsumer : TransportEventHubConsumer
    {
        /// <summary>The active retry policy for the consumer.</summary>
        private EventHubRetryPolicy _retryPolicy;

        /// <summary>The amount of time to allow for an operation to complete before considering it to have timed out.</summary>
        private TimeSpan _tryTimeout;

        /// <summary>Indicates whether or not this instance has been closed.</summary>
        private bool _closed = false;

        /// <summary>
        ///   Indicates whether or not this consumer has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the consumer is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public override bool Closed => _closed;

        /// <summary>
        ///   The converter to use for translating between AMQP messages and client library
        ///   types.
        /// </summary>
        ///
        private AmqpMessageConverter MessageConverter { get; }

        /// <summary>
        ///   The AMQP connection scope responsible for managing transport constructs for this instance.
        /// </summary>
        ///
        private AmqpConnectionScope ConnectionScope { get; }

        /// <summary>
        ///   The AMQP link intended for use with receiving operations.
        /// </summary>
        ///
        private FaultTolerantAmqpObject<ReceivingAmqpLink> ReceiveLink { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpEventHubConsumer"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="consumerOptions">The set of active options for the consumer that will make use of the link.</param>
        /// <param name="eventPosition">The position of the event in the partition where the consumer should begin reading.</param>
        /// <param name="connectionScope">The AMQP connection context for operations .</param>
        /// <param name="messageConverter">The converter to use for translating between AMQP messages and client types.</param>
        /// <param name="retryPolicy">The retry policy to consider when an operation fails.</param>
        /// <param name="lastEnqueuedEventProperties">The set of properties for the last event enqueued in a partition; if not requested in the consumer options, it is expected that this is <c>null</c>.</param>
        ///
        /// <remarks>
        ///   As an internal type, this class performs only basic sanity checks against its arguments.  It
        ///   is assumed that callers are trusted and have performed deep validation.
        ///
        ///   Any parameters passed are assumed to be owned by this instance and safe to mutate or dispose;
        ///   creation of clones or otherwise protecting the parameters is assumed to be the purview of the
        ///   caller.
        /// </remarks>
        ///
        public AmqpEventHubConsumer(string consumerGroup,
                                    string partitionId,
                                    EventPosition eventPosition,
                                    EventHubConsumerOptions consumerOptions,
                                    AmqpConnectionScope connectionScope,
                                    AmqpMessageConverter messageConverter,
                                    EventHubRetryPolicy retryPolicy,
                                    LastEnqueuedEventProperties lastEnqueuedEventProperties) : base(lastEnqueuedEventProperties)
        {
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));
            Argument.AssertNotNull(connectionScope, nameof(connectionScope));
            Argument.AssertNotNull(messageConverter, nameof(messageConverter));
            Argument.AssertNotNull(retryPolicy, nameof(retryPolicy));

            ConnectionScope = connectionScope;
            MessageConverter = messageConverter;
            ReceiveLink = new FaultTolerantAmqpObject<ReceivingAmqpLink>(timeout => ConnectionScope.OpenConsumerLinkAsync(consumerGroup, partitionId, eventPosition, consumerOptions, timeout, CancellationToken.None), link => link.SafeClose());

            _retryPolicy = retryPolicy;
            _tryTimeout = retryPolicy.CalculateTryTimeout(0);
        }

        /// <summary>
        ///   Updates the active retry policy for the consumer.
        /// </summary>
        ///
        /// <param name="newRetryPolicy">The retry policy to set as active.</param>
        ///
        public override void UpdateRetryPolicy(EventHubRetryPolicy newRetryPolicy)
        {
            Argument.AssertNotNull(newRetryPolicy, nameof(newRetryPolicy));

            _retryPolicy = newRetryPolicy;
            _tryTimeout = _retryPolicy.CalculateTryTimeout(0);
        }

        /// <summary>
        ///   Receives a batch of <see cref="EventData" /> from the Event Hub partition.
        /// </summary>
        ///
        /// <param name="maximumMessageCount">The maximum number of messages to receive in this batch.</param>
        /// <param name="maximumWaitTime">The maximum amount of time to wait to build up the requested message count for the batch; if not specified, the default wait time specified when the consumer was created will be used.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The batch of <see cref="EventData" /> from the Event Hub partition this consumer is associated with.  If no events are present, an empty enumerable is returned.</returns>
        ///
        public override Task<IEnumerable<EventData>> ReceiveAsync(int maximumMessageCount,
                                                                  TimeSpan? maximumWaitTime,
                                                                  CancellationToken cancellationToken)
        {
             throw new NotImplementedException();
        }

        /// <summary>
        ///   Closes the connection to the transport consumer instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public override Task CloseAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
    }
}
