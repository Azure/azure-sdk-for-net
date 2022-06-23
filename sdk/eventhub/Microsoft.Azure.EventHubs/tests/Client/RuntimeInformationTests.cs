// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class RuntimeInformationTests : ClientTestBase
    {
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task GetEventHubRuntimeInformation()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);

                try
                {
                    TestUtility.Log("Getting  EventHubRuntimeInformation");
                    var eventHubRuntimeInformation = await ehClient.GetRuntimeInformationAsync();

                    Assert.True(eventHubRuntimeInformation != null, "eventHubRuntimeInformation was null!");
                    Assert.True(eventHubRuntimeInformation.PartitionIds != null, "eventHubRuntimeInformation.PartitionIds was null!");
                    Assert.True(eventHubRuntimeInformation.PartitionIds.Length != 0, "eventHubRuntimeInformation.PartitionIds.Length was 0!");

                    TestUtility.Log("Found partitions:");
                    foreach (string partitionId in eventHubRuntimeInformation.PartitionIds)
                    {
                        TestUtility.Log(partitionId);
                    }
                }
                finally
                {
                    await ehClient.CloseAsync();
                }
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task GetEventHubPartitionRuntimeInformation()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var csb = new EventHubsConnectionStringBuilder(connectionString);
                var ehClient = EventHubClient.CreateFromConnectionString(csb.ToString());
                var partitions = await this.GetPartitionsAsync(ehClient);

                try
                {
                    TestUtility.Log("Getting EventHubPartitionRuntimeInformation on each partition in parallel");
                    var tasks = partitions.Select(async (pid) =>
                    {
                        // Send some messages so we can have meaningful data returned from service call.
                        PartitionSender partitionSender = ehClient.CreatePartitionSender(pid);

                        try
                        {
                            TestUtility.Log($"Sending single event to partition {pid}");
                            var eDataToSend = new EventData(new byte[1]);
                            await partitionSender.SendAsync(eDataToSend);

                            TestUtility.Log($"Getting partition runtime information on partition {pid}");
                            var partition = await ehClient.GetPartitionRuntimeInformationAsync(pid);
                            TestUtility.Log($"Path:{partition.Path} PartitionId:{partition.PartitionId} BeginSequenceNumber:{partition.BeginSequenceNumber} LastEnqueuedOffset:{partition.LastEnqueuedOffset} LastEnqueuedTimeUtc:{partition.LastEnqueuedTimeUtc} LastEnqueuedSequenceNumber:{partition.LastEnqueuedSequenceNumber}");

                            // Validations.
                            Assert.True(partition.Path == csb.EntityPath, $"Returned path {partition.Path} is different than {csb.EntityPath}");
                            Assert.True(partition.PartitionId == pid, $"Returned partition id {partition.PartitionId} is different than {pid}");
                            Assert.True(partition.LastEnqueuedOffset != null, "Returned LastEnqueuedOffset is null");
                            Assert.True(partition.LastEnqueuedTimeUtc != default, "Returned LastEnqueuedTimeUtc is null");

                            // Validate returned data regarding recently sent event.
                            // Account 60 seconds of max clock skew.
                            Assert.True(partition.LastEnqueuedOffset != "-1", $"Returned LastEnqueuedOffset is {partition.LastEnqueuedOffset}");
                            Assert.True(partition.BeginSequenceNumber >= 0, $"Returned BeginSequenceNumber is {partition.BeginSequenceNumber}");
                            Assert.True(partition.LastEnqueuedSequenceNumber >= 0, $"Returned LastEnqueuedSequenceNumber is {partition.LastEnqueuedSequenceNumber}");
                            Assert.True(partition.LastEnqueuedTimeUtc >= DateTime.UtcNow.AddSeconds(-60), $"Returned LastEnqueuedTimeUtc is {partition.LastEnqueuedTimeUtc}");
                        }
                        finally
                        {
                            await partitionSender.CloseAsync();
                        }
                    });

                    await Task.WhenAll(tasks);
                }
                finally
                {
                    await ehClient.CloseAsync();
                }
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task MultipleClientsGetRuntimeInformation()
        {
            var maxNumberOfClients = 100;
            var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            TestUtility.Log($"Starting {maxNumberOfClients} GetRuntimeInformationAsync tasks in parallel.");

            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var tasks = new List<Task>();

                for (var i = 0; i < maxNumberOfClients; i++)
                {
                    var task = Task.Run(async () =>
                    {
                        await tcs.Task;
                        var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                        var ehClient = EventHubClient.CreateFromConnectionString(connectionString);

                        try
                        {
                            await ehClient.GetRuntimeInformationAsync();
                        }
                        finally
                        {
                            await ehClient.CloseAsync();
                        }

                    });

                    tasks.Add(task);
                }

                await Task.Delay(10000);
                tcs.TrySetResult(true);
                await Task.WhenAll(tasks);
            }

            TestUtility.Log("All GetRuntimeInformationAsync tasks have completed.");
        }
    }
}
