// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The set of extension methods for the <see cref="EventData" />
    ///   class.
    /// </summary>
    ///
    internal static class EventDataExtensions
    {
        /// <summary>
        ///   Compares event data between two instances to determine if the
        ///   instances represent the same event.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        /// <param name="other">The other event to consider.</param>
        /// <param name="considerSystemProperties">If <c>true</c>, the <see cref="EventData.SystemProperties" /> will be considered; otherwise, differences will be ignored.</param>
        ///
        /// <returns><c>true</c>, if the two events are structurally equivalent; otherwise, <c>false</c>.</returns>
        ///
        public static bool IsEquivalentTo(this EventData instance,
                                          EventData other,
                                          bool considerSystemProperties = false)
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

            // If the contents of each body is not equal, the events are not
            // equal.

            var instanceBody = instance.EventBody.ToArray();
            var otherBody = other.EventBody.ToArray();

            if (instanceBody.Length != otherBody.Length)
            {
                return false;
            }

            if (!Enumerable.SequenceEqual(instanceBody, otherBody))
            {
                return false;
            }

            // Verify that the stand-alone system properties are equivalent.

            if ((considerSystemProperties)
                && ((instance.OffsetString != other.OffsetString)
                    || (instance.EnqueuedTime != other.EnqueuedTime)
                    || (instance.PartitionKey != other.PartitionKey)
                    || (instance.SequenceNumber != other.SequenceNumber)))
            {
                return false;
            }

            // Verify the system properties are equivalent, unless they're the same reference.

            if ((considerSystemProperties) && (!Object.ReferenceEquals(instance.SystemProperties, other.SystemProperties)))
            {
                if ((instance.SystemProperties == null) || (other.SystemProperties == null))
                {
                    return false;
                }

                if (instance.SystemProperties.Count != other.SystemProperties.Count)
                {
                    return false;
                }

                if (!instance.SystemProperties.OrderBy(kvp => kvp.Key).SequenceEqual(other.SystemProperties.OrderBy(kvp => kvp.Key)))
                {
                    return false;
                }
            }

            // Since we know that the event bodies and system properties are equal, if the property sets are the
            // same instance, then we know that the events are equal.  This should only happen if both are null.

            if (Object.ReferenceEquals(instance.Properties, other.Properties))
            {
                return true;
            }

            // If either property is null, then the events are not equal, since we know that they are
            // not both null.

            if ((instance.Properties == null) || (other.Properties == null))
            {
                return false;
            }

            // The only meaningful comparison left is to ensure that the property sets are equivalent,
            // the outcome of this check is the final word on equality.

            if (instance.Properties.Count != other.Properties.Count)
            {
                return false;
            }

            foreach (var key in instance.Properties.Keys)
            {
                if (!other.Properties.TryGetValue(key, out object otherValue))
                {
                    return false;
                }

                // Properties can contain byte[] or ArraySegment<byte> values, which need to be compared
                // as a sequence rather than by strict equality.  Both forms implement IList<byte>, so they
                // can be normalized for comparison.

                if ((instance.Properties[key] is IList<byte> instanceList) && (otherValue is IList<byte> otherList))
                {
                    if (!instanceList.SequenceEqual(otherList))
                    {
                        return false;
                    }
                }
                else if (!instance.Properties[key].Equals(otherValue))
                {
                    return false;
                }
            }

            // No inequalities were found, so the events are equal.

            return true;
        }
    }
}
