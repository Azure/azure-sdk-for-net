﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Azure.Messaging.ServiceBus.Primitives;
using Azure.Messaging.ServiceBus.Tests.Infrastructure;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Diagnostics
{
    public class EventSourceTests : ServiceBusTestBase
    {
        [Test]
        public async Task SendSingleMessageLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportSender = new Mock<TransportSender>();
            var mockConnection = GetMockConnection(mockTransportSender);

            var sender = new ServiceBusSender("queueName", new ServiceBusSenderOptions(), mockConnection.Object)
            {
                Logger = mockLogger.Object
            };
            await sender.SendAsync(GetMessage());

            mockLogger
                .Verify(
                    log => log.SendMessageStart(
                        sender.Identifier,
                        1),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.SendMessageComplete(
                        sender.Identifier),
                Times.Once);
        }

        [Test]
        public async Task SendListOfMessageLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportSender = new Mock<TransportSender>();
            var mockConnection = GetMockConnection(mockTransportSender);

            var sender = new ServiceBusSender("queueName", new ServiceBusSenderOptions(), mockConnection.Object)
            {
                Logger = mockLogger.Object
            };
            await sender.SendAsync(GetMessages(5));

            mockLogger
                .Verify(
                    log => log.SendMessageStart(
                        sender.Identifier,
                        5),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.SendMessageComplete(
                        sender.Identifier),
                Times.Once);
        }

        [Test]
        public void SendMessageExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportSender = new Mock<TransportSender>();
            var mockConnection = GetMockConnection(mockTransportSender);

            var sender = new ServiceBusSender("queueName", new ServiceBusSenderOptions(), mockConnection.Object)
            {
                Logger = mockLogger.Object
            };

            mockTransportSender.Setup(
                sender => sender.SendAsync(
                    It.IsAny<IList<ServiceBusMessage>>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());

            Assert.That(
                async () => await sender.SendAsync(GetMessage()),
                Throws.InstanceOf<Exception>());
            mockLogger
                .Verify(
                    log => log.SendMessageStart(
                        sender.Identifier,
                        1),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.SendMessageException(
                        sender.Identifier,
                        It.IsAny<string>()),
                Times.Once);
        }

        [Test]
        public async Task SendBatchOfMessagesLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportSender = new Mock<TransportSender>();
            var mockTransportBatch = new Mock<TransportMessageBatch>();
            var mockConnection = GetMockConnection(mockTransportSender);

            var sender = new ServiceBusSender("queueName", new ServiceBusSenderOptions(), mockConnection.Object)
            {
                Logger = mockLogger.Object
            };

            mockTransportBatch
                .Setup(transport => transport.Count)
                .Returns(3);

            mockTransportSender.Setup(
                 sender => sender.CreateBatchAsync(
                    It.IsAny<CreateBatchOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<TransportMessageBatch>(mockTransportBatch.Object));

            var batch = await sender.CreateBatchAsync();
            await sender.SendAsync(batch);
            mockLogger
                .Verify(
                    log => log.CreateMessageBatchStart(
                        sender.Identifier),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.CreateMessageBatchComplete(
                        sender.Identifier),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.SendMessageStart(
                        sender.Identifier,
                        3),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.SendMessageComplete(
                        sender.Identifier),
                Times.Once);
        }

        [Test]
        public async Task ScheduleMessageLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportSender = new Mock<TransportSender>();
            var mockConnection = GetMockConnection(mockTransportSender);

            var sender = new ServiceBusSender("queueName", new ServiceBusSenderOptions(), mockConnection.Object)
            {
                Logger = mockLogger.Object
            };
            var scheduleTime = DateTimeOffset.UtcNow.AddMinutes(1);
            await sender.ScheduleMessageAsync(GetMessage(), scheduleTime);

            mockLogger
                .Verify(
                    log => log.ScheduleMessageStart(
                        sender.Identifier,
                        scheduleTime.ToString()),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.ScheduleMessageComplete(
                        sender.Identifier),
                Times.Once);
        }

        [Test]
        public void ScheduleMessageExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportSender = new Mock<TransportSender>();
            var mockConnection = GetMockConnection(mockTransportSender);

            var sender = new ServiceBusSender("queueName", new ServiceBusSenderOptions(), mockConnection.Object)
            {
                Logger = mockLogger.Object
            };

            mockTransportSender.Setup(
                sender => sender.ScheduleMessageAsync(
                    It.IsAny<ServiceBusMessage>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());

            var scheduleTime = DateTimeOffset.UtcNow.AddMinutes(1);
            Assert.That(
                async () => await sender.ScheduleMessageAsync(GetMessage(), scheduleTime),
                Throws.InstanceOf<Exception>());

            mockLogger
                .Verify(
                    log => log.ScheduleMessageStart(
                        sender.Identifier,
                        scheduleTime.ToString()),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.ScheduleMessageException(
                        sender.Identifier,
                        It.IsAny<string>()),
                Times.Once);
        }

        [Test]
        public async Task CancelScheduleMessageLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportSender = new Mock<TransportSender>();
            var mockConnection = GetMockConnection(mockTransportSender);

            var sender = new ServiceBusSender("queueName", new ServiceBusSenderOptions(), mockConnection.Object)
            {
                Logger = mockLogger.Object
            };
            var sequenceNumber = 1;
            await sender.CancelScheduledMessageAsync(sequenceNumber);

            mockLogger
                .Verify(
                    log => log.CancelScheduledMessageStart(
                        sender.Identifier,
                        sequenceNumber),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.CancelScheduledMessageComplete(
                        sender.Identifier),
                Times.Once);
        }

        [Test]
        public void CancelScheduleMessageExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportSender = new Mock<TransportSender>();
            var mockConnection = GetMockConnection(mockTransportSender);

            var sender = new ServiceBusSender("queueName", new ServiceBusSenderOptions(), mockConnection.Object)
            {
                Logger = mockLogger.Object
            };
            var sequenceNumber = 1;

            mockTransportSender.Setup(
                sender => sender.CancelScheduledMessageAsync(
                    sequenceNumber,
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());

            Assert.That(
                async () => await sender.CancelScheduledMessageAsync(sequenceNumber),
                Throws.InstanceOf<Exception>());

            mockLogger
                .Verify(
                    log => log.CancelScheduledMessageStart(
                        sender.Identifier,
                        sequenceNumber),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.CancelScheduledMessageException(
                        sender.Identifier,
                        It.IsAny<string>()),
                Times.Once);
        }

        [Test]
        public async Task ReceiveSingleMessageLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);

            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.ReceiveBatchAsync(
                    1,
                    It.IsAny<TimeSpan?>(),
                    It.IsAny<CancellationToken>()))
                .Returns(
                Task.FromResult((IList<ServiceBusReceivedMessage>)
                    new List<ServiceBusReceivedMessage> { new ServiceBusReceivedMessage() }));
            var receiver = new ServiceBusReceiver(mockConnection.Object, "queueName", false, new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };


            await receiver.ReceiveAsync();

            mockLogger
                .Verify(
                    log => log.ReceiveMessageStart(
                        receiver.Identifier,
                        1),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.ReceiveMessageComplete(
                        receiver.Identifier,
                        1),
                Times.Once);
        }

        [Test]
        public async Task ReceiveBatchOfMessagesLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var maxMessages = 4;
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);

            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.ReceiveBatchAsync(
                    maxMessages,
                    It.IsAny<TimeSpan?>(),
                    It.IsAny<CancellationToken>()))
                .Returns(
                Task.FromResult((IList<ServiceBusReceivedMessage>)
                    new List<ServiceBusReceivedMessage> { new ServiceBusReceivedMessage(),
                    new ServiceBusReceivedMessage()}));
            var receiver = new ServiceBusReceiver(mockConnection.Object, "queueName", false, new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var msgs = await receiver.ReceiveBatchAsync(maxMessages: maxMessages);

            mockLogger
                .Verify(
                    log => log.ReceiveMessageStart(
                        receiver.Identifier,
                        // the amount requested
                        maxMessages),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.ReceiveMessageComplete(
                        receiver.Identifier,
                        // the amount we actually received
                        msgs.Count),
                Times.Once);
        }

        [Test]
        public void ReceiveMessageExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);

            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.ReceiveBatchAsync(
                    1,
                    It.IsAny<TimeSpan?>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());
            var receiver = new ServiceBusReceiver(mockConnection.Object, "queueName", false, new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            Assert.That(
                async () => await receiver.ReceiveAsync(),
                Throws.InstanceOf<Exception>());

            mockLogger
                .Verify(
                    log => log.ReceiveMessageStart(
                        receiver.Identifier,
                        1),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.ReceiveMessageException(
                        receiver.Identifier,
                        It.IsAny<string>()),
                Times.Once);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task PeekSingleMessageLogsEvents(bool specifySeqNumber)
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);

            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.PeekBatchAtAsync(
                    It.IsAny<long?>(),
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .Returns(
                Task.FromResult((IList<ServiceBusReceivedMessage>)
                    new List<ServiceBusReceivedMessage> { new ServiceBusReceivedMessage() }));
            var receiver = new ServiceBusReceiver(mockConnection.Object, "queueName", false, new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };
            var seqNumber = 5;

            if (specifySeqNumber)
            {
                await receiver.PeekAtAsync(seqNumber);
            }
            else
            {
                await receiver.PeekAsync();
            }

            mockLogger
                .Verify(
                    log => log.PeekMessageStart(
                        receiver.Identifier,
                        specifySeqNumber ? (long?) seqNumber : null,
                        1),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.PeekMessageComplete(
                        receiver.Identifier,
                        1),
                Times.Once);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task PeekBatchOfMessagesLogsEvents(bool specifySeqNumber)
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var maxMessages = 4;
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);

            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.PeekBatchAtAsync(
                    It.IsAny<long?>(),
                    maxMessages,
                    It.IsAny<CancellationToken>()))
                .Returns(
                Task.FromResult((IList<ServiceBusReceivedMessage>)
                    new List<ServiceBusReceivedMessage> { new ServiceBusReceivedMessage(),
                    new ServiceBusReceivedMessage()}));
            var receiver = new ServiceBusReceiver(mockConnection.Object, "queueName", false, new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var seqNumber = 5;
            IList<ServiceBusReceivedMessage> msgs;
            if (specifySeqNumber)
            {
                msgs = await receiver.PeekBatchAtAsync(seqNumber, maxMessages);
            }
            else
            {
                msgs = await receiver.PeekBatchAsync(maxMessages: maxMessages);
            }

            mockLogger
                .Verify(
                    log => log.PeekMessageStart(
                        receiver.Identifier,
                        specifySeqNumber ? (long?)seqNumber : null,
                        // the amount requested
                        maxMessages),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.PeekMessageComplete(
                        receiver.Identifier,
                        // the amount we actually received
                        msgs.Count),
                Times.Once);
        }

        [Test]
        public void PeekMessageExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);

            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.PeekBatchAtAsync(
                    It.IsAny<long?>(),
                    1,
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());
            var receiver = new ServiceBusReceiver(mockConnection.Object, "queueName", false, new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            Assert.That(
                async () => await receiver.PeekAsync(),
                Throws.InstanceOf<Exception>());

            mockLogger
                .Verify(
                    log => log.PeekMessageStart(
                        receiver.Identifier,
                        null,
                        1),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.PeekMessageException(
                        receiver.Identifier,
                        It.IsAny<string>()),
                Times.Once);
        }

        [Test]
        public async Task CompleteMessageLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);

            var receiver = new ServiceBusReceiver(mockConnection.Object, "queueName", false, new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var msg = new ServiceBusReceivedMessage() { LockTokenGuid = Guid.NewGuid() };
            await receiver.CompleteAsync(msg);

            mockLogger
                .Verify(
                    log => log.CompleteMessageStart(
                        receiver.Identifier,
                        1,
                        StringUtility.GetFormattedLockTokens(new string[] { msg.LockToken })),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.CompleteMessageComplete(
                        receiver.Identifier),
                Times.Once);
        }

        [Test]
        public void CompleteMessageExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);

            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.CompleteAsync(
                    It.IsAny<IEnumerable<string>>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());
            var receiver = new ServiceBusReceiver(mockConnection.Object, "queueName", false, new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var msg = new ServiceBusReceivedMessage() { LockTokenGuid = Guid.NewGuid() };
            Assert.That(
                async () => await receiver.CompleteAsync(msg),
                Throws.InstanceOf<Exception>());

            mockLogger
                .Verify(
                    log => log.CompleteMessageStart(
                        receiver.Identifier,
                        1,
                        StringUtility.GetFormattedLockTokens(new string[] { msg.LockToken })),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.CompleteMessageException(
                        receiver.Identifier,
                        It.IsAny<string>()),
                Times.Once);
        }

        [Test]
        public async Task DeferMessageLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            var receiver = new ServiceBusReceiver(mockConnection.Object, "queueName", false, new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var msg = new ServiceBusReceivedMessage() { LockTokenGuid = Guid.NewGuid() };
            await receiver.DeferAsync(msg);

            mockLogger
                .Verify(
                    log => log.DeferMessageStart(
                        receiver.Identifier,
                        1,
                        msg.LockToken),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.DeferMessageComplete(
                        receiver.Identifier),
                Times.Once);
        }

        [Test]
        public void DeferMessageExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.CompleteAsync(
                    It.IsAny<IEnumerable<string>>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());
            var receiver = new ServiceBusReceiver(mockConnection.Object, "queueName", false, new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var msg = new ServiceBusReceivedMessage() { LockTokenGuid = Guid.NewGuid() };
            Assert.That(
                async () => await receiver.CompleteAsync(msg),
                Throws.InstanceOf<Exception>());

            mockLogger
                .Verify(
                    log => log.CompleteMessageStart(
                        receiver.Identifier,
                        1,
                        StringUtility.GetFormattedLockTokens(new string[] { msg.LockToken })),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.CompleteMessageException(
                        receiver.Identifier,
                        It.IsAny<string>()),
                Times.Once);
        }

        [Test]
        public async Task DeadLetterMessageLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            var receiver = new ServiceBusReceiver(mockConnection.Object, "queueName", false, new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var msg = new ServiceBusReceivedMessage() { LockTokenGuid = Guid.NewGuid() };
            await receiver.DeadLetterAsync(msg);

            mockLogger
                .Verify(
                    log => log.DeadLetterMessageStart(
                        receiver.Identifier,
                        1,
                        msg.LockToken),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.DeadLetterMessageComplete(
                        receiver.Identifier),
                Times.Once);
        }

        [Test]
        public void DeadLetterMessageExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.DeadLetterAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<IDictionary<string, object>>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());
            var receiver = new ServiceBusReceiver(mockConnection.Object, "queueName", false, new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var msg = new ServiceBusReceivedMessage() { LockTokenGuid = Guid.NewGuid() };
            Assert.That(
                async () => await receiver.DeadLetterAsync(msg),
                Throws.InstanceOf<Exception>());

            mockLogger
                .Verify(
                    log => log.DeadLetterMessageStart(
                        receiver.Identifier,
                        1,
                        msg.LockToken),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.DeadLetterMessageException(
                        receiver.Identifier,
                        It.IsAny<string>()),
                Times.Once);
        }

        [Test]
        public async Task AbandonMessageLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            var receiver = new ServiceBusReceiver(mockConnection.Object, "queueName", false, new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var msg = new ServiceBusReceivedMessage() { LockTokenGuid = Guid.NewGuid() };
            await receiver.AbandonAsync(msg);

            mockLogger
                .Verify(
                    log => log.AbandonMessageStart(
                        receiver.Identifier,
                        1,
                        msg.LockToken),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.AbandonMessageComplete(
                        receiver.Identifier),
                Times.Once);
        }

        [Test]
        public void AbandonMessageExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.AbandonAsync(
                    It.IsAny<string>(),
                    It.IsAny<IDictionary<string, object>>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());
            var receiver = new ServiceBusReceiver(mockConnection.Object, "queueName", false, new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var msg = new ServiceBusReceivedMessage() { LockTokenGuid = Guid.NewGuid() };
            Assert.That(
                async () => await receiver.AbandonAsync(msg),
                Throws.InstanceOf<Exception>());

            mockLogger
                .Verify(
                    log => log.AbandonMessageStart(
                        receiver.Identifier,
                        1,
                        msg.LockToken),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.AbandonMessageException(
                        receiver.Identifier,
                        It.IsAny<string>()),
                Times.Once);
        }

        [Test]
        public async Task RenewMessageLockLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            var receiver = new ServiceBusReceiver(mockConnection.Object, "queueName", false, new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var msg = new ServiceBusReceivedMessage() { LockTokenGuid = Guid.NewGuid() };
            await receiver.RenewMessageLockAsync(msg);

            mockLogger
                .Verify(
                    log => log.RenewMessageLockStart(
                        receiver.Identifier,
                        1,
                        msg.LockToken),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.RenewMessageLockComplete(
                        receiver.Identifier),
                Times.Once);
        }

        [Test]
        public void RenewMessageLockExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.RenewMessageLockAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());
            var receiver = new ServiceBusReceiver(mockConnection.Object, "queueName", false, new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var msg = new ServiceBusReceivedMessage() { LockTokenGuid = Guid.NewGuid() };
            Assert.That(
                async () => await receiver.RenewMessageLockAsync(msg),
                Throws.InstanceOf<Exception>());

            mockLogger
                .Verify(
                    log => log.RenewMessageLockStart(
                        receiver.Identifier,
                        1,
                        msg.LockToken),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.RenewMessageLockException(
                        receiver.Identifier,
                        It.IsAny<string>()),
                Times.Once);
        }

        [Test]
        public async Task RenewSessionLockLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            var receiver = new ServiceBusSessionReceiver(mockConnection.Object, "queueName", new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            await receiver.RenewSessionLockAsync();

            mockLogger
                .Verify(
                    log => log.RenewSessionLockStart(
                        receiver.Identifier,
                        It.IsAny<string>()),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.RenewSessionLockComplete(
                        receiver.Identifier),
                Times.Once);
        }

        [Test]
        public void RenewSessionLockExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.RenewSessionLockAsync(
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());
            var receiver = new ServiceBusSessionReceiver(mockConnection.Object, "queueName", new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            Assert.That(
                async () => await receiver.RenewSessionLockAsync(),
                Throws.InstanceOf<Exception>());

            mockLogger
                .Verify(
                    log => log.RenewSessionLockStart(
                        receiver.Identifier,
                        It.IsAny<string>()),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.RenewSessionLockException(
                        receiver.Identifier,
                        It.IsAny<string>()),
                Times.Once);
        }

        [Test]
        public async Task GetSessionStateLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            var receiver = new ServiceBusSessionReceiver(mockConnection.Object, "queueName", new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            await receiver.GetSessionStateAsync();

            mockLogger
                .Verify(
                    log => log.GetSessionStateStart(
                        receiver.Identifier,
                        It.IsAny<string>()),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.GetSessionStateComplete(
                        receiver.Identifier),
                Times.Once);
        }

        [Test]
        public void GetSessionStateExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.GetStateAsync(
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());
            var receiver = new ServiceBusSessionReceiver(mockConnection.Object, "queueName", new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            Assert.That(
                async () => await receiver.GetSessionStateAsync(),
                Throws.InstanceOf<Exception>());

            mockLogger
                .Verify(
                    log => log.GetSessionStateStart(
                        receiver.Identifier,
                        It.IsAny<string>()),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.GetSessionStateException(
                        receiver.Identifier,
                        It.IsAny<string>()),
                Times.Once);
        }

        [Test]
        public async Task SetSessionStateLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            var receiver = new ServiceBusSessionReceiver(mockConnection.Object, "queueName", new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            await receiver.SetSessionStateAsync(null);

            mockLogger
                .Verify(
                    log => log.SetSessionStateStart(
                        receiver.Identifier,
                        It.IsAny<string>()),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.SetSessionStateComplete(
                        receiver.Identifier),
                Times.Once);
        }

        [Test]
        public void SetSessionStateExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.SetStateAsync(
                    It.IsAny<byte[]>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());
            var receiver = new ServiceBusSessionReceiver(mockConnection.Object, "queueName", new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            Assert.That(
                async () => await receiver.SetSessionStateAsync(null),
                Throws.InstanceOf<Exception>());

            mockLogger
                .Verify(
                    log => log.SetSessionStateStart(
                        receiver.Identifier,
                        It.IsAny<string>()),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.SetSessionStateException(
                        receiver.Identifier,
                        It.IsAny<string>()),
                Times.Once);
        }

        [Test]
        public async Task StartStopProcessingLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.ReceiveBatchAsync(
                    1,
                    It.IsAny<TimeSpan?>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult((IList<ServiceBusReceivedMessage>) new List<ServiceBusReceivedMessage>() { new ServiceBusReceivedMessage() }));
            var processor = new ServiceBusProcessor(mockConnection.Object, "queueName", false, new ServiceBusProcessorOptions
            {
                MaxAutoLockRenewalDuration = TimeSpan.Zero,
                AutoComplete = false
            })
            {
                Logger = mockLogger.Object
            };
            processor.ProcessErrorAsync += ExceptionHandler;
            processor.ProcessMessageAsync += MessageHandler;

            async Task MessageHandler(ProcessMessageEventArgs arg)
            {
                // simulate IO
                await Task.Delay(1000);
            }

            await processor.StartProcessingAsync();

            mockLogger
                .Verify(
                    log => log.StartProcessingStart(
                        processor.Identifier),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.StartProcessingComplete(
                        processor.Identifier),
                Times.Once);

            await processor.StopProcessingAsync();

            mockLogger
                .Verify(
                    log => log.StopProcessingStart(
                        processor.Identifier),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.StopProcessingComplete(
                        processor.Identifier),
                Times.Once);
        }

        [Test]
        public void StartProcessingExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockConnection = new Mock<ServiceBusConnection>();
            mockConnection.Setup(
                connection => connection.RetryOptions)
                .Returns(new ServiceBusRetryOptions());
            var processor = new ServiceBusProcessor(mockConnection.Object, "queueName", false, new ServiceBusProcessorOptions
            {
                AutoComplete = false,
                MaxAutoLockRenewalDuration = TimeSpan.Zero
            })
            {
                Logger = mockLogger.Object
            };

            Assert.That(
                async () => await processor.StartProcessingAsync(),
                Throws.InstanceOf<InvalidOperationException>());

            mockLogger
                .Verify(
                    log => log.StartProcessingStart(
                        processor.Identifier),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.StartProcessingException(
                        processor.Identifier,
                        It.IsAny<string>()),
                Times.Once);
        }

        [Test]
        public async Task StopProcessingExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.ReceiveBatchAsync(
                    1,
                    It.IsAny<TimeSpan?>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult((IList<ServiceBusReceivedMessage>)
                new List<ServiceBusReceivedMessage>
                {
                    new ServiceBusReceivedMessage
                    {
                        LockTokenGuid = Guid.NewGuid()
                    }
                }));
            var processor = new ServiceBusProcessor(mockConnection.Object, "queueName", false, new ServiceBusProcessorOptions
            {
                AutoComplete = false,
                MaxAutoLockRenewalDuration = TimeSpan.Zero
            })
            {
                Logger = mockLogger.Object
            };
            processor.ProcessErrorAsync += ExceptionHandler;
            processor.ProcessMessageAsync += MessageHandler;

            async Task MessageHandler(ProcessMessageEventArgs arg)
            {
                // simulate IO
                await Task.Delay(1000);
                throw new TestException();
            }

            await processor.StartProcessingAsync();
            var cts = new CancellationTokenSource();
            cts.Cancel();
            Assert.That(
                async () => await processor.StopProcessingAsync(cts.Token),
                Throws.InstanceOf<TaskCanceledException>());

            mockLogger
                .Verify(
                    log => log.StopProcessingStart(
                        processor.Identifier),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.StopProcessingException(
                        processor.Identifier,
                        It.IsAny<string>()),
                Times.Once);
        }

        private Mock<ServiceBusConnection> GetMockConnection(Mock<TransportReceiver> mockTransportReceiver)
        {
            var mockConnection = new Mock<ServiceBusConnection>();
            mockConnection.Setup(
                connection => connection.RetryOptions)
                .Returns(new ServiceBusRetryOptions());
            mockConnection.Setup(
                connection => connection.CreateTransportReceiver(
                    It.IsAny<string>(),
                    It.IsAny<ServiceBusRetryPolicy>(),
                    It.IsAny<ReceiveMode>(),
                    It.IsAny<uint>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>()))
                .Returns(mockTransportReceiver.Object);
            return mockConnection;
        }

        private Mock<ServiceBusConnection> GetMockConnection(Mock<TransportSender> mockTransportSender)
        {
            var mockConnection = new Mock<ServiceBusConnection>();
            mockConnection.Setup(
                connection => connection.RetryOptions)
                .Returns(new ServiceBusRetryOptions());
            mockConnection.Setup(
                connection => connection.CreateTransportSender(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<ServiceBusRetryPolicy>(),
                    It.IsAny<string>()))
                .Returns(mockTransportSender.Object);
            return mockConnection;
        }
    }
}
