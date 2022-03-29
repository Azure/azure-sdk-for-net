// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    public enum MessageState
    {
        /// <summary>Specifies an active message state.</summary>
        Active = 0,

        /// <summary>Specifies a deferred message state.</summary>
        Deferred = 1,

        /// <summary>Specifies the scheduled message state.</summary>
        Scheduled = 2
    }
}
