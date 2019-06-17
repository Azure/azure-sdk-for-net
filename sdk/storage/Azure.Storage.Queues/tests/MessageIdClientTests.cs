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
                var messages = this.InstrumentClient(queue.GetMessagesClient());
                var enqueuedMessages = await messages.EnqueueAsync(String.Empty);
                var enqueuedMessage = enqueuedMessages.Value.First();
                var messageId = this.InstrumentClient(messages.GetMessageIdClient(enqueuedMessage.MessageId));

                // Act
                var result = await messageId.DeleteAsync(enqueuedMessage.PopReceipt);

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
                var messages = this.InstrumentClient(queue.GetMessagesClient());
                var messageId = this.InstrumentClient(messages.GetMessageIdClient(this.GetNewMessageId()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    messageId.DeleteAsync(this.GetNewString()),
                    actualException => Assert.AreEqual("MessageNotFound", actualException.ErrorCode));
            }
        }

        [Test]
        public async Task DeleteAsync_DeletePeek()
        {
            // Arrange
            using (this.GetNewQueue(out var queue))
            {
                var messages = this.InstrumentClient(queue.GetMessagesClient());
                var enqueuedMessages = await messages.EnqueueAsync(String.Empty);
                var enqueuedMessage = enqueuedMessages.Value.First();
                var messageId = this.InstrumentClient(messages.GetMessageIdClient(enqueuedMessage.MessageId));

                // Act
                var result = await messageId.DeleteAsync(enqueuedMessage.PopReceipt);

                // Assert
                await messages.PeekAsync();
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

                var messages = this.InstrumentClient(queue.GetMessagesClient());
                var enqueuedMessages = await messages.EnqueueAsync(message0);
                var enqueuedMessage = enqueuedMessages.Value.First();
                var messageId = this.InstrumentClient(messages.GetMessageIdClient(enqueuedMessage.MessageId));

                // Act
                var result = await messageId.UpdateAsync(message1, enqueuedMessage.PopReceipt, new TimeSpan(100));

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

                var messages = this.InstrumentClient(queue.GetMessagesClient());
                var enqueuedMessages = await messages.EnqueueAsync(message0);
                var enqueuedMessage = enqueuedMessages.Value.First();
                var messageId = this.InstrumentClient(messages.GetMessageIdClient(enqueuedMessage.MessageId));

                // Act
                var result = await messageId.UpdateAsync(message1, enqueuedMessage.PopReceipt);

                // Assert
                Assert.IsNotNull(result.GetRawResponse().Headers.RequestId);
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

                var messages = this.InstrumentClient(queue.GetMessagesClient());
                var enqueuedMessages = await messages.EnqueueAsync(message0);
                var enqueuedMessage = enqueuedMessages.Value.First();
                var messageId = this.InstrumentClient(messages.GetMessageIdClient(enqueuedMessage.MessageId));

                // Act
                await messageId.UpdateAsync(message1, enqueuedMessage.PopReceipt);

                // Assert
                var peekedMessages = await messages.PeekAsync(1);
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
                var messages = this.InstrumentClient(queue.GetMessagesClient());
                var messageId = this.InstrumentClient(messages.GetMessageIdClient(this.GetNewMessageId()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    messageId.UpdateAsync(String.Empty, this.GetNewString()),
                    actualException => Assert.AreEqual("MessageNotFound", actualException.ErrorCode));

            }
        }
    }
}
