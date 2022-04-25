// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Stress
{
    internal class BufferedProducerTestConfig : TestConfig
    {
        public int EventEnqueueListSize = 50;
    }
}