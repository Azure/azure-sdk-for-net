// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> dcfbe04dad (responding to feedback)
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;
<<<<<<< HEAD
=======
using System.ComponentModel;
using Azure.Core;
>>>>>>> 88750fe801 (Adding skeleton files)
=======
>>>>>>> dcfbe04dad (responding to feedback)

namespace Azure.Messaging.EventHubs.Producer
{
    /// <summary>
    ///   The set of options that can be specified when creating an <see cref="EventHubBufferedProducerClient" />
    ///   to configure its behavior.
    /// </summary>
    ///
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    internal class EventHubBufferedProducerClientOptions
    {
        /// <summary> The number of batches that may be sent concurrently to each partition. </summary>
        private int _maximumConcurrentSendsPerPartition = 1;

        /// <summary>The set of options to use for configuring the connection to the Event Hubs service.</summary>
        private EventHubConnectionOptions _connectionOptions = new EventHubConnectionOptions();

        /// <summary>The set of options to govern retry behavior and try timeouts.</summary>
        private EventHubsRetryOptions _retryOptions = new EventHubsRetryOptions();

=======
    public class EventHubBufferedProducerClientOptions : EventHubProducerClientOptions
=======
    internal class EventHubBufferedProducerClientOptions : EventHubProducerClientOptions
>>>>>>> c7457cff4d (updated to internal classes)
=======
    internal class EventHubBufferedProducerClientOptions
>>>>>>> dcfbe04dad (responding to feedback)
    {
>>>>>>> 88750fe801 (Adding skeleton files)
        /// <summary>
        ///   The amount of time to wait for a new event to be added to the buffer before sending a partially
        ///   full batch.
        /// </summary>
        ///
        /// <value>
        ///   The default wait time is 250 milliseconds.
        /// </value>
        ///
        public TimeSpan? MaximumWaitTime { get; set; } = TimeSpan.FromMilliseconds(250);

        /// <summary>
        ///   The total number of events that can be buffered for publishing at a given time across all partitions.
        ///   Once this capacity is reached, more events can enqueued by calling <see cref="EventHubBufferedProducerClient.EnqueueEventAsync(EventData, EnqueueEventOptions, System.Threading.CancellationToken)" /> or
        ///   <see cref="EventHubBufferedProducerClient.EnqueueEventsAsync(System.Collections.Generic.IEnumerable{EventData}, EnqueueEventOptions, System.Threading.CancellationToken)" />, which will automatically wait for room to be available.
        /// </summary>
        ///
        /// <value>
        ///   The default limit is 2,500 queued events.
        /// </value>
        ///
<<<<<<< HEAD
<<<<<<< HEAD
        public int MaximumEventBufferLength { get; set; } = 2500;
=======
        public int MaximumBufferedEventCount { get; set; } = 2500;
>>>>>>> 88750fe801 (Adding skeleton files)
=======
        public int MaximumEventBufferLength { get; set; } = 2500;
>>>>>>> dcfbe04dad (responding to feedback)

        /// <summary>
        ///    Indicates whether or not events should be published using idempotent semantics for retries. If enabled, retries during publishing
        ///    will attempt to avoid duplication with a minor cost to throughput.  Duplicates are still possible but the chance of them occurring is
        ///    much lower when idempotent retries are enabled.
        ///</summary>
        ///
        /// <value>
        ///   By default, idempotent retries are disabled.
        ///</value>
        ///
        /// <remarks>
        ///   It is important to note that enabling idempotent retries does not guarantee exactly-once semantics.  The existing
        ///   Event Hubs at-least-once delivery contract still applies and event duplication is unlikely, but possible.
        /// </remarks>
        ///
        public bool EnableIdempotentRetries { get; set; }

        /// <summary>
        ///   The number of batches that may be sent concurrently to each partition.
        /// </summary>
        ///
        /// <value>
        ///   By default, each partition will allow only one publishing operation to be active in
        ///   order to ensure that events are published in the order that they were enqueued.
        ///</value>
        ///
        /// <remarks>
        ///   When batches are published concurrently, the ordering of events is not guaranteed.  If the order events are published
        ///   must be maintained, <see cref="MaximumConcurrentSendsPerPartition" /> should not exceed 1.
        /// </remarks>
        ///
<<<<<<< HEAD
<<<<<<< HEAD
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested count is not between 1 and 100 (inclusive).</exception>
        ///
=======
>>>>>>> 88750fe801 (Adding skeleton files)
=======
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested count is not between 1 and 100 (inclusive).</exception>
        ///
>>>>>>> dcfbe04dad (responding to feedback)
        public int MaximumConcurrentSendsPerPartition
        {
            get => _maximumConcurrentSendsPerPartition;
            set
            {
                Argument.AssertInRange(value, 1, 100, nameof(MaximumConcurrentSendsPerPartition));
                _maximumConcurrentSendsPerPartition = value;
            }
        }

<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> dcfbe04dad (responding to feedback)
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
<<<<<<< HEAD
=======
=======

        /// <summary>
        ///   Indicates whether or not the producer should enable idempotent publishing to the Event Hub partitions.  If
        ///   enabled, the producer will only be able to publish directly to partitions; it will not be able to publish to
        ///   the Event Hubs gateway for automatic partition routing nor using a partition key.
        /// </summary>
        ///
        /// <value><c>true</c> if the producer should enable idempotent partition publishing; otherwise, <c>false</c>.</value>
        ///
        internal bool EnableIdempotentPartitions { get; set; }

        /// <summary>
        ///   The set of options that can be specified to influence publishing behavior specific to the configured Event Hub partition.  These
        ///   options are not necessary in the majority of scenarios and are intended for use with specialized scenarios, such as when
        ///   recovering the state used for idempotent publishing.
        ///
        ///   <para>It is highly recommended that these options only be specified if there is a proven need to do so; Incorrectly configuring these
        ///   values may result in an <see cref="EventHubProducerClient" /> instance that is unable to publish to the Event Hubs.</para>
        /// </summary>
        ///
        /// <remarks>
        ///   These options are ignored when publishing to the Event Hubs gateway for automatic routing or when using a partition key.
        /// </remarks>
        ///
        internal Dictionary<string, PartitionPublishingOptions> PartitionOptions { get; } = new Dictionary<string, PartitionPublishingOptions>();

>>>>>>> dcfbe04dad (responding to feedback)
        /// <summary> The number of batches that may be sent concurrently to each partition. </summary>
        private int _maximumConcurrentSendsPerPartition = 1;
>>>>>>> 88750fe801 (Adding skeleton files)

        /// <summary>The set of options to use for configuring the connection to the Event Hubs service.</summary>
        private EventHubConnectionOptions _connectionOptions = new EventHubConnectionOptions();

        /// <summary>The set of options to govern retry behavior and try timeouts.</summary>
        private EventHubsRetryOptions _retryOptions = new EventHubsRetryOptions();

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
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> dcfbe04dad (responding to feedback)

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
<<<<<<< HEAD
                MaximumEventBufferLength = MaximumEventBufferLength,
                MaximumWaitTime = MaximumWaitTime,
                EnableIdempotentRetries = EnableIdempotentRetries,
                _connectionOptions = ConnectionOptions.Clone(),
                _retryOptions = RetryOptions.Clone(),
                _maximumConcurrentSendsPerPartition = MaximumConcurrentSendsPerPartition
            };

=======
                EnableIdempotentPartitions = EnableIdempotentPartitions,
                _connectionOptions = ConnectionOptions.Clone(),
                _retryOptions = RetryOptions.Clone(),
                _maximumConcurrentSendsPerPartition = MaximumConcurrentSendsPerPartition,
                MaximumEventBufferLength = MaximumEventBufferLength,
                MaximumWaitTime = MaximumWaitTime,
                EnableIdempotentRetries = EnableIdempotentRetries
            };

