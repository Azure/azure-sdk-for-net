// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Stress
{
    internal class EventProducerTestConfig : TestConfig
    {
        public int PublishBatchSize = 50;
    }
}