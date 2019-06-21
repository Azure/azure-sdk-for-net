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
    [TestFixture]
    public class MessageClientTests : QueueTestBase
    {
        public MessageClientTests()
            : base(/* Use RecordedTestMode.Record here to re-record just these tests */)
        {
        }

        [Test]
        public async Task EnqueueAsync()
        {
            // Arrange
            using (this.GetNewQueue(out var queue))
            {
                // Act
                var messages = this.InstrumentClient(queue.GetMessagesClient());
                var response = await messages.EnqueueAsync(
                    messageText: this.GetNewString(),
                    visibilityTimeout: new TimeSpan(0, 0, 1),
                    timeToLive: new TimeSpan(1, 0, 0));

                // Assert
                Assert.AreEqual(1, response.Value.Count());
            }
        }

        [Test]
        public async Task EnqueueAsync_Min()
        {
            // Arrange
            using (this.GetNewQueue(out var queue))
            {
                // Act
                var messages = this.InstrumentClient(queue.GetMessagesClient());
                var response = await messages.EnqueueAsync(String.Empty);

                // Assert
                Assert.AreEqual(1, response.Value.Count());
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
                this.InstrumentClient(queue.GetMessagesClient()).EnqueueAsync(String.Empty),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task DequeueAsync()
        {
            // Arrange
            using (this.GetNewQueue(out var queue))
            {
                var messages = this.InstrumentClient(queue.GetMessagesClient());
                await messages.EnqueueAsync(this.GetNewString());
                await messages.EnqueueAsync(this.GetNewString());
                await messages.EnqueueAsync(this.GetNewString());

                // Act
                var response = await messages.DequeueAsync(
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
                var messages = this.InstrumentClient(queue.GetMessagesClient());
                await messages.EnqueueAsync(this.GetNewString());
                await messages.EnqueueAsync(this.GetNewString());
                await messages.EnqueueAsync(this.GetNewString());

                // Act
                var response = await messages.DequeueAsync();

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
            var messages = this.InstrumentClient(queue.GetMessagesClient());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                messages.DequeueAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task PeekAsync()
        {
            // Arrange
            using (this.GetNewQueue(out var queue))
            {
                var messages = this.InstrumentClient(queue.GetMessagesClient());
                await messages.EnqueueAsync(this.GetNewString());
                await messages.EnqueueAsync(this.GetNewString());
                await messages.EnqueueAsync(this.GetNewString());

                // Act
                var response = await messages.PeekAsync(maxMessages: 2);

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
                var messages = this.InstrumentClient(queue.GetMessagesClient());
                await messages.EnqueueAsync(this.GetNewString());
                await messages.EnqueueAsync(this.GetNewString());
                await messages.EnqueueAsync(this.GetNewString());

                // Act
                var response = await messages.PeekAsync();

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
            var messages = this.InstrumentClient(queue.GetMessagesClient());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                messages.PeekAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task ClearAsync()
        {
            // Arrange
            using (this.GetNewQueue(out var queue))
            {
                var messages = this.InstrumentClient(queue.GetMessagesClient());
                await messages.EnqueueAsync(this.GetNewString());
                await messages.EnqueueAsync(this.GetNewString());
                await messages.EnqueueAsync(this.GetNewString());

                // Act
                var response = await messages.ClearAsync();

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
            var messages = this.InstrumentClient(queue.GetMessagesClient());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                messages.ClearAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }
    }
}
