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
    public class MessageIdClientTests : QueueTestBase
    {
        public MessageIdClientTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public async Task DeleteAsync()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();
            Models.SendReceipt enqueuedMessage = (await test.Queue.SendMessageAsync(string.Empty)).Value;

            // Act
            Response result = await test.Queue.DeleteMessageAsync(enqueuedMessage.MessageId, enqueuedMessage.PopReceipt);

            // Assert
            Assert.IsNotNull(result.Headers.RequestId);
        }

        [Test]
        public async Task DeleteAsync_Error()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                test.Queue.DeleteMessageAsync(GetNewMessageId(), GetNewString()),
                actualException => Assert.AreEqual("MessageNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task DeleteAsync_DeletePeek()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();
            Models.SendReceipt enqueuedMessage = (await test.Queue.SendMessageAsync(string.Empty)).Value;

            // Act
            Response result = await test.Queue.DeleteMessageAsync(enqueuedMessage.MessageId, enqueuedMessage.PopReceipt);

            // Assert
            await test.Queue.PeekMessagesAsync();
            Assert.IsNotNull(result.Headers.RequestId);
        }

        [Test]
        public async Task UpdateAsync_Update()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            var message0 = "foo";
            var message1 = "bar";
            Models.SendReceipt enqueuedMessage = (await test.Queue.SendMessageAsync(message0)).Value;

            // Act
            Response<Models.UpdateReceipt> result = await test.Queue.UpdateMessageAsync(
                enqueuedMessage.MessageId,
                enqueuedMessage.PopReceipt,
                message1,
                new TimeSpan(100));

            // Assert
            Assert.IsNotNull(result.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task UpdateAsync_Min()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            var message0 = "foo";
            var message1 = "bar";
            Models.SendReceipt enqueuedMessage = (await test.Queue.SendMessageAsync(message0)).Value;

            // Act
            Response<Models.UpdateReceipt> result = await test.Queue.UpdateMessageAsync(
                enqueuedMessage.MessageId,
                enqueuedMessage.PopReceipt,
                message1);

            // Assert
            Assert.IsNotNull(result.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task UpdateAsync_UpdateDequeuedMessage()
        {
            await using DisposingQueue test = await GetTestQueueAsync();

            var message0 = "foo";
            var message1 = "bar";

            await test.Queue.SendMessageAsync(message0);
            Models.QueueMessage message = (await test.Queue.ReceiveMessagesAsync(1)).Value.First();

            Response<Models.UpdateReceipt> update = await test.Queue.UpdateMessageAsync(
                message.MessageId,
                message.PopReceipt,
                message1);

            Assert.AreNotEqual(update.Value.PopReceipt, message.PopReceipt);
            Assert.AreNotEqual(update.Value.NextVisibleOn, message.NextVisibleOn);

            Models.QueueMessage newMessage = message.Update(update);
            Assert.AreEqual(message.MessageId, newMessage.MessageId);
            Assert.AreEqual(message.MessageText, newMessage.MessageText);
            Assert.AreEqual(message.InsertedOn, newMessage.InsertedOn);
            Assert.AreEqual(message.ExpiresOn, newMessage.ExpiresOn);
            Assert.AreEqual(message.DequeueCount, newMessage.DequeueCount);
            Assert.AreNotEqual(message.PopReceipt, newMessage.PopReceipt);
            Assert.AreNotEqual(message.NextVisibleOn, newMessage.NextVisibleOn);
            Assert.AreEqual(update.Value.PopReceipt, newMessage.PopReceipt);
            Assert.AreEqual(update.Value.NextVisibleOn, newMessage.NextVisibleOn);
        }

        [Test]
        public async Task UpdateAsync_UpdatePeek()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            var message0 = "foo";
            var message1 = "bar";
            Models.SendReceipt enqueuedMessage = (await test.Queue.SendMessageAsync(message0)).Value;

            // Act
            await test.Queue.UpdateMessageAsync(enqueuedMessage.MessageId, enqueuedMessage.PopReceipt, message1);

            // Assert
            Response<Models.PeekedMessage[]> peekedMessages = await test.Queue.PeekMessagesAsync(1);
            Models.PeekedMessage peekedMessage = peekedMessages.Value.First();

            Assert.AreEqual(1, peekedMessages.Value.Count());
            Assert.AreEqual(message1, peekedMessage.MessageText);
        }

        [Test]
        public async Task UpdateAsync_Error()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                test.Queue.UpdateMessageAsync(GetNewMessageId(), GetNewString(), string.Empty),
                actualException => Assert.AreEqual("MessageNotFound", actualException.ErrorCode));
        }
    }
}
