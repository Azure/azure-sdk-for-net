﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Authorization;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Azure.Messaging.ServiceBus.Plugins;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Sender
{
    public class SenderTests : ServiceBusTestBase
    {
        [Test]
        public void SendNullMessageShouldThrow()
        {
            var mock = new Mock<ServiceBusSender>()
            {
                CallBase = true
            };
            Assert.ThrowsAsync<ArgumentNullException>(async () => await mock.Object.SendMessageAsync(null));
        }

        [Test]
        public void SendNullMessageListShouldThrow()
        {
            var mock = new Mock<ServiceBusSender>()
            {
                CallBase = true
            };
            Assert.ThrowsAsync<ArgumentNullException>(async () => await mock.Object.SendMessagesAsync(messages: null));
        }

        [Test]
        public async Task SendEmptyListShouldNotThrow()
        {
            var mock = new Mock<ServiceBusSender>("fake", new ServiceBusSenderOptions(), CreateMockConnection().Object, null)
            {
                CallBase = true
            };

            await mock.Object.SendMessagesAsync(new List<ServiceBusMessage>());
        }

        [Test]
        public async Task SendSingleDelegatesToSendList()
        {
           var mock = new Mock<ServiceBusSender>("fake", new ServiceBusSenderOptions(), CreateMockConnection().Object, null)
            {
                CallBase = true
            };

            mock
               .Setup(m => m.SendMessagesAsync(
                   It.Is<IEnumerable<ServiceBusMessage>>(value => value.Count() == 1),
                   It.IsAny<CancellationToken>()))
               .Returns(Task.CompletedTask)
               .Verifiable("The single send should delegate to the list send.");

            await mock.Object.SendMessageAsync(new ServiceBusMessage());
        }

        [Test]
        public void SendNullBatchShouldThrow()
        {
            var mock = new Mock<ServiceBusSender>()
            {
                CallBase = true
            };
            Assert.ThrowsAsync<ArgumentNullException>(async () => await mock.Object.SendMessagesAsync((ServiceBusMessageBatch)null));
        }

        [Test]
        public void ScheduleNullMessageShouldThrow()
        {
            var mock = new Mock<ServiceBusSender>()
            {
                CallBase = true
            };
            Assert.ThrowsAsync<ArgumentNullException>(async () => await mock.Object.ScheduleMessageAsync(null, default));
        }

        [Test]
        public void ScheduleNullMessageListShouldThrow()
        {
            var mock = new Mock<ServiceBusSender>()
            {
                CallBase = true
            };
            Assert.ThrowsAsync<ArgumentNullException>(async () => await mock.Object.ScheduleMessagesAsync(null, default));
        }

        [Test]
        public async Task ScheduleEmptyListShouldNotThrow()
        {
            var mock = new Mock<ServiceBusSender>("fake", new ServiceBusSenderOptions(), CreateMockConnection().Object, null)
            {
                CallBase = true
            };

            IReadOnlyList<long> sequenceNums = await mock.Object.ScheduleMessagesAsync(
                new List<ServiceBusMessage>(),
                default);
            Assert.IsEmpty(sequenceNums);
        }

        [Test]
        public void ClientProperties()
        {
            var account = Encoding.Default.GetString(GetRandomBuffer(12));
            var fullyQualifiedNamespace = new UriBuilder($"{account}.servicebus.windows.net/").Host;
            var connString = $"Endpoint=sb://{fullyQualifiedNamespace};SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey={Encoding.Default.GetString(GetRandomBuffer(64))}";
            var queueName = Encoding.Default.GetString(GetRandomBuffer(12));
            var sender = new ServiceBusClient(connString).CreateSender(queueName);
            Assert.AreEqual(queueName, sender.EntityPath);
            Assert.AreEqual(fullyQualifiedNamespace, sender.FullyQualifiedNamespace);
            Assert.IsNotNull(sender.Identifier);
        }

        [Test]
        public void CreateSenderUsingNullOptionsDoesNotThrow()
        {
            var account = Encoding.Default.GetString(GetRandomBuffer(12));
            var fullyQualifiedNamespace = new UriBuilder($"{account}.servicebus.windows.net/").Host;
            var connString = $"Endpoint=sb://{fullyQualifiedNamespace};SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey={Encoding.Default.GetString(GetRandomBuffer(64))}";
            var queueName = Encoding.Default.GetString(GetRandomBuffer(12));
            var client = new ServiceBusClient(connString);

            Assert.That(() => client.CreateSender(queueName, null), Throws.Nothing);
        }

        [Test]
        public async Task SendBatchManagesLockingTheBatch()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockTransportBatch = new Mock<TransportMessageBatch>();
            var mockScope = new EntityScopeFactory("mock", "mock");
            var batch = new ServiceBusMessageBatch(mockTransportBatch.Object, mockScope);
            var mockTransportSender = new Mock<TransportSender>();
            var mockConnection = CreateMockConnection();

            mockConnection
                .Setup(connection => connection.CreateTransportSender(It.IsAny<string>(), It.IsAny<ServiceBusRetryPolicy>(), It.IsAny<string>()))
                .Returns(mockTransportSender.Object);

            mockTransportBatch
                .Setup(transport => transport.TryAddMessage(It.IsAny<ServiceBusMessage>()))
                .Returns(true);

            mockTransportBatch
                .Setup(transport => transport.Count)
                .Returns(1);

            mockTransportSender
                .Setup(transport => transport.SendBatchAsync(It.IsAny<ServiceBusMessageBatch>(), It.IsAny<CancellationToken>()))
                .Returns(async () => await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token)));

            Assert.That(batch.TryAddMessage(new ServiceBusMessage(Array.Empty<byte>())), Is.True, "The batch should not be locked before sending.");

            var sender = new ServiceBusSender("dummy", null, mockConnection.Object, new ServiceBusPlugin[] { });
            var sendTask = sender.SendMessagesAsync(batch);

            Assert.That(() => batch.TryAddMessage(new ServiceBusMessage(Array.Empty<byte>())), Throws.InstanceOf<InvalidOperationException>(), "The batch should be locked while sending.");
            completionSource.TrySetResult(true);

            await sendTask;
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(batch.TryAddMessage(new ServiceBusMessage(Array.Empty<byte>())), Is.True, "The batch should not be locked after sending.");

            cancellationSource.Cancel();
        }

        [Test]
        public async Task CreateMessageBatchAsyncValidatesClientIsNotDisposed()
        {
            await using var client = new ServiceBusClient("not.real.com", Mock.Of<TokenCredential>());
            await using var sender = client.CreateSender("fake");

            await client.DisposeAsync();
            Assert.That(async () => await sender.CreateMessageBatchAsync(),
                Throws.InstanceOf<ObjectDisposedException>().And.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(nameof(ServiceBusConnection)));
        }

        [Test]
        public async Task SendMessageAsyncValidatesClientIsNotDisposed()
        {
            await using var client = new ServiceBusClient("not.real.com", Mock.Of<TokenCredential>());
            await using var sender = client.CreateSender("fake");

            await client.DisposeAsync();
            Assert.That(async () => await sender.SendMessageAsync(new ServiceBusMessage("test")),
                Throws.InstanceOf<ObjectDisposedException>().And.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(nameof(ServiceBusConnection)));
        }

        [Test]
        public async Task SendMessagesAsyncValidatesClientIsNotDisposed()
        {
            await using var client = new ServiceBusClient("not.real.com", Mock.Of<TokenCredential>());
            await using var sender = client.CreateSender("fake");

            using var batch = ServiceBusModelFactory.ServiceBusMessageBatch(4096, new List<ServiceBusMessage> { new ServiceBusMessage("test") });

            await client.DisposeAsync();
            Assert.That(async () => await sender.SendMessagesAsync(batch),
                Throws.InstanceOf<ObjectDisposedException>().And.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(nameof(ServiceBusConnection)));
        }

        [Test]
        public async Task ScheduleMessageAsyncValidatesClientIsNotDisposed()
        {
            await using var client = new ServiceBusClient("not.real.com", Mock.Of<TokenCredential>());
            await using var sender = client.CreateSender("fake");

            await client.DisposeAsync();
            Assert.That(async () => await sender.ScheduleMessageAsync(new ServiceBusMessage("test"), new DateTimeOffset(2015, 10, 27, 12, 0, 0, TimeSpan.Zero)),
                Throws.InstanceOf<ObjectDisposedException>().And.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(nameof(ServiceBusConnection)));
        }

        [Test]
        public async Task ScheduleMessagesAsyncValidatesClientIsNotDisposed()
        {
            await using var client = new ServiceBusClient("not.real.com", Mock.Of<TokenCredential>());
            await using var sender = client.CreateSender("fake");

            await client.DisposeAsync();
            Assert.That(async () => await sender.ScheduleMessagesAsync(new[] { new ServiceBusMessage("one"), new ServiceBusMessage("two") }, new DateTimeOffset(2015, 10, 27, 12, 0, 0, TimeSpan.Zero)),
                Throws.InstanceOf<ObjectDisposedException>().And.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(nameof(ServiceBusConnection)));
        }

        [Test]
        public async Task CancelScheduledMessageAsyncValidatesClientIsNotDisposed()
        {
            await using var client = new ServiceBusClient("not.real.com", Mock.Of<TokenCredential>());
            await using var sender = client.CreateSender("fake");

            await client.DisposeAsync();
            Assert.That(async () => await sender.CancelScheduledMessageAsync(12345),
                Throws.InstanceOf<ObjectDisposedException>().And.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(nameof(ServiceBusConnection)));
        }

        [Test]
        public async Task CancelScheduledMessagesAsyncValidatesClientIsNotDisposed()
        {
            await using var client = new ServiceBusClient("not.real.com", Mock.Of<TokenCredential>());
            await using var sender = client.CreateSender("fake");

            await client.DisposeAsync();
            Assert.That(async () => await sender.CancelScheduledMessagesAsync(new[] { 12345L, 678910L }),
                Throws.InstanceOf<ObjectDisposedException>().And.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(nameof(ServiceBusConnection)));
        }
    }
}
