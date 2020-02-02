// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Processor
{
    /// <summary>
    ///   The reason for stopping event processing for a given partition.
    /// </summary>
    ///
    internal enum ProcessingStoppedReason
    {
        /// <summary>A request was made to stop processing.</summary>
        Shutdown,

        /// <summary>The ownership of the associated partition was lost.</summary>
        OwnershipLost
    }
}
