// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Core;
using Moq;
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
            Assert.ThrowsAsync<ArgumentNullException>(async () => await mock.Object.SendAsync(message: null));
        }

        [Test]
        public void SendNullMessageListShouldThrow()
        {
            var mock = new Mock<ServiceBusSender>()
            {
                CallBase = true
            };
            Assert.ThrowsAsync<ArgumentNullException>(async () => await mock.Object.SendAsync(messages: null));
        }

        [Test]
        public async Task SendEmptyListShouldNotThrow()
        {
            var mock = new Mock<ServiceBusSender>()
            {
                CallBase = true
            };
            await mock.Object.SendAsync(new List<ServiceBusMessage>());
        }

        [Test]
        public async Task SendSingleDelegatesToSendList()
        {
            var mock = new Mock<ServiceBusSender>()
            {
                CallBase = true
            };
            mock
               .Setup(m => m.SendAsync(
                   It.Is<IEnumerable<ServiceBusMessage>>(value => value.Count() == 1),
                   It.IsAny<CancellationToken>()))
               .Returns(Task.CompletedTask)
               .Verifiable("The single send should delegate to the list send.");

            await mock.Object.SendAsync(new ServiceBusMessage());
        }

        [Test]
        public void SendNullBatchShouldThrow()
        {
            var mock = new Mock<ServiceBusSender>()
            {
                CallBase = true
            };
            Assert.ThrowsAsync<ArgumentNullException>(async () => await mock.Object.SendAsync((ServiceBusMessageBatch)null));
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
        public void CreateSenderUsingSendVia()
        {
            var account = Encoding.Default.GetString(GetRandomBuffer(12));
            var fullyQualifiedNamespace = new UriBuilder($"{account}.servicebus.windows.net/").Host;
            var connString = $"Endpoint=sb://{fullyQualifiedNamespace};SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey={Encoding.Default.GetString(GetRandomBuffer(64))}";
            var queueName = Encoding.Default.GetString(GetRandomBuffer(12));
            var client = new ServiceBusClient(connString);
            var sender = client.CreateSender(queueName,
                new ServiceBusSenderOptions
                {
                    ViaQueueOrTopicName = "sendViaName"
                });
        }

        [Test]
        public void CreateSenderUsingSendViaThrowsWhenEntityPath()
        {
            var account = Encoding.Default.GetString(GetRandomBuffer(12));
            var fullyQualifiedNamespace = new UriBuilder($"{account}.servicebus.windows.net/").Host;
            var connString = $"Endpoint=sb://{fullyQualifiedNamespace};SharedAccessKeyName=RootManageSharedAccessKey;EntityPath=something;SharedAccessKey={Encoding.Default.GetString(GetRandomBuffer(64))}";
            var queueName = Encoding.Default.GetString(GetRandomBuffer(12));
            var client = new ServiceBusClient(connString);
            Assert.That(() => client.CreateSender(queueName,
                new ServiceBusSenderOptions
                {
                    ViaQueueOrTopicName = "sendViaName"
                }),
                Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.CreateSender(queueName,
               new ServiceBusSenderOptions
               {
                   ViaQueueOrTopicName = queueName
               }),
               Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void CreateSenderUsingSendViaDoesNotThrowWhenSameEntityPath()
        {
            var account = Encoding.Default.GetString(GetRandomBuffer(12));
            var fullyQualifiedNamespace = new UriBuilder($"{account}.servicebus.windows.net/").Host;
            var connString = $"Endpoint=sb://{fullyQualifiedNamespace};SharedAccessKeyName=RootManageSharedAccessKey;EntityPath=something;SharedAccessKey={Encoding.Default.GetString(GetRandomBuffer(64))}";
            var client = new ServiceBusClient(connString);
            client.CreateSender("something",
                new ServiceBusSenderOptions
                {
                    ViaQueueOrTopicName = "something"
                });
        }

        [Test]
        public void CreateSenderUsingNullOptionsDoesNotThrow()
        {
            var account = Encoding.Default.GetString(GetRandomBuffer(12));
            var fullyQualifiedNamespace = new UriBuilder($"{account}.servicebus.windows.net/").Host;
            var connString = $"Endpoint=sb://{fullyQualifiedNamespace};SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey={Encoding.Default.GetString(GetRandomBuffer(64))}";
            var queueName = Encoding.Default.GetString(GetRandomBuffer(12));
            var client = new ServiceBusClient(connString);
            var sender = client.CreateSender(queueName,
                null);
        }

        [Test]
        public void CreateSenderUsingNullSendViaDoesNotThrow()
        {
            var account = Encoding.Default.GetString(GetRandomBuffer(12));
            var fullyQualifiedNamespace = new UriBuilder($"{account}.servicebus.windows.net/").Host;
            var connString = $"Endpoint=sb://{fullyQualifiedNamespace};SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey={Encoding.Default.GetString(GetRandomBuffer(64))}";
            var queueName = Encoding.Default.GetString(GetRandomBuffer(12));
            var client = new ServiceBusClient(connString);
            var sender = client.CreateSender(queueName,
                new ServiceBusSenderOptions
                {
                    ViaQueueOrTopicName = null
                });
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusSender.SendAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendBatchManagesLockingTheBatch()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockTransportBatch = new Mock<TransportMessageBatch>();
            var batch = new ServiceBusMessageBatch(mockTransportBatch.Object);
            var mockTransportSender = new Mock<TransportSender>();
            var mockConnection = new Mock<ServiceBusConnection>();

            mockConnection
                .Setup(connection => connection.RetryOptions)
                .Returns(new ServiceBusRetryOptions());

            mockConnection
                .Setup(connection => connection.CreateTransportSender(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<ServiceBusRetryPolicy>(), It.IsAny<string>()))
                .Returns(mockTransportSender.Object);

            mockConnection
                .Setup(connection => connection.ThrowIfClosed());

            mockTransportBatch
                .Setup(transport => transport.TryAdd(It.IsAny<ServiceBusMessage>()))
                .Returns(true);

            mockTransportSender
                .Setup(transport => transport.SendBatchAsync(It.IsAny<ServiceBusMessageBatch>(), It.IsAny<CancellationToken>()))
                .Returns(async () => await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token)));

            Assert.That(batch.TryAdd(new ServiceBusMessage(Array.Empty<byte>())), Is.True, "The batch should not be locked before sending.");

            var sender = new ServiceBusSender("dummy", null, mockConnection.Object);
            var sendTask = sender.SendAsync(batch);

            Assert.That(() => batch.TryAdd(new ServiceBusMessage(Array.Empty<byte>())), Throws.InstanceOf<InvalidOperationException>(), "The batch should be locked while sending.");
            completionSource.TrySetResult(true);

            await sendTask;
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(batch.TryAdd(new ServiceBusMessage(Array.Empty<byte>())), Is.True, "The batch should not be locked after sending.");

            cancellationSource.Cancel();
        }
    }
}
