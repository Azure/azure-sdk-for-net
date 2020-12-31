// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Primitives
{
    // Enum.ToString() is used while serializing the AMQP disposition request.
    // DO NOT rename the enums.
    internal enum DispositionStatus
    {
        Completed = 1,
        Defered = 2,
        Suspended = 3,
        Abandoned = 4,
        Renewed = 5,
    }
}
