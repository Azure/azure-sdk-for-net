// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Azure.Messaging.EventHubs;

namespace Microsoft.Azure.WebJobs.EventHubs.UnitTests
{
    public class TestPartitionProperties : PartitionProperties
    {
        public TestPartitionProperties(string eventHubName = default, string partitionId = default, bool isEmpty = default, long beginningSequenceNumber = default, long lastSequenceNumber = default, string lastOffset = default, DateTimeOffset lastEnqueuedTime = default) : base(eventHubName, partitionId, isEmpty, beginningSequenceNumber, lastSequenceNumber, lastOffset, lastEnqueuedTime)
        {
        }
    }
}