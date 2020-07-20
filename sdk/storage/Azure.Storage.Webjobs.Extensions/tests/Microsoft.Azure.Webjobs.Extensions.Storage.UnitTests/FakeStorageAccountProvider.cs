// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage.Queue;

namespace Microsoft.Azure.WebJobs
{
    public class FakeStorageAccountProvider : StorageAccountProvider
    {
        private readonly StorageAccount _account;

        public FakeStorageAccountProvider(StorageAccount account)
            : base(null)
        {
            this._account = account;
        }
        public override StorageAccount Get(string name)
        {
            return _account;
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    public class FakeStorageAccount : StorageAccount
#pragma warning restore SA1402 // File may only contain a single type
    {
        private FakeStorage.FakeAccount _account2 = new FakeStorage.FakeAccount();

        public override CloudQueueClient CreateCloudQueueClient()
        {
            return _account2.CreateCloudQueueClient();
        }
        public override CloudBlobClient CreateCloudBlobClient()
        {
            return _account2.CreateCloudBlobClient();
        }

        public override string Name => _account2.Name;
        public override bool IsDevelopmentStorageAccount() { return true; }
    }

    // Helpeful test extensions
#pragma warning disable SA1402 // File may only contain a single type
    public static class FakeStorageAccountExtensions
#pragma warning restore SA1402 // File may only contain a single type
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
