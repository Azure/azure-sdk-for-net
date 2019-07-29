// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        /// <summary>
        ///   The position within a partition where the partition processor should begin reading events.
        /// </summary>
        ///
        public EventPosition InitialEventPosition { get; set; } = EventPosition.Earliest;

        /// <summary>
        ///   The maximum number of messages to receive in every receive attempt.
        /// </summary>
        ///
        public int MaximumMessageCount { get; set; } = 10;

        /// <summary>
        ///   The maximum amount of time to wait to build up the requested message count in every receive attempt.
        /// </summary>
        ///
        public TimeSpan? MaximumReceiveWaitTime { get; set; } = null;

        /// <summary>
        ///   Creates a new copy of the current <see cref="EventProcessorOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="EventProcessorOptions" />.</returns>
        ///
        internal EventProcessorOptions Clone() =>
            new EventProcessorOptions
            {
                // TODO: EventPosition properties are internal. Should we clone it?
                InitialEventPosition = this.InitialEventPosition,
                MaximumMessageCount = this.MaximumMessageCount,
                MaximumReceiveWaitTime = this.MaximumReceiveWaitTime
            };
    }
}
