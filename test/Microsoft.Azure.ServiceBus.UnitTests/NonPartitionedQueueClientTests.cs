// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus.Primitives;
    using Xunit;
    using Xunit.Abstractions;

    public class NonPartitionedQueueClientTests : QueueClientTestBase
    {
        public NonPartitionedQueueClientTests(ITestOutputHelper output)
            : base(output)
        {
            this.ConnectionString = Environment.GetEnvironmentVariable("NONPARTITIONEDQUEUECLIENTCONNECTIONSTRING");

            if (string.IsNullOrWhiteSpace(this.ConnectionString))
            {
                throw new InvalidOperationException("QUEUECLIENTCONNECTIONSTRING environment variable was not found!");
            }
        }

        [Fact]
        async Task PeekLockTest()
        {
            await this.QueueClientPeekLockTestCase(messageCount: 10);
        }

        [Fact]
        async Task ReceiveDeleteTest()
        {
            await this.QueueClientReceiveDeleteTestCase(messageCount: 10);
        }

        [Fact]
        async Task PeekLockWithAbandonTest()
        {
            await this.QueueClientPeekLockWithAbandonTestCase(messageCount: 10);
        }

        [Fact]
        async Task PeekLockWithDeadLetterTest()
        {
            await this.QueueClientPeekLockWithDeadLetterTestCase(messageCount: 10);
        }

        [Fact]
        async Task PeekLockDeferTest()
        {
            await this.QueueClientPeekLockDeferTestCase(messageCount: 10);
        }

        // Request Response Tests
        [Fact]
        async Task BasicRenewLockTest()
        {
            await this.QueueClientRenewLockTestCase(messageCount: 1);
        }

        // TODO: Add this to BrokeredMessageTests after merge
        [Fact]
        async Task BrokeredMessageOperationsTest()
        {
            // Create QueueClient with ReceiveDelete,
            // Send and Receive a message, Try to Complete/Abandon/Defer/DeadLetter should throw InvalidOperationException()
            QueueClient queueClient = QueueClient.CreateFromConnectionString(this.ConnectionString, ReceiveMode.ReceiveAndDelete);
            await TestUtility.SendMessagesAsync(queueClient.InnerSender, 1, this.Output);
            BrokeredMessage message = await queueClient.ReceiveAsync();
            Assert.NotNull((object)message);

            await Assert.ThrowsAsync<InvalidOperationException>(async () => await message.CompleteAsync());
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await message.AbandonAsync());
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await message.DeferAsync());
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await message.DeadLetterAsync());

            // Create a PeekLock queueClient and do rest of the operations
            // Send a Message, Receive/ Abandon and Complete it using BrokeredMessage methods
            queueClient = QueueClient.CreateFromConnectionString(this.ConnectionString);
            await TestUtility.SendMessagesAsync(queueClient.InnerSender, 1, this.Output);
            message = await queueClient.ReceiveAsync();
            Assert.NotNull((object)message);
            await message.AbandonAsync();
            await Task.Delay(TimeSpan.FromMilliseconds(100));
            message = await queueClient.ReceiveAsync();
            await message.CompleteAsync();

            // Send a Message, Receive / DeadLetter using BrokeredMessage methods
            await TestUtility.SendMessagesAsync(queueClient.InnerSender, 1, this.Output);
            message = await queueClient.ReceiveAsync();
            await message.DeadLetterAsync();
            ServiceBusConnectionStringBuilder builder = new ServiceBusConnectionStringBuilder(this.ConnectionString);
            builder.EntityPath = EntityNameHelper.FormatDeadLetterPath(queueClient.QueueName);
            QueueClient deadLetterQueueClient = QueueClient.CreateFromConnectionString(builder.ToString());
            message = await deadLetterQueueClient.ReceiveAsync();
            await message.CompleteAsync();

            // Send a Message, Receive/Defer using BrokeredMessage methods
            await TestUtility.SendMessagesAsync(queueClient.InnerSender, 1, this.Output);
            message = await queueClient.ReceiveAsync();
            long deferredSequenceNumber = message.SequenceNumber;
            await message.DeferAsync();

            var deferredMessage = await queueClient.ReceiveBySequenceNumberAsync(deferredSequenceNumber);
            await deferredMessage.CompleteAsync();

            queueClient.Close();
        }
    }
}