// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Client
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class ClientNegativeCases : ClientTestBase
    {
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task NonexistentEntity()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                PartitionReceiver receiver = null;
                // Rebuild connection string with a nonexistent entity.
                var csb = new EventHubsConnectionStringBuilder(connectionString);
                csb.EntityPath = Guid.NewGuid().ToString();
                var ehClient = EventHubClient.CreateFromConnectionString(csb.ToString());

                try
                {
                    // GetRuntimeInformationAsync on a nonexistent entity.
                    await Assert.ThrowsAsync<MessagingEntityNotFoundException>(async () =>
                    {
                        TestUtility.Log("Getting entity information from a nonexistent entity.");
                        await ehClient.GetRuntimeInformationAsync();
                    });

                    // GetPartitionRuntimeInformationAsync on a nonexistent entity.
                    await Assert.ThrowsAsync<MessagingEntityNotFoundException>(async () =>
                    {
                        TestUtility.Log("Getting partition information from a nonexistent entity.");
                        await ehClient.GetPartitionRuntimeInformationAsync("0");
                    });

                    // Try sending.
                    PartitionSender sender = null;
                    await Assert.ThrowsAsync<MessagingEntityNotFoundException>(async () =>
                    {
                        TestUtility.Log("Sending an event to nonexistent entity.");
                        sender = ehClient.CreatePartitionSender("0");
                        await sender.SendAsync(new EventData(Encoding.UTF8.GetBytes("this send should fail.")));
                    });
                    await sender.CloseAsync();

                    // Try receiving.
                    await Assert.ThrowsAsync<MessagingEntityNotFoundException>(async () =>
                    {
                        TestUtility.Log("Receiving from nonexistent entity.");
                        receiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromStart());
                        await receiver.ReceiveAsync(1);
                    });
                    await receiver.CloseAsync();
                }
                finally
                {
                    await ehClient.CloseAsync();
                }

                // Try receiving on an nonexistent consumer group.
                ehClient = EventHubClient.CreateFromConnectionString(connectionString);

                try
                {
                    await Assert.ThrowsAsync<MessagingEntityNotFoundException>(async () =>
                    {
                        TestUtility.Log("Receiving from nonexistent consumer group.");
                        receiver = ehClient.CreateReceiver(Guid.NewGuid().ToString(), "0", EventPosition.FromStart());
                        await receiver.ReceiveAsync(1);
                    });
                    await receiver.CloseAsync();
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
        public async Task ReceiveFromInvalidPartition()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                PartitionReceiver receiver = null;

                try
                {
                    // Some invalid partition values. These will fail on the service side.
                    var invalidPartitions = new List<string>() { "XYZ", "-1", "1000", "-" };
                    foreach (var invalidPartitionId in invalidPartitions)
                    {
                        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
                        {
                            TestUtility.Log($"Receiving from invalid partition {invalidPartitionId}");
                            receiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, invalidPartitionId, EventPosition.FromStart());
                            await receiver.ReceiveAsync(1);
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
                            receiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, invalidPartitionId, EventPosition.FromStart());
                            await receiver.ReceiveAsync(1);
                        });
                        await receiver.CloseAsync();
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
        public async Task SendToInvalidPartition()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                PartitionSender sender = null;

                try
                {
                    // Some invalid partition values.
                    var invalidPartitions = new List<string>() { "XYZ", "-1", "1000", "-" };

                    foreach (var invalidPartitionId in invalidPartitions)
                    {
                        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
                        {
                            TestUtility.Log($"Sending to invalid partition {invalidPartitionId}");
                            sender = ehClient.CreatePartitionSender(invalidPartitionId);
                            await sender.SendAsync(new EventData(new byte[1]));
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
                            sender = ehClient.CreatePartitionSender(invalidPartitionId);
                            await sender.SendAsync(new EventData(new byte[1]));
                        });
                        await sender.CloseAsync();
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
        public async Task GetPartitionRuntimeInformationFromInvalidPartition()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);

                try
                {
                    // Some invalid partition values. These will fail on the service side.
                    var invalidPartitions = new List<string>() { "XYZ", "-1", "1000", "-" };

                    foreach (var invalidPartitionId in invalidPartitions)
                    {
                        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
                        {
                            TestUtility.Log($"Getting partition information from invalid partition {invalidPartitionId}");
                            await ehClient.GetPartitionRuntimeInformationAsync(invalidPartitionId);
                        });
                    }

                    // Some other invalid partition values. These will fail on the client side.
                    invalidPartitions = new List<string>() { "", " ", null };
                    foreach (var invalidPartitionId in invalidPartitions)
                    {
                        await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                        {
                            TestUtility.Log($"Getting partition information from invalid partition {invalidPartitionId}");
                            await ehClient.GetPartitionRuntimeInformationAsync(invalidPartitionId);
                        });
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
        public async Task CreateClientWithoutEntityPathShouldFail()
        {
            // Remove entity path from connection string.
            var csb = new EventHubsConnectionStringBuilder(TestUtility.EventHubsConnectionString);
            csb.EntityPath = null;

            await Assert.ThrowsAsync<ArgumentNullException>(() =>
            {
                EventHubClient.CreateFromConnectionString(csb.ToString());
                throw new Exception("Entity path wasn't provided in the connection string and this new call was supposed to fail");
            });

        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task MessageSizeExceededException()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);

                try
                {
                    await Assert.ThrowsAsync<MessageSizeExceededException>(async () =>
                    {
                        TestUtility.Log("Sending large event via EventHubClient.SendAsync(EventData)");
                        var eventData = new EventData(new byte[1100000]);
                        await ehClient.SendAsync(eventData);
                    });
                }
                finally
                {
                    await ehClient.CloseAsync();
                }
            }
        }

        [Fact]
        [DisplayTestMethodName]
        public async Task NullBodyShouldFail()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
            {
                new EventData(null);
                throw new Exception("new EventData(null) was supposed to fail");
            });
        }

        [Fact]
        [DisplayTestMethodName]
        public async Task ClosedClientsThrow()
        {
            var ehClient = EventHubClient.CreateFromConnectionString(DummyConnectionString);
            var receiver = ehClient.CreateReceiver("cg", "0", EventPosition.FromStart());
            var sender = ehClient.CreatePartitionSender("0");

            // Sender closed.
            await sender.CloseAsync();
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await sender.SendAsync(new EventData(new byte[10]));
                throw new Exception("SendAsync call was supposed to fail");
            });

            // Receiver closed.
            await receiver.CloseAsync();
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await receiver.ReceiveAsync(1);
                throw new Exception("ReceiveAsync call was supposed to fail");
            });

            // EventHubClient closed.
            await ehClient.CloseAsync();
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await ehClient.SendAsync(new EventData(new byte[10]));
                throw new Exception("SendAsync call was supposed to fail");
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task InvalidPrefetchCount()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                var receiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromStart());

                try
                {
                    await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
                    {
                        receiver.PrefetchCount = 3;
                        throw new Exception("Setting PrefetchCount to 3 didn't fail.");
                    });

                    TestUtility.Log("Setting PrefetchCount to 10.");
                    receiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromStart());
                    receiver.PrefetchCount = 10;

                    TestUtility.Log("Setting PrefetchCount to int.MaxValue.");
                    receiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromStart());
                    receiver.PrefetchCount = int.MaxValue;
                }
                finally
                {
                    await Task.WhenAll(
                        receiver.CloseAsync(),
                        ehClient.CloseAsync());
                }
            }
        }
    }
}
