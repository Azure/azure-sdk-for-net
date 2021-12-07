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
        public string Name => _creds.AccountName;
        public CloudTableClient CreateCloudTableClient()
        {
            return new FakeTableClient(this);
        }
    }
}