// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
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
        /// <summary>The set of options to apply for retrying failed operations.</summary>
        private RetryOptions _retryOptions = new RetryOptions();

        /// <summary>
        ///   The type of protocol and transport that will be used for communicating with the Event Hubs
        ///   service.
        /// </summary>
        ///
        public TransportType TransportType { get; set; } = TransportType.AmqpTcp;

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
        ///   The set of options to use for determining whether a failed operation should be retried and,
        ///   if so, the amount of time to wait between retry attempts.
        /// </summary>
        ///
        public RetryOptions RetryOptions
        {
            get => _retryOptions;

            set
            {
                ValidateRetryOptions(value);
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
        ///   Creates a new copy of the current <see cref="EventHubClientOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="EventHubClientOptions" />.</returns>
        ///
        internal EventHubClientOptions Clone() =>
            new EventHubClientOptions
            {
                TransportType = this.TransportType,
                Proxy = this.Proxy,
                _retryOptions = this.RetryOptions.Clone()
            };

        /// <summary>
        ///   Clears the retry options to allow for bypassing them in the
        ///   case where a custom retry policy is used.
        /// </summary>
        ///
        internal void ClearRetryOptions() => _retryOptions = null;

        /// <summary>
        ///   Validates the retry options are specified, throwing an <see cref="ArgumentException" /> if it is not valid.
        /// </summary>
        ///
        /// <param name="retryOptions">The set of retry options to validae.</param>
        ///
        private void ValidateRetryOptions(RetryOptions retryOptions)
        {
            if (retryOptions == null)
            {
                throw new ArgumentException(Resources.RetryOptionsMustBeSet, nameof(RetryOptions));
            }
        }
    }
}
