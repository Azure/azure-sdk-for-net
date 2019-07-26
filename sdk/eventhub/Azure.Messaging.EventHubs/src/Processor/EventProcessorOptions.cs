// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   TODO.
    /// </summary>
    ///
    public class EventProcessorOptions
    {
        /// <summary>
        ///   TODO. (nullable? Default value?)
        /// </summary>
        ///
        public EventPosition InitialEventPosition { get; set; }

        /// <summary>
        ///   TODO. (Guard? Default value?)
        /// </summary>
        ///
        public int MaximumMessageCount { get; set; }

        /// <summary>
        ///   TODO. Should we delegate the validation to the Consumer?
        /// </summary>
        ///
        public TimeSpan MaximumReceiveWaitTime { get; set; }

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
