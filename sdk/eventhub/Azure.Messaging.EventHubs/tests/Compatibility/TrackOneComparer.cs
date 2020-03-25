// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   Provides a means of comparing the track one and track two representations
    ///   of types.
    /// </summary>
    ///
    internal static class TrackOneComparer
    {
        /// <summary>
        ///   Compares event data between its representations in track one and
        ///   track two to determine if the instances represent the same event.
        /// </summary>
        ///
        /// <param name="trackOneEvent">The track one event to consider.</param>
        /// <param name="trackTwoEvent">The track two event to consider.</param>
        ///
        /// <returns><c>true</c>, if the two events are structurally equivalent; otherwise, <c>false</c>.</returns>
        ///
        public static bool IsEventDataEquivalent(TrackOne.EventData trackOneEvent,
                                                 EventData trackTwoEvent)
        {
            // If the events are the same instance, they're equal.  This should only happen
            // if both are null, since the types differ.

            if (Object.ReferenceEquals(trackOneEvent, trackTwoEvent))
            {
                return true;
            }

            // If one or the other is null, then they cannot be equal, since we know that
            // they are not both null.

            if ((trackOneEvent == null) || (trackTwoEvent == null))
            {
                return false;
            }

            // If the contents of each body is not equal, the events are not
            // equal.

            var trackOneBody = trackOneEvent.Body.ToArray();
            var trackTwoBody = trackTwoEvent.Body.ToArray();

            if (trackOneBody.Length != trackTwoBody.Length)
            {
                return false;
            }

            if (!Enumerable.SequenceEqual(trackOneBody, trackTwoBody))
            {
                return false;
            }

            // Verify the system properties are equivalent, unless they're the same reference.

            if (!Object.ReferenceEquals(trackOneEvent.SystemProperties, trackTwoEvent.SystemProperties))
            {

                if ((trackOneEvent.SystemProperties == null) || (trackTwoEvent.SystemProperties == null))
                {
                    return false;
                }

                if (trackOneEvent.SystemProperties.WithoutTypedMembers().Count != trackTwoEvent.SystemProperties.Count)
                {
                    return false;
                }

                foreach (var property in trackOneEvent.SystemProperties)
                {
                    if (property.Key == TrackOne.ClientConstants.EnqueuedTimeUtcName)
                    {
                        var trackOneDate = (DateTime)trackOneEvent.SystemProperties[property.Key];
                        var trackTwoDate = trackTwoEvent.EnqueuedTime;

                        if (trackOneDate != trackTwoDate.Value.UtcDateTime)
                        {
                            return false;
                        }
                    }
                    else if (property.Key == TrackOne.ClientConstants.SequenceNumberName)
                    {
                        var trackOneSequence = (long)trackOneEvent.SystemProperties[property.Key];
                        var trackTwoSequence = trackTwoEvent.SequenceNumber;

                        if (trackOneSequence != trackTwoSequence)
                        {
                            return false;
                        }
                    }
                    else if (property.Key == TrackOne.ClientConstants.OffsetName)
                    {
                        var trackOneOffset = (string)trackOneEvent.SystemProperties[property.Key];
                        var trackTwoOffset = trackTwoEvent.Offset?.ToString();

                        if (trackOneOffset != trackTwoOffset)
                        {
                            return false;
                        }
                    }
                    else if (property.Key == TrackOne.ClientConstants.PartitionKeyName)
                    {
                        var trackOnePartitionKey = (string)trackOneEvent.SystemProperties[property.Key];
                        var trackTwoPartitionKey = trackTwoEvent.PartitionKey;

                        if (trackOnePartitionKey != trackTwoPartitionKey)
                        {
                            return false;
                        }
                    }
                    else if ((!trackTwoEvent.SystemProperties.ContainsKey(property.Key))
                        || (trackOneEvent.SystemProperties[property.Key] != trackTwoEvent.SystemProperties[property.Key]))
                    {
                        return false;
                    }
                }
            }

            // Since we know that the event bodies and system properties are equal, if the property sets are the
            // same instance, then we know that the events are equal.  This should only happen if both are null.

            if (Object.ReferenceEquals(trackOneEvent.Properties, trackTwoEvent.Properties))
            {
                return true;
            }

            // If either property is null, then the events are not equal, since we know that they are
            // not both null.

            if ((trackOneEvent.Properties == null) || (trackTwoEvent.Properties == null))
            {
                return false;
            }

            // The only meaningful comparison left is to ensure that the property sets are equivalent,
            // the outcome of this check is the final word on equality.

            if (trackOneEvent.Properties.Count != trackTwoEvent.Properties.Count)
            {
                return false;
            }

            if (!trackOneEvent.Properties.OrderBy(kvp => kvp.Key).SequenceEqual(trackTwoEvent.Properties.OrderBy(kvp => kvp.Key)))
            {
                return false;
            }

            // Validate the runtime metrics properties.

            return ((trackOneEvent.LastSequenceNumber != default ? trackOneEvent.LastSequenceNumber : default(long?)) == trackTwoEvent.LastPartitionSequenceNumber)
                && ((trackOneEvent.LastEnqueuedTime != default ? new DateTimeOffset(trackOneEvent.LastEnqueuedTime) : default(DateTimeOffset?)) == trackTwoEvent.LastPartitionEnqueuedTime)
                && ((trackOneEvent.LastEnqueuedOffset == trackTwoEvent.LastPartitionOffset?.ToString()));
        }

        /// <summary>
        ///   Compares event position between its representations in track one and
        ///   track two to determine if the instances represent the same event.
        /// </summary>
        ///
        /// <param name="trackOnePosition">The track one event position to consider.</param>
        /// <param name="trackTwoPosition">The track two event position to consider.</param>
        ///
        /// <returns><c>true</c>, if the two events are structurally equivalent; otherwise, <c>false</c>.</returns>
        ///
        public static bool IsEventPositionEquivalent(TrackOne.EventPosition trackOnePosition,
                                                     EventPosition trackTwoPosition)
        {
            // If the positions are the same instance, they're equal.  This should only happen
            // if both are null, since the types differ.

            if (Object.ReferenceEquals(trackOnePosition, trackTwoPosition))
            {
                return true;
            }

            // If one or the other is null, then they cannot be equal, since we know that
            // they are not both null.

            if ((trackOnePosition == null) || (trackTwoPosition == null))
            {
                return false;
            }

            // Compare the properties and ensure that they're equal.

            return
            (
                (String.Equals(trackOnePosition.Offset, trackTwoPosition.Offset, StringComparison.Ordinal))
                 && (trackOnePosition.SequenceNumber == trackTwoPosition.SequenceNumber)
                 && (trackOnePosition.IsInclusive == trackTwoPosition.IsInclusive)
                 && (trackOnePosition.EnqueuedTimeUtc == trackTwoPosition.EnqueuedTime?.UtcDateTime)
            );
        }
    }
}
