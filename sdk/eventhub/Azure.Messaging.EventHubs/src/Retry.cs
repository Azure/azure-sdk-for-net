// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   An abstract representation of a policy to govern retrying of messaging operations.
    /// </summary>
    ///
    /// <remarks>
    ///   It is recommended that consumers not implement custom retry policies but instead
    ///   use one of the provided implementations.
    /// </remarks>
    ///
    /// <see cref="Retry.Default" />
    /// <see cref="Retry.NoRetry" />
    /// <seealso cref="ExponentialRetry"/>
    ///
    public abstract class Retry
    {
        /// <summary>The maximum number of retries allowed by default when no value is specified.</summary>
        private const int DefaultMaximumRetryCount = 10;

        /// <summary>The minimum time period permissible for backing off between retries by default when no value is specified.</summary>
        private static readonly TimeSpan DefaultRetryMinimumBackoff = TimeSpan.Zero;

        /// <summary>The maximum time period permissible for backing off between retries by default when no value is specified.</summary>
        private static readonly TimeSpan DefaultRetryMaximumBackoff = TimeSpan.FromSeconds(30);

        /// <summary>
        ///   The default retry policy, recommended for most general purpose scenarios.
        /// </summary>
        ///
        public static Retry Default => new ExponentialRetry(DefaultRetryMinimumBackoff, DefaultRetryMaximumBackoff, DefaultMaximumRetryCount);

        /// <summary>
        ///   A policy that disallows retries alltogether.
        /// </summary>
        ///
        public static Retry NoRetry => new ExponentialRetry(TimeSpan.Zero, TimeSpan.Zero, 0);

        /// <summary>
        ///   Determines whether or not a given exception is eligible for a retry attempt.
        /// </summary>
        ///
        /// <param name="exception">The exception to consider.</param>
        ///
        /// <returns><c>true</c> if the operation that produced the exception may be retried; otherwise, <c>false</c>.</returns>
        ///
        internal virtual bool IsRetriableException(Exception exception) => throw new NotImplementedException();

        /// <summary>
        ///   Calculates the amount of time to delay before the next retry attempt.
        /// </summary>
        ///
        /// <param name="lastException">The last exception that was observed for the operation to be retried.</param>
        /// <param name="remainingTime">The amount of time remaining for the cumulative timeout across retry attempts.</param>
        /// <param name="retryCount">The number of retries that have already been attempted.</param>
        ///
        /// <returns>The amount of time to delay before retrying the associated operation; if <c>null</c>, then the operation is no longer eligible to be retried.</returns>
        ///
        internal TimeSpan? GetNextRetryInterval(Exception lastException,
                                                TimeSpan  remainingTime,
                                                int       retryCount) => throw new NotImplementedException();
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
        ///   Creates a new copy of the current <see cref="Retry" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="Retry" />.</returns>
        ///
        internal abstract Retry Clone();

        /// <summary>
        ///   Allows a concrete retry policy implementation to offer a base retry interval to be used in
        ///   the calculations performed by <see cref="Retry.GetNextRetryInterval" />.
        /// </summary>
        ///
        /// <param name="lastException">The last exception that was observed for the operation to be retried.</param>
        /// <param name="remainingTime">The amount of time remaining for the cumulative timeout across retry attempts.</param>
        /// <param name="baseWaitSeconds">The number of seconds to base the suggested retry interval on; this should be used as the minimum interval returned under normal circumstances.</param>
        /// <param name="retryCount">The number of retries that have already been attempted.</param>
        ///
        /// <returns>The amount of time to delay before retrying the associated operation; if <c>null</c>, then the operation is no longer eligible to be retried.</returns>
        ///
        /// <remarks>
        ///   The interval produced by this method is considered non-authoritative and is subject to adjustment by the
        ///   <see cref="Retry.GetNextRetryInterval" /> implementation.
        /// </remarks>
        ///
        protected abstract TimeSpan? CalculateNextRetryInterval(Exception lastException,
                                                                TimeSpan  remainingTime,
                                                                int       baseWaitSeconds,
                                                                int       retryCount);
    }
}
