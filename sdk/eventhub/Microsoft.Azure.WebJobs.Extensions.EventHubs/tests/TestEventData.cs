// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Azure.Messaging.EventHubs;

namespace Microsoft.Azure.WebJobs.EventHubs.UnitTests
{
    public class TestEventData: EventData
    {
        public TestEventData(ReadOnlyMemory<byte> eventBody,
            IDictionary<string, object> properties = null,
            IReadOnlyDictionary<string, object> systemProperties = null,
            long sequenceNumber = long.MinValue,
            long offset = long.MinValue,
            DateTimeOffset enqueuedTime = new DateTimeOffset(),
            string partitionKey = null) : base(eventBody, properties, systemProperties, sequenceNumber, offset, enqueuedTime, partitionKey)
        {
        }
    }
}