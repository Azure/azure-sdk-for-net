// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
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
        public EventHubsRetryMode Mode { get; set; } = EventHubsRetryMode.Exponential;

        /// <summary>
        ///   The maximum number of retry attempts before considering the associated operation
        ///   to have failed.
        /// </summary>
        ///
        /// <value>The default retry limit is 3.</value>
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
        [SuppressMessage("Usage", "CA2208:Instantiate argument exceptions correctly", Justification = "We believe using the property name instead of 'value' is more intuitive")]
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
