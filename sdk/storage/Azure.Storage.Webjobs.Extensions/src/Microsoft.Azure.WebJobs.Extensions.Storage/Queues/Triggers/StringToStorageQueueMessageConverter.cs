// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.Storage.Queue;

namespace Microsoft.Azure.WebJobs.Host.Queues.Triggers
{
    internal class StringToStorageQueueMessageConverter : IConverter<string, CloudQueueMessage>
    {
        private readonly CloudQueue _queue;

        public StringToStorageQueueMessageConverter(CloudQueue queue)
        {
            if (queue == null)
            {
                throw new ArgumentNullException(nameof(queue));
            }

            _queue = queue;
        }

        public CloudQueueMessage Convert(string input)
        {
            return new CloudQueueMessage(input);
        }
    }
}
