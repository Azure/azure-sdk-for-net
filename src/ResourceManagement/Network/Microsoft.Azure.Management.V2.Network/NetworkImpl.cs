// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.V2.Network
{
    using Management.Network.Models;
    using System.Collections.Generic;
    using Resource.Core;
    using Management.Network;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for Network
    /// </summary>
    public partial class NetworkImpl :
        GroupableParentResource<INetwork,
            VirtualNetworkInner,
            Rest.Azure.Resource,
            NetworkImpl,
            NetworkManager,
            Network.Definition.IWithGroup,
            Network.Definition.IWithCreate,
            Network.Definition.IWithCreate,
            Network.Update.IUpdate>,
        INetwork,
        Network.Definition.IDefinition,
        Network.Update.IUpdate
    {
        private IVirtualNetworksOperations innerCollection;
        private IDictionary<string,Microsoft.Azure.Management.V2.Network.ISubnet> subnets;
        internal NetworkImpl(
            string name, 
            VirtualNetworkInner innerModel, 
            IVirtualNetworksOperations innerCollection, 
            NetworkManager networkManager) : base(name, innerModel, networkManager)
        {

            //$ final VirtualNetworkInner innerModel,
            //$ final VirtualNetworksInner innerCollection,
            //$ final NetworkManager networkManager) {
            //$ super(name, innerModel, networkManager);
            //$ this.innerCollection = innerCollection;
            //$ }

        }

        override protected void InitializeChildrenFromInner ()
        {

            //$ this.subnets = new TreeMap<>();
            //$ List<SubnetInner> inners = this.inner().subnets();
            //$ if (inners != null) {
            //$ for (SubnetInner inner : inners) {
            //$ SubnetImpl subnet = new SubnetImpl(inner, this);
            //$ this.subnets.put(inner.name(), subnet);
            //$ }
            //$ }

        }

        public override INetwork Refresh()
        {
            var response = this.innerCollection.Get(this.ResourceGroupName, this.Name);
            SetInner(response);
            return this;
        }

        internal NetworkImpl WithSubnet (SubnetImpl subnet)
        {

            //$ this.subnets.put(subnet.name(), subnet);
            //$ return this;
            //$ }

            return this;
        }

        internal NetworkManager Manager
        {
            get
            {
            //$ return super.myManager;
            //$ }


                return null;
            }
        }
        public NetworkImpl WithDnsServer (string ipAddress)
        {

            //$ this.inner().dhcpOptions().dnsServers().add(ipAddress);
            //$ return this;

            return this;
        }

        public NetworkImpl WithSubnet (string name, string cidr)
        {

            //$ return this.defineSubnet(name)
            //$ .withAddressPrefix(cidr)
            //$ .attach();

            return this;
        }

        public NetworkImpl WithSubnets (IDictionary<string,string> nameCidrPairs)
        {

            //$ this.subnets.clear();
            //$ for (Entry<String, String> pair : nameCidrPairs.entrySet()) {
            //$ this.withSubnet(pair.getKey(), pair.getValue());
            //$ }
            //$ return this;

            return this;
        }

        public NetworkImpl WithoutSubnet (string name)
        {

            //$ this.subnets.remove(name);
            //$ return this;

            return this;
        }

        public NetworkImpl WithAddressSpace (string cidr)
        {

            //$ this.inner().addressSpace().addressPrefixes().add(cidr);
            //$ return this;

            return this;
        }

        public SubnetImpl DefineSubnet (string name)
        {

            //$ SubnetInner inner = new SubnetInner()
            //$ .withName(name);
            //$ return new SubnetImpl(inner, this);

            return null;
        }

        public List<string> AddressSpaces
        {
            get
            {
            //$ return Collections.unmodifiableList(this.inner().addressSpace().addressPrefixes());


                return null;
            }
        }
        public List<string> DnsServerIPs
        {
            get
            {
            //$ return Collections.unmodifiableList(this.inner().dhcpOptions().dnsServers());


                return null;
            }
        }
        public IDictionary<string,Microsoft.Azure.Management.V2.Network.ISubnet> Subnets ()
        {

            //$ return Collections.unmodifiableMap(this.subnets);

            return null;
        }

        override protected void BeforeCreating ()
        {

            //$ // Ensure address spaces
            //$ if (this.addressSpaces().size() == 0) {
            //$ this.withAddressSpace("10.0.0.0/16");
            //$ }
            //$ 
            //$ if (isInCreateMode()) {
            //$ // Create a subnet as needed, covering the entire first address space
            //$ if (this.subnets.size() == 0) {
            //$ this.withSubnet("subnet1", this.addressSpaces().get(0));
            //$ }
            //$ }
            //$ 
            //$ // Reset and update subnets
            //$ this.inner().withSubnets(innersFromWrappers(this.subnets.values()));

        }

        override protected void AfterCreating ()
        {

            //$ initializeChildrenFromInner();

        }

        public SubnetImpl UpdateSubnet (string name)
        {

            //$ return (SubnetImpl) this.subnets.get(name);

            return null;
        }

        override protected Task<VirtualNetworkInner> CreateInner()
        {
            //$ return this.innerCollection.createOrUpdateAsync(this.resourceGroupName(), this.name(), this.inner());

                return null;
        }
    }
}