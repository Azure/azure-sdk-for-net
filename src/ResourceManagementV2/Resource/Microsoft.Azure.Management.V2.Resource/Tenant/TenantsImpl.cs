using System;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.V2.Resource
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
