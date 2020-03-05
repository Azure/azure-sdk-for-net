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

namespace Azure.Messaging.ServiceBus.Tests
{
    public class SenderTests : ServiceBusTestBase
    {
        [Test]
        public void Send_NullShouldThrow()
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
        public void SendRange_NullShouldThrow()
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
            var sender = new ServiceBusClient(connString).GetSender(queueName);
            Assert.AreEqual(queueName, sender.EntityName);
            Assert.AreEqual(fullyQualifiedNamespace, sender.FullyQualifiedNamespace);
        }
    }
}
