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
    ///   It is recommended that developers without advanced needs not implement custom retry
    ///   policies but instead configure the default policy by specifying the desired set of
    ///   retry options when creating one of the Event Hubs clients.
    /// </remarks>
    ///
    /// <seealso cref="RetryOptions"/>
    ///
    public abstract class EventHubRetryPolicy
    {
        /// <summary>
        ///   Calculates the amount of time to allow the current attempt for an operation to
        ///   complete before considering it to be timed out.
        /// </summary>
        ///
        /// <param name="attemptCount">The number of total attempts that have been made, including the initial attempt before any retries.</param>
        ///
        /// <returns>The amount of time to allow for an operation to complete.</returns>
        ///
        public abstract TimeSpan CalculateTryTimeout(int attemptCount);

        /// <summary>
        ///   Calculates the amount of time to wait before another attempt should be made.
        /// </summary>
        ///
        /// <param name="lastException">The last exception that was observed for the operation to be retried.</param>
        /// <param name="attemptCount">The number of total attempts that have been made, including the initial attempt before any retries.</param>
        ///
        /// <returns>The amount of time to delay before retrying the associated operation; if <c>null</c>, then the operation is no longer eligible to be retried.</returns>
        ///
        public abstract TimeSpan? CalculateRetryDelay(Exception lastException,
                                                      int attemptCount);

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
    }
}
