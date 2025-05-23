// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Amqp;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.Azure.Amqp.Transport;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="AmqpConnectionScope" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class AmqpConnectionScopeTests
    {
        /// <summary>
        ///   The set test cases for partially populated partition publishing options.
        /// </summary>
        ///
        public static IEnumerable<object[]> PartitionPublishingPartialOptionsTestCases
        {
            get
            {
                yield return new object[] { new PartitionPublishingOptions { ProducerGroupId = 123 } };
                yield return new object[] { new PartitionPublishingOptions { OwnerLevel = 123 } };
                yield return new object[] { new PartitionPublishingOptions { StartingSequenceNumber = 123 } };
                yield return new object[] { new PartitionPublishingOptions { ProducerGroupId = 123, OwnerLevel = 789 } };
                yield return new object[] { new PartitionPublishingOptions { ProducerGroupId = 123, StartingSequenceNumber = 789 } };
                yield return new object[] { new PartitionPublishingOptions { StartingSequenceNumber = 123, OwnerLevel = 789 } };
            }
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheServiceEndpoint()
        {
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            Assert.That(() => new AmqpConnectionScope(null, new Uri("https://some.place.com"), "hub", credential.Object, EventHubsTransportType.AmqpTcp, null, TimeSpan.FromSeconds(60)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheConnectionEndpoint()
        {
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            Assert.That(() => new AmqpConnectionScope(new Uri("https://some.place.com"), null, "hub", credential.Object, EventHubsTransportType.AmqpTcp, null, TimeSpan.FromSeconds(60)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheEventHubName()
        {
            var endpoint = new Uri("amqp://some.place.com");
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            Assert.That(() => new AmqpConnectionScope(endpoint, endpoint, null, credential.Object, EventHubsTransportType.AmqpWebSockets, Mock.Of<IWebProxy>(), TimeSpan.FromSeconds(60)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheCredential()
        {
            var endpoint = new Uri("amqp://some.place.com");
            Assert.That(() => new AmqpConnectionScope(endpoint, endpoint, "hub", null, EventHubsTransportType.AmqpWebSockets, null, TimeSpan.FromSeconds(60)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheTransport()
        {
            var invalidTransport = (EventHubsTransportType)(-2);
            var endpoint = new Uri("amqp://some.place.com");
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            Assert.That(() => new AmqpConnectionScope(endpoint, endpoint, "hun", credential.Object, invalidTransport, Mock.Of<IWebProxy>(), TimeSpan.FromSeconds(60)), Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheIdleTimeout()
        {
            var endpoint = new Uri("amqp://some.place.com");
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            Assert.That(() => new AmqpConnectionScope(endpoint, endpoint, "hub", credential.Object, EventHubsTransportType.AmqpTcp, null, TimeSpan.FromMilliseconds(-1)), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public async Task ConstructorInitializesTheConnectionFactory()
        {
            RemoteCertificateValidationCallback certCallback = (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) => true;

            var serviceEndpoint = new Uri("amqp://test.service.gov");
            var connectionEndpoint = new Uri("amqp://custom.thing.com");
            var eventHub = "myHub";
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var sendBuffer = 100;
            var receiveBuffer = 200;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());

            var mockScope = new Mock<AmqpConnectionScope>(serviceEndpoint, connectionEndpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier, sendBuffer, receiveBuffer, certCallback)
            {
                CallBase = true
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == serviceEndpoint),
                    ItExpr.Is<Uri>(value => value == connectionEndpoint),
                    ItExpr.Is<EventHubsTransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.Is<int>(value => value == sendBuffer),
                    ItExpr.Is<int>(value => value == receiveBuffer),
                    ItExpr.Is<RemoteCertificateValidationCallback>(value => ReferenceEquals(value, certCallback)),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection))
                .Verifiable();

            AmqpConnection connection = await GetActiveConnection(mockScope.Object).GetOrCreateAsync(TimeSpan.FromDays(1));
            Assert.That(connection, Is.SameAs(mockConnection), "The connection instance should have been returned");

            mockScope.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenManagementLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ConnectionsAreConfiguredCorrectly()
        {
            RemoteCertificateValidationCallback certCallback = (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) => true;

            var serviceEndpoint = new Uri("amqp://test.service.gov");
            var connectionEndpoint = new Uri("amqp://test.other.ext");
            var eventHub = "myHub";
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var sendBuffer = 100;
            var receiveBufer = 200;
            var cancellationSource = new CancellationTokenSource();
            var mockProxy = Mock.Of<IWebProxy>();
            var idleTimeout = TimeSpan.FromSeconds(30);
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());
            var mockLink = new RequestResponseAmqpLink("test", "test", mockSession, "test");
            var mockScope = new MockConnectionScope(serviceEndpoint, connectionEndpoint, eventHub, credential.Object, transport, mockProxy, idleTimeout, identifier, sendBuffer, receiveBufer, certCallback);

            var expected = new ConnectionConfiguration
            {
               serviceEndpoint = serviceEndpoint,
               connectionEndpoint = connectionEndpoint,
               transportType = transport,
               proxy = mockProxy,
               scopeIdentifier = identifier,
               sendBufferSizeBytes = sendBuffer,
               receiveBufferSizeBytes = receiveBufer,
               certificateValidationCallback = certCallback
            };

            await mockScope.OpenManagementLinkAsync(TimeSpan.FromDays(1), TimeSpan.FromDays(1), cancellationSource.Token);
            Assert.That(mockScope.LastConnectionConfiguration.IsEquivalentTo(expected), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenManagementLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void OpenManagementLinkAsyncRespectsTokenCancellation()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);

            using var scope = new AmqpConnectionScope(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier);

            var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => scope.OpenManagementLinkAsync(TimeSpan.FromDays(1), TimeSpan.FromDays(1), cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenManagementLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void OpenManagementLinkAsyncRespectsDisposal()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);

            var scope = new AmqpConnectionScope(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier);
            scope.Dispose();

            Assert.That(() => scope.OpenManagementLinkAsync(TimeSpan.FromDays(1), TimeSpan.FromDays(1), CancellationToken.None), Throws.InstanceOf<ObjectDisposedException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenManagementLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OpenManagementLinkAsyncRequestsTheLink()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);
            var cancellationSource = new CancellationTokenSource();
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());
            var mockLink = new RequestResponseAmqpLink("test", "test", mockSession, "test");

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier, 8192, 8192, default)
            {
                CallBase = true
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<EventHubsTransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<RemoteCertificateValidationCallback>(),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection))
                .Verifiable();

            mockScope
                .Protected()
                .Setup<Task<RequestResponseAmqpLink>>("CreateManagementLinkAsync",
                    ItExpr.Is<AmqpConnection>(value => value == mockConnection),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.Is<CancellationToken>(value => value == cancellationSource.Token))
                .Returns(Task.FromResult(mockLink))
                .Verifiable();

            mockScope
                .Protected()
                .Setup<Task>("OpenAmqpObjectAsync",
                    ItExpr.IsAny<AmqpObject>(),
                    ItExpr.IsAny<TimeSpan?>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask)
                .Verifiable();

            var link = await mockScope.Object.OpenManagementLinkAsync(TimeSpan.FromDays(1), TimeSpan.FromDays(1), cancellationSource.Token);
            Assert.That(link, Is.EqualTo(mockLink), "The mock return was incorrect");

            mockScope.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenManagementLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OpenManagementLinkAsyncManagesActiveLinks()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);
            var cancellationSource = new CancellationTokenSource();
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier, 8192, 8192, default)
            {
                CallBase = true
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<EventHubsTransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<RemoteCertificateValidationCallback>(),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection));

            mockScope
                 .Protected()
                 .Setup<Task>("OpenAmqpObjectAsync",
                     ItExpr.IsAny<AmqpObject>(),
                     ItExpr.IsAny<TimeSpan?>(),
                     ItExpr.IsAny<CancellationToken>())
                 .Returns(Task.CompletedTask);

            var activeLinks = GetActiveLinks(mockScope.Object);
            Assert.That(activeLinks, Is.Not.Null, "The set of active links was null.");
            Assert.That(activeLinks.Count, Is.Zero, "There should be no active links when none have been created.");

            var link = await mockScope.Object.OpenManagementLinkAsync(TimeSpan.FromDays(1), TimeSpan.FromDays(1), cancellationSource.Token);
            Assert.That(link, Is.Not.Null, "The link produced was null");

            Assert.That(activeLinks.Count, Is.EqualTo(1), "There should be an active link being tracked.");
            Assert.That(activeLinks.ContainsKey(link), Is.True, "The management link should be tracked as active.");

            activeLinks.TryGetValue(link, out var refreshTimer);
            Assert.That(refreshTimer, Is.Null, "The link should have a null timer since it has no authorization refresh needs.");

            link.SafeClose();
            Assert.That(activeLinks.Count, Is.Zero, "Closing the link should stop tracking it as active.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenConsumerLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void OpenConsumerLinkAsyncValidatesTheConsumerGroup(string consumerGroup)
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var partitionId = "0";
            var position = EventPosition.Latest;
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);

            using var scope = new AmqpConnectionScope(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier);
            Assert.That(() => scope.OpenConsumerLinkAsync(consumerGroup, partitionId, position, TimeSpan.FromDays(1), TimeSpan.FromDays(1), 0, null, null, false, identifier, CancellationToken.None), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenConsumerLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void OpenConsumerLinkAsyncValidatesThePartitionId(string partitionId)
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var consumerGroup = "$Default";
            var position = EventPosition.Latest;
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);

            using var scope = new AmqpConnectionScope(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier);
            Assert.That(() => scope.OpenConsumerLinkAsync(consumerGroup, partitionId, position, TimeSpan.FromDays(1), TimeSpan.FromDays(1), 0, null, null, false, identifier, CancellationToken.None), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenConsumerLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void OpenConsumerLinkAsyncRespectsTokenCancellation()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var consumerGroup = "group";
            var partitionId = "0";
            var position = EventPosition.Latest;
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);

            using var scope = new AmqpConnectionScope(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier);

            var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => scope.OpenConsumerLinkAsync(consumerGroup, partitionId, position, TimeSpan.FromDays(1), TimeSpan.FromDays(1), 0, null, null, false, null, cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenConsumerLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void OpenConsumerLinkAsyncRespectsDisposal()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var consumerGroup = "group";
            var partitionId = "0";
            var position = EventPosition.Latest;
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);

            var scope = new AmqpConnectionScope(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier);
            scope.Dispose();

            Assert.That(() => scope.OpenConsumerLinkAsync(consumerGroup, partitionId, position, TimeSpan.FromDays(1), TimeSpan.FromDays(1), 0, null, null, false, null, CancellationToken.None), Throws.InstanceOf<ObjectDisposedException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenConsumerLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OpenConsumerLinkAsyncRequestsTheLink()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var consumerGroup = "group";
            var partitionId = "0";
            var ownerLevel = 95;
            var prefetchCount = 300U;
            var prefetchSizeInBytes = 4242L;
            var trackLastEvent = false;
            var position = EventPosition.Latest;
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var scopeIdentifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);
            var consumerIdentifier = "otherIden3fid!";
            var cancellationSource = new CancellationTokenSource();
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());
            var mockLink = new ReceivingAmqpLink(new AmqpLinkSettings());

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, scopeIdentifier, 8192, 8192, default)
            {
                CallBase = true
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<EventHubsTransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<RemoteCertificateValidationCallback>(),
                    ItExpr.Is<string>(value => value == scopeIdentifier),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection))
                .Verifiable();

            mockScope
                .Protected()
                .Setup<Task<ReceivingAmqpLink>>("CreateReceivingLinkAsync",
                    ItExpr.Is<AmqpConnection>(value => value == mockConnection),
                    ItExpr.Is<Uri>(value => value.AbsoluteUri.StartsWith(endpoint.AbsoluteUri)),
                    ItExpr.Is<EventPosition>(value => value == position),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.Is<uint>(value => value == prefetchCount),
                    ItExpr.Is<long?>(value => value == prefetchSizeInBytes),
                    ItExpr.Is<long?>(value => value == ownerLevel),
                    ItExpr.Is<bool>(value => value == trackLastEvent),
                    ItExpr.Is<string>(value => value == consumerIdentifier),
                    ItExpr.Is<CancellationToken>(value => value == cancellationSource.Token))
                .Returns(Task.FromResult(mockLink))
                .Verifiable();

            mockScope
                .Protected()
                .Setup<Task>("OpenAmqpObjectAsync",
                    ItExpr.IsAny<AmqpObject>(),
                    ItExpr.IsAny<TimeSpan?>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask)
                .Verifiable();

            var link = await mockScope.Object.OpenConsumerLinkAsync(consumerGroup, partitionId, position, TimeSpan.FromDays(1), TimeSpan.FromDays(1), prefetchCount, prefetchSizeInBytes, ownerLevel, trackLastEvent, consumerIdentifier, cancellationSource.Token);
            Assert.That(link, Is.EqualTo(mockLink), "The mock return was incorrect");

            mockScope.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenConsumerLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OpenConsumerLinkAsyncConfiguresTheLink()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var consumerGroup = "group";
            var partitionId = "0";
            var ownerLevel = 459;
            var prefetchCount = 697U;
            var prefetchSizeInBytes = 12342L;
            var trackLastEvent = true;
            var position = EventPosition.Latest;
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);
            var cancellationSource = new CancellationTokenSource();
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier, 8192, 8192, default)
            {
                CallBase = true
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<EventHubsTransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<RemoteCertificateValidationCallback>(),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection));

            mockScope
                .Protected()
                .Setup<Task<DateTime>>("RequestAuthorizationUsingCbsAsync",
                    ItExpr.Is<AmqpConnection>(value => value == mockConnection),
                    ItExpr.IsAny<CbsTokenProvider>(),
                    ItExpr.Is<Uri>(value => value.AbsoluteUri.StartsWith(endpoint.AbsoluteUri)),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.Is<string[]>(value => value.SingleOrDefault() == EventHubsClaim.Listen),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(DateTime.UtcNow.AddDays(1)));

            mockScope
                .Protected()
                .Setup<Task>("OpenAmqpObjectAsync",
                    ItExpr.IsAny<AmqpObject>(),
                    ItExpr.IsAny<TimeSpan?>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask);

            var link = await mockScope.Object.OpenConsumerLinkAsync(consumerGroup, partitionId, position, TimeSpan.FromDays(1), TimeSpan.FromDays(1), prefetchCount, prefetchSizeInBytes, ownerLevel, trackLastEvent, identifier, cancellationSource.Token);
            Assert.That(link, Is.Not.Null, "The link produced was null");

            var linkSource = (Source)link.Settings.Source;
            Assert.That(linkSource.FilterSet.Any(item => item.Key.Key.ToString() == AmqpFilter.ConsumerFilterName), Is.True, "There should have been a producer filter set.");
            Assert.That(linkSource.Address.ToString(), Contains.Substring($"/{ partitionId }"), "The partition identifier should have been part of the link address.");
            Assert.That(linkSource.Address.ToString(), Contains.Substring($"/{ consumerGroup }"), "The consumer group should have been part of the link address.");

            Assert.That(link.Settings.TotalLinkCredit, Is.EqualTo(prefetchCount), "The prefetch count should have been used to set the credits.");
            Assert.That(link.GetSettingPropertyOrDefault<long>(AmqpProperty.ConsumerOwnerLevel, -1), Is.EqualTo(ownerLevel), "The owner level should have been used.");

            Assert.That(link.Settings.Properties.Any(item => item.Key.Key.ToString() == AmqpProperty.EntityType.ToString()), Is.True, "There should be an entity type specified.");
            Assert.That(link.Settings.Properties.Any(item => item.Key.Key.ToString() == AmqpProperty.ConsumerIdentifier.ToString()), Is.True, "There should be a consumer identifier specified.");
            Assert.That(link.Settings.Properties[AmqpProperty.ConsumerIdentifier], Is.EqualTo(identifier), "The consumer identifier should match.");

            Assert.That(link.Settings.DesiredCapabilities, Is.Not.Null, "There should have been a set of desired capabilities created.");
            Assert.That(link.Settings.DesiredCapabilities.Contains(AmqpProperty.TrackLastEnqueuedEventProperties), Is.True, "Last event tracking should be requested.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenConsumerLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OpenConsumerLinkAsyncRespectsTheOwnerLevelOption()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var consumerGroup = "group";
            var partitionId = "0";
            var ownerLevel = default(long?);
            var prefetchCount = 697U;
            var prefetchSizeInBytes = 12342L;
            var trackLastEvent = false;
            var position = EventPosition.Latest;
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);
            var cancellationSource = new CancellationTokenSource();
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier, 8192, 8192, default)
            {
                CallBase = true
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<EventHubsTransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<RemoteCertificateValidationCallback>(),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection));

            mockScope
                .Protected()
                .Setup<Task<DateTime>>("RequestAuthorizationUsingCbsAsync",
                    ItExpr.Is<AmqpConnection>(value => value == mockConnection),
                    ItExpr.IsAny<CbsTokenProvider>(),
                    ItExpr.Is<Uri>(value => value.AbsoluteUri.StartsWith(endpoint.AbsoluteUri)),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.Is<string[]>(value => value.SingleOrDefault() == EventHubsClaim.Listen),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(DateTime.UtcNow.AddDays(1)));

            mockScope
                .Protected()
                .Setup<Task>("OpenAmqpObjectAsync",
                    ItExpr.IsAny<AmqpObject>(),
                    ItExpr.IsAny<TimeSpan?>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask);

            var link = await mockScope.Object.OpenConsumerLinkAsync(consumerGroup, partitionId, position, TimeSpan.FromDays(1), TimeSpan.FromDays(1), prefetchCount, prefetchSizeInBytes, ownerLevel, trackLastEvent, identifier, cancellationSource.Token);
            Assert.That(link, Is.Not.Null, "The link produced was null");
            Assert.That(link.GetSettingPropertyOrDefault<long>(AmqpProperty.ConsumerOwnerLevel, long.MinValue), Is.EqualTo(long.MinValue), "The owner level should have been used.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenConsumerLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OpenConsumerLinkAsyncRespectsTheTrackLastEventOption()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var consumerGroup = "group";
            var partitionId = "0";
            var ownerLevel = 9987;
            var prefetchCount = 697U;
            var prefetchSizeInBytes = 12342L;
            var trackLastEvent = false;
            var position = EventPosition.Latest;
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);
            var cancellationSource = new CancellationTokenSource();
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier, 8192, 8192, default)
            {
                CallBase = true
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<EventHubsTransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<RemoteCertificateValidationCallback>(),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection));

            mockScope
                .Protected()
                .Setup<Task<DateTime>>("RequestAuthorizationUsingCbsAsync",
                    ItExpr.Is<AmqpConnection>(value => value == mockConnection),
                    ItExpr.IsAny<CbsTokenProvider>(),
                    ItExpr.Is<Uri>(value => value.AbsoluteUri.StartsWith(endpoint.AbsoluteUri)),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.Is<string[]>(value => value.SingleOrDefault() == EventHubsClaim.Listen),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(DateTime.UtcNow.AddDays(1)));

            mockScope
                .Protected()
                .Setup<Task>("OpenAmqpObjectAsync",
                    ItExpr.IsAny<AmqpObject>(),
                    ItExpr.IsAny<TimeSpan?>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask);

            var link = await mockScope.Object.OpenConsumerLinkAsync(consumerGroup, partitionId, position, TimeSpan.FromDays(1), TimeSpan.FromDays(1), prefetchCount, prefetchSizeInBytes, ownerLevel, trackLastEvent, identifier, cancellationSource.Token);
            Assert.That(link, Is.Not.Null, "The link produced was null");
            Assert.That(link.Settings.DesiredCapabilities.Contains(AmqpProperty.GeoReplication), Is.True, "Geo replication should always be requested.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenConsumerLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OpenConsumerLinkAsyncManagesActiveLinks()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var consumerGroup = "group";
            var partitionId = "0";
            var ownerLevel = 459;
            var prefetchCount = 697U;
            var prefetchSizeInBytes = 12342L;
            var trackLastEvent = false;
            var position = EventPosition.Latest;
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);
            var cancellationSource = new CancellationTokenSource();
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier, 8192, 8192, default)
            {
                CallBase = true
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<EventHubsTransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<RemoteCertificateValidationCallback>(),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection));

            mockScope
                .Protected()
                .Setup<Task<DateTime>>("RequestAuthorizationUsingCbsAsync",
                    ItExpr.Is<AmqpConnection>(value => value == mockConnection),
                    ItExpr.IsAny<CbsTokenProvider>(),
                    ItExpr.Is<Uri>(value => value.AbsoluteUri.StartsWith(endpoint.AbsoluteUri)),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.Is<string[]>(value => value.SingleOrDefault() == EventHubsClaim.Listen),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(DateTime.UtcNow.AddDays(1)));

            mockScope
                .Protected()
                .Setup<Task>("OpenAmqpObjectAsync",
                    ItExpr.IsAny<AmqpObject>(),
                    ItExpr.IsAny<TimeSpan?>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask);

            var activeLinks = GetActiveLinks(mockScope.Object);
            Assert.That(activeLinks, Is.Not.Null, "The set of active links was null.");
            Assert.That(activeLinks.Count, Is.Zero, "There should be no active links when none have been created.");

            var link = await mockScope.Object.OpenConsumerLinkAsync(consumerGroup, partitionId, position, TimeSpan.FromDays(1), TimeSpan.FromDays(1), prefetchCount, prefetchSizeInBytes, ownerLevel, trackLastEvent, identifier, cancellationSource.Token);
            Assert.That(link, Is.Not.Null, "The link produced was null");

            Assert.That(activeLinks.Count, Is.EqualTo(1), "There should be an active link being tracked.");
            Assert.That(activeLinks.ContainsKey(link), Is.True, "The consumer link should be tracked as active.");

            activeLinks.TryGetValue(link, out var refreshTimer);
            Assert.That(refreshTimer, Is.Not.Null, "The link should have a non-null timer.");

            link.SafeClose();
            Assert.That(activeLinks.Count, Is.Zero, "Closing the link should stop tracking it as active.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenConsumerLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OpenConsumerLinkAsyncConfiguresAuthorizationRefresh()
        {
            var timerCallbackInvoked = false;
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var consumerGroup = "group";
            var partitionId = "0";
            var position = EventPosition.Latest;
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);
            var cancellationSource = new CancellationTokenSource();
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier, 8192, 8192, default)
            {
                CallBase = true
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<EventHubsTransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<RemoteCertificateValidationCallback>(),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection));

            mockScope
                .Protected()
                .Setup<Task<DateTime>>("RequestAuthorizationUsingCbsAsync",
                    ItExpr.IsAny<AmqpConnection>(),
                    ItExpr.IsAny<CbsTokenProvider>(),
                    ItExpr.IsAny<Uri>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string[]>(),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(DateTime.UtcNow.AddDays(5)));

            mockScope
                .Protected()
                .Setup<TimerCallback>("CreateAuthorizationRefreshHandler",
                    ItExpr.IsAny<AmqpConnection>(),
                    ItExpr.IsAny<AmqpObject>(),
                    ItExpr.IsAny<CbsTokenProvider>(),
                    ItExpr.IsAny<Uri>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string[]>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<Func<Timer>>())
                .Returns(_ => timerCallbackInvoked = true);

            mockScope
                .Protected()
                .Setup<TimeSpan>("CalculateLinkAuthorizationRefreshInterval",
                    ItExpr.IsAny<DateTime>(),
                    ItExpr.IsAny<DateTime?>())
                .Returns(TimeSpan.Zero);

            mockScope
                .Protected()
                .Setup<Task>("OpenAmqpObjectAsync",
                    ItExpr.IsAny<AmqpObject>(),
                    ItExpr.IsAny<TimeSpan?>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask);

            var link = await mockScope.Object.OpenConsumerLinkAsync(consumerGroup, partitionId, position, TimeSpan.FromDays(1), TimeSpan.FromDays(1), 0, null, null, false, identifier, cancellationSource.Token);
            Assert.That(link, Is.Not.Null, "The link produced was null");

            var activeLinks = GetActiveLinks(mockScope.Object);
            Assert.That(activeLinks.ContainsKey(link), Is.True, "The consumer link should be tracked as active.");

            activeLinks.TryGetValue(link, out var refreshTimer);
            Assert.That(refreshTimer, Is.Not.Null, "The link should have a non-null timer.");

            // The timer be configured to fire immediately and set the flag.  Because the timer
            // runs in the background, there is a level of non-determinism in when that callback will execute.
            // Allow for a small number of delay and retries to account for it.

            var attemptCount = 0;
            var remainingAttempts = 10;

            while ((--remainingAttempts >= 0) && (!timerCallbackInvoked))
            {
                await Task.Delay(250 * ++attemptCount).ConfigureAwait(false);
            }

            Assert.That(timerCallbackInvoked, Is.True, "The timer should have been configured and running when the link was created.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenConsumerLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OpenConsumerLinkAsyncRefreshesAuthorization()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var consumerGroup = "group";
            var partitionId = "0";
            var position = EventPosition.Latest;
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);
            var cancellationSource = new CancellationTokenSource();
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier, 8192, 8192, default)
            {
                CallBase = true
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<EventHubsTransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<RemoteCertificateValidationCallback>(),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection));

            mockScope
                .Protected()
                .Setup<Task<DateTime>>("RequestAuthorizationUsingCbsAsync",
                    ItExpr.IsAny<AmqpConnection>(),
                    ItExpr.IsAny<CbsTokenProvider>(),
                    ItExpr.IsAny<Uri>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string[]>(),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(DateTime.UtcNow.AddDays(5)));

            mockScope
                .Protected()
                .Setup<Task>("OpenAmqpObjectAsync",
                    ItExpr.IsAny<AmqpObject>(),
                    ItExpr.IsAny<TimeSpan?>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask);

            var link = await mockScope.Object.OpenConsumerLinkAsync(consumerGroup, partitionId, position, TimeSpan.FromDays(1), TimeSpan.FromDays(1), 0, null, null, false, identifier, cancellationSource.Token);
            Assert.That(link, Is.Not.Null, "The link produced was null");

            var activeLinks = GetActiveLinks(mockScope.Object);
            Assert.That(activeLinks.ContainsKey(link), Is.True, "The consumer link should be tracked as active.");

            activeLinks.TryGetValue(link, out var refreshTimer);
            Assert.That(refreshTimer, Is.Not.Null, "The link should have a non-null timer.");

            // Verify that there was only a initial request for authorization.

            mockScope
                .Protected()
                .Verify("RequestAuthorizationUsingCbsAsync",
                    Times.Once(),
                    ItExpr.Is<AmqpConnection>(value => value == mockConnection),
                    ItExpr.IsAny<CbsTokenProvider>(),
                    ItExpr.Is<Uri>(value => value.AbsoluteUri.StartsWith(endpoint.AbsoluteUri)),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.Is<string[]>(value => value.SingleOrDefault() == EventHubsClaim.Listen),
                    ItExpr.IsAny<TimeSpan>());

            // Reset the timer so that it fires immediately and validate that authorization was
            // requested.  Since opening of the link requests an initial authorization and the expiration
            // was set way in the future, there should be exactly two calls.
            //
            // Because the timer runs in the background, there is a level of non-determinism in when that
            // callback will execute.  Allow for a small number of delay and retries to account for it.

            refreshTimer.Change(0, Timeout.Infinite);

            var attemptCount = 0;
            var remainingAttempts = 10;
            var success = false;

            while ((--remainingAttempts >= 0) && (!success))
            {
                try
                {
                    await Task.Delay(250 * ++attemptCount).ConfigureAwait(false);

                    mockScope
                        .Protected()
                        .Verify("RequestAuthorizationUsingCbsAsync",
                            Times.Exactly(2),
                            ItExpr.Is<AmqpConnection>(value => value == mockConnection),
                            ItExpr.IsAny<CbsTokenProvider>(),
                            ItExpr.Is<Uri>(value => value.AbsoluteUri.StartsWith(endpoint.AbsoluteUri)),
                            ItExpr.IsAny<string>(),
                            ItExpr.IsAny<string>(),
                            ItExpr.Is<string[]>(value => value.SingleOrDefault() == EventHubsClaim.Listen),
                            ItExpr.IsAny<TimeSpan>());

                    success = true;
                }
                catch when (remainingAttempts <= 0)
                {
                    throw;
                }
                catch
                {
                    // No action needed.
                }
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenProducerLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void OpenProducerLinkAsyncRespectsTokenCancellation()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var partitionId = "0";
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);

            using var scope = new AmqpConnectionScope(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier);

            var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => scope.OpenProducerLinkAsync(partitionId, TransportProducerFeatures.None, new PartitionPublishingOptions(), TimeSpan.FromDays(1), TimeSpan.FromDays(1), identifier, cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenProducerLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void OpenProducerLinkAsyncRespectsDisposal()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);

            var scope = new AmqpConnectionScope(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier);
            scope.Dispose();

            Assert.That(() => scope.OpenProducerLinkAsync(null, TransportProducerFeatures.None, new PartitionPublishingOptions(), TimeSpan.FromDays(1), TimeSpan.FromDays(1), identifier, CancellationToken.None), Throws.InstanceOf<ObjectDisposedException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenProducerLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OpenProducerLinkAsyncRequestsTheLink()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var partitionId = "0";
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var scopeIdentifier = "customIdentIFIER";
            var producerIdentifier = "producerId23!";
            var idleTimeout = TimeSpan.FromSeconds(30);
            var features = TransportProducerFeatures.IdempotentPublishing;
            var options = new PartitionPublishingOptions();
            var cancellationSource = new CancellationTokenSource();
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());
            var mockLink = new SendingAmqpLink(new AmqpLinkSettings());

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, scopeIdentifier, 8192, 8192, default)
            {
                CallBase = true
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<EventHubsTransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<RemoteCertificateValidationCallback>(),
                    ItExpr.Is<string>(value => value == scopeIdentifier),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection))
                .Verifiable();

            mockScope
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateSendingLinkAsync",
                    ItExpr.Is<AmqpConnection>(value => value == mockConnection),
                    ItExpr.Is<Uri>(value => value.AbsoluteUri.StartsWith(endpoint.AbsoluteUri)),
                    ItExpr.Is<TransportProducerFeatures>(value => value == features),
                    ItExpr.Is<PartitionPublishingOptions>(value => value == options),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.Is<string>(value => value == producerIdentifier),
                    ItExpr.Is<CancellationToken>(value => value == cancellationSource.Token))
                .Returns(Task.FromResult(mockLink))
                .Verifiable();

            mockScope
                .Protected()
                .Setup<Task>("OpenAmqpObjectAsync",
                    ItExpr.IsAny<AmqpObject>(),
                    ItExpr.IsAny<TimeSpan?>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask)
                .Verifiable();

            var link = await mockScope.Object.OpenProducerLinkAsync(partitionId, features, options, TimeSpan.FromDays(1), TimeSpan.FromDays(1), producerIdentifier, cancellationSource.Token);
            Assert.That(link, Is.EqualTo(mockLink), "The mock return was incorrect");

            mockScope.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenProducerLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OpenProducerLinkAsyncConfiguresTheLink()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var partitionId = "00_partition_00";
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);
            var features = TransportProducerFeatures.IdempotentPublishing;
            var cancellationSource = new CancellationTokenSource();
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier, 8192, 8192, default)
            {
                CallBase = true
            };

            var options = new PartitionPublishingOptions
            {
                ProducerGroupId = 123,
                OwnerLevel = 456,
                StartingSequenceNumber = 789
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<EventHubsTransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<RemoteCertificateValidationCallback>(),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection));

            mockScope
                .Protected()
                .Setup<Task<DateTime>>("RequestAuthorizationUsingCbsAsync",
                    ItExpr.Is<AmqpConnection>(value => value == mockConnection),
                    ItExpr.IsAny<CbsTokenProvider>(),
                    ItExpr.Is<Uri>(value => value.AbsoluteUri.StartsWith(endpoint.AbsoluteUri)),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.Is<string[]>(value => value.SingleOrDefault() == EventHubsClaim.Send),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(DateTime.UtcNow.AddDays(1)));

            mockScope
                .Protected()
                .Setup<Task>("OpenAmqpObjectAsync",
                    ItExpr.IsAny<AmqpObject>(),
                    ItExpr.IsAny<TimeSpan?>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask);

            var link = await mockScope.Object.OpenProducerLinkAsync(partitionId, features, options, TimeSpan.FromDays(1), TimeSpan.FromDays(1), identifier, cancellationSource.Token);
            Assert.That(link, Is.Not.Null, "The link produced was null");

            var linkTarget = (Target)link.Settings.Target;
            Assert.That(linkTarget.Address.ToString(), Contains.Substring($"/{ partitionId }"), "The partition identifier should have been part of the link address.");
            Assert.That(link.Settings.DesiredCapabilities.Contains(AmqpProperty.EnableIdempotentPublishing), Is.True, "The idempotent publishing capability should have been set.");
            Assert.That(link.Settings.Properties.Any(item => item.Key.Key.ToString() == AmqpProperty.EntityType.ToString()), Is.True, "There should be an entity type specified.");
            Assert.That(link.Settings.Properties[AmqpProperty.ProducerGroupId], Is.EqualTo(options.ProducerGroupId), "The producer group should have been set.");
            Assert.That(link.Settings.Properties[AmqpProperty.ProducerOwnerLevel], Is.EqualTo(options.OwnerLevel), "The owner level should have been set.");
            Assert.That(link.Settings.DesiredCapabilities.Contains(AmqpProperty.GeoReplication), Is.True, "Geo replication should always be requested.");
            Assert.That(link.Settings.Properties[AmqpProperty.ProducerSequenceNumber], Is.EqualTo(options.StartingSequenceNumber), "The published sequence number should have been set.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenProducerLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OpenProducerLinkAsyncConfiguresTheLinkWhenOptionsAreEmpty()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var partitionId = "00_partition_00";
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);
            var options = new PartitionPublishingOptions();
            var features = TransportProducerFeatures.IdempotentPublishing;
            var cancellationSource = new CancellationTokenSource();
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier, 8192, 8192, default)
            {
                CallBase = true
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<EventHubsTransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<RemoteCertificateValidationCallback>(),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection));

            mockScope
                .Protected()
                .Setup<Task<DateTime>>("RequestAuthorizationUsingCbsAsync",
                    ItExpr.Is<AmqpConnection>(value => value == mockConnection),
                    ItExpr.IsAny<CbsTokenProvider>(),
                    ItExpr.Is<Uri>(value => value.AbsoluteUri.StartsWith(endpoint.AbsoluteUri)),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.Is<string[]>(value => value.SingleOrDefault() == EventHubsClaim.Send),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(DateTime.UtcNow.AddDays(1)));

            mockScope
                .Protected()
                .Setup<Task>("OpenAmqpObjectAsync",
                    ItExpr.IsAny<AmqpObject>(),
                    ItExpr.IsAny<TimeSpan?>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask);

            var link = await mockScope.Object.OpenProducerLinkAsync(partitionId, features, options, TimeSpan.FromDays(1), TimeSpan.FromDays(1), identifier, cancellationSource.Token);
            Assert.That(link, Is.Not.Null, "The link produced was null");

            var linkTarget = (Target)link.Settings.Target;
            Assert.That(linkTarget.Address.ToString(), Contains.Substring($"/{ partitionId }"), "The partition identifier should have been part of the link address.");
            Assert.That(link.Settings.DesiredCapabilities.Contains(AmqpProperty.EnableIdempotentPublishing), Is.True, "The idempotent publishing capability should have been set.");
            Assert.That(link.Settings.Properties.Any(item => item.Key.Key.ToString() == AmqpProperty.EntityType.ToString()), Is.True, "There should be an entity type specified.");
            Assert.That(link.Settings.Properties.Any(item => item.Key.Key.ToString() == AmqpProperty.ProducerGroupId.ToString()), Is.False, "The producer group should not have been set.");
            Assert.That(link.Settings.Properties.Any(item => item.Key.Key.ToString() == AmqpProperty.ProducerOwnerLevel.ToString()), Is.False, "The owner level should not have been set.");
            Assert.That(link.Settings.Properties.Any(item => item.Key.Key.ToString() == AmqpProperty.ProducerSequenceNumber.ToString()), Is.False, "The published sequence number should not have been set.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenProducerLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(PartitionPublishingPartialOptionsTestCases))]
        public async Task OpenProducerLinkAsyncConfiguresTheLinkWhenOptionsAreEmpty(object options)
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var partitionId = "00_partition_00";
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);
            var features = TransportProducerFeatures.IdempotentPublishing;
            var cancellationSource = new CancellationTokenSource();
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier, 8192, 8192, default)
            {
                CallBase = true
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<EventHubsTransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<RemoteCertificateValidationCallback>(),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection));

            mockScope
                .Protected()
                .Setup<Task<DateTime>>("RequestAuthorizationUsingCbsAsync",
                    ItExpr.Is<AmqpConnection>(value => value == mockConnection),
                    ItExpr.IsAny<CbsTokenProvider>(),
                    ItExpr.Is<Uri>(value => value.AbsoluteUri.StartsWith(endpoint.AbsoluteUri)),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.Is<string[]>(value => value.SingleOrDefault() == EventHubsClaim.Send),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(DateTime.UtcNow.AddDays(1)));

            mockScope
                .Protected()
                .Setup<Task>("OpenAmqpObjectAsync",
                    ItExpr.IsAny<AmqpObject>(),
                    ItExpr.IsAny<TimeSpan?>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask);

            var link = await mockScope.Object.OpenProducerLinkAsync(partitionId, features, (PartitionPublishingOptions)options, TimeSpan.FromDays(1), TimeSpan.FromDays(1), identifier, cancellationSource.Token);
            Assert.That(link, Is.Not.Null, "The link produced was null");

            var linkTarget = (Target)link.Settings.Target;
            Assert.That(linkTarget.Address.ToString(), Contains.Substring($"/{ partitionId }"), "The partition identifier should have been part of the link address.");
            Assert.That(link.Settings.DesiredCapabilities.Contains(AmqpProperty.EnableIdempotentPublishing), Is.True, "The idempotent publishing capability should have been set.");
            Assert.That(link.Settings.DesiredCapabilities.Contains(AmqpProperty.GeoReplication), Is.True, "Geo replication should always be requested.");
            Assert.That(link.Settings.Properties.Any(item => item.Key.Key.ToString() == AmqpProperty.EntityType.ToString()), Is.True, "There should be an entity type specified.");
            Assert.That(link.Settings.Properties.Any(item => item.Key.Key.ToString() == AmqpProperty.ProducerGroupId.ToString()), Is.True, "The producer group should have been set.");
            Assert.That(link.Settings.Properties.Any(item => item.Key.Key.ToString() == AmqpProperty.ProducerOwnerLevel.ToString()), Is.True, "The owner level should have been set.");
            Assert.That(link.Settings.Properties.Any(item => item.Key.Key.ToString() == AmqpProperty.ProducerSequenceNumber.ToString()), Is.True, "The published sequence number should have been set.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenProducerLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OpenProducerLinkAsyncConfiguresTheLinkWhenNoFeaturesAreActive()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var partitionId = "00_partition_00";
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);
            var features = TransportProducerFeatures.None;
            var cancellationSource = new CancellationTokenSource();
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier, 8192, 8192, default)
            {
                CallBase = true
            };

            var options = new PartitionPublishingOptions
            {
                ProducerGroupId = 123,
                OwnerLevel = 456,
                StartingSequenceNumber = 789
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<EventHubsTransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<RemoteCertificateValidationCallback>(),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection));

            mockScope
                .Protected()
                .Setup<Task<DateTime>>("RequestAuthorizationUsingCbsAsync",
                    ItExpr.Is<AmqpConnection>(value => value == mockConnection),
                    ItExpr.IsAny<CbsTokenProvider>(),
                    ItExpr.Is<Uri>(value => value.AbsoluteUri.StartsWith(endpoint.AbsoluteUri)),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.Is<string[]>(value => value.SingleOrDefault() == EventHubsClaim.Send),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(DateTime.UtcNow.AddDays(1)));

            mockScope
                .Protected()
                .Setup<Task>("OpenAmqpObjectAsync",
                    ItExpr.IsAny<AmqpObject>(),
                    ItExpr.IsAny<TimeSpan?>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask);

            var link = await mockScope.Object.OpenProducerLinkAsync(partitionId, features, options, TimeSpan.FromDays(1), TimeSpan.FromDays(1), identifier, cancellationSource.Token);
            Assert.That(link, Is.Not.Null, "The link produced was null");

            var linkTarget = (Target)link.Settings.Target;
            Assert.That(linkTarget.Address.ToString(), Contains.Substring($"/{ partitionId }"), "The partition identifier should have been part of the link address.");
            Assert.That(link.Settings.DesiredCapabilities.Contains(AmqpProperty.GeoReplication), Is.True, "Geo replication should always be requested.");
            Assert.That(link.Settings.Properties.Any(item => item.Key.Key.ToString() == AmqpProperty.EntityType.ToString()), Is.True, "There should be an entity type specified.");
            Assert.That(link.Settings.Properties[AmqpProperty.ProducerGroupId], Is.EqualTo(options.ProducerGroupId), "The producer group should have been set.");
            Assert.That(link.Settings.Properties[AmqpProperty.ProducerOwnerLevel], Is.EqualTo(options.OwnerLevel), "The owner level should have been set.");
            Assert.That(link.Settings.Properties[AmqpProperty.ProducerSequenceNumber], Is.EqualTo(options.StartingSequenceNumber), "The published sequence number should have been set.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenProducerLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OpenProducerLinkAsyncManagesActiveLinks()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);
            var cancellationSource = new CancellationTokenSource();
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier, 8192, 8192, default)
            {
                CallBase = true
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<EventHubsTransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<RemoteCertificateValidationCallback>(),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection));

            mockScope
                .Protected()
                .Setup<Task<DateTime>>("RequestAuthorizationUsingCbsAsync",
                    ItExpr.Is<AmqpConnection>(value => value == mockConnection),
                    ItExpr.IsAny<CbsTokenProvider>(),
                    ItExpr.Is<Uri>(value => value.AbsoluteUri.StartsWith(endpoint.AbsoluteUri)),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.Is<string[]>(value => value.SingleOrDefault() == EventHubsClaim.Send),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(DateTime.UtcNow.AddDays(1)));

            mockScope
                .Protected()
                .Setup<Task>("OpenAmqpObjectAsync",
                    ItExpr.IsAny<AmqpObject>(),
                    ItExpr.IsAny<TimeSpan?>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask);

            var activeLinks = GetActiveLinks(mockScope.Object);
            Assert.That(activeLinks, Is.Not.Null, "The set of active links was null.");
            Assert.That(activeLinks.Count, Is.Zero, "There should be no active links when none have been created.");

            var link = await mockScope.Object.OpenProducerLinkAsync(null, TransportProducerFeatures.None, new PartitionPublishingOptions(), TimeSpan.FromDays(1), TimeSpan.FromDays(1), identifier, cancellationSource.Token);
            Assert.That(link, Is.Not.Null, "The link produced was null");

            Assert.That(activeLinks.Count, Is.EqualTo(1), "There should be an active link being tracked.");
            Assert.That(activeLinks.ContainsKey(link), Is.True, "The producer link should be tracked as active.");

            activeLinks.TryGetValue(link, out var refreshTimer);
            Assert.That(refreshTimer, Is.Not.Null, "The link should have a non-null timer.");

            link.SafeClose();
            Assert.That(activeLinks.Count, Is.Zero, "Closing the link should stop tracking it as active.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenProducerLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OpenProducerLinkAsyncConfiguresAuthorizationRefresh()
        {
            var timerCallbackInvoked = false;
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);
            var cancellationSource = new CancellationTokenSource();
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier, 8192, 8192, default)
            {
                CallBase = true
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<EventHubsTransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<RemoteCertificateValidationCallback>(),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection));

            mockScope
                .Protected()
                .Setup<Task<DateTime>>("RequestAuthorizationUsingCbsAsync",
                    ItExpr.IsAny<AmqpConnection>(),
                    ItExpr.IsAny<CbsTokenProvider>(),
                    ItExpr.IsAny<Uri>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string[]>(),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(DateTime.UtcNow.AddDays(5)));

            mockScope
                .Protected()
                .Setup<TimerCallback>("CreateAuthorizationRefreshHandler",
                    ItExpr.IsAny<AmqpConnection>(),
                    ItExpr.IsAny<AmqpObject>(),
                    ItExpr.IsAny<CbsTokenProvider>(),
                    ItExpr.IsAny<Uri>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string[]>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<Func<Timer>>())
                .Returns(_ => timerCallbackInvoked = true);

            mockScope
                .Protected()
                .Setup<TimeSpan>("CalculateLinkAuthorizationRefreshInterval",
                    ItExpr.IsAny<DateTime>(),
                    ItExpr.IsAny<DateTime?>())
                .Returns(TimeSpan.Zero);

            mockScope
                .Protected()
                .Setup<Task>("OpenAmqpObjectAsync",
                    ItExpr.IsAny<AmqpObject>(),
                    ItExpr.IsAny<TimeSpan?>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask);

            var link = await mockScope.Object.OpenProducerLinkAsync(null, TransportProducerFeatures.None, new PartitionPublishingOptions(), TimeSpan.FromDays(1), TimeSpan.FromDays(1), identifier, cancellationSource.Token);
            Assert.That(link, Is.Not.Null, "The link produced was null");

            var activeLinks = GetActiveLinks(mockScope.Object);
            Assert.That(activeLinks.ContainsKey(link), Is.True, "The producer link should be tracked as active.");

            activeLinks.TryGetValue(link, out var refreshTimer);
            Assert.That(refreshTimer, Is.Not.Null, "The link should have a non-null timer.");

            // The timer be configured to fire immediately and set the flag.  Because the timer
            // runs in the background, there is a level of non-determinism in when that callback will execute.
            // Allow for a small number of delay and retries to account for it.

            var attemptCount = 0;
            var remainingAttempts = 10;

            while ((--remainingAttempts >= 0) && (!timerCallbackInvoked))
            {
                await Task.Delay(250 * ++attemptCount).ConfigureAwait(false);
            }

            Assert.That(timerCallbackInvoked, Is.True, "The timer should have been configured and running when the link was created.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenProducerLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OpenProducerLinkAsyncRefreshesAuthorization()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);
            var cancellationSource = new CancellationTokenSource();
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier, 8192, 8192, default)
            {
                CallBase = true
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<EventHubsTransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<RemoteCertificateValidationCallback>(),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection));

            mockScope
                .Protected()
                .Setup<Task<DateTime>>("RequestAuthorizationUsingCbsAsync",
                    ItExpr.IsAny<AmqpConnection>(),
                    ItExpr.IsAny<CbsTokenProvider>(),
                    ItExpr.IsAny<Uri>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string[]>(),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(DateTime.UtcNow.AddDays(5)));

            mockScope
                .Protected()
                .Setup<Task>("OpenAmqpObjectAsync",
                    ItExpr.IsAny<AmqpObject>(),
                    ItExpr.IsAny<TimeSpan?>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask);

            var link = await mockScope.Object.OpenProducerLinkAsync(null, TransportProducerFeatures.None, new PartitionPublishingOptions(), TimeSpan.FromDays(1), TimeSpan.FromDays(1), identifier, cancellationSource.Token);
            Assert.That(link, Is.Not.Null, "The link produced was null");

            var activeLinks = GetActiveLinks(mockScope.Object);
            Assert.That(activeLinks.ContainsKey(link), Is.True, "The producer link should be tracked as active.");

            activeLinks.TryGetValue(link, out var refreshTimer);
            Assert.That(refreshTimer, Is.Not.Null, "The link should have a non-null timer.");

            // Verify that there was only a initial request for authorization.

            mockScope
                .Protected()
                .Verify("RequestAuthorizationUsingCbsAsync",
                    Times.Once(),
                    ItExpr.Is<AmqpConnection>(value => value == mockConnection),
                    ItExpr.IsAny<CbsTokenProvider>(),
                    ItExpr.Is<Uri>(value => value.AbsoluteUri.StartsWith(endpoint.AbsoluteUri)),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.Is<string[]>(value => value.SingleOrDefault() == EventHubsClaim.Send),
                    ItExpr.IsAny<TimeSpan>());

            // Reset the timer so that it fires immediately and validate that authorization was
            // requested.  Since opening of the link requests an initial authorization and the expiration
            // was set way in the future, there should be exactly two calls.
            //
            // Because the timer runs in the background, there is a level of non-determinism in when that
            // callback will execute.  Allow for a small number of delay and retries to account for it.

            refreshTimer.Change(0, Timeout.Infinite);

            var attemptCount = 0;
            var remainingAttempts = 10;
            var success = false;

            while ((--remainingAttempts >= 0) && (!success))
            {
                try
                {
                    await Task.Delay(250 * ++attemptCount).ConfigureAwait(false);

                    mockScope
                        .Protected()
                        .Verify("RequestAuthorizationUsingCbsAsync",
                            Times.Exactly(2),
                            ItExpr.Is<AmqpConnection>(value => value == mockConnection),
                            ItExpr.IsAny<CbsTokenProvider>(),
                            ItExpr.Is<Uri>(value => value.AbsoluteUri.StartsWith(endpoint.AbsoluteUri)),
                            ItExpr.IsAny<string>(),
                            ItExpr.IsAny<string>(),
                            ItExpr.Is<string[]>(value => value.SingleOrDefault() == EventHubsClaim.Send),
                            ItExpr.IsAny<TimeSpan>());

                    success = true;
                }
                catch when (remainingAttempts <= 0)
                {
                    throw;
                }
                catch
                {
                    // No action needed.
                }
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenProducerLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task AuthorizationTimerCallbackToleratesDisposal()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var idleTimeout = TimeSpan.FromSeconds(30);
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());
            var mockScope = new DisposeOnAuthorizationTimerCallbackMockScope(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout);

            var link = await mockScope.OpenProducerLinkAsync(null, TransportProducerFeatures.None, new PartitionPublishingOptions(), TimeSpan.FromDays(1), TimeSpan.FromDays(1), null, cancellationSource.Token);
            Assert.That(link, Is.Not.Null, "The link produced was null");

            var activeLinks = GetActiveLinks(mockScope);
            Assert.That(activeLinks.ContainsKey(link), Is.True, "The producer link should be tracked as active.");

            activeLinks.TryGetValue(link, out var refreshTimer);
            Assert.That(refreshTimer, Is.Not.Null, "The link should have a non-null timer.");

            // Reset the timer so that it fires immediately and validate that authorization was
            // requested.  Since opening of the link requests an initial authorization and the expiration
            // was set way in the future, there should be exactly two calls.
            //
            // Because the timer runs in the background, await the callback completion source, but using a
            // timed cancellation to ensure that the test does not hang.

            refreshTimer.Change(0, Timeout.Infinite);

            await Task.WhenAny(mockScope.CallbackCompletionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(mockScope.IsDisposed, Is.True, "The scope should have been disposed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.Dispose" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void DisposeCancelsOperations()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);
            var scope = new AmqpConnectionScope(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier);
            var cancellation = GetOperationCancellationSource(scope);

            Assert.That(cancellation.IsCancellationRequested, Is.False, "The cancellation source should not be canceled before disposal");

            scope.Dispose();
            Assert.That(cancellation.IsCancellationRequested, Is.True, "The cancellation source should be canceled by disposal");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.Dispose" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task DisposeClosesTheConnection()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            EventHubsTransportType transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);
            var connectionClosed = false;
            var cancellationSource = new CancellationTokenSource();
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());
            var mockLink = new RequestResponseAmqpLink("test", "test", mockSession, "test");

            mockConnection.Closed += (snd, args) => connectionClosed = true;

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier, 8192, 8192, default)
            {
                CallBase = true
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<EventHubsTransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<RemoteCertificateValidationCallback>(),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection))
                .Verifiable();

            mockScope
                .Protected()
                .Setup<Task<RequestResponseAmqpLink>>("CreateManagementLinkAsync",
                    ItExpr.Is<AmqpConnection>(value => value == mockConnection),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.Is<CancellationToken>(value => value == cancellationSource.Token))
                .Returns(Task.FromResult(mockLink))
                .Verifiable();

            mockScope
                .Protected()
                .Setup<Task>("OpenAmqpObjectAsync",
                    ItExpr.IsAny<AmqpObject>(),
                    ItExpr.IsAny<TimeSpan?>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask)
                .Verifiable();

            // Create the mock management link to force lazy creation of the connection.

            await mockScope.Object.OpenManagementLinkAsync(TimeSpan.FromDays(1), TimeSpan.FromDays(1), cancellationSource.Token);

            mockScope.Object.Dispose();
            Assert.That(connectionClosed, Is.True, "The link should have been closed when the scope was disposed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.Dispose" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task DisposeClosesActiveLinks()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var consumerGroup = "group";
            var partitionId = "0";
            var position = EventPosition.Latest;
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);
            var cancellationSource = new CancellationTokenSource();
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier, 8192, 8192, default)
            {
                CallBase = true
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<EventHubsTransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<RemoteCertificateValidationCallback>(),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection));

            mockScope
                .Protected()
                .Setup<Task<DateTime>>("RequestAuthorizationUsingCbsAsync",
                    ItExpr.Is<AmqpConnection>(value => value == mockConnection),
                    ItExpr.IsAny<CbsTokenProvider>(),
                    ItExpr.Is<Uri>(value => value.AbsoluteUri.StartsWith(endpoint.AbsoluteUri)),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.Is<string[]>(value => value.SingleOrDefault() == EventHubsClaim.Listen),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(DateTime.UtcNow.AddDays(1)));

            mockScope
                .Protected()
                .Setup<Task>("OpenAmqpObjectAsync",
                    ItExpr.IsAny<AmqpObject>(),
                    ItExpr.IsAny<TimeSpan?>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask);

            var activeLinks = GetActiveLinks(mockScope.Object);
            Assert.That(activeLinks, Is.Not.Null, "The set of active links was null.");
            Assert.That(activeLinks.Count, Is.Zero, "There should be no active links when none have been created.");

            var producerLink = await mockScope.Object.OpenConsumerLinkAsync(consumerGroup, partitionId, position, TimeSpan.FromDays(1), TimeSpan.FromDays(1), 0, null, null, false, identifier, cancellationSource.Token);
            Assert.That(producerLink, Is.Not.Null, "The producer link produced was null");

            var managementLink = await mockScope.Object.OpenManagementLinkAsync(TimeSpan.FromDays(1), TimeSpan.FromDays(1), cancellationSource.Token);
            Assert.That(managementLink, Is.Not.Null, "The management link produced was null");

            Assert.That(activeLinks.Count, Is.EqualTo(2), "There should be active links being tracked.");
            Assert.That(activeLinks.ContainsKey(managementLink), Is.True, "The management link should be tracked as active.");
            Assert.That(activeLinks.ContainsKey(producerLink), Is.True, "The producer link should be tracked as active.");

            mockScope.Object.Dispose();
            Assert.That(activeLinks.Count, Is.Zero, "Disposal should stop tracking it as active.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.Dispose" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task DisposeStopsManagingLinkAuthorizations()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var consumerGroup = "group";
            var partitionId = "0";
            var position = EventPosition.Latest;
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var transport = EventHubsTransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var idleTimeout = TimeSpan.FromSeconds(30);
            var cancellationSource = new CancellationTokenSource();
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, endpoint, eventHub, credential.Object, transport, null, idleTimeout, identifier, 8192, 8192, default)
            {
                CallBase = true
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<EventHubsTransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<int>(),
                    ItExpr.IsAny<RemoteCertificateValidationCallback>(),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection));

            mockScope
                .Protected()
                .Setup<Task<DateTime>>("RequestAuthorizationUsingCbsAsync",
                    ItExpr.Is<AmqpConnection>(value => value == mockConnection),
                    ItExpr.IsAny<CbsTokenProvider>(),
                    ItExpr.Is<Uri>(value => value.AbsoluteUri.StartsWith(endpoint.AbsoluteUri)),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.Is<string[]>(value => value.SingleOrDefault() == EventHubsClaim.Listen),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(DateTime.UtcNow.AddDays(1)));

            mockScope
                .Protected()
                .Setup<Task>("OpenAmqpObjectAsync",
                    ItExpr.IsAny<AmqpObject>(),
                    ItExpr.IsAny<TimeSpan?>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask);

            var managedAuthorizations = GetActiveLinks(mockScope.Object);
            Assert.That(managedAuthorizations, Is.Not.Null, "The set of managed authorizations was null.");
            Assert.That(managedAuthorizations.Count, Is.Zero, "There should be no managed authorizations when none have been created.");

            var link = await mockScope.Object.OpenConsumerLinkAsync(consumerGroup, partitionId, position, TimeSpan.FromDays(1), TimeSpan.FromDays(1), 12, 555, 777, true, identifier, cancellationSource.Token);
            Assert.That(link, Is.Not.Null, "The producer link produced was null");

            Assert.That(managedAuthorizations.Count, Is.EqualTo(1), "There should be a managed authorization being tracked.");
            Assert.That(managedAuthorizations.ContainsKey(link), Is.True, "The producer link should be tracked for authorization.");

            managedAuthorizations.TryGetValue(link, out var refreshTimer);
            Assert.That(refreshTimer, Is.Not.Null, "The link should have a non-null timer.");

            mockScope.Object.Dispose();
            Assert.That(managedAuthorizations.Count, Is.Zero, "Disposal should stop managing authorizations.");

