// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Management.Network.Fluent;
    using Management.Network.Fluent.Models;
    using Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class NetworkUsagesImpl : ReadableWrappers<INetworkUsage, NetworkUsageImpl, Usage>, INetworkUsages
    {
        private INetworkManagementClient client;

        internal NetworkUsagesImpl(INetworkManagementClient client)
        {
            this.client = client;
        }

        public IEnumerable<INetworkUsage> ListByRegion(string regionName)
        {
            return WrapList(Extensions.Synchronize(() => client.Usages.ListAsync(regionName))
                .AsContinuousCollection(link => Extensions.Synchronize(() => client.Usages.ListNextAsync(link))));
        }

        public IEnumerable<INetworkUsage> ListByRegion(Region region)
        {
            return ListByRegion(region.ToString());
        }

        public async Task<IPagedCollection<INetworkUsage>> ListByRegionAsync(Region region, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ListByRegionAsync(region.Name, cancellationToken);
        }

        public async Task<IPagedCollection<INetworkUsage>> ListByRegionAsync(string regionName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<INetworkUsage, Usage>.LoadPage(
                 async (cancellation) => await client.Usages.ListAsync(regionName, cancellation),
                 client.Usages.ListNextAsync,
                 WrapModel,
                 false,
                 cancellationToken);
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
