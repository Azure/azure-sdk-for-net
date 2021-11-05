// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Triggers
{
    internal class StringToStorageQueueMessageConverter : IConverter<string, QueueMessage>
    {
        private readonly QueueClient _queue;

        public StringToStorageQueueMessageConverter(QueueClient queue)
        {
            if (queue == null)
            {
                throw new ArgumentNullException(nameof(queue));
            }

            _queue = queue;
        }

        public QueueMessage Convert(string input)
        {
            return QueuesModelFactory.QueueMessage(null, null, input, 0);
        }
    }
}
