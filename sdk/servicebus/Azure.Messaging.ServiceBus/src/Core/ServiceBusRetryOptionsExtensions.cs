// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus.Core
{
    /// <summary>
    ///   The set of extension methods for the <see cref="ServiceBusRetryOptions" />
    ///   class.
    /// </summary>
    ///
    internal static class ServiceBusRetryOptionsExtensions
    {
        /// <summary>
        ///   Creates a new copy of the current <see cref="ServiceBusRetryOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        ///
        /// <returns>A new copy of <see cref="ServiceBusRetryOptions" />.</returns>
        ///
        public static ServiceBusRetryOptions Clone(this ServiceBusRetryOptions instance) =>
            new ServiceBusRetryOptions
            {
                Mode = instance.Mode,
                CustomRetryPolicy = instance.CustomRetryPolicy,
                MaxRetries = instance.MaxRetries,
                Delay = instance.Delay,
                MaxDelay = instance.MaxDelay,
                TryTimeout = instance.TryTimeout
            };

        /// <summary>
        ///   Converts the options into a retry policy for use.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        ///
        /// <returns>The <see cref="ServiceBusRetryPolicy" /> represented by the options.</returns>
        public static ServiceBusRetryPolicy ToRetryPolicy(this ServiceBusRetryOptions instance) =>
            instance.CustomRetryPolicy ?? new BasicRetryPolicy(instance);

        /// <summary>
        ///   Compares retry options between two instances to determine if the
        ///   instances represent the same set of options.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        /// <param name="other">The other set of retry options to consider.</param>
        ///
        /// <returns><c>true</c>, if the two sets of options are structurally equivalent; otherwise, <c>false</c>.</returns>
        ///
        public static bool IsEquivalentTo(
            this ServiceBusRetryOptions instance,
            ServiceBusRetryOptions other)
        {
            // If the events are the same instance, they're equal.  This should only happen
            // if both are null or they are the exact same instance.

            if (Object.ReferenceEquals(instance, other))
            {
                return true;
            }

            // If one or the other is null, then they cannot be equal, since we know that
            // they are not both null.

            if ((instance == null) || (other == null))
            {
                return false;
            }

            // If the contents of each attribute are equal, the instance are
            // equal.

            return
            (
                instance.Mode == other.Mode
                && instance.MaxRetries == other.MaxRetries
                && instance.Delay == other.Delay
                && instance.MaxDelay == other.MaxDelay
                && instance.TryTimeout == other.TryTimeout
                && instance.CustomRetryPolicy == other.CustomRetryPolicy
            );
        }
    }
}
