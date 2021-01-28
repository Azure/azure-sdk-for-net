// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
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
    public class Sample01a_HelloWorld
    {
        /// <summary>
        /// Create a queue and send a message.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string to your Azure Storage account.
        /// </param>
        /// <param name="queueName">
        /// The name of the queue to create and send a message to.
        /// </param>
        public static void SendMessage(string connectionString, string queueName)
        {
            #region Snippet:Azure_Storage_Queues_Samples_Sample01a_HelloWorld_SendMessage
            // We'll need a connection string to your Azure Storage account.
            // You can obtain your connection string from the Azure Portal
            // (click Access Keys under Settings in the Portal Storage account
            // blade) or using the Azure CLI with:
            //
            //     az storage account show-connection-string --name <account_name> --resource-group <resource_group>
            //
            // You would normally provide the connection string to your
            // application using an environment variable.
            //@@ string connectionString = "<connection_string>";

            // Name of the queue we'll send messages to
            //@@ string queueName = "sample-queue";

            // Get a reference to a queue and then create it
            QueueClient queue = new QueueClient(connectionString, queueName);
            queue.Create();

            // Send a message to our queue
            queue.SendMessage("Hello, Azure!");
            #endregion Snippet:Azure_Storage_Queues_Samples_Sample01a_HelloWorld_SendMessage
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
        public static void ReceiveMessages(string connectionString, string queueName)
        {
            #region Snippet:Azure_Storage_Queues_Samples_Sample01a_HelloWorld_ReceiveMessages
            // We'll need a connection string to your Azure Storage account.
            //@@ string connectionString = "<connection_string>";

            // Name of an existing queue we'll operate on
            //@@ string queueName = "sample-queue";

            // Get a reference to a queue and then fill it with messages
            QueueClient queue = new QueueClient(connectionString, queueName);
            queue.SendMessage("first");
            queue.SendMessage("second");
            queue.SendMessage("third");

            // Get the next messages from the queue
            foreach (QueueMessage message in queue.ReceiveMessages(maxMessages: 10).Value)
            {
                // "Process" the message
                Console.WriteLine($"Message: {message.Body}");

                // Let the service know we're finished with the message and
                // it can be safely deleted.
                queue.DeleteMessage(message.MessageId, message.PopReceipt);
            }
            #endregion Snippet:Azure_Storage_Queues_Samples_Sample01a_HelloWorld_ReceiveMessages
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
        public static void PeekMesssages(string connectionString, string queueName)
        {
            // Get a reference to a queue and then fill it with messages
            QueueClient queue = new QueueClient(connectionString, queueName);
            queue.SendMessage("first");
            queue.SendMessage("second");
            queue.SendMessage("third");

            // Get the messages from the queue
            foreach (PeekedMessage message in queue.PeekMessages(maxMessages: 10).Value)
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
        public static void ReceiveAndUpdate(string connectionString, string queueName)
        {
            // Add several messages to the queue
            QueueClient queue = new QueueClient(connectionString, queueName);
            queue.SendMessage("first");
            queue.SendMessage("second");
            queue.SendMessage("third");

            // Get the messages from the queue with a short visibility timeout
            // of 1 second
            List<QueueMessage> messages = new List<QueueMessage>();
            foreach (QueueMessage message in queue.ReceiveMessages(10, TimeSpan.FromSeconds(1)).Value)
            {
                // Tell the service we need a little more time to process the
                // message by giving them a 5 second visiblity window
                UpdateReceipt receipt = queue.UpdateMessage(
                    message.MessageId,
                    message.PopReceipt,
                    message.Body,
                    TimeSpan.FromSeconds(5));

                // Keep track of the updated messages
                messages.Add(message.Update(receipt));
            }

            // Wait until the original 1 second visiblity window times out and
            // check to make sure the messages aren't showing up yet
            Thread.Sleep(TimeSpan.FromSeconds(1.5));
            Assert.AreEqual(0, queue.ReceiveMessages(10).Value.Length);

            // Finish processing the messages
            foreach (QueueMessage message in messages)
            {
                // "Process" the message
                Console.WriteLine($"Message: {message.Body}");

                // Tell the service we need a little more time to process the message
                queue.DeleteMessage(message.MessageId, message.PopReceipt);
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
            #region Snippet:Azure_Storage_Queues_Samples_Sample01a_HelloWorld_IdentityAuth

            // Create a QueueClient that will authenticate through Active Directory
            Uri accountUri = new Uri("https://MYSTORAGEACCOUNT.blob.core.windows.net/");
            QueueClient queue = new QueueClient(accountUri, new DefaultAzureCredential());

            #endregion Snippet:Azure_Storage_Queues_Samples_Sample01a_HelloWorld_IdentityAuth
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
        public static void Errors(string connectionString, string queueName)
        {
            #region Snippet:Azure_Storage_Queues_Samples_Sample01a_HelloWorld_Errors
            // We'll need a connection string to your Azure Storage account.
            //@@ string connectionString = "<connection_string>";

            // Name of an existing queue we'll operate on
            //@@ string queueName = "sample-queue";

            try
            {
                // Try to create a queue that already exists
                QueueClient queue = new QueueClient(connectionString, queueName);
                queue.Create();
            }
            catch (RequestFailedException ex)
                when (ex.ErrorCode == QueueErrorCode.QueueAlreadyExists)
            {
                // Ignore any errors if the queue already exists
            }
            #endregion Snippet:Azure_Storage_Queues_Samples_Sample01a_HelloWorld_Errors
        }
    }
}
