// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///    The set of options that can be specified to influence how
    ///    retry attempts are made, and a failure is eligible to be retried.
    /// </summary>
    public class ServiceBusRetryOptions
    {
        /// <summary>The maximum number of retry attempts before considering the associated operation to have failed.</summary>
        private int _maxRetries = 3;

        /// <summary>The delay or backoff factor to apply between retry attempts.</summary>
        private TimeSpan _delay = TimeSpan.FromSeconds(0.8);

        /// <summary>The maximum delay to allow between retry attempts.</summary>
        private TimeSpan _maxDelay = TimeSpan.FromMinutes(1);

        /// <summary>The maximum duration to wait for an operation, per attempt.</summary>
        private TimeSpan _tryTimeout = TimeSpan.FromMinutes(1);

        /// <summary>
        ///   The approach to use for calculating retry delays.
        /// </summary>
        /// <value>The default retry mode is <see cref="ServiceBusRetryMode.Exponential"/>.</value>
        public ServiceBusRetryMode Mode { get; set; } = ServiceBusRetryMode.Exponential;

        /// <summary>
        ///   The maximum number of retry attempts before considering the associated operation
        ///   to have failed.
        /// </summary>
        /// <value>The default retry limit is 3.</value>
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested number of retries is not between 0 and 100 (inclusive).</exception>
        public int MaxRetries
        {
            get => _maxRetries;

            set
            {
                Argument.AssertInRange(value, 0, 100, nameof(MaxRetries));
                _maxRetries = value;
            }
        }

        /// <summary>
        ///   The delay between retry attempts for a fixed approach or the delay
        ///   on which to base calculations for a backoff-based approach.
        /// </summary>
        /// <value>The default delay is 0.8 seconds.</value>
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested delay is not between 1 millisecond and 5 minutes (inclusive).</exception>
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
        /// <value>The default maximum delay is 60 seconds.</value>
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested delay is negative.</exception>
        public TimeSpan MaxDelay
        {
            get => _maxDelay;

            set
            {
                Argument.AssertNotNegative(value, nameof(MaxDelay));
                _maxDelay = value;
            }
        }

        /// <summary>
        ///   The maximum duration to wait for completion of a single attempt, whether the initial
        ///   attempt or a retry.
        /// </summary>
        ///
        /// <value>The default timeout is 60 seconds.</value>
        /// <exception cref="ArgumentException">Occurs when the requested timeout is negative.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested timeout is not between <see cref="TimeSpan.Zero" /> and 1 hour (inclusive).</exception>
        public TimeSpan TryTimeout
        {
            get => _tryTimeout;

            set
            {
                if (value < TimeSpan.Zero)
                {
#pragma warning disable CA2208 // Instantiate argument exceptions. Using property name is more intuitive than Value.
                    throw new ArgumentException(Resources.TimeoutMustBePositive, nameof(TryTimeout));
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
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
        public ServiceBusRetryPolicy CustomRetryPolicy { get; set; }
    }
}
