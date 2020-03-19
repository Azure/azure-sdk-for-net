// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of live tests for the <see cref="PartitionReceiver" />
    ///   class.
    /// </summary>
    ///
    /// <remarks>
    ///   These tests have a dependency on live Azure services and may
    ///   incur costs for the associated Azure subscription.
    /// </remarks>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class PartitionReceiverLiveTests
    {
        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(EventHubsTransportType.AmqpTcp)]
        [TestCase(EventHubsTransportType.AmqpWebSockets)]
        public async Task PartitionReceiverCanRetrievePartitionProperties(EventHubsTransportType transportType)
        {
            var partitionCount = 1;

            await using (EventHubScope scope = await EventHubScope.CreateAsync(partitionCount))
            {
                var cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));

                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);
                var receiverOptions = new PartitionReceiverOptions { ConnectionOptions = new EventHubConnectionOptions { TransportType = transportType } };

                var partitionId = default(string);

                await using (var producer = new EventHubProducerClient(connectionString))
                {
                    partitionId = (await producer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                }

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partitionId, EventPosition.Earliest, connectionString, receiverOptions))
                {
                    var partitionProperties = await receiver.GetPartitionPropertiesAsync(cancellationSource.Token);

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    Assert.That(partitionProperties, Is.Not.Null, "A set of partition properties should have been returned.");
                    Assert.That(partitionProperties.Id, Is.EqualTo(partitionId), "The partition identifier should match.");
                    Assert.That(partitionProperties.EventHubName, Is.EqualTo(scope.EventHubName).Using((IEqualityComparer<string>)StringComparer.InvariantCultureIgnoreCase), "The Event Hub path should match.");
                    Assert.That(partitionProperties.BeginningSequenceNumber, Is.Not.EqualTo(default(long)), "The beginning sequence number should have been populated.");
                    Assert.That(partitionProperties.LastEnqueuedSequenceNumber, Is.Not.EqualTo(default(long)), "The last sequence number should have been populated.");
                    Assert.That(partitionProperties.LastEnqueuedOffset, Is.Not.EqualTo(default(long)), "The last offset should have been populated.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task PartitionReceiverCannotRetrievePartitionPropertiesWhenConnectionIsClosed()
        {
            var partitionCount = 1;

            await using (EventHubScope scope = await EventHubScope.CreateAsync(partitionCount))
            {
                var cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));

                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);
                var connection = new EventHubConnection(connectionString);

                var partitionId = default(string);

                await using (var producer = new EventHubProducerClient(connection))
                {
                    partitionId = (await producer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                }

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partitionId, EventPosition.Earliest, connection))
                {
                    Assert.That(async () => await receiver.GetPartitionPropertiesAsync(cancellationSource.Token), Throws.Nothing);

                    await connection.CloseAsync(cancellationSource.Token);

                    Assert.That(async () => await receiver.GetPartitionPropertiesAsync(cancellationSource.Token), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                }
            }
        }
    }
}
