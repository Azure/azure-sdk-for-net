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
        /// Gets or sets a value indicating whether the session is locked non-exclusively, allowing another receiver to
        /// cooperatively take over the session by presenting its <see cref="SessionLockToken"/>. When <c>false</c>
        /// (the default), the session is locked exclusively and no other receiver can access it until the lock is released.
        /// </summary>
        ///
        /// <remarks>
        /// Because a non-exclusive session can change hands, settlement for such a session is routed over the management
        /// link rather than the receive link, so that messages delivered to a previous holder can still be settled. This
        /// costs a request/response exchange on the shared management link per settlement rather than a disposition on
        /// the receiver's own link, which lowers settlement throughput compared to an exclusive session.
        ///
        /// <para>Accepting a session with this set throws <see cref="NotSupportedException"/> when the endpoint declines it,
        /// either by refusing the request outright or by accepting it without assigning a lock token, so catching that is how
        /// a caller detects whether the feature is available for a namespace. An endpoint that declines in some other way
        /// surfaces the exception its own error maps to.</para>
        /// </remarks>
        public bool EnableNonExclusiveSession { get; set; }

        /// <summary>
        /// Gets or sets the session lock token to present when cooperatively taking over a non-exclusive session. This must be
        /// the token previously assigned by the service to the session, as reported by
        /// <see cref="ServiceBusSessionReceiver.SessionLockToken"/> on the receiver that currently holds it, and is only valid
        /// when <see cref="EnableNonExclusiveSession"/> is <c>true</c> and a specific session is being accepted (validated when
        /// the receiver is created).
        /// </summary>
        /// <remarks>
        /// The service represents this token as a GUID on the wire, so it is taken here as a <see cref="Guid"/> while the
        /// receiver reports it as a <see cref="string"/>, matching how lock tokens are surfaced elsewhere in the library.
        /// Convert with <see cref="Guid.Parse(string)"/> when taking a session over from another receiver.
        ///
        /// <para>This token authorizes taking over the session lock for any caller with Listen rights on the entity, so treat
        /// it as sensitive: do not log it, do not persist it unprotected, and transmit it only over a trusted channel.</para>
        /// </remarks>
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
            new ServiceBusReceiverOptions(!EnableNonExclusiveSession, SessionLockToken)
            {
                ReceiveMode = ReceiveMode,
                PrefetchCount = PrefetchCount,
                Identifier = Identifier
            };
    }
}
