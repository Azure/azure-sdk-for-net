// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Storage.Queue;
using System;

namespace Microsoft.Azure.WebJobs.Host.Queues.Triggers
{
    internal class StorageQueueMessageToByteArrayConverter : IConverter<CloudQueueMessage, byte[]>
    {
        public byte[] Convert(CloudQueueMessage input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return input.AsBytes;
        }
    }
}
