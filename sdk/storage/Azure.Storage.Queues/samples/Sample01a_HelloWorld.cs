// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Azure.Storage;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using NUnit.Framework;

namespace Azure.Storage.Queues.Samples
{
    /// <summary>
    /// Basic Azure Queue Storage samples
    /// </summary>
    public class Sample01a_HelloWorld : SampleTest
    {
        /// <summary>
        /// Create a queue and add a message.
        /// </summary>
        [Test]
        public void Enqueue()
        {
            // Get a connection string to our Azure Storage account.  You can
            // obtain your connection string from the Azure Portal (click
            // Access Keys under Settings in the Portal Storage account blade)
            // or using the Azure CLI with:
            //
            //     az storage account show-connection-string --name <account_name> --resource-group <resource_group>
            //
            // And you can provide the connection string to your application
            // using an environment variable.
            string connectionString = ConnectionString;

            // Get a reference to a queue named "sample-queue" and then create it
            QueueClient queue = new QueueClient(connectionString, Randomize("sample-queue"));
            queue.Create();
            try
            {
                // Add a message to our queue
                queue.EnqueueMessage("Hello, Azure!");

                // Verify we uploaded one message
                Assert.AreEqual(1, queue.PeekMessages(10).Value.Count());
            }
            finally
            {
                // Clean up after the test when we're finished
                queue.Delete();
            }
        }

        /// <summary>
        /// Dequeue and process messages from a queue.
        /// </summary>
        [Test]
        public void Dequeue()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a queue named "sample-queue" and then create it
            QueueClient queue = new QueueClient(connectionString, Randomize("sample-queue"));
            queue.Create();
            try
            {
                // Add several messages to the queue
                queue.EnqueueMessage("first");
                queue.EnqueueMessage("second");
                queue.EnqueueMessage("third");
                queue.EnqueueMessage("fourth");
                queue.EnqueueMessage("fifth");

                // Get the next 10 messages from the queue
                List<string> messages = new List<string>();
                foreach (DequeuedMessage message in queue.DequeueMessages(maxMessages: 10).Value)
                {
                    // "Process" the message
                    messages.Add(message.MessageText);

                    // Let the service know we finished with the message and
                    // it can be safely deleted.
                    queue.DeleteMessage(message.MessageId, message.PopReceipt);
                }

                // Verify the messages
                Assert.AreEqual(5, messages.Count);
                Assert.Contains("first", messages);
                Assert.Contains("second", messages);
                Assert.Contains("third", messages);
                Assert.Contains("fourth", messages);
                Assert.Contains("fifth", messages);
            }
            finally
            {
                // Clean up after the test when we're finished
                queue.Delete();
            }
        }

        /// <summary>
        /// Peek at the messages on a queue.
        /// </summary>
        [Test]
        public void Peek()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a queue named "sample-queue" and then create it
            QueueClient queue = new QueueClient(connectionString, Randomize("sample-queue"));
            queue.Create();
            try
            {
                // Add several messages to the queue
                queue.EnqueueMessage("first");
                queue.EnqueueMessage("second");
                queue.EnqueueMessage("third");
                queue.EnqueueMessage("fourth");
                queue.EnqueueMessage("fifth");

                // Get the messages from the queue
                List<string> messages = new List<string>();
                foreach (PeekedMessage message in queue.PeekMessages(maxMessages: 10).Value)
                {
                    // Inspect the message
                    messages.Add(message.MessageText);
                }

                // Verify the messages
                Assert.AreEqual(5, messages.Count);
                Assert.Contains("first", messages);
                Assert.Contains("second", messages);
                Assert.Contains("third", messages);
                Assert.Contains("fourth", messages);
                Assert.Contains("fifth", messages);
            }
            finally
            {
                // Clean up after the test when we're finished
                queue.Delete();
            }
        }

        /// <summary>
        /// Dequeue messages and update their visibility timeout for extended
        /// processing.
        /// </summary>
        [Test]
        public void DequeueAndUpdate()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a queue named "sample-queue" and then create it
            QueueClient queue = new QueueClient(connectionString, Randomize("sample-queue"));
            queue.Create();
            try
            {
                // Add several messages to the queue
                queue.EnqueueMessage("first");
                queue.EnqueueMessage("second");
                queue.EnqueueMessage("third");

                // Get the messages from the queue with a short visibility timeout
                List<DequeuedMessage> messages = new List<DequeuedMessage>();
                foreach (DequeuedMessage message in queue.DequeueMessages(10, TimeSpan.FromSeconds(1)).Value)
                {
                    // Tell the service we need a little more time to process the message
                    UpdatedMessage changedMessage = queue.UpdateMessage(
                        message.MessageText,
                        message.MessageId,
                        message.PopReceipt,
                        TimeSpan.FromSeconds(5));
                    messages.Add(message.Update(changedMessage));
                }

                // Wait until the visibility window times out
                Thread.Sleep(TimeSpan.FromSeconds(1.5));

                // Ensure the messages aren't visible yet
                Assert.AreEqual(0, queue.DequeueMessages(10).Value.Count());

                // Finish processing the messages
                foreach (DequeuedMessage message in messages)
                {
                    // Tell the service we need a little more time to process the message
                    queue.DeleteMessage(message.MessageId, message.PopReceipt);
                }
            }
            finally
            {
                // Clean up after the test when we're finished
                queue.Delete();
            }
        }

        /// <summary>
        /// Trigger a recoverable error.
        /// </summary>
        [Test]
        public void Errors()
        {
            // Get a connection string to our Azure Storage account
            string connectionString = ConnectionString;

            // Get a reference to a queue named "sample-queue" and then create it
            QueueClient queue = new QueueClient(connectionString, Randomize("sample-queue"));
            queue.Create();

            try
            {
                // Try to create the queue again
                queue.Create();
            }
            catch (StorageRequestFailedException ex)
                when (ex.ErrorCode == QueueErrorCode.QueueAlreadyExists)
            {
                // Ignore any errors if the queue already exists
            }
            catch (StorageRequestFailedException ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }

            // Clean up after the test when we're finished
            queue.Delete();
        }
    }
}
