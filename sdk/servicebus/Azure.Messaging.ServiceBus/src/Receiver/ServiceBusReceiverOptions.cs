// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The set of options that can be specified when creating a <see cref="ServiceBusReceiver"/>
    /// to configure its behavior.
    /// </summary>
    public class ServiceBusReceiverOptions
    {
        /// <summary>
        /// Gets or sets the number of messages that will be eagerly requested from Queues or Subscriptions and queued locally without regard to
        /// whether the receiver is actively receiving, intended to help maximize throughput by allowing the receiver to receive
        /// from a local cache rather than waiting on a service request.
        /// </summary>
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
        private int _prefetchCount;

        /// <summary>
        /// Gets or sets the <see cref="ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.
        /// </summary>
        public ServiceBusReceiveMode ReceiveMode { get; set; } = ServiceBusReceiveMode.PeekLock;

        /// <summary>
        /// A property used to set the <see cref="ServiceBusReceiver"/> ID to identify the client. This can be used to correlate logs
        /// and exceptions. If <c>null</c> or empty, a random unique value will be used.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the subqueue to connect the receiver to. By default, the receiver will not connect to a subqueue.
        /// </summary>
        public SubQueue SubQueue { get; set; } = SubQueue.None;

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
    }
}
