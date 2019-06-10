// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of live tests for the <see cref="EventSender" />
    ///   class.
    /// </summary>
    ///
    /// <remarks>
    ///   These tests have a depenency on live Azure services and may
    ///   incur costs for the assocaied Azure subscription.
    /// </remarks>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class EventSenderLiveTests
    {
        /// <summary>
        ///   Verifies that the <see cref="EventHubClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task SenderWithNoOptionsCanSend()
        {
            await using (var scope = await EventHubScope.CreateAsync(4))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var sender = client.CreateSender())
                {
                    var events = new[] { new EventData(Encoding.UTF8.GetBytes("AWord")) };
                    Assert.That(async () => await sender.SendAsync(events), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task SenderWithOptionsCanSend()
        {
            await using (var scope = await EventHubScope.CreateAsync(4))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);
                var senderOptions = new EventSenderOptions { Retry = new ExponentialRetry(TimeSpan.FromSeconds(0.25), TimeSpan.FromSeconds(45), 5) };

                await using (var client = new EventHubClient(connectionString))
                await using (var sender = client.CreateSender(senderOptions))
                {
                    var events = new[] { new EventData(Encoding.UTF8.GetBytes("AWord")) };
                    Assert.That(async () => await sender.SendAsync(events), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task SenderCanSendToASpecificPartition()
        {
            await using (var scope = await EventHubScope.CreateAsync(4))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();
                    var senderOptions = new EventSenderOptions { PartitionId = partition };

                    await using (var sender = client.CreateSender(senderOptions))
                    {
                        var events = new[] { new EventData(Encoding.UTF8.GetBytes("AWord")) };
                        Assert.That(async () => await sender.SendAsync(events), Throws.Nothing);
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task SenderCanSendEventsWithCustomProperties()
        {
            await using (var scope = await EventHubScope.CreateAsync(4))
            {
                var events = new[]
                {
                    new EventData(new byte[] { 0x22, 0x33 }),
                    new EventData(Encoding.UTF8.GetBytes("This is a really long string of stuff that I wanted to type because I like to")),
                    new EventData(Encoding.UTF8.GetBytes("I wanted to type because I like to")),
                    new EventData(Encoding.UTF8.GetBytes("If you are reading this, you really like test cases"))
                };

                for (var index = 0; index < events.Length; ++index)
                {
                    events[index].Properties[index.ToString()] = "some value";
                    events[index].Properties["Type"] = $"com.microsoft.test.Type{ index }";
                }

                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var sender = client.CreateSender())
                {
                    Assert.That(async () => await sender.SendAsync(events), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task SenderCanSendEventsUsingAPartitionHashHey()
        {
            await using (var scope = await EventHubScope.CreateAsync(4))
            {
                var events = Enumerable
                    .Range(0, 25)
                    .Select(index => new EventData(Encoding.UTF8.GetBytes(new String('X', index + 5))));

                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var sender = client.CreateSender())
                {
                    var batchOptions = new EventBatchingOptions { PartitionKey = "some123key-!d" };
                    Assert.That(async () => await sender.SendAsync(events, batchOptions), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task SenderCanSendMultipleBatchesOfEventsUsingAPartitionHashHey()
        {
            await using (var scope = await EventHubScope.CreateAsync(4))
            {
                var batchOptions = new EventBatchingOptions { PartitionKey = "some123key-!d" };

                for (var index = 0; index < 5; ++index)
                {
                    var events = Enumerable
                        .Range(0, 25)
                        .Select(index => new EventData(Encoding.UTF8.GetBytes(new String((char)(65 + index), index + 5))));

                    var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                    await using (var client = new EventHubClient(connectionString))
                    await using (var sender = client.CreateSender())
                    {
                        Assert.That(async () => await sender.SendAsync(events, batchOptions), Throws.Nothing, $"Batch { index } should not have thrown an exception.");
                    }
                }
            }
        }
    }
}
