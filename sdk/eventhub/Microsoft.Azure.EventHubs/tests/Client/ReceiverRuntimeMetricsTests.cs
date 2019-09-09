// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Client
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class ReceiverRuntimeMetricsTests : ClientTestBase
    {
        string targetPartitionId = "1";

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task BasicValidation()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                var partitionReceiver = default(PartitionReceiver);

                try
                {
                    // Send some number of messages to target partition.
                    await TestUtility.SendToPartitionAsync(ehClient, targetPartitionId, "this is the message body", 10);

                    // Get partition runtime info so we can compare with runtime metrics.
                    var pInfo = await ehClient.GetPartitionRuntimeInformationAsync(targetPartitionId);

                    // Create a new receiver with ReceiverOptions setting to enable runtime metrics.
                    partitionReceiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName,
                        targetPartitionId,
                        EventPosition.FromStart(),
                        new ReceiverOptions()
                        {
                            EnableReceiverRuntimeMetric = true
                        });

                    await ValidateEnabledBehavior(partitionReceiver, pInfo);
                }
                finally
                {
                    await Task.WhenAll(
                        partitionReceiver?.CloseAsync(),
                        ehClient.CloseAsync());
                }
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task DefaultBehaviorDisabled()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                var partitionReceiver = default(PartitionReceiver);

                try
                {
                    // Send single event
                    await TestUtility.SendToPartitionAsync(ehClient, targetPartitionId, "this is the message body");

                    // Create a new receiver and validate ReceiverRuntimeMetricEnabled.
                    partitionReceiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, targetPartitionId, EventPosition.FromStart());
                    await ValidateDisabledBehavior(partitionReceiver);
                }
                finally
                {
                    await Task.WhenAll(
                        partitionReceiver?.CloseAsync(),
                        ehClient.CloseAsync());
                }
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task DisableWithReceiverOptions()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                var partitionReceiver = default(PartitionReceiver);

                try
                {
                    // Send single event
                    await TestUtility.SendToPartitionAsync(ehClient, targetPartitionId, "this is the message body");

                    // Enable runtime metrics on the client.
                    ehClient.EnableReceiverRuntimeMetric = true;

                    // Create a new receiver and disable runtime metrics via ReceiverOptions.
                    partitionReceiver =
                        ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, targetPartitionId, EventPosition.FromStart(),
                        new ReceiverOptions()
                        {
                            EnableReceiverRuntimeMetric = false
                        });

                    await ValidateDisabledBehavior(partitionReceiver);
                }
                finally
                {
                    await Task.WhenAll(
                        partitionReceiver?.CloseAsync(),
                        ehClient.CloseAsync());
                }
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task ClientSettingInherited()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                var partitionReceiver1 = default(PartitionReceiver);
                var partitionReceiver2 = default(PartitionReceiver);

                try
                {
                    // Send some number of messages to target partition.
                    await TestUtility.SendToPartitionAsync(ehClient, targetPartitionId, "this is the message body", 10);

                    // Get partition runtime info so we can compare with runtime metrics.
                    var pInfo = await ehClient.GetPartitionRuntimeInformationAsync(targetPartitionId);

                    // Enable runtime metrics on the client.
                    ehClient.EnableReceiverRuntimeMetric = true;

                    // Create 2 new receivers. These receivers are expected to show runtime metrics since their parent client is enabled.
                    partitionReceiver1 =
                        ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, targetPartitionId, EventPosition.FromStart());
                    partitionReceiver2 =
                        ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, targetPartitionId, EventPosition.FromStart());

                    await ValidateEnabledBehavior(partitionReceiver1, pInfo);
                    await ValidateEnabledBehavior(partitionReceiver2, pInfo);
                }
                finally
                {
                    await Task.WhenAll(
                        partitionReceiver1?.CloseAsync(),
                        partitionReceiver2?.CloseAsync(),
                        ehClient.CloseAsync());
                }
            }
        }

        private async Task ValidateEnabledBehavior(PartitionReceiver partitionReceiver, EventHubPartitionRuntimeInformation pInfo)
        {
            Assert.True(partitionReceiver.ReceiverRuntimeMetricEnabled == true, "ReceiverRuntimeMetricEnabled == false");

            // Receive a message and validate RuntimeInfo is set.
            var messages = await partitionReceiver.ReceiveAsync(1);
            Assert.True(messages != null, "Failed to receive a message.");

            var message = messages.Single();

            Assert.False(pInfo.IsEmpty, $"pInfo.IsEmpty == {pInfo.IsEmpty}");
            Assert.True(partitionReceiver.RuntimeInfo.LastEnqueuedOffset == pInfo.LastEnqueuedOffset,
                $"FAILED partitionReceiver.RuntimeInfo.LastEnqueuedOffset == {partitionReceiver.RuntimeInfo.LastEnqueuedOffset}");
            Assert.True(partitionReceiver.RuntimeInfo.LastEnqueuedTimeUtc == pInfo.LastEnqueuedTimeUtc,
                $"FAILED partitionReceiver.RuntimeInfo.LastEnqueuedTimeUtc == {partitionReceiver.RuntimeInfo.LastEnqueuedTimeUtc}");
            Assert.True(partitionReceiver.RuntimeInfo.LastSequenceNumber == pInfo.LastEnqueuedSequenceNumber,
                $"FAILED partitionReceiver.RuntimeInfo.LastSequenceNumber == {partitionReceiver.RuntimeInfo.LastSequenceNumber}");
            Assert.True(partitionReceiver.RuntimeInfo.RetrievalTime > DateTime.UtcNow.AddSeconds(-60),
                $"FAILED partitionReceiver.RuntimeInfo.RetrievalTime == {partitionReceiver.RuntimeInfo.RetrievalTime}");
            Assert.True(partitionReceiver.RuntimeInfo.PartitionId == partitionReceiver.PartitionId,
                $"FAILED partitionReceiver.RuntimeInfo.PartitionId == {partitionReceiver.RuntimeInfo.PartitionId}");
        }

        private async Task ValidateDisabledBehavior(PartitionReceiver partitionReceiver)
        {
            Assert.True(partitionReceiver.ReceiverRuntimeMetricEnabled == false, "ReceiverRuntimeMetricEnabled == true");

            // Receive a message and validate RuntimeInfo isn't set.
            var msg = await partitionReceiver.ReceiveAsync(1);
            Assert.True(msg != null, "Failed to receive a message.");
            Assert.True(partitionReceiver.RuntimeInfo.LastEnqueuedOffset == null,
                $"FAILED partitionReceiver.RuntimeInfo.LastEnqueuedOffset == {partitionReceiver.RuntimeInfo.LastEnqueuedOffset}");
            Assert.True(partitionReceiver.RuntimeInfo.LastEnqueuedTimeUtc == DateTime.MinValue,
                $"FAILED partitionReceiver.RuntimeInfo.LastEnqueuedTimeUtc == {partitionReceiver.RuntimeInfo.LastEnqueuedTimeUtc}");
            Assert.True(partitionReceiver.RuntimeInfo.LastSequenceNumber == 0,
                $"FAILED partitionReceiver.RuntimeInfo.LastSequenceNumber == {partitionReceiver.RuntimeInfo.LastSequenceNumber}");
            Assert.True(partitionReceiver.RuntimeInfo.RetrievalTime == DateTime.MinValue,
                $"FAILED partitionReceiver.RuntimeInfo.RetrievalTime == {partitionReceiver.RuntimeInfo.RetrievalTime}");
        }
    }
}
