﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Plugins;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Receiver
{
    public class SessionReceiverTests : ServiceBusTestBase
    {
        [Test]
        public void SessionReceiverCannotPerformMessageLock()
        {
            var receiver = new ServiceBusSessionReceiver(
                GetMockedReceiverConnection(),
                "fakeQueue",
                options: new ServiceBusSessionReceiverOptions(),
                plugins: new ServiceBusPlugin[] { },
                cancellationToken: CancellationToken.None);

            Assert.That(async () => await receiver.RenewMessageLockAsync(
                new ServiceBusReceivedMessage()),
                Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public async Task GetSessionStateAsyncValidatesClientIsNotDisposed()
        {
            await using var client = new ServiceBusClient("not.real.com", Mock.Of<TokenCredential>());
            await using var receiver = new ServiceBusSessionReceiver(client.Connection, "fake", default, default, CancellationToken.None);

            await client.DisposeAsync();
            Assert.That(async () => await receiver.GetSessionStateAsync(),
                Throws.InstanceOf<ObjectDisposedException>().And.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(nameof(ServiceBusConnection)));
        }

        [Test]
        public async Task SetSessionStateAsyncValidatesClientIsNotDisposed()
        {
            await using var client = new ServiceBusClient("not.real.com", Mock.Of<TokenCredential>());
            await using var receiver = new ServiceBusSessionReceiver(client.Connection, "fake", default, default, CancellationToken.None);

            await client.DisposeAsync();
            Assert.That(async () => await receiver.SetSessionStateAsync(new BinaryData("new!")),
                Throws.InstanceOf<ObjectDisposedException>().And.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(nameof(ServiceBusConnection)));
        }
    }
}
