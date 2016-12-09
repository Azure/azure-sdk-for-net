// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    internal class NetworkUsagesImpl : ReadableWrappers<INetworkUsage, NetworkUsageImpl, Usage>, INetworkUsages
    {
        private INetworkManagementClient client;

        internal NetworkUsagesImpl(INetworkManagementClient client) 
        {
            this.client = client;
        }

        public PagedList<INetworkUsage> ListByRegion(string regionName)
        {
            var pagedList = new PagedList<Usage>(this.client.Usages.List(regionName), (string nextPageLink) =>
            {
                return this.client.Usages.ListNext(nextPageLink);
            });
            return WrapList(pagedList);
        }

        public PagedList<INetworkUsage> ListByRegion(Region region)
        {
            return ListByRegion(region.ToString());
        }

        protected override INetworkUsage WrapModel(Usage inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new NetworkUsageImpl(inner);
        }
    }
}
