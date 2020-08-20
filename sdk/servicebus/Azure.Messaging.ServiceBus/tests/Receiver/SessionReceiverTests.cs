// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
                GetMockedConnection(),
                "fakeQueue",
                options: new ServiceBusSessionReceiverOptions(),
                plugins: new ServiceBusPlugin[] { });

            Assert.That(async () => await receiver.RenewMessageLockAsync(
                new ServiceBusReceivedMessage()),
                Throws.InstanceOf<InvalidOperationException>());
        }
    }
}
