// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Storage.Queues.Models;

namespace Microsoft.Azure.WebJobs.Host.Queues.Triggers
{
    internal class StorageQueueMessageToByteArrayConverter : IConverter<QueueMessage, byte[]>
    {
        public byte[] Convert(QueueMessage input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            // TODO (kasobol-msft) revisit this base64/BinaryData
            return Encoding.UTF8.GetBytes(input.MessageText);
        }
    }
}
