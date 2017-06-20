// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Management.Network.Fluent;
    using Management.Network.Fluent.Models;
    using Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal class NetworkUsagesImpl : ReadableWrappers<INetworkUsage, NetworkUsageImpl, Usage>, INetworkUsages
    {
        private INetworkManagementClient client;

        internal NetworkUsagesImpl(INetworkManagementClient client)
        {
            this.client = client;
        }

        public IEnumerable<INetworkUsage> ListByRegion(string regionName)
        {
            return WrapList(client.Usages.List(regionName).AsContinuousCollection(link => client.Usages.ListNext(link)));
        }

        public IEnumerable<INetworkUsage> ListByRegion(Region region)
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
