// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Microsoft.Azure.Storage.Queue;

namespace Microsoft.Azure.WebJobs
{
    public static class FakeStorageAccountExtensions
    {
        public static async Task AddQueueMessageAsync(this StorageAccount account, CloudQueueMessage message, string queueName)
        {
            var client = account.CreateCloudQueueClient();
            var queue = client.GetQueueReference(queueName);
            await queue.CreateIfNotExistsAsync();
            await queue.ClearAsync();
            await queue.AddMessageAsync(message);
        }
    }
}