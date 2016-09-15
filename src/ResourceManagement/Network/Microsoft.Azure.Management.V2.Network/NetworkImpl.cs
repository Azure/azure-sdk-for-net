/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using System.Threading;
    using Microsoft.Rest;
    using Microsoft.Azure.Management.V2.Network.Network.Update;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.V2.Network.Network.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Resource;
    using Management.Network;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Implementation for {@link Network} and its create and update interfaces.
    /// </summary>
    public partial class NetworkImpl :
        GroupableResource<INetwork, 
            VirtualNetworkInner,
            Rest.Azure.Resource,
            NetworkImpl, 
            NetworkManager,
            Network.Definition.IWithGroup,
            Network.Definition.IWithCreate,
            Network.Definition.IWithCreate,
            Network.Update.IUpdate>,
        INetwork,
        IDefinition,
        IUpdate
    {
        private VirtualNetworksOperations innerCollection;
        private Dictionary<string, ISubnet> subnets;
        private string name;
        private VirtualNetworkInner inner;
        private IVirtualNetworksOperations innerCollection1;
        private NetworkManager myManager;

        internal NetworkImpl(string name, VirtualNetworkInner innerModel, VirtualNetworksOperations innerCollection, NetworkManager networkManager) :
            base(name, innerModel, networkManager)
        {
            this.innerCollection = innerCollection;
            this.InitializeSubnetsFromInner();
        }

        private void InitializeSubnetsFromInner()
        {
            this.subnets = new Dictionary<string, ISubnet>();
            foreach (SubnetInner subnetInner in this.Inner.Subnets)
            {
                SubnetImpl subnet = new SubnetImpl(subnetInner, this);
                this.subnets.Add(subnetInner.Name, subnet);
            }
        }

        public override Task<INetwork> Refresh()
        {
            var task = new Task<INetwork>(() =>
            {
                var response = this.innerCollection.Get(this.ResourceGroupName, this.Name);
                SetInner(response);
                return this;
            });

            task.Start();
            return task;
        }

        internal NetworkImpl WithSubnet(SubnetImpl subnet)
        {
            this.Inner.Subnets.Add(subnet.Inner);
            this.subnets.Add(subnet.Name, subnet);
            return this;
        }

        public NetworkImpl WithDnsServer(string ipAddress)
        {
            this.Inner.DhcpOptions.DnsServers.Add(ipAddress);
            return this;
        }

        public NetworkImpl WithSubnet(string name, string cidr)
        {
            return this.DefineSubnet(name)
                .WithAddressPrefix(cidr)
                .Attach();
        }

        public NetworkImpl WithSubnets(IDictionary<string, string> nameCidrPairs)
        {
            List<SubnetInner> azureSubnets = new List<SubnetInner>();
            this.Inner.Subnets = azureSubnets;
            this.InitializeSubnetsFromInner();
            foreach (KeyValuePair<string, string> pair in nameCidrPairs)
            {
                this.WithSubnet(pair.Key, pair.Value);
            }

            return this;
        }

        public NetworkImpl WithoutSubnet(string name)
        {
            // Remove from cache
            this.subnets.Remove(name);

            // Remove from inner
            IList<SubnetInner> innerSubnets = this.Inner.Subnets;
            for (int i = 0; i < innerSubnets.Count; i++)
            {
                if (innerSubnets[i].Name.Equals(name, System.StringComparison.OrdinalIgnoreCase))
                {
                    innerSubnets.Remove(innerSubnets[i]);
                    break;
                }
            }

            return this;
        }

        public NetworkImpl WithAddressSpace(string cidr)
        {
            this.Inner.AddressSpace.AddressPrefixes.Add(cidr);
            return this;
        }

        public SubnetImpl DefineSubnet(string name)
        {
            SubnetInner inner = new SubnetInner();
            inner.Name = name;
            return new SubnetImpl(inner, this);
        }

        public IList<string> AddressSpaces
        {
            get
            {
                return new ReadOnlyCollection<string>(this.Inner.AddressSpace.AddressPrefixes);
            }
        }

        public IList<string> DnsServerIPs
        {
            get
            {
                return new ReadOnlyCollection<string>(this.Inner.DhcpOptions.DnsServers);
            }
        }
        public IDictionary<string, ISubnet> Subnets()
        {
            return new ReadOnlyDictionary<string, ISubnet>(this.subnets);
        }

        private void EnsureCreationPrerequisites()
        {
            // Ensure address spaces
            if (this.AddressSpaces.Count == 0)
            {
                this.WithAddressSpace("10.0.0.0/16");
            }

            if (IsInCreateMode)
            {
                // Create a subnet as needed, covering the entire first address space
                if (this.Inner.Subnets.Count == 0)
                {
                    this.WithSubnet("subnet1", this.AddressSpaces[0]);
                }
            }
        }

        public SubnetImpl UpdateSubnet(string name)
        {
            return (SubnetImpl)this.subnets[name];
        }


        public async override Task<INetwork> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {

            NetworkImpl self = this;
            this.EnsureCreationPrerequisites();
            var data = await this.innerCollection.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, this.Inner);
            self.SetInner(data);
            this.InitializeSubnetsFromInner();
            return this;
        }
    }
}