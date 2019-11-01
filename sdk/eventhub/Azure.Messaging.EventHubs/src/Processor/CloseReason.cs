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

        /// <summary>A request was made to stop processing.</summary>
        Shutdown,

        /// <summary>The ownership of the associated partition was lost.</summary>
        OwnershipLost,

        /// <summary>An unhandled exception has been thrown.</summary>
        Exception
    }
}
