// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   The reason for stopping event processing for a given partition.
    /// </summary>
    ///
    public enum CloseReason
    {
        /// <summary>An unknown circumstance forced the processing to stop.</summary>
        Unknown,

        /// <summary>A close request was fired by the user.</summary>
        Shutdown,

        /// <summary>The ownership of the associated partition was lost.</summary>
        OwnershipLost,

        /// <summary>A non-retriable exception was thrown by the Event Hub Client.</summary>
        EventHubException,

        /// <summary>A non-retriable exception was thrown by the provided event processing handler.</summary>
        ProcessEventException
    }
}
