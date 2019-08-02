// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   The reason for closing an <see cref="IPartitionProcessor" />.
    /// </summary>
    ///
    public enum PartitionProcessorCloseReason
    {
        /// <summary>An unknown circumstance forced the processor to close.</summary>
        Unknown,

        /// <summary>A close request was fired by the user.</summary>
        Shutdown,

        /// <summary>The ownership of the associated partition was lost.</summary>
        OwnershipLost,

        /// <summary>A non-retryable exception was thrown by the Event Hub Client.</summary>
        EventHubException
    }
}
