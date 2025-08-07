// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Authorization;
using Azure.Messaging.ServiceBus.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
{
    public static class ServiceBusTestUtilities
    {
        internal static List<ServiceBusMessage> GetMessages(int count, string sessionId = null, string partitionKey = null)
        {
            var messages = new List<ServiceBusMessage>();
            for (int i = 0; i < count; i++)
            {
                messages.Add(GetMessage(sessionId, partitionKey));
            }
            return messages;
        }

        internal static ServiceBusMessageBatch AddMessages(ServiceBusMessageBatch batch, int count, string sessionId = null, string partitionKey = null)
        {
            for (int i = 0; i < count; i++)
            {
                Assert.That(() => batch.TryAddMessage(GetMessage(sessionId, partitionKey)), Is.True, "A message was rejected by the batch; all messages should be accepted.");
            }

            return batch;
        }

        internal static List<ServiceBusMessage> AddAndReturnMessages(ServiceBusMessageBatch batch, int count, string sessionId = null, string partitionKey = null)
        {
            var messages = new List<ServiceBusMessage>();
            for (int i = 0; i < count; i++)
            {
                var currentMessage = GetMessage(sessionId, partitionKey);
                Assert.That(() => batch.TryAddMessage(currentMessage), Is.True, "A message was rejected by the batch; all messages should be accepted.");
                messages.Add(currentMessage);
            }

            return messages;
        }

        internal static Task ExceptionHandler(ProcessErrorEventArgs eventArgs)
        {
            Assert.IsNotNull(eventArgs.CancellationToken);
            Assert.Fail(eventArgs.Exception.ToString());
            return Task.CompletedTask;
        }

        internal static ServiceBusMessage GetMessage(string sessionId = null, string partitionKey = null)
        {
            var msg = new ServiceBusMessage(GetRandomBuffer(100))
            {
                Subject = $"test-{Guid.NewGuid()}",
                MessageId = Guid.NewGuid().ToString()
            };
            if (sessionId != null)
            {
                msg.SessionId = sessionId;
            }
            if (partitionKey != null)
            {
                msg.PartitionKey = partitionKey;
            }
            return msg;
        }

        public static byte[] GetRandomBuffer(long size)
        {
            var chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

            var random = new Random();
            var buffer = new byte[size];
            random.NextBytes(buffer);
            var text = new byte[size];
            for (int i = 0; i < size; i++)
            {
                var idx = buffer[i] % chars.Length;
                text[i] = (byte)chars[idx];
            }
            return text;
        }

        internal static ServiceBusConnection GetMockedReceiverConnection()
        {
            var mockTransportReceiver = new Mock<TransportReceiver>();
            mockTransportReceiver
                .Setup(receiver => receiver.ReceiveMessagesAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Returns(async (int maximumMessageCount, TimeSpan? maxWaitTime, CancellationToken cancellationToken) =>
                {
                    await Task.Delay(Timeout.Infinite, cancellationToken);
                    throw new NotImplementedException();
                });

            var mockConnection = CreateMockConnection();

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
                    It.IsAny<CancellationToken>()))
                .Returns(mockTransportReceiver.Object);
            return mockConnection.Object;
        }

        internal static Mock<ServiceBusConnection> CreateMockConnection()
        {
            var mockConnection = new Mock<ServiceBusConnection>("not.real.com", Mock.Of<TokenCredential>(), new ServiceBusClientOptions())
            {
                CallBase = true
            };

            mockConnection
                .Setup(connection => connection.CreateTransportClient(
                    It.IsAny<ServiceBusTokenCredential>(),
                    It.IsAny<ServiceBusClientOptions>(),
                    It.IsAny<bool>()))
                .Returns(Mock.Of<TransportClient>());

            return mockConnection;
        }
    }
}
