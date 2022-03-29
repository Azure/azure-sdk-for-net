// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus
{
    /// <summary>Represents the message state of the <see cref="ServiceBusReceivedMessage"/></summary>
    public enum ServiceBusMessageState
    {
        /// <summary>Specifies an active message state.</summary>
        Active = 0,

        /// <summary>Specifies a deferred message state.</summary>
        Deferred = 1,

        /// <summary>Specifies the scheduled message state.</summary>
        Scheduled = 2
    }
}
