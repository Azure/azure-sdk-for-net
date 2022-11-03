// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Azure.Core;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    ///   An abstract representation of a policy to govern retrying.
    /// </summary>
    ///
    /// <remarks>
    ///   It is recommended that developers without advanced needs not implement custom retry
    ///   policies but instead configure the default policy.
    /// </remarks>
    internal class WebPubSubRetryPolicy
    {
        private readonly int _maxRetries;
        private readonly TimeSpan _delay;
        private readonly TimeSpan _maxDelay;
        private readonly RetryMode _mode;

        public WebPubSubRetryPolicy(RetryOptions options)
        {
            _maxRetries = options.MaxRetries;
            _delay = options.Delay;
            _maxDelay = options.MaxDelay;
            _mode = options.Mode;
        }

        /// <summary>
        /// This will be called after the transport loses a connection to determine if and for how long to wait before the next reconnect attempt.
        /// </summary>
        /// <param name="retryContext">
        /// Information related to the next possible reconnect attempt including the number of consecutive failed retries so far, time spent
        /// reconnecting so far and the error that lead to this reconnect attempt.
        /// </param>
        /// <returns>
        /// A <see cref="TimeSpan"/> representing the amount of time to wait from now before starting the next reconnect attempt.
        /// <see langword="null" /> tells the client to stop retrying and close.
        /// </returns>
        public TimeSpan? NextRetryDelay(RetryContext retryContext)
        {
            if (retryContext.RetryAttempt > _maxRetries)
            {
                return null;
            }

            return GetDelay(retryContext.RetryAttempt);
        }

        private TimeSpan GetDelay(int attempted)
        {
            if (_mode == RetryMode.Fixed)
            {
                return _delay;
            }
            else
            {
                return CalculateExponentialDelay(attempted);
            }
        }

        private TimeSpan CalculateExponentialDelay(int attempted)
        {
            return TimeSpan.FromMilliseconds(
                Math.Min((1 << (attempted - 1)) * (int)(_delay.TotalMilliseconds),
                    _maxDelay.TotalMilliseconds));
        }
    }
}
