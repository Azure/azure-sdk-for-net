// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Update;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Management.Network;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for {@link NetworkSecurityGroup} and its create and update interfaces.
    /// </summary>
    public partial class NetworkSecurityGroupImpl :
        GroupableParentResource<INetworkSecurityGroup,
            NetworkSecurityGroupInner,
            Rest.Azure.Resource,
            NetworkSecurityGroupImpl,
            INetworkManager,
            NetworkSecurityGroup.Definition.IWithGroup,
            NetworkSecurityGroup.Definition.IWithCreate,
            NetworkSecurityGroup.Definition.IWithCreate,
            IUpdate>,
        INetworkSecurityGroup,
        IDefinition,
        IUpdate
    {
        private INetworkSecurityGroupsOperations innerCollection;
        private IDictionary<string,Microsoft.Azure.Management.V2.Network.INetworkSecurityRule> rules;
        private IDictionary<string,Microsoft.Azure.Management.V2.Network.INetworkSecurityRule> defaultRules;
        internal  NetworkSecurityGroupImpl(
            string name, 
            NetworkSecurityGroupInner innerModel, 
            INetworkSecurityGroupsOperations innerCollection, 
            NetworkManager networkManager) : base(name, innerModel, networkManager)
        {

            //$ final String name,
            //$ final NetworkSecurityGroupInner innerModel,
            //$ final NetworkSecurityGroupsInner innerCollection,
            //$ final NetworkManager networkManager) {
            //$ super(name, innerModel, networkManager);
            //$ this.innerCollection = innerCollection;
            //$ }

        }

        override protected void InitializeChildrenFromInner ()
        {

            //$ this.rules = new TreeMap<>();
            //$ List<SecurityRuleInner> inners = this.inner().securityRules();
            //$ if (inners != null) {
            //$ for (SecurityRuleInner inner : inners) {
            //$ this.rules.put(inner.name(), new NetworkSecurityRuleImpl(inner, this));
            //$ }
            //$ }
            //$ 
            //$ this.defaultRules = new TreeMap<>();
            //$ inners = this.inner().defaultSecurityRules();
            //$ if (inners != null) {
            //$ for (SecurityRuleInner inner : inners) {
            //$ this.defaultRules.put(inner.name(), new NetworkSecurityRuleImpl(inner, this));
            //$ }
            //$ }

        }

        public NetworkSecurityRuleImpl UpdateRule (string name)
        {

            //$ return (NetworkSecurityRuleImpl) this.rules.get(name);

            return null;
        }

        public NetworkSecurityRuleImpl DefineRule (string name)
        {

            //$ SecurityRuleInner inner = new SecurityRuleInner();
            //$ inner.withName(name);
            //$ inner.withPriority(100); // Must be at least 100
            //$ return new NetworkSecurityRuleImpl(inner, this);

            return null;
        }

        override public Task<INetworkSecurityGroup> Refresh ()
        {

            //$ NetworkSecurityGroupInner response = this.innerCollection.get(this.resourceGroupName(), this.name());
            //$ this.setInner(response);
            //$ initializeChildrenFromInner();
            //$ return this;

            return null;
        }

        public List<Microsoft.Azure.Management.V2.Network.ISubnet> ListAssociatedSubnets ()
        {

            //$ final List<SubnetInner> subnetRefs = this.inner().subnets();
            //$ final Map<String, Network> networks = new HashMap<>();
            //$ final List<Subnet> subnets = new ArrayList<>();
            //$ 
            //$ if (subnetRefs != null) {
            //$ for (SubnetInner subnetRef : subnetRefs) {
            //$ String networkId = ResourceUtils.parentResourcePathFromResourceId(subnetRef.id());
            //$ Network network = networks.get(networkId);
            //$ if (network == null) {
            //$ network = this.myManager.networks().getById(networkId);
            //$ networks.put(networkId, network);
            //$ }
            //$ 
            //$ String subnetName = ResourceUtils.nameFromResourceId(subnetRef.id());
            //$ subnets.add(network.subnets().get(subnetName));
            //$ }
            //$ }
            //$ 
            //$ return Collections.unmodifiableList(subnets);

            return null;
        }

        public IUpdate WithoutRule (string name)
        {

            //$ this.rules.remove(name);
            //$ return this;

            return null;
        }

        internal NetworkSecurityGroupImpl WithRule (NetworkSecurityRuleImpl rule)
        {

            //$ this.rules.put(rule.name(), rule);
            //$ return this;
            //$ }

            return this;
        }

        public IDictionary<string,Microsoft.Azure.Management.V2.Network.INetworkSecurityRule> SecurityRules ()
        {

            //$ return Collections.unmodifiableMap(this.rules);

            return null;
        }

        public IDictionary<string,Microsoft.Azure.Management.V2.Network.INetworkSecurityRule> DefaultSecurityRules ()
        {

            //$ return Collections.unmodifiableMap(this.defaultRules);

            return null;
        }

        public List<string> NetworkInterfaceIds
        {
            get
            {
            //$ List<String> ids = new ArrayList<>();
            //$ if (this.inner().networkInterfaces() != null) {
            //$ for (NetworkInterfaceInner inner : this.inner().networkInterfaces()) {
            //$ ids.add(inner.id());
            //$ }
            //$ }
            //$ return Collections.unmodifiableList(ids);


                return null;
            }
        }
        override protected void BeforeCreating ()
        {

            //$ // Reset and update subnets
            //$ this.inner().withSecurityRules(innersFromWrappers(this.rules.values()));

        }

        override protected void AfterCreating ()
        {
        }

        override protected Task<NetworkSecurityGroupInner> CreateInner()
        {
            //$ return this.innerCollection.createOrUpdateAsync(this.resourceGroupName(), this.name(), this.inner());


                return null;
        }
    }
}