// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    enum BrokeredMessageState
    {
        /// <summary> Message in the queue and ready to be sent to its receiver(s).  </summary>
        Active = 0,

        /// <summary> Message delivery is acknowledged in the system.  </summary>
        Acknowledged = 1,

        /// <summary> Message delivery is deferred by the its receiver.  </summary>
        Deferred = 2,

        /// <summary> Message is abandoned by receiver and delivery count is updated.  </summary>
        Abandoned = 3
    }
}