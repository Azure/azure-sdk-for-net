// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus.Primitives;
    using Xunit;
    using Xunit.Abstractions;

    public class PartitionedQueueClientTests : QueueClientTestBase
    {
        public PartitionedQueueClientTests(ITestOutputHelper output)
            : base(output)
        {
            this.ConnectionString = Environment.GetEnvironmentVariable("PARTITIONEDQUEUECLIENTCONNECTIONSTRING");

            if (string.IsNullOrWhiteSpace(this.ConnectionString))
            {
                throw new InvalidOperationException("QUEUECLIENTCONNECTIONSTRING environment variable was not found!");
            }
        }

        [Fact]
        async Task PeekLockTest()
        {
            await this.QueueClientPeekLockTestCase(messageCount: 10);
        }

        [Fact]
        async Task ReceiveDeleteTest()
        {
            await this.QueueClientReceiveDeleteTestCase(messageCount: 10);
        }

        [Fact]
        async Task PeekLockWithAbandonTest()
        {
            await this.QueueClientPeekLockWithAbandonTestCase(messageCount: 10);
        }

        [Fact]
        async Task PeekLockWithDeadLetterTest()
        {
            await this.QueueClientPeekLockWithDeadLetterTestCase(messageCount: 10);
        }

        [Fact]
        async Task PeekLockDeferTest()
        {
            await this.QueueClientPeekLockDeferTestCase(messageCount: 10);
        }

        // Request Response Tests
        [Fact]
        async Task BasicRenewLockTest()
        {
            await this.QueueClientRenewLockTestCase(messageCount: 1);
        }
    }
}