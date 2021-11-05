// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Primitives;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The set of extension methods for the <see cref="EventProcessorPartitionOwnership" />
    ///   class.
    /// </summary>
    ///
    internal static class PartitionOwnershipExtensions
    {
        /// <summary>
        ///   Compares ownership information between two instances to determine if the
        ///   instances represent the same ownership.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        /// <param name="other">The other partition ownership to consider.</param>
        ///
        /// <returns><c>true</c>, if the two ownership are structurally equivalent; otherwise, <c>false</c>.</returns>
        ///
        public static bool IsEquivalentTo(this EventProcessorPartitionOwnership instance,
                                          EventProcessorPartitionOwnership other)
        {
            // If the ownership are the same instance, they're equal.  This should only happen
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

            // If the contents of each attribute are equal, the instances are
            // equal.

            return
            (
                instance.FullyQualifiedNamespace == other.FullyQualifiedNamespace
                && instance.EventHubName == other.EventHubName
                && instance.ConsumerGroup == other.ConsumerGroup
                && instance.OwnerIdentifier == other.OwnerIdentifier
                && instance.PartitionId == other.PartitionId
                && instance.LastModifiedTime == other.LastModifiedTime
                && instance.Version == other.Version
            );
        }
    }
}