            foreach (var pair in PartitionOptions)
            {
                copiedOptions.PartitionOptions.Add(pair.Key, pair.Value.Clone());
            }

>>>>>>> dcfbe04dad (responding to feedback)
            return copiedOptions;
        }

        /// <summary>
        /// Creates an <see cref="EventHubProducerClientOptions"/> from the current instance.
        /// </summary>
        ///
<<<<<<< HEAD
<<<<<<< HEAD
        /// <remarks>
        ///   This method does not make defensive copies of the references properties; it is assumed that they'll be used with
        ///    the <see cref="EventHubProducerClient" /> which has responsibility for ensuring defensive copies when constructed.
        /// </remarks>
        ///
=======
>>>>>>> dcfbe04dad (responding to feedback)
=======
        /// <remarks>
        ///   This method does not make defensive copies of the references properties; it is assumed that they'll be used with 
        ///    the <see cref="EventHubProducerClient" /> which has responsibility for ensuring defensive copies when constructed.
        /// </remarks>
        ///
>>>>>>> cb7c6b4182 (Update sdk/eventhub/Azure.Messaging.EventHubs/src/Producer/EventHubBufferedProducerClientOptions.cs)
        /// <returns>The set of options represented as <see cref="EventHubProducerClientOptions"/></returns>
        ///
        internal EventHubProducerClientOptions ToEventHubProducerClientOptions()
        {
            var translatedOptions = new EventHubProducerClientOptions
            {
                Identifier = Identifier,
<<<<<<< HEAD
<<<<<<< HEAD
                EnableIdempotentPartitions = EnableIdempotentRetries,
=======
                EnableIdempotentPartitions = EnableIdempotentPartitions,
>>>>>>> dcfbe04dad (responding to feedback)
=======
                EnableIdempotentPartitions = EnableIdempotentRetries,
>>>>>>> 233f6fedbb (Update sdk/eventhub/Azure.Messaging.EventHubs/src/Producer/EventHubBufferedProducerClientOptions.cs)
                ConnectionOptions = ConnectionOptions,
                RetryOptions = RetryOptions
            };
            return translatedOptions;
        }
<<<<<<< HEAD
=======
>>>>>>> 88750fe801 (Adding skeleton files)
=======

        /// <summary>
        ///   Creates the set of flags that represents the features requested by these options.
        /// </summary>
        ///
        /// <returns>The set of features that were requested for the <see cref="EventHubProducerClient" />.</returns>
        ///
        internal TransportProducerFeatures CreateFeatureFlags()
        {
            var features = TransportProducerFeatures.None;

            if (EnableIdempotentPartitions)
            {
                features |= TransportProducerFeatures.IdempotentPublishing;
            }

            return features;
        }

        /// <summary>
        ///   Attempts to retrieve the publishing options for a given partition, returning a
        ///   default in the case that no partition was specified or there were no available options
        ///   for that partition.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition for which options are requested.</param>
        ///
        /// <returns><c>null</c> in the event that there was no partition specified or no options for the partition; otherwise, the publishing options.</returns>
        ///
        internal PartitionPublishingOptions GetPublishingOptionsOrDefaultForPartition(string partitionId)
        {
            if (string.IsNullOrEmpty(partitionId))
            {
                return default;
            }

            PartitionOptions.TryGetValue(partitionId, out var options);
            return options;
        }
>>>>>>> dcfbe04dad (responding to feedback)
    }
}
