// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Globalization;
using System.Net;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   The set of options that can be specified when creating an <see cref="EventHubClient" />
    ///   to configure its behavior.
    /// </summary>
    ///
    public class EventHubClientOptions
    {
        /// <summary>The value to use as the default for the <see cref="DefaultTimeout" /> property.</summary>
        protected static readonly TimeSpan DefaultTimeoutValue = TimeSpan.FromMinutes(1);

        /// <summary>The retry policy to apply to operations.</summary>
        protected Retry _retry = Retry.Default;

        /// <summary>the timeout that will be used by default for operations.</summary>
        protected TimeSpan _defaultTimeout = DefaultTimeoutValue;

        /// <summary>
        ///   The type of connection that will be used for communicating with the Event Hubs
        ///   service.
        /// </summary>
        ///
        public ConnectionType ConnectionType { get; set; } = ConnectionType.AmqpTcp;

        /// <summary>
        ///   The proxy to use for communication over web sockets.  If not specified,
        ///   the system-wide proxy settings will be honored.
        /// </summary>
        ///
        /// <remarks>
        ///   A proxy cannot be used for communication over TCP; if web sockets are not in
        ///   use, specifying a proxy is an invalid option.
        /// </remarks>
        ///
        public IWebProxy Proxy { get; set; } = null;

        /// <summary>
        ///   The policy to use for determining whether a failed operation should be retried and,
        ///   if so, the amount of time to wait between retry attempts.
        /// </summary>
        ///
        public Retry Retry
        {
            get => _retry;

            set
            {
                ValidateRetry(value);
                _retry = value;
            }
        }

        /// <summary>
        ///   Gets or sets the timeout that will be used by default for operations associated with
        ///   the requested Event Hub.
        /// </summary>
        ///
        public TimeSpan DefaultTimeout
        {
            get => _defaultTimeout;

            set
            {
                ValidateDefaultTimeout(value);
                _defaultTimeout = value;
            }
        }

        /// <summary>
        ///   Normalizes the specified timeout value, returning the timeout period or the
        ///   a <c>null</c> value if no timeout was specified.
        /// </summary>
        ///
        internal TimeSpan? TimeoutOrDefault => (_defaultTimeout == TimeSpan.Zero) ? DefaultTimeoutValue : _defaultTimeout;

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" />, is equal to this instance.
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
        ///   Creates a new copy of the current <see cref="EventHubClientOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="EventHubClientOptions" />.</returns>
        ///
        internal EventHubClientOptions Clone() =>
            new EventHubClientOptions
            {
                Retry = this.Retry.Clone(),
                ConnectionType = this.ConnectionType,
                DefaultTimeout = this.DefaultTimeout,
                Proxy = this.Proxy
            };

        /// <summary>
        ///   Validates the time period specified as the default operation timeout, throwing an <see cref="ArgumentException" /> if
        ///   it is not valid.
        /// </summary>
        ///
        /// <param name="timeout">The time period to validate.</param>
        ///
        protected virtual void ValidateDefaultTimeout(TimeSpan timeout)
        {
            if (timeout < TimeSpan.Zero)
            {
                throw new ArgumentException(Resources.TimeoutMustBePositive, nameof(DefaultTimeout));
            }
        }

        /// <summary>
        ///   Validates the retry policy specified, throwing an <see cref="ArgumentException" /> if it is not valid.
        /// </summary>
        ///
        /// <param name="retry">The time period to validae.</param>
        ///
        protected virtual void ValidateRetry(Retry retry)
        {
            if (retry == null)
            {
                throw new ArgumentException(Resources.RetryMustBeSet, nameof(Retry));
            }
        }
    }
}
