// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Amqp;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Receiver
{
    public class SessionReceiverTests
    {
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
            Assert.That(options.IsSessionExclusive, Is.True, "Sessions should be locked exclusively by default.");
            Assert.That(options.SessionLockToken, Is.Null, "No session lock token should be set by default.");
        }

        [Test]
        public void SessionReceiverOptionsCarryNonExclusiveValuesToReceiverOptions()
        {
            var token = Guid.NewGuid();
            var options = new ServiceBusSessionReceiverOptions
            {
                IsSessionExclusive = false,
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
            // IsSessionExclusive is true (the default) is invalid.
            Assert.That(async () => await client.AcceptSessionAsync("queue", "sessionId", options),
                Throws.InstanceOf<ArgumentException>().And.Message.Contains("IsSessionExclusive"));
        }

        [Test]
        public async Task AcceptNextSessionThrowsWhenLockTokenSupplied()
        {
            await using var client = new ServiceBusClient("not.real.com", Mock.Of<TokenCredential>());
            var options = new ServiceBusSessionReceiverOptions
            {
                IsSessionExclusive = false,
                SessionLockToken = Guid.NewGuid()
            };

            // Taking over a session by presenting a lock token requires accepting a specific session; it cannot
            // be combined with accepting the next available session.
            Assert.That(async () => await client.AcceptNextSessionAsync("queue", options),
                Throws.InstanceOf<ArgumentException>().And.Message.Contains("specific session"));
        }

        [Test]
        public async Task AcceptNextSessionThrowsWhenNonExclusiveWithoutToken()
        {
            await using var client = new ServiceBusClient("not.real.com", Mock.Of<TokenCredential>());
            var options = new ServiceBusSessionReceiverOptions { IsSessionExclusive = false };

            // Non-exclusive locking is by-sessionId accept only; it cannot be combined with accepting the next
            // available session, even without a takeover token.
            Assert.That(async () => await client.AcceptNextSessionAsync("queue", options),
                Throws.InstanceOf<ArgumentException>().And.Message.Contains("next available"));
        }
    }
}
