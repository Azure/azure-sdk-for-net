// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Client
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class TimeoutTests : ClientTestBase
    {
        [Fact]
        [DisplayTestMethodName]
        async Task ReceiveTimeout()
        {
            var testValues = new[] { 30, 60, 120 };

            PartitionReceiver receiver = null;

            foreach (var receiveTimeoutInSeconds in testValues)
            {
                TestUtility.Log($"Testing with {receiveTimeoutInSeconds} seconds.");

                try
                {
                    // Start receiving from a future time so that Receive call won't be able to fetch any events.
                    receiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromEnqueuedTime(DateTime.UtcNow.AddMinutes(1)));

                    var startTime = DateTime.Now;
                    await receiver.ReceiveAsync(1, TimeSpan.FromSeconds(receiveTimeoutInSeconds));

                    // Receive call should have waited more than receive timeout.
                    // Give 100 milliseconds of buffer.
                    var diff = DateTime.Now.Subtract(startTime).TotalSeconds;
                    Assert.True(diff >= receiveTimeoutInSeconds - 0.1, $"Hit timeout {diff} seconds into Receive call while testing {receiveTimeoutInSeconds} seconds timeout.");

                    // Timeout should not be late more than 5 seconds.
                    // This is just a logical buffer for timeout behavior validation.
                    Assert.True(diff < receiveTimeoutInSeconds + 5, $"Hit timeout {diff} seconds into Receive call while testing {receiveTimeoutInSeconds} seconds timeout.");
                }
                finally
                {
                    await receiver.CloseAsync();
                }
            }
        }

        /// <summary>
        /// Small receive timeout should not throw EventHubsTimeoutException. 
        /// EventHubsTimeoutException should be returned as NULL to the awaiting client.
        /// </summary>
        /// <returns></returns>
        [Fact]
        [DisplayTestMethodName]
        async Task SmallReceiveTimeout()
        {
            var maxClients = 4;

            // Issue receives with 1 second so that some of the Receive calls will timeout while creating AMQP link.
            // Even those Receive calls should return NULL instead of bubbling the exception up.
            var receiveTimeoutInSeconds = 1;

            var tasks = Enumerable.Range(0, maxClients)
                .Select(async i =>
                {
                    PartitionReceiver receiver = null;

                    try
                    {
                        TestUtility.Log($"Testing with {receiveTimeoutInSeconds} seconds on client {i}.");

                        // Start receiving from a future time so that Receive call won't be able to fetch any events.
                        var ehClient = EventHubClient.CreateFromConnectionString(TestUtility.EventHubsConnectionString);
                        receiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromEnqueuedTime(DateTime.UtcNow.AddMinutes(1)));
                        var ed = await receiver.ReceiveAsync(1, TimeSpan.FromSeconds(receiveTimeoutInSeconds));
                        if (ed == null)
                        {
                            TestUtility.Log($"Received NULL from client {i}");
                        }
                    }
                    finally
                    {
                        await receiver.CloseAsync();
                    }
                });

            await Task.WhenAll(tasks);
        }
    }
}
