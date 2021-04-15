// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Amqp;
using Azure.Messaging.ServiceBus.Authorization;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Transport;
using Moq;
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
        ///   Verifies functionality of the <see cref="AmqpConnectionScope.CalculateLinkAuthorizationRefreshInterval" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CalculateLinkAuthorizationRefreshIntervalRespectsTheRefreshBuffer()
        {
            var credential = new Mock<ServiceBusTokenCredential>(Mock.Of<TokenCredential>());
            var mockScope = new MockConnectionMockScope(new Uri("sb://mine.hubs.com"), credential.Object, ServiceBusTransportType.AmqpTcp, null);
            var currentTime = new DateTime(2015, 10, 27, 00, 00, 00);
            var expireTime = currentTime.AddHours(1);
            var buffer = GetAuthorizationRefreshBuffer();
            var calculatedRefresh = mockScope.InvokeCalculateLinkAuthorizationRefreshInterval(expireTime, currentTime);
            var calculatedExpire = currentTime.Add(calculatedRefresh);

            Assert.That(calculatedExpire, Is.LessThan(expireTime), "The refresh should be account for the buffer and be earlier than expiration.");
            Assert.That(calculatedExpire, Is.EqualTo(expireTime.Subtract(buffer)).Within(TimeSpan.FromSeconds(2)), "The authorization buffer should have been used for buffering.");
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
            var mockScope = new MockConnectionMockScope(new Uri("sb://mine.hubs.com"), credential.Object, ServiceBusTransportType.AmqpTcp, null);
            var currentTime = new DateTime(2015, 10, 27, 00, 00, 00);
            var minimumRefresh = GetMinimumAuthorizationRefresh();
            var expireTime = currentTime.Add(minimumRefresh.Subtract(TimeSpan.FromMilliseconds(500)));
            var calculatedRefresh = mockScope.InvokeCalculateLinkAuthorizationRefreshInterval(expireTime, currentTime);

            Assert.That(calculatedRefresh, Is.EqualTo(minimumRefresh), "The minimum refresh duration should have been used.");
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
            var mockScope = new MockConnectionMockScope(new Uri("sb://mine.hubs.com"), credential.Object, ServiceBusTransportType.AmqpTcp, null);
            var currentTime = new DateTime(2015, 10, 27, 00, 00, 00);
            var refreshBuffer = GetAuthorizationRefreshBuffer();
            var maximumRefresh = GetMaximumAuthorizationRefresh();
            var expireTime = currentTime.Add(maximumRefresh.Add(refreshBuffer).Add(TimeSpan.FromMilliseconds(500)));
            var calculatedRefresh = mockScope.InvokeCalculateLinkAuthorizationRefreshInterval(expireTime, currentTime);

            Assert.That(calculatedRefresh, Is.EqualTo(maximumRefresh), "The maximum refresh duration should have been used.");
        }

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
        private class MockConnectionMockScope : AmqpConnectionScope
        {
            public readonly Mock<AmqpConnection> MockConnection;

            public MockConnectionMockScope(
                Uri serviceEndpoint,
                ServiceBusTokenCredential credential,
                ServiceBusTransportType transport,
                IWebProxy proxy) : base(serviceEndpoint, credential, transport, proxy, false)
            {
                MockConnection = new Mock<AmqpConnection>(new MockTransport(), CreateMockAmqpSettings(), new AmqpConnectionSettings());
            }

            public TimeSpan InvokeCalculateLinkAuthorizationRefreshInterval(
                DateTime expirationTimeUtc,
                DateTime currentTimeUtc) => base.CalculateLinkAuthorizationRefreshInterval(expirationTimeUtc, currentTimeUtc);
        }
    }
}
