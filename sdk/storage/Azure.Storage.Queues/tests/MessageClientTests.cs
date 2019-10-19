// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Queues.Tests;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Queues.Test
{
    public class MessageClientTests : QueueTestBase
    {
        public MessageClientTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public async Task EnqueueAsync()
        {
            // Arrange
            using (GetNewQueue(out QueueClient queue))
            {
                // Act
                Response<Models.SendReceipt> response = await queue.SendMessageAsync(
                    messageText: GetNewString(),
                    visibilityTimeout: new TimeSpan(0, 0, 1),
                    timeToLive: new TimeSpan(1, 0, 0));

                // Assert
                Assert.NotNull(response.Value);
            }
        }

        [Test]
        public async Task EnqueueAsync_Min()
        {
            // Arrange
            using (GetNewQueue(out QueueClient queue))
            {
                // Act
                Response<Models.SendReceipt> response = await queue.SendMessageAsync(string.Empty);

                // Assert
                Assert.NotNull(response.Value);
            }
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [Test]
        public async Task EnqueueAsync_Error()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                queue.SendMessageAsync(string.Empty),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task DequeueAsync()
        {
            // Arrange
            using (GetNewQueue(out QueueClient queue))
            {
                await queue.SendMessageAsync(GetNewString());
                await queue.SendMessageAsync(GetNewString());
                await queue.SendMessageAsync(GetNewString());

                // Act
                Response<Models.QueueMessage[]> response = await queue.ReceiveMessagesAsync(
                    maxMessages: 2,
                    visibilityTimeout: new TimeSpan(1, 0, 0));

                // Assert
                Assert.AreEqual(2, response.Value.Count());
            }
        }

        [Test]
        public async Task DequeueAsync_Min()
        {
            // Arrange
            using (GetNewQueue(out QueueClient queue))
            {
                await queue.SendMessageAsync(GetNewString());
                await queue.SendMessageAsync(GetNewString());
                await queue.SendMessageAsync(GetNewString());

                // Act
                Response<Models.QueueMessage[]> response = await queue.ReceiveMessagesAsync();

                // Assert
                Assert.AreEqual(1, response.Value.Count());
            }
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [Test]
        public async Task DequeueAsync_Error()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                queue.ReceiveMessagesAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task PeekAsync()
        {
            // Arrange
            using (GetNewQueue(out QueueClient queue))
            {
                await queue.SendMessageAsync(GetNewString());
                await queue.SendMessageAsync(GetNewString());
                await queue.SendMessageAsync(GetNewString());

                // Act
                Response<Models.PeekedMessage[]> response = await queue.PeekMessagesAsync(maxMessages: 2);

                // Assert
                Assert.AreEqual(2, response.Value.Count());
            }
        }

        [Test]
        public async Task PeekAsync_Min()
        {
            // Arrange
            using (GetNewQueue(out QueueClient queue))
            {
                await queue.SendMessageAsync(GetNewString());
                await queue.SendMessageAsync(GetNewString());
                await queue.SendMessageAsync(GetNewString());

                // Act
                Response<Models.PeekedMessage[]> response = await queue.PeekMessagesAsync();

                // Assert
                Assert.AreEqual(1, response.Value.Count());
            }
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [Test]
        public async Task PeekAsync_Error()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                queue.PeekMessagesAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task ClearAsync()
        {
            // Arrange
            using (GetNewQueue(out QueueClient queue))
            {
                await queue.SendMessageAsync(GetNewString());
                await queue.SendMessageAsync(GetNewString());
                await queue.SendMessageAsync(GetNewString());

                // Act
                Response response = await queue.ClearMessagesAsync();

                // Assert
                Assert.IsNotNull(response.Headers.RequestId);
            }
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [Test]
        public async Task ClearAsync_Error()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                queue.ClearMessagesAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }
    }
}