#if NET8_0_OR_GREATER
            Assert.That(refreshTimer.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan), Is.False, "The timer should have been disposed.");
#else
            Assert.That(() => refreshTimer.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan), Throws.InstanceOf<ObjectDisposedException>(), "The timer should have been disposed.");
#endif
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenProducerLinkAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task RequestAuthorizationUsingCbsAsyncRespectsTheConnectionClosing()
        {
            var observedException = default(EventHubsException);
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var transport = EventHubsTransportType.AmqpTcp;
            var idleTimeout = TimeSpan.FromSeconds(30);
            var mockCredential = new Mock<TokenCredential>();
            var mockEventHubsCredential = new Mock<EventHubTokenCredential>(mockCredential.Object);
            var mockTokenProvider = new CbsTokenProvider(mockEventHubsCredential.Object, TimeSpan.Zero, CancellationToken.None);
            var mockScope = new MockConnectionScope(endpoint, endpoint, eventHub, mockEventHubsCredential.Object, transport, null, idleTimeout);

            // This is brittle, but the AMQP library does not support mocking nor setting this directly.

            typeof(AmqpObject)
                .GetProperty(nameof(AmqpObject.State), BindingFlags.Public | BindingFlags.Instance)
                .SetValue(mockScope.MockConnection.Object, AmqpObjectState.CloseSent);

            try
            {
                await mockScope.InvokeRequestAuthorizationUsingCbsAsync(mockTokenProvider, endpoint, "dummy", eventHub, new[] { "dummy" }, TimeSpan.FromSeconds(10));
            }
            catch (EventHubsException ex)
            {
                observedException = ex;
            }
            catch
            {
                // Ignore any other exception; the assertions will fail with better context.
            }

            Assert.That(observedException, Is.Not.Null, "An Event Hubs exception should have been thrown when requesting authorization.");
            Assert.That(observedException.IsTransient, Is.True, "The authorization failure should have been transient.");
            Assert.That(observedException.Reason, Is.EqualTo(EventHubsException.FailureReason.ServiceCommunicationProblem), "The authorization failure should present as a generic failure.");
            Assert.That(observedException.InnerException, Is.Null, "The authorization failure should not be wrapping another exception.");

            mockCredential.Verify(cred =>
                cred.GetTokenAsync(
                    It.IsAny<TokenRequestContext>(),
                    It.IsAny<CancellationToken>()),
                Times.Never,
                "The token should not have been requested.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.CalculateLinkAuthorizationRefreshInterval" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CalculateLinkAuthorizationRefreshIntervalRespectsTheRefreshBuffer()
        {
            var endPoint = new Uri("sb://mine.hubs.com");
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var idleTimeout = TimeSpan.FromSeconds(30);
            var mockScope = new MockConnectionScope(endPoint, endPoint, "test", credential.Object, EventHubsTransportType.AmqpTcp, null, idleTimeout);
            var currentTime = new DateTime(2015, 10, 27, 00, 00, 00);
            var expireTime = currentTime.AddHours(1);
            var buffer = GetAuthorizationRefreshBuffer();
            var jitterBuffer = TimeSpan.FromSeconds(GetAuthorizationBaseJitterSeconds()).Add(TimeSpan.FromSeconds(5));
            var calculatedRefresh = mockScope.InvokeCalculateLinkAuthorizationRefreshInterval(expireTime, currentTime);
            var calculatedExpire = currentTime.Add(calculatedRefresh);

            Assert.That(calculatedExpire, Is.LessThan(expireTime), "The refresh should be account for the buffer and be earlier than expiration.");
            Assert.That(calculatedExpire, Is.EqualTo(expireTime.Subtract(buffer)).Within(jitterBuffer), "The authorization buffer should have been used for buffering.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.CalculateLinkAuthorizationRefreshInterval" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CalculateLinkAuthorizationRefreshIntervalRespectsTheMinimumDuration()
        {
            var endPoint = new Uri("sb://mine.hubs.com");
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var idleTimeout = TimeSpan.FromSeconds(30);
            var mockScope = new MockConnectionScope(endPoint, endPoint, "test", credential.Object, EventHubsTransportType.AmqpTcp, null, idleTimeout);
            var currentTime = new DateTime(2015, 10, 27, 00, 00, 00);
            var minimumRefresh = GetMinimumAuthorizationRefresh();
            var jitterBuffer = TimeSpan.FromSeconds(GetAuthorizationBaseJitterSeconds()).Add(TimeSpan.FromSeconds(5));
            var expireTime = currentTime.Add(minimumRefresh.Subtract(TimeSpan.FromMilliseconds(500)));
            var calculatedRefresh = mockScope.InvokeCalculateLinkAuthorizationRefreshInterval(expireTime, currentTime);

            Assert.That(calculatedRefresh, Is.GreaterThanOrEqualTo(minimumRefresh), "The minimum refresh duration should be violated.");
            Assert.That(calculatedRefresh, Is.EqualTo(minimumRefresh).Within(jitterBuffer), "The minimum refresh duration should have been used.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.CalculateLinkAuthorizationRefreshInterval" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CalculateLinkAuthorizationRefreshIntervalRespectsTheMaximumDuration()
        {
            var endPoint = new Uri("sb://mine.hubs.com");
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var idleTimeout = TimeSpan.FromSeconds(30);
            var mockScope = new MockConnectionScope(endPoint, endPoint, "test", credential.Object, EventHubsTransportType.AmqpTcp, null, idleTimeout);
            var currentTime = new DateTime(2015, 10, 27, 00, 00, 00);
            var refreshBuffer = GetAuthorizationRefreshBuffer();
            var jitterBuffer = TimeSpan.FromSeconds(GetAuthorizationBaseJitterSeconds()).Add(TimeSpan.FromSeconds(5));
            var maximumRefresh = GetMaximumAuthorizationRefresh();
            var expireTime = currentTime.Add(maximumRefresh.Add(refreshBuffer).Add(TimeSpan.FromMilliseconds(500)));
            var calculatedRefresh = mockScope.InvokeCalculateLinkAuthorizationRefreshInterval(expireTime, currentTime);

            Assert.That(calculatedRefresh, Is.LessThanOrEqualTo(maximumRefresh), "The maximum refresh duration should not be exceeded.");
            Assert.That(calculatedRefresh, Is.EqualTo(maximumRefresh).Within(jitterBuffer), "The maximum refresh duration should have been used.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenAmqpObjectAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(typeof(InvalidOperationException))]
        [TestCase(typeof(ObjectDisposedException))]
        public async Task OpenAmqpObjectAsyncTranslatesInvalidStateExceptions(Type exceptionType)
        {
            var observedException = default(Exception);
            var openException = (Exception)Activator.CreateInstance(exceptionType, "stringArg");
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var transport = EventHubsTransportType.AmqpTcp;
            var idleTimeout = TimeSpan.FromSeconds(30);
            var mockCredential = new Mock<TokenCredential>();
            var mockEventHubsCredential = new Mock<EventHubTokenCredential>(mockCredential.Object);
            var mockScope = new MockConnectionScope(endpoint, endpoint, eventHub, mockEventHubsCredential.Object, transport, null, idleTimeout);

            mockScope.MockConnection
                .Protected()
                .Setup("OpenInternal")
                .Throws(openException)
                .Verifiable();

            try
            {
                await mockScope.InvokeBaseOpenAmqpObjectAsync(mockScope.MockConnection.Object, EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);
            }
            catch (Exception ex)
            {
                observedException = ex;
            }

            Assert.That(observedException, Is.Not.Null, "An exception should have been observed.");
            Assert.That(observedException, Is.TypeOf<EventHubsException>(), "The exception should have been translated.");
            Assert.That(((EventHubsException)observedException).IsTransient, Is.True, "The exception should be transient.");

            mockScope.MockConnection.VerifyAll();
        }

        /// <summary>
        ///   Gets the active connection for the given scope, using the
        ///   private property accessor.
        /// </summary>
        ///
        private static FaultTolerantAmqpObject<AmqpConnection> GetActiveConnection(AmqpConnectionScope target) =>
            (FaultTolerantAmqpObject<AmqpConnection>)
                typeof(AmqpConnectionScope)
                    .GetProperty("ActiveConnection", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetProperty)
                    .GetValue(target);

        /// <summary>
        ///   Gets the set of active links for the given scope, using the
        ///   private property accessor.
        /// </summary>
        ///
        private static ConcurrentDictionary<AmqpObject, Timer> GetActiveLinks(AmqpConnectionScope target) =>
            (ConcurrentDictionary<AmqpObject, Timer>)
                typeof(AmqpConnectionScope)
                    .GetProperty("ActiveLinks", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetProperty)
                    .GetValue(target);

        /// <summary>
        ///   Gets the CBS token provider for the given scope, using the
        ///   private property accessor.
        /// </summary>
        ///
        private static CancellationTokenSource GetOperationCancellationSource(AmqpConnectionScope target) =>
            (CancellationTokenSource)
                typeof(AmqpConnectionScope)
                    .GetProperty("OperationCancellationSource", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetProperty)
                    .GetValue(target);

        /// <summary>
        ///   Gets the token refresh buffer for the scope, using the
        ///   private property accessor.
        /// </summary>
        ///
        private static TimeSpan GetAuthorizationRefreshBuffer() =>
            (TimeSpan)
                typeof(AmqpConnectionScope)
                    .GetProperty("AuthorizationRefreshBuffer", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetProperty)
                    .GetValue(null);

        /// <summary>
        ///   Gets the minimum authorization refresh interval, using the
        ///   private property accessor.
        /// </summary>
        ///
        private static TimeSpan GetMinimumAuthorizationRefresh() =>
            (TimeSpan)
                typeof(AmqpConnectionScope)
                    .GetProperty("MinimumAuthorizationRefresh", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetProperty)
                    .GetValue(null);

        /// <summary>
        ///   Gets the maximum authorization refresh interval, using the
        ///   private property accessor.
        /// </summary>
        ///
        private static TimeSpan GetMaximumAuthorizationRefresh() =>
            (TimeSpan)
                typeof(AmqpConnectionScope)
                    .GetProperty("MaximumAuthorizationRefresh", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetProperty)
                    .GetValue(null);

        /// <summary>
        ///   Gets the base time used to calculate random jitter for refreshing authorization,
        ///   using the private accessor.
        /// </summary>
        ///
        private static int GetAuthorizationBaseJitterSeconds() =>
            (int)
                typeof(AmqpConnectionScope)
                    .GetProperty("AuthorizationBaseJitterSeconds", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetProperty)
                    .GetValue(null);

        /// <summary>
        ///   Creates a set of dummy settings for testing purposes.
        /// </summary>
        ///
        private static AmqpSettings CreateMockAmqpSettings()
        {
            var transportProvider = new AmqpTransportProvider();
            transportProvider.Versions.Add(new AmqpVersion(new Version(1, 0, 0, 0)));

            var amqpSettings = new AmqpSettings();
            amqpSettings.TransportProviders.Add(transportProvider);

            return amqpSettings;
        }

        /// <summary>
        ///   Provides a dummy transport for testing purposes.
        /// </summary>
        ///
        private class MockTransport : TransportBase
        {
            public MockTransport() : base("Mock") { }
            public override string LocalEndPoint { get; }
            public override string RemoteEndPoint { get; }
            public override bool ReadAsync(TransportAsyncCallbackArgs args) => throw new NotImplementedException();
            public override void SetMonitor(ITransportMonitor usageMeter) => throw new NotImplementedException();
            public override bool WriteAsync(TransportAsyncCallbackArgs args) => throw new NotImplementedException();
            protected override void AbortInternal() => throw new NotImplementedException();
            protected override bool CloseInternal() => throw new NotImplementedException();
        }

        /// <summary>
        ///   Provides a mock which disposes the scope before invoking the default timer callback for authorization.
        /// </summary>
        ///
        private class DisposeOnAuthorizationTimerCallbackMockScope : AmqpConnectionScope
        {
            public TaskCompletionSource<bool> CallbackCompletionSource = new TaskCompletionSource<bool>();
            private readonly AmqpConnection _mockConnection;

            public DisposeOnAuthorizationTimerCallbackMockScope(Uri serviceEndpoint,
                                                                Uri connectionEndpoint,
                                                                string eventHubName,
                                                                EventHubTokenCredential credential,
                                                                EventHubsTransportType transport,
                                                                IWebProxy proxy,
                                                                TimeSpan idleTimeout) : base(serviceEndpoint, connectionEndpoint, eventHubName, credential, transport, proxy, idleTimeout)
            {
                _mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            }

            protected override Task<AmqpConnection> CreateAndOpenConnectionAsync(Version amqpVersion,
                                                                                 Uri serviceEndpoint,
                                                                                 Uri connectionEndpoint,
                                                                                 EventHubsTransportType transportType,
                                                                                 IWebProxy proxy,
                                                                                 int sendBufferSizeBytes,
                                                                                 int receiveBufferSizeBytes,
                                                                                 RemoteCertificateValidationCallback certificateValidationCallback,
                                                                                 string scopeIdentifier,
                                                                                 TimeSpan timeout) => Task.FromResult(_mockConnection);

            protected override Task OpenAmqpObjectAsync(AmqpObject target, TimeSpan? timeout = default, CancellationToken cancellationToken = default) => Task.CompletedTask;

            protected override TimerCallback CreateAuthorizationRefreshHandler(AmqpConnection connection,
                                                                               AmqpObject amqpLink,
                                                                               CbsTokenProvider tokenProvider,
                                                                               Uri endpoint,
                                                                               string audience,
                                                                               string resource,
                                                                               string[] requiredClaims,
                                                                               TimeSpan refreshTimeout,
                                                                               Func<Timer> refreshTimerFactory)
            {
                Action baseImplementation = () => base.CreateAuthorizationRefreshHandler(connection, amqpLink, tokenProvider, endpoint, audience, resource, requiredClaims, refreshTimeout, refreshTimerFactory);

                return state =>
                {
                    Dispose();
                    baseImplementation();
                    CallbackCompletionSource.TrySetResult(true);
                };
            }
            protected override Task<DateTime> RequestAuthorizationUsingCbsAsync(AmqpConnection connection,
                                                                                CbsTokenProvider tokenProvider,
                                                                                Uri endpoint,
                                                                                string audience,
                                                                                string resource,
                                                                                string[] requiredClaims,
                                                                                TimeSpan timeout) => Task.FromResult(DateTime.Now.AddMinutes(60));
        }

        /// <summary>
        ///   Provides a mock to use with a mocked connection.
        /// </summary>
        ///
        private class MockConnectionScope : AmqpConnectionScope
        {
            public readonly Mock<AmqpConnection> MockConnection;

            public ConnectionConfiguration LastConnectionConfiguration;

            public MockConnectionScope(Uri serviceEndpoint,
                                           Uri connectionEndpoint,
                                           string eventHubName,
                                           EventHubTokenCredential credential,
                                           EventHubsTransportType transport,
                                           IWebProxy proxy,
                                           TimeSpan idleTimeout,
                                           string identifier = default,
                                           int sendBufferSizeBytes = AmqpConstants.TransportBufferSize,
                                           int receiveBufferSizeBytes = AmqpConstants.TransportBufferSize,
                                           RemoteCertificateValidationCallback certificateValidationCallback = default) : base(serviceEndpoint, connectionEndpoint, eventHubName, credential, transport, proxy, idleTimeout, identifier, sendBufferSizeBytes, receiveBufferSizeBytes, certificateValidationCallback)
            {
                MockConnection = new Mock<AmqpConnection>(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            }

            public Task InvokeBaseOpenAmqpObjectAsync(AmqpObject target, TimeSpan timeout) => base.OpenAmqpObjectAsync(target, timeout);

            public TimeSpan InvokeCalculateLinkAuthorizationRefreshInterval(DateTime expirationTimeUtc,
                                                                            DateTime currentTimeUtc) => base.CalculateLinkAuthorizationRefreshInterval(expirationTimeUtc, currentTimeUtc);

            public Task<DateTime> InvokeRequestAuthorizationUsingCbsAsync(CbsTokenProvider tokenProvider,
                                                                          Uri endpoint,
                                                                          string audience,
                                                                          string resource,
                                                                          string[] requiredClaims,
                                                                          TimeSpan timeout) => base.RequestAuthorizationUsingCbsAsync(MockConnection.Object, tokenProvider, endpoint, audience, resource, requiredClaims, timeout);

            protected override Task<AmqpConnection> CreateAndOpenConnectionAsync(Version amqpVersion,
                                                                                 Uri serviceEndpoint,
                                                                                 Uri connectionEndpoint,
                                                                                 EventHubsTransportType transportType,
                                                                                 IWebProxy proxy,
                                                                                 int sendBufferSizeBytes,
                                                                                 int receiveBufferSizeBytes,
                                                                                 RemoteCertificateValidationCallback certificateValidationCallback,
                                                                                 string scopeIdentifier,
                                                                                 TimeSpan timeout)
            {
                LastConnectionConfiguration = new ConnectionConfiguration
                {
                    serviceEndpoint = serviceEndpoint,
                    connectionEndpoint = connectionEndpoint,
                    transportType = transportType,
                    proxy = proxy,
                    sendBufferSizeBytes = sendBufferSizeBytes,
                    receiveBufferSizeBytes = receiveBufferSizeBytes,
                    certificateValidationCallback = certificateValidationCallback,
                    scopeIdentifier = scopeIdentifier
                };

                return Task.FromResult(MockConnection.Object);
            }

            protected override Task OpenAmqpObjectAsync(AmqpObject target, TimeSpan? timeout = default, CancellationToken cancellationToken = default) => Task.CompletedTask;
        }

        private class ConnectionConfiguration
        {
            public Uri serviceEndpoint;
            public Uri connectionEndpoint;
            public EventHubsTransportType transportType;
            public IWebProxy proxy;
            public int sendBufferSizeBytes;
            public int receiveBufferSizeBytes;
            public RemoteCertificateValidationCallback certificateValidationCallback;
            public string scopeIdentifier;

            public bool IsEquivalentTo(ConnectionConfiguration other) =>
                serviceEndpoint == other.serviceEndpoint
                    && connectionEndpoint == other.connectionEndpoint
                    && transportType == other.transportType
                    && ReferenceEquals(proxy, other.proxy)
                    && sendBufferSizeBytes == other.sendBufferSizeBytes
                    && receiveBufferSizeBytes == other.receiveBufferSizeBytes
                    && ReferenceEquals(certificateValidationCallback, other.certificateValidationCallback)
                    && scopeIdentifier == other.scopeIdentifier;
        }
    }
}
