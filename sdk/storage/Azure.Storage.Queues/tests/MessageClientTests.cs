// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

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
            using (this.GetNewQueue(out var queue))
            {
                // Act
                var response = await queue.EnqueueMessageAsync(
                    messageText: this.GetNewString(),
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
            using (this.GetNewQueue(out var queue))
            {
                // Act
                var response = await queue.EnqueueMessageAsync(String.Empty);

                // Assert
                Assert.NotNull(response.Value);
            }
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [Test]
        public async Task EnqueueAsync_Error()
        {
            // Arrange
            var queueName = this.GetNewQueueName();
            var service = this.GetServiceClient_SharedKey();
            var queue = this.InstrumentClient(service.GetQueueClient(queueName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.EnqueueMessageAsync(String.Empty),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task DequeueAsync()
        {
            // Arrange
            using (this.GetNewQueue(out var queue))
            {
                await queue.EnqueueMessageAsync(this.GetNewString());
                await queue.EnqueueMessageAsync(this.GetNewString());
                await queue.EnqueueMessageAsync(this.GetNewString());

                // Act
                var response = await queue.DequeueMessagesAsync(
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
            using (this.GetNewQueue(out var queue))
            {
                await queue.EnqueueMessageAsync(this.GetNewString());
                await queue.EnqueueMessageAsync(this.GetNewString());
                await queue.EnqueueMessageAsync(this.GetNewString());

                // Act
                var response = await queue.DequeueMessagesAsync();

                // Assert
                Assert.AreEqual(1, response.Value.Count());
            }
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [Test]
        public async Task DequeueAsync_Error()
        {
            // Arrange
            var queueName = this.GetNewQueueName();
            var service = this.GetServiceClient_SharedKey();
            var queue = this.InstrumentClient(service.GetQueueClient(queueName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.DequeueMessagesAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task PeekAsync()
        {
            // Arrange
            using (this.GetNewQueue(out var queue))
            {
                await queue.EnqueueMessageAsync(this.GetNewString());
                await queue.EnqueueMessageAsync(this.GetNewString());
                await queue.EnqueueMessageAsync(this.GetNewString());

                // Act
                var response = await queue.PeekMessagesAsync(maxMessages: 2);

                // Assert
                Assert.AreEqual(2, response.Value.Count());
            }
        }

        [Test]
        public async Task PeekAsync_Min()
        {
            // Arrange
            using (this.GetNewQueue(out var queue))
            {
                await queue.EnqueueMessageAsync(this.GetNewString());
                await queue.EnqueueMessageAsync(this.GetNewString());
                await queue.EnqueueMessageAsync(this.GetNewString());

                // Act
                var response = await queue.PeekMessagesAsync();

                // Assert
                Assert.AreEqual(1, response.Value.Count());
            }
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [Test]
        public async Task PeekAsync_Error()
        {
            // Arrange
            var queueName = this.GetNewQueueName();
            var service = this.GetServiceClient_SharedKey();
            var queue = this.InstrumentClient(service.GetQueueClient(queueName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.PeekMessagesAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task ClearAsync()
        {
            // Arrange
            using (this.GetNewQueue(out var queue))
            {
                await queue.EnqueueMessageAsync(this.GetNewString());
                await queue.EnqueueMessageAsync(this.GetNewString());
                await queue.EnqueueMessageAsync(this.GetNewString());

                // Act
                var response = await queue.ClearMessagesAsync();

                // Assert
                Assert.IsNotNull(response.Headers.RequestId);
            }
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [Test]
        public async Task ClearAsync_Error()
        {
            // Arrange
            var queueName = this.GetNewQueueName();
            var service = this.GetServiceClient_SharedKey();
            var queue = this.InstrumentClient(service.GetQueueClient(queueName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.ClearMessagesAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }
    }
}
