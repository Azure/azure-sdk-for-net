// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using ResourceManager.Fluent.Core;
    using Models;
    using Rest.Azure;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Threading;

    /// <summary>
    /// The implementation of ComputeUsages.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uQ29tcHV0ZVVzYWdlc0ltcGw=
    internal partial class ComputeUsagesImpl :
        ReadableWrappers<IComputeUsage, ComputeUsageImpl, Usage>,
        IComputeUsages
    {
        private IComputeManagementClient client;

        ///GENMHASH:38AF54D6D93CDEF7138D771AB45B7132:FCBE9313644315745EDD2396965C2FE2
        internal ComputeUsagesImpl(IComputeManagementClient client)
        {
            this.client = client;
        }

        ///GENMHASH:BA2FEDDF9D78BF55786D81F6C85E907C:278D096DC6C27545470C89C8D1259A16
        public IEnumerable<IComputeUsage> ListByRegion(Region region)
        {
            return ListByRegion(region.Name);
        }

        ///GENMHASH:360BB74037893879A730ED7ED0A3938A:34BF45703D53DEAC832C7449858B69FC
        public IEnumerable<IComputeUsage> ListByRegion(string regionName)
        {
            return WrapList(Extensions.Synchronize(() => client.Usage.ListAsync(regionName))
                .AsContinuousCollection(link => Extensions.Synchronize(() => client.Usage.ListNextAsync(link))));
        }

        ///GENMHASH:271CC39CE723B6FD3D7CCA7471D4B201:039795D842B96323D94D260F3FF83299
        public async Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IComputeUsage>> ListByRegionAsync(Region region, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ListByRegionAsync(region.Name, cancellationToken);
        }

        ///GENMHASH:2ED29FF482F2137640A1CA66925828A8:DBED7C5E8F3D15AA49FB5B3D4C6C961C
        public async Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IComputeUsage>> ListByRegionAsync(string regionName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IComputeUsage, Usage>.LoadPage(
                 async (cancellation) => await client.Usage.ListAsync(regionName, cancellation),
                 client.Usage.ListNextAsync,
                 WrapModel,
                 false,
                 cancellationToken);
        }

        ///GENMHASH:438AA0AEE9E5AB3F7FB0CB3404AB0062:347158454CE9D4F224065BB056903D09
        protected override IComputeUsage WrapModel(Usage usageInner)
        {
            if (usageInner == null) {
                return null;
            }
            return new ComputeUsageImpl(usageInner);
        }
    }
}
