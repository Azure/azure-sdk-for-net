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
        public void MessageDecodingFailedHandlerAsync()
        {
            var connectionString = ConnectionString;
            var queueName = "foo";
            #region Snippet:Azure_Storage_Queues_Samples_Sample03_MessageEncoding_MessageDecodingFailedHandlerAsync

            QueueClientOptions queueClientOptions = new QueueClientOptions()
            {
                MessageEncoding = QueueMessageEncoding.Base64
            };

            queueClientOptions.MessageDecodingFailed += async (QueueMessageDecodingFailedEventArgs args) =>
            {
                if (args.PeekedMessage != null)
                {
                    Console.WriteLine($"Invalid message has been peeked, message id={args.PeekedMessage.MessageId} body={args.PeekedMessage.Body}");
                }
                else if (args.ReceivedMessage != null)
                {
                    Console.WriteLine($"Invalid message has been received, message id={args.ReceivedMessage.MessageId} body={args.ReceivedMessage.Body}");

                    if (args.IsRunningSynchronously)
                    {
                        args.Queue.DeleteMessage(args.ReceivedMessage.MessageId, args.ReceivedMessage.PopReceipt);
                    }
                    else
                    {
                        await args.Queue.DeleteMessageAsync(args.ReceivedMessage.MessageId, args.ReceivedMessage.PopReceipt);
                    }
                }
            };

            QueueClient queueClient = new QueueClient(connectionString, queueName, queueClientOptions);
            #endregion
        }
    }
}
