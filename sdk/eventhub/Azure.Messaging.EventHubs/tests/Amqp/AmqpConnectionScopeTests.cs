// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Amqp;
using Microsoft.Azure.Amqp;
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
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheEndpoint()
        {
            Assert.That(() => new AmqpConnectionScope(null, "hub", Mock.Of<TokenCredential>(), TransportType.AmqpTcp, null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheEventHubName()
        {
            Assert.That(() => new AmqpConnectionScope(new Uri("amqp://some.place.com"), null, Mock.Of<TokenCredential>(), TransportType.AmqpWebSockets, Mock.Of<IWebProxy>()), Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheCredential()
        {
            Assert.That(() => new AmqpConnectionScope(new Uri("amqp://some.place.com"), "hub", null, TransportType.AmqpWebSockets, null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheTransport()
        {
            var invalidTransport = (TransportType)(-2);
            Assert.That(() => new AmqpConnectionScope(new Uri("amqp://some.place.com"), "hun", Mock.Of<TokenCredential>(), invalidTransport, Mock.Of<IWebProxy>()), Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public async Task ConstructorCreatesTheConnection()
        {
            var endpoint = new Uri("amqp://test.service.gov");
            var eventHub = "myHub";
            var credential = Mock.Of<TokenCredential>();
            var transport = TransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, eventHub, credential, transport, null, identifier)
            {
                CallBase = true
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<TransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection))
                .Verifiable();

            var connection = await GetActiveConnection(mockScope.Object).GetOrCreateAsync(TimeSpan.FromDays(1));
            Assert.That(connection, Is.SameAs(mockConnection), "The connection instance should have been returned");

            mockScope.VerifyAll();
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
            var credential = Mock.Of<TokenCredential>();
            var transport = TransportType.AmqpTcp;
            var identifier = "customIdentIFIER";

            using var scope = new AmqpConnectionScope(endpoint, eventHub, credential, transport, null, identifier);

            var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => scope.OpenManagementLinkAsync(TimeSpan.FromDays(1), cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
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
            var credential = Mock.Of<TokenCredential>();
            var transport = TransportType.AmqpTcp;
            var identifier = "customIdentIFIER";

            var scope = new AmqpConnectionScope(endpoint, eventHub, credential, transport, null, identifier);
            scope.Dispose();

            Assert.That(() => scope.OpenManagementLinkAsync(TimeSpan.FromDays(1), CancellationToken.None), Throws.InstanceOf<ObjectDisposedException>());
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
            var credential = Mock.Of<TokenCredential>();
            var transport = TransportType.AmqpTcp;
            var identifier = "customIdentIFIER";
            var cancellationSource = new CancellationTokenSource();
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, eventHub, credential, transport, null, identifier)
            {
                CallBase = true
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == endpoint),
                    ItExpr.Is<TransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection))
                .Verifiable();

            mockScope
                .Protected()
                .Setup<Task<RequestResponseAmqpLink>>("OpenManagementLinkAsync",
                    ItExpr.Is<AmqpConnection>(value => value == mockConnection),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.Is<CancellationToken>(value => value == cancellationSource.Token))
                .Returns(Task.FromResult(default(RequestResponseAmqpLink)))
                .Verifiable();

            var link = await mockScope.Object.OpenManagementLinkAsync(TimeSpan.FromDays(1), cancellationSource.Token);
            Assert.That(link, Is.Null, "The mock return was null");

            mockScope.VerifyAll();
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
    }
}
