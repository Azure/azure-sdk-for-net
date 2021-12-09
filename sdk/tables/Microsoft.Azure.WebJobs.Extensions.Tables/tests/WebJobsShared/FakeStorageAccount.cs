// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.Storage.Queue;

namespace Microsoft.Azure.WebJobs
{
    internal class FakeStorageAccount : StorageAccount
    {
        private FakeStorage.FakeAccount _account2 = new FakeStorage.FakeAccount();
        public override CloudTableClient CreateCloudTableClient()
        {
            return _account2.CreateCloudTableClient();
        }
        public override string Name => _account2.Name;
        public override bool IsDevelopmentStorageAccount() { return true; }
    }
}