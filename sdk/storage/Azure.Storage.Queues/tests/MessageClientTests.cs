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
            await using DisposingQueue test = await GetTestQueueAsync();

            // Act
            Response<Models.SendReceipt> response = await test.Queue.SendMessageAsync(
                messageText: GetNewString(),
                visibilityTimeout: new TimeSpan(0, 0, 1),
                timeToLive: new TimeSpan(1, 0, 0));

            // Assert
            Assert.NotNull(response.Value);
        }

        [Test]
        public async Task EnqueueAsync_Min()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            // Act
            Response<Models.SendReceipt> response = await test.Queue.SendMessageAsync(string.Empty);

            // Assert
            Assert.NotNull(response.Value);
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
            await using DisposingQueue test = await GetTestQueueAsync();

            await test.Queue.SendMessageAsync(GetNewString());
            await test.Queue.SendMessageAsync(GetNewString());
            await test.Queue.SendMessageAsync(GetNewString());

            // Act
            Response<Models.QueueMessage[]> response = await test.Queue.ReceiveMessagesAsync(
                maxMessages: 2,
                visibilityTimeout: new TimeSpan(1, 0, 0));

            // Assert
            Assert.AreEqual(2, response.Value.Count());
        }

        [Test]
        public async Task DequeueAsync_Min()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            await test.Queue.SendMessageAsync(GetNewString());
            await test.Queue.SendMessageAsync(GetNewString());
            await test.Queue.SendMessageAsync(GetNewString());

            // Act
            Response<Models.QueueMessage[]> response = await test.Queue.ReceiveMessagesAsync();

            // Assert
            Assert.AreEqual(1, response.Value.Count());
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
            await using DisposingQueue test = await GetTestQueueAsync();

            await test.Queue.SendMessageAsync(GetNewString());
            await test.Queue.SendMessageAsync(GetNewString());
            await test.Queue.SendMessageAsync(GetNewString());

            // Act
            Response<Models.PeekedMessage[]> response = await test.Queue.PeekMessagesAsync(maxMessages: 2);

            // Assert
            Assert.AreEqual(2, response.Value.Count());
        }

        [Test]
        public async Task PeekAsync_Min()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            await test.Queue.SendMessageAsync(GetNewString());
            await test.Queue.SendMessageAsync(GetNewString());
            await test.Queue.SendMessageAsync(GetNewString());

            // Act
            Response<Models.PeekedMessage[]> response = await test.Queue.PeekMessagesAsync();

            // Assert
            Assert.AreEqual(1, response.Value.Count());
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
            await using DisposingQueue test = await GetTestQueueAsync();

            await test.Queue.SendMessageAsync(GetNewString());
            await test.Queue.SendMessageAsync(GetNewString());
            await test.Queue.SendMessageAsync(GetNewString());

            // Act
            Response response = await test.Queue.ClearMessagesAsync();

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);
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
