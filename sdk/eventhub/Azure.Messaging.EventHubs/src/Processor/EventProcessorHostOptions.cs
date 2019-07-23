// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   TODO.
    /// </summary>
    ///
    public class EventProcessorHostOptions
    {
        /// <summary>
        ///   TODO. (nullable?)
        /// </summary>
        ///
        public EventPosition InitialEventPosition { get; }

        /// <summary>
        ///   TODO. (nullable? Maximum? InBytes? int?)
        /// </summary>
        ///
        public long MaxBatchSize { get; }

        /// <summary>
        ///   TODO. (nullable? Maximum?)
        /// </summary>
        ///
        public TimeSpan MaxWaitTime { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        internal EventProcessorHostOptions(EventPosition initialEventPosition,
                                           long maxBatchSize,
                                           TimeSpan maxWaitTime)
        {
            InitialEventPosition = initialEventPosition;
            MaxBatchSize = maxBatchSize;
            MaxWaitTime = maxWaitTime;
        }
    }
}
