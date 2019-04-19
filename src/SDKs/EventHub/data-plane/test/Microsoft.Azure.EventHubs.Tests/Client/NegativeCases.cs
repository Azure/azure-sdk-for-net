// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Client
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class NegativeCases : ClientTestBase
    {
        [Fact]
        [DisplayTestMethodName]
        async Task NonexistentEntity()
        {
            // Rebuild connection string with a nonexistent entity.
            var csb = new EventHubsConnectionStringBuilder(TestUtility.EventHubsConnectionString);
            csb.EntityPath = Guid.NewGuid().ToString();
            var ehClient = EventHubClient.CreateFromConnectionString(csb.ToString());

            // GetRuntimeInformationAsync on a nonexistent entity.
            await Assert.ThrowsAsync<MessagingEntityNotFoundException>(async () =>
            {
                TestUtility.Log("Getting entity information from a nonexistent entity.");
                await ehClient.GetRuntimeInformationAsync();
                throw new InvalidOperationException("GetRuntimeInformation call should have failed");
            });

            // GetPartitionRuntimeInformationAsync on a nonexistent entity.
            await Assert.ThrowsAsync<MessagingEntityNotFoundException>(async () =>
            {
                TestUtility.Log("Getting partition information from a nonexistent entity.");
                await ehClient.GetPartitionRuntimeInformationAsync("0");
                throw new InvalidOperationException("GetPartitionRuntimeInformation call should have failed");
            });

            // Try sending.
            PartitionSender sender = null;
            await Assert.ThrowsAsync<MessagingEntityNotFoundException>(async () =>
            {
                TestUtility.Log("Sending an event to nonexistent entity.");
                sender = ehClient.CreatePartitionSender("0");
                await sender.SendAsync(new EventData(Encoding.UTF8.GetBytes("this send should fail.")));
                throw new InvalidOperationException("Send call should have failed");
            });
            await sender.CloseAsync();

            // Try receiving.
            PartitionReceiver receiver = null;
            await Assert.ThrowsAsync<MessagingEntityNotFoundException>(async () =>
            {
                TestUtility.Log("Receiving from nonexistent entity.");
                receiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromStart());
                await receiver.ReceiveAsync(1);
                throw new InvalidOperationException("Receive call should have failed");
            });
            await receiver.CloseAsync();

            // Try receiving on an nonexistent consumer group.
            ehClient = EventHubClient.CreateFromConnectionString(TestUtility.EventHubsConnectionString);
            await Assert.ThrowsAsync<MessagingEntityNotFoundException>(async () =>
            {
                TestUtility.Log("Receiving from nonexistent consumer group.");
                receiver = ehClient.CreateReceiver(Guid.NewGuid().ToString(), "0", EventPosition.FromStart());
                await receiver.ReceiveAsync(1);
                throw new InvalidOperationException("Receive call should have failed");
            });
            await receiver.CloseAsync();
        }

        [Fact]
        [DisplayTestMethodName]
        async Task ReceiveFromInvalidPartition()
        {
            PartitionReceiver receiver = null;

            // Some invalid partition values. These will fail on the service side.
            var invalidPartitions = new List<string>() { "XYZ", "-1", "1000", "-" };
            foreach (var invalidPartitionId in invalidPartitions)
            {
                await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
                {
                    TestUtility.Log($"Receiving from invalid partition {invalidPartitionId}");
                    receiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, invalidPartitionId, EventPosition.FromStart());
                    await receiver.ReceiveAsync(1);
                    throw new InvalidOperationException("Receive call should have failed");
                });
                await receiver.CloseAsync();
            }

            // Some invalid partition values. These will fail on the client side.
            invalidPartitions = new List<string>() { " ", null, "" };
            foreach (var invalidPartitionId in invalidPartitions)
            {
                await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                {
                    TestUtility.Log($"Receiving from invalid partition {invalidPartitionId}");
                    receiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, invalidPartitionId, EventPosition.FromStart());
                    await receiver.ReceiveAsync(1);
                    throw new InvalidOperationException("Receive call should have failed");
                });
                await receiver.CloseAsync();
            }
        }

        [Fact]
        [DisplayTestMethodName]
        async Task SendToInvalidPartition()
        {
            PartitionSender sender = null;

            // Some invalid partition values.
            var invalidPartitions = new List<string>() { "XYZ", "-1", "1000", "-" };

            foreach (var invalidPartitionId in invalidPartitions)
            {
                await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
                {
                    TestUtility.Log($"Sending to invalid partition {invalidPartitionId}");
                    sender = this.EventHubClient.CreatePartitionSender(invalidPartitionId);
                    await sender.SendAsync(new EventData(new byte[1]));
                    throw new InvalidOperationException("Send call should have failed");
                });
                await sender.CloseAsync();
            }

            // Some other invalid partition values. These will fail on the client side.
            invalidPartitions = new List<string>() { "", " ", null };
            foreach (var invalidPartitionId in invalidPartitions)
            {
                await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                {
                    TestUtility.Log($"Sending to invalid partition {invalidPartitionId}");
                    sender = this.EventHubClient.CreatePartitionSender(invalidPartitionId);
                    await sender.SendAsync(new EventData(new byte[1]));
                    throw new InvalidOperationException("Send call should have failed");
                });
                await sender.CloseAsync();
            }
        }

        [Fact]
        [DisplayTestMethodName]
        async Task GetPartitionRuntimeInformationFromInvalidPartition()
        {
            // Some invalid partition values. These will fail on the service side.
            var invalidPartitions = new List<string>() { "XYZ", "-1", "1000", "-" };

            foreach (var invalidPartitionId in invalidPartitions)
            {
                await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
                {
                    TestUtility.Log($"Getting partition information from invalid partition {invalidPartitionId}");
                    await this.EventHubClient.GetPartitionRuntimeInformationAsync(invalidPartitionId);
                    throw new InvalidOperationException("GetPartitionRuntimeInformation call should have failed");
                });
            }

            // Some other invalid partition values. These will fail on the client side.
            invalidPartitions = new List<string>() { "", " ", null };
            foreach (var invalidPartitionId in invalidPartitions)
            {
                await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                {
                    TestUtility.Log($"Getting partition information from invalid partition {invalidPartitionId}");
                    await this.EventHubClient.GetPartitionRuntimeInformationAsync(invalidPartitionId);
                    throw new InvalidOperationException("GetPartitionRuntimeInformation call should have failed");
                });
            }
        }

        [Fact]
        [DisplayTestMethodName]
        Task CreateClientWithoutEntityPathShouldFail()
        {
            // Remove entity path from connection string.
            var csb = new EventHubsConnectionStringBuilder(TestUtility.EventHubsConnectionString);
            csb.EntityPath = null;

            return Assert.ThrowsAsync<ArgumentNullException>(() =>
            {
                EventHubClient.CreateFromConnectionString(csb.ToString());
                throw new Exception("Entity path wasn't provided in the connection string and this new call was supposed to fail");
            });
        }

        [Fact]
        [DisplayTestMethodName]
        async Task MessageSizeExceededException()
        {
            try
            {
                TestUtility.Log("Sending large event via EventHubClient.SendAsync(EventData)");
                var eventData = new EventData(new byte[1100000]);
                await this.EventHubClient.SendAsync(eventData);
                throw new InvalidOperationException("Send should have failed with " +
                    typeof(MessageSizeExceededException).Name);
            }
            catch (MessageSizeExceededException)
            {
                TestUtility.Log("Caught MessageSizeExceededException as expected");
            }
        }

        [Fact]
        [DisplayTestMethodName]
        async Task NullBodyShouldFail()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
            {
                new EventData(null);
                throw new Exception("new EventData(null) was supposed to fail");
            });
        }

        [Fact]
        [DisplayTestMethodName]
        async Task InvalidPrefetchCount()
        {
            var receiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromStart());

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
            {
                receiver.PrefetchCount = 3;
                throw new Exception("Setting PrefetchCount to 3 didn't fail.");
            });

            TestUtility.Log("Setting PrefetchCount to 10.");
            receiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromStart());
            receiver.PrefetchCount = 10;

            TestUtility.Log("Setting PrefetchCount to int.MaxValue.");
            receiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromStart());
            receiver.PrefetchCount = int.MaxValue;
        }
    }
}
