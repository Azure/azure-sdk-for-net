// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Messaging.EventHubs.Stress
{
    internal class EventProducerTestConfig : TestConfig
    {
        // The number of events to generate and put into a batch during each iteration of PerformSend
        public int PublishBatchSize = 50;

        private static string[] _roles = { "publisher", "publisher" };
        public new List<string> Roles = new List<string>(_roles);
    }
}