// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;

namespace Microsoft.Azure.WebJobs.Host.Bindings.StorageAccount
{
    internal class CloudStorageAccountValueProvider : IValueProvider
    {
        private readonly CloudStorageAccount _account;

        public CloudStorageAccountValueProvider(CloudStorageAccount account)
        {
            _account = account;
        }

        public Type Type
        {
            get { return typeof(CloudStorageAccount); }
        }

        public Task<object> GetValueAsync()
        {
            return Task.FromResult<object>(_account);
        }

        public string ToInvokeString()
        {
            return null;
        }
    }
}
