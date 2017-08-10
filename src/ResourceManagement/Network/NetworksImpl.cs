// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;
    using Rest.Azure;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for Networks.
    /// </summary>
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTmV0d29ya3NJbXBs
    internal partial class NetworksImpl  :
        TopLevelModifiableResources<
            INetwork,
            NetworkImpl,
            VirtualNetworkInner,
            IVirtualNetworksOperations,
            INetworkManager>,
        INetworks
    {
        
        ///GENMHASH:3A6A0751052AB516180B0159DB204F6D:6EDFD09151C46F1D2C3B423AC05A1639
        internal  NetworksImpl (NetworkManager networkManager)
            : base(networkManager.Inner.VirtualNetworks, networkManager)
        {
        }

        
        protected async override Task<IPage<VirtualNetworkInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAllAsync(cancellationToken);
        }

        protected async override Task<IPage<VirtualNetworkInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListAllNextAsync(nextLink, cancellationToken);
        }

        
        protected async override Task<IPage<VirtualNetworkInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(groupName, cancellationToken);
        }

        protected async override Task<IPage<VirtualNetworkInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

        
        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        internal NetworkImpl Define (string name)
        {
            return WrapModel(name);
        }

        
        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        
        protected async override Task<VirtualNetworkInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken: cancellationToken);
        }

        
        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:8923589BAA698713A3D55DA89CCA0561
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
            return new NetworkImpl(name, inner, Manager);
        }

        //$TODO: this should return NetworkImpl

        
        ///GENMHASH:95C9E8EAF4F740DFFF516E71ABF00C42:7A8F66C1BE7268F607FE53906E378ECA
        override protected INetwork WrapModel (VirtualNetworkInner inner)
        {
            return new NetworkImpl(inner.Name, inner, Manager);
        }
    }
}
