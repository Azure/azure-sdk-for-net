// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Azure.Storage.Queues.Test
{
    [TestClass]
    public class MessageClientTests
    {
        [TestMethod]
        [TestCategory("Live")]
        public async Task EnqueueAsync()
        {
            // Arrange
            using (TestHelper.GetNewQueue(out var queue))
            {
                // Act
                var response = await queue.GetMessagesClient().EnqueueAsync(
                    messageText: TestHelper.GetNewString(),
                    visibilityTimeout: new TimeSpan(0, 0, 1),
                    timeToLive: new TimeSpan(1, 0, 0));

                // Assert
                Assert.AreEqual(1, response.Value.Count());
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task EnqueueAsync_Min()
        {
            // Arrange
            using (TestHelper.GetNewQueue(out var queue))
            {
                // Act
                var response = await queue.GetMessagesClient().EnqueueAsync(String.Empty);

                // Assert
                Assert.AreEqual(1, response.Value.Count());
            }
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [TestMethod]
        [TestCategory("Live")]
        public async Task EnqueueAsync_Error()
        {
            // Arrange
            var queueName = TestHelper.GetNewQueueName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var queue = service.GetQueueClient(queueName);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.GetMessagesClient().EnqueueAsync(String.Empty),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task DequeueAsync()
        {
            // Arrange
            using (TestHelper.GetNewQueue(out var queue))
            {
                await queue.GetMessagesClient().EnqueueAsync(TestHelper.GetNewString());
                await queue.GetMessagesClient().EnqueueAsync(TestHelper.GetNewString());
                await queue.GetMessagesClient().EnqueueAsync(TestHelper.GetNewString());

                // Act
                var response = await queue.GetMessagesClient().DequeueAsync(
                    maxMessages: 2,
                    visibilityTimeout: new TimeSpan(1, 0, 0));

                // Assert
                Assert.AreEqual(2, response.Value.Count());
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task DequeueAsync_Min()
        {
            // Arrange
            using (TestHelper.GetNewQueue(out var queue))
            {
                await queue.GetMessagesClient().EnqueueAsync(TestHelper.GetNewString());
                await queue.GetMessagesClient().EnqueueAsync(TestHelper.GetNewString());
                await queue.GetMessagesClient().EnqueueAsync(TestHelper.GetNewString());

                // Act
                var response = await queue.GetMessagesClient().DequeueAsync();

                // Assert
                Assert.AreEqual(1, response.Value.Count());
            }
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [TestMethod]
        [TestCategory("Live")]
        public async Task DequeueAsync_Error()
        {
            // Arrange
            var queueName = TestHelper.GetNewQueueName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var queue = service.GetQueueClient(queueName);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.GetMessagesClient().DequeueAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task PeekAsync()
        {
            // Arrange
            using (TestHelper.GetNewQueue(out var queue))
            {
                await queue.GetMessagesClient().EnqueueAsync(TestHelper.GetNewString());
                await queue.GetMessagesClient().EnqueueAsync(TestHelper.GetNewString());
                await queue.GetMessagesClient().EnqueueAsync(TestHelper.GetNewString());

                // Act
                var response = await queue.GetMessagesClient().PeekAsync(maxMessages: 2);

                // Assert
                Assert.AreEqual(2, response.Value.Count());
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task PeekAsync_Min()
        {
            // Arrange
            using (TestHelper.GetNewQueue(out var queue))
            {
                await queue.GetMessagesClient().EnqueueAsync(TestHelper.GetNewString());
                await queue.GetMessagesClient().EnqueueAsync(TestHelper.GetNewString());
                await queue.GetMessagesClient().EnqueueAsync(TestHelper.GetNewString());

                // Act
                var response = await queue.GetMessagesClient().PeekAsync();

                // Assert
                Assert.AreEqual(1, response.Value.Count());
            }
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [TestMethod]
        [TestCategory("Live")]
        public async Task PeekAsync_Error()
        {
            // Arrange
            var queueName = TestHelper.GetNewQueueName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var queue = service.GetQueueClient(queueName);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.GetMessagesClient().PeekAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task ClearAsync()
        {
            // Arrange
            using (TestHelper.GetNewQueue(out var queue))
            {
                await queue.GetMessagesClient().EnqueueAsync(TestHelper.GetNewString());
                await queue.GetMessagesClient().EnqueueAsync(TestHelper.GetNewString());
                await queue.GetMessagesClient().EnqueueAsync(TestHelper.GetNewString());

                // Act
                var response = await queue.GetMessagesClient().ClearAsync();

                // Assert
                Assert.IsNotNull(response.Headers.RequestId);
            }
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [TestMethod]
        [TestCategory("Live")]
        public async Task ClearAsync_Error()
        {
            // Arrange
            var queueName = TestHelper.GetNewQueueName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var queue = service.GetQueueClient(queueName);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.GetMessagesClient().ClearAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }
    }
}
