// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    internal class TenantsImpl :
        ITenants
    {
        private ITenantsOperations innerCollection;
        internal TenantsImpl(ITenantsOperations client)
        {
            this.innerCollection = client;
        }

        public async Task<IPagedCollection<ITenant>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<ITenant, TenantIdDescription>.LoadPage(
                async (cancellation) => await innerCollection.ListAsync(cancellation),
                innerCollection.ListNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }

        IEnumerable<ITenant> ISupportsListing<ITenant>.List()
        {
            return Extensions.Synchronize(() => innerCollection.ListAsync())
                                  .AsContinuousCollection(link => Extensions.Synchronize(() => innerCollection.ListNextAsync(link)))
                                  .Select(inner => WrapModel(inner));
        }

        private ITenant WrapModel(TenantIdDescription inner)
        {
            return new TenantImpl(inner);
        }
    }
}
