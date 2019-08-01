// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Core;
using System;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   The baseline set of options that can be specified when creating a <see cref="EventProcessor" />
    ///   to configure its behavior.
    /// </summary>
    ///
    public class EventProcessorOptions
    {
        /// <summary>The maximum number of messages to receive in every receive attempt.</summary>
        private int _maximumMessageCount = 10;

        /// <summary>The maximum amount of time to wait to build up the requested message count in every receive attempt.</summary>
        private TimeSpan? _maximumReceiveWaitTime = null;

        /// <summary>
        ///   The position within a partition where the partition processor should begin reading events.
        /// </summary>
        ///
        public EventPosition InitialEventPosition { get; set; } = EventPosition.Earliest;

        /// <summary>
        ///   The maximum number of messages to receive in every receive attempt.
        /// </summary>
        ///
        public int MaximumMessageCount
        {
            get => _maximumMessageCount;

            set
            {
                Guard.ArgumentInRange(nameof(MaximumMessageCount), _maximumMessageCount, 1, Int32.MaxValue);
                _maximumMessageCount = value;
            }
        }

        /// <summary>
        ///   The maximum amount of time to wait to build up the requested message count in every receive attempt.
        /// </summary>
        ///
        public TimeSpan? MaximumReceiveWaitTime
        {
            get => _maximumReceiveWaitTime;

            set
            {
                if (value.HasValue)
                {
                    Guard.ArgumentNotNegative(nameof(MaximumReceiveWaitTime), _maximumReceiveWaitTime.Value);
                }

                _maximumReceiveWaitTime = value;
            }
        }

        /// <summary>
        ///   Creates a new copy of the current <see cref="EventProcessorOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="EventProcessorOptions" />.</returns>
        ///
        /// <remarks>
        ///   The members of an <see cref="EventPosition" /> are internal and can't be modified by the user after its
        ///   creation.
        /// </remarks>
        ///
        internal EventProcessorOptions Clone() =>
            new EventProcessorOptions
            {
                InitialEventPosition = this.InitialEventPosition,
                MaximumMessageCount = this.MaximumMessageCount,
                MaximumReceiveWaitTime = this.MaximumReceiveWaitTime
            };
    }
}
