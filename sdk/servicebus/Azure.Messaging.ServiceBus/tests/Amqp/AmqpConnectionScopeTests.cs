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
using Azure.Messaging.ServiceBus.Amqp.Framing;
using Azure.Messaging.ServiceBus.Authorization;
using Azure.Messaging.ServiceBus.Core;
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
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.OpenReceiverLinkAsync(string, string, TimeSpan, uint, ServiceBusReceiveMode, string, bool, bool, System.Guid?, CancellationToken)" />
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

            var link = await mockScope.Object.OpenReceiverLinkAsync(linkIdentifier, "fake/path", TimeSpan.FromDays(1), 100, ServiceBusReceiveMode.ReceiveAndDelete, "0", false, cancellationToken: cancellationSource.Token);
            Assert.That(link, Is.Not.Null, "The link produced was null");
            Assert.That(link.Settings.Target.ToString(), Contains.Substring(linkIdentifier));
        }

        /// <summary>
        ///   Verifies that <see cref="AmqpConnectionScope.OpenReceiverLinkAsync" /> adds a single composite
        ///   non-exclusive session filter (carrying both the session id and the supplied lock token) to the
        ///   receive link source, and omits the plain session filter, when a non-exclusive session takeover
        ///   is requested.
        /// </summary>
        ///
        [Test]
        public async Task OpenReceiverLinkAddsNonExclusiveSessionFilters()
        {
            var sessionLockToken = Guid.NewGuid();
            var mockScope = CreateMockReceiverScope();
            using var cancellationSource = new CancellationTokenSource();

            var link = await mockScope.Object.OpenReceiverLinkAsync(
                "MyAmqpConnectionScope",
                "fake/path",
                TimeSpan.FromDays(1),
                100,
                ServiceBusReceiveMode.PeekLock,
                "sessionId",
                isSessionReceiver: true,
                isSessionExclusive: false,
                sessionLockToken: sessionLockToken,
                cancellationToken: cancellationSource.Token);

            var filterSet = ((Microsoft.Azure.Amqp.Framing.Source)link.Settings.Source).FilterSet;
            Assert.That(filterSet.TryGetValue<AmqpNonExclusiveSessionFilterCodec>(AmqpClientConstants.NonExclusiveSessionFilterName, out var nonExclusiveFilter), Is.True, "The non-exclusive session filter should be present.");
            Assert.That(nonExclusiveFilter.SessionId, Is.EqualTo("sessionId"), "The composite filter should carry the session id.");
            Assert.That(nonExclusiveFilter.LockToken, Is.EqualTo(sessionLockToken), "The composite filter should carry the supplied lock token.");
            Assert.That(filterSet.TryGetValue<string>(AmqpClientConstants.SessionFilterName, out _), Is.False, "The plain session filter should be omitted for a non-exclusive session.");

            // The link name is built from the source, which renders the filter set, and it reaches the event source and
            // the associated-link-name on every management request. Assert on the link name itself rather than only on
            // the codec, so that a change to either one re-opens this leak loudly.
            Assert.That(link.Settings.LinkName, Does.Not.Contain(sessionLockToken.ToString()), "The lock token must not reach the link name, which is logged.");
        }

        /// <summary>
        ///   Verifies that <see cref="AmqpConnectionScope.OpenReceiverLinkAsync" /> omits the non-exclusive
        ///   session filters for a standard (exclusive) session receiver, preserving back-compatibility with
        ///   services that predate the non-exclusive session feature.
        /// </summary>
        ///
        [Test]
        public async Task OpenReceiverLinkUsesPlainSessionFilterWhenExclusive()
        {
            var mockScope = CreateMockReceiverScope();
            using var cancellationSource = new CancellationTokenSource();

            var link = await mockScope.Object.OpenReceiverLinkAsync(
                "MyAmqpConnectionScope",
                "fake/path",
                TimeSpan.FromDays(1),
                100,
                ServiceBusReceiveMode.PeekLock,
                "sessionId",
                isSessionReceiver: true,
                cancellationToken: cancellationSource.Token);

            var filterSet = ((Microsoft.Azure.Amqp.Framing.Source)link.Settings.Source).FilterSet;
            Assert.That(filterSet.TryGetValue<string>(AmqpClientConstants.SessionFilterName, out _), Is.True, "The session filter should still be present for an exclusive session.");
            Assert.That(filterSet.TryGetValue<AmqpNonExclusiveSessionFilterCodec>(AmqpClientConstants.NonExclusiveSessionFilterName, out _), Is.False, "The non-exclusive session filter should be absent for an exclusive session.");
        }

        /// <summary>
        ///   Verifies that <see cref="AmqpConnectionScope.OpenReceiverLinkAsync" /> adds the composite non-exclusive
        ///   session filter with a null lock token for a fresh non-exclusive acquire (the first holder presents no token).
        /// </summary>
        ///
        [Test]
        public async Task OpenReceiverLinkAddsCompositeFilterWithoutTokenForFreshNonExclusiveSession()
        {
            var mockScope = CreateMockReceiverScope();
            using var cancellationSource = new CancellationTokenSource();

            var link = await mockScope.Object.OpenReceiverLinkAsync(
                "MyAmqpConnectionScope",
                "fake/path",
                TimeSpan.FromDays(1),
                100,
                ServiceBusReceiveMode.PeekLock,
                "sessionId",
                isSessionReceiver: true,
                isSessionExclusive: false,
                sessionLockToken: null,
                cancellationToken: cancellationSource.Token);

            var filterSet = ((Microsoft.Azure.Amqp.Framing.Source)link.Settings.Source).FilterSet;
            Assert.That(filterSet.TryGetValue<AmqpNonExclusiveSessionFilterCodec>(AmqpClientConstants.NonExclusiveSessionFilterName, out var nonExclusiveFilter), Is.True, "The non-exclusive session filter should be present for a fresh acquire.");
            Assert.That(nonExclusiveFilter.SessionId, Is.EqualTo("sessionId"), "The composite filter should carry the session id.");
            Assert.That(nonExclusiveFilter.LockToken, Is.Null, "No token should be present when none is presented.");
        }

        /// <summary>
        ///   Creates a mocked <see cref="AmqpConnectionScope" /> with the transport, authorization, and link
        ///   open operations stubbed so that <see cref="AmqpConnectionScope.OpenReceiverLinkAsync" /> can be
        ///   exercised without a live connection.
        /// </summary>
        ///
        /// <param name="assignedSessionLockToken">When set, the attach echoes back a non-exclusive session filter carrying this token.</param>
        /// <param name="attachFailure">When set, the attach fails with this exception, simulating an endpoint that refuses the link.</param>
        ///
        /// <returns>A scope whose receiver link attach behaves as requested.</returns>
        ///
        internal static Mock<AmqpConnectionScope> CreateMockReceiverScope(
            Guid? assignedSessionLockToken = null,
            Exception attachFailure = null)
        {
            var credential = new Mock<ServiceBusTokenCredential>(Mock.Of<TokenCredential>());
            var endpoint = new Uri("amqp://mine.hubs.com");
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());

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
                .Callback(new InvocationAction(invocation =>
                {
                    if (attachFailure != null)
                    {
                        throw attachFailure;
                    }

                    // Simulate the service honoring the non-exclusive session on attach: echo back the composite
                    // non-exclusive session filter carrying the assigned session id and lock token, so the receiver's
                    // non-exclusive read can be exercised without a live link.
                    if (assignedSessionLockToken.HasValue)
                    {
                        var openedLink = (ReceivingAmqpLink)invocation.Arguments[0];
                        ((Microsoft.Azure.Amqp.Framing.Source)openedLink.Settings.Source).FilterSet[AmqpClientConstants.NonExclusiveSessionFilterName] =
                            new AmqpNonExclusiveSessionFilterCodec { SessionId = "sessionId", LockToken = assignedSessionLockToken.Value };
                    }

                    typeof(AmqpObject)
                        .GetProperty(nameof(AmqpObject.State), BindingFlags.Instance | BindingFlags.Public)
                        .GetSetMethod(true)
                        .Invoke(invocation.Arguments[0], new object[] { AmqpObjectState.Opened });
                }))
                .Returns(Task.CompletedTask)
                .Verifiable();

            return mockScope;
        }

        internal static RequestResponseAmqpLink CreateRequestResponseLink()
        {
            var mockConnection = new AmqpConnection(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            var mockSession = new AmqpSession(mockConnection, new AmqpSessionSettings(), Mock.Of<ILinkFactory>());
            return new RequestResponseAmqpLink("request-response-link", mockSession, "address", null);
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
