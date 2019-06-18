// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of live tests for the <see cref="EventHubClient" />
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
    public class EventHubClientLiveTests
    {
        /// <summary>
        ///   Verifies that the <see cref="EventHubClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ClientCanConnectToEventHubsUsingFullConnectionString()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    Assert.That(() => client.GetPropertiesAsync(), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ClientCanConnectToEventHubsUsingConnectionStringAndEventHub()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.EventHubsConnectionString;

                await using (var client = new EventHubClient(connectionString, scope.EventHubName))
                {
                    Assert.That(() => client.GetPropertiesAsync(), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ClientCanConnectToEventHubsUsingSharedKeyCredential()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);
                var properties = ConnectionStringParser.Parse(connectionString);
                var credential = new EventHubSharedKeyCredential(properties.SharedAccessKeyName, properties.SharedAccessKey);

                await using (var client = new EventHubClient(properties.Endpoint.Host, scope.EventHubName, credential))
                {
                    Assert.That(() => client.GetPropertiesAsync(), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ClientCanConnectToEventHubsUsingArguments()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var clientOptions = new EventHubClientOptions();
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);
                var connectionProperties = ConnectionStringParser.Parse(connectionString);

                var credential = new SharedAccessSignatureCredential
                (
                    new SharedAccessSignature
                    (
                        $"{ clientOptions.TransportType.GetUriScheme() }://{ connectionProperties.Endpoint.Host }/{ connectionProperties.EventHubPath }".ToLowerInvariant(),
                        connectionProperties.SharedAccessKeyName,
                        connectionProperties.SharedAccessKey,
                        TimeSpan.FromHours(4)
                    )
                );

                await using (var client = new EventHubClient(connectionProperties.Endpoint.Host, connectionProperties.EventHubPath, credential))
                {
                    Assert.That(() => client.GetPropertiesAsync(), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ClientCanRetrieveProperties()
        {
            var partitionCount = 4;

            await using (var scope = await EventHubScope.CreateAsync(partitionCount))
            {
                var connectionString = TestEnvironment.EventHubsConnectionString;

                await using (var client = new EventHubClient(connectionString, scope.EventHubName))
                {
                    var properties = await client.GetPropertiesAsync();

                    Assert.That(properties, Is.Not.Null, "A set of properties should have been returned.");
                    Assert.That(properties.Path, Is.EqualTo(scope.EventHubName), "The property Event Hub name should match the scope.");
                    Assert.That(properties.PartitionIds.Length, Is.EqualTo(partitionCount), "The properties should have the requested number of partitions.");
                    Assert.That(properties.CreatedAtUtc, Is.EqualTo(DateTime.UtcNow).Within(TimeSpan.FromSeconds(5)), "The Event Hub should have been created just about now.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ClientCanRetrievePartitionProperties()
        {
            var partitionCount = 4;

            await using (var scope = await EventHubScope.CreateAsync(partitionCount))
            {
                var clientOptions = new EventHubClientOptions();
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);
                var connectionProperties = ConnectionStringParser.Parse(connectionString);

                var credential = new SharedAccessSignatureCredential
                (
                    new SharedAccessSignature
                    (
                        $"{ clientOptions.TransportType.GetUriScheme() }://{ connectionProperties.Endpoint.Host }/{ connectionProperties.EventHubPath }".ToLowerInvariant(),
                        connectionProperties.SharedAccessKeyName,
                        connectionProperties.SharedAccessKey,
                        TimeSpan.FromHours(4)
                    )
                );

                await using (var client = new EventHubClient(connectionProperties.Endpoint.Host, connectionProperties.EventHubPath, credential))
                {
                    var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(20));
                    var properties = await client.GetPropertiesAsync();
                    var partition = properties.PartitionIds.First();
                    var partitionProperties = await client.GetPartitionPropertiesAsync(partition, cancellation.Token);

                    Assert.That(partitionProperties, Is.Not.Null, "A set of partition properties should have been returned.");
                    Assert.That(partitionProperties.Id, Is.EqualTo(partition), "The partition identifier should match.");
                    Assert.That(partitionProperties.EventHubPath, Is.EqualTo(connectionProperties.EventHubPath).Using((IEqualityComparer<string>)StringComparer.InvariantCultureIgnoreCase), "The Event Hub path should match.");
                    Assert.That(partitionProperties.BeginningSequenceNumber, Is.Not.EqualTo(default(Int64)), "The beginning sequence number should have been populated.");
                    Assert.That(partitionProperties.LastEnqueuedSequenceNumber, Is.Not.EqualTo(default(Int64)), "The last sequance number should have been populated.");
                    Assert.That(partitionProperties.LastEnqueuedOffset, Is.Not.Null.Or.Empty, "The last offset should have been populated.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ClientPartitionIdsMatchPartitionProperties()
        {
            var partitionCount = 4;

            await using (var scope = await EventHubScope.CreateAsync(partitionCount))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var properties = await client.GetPropertiesAsync();
                    var partitions = await client.GetPartitionIdsAsync();

                    Assert.That(properties, Is.Not.Null, "A set of properties should have been returned.");
                    Assert.That(properties.PartitionIds, Is.Not.Null, "A set of partition identifiers for the properties should have been returned.");
                    Assert.That(partitions, Is.Not.Null, "A set of partition identifiers should have been returned.");
                    Assert.That(partitions, Is.EquivalentTo(properties.PartitionIds), "The partition identifiers returned directly should match those returned with properties.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ClientCanRetrievePropertiesWithAmqpWebSocketsConnection()
        {
            var partitionCount = 4;

            await using (var scope = await EventHubScope.CreateAsync(partitionCount))
            {
                var connectionString = TestEnvironment.EventHubsConnectionString;

                await using (var client = new EventHubClient(connectionString, scope.EventHubName, new EventHubClientOptions { TransportType = TransportType.AmqpWebSockets }))
                {
                    var properties = await client.GetPropertiesAsync();

                    Assert.That(properties, Is.Not.Null, "A set of properties should have been returned.");
                    Assert.That(properties.Path, Is.EqualTo(scope.EventHubName), "The property Event Hub name should match the scope.");
                    Assert.That(properties.PartitionIds.Length, Is.EqualTo(partitionCount), "The properties should have the requested number of partitions.");
                    Assert.That(properties.CreatedAtUtc, Is.EqualTo(DateTime.UtcNow).Within(TimeSpan.FromSeconds(5)), "The Event Hub should have been created just about now.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ClientCanRetrievePartitionPropertiesWithAmqpWebSocketsConnection()
        {
            var partitionCount = 4;

            await using (var scope = await EventHubScope.CreateAsync(partitionCount))
            {
                var clientOptions = new EventHubClientOptions { TransportType = TransportType.AmqpWebSockets };
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);
                var connectionProperties = ConnectionStringParser.Parse(connectionString);

                var credential = new SharedAccessSignatureCredential
                (
                    new SharedAccessSignature
                    (
                        $"{ clientOptions.TransportType.GetUriScheme() }://{ connectionProperties.Endpoint.Host }/{ connectionProperties.EventHubPath }".ToLowerInvariant(),
                        connectionProperties.SharedAccessKeyName,
                        connectionProperties.SharedAccessKey,
                        TimeSpan.FromHours(4)
                    )
                );

                await using (var client = new EventHubClient(connectionProperties.Endpoint.Host, connectionProperties.EventHubPath, credential, clientOptions))
                {
                    var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(20));
                    var properties = await client.GetPropertiesAsync();
                    var partition = properties.PartitionIds.First();
                    var partitionProperties = await client.GetPartitionPropertiesAsync(partition, cancellation.Token);

                    Assert.That(partitionProperties, Is.Not.Null, "A set of partition properties should have been returned.");
                    Assert.That(partitionProperties.Id, Is.EqualTo(partition), "The partition identifier should match.");
                    Assert.That(partitionProperties.EventHubPath, Is.EqualTo(connectionProperties.EventHubPath).Using((IEqualityComparer<string>)StringComparer.InvariantCultureIgnoreCase), "The Event Hub path should match.");
                    Assert.That(partitionProperties.BeginningSequenceNumber, Is.Not.EqualTo(default(Int64)), "The beginning sequence number should have been populated.");
                    Assert.That(partitionProperties.LastEnqueuedSequenceNumber, Is.Not.EqualTo(default(Int64)), "The last sequance number should have been populated.");
                    Assert.That(partitionProperties.LastEnqueuedOffset, Is.Not.Null.Or.Empty, "The last offset should have been populated.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ClientCanSendWithAmqpWebSocketsConnection()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString, new EventHubClientOptions { TransportType = TransportType.AmqpWebSockets }))
                await using (var producer = client.CreateProducer())
                {
                    var events = new[] { new EventData(Encoding.UTF8.GetBytes("Awesome content")) };
                    Assert.That(async () => await producer.SendAsync(events), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ClientCanReceiveWithAmqpWebSocketsConnection()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString, new EventHubClientOptions { TransportType = TransportType.AmqpWebSockets }))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    await using (var consumer = client.CreateConsumer(partition, EventPosition.Latest))
                    {
                        Assert.That(async () => await consumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
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
        [TestCase(true)]
        [TestCase(false)]
        public async Task ClientCannotRetrieveMetadataWhenClosed(bool sync)
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    Assert.That(async () => await client.GetPropertiesAsync(), Throws.Nothing);
                    Assert.That(async () => await client.GetPartitionPropertiesAsync(partition), Throws.Nothing);

                    if (sync)
                    {
                        client.Close();
                    }
                    else
                    {
                        await client.CloseAsync();
                    }

                    Assert.ThrowsAsync<OperationCanceledException>(async () => await client.GetPartitionIdsAsync());
                    Assert.ThrowsAsync<ObjectDisposedException>(async () => await client.GetPropertiesAsync());
                    Assert.ThrowsAsync<ObjectDisposedException>(async () => await client.GetPartitionPropertiesAsync(partition));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ClientCannotRetrievePartitionPropertiesWhenPartitionIdIsInvalid()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    // Some invalid partition values. These will fail on the service side.
                    var invalidPartitions = new[]
                    {
                        "XYZ",
                        "-1",
                        "1000",
                        "-"
                    };

                    foreach (var invalidPartition in invalidPartitions)
                    {
                        Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await client.GetPartitionPropertiesAsync(invalidPartition));
                    }
                }
            }
        }
    }
}
