// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   A producer responsible for transmitting <see cref="EventData" /> to a specific Event Hub,
    ///   grouped together in batches.  Depending on the options specified at creation, the producer may
    ///   be created to allow event data to be automatically routed to an available partition or specific
    ///   to a partition.
    /// </summary>
    ///
    /// <remarks>
    ///   Allowing automatic routing of partitions is recommended when:
    ///   <para>- The sending of events needs to be highly available.</para>
    ///   <para>- The event data should be evenly distributed among all available partitions.</para>
    ///
    ///   If no partition is specified, the following rules are used for automatically selecting one:
    ///   <para>1) Distribute the events equally amongst all available partitions using a round-robin approach.</para>
    ///   <para>2) If a partition becomes unavailable, the Event Hubs service will automatically detect it and forward the message to another available partition.</para>
    /// </remarks>
    ///
    public class EventHubProducer : IAsyncDisposable
    {
        /// <summary>The maximum allowable size, in bytes, for a batch to be sent.</summary>
        internal const int MinimumBatchSizeLimit = 24;

        /// <summary>The maximum allowable size, in bytes, for a batch to be sent.</summary>
        internal const int MaximumBatchSizeLimit = 4 * 1024 * 1024;

        /// <summary>The set of default batching options to use when no specific options are requested.</summary>
        private static readonly SendOptions DefaultSendOptions = new SendOptions();

        /// <summary>The policy to use for determining retry behavior for when an operation fails.</summary>
        private EventHubRetryPolicy _retryPolicy;

        /// <summary>
        ///   The identifier of the Event Hub partition that the <see cref="EventHubProducer" /> is bound to, indicating
        ///   that it will send events to only that partition.
        ///
        ///   If the identifier was not specified at creation, the producer will allow the Event Hubs service to be
        ///   responsible for routing events that are sent to an available partition.
        /// </summary>
        ///
        /// <value>If <c>null</c>, the producer is not specific to a partition and events will be automatically routed; otherwise, the identifier of the partition events will be sent to.</value>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   The path of the specific Event Hub that the client is connected to, relative
        ///   to the Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubPath { get; }

        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        public EventHubRetryPolicy RetryPolicy
        {
            get => _retryPolicy;

            set
            {
                Guard.ArgumentNotNull(nameof(RetryPolicy), value);
                _retryPolicy = value;

                // Applying a custom retry policy invalidates the retry options specified.
                // Clear them to ensure the custom policy is propagated as the default.

                Options.RetryOptions = null;
                InnerProducer.UpdateRetryPolicy(value);
            }
        }

        /// <summary>
        ///   The set of options used for creation of this producer.
        /// </summary>
        ///
        private EventHubProducerOptions Options { get; }

        /// <summary>
        ///   An abstracted Event Hub producer specific to the active protocol and transport intended to perform delegated operations.
        /// </summary>
        ///
        private TransportEventHubProducer InnerProducer { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubProducer"/> class.
        /// </summary>
        ///
        /// <param name="transportProducer">An abstracted Event Hub producer specific to the active protocol and transport intended to perform delegated operations.</param>
        /// <param name="eventHubPath">The path of the Event Hub to which events will be sent.</param>
        /// <param name="producerOptions">The set of options to use for this consumer.</param>
        /// <param name="retryPolicy">The policy to apply when making retry decisions for failed operations.</param>
        ///
        /// <remarks>
        ///   Because this is a non-public constructor, it is assumed that the <paramref name="producerOptions" /> passed are
        ///   owned by this instance and are safe from changes made by consumers.  It is considered the responsibility of the
        ///   caller to ensure that any needed cloning of options is performed.
        /// </remarks>
        ///
        internal EventHubProducer(TransportEventHubProducer transportProducer,
                                  string eventHubPath,
                                  EventHubProducerOptions producerOptions,
                                  EventHubRetryPolicy retryPolicy)
        {
            Guard.ArgumentNotNull(nameof(transportProducer), transportProducer);
            Guard.ArgumentNotNullOrEmpty(nameof(eventHubPath), eventHubPath);
            Guard.ArgumentNotNull(nameof(producerOptions), producerOptions);
            Guard.ArgumentNotNull(nameof(retryPolicy), retryPolicy);

            PartitionId = producerOptions.PartitionId;
            EventHubPath = eventHubPath;
            Options = producerOptions;
            InnerProducer = transportProducer;

            _retryPolicy = retryPolicy;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubProducer"/> class.
        /// </summary>
        ///
        protected EventHubProducer()
        {
        }

        /// <summary>
        ///   Sends an event to the associated Event Hub using a batched approach.  If the size of the event exceeds the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="eventData">The event data to send.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <seealso cref="SendAsync(IEnumerable{EventData}, SendOptions, CancellationToken)"/>
        ///
        public virtual Task SendAsync(EventData eventData,
                                      CancellationToken cancellationToken = default)
        {
            Guard.ArgumentNotNull(nameof(eventData), eventData);
            return SendAsync(new[] { eventData }, null, cancellationToken);
        }

        /// <summary>
        ///   Sends an event to the associated Event Hub using a batched approach.  If the size of the event exceeds the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="eventData">The event data to send.</param>
        /// <param name="options">The set of options to consider when sending this batch.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <seealso cref="SendAsync(IEnumerable{EventData}, CancellationToken)" />
        ///
        public virtual Task SendAsync(EventData eventData,
                                      SendOptions options,
                                      CancellationToken cancellationToken = default)
        {
            Guard.ArgumentNotNull(nameof(eventData), eventData);
            return SendAsync(new[] { eventData }, options, cancellationToken);
        }

        /// <summary>
        ///   Sends a set of events to the associated Event Hub using a batched approach.  If the size of events exceed the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="events">The set of event data to send.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <seealso cref="SendAsync(IEnumerable{EventData}, SendOptions, CancellationToken)"/>
        ///
        public virtual Task SendAsync(IEnumerable<EventData> events,
                                      CancellationToken cancellationToken = default) => SendAsync(events, null, cancellationToken);

        /// <summary>
        ///   Sends a set of events to the associated Event Hub using a batched approach.  If the size of events exceed the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="events">The set of event data to send.</param>
        /// <param name="options">The set of options to consider when sending this batch.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <seealso cref="SendAsync(IEnumerable{EventData}, CancellationToken)" />
        ///
        public virtual Task SendAsync(IEnumerable<EventData> events,
                                      SendOptions options,
                                      CancellationToken cancellationToken = default)
        {
            Guard.ArgumentNotNull(nameof(events), events);

            options = options ?? DefaultSendOptions;

            if ((!String.IsNullOrEmpty(PartitionId)) && (!String.IsNullOrEmpty(options.PartitionKey)))
            {
                throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture, Resources.CannotSendWithPartitionIdAndPartitionKey, PartitionId));
            }

            return InnerProducer.SendAsync(events, options, cancellationToken);
        }

        /// <summary>
        ///   Closes the producer.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual Task CloseAsync(CancellationToken cancellationToken = default) => InnerProducer.CloseAsync(cancellationToken);

        /// <summary>
        ///   Closes the producer.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public virtual void Close(CancellationToken cancellationToken = default) => CloseAsync(cancellationToken).GetAwaiter().GetResult();

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="EventHubClient" />,
        ///   including ensuring that the client itself has been closed.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async ValueTask DisposeAsync() => await CloseAsync().ConfigureAwait(false);

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
    }
}
