// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Stress
{
    internal class EventProducerTestConfig : TestConfig
    {
        // The number of events to generate and put into a batch during each iteration of PerformSend
        public int PublishBatchSize = 50;
    }
}