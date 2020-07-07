// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.Azure.Storage.Queue;

namespace Microsoft.Azure.WebJobs.Host.TestCommon.AzureSdk
{
    public static class CloudQueueClientExtensions
    {
        public async static Task CreateQueueOrClearIfExists(this CloudQueueClient queueClient, string queueName)
        {
            CloudQueue queue = queueClient.GetQueueReference(queueName);

            bool wasCreatedNow = await queue.CreateIfNotExistsAsync();
            if (!wasCreatedNow)
            {
                await queue.ClearAsync();
            }
        }

        public async static Task DeleteQueueIfExists(this CloudQueueClient queueClient, string queueName)
        {
            CloudQueue queue = queueClient.GetQueueReference(queueName);

            if (await queue.ExistsAsync())
            {
                await queue.DeleteAsync();
            }
        }
    }
}
