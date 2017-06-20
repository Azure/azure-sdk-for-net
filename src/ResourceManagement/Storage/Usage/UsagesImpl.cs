// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Storage.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.Storage.Fluent
{
    internal class UsagesImpl : ReadableWrappers<IStorageUsage, UsageImpl, Usage>,
        IUsages
    {
        private IUsageOperations client;

        internal UsagesImpl(IUsageOperations client)
        {
            this.client = client;
        }

        public IEnumerable<IStorageUsage> List()
        {
            if (client.List() == null)
            {
                return new List<IStorageUsage>();
            }
            return WrapList(client.List());
        }

        public async Task<IPagedCollection<IStorageUsage>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IStorageUsage, Usage>.LoadPage(client.ListAsync, WrapModel, cancellationToken);
        }

        protected override IStorageUsage WrapModel(Usage inner)
        {
            return new UsageImpl(inner);
        }
    }
}
