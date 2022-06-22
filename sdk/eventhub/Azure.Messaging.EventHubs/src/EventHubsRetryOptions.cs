// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///    The set of options that can be specified to influence how
    ///    retry attempts are made, and a failure is eligible to be retried.
    /// </summary>
    ///
    public class EventHubsRetryOptions
    {
        /// <summary>The maximum number of retry attempts before considering the associated operation to have failed.</summary>
        private int _maximumRetries = 3;

        /// <summary>The delay or back-off factor to apply between retry attempts.</summary>
        private TimeSpan _delay = TimeSpan.FromSeconds(0.8);

        /// <summary>The maximum delay to allow between retry attempts.</summary>
        private TimeSpan _maximumDelay = TimeSpan.FromMinutes(1);

        /// <summary>The maximum duration to wait for an operation, per attempt.</summary>
        private TimeSpan _tryTimeout = TimeSpan.FromMinutes(1);

        /// <summary>
        ///   The approach to use for calculating retry delays.
        /// </summary>
        ///
        /// <value>The default retry mode is <see cref="EventHubsRetryMode.Exponential"/>.</value>
        ///
        public EventHubsRetryMode Mode { get; set; } = EventHubsRetryMode.Exponential;

        /// <summary>
        ///   The maximum number of retry attempts before considering the associated operation
        ///   to have failed.
        /// </summary>
        ///
        /// <value>The default retry limit is 3.</value>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested number of retries is not between 0 and 100 (inclusive).</exception>
        ///
        public int MaximumRetries
        {
            get => _maximumRetries;

            set
            {
                Argument.AssertInRange(value, 0, 100, nameof(MaximumRetries));
                _maximumRetries = value;
            }
        }

        /// <summary>
        ///   The delay between retry attempts for a fixed approach or the delay
        ///   on which to base calculations for a backoff-based approach.
        /// </summary>
        ///
        /// <value>The default delay is 0.8 seconds.</value>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested delay is not between 1 millisecond and 5 minutes (inclusive).</exception>
        ///
        public TimeSpan Delay
        {
            get => _delay;

            set
            {
                Argument.AssertInRange(value, TimeSpan.FromMilliseconds(1), TimeSpan.FromMinutes(5), nameof(Delay));
                _delay = value;
            }
        }

        /// <summary>
        ///   The maximum permissible delay between retry attempts.
        /// </summary>
        ///
        /// <value>The default maximum delay is 60 seconds.</value>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested delay is negative.</exception>
        ///
        public TimeSpan MaximumDelay
        {
            get => _maximumDelay;

            set
            {
                Argument.AssertNotNegative(value, nameof(MaximumDelay));
                _maximumDelay = value;
            }
        }

        /// <summary>
        ///   The maximum duration to wait for completion of a single attempt, whether the initial
        ///   attempt or a retry.
        /// </summary>
        ///
        /// <value>The default timeout is 60 seconds.</value>
        ///
        /// <exception cref="ArgumentException">Occurs when the requested timeout is negative.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested timeout is not between <see cref="TimeSpan.Zero" /> and 1 hour (inclusive).</exception>
        ///
        public TimeSpan TryTimeout
        {
            get => _tryTimeout;

            set
            {
                if (value < TimeSpan.Zero)
                {
                    throw new ArgumentException(Resources.TimeoutMustBePositive, nameof(TryTimeout));
                }

                Argument.AssertInRange(value, TimeSpan.Zero, TimeSpan.FromHours(1), nameof(TryTimeout));
                _tryTimeout = value;
            }
        }

        /// <summary>
        ///   A custom retry policy to be used in place of the individual option values.
        /// </summary>
        ///
        /// <remarks>
        ///   When populated, this custom policy will take precedence over the individual retry
        ///   options provided.
        /// </remarks>
        ///
        public EventHubsRetryPolicy CustomRetryPolicy { get; set; }
    }
}
