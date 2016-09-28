// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.Network.Models;
    using System.Threading.Tasks;
    using System.Threading;
    using Microsoft.Azure.Management.V2.Resource;
    using Management.Network;
    using System;

    /// <summary>
    /// Implementation for Networks.
    /// </summary>
    public partial class NetworksImpl  :
        GroupableResources<
            Microsoft.Azure.Management.V2.Network.INetwork,
            Microsoft.Azure.Management.V2.Network.NetworkImpl,
            Microsoft.Azure.Management.Network.Models.VirtualNetworkInner,
            IVirtualNetworksOperations,
            NetworkManager>,
        INetworks
    {
        internal  NetworksImpl (NetworkManagementClient networkClient, NetworkManager networkManager)
            : base(networkClient.VirtualNetworks, networkManager)
        {

            //$ final NetworkManagementClientImpl networkClient,
            //$ final NetworkManager networkManager) {
            //$ super(networkClient.virtualNetworks(), networkManager);
            //$ }

        }

        public PagedList<Microsoft.Azure.Management.V2.Network.INetwork> List ()
        {

            //$ return wrapList(this.innerCollection.listAll());

            return null;
        }

        public PagedList<Microsoft.Azure.Management.V2.Network.INetwork> ListByGroup (string groupName)
        {

            //$ return wrapList(this.innerCollection.list(groupName));

            return null;
        }

        public NetworkImpl Define (string name)
        {

            //$ return wrapModel(name);

            return null;
        }

        Task DeleteAsync(string groupName, string name)
        {
            throw new NotImplementedException();
        }

        public override async Task<INetwork> GetByGroupAsync(string groupName, string name)
        {
            return this as INetwork;
        }

        override protected NetworkImpl WrapModel (string name)
        {

            //$ VirtualNetworkInner inner = new VirtualNetworkInner();
            //$ 
            //$ // Initialize address space
            //$ AddressSpace addressSpace = inner.addressSpace();
            //$ if (addressSpace == null) {
            //$ addressSpace = new AddressSpace();
            //$ inner.withAddressSpace(addressSpace);
            //$ }
            //$ 
            //$ if (addressSpace.addressPrefixes() == null) {
            //$ addressSpace.withAddressPrefixes(new ArrayList<String>());
            //$ }
            //$ 
            //$ // Initialize subnets
            //$ if (inner.subnets() == null) {
            //$ inner.withSubnets(new ArrayList<SubnetInner>());
            //$ }
            //$ 
            //$ // Initialize DHCP options (DNS servers)
            //$ DhcpOptions dhcp = inner.dhcpOptions();
            //$ if (dhcp == null) {
            //$ dhcp = new DhcpOptions();
            //$ inner.withDhcpOptions(dhcp);
            //$ }
            //$ 
            //$ if (dhcp.dnsServers() == null) {
            //$ dhcp.withDnsServers(new ArrayList<String>());
            //$ }
            //$ 
            //$ return new NetworkImpl(
            //$ name,
            //$ inner,
            //$ this.innerCollection,
            //$ super.myManager);

            return null;
        }

        //$TODO: this should return NetworkImpl
        override protected INetwork WrapModel (VirtualNetworkInner inner)
        {

            //$ return new NetworkImpl(
            //$ inner.name(),
            //$ inner,
            //$ this.innerCollection,
            //$ this.myManager);

            return null;
        }

        Task<PagedList<INetwork>> ISupportsListingByGroup<INetwork>.ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        void ISupportsDeleting.Delete(string id)
        {
            throw new NotImplementedException();
        }

        Task ISupportsDeleting.DeleteAsync(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        void ISupportsDeletingByGroup.Delete(string groupName, string name)
        {
            throw new NotImplementedException();
        }
    }
}