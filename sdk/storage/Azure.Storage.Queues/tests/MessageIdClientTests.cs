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
    public class MessageIdClientTests : QueueTestBase
    {
        public MessageIdClientTests()
            : base(/* Use RecordedTestMode.Record here to re-record just these tests */)
        {
        }

        [Test]
        public async Task DeleteAsync()
        {
            // Arrange
            using (this.GetNewQueue(out var queue))
            {
                var enqueuedMessage = (await queue.EnqueueMessageAsync(String.Empty)).Value;

                // Act
                var result = await queue.DeleteMessageAsync(enqueuedMessage.MessageId, enqueuedMessage.PopReceipt);

                // Assert
                Assert.IsNotNull(result.Headers.RequestId);
            }
        }

        [Test]
        public async Task DeleteAsync_Error()
        {
            // Arrange
            using (this.GetNewQueue(out var queue))
            {
                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    queue.DeleteMessageAsync(this.GetNewMessageId(), this.GetNewString()),
                    actualException => Assert.AreEqual("MessageNotFound", actualException.ErrorCode));
            }
        }

        [Test]
        public async Task DeleteAsync_DeletePeek()
        {
            // Arrange
            using (this.GetNewQueue(out var queue))
            {
                var enqueuedMessage = (await queue.EnqueueMessageAsync(String.Empty)).Value;
                
                // Act
                var result = await queue.DeleteMessageAsync(enqueuedMessage.MessageId, enqueuedMessage.PopReceipt);

                // Assert
                await queue.PeekMessagesAsync();
                Assert.IsNotNull(result.Headers.RequestId);
            }
        }

        [Test]
        public async Task UpdateAsync_Update()
        {
            // Arrange
            using (this.GetNewQueue(out var queue))
            {
                var message0 = "foo";
                var message1 = "bar";

                var enqueuedMessage = (await queue.EnqueueMessageAsync(message0)).Value;

                // Act
                var result = await queue.UpdateMessageAsync(
                    message1,
                    enqueuedMessage.MessageId,
                    enqueuedMessage.PopReceipt,
                    new TimeSpan(100));

                // Assert
                Assert.IsNotNull(result.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task UpdateAsync_Min()
        {
            // Arrange
            using (this.GetNewQueue(out var queue))
            {
                var message0 = "foo";
                var message1 = "bar";

                var enqueuedMessage = (await queue.EnqueueMessageAsync(message0)).Value;

                // Act
                var result = await queue.UpdateMessageAsync(
                    message1,
                    enqueuedMessage.MessageId,
                    enqueuedMessage.PopReceipt);

                // Assert
                Assert.IsNotNull(result.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task UpdateAsync_UpdateDequeuedMessage()
        {
            using (this.GetNewQueue(out var queue))
            {
                var message0 = "foo";
                var message1 = "bar";

                await queue.EnqueueMessageAsync(message0);
                var message = (await queue.DequeueMessagesAsync(1)).Value.First();

                var update = await queue.UpdateMessageAsync(
                    message1,
                    message.MessageId,
                    message.PopReceipt);

                Assert.AreNotEqual(update.Value.PopReceipt, message.PopReceipt);
                Assert.AreNotEqual(update.Value.TimeNextVisible, message.TimeNextVisible);

                var newMessage = message.Update(update);
                Assert.AreEqual(message.MessageId, newMessage.MessageId);
                Assert.AreEqual(message.MessageText, newMessage.MessageText);
                Assert.AreEqual(message.InsertionTime, newMessage.InsertionTime);
                Assert.AreEqual(message.ExpirationTime, newMessage.ExpirationTime);
                Assert.AreEqual(message.DequeueCount, newMessage.DequeueCount);
                Assert.AreNotEqual(message.PopReceipt, newMessage.PopReceipt);
                Assert.AreNotEqual(message.TimeNextVisible, newMessage.TimeNextVisible);
                Assert.AreEqual(update.Value.PopReceipt, newMessage.PopReceipt);
                Assert.AreEqual(update.Value.TimeNextVisible, newMessage.TimeNextVisible);
            }
        }

        [Test]
        public async Task UpdateAsync_UpdatePeek()
        {
            // Arrange
            using (this.GetNewQueue(out var queue))
            {
                var message0 = "foo";
                var message1 = "bar";

                var enqueuedMessage = (await queue.EnqueueMessageAsync(message0)).Value;

                // Act
                await queue.UpdateMessageAsync(message1, enqueuedMessage.MessageId, enqueuedMessage.PopReceipt);

                // Assert
                var peekedMessages = await queue.PeekMessagesAsync(1);
                var peekedMessage = peekedMessages.Value.First();

                Assert.AreEqual(1, peekedMessages.Value.Count());
                Assert.AreEqual(message1, peekedMessage.MessageText);
            }
        }

        [Test]
        public async Task UpdateAsync_Error()
        {
            // Arrange
            using (this.GetNewQueue(out var queue))
            {
                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    queue.UpdateMessageAsync(String.Empty, this.GetNewMessageId(), this.GetNewString()),
                    actualException => Assert.AreEqual("MessageNotFound", actualException.ErrorCode));

            }
        }
    }
}
