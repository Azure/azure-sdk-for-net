// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage.Queue;

using StorageCredentials = Microsoft.Azure.Storage.Auth.StorageCredentials;
using TableStorageCredentials = Microsoft.Azure.Cosmos.Table.StorageCredentials;

namespace FakeStorage
{
    public class FakeAccount
    {
        internal StorageCredentials _creds = new StorageCredentials("fakeaccount", "key1");
        internal TableStorageCredentials _tableCreds = new TableStorageCredentials("fakeaccount", "key1");

        internal readonly MemoryBlobStore _blobStore = new MemoryBlobStore();
        internal readonly MemoryTableStore Store = new MemoryTableStore();
        internal readonly MemoryQueueStore _queueStore = new MemoryQueueStore();

        public string Name => _creds.AccountName;

        public CloudQueueClient CreateCloudQueueClient()
        {
            return new FakeQueueClient(this);
        }

        public CloudTableClient CreateCloudTableClient()
        {
            return new FakeTableClient(this);
        }

        public CloudBlobClient CreateCloudBlobClient()
        {
            return new FakeStorageBlobClient(this);
        }

        // For testing, set a blob instance. 
        public void SetBlob(string containerName, string blobName, ICloudBlob blob)
        {
            _blobStore.SetBlob(containerName, blobName, blob);
        }
    }
}