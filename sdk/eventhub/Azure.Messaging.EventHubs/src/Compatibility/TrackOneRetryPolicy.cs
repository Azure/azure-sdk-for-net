// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using TrackOne;

namespace Azure.Messaging.EventHubs.Compatibility
{
    /// <summary>
    ///   A retry policy that conforms to the track one API shape, which delegates the retry calculations
    ///   to a modern track two policy implementation.
    /// </summary>
    ///
    /// <seealso cref="TrackOne.RetryPolicy" />
    ///
    internal sealed class TrackOneRetryPolicy : TrackOne.RetryPolicy
    {
        /// <summary>The modern retry policy to use as the source of retry calculations.</summary>
        private EventHubRetryPolicy _sourcePolicy;

        /// <summary>
        ///   Initializes a new instance of the <see cref="TrackOneRetryPolicy"/> class.
        /// </summary>
        ///
        /// <param name="sourcePolicy">The modern retry policy to use as the source of retry calculations.</param>
        ///
        public TrackOneRetryPolicy(EventHubRetryPolicy sourcePolicy) : base()
        {
            Argument.NotNull(sourcePolicy, nameof(sourcePolicy));
            _sourcePolicy = sourcePolicy;
        }

        /// <summary>
        ///   Invoked by the base implementation to determine the delay to wait until the next
        ///   retry attempt.
        /// </summary>
        ///
        /// <param name="lastException">The last exception that was encountered; may be <c>null</c> if the retry was not triggered by an exception.</param>
        /// <param name="remainingTime">The remaining time for the overall operation timeout.</param>
        /// <param name="baseWaitTimeSecs">The base wait time for retries, in seconds.</param>
        /// <param name="retryCount">The number of retry attempts that have been made.</param>
        ///
        /// <returns>The duration to wait before retrying; or <c>null</c> if the operation should not be retried.</returns>
        ///
        protected override TimeSpan? OnGetNextRetryInterval(Exception lastException,
                                                            TimeSpan remainingTime,
                                                            int baseWaitTimeSecs,
                                                            int retryCount)
        {
            // If there is no time remaining, do not retry.

            if (remainingTime <= TimeSpan.Zero)
            {
                return null;
            }

            // Delegate to the track one code for eligibility to retry an exception, for
            // the sake of consistency.

            if (!TrackOne.RetryPolicy.IsRetryableException(lastException))
            {
                return null;
            }

            Exception mappedException;

            switch (lastException)
            {
                case TrackOne.EventHubsException ex:
                    mappedException = ex.MapToTrackTwoException();
                    break;

                default:
                    mappedException = lastException;
                    break;
            }

            var delay = _sourcePolicy.CalculateRetryDelay(mappedException, retryCount);

            if (delay > remainingTime)
            {
                return null;
            }

            return delay;
        }

        /// <summary>
        ///   Creates a new copy of the current <see cref="RetryPolicy" /> and clones it into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="RetryPolicy" />.</returns>
        ///
        public override RetryPolicy Clone() =>
            new TrackOneRetryPolicy(_sourcePolicy);
    }
}
