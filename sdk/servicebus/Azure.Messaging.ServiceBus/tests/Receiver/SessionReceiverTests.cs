// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Amqp;
using Azure.Messaging.ServiceBus.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Receiver
{
    public class SessionReceiverTests
    {
        [Test]
        public async Task PurgeMessagesUsesFixedCutoffUntilServiceReturnsZero()
        {
            var timestamps = new List<DateTimeOffset>();
            var requestedCounts = new List<int>();
            var deleteCounts = new Queue<int>(new[] { 500, 2, 0 });
            var transport = new Mock<TransportReceiver>();

            transport
                .Setup(receiver => receiver.DeleteMessagesAsync(
                    It.IsAny<int>(),
                    It.IsAny<DateTimeOffset>(),
                    It.IsAny<CancellationToken>()))
                .Returns<int, DateTimeOffset, CancellationToken>((count, timestamp, _) =>
                {
                    requestedCounts.Add(count);
                    timestamps.Add(timestamp);
                    return Task.FromResult(deleteCounts.Dequeue());
                });

            var receiver = new ServiceBusSessionReceiver(
                ServiceBusTestUtilities.GetMockedReceiverConnection(transport),
                "fakeQueue",
                options: new ServiceBusSessionReceiverOptions(),
                cancellationToken: CancellationToken.None,
                sessionId: "sessionId");

            var result = await receiver.PurgeMessagesAsync();

            Assert.That(result.DeletedCount, Is.EqualTo(502));
            Assert.That(requestedCounts, Is.EqualTo(new[] { 500, 500, 500 }));
            Assert.That(timestamps, Has.Count.EqualTo(3));
            Assert.That(timestamps, Is.All.EqualTo(timestamps[0]));
        }

        [Test]
        public void SessionReceiverCannotPerformMessageLock()
        {
            var receiver = new ServiceBusSessionReceiver(
                ServiceBusTestUtilities.GetMockedReceiverConnection(),
                "fakeQueue",
                options: new ServiceBusSessionReceiverOptions(),
                cancellationToken: CancellationToken.None);

            Assert.That(async () => await receiver.RenewMessageLockAsync(
                new ServiceBusReceivedMessage()),
                Throws.InstanceOf<InvalidOperationException>());
        }

        /// <summary>
        ///   Verifies that the receiver reports the non-exclusive mode and surfaces the token the transport was
        ///   assigned. The token is held as a <see cref="Guid"/> by the transport and reported as a string, so the
        ///   round trip back through <see cref="ServiceBusSessionReceiverOptions.SessionLockToken"/> is asserted here
        ///   rather than left to the live tests, which cannot run until the service feature is deployed.
        /// </summary>
        ///
        [Test]
        public void NonExclusiveSessionReceiverSurfacesTheTransportModeAndToken()
        {
            var token = Guid.NewGuid();
            var transport = new Mock<TransportReceiver>();
            transport.Setup(inner => inner.IsSessionExclusive).Returns(false);
            transport.Setup(inner => inner.SessionLockToken).Returns(token);

            var receiver = new ServiceBusSessionReceiver(
                ServiceBusTestUtilities.GetMockedReceiverConnection(transport),
                "fakeQueue",
                options: new ServiceBusSessionReceiverOptions(),
                cancellationToken: CancellationToken.None);

            Assert.That(receiver.IsSessionExclusive, Is.False, "The receiver should report the mode the transport established.");
            Assert.That(receiver.SessionLockToken, Is.EqualTo(token.ToString()), "The receiver should report the assigned token as a string.");
            Assert.That(Guid.Parse(receiver.SessionLockToken), Is.EqualTo(token), "The reported token must round-trip back to the Guid the options accept.");
        }

        /// <summary>
        ///   Verifies the other half: an exclusive session carries no lock token, so the receiver reports null rather
        ///   than a string. This is the case that exercises the null branch of the conversion. The transport is
        ///   verified as having been consulted, because asserting only the values would also pass against a receiver
        ///   that returned the exclusive defaults without reading the transport at all.
        /// </summary>
        ///
        [Test]
        public void ExclusiveSessionReceiverReportsNoLockToken()
        {
            var transport = new Mock<TransportReceiver>();
            transport.Setup(inner => inner.IsSessionExclusive).Returns(true);
            transport.Setup(inner => inner.SessionLockToken).Returns((Guid?)null);

            var receiver = new ServiceBusSessionReceiver(
                ServiceBusTestUtilities.GetMockedReceiverConnection(transport),
                "fakeQueue",
                options: new ServiceBusSessionReceiverOptions(),
                cancellationToken: CancellationToken.None);

            Assert.That(receiver.IsSessionExclusive, Is.True, "The receiver should report the exclusive mode the transport established.");
            Assert.That(receiver.SessionLockToken, Is.Null, "An exclusive session has no token, so the receiver should report null.");

            transport.VerifyGet(inner => inner.IsSessionExclusive, Times.AtLeastOnce, "The mode must be read from the transport rather than assumed.");
            transport.VerifyGet(inner => inner.SessionLockToken, Times.AtLeastOnce, "The token must be read from the transport rather than assumed.");
        }

        /// <summary>
        ///   Verifies the seam that gives <see cref="ServiceBusSessionReceiverOptions.EnableNonExclusiveSession"/> its
        ///   effect: the values the caller set must reach the transport. Without this, a regression that stops passing
        ///   them silently disables the whole feature while every other test still passes, because the live tests that
        ///   would catch it cannot run until the service change is deployed.
        /// </summary>
        ///
        [Test]
        public void NonExclusiveSessionOptionsReachTheTransport()
        {
            var token = Guid.NewGuid();
            var mockConnection = ServiceBusTestUtilities.CreateMockConnection();
            var capturedExclusive = true;
            Guid? capturedToken = null;

            mockConnection
                .Setup(connection => connection.CreateTransportReceiver(
                    It.IsAny<string>(),
                    It.IsAny<ServiceBusRetryPolicy>(),
                    It.IsAny<ServiceBusReceiveMode>(),
                    It.IsAny<uint>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<Guid?>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, ServiceBusRetryPolicy, ServiceBusReceiveMode, uint, string, string, bool, bool, bool, Guid?, CancellationToken>(
                    (_, _, _, _, _, _, _, isSessionExclusive, _, sessionLockToken, _) =>
                    {
                        capturedExclusive = isSessionExclusive;
                        capturedToken = sessionLockToken;
                    })
                .Returns(new Mock<TransportReceiver>().Object);

            var options = new ServiceBusSessionReceiverOptions
            {
                EnableNonExclusiveSession = true,
                SessionLockToken = token
            };

            _ = new ServiceBusSessionReceiver(
                mockConnection.Object,
                "fakeQueue",
                options: options,
                cancellationToken: CancellationToken.None);

            Assert.That(capturedExclusive, Is.False, "Enabling the non-exclusive session must reach the transport as a non-exclusive request.");
            Assert.That(capturedToken, Is.EqualTo(token), "The token the caller supplied must reach the transport so the takeover can be requested.");
        }

        [Test]
        public async Task GetSessionStateAsyncValidatesClientIsNotDisposed()
        {
            await using var client = new ServiceBusClient("not.real.com", Mock.Of<TokenCredential>());
            await using var receiver = new ServiceBusSessionReceiver(client.Connection, "fake", default, CancellationToken.None);

            await client.DisposeAsync();
            Assert.That(async () => await receiver.GetSessionStateAsync(),
                Throws.InstanceOf<ObjectDisposedException>().And.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(nameof(ServiceBusConnection)));
        }

        [Test]
        public async Task SetSessionStateAsyncValidatesClientIsNotDisposed()
        {
            await using var client = new ServiceBusClient("not.real.com", Mock.Of<TokenCredential>());
            await using var receiver = new ServiceBusSessionReceiver(client.Connection, "fake", default, CancellationToken.None);

            await client.DisposeAsync();
            Assert.That(async () => await receiver.SetSessionStateAsync(new BinaryData("new!")),
                Throws.InstanceOf<ObjectDisposedException>().And.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(nameof(ServiceBusConnection)));
        }

        [Test]
        public async Task CallingCloseAsyncUpdatesIsClosed()
        {
            var account = Encoding.Default.GetString(ServiceBusTestUtilities.GetRandomBuffer(12));
            var fullyQualifiedNamespace = new UriBuilder($"{account}.servicebus.windows.net/").Host;
            var client = new ServiceBusClient(fullyQualifiedNamespace, Mock.Of<TokenCredential>());
            var receiver = new ServiceBusSessionReceiver(client.Connection, "fake", default, CancellationToken.None);
            await receiver.CloseAsync();
            Assert.IsTrue(receiver.IsClosed);

            Assert.IsTrue(((AmqpReceiver)receiver.InnerReceiver).RequestResponseLockedMessages.IsDisposed);
        }

        [Test]
        public void SessionReceiverOptionsDefaultToExclusiveLocking()
        {
            var options = new ServiceBusSessionReceiverOptions();
            Assert.That(options.EnableNonExclusiveSession, Is.False, "Sessions should be locked exclusively by default.");
            Assert.That(options.SessionLockToken, Is.Null, "No session lock token should be set by default.");
        }

        [Test]
        public void SessionReceiverOptionsCarryNonExclusiveValuesToReceiverOptions()
        {
            var token = Guid.NewGuid();
            var options = new ServiceBusSessionReceiverOptions
            {
                EnableNonExclusiveSession = true,
                SessionLockToken = token
            };

            var receiverOptions = options.ToReceiverOptions();
            Assert.That(receiverOptions.IsSessionExclusive, Is.False, "The non-exclusive flag should be carried to the receiver options.");
            Assert.That(receiverOptions.SessionLockToken, Is.EqualTo(token), "The session lock token should be carried to the receiver options.");
        }

        [Test]
        public async Task AcceptSessionThrowsWhenLockTokenSuppliedInExclusiveMode()
        {
            await using var client = new ServiceBusClient("not.real.com", Mock.Of<TokenCredential>());
            var options = new ServiceBusSessionReceiverOptions { SessionLockToken = Guid.NewGuid() };

            // A lock token can only be presented when taking over a non-exclusive session; supplying it while
            // EnableNonExclusiveSession is false (the default) is invalid.
            Assert.That(async () => await client.AcceptSessionAsync("queue", "sessionId", options),
                Throws.InstanceOf<ArgumentException>().And.Message.Contains("EnableNonExclusiveSession"));
        }

        [Test]
        public async Task AcceptNextSessionThrowsWhenLockTokenSupplied()
        {
            await using var client = new ServiceBusClient("not.real.com", Mock.Of<TokenCredential>());
            var options = new ServiceBusSessionReceiverOptions
            {
                EnableNonExclusiveSession = true,
                SessionLockToken = Guid.NewGuid()
            };

            // Taking over a session by presenting a lock token requires accepting a specific session; it cannot
            // be combined with accepting the next available session.
            Assert.That(async () => await client.AcceptNextSessionAsync("queue", options),
                Throws.InstanceOf<ArgumentException>().And.Message.Contains("specific session"));
        }

        [Test]
        public async Task AcceptNextSessionAllowsNonExclusiveWithoutSessionId()
        {
            await using var client = new ServiceBusClient("not.real.com", Mock.Of<TokenCredential>());
            var options = new ServiceBusSessionReceiverOptions { EnableNonExclusiveSession = true };
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            // Accepting the next available session is valid in non-exclusive mode: the service assigns both the
            // session and the lock token, so no specific session has to be targeted client-side. Cancelling the
            // token up front lets the assertion distinguish the two outcomes: the call clears synchronous
            // client-side validation and reaches cancellation, so an ArgumentException here would mean validation
            // rejected the combination.
            Assert.That(async () => await client.AcceptNextSessionAsync("queue", options, cts.Token),
                Throws.InstanceOf<OperationCanceledException>());
        }
    }
}
