// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using Azure.Core;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The set of options that can be specified when creating a
    /// <see cref="ServiceBusProcessor" /> to configure its behavior.
    /// </summary>
    public class ServiceBusProcessorOptions
    {
        /// <summary>
        /// Gets or sets the number of messages that will be eagerly requested
        /// from Queues or Subscriptions and queued locally, intended to help
        /// maximize throughput by allowing the processor to receive
        /// from a local cache rather than waiting on a service request.
        /// </summary>
        /// <value>The default value is 0.</value>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   A negative value is attempted to be set for the property.
        /// </exception>
        public int PrefetchCount
        {
            get
            {
                return _prefetchCount;
            }
            set
            {
                Argument.AssertAtLeast(value, 0, nameof(PrefetchCount));
                _prefetchCount = value;
            }
        }
        private volatile int _prefetchCount;

        /// <summary>
        /// Gets or sets the <see cref="ReceiveMode"/> used to specify how messages
        /// are received.
        /// </summary>
        ///
        /// <value>The mode to use for receiving messages. The default value is <see cref="ServiceBusReceiveMode.PeekLock"/>.</value>
        public ServiceBusReceiveMode ReceiveMode { get; set; } = ServiceBusReceiveMode.PeekLock;

        /// <summary>
        /// Gets or sets a value that indicates whether the processor
        /// should automatically complete messages after the <see cref="ServiceBusProcessor.ProcessMessageAsync"/> handler has
        /// completed processing. If the message handler triggers an exception, the message will not be automatically completed.
        /// </summary>
        /// <remarks>
        /// If the message handler triggers an exception and did not settle the message,
        /// then the message will be automatically abandoned, irrespective of <see cref= "AutoCompleteMessages" />.
        /// </remarks>
        ///
        /// <value><c>true</c> to complete the message automatically on successful execution of the message handler; otherwise, <c>false</c>.
        /// The default value is <c>true</c>.</value>
        public bool AutoCompleteMessages { get; set; } = true;

        /// <summary>
        /// Gets or sets the maximum duration within which the lock will be renewed automatically. This
        /// value should be greater than the longest message lock duration; for example, the LockDuration Property.
        /// To specify an infinite duration, use <see cref="Timeout.InfiniteTimeSpan"/>.
        /// </summary>
        ///
        /// <value>The maximum duration during which message locks are automatically renewed. The default value is 5 minutes.</value>
        ///
        /// <remarks>The message renew can continue for sometime in the background
        /// after completion of message and result in a few false MessageLockLostExceptions temporarily.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   A negative value is attempted to be set for the property.
        /// </exception>
        public TimeSpan MaxAutoLockRenewalDuration
        {
            get => _maxAutoRenewDuration;

            set
            {
                if (value != Timeout.InfiniteTimeSpan)
                {
                    Argument.AssertNotNegative(value, nameof(MaxAutoLockRenewalDuration));
                }
                _maxAutoRenewDuration = value;
            }
        }
        private TimeSpan _maxAutoRenewDuration = TimeSpan.FromMinutes(5);

        /// <summary>
        /// The maximum amount of time to wait for each Receive call using the processor's underlying receiver.
        /// If not specified, the <see cref="ServiceBusRetryOptions.TryTimeout"/> will be used.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   A value that is not positive is attempted to be set for the property.
        /// </exception>
        internal TimeSpan? MaxReceiveWaitTime
        {
            get => _maxReceiveWaitTime;

            set
            {
                if (value.HasValue)
                {
                    Argument.AssertPositive(value.Value, nameof(MaxReceiveWaitTime));
                }

                _maxReceiveWaitTime = value;
            }
        }
        private TimeSpan? _maxReceiveWaitTime;

        /// <summary>Gets or sets the maximum number of concurrent calls to the
        /// message handler the processor should initiate.
        /// </summary>
        ///
        /// <value>The maximum number of concurrent calls to the message handler. The default value is 1.</value>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   A value that is not positive is attempted to be set for the property.
        /// </exception>
        public int MaxConcurrentCalls
        {
            get => _maxConcurrentCalls;

            set
            {
                Argument.AssertAtLeast(value, 1, nameof(MaxConcurrentCalls));
                _maxConcurrentCalls = value;
            }
        }
        private volatile int _maxConcurrentCalls = 1;

        /// <summary>
        /// Gets or sets the subqueue to connect the processor to.
        /// </summary>
        ///
        /// <value>The subqueue to connect the processor to. The default value is <see cref="SubQueue.None"/>, meaning the processor will
        /// not connect to a subqueue.
        /// </value>
        public SubQueue SubQueue { get; set; } = SubQueue.None;

        /// <summary>
        /// A property used to set the <see cref="ServiceBusProcessor"/> ID to identify the processor. This can be used to correlate logs
        /// and exceptions. If <c>null</c> or empty, a random unique value will be used.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        /// Creates a new copy of the current <see cref="ServiceBusProcessorOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="ServiceBusProcessorOptions" />.</returns>
        internal ServiceBusProcessorOptions Clone()
        {
            return new ServiceBusProcessorOptions
            {
                ReceiveMode = ReceiveMode,
                PrefetchCount = PrefetchCount,
                AutoCompleteMessages = AutoCompleteMessages,
                MaxAutoLockRenewalDuration = MaxAutoLockRenewalDuration,
                MaxReceiveWaitTime = MaxReceiveWaitTime,
                MaxConcurrentCalls = MaxConcurrentCalls,
                SubQueue = SubQueue,
                Identifier = Identifier
            };
        }
    }
}
