// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The set of extension methods for the <see cref="EventPosition" />
    ///   class.
    /// </summary>
    ///
    internal static class EventPositionExtensions
    {
        /// <summary>
        ///   Compares two event position instances to determine if they represent the same
        ///   position.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        /// <param name="other">The other event position to consider.</param>
        ///
        /// <returns><c>true</c>, if the two event positions are structurally equivalent; otherwise, <c>false</c>.</returns>
        ///
        public static bool IsEquivalentTo(this EventPosition instance,
                                          EventPosition other)
        {
            // If the event positions are the same instance, they're equal.  This should only happen
            // if both are null or if they are the exact same instance.

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

            // If the contents of each attribute are equal, the instances are
            // equal.

            return
            (
                instance.Offset == other.Offset
                && instance.IsInclusive == other.IsInclusive
                && instance.EnqueuedTime == other.EnqueuedTime
                && instance.SequenceNumber == other.SequenceNumber
            );
        }
    }
}
