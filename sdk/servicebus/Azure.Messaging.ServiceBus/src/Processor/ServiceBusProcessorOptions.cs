// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Primitives;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The baseline set of options that can be specified when creating a <see cref="ServiceBusReceiver"/> or <see cref="ServiceBusProcessor" />
    /// to configure its behavior.
    /// </summary>
    public class ServiceBusProcessorOptions
    {
        /// <summary>
        /// The set of options to use for configuring the connection to the Service Bus entities.
        /// </summary>
        internal ServiceBusClientOptions _connectionOptions = new ServiceBusClientOptions();

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
                if (value < 0)
                {
                    throw Fx.Exception.ArgumentOutOfRange(nameof(PrefetchCount), value, "Value cannot be less than 0.");
                }
                _prefetchCount = value;
            }
        }
        private int _prefetchCount = 0;

        /// <summary>
        /// The <see cref="ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.
        /// </summary>
        public ReceiveMode ReceiveMode { get; set; } = ReceiveMode.PeekLock;

        /// <summary>
        /// Gets or sets the options used for configuring the connection to the Service Bus entities.
        /// </summary>
        internal ServiceBusClientOptions ConnectionOptions
        {
            get => _connectionOptions;
            set
            {
                Argument.AssertNotNull(value, nameof(ConnectionOptions));
                _connectionOptions = value;
            }
        }

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
                TimeoutHelper.ThrowIfNegativeArgument(value, nameof(value));
                _maxAutoRenewDuration = value;
            }
        }
        private TimeSpan _maxAutoRenewDuration = TimeSpan.FromMinutes(5);

        /// <summary>Gets or sets the maximum number of concurrent calls to the callback the message pump should initiate. The default value when used with a session processor is 8. For a non-session processor, the default is 1.</summary>
        /// <value>The maximum number of concurrent calls to the callback.</value>
        public int MaxConcurrentCalls
        {
            get => _maxConcurrentCalls;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(Resources.MaxConcurrentCallsMustBeGreaterThanZero.FormatForUser(value));
                }

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
        /// Creates a new copy of the current <see cref="ServiceBusReceiverOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="ServiceBusReceiverOptions" />.</returns>
        internal ServiceBusProcessorOptions Clone() =>
            new ServiceBusProcessorOptions
            {
                _connectionOptions = ConnectionOptions.Clone(),
                ReceiveMode = ReceiveMode,
                AutoComplete = AutoComplete,
                MaxAutoLockRenewalDuration = MaxAutoLockRenewalDuration
            };
    }
}
