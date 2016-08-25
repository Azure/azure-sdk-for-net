/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Resource;
    using Management.Network;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System;
    using System.Threading;

    /// <summary>
    /// Implementation for {@link Networks}.
    /// </summary>
    public partial class NetworksImpl :
        GroupableResources<INetwork, NetworkImpl, VirtualNetworkInner, IVirtualNetworksOperations, NetworkManager>,
        INetworks
    {
        internal NetworksImpl(NetworkManagementClient networkClient, NetworkManager networkManager) : 
            base(networkClient.VirtualNetworks, networkManager)
        {
        }

        public PagedList<INetwork> List()
        {
            IEnumerable<VirtualNetworkInner> list = InnerCollection.ListAll();
            var pagedList = new PagedList<VirtualNetworkInner>(list);
            return this.WrapList(pagedList);
        }

        public PagedList<INetwork> ListByGroup(string groupName)
        {
            IEnumerable<VirtualNetworkInner> list = InnerCollection.List(groupName);
            var pagedList = new PagedList<VirtualNetworkInner>(list);
            return this.WrapList(pagedList);
        }

        public void Delete(string id)
        {
            this.Delete(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        public void Delete(string groupName, string name)
        {
            this.InnerCollection.Delete(groupName, name);
        }

        public NetworkImpl Define(string name)
        {
            return this.WrapModel(name);
        }

        protected override NetworkImpl WrapModel(string name)
        {
            VirtualNetworkInner inner = new VirtualNetworkInner(default(string), default(string), name);

            // Initialize address space
            AddressSpace addressSpace = inner.AddressSpace;
            if (addressSpace == null)
            {
                addressSpace = new AddressSpace();
                inner.AddressSpace = addressSpace;
            }

            if (addressSpace.AddressPrefixes == null)
            {
                addressSpace.AddressPrefixes  =new List<string>();
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

            return this.WrapModel(inner) as NetworkImpl;
        }

        protected override INetwork WrapModel(VirtualNetworkInner inner)
        {
            return new NetworkImpl(
                inner.Name,
                inner,
                this.InnerCollection as VirtualNetworksOperations,
                this.MyManager);
        }

        public Task<PagedList<INetwork>> ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            await this.InnerCollection.DeleteAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id), cancellationToken);
        }

        public async Task DeleteAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await this.InnerCollection.DeleteAsync(groupName, name, cancellationToken);
        }

        public async override Task<INetwork> GetByGroupAsync(string groupName, string name)
        {
            var data = await this.InnerCollection.GetAsync(groupName, name);
            return this.WrapModel(data);
        }
    }
}