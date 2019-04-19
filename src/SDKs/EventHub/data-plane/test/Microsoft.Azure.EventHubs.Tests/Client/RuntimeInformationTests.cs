// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class RuntimeInformationTests : ClientTestBase
    {
        [Fact]
        [DisplayTestMethodName]
        async Task GetEventHubRuntimeInformation()
        {
            TestUtility.Log("Getting  EventHubRuntimeInformation");
            var eventHubRuntimeInformation = await this.EventHubClient.GetRuntimeInformationAsync();

            Assert.True(eventHubRuntimeInformation != null, "eventHubRuntimeInformation was null!");
            Assert.True(eventHubRuntimeInformation.PartitionIds != null, "eventHubRuntimeInformation.PartitionIds was null!");
            Assert.True(eventHubRuntimeInformation.PartitionIds.Length != 0, "eventHubRuntimeInformation.PartitionIds.Length was 0!");

            TestUtility.Log("Found partitions:");
            foreach (string partitionId in eventHubRuntimeInformation.PartitionIds)
            {
                TestUtility.Log(partitionId);
            }
        }

        [Fact]
        [DisplayTestMethodName]
        async Task GetEventHubPartitionRuntimeInformation()
        {
            var cbs = new EventHubsConnectionStringBuilder(TestUtility.EventHubsConnectionString);

            TestUtility.Log("Getting EventHubPartitionRuntimeInformation on each partition in parallel");
            var tasks = this.PartitionIds.Select(async (pid) =>
            {
                // Send some messages so we can have meaningful data returned from service call.
                PartitionSender partitionSender = this.EventHubClient.CreatePartitionSender(pid);
                TestUtility.Log($"Sending single event to partition {pid}");
                var eDataToSend = new EventData(new byte[1]);
                await partitionSender.SendAsync(eDataToSend);

                TestUtility.Log($"Getting partition runtime information on partition {pid}");
                var p = await this.EventHubClient.GetPartitionRuntimeInformationAsync(pid);
                TestUtility.Log($"Path:{p.Path} PartitionId:{p.PartitionId} BeginSequenceNumber:{p.BeginSequenceNumber} LastEnqueuedOffset:{p.LastEnqueuedOffset} LastEnqueuedTimeUtc:{p.LastEnqueuedTimeUtc} LastEnqueuedSequenceNumber:{p.LastEnqueuedSequenceNumber}");

                // Validations.
                Assert.True(p.Path == cbs.EntityPath, $"Returned path {p.Path} is different than {cbs.EntityPath}");
                Assert.True(p.PartitionId == pid, $"Returned partition id {p.PartitionId} is different than {pid}");
                Assert.True(p.LastEnqueuedOffset != null, "Returned LastEnqueuedOffset is null");
                Assert.True(p.LastEnqueuedTimeUtc != null, "Returned LastEnqueuedTimeUtc is null");

                // Validate returned data regarding recently sent event.
                // Account 60 seconds of max clock skew.
                Assert.True(p.LastEnqueuedOffset != "-1", $"Returned LastEnqueuedOffset is {p.LastEnqueuedOffset}");
                Assert.True(p.BeginSequenceNumber >= 0, $"Returned BeginSequenceNumber is {p.BeginSequenceNumber}");
                Assert.True(p.LastEnqueuedSequenceNumber >= 0, $"Returned LastEnqueuedSequenceNumber is {p.LastEnqueuedSequenceNumber}");
                Assert.True(p.LastEnqueuedTimeUtc >= DateTime.UtcNow.AddSeconds(-60), $"Returned LastEnqueuedTimeUtc is {p.LastEnqueuedTimeUtc}");
            });

            await Task.WhenAll(tasks);
        }

        [Fact]
        [DisplayTestMethodName]
        async Task MultipleClientsGetRuntimeInformation()
        {
            var maxNumberOfClients = 100;
            var syncEvent = new ManualResetEventSlim(false);

            TestUtility.Log($"Starting {maxNumberOfClients} GetRuntimeInformationAsync tasks in parallel.");

            var tasks = new List<Task>();
            for (var i = 0; i < maxNumberOfClients; i++)
            {
                var task = Task.Run(async () =>
                {
                    syncEvent.Wait();
                    var ehClient = EventHubClient.CreateFromConnectionString(TestUtility.EventHubsConnectionString);
                    await ehClient.GetRuntimeInformationAsync();
                });

                tasks.Add(task);
            }

            var waitForAccountToInitialize = Task.Delay(10000);
            await waitForAccountToInitialize;
            syncEvent.Set();
            await Task.WhenAll(tasks);

            TestUtility.Log("All GetRuntimeInformationAsync tasks have completed.");
        }
    }
}
