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
    public class RetryOptions
    {
        /// <summary>The maximum number of retry attempts before considering the associated operation to have failed.</summary>
        private int _maximumRetries = 3;

        /// <summary>The delay or backoff factor to apply between retry attempts.</summary>
        private TimeSpan _delay = TimeSpan.FromSeconds(0.8);

        /// <summary>The maximum delay to allow between retry attempts.</summary>
        private TimeSpan _maximumDelay = TimeSpan.FromMinutes(1);

        /// <summary>The maximum duration to wait for an operation, per attempt.</summary>
        private TimeSpan _tryTimeOut = TimeSpan.FromMinutes(1);

        /// <summary>
        ///   The approach to use for calculating retry delays.
        /// </summary>
        ///
        public RetryMode Mode { get; set; } = RetryMode.Exponential;

        /// <summary>
        ///   The maximum number of retry attempts before considering the associated operation
        ///   to have failed.
        /// </summary>
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
        ///   The maximum duration to wait for completion of a single attempt, whether the intial
        ///   attempt or a retry.
        /// </summary>
        ///
        public TimeSpan TryTimeout
        {
            get => _tryTimeOut;

            set
            {
                if (value < TimeSpan.Zero)
                {
                    throw new ArgumentException(Resources.TimeoutMustBePositive, nameof(TryTimeout));
                }

                Argument.AssertInRange(value, TimeSpan.Zero, TimeSpan.FromHours(1), nameof(TryTimeout));
                _tryTimeOut = value;
            }
        }

        /// <summary>
        ///   Creates a new copy of the current <see cref="RetryOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="RetryOptions" />.</returns>
        ///
        internal RetryOptions Clone() =>
            new RetryOptions
            {
                Mode = Mode,
                _maximumRetries = _maximumRetries,
                _delay = _delay,
                _maximumDelay = _maximumDelay,
                _tryTimeOut = _tryTimeOut
            };
    }
}
