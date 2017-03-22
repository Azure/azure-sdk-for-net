// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Microsoft.Rest.Azure;

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

        PagedList<ITenant> ISupportsListing<ITenant>.List()
        {
            IPage<TenantIdDescription> firstPage = innerCollection.List();
            var innerList = new PagedList<TenantIdDescription>(firstPage, (string nextPageLink) =>
            {
                return innerCollection.ListNext(nextPageLink);
            });

            return new PagedList<ITenant>(new WrappedPage<TenantIdDescription, ITenant>(innerList.CurrentPage, WrapModel),
            (string nextPageLink) =>
            {
                innerList.LoadNextPage();
                return new WrappedPage<TenantIdDescription, ITenant>(innerList.CurrentPage, WrapModel);
            });
        }

        private ITenant WrapModel(TenantIdDescription inner)
        {
            return new TenantImpl(inner);
        }
    }
}
