// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Processor.Perf.Infrastructure
{
    /// <summary>
    ///   The strategy to apply when a test needs to introduce
    ///   a delay.
    /// </summary>
    ///
    public enum ProcessingDelayStrategy
    {
        /// <summary>Sleep the thread; this may be less accurate due to reliance on scheduling to resume. </summary>
        Sleep,

        /// <summary>The thread will wait by spinning; this is more accurate as the thread is active, but is more CPU intensive.</summary>
        Spin
    }
}
