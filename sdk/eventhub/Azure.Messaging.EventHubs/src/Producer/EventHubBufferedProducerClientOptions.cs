// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs.Producer
{
    /// <summary>
    ///   The set of options that can be specified when creating an <see cref="EventHubBufferedProducerClient" />
    ///   to configure its behavior.
    /// </summary>
    ///
    /// <seealso href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples">Event Hubs samples and discussion</seealso>
    ///
    public class EventHubBufferedProducerClientOptions
    {
        /// <summary>The number of batches that may be sent concurrently across all partitions.</summary>
        private int _maximumConcurrentSends = Environment.ProcessorCount;

        /// <summary>The number of batches that may be sent concurrently to each partition.</summary>
        private int _maximumConcurrentSendsPerPartition = 1;

        /// <summary>The total number of events that can be buffered for publishing at a given time for a given partition.</summary>
        private int _maximumEventBufferLengthPerPartition = 1500;

        /// <summary> The amount of time to wait for a new event to be enqueued in the buffer before publishing a partially full batch.</summary>
        private TimeSpan? _maximumWaitTime = TimeSpan.FromSeconds(1);

        /// <summary>The set of options to use for configuring the connection to the Event Hubs service.</summary>
        private EventHubConnectionOptions _connectionOptions = new EventHubConnectionOptions();

        /// <summary>The set of options to govern retry behavior and try timeouts.</summary>
        private EventHubsRetryOptions _retryOptions;

        /// <summary>
        ///   Indicates whether or not events should be published using idempotent semantics for retries. If enabled, retries during publishing
        ///   will attempt to avoid duplication with a minor cost to throughput.  Duplicates are still possible but the chance of them occurring is
        ///   much lower when idempotent retries are enabled.
        ///</summary>
        ///
        /// <value>
        ///   By default, idempotent retries are disabled.
        /// </value>
        ///
        /// <remarks>
        ///   It is important to note that enabling idempotent retries does not guarantee exactly-once semantics.  The existing
        ///   Event Hubs at-least-once delivery contract still applies and event duplication is unlikely, but possible.
        /// </remarks>
        ///
        public bool EnableIdempotentRetries { get; set; }

        /// <summary>
        ///   The amount of time to wait for a batch to be built with events in the buffer before publishing
        ///   a partially full batch.
        /// </summary>
        ///
        /// <value>
        ///   The default wait time is 1 second.  For most scenarios, it is recommended to allow for at least 1
        ///   second in order to ensure consistent performance.
        ///
        ///   <para>If <c>null</c>, batches will only be published when full unless <see cref="EventHubBufferedProducerClient.FlushAsync(System.Threading.CancellationToken)"/>
        ///   is called.</para>
        /// </value>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested wait time is negative.</exception>
        ///
        public TimeSpan? MaximumWaitTime
        {
            get => _maximumWaitTime;

            set
            {
                if (value.HasValue)
                {
                    Argument.AssertNotNegative(value.Value, nameof(MaximumWaitTime));
                }

                _maximumWaitTime = value;
            }
        }

        /// <summary>
        ///   The total number of events that can be buffered for publishing at a given time for a given partition.  Once this capacity is reached, more events can enqueued by calling
        ///   <see cref="EventHubBufferedProducerClient.EnqueueEventAsync(EventData, EnqueueEventOptions, System.Threading.CancellationToken)" /> or
        ///   <see cref="EventHubBufferedProducerClient.EnqueueEventsAsync(IEnumerable{EventData}, EnqueueEventOptions, System.Threading.CancellationToken)" />, which will automatically wait for room to be available.
        /// </summary>
        ///
        /// <value>
        ///   The default limit is 1500 queued events for each partition.
        /// </value>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested count is not between 1 and 1 million (inclusive).</exception>
        ///
        public int MaximumEventBufferLengthPerPartition
        {
            get => _maximumEventBufferLengthPerPartition;
            set
            {
                // An upper bound of 1 million was chosen because it offers enough room for
                // 2147 partitions to be completely full before overflowing an integer value.
                // The current cap for general Event Hubs use is 32 partitions.
                //
                // Important enterprise customers can request up to 2000.

                Argument.AssertInRange(value, 1, 1_000_000, nameof(MaximumEventBufferLengthPerPartition));
                _maximumEventBufferLengthPerPartition = value;
            }
        }

        /// <summary>
        ///   The total number of batches that may be sent concurrently, across all partitions.  This limit takes precedence over
        ///   the value specified in <see cref="MaximumConcurrentSendsPerPartition" />, ensuring this maximum is respected.
        /// </summary>
        ///
        /// <value>
        ///   By default, this will be set to the number of processors available in the host environment.
        /// </value>
        ///
        /// <remarks>
        ///   When batches for the same partition are published concurrently, the ordering of events is not guaranteed.  If the order events are published
        ///   must be maintained, <see cref="MaximumConcurrentSendsPerPartition" /> should not exceed 1.
        /// </remarks>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested count is not between 1 and 100 (inclusive).</exception>
        ///
        public int MaximumConcurrentSends
        {
            get => _maximumConcurrentSends;
            set
            {
                Argument.AssertInRange(value, 1, 100, nameof(MaximumConcurrentSends));
                _maximumConcurrentSends = value;
            }
        }

        /// <summary>
        ///   The number of batches that may be sent concurrently for a given partition.  This option is superseded by
        ///   the value specified for <see cref="MaximumConcurrentSends" />, ensuring that limit is respected.
        /// </summary>
        ///
        /// <value>
        ///   By default, each partition will allow only one publishing operation to be active in
        ///   order to ensure that events are published in the order that they were enqueued.
        ///</value>
        ///
        /// <remarks>
        ///   When batches for the same partition are published concurrently, the ordering of events is not guaranteed.  If the order of events
        ///   must be maintained, <see cref="MaximumConcurrentSendsPerPartition" /> should not exceed 1.
        /// </remarks>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested count is not between 1 and 100 (inclusive).</exception>
        ///
        public int MaximumConcurrentSendsPerPartition
        {
            get => _maximumConcurrentSendsPerPartition;
            set
            {
                Argument.AssertInRange(value, 1, 100, nameof(MaximumConcurrentSendsPerPartition));
                _maximumConcurrentSendsPerPartition = value;
            }
        }

        /// <summary>
        ///   A unique name used to identify the consumer.  If <c>null</c> or empty, a GUID will be used as the
        ///   identifier.
        /// </summary>
        ///
        public string Identifier { get; set; }

        /// <summary>
        ///   The options used for configuring the connection to the Event Hubs service.
        /// </summary>
        ///
        public EventHubConnectionOptions ConnectionOptions
        {
            get => _connectionOptions;
            set
            {
                Argument.AssertNotNull(value, nameof(ConnectionOptions));
                _connectionOptions = value;
            }
        }

        /// <summary>
        ///   The set of options to use for determining whether a failed operation should be retried and,
        ///   if so, the amount of time to wait between retry attempts.  These options also control the
        ///   amount of time allowed for publishing events and other interactions with the Event Hubs service.
        /// </summary>
        ///
        public EventHubsRetryOptions RetryOptions
        {
            get => _retryOptions;
            set
            {
                Argument.AssertNotNull(value, nameof(RetryOptions));
                _retryOptions = value;
            }
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubBufferedProducerClientOptions"/> class.
        /// </summary>
        ///
        public EventHubBufferedProducerClientOptions()
        {
            _retryOptions = new EventHubsRetryOptions
            {
                MaximumRetries = 15,
                TryTimeout = TimeSpan.FromMinutes(3),
            };
        }

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" /> is equal to this instance.
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

        /// <summary>
        ///   Creates a new copy of the current <see cref="EventHubBufferedProducerClientOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="EventHubBufferedProducerClientOptions" />.</returns>
        ///
        internal EventHubBufferedProducerClientOptions Clone()
        {
            var copiedOptions = new EventHubBufferedProducerClientOptions
            {
                Identifier = Identifier,
                EnableIdempotentRetries = EnableIdempotentRetries,
                _connectionOptions = ConnectionOptions.Clone(),
                _retryOptions = RetryOptions.Clone(),
                _maximumEventBufferLengthPerPartition = MaximumEventBufferLengthPerPartition,
                _maximumWaitTime = MaximumWaitTime,
                _maximumConcurrentSends = MaximumConcurrentSends,
                _maximumConcurrentSendsPerPartition = MaximumConcurrentSendsPerPartition
            };

            return copiedOptions;
        }

        /// <summary>
        /// Creates an <see cref="EventHubProducerClientOptions"/> from the current instance.
        /// </summary>
        ///
        /// <remarks>
        ///   This method does not make defensive copies of the references properties; it is assumed that they'll be used with
        ///    the <see cref="EventHubProducerClient" /> which has responsibility for ensuring defensive copies when constructed.
        /// </remarks>
        ///
        /// <returns>The set of options represented as <see cref="EventHubProducerClientOptions"/></returns>
        ///
        internal EventHubProducerClientOptions ToEventHubProducerClientOptions()
        {
            var translatedOptions = new EventHubProducerClientOptions
            {
                Identifier = Identifier,
                EnableIdempotentPartitions = EnableIdempotentRetries,
                ConnectionOptions = ConnectionOptions,
                RetryOptions = RetryOptions
            };
            return translatedOptions;
        }
    }
}
