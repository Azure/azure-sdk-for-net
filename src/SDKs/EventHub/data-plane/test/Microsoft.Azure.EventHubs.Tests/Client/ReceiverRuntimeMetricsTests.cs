// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class ReceiverRuntimeMetricsTests : ClientTestBase
    {
        string targetPartitionId = "1";

        /// <summary>
        /// Basic runtime metrics validation.
        /// </summary>
        [Fact]
        [DisplayTestMethodName]
        async Task BasicValidation()
        {
            // Send some number of messages to target partition.
            await TestUtility.SendToPartitionAsync(this.EventHubClient, targetPartitionId, "this is the message body", 10);

            // Get partition runtime info so we can compare with runtime metrics.
            var pInfo = await this.EventHubClient.GetPartitionRuntimeInformationAsync(targetPartitionId);

            // Create a new receiver with ReceiverOptions setting to enable runtime metrics.
            var partitionReceiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName,
                targetPartitionId,
                EventPosition.FromStart(),
                new ReceiverOptions()
                {
                    EnableReceiverRuntimeMetric = true
                });

            await ValidateEnabledBehavior(partitionReceiver, pInfo);
        }

        /// <summary>
        /// Validate that receiver runtime metrics are disabled by default.
        /// </summary>
        [Fact]
        [DisplayTestMethodName]
        async Task DefaultBehaviorDisabled()
        {
            // Send single event 
            await TestUtility.SendToPartitionAsync(this.EventHubClient, targetPartitionId, "this is the message body");

            // Create a new receiver and validate ReceiverRuntimeMetricEnabled.
            var partitionReceiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, targetPartitionId, EventPosition.FromStart());
            await ValidateDisabledBehavior(partitionReceiver);
        }

        /// <summary>
        /// Validate that ReceiverOptions setting while creating PartitionReceiver overrides client settings.
        /// </summary>
        [Fact]
        [DisplayTestMethodName]
        async Task DisableWithReceiverOptions()
        {
            // Send single event 
            await TestUtility.SendToPartitionAsync(this.EventHubClient, targetPartitionId, "this is the message body");

            // Enable runtime metrics on the client.
            var defaultReceiverRuntimeMetricSetting = this.EventHubClient.EnableReceiverRuntimeMetric;
            this.EventHubClient.EnableReceiverRuntimeMetric = true;

            try
            {
                // Create a new receiver and disable runtime metrics via ReceiverOptions.
                var partitionReceiver = 
                    this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, targetPartitionId, EventPosition.FromStart(),
                    new ReceiverOptions()
                    {
                        EnableReceiverRuntimeMetric = false
                    });

                await ValidateDisabledBehavior(partitionReceiver);
            }
            finally
            {
                this.EventHubClient.EnableReceiverRuntimeMetric = defaultReceiverRuntimeMetricSetting;
            }
        }

        /// <summary>
        /// Client setting should inheret all receivers created from that client.
        /// </summary>
        [Fact]
        [DisplayTestMethodName]
        async Task ClientSettingInherited()
        {
            // Send some number of messages to target partition.
            await TestUtility.SendToPartitionAsync(this.EventHubClient, targetPartitionId, "this is the message body", 10);

            // Get partition runtime info so we can compare with runtime metrics.
            var pInfo = await this.EventHubClient.GetPartitionRuntimeInformationAsync(targetPartitionId);

            // Enable runtime metrics on the client.
            var defaultReceiverRuntimeMetricSetting = this.EventHubClient.EnableReceiverRuntimeMetric;
            this.EventHubClient.EnableReceiverRuntimeMetric = true;

            try
            {
                // Create 2 new receivers. These receivers are expected to show runtime metrics since their parent client is enabled.
                var partitionReceiver1 =
                    this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, targetPartitionId, EventPosition.FromStart());
                var partitionReceiver2 =
                    this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, targetPartitionId, EventPosition.FromStart());

                await ValidateEnabledBehavior(partitionReceiver1, pInfo);
                await ValidateEnabledBehavior(partitionReceiver2, pInfo);
            }
            finally
            {
                this.EventHubClient.EnableReceiverRuntimeMetric = defaultReceiverRuntimeMetricSetting;
            }
        }

        async Task ValidateEnabledBehavior(PartitionReceiver partitionReceiver, EventHubPartitionRuntimeInformation pInfo)
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

        async Task ValidateDisabledBehavior(PartitionReceiver partitionReceiver)
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
