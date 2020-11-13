// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
{
    public abstract class ServiceBusTestBase
    {
        protected List<ServiceBusMessage> GetMessages(int count, string sessionId = null, string partitionKey = null)
        {
            var messages = new List<ServiceBusMessage>();
            for (int i = 0; i < count; i++)
            {
                messages.Add(GetMessage(sessionId, partitionKey));
            }
            return messages;
        }

        protected ServiceBusMessageBatch AddMessages(ServiceBusMessageBatch batch, int count, string sessionId = null, string partitionKey = null)
        {
            for (int i = 0; i < count; i++)
            {
                Assert.That(() => batch.TryAddMessage(GetMessage(sessionId, partitionKey)), Is.True, "A message was rejected by the batch; all messages should be accepted.");
            }

            return batch;
        }

        protected Task ExceptionHandler(ProcessErrorEventArgs eventArgs)
        {
            Assert.IsNotNull(eventArgs.CancellationToken);
            Assert.Fail(eventArgs.Exception.ToString());
            return Task.CompletedTask;
        }

        protected ServiceBusMessage GetMessage(string sessionId = null, string partitionKey = null)
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

        protected byte[] GetRandomBuffer(long size)
        {
            var chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

            var csp = new RNGCryptoServiceProvider();
            var bytes = new byte[4];
            csp.GetBytes(bytes);
            var random = new Random(BitConverter.ToInt32(bytes, 0));
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

        internal ServiceBusConnection GetMockedConnection()
        {
            var mockConnection = new Mock<ServiceBusConnection>();

            mockConnection
                .Setup(connection => connection.RetryOptions)
                .Returns(new ServiceBusRetryOptions());
            return mockConnection.Object;
        }
    }
}
