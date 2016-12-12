// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Rest.Azure;

    /// <summary>
    /// The implementation of ComputeUsages.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uQ29tcHV0ZVVzYWdlc0ltcGw=
    internal partial class ComputeUsagesImpl :
        ReadableWrappers<Microsoft.Azure.Management.Compute.Fluent.IComputeUsage, Microsoft.Azure.Management.Compute.Fluent.ComputeUsageImpl, Models.Usage>,
        IComputeUsages
    {
        private IComputeManagementClient client;

        ///GENMHASH:38AF54D6D93CDEF7138D771AB45B7132:FCBE9313644315745EDD2396965C2FE2
        internal ComputeUsagesImpl(IComputeManagementClient client)
        {
            this.client = client;
        }

        ///GENMHASH:BA2FEDDF9D78BF55786D81F6C85E907C:278D096DC6C27545470C89C8D1259A16
        public PagedList<Microsoft.Azure.Management.Compute.Fluent.IComputeUsage> ListByRegion(Region region)
        {
            return ListByRegion(region.Name);
        }

        ///GENMHASH:360BB74037893879A730ED7ED0A3938A:34BF45703D53DEAC832C7449858B69FC
        public PagedList<Microsoft.Azure.Management.Compute.Fluent.IComputeUsage> ListByRegion(string regionName)
        {
            IPage<Usage> firstPage = client.Usage.List(regionName);
            var pagedList = new PagedList<Usage>(firstPage, (string nextPageLink) =>
            {
                return client.Usage.ListNext(nextPageLink);
            });
            return WrapList(pagedList);
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