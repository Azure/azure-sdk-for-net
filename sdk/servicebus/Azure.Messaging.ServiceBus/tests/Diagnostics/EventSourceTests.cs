// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Authorization;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Microsoft.Azure.Amqp;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Diagnostics
{
    public class EventSourceTests
    {
        [Test]
        public async Task SendSingleMessageLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportSender = new Mock<TransportSender>();
            var mockConnection = GetMockConnection(mockTransportSender);

            var sender = new ServiceBusSender(
                "queueName",
                mockConnection.Object)
            {
                Logger = mockLogger.Object
            };
            await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage());

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

            var sender = new ServiceBusSender(
                "queueName",
                mockConnection.Object)
            {
                Logger = mockLogger.Object
            };
            await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(5));

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

            var sender = new ServiceBusSender(
                "queueName",
                mockConnection.Object)
            {
                Logger = mockLogger.Object
            };

            mockTransportSender.Setup(
                sender => sender.SendAsync(
                    It.IsAny<IReadOnlyCollection<ServiceBusMessage>>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());

            Assert.That(
                async () => await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage()),
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

            var sender = new ServiceBusSender(
                "queueName",
                mockConnection.Object)
            {
                Logger = mockLogger.Object
            };

            mockTransportBatch
                .Setup(transport => transport.Count)
                .Returns(3);

            mockTransportBatch
                .Setup(transport => transport.AsReadOnly<AmqpMessage>())
                .Returns(new List<AmqpMessage>());

            mockTransportSender.Setup(
                 sender => sender.CreateMessageBatchAsync(
                    It.IsAny<CreateMessageBatchOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<TransportMessageBatch>(mockTransportBatch.Object));

            var batch = await sender.CreateMessageBatchAsync();
            await sender.SendMessagesAsync(batch);
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
            var sender = new ServiceBusSender(
                "queueName",
                mockConnection.Object)
            {
                Logger = mockLogger.Object
            };
            mockTransportSender.Setup(
                sender => sender.ScheduleMessagesAsync(
                    It.IsAny<IReadOnlyCollection<ServiceBusMessage>>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult((IReadOnlyList<long>) new List<long> { 1 }));

            var scheduleTime = DateTimeOffset.UtcNow.AddMinutes(1);
            await sender.ScheduleMessageAsync(ServiceBusTestUtilities.GetMessage(), scheduleTime);

            mockLogger
                .Verify(
                    log => log.ScheduleMessagesStart(
                        sender.Identifier,
                        1,
                        It.IsAny<string>()),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.ScheduleMessagesComplete(
                        sender.Identifier),
                Times.Once);
        }

        [Test]
        public void ScheduleMessageExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportSender = new Mock<TransportSender>();
            var mockConnection = GetMockConnection(mockTransportSender);

            var sender = new ServiceBusSender(
                "queueName",
                mockConnection.Object)
            {
                Logger = mockLogger.Object
            };

            mockTransportSender.Setup(
                sender => sender.ScheduleMessagesAsync(
                    It.IsAny<IReadOnlyCollection<ServiceBusMessage>>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());

            var scheduleTime = DateTimeOffset.UtcNow.AddMinutes(1);
            Assert.That(
                async () => await sender.ScheduleMessageAsync(ServiceBusTestUtilities.GetMessage(), scheduleTime),
                Throws.InstanceOf<Exception>());

            mockLogger
                .Verify(
                    log => log.ScheduleMessagesStart(
                        sender.Identifier,
                        1,
                        It.IsAny<string>()),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.ScheduleMessagesException(
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
            var sender = new ServiceBusSender(
                "queueName",
                mockConnection.Object)
            {
                Logger = mockLogger.Object
            };
            long[] sequenceNumbers = new long[] { 1 };
            await sender.CancelScheduledMessagesAsync(sequenceNumbers: sequenceNumbers);

            mockLogger
                .Verify(
                    log => log.CancelScheduledMessagesStart(
                        sender.Identifier,
                        sequenceNumbers),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.CancelScheduledMessagesComplete(
                        sender.Identifier),
                Times.Once);
        }

        [Test]
        public void CancelScheduleMessageExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportSender = new Mock<TransportSender>();
            var mockConnection = GetMockConnection(mockTransportSender);

            var sender = new ServiceBusSender(
                "queueName",
                mockConnection.Object)
            {
                Logger = mockLogger.Object
            };
            long[] sequenceNumbers = new long[] { 1 };

            mockTransportSender.Setup(
                sender => sender.CancelScheduledMessagesAsync(
                    It.IsAny<long[]>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());

            Assert.That(
                async () => await sender.CancelScheduledMessagesAsync(sequenceNumbers: sequenceNumbers),
                Throws.InstanceOf<Exception>());

            mockLogger
                .Verify(
                    log => log.CancelScheduledMessagesStart(
                        sender.Identifier,
                        sequenceNumbers),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.CancelScheduledMessagesException(
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
            var received = (IReadOnlyList<ServiceBusReceivedMessage>)
                new List<ServiceBusReceivedMessage> { new() };
            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.ReceiveMessagesAsync(
                    1,
                    It.IsAny<TimeSpan?>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(received));
            var receiver = new ServiceBusReceiver(
                mockConnection.Object,
                "queueName",
                false,
                new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            await receiver.ReceiveMessageAsync();

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
                        received),
                Times.Once);
            mockLogger
            .Verify(
                log => log.MaxMessagesExceedsPrefetch(
                    receiver.Identifier,
                    receiver.PrefetchCount,
                    1),
                Times.Never);
        }

        [Test]
        public async Task ReceiveBatchOfMessagesLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var maxMessages = 4;
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            var received = (IReadOnlyList<ServiceBusReceivedMessage>)
                new List<ServiceBusReceivedMessage> { new() };

            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.ReceiveMessagesAsync(
                    maxMessages,
                    It.IsAny<TimeSpan?>(),
                    It.IsAny<CancellationToken>()))
                .Returns(
                Task.FromResult(received));
            var receiver = new ServiceBusReceiver(
                mockConnection.Object,
                "queueName",
                false,
                new ServiceBusReceiverOptions
                {
                    PrefetchCount = maxMessages - 1
                })
            {
                Logger = mockLogger.Object
            };

            var msgs = await receiver.ReceiveMessagesAsync(maxMessages: maxMessages);

            mockLogger
                .Verify(
                    log => log.ReceiveMessageStart(
                        receiver.Identifier,
                        // the amount requested
                        maxMessages),
                Times.Once);

            mockLogger
                .Verify(
                    log => log.MaxMessagesExceedsPrefetch(
                        receiver.Identifier,
                        receiver.PrefetchCount,
                        maxMessages),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.ReceiveMessageComplete(
                        receiver.Identifier,
                        // the amount we actually received
                        msgs),
                Times.Once);
        }

        [Test]
        public void ReceiveMessageExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);

            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.ReceiveMessagesAsync(
                    1,
                    It.IsAny<TimeSpan?>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());
            var receiver = new ServiceBusReceiver(
                mockConnection.Object,
                "queueName",
                false,
                new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            Assert.That(
                async () => await receiver.ReceiveMessageAsync(),
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
                transportReceiver => transportReceiver.PeekMessagesAsync(
                    It.IsAny<long?>(),
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .Returns(
                Task.FromResult((IReadOnlyList<ServiceBusReceivedMessage>)
                    new List<ServiceBusReceivedMessage> { new ServiceBusReceivedMessage() }));
            var receiver = new ServiceBusReceiver(
                mockConnection.Object,
                "queueName",
                false,
                new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var seqNumber = 5;

            await receiver.PeekMessageAsync(specifySeqNumber ? seqNumber : (long?)null);

            mockLogger
                .Verify(
                    log => log.PeekMessageStart(
                        receiver.Identifier,
                        specifySeqNumber ? (long?)seqNumber : null,
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
                transportReceiver => transportReceiver.PeekMessagesAsync(
                    It.IsAny<long?>(),
                    maxMessages,
                    It.IsAny<CancellationToken>()))
                .Returns(
                Task.FromResult((IReadOnlyList<ServiceBusReceivedMessage>)
                    new List<ServiceBusReceivedMessage> { new ServiceBusReceivedMessage(),
                    new ServiceBusReceivedMessage()}));
            var receiver = new ServiceBusReceiver(
                mockConnection.Object,
                "queueName",
                false,
                new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var seqNumber = 5;
            IReadOnlyList<ServiceBusReceivedMessage> msgs;
            msgs = await receiver.PeekMessagesAsync(maxMessages, specifySeqNumber ? seqNumber : (long?)null);

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
                transportReceiver => transportReceiver.PeekMessagesAsync(
                    It.IsAny<long?>(),
                    1,
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());
            var receiver = new ServiceBusReceiver(
                mockConnection.Object,
                "queueName",
                false,
                new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            Assert.That(
                async () => await receiver.PeekMessageAsync(),
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
            var receiver = new ServiceBusReceiver(
                mockConnection.Object,
                "queueName",
                false,
                new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var msg = new ServiceBusReceivedMessage() { LockTokenGuid = Guid.NewGuid() };
            await receiver.CompleteMessageAsync(msg);

            mockLogger
                .Verify(
                    log => log.CompleteMessageStart(
                        receiver.Identifier,
                        1,
                        msg.LockTokenGuid),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.CompleteMessageComplete(
                        receiver.Identifier,
                        msg.LockTokenGuid),
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
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());
            var receiver = new ServiceBusReceiver(
                mockConnection.Object,
                "queueName",
                false,
                new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var msg = new ServiceBusReceivedMessage() { LockTokenGuid = Guid.NewGuid() };
            Assert.That(
                async () => await receiver.CompleteMessageAsync(msg),
                Throws.InstanceOf<Exception>());

            mockLogger
                .Verify(
                    log => log.CompleteMessageStart(
                        receiver.Identifier,
                        1,
                        msg.LockTokenGuid),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.CompleteMessageException(
                        receiver.Identifier,
                        It.IsAny<string>(),
                        msg.LockTokenGuid),
                Times.Once);
        }

        [Test]
        public async Task DeferMessageLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            var receiver = new ServiceBusReceiver(
                mockConnection.Object,
                "queueName",
                false,
                new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var msg = new ServiceBusReceivedMessage() { LockTokenGuid = Guid.NewGuid() };
            await receiver.DeferMessageAsync(msg);

            mockLogger
                .Verify(
                    log => log.DeferMessageStart(
                        receiver.Identifier,
                        1,
                        msg.LockTokenGuid),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.DeferMessageComplete(
                        receiver.Identifier,
                        msg.LockTokenGuid),
                Times.Once);
        }

        [Test]
        public void DeferMessageExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.DeferAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<IDictionary<string, object>>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());
            var receiver = new ServiceBusReceiver(
                mockConnection.Object,
                "queueName",
                false,
                new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var msg = new ServiceBusReceivedMessage() { LockTokenGuid = Guid.NewGuid() };
            Assert.That(
                async () => await receiver.DeferMessageAsync(msg),
                Throws.InstanceOf<Exception>());

            mockLogger
                .Verify(
                    log => log.DeferMessageStart(
                        receiver.Identifier,
                        1,
                        msg.LockTokenGuid),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.DeferMessageException(
                        receiver.Identifier,
                        It.IsAny<string>(),
                        msg.LockTokenGuid),
                Times.Once);
        }

        [Test]
        public async Task DeadLetterMessageLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            var receiver = new ServiceBusReceiver(
                mockConnection.Object,
                "queueName",
                false,
                new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var msg = new ServiceBusReceivedMessage() { LockTokenGuid = Guid.NewGuid() };
            await receiver.DeadLetterMessageAsync(msg);

            mockLogger
                .Verify(
                    log => log.DeadLetterMessageStart(
                        receiver.Identifier,
                        1,
                        msg.LockTokenGuid),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.DeadLetterMessageComplete(
                        receiver.Identifier,
                        msg.LockTokenGuid),
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
                    It.IsAny<Guid>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<IDictionary<string, object>>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());
            var receiver = new ServiceBusReceiver(
                mockConnection.Object,
                "queueName",
                false,
                new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var msg = new ServiceBusReceivedMessage() { LockTokenGuid = Guid.NewGuid() };
            Assert.That(
                async () => await receiver.DeadLetterMessageAsync(msg),
                Throws.InstanceOf<Exception>());

            mockLogger
                .Verify(
                    log => log.DeadLetterMessageStart(
                        receiver.Identifier,
                        1,
                        msg.LockTokenGuid),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.DeadLetterMessageException(
                        receiver.Identifier,
                        It.IsAny<string>(),
                        msg.LockTokenGuid),
                Times.Once);
        }

        [Test]
        public async Task AbandonMessageLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            var receiver = new ServiceBusReceiver(
                mockConnection.Object,
                "queueName",
                false,
                new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var msg = new ServiceBusReceivedMessage() { LockTokenGuid = Guid.NewGuid() };
            await receiver.AbandonMessageAsync(msg);

            mockLogger
                .Verify(
                    log => log.AbandonMessageStart(
                        receiver.Identifier,
                        1,
                        msg.LockTokenGuid),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.AbandonMessageComplete(
                        receiver.Identifier,
                        msg.LockTokenGuid),
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
                    It.IsAny<Guid>(),
                    It.IsAny<IDictionary<string, object>>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());
            var receiver = new ServiceBusReceiver(
                mockConnection.Object,
                "queueName",
                false,
                new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var msg = new ServiceBusReceivedMessage() { LockTokenGuid = Guid.NewGuid() };
            Assert.That(
                async () => await receiver.AbandonMessageAsync(msg),
                Throws.InstanceOf<Exception>());

            mockLogger
                .Verify(
                    log => log.AbandonMessageStart(
                        receiver.Identifier,
                        1,
                        msg.LockTokenGuid),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.AbandonMessageException(
                        receiver.Identifier,
                        It.IsAny<string>(),
                        msg.LockTokenGuid),
                Times.Once);
        }

         [Test]
        public async Task DeleteMessagesLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.DeleteMessagesAsync(
                    It.IsAny<int>(),
                    It.IsAny<DateTimeOffset>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);
            var receiver = new ServiceBusReceiver(
                mockConnection.Object,
                "queueName",
                false,
                new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var dateTime = DateTimeOffset.UtcNow;
            await receiver.DeleteMessagesAsync(1, dateTime);

            mockLogger
                .Verify(
                    log => log.DeleteMessagesStart(
                        receiver.Identifier,
                        1,
                        dateTime),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.DeleteMessagesComplete(
                        receiver.Identifier,
                        1),
                Times.Once);
        }

        [Test]
        public void DeleteMessagesExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.DeleteMessagesAsync(
                    It.IsAny<int>(),
                    It.IsAny<DateTimeOffset>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());
            var receiver = new ServiceBusReceiver(
                mockConnection.Object,
                "queueName",
                false,
                new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var time = DateTimeOffset.UtcNow;
            Assert.That(
                async () => await receiver.DeleteMessagesAsync(1, time),
                Throws.InstanceOf<Exception>());

            mockLogger
                .Verify(
                    log => log.DeleteMessagesStart(
                        receiver.Identifier,
                        1,
                        time),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.DeleteMessagesException(
                        receiver.Identifier,
                        It.IsAny<string>()),
                Times.Once);
        }

        [Test]
        public async Task PurgeMessagesLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            mockTransportReceiver.SetupSequence(
                transportReceiver => transportReceiver.DeleteMessagesAsync(
                    It.IsAny<int>(),
                    It.IsAny<DateTimeOffset>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(1)
                .ReturnsAsync(0);
            var receiver = new ServiceBusReceiver(
                mockConnection.Object,
                "queueName",
                false,
                new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var dateTime = DateTimeOffset.UtcNow;
            await receiver.PurgeMessagesAsync(dateTime);

            mockLogger
                .Verify(
                    log => log.PurgeMessagesStart(
                        receiver.Identifier,
                        dateTime),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.PurgeMessagesComplete(
                        receiver.Identifier,
                        1),
                Times.Once);
        }

        [Test]
        public void PurgeMessagesExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.DeleteMessagesAsync(
                    It.IsAny<int>(),
                    It.IsAny<DateTimeOffset>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());
            var receiver = new ServiceBusReceiver(
                mockConnection.Object,
                "queueName",
                false,
                new ServiceBusReceiverOptions())
            {
                Logger = mockLogger.Object
            };

            var time = DateTimeOffset.UtcNow;
            Assert.That(
                async () => await receiver.PurgeMessagesAsync(time),
                Throws.InstanceOf<Exception>());

            mockLogger
                .Verify(
                    log => log.PurgeMessagesStart(
                        receiver.Identifier,
                        time),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.PurgeMessagesException(
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
            var receiver = new ServiceBusReceiver(
                mockConnection.Object,
                "queueName",
                false,
                new ServiceBusReceiverOptions())
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
                        msg.LockTokenGuid),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.RenewMessageLockComplete(
                        receiver.Identifier,
                        msg.LockTokenGuid),
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
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());
            var receiver = new ServiceBusReceiver(
                mockConnection.Object,
                "queueName",
                false,
                new ServiceBusReceiverOptions())
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
                        msg.LockTokenGuid),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.RenewMessageLockException(
                        receiver.Identifier,
                        It.IsAny<string>(),
                        msg.LockTokenGuid),
                Times.Once);
        }

        [Test]
        public async Task RenewSessionLockLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            mockTransportReceiver.Setup(r => r.SessionId).Returns("sessionId");
            var mockConnection = GetMockConnection(mockTransportReceiver);
            var receiver = new ServiceBusSessionReceiver(mockConnection.Object, "queueName",  new ServiceBusSessionReceiverOptions(), cancellationToken: CancellationToken.None)
            {
                Logger = mockLogger.Object
            };

            await receiver.RenewSessionLockAsync();

            mockLogger
                .Verify(
                    log => log.RenewSessionLockStart(
                        receiver.Identifier,
                        "sessionId"),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.RenewSessionLockComplete(
                        receiver.Identifier,
                        "sessionId"),
                Times.Once);
        }

        [Test]
        public void RenewSessionLockExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            mockTransportReceiver.Setup(r => r.SessionId).Returns("sessionId");
            var mockConnection = GetMockConnection(mockTransportReceiver);
            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.RenewSessionLockAsync(
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());
            var receiver = new ServiceBusSessionReceiver(
                mockConnection.Object,
                "queueName",
                new ServiceBusSessionReceiverOptions(),
                cancellationToken: CancellationToken.None)
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
                        "sessionId"),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.RenewSessionLockException(
                        receiver.Identifier,
                        It.IsAny<string>(),
                        "sessionId"),
                Times.Once);
        }

        [Test]
        public async Task GetSessionStateLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            mockTransportReceiver.Setup(r => r.SessionId).Returns("sessionId");
            var mockConnection = GetMockConnection(mockTransportReceiver);
            var receiver = new ServiceBusSessionReceiver(
                mockConnection.Object,
                "queueName",
                new ServiceBusSessionReceiverOptions(),
                cancellationToken: CancellationToken.None)
            {
                Logger = mockLogger.Object
            };

            await receiver.GetSessionStateAsync();

            mockLogger
                .Verify(
                    log => log.GetSessionStateStart(
                        receiver.Identifier,
                        "sessionId"),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.GetSessionStateComplete(
                        receiver.Identifier,
                        "sessionId"),
                Times.Once);
        }

        [Test]
        public void GetSessionStateExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            mockTransportReceiver.Setup(r => r.SessionId).Returns("sessionId");
            var mockConnection = GetMockConnection(mockTransportReceiver);
            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.GetStateAsync(
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());
            var receiver = new ServiceBusSessionReceiver(
                mockConnection.Object,
                "queueName",
                new ServiceBusSessionReceiverOptions(),
                cancellationToken: CancellationToken.None)
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
                        "sessionId"),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.GetSessionStateException(
                        receiver.Identifier,
                        It.IsAny<string>(),
                        "sessionId"),
                Times.Once);
        }

        [Test]
        public async Task SetSessionStateLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            mockTransportReceiver.Setup(r => r.SessionId).Returns("sessionId");
            var mockConnection = GetMockConnection(mockTransportReceiver);
            var receiver = new ServiceBusSessionReceiver(
                mockConnection.Object,
                "queueName",
                new ServiceBusSessionReceiverOptions(),
                cancellationToken: CancellationToken.None)
            {
                Logger = mockLogger.Object
            };

            await receiver.SetSessionStateAsync(default);

            mockLogger
                .Verify(
                    log => log.SetSessionStateStart(
                        receiver.Identifier,
                        "sessionId"),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.SetSessionStateComplete(
                        receiver.Identifier,
                        "sessionId"),
                Times.Once);
        }

        [Test]
        public void SetSessionStateExceptionLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            mockTransportReceiver.Setup(r => r.SessionId).Returns("sessionId");
            var mockConnection = GetMockConnection(mockTransportReceiver);
            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.SetStateAsync(
                    It.IsAny<BinaryData>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());
            var receiver = new ServiceBusSessionReceiver(
                mockConnection.Object,
                "queueName",
                new ServiceBusSessionReceiverOptions(),
                cancellationToken: CancellationToken.None)
            {
                Logger = mockLogger.Object
            };

            Assert.That(
                async () => await receiver.SetSessionStateAsync(default),
                Throws.InstanceOf<Exception>());

            mockLogger
                .Verify(
                    log => log.SetSessionStateStart(
                        receiver.Identifier,
                        "sessionId"),
                Times.Once);
            mockLogger
                .Verify(
                    log => log.SetSessionStateException(
                        receiver.Identifier,
                        It.IsAny<string>(),
                        "sessionId"),
                Times.Once);
        }

        [Test]
        public async Task StartStopProcessingLogsEvents()
        {
            var mockLogger = new Mock<ServiceBusEventSource>();
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);
            mockTransportReceiver.Setup(
                transportReceiver => transportReceiver.ReceiveMessagesAsync(
                    1,
                    It.IsAny<TimeSpan?>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult((IReadOnlyList<ServiceBusReceivedMessage>) new List<ServiceBusReceivedMessage>() { new ServiceBusReceivedMessage() }));
            var processor = new ServiceBusProcessor(mockConnection.Object, "queueName", false, new ServiceBusProcessorOptions
            {
                MaxAutoLockRenewalDuration = TimeSpan.Zero,
                AutoCompleteMessages = false
            })
            {
                Logger = mockLogger.Object
            };
            processor.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;
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
            var mockConnection = ServiceBusTestUtilities.CreateMockConnection();
            var processor = new ServiceBusProcessor(mockConnection.Object, "queueName", false, new ServiceBusProcessorOptions
            {
                AutoCompleteMessages = false,
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

        private Mock<ServiceBusConnection> GetMockConnection(Mock<TransportReceiver> mockTransportReceiver)
        {
            var prefetchCount = 0;

            mockTransportReceiver.Setup(receiver => receiver.PrefetchCount).Returns(() => prefetchCount);
            var mockConnection = GetMockConnection();

            mockConnection.Setup(
                connection => connection.CreateTransportReceiver(
                    It.IsAny<string>(),
                    It.IsAny<ServiceBusRetryPolicy>(),
                    It.IsAny<ServiceBusReceiveMode>(),
                    It.IsAny<uint>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, ServiceBusRetryPolicy, ServiceBusReceiveMode, uint, string, string, bool, bool, CancellationToken>(
                    (_, _, _, count, _, _, _, _, _) =>
                    {
                        prefetchCount = (int) count;
                    })
                .Returns(mockTransportReceiver.Object);

            return mockConnection;
        }

        private Mock<ServiceBusConnection> GetMockConnection(Mock<TransportSender> mockTransportSender)
        {
            var mockConnection = GetMockConnection();

            mockConnection.Setup(
                connection => connection.CreateTransportSender(
                    It.IsAny<string>(),
                    It.IsAny<ServiceBusRetryPolicy>(),
                    It.IsAny<string>()))
                .Returns(mockTransportSender.Object);

            return mockConnection;
        }

        private Mock<ServiceBusConnection> GetMockConnection()
        {
            var mockConnection = new Mock<ServiceBusConnection>("not.real.com", Mock.Of<TokenCredential>(), new ServiceBusClientOptions())
            {
                CallBase = true
            };

            mockConnection.Setup(
                connection => connection.CreateTransportClient(
                    It.IsAny<ServiceBusTokenCredential>(),
                    It.IsAny<ServiceBusClientOptions>(),
                    It.IsAny<bool>()))
                .Returns(Mock.Of<TransportClient>());

            return mockConnection;
        }
    }
}
