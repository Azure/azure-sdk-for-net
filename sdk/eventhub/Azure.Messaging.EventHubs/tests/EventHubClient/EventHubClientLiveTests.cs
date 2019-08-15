// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
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
    ///   These tests have a dependency on live Azure services and may
    ///   incur costs for the associated Azure subscription.
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
                        $"{ clientOptions.TransportType.GetUriScheme() }://{ connectionProperties.Endpoint.Host }/{ connectionProperties.EventHubName }".ToLowerInvariant(),
                        connectionProperties.SharedAccessKeyName,
                        connectionProperties.SharedAccessKey,
                        TimeSpan.FromHours(4)
                    )
                );

                await using (var client = new EventHubClient(connectionProperties.Endpoint.Host, connectionProperties.EventHubName, credential))
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
        [TestCase(TransportType.AmqpTcp)]
        [TestCase(TransportType.AmqpWebSockets)]
        public async Task ClientCanRetrieveProperties(TransportType transportType)
        {
            var partitionCount = 4;

            await using (var scope = await EventHubScope.CreateAsync(partitionCount))
            {
                var connectionString = TestEnvironment.EventHubsConnectionString;

                await using (var client = new EventHubClient(connectionString, scope.EventHubName, new EventHubClientOptions { TransportType = transportType }))
                {
                    var properties = await client.GetPropertiesAsync();

                    Assert.That(properties, Is.Not.Null, "A set of properties should have been returned.");
                    Assert.That(properties.Name, Is.EqualTo(scope.EventHubName), "The property Event Hub name should match the scope.");
                    Assert.That(properties.PartitionIds.Length, Is.EqualTo(partitionCount), "The properties should have the requested number of partitions.");
                    Assert.That(properties.CreatedAt, Is.EqualTo(DateTimeOffset.UtcNow).Within(TimeSpan.FromSeconds(10)), "The Event Hub should have been created just about now.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        [TestCase(TransportType.AmqpTcp)]
        [TestCase(TransportType.AmqpWebSockets)]
        public async Task ClientCanRetrievePartitionProperties(TransportType transportType)
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
                        $"{ clientOptions.TransportType.GetUriScheme() }://{ connectionProperties.Endpoint.Host }/{ connectionProperties.EventHubName }".ToLowerInvariant(),
                        connectionProperties.SharedAccessKeyName,
                        connectionProperties.SharedAccessKey,
                        TimeSpan.FromHours(4)
                    )
                );

                await using (var client = new EventHubClient(connectionProperties.Endpoint.Host, connectionProperties.EventHubName, credential, new EventHubClientOptions { TransportType = transportType }))
                {
                    var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(20));
                    var properties = await client.GetPropertiesAsync();
                    var partition = properties.PartitionIds.First();
                    var partitionProperties = await client.GetPartitionPropertiesAsync(partition, cancellation.Token);

                    Assert.That(partitionProperties, Is.Not.Null, "A set of partition properties should have been returned.");
                    Assert.That(partitionProperties.Id, Is.EqualTo(partition), "The partition identifier should match.");
                    Assert.That(partitionProperties.EventHubName, Is.EqualTo(connectionProperties.EventHubName).Using((IEqualityComparer<string>)StringComparer.InvariantCultureIgnoreCase), "The Event Hub path should match.");
                    Assert.That(partitionProperties.BeginningSequenceNumber, Is.Not.EqualTo(default(Int64)), "The beginning sequence number should have been populated.");
                    Assert.That(partitionProperties.LastEnqueuedSequenceNumber, Is.Not.EqualTo(default(Int64)), "The last sequence number should have been populated.");
                    Assert.That(partitionProperties.LastEnqueuedOffset, Is.Not.EqualTo(default(Int64)), "The last offset should have been populated.");
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
            await using (var scope = await EventHubScope.CreateAsync(4))
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

                    await Task.Delay(TimeSpan.FromSeconds(5));

                    Assert.That(async () => await client.GetPartitionIdsAsync(), Throws.TypeOf<ObjectDisposedException>());
                    Assert.That(async () => await client.GetPropertiesAsync(), Throws.TypeOf<ObjectDisposedException>());
                    Assert.That(async () => await client.GetPartitionPropertiesAsync(partition), Throws.TypeOf<ObjectDisposedException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        [TestCase("XYZ")]
        [TestCase("-1")]
        [TestCase("1000")]
        [TestCase("-")]
        public async Task ClientCannotRetrievePartitionPropertiesWhenPartitionIdIsInvalid(string invalidPartition)
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    Assert.That(async () => await client.GetPartitionPropertiesAsync(invalidPartition), Throws.TypeOf<ArgumentOutOfRangeException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ClientCannotRetrieveMetadataWhenProxyIsInvalid()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);
                var clientOptions = new EventHubClientOptions
                {
                    Proxy = new WebProxy("http://1.2.3.4:9999"),
                    TransportType = TransportType.AmqpWebSockets,
                    RetryOptions = new RetryOptions { TryTimeout = TimeSpan.FromMinutes(2) }
                };

                await using (var client = new EventHubClient(connectionString))
                await using (var invalidProxyClient = new EventHubClient(connectionString, clientOptions))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    Assert.That(async () => await invalidProxyClient.GetPartitionIdsAsync(), Throws.InstanceOf<WebSocketException>().Or.InstanceOf<TimeoutException>());
                    Assert.That(async () => await invalidProxyClient.GetPropertiesAsync(), Throws.InstanceOf<WebSocketException>().Or.InstanceOf<TimeoutException>());
                    Assert.That(async () => await invalidProxyClient.GetPartitionPropertiesAsync(partition), Throws.InstanceOf<WebSocketException>().Or.InstanceOf<TimeoutException>());
                }
            }
        }
    }
}
