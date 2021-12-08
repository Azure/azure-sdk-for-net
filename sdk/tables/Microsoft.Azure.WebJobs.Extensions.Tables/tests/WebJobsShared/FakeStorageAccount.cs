// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs
{
    internal class FakeStorageAccount : StorageAccount
    {
        private FakeStorage.FakeAccount _account2 = new FakeStorage.FakeAccount();
        public override CloudTableClient CreateCloudTableClient()
        {
            return _account2.CreateCloudTableClient();
        }
    }
}