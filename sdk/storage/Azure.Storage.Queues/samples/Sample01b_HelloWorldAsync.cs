// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
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
        /// <param name="connectionString">
        /// A connection string to your Azure Storage account.
        /// </param>
        /// <param name="queueName">
        /// The name of the queue to create and send a message to.
        /// </param>
        public static async Task SendMessageAsync(string connectionString, string queueName)
        {
            // We'll need a connection string to your Azure Storage account.
            // You can obtain your connection string from the Azure Portal
            // (click Access Keys under Settings in the Portal Storage account
            // blade) or using the Azure CLI with:
            //
            //     az storage account show-connection-string --name <account_name> --resource-group <resource_group>
            //
            // You would normally provide the connection string to your
            // application using an environment variable.

            #region Snippet:Azure_Storage_Queues_Samples_Sample01b_HelloWorld_SendMessageAsync
            // We'll need a connection string to your Azure Storage account.
            //@@ string connectionString = "<connection_string>";

            // Name of the queue we'll send messages to
            //@@ string queueName = "sample-queue";

            // Get a reference to a queue and then create it
            QueueClient queue = new QueueClient(connectionString, queueName);
            await queue.CreateAsync();

            // Send a message to our queue
            await queue.SendMessageAsync("Hello, Azure!");
            #endregion Snippet:Azure_Storage_Queues_Samples_Sample01b_HelloWorld_SendMessageAsync
        }

        /// <summary>
        /// Receive and process messages from a queue.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string to your Azure Storage account.
        /// </param>
        /// <param name="queueName">
        /// The name of an existing queue to operate on.
        /// </param>
        public static async Task ReceiveMessagesAsync(string connectionString, string queueName)
        {
            // Get a reference to a queue and then fill it with messages
            QueueClient queue = new QueueClient(connectionString, queueName);
            await queue.SendMessageAsync("first");
            await queue.SendMessageAsync("second");
            await queue.SendMessageAsync("third");

            // Get the next messages from the queue
            foreach (QueueMessage message in (await queue.ReceiveMessagesAsync(maxMessages: 10)).Value)
            {
                // "Process" the message
                Console.WriteLine($"Message: {message.Body}");

                // Let the service know we're finished with the message and
                // it can be safely deleted.
                await queue.DeleteMessageAsync(message.MessageId, message.PopReceipt);
            }
        }

        /// <summary>
        /// Peek at the messages on a queue.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string to your Azure Storage account.
        /// </param>
        /// <param name="queueName">
        /// The name of an existing queue to operate on.
        /// </param>
        public static async Task PeekMesssagesAsync(string connectionString, string queueName)
        {
            // Get a reference to a queue and then fill it with messages
            QueueClient queue = new QueueClient(connectionString, queueName);
            await queue.SendMessageAsync("first");
            await queue.SendMessageAsync("second");
            await queue.SendMessageAsync("third");

            // Get the messages from the queue
            foreach (PeekedMessage message in (await queue.PeekMessagesAsync(maxMessages: 10)).Value)
            {
                // Inspect the message
                Console.WriteLine($"Message: {message.Body}");
            }
        }

        /// <summary>
        /// Receive messages and update their visibility timeout for extended
        /// processing.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string to your Azure Storage account.
        /// </param>
        /// <param name="queueName">
        /// The name of an existing queue to operate on.
        /// </param>
        public static async Task ReceiveAndUpdateAsync(string connectionString, string queueName)
        {
            // Get a reference to a queue and then fill it with messages
            QueueClient queue = new QueueClient(connectionString, queueName);
            await queue.SendMessageAsync("first");
            await queue.SendMessageAsync("second");
            await queue.SendMessageAsync("third");

            // Get the messages from the queue with a short visibility timeout
            // of 1 second
            List<QueueMessage> messages = new List<QueueMessage>();
            Response<QueueMessage[]> received = await queue.ReceiveMessagesAsync(10, TimeSpan.FromSeconds(1));
            foreach (QueueMessage message in received.Value)
            {
                // Tell the service we need a little more time to process the
                // message by giving them a 5 second visiblity window
                UpdateReceipt receipt = await queue.UpdateMessageAsync(
                    message.MessageId,
                    message.PopReceipt,
                    message.Body,
                    TimeSpan.FromSeconds(5));

                // Keep track of the updated messages
                messages.Add(message.Update(receipt));
            }

            // Wait until the original 1 second visiblity window times out and
            // check to make sure the messages aren't showing up yet
            await Task.Delay(TimeSpan.FromSeconds(1.5));
            Assert.AreEqual(0, (await queue.ReceiveMessagesAsync(10)).Value.Length);

            // Finish processing the messages
            foreach (QueueMessage message in messages)
            {
                // "Process" the message
                Console.WriteLine($"Message: {message.Body}");

                // Tell the service we need a little more time to process the message
                await queue.DeleteMessageAsync(message.MessageId, message.PopReceipt);
            }
        }

        /// <summary>
        /// Authenticate via Azure Active Directory.
        ///
        /// Azure Storage provides integration with Azure Active Directory
        /// (Azure AD) for identity-based authentication of requests to the
        /// Queue and Queue services. With Azure AD, you can use role-based
        /// access control (RBAC) to grant access to your Azure Storage
        /// resources to users, groups, or applications. You can grant
        /// permissions that are scoped to the level of an individual
        /// container or queue.
        ///
        /// To learn more about Azure AD integration in Azure Storage, see
        /// https://docs.microsoft.com/en-us/azure/storage/common/storage-auth-aad
        /// </summary>
        public static void IdentityAuth()
        {
            // Create a QueueClient that will authenticate through Active Directory
            Uri queueUri = new Uri("https://MYSTORAGEACCOUNT.blob.core.windows.net/QUEUENAME");
            QueueClient queue = new QueueClient(queueUri, new DefaultAzureCredential());
        }

        /// <summary>
        /// Trigger a recoverable error.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string to your Azure Storage account.
        /// </param>
        /// <param name="queueName">
        /// The name of an existing queue to operate on.
        /// </param>
        public static async Task ErrorsAsync(string connectionString, string queueName)
        {
            try
            {
                // Try to create a queue that already exists
                QueueClient queue = new QueueClient(connectionString, queueName);
                await queue.CreateAsync();
            }
            catch (RequestFailedException ex)
                when (ex.ErrorCode == QueueErrorCode.QueueAlreadyExists)
            {
                // Ignore any errors if the queue already exists
            }
        }
    }
}
