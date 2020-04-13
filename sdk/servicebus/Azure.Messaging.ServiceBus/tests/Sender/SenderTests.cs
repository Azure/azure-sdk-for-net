// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Messaging.ServiceBus.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Sender
{
    public class SenderTests : ServiceBusTestBase
    {
        [Test]
        public void SendNullShouldThrow()
        {
            var mock = new Mock<ServiceBusSender>()
            {
                CallBase = true
            };
            Assert.ThrowsAsync<ArgumentNullException>(async () => await mock.Object.SendAsync(null));
        }

        //[Test]
        //public async Task Send_DelegatesToSendRange()
        //{
        //    var mock = new Mock<ServiceBusSender>()
        //    {
        //        CallBase = true
        //    };
        //    mock
        //       .Setup(m => m.SendBatchAsync(
        //           It.Is<IEnumerable<ServiceBusMessage>>(value => value.Count() == 1),
        //           It.IsAny<CancellationToken>()))
        //       .Returns(Task.CompletedTask)
        //       .Verifiable("The single send should delegate to the batch send.");

        //    await mock.Object.SendAsync(new ServiceBusMessage());
        //}

        [Test]
        public void SendRangeNullShouldThrow()
        {
            var mock = new Mock<ServiceBusSender>()
            {
                CallBase = true
            };
            Assert.ThrowsAsync<ArgumentNullException>(async () => await mock.Object.SendBatchAsync(null));
        }

        //[Test]
        // TODO figure out a better way to test this without making InnerSender internal
        //public async Task SendRange_DelegatesToInnerSender()
        //{
        //    var mock = new Mock<ServiceBusSender>()
        //    {
        //        CallBase = true
        //    };

        //    var msgs = GetMessages(10);
        //    var mockSender = new Mock<TransportSender>();
        //    mock.SetupGet(m => m.InnerSender).Returns(mockSender.Object);
        //    mock.Setup(m => m.CreateDiagnosticScope()).Returns(default(DiagnosticScope));
        //    await mock.Object.SendBatchAsync(msgs);
        //    mockSender.Verify(m => m.SendAsync(msgs, default), "Send should delegate to Inner Sender");

        //}

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
            var mockTransportProducer = new Mock<TransportSender>();
            var mockConnection = new Mock<ServiceBusConnection>();

            mockConnection
                .Setup(connection => connection.RetryOptions)
                .Returns(new ServiceBusRetryOptions());

            mockConnection
                .Setup(connection => connection.CreateTransportSender(It.IsAny<string>(), It.IsAny<ServiceBusRetryPolicy>()))
                .Returns(mockTransportProducer.Object);

            mockConnection
                .Setup(connection => connection.ThrowIfClosed());

            mockTransportBatch
                .Setup(transport => transport.TryAdd(It.IsAny<ServiceBusMessage>()))
                .Returns(true);

            mockTransportProducer
                .Setup(transport => transport.SendBatchAsync(It.IsAny<ServiceBusMessageBatch>(), It.IsAny<CancellationToken>()))
                .Returns(async () => await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token)));

            Assert.That(batch.TryAdd(new ServiceBusMessage(Array.Empty<byte>())), Is.True, "The batch should not be locked before sending.");

            var sender = new ServiceBusSender("dummy", mockConnection.Object);
            var sendTask = sender.SendBatchAsync(batch);

            Assert.That(() => batch.TryAdd(new ServiceBusMessage(Array.Empty<byte>())), Throws.InstanceOf<InvalidOperationException>(), "The batch should be locked while sending.");
            completionSource.TrySetResult(true);

            await sendTask;
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(batch.TryAdd(new ServiceBusMessage(Array.Empty<byte>())), Is.True, "The batch should not be locked after sending.");

            cancellationSource.Cancel();
        }
    }
}
