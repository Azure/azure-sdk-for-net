// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.Messaging
{
    enum BrokeredMessageFormat : byte
    {
        //Sbmp = 0,
        Amqp = 0,
        PassthroughAmqp = 2,
        AmqpEventData = 3,
    }
}
