// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Storage.Queues.Samples
{
    /// <summary>
    /// Turn the simple Queues samples into tests.
    /// </summary>
    public class QueuesSampleTest : SampleTest
    {
        [Test]
        public void Sample01a_HelloWorld_SendMessage()
        {
            string queueName = Randomize("sample-queue");
            QueueClient queue = new QueueClient(ConnectionString, queueName);
            try
            {
                Sample01a_HelloWorld.SendMessage(ConnectionString, queueName);

                // Verify we uploaded one message
                Assert.AreEqual(1, queue.PeekMessages().Value.Length);
            }
            finally
            {
                queue.Delete();
            }
        }

        [Test]
        public async Task Sample01b_HelloWorldAsync_SendMessageAsync()
        {
            string queueName = Randomize("sample-queue");
            QueueClient queue = new QueueClient(ConnectionString, queueName);
            try
            {
                await Sample01b_HelloWorldAsync.SendMessageAsync(ConnectionString, queueName);

                // Verify we uploaded one message
                Assert.AreEqual(1, (await queue.PeekMessagesAsync(10)).Value.Length);
            }
            finally
            {
                await queue.DeleteAsync();
            }
        }

        [Test]
        public void Sample01a_HelloWorld_ReceiveMessages()
        {
            string queueName = Randomize("sample-queue");
            QueueClient queue = new QueueClient(ConnectionString, queueName);
            try
            {
                queue.Create();
                Sample01a_HelloWorld.ReceiveMessages(ConnectionString, queueName);

                // Verify we processed all the messages
                Assert.AreEqual(0, queue.PeekMessages().Value.Length);
            }
            finally
            {
                queue.Delete();
            }
        }

        [Test]
        public async Task Sample01b_HelloWorldAsync_ReceiveMessagesAsync()
        {
            string queueName = Randomize("sample-queue");
            QueueClient queue = new QueueClient(ConnectionString, queueName);
            try
            {
                await queue.CreateAsync();
                await Sample01b_HelloWorldAsync.ReceiveMessagesAsync(ConnectionString, queueName);

                // Verify we processed all the messages
                Assert.AreEqual(0, (await queue.PeekMessagesAsync()).Value.Length);
            }
            finally
            {
                await queue.DeleteAsync();
            }
        }

        [Test]
        public void Sample01a_HelloWorld_PeekMesssages()
        {
            string queueName = Randomize("sample-queue");
            QueueClient queue = new QueueClient(ConnectionString, queueName);
            try
            {
                queue.Create();
                Sample01a_HelloWorld.PeekMesssages(ConnectionString, queueName);

                // Verify we haven't emptied the queue
                Assert.Less(0, queue.PeekMessages().Value.Length);
            }
            finally
            {
                queue.Delete();
            }
        }

        [Test]
        public async Task Sample01b_HelloWorldAsync_PeekMesssagesAsync()
        {
            string queueName = Randomize("sample-queue");
            QueueClient queue = new QueueClient(ConnectionString, queueName);
            try
            {
                await queue.CreateAsync();
                await Sample01b_HelloWorldAsync.PeekMesssagesAsync(ConnectionString, queueName);

                // Verify we haven't emptied the queue
                Assert.Less(0, (await queue.PeekMessagesAsync()).Value.Length);
            }
            finally
            {
                await queue.DeleteAsync();
            }
        }

        [Test]
        public void Sample01a_HelloWorld_ReceiveAndUpdate()
        {
            string queueName = Randomize("sample-queue");
            QueueClient queue = new QueueClient(ConnectionString, queueName);
            try
            {
                queue.Create();
                Sample01a_HelloWorld.ReceiveAndUpdate(ConnectionString, queueName);

                // Verify we processed all the messages
                Assert.AreEqual(0, queue.PeekMessages().Value.Length);
            }
            finally
            {
                queue.Delete();
            }
        }

        [Test]
        public async Task Sample01b_HelloWorldAsync_ReceiveAndUpdateAsync()
        {
            string queueName = Randomize("sample-queue");
            QueueClient queue = new QueueClient(ConnectionString, queueName);
            try
            {
                await queue.CreateAsync();
                await Sample01b_HelloWorldAsync.ReceiveAndUpdateAsync(ConnectionString, queueName);

                // Verify we processed all the messages
                Assert.AreEqual(0, (await queue.PeekMessagesAsync()).Value.Length);
            }
            finally
            {
                await queue.DeleteAsync();
            }
        }

        [Test]
        public void Sample01a_HelloWorld_Errors()
        {
            string queueName = Randomize("sample-queue");
            QueueClient queue = new QueueClient(ConnectionString, queueName);
            try
            {
                queue.Create();
                Sample01a_HelloWorld.Errors(ConnectionString, queueName);
            }
            finally
            {
                queue.Delete();
            }
        }

        [Test]
        public async Task Sample01b_HelloWorldAsync_ErrorsAsync()
        {
            string queueName = Randomize("sample-queue");
            QueueClient queue = new QueueClient(ConnectionString, queueName);
            try
            {
                await queue.CreateAsync();
                await Sample01b_HelloWorldAsync.ErrorsAsync(ConnectionString, queueName);
            }
            finally
            {
                await queue.DeleteAsync();
            }
        }
    }
}
