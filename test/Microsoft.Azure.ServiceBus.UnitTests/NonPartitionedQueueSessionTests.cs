// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Threading.Tasks;
    using Xunit;
    using Xunit.Abstractions;

    public class NonPartitionedQueueSessionTests : QueueSessionTestBase
    {
        public NonPartitionedQueueSessionTests(ITestOutputHelper output)
            : base(output)
        {
            this.ConnectionString = Environment.GetEnvironmentVariable("NONPARTITIONEDSESSIONQUEUECONNECTIONSTRING");

            if (string.IsNullOrWhiteSpace(this.ConnectionString))
            {
                throw new InvalidOperationException("SESSIONQUEUECLIENTCONNECTIONSTRING environment variable was not found!");
            }
        }

        [Fact]
        async Task SessionTest()
        {
            await this.SessionTestCase();
        }

        [Fact]
        async Task GetAndSetSessionStateTest()
        {
            await this.GetAndSetSessionStateTestCase();
        }

        [Fact]
        async Task SessionRenewLockTest()
        {
            await this.SessionRenewLockTestCase();
        }
    }
}