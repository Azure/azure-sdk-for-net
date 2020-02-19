// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Client
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure.EventHubs;
    using Xunit;

    public class ReceiverRuntimeMetricsTests : ClientTestBase
    {
        readonly string targetPartitionId = "1";
        readonly string connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";

        [Fact]
        [DisplayTestMethodName]
        public async Task BasicValidation()
        {
            var mockClient = new MockEventHubClient(new EventHubsConnectionStringBuilder(connectionString));
            var partitionReceiver = mockClient.CreateReceiver("consumerGroup", targetPartitionId, EventPosition.FromStart(), new ReceiverOptions { EnableReceiverRuntimeMetric = true });
            var partitionSender = mockClient.CreateEventSender(targetPartitionId);

            await partitionSender.SendAsync(new EventData[] { new EventData(Encoding.UTF8.GetBytes("foo")) }, targetPartitionId);

            // Get the partition runtime info so we can compare with runtime metrics.
            var pInfo = await mockClient.GetPartitionRuntimeInformationAsync(targetPartitionId);

            await ValidateEnabledBehavior(partitionReceiver, pInfo);
        }

        [Fact]
        [DisplayTestMethodName]
        public async Task DefaultBehaviorDisabled()
        {
            var mockClient = new MockEventHubClient(new EventHubsConnectionStringBuilder(connectionString));
            var partitionReceiver = mockClient.CreateReceiver("consumerGroup", targetPartitionId, EventPosition.FromStart());
            var partitionSender = mockClient.CreateEventSender(targetPartitionId);

            await partitionSender.SendAsync(new EventData[] { new EventData(Encoding.UTF8.GetBytes("foo")) }, targetPartitionId);

            await ValidateDisabledBehavior(partitionReceiver);
        }

        [Fact]
        [DisplayTestMethodName]
        public async Task DisableWithReceiverOptions()
        {
            var mockClient = new MockEventHubClient(new EventHubsConnectionStringBuilder(connectionString));
            var partitionReceiver = mockClient.CreateReceiver("consumerGroup", targetPartitionId, EventPosition.FromStart(), new ReceiverOptions { EnableReceiverRuntimeMetric = false });
            var partitionSender = mockClient.CreateEventSender(targetPartitionId);

            await partitionSender.SendAsync(new EventData[] { new EventData(Encoding.UTF8.GetBytes("foo")) }, targetPartitionId);

            await ValidateDisabledBehavior(partitionReceiver);
        }

        [Fact]
        [DisplayTestMethodName]
        public async Task ClientSettingInherited()
        {
            var mockClient = new MockEventHubClient(new EventHubsConnectionStringBuilder(connectionString));

            // Enable runtime metrics on the client.
            mockClient.EnableReceiverRuntimeMetric = true;

            var partitionReceiver1 = mockClient.CreateReceiver("consumerGroup", targetPartitionId, EventPosition.FromStart());
            var partitionReceiver2 = mockClient.CreateReceiver("consumerGroup", targetPartitionId, EventPosition.FromStart());
            var partitionSender = mockClient.CreateEventSender(targetPartitionId);

            await partitionSender.SendAsync(
                Enumerable.Range(1, 10)
                    .Select(number => new EventData(Encoding.UTF8.GetBytes(number.ToString()))
                ), targetPartitionId);

            // Get the partition runtime info so we can compare with runtime metrics.
            var pInfo = await mockClient.GetPartitionRuntimeInformationAsync(targetPartitionId);

            await ValidateEnabledBehavior(partitionReceiver1, pInfo);
            await ValidateEnabledBehavior(partitionReceiver2, pInfo);

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
            Assert.True(partitionReceiver.RuntimeInfo.LastSequenceNumber == -1,
                $"FAILED partitionReceiver.RuntimeInfo.LastSequenceNumber == {partitionReceiver.RuntimeInfo.LastSequenceNumber}");
            Assert.True(partitionReceiver.RuntimeInfo.RetrievalTime == DateTime.MinValue,
                $"FAILED partitionReceiver.RuntimeInfo.RetrievalTime == {partitionReceiver.RuntimeInfo.RetrievalTime}");
        }
    }
}
