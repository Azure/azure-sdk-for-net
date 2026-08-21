// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Amqp;
using Azure.Messaging.ServiceBus.Authorization;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Transport;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
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
        public void ConstructorValidatesTheIdleTimeout()
        {
            var endpoint = new Uri("amqp://some.place.com");
            var credential = new Mock<ServiceBusTokenCredential>(Mock.Of<TokenCredential>());
            Assert.That(() => new AmqpConnectionScope(endpoint, endpoint, credential.Object, ServiceBusTransportType.AmqpTcp, null, false, default, TimeSpan.FromMilliseconds(-1)), Throws.InstanceOf<ArgumentOutOfRangeException>());
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
            var credential = new Mock<ServiceBusTokenCredential>(Mock.Of<TokenCredential>());
            var transport = ServiceBusTransportType.AmqpTcp;
            var idleTimeout = TimeSpan.FromSeconds(30);
            var operationTimeout = TimeSpan.FromSeconds(30);
            var useSingleSession = true;
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());

            var mockScope = new Mock<AmqpConnectionScope>(serviceEndpoint, connectionEndpoint, credential.Object, transport, null, useSingleSession, operationTimeout, idleTimeout, certCallback)
            {
                CallBase = true
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.Is<Uri>(value => value == serviceEndpoint),
                    ItExpr.Is<Uri>(value => value == connectionEndpoint),
                    ItExpr.Is<ServiceBusTransportType>(value => value == transport),
                    ItExpr.Is<IWebProxy>(value => value == null),
                    ItExpr.Is<RemoteCertificateValidationCallback>(value => ReferenceEquals(value, certCallback)),
                    ItExpr.Is<string>(value => (!string.IsNullOrEmpty(value))),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection))
                .Verifiable();

            AmqpConnection connection = await GetActiveConnection(mockScope.Object).GetOrCreateAsync(TimeSpan.FromDays(1));
            Assert.That(connection, Is.SameAs(mockConnection), "The connection instance should have been returned");

            mockScope.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.CalculateLinkAuthorizationRefreshInterval" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CalculateLinkAuthorizationRefreshIntervalRespectsTheRefreshBuffer()
        {
            var credential = new Mock<ServiceBusTokenCredential>(Mock.Of<TokenCredential>());
            var endpoint = new Uri("sb://mine.hubs.com");
            var mockScope = new MockConnectionScope(endpoint, endpoint, credential.Object, ServiceBusTransportType.AmqpTcp, null);
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
            var credential = new Mock<ServiceBusTokenCredential>(Mock.Of<TokenCredential>());
            var endpoint = new Uri("sb://mine.hubs.com");
            var mockScope = new MockConnectionScope(endpoint, endpoint, credential.Object, ServiceBusTransportType.AmqpTcp, null);
            var currentTime = new DateTime(2015, 10, 27, 00, 00, 00);
            var jitterBuffer = TimeSpan.FromSeconds(GetAuthorizationBaseJitterSeconds()).Add(TimeSpan.FromSeconds(5));
            var minimumRefresh = GetMinimumAuthorizationRefresh();
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
            var credential = new Mock<ServiceBusTokenCredential>(Mock.Of<TokenCredential>());
            var endpoint = new Uri("sb://mine.hubs.com");
            var mockScope = new MockConnectionScope(endpoint, endpoint, credential.Object, ServiceBusTransportType.AmqpTcp, null);
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
            var transport = ServiceBusTransportType.AmqpTcp;
            var mockCredential = new Mock<TokenCredential>();
            var mockServiceBusCredential = new Mock<ServiceBusTokenCredential>(mockCredential.Object);
            var mockScope = new MockConnectionScope(endpoint, endpoint, mockServiceBusCredential.Object, transport, null);

            mockScope.MockConnection
                .Protected()
                .Setup("OpenInternal")
                .Throws(openException)
                .Verifiable();

            try
            {
                await mockScope.InvokeOpenAmqpObjectAsync(mockScope.MockConnection.Object, TimeSpan.FromMinutes(5));
            }
            catch (Exception ex)
            {
                observedException = ex;
            }

            Assert.That(observedException, Is.Not.Null, "An exception should have been observed.");
            Assert.That(observedException, Is.TypeOf<ServiceBusException>(), "The exception should have been translated.");
            Assert.That(((ServiceBusException)observedException).IsTransient, Is.True, "The exception should be transient.");

            mockScope.MockConnection.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenSenderLinkAsync(string, string, TimeSpan, CancellationToken)" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OpenLinkAssociatesSendLinkSource()
        {
            var credential = new Mock<ServiceBusTokenCredential>(Mock.Of<TokenCredential>());
            var endpoint = new Uri("amqp://mine.hubs.com");
            var linkIdentifier = "MyAmqpConnectionScope";
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var cancellationSource = new CancellationTokenSource();
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, endpoint, credential.Object, ServiceBusTransportType.AmqpTcp, null, false, default, default, default)
            {
                CallBase = true,
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                    ItExpr.IsAny<Version>(),
                    ItExpr.IsAny<Uri>(),
                    ItExpr.IsAny<Uri>(),
                    ItExpr.IsAny<ServiceBusTransportType>(),
                    ItExpr.IsAny<IWebProxy>(),
                    ItExpr.IsAny<RemoteCertificateValidationCallback>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection))
                .Verifiable();

            mockScope
                .Protected()
                .Setup<Task<DateTime>>("RequestAuthorizationUsingCbsAsync",
                    ItExpr.IsAny<AmqpConnection>(),
                    ItExpr.IsAny<CbsTokenProvider>(),
                    ItExpr.IsAny<Uri>(),
                    ItExpr.IsAny<string[]>(),
                    ItExpr.IsAny<string[]>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<string>())
                .Returns(Task.FromResult(DateTime.UtcNow.AddDays(1)))
                .Verifiable();

            mockScope
                .Protected()
                .Setup<Task>("OpenAmqpObjectAsync",
                    ItExpr.IsAny<AmqpObject>(),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.CompletedTask)
                .Verifiable();

            mockScope
                .Protected()
                .Setup<Task>("OpenAmqpLinkAsync",
                    ItExpr.IsAny<SendingAmqpLink>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask)
                .Verifiable();

            var link = await mockScope.Object.OpenSenderLinkAsync("fake/path", linkIdentifier, TimeSpan.FromDays(1), cancellationSource.Token);
            Assert.That(link, Is.Not.Null, "The link produced was null");
            Assert.That(link.Settings.Source.ToString(), Contains.Substring(linkIdentifier));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenReceiverLinkAsync(string, string, TimeSpan, uint, ServiceBusReceiveMode, string, bool, CancellationToken)" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OpenLinkAssociatesReceiveLinkTarget()
        {
            var credential = new Mock<ServiceBusTokenCredential>(Mock.Of<TokenCredential>());
            var endpoint = new Uri("amqp://mine.hubs.com");
            var linkIdentifier = "MyAmqpConnectionScope";
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var cancellationSource = new CancellationTokenSource();
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());

            var mockScope = new Mock<AmqpConnectionScope>(endpoint, endpoint, credential.Object, ServiceBusTransportType.AmqpTcp, null, false, default, default, default)
            {
                CallBase = true,
            };

            mockScope
                .Protected()
                .Setup<Task<AmqpConnection>>("CreateAndOpenConnectionAsync",
                ItExpr.IsAny<Version>(),
                ItExpr.IsAny<Uri>(),
                ItExpr.IsAny<Uri>(),
                ItExpr.IsAny<ServiceBusTransportType>(),
                ItExpr.IsAny<IWebProxy>(),
                ItExpr.IsAny<RemoteCertificateValidationCallback>(),
                ItExpr.IsAny<string>(),
                ItExpr.IsAny<TimeSpan>())
                .Returns(Task.FromResult(mockConnection))
                .Verifiable();

            mockScope
                .Protected()
                .Setup<Task<DateTime>>("RequestAuthorizationUsingCbsAsync",
                    ItExpr.IsAny<AmqpConnection>(),
                    ItExpr.IsAny<CbsTokenProvider>(),
                    ItExpr.IsAny<Uri>(),
                    ItExpr.IsAny<string[]>(),
                    ItExpr.IsAny<string[]>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<string>())
                .Returns(Task.FromResult(DateTime.UtcNow.AddDays(1)))
                .Verifiable();

            mockScope
                .Protected()
                .Setup<Task>("OpenAmqpObjectAsync",
                    ItExpr.IsAny<AmqpObject>(),
                    ItExpr.IsAny<TimeSpan>())
                .Returns(Task.CompletedTask)
                .Verifiable();

            mockScope
                .Protected()
                .Setup<Task>("OpenAmqpLinkAsync",
                    ItExpr.IsAny<ReceivingAmqpLink>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask)
                .Verifiable();

            var link = await mockScope.Object.OpenReceiverLinkAsync(linkIdentifier, "fake/path", TimeSpan.FromDays(1), 100, ServiceBusReceiveMode.ReceiveAndDelete, "0", false, cancellationSource.Token);
            Assert.That(link, Is.Not.Null, "The link produced was null");
            Assert.That(link.Settings.Target.ToString(), Contains.Substring(linkIdentifier));
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
        ///   Provides a mock to use with a mocked connection.
        /// </summary>
        ///
        private class MockConnectionScope : AmqpConnectionScope
        {
            public readonly Mock<AmqpConnection> MockConnection;

            public MockConnectionScope(
                Uri serviceEndpoint,
                Uri customConnectionEndpoint,
                ServiceBusTokenCredential credential,
                ServiceBusTransportType transport,
                IWebProxy proxy) : base(serviceEndpoint, customConnectionEndpoint, credential, transport, proxy, false, default, default)
            {
                MockConnection = new Mock<AmqpConnection>(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            }

            public Task InvokeOpenAmqpObjectAsync(
                AmqpObject target,
                TimeSpan timeout) =>
                base.OpenAmqpObjectAsync(target, timeout);

            public TimeSpan InvokeCalculateLinkAuthorizationRefreshInterval(
                DateTime expirationTimeUtc,
                DateTime currentTimeUtc) => base.CalculateLinkAuthorizationRefreshInterval(expirationTimeUtc, currentTimeUtc);

            protected override Task<AmqpConnection> CreateAndOpenConnectionAsync(Version amqpVersion,
                                                                                 Uri serviceEndpoint,
                                                                                 Uri connectionEndpoint,
                                                                                 ServiceBusTransportType transportType,
                                                                                 IWebProxy proxy,
                                                                                 RemoteCertificateValidationCallback certificateValidationCallback,
                                                                                 string scopeIdentifier,
                                                                                 TimeSpan timeout)
            {
                return Task.FromResult(MockConnection.Object);
            }
        }
    }
}
