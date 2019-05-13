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
    public class MessageIdClientTests
    {
        [TestMethod]
        public async Task DeleteAsync()
        {
            // Arrange
            using (TestHelper.GetNewQueue(out var queue))
            {
                var enqueuedMessages = await queue.GetMessagesClient().EnqueueAsync(String.Empty);
                var enqueuedMessage = enqueuedMessages.Value.First();
                var messageId = queue.GetMessagesClient().GetMessageIdClient(enqueuedMessage.MessageId);

                // Act
                var result = await messageId.DeleteAsync(enqueuedMessage.PopReceipt);

                // Assert
                Assert.IsNotNull(result.Headers.RequestId);
            }
        }

        [TestMethod]
        public async Task DeleteAsync_Error()
        {
            // Arrange
            using (TestHelper.GetNewQueue(out var queue))
            {
                var messageId = queue.GetMessagesClient().GetMessageIdClient(TestHelper.GetNewMessageId());

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    messageId.DeleteAsync(TestHelper.GetNewString()),
                    actualException => Assert.AreEqual("MessageNotFound", actualException.ErrorCode));
            }
        }

        [TestMethod]
        public async Task DeleteAsync_DeletePeek()
        {
            // Arrange
            using (TestHelper.GetNewQueue(out var queue))
            {
                var enqueuedMessages = await queue.GetMessagesClient().EnqueueAsync(String.Empty);
                var enqueuedMessage = enqueuedMessages.Value.First();
                var messageId = queue.GetMessagesClient().GetMessageIdClient(enqueuedMessage.MessageId);

                // Act
                var result = await messageId.DeleteAsync(enqueuedMessage.PopReceipt);

                // Assert
                await queue.GetMessagesClient().PeekAsync();
                Assert.IsNotNull(result.Headers.RequestId);
            }
        }

        [TestMethod]
        public async Task UpdateAsync_Update()
        {
            // Arrange
            using (TestHelper.GetNewQueue(out var queue))
            {
                var message0 = "foo";
                var message1 = "bar";

                var enqueuedMessages = await queue.GetMessagesClient().EnqueueAsync(message0);
                var enqueuedMessage = enqueuedMessages.Value.First();
                var messageId = queue.GetMessagesClient().GetMessageIdClient(enqueuedMessage.MessageId);

                // Act
                var result = await messageId.UpdateAsync(message1, enqueuedMessage.PopReceipt, new TimeSpan(100));

                // Assert
                Assert.IsNotNull(result.Raw.Headers.RequestId);
            }
        }

        [TestMethod]
        public async Task UpdateAsync_Min()
        {
            // Arrange
            using (TestHelper.GetNewQueue(out var queue))
            {
                var message0 = "foo";
                var message1 = "bar";

                var enqueuedMessages = await queue.GetMessagesClient().EnqueueAsync(message0);
                var enqueuedMessage = enqueuedMessages.Value.First();
                var messageId = queue.GetMessagesClient().GetMessageIdClient(enqueuedMessage.MessageId);

                // Act
                var result = await messageId.UpdateAsync(message1, enqueuedMessage.PopReceipt);

                // Assert
                Assert.IsNotNull(result.Raw.Headers.RequestId);
            }
        }

        [TestMethod]
        public async Task UpdateAsync_UpdatePeek()
        {
            // Arrange
            using (TestHelper.GetNewQueue(out var queue))
            {
                var message0 = "foo";
                var message1 = "bar";

                var enqueuedMessages = await queue.GetMessagesClient().EnqueueAsync(message0);
                var enqueuedMessage = enqueuedMessages.Value.First();
                var messageId = queue.GetMessagesClient().GetMessageIdClient(enqueuedMessage.MessageId);

                // Act
                await messageId.UpdateAsync(message1, enqueuedMessage.PopReceipt);

                // Assert
                var peekedMessages = await queue.GetMessagesClient().PeekAsync(1);
                var peekedMessage = peekedMessages.Value.First();

                Assert.AreEqual(1, peekedMessages.Value.Count());
                Assert.AreEqual(message1, peekedMessage.MessageText);
            }
        }

        [TestMethod]
        public async Task UpdateAsync_Error()
        {
            // Arrange
            using (TestHelper.GetNewQueue(out var queue))
            {
                var messageId = queue.GetMessagesClient().GetMessageIdClient(TestHelper.GetNewMessageId());

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    messageId.UpdateAsync(String.Empty, TestHelper.GetNewString()),
                    actualException => Assert.AreEqual("MessageNotFound", actualException.ErrorCode));

            }
        }
    }
}
