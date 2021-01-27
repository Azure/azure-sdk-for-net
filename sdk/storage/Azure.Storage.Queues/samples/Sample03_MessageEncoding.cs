// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Queues.Models;
using NUnit.Framework;

namespace Azure.Storage.Queues.Samples.Tests
{
    public class Sample03_MessageEncoding : SampleTest
    {
        [Test]
        public void ConfigureMessageEncodingAsync()
        {
            var connectionString = ConnectionString;
            var queueName = "foo";
            #region Snippet:Azure_Storage_Queues_Samples_Sample03_MessageEncoding_ConfigureMessageEncodingAsync

            QueueClientOptions queueClientOptions = new QueueClientOptions()
            {
                MessageEncoding = QueueMessageEncoding.Base64
            };

            QueueClient queueClient = new QueueClient(connectionString, queueName, queueClientOptions);
            #endregion
        }

        [Test]
        public void InvalidMessageHandlerAsync()
        {
            var connectionString = ConnectionString;
            var queueName = "foo";
            #region Snippet:Azure_Storage_Queues_Samples_Sample03_MessageEncoding_InvalidMessageHandlerAsync

            QueueClientOptions queueClientOptions = new QueueClientOptions()
            {
                MessageEncoding = QueueMessageEncoding.Base64
            };

            queueClientOptions.OnInvalidMessage += async (InvalidMessageEventArgs args) =>
            {
                if (args.Message is PeekedMessage peekedMessage)
                {
                    Console.WriteLine($"Invalid message has been peeked, message id={peekedMessage.MessageId} body={peekedMessage.Body}");
                }
                else if (args.Message is QueueMessage queueMessage)
                {
                    Console.WriteLine($"Invalid message has been received, message id={queueMessage.MessageId} body={queueMessage.Body}");

                    if (args.RunSynchronously)
                    {
                        args.QueueClient.DeleteMessage(queueMessage.MessageId, queueMessage.PopReceipt);
                    }
                    else
                    {
                        await args.QueueClient.DeleteMessageAsync(queueMessage.MessageId, queueMessage.PopReceipt);
                    }
                }
            };

            QueueClient queueClient = new QueueClient(connectionString, queueName, queueClientOptions);
            #endregion
        }
    }
}
