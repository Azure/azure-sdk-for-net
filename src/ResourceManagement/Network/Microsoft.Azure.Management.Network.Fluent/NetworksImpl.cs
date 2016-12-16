// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTmV0d29ya3NJbXBs
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Resource.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for Networks.
    /// </summary>
    internal partial class NetworksImpl  :
        GroupableResources<
            INetwork,
            NetworkImpl,
            VirtualNetworkInner,
            IVirtualNetworksOperations,
            INetworkManager>,
        INetworks
    {
        internal  NetworksImpl (NetworkManagementClient networkClient, NetworkManager networkManager)
            : base(networkClient.VirtualNetworks, networkManager)
        {
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:36E25639805611CF89054C004B22BB15
        internal PagedList<INetwork> List ()
        {
            var pagedList = new PagedList<VirtualNetworkInner>(InnerCollection.ListAll(), (string nextPageLink) =>
            {
                return InnerCollection.ListAllNext(nextPageLink);
            });

            return WrapList(pagedList);
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:3953AC722DFFCDF40E1EEF787AFD1326
        internal PagedList<INetwork> ListByGroup (string groupName)
        {
            var pagedList = new PagedList<VirtualNetworkInner>(InnerCollection.List(groupName), (string nextPageLink) =>
            {
                return InnerCollection.ListNext(nextPageLink);
            });

            return WrapList(pagedList);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        internal NetworkImpl Define (string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:3F66CB38737E789E83D4F94D3B9FA876:B9B028D620AC932FDF66D2783E476B0D
        public override Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return InnerCollection.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:7C0A1D0C3FE28C45F35B565F4AFF751D
        public override async Task<INetwork> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var data = await InnerCollection.GetAsync(groupName, name, null, cancellationToken);
            return WrapModel(data);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:A3374975BF5618E060C608FF1729A058
        override protected NetworkImpl WrapModel (string name)
        {
            VirtualNetworkInner inner = new VirtualNetworkInner();
            
            // Initialize address space
            AddressSpace addressSpace = inner.AddressSpace;
            if (addressSpace == null)
            {
                addressSpace = new AddressSpace();
                inner.AddressSpace = addressSpace;
            }

            if (addressSpace.AddressPrefixes == null)
            {
                addressSpace.AddressPrefixes = new List<string>();
            }
            
            // Initialize subnets
            if (inner.Subnets == null)
            {
                inner.Subnets = new List<SubnetInner>();
            }

            // Initialize DHCP options (DNS servers)
            DhcpOptions dhcp = inner.DhcpOptions;
            if (dhcp == null)
            {
                dhcp = new DhcpOptions();
                inner.DhcpOptions = dhcp;
            }

            if (dhcp.DnsServers == null)
            {
                dhcp.DnsServers = new List<string>();
            }
            
            return new NetworkImpl(name, inner, InnerCollection, Manager);
        }

        //$TODO: this should return NetworkImpl
        ///GENMHASH:95C9E8EAF4F740DFFF516E71ABF00C42:E81780AEFA4C9F41FD95A65101672DF8
        override protected INetwork WrapModel (VirtualNetworkInner inner)
        {
            return new NetworkImpl(inner.Name, inner, InnerCollection, Manager);
        }
    }
}
