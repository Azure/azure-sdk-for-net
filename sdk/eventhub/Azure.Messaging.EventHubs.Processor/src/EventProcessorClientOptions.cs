﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Processor;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   The set of options that can be specified when creating an <see cref="EventProcessorClient" />
    ///   to configure its behavior.
    /// </summary>
    ///
    public class EventProcessorClientOptions
    {
        /// <summary>The maximum amount of time to wait for an event to become available before emitting an <c>null</c> value.</summary>
        private TimeSpan? _maximumWaitTime = null;

        /// <summary>The set of options to use for configuring the connection to the Event Hubs service.</summary>
        private EventHubConnectionOptions _connectionOptions = new EventHubConnectionOptions();

        /// <summary>The set of options to govern retry behavior and try timeouts.</summary>
        private EventHubsRetryOptions _retryOptions = new EventHubsRetryOptions();

        /// <summary>
        ///   A unique name used to identify the event processor.  If <c>null</c> or empty, a GUID will be used as the
        ///   identifier.
        /// </summary>
        ///
        public string Identifier { get; set; }

        /// <summary>
        ///   Indicates whether or not the consumer should request information on the last enqueued event on the partition
        ///   associated with a given event, and track that information as events are received.
        /// </summary>
        ///
        /// <value><c>true</c> if information about a partition's last event should be requested and tracked; otherwise, <c>false</c>.</value>
        ///
        /// <remarks>
        ///   When information about a partition's last enqueued event is being tracked, each event received from the Event Hubs
        ///   service will carry metadata about the partition that it otherwise would not. This results in a small amount of
        ///   additional network bandwidth consumption that is generally a favorable trade-off when considered
        ///   against periodically making requests for partition properties using one of the Event Hub clients.
        /// </remarks>
        ///
        public bool TrackLastEnqueuedEventProperties { get; set; } = true;

        /// <summary>
        ///   The maximum amount of time to wait for an event to become available for a given partition before emitting
        ///   an empty event.
        /// </summary>
        ///
        /// <value>
        ///   If <c>null</c>, the processor will wait indefinitely for an event to become available; otherwise, a value will
        ///   always be emitted within this interval, whether an event was available or not.
        /// </value>
        ///
        /// <remarks>
        ///   When set, if no events are received before the timeout, <see cref="EventProcessorClient.ProcessEventAsync" />
        ///   is called with a <see cref="ProcessEventArgs" /> instance that does not contain any event data. The
        ///   <see cref="ProcessEventArgs.HasEvent" /> property is intended to help detect this.
        /// </remarks>
        ///
        /// <seealso cref="ProcessEventArgs.HasEvent" />
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
        ///   Gets or sets the options used for configuring the connection to the Event Hubs service.
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
        ///   Creates a new copy of the current <see cref="EventProcessorClientOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="EventProcessorClientOptions" />.</returns>
        ///
        internal EventProcessorClientOptions Clone() =>
            new EventProcessorClientOptions
            {
                Identifier = Identifier,
                TrackLastEnqueuedEventProperties = TrackLastEnqueuedEventProperties,
                _maximumWaitTime = _maximumWaitTime,
                _connectionOptions = ConnectionOptions.Clone(),
                _retryOptions = RetryOptions.Clone()
            };
    }
}
