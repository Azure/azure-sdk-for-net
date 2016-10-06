// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Management.Network.Fluent.Models;
    using Resource.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for Networks.
    /// </summary>
    public partial class NetworksImpl  :
        GroupableResources<
            INetwork,
            NetworkImpl,
            VirtualNetworkInner,
            IVirtualNetworksOperations,
            NetworkManager>,
        INetworks
    {
        internal  NetworksImpl (NetworkManagementClient networkClient, NetworkManager networkManager)
            : base(networkClient.VirtualNetworks, networkManager)
        {
        }

        internal PagedList<INetwork> List ()
        {
            var pagedList = new PagedList<VirtualNetworkInner>(InnerCollection.ListAll(), (string nextPageLink) =>
            {
                return InnerCollection.ListAllNext(nextPageLink);
            });

            return WrapList(pagedList);
        }

        internal PagedList<INetwork> ListByGroup (string groupName)
        {
            var pagedList = new PagedList<VirtualNetworkInner>(InnerCollection.List(groupName), (string nextPageLink) =>
            {
                return InnerCollection.ListNext(nextPageLink);
            });

            return WrapList(pagedList);
        }

        internal NetworkImpl Define (string name)
        {
            return WrapModel(name);
        }

        Task DeleteAsync(string groupName, string name)
        {
            return InnerCollection.DeleteAsync(groupName, name);
        }

        public override async Task<INetwork> GetByGroupAsync(string groupName, string name)
        {
            var data = await InnerCollection.GetAsync(groupName, name);
            return WrapModel(data);
        }

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
        override protected INetwork WrapModel (VirtualNetworkInner inner)
        {
            return new NetworkImpl(inner.Name, inner, InnerCollection, Manager);
        }

        public void Delete(string id)
        {
            DeleteAsync(id).Wait();
        }

        public Task DeleteAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        public void Delete(string groupName, string name)
        {
            DeleteAsync(groupName, name).Wait();
        }
    }
}