// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Primitives
{
    /// <summary>
    ///   Represents the state of an event processor.
    /// </summary>
    ///
    internal enum EventProcessorStatus
    {
        /// <summary>The processor is not running and in a good state.</summary>
        NotRunning,

        /// <summary>The processor is running and actively processing events.</summary>
        Running,

        /// <summary>The processor has begun its initialization, which is still in progress.</summary>
        Starting,

        /// <summary>The processor has begun shutting down, which is still in progress.</summary>
        Stopping,

        /// <summary>The processor is not running and in a bad state; Stop must be called to reset state.</summary>
        Faulted
    }
}
