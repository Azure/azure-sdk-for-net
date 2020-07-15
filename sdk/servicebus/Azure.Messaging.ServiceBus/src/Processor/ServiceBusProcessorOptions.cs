// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The baseline set of options that can be specified when creating a <see cref="ServiceBusProcessor" />
    /// to configure its behavior.
    /// </summary>
    public class ServiceBusProcessorOptions
    {
        /// <summary>
        /// The number of messages that will be eagerly requested from Queues or Subscriptions and queued locally without regard to
        /// whether a processing is currently active, intended to help maximize throughput by allowing the receiver to receive
        /// from a local cache rather than waiting on a service request.
        /// </summary>
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
        private int _prefetchCount = 0;

        /// <summary>
        /// The <see cref="ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.
        /// </summary>
        public ReceiveMode ReceiveMode { get; set; } = ReceiveMode.PeekLock;

        /// <summary>Gets or sets a value that indicates whether the message-pump should call
        /// Receiver.CompleteAsync() on messages after the callback has completed processing.
        /// The default value is true.</summary>
        /// <value>true to complete the message processing automatically on successful execution of the operation; otherwise, false.</value>
        public bool AutoComplete { get; set; } = true;

        /// <summary>
        /// Gets or sets the maximum duration within which the lock will be renewed automatically. This
        /// value should be greater than the longest message lock duration; for example, the LockDuration Property.
        /// </summary>
        ///
        /// <value>The maximum duration during which locks are automatically renewed.</value>
        ///
        /// <remarks>The message renew can continue for sometime in the background
        /// after completion of message and result in a few false MessageLockLostExceptions temporarily.</remarks>
        public TimeSpan MaxAutoLockRenewalDuration
        {
            get => _maxAutoRenewDuration;

            set
            {
                Argument.AssertNotNegative(value, nameof(MaxAutoLockRenewalDuration));
                _maxAutoRenewDuration = value;
            }
        }
        private TimeSpan _maxAutoRenewDuration = TimeSpan.FromMinutes(5);

        /// <summary>
        ///   The maximum amount of time to wait for each Receive call using the processor's underlying receiver. If not specified, the <see cref="ServiceBusRetryOptions.TryTimeout"/> will be used.
        /// </summary>
        /// <remarks>When using a <see cref="ServiceBusSessionProcessor"/>, if no message is returned for a call to Receive, a new session will be requested by the processor. Hence, if this value is set to be too low, it could cause new sessions to be requested more often than necessary.</remarks>
        public TimeSpan? MaxReceiveWaitTime
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

        /// <summary>Gets or sets the maximum number of concurrent calls to the callback the processor should initiate. The default is 1.</summary>
        /// <value>The maximum number of concurrent calls to the callback.</value>
        public int MaxConcurrentCalls
        {
            get => _maxConcurrentCalls;

            set
            {
                Argument.AssertAtLeast(value, 1, nameof(MaxConcurrentCalls));
                _maxConcurrentCalls = value;
            }
        }
        private int _maxConcurrentCalls;

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
            var clone = new ServiceBusProcessorOptions
            {
                ReceiveMode = ReceiveMode,
                PrefetchCount = PrefetchCount,
                AutoComplete = AutoComplete,
                MaxAutoLockRenewalDuration = MaxAutoLockRenewalDuration,
                MaxReceiveWaitTime = MaxReceiveWaitTime
            };
            if (MaxConcurrentCalls > 0)
            {
                clone.MaxConcurrentCalls = MaxConcurrentCalls;
            }
            return clone;
        }
    }
}
