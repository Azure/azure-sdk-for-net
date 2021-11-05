// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Queues.Models;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Triggers
{
    internal class CloudQueueMessageDirectConverter : IConverter<QueueMessage, QueueMessage>
    {
        public QueueMessage Convert(QueueMessage input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return input;
        }
    }
}
