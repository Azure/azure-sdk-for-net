﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using NUnit.Framework;

namespace Azure.Storage.Queues.Samples
{
    /// <summary>
    /// Basic Azure Queue Storage samples
    /// </summary>
    public class Sample01b_HelloWorldAsync : SampleTest
    {
        /// <summary>
        /// Create a queue and add a message.
        /// </summary>
        [Test]
        public async Task EnqueueAsync()
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
            await queue.CreateAsync();
            try
            {
                // Add a message to our queue
                await queue.SendMessageAsync("Hello, Azure!");

                // Verify we uploaded one message
                Assert.AreEqual(1, (await queue.PeekMessagesAsync(10)).Value.Count());
            }
            finally
            {
                // Clean up after the test when we're finished
                await queue.DeleteAsync();
            }
        }

        /// <summary>
        /// Dequeue and process messages from a queue.
        /// </summary>
        [Test]
        public async Task DequeueAsync()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a queue named "sample-queue" and then create it
            QueueClient queue = new QueueClient(connectionString, Randomize("sample-queue"));
            await queue.CreateAsync();
            try
            {
                // Add several messages to the queue
                await queue.SendMessageAsync("first");
                await queue.SendMessageAsync("second");
                await queue.SendMessageAsync("third");
                await queue.SendMessageAsync("fourth");
                await queue.SendMessageAsync("fifth");

                // Get the messages from the queue
                List<string> messages = new List<string>();
                foreach (QueueMessage message in (await queue.ReceiveMessagesAsync(maxMessages: 10)).Value)
                {
                    // "Process" the message
                    messages.Add(message.MessageText);

                    // Let the service know we finished with the message and
                    // it can be safely deleted.
                    await queue.DeleteMessageAsync(message.MessageId, message.PopReceipt);
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
                await queue.DeleteAsync();
            }
        }

        /// <summary>
        /// Peek at the messages on a queue.
        /// </summary>
        [Test]
        public async Task PeekAsync()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a queue named "sample-queue" and then create it
            QueueClient queue = new QueueClient(connectionString, Randomize("sample-queue"));
            await queue.CreateAsync();
            try
            {
                // Add several messages to the queue
                await queue.SendMessageAsync("first");
                await queue.SendMessageAsync("second");
                await queue.SendMessageAsync("third");
                await queue.SendMessageAsync("fourth");
                await queue.SendMessageAsync("fifth");

                // Get the messages from the queue
                List<string> messages = new List<string>();
                foreach (PeekedMessage message in (await queue.PeekMessagesAsync(maxMessages: 10)).Value)
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
                await queue.DeleteAsync();
            }
        }

        /// <summary>
        /// Dequeue messages and update their visibility timeout for extended
        /// processing.
        /// </summary>
        [Test]
        public async Task DequeueAndUpdateAsync()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a queue named "sample-queue" and then create it
            QueueClient queue = new QueueClient(connectionString, Randomize("sample-queue"));
            await queue.CreateAsync();
            try
            {
                // Add several messages to the queue
                await queue.SendMessageAsync("first");
                await queue.SendMessageAsync("second");
                await queue.SendMessageAsync("third");

                // Get the messages from the queue with a short visibility timeout
                List<QueueMessage> messages = new List<QueueMessage>();
                foreach (QueueMessage message in (await queue.ReceiveMessagesAsync(10, TimeSpan.FromSeconds(1))).Value)
                {
                    // Tell the service we need a little more time to process the message
                    UpdateReceipt changedMessage = await queue.UpdateMessageAsync(
                        message.MessageId,
                        message.PopReceipt,
                        message.MessageText,
                        TimeSpan.FromSeconds(5));
                    messages.Add(message.Update(changedMessage));
                }

                // Wait until the visibility window times out
                await Task.Delay(TimeSpan.FromSeconds(1.5));

                // Ensure the messages aren't visible yet
                Assert.AreEqual(0, (await queue.ReceiveMessagesAsync(10)).Value.Count());

                // Finish processing the messages
                foreach (QueueMessage message in messages)
                {
                    // Tell the service we need a little more time to process the message
                    await queue.DeleteMessageAsync(message.MessageId, message.PopReceipt);
                }
            }
            finally
            {
                // Clean up after the test when we're finished
                await queue.DeleteAsync();
            }
        }

        /// <summary>
        /// Trigger a recoverable error.
        /// </summary>
        [Test]
        public async Task ErrorsAsync()
        {
            // Get a connection string to our Azure Storage account
            string connectionString = ConnectionString;

            // Get a reference to a queue named "sample-queue" and then create it
            QueueClient queue = new QueueClient(connectionString, Randomize("sample-queue"));
            await queue.CreateAsync();

            try
            {
                // Try to create the queue again
                await queue.CreateAsync();
            }
            catch (RequestFailedException ex)
                when (ex.ErrorCode == QueueErrorCode.QueueAlreadyExists)
            {
                // Ignore any errors if the queue already exists
            }
            catch (RequestFailedException ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }

            // Clean up after the test when we're finished
            await queue.DeleteAsync();
        }
    }
}
