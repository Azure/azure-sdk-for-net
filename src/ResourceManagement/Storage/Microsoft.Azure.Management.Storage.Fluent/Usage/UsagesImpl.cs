// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Azure.Management.Storage.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System.Collections.Generic;

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

        protected override IStorageUsage WrapModel(Usage inner)
        {
            return new UsageImpl(inner);
        }
    }
}
