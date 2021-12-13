// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs
{
    internal class FakeStorageAccountProvider : StorageAccountProvider
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

    // Helpeful test extensions
}