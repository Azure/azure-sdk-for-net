// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    enum MessagingEntityType
    {
        Queue = 0,
        Topic = 1,
        Subscriber = 2,
        Filter = 3,
        Namespace = 4,
        VolatileTopic = 5,
        VolatileTopicSubscription = 6,
        EventHub = 7,
        ConsumerGroup = 8,
        Partition = 9,
        Checkpoint = 10,
        RevokedPublisher = 11,
        Unknown = 0x7FFFFFFE,
    }
}
