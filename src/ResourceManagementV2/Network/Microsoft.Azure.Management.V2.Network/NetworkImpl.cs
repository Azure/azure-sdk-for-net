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

    /// <summary>
    /// Implementation for {@link Network} and its create and update interfaces.
    /// </summary>
    public class NetworkImpl :
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
        private NetworkImpl(string name, VirtualNetworkInner innerModel, VirtualNetworksOperations innerCollection, NetworkManager networkManager) :
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
                //TODO: need to make readonly
                return this.Inner.AddressSpace.AddressPrefixes;
            }
        }

        public IList<string> DnsServerIPs
        {
            get
            {
                //TODO: need to make readonly
                return this.Inner.DhcpOptions.DnsServers;
            }
        }
        public IDictionary<string, ISubnet> Subnets
        {
            get
            {
                //TODO: need to make readonly
                return this.subnets;
            }
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

        /// <summary>
        /// Explicitly adds an address space to the virtual network.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, a new address space is added to the network.
        /// <p>
        /// This method does not check for conflicts or overlaps with other address spaces. If there is a conflict,
        /// a cloud exception may be thrown after the update is applied.
        /// </summary>
        /// <param name="cidr">cidr the CIDR representation of the address space</param>
        /// <returns>the next stage of the virtual network update</returns>
        Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate Microsoft.Azure.Management.V2.Network.Network.Update.IWithAddressSpace.WithAddressSpace(string cidr)
        {
            return this.WithAddressSpace(cidr) as Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate;
        }


        /// <summary>
        /// Begins the description of an update of an existing subnet of this network.
        /// </summary>
        /// <param name="name">name the name of an existing subnet</param>
        /// <returns>the first stage of the subnet update description</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.Update.IUpdate Microsoft.Azure.Management.V2.Network.Network.Update.IWithSubnet.UpdateSubnet(string name)
        {
            return this.UpdateSubnet(name) as Microsoft.Azure.Management.V2.Network.Subnet.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new subnet to be added to this virtual network.
        /// </summary>
        /// <param name="name">name the name of the new subnet</param>
        /// <returns>the first stage of the new subnet definition</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition.IBlank<IUpdate> Microsoft.Azure.Management.V2.Network.Network.Update.IWithSubnet.DefineSubnet(string name)
        {
            return this.DefineSubnet(name) as Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition.IBlank<IUpdate>;
        }

        /// <summary>
        /// Explicitly adds a subnet to the virtual network.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, a new subnet is added to the network.
        /// </summary>
        /// <param name="name">name the name to assign to the subnet</param>
        /// <param name="cidr">cidr the address space of the subnet, within the address space of the network, using the CIDR notation</param>
        /// <returns>the next stage of the virtual network update</returns>
        Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate Microsoft.Azure.Management.V2.Network.Network.Update.IWithSubnet.WithSubnet(string name, string cidr)
        {
            return this.WithSubnet(name, cidr) as Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate;
        }

        /// <summary>
        /// Explicitly defines all the subnets in the virtual network based on the provided map.
        /// <p>
        /// This replaces any previously existing subnets.
        /// </summary>
        /// <param name="nameCidrPairs">nameCidrPairs a {@link Map} of CIDR addresses for the subnets, indexed by the name of each subnet to be added</param>
        /// <returns>the next stage of the virtual network update</returns>
        Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate Microsoft.Azure.Management.V2.Network.Network.Update.IWithSubnet.WithSubnets(IDictionary<string, string> nameCidrPairs)
        {
            return this.WithSubnets(nameCidrPairs) as Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate;
        }

        /// <summary>
        /// Removes a subnet from the virtual network.
        /// </summary>
        /// <param name="name">name name of the subnet to remove</param>
        /// <returns>the next stage of the virtual network update</returns>
        Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate Microsoft.Azure.Management.V2.Network.Network.Update.IWithSubnet.WithoutSubnet(string name)
        {
            return this.WithoutSubnet(name) as Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new subnet to add to the virtual network.
        /// <p>
        /// The definition must be completed with a call to {@link Subnet.DefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name of the subnet</param>
        /// <returns>the first stage of the new subnet definition</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.Definition.IBlank<IWithCreateAndSubnet> Microsoft.Azure.Management.V2.Network.Network.Definition.IWithSubnet.DefineSubnet(string name)
        {
            return this.DefineSubnet(name) as Microsoft.Azure.Management.V2.Network.Subnet.Definition.IBlank<IWithCreateAndSubnet>;
        }

        /// <summary>
        /// Explicitly adds a subnet to the virtual network.
        /// <p>
        /// If no subnets are explicitly specified, a default subnet called "subnet1" covering the
        /// entire first address space will be created.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, a new subnet is added to the network.
        /// </summary>
        /// <param name="name">name the name to assign to the subnet</param>
        /// <param name="cidr">cidr the address space of the subnet, within the address space of the network, using the CIDR notation</param>
        /// <returns>the next stage of the virtual network definition</returns>
        Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet Microsoft.Azure.Management.V2.Network.Network.Definition.IWithSubnet.WithSubnet(string name, string cidr)
        {
            return this.WithSubnet(name, cidr) as Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet;
        }

        /// <summary>
        /// Explicitly defines subnets in the virtual network based on the provided map.
        /// </summary>
        /// <param name="nameCidrPairs">nameCidrPairs a {@link Map} of CIDR addresses for the subnets, indexed by the name of each subnet to be defined</param>
        /// <returns>the next stage of the virtual network definition</returns>
        Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet Microsoft.Azure.Management.V2.Network.Network.Definition.IWithSubnet.WithSubnets(IDictionary<string, string> nameCidrPairs)
        {
            return this.WithSubnets(nameCidrPairs) as Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet;
        }

        /// <summary>
        /// Specifies the IP address of the DNS server to associate with the virtual network.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, a new DNS server is
        /// added to the network
        /// </summary>
        /// <param name="ipAddress">ipAddress the IP address of the DNS server</param>
        /// <returns>the next stage of the virtual network update</returns>
        Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate Microsoft.Azure.Management.V2.Network.Network.Update.IWithDnsServer.WithDnsServer(string ipAddress)
        {
            return this.WithDnsServer(ipAddress) as Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate;
        }

        /// <returns>list of DNS server IP addresses associated with this virtual network</returns>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.V2.Network.INetwork.DnsServerIPs
        {
            get
            {
                return this.DnsServerIPs as System.Collections.Generic.IList<string>;
            }
        }
        /// <returns>subnets of this virtual network as a map indexed by subnet name</returns>
        /// <returns><p>Note that when a virtual network is created with no subnets explicitly defined, a default subnet is</returns>
        /// <returns>automatically created with the name "subnet1".</returns>
        System.Collections.Generic.IDictionary<string, ISubnet> Microsoft.Azure.Management.V2.Network.INetwork.Subnets
        {
            get
            {
                return this.Subnets as System.Collections.Generic.IDictionary<string, ISubnet>;
            }
        }

        /// <returns>list of address spaces associated with this virtual network, in the CIDR notation</returns>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.V2.Network.INetwork.AddressSpaces
        {
            get
            {
                return this.AddressSpaces as System.Collections.Generic.IList<string>;
            }
        }
        /// <summary>
        /// Explicitly adds an address space to the virtual network.
        /// <p>
        /// If no address spaces are explicitly specified, a default address space with the CIDR "10.0.0.0/16" will be
        /// assigned to the virtual network.
        /// <p>
        /// Note that this method's effect is additive, i.e. each time it is used, a new address space is added to the network.
        /// This method does not check for conflicts or overlaps with other address spaces. If there is a conflict,
        /// a cloud exception may be thrown at the time the network is created.
        /// </summary>
        /// <param name="cidr">cidr the CIDR representation of the address space</param>
        /// <returns>the next stage of the virtual network definition</returns>
        Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreate.WithAddressSpace(string cidr)
        {
            return this.WithAddressSpace(cidr) as Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet;
        }

        /// <summary>
        /// Specifies the IP address of an existing DNS server to associate with the virtual network.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, a new dns server is added
        /// to the network.
        /// </summary>
        /// <param name="ipAddress">ipAddress the IP address of the DNS server</param>
        /// <returns>the next stage of the virtual network definition</returns>
        Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreate.WithDnsServer(string ipAddress)
        {
            return this.WithDnsServer(ipAddress) as Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreate;
        }

    }
}