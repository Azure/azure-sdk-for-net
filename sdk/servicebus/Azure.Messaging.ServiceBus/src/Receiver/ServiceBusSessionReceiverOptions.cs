// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The set of options that can be specified when creating a <see cref="ServiceBusSessionReceiver"/>
    /// to configure its behavior.
    /// </summary>
    public class ServiceBusSessionReceiverOptions
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

        /// <inheritdoc cref="ServiceBusReceiverOptions.Identifier"/>
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the session is locked exclusively by this receiver. When <c>true</c>
        /// (the default), the session is locked exclusively and no other receiver can access it until the lock is released.
        /// When <c>false</c>, the session is locked non-exclusively, allowing another receiver to cooperatively take over the
        /// session by presenting its <see cref="SessionLockToken"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public bool IsSessionExclusive { get; set; } = true;

        /// <summary>
        /// Gets or sets the session lock token to present when cooperatively taking over a non-exclusive session. This must be
        /// the token previously assigned by the service to the session (see <see cref="ServiceBusSessionReceiver.SessionLockToken"/>),
        /// and is only valid when <see cref="IsSessionExclusive"/> is <c>false</c> and a specific session is being accepted
        /// (validated when the receiver is created).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public Guid? SessionLockToken { get; set; }

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

        internal ServiceBusReceiverOptions ToReceiverOptions() =>
            new ServiceBusReceiverOptions()
            {
                ReceiveMode = ReceiveMode,
                PrefetchCount = PrefetchCount,
                Identifier = Identifier,
                IsSessionExclusive = IsSessionExclusive,
                SessionLockToken = SessionLockToken
            };
    }
}
