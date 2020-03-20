// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    public class ServiceBusReceiverOptions
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
        internal ServiceBusReceiverOptions Clone() =>
            new ServiceBusReceiverOptions
            {
                ReceiveMode = ReceiveMode,
                PrefetchCount = PrefetchCount
            };
    }
}
